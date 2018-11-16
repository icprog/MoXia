using System . Windows . Forms;
using System . Reflection;
using System . Collections . Generic;
using System . Data;

namespace Carpenter .ControlUser
{
    public partial class PlanCutProduct :UserControl
    {
        public PlanCutProduct ( DataTable da )
        {
            InitializeComponent ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            da . Columns . Add ( "check" ,typeof ( System . Boolean ) );
            gridControl1 . DataSource = da;
        }

        #region Event
        string productNum = string . Empty;
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        //CheckAll
        private void bthAll_Click ( object sender ,System . EventArgs e )
        {
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                gridView1 . GetDataRow ( i ) [ "check" ] = true;
                productNum = gridView1 . GetDataRow ( i ) [ "OPI001" ] . ToString ( );
                if ( !strList . Contains ( productNum ) )
                    strList . Add ( productNum );
            }
        }
        //UnCheckAll
        private void btnCanAll_Click ( object sender ,System . EventArgs e )
        {
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                gridView1 . GetDataRow ( i ) [ "check" ] = false;
                strList . Clear ( );
            }
        }
        //Click
        List<string> strList=new List<string>();
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            int num = gridView1 . FocusedRowHandle;            
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                productNum = gridView1 . GetDataRow ( num ) [ "OPI001" ] . ToString ( );
                if ( gridView1 . GetDataRow ( num ) [ "check" ] . ToString ( ) == "True" )
                {
                    gridView1 . GetDataRow ( num ) [ "check" ] = false;
                    if ( strList . Contains ( productNum ) )
                        strList . Remove ( productNum );

                }
                else
                {
                    gridView1 . GetDataRow ( num ) [ "check" ] = true;
                    if ( !strList . Contains ( productNum ) )
                        strList . Add ( productNum );
                }
            }
        }

        public List<string> getTable
        {
            get
            {
                return strList;
            }
        }
        #endregion

        private void btnSure_Click ( object sender ,System . EventArgs e )
        {

        }
    }
}
