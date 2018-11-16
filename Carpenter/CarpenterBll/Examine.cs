using System;
using System . Collections;
using System . Data;
using System . Data . SqlClient;
using System . Text;
using StudentMgr;

namespace CarpenterBll
{
    public static class Examine
    {
        static DateTime dt ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GETDATE() t " );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) ) )
                    return DateTime . Now;
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) );
            }
            else
                return DateTime . Now;
        }

        /// <summary>
        /// 写入审核记录到送审表
        /// </summary>
        /// <param name="programName"></param>
        /// <param name="oddNum"></param>
        /// <param name="personId"></param>
        /// <param name="SQLString"></param>
        public static void writeToReview (string programName,string oddNum,string personId ,Hashtable SQLString)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXREV(" );
            strSql . Append ( "REV001,REV002,REV003,REV004,REV005,REV006)" );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@REV001,@REV002,@REV003,@REV004,@REV005,@REV006)" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@REV001",System.Data.SqlDbType.NVarChar,20),
                new SqlParameter("@REV002",System.Data.SqlDbType.NVarChar,20),
                new SqlParameter("@REV003",System.Data.SqlDbType.NVarChar,20),
                new SqlParameter("@REV004",System.Data.SqlDbType.DateTime2),
                new SqlParameter("@REV005",System.Data.SqlDbType.NVarChar,10),
                new SqlParameter("@REV006",System.Data.SqlDbType.NVarChar,500)
            };
            parameter [ 0 ] . Value = programName;
            parameter [ 1 ] . Value = oddNum;
            parameter [ 2 ] . Value = personId;
            parameter [ 3 ] . Value = dt ( );
            parameter [ 4 ] . Value = "审核";
            parameter [ 5 ] . Value = string . Empty;

            SQLString . Add ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 写入反审核记录到送审表
        /// </summary>
        /// <param name="programName"></param>
        /// <param name="oddNum"></param>
        /// <param name="personId"></param>
        /// <param name="SQLString"></param>
        public static void deleteToReview ( string programName ,string oddNum ,string personId ,Hashtable SQLString )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXREV(" );
            strSql . Append ( "REV001,REV002,REV003,REV004,REV005,REV006)" );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@REV001,@REV002,@REV003,@REV004,@REV005,@REV006)" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@REV001",System.Data.SqlDbType.NVarChar,20),
                new SqlParameter("@REV002",System.Data.SqlDbType.NVarChar,20),
                new SqlParameter("@REV003",System.Data.SqlDbType.NVarChar,20),
                new SqlParameter("@REV004",System.Data.SqlDbType.DateTime2),
                new SqlParameter("@REV005",System.Data.SqlDbType.NVarChar,10),
                new SqlParameter("@REV006",System.Data.SqlDbType.NVarChar,500)
            };
            parameter [ 0 ] . Value = programName;
            parameter [ 1 ] . Value = oddNum;
            parameter [ 2 ] . Value = personId;
            parameter [ 3 ] . Value = dt ( );
            parameter [ 4 ] . Value = "反审核";
            parameter [ 5 ] . Value = string . Empty;

            SQLString . Add ( strSql . ToString ( ) ,parameter );
        }


    }
}
