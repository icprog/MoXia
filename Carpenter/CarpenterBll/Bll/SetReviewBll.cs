using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class SetReviewBll
    {
        private readonly Dao.SetReviewDao _dao=new Dao.SetReviewDao();

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
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            return _dao . Delete ( idx );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Save ( CarpenterEntity . SetReviewEntity _model )
        {
            return _dao . Save ( _model );
        }
        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . SetReviewEntity _model )
        {
            return _dao . Edit ( _model );
        }

    }
}
