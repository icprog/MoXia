using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ProductionPaintWeekBll
    {
        private readonly Dao.ProductionPaintWeekDao dal=null;
        public ProductionPaintWeekBll ( )
        {
            dal = new Dao . ProductionPaintWeekDao ( );
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
        /// 删除
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            return dal . Delete ( oddNum );
        }

        /// <summary>
        /// 编辑保存数据
        /// </summary>
        /// <param name="_pmc"></param>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . ProductionPaintWeekPWGEntity _pla ,DataTable tableView )
        {
            return dal . Edit ( _pla ,tableView );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examine ( string oddNum ,bool state ,string programId )
        {
            return dal . Examine ( oddNum ,state ,programId );
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
        public DataTable GetDataTableView ( string oddNum )
        {
            return dal . GetDataTableView ( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public CarpenterEntity . ProductionPaintWeekPWGEntity GetDataTableHead ( string oddNum )
        {
            return dal . GetDataTableHead ( oddNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable TablePrintOne ( string oddNum )
        {
            return dal . TablePrintOne ( oddNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable TablePrintTwo ( string oddNum )
        {
            return dal . TablePrintTwo ( oddNum );
        }


    }
}
