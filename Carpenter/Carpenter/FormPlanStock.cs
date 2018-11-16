using System . Data;
using System . Reflection;
using System . Windows . Forms;
using System;
using DevExpress . XtraEditors;
using System . ComponentModel;

namespace Carpenter
{
    public partial class FormPlanStock :FormChild
    {
        CarpenterEntity.PlanStockPLSEntity _modePLS=new CarpenterEntity.PlanStockPLSEntity();
        CarpenterEntity.PlanStockPLTEntity _modePLT=new CarpenterEntity.PlanStockPLTEntity();

        CarpenterBll.Bll.PlanStockBll _bll=new CarpenterBll.Bll.PlanStockBll();
        DataTable tableQuery,tableQueryView;
        bool result=false;string state=string.Empty;
        
        public FormPlanStock ( )
        {
            InitializeComponent ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolAdd } );

            wait . Hide ( );
            //SetImage . setImage ( Concell1 . pictureBox1 ,"zhuxiao.png" );
            //Concell1 . Hide ( );
            //SetImage . setImage ( Concell2 . pictureBox1 ,"shenhe.png" );
            //Concell2 . Hide ( );

            splitContainerControl1 . Panel1 . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;

            dtpEnd . Text = dtpOrder . Text = dtpStart . Text = CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyy年MM月dd日" );
        }
        
        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;

            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "备料车间生产周计划查询" ,"FormPlanStock" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                _modePLS . PLS001 = _modePLT . PLT001 = from . GetBLOddNum;

                wait . Show ( );
                backgroundWorker1 . RunWorkerAsync ( );
            }else
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
                XtraMessageBox . Show ( "周次不可为空" );
                return 0;
            }

            _modePLS . PLS001 = _modePLT . PLT001 = texBatchNum . Tag . ToString ( );

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            result = _bll . Delete ( _modePLS . PLS001 ,tableQueryView );
            if ( result == true )
            {
                XtraMessageBox . Show ( "成功删除" );

                clear ( );

                //Concell1 . Hide ( );
                //Concell2 . Hide ( );

                Graph . gra ( splitContainerControl1 ,"反" );
                splitContainerControl1 . Panel1 . Refresh ( );

                deleteTool ( );
                tableQuery = null;
                tableQueryView = null;
                gridControl1 . DataSource = tableQueryView;
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        protected override int Review ( )
        {
            if ( texBatchNum . Tag == null || string . IsNullOrEmpty ( texBatchNum . Tag . ToString ( ) ) )
            {
                XtraMessageBox . Show ( "请选择需要送审的内容" );
                return 0;
            }

            Review ( texBatchNum . Tag . ToString ( ) ,this . Name );

            return base . Review ( );
        }
        protected override int Cancellation ( )
        {
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "周次不可为空" );
                return 0;
            }

            if ( toolCancellation . Caption . Equals ( "注销" ) )
            {
                state = "注销";
                _modePLS . PLS008 = true;
            }
            else
            {
                state = "反注销";
                _modePLS . PLS008 = false;
            }

            _modePLS . PLS001 = texBatchNum . Tag . ToString ( );
            result = _bll . Concell ( _modePLS . PLS001 ,_modePLS . PLS008 );
            if ( result == true )
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
            //审核之后  若有批号和品号在日计划  则不允许反审核

            if ( texBatchNum . Tag == null || string . IsNullOrEmpty ( texBatchNum . Tag . ToString ( ) ) )
            {
                XtraMessageBox . Show ( "请选择需要审核的内容" );
                return 0;
            }
            _modePLS.PLS001 = texBatchNum . Tag . ToString ( );
            if ( toolExamin . Caption . Equals ( "审核" ) )
            {
                state = "审核";
                _modePLS . PLS009 = true;
            }
            else
            {
                state = "反审核";
                _modePLS . PLS009 = false;
            }

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            result = _bll . Examin ( _modePLS . PLS001 ,this . Name ,UserLogin . userName ,UserLogin . userNum ,_modePLS . PLS009 ,tableQueryView );
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
                XtraMessageBox . Show ( "周次不可为空" );
                return 0;
            }

            
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );
            if ( checkView ( ) == false )
                return 0;
            assign ( );
            result = _bll . Edit ( _modePLS ,tableQueryView );
            if ( result == true )
            {
                XtraMessageBox . Show ( "保存成功" );

                splitContainerControl1 . Panel1 . Enabled = false;
                gridView1 . OptionsBehavior . Editable = false;

                saveTool ( );
            }
            else
                XtraMessageBox . Show ( "保存失败" );

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
            
            Print ( new DataTable [ ] { printOne ,printTwo } ,"备料车间周计划表.frx" );
            
            return base . Print ( );
        }
        protected override int Export ( )
        {
            if ( printOrExport ( ) == false )
                return 0;

            Export ( new DataTable [ ] { printOne ,printTwo } ,"备料车间周计划表.frx" );

            return base . Export ( );
        }
        bool printOrExport ( )
        {
            if ( toolExamin . Caption . Equals ( "审核" ) )
            {
                XtraMessageBox . Show ( "没有审核的单据不允许打印" );
                return false;
            }

            printOne = _bll . printOne ( _modePLS . PLS001 );
            printOne . TableName = "TableOne";
            printTwo = _bll . printTwo ( _modePLS . PLS001 );
            printTwo . TableName = "TableTwo";

            return true;
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
            tableQuery = _bll . GetDataTableHeader ( _modePLS . PLS001 );
            tableQueryView = _bll . GetDataTableBody ( _modePLT . PLT001 );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                toolQuery . Enabled = true;

                splitContainerControl1 . Panel1 . Enabled = false;
                gridView1 . OptionsBehavior . Editable = false;

                if ( tableQuery != null && tableQuery . Rows . Count > 0 )
                {

                    //Concell1 . Hide ( );
                    //Concell2 . Hide ( );

                    texBatchNum . Text = tableQuery . Rows [ 0 ] [ "PLS002" ] . ToString ( );
                    texBatchNum . Tag = tableQuery . Rows [ 0 ] [ "PLS001" ] . ToString ( );
                    if ( !string . IsNullOrEmpty ( tableQuery . Rows [ 0 ] [ "PLS003" ] . ToString ( ) ) )
                        dtpOrder . Text = tableQuery . Rows [ 0 ] [ "PLS003" ] . ToString ( );
                    if ( !string . IsNullOrEmpty ( tableQuery . Rows [ 0 ] [ "PLS004" ] . ToString ( ) ) )
                        dtpStart . Text = tableQuery . Rows [ 0 ] [ "PLS004" ] . ToString ( );
                    if ( !string . IsNullOrEmpty ( tableQuery . Rows [ 0 ] [ "PLS005" ] . ToString ( ) ) )
                        dtpEnd . Text = tableQuery . Rows [ 0 ] [ "PLS005" ] . ToString ( );
                    _modePLS . PLS008 = ( bool ) tableQuery . Rows [ 0 ] [ "PLS008" ];
                    if ( _modePLS . PLS008 == false )
                    {
                        //Concell1 . Hide ( );
                        toolCancellation . Caption = "注销";
                    }
                    else
                    {
                        Graph . gra ( splitContainerControl1 ,"注销" );
                        //Concell1 . Show ( );
                        toolCancellation . Caption = "反注销";
                    }
                    _modePLS . PLS009 = ( bool ) tableQuery . Rows [ 0 ] [ "PLS009" ];
                    if ( _modePLS . PLS009 == false )
                    {
                        // Concell2 . Hide ( );
                        toolExamin . Caption = "审核";
                    }
                    else
                    {
                        Graph . gra ( splitContainerControl1 ,"审核" );
                        //Concell2 . Show ( );
                        toolExamin . Caption = "反审核";
                    }
                    if ( _modePLS . PLS008 == false && _modePLS . PLS009 == false )
                        Graph . gra ( splitContainerControl1 ,"反" );
                    splitContainerControl1 . Panel1 . Refresh ( );
                    QueryTool ( );
                }
                gridControl1 . DataSource = tableQueryView;
                valuesOfAll ( );
            }
        }
        private void gridView1_CellValueChanged ( object sender ,DevExpress . XtraGrid . Views . Base . CellValueChangedEventArgs e )
        {
            if ( e . Column . Name == "PLT012" )
            {
                valuesOfAll ( );
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
                if ( row!=null )
                {
                    _modePLT . PLT003 = row [ "PLT003" ] . ToString ( );
                    _modePLT . PLT004 = row [ "PLT004" ] . ToString ( );

                    if ( _bll . Exists ( _modePLS . PLS001 ,_modePLT . PLT003 ,_modePLT . PLT004 ) )
                    {
                        XtraMessageBox . Show ( "此产品已经报工,不允许删除" );
                        return;
                    }

                    if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                        return;
                    tableQueryView . Rows . Remove ( row );
                    gridControl1 . RefreshDataSource ( );
                }
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
            _modePLS . PLS001 = texBatchNum . Tag . ToString ( );
            _modePLS . PLS002 = texBatchNum . Text;
            _modePLS . PLS003 = Convert . ToDateTime ( dtpOrder . Text );
            _modePLS . PLS004 = Convert . ToDateTime ( dtpStart . Text );
            _modePLS . PLS005 = Convert . ToDateTime ( dtpEnd . Text );
            _modePLS . PLS007 = UserLogin . userName;
        }
        void valuesOfAll ( )
        {
            gridView1 . CloseEditor ( );
            decimal dOne = 0M, dTwo = 0M, dSum = 0M;
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                dOne = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "OPI004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "OPI004" ] . ToString ( ) );
                dTwo = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "PLT012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "PLT012" ] . ToString ( ) );
                dSum += dOne * dTwo;
            }
            dSum = Math . Round ( dSum ,4 );
            OPI004 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dSum . ToString ( "0.####" ) );
            texValue . Text = dSum . ToString ( "0.####" );
        }
        bool checkView ( )
        {
            result = true;
            DataRow row;
            
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {               
                row = gridView1 . GetDataRow ( i );
                row . ClearErrors ( );
                if ( string . IsNullOrEmpty ( row [ "PLT007" ] . ToString ( ) ) )
                {
                    row . SetColumnError ( "PLT007" ,"不可为空" );
                    result = false;
                    break;
                }
            }

            return result;
        }
        void clear ( )
        {
            texBatchNum . Text = texValue . Text = string . Empty;
            dtpEnd . Text = dtpOrder . Text = dtpStart . Text = CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyy年MM月dd日" );
        }
        #endregion

    }
}
