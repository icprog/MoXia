using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class WoodBaseBll
    {
        readonly private Dao.WoodBaseDao _dal=null;
        public WoodBaseBll ( )
        {
            _dal = new Dao . WoodBaseDao ( );
        }

        /// <summary>
        /// get wood from database 
        /// </summary>
        /// <returns></returns>
        public DataTable getWood ( )
        {
            return _dal . getWood ( );
        }

        /// <summary>
        /// get part num from moxcut
        /// </summary>
        /// <returns></returns>
        public DataTable getPartNum ( )
        {
            return _dal . getPartNum ( );
        }

        /// <summary>
        /// get table from database
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return _dal . getTableView ( strWhere );
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
        /// add or edit data to database
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Add ( DataTable table,List<int> intList )
        {
            return _dal . Add ( table ,intList );
        }


        /// <summary>
        /// get table from database to product
        /// </summary>
        /// <returns></returns>
        public DataTable getTableProduct ( )
        {
            return _dal . getTableProduct ( );
        }

        /// <summary>
        /// get table from database to wood type
        /// </summary>
        /// <returns></returns>
        public DataTable getTableType ( )
        {
            return _dal . getTableType ( );
        }

    }
}
