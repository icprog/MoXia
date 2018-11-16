

using DevExpress . XtraEditors;
using System;

namespace Carpenter . Query
{
    public partial class OPIEdit :FormBase
    {
        CarpenterEntity.OPIEntity _model=new CarpenterEntity.OPIEntity();
        CarpenterBll.Bll.OPIBll _bll=new CarpenterBll.Bll.OPIBll();


        public OPIEdit ( string text ,CarpenterEntity . OPIEntity _model ,bool result )
        {
            InitializeComponent ( );

            this . Text = text;
            this . _model = _model;
            
            comAtt . Items . Add ( "" );
            comAtt . Items . Add ( "常规" );
            comAtt . Items . Add ( "定制" );
            comClass . Items . Add ( "" );
            comClass . Items . Add ( "木材" );
            comClass . Items . Add ( "油漆" );
            comClass . Items . Add ( "成品" );
            comState . Items . Add ( "" );
            comState . Items . Add ( "在产" );
            comState . Items . Add ( "停产" );
            comState . Items . Add ( "样品" );
            comUnit . Items . Add ( "" );
            comUnit . Items . Add ( "PCS" );
            comUnit . Items . Add ( "平方" );
            comUnit . Items . Add ( "立方" );
            comUnit . Items . Add ( "公斤" );

            if ( result )
            {
                texProductNum . Enabled = texProductName.Enabled= texType.Enabled= false;
            }
        }
        
        private void OPIEdit_Load ( object sender ,System . EventArgs e )
        {
            if ( this . Text . Equals ( "编辑" ) )
            {
                texProductNum . Tag = _model . idx;
                texProductNum . Text = _model . OPI001;
                texProductName . Text = _model . OPI002;
                texClass . Text = _model . OPI003;
                texValue . Text = _model . OPI004 . ToString ( );
                texType . Text = _model . OPI005;
                texColor . Text = _model . OPI006;
                comUnit . Text = _model . OPI007;
                comState . Text = _model . OPI008;
                comAtt . Text = _model . OPI009;
                comClass . Text = _model . OPI010;
                pictureBoxProduct . Image = ReadOrWriteImageOfPicutre . ReadPicture ( _model . OPI012 );
            }
        }

        private void btnOk_Click ( object sender ,System . EventArgs e )
        {
            errorProvider1 . Clear ( );
            bool isOk = true;
            if ( string . IsNullOrEmpty ( texProductNum . Text ) )
            {
                errorProvider1 . SetError ( texProductNum ,"不可为空" );
                isOk = false;
            }
            if ( string . IsNullOrEmpty ( texProductName . Text ) )
            {
                errorProvider1 . SetError ( texProductName ,"不可为空" );
                isOk = false;
            }
            decimal outPutValue = 0M;
            if ( !string . IsNullOrEmpty ( texValue . Text ) && decimal . TryParse ( texValue . Text ,out outPutValue ) == false )
            {
                errorProvider1 . SetError ( texValue ,"产值为数字" );
                isOk = false;
            }
            if ( isOk == false )
                return;

            _model . OPI001 = texProductNum . Text;
            _model . OPI002 = texProductName . Text;
            _model . OPI003 = texClass . Text;
            _model . OPI004 = string . IsNullOrEmpty ( texValue . Text ) == true ? 0 : Convert . ToDecimal ( texValue . Text );
            _model . OPI005 = texType . Text;
            _model . OPI006 = texColor . Text;
            _model . OPI007 = comUnit . Text;
            _model . OPI008 = comState . Text;
            _model . OPI009 = comAtt . Text;
            _model . OPI010 = comClass . Text;
            
            if ( this . Text .Equals( "新增") )
            {
                _model . OPI011 = false;
                //numOfProduct ( );

                if ( _bll . Exists ( _model . OPI001 . Trim ( ) ) == true )
                {
                    XtraMessageBox . Show ( "品号:" + _model . OPI001 + "已经存在" ,"提示" );
                    return;
                }
                _model . idx = _bll . Add ( _model );
                if ( _model . idx > 0 )
                {
                    XtraMessageBox . Show ( "新增成功" ,"提示" );
                    texProductNum . Tag = _model . idx;
                    this . DialogResult = System . Windows . Forms . DialogResult . OK;
                }
                else
                    XtraMessageBox . Show ( "新增失败,请重试" ,"提示" );
            }
            else if ( this . Text .Equals( "编辑") )
            {
                _model . idx = int . Parse ( texProductNum . Tag . ToString ( ) );
                isOk = _bll . Edit ( _model );
                if ( isOk == true )
                {
                    XtraMessageBox . Show ( "编辑成功" ,"提示" );
                    this . DialogResult = System . Windows . Forms . DialogResult . OK;
                }
                else
                    XtraMessageBox . Show ( "编辑失败,请重试" ,"提示" );
            }
            else
            {
                XtraMessageBox . Show ( "请重新选择新增或编辑","提示" );
                this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
            }
        }
        
