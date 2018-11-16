using System;
using System . Xml;
using Helpers;
using System . Data;
using System . Windows . Forms;

namespace test
{
    public partial class FormXml :DevExpress . XtraEditors . XtraForm
    {
        public FormXml ( )
        {
            InitializeComponent ( );
        }


        private void button1_Click ( object sender ,EventArgs e )
        {
            //string path= "D:\\";
            DataTable table = new DataTable ( );
            XmlHelper . SaveTableToFile ( table ,Application . StartupPath );

        }

        private void button2_Click ( object sender ,EventArgs e )
        {

        }
    }
}