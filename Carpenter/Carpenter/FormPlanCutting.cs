using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormPlanCutting :FormChild
    {
        CarpenterEntity.PlanCutCUTEntity _modelCut=new CarpenterEntity.PlanCutCUTEntity();
        CarpenterEntity.PlanCutCUUEntity _modelCuu=new CarpenterEntity.PlanCutCUUEntity();
        CarpenterBll.Bll.PlanCuttingBll _bll=new CarpenterBll.Bll.PlanCuttingBll();
        DataTable dt,tableQueryOne,tableQueryTwo; string productNum = string . Empty,state=string.Empty,strWhere=string.Empty;DataRow row;
        bool result=false;
        List<string> strList=new List<string>();
        
        public FormPlanCutting ( )
        {
            InitializeComponent ( );

            //this . Concell1 = new UIControl . UserControlConcell ( "zhuxiao.png" );
            //this . Concell2 = new UIControl . UserControlConcell ( "shenhe.png" );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            wait . Hide ( );
            //SetImage . setImage ( Concell1 . pictureBox1 ,"zhuxiao.png" );
            //Concell1 . Hide ( );
            //SetImage . setImage ( Concell2 . pictureBox1 ,"shenhe.png" );
            //Concell2 . Hide ( );
            //SetImage . setImageDev ( Concell3 .pictureEdit1 ,"shenhe.png" );            
            //Concell3 . Hide ( );
            //pictureBox1 . Visible = false;

            splitContainerControl1 . Panel1 . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;

            dateTimePicker1 . Text = dateTimePicker2 . Text = dateTimePicker3 . Text = CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyy年MM月dd日" );
        }
        
        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;
            toolAdd . Enabled = false;

            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "开料生产周计划产品选择" ,"FormPlanCutQuery" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . Cancel )
            {
                toolQuery . Enabled = true;
                toolAdd . Enabled = true;
                return 0;
            }
            _modelCut . CUT001 = from . GetBarchNum;
            strWhere = _modelCut . CUT001;

            wait . Show ( );
            backgroundWorker2 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Add ( )
        {
            clear ( );
            splitContainerControl1 . Panel1 . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;

            addTool ( );

            Graph . gra ( splitContainerControl1 ,"反" );
            splitContainerControl1 . Panel1 . Refresh ( );

            //Concell1 . Hide ( );
            //Concell2 . Hide ( );

            state = "add";

            strWhere = "1=2";
            tableQueryTwo = _bll . GetDataTableQueryTwo ( strWhere );
            gridControl1 . DataSource = tableQueryTwo;

            dateTimePicker1 . Text = dateTimePicker2 . Text = dateTimePicker3 . Text = CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyy年MM月dd日" );

            return base . Add ( );
        }
        protected override int Edit ( )
        {
            splitContainerControl1 . Panel1 . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;

            editTool ( );

            state = "edit";

            return base . Edit ( );
        }
        protected override int Delete ( )
        {
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "批号不可为空" );
                return 0;
            }
           
            _modelCut . CUT001 = _modelCuu . CUU001 = texBatchNum . Text;


            if ( _bll . ExistsPRS ( _modelCut . CUT001 ) )
            {
                XtraMessageBox . Show ( "跟踪表中已经存在此批号产品,不允许删除","提示" );
                return 0;
            }
            else
            {
                if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                    return 0;
            }

            result = _bll . Delete ( _modelCut . CUT001 );
            if ( result == true )
            {
                XtraMessageBox . Show ( "删除成功" );

                deleteTool ( );

                clear ( );
                tableQueryOne = null;
                tableQueryTwo = null;
                gridControl1 . DataSource = tableQueryTwo;
                splitContainerControl1 . Panel1 . Enabled = false;
                gridView1 . OptionsBehavior . Editable = false;
                //Concell1 . Hide ( );
                //Concell2 . Hide ( );
                Graph . gra ( splitContainerControl1 ,"反" );
                splitContainerControl1 . Panel1 . Refresh ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        protected override int Cancellation ( )
        {
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "批号不可为空" );
                return 0;
            }
            state = toolCancellation . Caption;
            if ( toolCancellation . Caption . Equals ( "注销" ) )
                _modelCut . CUT007 = true;
            else
                _modelCut . CUT007 = false;

            _modelCut . CUT001 =  texBatchNum . Text;         
            result = _bll . Concell ( _modelCut . CUT001 ,_modelCut . CUT007 );
            if ( result == true )
            {
                XtraMessageBox . Show ( "" + state + "成功" );
                if ( state . Equals ( "注销" ) )
                {
                    Graph . gra ( splitContainerControl1 ,"注销" );
                    //Concell1 . Show ( );
                }
                else if ( state . Equals ( "反注销" ) )
                {
                    Graph . gra ( splitContainerControl1 ,"反" );
                    //Concell1 . Hide ( );
                }
                splitContainerControl1 . Panel1 . Refresh ( );
                cancelltionTool ( state );
            }
            else
                XtraMessageBox . Show ( "" + state + "失败" );

            return base . Cancellation ( );
        }
        protected override int Examine ( )
        {
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "批号不可为空" );
                return 0;
            }
            
            state = toolExamin . Caption;
            if ( toolExamin . Caption . Equals ( "审核" ) )
                _modelCut . CUT008 = true;
            else
            {
                _modelCut . CUT008 = false;
                //XtraMessageBox . Show ( "数据已经写入生产部生产跟踪表,不允许反审核" );
                //return 0;
            }
            _modelCut . CUT001 = texBatchNum . Text;
            result = _bll . Examine ( _modelCut . CUT001 ,_modelCut . CUT008 ,tableQueryTwo ,Convert . ToDateTime ( dateTimePicker1 . Text ) ,UserLogin . userName ,this . Name ,UserLogin . userNum );
            if ( result == true )
            {
                XtraMessageBox . Show ( "" + state + "成功" );
                if ( state . Equals ( "审核" ) )
                {
                    Graph . gra ( splitContainerControl1 ,"审核" );
                    //Concell2 . Show ( );
                }
                else if ( state . Equals ( "反审核" ) )
                {
                    Graph . gra ( splitContainerControl1 ,"反" );
                    //Concell2 . Hide ( );
                }

                splitContainerControl1 . Panel1 . Refresh ( );
                examineTool ( state );
            }
            else
                XtraMessageBox . Show ( "" + state + "失败" );

            return base . Examine ( );
        }
        protected override int Save ( )
        {
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "生产批号不可为空" );
                return 0;
            }

            _modelCut . CUT001 = texBatchNum . Text;

            if ( state . Equals ( "add" ) )
            {
                if ( _bll . Exists ( _modelCut . CUT001 ) == true )
                {
                    XtraMessageBox . Show ( "生产批号:" + _modelCut . CUT001 + " 已经存在,请查询编辑" );
                    return 0;
                }

                if ( isnullOrEmpty ( ) == false )
                    return 0;

                _modelCut . CUT007 = false;
                _modelCut . CUT008 = false;
                gridView1 . CloseEditor ( );
                gridView1 . UpdateCurrentRow ( );
                variable ( );

                wait . Show ( );
                backgroundWorker3 . RunWorkerAsync ( );
            }
            else if ( state . Equals ( "edit" ) )
            {
                if ( isnullOrEmpty ( ) == false )
                    return 0;

                _modelCut . idx = Convert . ToInt32 ( texBatchNum . Tag );
                if ( _bll . Exists ( _modelCut . CUT001 ,_modelCut . idx ) == true )
                {
                    XtraMessageBox . Show ( "生产批号:" + _modelCut . CUT001 + "已经存在,请核实" );
                    return 0;
                }
                gridView1 . CloseEditor ( );
                gridView1 . UpdateCurrentRow ( );
                variable ( );

                wait . Show ( );
                backgroundWorker3 . RunWorkerAsync ( );
            }

            return base . Save ( );
        }
        protected override int Cancel ( )
        {
            if ( state .Equals( "add" ))
            {
                clear ( );
                splitContainerControl1 . Panel1 . Enabled = false;
                gridView1 . OptionsBehavior . Editable = false;

                tableQueryOne = null;
                tableQueryTwo = null;
                gridControl1 . DataSource = tableQueryTwo;
            }
            else if ( state .Equals( "edit" ))
            {
                splitContainerControl1 . Panel1 . Enabled = true;
                gridView1 . OptionsBehavior . Editable = false;
            }
            cancelTool ( state );

            return base . Cancel ( );
        }
        protected override int Review ( )
        {
            Review ( texBatchNum . Text ,this . Name );
            return base . Review (  );
        }
        DataTable printOne,printTwo;
        protected override int Print ( )
        {
            if ( checkProductNum ( ) == false )
                return 0;
                    
            if ( strList . Count > 0 )
            {
                wait . Show ( );
                backgroundWorker4 . RunWorkerAsync ( );
            }
            else
            {
                if ( printOrExport ( ) == false )
                    return 0;

                Print ( new DataTable [ ] { printOne ,printTwo } ,"开料生产计划表.frx" );
            }

            return base . Print ( );
        }
        protected override int Export ( )
        {
            if ( checkProductNum ( ) == false )
                return 0;

            if ( strList . Count > 0 )
            {
                wait . Show ( );
                backgroundWorker4 . RunWorkerAsync ( );
            }
            else
            {
                if ( printOrExport ( ) == false )
                    return 0;

                Export ( new DataTable [ ] { printOne ,printTwo } ,"开料生产计划表.frx" );
            }

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
        //Get Product Information
        private void btnObtain_Click ( object sender ,System . EventArgs e )
        {
            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "开料生产周计划产品查询" ,"FormPlanCutting" );
            DialogResult result = from . ShowDialog ( );
            if ( result == System . Windows . Forms . DialogResult . Cancel )
                return;
            List<string> strList = new List<string> ( );
            strList = from . GetstrList;
            productNum = string . Empty;
            foreach ( string str in strList )
            {
                if ( productNum == string . Empty )
                    productNum = "'" + str + "'";
                else
                    productNum += "," + "'" + str + "'";
            }
            strWhere = "";
            strWhere = " OPI001 IN (" + productNum + ")";
            if ( strList . Count < 1 )
                strWhere = "1=2";
            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );
        }
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            dt = _bll . GetDataTableProduct ( strWhere );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                    {
                        _modelCuu . CUU002 = dt . Rows [ i ] [ "OPI001" ] . ToString ( );
                        if ( tableQueryTwo . Select ( "CUU002='" + _modelCuu . CUU002 + "'" ) . Length < 1 )
                        {
                            row = tableQueryTwo . NewRow ( );
                            row [ "CUU002" ] = _modelCuu . CUU002;
                            row [ "CUU003" ] = 0;
                            row [ "CUU004" ] = dateTimePicker3 . Text;
                            row [ "CUU008" ] = dt . Rows [ i ] [ "OPI002" ] . ToString ( );
                            row [ "CUU009" ] = dt . Rows [ i ] [ "OPI005" ] . ToString ( );
                            row [ "OPI003" ] = dt . Rows [ i ] [ "OPI003" ] . ToString ( );
                            row [ "OPI004" ] = dt . Rows [ i ] [ "OPI004" ] . ToString ( );
                            row [ "OPI006" ] = dt . Rows [ i ] [ "OPI006" ] . ToString ( );
                            row [ "OPI007" ] = dt . Rows [ i ] [ "OPI007" ] . ToString ( );
                            tableQueryTwo . Rows . Add ( row );
                        }
                    }
                }
            }
        }
        private void backgroundWorker2_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            tableQueryOne = _bll . GetDataTableQueryOne ( strWhere );
            tableQueryTwo = _bll . GetDataTableQueryTwo ( strWhere );
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                toolQuery . Enabled = true;
                toolAdd . Enabled = true;

                if ( tableQueryOne != null && tableQueryOne . Rows . Count > 0 )
                {
                    texBatchNum.Tag = tableQueryOne . Rows [ 0 ] [ "idx" ] . ToString ( );
                    texBatchNum . Text = tableQueryOne . Rows [ 0 ] [ "CUT001" ] . ToString ( );
                    if ( !string . IsNullOrEmpty ( tableQueryOne . Rows [ 0 ] [ "CUT002" ] . ToString ( ) ) )
                        dateTimePicker1 . Text = tableQueryOne . Rows [ 0 ] [ "CUT002" ] . ToString ( );
                    if ( !string . IsNullOrEmpty ( tableQueryOne . Rows [ 0 ] [ "CUT003" ] . ToString ( ) ) )
                        dateTimePicker2 . Text = tableQueryOne . Rows [ 0 ] [ "CUT003" ] . ToString ( );
                    if ( !string . IsNullOrEmpty ( tableQueryOne . Rows [ 0 ] [ "CUT004" ] . ToString ( ) ) )
                        dateTimePicker3 . Text = tableQueryOne . Rows [ 0 ] [ "CUT004" ] . ToString ( );
                    _modelCut . CUT007 = ( bool ) tableQueryOne . Rows [ 0 ] [ "CUT007" ];

                    if ( _modelCut . CUT007 == true )
                    {
                        Graph . gra ( splitContainerControl1 ,"注销" );
                        //Concell1 . Show ( );
                        toolCancellation . Caption = "反注销";
                    }
                    else
                    {
                        //Concell1 . Hide ( );
                        toolCancellation . Caption = "注销";
                    }
                    _modelCut . CUT008 = ( bool ) tableQueryOne . Rows [ 0 ] [ "CUT008" ];
                    if ( _modelCut . CUT008 == true )
                    {
                        Graph . gra ( splitContainerControl1 ,"审核" );
                        //Concell2 . Show ( );
                        toolExamin . Caption = "反审核";
                    }
                    else
                    {
                        //Concell2 . Hide ( );                
                        toolExamin . Caption = "审核";
                    }

                    if ( _modelCut . CUT007 == false && _modelCut . CUT008 == false )
                        Graph . gra ( splitContainerControl1 ,"反" );
                    splitContainerControl1 . Panel1 . Refresh ( );
                    QueryTool ( );
                    gridControl1 . DataSource = tableQueryTwo;
                    valuesOfAll ( );
                }
            }
        }
        private void gridView1_CellValueChanged ( object sender ,DevExpress . XtraGrid . Views . Base . CellValueChangedEventArgs e )
        {
            if ( e . Column . Name == "CUU003"  )
            {
                valuesOfAll ( );
            }
        }
        private void gridControl1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( toolSave . Visibility == DevExpress . XtraBars . BarItemVisibility . Never )
                return;
            DataRow row = gridView1 . GetFocusedDataRow ( );
            //num = gridView1 . FocusedRowHandle;
            //Enter
            if ( e . KeyChar == 13 )
            {
                if ( row!=null )
                {
                    if ( _bll . ExistsPRS ( _modelCut . CUT001 ,row [ "CUU002" ] . ToString ( ) ) )
                    {
                        XtraMessageBox . Show ( "跟踪表中已经存在此批号产品,不允许删除" ,"提示" );
                        return;
                    }

                    if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                        return;
                    tableQueryTwo . Rows . Remove ( row );
                    gridControl1 . RefreshDataSource ( );
                }
            }
        }
        private void backgroundWorker3_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            if ( state .Equals( "add" ))
                result = _bll . Add ( _modelCut ,tableQueryTwo );
            if ( state .Equals( "edit" ))
                result = _bll . Edit ( _modelCut ,tableQueryTwo );
        }
        private void backgroundWorker3_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                if ( result == true )
                {
                    XtraMessageBox . Show ( "保存成功" );

                   
                    splitContainerControl1 . Panel1 . Enabled = false;
                    gridView1 . OptionsBehavior . Editable = false;

                    try
                    {
                        texBatchNum . Tag = _bll . id ( _modelCut . CUT001 );
                    }
                    catch ( Exception ex )
                    {
                        Utility . LogHelper . WriteException ( ex );
                    }

                    strWhere = texBatchNum . Text;
                    query_where ( );

                    saveTool ( );
                }
                else
                    XtraMessageBox . Show ( "保存失败" );

                
            }
        }
        private void backgroundWorker4_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            result = _bll . GenerateCodeAndPrint ( strList ,texBatchNum . Text );
        }
        private void backgroundWorker4_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );

                if ( result )
                {
                    if ( CarpenterBll . UserInformation . StrList == null )
                    {
                        Carpenter . Query . FormPrintBoms from = new Carpenter . Query . FormPrintBoms ( "BOM打印" ,strList ,texBatchNum . Text );
                        from . ShowDialog ( );
                    }
                    else
                    {
                        if ( CarpenterBll . UserInformation . StrList . Count > 0 )
                        {
                            string str = "以下品号不存在BOM基础资料:";
                            foreach ( string s in CarpenterBll . UserInformation . StrList )
                            {
                                str = str + "\n\r" + s;
                            }
                            if ( XtraMessageBox . Show ( str ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                                return;

                            Carpenter . Query . FormPrintBoms from = new Carpenter . Query . FormPrintBoms ( "BOM打印" ,strList ,texBatchNum . Text );
                            from . ShowDialog ( );
                        }
                        else
                        {
                            Carpenter . Query . FormPrintBoms from = new Carpenter . Query . FormPrintBoms ( "BOM打印" ,strList ,texBatchNum . Text );
                            from . ShowDialog ( );
                        }
                    }
                }
                else
                    XtraMessageBox . Show ( "打印清单、传票失败,请查看操作日志" );
            }
        }
        protected override void OnClosing ( CancelEventArgs e )
        {
            if ( toolSave . Visibility == DevExpress . XtraBars . BarItemVisibility . Always )
            {
                if ( XtraMessageBox . Show ( "是否保存?" ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
                {
                    Save ( );
                    e . Cancel = true;
                }
            }
            base . OnClosing ( e );
        }
        #endregion

        #region Method
        void variable ( )
        {
            _modelCut . CUT001 = texBatchNum . Text;
            _modelCut . CUT002 = Convert . ToDateTime ( dateTimePicker1 . Text );
            _modelCut . CUT003 = Convert . ToDateTime ( dateTimePicker2 . Text );
            _modelCut . CUT004 = Convert . ToDateTime ( dateTimePicker3 . Text );
            _modelCut . CUT005 = DateTime . Now;
            _modelCut . CUT006 = UserLogin . userName;
        }
        bool isnullOrEmpty ( )
        {
            result = true;
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                if ( string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "CUU003" ] . ToString ( ) ) )
                {
                    XtraMessageBox . Show ( "产品数量不可为空" );
                    result = false;
                    break;
                }
                if ( string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "CUU004" ] . ToString ( ) ) )
                {
                    XtraMessageBox . Show ( "下料计划完成时间不可为空" );
                    result = false;
                    break;
                }
            }

            return result;
        }
        void query_where ( )
        {
            tableQueryTwo = _bll . GetDataTableQueryTwo ( strWhere );
            gridControl1 . DataSource = tableQueryTwo;
        }
        void valuesOfAll ( )
        {
            decimal dOne = 0M, dTwo = 0M, dSum = 0M;
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                dOne = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "CUU003" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "CUU003" ] . ToString ( ) );
                dTwo = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "OPI004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "OPI004" ] . ToString ( ) );
                dSum += dOne * dTwo;
            }
            dSum = Math . Round ( dSum ,4 );
            OPI004 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dSum . ToString ( ) );
            texValue . Text = dSum . ToString ( );
        }
        bool printOrExport ( )
        {
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "生产批号不可为空" );
                return false;
            }
            printOne = _bll . printOne ( _modelCut . CUT001 );
            printOne . TableName = "TableOne";
            printTwo = _bll . printTwo ( _modelCut . CUT001 );
            printTwo . TableName = "TableTwo";

            return true;
        }
        bool printOrExportBOM ( )
        {
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "生产批号不可为空" );
                return false;
            }

            return true;
        }
        bool checkProductNum ( )
        {
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "生产批号不可为空" );
                return false;
            }
            strList . Clear ( );
            if ( gridView1 . DataRowCount > 0 )
            {
                int [ ] x = gridView1 . GetSelectedRows ( );
                foreach ( int y in x )
                {
                    DataRow row = gridView1 . GetDataRow ( y );
                    _modelCuu . CUU002 = row [ "CUU002" ] . ToString ( );
                    strList . Add ( _modelCuu . CUU002 );
                }
            }

            return true;
        }
        void clear ( )
        {
            texBatchNum . Text = texValue . Text = string . Empty;
            dateTimePicker1 . Text = dateTimePicker2 . Text = dateTimePicker3 . Text = CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyy年MM月dd日" );
        }
        #endregion

    }
}

/*
 * 1.同生产批号、同品号只能生成一次
 * 2.审核生成生产部生产跟踪进度表、备料(机加工)车间进度跟踪表、组装车间进度跟踪表、油漆车间进度跟踪表
 * 3.不允许反审核
     */

