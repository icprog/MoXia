using System;
using System . Windows . Forms;

namespace Carpenter . ControlUser
{
    public partial class DayPlan :UserControl
    {

        public DayPlan ( string workShop )
        {
            InitializeComponent ( );
            
            dtpPlan . Value = CarpenterBll . UserInformation . dt ( ) . AddDays ( 1 );
            dtpOrder . Value = CarpenterBll . UserInformation . dt ( );
            
            if ( workShop . Equals ( "备料" ) )
            {
                foreach ( string s in CarpenterBll . ColumnValues . bl )
                {
                    comWorkShip . Items . Add ( s );
                }
            }
            if ( workShop . Equals ( "机加工" ) )
            {
                foreach ( string s in CarpenterBll . ColumnValues . jjg )
                {
                    comWorkShip . Items . Add ( s );
                }
            }
            if ( workShop . Equals ( "组装" ) )
            {
                comWorkShip . Items . Add ( "组装" );
                comWorkShip . Text = "组装";               
            }
            if ( workShop . Equals ( "油漆" ) )
            {
                foreach ( string s in CarpenterBll . ColumnValues . yq )
                {
                    comWorkShip . Items . Add ( s );
                }
            }
        }
        
        CarpenterEntity.PlanStockWorkPSWEntity _model=new CarpenterEntity.PlanStockWorkPSWEntity();
        public CarpenterEntity . PlanStockWorkPSWEntity getModel
        {
            get
            {
                _model . PSW002 = comWorkShip . Text;
                _model . PSW003 = Convert . ToDateTime ( dtpPlan . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                _model . PSW004 = Convert . ToDateTime ( dtpOrder . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                _model . PSW005 = checkPlan . Checked;
                return _model;
            }
        }
        
        CarpenterEntity.PlanMachinWorkPMWEntity _entity=new CarpenterEntity.PlanMachinWorkPMWEntity();
        public CarpenterEntity . PlanMachinWorkPMWEntity getEntity
        {
            get
            {
                _entity . PMW002 = comWorkShip . Text;
                _entity . PMW003 = Convert . ToDateTime ( dtpPlan . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                _entity . PMW004 = Convert . ToDateTime ( dtpOrder . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                _entity . PMW005 = checkPlan . Checked;
                return _entity;
            }
        }

        CarpenterEntity.PlanAssembleDayPLDEntity _pld=new CarpenterEntity.PlanAssembleDayPLDEntity();
        public CarpenterEntity . PlanAssembleDayPLDEntity getPld
        {
            get
            {
                _pld . PLD002 = comWorkShip . Text;
                _pld . PLD004 = Convert . ToDateTime ( dtpPlan . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                _pld . PLD003 = Convert . ToDateTime ( dtpOrder . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                _pld . PLD005 = checkPlan . Checked;
                return _pld;
            }
        }

        CarpenterEntity.ProductionPaintDayPWDEntity _pwd=new CarpenterEntity.ProductionPaintDayPWDEntity();
        public CarpenterEntity . ProductionPaintDayPWDEntity getPwd
        {
            get
            {
                _pwd . PWD002 = comWorkShip . Text;
                _pwd . PWD004 = Convert . ToDateTime ( dtpPlan . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                _pwd . PWD003 = Convert . ToDateTime ( dtpOrder . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                _pwd . PWD005 = checkPlan . Checked;
                return _pwd;
            }
        }

    }
}
