using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ExpendPaintAnalysisBll
    {
        readonly private Dao.ExpendPaintAnalysisDao _dal=null;

        public ExpendPaintAnalysisBll ( )
        {
            _dal = new Dao . ExpendPaintAnalysisDao ( );
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
        /// delete data from database
        /// </summary>
        /// <param name="dateEdit"></param>
        /// <returns></returns>
        public bool Delete ( string dateEdit )
        {
            return _dal . Delete ( dateEdit );
        }

        /// <summary>
        /// add data to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="dateEdit"></param>
        /// <param name="intList"></param>
        /// <returns></returns>
        public bool Add ( DataTable table ,string dateEdit ,List<int> intList )
        {
            return _dal . Add ( table ,dateEdit ,intList );
        }

        /// <summary>
        /// generate the data to database
        /// </summary>
        /// <param name="yearAndMonth"></param>
        /// <returns></returns>
        public bool Generate ( string yearAndMonth )
        {
            return _dal . Generate ( yearAndMonth );
        }

        /// <summary>
        /// 获取不在本月的油漆名称的数据
        /// </summary>
        /// <param name="yearAndMonth"></param>
        /// <returns></returns>
        public DataTable proList ( string yearAndMonth )
        {
            return _dal . proList ( yearAndMonth );
        }

        /// <summary>
        /// get print data from database
        /// </summary>
        /// <param name="yearAndMonth"></param>
        /// <returns></returns>
        public DataTable getPrintTable ( string yearAndMonth )
        {
            return _dal . getPrintTable ( yearAndMonth );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable getPrintTableTwo ( string year )
        {
            return _dal . getPrintTableTwo ( year );
        }


        }
}
