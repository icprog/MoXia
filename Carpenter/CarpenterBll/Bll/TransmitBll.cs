using System . Data;

namespace CarpenterBll . Bll
{
    public class TransmitBll
    {
        private readonly Dao.TransmitDao _dao=new Dao.TransmitDao();

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            return _dao . GetDataTable ( );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,string userName )
        {
            return _dao . Save ( table ,userName );
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            return _dao . Delete ( idx );
        }

    }
}
