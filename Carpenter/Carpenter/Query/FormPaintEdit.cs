using DevExpress . XtraEditors;
using System;
using System . Windows . Forms;

namespace Carpenter . Query
{
    public partial class FormPaintEdit :FormBase
    {
        CarpenterEntity.PAITEntity _model=new CarpenterEntity.PAITEntity();
        CarpenterBll.Bll.WoodPaintBll _bll=new CarpenterBll.Bll.WoodPaintBll();
        
        public FormPaintEdit (string text,CarpenterEntity.PAITEntity _model )
        {
            InitializeComponent ( );

            this . Text = text;
            this . _model = _model;

            if ( this . Text == "编辑" )
            {
                texPaintNum . Text = _model . PAI004;
                texPaintName . Text = _model . PAI005;
                texPaintSpeci . Text = _model . PAI006;
                texPaintUnit . Text = _model . PAI007;
                texPaintConsu . Text = _model . PAI008 . ToString ( );
                texClass . Text = _model . PAI009;
            }
        }

        private void btnOk_Click ( object sender ,EventArgs e )
        {
            errorProvider1 . Clear ( );
            bool isOk = true;
            if ( string . IsNullOrEmpty ( texPaintNum . Text ) )
            {
                errorProvider1 . SetError ( texPaintNum ,"不可为空" );
                isOk = false;
            }
            if ( string . IsNullOrEmpty ( texPaintName . Text ) )
            {
                errorProvider1 . SetError ( texPaintName ,"不可为空" );
                isOk = false;
            }
            decimal outPut = 0M;
            if ( !string . IsNullOrEmpty ( texPaintConsu . Text ) && decimal . TryParse ( texPaintConsu . Text ,out outPut ) == false )
            {
                errorProvider1 . SetError ( texPaintConsu ,"请输入数字" );
                isOk = false;
            }
            if ( isOk == false )
                return;

            _model . PAI004 = texPaintNum . Text;
            _model . PAI005 = texPaintName . Text;
            _model . PAI006 = texPaintSpeci . Text;
            _model . PAI007 = texPaintUnit . Text;
            _model . PAI008 = string . IsNullOrEmpty ( texPaintConsu . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texPaintConsu . Text ) ,4 );
            _model . PAI009 = texClass . Text;
            _model . PAI010 = DateTime . Now;
            _model . PAI011 = UserLogin . userName;

            if ( this . Text == "新增" )
            {
                if ( _bll . Exists ( "MOXPAI" ,"PAI004" ,_model . PAI004 ) )
                {
                    XtraMessageBox . Show ( "油漆编码：" + _model . PAI004 + "已存在,请编辑" );
                    return;
                }
                _model . PAI012 = false;
                _model . idx = _bll . AddPaint ( _model );
                if ( _model . idx > 0 )
                {
                    XtraMessageBox . Show ( "新增成功" );
                    this . DialogResult = DialogResult . OK;
                }
                else
                    XtraMessageBox . Show ( "新增失败,请重试" );
            }
            else if ( this . Text == "编辑" )
            {
                isOk = _bll . EditPaint ( _model );
                if ( isOk == true )
                {
                    XtraMessageBox . Show ( "编辑成功" );
                    this . DialogResult = System . Windows . Forms . DialogResult . OK;
                }
                else
                    XtraMessageBox . Show ( "编辑失败,请重试" );
            }
        }

        private void btnCan_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }

        public CarpenterEntity . PAITEntity getPaint
        {
            get
            {
                return _model;
            }
        }

        private void FormPaintEdit_Click ( object sender ,EventArgs e )
        {
            if ( this . Text == "新增" )
            {
                Carpenter . Query . FormBomWorkPlanQuery from = new Carpenter . Query . FormBomWorkPlanQuery ( "油漆信息查询" ,"FormPaintEdit" );
                DialogResult result = from . ShowDialog ( );
                if ( result == DialogResult . OK )
                {
                    CarpenterEntity . OPIEntity _model = from . getModel;
                    texPaintNum . Text = _model . OPI001;
                    texPaintName . Text = _model . OPI002;
                    texPaintSpeci . Text = _model . OPI005;
                    texPaintUnit . Text = _model . OPI007;
                }
            }
        }
    }
}
