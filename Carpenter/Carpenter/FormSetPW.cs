
using DevExpress . XtraEditors;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormSetPW :FormBase
    {
        public FormSetPW ( )
        {
            InitializeComponent ( );

            this . texNumPerson . Text = UserLogin . userNum;
            this . texNamePerson . Text = UserLogin . userName;
        }
        
        private void btnOk_Click ( object sender ,System . EventArgs e )
        {
            errorProvider1 . Clear ( );
            bool isOk = true;
            if ( string . IsNullOrEmpty ( texNumPerson . Text ) )
            {
                errorProvider1 . SetError ( texNumPerson ,"用户编号不可为空" );
                isOk = false;
            }
            if ( string . IsNullOrEmpty ( texNamePerson . Text ) )
            {
                errorProvider1 . SetError ( texNamePerson ,"用户姓名不可为空" );
                isOk = false;
            }
            if ( string . IsNullOrEmpty ( texPW . Text ) )
            {
                errorProvider1 . SetError ( texPW ,"口令不可为空" );
                isOk = false;
            }
            if ( string . IsNullOrEmpty ( texPWS . Text ) )
            {
                errorProvider1 . SetError ( texNumPerson ,"请确认口令" );
                isOk = false;
            }
            if ( isOk == false )
                return;

            if ( texPW . Text . Trim ( ) != texPWS . Text . Trim ( ) )
            {
                XtraMessageBox . Show ( "两次输入口令不一致,请重新输入" );
                return;
            }

            string pwdMD5 = Utility . DesEncryptUtil . EncryptMD5 ( texPW . Text );
            CarpenterBll . Bll . EmployeeBll _bll = new CarpenterBll . Bll . EmployeeBll ( );
            isOk = _bll . EditPw ( texNumPerson . Text ,pwdMD5 );
            if ( isOk == true )
                XtraMessageBox . Show ( "成功设置口令" );
            else
                XtraMessageBox . Show ( "设置口令失败" );
        }

        private void btnCan_Click ( object sender ,System . EventArgs e )
        {
            this . Close ( );
        }
    }
}
