using System . Data;

namespace CarpenterBll . Bll
{
    public class ExoendBasePaintBll
    {
        readonly private Dao.ExoendBasePaintDao _dal=null;
        public ExoendBasePaintBll ( )
        {
            _dal = new Dao . ExoendBasePaintDao ( );
        }

        /// <summary>
        /// get data from database to view
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( )
        {
            return _dal . getTableView ( );
        }


        /// <summary>
        /// get wood data from database 
        /// </summary>
        /// <returns></returns>
        public DataTable getWood ( )
        {
            return _dal . getWood ( );
        }

        /// <summary>
        /// get work procedure data from database
        /// </summary>
        /// <returns></returns>
        public DataTable getWorkProcedure ( )
        {
            return _dal . getWorkProcedure ( );
        }

        /// <summary>
        /// get paint name from database
        /// </summary>
        /// <returns></returns>
        public DataTable getPaintName ( )
        {
            return _dal . getPaintName ( );
        }

        /// <summary>
        /// get paint type from database
        /// </summary>
        /// <returns></returns>
        public DataTable getPaintType ( )
        {
            return _dal . getPaintType ( );
        }

        /// <summary>
        /// add data to database
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Add ( DataTable table )
        {
            return _dal . Add ( table );
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
    }
}
