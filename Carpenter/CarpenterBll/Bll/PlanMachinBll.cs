using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class PlanMachinBll
    {
        private readonly Dao.PlanMachinDao dal=null;

        public PlanMachinBll ( )
        {
            dal = new Dao . PlanMachinDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableView ( string oddNum )
        {
            return dal . GetDataTableView ( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( )
        {
            return dal . GetDataTableQuery ( );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public CarpenterEntity . PlanMachinPMCEntity GetDataTableMain ( string oddNum )
        {
            return dal . GetDataTableMain ( oddNum );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,DataTable table)
        {
            return dal . Delete ( oddNum ,table );
        }

        /// <summary>
        /// 编辑保存数据
        /// </summary>
        /// <param name="_pmc"></param>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . PlanMachinPMCEntity _pmc ,DataTable tableView )
        {
            return dal . Edit ( _pmc ,tableView );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examine ( string oddNum ,bool state,string programId,string userNum ,DataTable table)
        {
            return dal . Examine ( oddNum ,state ,programId ,userNum ,table );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Cancellation ( string oddNum ,bool state )
        {
            return dal . Cancellation ( oddNum ,state );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string oddNum )
        {
            return dal . GetDataTablePrintOne ( oddNum );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string oddNum )
        {
            return dal . GetDataTablePrintTwo ( oddNum );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="batNum"></param>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public bool Exists ( string oddNum ,string batNum ,string proNum )
        {
            return dal . Exists ( oddNum ,batNum ,proNum );
        }

        }
}
