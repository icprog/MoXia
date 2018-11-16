using System;
using System . Data;
using System . Windows . Forms;
using DevExpress . XtraEditors;
using System . IO;

namespace Carpenter
{
    public partial class FormExportWood :FormBase
    {
        CarpenterBll.Bll.ExportWoodBll _bll=null;

        DataTable table;

        public FormExportWood ( )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . ExportWoodBll ( );
            table = new DataTable ( );
        }

        //choise
        private void button2_Click ( object sender ,EventArgs e )
        {
            choise ( textEdit1 );
        }
        //save
        private void button1_Click ( object sender ,EventArgs e )
        {
            bool result = _bll . Save ( table );
            if ( result )
                XtraMessageBox . Show ( "保存成功" );
            else
                XtraMessageBox . Show ( "保存失败" );
        }

        void choise ( DevExpress . XtraEditors . TextEdit text )
        {
            OpenFileDialog open = new OpenFileDialog ( );
            open . Filter = "Execl文件|*.xlx;*.xlsx;*.xls";
            if ( open . ShowDialog ( ) == DialogResult . OK )
            {
                text . Text = open . FileName;
                string extendName = Path . GetExtension ( text . Text );
                if ( extendName . Equals ( ".xls" ) || extendName . Equals ( ".xlx" ) )
                {
                    table = ExeclExportHelper . InitializeWorkB ( text . Text ,20 );
                    //table = ExeclExportHelper . InitializeWorkBAll ( text . Text ,20 );
                }
                else if ( extendName . Equals ( ".xlsx" ) )
                {
                    table = ExeclExportHelper . InitializeWorkBook ( text . Text ,20 );
                    //table = ExeclExportHelper . InitializeWorkBookAll ( text . Text ,20 );
                }

                gridControl1 . DataSource = table;
            }
        }

    }
}