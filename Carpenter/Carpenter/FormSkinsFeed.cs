using DevExpress . LookAndFeel;
using System . Configuration;
using System . Data;

namespace Carpenter
{
    public partial class FormSkinsFeed :DevExpress . XtraEditors . XtraForm
    {
        protected static DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel=new DevExpress.LookAndFeel.DefaultLookAndFeel();

        public FormSkinsFeed ( )
        {
            InitializeComponent ( );
            
            foreach ( DevExpress . Skins . SkinContainer skin in DevExpress . Skins . SkinManager . Default . Skins )
            {
                comboBox1 . Items . Add ( skin . SkinName );
            }

            DataTable table = new DataTable ( );
            table . Columns . Add ( "皮肤颜色预览" ,typeof ( System . String ) );
            for ( int i = 0 ; i < 100 ; i++ )
            {
                DataRow row = table . NewRow ( );
                row [ "皮肤颜色预览" ] = "湖州莫霞皮肤预览";
                table . Rows . Add ( row );
            }
            gridControl1 . DataSource = table;
        }

        private void comboBox1_TextChanged ( object sender ,System . EventArgs e )
        {
            defaultLookAndFeel . LookAndFeel . SkinName = comboBox1 . Text ;//Office 2013 Light Gray
        }

        private void simpleButton1_Click ( object sender ,System . EventArgs e )
        {
            //获取Configuration对象
            Configuration config = ConfigurationManager . OpenExeConfiguration ( /*ConfigurationUserLevel.None*/System . Windows . Forms . Application . ExecutablePath );
            //删除<add>元素
            config . AppSettings . Settings . Remove ( "Feed" ); //增加<add> 元素
            config . AppSettings . Settings . Add ( "Feed" ,comboBox1 . Text );
            //一定要记得保存，写不带参数的config.Save()也可以
            config . Save ( ConfigurationSaveMode . Modified );
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            System . Configuration . ConfigurationManager . RefreshSection ( "appSettings" );
        }
    }
}
