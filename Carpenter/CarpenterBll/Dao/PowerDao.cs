using System . Data;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class PowerDao
    {
        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetPerson ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT EMP001,EMP002 FROM MOXEMP WHERE EMP001!='00001' AND EMP008=0" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取程序信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetProgram ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT FOR002,FOR001 FROM MOXFOR WHERE FOR003='1'" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,A.POW002,B.EMP001,A.POW003,FOR001,B.EMP002,POW004,POW005,POW006,POW007,POW008,POW009,POW010,POW011,POW012,POW013,POW016,POW017 FROM MOXPOW A LEFT JOIN MOXEMP B ON A.POW002=B.EMP001 LEFT JOIN MOXFOR C ON A.POW003=C.FOR002 " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPOW " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;

        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( CarpenterEntity . PowerEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPOW (" );
            strSql . Append ( "POW002,POW003,POW004,POW005,POW006,POW007,POW008,POW009,POW010,POW011,POW012,POW013,POW016,POW017) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@POW002,@POW003,@POW004,@POW005,@POW006,@POW007,@POW008,@POW009,@POW010,@POW011,@POW012,@POW013,@POW016,@POW017);" );
            strSql . Append ( "SELECT SCOPE_IDENTITY();" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@POW002",SqlDbType.NVarChar,20),
                new SqlParameter("@POW003",SqlDbType.NVarChar,50),
                new SqlParameter("@POW004",SqlDbType.Bit),
                new SqlParameter("@POW005",SqlDbType.Bit),
                new SqlParameter("@POW006",SqlDbType.Bit),
                new SqlParameter("@POW007",SqlDbType.Bit),
                new SqlParameter("@POW008",SqlDbType.Bit),
                new SqlParameter("@POW009",SqlDbType.Bit),
                new SqlParameter("@POW010",SqlDbType.Bit),
                new SqlParameter("@POW011",SqlDbType.Bit),
                new SqlParameter("@POW012",SqlDbType.Bit),
                new SqlParameter("@POW013",SqlDbType.Bit),
                new SqlParameter("@POW016",SqlDbType.Bit),
                new SqlParameter("@POW017",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _model . POW002;
            parameter [ 1 ] . Value = _model . POW003;
            parameter [ 2 ] . Value = _model . POW004;
            parameter [ 3 ] . Value = _model . POW005;
            parameter [ 4 ] . Value = _model . POW006;
            parameter [ 5 ] . Value = _model . POW007;
            parameter [ 6 ] . Value = _model . POW008;
            parameter [ 7 ] . Value = _model . POW009;
            parameter [ 8 ] . Value = _model . POW010;
            parameter [ 9 ] . Value = _model . POW011;
            parameter [ 10 ] . Value = _model . POW012;
            parameter [ 11 ] . Value = _model . POW013;
            parameter [ 12 ] . Value = _model . POW016;
            parameter [ 13 ] . Value = _model . POW017;

            return SqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . PowerEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPOW SET " );
            strSql . Append ( "POW002=@POW002," );
            strSql . Append ( "POW003=@POW003," );
            strSql . Append ( "POW004=@POW004," );
            strSql . Append ( "POW005=@POW005," );
            strSql . Append ( "POW006=@POW006," );
            strSql . Append ( "POW007=@POW007," );
            strSql . Append ( "POW008=@POW008," );
            strSql . Append ( "POW009=@POW009," );
            strSql . Append ( "POW010=@POW010," );
            strSql . Append ( "POW011=@POW011," );
            strSql . Append ( "POW012=@POW012," );
            strSql . Append ( "POW013=@POW013," );
            strSql . Append ( "POW016=@POW016," );
            strSql . Append ( "POW017=@POW017 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@POW002",SqlDbType.NVarChar,20),
                new SqlParameter("@POW003",SqlDbType.NVarChar,50),
                new SqlParameter("@POW004",SqlDbType.Bit),
                new SqlParameter("@POW005",SqlDbType.Bit),
                new SqlParameter("@POW006",SqlDbType.Bit),
                new SqlParameter("@POW007",SqlDbType.Bit),
                new SqlParameter("@POW008",SqlDbType.Bit),
                new SqlParameter("@POW009",SqlDbType.Bit),
                new SqlParameter("@POW010",SqlDbType.Bit),
                new SqlParameter("@POW011",SqlDbType.Bit),
                new SqlParameter("@POW012",SqlDbType.Bit),
                new SqlParameter("@POW013",SqlDbType.Bit),
                new SqlParameter("@POW016",SqlDbType.Bit),
                new SqlParameter("@POW017",SqlDbType.Bit),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _model . POW002;
            parameter [ 1 ] . Value = _model . POW003;
            parameter [ 2 ] . Value = _model . POW004;
            parameter [ 3 ] . Value = _model . POW005;
            parameter [ 4 ] . Value = _model . POW006;
            parameter [ 5 ] . Value = _model . POW007;
            parameter [ 6 ] . Value = _model . POW008;
            parameter [ 7 ] . Value = _model . POW009;
            parameter [ 8 ] . Value = _model . POW010;
            parameter [ 9 ] . Value = _model . POW011;
            parameter [ 10 ] . Value = _model . POW012;
            parameter [ 11 ] . Value = _model . POW013;
            parameter [ 12 ] . Value = _model . POW016;
            parameter [ 13 ] . Value = _model . POW017;
            parameter [ 14 ] . Value = _model . idx;

            int row= SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Exsits ( CarpenterEntity . PowerEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXPOW " );
            strSql . Append ( "WHERE POW002=@POW002 AND POW003=@POW003" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@POW002",SqlDbType.NVarChar,50),
                new SqlParameter("@POW003",SqlDbType.NVarChar,50)
            };
            parameter [ 0 ] . Value = _model . POW002;
            parameter [ 1 ] . Value = _model . POW003;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int EditIdx ( CarpenterEntity . PowerEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx FROM MOXPOW " );
            strSql . Append ( "WHERE POW002=@POW002 AND POW003=@POW003" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@POW002",SqlDbType.NVarChar,20),
                new SqlParameter("@POW003",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . POW002;
            parameter [ 1 ] . Value = _model . POW003;

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "idx" ] . ToString ( ) ) )
                    return 0;
                else
                    return int . Parse ( da . Rows [ 0 ] [ "idx" ] . ToString ( ) );
            }
            else
                return 0;
        }

    }
}
