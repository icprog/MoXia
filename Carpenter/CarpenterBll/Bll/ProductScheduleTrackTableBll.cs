using System . Data;

namespace CarpenterBll . Bll
{
    public class ProductScheduleTrackTableBll
    {
        Dao.ProductScheduleTrackTableDao _dal=null;
        public ProductScheduleTrackTableBll ( )
        {
            _dal = new Dao . ProductScheduleTrackTableDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return _dal . getTableView ( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableInfo ( )
        {
            return _dal . getTableInfo ( );
        }

    }
}
