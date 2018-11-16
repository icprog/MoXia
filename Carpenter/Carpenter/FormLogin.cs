using DevExpress . XtraEditors;
using System;
using System . Configuration;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormLogin :FormBase
    {
        //获取Configuration对象
        Configuration config = ConfigurationManager . OpenExeConfiguration ( /*ConfigurationUserLevel.None*/System . Windows . Forms . Application . ExecutablePath );

        public FormLogin ( )
        {
            InitializeComponent ( );
            
            labUserName . Visible = labPassW . Visible = labTip . Visible = false;

            SetImage . setImage ( pictureBox1 ,"SetConn.png" );

            UserLogin . userName = CarpenterBll . UserInformation . UserName = config . AppSettings . Settings [ "UserName" ] . Value;
            UserLogin . userNum = config . AppSettings . Settings [ "UserNum" ] . Value;
            UserLogin . sign = config . AppSettings . Settings [ "Sign" ] . Value;

            if ( UserLogin . sign . Equals ( "1" ) )
            {
                txtUserName . Text = UserLogin . userName;
                txtUserName . Tag = UserLogin . userNum;
            }
        }
        
        private void FormLogin_Load ( object sender ,EventArgs e )
        {
            
        }

        private void button2_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void btnOk_Click ( object sender ,EventArgs e )
        {
            labUserName . Visible = labPassW . Visible = labTip.Visible= false;
            bool isOk = true;
            if ( string . IsNullOrEmpty ( txtUserName . Text ) )
            {
                labUserName . Text = "请输入用户名";
                labUserName . Visible = true;
                isOk = false;
                txtUserName . Focus ( );
            }
            if ( string . IsNullOrEmpty ( txtPassW . Text ) )
            {
                labPassW . Text = "请输入密码";
                labPassW . Visible = true;
                isOk = false;
                txtPassW . Focus ( );
            }
            if ( isOk == false )
            {
                this . DialogResult = System . Windows . Forms . DialogResult . None;
                return;
            }

            UserLogin . userName = CarpenterBll . UserInformation . UserName = txtUserName . Text;
            try
            {
                readNum ( );
            }
            catch ( Exception ex )
            {
                XtraMessageBox . Show ( "请检查连接参数" );
                Utility . LogHelper . WriteLog ( ex . StackTrace );
                return;
            }
            UserLogin . sign = chxUserName . Checked == true ? "1" : "0";
            string password = txtPassW . Text;
            string pwdMD5 = Utility . DesEncryptUtil .EncryptMD5 ( password );
            
            CarpenterBll . Bll . EmployeeBll _bll = new CarpenterBll . Bll . EmployeeBll ( );
            try
            {
                bool result = _bll . yesOrNoLogin ( UserLogin . userName ,pwdMD5 );
                if ( result == false )
                {
                    this . DialogResult = System . Windows . Forms . DialogResult . None;
                    labTip . Text = "登录失败，用户名或密码错误";
                    labTip . Visible = true;
                    return;
                }
            }
            catch ( Exception ex )
            {
                XtraMessageBox . Show ( "请检查网络是否正常" );
                Utility . LogHelper . WriteLog ( ex . StackTrace );
            }
            
            
            SaveUser ( );
            DialogResult = System . Windows . Forms . DialogResult . OK;
            this . Close ( );
        }

        protected void readNum ( )
        {
            CarpenterBll . Bll . EmployeeBll _bll = new CarpenterBll . Bll . EmployeeBll ( );
            UserLogin . userNum = _bll . GetUserNum ( UserLogin . userName );
        }

        protected void SaveUser ( )
        {
            //删除<add>元素
            config . AppSettings . Settings . Remove ( "UserName" );
            config . AppSettings . Settings . Remove ( "UserNum" );
            config . AppSettings . Settings . Remove ( "Sign" );
            //写入<add>元素的value
            //config.AppSettings.Settings["UserName"].Value = userName;
            //config.AppSettings.Settings["PassWord"].Value = passWord;
            //增加<add> 元素
            config . AppSettings . Settings . Add ( "UserName" ,UserLogin.userName );
            config . AppSettings . Settings . Add ( "UserNum" ,UserLogin . userNum );
            config . AppSettings . Settings . Add ( "Sign" ,UserLogin . sign );
            //一定要记得保存，写不带参数的config.Save()也可以
            config . Save ( ConfigurationSaveMode . Modified );
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            System . Configuration . ConfigurationManager . RefreshSection ( "appSettings" );
        }

        private void pictureBox1_Click ( object sender ,EventArgs e )
        {
            Connection . Form1 form = new Connection . Form1 ( );
            form . StartPosition = System . Windows . Forms . FormStartPosition . CenterScreen;
            form . ShowDialog ( );
        }

    }
}
