using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormPlanStockWork :FormChild
    {
        DataTable tableQuery,tableQueryView;
        CarpenterEntity.PlanStockWorkPSWEntity _modelPSW=null;
        CarpenterEntity.PlanStockWorkPSXEntity _modelPSX=null;
        CarpenterBll.Bll.PlanStockWorkBll _bll=null;
        bool isOk=false;string state=string.Empty;
        List<string> bodyList=new List<string>();
        
        public FormPlanStockWork ( )
        {
            InitializeComponent ( );

            _modelPSW = new CarpenterEntity . PlanStockWorkPSWEntity ( );
            _modelPSX = new CarpenterEntity . PlanStockWorkPSXEntity ( );
            _bll = new CarpenterBll . Bll . PlanStockWorkBll ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] {toolAdd } );

            
            //SetImage . setImage ( Concell1 . pictureBox1 ,"zhuxiao.png" );
            //Concell1 . Hide ( );
            //SetImage . setImage ( Concell2 . pictureBox1 ,"shenhe.png" );
            //Concell2 . Hide ( );

            wait . Hide ( );

            splitContainerControl1 . Panel1 . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;

            dtpPlan . Text = dtpOrder . Text = dateTimePicker2 . Text = CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyy年MM月dd日" );
        }
        
        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;

            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "备料日计划查询" ,"FormPlanStockWork" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                _modelPSW . PSW001 = _modelPSX . PSX001 = from . GetBLOddNum;
                _modelPSW . PSW002 = from . GetWorkShop;

                wait . Show ( );
                backgroundWorker1 . RunWorkerAsync ( );
            }
            else
                toolQuery . Enabled = true;

            return base . Query ( );
        }
        protected override int Edit ( )
        {
            splitContainerControl1 . Panel1 . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;

            editTool ( );

            return base . Edit ( );
        }
        protected override int Delete ( )
        {
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "工段不可为空" );
                return 0;
            }
            _modelPSW . PSW001 = texBatchNum . Tag . ToString ( );
            _modelPSW . PSW002 = texBatchNum . Text;
            _modelPSW . PSW003 = Convert . ToDateTime ( dtpPlan . Text );

            if ( _bll . Exists_BG ( _modelPSW . PSW001 ) )
            {
                XtraMessageBox . Show ( "此单已经有产品报工,请先删除报工记录" );
                return 0;
            }

            isOk = _bll . Delete ( _modelPSW . PSW001 ,_modelPSW . PSW002,_modelPSW . PSW003 );
            if ( isOk == true )
            {
                XtraMessageBox . Show ( "删除成功" );

                clear ( );
                splitContainerControl1 . Panel1 . Enabled = false;
                gridView1 . OptionsBehavior . Editable = false;

                deleteTool ( );

                tableQuery = null;
                tableQueryView = null;
                gridControl1 . DataSource = tableQueryView;

                Graph . gra ( splitContainerControl1 ,"反" );
                splitContainerControl1 . Panel1 . Refresh ( );
            }
            else
                XtraMessageBox . Show ( "删除失败,请重试" );

            return base . Delete ( );
        }
        protected override int Cancellation ( )
        {
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "工段不可为空" );
                return 0;
            }
            _modelPSW . PSW001 = texBatchNum . Tag . ToString ( );
            if ( toolCancellation . Caption . Equals ( "注销" ) )
            {
                state = "注销";
                _modelPSW . PSW005 = true;
            }
            else
            {
                state = "反注销";
                _modelPSW . PSW005 = false;
            }
            isOk = _bll . Concell ( _modelPSW . PSW001 ,_modelPSW . PSW005 );
            if ( isOk == true )
            {
                XtraMessageBox . Show ( "" + state + "成功" );
                if ( state . Equals ( "注销" ) )
                {
                    Graph . gra ( splitContainerControl1 ,"注销" );
                    //Concell1 . Show ( );
                }
                else
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
                XtraMessageBox . Show ( "工段不可为空" );
                return 0;
            }
            _modelPSW . PSW001 = texBatchNum . Tag . ToString ( );
            if ( toolExamin . Caption . Equals ( "审核" ) )
            {
                state = "审核";
                _modelPSW . PSW006 = true;
            }
            else
            {
                state = "反审核";
                _modelPSW . PSW006 = false;
            }

            isOk = _bll . Examin ( _modelPSW . PSW001 ,this . Name ,UserLogin . userName ,UserLogin . userNum ,_modelPSW . PSW006 );
            if ( isOk == true )
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
        protected override int Review ( )
        {
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "工段不可为空" );
                return 0;
            }
            _modelPSW . PSW001 = texBatchNum . Tag . ToString ( );
            Review ( _modelPSW . PSW001 ,this . Name );

            return base . Review ( );
        }
        protected override int Save ( )
        {
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "工段不可为空" );
                return 0;
            }
            gridView1 . CloseEditor ( );

            if ( checkError ( ) == false )
                return 0;

            gridView1 . UpdateCurrentRow ( );

            assign ( );

            wait . Show ( );
            backgroundWorker2 . RunWorkerAsync ( );

            return base . Save ( );
        }
        protected override int Cancel ( )
        {
            splitContainerControl1 . Panel1 . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;
            cancelTool ( "edit" );

            return base . Cancel ( );
        }
        DataTable printOne,printTwo;
        protected override int Print ( )
        {
            if ( printOrExport ( ) == false )
                return 0;

            Print ( new DataTable [ ] { printOne ,printTwo } ,"备料车间生产日计划.frx" );

            return base . Print ( );
        }
        protected override int Export ( )
        {
            if ( printOrExport ( ) == false )
                return 0;

            Export ( new DataTable [ ] { printOne ,printTwo } ,"备料车间生产日计划.frx" );

            return base . Export ( );
        }
        bool printOrExport ( )
        {
            //if ( Concell2 . Visible==false )
            //{
            //    XtraMessageBox . Show ( "非审核单据,不允许打印或导出" );
            //    return false;
            //}

            if ( string . IsNullOrEmpty (texBatchNum.Text ) )
            {
                XtraMessageBox . Show ( "工作不可为空" );
                return false;
            }
            printOne = _bll . printOne ( _modelPSW . PSW001 );
            printOne . TableName = "TableOne";
            printTwo = _bll . printTwo ( _modelPSW . PSW001 );
            printTwo . TableName = "TableTwo";

            return true;
        }
        #endregion
        
        #region Event
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            tableQuery = _bll . GetDataTableOne ( _modelPSW . PSW001 ,_modelPSW . PSW002 );
            tableQueryView = _bll . GetDataTableTwo ( _modelPSX . PSX001 );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                toolQuery . Enabled = true;

                if ( tableQuery != null && tableQuery . Rows . Count > 0 )
                {
                    //Concell1 . Hide ( );
                    //Concell2 . Hide ( );


                    texBatchNum . Text = tableQuery . Rows [ 0 ] [ "PSW002" ] . ToString ( );
                    texBatchNum . Tag = tableQuery . Rows [ 0 ] [ "PSW001" ];

                    if ( !string . IsNullOrEmpty ( tableQuery . Rows [ 0 ] [ "PSW003" ] . ToString ( ) ) )
                        dtpPlan . Text = tableQuery . Rows [ 0 ] [ "PSW003" ] . ToString ( );
                    if ( !string . IsNullOrEmpty ( tableQuery . Rows [ 0 ] [ "PSW004" ] . ToString ( ) ) )
                        dtpOrder . Text = tableQuery . Rows [ 0 ] [ "PSW004" ] . ToString ( );
                    texOver . Text = string . IsNullOrEmpty ( tableQuery . Rows [ 0 ] [ "PSW009" ] . ToString ( ) ) == true ? 0 + "%" : Convert . ToDecimal ( tableQuery . Rows [ 0 ] [ "PSW009" ] . ToString ( ) ) . ToString ( ) + "%";
                    dateTimePicker2 . Text = string . IsNullOrEmpty ( tableQuery . Rows [ 0 ] [ "PSW010" ] . ToString ( ) ) == true ? DateTime . Now . ToString ( "yyyy年MM月dd日" ) : tableQuery . Rows [ 0 ] [ "PSW010" ] . ToString ( );
                    //completionRate ( );
                    _modelPSW . PSW005 = ( bool ) tableQuery . Rows [ 0 ] [ "PSW005" ];
                    if ( _modelPSW . PSW005 == true )
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
                    _modelPSW . PSW006 = ( bool ) tableQuery . Rows [ 0 ] [ "PSW006" ];
                    if ( _modelPSW . PSW006 == true )
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

                    if ( _modelPSW . PSW006 == false && _modelPSW . PSW005 == false )
                        Graph . gra ( splitContainerControl1 ,"反" );
                    splitContainerControl1 . Panel1 . Refresh ( );
                    QueryTool ( );
                }

                gridControl1 . DataSource = tableQueryView;
                assignSum ( );
            }
        }
        private void backgroundWorker2_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            isOk = _bll . Edit ( _modelPSW ,tableQueryView ,bodyList );
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                if ( isOk == true )
                {
                    XtraMessageBox . Show ( "保存成功" );
                    saveTool ( );
                    splitContainerControl1 . Panel1 . Enabled = false;
                    gridView1 . OptionsBehavior . Editable = false;
                }
                else
                    XtraMessageBox . Show ( "保存失败" );
            }
        }
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridControl1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( toolSave . Visibility == DevExpress . XtraBars . BarItemVisibility . Never )
                return;
            DataRow row = gridView1 . GetFocusedDataRow ( );
            //int num = gridView1 . FocusedRowHandle;
            //Enter
            if ( e . KeyChar == 13 )
            {
                if ( row != null )
                {
                    _modelPSX . PSX003 = row [ "PSX003" ] . ToString ( );
                    _modelPSX . PSX004 = row [ "PSX004" ] . ToString ( );

                    if ( _bll . Exists ( _modelPSW . PSW001 ,_modelPSX . PSX003 ,_modelPSX . PSX004 ) )
                    {
                        XtraMessageBox . Show ( "此产品已经报工,不允许删除" );
                        return;
                    }

                    if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                        return;
                    bodyList . Add ( row [ "idx" ] . ToString ( ) );
                    tableQueryView . Rows . Remove ( row );
                    gridControl1 . RefreshDataSource ( );
                }
            }
        }
        private void gridView1_CellValueChanged ( object sender ,DevExpress . XtraGrid . Views . Base . CellValueChangedEventArgs e )
        {
            if ( e . Column . Name == "PSX007" )
            {
                assignSum ( );
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
        void assign ( )
        {
            _modelPSW . PSW001 = texBatchNum . Tag . ToString ( );
            _modelPSW . PSW002 = texBatchNum . Text;
            _modelPSW . PSW003 = Convert . ToDateTime ( dtpPlan . Text );
            _modelPSW . PSW004 = Convert . ToDateTime ( dtpOrder . Text );
            _modelPSW . PSW008 = UserLogin . userName;
            _modelPSW . PSW009 = Convert . ToDecimal ( texOver . Text . Split ( '%' ) [ 0 ] );
            _modelPSW . PSW010 = Convert . ToDateTime ( dateTimePicker2 . Text );
        }
        /*void completionRate ( )
        {
            if ( !string . IsNullOrEmpty ( texBatchNum . Tag . ToString ( ) ) )
            {
                DataTable dt = _bll . completionRate ( texBatchNum . Tag . ToString ( ) );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    if ( !string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PSW003" ] . ToString ( ) ) )
                        dateTimePicker2 . Value = Convert . ToDateTime ( dt . Rows [ 0 ] [ "PSW003" ] . ToString ( ) );
                    if ( !string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "CO" ] . ToString ( ) ) )
                        texOver . Text = dt . Rows [ 0 ] [ "CO" ] . ToString ( );
                }
            }
        }
        */
        bool checkError ( )
        {
            isOk = true;
            if ( gridView1 . DataRowCount > 0 )
            {
                DataRow row;
                for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
                {
                    row = gridView1 . GetDataRow ( i );

                    _modelPSX . PSX002 = row [ "PSX002" ] . ToString ( );
                    _modelPSX . PSX006 = string . IsNullOrEmpty ( row [ "PSX006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PSX006" ] . ToString ( ) );
                    _modelPSX . PSX007 = string . IsNullOrEmpty ( row [ "PSX007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PSX007" ] . ToString ( ) );
                    row . ClearErrors ( );
                    if ( _modelPSX . PSX007 > _modelPSX . PSX006 )
                    {
                        row . SetColumnError ( "PSX007" ,"计划数量多于订单数量" );
                        isOk = false;
                        break;
                    }

                    if ( _modelPSX . PSX007 < 1 )
                    {
                        row . SetColumnError ( "PSX007" ,"计划数量须大于零" );
                        isOk = false;
                        break;
                    }

                    if ( string . IsNullOrEmpty ( _modelPSX . PSX002 ) )
                    {
                        row . SetColumnError ( "PSX002" ,"完工状态不可为空" );
                        isOk = false;
                        break;
                    }

                }
            }

            return isOk;
        }
        void assignSum ( )
        {
            decimal nums = 0, outPutValue = 0, sumValue = 0;
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                nums = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "PSX007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "PSX007" ] . ToString ( ) );
                outPutValue = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "OPI004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "OPI004" ] . ToString ( ) );
                sumValue += nums * outPutValue;
            }
            sumValue = Math . Round ( sumValue ,4 );
            OPI004 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,sumValue . ToString ( ) );
        }
        void clear ( )
        {
            texBatchNum . Text = texOver . Text = string . Empty;
            dtpOrder . Text = dtpPlan . Text = dateTimePicker2 . Text = CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyy年MM月dd日" );
        }
        #endregion

    }
}




/* 
注：
1、总产值按照计划数量计算
2、完成率保留两位小数
*/
