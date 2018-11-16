using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class PlanStockWorkBll
    {
        private readonly Dao.PlanStockWorkDao _dao=new Dao.PlanStockWorkDao();
        
        /// <summary>
        /// 获取查询列表
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
        public DataTable GetDataTableOne ( string oddNum ,string workShop)
        {
            return _dao . GetDataTableOne ( oddNum ,workShop );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo ( string oddNum )
        {
            return _dao . GetDataTableTwo ( oddNum );
        }


        /// <summary>
        /// 是否已经报工,且没有删除
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists_BG ( string oddNum )
        {
            return _dao . Exists_BG ( oddNum );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string work,DateTime? dt)
        {
            return _dao . Delete ( oddNum ,work ,dt );
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
        /// 保存
        /// </summary>
        /// <param name="_modelPSW"></param>
        /// <param name="tableQuery"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . PlanStockWorkPSWEntity _modelPSW ,DataTable tableQuery ,List<string> bodyList)
        {
            return _dao . Edit ( _modelPSW ,tableQuery ,bodyList );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="programName"></param>
        /// <param name="userName"></param>
        /// <param name="userNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examin ( string oddNum ,string programName ,string userName ,string userNum ,bool state )
        {
            return _dao . Examin ( oddNum ,programName ,userName ,userNum ,state );
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
        /// 获取完成率和工作日日期
        /// </summary>
        /// <returns></returns>
        public DataTable completionRate ( string oddNum,string workShop )
        {
            return _dao . completionRate ( oddNum ,workShop );
        }

        /// <summary>
        /// 是否存在记录
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
