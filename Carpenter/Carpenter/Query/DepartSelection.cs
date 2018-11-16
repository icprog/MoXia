
using System . Data;
using System . Reflection;

namespace Carpenter . Query
{
    public partial class DepartSelection :FormBase
    {
        public DepartSelection (string text )
        {
            InitializeComponent ( );

            this . Text = text;

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            query ( );
        }

        void query ( )
        {
            CarpenterBll . Bll . ArtBll _bll = new CarpenterBll . Bll . ArtBll ( );
            DataTable dt = _bll . GetDepart ( );
            gridControl1 . DataSource = dt;
        }

        int num=0;

        private void gridView1_DoubleClick ( object sender ,System . EventArgs e )
        {
            num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }

        public CarpenterEntity.DepartMentEntity getDou
        {
            get
            {
                CarpenterEntity . DepartMentEntity _model = new CarpenterEntity . DepartMentEntity ( );
                DataRow row = gridView1 . GetDataRow ( num );
                _model . DEP001 = row [ "DEP001" ] . ToString ( );
                _model . DEP002 = row [ "DEP002" ] . ToString ( );

                return _model;
            }
        }
    }
}
