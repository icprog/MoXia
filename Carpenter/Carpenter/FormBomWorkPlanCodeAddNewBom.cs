using System;
using Carpenter . Query;
using System . Data;
using DevExpress . XtraEditors;

namespace Carpenter
{
    public partial class FormBomWorkPlanCodeAddNewBom :FormBase
    {
        CarpenterBll.Bll.BomWorkPlanCodeBll _bll;
        CarpenterEntity.BomWorkPlanCodeEntity _model;
        bool result = false;

        public FormBomWorkPlanCodeAddNewBom ( )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . BomWorkPlanCodeBll ( );
            _model = new CarpenterEntity . BomWorkPlanCodeEntity ( );
        }

        private void FormBomWorkPlanCodeAddNewBom_Load ( object sender ,EventArgs e )
        {
            txtCode . Text = _bll . getCodeNum ( );
            txtPartNum . Text = "001";
            secPinNum . Properties . DataSource = _bll . getProductInfo ( );
            secPinNum . Properties . DisplayMember = "OPI001";

            foreach ( string s in CarpenterBll . ColumnValues . strWorkType )
            {
                comWorkType . Properties . Items . Add ( s );
            }

            _model . WPC030 = new byte [ 0 ];
            _model . WPC031 = new byte [ 0 ];
            _model . WPC032 = new byte [ 0 ];
            _model . WPC033 = new byte [ 0 ];
        }
        
        private void pibOne_DoubleClick ( object sender ,EventArgs e )
        {
            if ( pibOne . ImageLocation == string . Empty )
                return;
            FormPictureEnlarge from = new FormPictureEnlarge ( "产品图片" ,pibOne . Image );
            from . ShowDialog ( );
        }
        private void picTwo_DoubleClick ( object sender ,EventArgs e )
        {
            if ( picTwo . ImageLocation == string . Empty )
                return;
            FormPictureEnlarge from = new FormPictureEnlarge ( "产品图片" ,picTwo . Image );
            from . ShowDialog ( );
        }
        private void picTre_DoubleClick ( object sender ,EventArgs e )
        {
            if ( picTre . ImageLocation == string . Empty )
                return;
            FormPictureEnlarge from = new FormPictureEnlarge ( "产品图片" ,picTre . Image );
            from . ShowDialog ( );
        }
        private void picFor_DoubleClick ( object sender ,EventArgs e )
        {
            if ( picFor . ImageLocation == string . Empty )
                return;
            FormPictureEnlarge from = new FormPictureEnlarge ( "产品图片" ,picFor . Image );
            from . ShowDialog ( );
        }

        private void btnPicAddOne_Click ( object sender ,EventArgs e )
        {
            _model . WPC030 =  ReadOrWriteImageOfPicutre . ReadPicture ( pibOne );
        }
        private void btnPicAddTwo_Click ( object sender ,EventArgs e )
        {
            _model . WPC031 = ReadOrWriteImageOfPicutre . ReadPicture ( picTwo );
        }
        private void btnPicAddTre_Click ( object sender ,EventArgs e )
        {
            _model . WPC032 = ReadOrWriteImageOfPicutre . ReadPicture ( picTre );
        }
        private void btnPicAddFor_Click ( object sender ,EventArgs e )
        {
            _model . WPC033 = ReadOrWriteImageOfPicutre . ReadPicture ( picFor );
        }

        private void btnDeletePicOne_Click ( object sender ,EventArgs e )
        {
            pibOne . Image = null;
            pibOne . ImageLocation = string . Empty;
            _model .WPC030 = new byte [ 0 ];
        }
        private void btnDeletePicTwo_Click ( object sender ,EventArgs e )
        {
            picTwo . Image = null;
            picTwo . ImageLocation = string . Empty;
            _model . WPC031 = new byte [ 0 ];
        }
        private void btnDeletePicTre_Click ( object sender ,EventArgs e )
        {
            picTre . Image = null;
            picTre . ImageLocation = string . Empty;
            _model . WPC032 = new byte [ 0 ];
        }
        private void btnDeletePicFor_Click ( object sender ,EventArgs e )
        {
            picFor . Image = null;
            picFor . ImageLocation = string . Empty;
            _model . WPC033 = new byte [ 0 ];
        }

