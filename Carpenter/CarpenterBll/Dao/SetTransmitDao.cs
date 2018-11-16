using System . Text;
using StudentMgr;
using System . Data;
using System . Data . SqlClient;
using System . Collections . Generic;
using System . Collections;
using System;

namespace CarpenterBll . Dao
{
    public class SetTransmitDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,STR001,STR002,STR003,STR004 FROM MOXSTR ORDER BY STR003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="str001"></param>
        /// <param name="str002"></param>
        /// <param name="str003"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXSTR " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@idx",SqlDbType.Int,4)
            };
            parameter [ 0 ] . Value = idx;
            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetPerson ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT EMP001,EMP002,DEP002 FROM MOXEMP A INNER JOIN MOXDEP B ON A.EMP003=B.DEP001 WHERE EMP001!='00001' ORDER BY DEP002,EMP001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        DateTime dt ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GETDATE() t" );

            DataTable tab = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( tab != null && tab . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( tab . Rows [ 0 ] [ "t" ] . ToString ( ) ) )
                    return DateTime . Now;
                else
                    return DateTime . Parse ( tab . Rows [ 0 ] [ "t" ] . ToString ( ) );
            }
            else
                return DateTime . Now;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool Add ( List<CarpenterBll . Paramete> table ,string userName )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            CarpenterEntity . SetTransmitEntity model = new CarpenterEntity . SetTransmitEntity ( );
            model . STR005 = dt ( );
            model . STR006 = userName;

            Paramete pam = table . Find ( ( k ) =>
            {
                return k . Key . Equals ( "1" );
            } );
            model . STR001 = pam . Name;
            model . STR002 = pam . Value;
            foreach ( Paramete pa in table )
            {
                if ( !pa . Key . Equals ( "1" ) )
                {
                    model . STR003 = pa . Name;
                    model . STR004 = pa . Value;

                    if ( Exists ( model . STR001 ,model . STR003 ) == false )
                        add_one ( model ,SQLString ,strSql );
                }

               
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        bool Exists ( string str001 ,string str003 )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXSTR " );
            strSql . Append ( "WHERE STR001=@STR001 AND STR003=@STR003" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@STR001",SqlDbType.NVarChar,20),
                new SqlParameter("@STR003",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = str001;
            parameter [ 1 ] . Value = str003;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );

        }

        void add_one ( CarpenterEntity . SetTransmitEntity model ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXSTR (" );
            strSql . Append ( "STR001,STR002,STR003,STR004,STR005,STR006) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@STR001,@STR002,@STR003,@STR004,@STR005,@STR006) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@STR001",SqlDbType.NVarChar,20),
                new SqlParameter("@STR002",SqlDbType.NVarChar,20),
                new SqlParameter("@STR003",SqlDbType.NVarChar,20),
                new SqlParameter("@STR004",SqlDbType.NVarChar,20),
                new SqlParameter("@STR005",SqlDbType.Date),
                new SqlParameter("@STR006",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = model . STR001;
            parameter [ 1 ] . Value = model . STR002;
            parameter [ 2 ] . Value = model . STR003;
            parameter [ 3 ] . Value = model . STR004;
            parameter [ 4 ] . Value = model . STR005;
            parameter [ 5 ] . Value = model . STR006;

            SQLString . Add ( strSql ,parameter );
        }

    }
}
