
using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormProductDailyWork :FormChild
    {
        CarpenterEntity.ProductDailyWorkEntity _model=null;
        CarpenterBll.Bll.ProductDailyWorkBll _bll=null;
        DataTable tableView,tablePrint,tableViewTwo;
        int num=0;string strWhere=""; List<string> strList = new List<string> ( );
        bool result=false;
        DataRow row;
        
        public FormProductDailyWork ( )
        {
            InitializeComponent ( );

            _model = new CarpenterEntity . ProductDailyWorkEntity ( );
            _bll = new CarpenterBll . Bll . ProductDailyWorkBll ( );
            tableView = new DataTable ( );
            tablePrint = new DataTable ( );
            tableViewTwo = new DataTable ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            
            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            wait . Hide ( );
            gridView1 . OptionsBehavior . Editable = false;


            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolReview ,toolAdd } );


            DataTable dt = _bll . GetDataTableOnly ( );
            lupWeek . Properties . DataSource = new DataView ( dt . Copy ( ) ) . ToTable ( true ,"PRD007" );
            lupWeek . Properties . DisplayMember = "PRD007";
            lupDep . Properties . DataSource = new DataView ( dt . Copy ( ) ) . ToTable ( true ,new string [ ] { "PRD001" ,"PRD002" } );
            lupDep . Properties . DisplayMember = "PRD002";
            lupDep . Properties . ValueMember = "PRD001";
            lupArt . Properties . DataSource = new DataView ( dt . Copy ( ) ) . ToTable ( true ,"PRD003" );
            lupArt . Properties . DisplayMember = "PRD003";
            lupPart . Properties . DataSource = new DataView ( dt . Copy ( ) ) . ToTable ( true ,"PRD011" );
            lupPart . Properties . DisplayMember = "PRD011";
            lupPer . Properties . DataSource = new DataView ( dt . Copy ( ) ) . ToTable ( true ,new string [ ] { "PRD005" ,"PRD004" } );
            lupPer . Properties . DisplayMember = "PRD005";
            lupPer . Properties . ValueMember = "PRD004";
            lupPro . Properties . DataSource = new DataView ( dt . Copy ( ) ) . ToTable ( true ,new string [ ] { "PRD008" ,"PRD009" ,"PRD010" } );
            lupPro . Properties . DisplayMember = "PRD009";
            lupPro . Properties . ValueMember = "PRD008";

            toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
        }
        
        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;

            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupWeek . Text ) )
                strWhere = strWhere + " AND PRD007='" + lupWeek . Text + "'";
            if ( !string . IsNullOrEmpty ( lupDep . Text ) )
                strWhere = strWhere + " AND PRD001='" + lupDep . EditValue . ToString ( ) + "'";
            if ( !string . IsNullOrEmpty ( lupArt . Text ) )
                strWhere = strWhere + " AND PRD003='" + lupArt . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPart . Text ) )
                strWhere = strWhere + " AND PRD011='" + lupPart . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPer . Text ) )
                strWhere = strWhere + " AND PRD004='" + lupPer . EditValue . ToString ( ) + "'";
            if ( !string . IsNullOrEmpty ( lupPro . Text ) )
                strWhere = strWhere + " AND PRD008='" + lupPro . EditValue . ToString ( ) + "'";
            if ( !string . IsNullOrEmpty ( dateEdit1 . Text ) )
                strWhere = strWhere + " AND PRD013 BETWEEN '" + dateEdit1 . Text + " 00:00:00.000' AND '" + dateEdit1 . Text + " 23:59:59.000'";

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Delete ( )
        {
            if ( _model . idx < 1 )
            {
                XtraMessageBox . Show ( "请选择需要删除的内容" );
                return 0;
            }
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            bool isOk = _bll . Delete ( _model . idx );
            if ( isOk )
            {
                XtraMessageBox . Show ( "删除成功" );
                tableView . Rows . RemoveAt ( num );
                gridControl1 . RefreshDataSource ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        protected override int Examine ( )
        {
            if ( gridView1 . RowCount < 1 )
            {
                XtraMessageBox . Show ( "请查询需要审核的内容" );
                return 0;
            }
            strList = new List<string> ( );
            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
            {
                DataRow row = gridView1 . GetDataRow ( i );
                strList . Add ( row [ "idx" ] . ToString ( ) );
            }

            wait . Show ( );
            backgroundWorker2 . RunWorkerAsync ( );

            return base . Examine ( );
        }
        protected override int Cancellation ( )
        {
            if ( gridView1 . RowCount < 1 )
            {
                XtraMessageBox . Show ( "请查询需要注销的内容" );
                return 0;
            }
            strList = new List<string> ( );
            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
            {
                DataRow row = gridView1 . GetDataRow ( i );
                strList . Add ( row [ "idx" ] . ToString ( ) );
            }

            wait . Show ( );
            backgroundWorker3 . RunWorkerAsync ( );

            return base . Cancellation ( );
        }
        protected override int Edit ( )
        {
            //if ( gridView1 . RowCount < 1 )
            //{
            //    XtraMessageBox . Show ( "请查询需要编辑的内容" );
            //    return 0;
            //}
            //editTool ( );
            //gridView1 . OptionsBehavior . Editable = true;

            if ( row == null )
            {
                XtraMessageBox . Show ( "请选择需要编辑的内容" );
                return 0;
            }
            //if ( row [ "PRD021" ] != null && row [ "PRD021" ] . ToString ( ) == "True" )
            //{
            //    XtraMessageBox . Show ( "数据已注销,不允许编辑" );
            //    return 0;
            //}
            //if ( row [ "PRD020" ] != null && row [ "PRD020" ] . ToString ( ) == "True" )
            //{
            //    XtraMessageBox . Show ( "数据已审核,不允许编辑" );
            //    return 0;
            //}
            OrderEdit . FormProductDailyEdit from = new OrderEdit . FormProductDailyEdit ( row );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                _model = from . getModel;
                if ( _model == null )
                    return 0;
                DataRow rows = tableView . Rows [ num ];
                row . BeginEdit ( );
                rows [ "PRD020" ] = _model . PRD020;
                rows [ "PRD021" ] = _model . PRD021;
                rows [ "PRD023" ] = _model . PRD023;
                rows [ "PRD033" ] = _model . PRD033;
                rows [ "PRD036" ] = _model . PRD036;
                rows [ "PRD037" ] = _model . PRD037;
                rows [ "PRD038" ] = _model . PRD038;
                rows [ "PRD039" ] = _model . PRD039;
                rows [ "PRD040" ] = _model . PRD040;
                rows [ "PRD041" ] = _model . PRD041;
                row . EndEdit ( );
                gridControl1 . RefreshDataSource ( );
            }

            return base . Edit ( );
        }
        protected override int Save ( )
        {
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );
            if ( gridView1 . RowCount < 1 )
            {
                XtraMessageBox . Show ( "请查询需要编辑的内容" );
                return 0;
            }

            wait . Show ( );
            backgroundWorker3 . RunWorkerAsync ( );

            return base . Save ( );
        }
        protected override int Cancel ( )
        {
            cancelTool ( "edit" );
            gridView1 . OptionsBehavior . Editable = false;

            return base . Cancel ( );
        }
        protected override int Print ( )
        {
            if ( string . IsNullOrEmpty ( dateEdit1 . Text ) )
            {
                XtraMessageBox . Show ( "请选择扫描日期" );
                return 0;
            }

            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupPer . Text ) )
                strWhere = strWhere + " AND PRD004='" + lupPer . EditValue + "'";
            if ( !string . IsNullOrEmpty ( dateEdit1 . Text ) )
                strWhere = strWhere + " AND convert(varchar,PRD013,112)='" + Convert . ToDateTime ( dateEdit1 . Text ) . ToString ( "yyyyMMdd" ) + "'";

            DataTable tableUser = null;
            if ( strWhere . Contains ( "PRD004" ) )
            {
                tableUser = _bll . getPrintUser ( strWhere );
                if ( tableUser == null || tableUser . Rows . Count < 1 )
                    return 0;
                for ( int i = 0 ; i < tableUser . Rows . Count ; i++ )
                {
                    strWhere = strWhere + " AND PRD004='" + tableUser . Rows [ i ] [ "PRD004" ] . ToString ( ) + "'";
                    tablePrint = _bll . getPrintTable ( strWhere );
                    if ( tablePrint == null || tablePrint . Rows . Count < 1 )
                        return 0;
                    Print ( new DataTable [ ] { tablePrint } ,"生产报工记录表.frx" );
                }
            }
            else
            {
                tablePrint = _bll . getPrintTable ( strWhere );
                if ( tablePrint == null || tablePrint . Rows . Count < 1 )
                    return 0;
                Print ( new DataTable [ ] { tablePrint } ,"生产报工记录表.frx" );
            }


            return base . Print ( );
        }
        protected override int Export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            return base . Export ( );
        }
        #endregion

        #region Event
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            tableView = _bll . GetDataTable ( strWhere );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                toolQuery . Enabled = true;

                gridControl1 . DataSource = tableView;
                QueryTool ( );
                gridView1 . OptionsBehavior . Editable = false;
                toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            row = gridView1 . GetFocusedDataRow ( );
             num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                _model . idx = string . IsNullOrEmpty ( gridView1 . GetDataRow ( num ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( num ) [ "idx" ] . ToString ( ) );
                _model . PRD015 = gridView1 . GetDataRow ( num ) [ "PRD015" ] . ToString ( );
                tableViewTwo = _bll . GetDataTableTwo ( _model . PRD015 );
                gridControl2 . DataSource = tableViewTwo;
            }
        }
        private void btnClear_Click ( object sender ,EventArgs e )
        {
            lupArt . EditValue = lupDep . EditValue = lupPart . EditValue = lupPer . EditValue = lupPro . EditValue = lupWeek . EditValue = null;
            dateEdit1 . Text = string . Empty;
        }
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void backgroundWorker2_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            result = _bll . Examin ( strList );
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                if ( result )
                {
                    XtraMessageBox . Show ( "审核成功" );
                    Query ( );
                    toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                    toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                    gridView1 . OptionsBehavior . Editable = false;
                }
                else
                    XtraMessageBox . Show ( "审核失败" );
            }
        }
        private void backgroundWorker3_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            result = _bll . Edit ( tableView );
        }
        private void backgroundWorker3_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                if ( result )
                {
                    XtraMessageBox . Show ( "编辑成功" );
                    Query ( );
                }
                else
                    XtraMessageBox . Show ( "编辑失败,请重试" );
            }
        }
        private void backgroundWorker4_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            result = _bll . Cancella ( strList );
        }
        private void backgroundWorker4_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                if ( result )
                {
                    XtraMessageBox . Show ( "注销成功" );
                    Query ( );
                    toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                    toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                    gridView1 . OptionsBehavior . Editable = false;
                }
                else
                    XtraMessageBox . Show ( "注销失败" );
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

    }
}
