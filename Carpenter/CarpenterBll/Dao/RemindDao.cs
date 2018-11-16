using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;
using System . Data;

namespace CarpenterBll . Dao
{
    public class RemindDao
    {
        /// <summary>
        /// 送审
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool AddReview ( CarpenterEntity . RemindEntity _model )
        {
            _model . REV004 = getDt ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXREV (" );
            strSql . Append ( "REV001,REV002,REV003,REV004,REV005,REV006) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@REV001,@REV002,@REV003,@REV004,@REV005,@REV006) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@REV001",SqlDbType.NVarChar,20),
                new SqlParameter("@REV002",SqlDbType.NVarChar,20),
                new SqlParameter("@REV003",SqlDbType.NVarChar,20),
                new SqlParameter("@REV004",SqlDbType.DateTime),
                new SqlParameter("@REV005",SqlDbType.NVarChar,10),
                new SqlParameter("@REV006",SqlDbType.NVarChar,500)
            };
            parameter [ 0 ] . Value = _model . REV001;
            parameter [ 1 ] . Value = _model . REV002;
            parameter [ 2 ] . Value = _model . REV003;
            parameter [ 3 ] . Value = _model . REV004;
            parameter [ 4 ] . Value = _model . REV005;
            parameter [ 5 ] . Value = _model . REV006;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        
        /// <summary>
        /// 获取服务器日期
        /// </summary>
        /// <returns></returns>
        DateTime getDt ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GETDATE() t" );

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
        /// 得到消息提醒列表
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable GetQuery ( string userNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT SRE004,SRE002 FROM MOXSRE WHERE SRE003=userNum AND SRE004!='0'" );
            strSql . Append ( "),CFT AS (" );
            strSql . Append ( "SELECT A.SRE002,A.SRE004 FROM MOXSRE A LEFT JOIN CET B ON A.SRE002=B.SRE002 GROUP BY A.SRE002,A.SRE004,B.SRE004 HAVING A.SRE004<B.SRE004" );
            strSql . Append ( "),CHT AS (" );
            strSql . Append ( "SELECT SRE002,MAX(SRE004) SRE004 FROM CFT GROUP BY SRE002" );
            strSql . Append ( "),CJT AS(" );
            strSql . Append ( "SELECT MAX(REV004) REV004,REV001 FROM MOXREV GROUP BY REV001" );
            strSql . Append ( "),CKT AS (" );
            strSql . Append ( "SELECT REV003,B.REV001 FROM MOXREV A INNER JOIN CJT B ON A.REV001=B.REV001 AND A.REV004=B.REV004  WHERE REV005='送审'" );
            strSql . Append ( "),CGT AS (" );
            strSql . Append ( "SELECT SRE004,SRE003,REV001 FROM MOXSRE A INNER JOIN CKT B ON A.SRE002=B.REV001 AND A.SRE003=B.REV003" );
            strSql . Append ( "),CLT AS (" );
            strSql . Append ( "SELECT A.SRE002,A.SRE004,B.SRE003 FROM CHT A INNER JOIN CGT B ON A.SRE002=B.REV001 AND A.SRE004=B.SRE004" );
            strSql . Append ( "),CZT AS(" );
            strSql . Append ( "SELECT A.REV004,A.REV001 FROM MOXREV A INNER JOIN CJT B ON A.REV001=B.REV001 AND A.REV004=B.REV004 WHERE REV005='驳回' " );
            strSql . Append ( "),CMT AS (" );
            strSql . Append ( "SELECT A.* FROM MOXREV A INNER JOIN CLT B ON A.REV001=B.SRE002 AND A.REV003=B.SRE003 " );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT A.* FROM MOXREV A LEFT JOIN CZT B ON A.REV001=B.REV001 AND A.REV004=B.REV004 WHERE REV005='驳回' AND REV003!=userNum)" );
            strSql . Append ( "SELECT FOR001,REV001,REV002,REV003,EMP002,REV004,REV005,REV006 FROM CMT A LEFT JOIN MOXEMP B ON A.REV003=B.EMP001 LEFT JOIN MOXFOR C ON A.REV001=C.FOR002  WHERE REV004 IN (SELECT MAX(REV004) FROM MOXREV GROUP BY REV001)" );
            SqlParameter [ ] parameter = {
                new SqlParameter("userNum",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = userNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取消息数量
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public int GetQueryCount ( string userNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT SRE004,SRE002 FROM MOXSRE WHERE SRE003=userNum AND SRE004!='0'" );
            strSql . Append ( "),CFT AS (" );
            strSql . Append ( "SELECT A.SRE002,A.SRE004 FROM MOXSRE A LEFT JOIN CET B ON A.SRE002=B.SRE002 GROUP BY A.SRE002,A.SRE004,B.SRE004 HAVING A.SRE004<B.SRE004" );
            strSql . Append ( "),CHT AS (" );
            strSql . Append ( "SELECT SRE002,MAX(SRE004) SRE004 FROM CFT GROUP BY SRE002" );
            strSql . Append ( "),CJT AS(" );
            strSql . Append ( "SELECT MAX(REV004) REV004,REV001 FROM MOXREV GROUP BY REV001" );
            strSql . Append ( "),CKT AS (" );
            strSql . Append ( "SELECT REV003,B.REV001 FROM MOXREV A INNER JOIN CJT B ON A.REV001=B.REV001 AND A.REV004=B.REV004  WHERE REV005='送审'" );
            strSql . Append ( "),CGT AS (" );
            strSql . Append ( "SELECT SRE004,SRE003,REV001 FROM MOXSRE A INNER JOIN CKT B ON A.SRE002=B.REV001 AND A.SRE003=B.REV003" );
            strSql . Append ( "),CLT AS (" );
            strSql . Append ( "SELECT A.SRE002,A.SRE004,B.SRE003 FROM CHT A INNER JOIN CGT B ON A.SRE002=B.REV001 AND A.SRE004=B.SRE004" );
            strSql . Append ( "),CZT AS(" );
            strSql . Append ( "SELECT A.REV004,A.REV001 FROM MOXREV A INNER JOIN CJT B ON A.REV001=B.REV001 AND A.REV004=B.REV004 WHERE REV005='驳回' " );
            strSql . Append ( "),CMT AS (" );
            strSql . Append ( "SELECT A.* FROM MOXREV A INNER JOIN CLT B ON A.REV001=B.SRE002 AND A.REV003=B.SRE003 " );
            strSql . Append ( "UNION ALL " );
            strSql . Append ( "SELECT A.* FROM MOXREV A LEFT JOIN CZT B ON A.REV001=B.REV001 AND A.REV004=B.REV004 WHERE REV005='驳回' AND REV003!=userNum)" );
            strSql . Append ( "SELECT FOR001,REV001,REV002,REV003,EMP002,REV004,REV005,REV006 FROM CMT A LEFT JOIN MOXEMP B ON A.REV003=B.EMP001 LEFT JOIN MOXFOR C ON A.REV001=C.FOR002  WHERE REV004 IN (SELECT MAX(REV004) FROM MOXREV GROUP BY REV001)" );
            SqlParameter [ ] parameter = {
                new SqlParameter("userNum",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = userNum;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
                return dt . Rows . Count;
            else
                return 0;
        }

        public CarpenterEntity . RemindEntity getModel ( DataRow row )
        {
            CarpenterEntity . RemindEntity model = new CarpenterEntity . RemindEntity ( );

            if ( row != null )
            {
                if ( row [ "FOR001" ] != null && row [ "FOR001" ] . ToString ( ) != "" )
                    model . FOR001 = row [ "FOR001" ] . ToString ( );
                if ( row [ "REV001" ] != null && row [ "REV001" ] . ToString ( ) != "" )
                    model . REV001 = row [ "REV001" ] . ToString ( );
                if ( row [ "REV002" ] != null && row [ "REV002" ] . ToString ( ) != "" )
                    model . REV002 = row [ "REV002" ] . ToString ( );
                if ( row [ "REV003" ] != null && row [ "REV003" ] . ToString ( ) != "" )
                    model . REV003 = row [ "REV003" ] . ToString ( );
                if ( row [ "EMP002" ] != null && row [ "EMP002" ] . ToString ( ) != "" )
                    model . EMP002 = row [ "EMP002" ] . ToString ( );
                if ( row [ "REV004" ] != null && row [ "REV004" ] . ToString ( ) != "" )
                    model . REV004 = DateTime . Parse ( row [ "REV004" ] . ToString ( ) );
                if ( row [ "REV005" ] != null && row [ "REV005" ] . ToString ( ) != "" )
                    model . REV005 = row [ "REV005" ] . ToString ( );
                if ( row [ "REV006" ] != null && row [ "REV006" ] . ToString ( ) != "" )
                    model . REV006 = row [ "REV006" ] . ToString ( );
            }

            return model;

        }

    }
}
