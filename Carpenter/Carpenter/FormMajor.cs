using DevExpress . XtraEditors;
using System;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Threading;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormMajor :FormBase
    {
        ThreadManager _threadManager=null;
        FormMaintainTransmit _formMaintain=null;
        int x=0;

        public FormMajor ( )
        {
            InitializeComponent ( );
            this . Location = new Point ( -1000 ,-1000 );
            //pictureBox1 . Visible = false;
            //SetImage . setImage ( this . pictureBox1 ,"LOGO.jpg" );
            SetImage . setImage ( this . splitContainer1 . Panel2 ,"LOGO.jpg" );
        }

        private void FormMajor_Load ( object sender ,EventArgs e )
        {
            Login ( );

            //SetImage . setImage ( pictureBox1 ,"BackGround.jpg" );
            //splitContainer1 . Panel2 . BackgroundImageLayout = ImageLayout . Stretch;        
        }

        protected void Login ( )
        {
            this . Hide ( );
            FormLogin form = new FormLogin ( );
            this . StartPosition = FormStartPosition . WindowsDefaultBounds;
            if ( form . ShowDialog ( ) == System . Windows . Forms . DialogResult . OK )
            {
                this . Location = new Point ( 0 ,0 );
                this . WindowState = FormWindowState . Maximized;
                this . Show ( );
                this . BringToFront ( );
                this . toolLogin . Text = UserLogin . userName + "(" + UserLogin . userNum + ")";

                ShowMenuByUser ( );
                //checkRemind ( );
                //StartBackThread ( );
            }
            else
            {
                x = 1;
                result = false;
                this . Close ( );
            }        
        }

        #region ThreadManager
        protected void StartBackThread ( )
        {
            _threadManager = new ThreadManager ( );
            _threadManager . UIAnnouncementCallBackEvent += _threadManager_UIAnnouncementCallBackEvent;
            _threadManager . StartThread ( );
        }
        void _threadManager_UIAnnouncementCallBackEvent ( object sender ,AnnouncementRemindEventArgs e )
        {
            if ( e . Table == null )
                return;
            if ( this . InvokeRequired )
            {
                this . Invoke ( new EventHandler<AnnouncementRemindEventArgs> ( _threadManager_UIAnnouncementCallBackEvent ) ,new object [ ] { sender ,e } );
            }
            else
            {
                if ( _formMaintain == null )
                {
                    _formMaintain = new FormMaintainTransmit ( );
                    _formMaintain . Location = new Point ( -1000 ,0 );
                }
                else
                {
                    _formMaintain = new FormMaintainTransmit ( );
                    _formMaintain . SetPosition ( );
                    _formMaintain . Show ( );
                }
                Utility . NativeMethods . ShowWindow ( new System . Runtime . InteropServices . HandleRef ( _formMaintain ,_formMaintain . Handle ) ,4 );
            }
        }
        void _formMaintain_OpenFormEvent ( object sender ,AnnouncementRemindEventArgs e )
        {
            if ( e == null || e . Table == null )
                return;
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = _formMaintain . Name;
            _formMaintain . Show ( );
        }
        #endregion

        #region premission setting
        void ShowMenuByUser ( )
        {
            if ( UserLogin . userNum . Equals ( "00001" ) )
                return;

            CarpenterBll . Bll . MainBll _bll = new CarpenterBll . Bll . MainBll ( );
            DataTable dt = _bll . GetDataTablePower ( UserLogin . userNum );

            Power ( baseN ,dt );
            Power ( planN ,dt );
            Power ( JPlanN ,dt );
            Power ( ZPlanN ,dt );
            Power ( PPlanN ,dt );
            Power ( OtherN ,dt );
        }
        void Power (DevExpress.XtraNavBar.NavBarGroup pnl,DataTable dt )
        {         
            if ( dt != null && dt . Rows . Count > 0 )
            {
                foreach ( DevExpress . XtraNavBar . NavBarItem cn in pnl . NavBar . Items )
                {
                    if ( !string . IsNullOrEmpty ( cn . Tag . ToString ( ) ) )
                    {
                        if ( dt . Select ( "POW003='" + cn . Tag . ToString ( ) + "'" ) . Length < 1 )
                            cn . Visible = false;
                        else
                            cn . Visible = true;
                    }
                    else
                        cn . Visible = false;
                }
            }
            else
            {
                foreach ( DevExpress . XtraNavBar . NavBarItem cn in pnl . NavBar . Items )
                {
                    cn . Visible = false;
                }
            }
        }
        #endregion

        #region button event
        private void ToolClose_Click ( object sender ,EventArgs e )
        {
            //if ( XtraMessageBox . Show ( "确认退出?" ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
            //{
                result = false;
                x = 0;
                this . Close ( );
            //}
        }
        private void ToolRstart_Click ( object sender ,EventArgs e )
        {
            Application . Restart ( );
        }
        private void ToolStripPwd_Click ( object sender ,EventArgs e )
        {
            Form from = new FormSetPW ( );
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = from . Name;
            from . Show ( );
        }
        private void ToolStripFeed_Click ( object sender ,EventArgs e )
        {
            FormSkinsFeed from = new FormSkinsFeed ( );
            from . Show ( );
        }
        private void ToolStripRemind_Click ( object sender ,EventArgs e )
        {
            Form from = new FormRemind ( );
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = from . Name;
            from . Show ( );
        }
        protected override void OnClosing ( CancelEventArgs e )
        {
            if ( x == 0 )
            {
                if ( XtraMessageBox . Show ( "确认退出?" ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
                {
                    result = false;
                    e . Cancel = false;
                }
                else
                    e . Cancel = true;
            }
        }
        #endregion

        #region basic information
        private void Powers_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPower";
            Form from = new FormPower ( );
            from . Show ( );
        }
        private void ProgramControl_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormProgramControl";
            Form from = new FormProgramControl ( );
            from . Show ( );
        }
        private void DepartMent_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormDepartMent";
            Form from = new FormDepartMent ( );
            from . Show ( );
        }
        private void Employee_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormEmployee";
            Form from = new FormEmployee ( );
            from . Show ( );
        }
        private void Art_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormArt";
            Form from = new FormArt ( );
            from . Show ( );
        }
        private void Equipment_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormEquipment";
            Form from = new FormEquipment ( );
            from . Show ( );
        }
        private void OPI_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormOPI";
            Form from = new FormOPI ( );
            from . Show ( );
        }
        private void SetReview_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormSetReview";
            Form from = new FormSetReview ( );
            from . Show ( );
        }
        private void BomWorkPlan_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormBomWorkPlan";
            Form from = new FormBomWorkPlan ( );
            from . Show ( );
        }
        private void BomWoodPaint_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormBomWoodPaint";
            Form from = new FormBomWoodPaint ( );
            from . Show ( );
        }
        private void Transmit_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormTransmit";
            Form from = new FormTransmit ( );
            from . Show ( );
        }
        private void SetTransmit_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormSetTransmit";
            Form from = new FormSetTransmit ( );
            from . Show ( );
        }
        private void MaintainTransmit_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormMaintainTransmit";
            Form from = new FormMaintainTransmit ( );
            from . Show ( );
        }
        #endregion
        
        #region plan production
        //开料周计划
        private void PlanCutting_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPlanCutting";
            Form from = new FormPlanCutting ( );
            from . Show ( );
        }
        //生产部生产进度跟踪表
        private void ProductSchedule_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormProductSchedule";
            Form from = new FormProductSchedule ( );
            from . Show ( );
        }
        //备料机加工跟踪表
        private void ProductionStock_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormProductionStock";
            Form from = new FormProductionStock ( );
            from . Show ( );
        }
        //备料周计划
        private void PlanStock_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPlanStock";
            Form from = new FormPlanStock ( );
            from . Show ( );
        }
        //备料日计划
        private void PlanStockWork_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPlanStockWork";
            Form from = new FormPlanStockWork ( );
            from . Show ( );
        }
        //备料日计划报工
        private void PlanStockDailyWo_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPlanStockDailyWork";
            Form from = new FormPlanStockDailyWork ( );
            from . Show ( );
        }
        //备料周计划报工
        private void PlanStockDailyWeek_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPlanStockDailyWeek";
            Form from = new FormPlanStockDailyWeek ( );
            from . Show ( );
        }
        //机加工周计划
        private void PlanMachin_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPlanMachin";
            Form from = new FormPlanMachin ( );
            from . Show ( );
        }
        //机加工周计划报工
        private void PlanMachinWeekDailyWork_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FromPlanMachinWeekDailyWork";
            Form from = new FromPlanMachinWeekDailyWork ( );
            from . Show ( );
        }
        //机加工日计划
        private void PlanMachinWork_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPlanMachinWork";
            Form from = new FormPlanMachinWork ( );
            from . Show ( );
        }
        //机加工日计划报工
        private void PlanMachinDayDailyWork_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPlanMachinDayDailyWork";
            Form from = new FormPlanMachinDayDailyWork ( );
            from . Show ( );
        }
        //组装跟踪表
        private void ProductionAssemble_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormProductionAssemble";
            Form from = new FormProductionAssemble ( );
            from . Show ( );
        }
        //组装周计划
        private void PlanAssembleWeek_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPlanAssembleWeek";
            Form from = new FormPlanAssembleWeek ( );
            from . Show ( );
        }
        //组装周计划报工
        private void PlanAssembleWeekDaily_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPlanAssembleWeekDaily";
            Form from = new FormPlanAssembleWeekDaily ( );
            from . Show ( );
        }
        //组装日计划
        private void PlanAssembleDay_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPlanAssembleDay";
            Form from = new FormPlanAssembleDay ( );
            from . Show ( );
        }
        //组装日计划报工
        private void PlanAssembleDayDaily_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPlanAssembleDayDaily";
            Form from = new FormPlanAssembleDayDaily ( );
            from . Show ( );
        }
        //组装派工单
        private void AssembleWorkOrder_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormAssembleWorkOrder";
            Form from = new FormAssembleWorkOrder ( );
            from . Show ( );
        }
        //油漆跟踪表
        private void FormProductionPaint_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormProductionPaint";
            Form from = new FormProductionPaint ( );
            from . Show ( );
        }
        //油漆周计划
        private void ProductionPaintWeek_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormProductionPaintWeek";
            Form from = new FormProductionPaintWeek ( );
            from . Show ( );
        }
        //油漆周计划报工
        private void ProductionPaintWeekDaily_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormProductionPaintWeekDaily";
            Form from = new FormProductionPaintWeekDaily ( );
            from . Show ( );
        }
        //油漆日计划
        private void ProductionPaintDay_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormProductionPaintDay";
            Form from = new FormProductionPaintDay ( );
            from . Show ( );
        }
        //油漆日计划报工
        private void FormProductionPaintDayDaily_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormProductionPaintDayDaily";
            Form from = new FormProductionPaintDayDaily ( );
            from . Show ( );
        }
        //备料、机加工车间工序跟踪表
        private void ProductBLWorkB_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormProductBLWork";
            Form from = new FormProductBLWork ( );
            from . Show ( );
        }
        #endregion

        #region Other Information
        //传票条码管理
        private void BomWorkPlanCode_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormBomWorkPlanCode";
            Form from = new FormBomWorkPlanCode ( );
            from . Show ( );
        }
        //传票导入
        private void ImportExeclToTable_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormImportExeclToTable";
            Form from = new FormImportExeclToTable ( );
            from . Show ( );
        }
        //产品排单
        private void Schedul_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormSchedul";
            Form from = new FormSchedul ( );
            from . Show ( );
        }
        //生产报工记录表
        private void ProductDailyWork_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormProductDailyWork";
            Form from = new FormProductDailyWork ( );
            from . Show ( );
        }
        //车间生产记工
        private void CodeDailyWork_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormCodeDailyWork";
            Form from = new FormCodeDailyWork ( );
            from . Show ( );
        }
        //员工工资报表
        private void PayrollReport_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPayrollReport";
            Form from = new FormPayrollReport ( );
            from . Show ( );
        }
        //计件工资统计表
        private void PiceWageStatisticalTable_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPiceWageStatisticalTable";
            Form from = new FormPiceWageStatisticalTable ( );
            from . Show ( );
        }
        //组别工资系数配比
        private void WageCoef_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = "FormWageCoef";
            Form from = new FormWageCoef ( );
            from . Show ( );
        }
        //产品周期表
        private void ProductCycle_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormProductCycle";
            Form from = new FormProductCycle ( );
            from . Show ( );
        }
        //油漆导入
        private void ExportPaint_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormExportPaint";
            Form from = new FormExportPaint ( );
            from . Show ( );
        }
        //木材导入
        private void ExportWood_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormExportWood";
            Form from = new FormExportWood ( );
            from . Show ( );
        }
        //产品生产进度跟踪表
        private void ProductScheduleTrackTable_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormProductScheduleTrackTable";
            Form from = new FormProductScheduleTrackTable ( " AND 1=2 " );
            from . Show ( );
        }
        //产品部件工序表
        private void ProPartArt_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormProPartArt";
            Form from = new FormProPartArt ( );
            from . Show ( );
        }
        #endregion

        #region wpN Information
        private void ExpendWood_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormExpendWood";
            Form from = new FormExpendWood ( );
            from . Show ( );
        }
        private void WoodBase_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormWoodBase";
            Form from = new FormWoodBase ( );
            from . Show ( );
        }
        //木材耗用分析表
        private void ExpendWoodAnalysis_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormExpendWoodAnalysis";
            Form from = new FormExpendWoodAnalysis ( );
            from . Show ( );
        }
        //每日油漆耗用录入
        private void ExpendPaint_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormExpendPaint";
            Form from = new FormExpendPaint ( );
            from . Show ( );
        }
        //油漆基础资料
        private void ExoendBasePaint_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormExoendBasePaint";
            Form from = new FormExoendBasePaint ( );
            from . Show ( );
        }
        //油漆平方标准用量
        private void ExpendPlanPaint_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormExpendPlanPaint";
            Form from = new FormExpendPlanPaint ( );
            from . Show ( );
        }
        //油漆耗用分析表
        private void ExpendPaintAnalysis_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormExpendPaintAnalysis";
            Form from = new FormExpendPaintAnalysis ( );
            from . Show ( );
        }
        //油漆名称
        private void PaintBaseAndProduct_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormPaintBaseAndProduct";
            Form from = new FormPaintBaseAndProduct ( );
            from . Show ( );
        }
        //产值统计表
        private void OutPutValue_LinkClicked ( object sender ,DevExpress . XtraNavBar . NavBarLinkEventArgs e )
        {
            UserLogin . programName = CarpenterBll . UserInformation . ProgramName = "FormOutPutValue";
            Form from = new FormOutPutValue ( );
            from . Show ( );
        }
        #endregion

        #region Method
        Thread thread;
        bool result=true;
        void checkRemind ( )
        {
            thread = new Thread ( remind );
            thread . Start ( );
        }
        void remind ( )
        {
            //while ( true )
            //{
            //    Thread . Sleep ( 1000 * 6 );
            //    CarpenterBll . Bll . RemindBll _bll = new CarpenterBll . Bll . RemindBll ( );
            //    int count = _bll . GetQueryCount ( UserLogin . userName );
            //    MessageBox . Show ( "1" );
            //    if ( count > 0 )
            //        this . toolLogin . Text = UserLogin . userName + "(" + UserLogin . userNum + ")" + "       您有" + count + "条待处理事项";
            //    if ( result == false )
            //    {
            //        break;
            //    }
            //}
        }
        #endregion

    }
}
