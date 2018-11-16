using System . Data;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class ProgramControlDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,FOR001,FOR002,FOR003,FOR004 FROM MOXFOR " );
            
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
            strSql . Append ( "DELETE FROM MOXFOR " );
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
        public int Add ( CarpenterEntity . ProgramControlEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXFOR (" );
            strSql . Append ( "FOR001,FOR002,FOR003,FOR004) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@FOR001,@FOR002,@FOR003,@FOR004);" );
            strSql . Append ( "SELECT SCOPE_IDENTITY();" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@FOR001",SqlDbType.NVarChar,20),
                new SqlParameter("@FOR002",SqlDbType.NVarChar,20),
                new SqlParameter("@FOR003",SqlDbType.NChar,10),
                new SqlParameter("@FOR004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . FOR001;
            parameter [ 1 ] . Value = _model . FOR002;
            parameter [ 2 ] . Value = _model . FOR003;
            parameter [ 3 ] . Value = _model . FOR004;

            return SqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . ProgramControlEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXFOR SET " );
            strSql . Append ( "FOR001=@FOR001," );
            strSql . Append ( "FOR002=@FOR002," );
            strSql . Append ( "FOR003=@FOR003," );
            strSql . Append ( "FOR004=@FOR004 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@FOR001",SqlDbType.NVarChar,20),
                new SqlParameter("@FOR002",SqlDbType.NVarChar,20),
                new SqlParameter("@FOR003",SqlDbType.NChar,10),
                new SqlParameter("@FOR004",SqlDbType.NVarChar,20),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _model . FOR001;
            parameter [ 1 ] . Value = _model . FOR002;
            parameter [ 2 ] . Value = _model . FOR003;
            parameter [ 3 ] . Value = _model . FOR004;
            parameter [ 4 ] . Value = _model . idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

    }
}
