using System;
using System . Data;
using StudentMgr;
using DevExpress . XtraGrid . Views . Grid;
using System . Reflection;

namespace test
{
    public partial class Form2 :DevExpress.XtraEditors.XtraForm
    {
        public Form2 ( )
        {
            InitializeComponent ( );
        }

        protected static DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel=new DevExpress.LookAndFeel.DefaultLookAndFeel();

        private void button1_Click ( object sender ,EventArgs e )
        {
            foreach ( DevExpress . Skins . SkinContainer skin in DevExpress . Skins . SkinManager . Default . Skins )
            {
                comboBox1 . Items . Add ( skin . SkinName );
            }

              
        }

        private void comboBox1_SelectedValueChanged ( object sender ,EventArgs e )
        {
            defaultLookAndFeel . LookAndFeel . SkinName = comboBox1 . Text . ToString ( );//Office 2013 Light Gray
        }

        private void Form2_Load ( object sender ,EventArgs e )
        {
            DataTable dt = SqlHelper . ExecuteDataTable ( "SELECT PQF01,PQF02,PQF03,PQF04 FROM R_PQF" );
            gridControl1 . DataSource = dt;
        }

        private void gridView1_RowCellClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowCellClickEventArgs e )
        {
            var appobj = GetRowCellStyle ( ( sender as GridView ) ,e . RowHandle ,e . Column );

            labelControl1 . BackColor = appobj . BackColor;

            labelControl1 . ForeColor = appobj . ForeColor;
        }

        public virtual DevExpress . Utils . AppearanceObject GetRowCellStyle ( GridView view ,int rowHandle ,DevExpress . XtraGrid . Columns . GridColumn column )
        {
            System . Reflection . MethodInfo mi = view . GetType ( ) . GetMethod ( "GetRowCellStyle" ,BindingFlags . NonPublic | BindingFlags . Instance );

            using ( DevExpress . Utils . AppearanceObject app = new DevExpress . Utils . AppearanceObject ( ) )
            {
                app . Assign ( view . Appearance . Row );

                mi . Invoke ( view ,new object [ ] { rowHandle ,column ,DevExpress . XtraGrid . Views . Base . GridRowCellState . Default ,app } );

                return app;
            }
        }


    }
}
