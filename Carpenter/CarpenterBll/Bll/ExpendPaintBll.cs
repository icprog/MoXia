using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ExpendPaintBll
    {
        readonly private Dao.ExpendPaintDao _dal=null;

        public ExpendPaintBll ( )
        {
            _dal = new Dao . ExpendPaintDao ( );
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
        /// add data to database from view 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Add ( DataTable table ,string oddNum,List<string> idxList )
        {
            return _dal . Add ( table ,oddNum ,idxList );
        }

        /// <summary>
        /// does it exists of oddNum
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists ( string oddNum )
        {
            return _dal . Exists ( oddNum );
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
        /// get oddNum from database
        /// </summary>
        /// <returns></returns>
        public DataTable getOddNum ( )
        {
            return _dal . getOddNum ( );
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
        /// 是否已经存在此日期
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool ExistsDate ( string code )
        {
            return _dal . ExistsDate ( code );
        }

        /// <summary>
        /// get data from database to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getView ( string strWhere )
        {
            return _dal . getView ( strWhere );
        }

    }
}
