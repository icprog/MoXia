using System . Reflection;
using DevExpress . Utils . Paint;
using DevExpress . XtraEditors;
using System . Data;
using System;

namespace Carpenter
{
    public partial class FormProductCycle :FormChild
    {
        CarpenterBll.Bll.ProductCycleBll _bll=null;
        DataTable tableView;
        string piNum=string.Empty,pinNum=string.Empty;
        
        public FormProductCycle ( )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . ProductCycleBll ( );
            tableView = new DataTable ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            FieldInfo fi = typeof ( XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave  ,toolPrint ,toolCancellation ,toolExamin ,toolReview,toolDelete,toolEdit,toolAdd } );

            wait . Hide ( );

            getTableColumn ( );
        }
        
        void getTableColumn ( )
        {
            DataTable dt = _bll . getTableColumn ( );
            lupPartNum . Properties . DataSource = dt . DefaultView . ToTable ( true ,"CUU001" );
            lupPartNum . Properties . DisplayMember = "CUU001";
            lupProductName . Properties . DataSource = dt . DefaultView . ToTable ( true ,new string [ ] { "CUU002" ,"OPI002" } );
            lupProductName . Properties . DisplayMember = "CUU002";
            lupProductName . Properties . ValueMember = "OPI002";
        }
        
        protected override int Query ( )
        {
            piNum = string . Empty;
            pinNum = string . Empty;
            if ( !string . IsNullOrEmpty ( lupPartNum . Text ) )
                piNum = lupPartNum . Text;
            if ( !string . IsNullOrEmpty ( lupProductName . Text ) )
                pinNum = lupProductName . Text;

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Export ( )
        {
            //if ( string . IsNullOrEmpty ( dateEdit . Text ) )
            //{
            //    XtraMessageBox . Show ( "请选择年" );
            //    return 0;
            //}
            //DataTable tablePrint = _bll . getTableExport ( Convert . ToInt32 ( dateEdit . Text ) );
            //tablePrint . TableName = "TableOne";

            //Export ( new DataTable [ ] { tablePrint } ,"产品周期表.frx" );

            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            return base . Export ( );
        }

        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            tableView = _bll . getTableView ( piNum ,pinNum );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                gridControl1 . DataSource = tableView;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }

        private void btnClear_Click ( object sender ,EventArgs e )
        {
            //dateEdit . Text = string . Empty;
            lupPartNum . EditValue = lupProductName . EditValue  = null;
        }
    }
}