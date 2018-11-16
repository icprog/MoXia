
using System . Data;

namespace CarpenterBll . Bll
{
    public class ArtBll
    {
        private readonly Dao.ArtDao _dao=new Dao.ArtDao();
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            return _dao . GetDataTable ( );
        }

        /// <summary>
        /// 获取工艺信息  区间信息
        /// </summary>
        /// <param name="artNum"></param>
        /// <returns></returns>
        public DataTable tableView ( string artNum )
        {
            return _dao . tableView ( artNum );
        }

        /// <summary>
        /// 获取编号
        /// </summary>
        /// <returns></returns>
        public string GetNum ( )
        {
            return _dao . GetNum ( );
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
        public bool Add ( CarpenterEntity . ArtEntity _model ,DataTable table)
        {
            return _dao . Add ( _model ,table );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . ArtEntity _model ,DataTable table)
        {
            return _dao . Edit ( _model ,table );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Cancel ( int idx ,bool state )
        {
            return _dao . Cancel ( idx ,state );
        }


        /// <summary>
        /// 获取部门
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepart ( )
        {
            return _dao . GetDepart ( );
        }

    }
}
