using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class OutPutValueBll
    {
        Dao.OutPutValueDao dal=null;

        public OutPutValueBll ( )
        {
            dal = new Dao . OutPutValueDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable getTableView ( int year ,int month )
        {
            return dal . getTableView ( year ,month );
        }

    }
}
