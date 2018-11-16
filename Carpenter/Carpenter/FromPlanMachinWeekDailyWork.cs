using Carpenter . Query;
using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FromPlanMachinWeekDailyWork :FormChild
    {
        CarpenterBll.Bll.PlanMachinWeekDailyWorkBll _bll=null;
        string strWhere="1=1";DataTable tableView,printOne,printTwo;
         
        public FromPlanMachinWeekDailyWork ( )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . PlanMachinWeekDailyWorkBll ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave ,toolCancellation ,toolExamin ,toolReview ,toolEdit ,toolAdd } );

            toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;

            wait . Hide ( );

            lupOddNum . Properties . DataSource = _bll . GetOnly ( "PME001" );
            lupOddNum . Properties . DisplayMember = "PME001";
            lupPn . Properties . DataSource = _bll . GetOnly ( "PME002" );
            lupPn . Properties . DisplayMember = "PME002";
            lupProN . Properties . DataSource = _bll . GetOnly ( "PME003" );
            lupProN . Properties . DisplayMember = "PME003";
        }
        
        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;

            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupOddNum . Text ) )
                strWhere = strWhere + " AND PME001='" + lupOddNum . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPn . Text ) )
                strWhere = strWhere + " AND PME002='" + lupPn . Text + "'";
            if ( !string . IsNullOrEmpty ( lupProN . Text ) )
                strWhere = strWhere + " AND PME003='" + lupProN . Text + "'";

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Delete ( )
        {
            if ( gridView1 . RowCount < 1 )
            {
                XtraMessageBox . Show ( "请查询需要删除的内容" );
                return 0;
            }
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            List<string> strList = new List<string> ( );
            CarpenterEntity . PlanMachinWeekDailyWorkEntity _model = new CarpenterEntity . PlanMachinWeekDailyWorkEntity ( );
            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
            {
                _model . idx = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                strList . Add ( _model . idx . ToString ( ) );
            }

            if ( strList . Count < 1 )
                return 0;
            bool result = _bll . Delete ( strList );
            if ( result )
            {
                XtraMessageBox . Show ( "成功删除" );
                Query ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        protected override int Print ( )
        {
            if ( printOrExport ( ) == false )
                return 0;
            Print ( new DataTable [ ] { printOne ,printTwo } ,"机加工周计划报工打印.frx" );

            return base . Print ( );
        }
        protected override int Export ( )
        {
            if ( printOrExport ( ) == false )
                return 0;
            Export ( new DataTable [ ] { printOne ,printTwo } ,"机加工周计划报工打印.frx" );

            return base . Export ( );
        }
        #endregion
        
        #region Event
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            tableView = _bll . GetDataTableView ( strWhere );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );

                toolQuery . Enabled = true;
                gridControl1 . DataSource = tableView;

                toolPrint . Visibility = toolExport . Visibility = toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }
        private void btnClear_Click ( object sender ,System . EventArgs e )
        {
            lupOddNum . EditValue = lupPn . EditValue = lupProN . EditValue = dtOrder . Text = null;
        }
        #endregion

        #region Method
        bool printOrExport ( )
        {

            FormDWPrintWeek from = new FormDWPrintWeek ( "机加工" );
            if ( from . ShowDialog ( ) == System . Windows . Forms . DialogResult . OK )
            {
                string [ ] strArry = from . getStr;
                if ( strArry . Length == 3 )
                {
                    printOne = _bll . GetDataTablePrintOne ( strArry [ 0 ] ,strArry [ 1 ] ,strArry [ 2 ] );
                    printOne . TableName = "TableTwo";
                    printTwo = _bll . GetDataTablePrintTwo ( strArry [ 0 ] ,strArry [ 1 ] ,strArry [ 2 ] );
                    printTwo . TableName = "TableOne";
                }
                else if ( strArry . Length == 2 )
                {
                    printOne = _bll . GetDataTablePrintOne ( strArry [ 0 ] ,strArry [ 1 ] );
                    printOne . TableName = "TableTwo";
                    printTwo = _bll . GetDataTablePrintTwo ( strArry [ 0 ] ,strArry [ 1 ] );
                    printTwo . TableName = "TableOne";
                }

                if ( printOne == null || printOne . Rows . Count < 1 )
                {
                    XtraMessageBox . Show ( "查无数据,请核实" );
                    return false;
                }

                return true;
            }
            return false;
        }
        #endregion

    }
}