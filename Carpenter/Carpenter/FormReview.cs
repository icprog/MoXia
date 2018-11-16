using DevExpress . XtraEditors;
using System;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormReview :FormBase
    {
        CarpenterEntity . RemindEntity _model = new CarpenterEntity . RemindEntity ( );
        
        public FormReview ( string programNum ,string oddNum )
        {
            InitializeComponent ( );
            
            _model . REV001 = programNum;
            _model . REV002 = oddNum;
            _model . REV003 = UserLogin . userNum;          
        }
        
        private void btnOk_Click ( object sender ,EventArgs e )
        {
            if ( radReview . Checked == false && radReject . Checked == false )
            {
                XtraMessageBox . Show ( "请选择送审或驳回" );
                return;
            }
            CarpenterBll . Bll . RemindBll _bll = new CarpenterBll . Bll . RemindBll ( );
            _model . REV005 = radReview . Checked == true ? radReview . Text : radReject . Text;
            _model . REV006 = richView . Text;
            bool result = _bll . AddReview ( _model );
            if ( result == true )
            {
                XtraMessageBox . Show ( "送审成功" );
                this . DialogResult = DialogResult . OK;
            }
            else
                XtraMessageBox . Show ( "送审失败" );

        }

        private void btnCan_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }
    }
}
