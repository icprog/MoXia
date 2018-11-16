using System . Collections;
using System . Collections . Generic;
using System . Windows . Forms;

namespace Carpenter . ControlUser
{
    public partial class MaintainTranmsmitPeoQuery :UserControl
    {
        PersonQuery per = new PersonQuery ( );

        public MaintainTranmsmitPeoQuery ( )
        {
            InitializeComponent ( );
           
            this . splitContainer1 . Panel2 . Controls . Add ( per );
            per . Dock = DockStyle . Fill;
        }

        //checkAll
        private void btnCheckAll_Click ( object sender ,System . EventArgs e )
        {
            for ( int i = 0 ; i < per . gridView1 . RowCount ; i++ )
            {
                per . gridView1 . GetDataRow ( i ) [ "check" ] = true;
            }
        }
        //unChekcAll
        private void btnUnCheckAll_Click ( object sender ,System . EventArgs e )
        {
            for ( int i = 0 ; i < per . gridView1 . RowCount ; i++ )
            {
                per . gridView1 . GetDataRow ( i ) [ "check" ] = false;
            }
        }

        public List<CarpenterBll . Paramete> getHas
        {
            get
            {
                return per . getHash;
            }
        }

    }
}
