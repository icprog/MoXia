using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ExpendWoodBll
    {
        readonly private Dao.ExpendWoodDao _dal=null;
        public ExpendWoodBll ( )
        {
            _dal = new Dao . ExpendWoodDao ( );
        }

        /// <summary>
        /// get oddNum from database 
        /// </summary>
        /// <returns></returns>
        public DataTable getOddNum ( )
        {
            return _dal . getOddNum ( );
        }

        /// <summary>
        /// read data from the database to view as required
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
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            return _dal . Delete ( oddNum );
        }


        /// <summary>
        /// is there a singular number
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists_Odd ( string oddNum )
        {
            return _dal . Exists_Odd ( oddNum );
        }

        /// <summary>
        /// add data to database 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Add ( DataTable table,string oddNum )
        {
            return _dal . Add ( table ,oddNum );
        }

        /// <summary>
        /// change database data
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table ,string oddNu )
        {
            return _dal . Edit ( table ,oddNu );
        }

        /// <summary>
        /// get wood grade from database 
        /// </summary>
        /// <returns></returns>
        public DataTable getCmbGrade ( )
        {
            return _dal . getCmbGrade ( );
        }

        /// <summary>
        /// get wood type from database 
        /// </summary>
        /// <returns></returns>
        public DataTable getCmbType ( )
        {
            return _dal . getCmbType ( );
        }

    }
}
