using DevExpress . XtraEditors;
using System;
using System . Data;
using System . Windows . Forms;

namespace Carpenter . Query
{
    public partial class ProgramControlEdit :FormBase
    {
        CarpenterEntity.ProgramControlEntity _model;
        CarpenterBll.Bll.ProgramControlBll _bll=new CarpenterBll.Bll.ProgramControlBll();
        string sign=string.Empty;
        
        public ProgramControlEdit ( string text ,CarpenterEntity . ProgramControlEntity _model ,string sign)
        {
            InitializeComponent ( );

            this . Text = text;
            this . _model = _model;      
            this . sign = sign;

            comType . Items . Add ( "0" );
            comType . Items . Add ( "1" );
        
        }

        private void ProgramControlEdit_Load ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( _model . idx . ToString ( ) ) && _model . idx > 0 )
            {
                texName . Text = _model . FOR001;
                texName . Tag = _model . idx;
                texNum . Text = _model . FOR002;
                comType . Text = _model . FOR003 . Trim ( );
                texTab . Text = _model . FOR004;
            }
        }

        private void btnOk_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( sign ) )
            {
                XtraMessageBox . Show ( "请重新选择编辑或增加" );
                return;
            }
            errorProvider1 . Clear ( );
            bool isOk = true;
            if ( string . IsNullOrEmpty ( texName . Text ) )
            {
                errorProvider1 . SetError ( texName ,"程序名称不可为空" );
                isOk = false;
            }
            if ( string . IsNullOrEmpty ( texNum . Text ) )
            {
                errorProvider1 . SetError ( texName ,"程序编号不可为空" );
                isOk = false;
            }
            if ( string . IsNullOrEmpty ( comType . Text ) )
            {
                errorProvider1 . SetError ( texName ,"程序类别不可为空" );
                isOk = false;
            }
            if ( isOk == false )
                return;

            _model . FOR001 = texName . Text;
            _model . FOR002 = texNum . Text;
            _model . FOR003 = comType . Text;
            _model . FOR004 = texTab . Text;
            if ( sign == "add" )
            {
                _model . idx = _bll . Add ( _model );
                if ( _model . idx > 0 )
                {
                    XtraMessageBox . Show ( "增加成功" );
                    this . DialogResult = System . Windows . Forms . DialogResult . OK;
                }
                else
                    XtraMessageBox . Show ( "增加失败,请重试" );
            }
            else if ( sign == "edit" )
            {
                _model . idx = int . Parse ( texName . Tag . ToString ( ) );
                isOk = _bll . Edit ( _model );
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

    }
}
