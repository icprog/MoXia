

using DevExpress . XtraEditors;
using System;
using System . Data;
using System . Windows . Forms;

namespace Carpenter . Query
{
    public partial class FormPaintWorkProcedureEdit :FormBase
    {
        CarpenterEntity.PAIJEntity  _model=new CarpenterEntity.PAIJEntity();
        CarpenterBll.Bll.WoodPaintBll _bll=new CarpenterBll.Bll.WoodPaintBll();
        
        public FormPaintWorkProcedureEdit (string text,CarpenterEntity.PAIJEntity  _model)
        {
            InitializeComponent ( );

            this . Text = text;
            this . _model = _model;

            if ( this . Text == "编辑" )
            {
                texPaintNum . Text = _model . PAJ004;
                texGM . Text = _model . PAJ005 . ToString ( );
                texBP . Text = _model . PAJ006 . ToString ( );
                texDQ . Text = _model . PAJ007 . ToString ( );
                texYM . Text = _model . PAJ008 . ToString ( );
                texXS . Text = _model . PAJ009 . ToString ( );
                texMQ . Text = _model . PAJ010 . ToString ( );
                texPaintName . Text = _model . PAJ014;
                texPaintName . Tag = _model . PAJ015;
            }
        }

        private void btnOk_Click ( object sender ,System . EventArgs e )
        {
            errorProvider1 . Clear ( );
            bool isOk = true;
            if ( string . IsNullOrEmpty ( texPaintNum . Text ) )
            {
                errorProvider1 . SetError ( texPaintNum ,"不可为空" );
                isOk = false;
            }
            decimal outPut = 0M;
            if ( !string . IsNullOrEmpty ( texGM . Text ) && decimal . TryParse ( texGM . Text ,out outPut ) == false )
            {
                errorProvider1 . SetError ( texGM ,"请填写数字" );
                isOk = false;
            }
            outPut = 0M;
            if ( !string . IsNullOrEmpty ( texDQ . Text ) && decimal . TryParse ( texDQ . Text ,out outPut ) == false )
            {
                errorProvider1 . SetError ( texDQ ,"请填写数字" );
                isOk = false;
            }
            outPut = 0M;
            if ( !string . IsNullOrEmpty ( texBP . Text ) && decimal . TryParse ( texBP . Text ,out outPut ) == false )
            {
                errorProvider1 . SetError ( texBP ,"请填写数字" );
                isOk = false;
            }
            outPut = 0M;
            if ( !string . IsNullOrEmpty ( texMQ . Text ) && decimal . TryParse ( texMQ . Text ,out outPut ) == false )
            {
                errorProvider1 . SetError ( texMQ ,"请填写数字" );
                isOk = false;
            }
            outPut = 0M;
            if ( !string . IsNullOrEmpty ( texXS . Text ) && decimal . TryParse ( texXS . Text ,out outPut ) == false )
            {
                errorProvider1 . SetError ( texXS ,"请填写数字" );
                isOk = false;
            }
            outPut = 0M;
            if ( !string . IsNullOrEmpty ( texYM . Text ) && decimal . TryParse ( texYM . Text ,out outPut ) == false )
            {
                errorProvider1 . SetError ( texYM ,"请填写数字" );
                isOk = false;
            }
            if ( isOk == false )
                return;

            _model . PAJ004 = texPaintNum . Text;
            _model . PAJ005 = string . IsNullOrEmpty ( texGM . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texGM . Text ) ,2 );
            _model . PAJ006 = string . IsNullOrEmpty ( texBP . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texBP . Text ) ,2 );
            _model . PAJ007 = string . IsNullOrEmpty ( texDQ . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texDQ . Text ) ,2 );
            _model . PAJ008 = string . IsNullOrEmpty ( texYM . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texYM . Text ) ,2 );
            _model . PAJ009 = string . IsNullOrEmpty ( texXS . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texXS . Text ) ,2 );
            _model . PAJ010 = string . IsNullOrEmpty ( texMQ . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texMQ . Text ) ,2 );
            _model . PAJ011 = DateTime . Now;
            _model . PAJ012 = UserLogin . userName;
            _model . PAJ014 = texPaintName . Text;
            _model . PAJ015 = texPaintName . Tag . ToString ( );

            if ( this . Text . Equals ( "新增" ) )
            {
                if ( _bll . Exists ( _model ) )
                {
                    XtraMessageBox . Show ( "油漆编码：" + _model . PAJ004 + "油漆名称：" + _model . PAJ014 + "\n\r刮毛单价：" + _model . PAJ005 + "\n\r白坯单价：" + _model . PAJ006 + "\n\r底漆单价：" + _model . PAJ007 + "\n\r油磨单价：" + _model . PAJ008 + "\n\r修色单价：" + _model . PAJ009 + "\n\r面漆单价：" + _model . PAJ010 + "\n\r的记录已经存在" ,"提示" );
                    return;
                }
                paintOneNum ( );
                _model . PAJ013 = false;
                _model . idx = _bll . AddPaintWorkProcedure ( _model );
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
                isOk = _bll . EditPaintWorkProcedure ( _model );
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

        public CarpenterEntity . PAIJEntity getModel
        {
            get
            {
                return _model;
            }
        }

        void paintOneNum ( )
        {
            _model . PAJ002 = _bll . GetPaintOneNum ( _model . PAJ004 );
            if ( string . IsNullOrEmpty ( _model . PAJ002 ) )
                _model . PAJ002 = "001";
            else
            {
                _model . PAJ002 = ( Convert . ToInt32 ( _model . PAJ002 ) + 1 ) . ToString ( );
                _model . PAJ002 = _model . PAJ002 . PadLeft ( 3 ,'0' );
            }
        }

        private void texPaintNum_Click ( object sender ,EventArgs e )
        {
            if ( this . Text == "新增" )
            {
                Carpenter . Query . FormBomWorkPlanQuery from = new Carpenter . Query . FormBomWorkPlanQuery ( "油漆信息查询" ,"FormPaintWorkProcedureEdit" );
                DialogResult result = from . ShowDialog ( );
                if ( result == DialogResult . OK )
                {
                    CarpenterEntity . OPIEntity _model = from . getModel;
                    texPaintNum . Text = _model . OPI001;
                    texPaintName . Text = _model . OPI002;
                    texPaintName . Tag = _model . OPI005;
                }
            }
        }

    }
}
