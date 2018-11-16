using System;
using System . IO;
using System . Windows . Forms;

namespace test
{
    public partial class FormExportPaint :Form
    {
        public FormExportPaint ( )
        {
            InitializeComponent ( );
        }

        //check execl
        private void btnChoise_Click ( object sender ,EventArgs e )
        {
            choise ( txtChoise );           
        }
        //save to database from gridcontrol
        private void btnSave_Click ( object sender ,EventArgs e )
        {

        }

        void choise ( DevExpress.XtraEditors.TextEdit text )
        {
            OpenFileDialog open = new OpenFileDialog ( );
            open . Filter = "Execl文件|*.xlx;*.xlsx;*.xls";
            if ( open . ShowDialog ( ) == DialogResult . OK )
            {
                text . Text = open . FileName;
                string extendName = Path . GetExtension ( text . Text );
                if ( extendName . Equals ( ".xls" ) || extendName . Equals ( ".xlx" ) )
                {
                  gridControl1.DataSource=  ExeclExportHelper . InitializeWorkBAll ( text . Text ,20 );
                }
                else if ( extendName . Equals ( ".xlsx" ) )
                {
                  gridControl1.DataSource=  ExeclExportHelper . InitializeWorkBookAll ( text . Text ,20 );
                }
            }
        }

    }
}
