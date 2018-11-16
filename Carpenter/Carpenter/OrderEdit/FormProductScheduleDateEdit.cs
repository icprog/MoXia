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
    public partial class FormProductScheduleDateEdit :FormBase
    {
        DataRow rowEdit;
        CarpenterBll.Bll.ProductScheduleBll _bll=null;
        CarpenterEntity.ProductScheduleEntity model=null;

        public FormProductScheduleDateEdit (DataRow row )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . ProductScheduleBll ( );
            model = new CarpenterEntity . ProductScheduleEntity ( );

            rowEdit = row;
            setValue ( );
        }

        void setValue ( )
        {
            if ( rowEdit == null )
                return;
            labP . Text = rowEdit [ "PRS001" ] . ToString ( );
            labPro . Text = rowEdit [ "PRS002" ] . ToString ( );
            dtJ . Text = rowEdit [ "PRS031" ] . ToString ( );
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void btnOk_Click ( object sender ,EventArgs e )
        {
            model . PRS001 = labP . Text;
            model . PRS002 = labPro . Text;
            if ( string . IsNullOrEmpty ( dtJ . Text ) )
                model . PRS031 = null;
            else
                model . PRS031 = Convert . ToDateTime ( dtJ . Text );
            bool result = _bll . EditDate ( model );
            if ( result )
            {
                XtraMessageBox . Show ( "成功编辑" );
                this . DialogResult = DialogResult . OK;
            }
            else
                XtraMessageBox . Show ( "编辑失败" );
        }

        public string getDate
        {
            get
            {
                return dtJ . Text;
            }
        }

    }
}