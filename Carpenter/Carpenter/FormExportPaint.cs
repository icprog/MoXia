using DevExpress . XtraEditors;
using System;
using System . Data;
using System . IO;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormExportPaint :Form
    {
        CarpenterBll.Bll.ExportPaintBll _bll=null;
        DataTable table;

        public FormExportPaint ( )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . ExportPaintBll ( );
            table = new DataTable ( );
        }

        //check execl
        private void btnChoise_Click ( object sender ,EventArgs e )
        {
            choise ( txtChoise );           
        }
        //save to database from gridcontrol
        private void btnSave_Click ( object sender ,EventArgs e )
        {
            bool result = _bll . SavePaintBase ( table );
            if ( result )
                XtraMessageBox . Show ( "保存成功" );
            else
                XtraMessageBox . Show ( "保存失败" );
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
                  table=  ExeclExportHelper . InitializeWorkBAll ( text . Text ,20 );
                }
                else if ( extendName . Equals ( ".xlsx" ) )
                {
                  table=  ExeclExportHelper . InitializeWorkBookAll ( text . Text ,20 );
                }

                gridControl1 . DataSource = table;
            }
        }

    }
}
