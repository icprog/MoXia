using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class WageCoefBll
    {
        private readonly Dao.WageCoefDao dal=null;
        public WageCoefBll ( )
        {
            dal = new Dao . WageCoefDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return dal . getTableView ( strWhere );
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Delete ( string strWhere )
        {
            return dal . Delete ( strWhere );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="yearAndMonth"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,string strWhere )
        {
            return dal . Save ( table ,strWhere );
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Read ( string strWhere )
        {
            return dal . Read ( strWhere );
        }

    }
}
