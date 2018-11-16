using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Linq;
using System . Text;
using System . Windows . Forms;

namespace Carpenter . Query
{
    public partial class SetReviewEdit :FormBase
    {
        CarpenterBll.Bll.SetReviewBll _bll=new CarpenterBll.Bll.SetReviewBll();
        CarpenterEntity.SetReviewEntity _model=new CarpenterEntity.SetReviewEntity();
        string nameOfPerson=string.Empty,nameOfProgram=string.Empty;

        public SetReviewEdit (string text ,CarpenterEntity.SetReviewEntity _model,string nameOfPerson,string nameOfProgram)
        {
            InitializeComponent ( );

            this . Text = text;
            this . _model = _model;
            this . nameOfPerson = nameOfPerson;
            this . nameOfProgram = nameOfProgram;

            CarpenterBll . Bll . PowerBll _bll = new CarpenterBll . Bll . PowerBll ( );
            lupNamePerson . Properties . DataSource = _bll . GetPerson ( );
            lupNamePerson . Properties . DisplayMember = "EMP002";
            lupNamePerson . Properties . ValueMember = "EMP001";
            lupNamePro . Properties . DataSource = _bll . GetProgram ( );
            lupNamePro . Properties . DisplayMember = "FOR001";
            lupNamePro . Properties . ValueMember = "FOR002";
        }

        private void SetReviewEdit_Load ( object sender ,EventArgs e )
        {
            lupNamePerson . Text = nameOfPerson;
            lupNamePro . Text = nameOfProgram;
            texLevel . Text = _model . SRE004;
            texLevel . Tag = _model . idx;
        }

        private void btnOk_Click ( object sender ,EventArgs e )
        {
            errorProvider1 . Clear ( );
            bool isOk = true;
            if (string.IsNullOrEmpty(lupNamePerson.Text))
            {
                errorProvider1 . SetError ( lupNamePerson ,"人员信息不可为空" );
                isOk = false;
            }
            if ( string . IsNullOrEmpty ( lupNamePro . Text ) )
            {
                errorProvider1 . SetError ( lupNamePro ,"程序信息不可为空" );
                isOk = false;
            }
            if ( string . IsNullOrEmpty ( texLevel . Text ) )
            {
                errorProvider1 . SetError ( lupNamePro ,"程序类别不可为空" );
                isOk = false;
            }
            if ( isOk == false )
                return;
            _model . SRE002 = lupNamePro . EditValue . ToString ( );
            _model . SRE003 = lupNamePerson . EditValue . ToString ( );
            _model . SRE004 = texLevel . Text;
            _model . SRE005 = DateTime . Now;
            _model . SRE006 = UserLogin . userName;
            if ( this . Text == "新增" )
            {
                _model . idx = _bll . Save ( _model );
                if ( _model . idx > 0 )
                {
                    XtraMessageBox . Show ( "新增成功" );
                    this . DialogResult = System . Windows . Forms . DialogResult . OK;
                }
                else
                    XtraMessageBox . Show ( "新增失败,请重试" );
            }
            else if ( this . Text == "编辑" )
            {
                _model . idx = int . Parse ( texLevel . Tag . ToString ( ) );
                isOk = _bll . Edit ( _model );
                if ( isOk == true )
                {
                    XtraMessageBox . Show ( "编辑成功" );
                    this . DialogResult = System . Windows . Forms . DialogResult . OK;
                }
                else
                    XtraMessageBox . Show ( "编辑失败,请重试" );
            }
            else
                XtraMessageBox . Show ( "请重新选择新增或编辑" );
        }

        private void btnCan_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }
    }
}
