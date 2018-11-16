using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ProductCycleBll
    {
        readonly private Dao.ProductCycleDao _dal=null;
        public ProductCycleBll ( )
        {
            _dal = new Dao . ProductCycleDao ( );
        }

        /// <summary>
        /// get data from database to view
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable getTableView ( string piNum,string pinNum )
        {
            return _dal . getTableView ( piNum ,pinNum );
        }

        /// <summary>
        /// get data from database to export
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable getTableExport ( int year )
        {
            return _dal . getTableExport ( year );
        }

        /// <summary>
        /// get data from database to query column value
        /// </summary>
        /// <returns></returns>
        public DataTable getTableColumn ( )
        {
            return _dal . getTableColumn ( );
        }

    }
}
