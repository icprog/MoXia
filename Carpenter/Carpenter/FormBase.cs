using System . Data;
using System . Windows . Forms;
using FastReport;
using FastReport . Export . Xml;
using System;

namespace Carpenter
{
    public partial class FormBase :FormBC
    {
        public FormBase ( )
        {
            InitializeComponent ( );
        }

        private void FormBase_Load ( object sender ,System . EventArgs e )
        {

        }


        private void panel1_Paint ( object sender ,PaintEventArgs e )
        {


        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="printFile"></param>
        protected void Print ( DataTable [ ] dt ,string printFile )
        {
            DataSet ds = new DataSet ( );
            if ( dt . Length > 0 )
            {
                for ( int i = 0 ; i < dt . Length ; i++ )
                {
                    ds . Tables . Add ( dt [ i ]  );
                }
            }

            if ( ds != null && ds . Tables . Count > 0 )
            {
                string file = Application . StartupPath + "\\" + printFile + "";
                Report report = new Report ( );
                report . Load ( file );
                report . RegisterData ( ds );
                report . Show ( );
            }

        }

        /// <summary>
        /// 导出Execl
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="printFile"></param>
        protected void Export ( DataTable [ ] dt ,string printFile )
        {
            DataSet ds = new DataSet ( );
            if ( dt . Length > 0 )
            {
                for ( int i = 0 ; i < dt . Length ; i++ )
                {
                    ds . Tables . Add ( dt [ i ]  );
                }
            }

            if ( ds != null && ds . Tables . Count > 0 )
            {
                string file = Application . StartupPath + "\\" + printFile + "";
                Report report = new Report ( );
                report . Load ( file );
                report . RegisterData ( ds );
                report . Prepare ( );
                XMLExport exprots = new XMLExport ( );
                exprots . Export ( report );
            }
        }

    }
}
