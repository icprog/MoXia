using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class PiceWageStatisticalTableBll
    {
        readonly private Dao.PiceWageStatisticalTableDao _dal=null;
        public PiceWageStatisticalTableBll ( )
        {
            _dal = new Dao . PiceWageStatisticalTableDao ( );
        }

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <returns></returns>
        public DataTable getTableUser ( )
        {
            return _dal.getTableUser ( );
        }

        /// <summary>
        /// add data to database
        /// </summary>
        /// <param name="yearAndMonth"></param>
        /// <returns></returns>
        public int Generate ( string yearAndMonth )
        {
            return _dal . Generate ( yearAndMonth );
        }

        /// <summary>
        /// get data from database to view 
        /// </summary>
        /// <param name="yearAndMonth"></param>
        /// <returns></returns>
        public DataTable getTableView ( string yearAndMonth )
        {
            return _dal . getTableView ( yearAndMonth );
        }

        /// <summary>
        /// delete data from database 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Delete ( string strWhere )
        {
            return _dal . Delete ( strWhere );
        }

        /// <summary>
        /// edit data to database from view
        /// </summary>
        /// <param name="table"></param>
        /// <param name="intList"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table ,List<int> intList )
        {
            return _dal . Edit ( table ,intList );
        }

        /// <summary>
        /// get data from database to export
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getPrintTable ( string strWhere )
        {
            return _dal . getPrintTable ( strWhere );
        }

        /// <summary>
        /// 编辑工艺单价
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditArtPrice ( CarpenterEntity . PiceWageStatisticalTableEntity model )
        {
            return _dal . EditArtPrice ( model );
        }

    }
}
