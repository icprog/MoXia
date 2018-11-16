using System . Windows . Forms;
using System . Reflection;
using System . Data;
using System . Collections . Generic;
using System . Collections;

namespace Carpenter . ControlUser
{
    public partial class PersonQuery :UserControl
    {
        public PersonQuery ( )
        {
            InitializeComponent ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            
            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            CarpenterBll . Bll . SetTransmitBll bll = new CarpenterBll . Bll . SetTransmitBll ( );
            DataTable tableQuery = bll . GetPerson ( );
            tableQuery . Columns . Add ( "check" ,typeof ( System . Boolean ) );
            gridControl1 . DataSource = tableQuery;
        }
        
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

        private void gridView1_Click ( object sender ,System . EventArgs e )
        {
            int num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                if ( gridView1 . GetDataRow ( num ) [ "check" ] . ToString ( ) == "True" )
                    gridView1 . GetDataRow ( num ) [ "check" ] = false;
                else
                    gridView1 . GetDataRow ( num ) [ "check" ] = true;
            }
        }

        public List<CarpenterBll . Paramete> getHash
        {
            get
            {
                List<CarpenterBll . Paramete> paList = new List<CarpenterBll . Paramete> ( );
                for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
                {
                    CarpenterBll . Paramete pa = new CarpenterBll . Paramete ( );
                    if ( gridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
                    {
                        pa . Key = gridView1 . GetDataRow ( i ) [ "EMP001" ] . ToString ( );
                        pa . Name = gridView1 . GetDataRow ( i ) [ "EMP001" ] . ToString ( );
                        pa . Value = gridView1 . GetDataRow ( i ) [ "EMP002" ] . ToString ( );
                        //hsTable . Add ( pa . Key ,pa );
                        paList . Add ( pa );
                    }
                }

                return paList;
            }
        }

    }
}
