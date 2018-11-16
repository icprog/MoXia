using System . Text;
using StudentMgr;
using System . Data;
using System . Data . SqlClient;
using System . Collections . Generic;

namespace CarpenterBll . Dao
{
    public class EmployeeDao
    {
        /// <summary>
        /// 获取人员编号
        /// </summary>
        /// <returns></returns>
        public string GetNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(EMP001) EMP001 FROM MOXEMP " );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "EMP001" ] . ToString ( ) ) )
                    return string . Empty;
                else
                    return dt . Rows [ 0 ] [ "EMP001" ] . ToString ( );
            }
            else
                return string . Empty;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete ( int id )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXEMP " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] .Value = id;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Exists ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXEMP " );
            strSql . AppendFormat ( "WHERE EMP001='{0}'" ,num );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( CarpenterEntity . EmployeeEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXEMP (" );
            strSql . Append ( "EMP001,EMP002,EMP003,EMP004,EMP005,EMP006,EMP007,EMP008,EMP009,EMP010,EMP011,EMP012) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EMP001,@EMP002,@EMP003,@EMP004,@EMP005,@EMP006,@EMP007,@EMP008,@EMP009,@EMP010,@EMP011,@EMP012);" );
            strSql . Append ( "SELECT SCOPE_IDENTITY();" );
            SqlParameter [ ] parametere = {
                new SqlParameter("@EMP001",SqlDbType.NVarChar,20),
                new SqlParameter("@EMP002",SqlDbType.NVarChar,20),
                new SqlParameter("@EMP003",SqlDbType.NVarChar,20),
                new SqlParameter("@EMP004",SqlDbType.NVarChar,20),
                new SqlParameter("@EMP005",SqlDbType.NVarChar,20),
                new SqlParameter("@EMP006",SqlDbType.NVarChar,50),
                new SqlParameter("@EMP007",SqlDbType.NVarChar,200),
                new SqlParameter("@EMP008",SqlDbType.Bit),
                new SqlParameter("@EMP009",SqlDbType.NVarChar,50),
                new SqlParameter("@EMP010",SqlDbType.NVarChar,2),
                new SqlParameter("@EMP011",SqlDbType.Decimal,4),
                new SqlParameter("@EMP012",SqlDbType.NVarChar,20)
            };
            parametere [ 0 ] . Value = _model . EMP001;
            parametere [ 1 ] . Value = _model . EMP002;
            parametere [ 2 ] . Value = _model . EMP003;
            parametere [ 3 ] . Value = _model . EMP004;
            parametere [ 4 ] . Value = _model . EMP005;
            parametere [ 5 ] . Value = _model . EMP006;
            parametere [ 6 ] . Value = _model . EMP007;
            parametere [ 7 ] . Value = _model . EMP008;
            parametere [ 8 ] . Value = _model . EMP009;
            parametere [ 9 ] . Value = _model . EMP010;
            parametere [ 10 ] . Value = _model . EMP011;
            parametere [ 11 ] . Value = _model . EMP012;

            return SqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parametere );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . EmployeeEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXEMP SET " );
            strSql . Append ( "EMP001=@EMP001," );
            strSql . Append ( "EMP002=@EMP002," );
            strSql . Append ( "EMP003=@EMP003," );
            strSql . Append ( "EMP004=@EMP004," );
            strSql . Append ( "EMP005=@EMP005," );
            strSql . Append ( "EMP006=@EMP006," );
            strSql . Append ( "EMP007=@EMP007," );
            strSql . Append ( "EMP008=@EMP008," );
            strSql . Append ( "EMP010=@EMP010," );
            strSql . Append ( "EMP011=@EMP011," );
            strSql . Append ( "EMP012=@EMP012" );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parametere = {
                new SqlParameter("@EMP001",SqlDbType.NVarChar,20),
                new SqlParameter("@EMP002",SqlDbType.NVarChar,20),
                new SqlParameter("@EMP003",SqlDbType.NVarChar,20),
                new SqlParameter("@EMP004",SqlDbType.NVarChar,20),
                new SqlParameter("@EMP005",SqlDbType.NVarChar,20),
                new SqlParameter("@EMP006",SqlDbType.NVarChar,50),
                new SqlParameter("@EMP007",SqlDbType.NVarChar,200),
                new SqlParameter("@EMP008",SqlDbType.Bit),
                new SqlParameter("@EMP010",SqlDbType.NVarChar,2),
                new SqlParameter("@EMP011",SqlDbType.Decimal,4),
                new SqlParameter("@EMP012",SqlDbType.NVarChar,20),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parametere [ 0 ] . Value = _model . EMP001;
            parametere [ 1 ] . Value = _model . EMP002;
            parametere [ 2 ] . Value = _model . EMP003;
            parametere [ 3 ] . Value = _model . EMP004;
            parametere [ 4 ] . Value = _model . EMP005;
            parametere [ 5 ] . Value = _model . EMP006;
            parametere [ 6 ] . Value = _model . EMP007;
            parametere [ 7 ] . Value = _model . EMP008;
            parametere [ 8 ] . Value = _model . EMP010;
            parametere [ 9 ] . Value = _model . EMP011;
            parametere [ 10 ] . Value = _model . EMP012;
            parametere [ 11 ] . Value = _model . idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parametere );
            if ( row > 0 )
                return true;
            else
                return false;

        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableAll ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,EMP001,EMP002,EMP003,DEP002,EMP004,EMP005,EMP006,EMP007,EMP008,EMP010,EMP011,EMP012 FROM MOXEMP A LEFT JOIN MOXDEP B ON EMP003=DEP001 WHERE EMP001!='00001' ORDER BY EMP001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 编辑注销状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public bool Cancel ( int id ,bool sign )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXEMP SET " );
            strSql . Append ( "EMP008=@EMP008 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EMP008",SqlDbType.Bit),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = sign;
            parameter [ 1 ] . Value = id;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="userNum"></param>
        /// <param name="pwdMD5"></param>
        /// <returns></returns>
        public bool yesOrNoLogin ( string userName ,string pwdMD5 )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXEMP " );
            strSql . Append ( "WHERE EMP002=@EMP002 AND EMP009=@EMP009 AND EMP008=0" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EMP002",SqlDbType.NVarChar,20),
                new SqlParameter("@EMP009",SqlDbType.NVarChar,50)
            };
            parameter [ 0 ] . Value = userName;
            parameter [ 1 ] . Value = pwdMD5;

            return  SqlHelper .Exists ( strSql . ToString ( ) ,parameter );           
        }

        /// <summary>
        /// 获取用户编号
        /// </summary>
        /// <param name="usernum"></param>
        /// <returns></returns>
        public string GetUserNum ( string username )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT EMP001 FROM MOXEMP " );
            strSql . Append ( "WHERE EMP002=@EMP002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EMP002",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = username;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "EMP001" ] . ToString ( ) ) )
                    return string . Empty;
                else
                    return dt . Rows [ 0 ] [ "EMP001" ] . ToString ( );
            }
            else
                return string . Empty;
        }

        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="numOfPerson"></param>
        /// <param name="pw"></param>
        /// <returns></returns>
        public bool EditPw ( string numOfPerson ,string pw )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXEMP SET " );
            strSql . Append ( "EMP009=@EMP009 " );
            strSql . Append ( "WHERE EMP001=@EMP001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EMP001",SqlDbType.NVarChar,20),
                new SqlParameter("@EMP009",SqlDbType.NVarChar,50)
            };
            parameter [ 0 ] . Value = numOfPerson;
            parameter [ 1 ] . Value = pw;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="intList"></param>
        /// <returns></returns>
        public DataTable printOne ( List<int> intList )
        {
            StringBuilder strSql = new StringBuilder ( );
            if ( intList . Count > 0 )
            {
                string idxStr = string . Empty;
                foreach ( int i in intList )
                {
                    if ( idxStr == string . Empty )
                        idxStr = i . ToString ( );
                    else
                        idxStr = idxStr + "," + i . ToString ( );
                }
                strSql . Append ( "SELECT EMP001,EMP002,DEP002 FROM MOXEMP A LEFT JOIN MOXDEP B ON A.EMP003=B.DEP001 " );
                strSql . AppendFormat ( "WHERE A.idx IN ({0})" ,idxStr );
            }
            else
                strSql . Append ( "SELECT EMP001,EMP002,DEP002 FROM MOXEMP A LEFT JOIN MOXDEP B ON A.EMP003=B.DEP001 " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
