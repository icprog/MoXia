using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ProductBLWorkBll
    {
        Dao.ProductBLWorkDao _dao=null;
        

        public ProductBLWorkBll ( )
        {
            _dao = new Dao . ProductBLWorkDao ( );
        }

        /// <summary>
        /// get table form bl
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTable ( )
        {
            return _dao . getDataTable ( );
        }

        /// <summary>
        /// get data table from moxprd
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getDataTableToView ( string strWhere )
        {
            return _dao . getDataTableToView ( strWhere );
        }

        }
}
