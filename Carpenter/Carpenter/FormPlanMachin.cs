using DevExpress . XtraEditors;
using System;
using System . ComponentModel;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormPlanMachin :FormChild
    {
        CarpenterEntity.PlanMachinPMCEntity _pmc=null;
        CarpenterEntity.PlanMachinPMDEntity _pmd=null;
        CarpenterBll.Bll.PlanMachinBll _bll=null;
        bool isOk=false;DataTable tableView,PrintOne,PrintTwo;
        string state=string.Empty;
        
        public FormPlanMachin ( )
        {
            InitializeComponent ( );

            _pmc = new CarpenterEntity . PlanMachinPMCEntity ( );
            _pmd = new CarpenterEntity . PlanMachinPMDEntity ( );
            _bll = new CarpenterBll . Bll . PlanMachinBll ( );
            tableView = new DataTable ( );
            PrintOne = new DataTable ( );
            PrintTwo = new DataTable ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolAdd } );

            wait . Hide ( );
            //SetImage . setImage ( Concell1 . pictureBox1 ,"zhuxiao.png" );
            //Concell1 . Hide ( );
            //SetImage . setImage ( Concell2 . pictureBox1 ,"shenhe.png" );
            //Concell2 . Hide ( );

            UnEnable ( );

            dtpEnd . Text = dtpOrder . Text = dtpStart . Text = CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyy年MM月dd日" );
        }
        
        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;

            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "机加工周计划查询" ,"PlanMachine" );
            if ( from . ShowDialog ( ) == System . Windows . Forms . DialogResult . OK )
            {
                _pmc . PMC001 = from . GetBarchNum;
                wait . Show ( );
                backgroundWorker1 . RunWorkerAsync ( );
            }
            else
                toolQuery . Enabled = true;


            return base . Query ( );
        }
        protected override int Edit ( )
        {
            editTool ( );
            Enable ( );

            return base . Edit ( );
        }
        protected override int Delete ( )
        {
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "周次不可为空" );
                return 0;
            }
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            _pmc . PMC001 = _pmd . PMD001 = texBatchNum . Tag . ToString ( );

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            isOk = _bll . Delete ( _pmc . PMC001 ,tableView );
            if ( isOk )
            {
                XtraMessageBox . Show ( "删除成功" );
                Clear ( );
                deleteTool ( );
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
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "周次不可为空" );
                return 0;
            }

            if ( checkView ( ) == false )
                return 0;

            getHeadValue ( );
            isOk = _bll . Edit ( _pmc ,tableView );
            if ( isOk )
            {
                XtraMessageBox . Show ( "保存成功" );
                saveTool ( );
                UnEnable ( );
            }
            else
                XtraMessageBox . Show ( "保存失败" );

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
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "周次不可为空" );
                return 0;
            }
            _pmc . PMC001 = texBatchNum . Tag . ToString ( );
            if ( toolExamin . Caption . Equals ( "审核" ) )
            {
                state = "审核";
                _pmc . PMC007 = true;
            }
            else
            {
                state = "反审核";
                _pmc . PMC007 = false;
            }

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            isOk = _bll . Examine ( _pmc . PMC001 ,_pmc . PMC007 ,this . Name  ,UserLogin . userNum ,tableView );
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
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "周次不可为空" );
                return 0;
            }
            _pmc . PMC001 = texBatchNum . Tag . ToString ( );
            if ( toolCancellation . Caption . Equals ( "注销" ) )
            {
                state = "注销";
                _pmc . PMC008 = true;
            }
            else
            {
                state = "反注销";
                _pmc . PMC008 = false;
            }
            isOk = _bll . Cancellation ( _pmc . PMC001 ,_pmc . PMC008 );
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
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "周次不可为空" );
                return 0;
            }
            _pmc . PMC001 = texBatchNum . Tag . ToString ( );
            Review ( _pmc . PMC001 ,this . Name );

            return base . Review ( );
        }
        protected override int Print ( )
        {
            if ( printOrExport ( ) == false )
                return 0;
            Print ( new DataTable [ ] { PrintOne ,PrintTwo } ,"机加工车间周计划表.frx" );

            return base . Print ( );
        }
        protected override int Export ( )
        {
            if ( printOrExport ( ) == false )
                return 0;
            Export ( new DataTable [ ] { PrintOne ,PrintTwo } ,"机加工车间周计划表.frx" );

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
            _pmc = _bll . GetDataTableMain ( _pmc . PMC001 );
            tableView = _bll . GetDataTableView ( _pmc . PMC001 );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                toolQuery . Enabled = true;

                gridControl1 . DataSource = tableView;
                valuesOfAll ( );

                if ( _pmc == null )
                    return;
                setHeadValue ( );
                if ( _pmc . PMC008 == false )
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
                if ( _pmc . PMC007 == false )
                {
                    //Concell2 . Hide ( );
                    toolExamin . Caption = "审核";
                }
                else
                {
                    Graph . gra ( splitContainerControl1 ,"审核" );
                    //Concell2 . Show ( );
                    toolExamin . Caption = "反审核";
                }
                if ( _pmc . PMC007 == false && _pmc . PMC008 == false )
                    Graph . gra ( splitContainerControl1 ,"反" );
                splitContainerControl1 . Panel1 . Refresh ( );
                QueryTool ( );
                UnEnable ( );
            }
        }
        private void gridView1_CellValueChanged ( object sender ,DevExpress . XtraGrid . Views . Base . CellValueChangedEventArgs e )
        {
            if ( e . Column . Name == "PMD007" )
            {
                valuesOfAll ( );
            }
        }
        private void gridControl1_KeyPress ( object sender ,System . Windows . Forms . KeyPressEventArgs e )
        {
            if ( toolSave . Visibility == DevExpress . XtraBars . BarItemVisibility . Never )
                return;
            DataRow row = gridView1 . GetFocusedDataRow ( );
            //int num = gridView1 . FocusedRowHandle;
            //Enter
            if ( e . KeyChar == 13 )
            {
                if (row!=null )
                {
                    _pmd . PMD003 = row [ "PMD003" ] . ToString ( );
                    _pmd . PMD004 = row [ "PMD004" ] . ToString ( );

                    if ( _bll . Exists ( _pmc . PMC001 ,_pmd . PMD003 ,_pmd . PMD004 ) )
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
            texBatchNum . Text =texValue.Text= string . Empty;
            dtpEnd . Text = dtpOrder . Text = dtpStart . Text = CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyy年MM月dd日" );
            tableView = null;
            gridControl1 . DataSource = tableView;
        }
        bool checkView ( )
        {
            isOk = true;
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );
            DataRow row;       
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                row = gridView1 . GetDataRow ( i );
                row . ClearErrors ( );
                if ( row != null )
                {
                    if ( string . IsNullOrEmpty ( row [ "PMD008" ] . ToString ( ) ) )
                    {
                        row . SetColumnError ( "PMD008" ,"不可为空" );
                        isOk = false;
                        break;
                    }
                }
            }

            return isOk;
        }
        void getHeadValue ( )
        {
            _pmc . PMC001 = texBatchNum . Tag . ToString ( );
            _pmc . PMC003 = Convert . ToDateTime ( dtpOrder . Text );
            _pmc . PMC004 = Convert . ToDateTime ( dtpStart . Text );
            _pmc . PMC005 = Convert . ToDateTime ( dtpEnd . Text );
            _pmc . PMC009 = texBatchNum . Text;
        }
        void setHeadValue ( )
        {
            texBatchNum . Tag = _pmc . PMC001;
            dtpOrder . Text = _pmc . PMC003 . ToString ( );
            dtpStart . Text = _pmc . PMC004 . ToString ( );
            dtpEnd . Text = _pmc . PMC005 . ToString ( );
            texBatchNum . Text = _pmc . PMC009;
        }
        void valuesOfAll ( )
        {
            gridView1 . CloseEditor ( );
            decimal dOne = 0M, dTwo = 0M, dSum = 0M;
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                dOne = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "OPI004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "OPI004" ] . ToString ( ) );
                dTwo = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "PMD007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "PMD007" ] . ToString ( ) );
                dSum += dOne * dTwo;
            }
            dSum = Math . Round ( dSum ,4 );
            OPI004 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dSum . ToString ( "0.####" ) );
            texValue . Text = dSum . ToString ( "0.####" );
        }
        void Enable ( )
        {
            dtpOrder . Enabled = dtpEnd . Enabled = dtpStart . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;
        }
        void UnEnable ( )
        {
            dtpOrder . Enabled = dtpEnd . Enabled = dtpStart . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;
        }
        bool printOrExport ( )
        {
            isOk = true;
            if ( string . IsNullOrEmpty ( texBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "周次不可为空" );
                return false;
            }
            _pmc . PMC001 = _pmd . PMD001 = texBatchNum . Tag . ToString ( );
            PrintOne = _bll . GetDataTablePrintOne ( _pmc . PMC001 );
            PrintOne . TableName = "TableOne";
            PrintTwo = _bll . GetDataTablePrintTwo ( _pmc . PMC001 );
            PrintTwo . TableName = "TableTwo";

            return isOk;
        }
        #endregion

    }
}