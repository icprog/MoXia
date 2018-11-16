using System;
using System . Windows . Forms;

namespace Carpenter . ControlUser
{
    public partial class WeeklyPlan :UserControl
    {
        public WeeklyPlan ( )
        {
            InitializeComponent ( );

            dtpEnd . Value = dtpOrder . Value = dtpStart . Value = CarpenterBll . UserInformation . dt ( );

        }
        
        CarpenterEntity.PlanStockPLSEntity _modelPLS=new CarpenterEntity.PlanStockPLSEntity();
        public CarpenterEntity . PlanStockPLSEntity GetPLS
        {
            get
            {
                _modelPLS . PLS002 = texWeek . Text;
                _modelPLS . PLS003 = Convert . ToDateTime ( dtpOrder . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                _modelPLS . PLS004 = Convert . ToDateTime ( dtpStart . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                _modelPLS . PLS005 = Convert . ToDateTime ( dtpEnd . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                _modelPLS . PLS008 = checkPlan . Checked;
                return _modelPLS;
            }
        }
    }
}
