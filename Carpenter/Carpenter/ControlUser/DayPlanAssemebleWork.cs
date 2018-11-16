using System . Data;
using System . Reflection;

namespace Carpenter . ControlUser
{
    public partial class DayPlanAssemebleWork :DevExpress . XtraEditors . XtraUserControl
    {
        public DayPlanAssemebleWork ( DataTable table )
        {
            InitializeComponent ( );

            gridControl1 . DataSource = table;

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

        }

        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
    }
}
