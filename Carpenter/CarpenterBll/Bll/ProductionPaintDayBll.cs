using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ProductionPaintDayBll
    {
        private readonly Dao.ProductionPaintDayDao dal=null;
        public ProductionPaintDayBll ( )
        {
            dal = new Dao . ProductionPaintDayDao ( );
        }

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( )
        {
            return dal . GetDataTableQuery ( );
        }

        /// <summary>
        /// 是否报工，若有则不能删除
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists_BG ( string oddNum )
        {
            return dal . Exists_BG ( oddNum );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string work )
        {
            return dal . Delete ( oddNum ,work );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="programName"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examine ( string oddNum ,string programName ,bool state )
        {
            return dal . Examine ( oddNum ,programName ,state );
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
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string oddNum )
        {
            return dal . GetDataTablePrintOne ( oddNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string oddNum )
        {
            return dal . GetDataTablePrintTwo ( oddNum );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public CarpenterEntity . ProductionPaintDayPWDEntity GetList ( string oddNum,string workShop )
        {
            return dal . GetList ( oddNum ,workShop );
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
        /// 保存数据
        /// </summary>
        /// <param name="_psw"></param>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . ProductionPaintDayPWDEntity _pld ,DataTable tableView )
        {
            return dal . Edit ( _pld ,tableView );
        }



        /// <summary>
        /// 是否已经报工
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="batNum"></param>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public bool exists ( string oddNum ,string batNum ,string proNum )
        {
            return dal . exists ( oddNum ,batNum ,proNum );
        }

    }
}
