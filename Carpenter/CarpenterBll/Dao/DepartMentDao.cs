using System . Text;
using StudentMgr;
using System . Data;
using System . Data . SqlClient;
using System . Collections;

namespace CarpenterBll . Dao
{
    public class DepartMentDao
    {
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( int pid )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,DEP001,DEP002,DEP003 FROM MOXDEP " );
            strSql . Append ( "WHERE DEP003=@DEP003 ORDER BY DEP001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@DEP003",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = pid;

           return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public CarpenterEntity . DepartMentEntity GetModel ( DataRow row )
        {
            CarpenterEntity . DepartMentEntity _model = new CarpenterEntity . DepartMentEntity ( );

            if ( row != null )
            {
                if ( row [ "idx" ] != null && row [ "idx" ] . ToString ( ) != "" )
                    _model . IDX = int . Parse ( row [ "idx" ] . ToString ( ) );
                if ( row [ "DEP001" ] != null && row [ "DEP001" ] . ToString ( ) != "" )
                    _model . DEP001 = row [ "DEP001" ] . ToString ( );
                if ( row [ "DEP002" ] != null && row [ "DEP002" ] . ToString ( ) != "" )
                    _model . DEP002 = row [ "DEP002" ] . ToString ( );
                if ( row [ "DEP003" ] != null && row [ "DEP003" ] . ToString ( ) != "" )
                    _model . DEP003 = int . Parse ( row [ "DEP003" ] . ToString ( ) );

            }

            return _model;
        }

        /// <summary>
        /// 获取部门编号
        /// </summary>
        /// <returns></returns>
        public string GetStr ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(DEP001) DEP001 FROM MOXDEP" );

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "DEP001" ] . ToString ( ) ) )
                    return string . Empty;
                else
                    return da . Rows [ 0 ] [ "DEP001" ] . ToString ( );
            }
            else
                return string . Empty;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete ( string id )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );

            deletePid ( id ,strSql ,SQLString );
            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void deletePid ( string pid ,StringBuilder strSql ,ArrayList SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DEP001 FROM MOXDEP " );
            strSql . AppendFormat ( "WHERE DEP003='{0}'" ,pid );
            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                foreach ( DataRow row in da . Rows )
                {
                    strSql = new StringBuilder ( );
                    strSql . Append ( "DELETE FROM MOXDEP " );
                    strSql . AppendFormat ( "WHERE DEP001={0}" ,pid );
                    SQLString . Add ( strSql . ToString ( ) );
                    string pd = row [ "DEP001" ] . ToString ( );
                    deletePid ( pd ,strSql ,SQLString );
                }
            }
            else
            {
                strSql = new StringBuilder ( );
                strSql . Append ( "DELETE FROM MOXDEP " );
                strSql . AppendFormat ( "WHERE DEP001='{0}'" ,pid );
                SQLString . Add ( strSql . ToString ( ) );
            }
        }

        /// <summary>
        /// 注销记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Examine ( int id,string state )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXDEP SET " );
            strSql . Append ( "DEP003=@DEP003 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@DEP003",SqlDbType.Bit),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = state;
            parameter [ 1 ] . Value = id;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Save ( CarpenterEntity . DepartMentEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXDEP (" );
            strSql . Append ( "DEP001,DEP002,DEP003,DEP004) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@DEP001,@DEP002,@DEP003,@DEP004);" );
            strSql . Append ( "SELECT SCOPE_IDENTITY()" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@DEP001",SqlDbType.NVarChar,20),
                new SqlParameter("@DEP002",SqlDbType.NVarChar,20),
                new SqlParameter("@DEP003",SqlDbType.Int),
                new SqlParameter("@DEP004",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _model . DEP001;
            parameter [ 1 ] . Value = _model . DEP002;
            parameter [ 2 ] . Value = _model . DEP003;
            parameter [ 3 ] . Value = _model . DEP004;

            return  SqlHelper .ExecuteSqlReturnId ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 删除具有相同编号和名称的部门
        /// </summary>
        /// <param name="nameOfDe"></param>
        /// <returns></returns>
        public bool Exists ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(idx) idx FROM MOXDEP GROUP BY DEP001,DEP002 HAVING COUNT(1)>1 " );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                ArrayList SQLString = new ArrayList ( );
                
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "DELETE FROM MOXDEP WHERE idx={0}" ,dt . Rows [ i ] [ "idx" ] . ToString ( ) );
                    SQLString . Add ( strSql . ToString ( ) );
                }
                return SqlHelper . ExecuteSqlTran ( SQLString );
            }
            else
                return true;
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . DepartMentEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXDEP SET " );       
            strSql . Append ( "DEP002=@DEP002, " );
            strSql . Append ( "DEP004=@DEP004 " );
            strSql . Append ( "WHERE DEP001=@DEP001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@DEP001",SqlDbType.NVarChar,20),
                new SqlParameter("@DEP002",SqlDbType.NVarChar,20),
                new SqlParameter("@DEP004",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _model . DEP001;
            parameter [ 1 ] . Value = _model . DEP002;
            parameter [ 2 ] . Value = _model . DEP004;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取pid
        /// </summary>
        /// <param name="DEP001"></param>
        /// <returns></returns>
        public string GetDEP003 ( string DEP001 )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DEP003 FROM MOXDEP WHERE DEP001=@DEP001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@DEP001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = DEP001;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "DEP003" ] . ToString ( ) ) )
                    return null;
                else
                    return dt . Rows [ 0 ] [ "DEP003" ] . ToString ( );
            }
            else
                return null;
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DEP001,DEP002 FROM MOXDEP WHERE DEP001!='0001' ORDER BY DEP001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取是否工作中心
        /// </summary>
        /// <param name="numOfDepart"></param>
        /// <returns></returns>
        public bool signOfJob ( string numOfDepart )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DEP004 FROM MOXDEP " );
            strSql . Append ( "WHERE DEP001=@DEP001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@DEP001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = numOfDepart;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "DEP004" ] . ToString ( ) ) )
                    return false;
                else
                    return ( bool ) dt . Rows [ 0 ] [ "DEP004" ];
            }
            else
                return false;
        }

    }
}
