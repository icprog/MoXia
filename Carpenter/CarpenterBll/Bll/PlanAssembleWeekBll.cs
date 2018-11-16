using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class PlanAssembleWeekBll
    {
        private readonly Dao.PlanAssembleWeekDao _dal=null;
        public PlanAssembleWeekBll ( )
        {
            _dal = new Dao . PlanAssembleWeekDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( )
        {
            return _dal . GetDataTableQuery ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableView ( string oddNum )
        {
            return _dal . GetDataTableView ( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public CarpenterEntity . PlanAssembleWeekPLAEntity GetDataTableHead ( string oddNum )
        {
            return _dal . GetDataTableHead ( oddNum );
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum,DataTable table )
        {
            return _dal . Delete ( oddNum ,table );
        }

        /// <summary>
        /// 编辑保存数据
        /// </summary>
        /// <param name="_pmc"></param>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . PlanAssembleWeekPLAEntity _pla ,DataTable tableView )
        {
            return _dal . Edit ( _pla ,tableView  );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examine ( string oddNum ,bool state ,string programId ,DataTable table )
        {
            return _dal . Examine ( oddNum ,state ,programId ,table );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Cancellation ( string oddNum ,bool state )
        {
            return _dal . Cancellation ( oddNum ,state );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string oddNum )
        {
            return _dal . GetDataTablePrintOne ( oddNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string oddNum )
        {
            return _dal . GetDataTablePrintTwo ( oddNum );
        }

    }
}
