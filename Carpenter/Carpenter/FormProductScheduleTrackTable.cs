using System . Data;
using System . Reflection;

namespace Carpenter
{
    public partial class FormProductScheduleTrackTable :FormChild
    {
        CarpenterBll.Bll.ProductScheduleTrackTableBll _bll=null;
        DataTable tableView;
        string strWhere="1=1";

        public FormProductScheduleTrackTable ( string strWhere )
        {
            InitializeComponent ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            _bll = new CarpenterBll . Bll . ProductScheduleTrackTableBll ( );


            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave ,toolExport ,toolPrint ,toolCancellation ,toolExamin ,toolReview ,toolDelete ,toolEdit ,toolAdd } );

            this . strWhere = strWhere;
            getTable ( );
            getInfo ( );
        }

        protected override int Query ( )
        {
            strWhere = " AND 1=1 ";
            if ( !string . IsNullOrEmpty ( luPro . Text ) )
                strWhere = strWhere + " AND PRD008='" + luPro . EditValue . ToString ( ) + "'";
            if ( !string . IsNullOrEmpty ( lupBat . Text ) )
                strWhere = strWhere + " AND PRD007='" + lupBat . Text + "'";

            getTable ( );

            return base . Query ( );
        }

        void getTable ( )
        {
            tableView = _bll . getTableView ( strWhere );
            gridControl1 . DataSource = tableView;
        }

        void getInfo ( )
        {
            DataTable dt = _bll . getTableInfo ( );
            luPro . Properties . DataSource = dt . DefaultView . ToTable ( true ,new string [ ] { "PRD008" ,"PRD009" } );
            luPro . Properties . DisplayMember = "PRD009";
            luPro . Properties . ValueMember = "PRD008";

            lupBat . Properties . DataSource = dt . DefaultView . ToTable ( true ,"PRD007" );
            lupBat . Properties . DisplayMember = "PRD007";
        }

        private void btnClear_Click ( object sender ,System . EventArgs e )
        {
            lupBat . EditValue = luPro . EditValue = null;
        }
    }
}
