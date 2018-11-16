
using System . Data;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class OPIDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOne ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT OPI001,OPI002 FROM MOXOPI ORDER BY OPI001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string fileName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM MOXOPI",fileName );

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
            strSql . Append ( "SELECT idx,OPI001,OPI002,OPI003,OPI004,OPI005,OPI006,OPI007,OPI008,OPI009,OPI010,OPI011,OPI012 FROM MOXOPI " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( "ORDER BY OPI001" );

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
            strSql . Append ( "DELETE FROM MOXOPI " );
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
        /// 注销
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Cancellation ( int idx ,bool state )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXOPI SET " );
            strSql . Append ( "OPI011=@OPI011 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@OPI011",SqlDbType.Bit),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = state;
            parameter [ 1 ] . Value = idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在此品号
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public bool Exists ( string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXOPI " );
            strSql . Append ( "WHERE OPI001=@OPI001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@OPI001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = productNum;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( CarpenterEntity . OPIEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXOPI (" );
            strSql . Append ( "OPI001,OPI002,OPI003,OPI004,OPI005,OPI006,OPI007,OPI008,OPI009,OPI010,OPI011,OPI012) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@OPI001,@OPI002,@OPI003,@OPI004,@OPI005,@OPI006,@OPI007,@OPI008,@OPI009,@OPI010,@OPI011,@OPI012); " );
            strSql . Append ( "SELECT SCOPE_IDENTITY(); " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@OPI001",SqlDbType.NVarChar,20),
                new SqlParameter("@OPI002",SqlDbType.NVarChar,20),
                new SqlParameter("@OPI003",SqlDbType.NVarChar,20),
                new SqlParameter("@OPI004",SqlDbType.Decimal,18),
                new SqlParameter("@OPI005",SqlDbType.NVarChar,20),
                new SqlParameter("@OPI006",SqlDbType.NVarChar,20),
                new SqlParameter("@OPI007",SqlDbType.NVarChar,10),
                new SqlParameter("@OPI008",SqlDbType.NVarChar,10),
                new SqlParameter("@OPI009",SqlDbType.NVarChar,10),
                new SqlParameter("@OPI010",SqlDbType.NVarChar,10),
                new SqlParameter("@OPI011",SqlDbType.Bit),
                new SqlParameter("@OPI012",SqlDbType.VarBinary)
            };
            parameter [ 0 ] . Value = _model . OPI001;
            parameter [ 1 ] . Value = _model . OPI002;
            parameter [ 2 ] . Value = _model . OPI003;
            parameter [ 3 ] . Value = _model . OPI004;
            parameter [ 4 ] . Value = _model . OPI005;
            parameter [ 5 ] . Value = _model . OPI006;
            parameter [ 6 ] . Value = _model . OPI007;
            parameter [ 7 ] . Value = _model . OPI008;
            parameter [ 8 ] . Value = _model . OPI009;
            parameter [ 9 ] . Value = _model . OPI010;
            parameter [ 10 ] . Value = _model . OPI011;
            parameter [ 11 ] . Value = _model . OPI012;

            return SqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . OPIEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXOPI SET " );
            strSql . Append ( "OPI001=@OPI001," );
            strSql . Append ( "OPI002=@OPI002," );
            strSql . Append ( "OPI003=@OPI003," );
            strSql . Append ( "OPI004=@OPI004," );
            strSql . Append ( "OPI005=@OPI005," );
            strSql . Append ( "OPI006=@OPI006," );
            strSql . Append ( "OPI007=@OPI007," );
            strSql . Append ( "OPI008=@OPI008," );
            strSql . Append ( "OPI009=@OPI009," );
            strSql . Append ( "OPI010=@OPI010," );
            strSql . Append ( "OPI012=@OPI012 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@OPI001",SqlDbType.NVarChar,20),
                new SqlParameter("@OPI002",SqlDbType.NVarChar,20),
                new SqlParameter("@OPI003",SqlDbType.NVarChar,20),
                new SqlParameter("@OPI004",SqlDbType.Decimal,18),
                new SqlParameter("@OPI005",SqlDbType.NVarChar,20),
                new SqlParameter("@OPI006",SqlDbType.NVarChar,20),
                new SqlParameter("@OPI007",SqlDbType.NVarChar,10),
                new SqlParameter("@OPI008",SqlDbType.NVarChar,10),
                new SqlParameter("@OPI009",SqlDbType.NVarChar,10),
                new SqlParameter("@OPI010",SqlDbType.NVarChar,10),
                new SqlParameter("@OPI012",SqlDbType.VarBinary),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _model . OPI001;
            parameter [ 1 ] . Value = _model . OPI002;
            parameter [ 2 ] . Value = _model . OPI003;
            parameter [ 3 ] . Value = _model . OPI004;
            parameter [ 4 ] . Value = _model . OPI005;
            parameter [ 5 ] . Value = _model . OPI006;
            parameter [ 6 ] . Value = _model . OPI007;
            parameter [ 7 ] . Value = _model . OPI008;
            parameter [ 8 ] . Value = _model . OPI009;
            parameter [ 9 ] . Value = _model . OPI010;
            parameter [ 10 ] . Value = _model . OPI012;
            parameter [ 11 ] . Value = _model . idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取品号
        /// </summary>
        /// <returns></returns>
        public string GetNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(OPI001) OPI001 FROM MOXOPI " );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "OPI001" ] . ToString ( ) ) )
                    return string . Empty;
                else
                    return dt . Rows [ 0 ] [ "OPI001" ] . ToString ( );
            }
            else
                return string . Empty;
        }

        /// <summary>
        /// 是否在BOM清单或开料周计划中存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exists (int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXWOQ WHERE WOQ001=(SELECT OPI001 FROM MOXOPI WHERE idx={0})" ,idx );

            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return true;
            else
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXCUU WHERE CUU002=(SELECT OPI001 FROM MOXOPI WHERE idx={0})" ,idx );
                if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                    return true;
                else
                    return false;
            }
        }

    }
}
