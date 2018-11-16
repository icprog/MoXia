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
    public partial class FormPiceWageStatisticalTableEdit :FormBase
    {
        CarpenterBll.Bll.PiceWageStatisticalTableBll _bll=null;
        CarpenterEntity . PiceWageStatisticalTableEntity _model =null;

        public FormPiceWageStatisticalTableEdit ( DataRow row  )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . PiceWageStatisticalTableBll ( );
            _model = new CarpenterEntity . PiceWageStatisticalTableEntity ( );
            setValue ( row );
        }

        void setValue ( DataRow row )
        {
            txtPWS011 . Text = row [ "PWS011" ] . ToString ( );
            txtPWS012 . Text = row [ "PWS012" ] . ToString ( );
            txtPWS014 . Text = row [ "PWS014" ] . ToString ( );
            txtPWS015 . Text = row [ "PWS015" ] . ToString ( );
            txtPWS022 . Text = row [ "PWS022" ] . ToString ( );
            txtPWS029 . Text = row [ "PWS029" ] . ToString ( );
            txtPWS030 . Text = row [ "PWS030" ] . ToString ( );
            txtPWS031 . Text = row [ "PWS031" ] . ToString ( );
            txtPWS032 . Text = row [ "PWS032" ] . ToString ( );
            txtPWS028 . Text = row [ "PWS028" ] . ToString ( );
            _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] );
        }

        private void btnSure_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtPWS022 . Text ) )
            {
                XtraMessageBox . Show ( "请录入标准单价" );
                return;
            }
            decimal outResult = 0;
            if ( decimal . TryParse ( txtPWS022 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "标准单价应为数字" );
                return;
            }
           
            _model . PWS022 = outResult;
            _model . PWS011 = txtPWS011 . Text;
            _model . PWS012 = txtPWS012 . Text;
            _model . PWS014 = string . IsNullOrEmpty ( txtPWS014 . Text ) == true ? 0 : Convert . ToDecimal ( txtPWS014 . Text );
            _model . PWS015 = string . IsNullOrEmpty ( txtPWS015 . Text ) == true ? 0 : Convert . ToDecimal ( txtPWS015 . Text );
            _model . PWS029 = string . IsNullOrEmpty ( txtPWS029 . Text ) == true ? 0 : Convert . ToDecimal ( txtPWS029 . Text );
            _model . PWS030 = string . IsNullOrEmpty ( txtPWS030 . Text ) == true ? 0 : Convert . ToDecimal ( txtPWS030 . Text );
            _model . PWS031 = string . IsNullOrEmpty ( txtPWS031 . Text ) == true ? 0 : Convert . ToDecimal ( txtPWS031 . Text );
            _model . PWS032 = string . IsNullOrEmpty ( txtPWS032 . Text ) == true ? 0 : Convert . ToDecimal ( txtPWS032 . Text );
            _model . PWS028 = txtPWS028 . Text;

            bool result = _bll . EditArtPrice ( _model );
            if ( result )
            {
                XtraMessageBox . Show ( "编辑成功" );
                this . DialogResult = DialogResult . OK;
            }
            else
                XtraMessageBox . Show ( "编辑失败" );
        }
        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

    }
}




