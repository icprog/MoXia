using System . Data;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;
using System;
using System . Collections;

namespace CarpenterBll . Dao
{
    public class MaintainTransmitDao
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere ,string userNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MTR001,MTR002,MTR003,MTR009,MTR004,MTR005,MTR006,MTR007,MTR008,MTR010,MTR011 FROM MOXMTR " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( "AND (MTR005='"+userNum+"'" );
            strSql . Append ( " OR MTR010 LIKE '%" + userNum + "%')" );
            strSql . Append ( " ORDER BY MTR001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable getTableOfView ( string userNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MTR001,MTR002,MTR003,MTR009,MTR004,MTR005,MTR006,MTR007,MTR008,MTR010,MTR011 FROM MOXMTR " );
            strSql . AppendFormat ( " WHERE MTR002='未结束' AND MTR005!='{0}' AND MTR010 LIKE '%{0}%'" ,userNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="mts001"></param>
        /// <returns></returns>
        public DataTable GetDataTableOne ( string mts001 )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MTS002+' '+CONVERT(VARCHAR,MTS004,120)+'：'+MTS003 MTS FROM MOXMTS " );
            strSql . Append ( "WHERE MTS001=@MTS001" );
            strSql . Append ( " ORDER BY MTS004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@MTS001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = mts001;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取联系单编号
        /// </summary>
        /// <returns></returns>
        public string contact ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(MTR001) MTR001 FROM MOXMTR" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "MTR001" ] . ToString ( ) ) )
                    return "000001";
                else
                {
                    string str = dt . Rows [ 0 ] [ "MTR001" ] . ToString ( );
                    str = ( Convert . ToInt64 ( str ) + 1 ) . ToString ( );
                    str = str . PadLeft ( 6 ,'0' );
                    return str;
                }
            }
            else
                return "000001";

        }

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime getTime ( )
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
        /// 增加记录
        /// </summary>
        /// <param name="_MTE"></param>
        /// <param name="_MTS"></param>
        /// <returns></returns>
        public bool Add ( CarpenterEntity . MaintainTransmitMTREntity _MTE,CarpenterEntity . MaintainTransmitMTSEntity _MTS )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXMTR " );
            strSql . AppendFormat ( "WHERE MTR001='{0}'" ,_MTE . MTR001 );
            if ( SqlHelper . Exists ( strSql . ToString ( ) ) == false )
                add_one ( _MTE ,SQLString ,strSql );

            add_two ( _MTS ,SQLString ,strSql );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_one ( CarpenterEntity . MaintainTransmitMTREntity _MTE ,Hashtable SQLString ,StringBuilder strSql )
        {
            _MTE . MTR009 = getTime ( );
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXMTR (" );//
            strSql . Append ( "MTR001,MTR002,MTR003,MTR004,MTR005,MTR006,MTR007,MTR008,MTR009,MTR010,MTR011) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@MTR001,@MTR002,@MTR003,@MTR004,@MTR005,@MTR006,@MTR007,@MTR008,@MTR009,@MTR010,@MTR011)" );//
            SqlParameter [ ] parameter = {
                new SqlParameter("@MTR001",SqlDbType.NVarChar,20),
                new SqlParameter("@MTR002",SqlDbType.NVarChar,500),
                new SqlParameter("@MTR003",SqlDbType.Date),
                new SqlParameter("@MTR004",SqlDbType.DateTime),
                new SqlParameter("@MTR005",SqlDbType.NVarChar,50),
                new SqlParameter("@MTR006",SqlDbType.NVarChar,50),
                new SqlParameter("@MTR007",SqlDbType.NVarChar,50),
                new SqlParameter("@MTR008",SqlDbType.NVarChar,50),
                new SqlParameter("@MTR009",SqlDbType.Date),
                new SqlParameter("@MTR010",SqlDbType.NVarChar,500),
                new SqlParameter("@MTR011",SqlDbType.NVarChar,100)
            };
            parameter [ 0 ] . Value = _MTE . MTR001;
            parameter [ 1 ] . Value = _MTE . MTR002;
            parameter [ 2 ] . Value = _MTE . MTR003;
            parameter [ 3 ] . Value = _MTE . MTR004;
            parameter [ 4 ] . Value = _MTE . MTR005;
            parameter [ 5 ] . Value = _MTE . MTR006;
            parameter [ 6 ] . Value = _MTE . MTR007;
            parameter [ 7 ] . Value = _MTE . MTR008;
            parameter [ 8 ] . Value = _MTE . MTR009;
            parameter [ 9 ] . Value = _MTE . MTR010;
            parameter [ 10 ] . Value = _MTE . MTR011;

            SQLString . Add ( strSql ,parameter );
        }

        void add_two ( CarpenterEntity . MaintainTransmitMTSEntity _MTS ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXMTS (" );
            strSql . Append ( "MTS001,MTS002,MTS003,MTS004) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@MTS001,@MTS002,@MTS003,@MTS004) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@MTS001",SqlDbType.NVarChar,20),
                new SqlParameter("@MTS002",SqlDbType.NVarChar,20),
                new SqlParameter("@MTS003",SqlDbType.NVarChar,500),
                new SqlParameter("@MTS004",SqlDbType.DateTime)
            };
            parameter [ 0 ] . Value = _MTS . MTS001;
            parameter [ 1 ] . Value = _MTS . MTS002;
            parameter [ 2 ] . Value = _MTS . MTS003;
            parameter [ 3 ] . Value = _MTS . MTS004;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 编辑结束标记
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public bool Edit ( string contact,string sign )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXMTR SET " );
            strSql . Append ( "MTR002=@MTR002 " );
            strSql . Append ( "WHERE MTR001=@MTR001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@MTR001",SqlDbType.NVarChar,20),
                new SqlParameter("@MTR002",SqlDbType.NVarChar,50)
            };
            parameter [ 0 ] . Value = contact;
            parameter [ 1 ] . Value = sign;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 工作联系单
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfGZ ( string userNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT STR001,STR002 FROM MOXSTR " );
            strSql . AppendFormat ( "WHERE STR003='{0}'" ,userNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public DataTable printOne ( string contact )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MTS001,MTR002,MTS002,CONVERT(VARCHAR,MTR003,102) MTR003,MTS002+' '+CONVERT(VARCHAR,MTS004,120)+'：'+REPLACE(MTS003,CHAR(10),'')  MTS003,MTR004,MTR005,MTR006,MTR007,MTR008,MTR010,CONVERT(CHAR(8),MTR004,108) MTR004,MTR011 FROM MOXMTR A LEFT JOIN MOXMTS B ON A.MTR001=B.MTS001 " );
            strSql . AppendFormat ( "WHERE MTR001='" + contact + "'" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable printTwo ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MTR001,MTR002,MTR003,MTR009,CONVERT(CHAR(8),MTR004,120) MTR004,MTR005,MTR006,MTR008,MTR010 FROM MOXMTR " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
