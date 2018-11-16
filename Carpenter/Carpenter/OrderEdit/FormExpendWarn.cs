using DevExpress . Utils . Paint;
using System . Data;
using System . Reflection;

namespace Carpenter . OrderEdit
{
    public partial class FormExpendWarn :FormBase
    {
        public FormExpendWarn ( DataTable table, string text )
        {
            InitializeComponent ( );

            gridControl1 . DataSource = table;
            this . Text = text + this . Text;

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            FieldInfo fi = typeof ( XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );
        }

        private void toolExport_Click ( object sender ,System . EventArgs e )
        {
            ViewExport . ExportToExcel ( this . Text ,this . gridControl1 );
        }
    }
}