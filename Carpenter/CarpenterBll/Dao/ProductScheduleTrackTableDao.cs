using System . Data;
using System . Text;
using StudentMgr;

namespace CarpenterBll . Dao
{
    public class ProductScheduleTrackTableDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PRD007,PRD008,PRD009,CUU003,PRD011,PRD034,WPC016,CUU003*WPC016 WPC,PRD003,PRD013,PRD004,PRD005,PRD019 FROM MOXPRD A INNER JOIN MOXCUU B ON A.PRD007=B.CUU001 AND A.PRD008=B.CUU002 INNER JOIN MOXWPC C ON A.PRD007=C.WPC001 AND A.PRD008=C.WPC002 AND A.PRD011=C.WPC004 AND A.PRD034=C.WPC006+'*'+C.WPC009+'*'+C.WPC012 " );
            if ( string . IsNullOrEmpty ( strWhere ) )
                strSql . Append ( "WHERE PRD014=1 AND 1=2 ORDER BY PRD013" );
            else
                strSql . AppendFormat ( "WHERE PRD014=1 {0} ORDER BY PRD013" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PRD007,PRD008,PRD009 FROM MOXPRD" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
