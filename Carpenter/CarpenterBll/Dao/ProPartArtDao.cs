using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;

namespace CarpenterBll . Dao
{
    public class ProPartArtDao
    {
        /// <summary>
        /// 获取产品和零件
        /// </summary>
        /// <returns></returns>
        public DataTable getTableForInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT PPA001,PPA002,PPA003,PPA004 FROM MOXPPA" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView (  string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PPA001,PPA002,PPA003,PPA004,PPA005,PPA006,PPA007,PPA008 FROM MOXPPA WHERE {0} ORDER BY PPA001,PPA007,PPA003,PPA005" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
