using System . Data;
using System . Data . SqlClient;
using System . Text;
using StudentMgr;

namespace CarpenterBll . Dao
{
    public class MainDao
    {
        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePower ( string userNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,A.POW002,B.EMP002,A.POW003,FOR001,POW013 FROM MOXPOW A LEFT JOIN MOXEMP B ON A.POW002=B.EMP001 LEFT JOIN MOXFOR C ON A.POW003=C.FOR002 " );
            strSql . Append ( "WHERE EMP001=@EMP001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EMP001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = userNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取按钮级权限
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableBtnPower ( string userNum ,string programNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT POW004,POW005,POW006,POW007,POW008,POW009,POW010,POW011,POW012,POW016,POW017 FROM MOXPOW A LEFT JOIN MOXEMP B ON A.POW002=B.EMP001 LEFT JOIN MOXFOR C ON A.POW003=C.FOR002 " );
            strSql . Append ( "WHERE EMP001=@EMP001 AND FOR002=@FOR002" );

            SqlParameter [ ] parameter = {
                new SqlParameter("@EMP001",SqlDbType.NVarChar,20),
                new SqlParameter("@FOR002",SqlDbType.NVarChar,50)
            };
            parameter [ 0 ] . Value = userNum;
            parameter [ 1 ] . Value = programNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

    }
}
