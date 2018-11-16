using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class SchedulBll
    {
        readonly private Dao.SchedulDao _dal=null;
        public SchedulBll ( )
        {
            _dal = new Dao . SchedulDao ( );
        }

        /// <summary>
        /// get data from database for StoredProcedure
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( )
        {
            return _dal . getTableView ( );
        }

        /// <summary>
        /// get data from database 
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOne ( )
        {
            return _dal . getTableOne ( );
        }

        /// <summary>
        /// get data from database 
        /// </summary>
        /// <returns></returns>
        public DataTable getTable ( )
        {
            return _dal . getTable ( );
        }
    }
}
