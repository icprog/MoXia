using System;
using System . Data;
using System . Reflection;

namespace Carpenter . ControlUser
{
    public partial class JDailyWeek :DevExpress . XtraEditors . XtraUserControl
    {
        DataTable tableQuery;
        public JDailyWeek ( DataTable tableQuery )
        {
            InitializeComponent ( );

            dateTimePicker1 . Value = CarpenterBll . UserInformation . dt ( ) . AddDays ( -1 );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            this . tableQuery = tableQuery;
            gridControl1 . DataSource = this . tableQuery;
        }

        public DataTable getTable
        {
            get
            {
                gridView1 . CloseEditor ( );
                gridView1 . UpdateCurrentRow ( );
                foreach ( DataRow row in tableQuery . Rows )
                {
                    row . BeginEdit ( );
                    row [ "PME012" ] = Convert . ToDateTime ( dateTimePicker1 . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                    row . EndEdit ( );
                }
                return this . tableQuery;
            }
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