        private void secPinNum_TextChanged ( object sender ,EventArgs e )
        {
            DataRow row = searchLookUpEdit1View . GetFocusedDataRow ( );
            if ( row == null )
                return;
            txtPinName . Text = row [ "OPI002" ] . ToString ( );
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }
        private void btnSave_Click ( object sender ,EventArgs e )
        {
            if ( CheckValue ( ) == false )
                return;
            getValue ( );

            result = _bll . Save ( _model );
            if ( result )
            {
                XtraMessageBox . Show ( "成功保存,请查询" );
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
            }
            else
                XtraMessageBox . Show ( "保存失败,请重试" );
        }

        void getValue ( )
        {
            _model . WPC001 = txtPiNum . Text;
            _model . WPC002 = secPinNum . Text;
            _model . WPC003 = txtPartNum . Text;
            _model . WPC004 = txtPartName . Text;
            _model . WPC005 = txtCode . Text;
            _model . WPC006 = txtLen . Text;
            _model . WPC007 = txtLenJ . Text;
            _model . WPC008 = txtLenC . Text;
            _model . WPC009 = txtWidth . Text;
            _model . WPC010 = txtWidthJ . Text;
            _model . WPC011 = txtWidthC . Text;
            _model . WPC012 = txtHeigh . Text;
            _model . WPC013 = txtHeighJ . Text;
            _model . WPC014 = txtHeighC . Text;
            _model . WPC015 = comWorkType . Text;
            _model . WPC016 = string . IsNullOrEmpty ( txtOrderNum . Text ) == true ? 0 : Convert . ToDecimal ( txtOrderNum . Text );
            _model . WPC017 = txtMate . Text;
            _model . WPC018 = string . IsNullOrEmpty ( txtBanH . Text ) == true ? 0 : Convert . ToInt32 ( txtBanH . Text );
            _model . WPC019 = txtPart . Text;
            _model . WPC020 = txtCaiLiao . Text;
            _model . WPC021 = txtRemark . Text;
            _model . WPC022 = CarpenterBll . UserInformation . dt ( );
            _model . WPC023 = UserLogin . userName;
            _model . WPC024 = txtPinFa . Text;
            _model . WPC025 = txtJi . Text;
            _model . WPC026 = txtDuan . Text;
            _model . WPC027 = string . IsNullOrEmpty ( txtPinWidth . Text ) == true ? 0 : Convert . ToInt32 ( txtPinWidth . Text );
            _model . WPC028 = string . IsNullOrEmpty ( txtPinGen . Text ) == true ? 0 : Convert . ToInt32 ( txtPinGen . Text );
            _model . WPC029 = txtNum . Text;
            _model . WPC036 = txtPinName . Text;
        }
        bool CheckValue ( )
        {
            dxErrorProvider1 . ClearErrors ( );
            if ( string . IsNullOrEmpty ( txtPiNum . Text ) )
            {
                dxErrorProvider1 . SetError ( txtPiNum ,"不可为空" );
                return false;
            }
            if ( string . IsNullOrEmpty ( secPinNum . Text ) )
            {
                dxErrorProvider1 . SetError ( secPinNum ,"不可为空" );
                return false;
            }
            decimal nums = 0;
            if (!string.IsNullOrEmpty(txtOrderNum.Text) && decimal . TryParse ( txtOrderNum . Text ,out nums ) == false )
            {
                dxErrorProvider1 . SetError ( txtOrderNum ,"请填写数字" );
                return false;
            }
            int numes = 0;
            if ( !string . IsNullOrEmpty ( txtBanH . Text ) && int . TryParse ( txtBanH . Text ,out numes ) == false )
            {
                dxErrorProvider1 . SetError ( txtBanH ,"请填写整数" );
                return false;
            }
            numes = 0;
            if ( !string . IsNullOrEmpty ( txtPinWidth . Text ) && int . TryParse ( txtPinWidth . Text ,out numes ) == false )
            {
                dxErrorProvider1 . SetError ( txtPinWidth ,"请填写整数" );
                return false;
            }
            numes = 0;
            if ( !string . IsNullOrEmpty ( txtPinGen . Text ) && int . TryParse ( txtPinGen . Text ,out numes ) == false )
            {
                dxErrorProvider1 . SetError ( txtPinGen ,"请填写整数" );
                return false;
            }

            return true;
        }

    }
}