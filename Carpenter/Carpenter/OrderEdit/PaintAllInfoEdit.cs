using DevExpress . XtraEditors;
using System;

namespace Carpenter . OrderEdit
{
    public partial class PaintAllInfoEdit :FormBC
    {
        CarpenterEntity.ProductionPaintEntity _model=null;
        public PaintAllInfoEdit ( string text ,CarpenterEntity . ProductionPaintEntity _model )
        {
            InitializeComponent ( );

            this . Text = text;

            this . _model = new CarpenterEntity . ProductionPaintEntity ( );
            txtPDP005 . Text = _model . PDP005 . ToString ( );
            dtPDP007 . Text = _model . PDP007 . ToString ( );
            mePDP006 . Text = _model . PDP006;
            txtPDP020 . Text = _model . PDP020 . ToString ( );
            mePDP021 . Text = _model . PDP021;
            txtPDP005 . Tag = _model . idx;
        }

        private void btnOk_Click ( object sender ,EventArgs e )
        {
            _model . idx = Convert . ToInt32 ( txtPDP005 . Tag );
            _model . PDP005 = string . IsNullOrEmpty ( txtPDP005 . Text ) == true ? 0 : Convert . ToInt32 ( txtPDP005 . Text );
            if ( string . IsNullOrEmpty ( dtPDP007 . Text ) )
                _model . PDP007 = null;
            else
                _model . PDP007 = Convert . ToDateTime ( dtPDP007 . Text );
            _model . PDP006 = mePDP006 . Text;
            _model . PDP020 = string . IsNullOrEmpty ( txtPDP020 . Text ) == true ? 0 : Convert . ToInt32 ( txtPDP020 . Text );
            _model . PDP021 = mePDP021 . Text;
            CarpenterBll . Bll . ProductionPaintBll _bll = new CarpenterBll . Bll . ProductionPaintBll ( );

            bool result = _bll . Edit ( _model );
            if ( result )
            {
                XtraMessageBox . Show ( "成功编辑" );
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
            }
            else
                XtraMessageBox . Show ( "编辑失败" );
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }

        public CarpenterEntity . ProductionPaintEntity getModel
        {
            get
            {
                return _model;
            }
        }

    }
}
