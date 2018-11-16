
using DevExpress . Skins;
using System . Configuration;

namespace Carpenter
{
    public partial class FormBC :DevExpress . XtraEditors . XtraForm
    {
        public string strFeel=string.Empty;
        protected static DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel=new DevExpress.LookAndFeel.DefaultLookAndFeel(); 
        
        //获取Configuration对象
        Configuration config = ConfigurationManager . OpenExeConfiguration ( /*ConfigurationUserLevel.None*/System . Windows . Forms . Application . ExecutablePath );
        
        public FormBC ( )
        {
            InitializeComponent ( );

            strFeel = config . AppSettings . Settings [ "Feed" ] . Value;
            if ( string . IsNullOrEmpty ( strFeel ) )
                strFeel = "Office 2013";
            defaultLookAndFeel . LookAndFeel . SkinName = strFeel;

            Skin GridSkin = GridSkins . GetSkin ( defaultLookAndFeel . LookAndFeel );
            CarpenterBll . UserInformation . FeedColor = GridSkin [ GridSkins . SkinGridEvenRow ] . Color . BackColor;
        }

    }
}