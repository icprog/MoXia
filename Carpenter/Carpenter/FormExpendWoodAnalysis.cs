using System . ComponentModel;
using System . Data;
using DevExpress . XtraEditors;
using System . Reflection;
using DevExpress . Utils . Paint;

namespace Carpenter
{
    public partial class FormExpendWoodAnalysis :FormChild
    {
        CarpenterBll.Bll.ExpendWoodAnalysisBll _bll=null;

        DataTable tableView;
        
        public FormExpendWoodAnalysis ( )
        {
            InitializeComponent ( );
            
            _bll = new CarpenterBll . Bll . ExpendWoodAnalysisBll ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            FieldInfo fi = typeof ( XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave ,toolCancellation ,toolExamin ,toolReview ,toolDelete ,toolEdit ,toolAdd } );

            wait . Hide ( );

            lupBatchNum . Properties . DataSource = _bll . getTableBatchNum ( );
            lupBatchNum . Properties . DisplayMember = "CUT001";
        }
        
        #region Main
        protected override int Query ( )
        {
            if ( string . IsNullOrEmpty ( lupBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "请选择批号" );
                return 0;
            }

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Export ( )
        {
            if ( getPrintTable ( ) == false )
                return 0;

            Export ( new DataTable [ ] { tableView } ,"木材耗用分析表.frx" );

            return base . Export ( );
        }
        protected override int Print ( )
        {
            if ( getPrintTable ( ) == false )
                return 0;

            Print ( new DataTable [ ] { tableView } ,"木材耗用分析表.frx" );

            return base . Print ( );
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
        private void backgroundWorker1_DoWork ( object sender ,DoWorkEventArgs e )
        {
            tableView = _bll . getTableView ( lupBatchNum . Text );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                gridControl1 . DataSource = tableView;
                toolExport . Visibility = toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }
        #endregion

        #region Method
        bool getPrintTable ( )
        {
            if ( string . IsNullOrEmpty ( lupBatchNum . Text ) )
            {
                XtraMessageBox . Show ( "请选择批号" );
                return false;
            }

            tableView = _bll . getTableView ( lupBatchNum . Text );
            tableView . TableName = "Table";

            return true;
        }
        #endregion

    }
}