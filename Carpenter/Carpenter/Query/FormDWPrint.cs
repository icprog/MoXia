
using DevExpress . XtraEditors;
using System;
using System . Data;

namespace Carpenter . Query
{
    public partial class FormDWPrint :FormBase
    {
        DataTable dt;
        
        string[] strArry;

        public FormDWPrint ( string text )
        {
            InitializeComponent ( );

            dt = new DataTable ( );
            strArry = new string [ 3 ];

            this . Text = text;

            this . dwP . btnOk . Click += BtnOk_Click;
            this . dwP . btnCancel . Click += BtnCancel_Click;

            if ( this . Text . Equals ( "备料" ) )
            {
                foreach ( string s in CarpenterBll . ColumnValues . bl )
                {
                    dwP . cmbWorkShop . Properties . Items . Add ( s );
                }
                CarpenterBll . Bll . PlanStockDailyWorkBll _bll = new CarpenterBll . Bll . PlanStockDailyWorkBll ( );

                dt = _bll . GetDataTableDWPerson ( );
                if ( dt == null || dt . Rows . Count < 1 )
                    return;

                dwP . cmbPerson . Properties . DataSource = dt;
                dwP . cmbPerson . Properties . DisplayMember = "PDW014";

            }

            if ( this . Text . Equals ( "机加工" ) )
            {
                foreach ( string s in CarpenterBll . ColumnValues . jjg )
                {
                    dwP . cmbWorkShop . Properties . Items . Add ( s );
                }
                CarpenterBll . Bll . PlanMachinDayDailyWorkBll _bll = new CarpenterBll . Bll . PlanMachinDayDailyWorkBll ( );

                dt = _bll . GetDataTableDWPerson ( );
                if ( dt == null || dt . Rows . Count < 1 )
                    return;
                
                dwP . cmbPerson . Properties . DataSource = dt;
                dwP . cmbPerson . Properties . DisplayMember = "PMY014";

            }

            if ( this . Text . Equals ( "组装" ) )
            {
                dwP . cmbWorkShop . Text = "组装";
                CarpenterBll . Bll . PlanAssembleDayDailyBll _bll = new CarpenterBll . Bll . PlanAssembleDayDailyBll ( );

                dt = _bll . GetDataTableDWPerson ( );
                if ( dt == null || dt . Rows . Count < 1 )
                    return;

                dwP . cmbPerson . Properties . DataSource = dt;
                dwP . cmbPerson . Properties . DisplayMember = "PLF014";

            }

            if ( this . Text . Equals ( "油漆" ) )
            {
                foreach ( string s in CarpenterBll . ColumnValues . yq )
                {
                    dwP . cmbWorkShop . Properties . Items . Add ( s );
                }
                //dwP . cmbWorkShop . Properties . Items . Add ( CarpenterBll . ColumnValues . yq_bz );
                CarpenterBll . Bll . ProductionPaintDayDailyBll _bll = new CarpenterBll . Bll . ProductionPaintDayDailyBll ( );

                dt = _bll . GetDataTableDWPerson ( );
                if ( dt == null || dt . Rows . Count < 1 )
                    return;

                dwP . cmbPerson . Properties . DataSource = dt;
                dwP . cmbPerson . Properties . DisplayMember = "PWF014";

            }

        }
        
        private void BtnCancel_Click ( object sender ,System . EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }

        private void BtnOk_Click ( object sender ,System . EventArgs e )
        {
            if ( string . IsNullOrEmpty ( dwP . cmbWorkShop . Text ) )
            {
                XtraMessageBox . Show ( "请选择报工工段" );
                return;
            }
            if ( string . IsNullOrEmpty ( dwP . cmbPerson . Text ) )
            {
                XtraMessageBox . Show ( "请选择报工人" );
                return;
            }
            if ( string . IsNullOrEmpty ( dwP . dateEdit . Text ) )
            {
                XtraMessageBox . Show ( "请选择报工时间" );
                return;
            }

            Array . Clear ( strArry ,0 ,strArry . Length );
            strArry [ 0 ] = dwP . cmbWorkShop . Text;
            strArry [ 1 ] = dwP . cmbPerson . Text;
            strArry [ 2 ] = dwP . dateEdit . Text;

            this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }

        public string [ ] getStr
        {
            get
            {
                return strArry;
            }
        }

    }
}


