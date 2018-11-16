using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class SetTransmitBll
    {
        private readonly Dao.SetTransmitDao _dao=new Dao.SetTransmitDao();
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            return _dao . GetDataTable ( );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="str001"></param>
        /// <param name="str002"></param>
        /// <param name="str003"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            return _dao . Delete ( idx );
        }


        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetPerson ( )
        {
            return _dao . GetPerson ( );
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool Add ( List<CarpenterBll . Paramete> table ,string userName )
        {
            return _dao . Add ( table ,userName );
        }

    }
}
