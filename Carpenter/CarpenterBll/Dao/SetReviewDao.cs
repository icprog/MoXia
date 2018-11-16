using StudentMgr;
using System . Data;
using System . Data . SqlClient;
using System . Text;

namespace CarpenterBll . Dao
{
    public class SetReviewDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,SRE001,SRE002,SRE003,EMP002,FOR001,SRE004 FROM MOXSRE A LEFT JOIN MOXEMP B ON A.SRE003=B.EMP001 LEFT JOIN MOXFOR C ON A.SRE002=C.FOR002 ORDER BY SRE002,SRE004" );

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
            strSql . Append ( "DELETE FROM MOXSRE " );
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
        public int Save ( CarpenterEntity . SetReviewEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXSRE (" );
            strSql . Append ( "SRE002,SRE003,SRE004,SRE005,SRE006) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@SRE002,@SRE003,@SRE004,@SRE005,@SRE006); " );
            strSql . Append ( "SELECT SCOPE_IDENTITY();" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@SRE002",SqlDbType.NVarChar,20),
                new SqlParameter("@SRE003",SqlDbType.NVarChar,20),
                new SqlParameter("@SRE004",SqlDbType.NVarChar,20),
                new SqlParameter("@SRE005",SqlDbType.Date),
                new SqlParameter("@SRE006",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . SRE002;
            parameter [ 1 ] . Value = _model . SRE003;
            parameter [ 2 ] . Value = _model . SRE004;
            parameter [ 3 ] . Value = _model . SRE005;
            parameter [ 4 ] . Value = _model . SRE006;

            return SqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . SetReviewEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXSRE SET " );
            strSql . Append ( "SRE002=@SRE002," );
            strSql . Append ( "SRE003=@SRE003," );
            strSql . Append ( "SRE004=@SRE004," );
            strSql . Append ( "SRE005=@SRE005," );
            strSql . Append ( "SRE006=@SRE006 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@SRE002",SqlDbType.NVarChar,20),
                new SqlParameter("@SRE003",SqlDbType.NVarChar,20),
                new SqlParameter("@SRE004",SqlDbType.NVarChar,20),
                new SqlParameter("@SRE005",SqlDbType.Date),
                new SqlParameter("@SRE006",SqlDbType.NVarChar,20),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _model . SRE002;
            parameter [ 1 ] . Value = _model . SRE003;
            parameter [ 2 ] . Value = _model . SRE004;
            parameter [ 3 ] . Value = _model . SRE005;
            parameter [ 4 ] . Value = _model . SRE006;
            parameter [ 5 ] . Value = _model . idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

    }
}
