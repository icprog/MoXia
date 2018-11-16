

using DevExpress . XtraEditors;
using System;
using System . Windows . Forms;

namespace Carpenter . Query
{
    public partial class FormWoodEdit :FormBase
    {
        CarpenterEntity.WOODEntity _model=new CarpenterEntity.WOODEntity();
        CarpenterBll.Bll.WoodPaintBll _bll=new CarpenterBll.Bll.WoodPaintBll();

        public FormWoodEdit (string text ,CarpenterEntity.WOODEntity _model)
        {
            InitializeComponent ( );

            this . Text = text;
            this . _model = _model;

            if ( this . Text == "编辑" )
            {
                texWoodNum . Text = _model . WOD004;
                texWoodName . Text = _model . WOD005;
                texWoodSpeci . Text = _model . WOD006;
                texWoodUnit . Text = _model . WOD007;
                texConsu . Text = _model . WOD008 . ToString ( );
            }
        }

        private void btnOk_Click ( object sender ,System . EventArgs e )
        {
            errorProvider1 . Clear ( );
            bool isOk = true;
            if ( string . IsNullOrEmpty ( texWoodNum . Text ) )
            {
                errorProvider1 . SetError ( texWoodNum ,"不可为空" );
                isOk = false;
            }
            if ( string . IsNullOrEmpty ( texWoodName . Text ) )
            {
                errorProvider1 . SetError ( texWoodName ,"不可为空" );
                isOk = false;
            }
            decimal outPut = 0M;
            if ( !string . IsNullOrEmpty ( texConsu . Text ) && decimal . TryParse ( texConsu . Text ,out outPut ) == false )
            {
                errorProvider1 . SetError ( texConsu ,"请输入数字" );
                isOk = false;
            }
            if ( isOk == false )
                return;

            _model . WOD004 = texWoodNum . Text;
            _model . WOD005 = texWoodName . Text;
            _model . WOD006 = texWoodSpeci . Text;
            _model . WOD007 = texWoodUnit . Text;
            _model . WOD008 = string . IsNullOrEmpty ( texConsu . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texConsu . Text ) ,6 );
            _model . WOD009 = DateTime . Now;
            _model . WOD010 = UserLogin . userName;

            if ( this . Text . Equals ( "新增" ) )
            {
                if ( _bll . Exists ( "MOXWOD" ,"WOD004" ,_model . WOD004 ) )
                {
                    XtraMessageBox . Show ( "木材编码：" + _model . WOD004 + "已经存在,请编辑","提示" );
                    return;
                }
                _model . WOD011 = false;
                _model . idx = _bll . AddWood ( _model );
                if ( _model . idx > 0 )
                {
                    XtraMessageBox . Show ( "新增成功" ,"提示" );
                    this . DialogResult = DialogResult . OK;
                }
                else
                    XtraMessageBox . Show ( "新增失败,请重试" ,"提示" );
            }
            else if ( this . Text . Equals ( "编辑" ) )
            {
                isOk = _bll . EditWood ( _model );
                if ( isOk == true )
                {
                    XtraMessageBox . Show ( "编辑成功" ,"提示" );
                    this . DialogResult = DialogResult . OK;
                }
                else
                    XtraMessageBox . Show ( "编辑失败,请重试" ,"提示" );
            }
        }

        private void btnCan_Click ( object sender ,System . EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }

        public CarpenterEntity . WOODEntity getMood
        {
            get
            {
                return _model;
            }
        }

        private void texWoodNum_Click ( object sender ,EventArgs e )
        {
            if ( this . Text . Equals ( "新增" ) )
            {
                Carpenter . Query . FormBomWorkPlanQuery from = new Carpenter . Query . FormBomWorkPlanQuery ( "木材信息查询" ,"FormWoodEdit" );
                DialogResult result = from . ShowDialog ( );
                if ( result == DialogResult . OK )
                {
                    CarpenterEntity . OPIEntity _model = from . getModel;
                    texWoodNum . Text = _model . OPI001;
                    texWoodName . Text = _model . OPI002;
                    texWoodSpeci . Text = _model . OPI005;
                    texWoodUnit . Text = _model . OPI007;
                }
            }
        }

    }
}
