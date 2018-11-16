using DevExpress . XtraEditors;
using System;
using System . ComponentModel;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormProductionPaintDay :FormChild
    {
        CarpenterEntity.ProductionPaintDayPWDEntity _pwd=null;
        CarpenterEntity.ProductionPaintDayPWEEntity _pwe=null;
        CarpenterBll.Bll.ProductionPaintDayBll _bll=null;
        bool isOk=false; DataTable tableView,PrintOne,PrintTwo; string state=string.Empty;
        
        public FormProductionPaintDay ( )
        {
            InitializeComponent ( );

            _pwd = new CarpenterEntity . ProductionPaintDayPWDEntity ( );
            _pwe = new CarpenterEntity . ProductionPaintDayPWEEntity ( );
            _bll = new CarpenterBll . Bll . ProductionPaintDayBll ( );
            tableView = new DataTable ( );
            PrintOne = new DataTable ( );
            PrintTwo = new DataTable ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] {toolAdd } );


            //SetImage . setImage ( Concell1 . pictureBox1 ,"zhuxiao.png" );
            //Concell1 . Hide ( );
            //SetImage . setImage ( Concell2 . pictureBox1 ,"shenhe.png" );
            //Concell2 . Hide ( );

            wait . Hide ( );

            UnEnable ( );
        }
        
        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;

            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "油漆日计划查询" ,"FormProductionPaintDay" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                _pwd . PWD001 = _pwe . PWE001 = from . GetBarchNum;
                _pwd . PWD002 = from . GetWorkShop;
                wait . Show ( );
                backgroundWorker1 . RunWorkerAsync ( );
            }
            else
                toolQuery . Enabled = true;

            return base . Query ( );
        }
        protected override int Edit ( )
        {
            Enable ( );
            editTool ( );

            return base . Edit ( );
        }
        protected override int Delete ( )
        {
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            _pwd . PWD001 = texOver . Tag . ToString ( );

            if ( _bll . Exists_BG ( _pwd . PWD001 ) )
            {
                XtraMessageBox . Show ( "此单中的部分产品已经报工,请先删除报工记录" );
                return 0;
            }
            
            isOk = _bll . Delete ( _pwd . PWD001 ,texBatchNum . Text );
            if ( isOk )
            {
                XtraMessageBox . Show ( "成功删除" );
                deleteTool ( );
                Clear ( );
                UnEnable ( );
                Graph . gra ( splitContainerControl1 ,"反" );
                splitContainerControl1 . Panel1 . Refresh ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        protected override int Save ( )
        {
            if ( checkView ( ) == false )
                return 0;
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );
            getHeadValue ( );

            wait . Show ( );
            backgroundWorker2 . RunWorkerAsync ( );

            return base . Save ( );
        }
        protected override int Cancel ( )
        {
            cancelTool ( "edit" );
            UnEnable ( );

            return base . Cancel ( );
        }
        protected override int Examine ( )
        {
            _pwd . PWD001 = texOver . Tag . ToString ( );
            if ( toolExamin . Caption . Equals ( "审核" ) )
            {
                state = "审核";
                _pwd . PWD006 = true;
            }
            else
            {
                state = "反审核";
                _pwd . PWD006 = false;
            }
            isOk = _bll . Examine ( _pwd . PWD001 ,this . Name ,_pwd . PWD006 );
            if ( isOk )
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
        protected override int Cancellation ( )
        {
            _pwd . PWD001 = texOver . Tag . ToString ( );
            if ( toolCancellation . Caption . Equals ( "注销" ) )
            {
                state = "注销";
                _pwd . PWD005 = true;
            }
            else
            {
                state = "反注销";
                _pwd . PWD005 = false;
            }
            isOk = _bll . Cancellation ( _pwd . PWD001 ,_pwd . PWD005 );
            if ( isOk )
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
        protected override int Review ( )
        {
            _pwd . PWD001 = texOver . Tag . ToString ( );

            Review ( _pwd . PWD001 ,this . Name );

            return base . Review ( );
        }
        protected override int Print ( )
        {
            printOrExport ( );

            Print ( new DataTable [ ] { PrintOne ,PrintTwo } ,"油漆车间生产日计划.frx" );

            return base . Print ( );
        }
        protected override int Export ( )
        {
            printOrExport ( );

            Export ( new DataTable [ ] { PrintOne ,PrintTwo } ,"油漆车间生产日计划.frx" );

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
        private void gridControl1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( toolSave . Visibility == DevExpress . XtraBars . BarItemVisibility . Never )
                return;
            DataRow row = gridView1 . GetFocusedDataRow ( );
            //num = gridView1 . FocusedRowHandle;
            //Enter
            if ( e . KeyChar == 13 )
            {
                if (row!=null  )
                {
                    _pwe . PWE003 = row [ "PWE003" ] . ToString ( );
                    _pwe . PWE004 = row [ "PWE004" ] . ToString ( );

                    if ( _bll . exists ( _pwd . PWD001 ,_pwe . PWE003 ,_pwe . PWE004 ) )
                    {
                        XtraMessageBox . Show ( "此产品已经报工,不允许删除" );
                        return;
                    }

                    if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                        return;
                    tableView . Rows . Remove ( row );
                    gridControl1 . RefreshDataSource ( );
                }
            }
        }
        private void gridView1_CellValueChanged ( object sender ,DevExpress . XtraGrid . Views . Base . CellValueChangedEventArgs e )
        {
            if ( e . Column . Name == "PWE007" )
            {
                valueOfAll ( );
            }
        }
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            _pwd = _bll . GetList ( _pwd . PWD001 ,_pwd . PWD002 );
            tableView = _bll . GetDataTableView ( _pwd . PWD001 );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                toolQuery . Enabled = true;
                gridControl1 . DataSource = tableView;
                valueOfAll ( );
                texOver . Tag = _pwd . PWD001;
                texBatchNum . Text = _pwd . PWD002;
                dtpOrder . Text = _pwd . PWD003 . ToString ( );
                dtpPlan . Text = _pwd . PWD004 . ToString ( );
                if ( _pwd . PWD010 > DateTime . MinValue && _pwd . PWD010 < DateTime . MaxValue )
                    dtpPrevious . Text = _pwd . PWD010 . ToString ( );
                texOver . Text = _pwd . PWD009 . ToString ( ) + "%";
                if ( _pwd . PWD005 == true )
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
                if ( _pwd . PWD006 == true )
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

                if ( _pwd . PWD005 == false && _pwd . PWD006 == false )
                    Graph . gra ( splitContainerControl1 ,"反" );
                splitContainerControl1 . Panel1 . Refresh ( );

                QueryTool ( );
            }
        }
        private void backgroundWorker2_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            isOk = _bll . Edit ( _pwd ,tableView );
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );

                if ( isOk )
                {
                    XtraMessageBox . Show ( "保存成功" );
                    saveTool ( );
                    UnEnable ( );
                }
                else
                    XtraMessageBox . Show ( "保存失败" );
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
        void Clear ( )
        {
            texOver . Text = string . Empty;
            dtpOrder . Text = dtpPlan . Text = dtpPrevious . Text = CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyy年MM月dd日" );
            tableView = null;
            gridControl1 . DataSource = tableView;
        }
        void Enable ( )
        {
            dtpOrder . Enabled = dtpPlan . Enabled = dtpPrevious . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;
        }
        void UnEnable ( )
        {
            dtpOrder . Enabled = dtpPlan . Enabled = dtpPrevious . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;
        }
        bool checkView ( )
        {
            isOk = true;
            gridView1 . CloseEditor ( );
            DataRow row;
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                row = gridView1 . GetDataRow ( i );
                row . ClearErrors ( );
                if ( row != null )
                {
                    _pwe . PWE006 = string . IsNullOrEmpty ( row [ "PWE006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PWE006" ] . ToString ( ) );
                    _pwe . PWE007 = string . IsNullOrEmpty ( row [ "PWE007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PWE007" ] . ToString ( ) );
                    if ( _pwe . PWE007 == 0 || _pwe . PWE006 < _pwe . PWE007 )
                    {
                        row . SetColumnError ( "PWE007" ,"数量错误" );
                        isOk = false;
                        break;
                    }
                }
            }

            return isOk;
        }
        void getHeadValue ( )
        {
            _pwd . PWD001 = texOver . Tag . ToString ( );
            _pwd . PWD002 = texBatchNum . Text;
            _pwd . PWD004 = Convert . ToDateTime ( dtpPlan . Text );
            _pwd . PWD003 = Convert . ToDateTime ( dtpOrder . Text );
            _pwd . PWD009 = string . IsNullOrEmpty ( texOver . Text . Split ( '%' ) [ 0 ] ) == true ? 0 : Convert . ToDecimal ( texOver . Text . Split ( '%' ) [ 0 ] );
        }
        void printOrExport ( )
        {
            _pwd . PWD001 = texOver . Tag . ToString ( );
            PrintOne = _bll . GetDataTablePrintOne ( _pwd . PWD001 );
            PrintOne . TableName = "TableOne";
            PrintTwo = _bll . GetDataTablePrintTwo ( _pwd . PWD001 );
            PrintTwo . TableName = "TableTwo";
        }
        void valueOfAll ( )
        {
            decimal nums = 0, outPutValue = 0, sumValue = 0;
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                nums = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "PWE007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "PWE007" ] . ToString ( ) );
                outPutValue = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "OPI004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "OPI004" ] . ToString ( ) );
                sumValue += nums * outPutValue;
            }
            sumValue = Math . Round ( sumValue ,4 );
            OPI004 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,sumValue . ToString ( "0.####" ) );
        }
        #endregion

    }
}
