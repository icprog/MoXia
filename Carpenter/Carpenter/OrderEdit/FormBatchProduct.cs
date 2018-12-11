using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Linq;
using System . Windows . Forms;
using DevExpress . XtraEditors;

namespace Carpenter . OrderEdit
{
    public partial class FormBatchProduct :FormBase
    {
        List<string> piStr =new List<string>();
        CarpenterBll.Bll.OPIBll _bll=null;

        public FormBatchProduct ( List<string> piStr )
        {
            InitializeComponent ( );

            this . piStr = piStr;
            _bll = new CarpenterBll . Bll . OPIBll ( );
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . Close ( );
        }

        private void btnSure_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textEdit1 . Text ) )
            {
                XtraMessageBox . Show ( "请录入系列" );
                return;
            }
            bool result = _bll . BatchProOfAll ( piStr ,textEdit1 . Text );
            if ( result )
            {
                XtraMessageBox . Show ( "编辑成功" );
                this . DialogResult = DialogResult . OK;
            }
            else
                XtraMessageBox . Show ( "编辑失败,请重试" );
        }

    }
}