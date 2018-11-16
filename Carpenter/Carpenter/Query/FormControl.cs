
using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Carpenter . Query
{
    public partial class FormControl :FormBase
    {
        string sign=string.Empty;
        DataTable tableQuery;
        Carpenter . ControlUser . PlanCutProduct proControl;
        Carpenter.ControlUser.PlanCutQuery planQuery;
        Carpenter.ControlUser.WeeklyPlan weekPlan;
        Carpenter.ControlUser.PlanStockQuery stockQuery;
        Carpenter.ControlUser.DayPlan dayPlan;
        Carpenter.ControlUser.DayPlanQuery dayQuery;
        Carpenter.ControlUser.PlanMachinQuery machinQuery;
        Carpenter.ControlUser.DayPlanMachinWork dayMachine;
        Carpenter.ControlUser.PlanAssmebleQuery assmebleQuery;
        Carpenter.ControlUser.DayPlanAssemebleWork dayAssemeble;
        Carpenter.ControlUser.AssembleWorkOrderQuery assQuery;
        Carpenter.ControlUser.ProductionPaintWeekQuery paintWeek;
        Carpenter.ControlUser.DayProductionPaintWork dayPaint;
        
        Carpenter.ControlUser.SetTransmitAdd setTran;
        Carpenter.ControlUser.MaintainTranmsmitPeoQuery mainQuery;
        Carpenter.ControlUser.AddContact contact;
        string batchNum=string.Empty,workShop=string.Empty;
                
        public FormControl ( string text ,string sign)
        {
            InitializeComponent ( );
            
            this . Text = text;
            this . sign = sign;

            this . Controls . Clear ( );

            #region FormPlanCutting
            if ( this . sign . Equals ( "FormPlanCutting" ) )
            {
                CarpenterBll . Bll . PlanCuttingBll _bll = new CarpenterBll . Bll . PlanCuttingBll ( );
                tableQuery = _bll . GetDataTableProduct ( "1=1" );
                proControl = new ControlUser . PlanCutProduct ( tableQuery );
                this . Controls . Add ( proControl );
                proControl . Dock = System . Windows . Forms . DockStyle . Fill;
                proControl . btnSure . Click += BtnSure_Click;
                proControl . btnCancel . Click += BtnCancel_Click;
            }
            #endregion

            #region FormPlanCutQuery
            else if ( this . sign . Equals ( "FormPlanCutQuery" ) )
            {
                CarpenterBll . Bll . PlanCuttingBll _bll = new CarpenterBll . Bll . PlanCuttingBll ( );
                tableQuery = _bll . GetDataTableProduct ( );
                planQuery = new ControlUser . PlanCutQuery ( tableQuery );
                this . Controls . Add ( planQuery );
                planQuery . Dock = System . Windows . Forms . DockStyle . Fill;
                planQuery . gridView1 . DoubleClick += GridView1_DoubleClick;
            }
            #endregion

            #region BLWeeklyPlan
            else if ( this . sign . Equals ( "BLWeeklyPlan" ) )
            {
                weekPlan = new ControlUser . WeeklyPlan ( );
                this . Controls . Add ( weekPlan );
                this . ClientSize = new System . Drawing . Size ( 381 ,191 );
                this . FormBorderStyle = FormBorderStyle . FixedSingle;
                this . MaximizeBox = false;
                weekPlan . Dock = System . Windows . Forms . DockStyle . Fill;
                weekPlan . btnOk . Click += BtnOk_Click;
                weekPlan . btnCancel . Click += BtnCancel_Click1;
            }
            #endregion

            #region FormPlanStock
            else if ( this . sign . Equals ( "FormPlanStock" ) )
            {
                CarpenterBll . Bll . PlanStockBll _bll = new CarpenterBll . Bll . PlanStockBll ( );
                tableQuery = _bll . GetDataTableQuery ( );
                stockQuery = new ControlUser . PlanStockQuery ( tableQuery );
                this . Controls . Add ( stockQuery );
                stockQuery . Dock = System . Windows . Forms . DockStyle . Fill;
                stockQuery . gridView1 . DoubleClick += GridView1_DoubleClick1;
            }
            #endregion

            #region BLDayPlan
            else if ( this . sign . Equals ( "BLDayPlan" ) )
            {
                dayPlan = new ControlUser . DayPlan ( "备料" );
                this . Controls . Add ( dayPlan );
                this . ClientSize = new System . Drawing . Size ( 287 ,212 );
                this . FormBorderStyle = FormBorderStyle . FixedSingle;
                this . MaximizeBox = false;
                dayPlan . Dock = System . Windows . Forms . DockStyle . Fill;
                dayPlan . btnOk . Click += BtnOk_Click1;
                dayPlan . btnCancel . Click += BtnCancel_Click2;
            }
            #endregion

            #region JDayPlan
            else if ( this . sign . Equals ( "JDayPlan" ) )
            {
                dayPlan = new ControlUser . DayPlan ( "机加工" );
                this . Controls . Add ( dayPlan );
                this . ClientSize = new System . Drawing . Size ( 287 ,212 );
                this . FormBorderStyle = FormBorderStyle . FixedSingle;
                this . MaximizeBox = false;
                dayPlan . Dock = System . Windows . Forms . DockStyle . Fill;
                dayPlan . btnOk . Click += BtnOk_Click1;
                dayPlan . btnCancel . Click += BtnCancel_Click2;
            }
            #endregion

            #region ZDayPlan
            else if ( this . sign . Equals ( "ZDayPlan" ) )
            {
                dayPlan = new ControlUser . DayPlan ( "组装" );
                this . Controls . Add ( dayPlan );
                this . ClientSize = new System . Drawing . Size ( 287 ,212 );
                this . FormBorderStyle = FormBorderStyle . FixedSingle;
                this . MaximizeBox = false;
                dayPlan . Dock = System . Windows . Forms . DockStyle . Fill;
                dayPlan . btnOk . Click += BtnOk_Click1;
                dayPlan . btnCancel . Click += BtnCancel_Click2;
            }
            #endregion

            #region PDayPlan
            else if ( this . sign . Equals ( "PDayPlan" ) )
            {
                dayPlan = new ControlUser . DayPlan ( "油漆" );
                this . Controls . Add ( dayPlan );
                this . ClientSize = new System . Drawing . Size ( 287 ,212 );
                this . FormBorderStyle = FormBorderStyle . FixedSingle;
                this . MaximizeBox = false;
                dayPlan . Dock = System . Windows . Forms . DockStyle . Fill;
                dayPlan . btnOk . Click += BtnOk_Click1;
                dayPlan . btnCancel . Click += BtnCancel_Click2;
            }
            #endregion

            #region FormPlanStockWork
            else if ( this . sign . Equals ( "FormPlanStockWork" ) )
            {
                CarpenterBll . Bll . PlanStockWorkBll _bll = new CarpenterBll . Bll . PlanStockWorkBll ( );
                tableQuery = _bll . GetDataTableQuery ( );
                dayQuery = new ControlUser . DayPlanQuery ( tableQuery );
                this . Controls . Add ( dayQuery );
                dayQuery . Dock = System . Windows . Forms . DockStyle . Fill;
                dayQuery . gridView1 . DoubleClick += GridView1_DoubleClick2;
            }
            #endregion

            #region FormSetTransmit
            else if ( this . sign . Equals ( "FormSetTransmit" ) )
            {
                setTran = new ControlUser . SetTransmitAdd ( );
                this . Controls . Add ( setTran );
                setTran . Dock = System . Windows . Forms . DockStyle . Fill;
                setTran . btnOk . Click += BtnOk_Click3;
                setTran . btnCancel . Click += BtnCancel_Click4;
            }
            #endregion

            #region FormMaintainTransmit
            else if ( this . sign . Equals ( "FormMaintainTransmit" ) )
            {
                mainQuery = new ControlUser . MaintainTranmsmitPeoQuery ( );
                this . Controls . Add ( mainQuery );
                mainQuery . Dock = System . Windows . Forms . DockStyle . Fill;
                mainQuery . btnOk . Click += BtnOk_Click4;
                mainQuery . btnCancel . Click += BtnCancel_Click5;
            }
            #endregion

            #region FormContact
            else if ( this . sign . Equals ( "FormContact" ) )
            {
                contact = new ControlUser . AddContact ( );
                this . Controls . Add ( contact );
                this . ClientSize = new System . Drawing . Size ( 450 ,245 );
                this . FormBorderStyle = FormBorderStyle . FixedSingle;
                this . MaximizeBox = false;
                contact . btnOk . Click += BtnOk_Click4;
                contact . btnCancel . Click += BtnCancel_Click5;
            }
            #endregion

            #region PlanMachine
            else if ( this . sign . Equals ( "PlanMachine" ) )
            {
                CarpenterBll . Bll . PlanMachinBll _bll = new CarpenterBll . Bll . PlanMachinBll ( );
                DataTable dt = _bll . GetDataTableQuery ( );
                machinQuery = new ControlUser . PlanMachinQuery ( dt );
                this . Controls . Add ( machinQuery );
                machinQuery . Dock = System . Windows . Forms . DockStyle . Fill;
                machinQuery . gridView1 . DoubleClick += GridView1_DoubleClick3;
            }
            #endregion

            #region FormPlanMachinWork
            else if ( this . sign . Equals ( "FormPlanMachinWork" ) )
            {
                CarpenterBll . Bll . PlanMachinWorkBll _bll = new CarpenterBll . Bll . PlanMachinWorkBll ( );
                DataTable dt = _bll . GetDataTableQuery ( );
                dayMachine = new ControlUser . DayPlanMachinWork ( dt );
                this . Controls . Add ( dayMachine );
                dayMachine . Dock = DockStyle . Fill;
                dayMachine . gridView1 . DoubleClick += GridView1_DoubleClick4;
            }
            #endregion

            #region PlanAssembleWeek
            else if ( this . sign . Equals ( "PlanAssembleWeek" ) )
            {
                CarpenterBll . Bll . PlanAssembleWeekBll _bll = new CarpenterBll . Bll . PlanAssembleWeekBll ( );
                DataTable dt = _bll . GetDataTableQuery ( );
                assmebleQuery = new ControlUser . PlanAssmebleQuery ( dt );
                this . Controls . Add ( assmebleQuery );
                assmebleQuery . Dock = System . Windows . Forms . DockStyle . Fill;
                assmebleQuery . gridView1 . DoubleClick += GridView1_DoubleClick5;
            }
            #endregion

            #region FormPlanAssembleDay
            else if ( this . sign . Equals ( "FormPlanAssembleDay" ) )
            {
                CarpenterBll . Bll . PlanAssembleDayBll _bll = new CarpenterBll . Bll . PlanAssembleDayBll ( );
                DataTable dt = _bll . GetDataTableQuery ( );
                dayAssemeble = new ControlUser . DayPlanAssemebleWork ( dt );
                this . Controls . Add ( dayAssemeble );
                dayAssemeble . Dock = DockStyle . Fill;
                dayAssemeble . gridView1 . DoubleClick += GridView1_DoubleClick6;
            }
            #endregion

            #region FormAssembleWorkOrder
            else if ( this . sign . Equals ( "FormAssembleWorkOrder" ) )
            {
                CarpenterBll . Bll . AssembleWorkOrderBll _bll = new CarpenterBll . Bll . AssembleWorkOrderBll ( );
                DataTable dt = _bll . table ( );
                assQuery = new ControlUser . AssembleWorkOrderQuery ( dt );
                this . Controls . Add ( assQuery );
                assQuery . Dock = DockStyle . Fill;
                assQuery . gridView1 . DoubleClick += GridView1_DoubleClick7;
            }
            #endregion

            #region ProductionPaintWeek
            else if ( this . sign . Equals ( "ProductionPaintWeek" ) )
            {
                CarpenterBll . Bll . ProductionPaintWeekBll _bll = new CarpenterBll . Bll . ProductionPaintWeekBll ( );
                DataTable dt = _bll . GetDataTableQuery ( );
                paintWeek = new ControlUser . ProductionPaintWeekQuery ( dt );
                this . Controls . Add ( paintWeek );
                paintWeek . Dock = System . Windows . Forms . DockStyle . Fill;
                paintWeek . gridView1 . DoubleClick += GridView1_DoubleClick8;
            }
            #endregion

            #region  FormProductionPaintDay
            else if ( this . sign . Equals ( "FormProductionPaintDay" ) )
            {
                CarpenterBll . Bll . ProductionPaintDayBll _bll = new CarpenterBll . Bll . ProductionPaintDayBll ( );
                DataTable dt = _bll . GetDataTableQuery ( );
                dayPaint = new ControlUser . DayProductionPaintWork ( dt );
                this . Controls . Add ( dayPaint );
                dayPaint . Dock = DockStyle . Fill;
                dayPaint . gridView1 . DoubleClick += GridView1_DoubleClick9;
            }
            #endregion

        }


        #region FormPlanAssembleDay

        private void GridView1_DoubleClick9 ( object sender ,EventArgs e )
        {
            int num = dayPaint . gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= dayPaint . gridView1 . DataRowCount - 1 )
            {
                batchNum = dayPaint . gridView1 . GetDataRow ( num ) [ "PWD001" ] . ToString ( );
                workShop = dayPaint . gridView1 . GetDataRow ( num ) [ "PWD002" ] . ToString ( );
                this . DialogResult = DialogResult . OK;
            }
        }

        #endregion

        #region ProductionPaintWeek
        private void GridView1_DoubleClick8 ( object sender ,EventArgs e )
        {
            int num = paintWeek . gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= paintWeek . gridView1 . DataRowCount - 1 )
            {
                batchNum = paintWeek . gridView1 . GetDataRow ( num ) [ "PWG001" ] . ToString ( );
                this . DialogResult = DialogResult . OK;
            }
        }
        #endregion

        #region FormAssembleWorkOrder

        private void GridView1_DoubleClick7 ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . OK;
        }

        #endregion

        #region FormPlanAssembleDay
        private void GridView1_DoubleClick6 ( object sender ,EventArgs e )
        {
            int num = dayAssemeble . gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= dayAssemeble . gridView1 . DataRowCount - 1 )
            {
                batchNum = dayAssemeble . gridView1 . GetDataRow ( num ) [ "PLD001" ] . ToString ( );
                this . DialogResult = DialogResult . OK;
            }
        }
        #endregion

        #region PlanAssembleWeek
        private void GridView1_DoubleClick5 ( object sender ,EventArgs e )
        {
            int num = assmebleQuery . gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= assmebleQuery . gridView1 . DataRowCount - 1 )
            {
                batchNum = assmebleQuery . gridView1 . GetDataRow ( num ) [ "PLA001" ] . ToString ( );
                this . DialogResult = DialogResult . OK;
            }
        }
        #endregion

        #region FormPlanMachinWork
        private void GridView1_DoubleClick4 ( object sender ,EventArgs e )
        {
            int num = dayMachine . gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= dayMachine . gridView1 . DataRowCount - 1 )
            {
                batchNum = dayMachine . gridView1 . GetDataRow ( num ) [ "PMW001" ] . ToString ( );
                workShop = dayMachine . gridView1 . GetDataRow ( num ) [ "PMW002" ] . ToString ( );
                this . DialogResult = DialogResult . OK;
            }
        }
        #endregion

        #region PlanMachine
        private void GridView1_DoubleClick3 ( object sender ,EventArgs e )
        {
            int num = machinQuery . gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= machinQuery . gridView1 . DataRowCount - 1 )
            {
                batchNum = machinQuery . gridView1 . GetDataRow ( num ) [ "PMC001" ] . ToString ( );
                this . DialogResult = DialogResult . OK;
            }
        }
        #endregion

        #region FormMaintainTransmit
        private void BtnCancel_Click5 ( object sender ,EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }
        private void BtnOk_Click4 ( object sender ,EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }
        #endregion

        #region FormSetTransmit
        private void BtnCancel_Click4 ( object sender ,EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }
        private void BtnOk_Click3 ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( setTran . lupTran . Text ) )
            {
                XtraMessageBox . Show ( "请选择单据" );
                return;
            }
            List<CarpenterBll . Paramete> tab = setTran . gethashL;
            if ( tab . Count < 2 )
            {
                XtraMessageBox . Show ( "请选择人员信息" );
                return;
            }        
            this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }
        #endregion

        #region FormPlanStockWork Event
        private void GridView1_DoubleClick2 ( object sender ,System . EventArgs e )
        {
            int num = dayQuery . gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= dayQuery . gridView1 . DataRowCount - 1 )
            {
                batchNum = dayQuery . gridView1 . GetDataRow ( num ) [ "PSW001" ] . ToString ( );
                workShop = dayQuery . gridView1 . GetDataRow ( num ) [ "PSW002" ] . ToString ( );
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
            }
        }
        #endregion

        #region dayPlan
        private void BtnOk_Click1 ( object sender ,System . EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }
        private void BtnCancel_Click2 ( object sender ,System . EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }
        #endregion

        #region FormPlanStock Event
        private void GridView1_DoubleClick1 ( object sender ,System . EventArgs e )
        {
            //stockQuery = new ControlUser . PlanStockQuery ( );
            int num = stockQuery . gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= stockQuery . gridView1 . DataRowCount - 1 )
            {
                batchNum = stockQuery . gridView1 . GetDataRow ( num ) [ "PLS001" ] . ToString ( );
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
            }
        }
        #endregion

        #region BLWeeklyPlan Event
        private void BtnOk_Click ( object sender ,System . EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }
        private void BtnCancel_Click1 ( object sender ,System . EventArgs e )
        {
            this . Close ( );
        }
        #endregion

        #region FormPlanCutQuery Event
        private void GridView1_DoubleClick ( object sender ,System . EventArgs e )
        {
            int num = planQuery. gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= planQuery.gridView1 . DataRowCount - 1 )
            {
                batchNum = planQuery. gridView1 . GetDataRow ( num ) [ "CUT001" ] . ToString ( );
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
            }
        }
        #endregion

        #region FormPlanCutting Event
        //Sure
        private void BtnSure_Click ( object sender ,System . EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }
        //Canecl
        private void BtnCancel_Click ( object sender ,System . EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }
        #endregion

        #region Method
        public List<string> GetstrList
        {
            get
            {
                return proControl . getTable;
            }
        }
        public string GetBarchNum
        {
            get
            {
                return batchNum;
            }
        }
        public string GetWorkShop
        {
            get
            {
                return workShop;
            }
        }
        public CarpenterEntity . PlanStockPLSEntity GetPLS
        {
            get
            {
                return weekPlan . GetPLS;
            }
        }
        public string GetBLOddNum
        {
            get
            {
                return batchNum;
            }
        }
        public CarpenterEntity . PlanStockWorkPSWEntity getDayBL
        {
            get
            {
                return dayPlan . getModel;
            }
        }
        public CarpenterEntity . PlanMachinWorkPMWEntity getDayJ
        {
            get
            {
                return dayPlan . getEntity;
            }
        }
        public CarpenterEntity . PlanAssembleDayPLDEntity getPld
        {
            get
            {
                return dayPlan . getPld;
            }
        }
        public CarpenterEntity . ProductionPaintDayPWDEntity getPwd
        {
            get
            {
                return dayPlan . getPwd;
            }
        }
        public List<CarpenterBll . Paramete> getHash
        {
            get
            {
                return setTran . gethashL;
            }
        }
        public List<CarpenterBll . Paramete> getMainHas
        {
            get
            {
                return mainQuery . getHas;
            }
        }
        public string getContact
        {
            get
            {
                return contact . getStr;
            }
        }
        public string getOdd
        {
            get
            {
                return assQuery . getOdd;
            }
        }
        #endregion
    }
}
