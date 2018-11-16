using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Carpenter . ControlUser
{
    public partial class SetTransmitAdd :UserControl
    {
        PersonQuery per;

        public SetTransmitAdd ( )
        {
            InitializeComponent ( );
            
            per = new PersonQuery ( );
            this . splitContainer1 . Panel2 . Controls . Add ( per );
            per . Dock = DockStyle . Fill;

            CarpenterBll . Bll . TransmitBll bll = new CarpenterBll . Bll . TransmitBll ( );
            lupTran . Properties . DataSource = bll . GetDataTable ( );
            lupTran . Properties . DisplayMember = "TRA002";
            lupTran . Properties . ValueMember = "TRA001";
        }

        List<CarpenterBll . Paramete> hasT=new List<CarpenterBll . Paramete>();
        public List<CarpenterBll . Paramete> gethashL
        {
            get
            {
                hasT = per . getHash;
                CarpenterBll . Paramete pa = new CarpenterBll . Paramete ( );
                pa . Key = "1";
                pa . Name = lupTran . EditValue . ToString ( );
                pa . Value = lupTran . Text;
                //hasT . Add ( pa . Key ,pa );
                hasT . Add ( pa );

                return hasT;
            }
        }

        private void btnOk_Click ( object sender ,System . EventArgs e )
        {
            //hasT = per . getHash;
            //if ( hasT . Count < 1 )
            //{
            //    XtraMessageBox . Show ( "请选择人员信息" );
            //    return;
            //}

            //if ( string . IsNullOrEmpty ( lupTran . Text ) )
            //{
            //    XtraMessageBox . Show ( "请选择单据" );
            //    return;
            //}
           
        }

    }
}
