
using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormBomWorkPlanCode :FormChild
    {
        CarpenterBll.Bll.BomWorkPlanCodeBll _bll;
        CarpenterEntity.BomWorkPlanCodeEntity _model;
        string strWhere="1=1";int num=0;
        DataTable tableView;bool isOk=false;
        List<string> strList=new List<string>();
        
        public FormBomWorkPlanCode ( )
        {
            InitializeComponent ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            _bll = new CarpenterBll . Bll . BomWorkPlanCodeBll ( );
            _model = new CarpenterEntity . BomWorkPlanCodeEntity ( );
            tableView = new DataTable ( );
            wait . Hide ( );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave ,toolCancellation ,toolExamin ,toolReview ,toolEdit ,toolAdd } );
        }
        
        private void FormBomWorkPlanCode_Load ( object sender ,System . EventArgs e )
        {
            lupWeek . Properties . DataSource = _bll . GetDataTableWeekend ( );
            lupWeek . Properties . DisplayMember = "WPC001";
            lupProduct . Properties . DataSource = _bll . GetDataTablePorductNum ( );
            lupProduct . Properties . DisplayMember = "WPC002";
            lupProduct . Properties . ValueMember = "WOQ002";
            lupPart . Properties . DataSource = _bll . GetDataTablePartNum ( );
            lupPart . Properties . DisplayMember = "WPC004";
            lupPart . Properties . ValueMember = "WPC003";
        }

        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;

            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupWeek . Text ) )
                strWhere = strWhere + " and WPC001='" + lupWeek . Text + "'";
            if ( !string . IsNullOrEmpty ( lupProduct . Text ) )
                strWhere = strWhere + " and WPC002='" + lupProduct . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPart . Text ) )
                strWhere = strWhere + " and WPC003='" + lupPart . Text + "'";

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
            isOk = _bll . Delete ( _model . idx );
            if ( isOk == true )
            {
                XtraMessageBox . Show ( "删除成功" );
                tableView . Rows . RemoveAt ( num );
                gridControl1 . RefreshDataSource ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        protected override int Print ( )
        {
            if ( strList . Count < 1 )
                return 0;

            DataTable print = _bll . printOne ( strList );
            print . TableName = "TableOne";

            Print ( new DataTable [ ] { print } ,"传票.frx" );

            return base . Print ( );
        }
        protected override int Export ( )
        {
            if ( strList . Count < 1 )
                return 0;

            DataTable print = _bll . printOne ( strList );
            print . TableName = "TableOne";

            Export ( new DataTable [ ] { print } ,"传票.frx" );

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
        private void btnClear_Click ( object sender ,System . EventArgs e )
        {
            lupPart . EditValue = lupProduct . EditValue = lupWeek . EditValue = null;
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
                tableView . Columns . Add ( "check" ,typeof ( System . Boolean ) );
                gridControl1 . DataSource = tableView;
                toolQuery . Visibility = toolDelete . Visibility = toolPrint . Visibility = toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            num = gridView1 . FocusedRowHandle;
            if ( num < 0 || num > gridView1 . DataRowCount - 1 )
                return;
            DataRow row = gridView1 . GetDataRow ( num );
            if ( row != null )
            {
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                if ( row [ "check" ] . ToString ( ) == "True" )
                {
                    row [ "check" ] = false;
                    if ( strList . Contains ( _model . idx . ToString ( ) ) )
                        strList . Remove ( _model . idx . ToString ( ) );
                }
                else
                {
                    row [ "check" ] = true;
                    if ( !strList . Contains ( _model . idx . ToString ( ) ) )
                        strList . Add ( _model . idx . ToString ( ) );
                }
            }

        }
        private void btnAddBom_Click ( object sender ,EventArgs e )
        {
            FormBomWorkPlanCodeAddNewBom form = new FormBomWorkPlanCodeAddNewBom ( );
            form . ShowDialog ( );
        }
        #endregion

    }
}