using System . Windows . Forms;

namespace Carpenter . ControlUser
{
    public partial class AddContact :UserControl
    {
        public AddContact ( )
        {
            InitializeComponent ( );
        }

        public string getStr
        {
            get
            {
                return richContact . Text;
            }
        }
    }
}
