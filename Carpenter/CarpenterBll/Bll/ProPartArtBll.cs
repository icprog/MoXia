using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ProPartArtBll
    {
        private readonly Dao.ProPartArtDao dal=null;
        public ProPartArtBll ( )
        {
            dal = new Dao . ProPartArtDao ( );
        }


        /// <summary>
        /// 获取产品和零件
        /// </summary>
        /// <returns></returns>
        public DataTable getTableForInfo ( )
        {
            return dal . getTableForInfo ( );
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return dal . getTableView ( strWhere );
        }

    }
}
