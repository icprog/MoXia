using System . Data;
using System . Reflection;

namespace Carpenter . ControlUser
{
    public partial class DLPlanDayPort :DevExpress . XtraEditors . XtraUserControl
    {
        public DLPlanDayPort ( )
        {
            InitializeComponent ( );
            
            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );
        }
    }
}
