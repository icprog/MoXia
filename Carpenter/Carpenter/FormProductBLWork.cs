using System;
using System . ComponentModel;
using System . Data;

namespace Carpenter
{
    public partial class FormProductBLWork :FormChild
    {
        CarpenterBll.Bll.ProductBLWorkBll _bll=null;
        CarpenterEntity.productBLWorkEntity _entity=null;
        string strWhere=string . Empty;
        DataTable tableQuery;

        public FormProductBLWork ( )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . ProductBLWorkBll ( );
            _entity = new CarpenterEntity . productBLWorkEntity ( );
        }

        private void FormProductBLWork_Load ( object sender ,EventArgs e )
        {
            DataTable dt = _bll . getDataTable ( );
            lupPart . Properties . DataSource = dt . DefaultView . ToTable ( true ,"PST001" );
            lupPart . Properties . DisplayMember = "PST001";
            lupPro . Properties . DataSource = dt . DefaultView . ToTable ( true ,new string [ ] { "PST002" ,"PST003" } );
            lupPro . Properties . DisplayMember = "PST002";

            wait . Hide ( );
        }

        protected override int Query ( )
        {
            strWhere = string . Empty;
            if ( !string . IsNullOrEmpty ( lupPart . Text ) )
                strWhere = strWhere + " AND PRD007='" + lupPart . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPro . Text ) )
                strWhere = strWhere + " AND PRD008='" + lupPro . Text + "'";

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }

        private void btnClear_Click ( object sender ,EventArgs e )
        {
            lupPart . EditValue = lupPro . EditValue = null;
        }

        private void backgroundWorker1_DoWork ( object sender ,DoWorkEventArgs e )
        {
            tableQuery = _bll . getDataTableToView ( strWhere );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                gridControl1 . DataSource = tableQuery;
            }
        }

    }
}