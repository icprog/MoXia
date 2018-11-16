using System;
using System . Collections . Generic;
using System . Data;
using System . Reflection;

namespace Carpenter . ControlUser
{
    public partial class ZDayDailyWork :DevExpress . XtraEditors . XtraUserControl
    {
        DataTable tableView;
        CarpenterBll.Bll.PlanAssembleDayDailyBll bll=null;
        
        public ZDayDailyWork ( bool plan,List<string> strList )
        {
            InitializeComponent ( );

            bll = new CarpenterBll . Bll . PlanAssembleDayDailyBll ( );

            this . dateTimePicker1 . Value = CarpenterBll . UserInformation . dt ( ) . AddDays ( -1 );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            if ( CarpenterBll . ColumnValues . pro_cg . Equals ( "其它" ) )
                tableView = bll . GetDataTableDailyOnley ( strList );
            else
            {
                if ( plan )
                    tableView = bll . GetDataTableDailyPlan ( strList );
                else
                    tableView = bll . GetDataTableDaily ( strList );
            }

            gridControl1 . DataSource = tableView;
        }

        public DataTable getTable
        {
            get
            {
                gridView1 . CloseEditor ( );
                gridView1 . UpdateCurrentRow ( );
                foreach ( DataRow row in tableView . Rows )
                {
                    row . BeginEdit ( );
                    row [ "PLF012" ] = Convert . ToDateTime ( dateTimePicker1 . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                    row . EndEdit ( );
                }
                return this . tableView;
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
