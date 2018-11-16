using DevExpress . XtraPrinting;
using DevExpress . XtraPrintingLinks;
using System;
using System . Data;
using System . Reflection;
using System . Windows . Forms;
using DevExpress . XtraCharts;
using System . IO;
using System . Linq;
using System . Collections . Generic;

namespace Carpenter
{
    public partial class FormSchedul :FormChild
    {
        CarpenterBll.Bll.SchedulBll _bll=null;
        DataTable tableView,table,tableOne,tableQueryView;
        
        public FormSchedul ( )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . SchedulBll ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            
            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave ,toolPrint ,toolCancellation ,toolExamin ,toolReview ,toolDelete ,toolEdit ,toolAdd } );

            wait . Hide ( );
        }
        
        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;
            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Export ( )
        {
            //1、方法一导出
            //DevExpress . XtraGrid . Views . Grid . GridView view = gridControl1 . MainView as DevExpress . XtraGrid . Views . Grid . GridView;
            //if ( view != null )
            //    view . ExportToXls ( "MainViewData.xls" );

            //Process pdfExport = new Process ( );
            ////pdf名称
            //pdfExport . StartInfo . FileName = "JisuPdf.exe";
            ////导出的pdf名称
            //pdfExport . StartInfo . Arguments = "MainViewData.pdf";
            //pdfExport . Start ( );

            //2、方法二导出
            GridControlExport . ExportToExcel ( this . Text ,gridControl1 );
            
            return base . Export ( );
        }
       

        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            tableView = _bll . getTableView ( );
            string previousYear = ( CarpenterBll . UserInformation . dt ( ) . Year - 2 ) . ToString ( ) + "发出量",
                thisYear = ( CarpenterBll . UserInformation . dt ( ) . Year - 1 ) . ToString ( ) + "发出量",
                nextYear = ( CarpenterBll . UserInformation . dt ( ) . Year ) . ToString ( ) + "发出量";
            tableView . Columns . RemoveAt ( 0 );
            if ( tableView != null && tableView . Rows . Count > 0 )
            {
                foreach ( DataRow row in tableView . Rows )
                {
                    row [ 3 ] = decimal . Parse ( row [ 3 ] . ToString ( ) ) . ToString ( "0" );
                    row [ 4 ] = decimal . Parse ( row [ 4 ] . ToString ( ) ) . ToString ( "0" );
                    row [ 5 ] = decimal . Parse ( row [ 5 ] . ToString ( ) ) . ToString ( "0" );
                    row [ 7 ] = decimal . Parse ( row [ 7 ] . ToString ( ) ) . ToString ( "0" );
                    row [ 6 ] = decimal . Parse ( row [ 6 ] . ToString ( ) ) . ToString ( "0" );
                }

                tableOne = _bll . getTableOne ( );

                var query = from t in tableView . AsEnumerable ( )
                            join t1 in tableOne . AsEnumerable ( )
                            on t . Field<string> ( "Fnumber" ) equals t1 . Field<string> ( "FNumber" )
                            select new
                            {
                                品号 = t . Field<string> ( "Fnumber" ) ,
                                品名 = t . Field<string> ( "Fname" ) ,
                                单位 = t . Field<string> ( "FUnit" ) ,
                                previousYear = t . Field<decimal> ( "FQty1" ) ,
                                thisYear = t . Field<decimal> ( "FQty2" ) ,
                                nextYear = t . Field<decimal> ( "FQty3" ) ,
                                库存 = t . Field<decimal> ( "FInvQty" ) ,
                                今天 = t1 . Field<decimal> ( "FQty0" ) ,
                                十天交货 = t1 . Field<decimal> ( "FQty1" ) ,
                                二十天交货 = t1 . Field<decimal> ( "FQty2" ) ,
                                三十天交货 = t1 . Field<decimal> ( "FQty3" ) ,
                                六十天交货 = t1 . Field<decimal> ( "FQty4" ) ,
                                六十天以上 = t1 . Field<decimal> ( "FQty5" ) ,
                                合计 = t1 . Field<decimal> ( "FQY" )
                            };

                tableView = new DataTable ( );
                tableView= ListToTable ( query . ToList ( ) );

                

                table = _bll . getTable ( );
                if ( table != null && table . Rows . Count > 0 )
                {
                    //批次数量合计
                    var result = from t in table . AsEnumerable ( )
                                 group t by new
                                 {
                                     t1 = t . Field<string> ( "CUU002" )
                                 } into m
                                 let sum = m . Sum ( t => t . Field<int> ( "CUU" ) )
                                 select new
                                 {
                                     cuu002 = m . Key . t1 ,
                                     sum = sum
                                 };

                    string column = string . Empty, columnOne = string . Empty, one = string . Empty, two = string . Empty;
                    int iValue = 0;
                    DataRow row;
                    for ( int l = 0 ; l < table . Rows . Count ; l++ )
                    {
                        column = table . Rows [ l ] [ "CUU001" ] . ToString ( );
                        if ( !tableView . Columns . Contains ( column ) )
                            tableView . Columns . Add ( column ,typeof ( System . String ) );

                        one = table . Rows [ l ] [ "CUU002" ] . ToString ( );
                        iValue = string . IsNullOrEmpty ( table . Rows [ l ] [ "CUU" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ l ] [ "CUU" ] . ToString ( ) );
                        for ( int n = 0 ; n < tableView . Rows . Count ; n++ )
                        {
                            row = tableView . Rows [ n ];
                            two = row [ "品号" ] . ToString ( );
                            if ( one . Equals ( two ) )
                            {
                                row [ column ] = iValue;
                            }
                        }
                    }

                    foreach ( var x in result )
                    {
                        columnOne = "批次数量合计";
                        if ( !tableView . Columns . Contains ( columnOne ) )
                            tableView . Columns . Add ( columnOne ,typeof ( System . String ) );
                        one = x . cuu002;
                        for ( int n = 0 ; n < tableView . Rows . Count ; n++ )
                        {
                            row = tableView . Rows [ n ];
                            two = row [ "品号" ] . ToString ( );
                            if ( one . Equals ( two ) )
                            {
                                row [ columnOne ] = x . sum;
                            }
                        }
                    }
                }

                string columnTwo = "余量";
                if ( !tableView . Columns . Contains ( columnTwo ) )
                    tableView . Columns . Add ( columnTwo ,typeof ( System . String ) );
                int total = 0, kucun = 0, sumTotal = 0;
                DataRow rows;
                for ( int n = 0 ; n < tableView . Rows . Count ; n++ )
                {
                    rows = tableView . Rows [ n ];
                    total = string . IsNullOrEmpty ( rows [ "合计" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( rows [ "合计" ] );
                    kucun = string . IsNullOrEmpty ( rows [ "库存" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( rows [ "库存" ] );
                    sumTotal = string . IsNullOrEmpty ( rows [ "批次数量合计" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( rows [ "批次数量合计" ] );
                    rows [ columnTwo ] = kucun - total + sumTotal;
                }

                //tableView . Columns . Add ( "小计" ,typeof ( decimal ) );
                //DataRow rows = tableView . NewRow ( );
                //rows["小计"]=tableView.
            }
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                toolQuery . Enabled = true;
                wait . Hide ( );
                gridControl1 . DataSource = tableView;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }
        #endregion

        #region Method
        /// <summary>  
        /// List集合转DataTable  
        /// </summary>  
        /// <typeparam name="T">实体类型</typeparam>  
        /// <param name="list">传入集合</param>   
        /// <returns>返回datatable结果</returns>  
        public DataTable ListToTable<T> ( List<T> list )
        {
            Type tp = typeof ( T );
            PropertyInfo [ ] proInfos = tp . GetProperties ( );
            DataTable dt = new DataTable ( );
            foreach ( var item in proInfos )
            {
                dt . Columns . Add ( item . Name ,item . PropertyType ); //添加列明及对应类型  
            }
            foreach ( var item in list )
            {
                DataRow dr = dt . NewRow ( );
                foreach ( var proInfo in proInfos )
                {
                    object obj = proInfo . GetValue ( item ,null );
                    if ( obj == null )
                    {
                        continue;
                    }

                    dr [ proInfo . Name ] = obj;
                }
                dt . Rows . Add ( dr );
            }
            return dt;
        }
        #endregion

    }
}