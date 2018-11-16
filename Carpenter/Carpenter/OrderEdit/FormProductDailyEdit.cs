using DevExpress . XtraEditors;
using System;
using System . Data;
using System . Windows . Forms;

namespace Carpenter . OrderEdit
{
    public partial class FormProductDailyEdit :FormBase
    {
        CarpenterBll.Bll.ProductDailyWorkBll _bll=null; CarpenterEntity.ProductDailyWorkEntity _model=null;

        public FormProductDailyEdit ( DataRow row )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . ProductDailyWorkBll ( );
            _model = new CarpenterEntity . ProductDailyWorkEntity ( );


            InitData ( );
            setValue ( row );
        }
        
        void setValue ( DataRow row )
        {
            textEdit1 . Tag = row [ "idx" ];
            textEdit1 . Text = row [ "PRD007" ] . ToString ( );
            textEdit2 . Text = row [ "PRD003" ] . ToString ( );
            textEdit3 . Text = row [ "PRD009" ] . ToString ( );
            textEdit4 . Text = row [ "PRD011" ] . ToString ( );
            textEdit5 . Text = row [ "PRD034" ] . ToString ( );
            textEdit6 . Text = row [ "PRD007" ] . ToString ( );
            textEdit7 . Text = row [ "PRD002" ] . ToString ( );
            textEdit8 . Text = row [ "PRD005" ] . ToString ( );
            textEdit9 . Text = row [ "PRD004" ] . ToString ( );
            textEdit10 . Text = row [ "PRD032" ] . ToString ( );
            textEdit11 . Text = row [ "PRD005" ] . ToString ( );
            textEdit12 . Text = row [ "PRD037" ] . ToString ( );
            textEdit13 . Text = row [ "PRD036" ] . ToString ( );
            textEdit14 . Text = row [ "PRD039" ] . ToString ( );
            textEdit15 . Text = row [ "PRD038" ] . ToString ( );
            textEdit16 . Text = row [ "PRD041" ] . ToString ( );
            textEdit17 . Text = row [ "PRD040" ] . ToString ( );
            textEdit18 . Text = row [ "PRD023" ] . ToString ( );
            textEdit19 . Text = row [ "PRD033" ] . ToString ( );
            textEdit20 . Text = row [ "PRD012" ] . ToString ( );
            checkEdit2 . Checked = string . IsNullOrEmpty ( row [ "PRD020" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( row [ "PRD020" ] . ToString ( ) );
            checkEdit1 . Checked = string . IsNullOrEmpty ( row [ "PRD021" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( row [ "PRD021" ] . ToString ( ) );
        }
        void InitData ( )
        {
            textEdit19 . Properties . Items . Clear ( );
            foreach ( string art in CarpenterBll . ColumnValues . artSaType )
            {
                textEdit19 . Properties . Items . Add ( art );
            }
        }

        bool getValue ( )
        {
            dxErrorProvider1 . ClearErrors ( );
            decimal outResult = 0;
            int outResultNum = 0;
            if ( string . IsNullOrEmpty ( textEdit18 . Text ) )
            {
                dxErrorProvider1 . SetError ( textEdit18 ,"不可为空" );
                return false;
            }
            if ( !string . IsNullOrEmpty ( textEdit18 . Text ) && int . TryParse ( textEdit18 . Text ,out outResultNum ) == false )
            {
                dxErrorProvider1 . SetError ( textEdit18 ,"请输入整数" );
                return false;
            }
            _model . PRD023 = outResultNum;
            _model . idx = textEdit1 . Tag == null ? 0 : Convert . ToInt32 ( textEdit1 . Tag );
            if ( string . IsNullOrEmpty ( textEdit19 . Text ) )
            {
                dxErrorProvider1 . SetError ( textEdit19 ,"不可为空" );
                return false;
            }
            _model . PRD033 = textEdit19 . Text;
            //if ( string . IsNullOrEmpty ( textEdit13 . Text ) )
            //{
            //    dxErrorProvider1 . SetError ( textEdit13 ,"不可为空" );
            //    return false;
            //}
            _model . PRD036 = textEdit13 . Text;
            outResult = 0;
            //if ( string . IsNullOrEmpty ( textEdit12 . Text ) )
            //{
            //    dxErrorProvider1 . SetError ( textEdit12 ,"不可为空" );
            //    return false;
            //}
            if ( !string . IsNullOrEmpty ( textEdit12 . Text ) && decimal . TryParse ( textEdit12 . Text ,out outResult ) == false )
            {
                dxErrorProvider1 . SetError ( textEdit12 ,"请输入整数" );
                return false;
            }
            _model . PRD037 = outResult;
            //if ( string . IsNullOrEmpty ( textEdit15 . Text ) )
            //{
            //    dxErrorProvider1 . SetError ( textEdit15 ,"不可为空" );
            //    return false;
            //}
            _model . PRD038 = textEdit15 . Text;
            outResult = 0;
            //if ( string . IsNullOrEmpty ( textEdit14 . Text ) )
            //{
            //    dxErrorProvider1 . SetError ( textEdit14 ,"不可为空" );
            //    return false;
            //}
            if ( !string . IsNullOrEmpty ( textEdit14 . Text ) && decimal . TryParse ( textEdit14 . Text ,out outResult ) == false )
            {
                dxErrorProvider1 . SetError ( textEdit14 ,"请输入整数" );
                return false;
            }
            _model . PRD039 = outResult;
            //if ( string . IsNullOrEmpty ( textEdit17 . Text ) )
            //{
            //    dxErrorProvider1 . SetError ( textEdit17 ,"不可为空" );
            //    return false;
            //}
            _model . PRD040 = textEdit17 . Text;
            outResult = 0;
            //if ( string . IsNullOrEmpty ( textEdit16 . Text ) )
            //{
            //    dxErrorProvider1 . SetError ( textEdit16 ,"不可为空" );
            //    return false;
            //}
            if ( !string . IsNullOrEmpty ( textEdit16 . Text ) && decimal . TryParse ( textEdit16 . Text ,out outResult ) == false )
            {
                dxErrorProvider1 . SetError ( textEdit16 ,"请输入整数" );
                return false;
            }
            _model . PRD041 = outResult;
            _model . PRD020 = checkEdit2 . Checked;
            _model . PRD021 = checkEdit1 . Checked;

            return true;
        }

        private void btnSure_Click ( object sender ,EventArgs e )
        {
            if ( getValue ( ) == false )
                return;
            bool result = _bll . Edit ( _model );
            if ( result )
            {
                XtraMessageBox . Show ( "成功保存" );
                this . DialogResult = DialogResult . OK;
            }
            else
                XtraMessageBox . Show ( "保存失败" );
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        public CarpenterEntity . ProductDailyWorkEntity getModel
        {
            get
            {
                return _model;
            }
        }

    }
}