using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ExpendPlanPaintBll
    {
        readonly private Dao.ExpendPlanPaintDao _dal=null;
        public ExpendPlanPaintBll ( )
        {
            _dal = new Dao . ExpendPlanPaintDao ( );
        }

        /// <summary>
        /// get product info from database to lookupedit
        /// </summary>
        /// <returns></returns>
        public DataTable getTableProduct ( )
        {
            return _dal . getTableProduct ( );
        }

        /// <summary>
        /// get column data from database
        /// </summary>
        /// <returns></returns>
        public DataTable getTableColumn ( )
        {
            return _dal . getTableColumn ( );
        }

        /// <summary>
        /// 获取部件
        /// </summary>
        /// <returns></returns>
        public DataTable getTablePart ( )
        {
            return _dal . getTablePart ( );
        }

        /// <summary>
        /// get data from database to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return _dal . getTableView ( strWhere );
        }

        /// <summary>
        /// add data to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="intList"></param>
        /// <returns></returns>
        public bool Add ( DataTable table ,List<int?> intList )
        {
            return _dal . Add ( table ,intList );
        }

        /// <summary>
        /// delete data from database
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Delete ( DataTable table )
        {
            return _dal . Delete ( table );
        }

        /// <summary>
        /// get product info from database
        /// </summary>
        /// <returns></returns>
        public DataTable getTableProductInfo ( )
        {
            return _dal . getTableProductInfo ( );
        }


        /// <summary>
        /// get other info from database
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOther ( )
        {
            return _dal . getTableOther ( );
        }

        /// <summary>
        /// 导入数据到库
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool SaveTable ( DataTable table )
        {
            return _dal . SaveTable ( table );
        }

    }
}
