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
    public partial class FormProductDailyWorkArtEdit :FormBase
    {
        CarpenterEntity . ProductDailyWorkPREEntity model;
        CarpenterBll.Bll.ProductDailyWorkBll _bll=null;


        public FormProductDailyWorkArtEdit ( DataRow row )
        {
            InitializeComponent ( );

            this . model = new CarpenterEntity . ProductDailyWorkPREEntity ( );
            _bll = new CarpenterBll . Bll . ProductDailyWorkBll ( );

            setValue ( row );

        }

        void setValue ( DataRow row )
        {
            txtPRE003 . Text = row [ "PRE003" ] . ToString ( );
            txtPRE004 . Text = row [ "PRE004" ] . ToString ( );
            txtPRE005 . Text = row [ "PRE005" ] . ToString ( );
            txtPRE006 . Text = row [ "PRE006" ] . ToString ( );
            txtPRE008 . Text = row [ "PRE008" ] . ToString ( );
            txtPRE009 . Text = row [ "PRE009" ] . ToString ( );
            txtPRE010 . Text = row [ "PRE010" ] . ToString ( );
            txtPRE011 . Text = row [ "PRE011" ] . ToString ( );
            txtPRE003 . Tag = row [ "idx" ] . ToString ( );
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void btnSure_Click ( object sender ,EventArgs e )
        {
            dxErrorProvider1 . ClearErrors ( );
            decimal ourResult = 0M;
            if ( !string . IsNullOrEmpty ( txtPRE003 . Text ) && decimal . TryParse ( txtPRE003 . Text ,out ourResult ) == false )
            {
                dxErrorProvider1 . SetError ( txtPRE003 ,"请输入数字" );
                return;
            }
            model . PRE003 = ourResult;
            ourResult = 0M;
            if ( !string . IsNullOrEmpty ( txtPRE004 . Text ) && decimal . TryParse ( txtPRE004 . Text ,out ourResult ) == false )
            {
                dxErrorProvider1 . SetError ( txtPRE004 ,"请输入数字" );
                return;
            }
            model . PRE004 = ourResult;
            ourResult = 0M;
            if ( !string . IsNullOrEmpty ( txtPRE005 . Text ) && decimal . TryParse ( txtPRE005 . Text ,out ourResult ) == false )
            {
                dxErrorProvider1 . SetError ( txtPRE005 ,"请输入数字" );
                return;
            }
            model . PRE005 = ourResult;
            ourResult = 0M;
            if ( !string . IsNullOrEmpty ( txtPRE008 . Text ) && decimal . TryParse ( txtPRE008 . Text ,out ourResult ) == false )
            {
                dxErrorProvider1 . SetError ( txtPRE008 ,"请输入数字" );
                return;
            }
            model . PRE008 = ourResult;
            ourResult = 0M;
            if ( !string . IsNullOrEmpty ( txtPRE009 . Text ) && decimal . TryParse ( txtPRE009 . Text ,out ourResult ) == false )
            {
                dxErrorProvider1 . SetError ( txtPRE009 ,"请输入数字" );
                return;
            }
            model . PRE009 = ourResult;
            ourResult = 0M;
            if ( !string . IsNullOrEmpty ( txtPRE010 . Text ) && decimal . TryParse ( txtPRE010 . Text ,out ourResult ) == false )
            {
                dxErrorProvider1 . SetError ( txtPRE010 ,"请输入数字" );
                return;
            }
            model . PRE010 = ourResult;
            ourResult = 0M;
            if ( !string . IsNullOrEmpty ( txtPRE011 . Text ) && decimal . TryParse ( txtPRE011 . Text ,out ourResult ) == false )
            {
                dxErrorProvider1 . SetError ( txtPRE011 ,"请输入数字" );
                return;
            }
            model . PRE011 = ourResult;
            model . idx = Convert . ToInt32 ( txtPRE003 . Tag );
            model . PRE006 = txtPRE006 . Text;

            bool result = _bll . editArt ( model );
            if ( result )
                this . DialogResult = DialogResult . OK;
            else
                XtraMessageBox . Show ( "编辑失败,请重试" );
        }

        public CarpenterEntity . ProductDailyWorkPREEntity getModel
        {
            get
            {
                return model;
            }
        }
    }
}