        private void btnCan_Click ( object sender ,System . EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }

        public CarpenterEntity . OPIEntity getModel
        {
            get
            {
                //_model . idx = int . Parse ( texProductNum . Tag . ToString ( ) );
                //_model . OPI001 = texProductNum . Text;
                //_model . OPI002 = texProductName . Text;
                //_model . OPI003 = texClass . Text;
                //_model . OPI004 = Math . Round ( Convert . ToDecimal ( texValue . Text ) ,2 );
                //_model . OPI005 = texType . Text;
                //_model . OPI006 = texColor . Text;
                //_model . OPI007 = comUnit . Text;
                //_model . OPI008 = comState . Text;
                //_model . OPI009 = comAtt . Text;
                //_model . OPI010 = comClass . Text;

                return _model;
            }
        }

        void numOfProduct ( )
        {
            _model . OPI001 = _bll . GetNum ( );
            if ( _model . OPI001 == string . Empty )
                _model . OPI001 = DateTime . Now . ToString ( "yyyyMMdd" ) + "001";
            else
            {
                if ( _model . OPI001 . Substring ( 0 ,8 ) == DateTime . Now . ToString ( "yyyyMMdd" ) )
                    _model . OPI001 = ( Convert . ToInt64 ( _model . OPI001 ) + 1 ) . ToString ( );
                else
                    _model . OPI001 = DateTime . Now . ToString ( "yyyyMMdd" ) + "001";
            }
        }

        private void btnDelete_Click ( object sender ,EventArgs e )
        {
            pictureBoxProduct . Image = null;
            pictureBoxProduct . ImageLocation = string . Empty;
            _model . OPI012 = new byte [ 0 ];
        }

        private void btnPicuter_Click ( object sender ,EventArgs e )
        {
            _model . OPI012 = ReadOrWriteImageOfPicutre . ReadPicture ( pictureBoxProduct );
            //string filePath = string . Empty;
            //OpenFileDialog old = new OpenFileDialog ( );
            //old . Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            //if ( old . ShowDialog ( ) == DialogResult . OK )
            //{
            //    filePath = old . FileName;//获取图片路径
            //    pictureBoxProduct . ImageLocation = filePath;

            //    FileStream fs = new FileStream ( filePath ,FileMode . Open ,FileAccess . Read );
            //    BinaryReader br = new BinaryReader ( fs );
            //    _model . OPI012 = br . ReadBytes ( ( int ) fs . Length );//图片转换成二进制流 
            //}
        }

        private void pictureBoxProduct_DoubleClick ( object sender ,EventArgs e )
        {
            if ( pictureBoxProduct . ImageLocation == string . Empty )
                return;
            FormPictureEnlarge from = new FormPictureEnlarge ( "产品图片" ,pictureBoxProduct . Image );
            from . ShowDialog ( );
        }
    }
}
