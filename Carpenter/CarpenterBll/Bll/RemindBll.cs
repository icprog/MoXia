using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class RemindBll
    {
        private readonly Dao.RemindDao _dao=new Dao.RemindDao();

        /// <summary>
        /// 送审
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool AddReview ( CarpenterEntity . RemindEntity _model )
        {
            return _dao . AddReview ( _model );
        }

        /// <summary>
        /// 得到消息提醒列表
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable GetQuery ( string userNum )
        {
            return _dao . GetQuery ( userNum );
        }


        /// <summary>
        /// 获取消息数量
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public int GetQueryCount ( string userNum )
        {
            return _dao . GetQueryCount ( userNum );
        }

    }
}
