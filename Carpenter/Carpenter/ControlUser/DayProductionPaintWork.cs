using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Drawing;
using System . Data;
using System . Text;
using System . Linq;
using System . Windows . Forms;
using DevExpress . XtraEditors;
using System . Reflection;

namespace Carpenter . ControlUser
{
    public partial class DayProductionPaintWork :DevExpress . XtraEditors . XtraUserControl
    {
        public DayProductionPaintWork ( DataTable table )
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
