using DevExpress . XtraEditors;
using System;
using System . Data;

namespace Carpenter . Query
{
    public partial class FormDWPrintWeek :FormBase
    {
        DataTable dt,tableName;

        string[] strArry;
        
        public FormDWPrintWeek ( string text )
        {
            InitializeComponent ( );

            this . Text = text;
            
            dt = new DataTable ( );
            

            this . dwp . btnOk . Click += BtnOk_Click;
            this . dwp . btnCancel . Click += BtnCancel_Click;
            this . dwp . lupYear . TextChanged += LupYear_TextChanged;

            if ( this . Text . Contains ( "备料" ) )
            {
                CarpenterBll . Bll . PlanStockDailyWeekBll _bll = new CarpenterBll . Bll . PlanStockDailyWeekBll ( );
                dwp . lupYear . Properties . DataSource = _bll . GetDataTableYear ( );
                dwp . lupYear . Properties . DisplayMember = "PDK001";
                dwp . lupPerson . Properties . DataSource = _bll . GetDataTablePerson ( );
                dwp . lupPerson . Properties . DisplayMember = "PDK014";

                tableName = _bll . getTableForName ( );
                if ( tableName != null && tableName . Rows . Count > 0 )
                {
                    cmbName . Properties . Items . Clear ( );
                    foreach ( DataRow row in tableName . Rows )
                    {
                        cmbName . Properties . Items . Add ( row [ "NAME" ] );
                    }
                }
            }
            
            if ( this . Text . Contains ( "机加工" ) )
            {
                CarpenterBll . Bll . PlanMachinWeekDailyWorkBll _bll = new CarpenterBll . Bll . PlanMachinWeekDailyWorkBll ( );
                dwp . lupYear . Properties . DataSource = _bll . GetDataTableYear ( );
                dwp . lupYear . Properties . DisplayMember = "PME001";
                dwp . lupPerson . Properties . DataSource = _bll . GetDataTablePerson ( );
                dwp . lupPerson . Properties . DisplayMember = "PME014";

                tableName = _bll . getTableForName ( );
                if ( tableName != null && tableName . Rows . Count > 0 )
                {
                    cmbName . Properties . Items . Clear ( );
                    foreach ( DataRow row in tableName . Rows )
                    {
                        cmbName . Properties . Items . Add ( row [ "NAME" ] );
                    }
                }

            }

            if ( this . Text . Contains ( "组装" ) )
            {
                CarpenterBll . Bll . PlanAssembleWeekDailyBll _bll = new CarpenterBll . Bll . PlanAssembleWeekDailyBll ( );
                dwp . lupYear . Properties . DataSource = _bll . GetDataTableYear ( );
                dwp . lupYear . Properties . DisplayMember = "PLC001";
                dwp . lupPerson . Properties . DataSource = _bll . GetDataTablePerson ( );
                dwp . lupPerson . Properties . DisplayMember = "PLC014";
            }

            if ( this . Text . Contains ( "油漆" ) )
            {
                CarpenterBll . Bll . ProductionPaintWeekDailyBll _bll = new CarpenterBll . Bll . ProductionPaintWeekDailyBll ( );
                dwp . lupYear . Properties . DataSource = _bll . GetDataTableYear ( );
                dwp . lupYear . Properties . DisplayMember = "PWI001";
                dwp . lupPerson . Properties . DataSource = _bll . GetDataTablePerson ( );
                dwp . lupPerson . Properties . DisplayMember = "PWI014";
            }

        }
        
        private void LupYear_TextChanged ( object sender ,EventArgs e )
        {
            if ( this . Text . Contains ( "备料" ) )
            {
                CarpenterBll . Bll . PlanStockDailyWeekBll _bll = new CarpenterBll . Bll . PlanStockDailyWeekBll ( );
                dwp . lupWeek . Properties . DataSource = _bll . GetDataTableWeek ( dwp . lupYear . Text );
                dwp . lupWeek . Properties . DisplayMember = "PLS002";
            }
            if ( this . Text . Contains ( "机加工" ) )
            {
                CarpenterBll . Bll . PlanMachinWeekDailyWorkBll _bll = new CarpenterBll . Bll . PlanMachinWeekDailyWorkBll ( );
                dwp . lupWeek . Properties . DataSource = _bll . GetDataTableWeek ( dwp . lupYear . Text );
                dwp . lupWeek . Properties . DisplayMember = "PMC009";
            }
            if ( this . Text . Contains ( "组装" ) )
            {
                CarpenterBll . Bll . PlanAssembleWeekDailyBll _bll = new CarpenterBll . Bll . PlanAssembleWeekDailyBll ( );
                dwp . lupWeek . Properties . DataSource = _bll . GetDataTableWeek ( dwp . lupYear . Text );
                dwp . lupWeek . Properties . DisplayMember = "PLA009";
            }
            if ( this . Text . Contains ( "油漆" ) )
            {
                CarpenterBll . Bll . ProductionPaintWeekDailyBll _bll = new CarpenterBll . Bll . ProductionPaintWeekDailyBll ( );
                dwp . lupWeek . Properties . DataSource = _bll . GetDataTableWeek ( dwp . lupYear . Text );
                dwp . lupWeek . Properties . DisplayMember = "PWG009";
            }
        }

        private void BtnCancel_Click ( object sender ,System . EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }

        private void BtnOk_Click ( object sender ,System . EventArgs e )
        {
            if ( string . IsNullOrEmpty ( dwp . lupYear . Text ) )
            {
                XtraMessageBox . Show ( "请选择年" );
                return;
            }
            if ( string . IsNullOrEmpty ( dwp . lupWeek . Text ) )
            {
                XtraMessageBox . Show ( "请选择周次" );
                return;
            }
            if ( string . IsNullOrEmpty ( dwp . lupPerson . Text ) )
            {
                XtraMessageBox . Show ( "请选择报工人" );
                return;
            }
            strArry = new string [ 3 ];
            Array . Clear ( strArry ,0 ,strArry . Length );
            strArry [ 0 ] = dwp . lupYear . Text;
            strArry [ 1 ] = dwp . lupWeek . Text;
            strArry [ 2 ] = dwp . lupPerson . Text;

            this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }
        
        public string [ ] getStr
        {
            get
            {
                return strArry;
            }
        }

        private void btnCancel_Click_1 ( object sender ,EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }

        private void btnOk_Click_1 ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( dtOrder . Text ) )
            {
                XtraMessageBox . Show ( "请选择报工日期" );
                return;
            }
            if ( string . IsNullOrEmpty ( cmbName . Text ) )
            {
                XtraMessageBox . Show ( "请选择报工人" );
                return;
            }
            strArry = new string [ 2 ];
            Array . Clear ( strArry ,0 ,strArry . Length );
            strArry [ 0 ] = Convert . ToDateTime ( dtOrder . Text ) . ToString ( "yyyyMMdd" );
            strArry [ 1 ] = cmbName . Text;

            this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }

    }
}