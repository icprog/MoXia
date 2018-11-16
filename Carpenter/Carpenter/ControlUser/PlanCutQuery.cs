using System;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter . ControlUser
{
    public partial class PlanCutQuery :UserControl
    {
        public PlanCutQuery ( DataTable da )
        {
            InitializeComponent ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            gridControl1 . DataSource = da;
        }
        
        string batchNum=string.Empty;

        #region Event
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        #endregion

    }
}
