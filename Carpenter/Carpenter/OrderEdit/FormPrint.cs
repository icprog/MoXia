using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Linq;
using System . Windows . Forms;
using DevExpress . XtraEditors;

namespace Carpenter . OrderEdit
{
    public partial class FormPrint :FormBase
    {
        string[] strArry;

        public FormPrint ( string text ,DataTable planName )
        {
            InitializeComponent ( );

            this . Text = text;

            if ( planName != null && planName . Rows . Count > 0 )
            {
                cmbName . Properties . Items . Clear ( );
                foreach ( DataRow row in planName . Rows )
                {
                    cmbName . Properties . Items . Add ( row [ "NAME" ] );
                }
            }
        }

        private void btnSure_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( dtOrder . Text ) )
            {
                XtraMessageBox . Show ( "请选择报工日期" );
                return;
            }
            if ( string . IsNullOrEmpty ( cmbName . Text ) )
            {
                XtraMessageBox . Show ( "请选择报工人" );
                return;
            }

            Array . Clear ( strArry ,0 ,strArry . Length );
            strArry [ 0 ] = Convert . ToDateTime ( dtOrder . Text ) . ToString ( "yyyyMMdd" );
            strArry [ 1 ] = cmbName . Text;

            this . DialogResult = DialogResult . OK;
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        public string [ ] getStr
        {
            get
            {
                return strArry;
            }
        }

    }
}