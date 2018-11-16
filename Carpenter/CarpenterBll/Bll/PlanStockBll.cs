using System . Data;


namespace CarpenterBll . Bll
{
    public class PlanStockBll
    {
        private readonly Dao.PlanStockDao _dao=new Dao.PlanStockDao();
        
        /// <summary>
        /// 获取备料查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( )
        {
            return _dao . GetDataTableQuery ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableHeader ( string oddNum )
        {
            return _dao . GetDataTableHeader ( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableBody ( string oddNum )
        {
            return _dao . GetDataTableBody ( oddNum );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum,DataTable table )
        {
            return _dao . Delete ( oddNum ,table );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Concell ( string oddNum ,bool state )
        {
            return _dao . Concell ( oddNum ,state );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_modePLS"></param>
        /// <param name="tableQuery"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . PlanStockPLSEntity _modePLS ,DataTable tableQuery )
        {
            return _dao . Edit ( _modePLS ,tableQuery );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="programName"></param>
        /// <param name="userNane"></param>
        /// <param name="userNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examin ( string oddNum ,string programName ,string userNane ,string userNum ,bool state ,DataTable table)
        {
            return _dao . Examin ( oddNum ,programName ,userNane ,userNum ,state ,table );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable printOne ( string oddNum )
        {
            return _dao . printOne ( oddNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable printTwo ( string oddNum )
        {
            return _dao . printTwo ( oddNum );
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
            return _dao . Exists ( oddNum ,batNum ,proNum );
        }

    }
}
