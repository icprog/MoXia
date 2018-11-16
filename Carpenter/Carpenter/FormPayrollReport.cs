using System . ComponentModel;
using System . Data;
using DevExpress . XtraEditors;
using System . Reflection;
using DevExpress . Utils . Paint;

namespace Carpenter
{
    public partial class FormPayrollReport :FormChild
    {
        CarpenterBll.Bll.PayrollReportBll _bll=null;
        DataTable tableView;
        
        public FormPayrollReport ( )
        {
            InitializeComponent ( );
            
            _bll = new CarpenterBll . Bll . PayrollReportBll ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            FieldInfo fi = typeof ( XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave ,toolPrint ,toolCancellation ,toolExamin ,toolReview ,toolDelete ,toolEdit ,toolAdd } );

            wait . Hide ( );
        }
        
        protected override int Query ( )
        {
            if ( string . IsNullOrEmpty ( dateEdit . Text ) )
            {
                XtraMessageBox . Show ( "请选择年月" );
                return 0;
            }

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }

        protected override int Export ( )
        {
            if ( gridView1 . RowCount < 1 )
            {
                XtraMessageBox . Show ( "请选择导出的内容" );
                return 0;
            }

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

        private void backgroundWorker1_DoWork ( object sender ,DoWorkEventArgs e )
        {
            tableView = _bll . getTableQuery ( dateEdit . Text );
        }

        private void backgroundWorker1_RunWorkerCompleted ( object sender ,RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                gridControl1 . DataSource = tableView;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }

        //读取数据
        private void btnRead_Click ( object sender ,System . EventArgs e )
        {
            int result = _bll . Read ( dateEdit . Text );
            if ( result == -1 )
                XtraMessageBox . Show ( "工资表中无本月工资" );
            else if ( result == 1 )
            {
                XtraMessageBox . Show ( "读取成功" );
                Query ( );
            }
            else
                XtraMessageBox . Show ( "读取失败" );
        }

    }
}