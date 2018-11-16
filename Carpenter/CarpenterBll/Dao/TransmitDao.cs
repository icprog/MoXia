using System . Text;
using System . Data;
using StudentMgr;
using System . Collections;
using System;
using System . Data . SqlClient;
using System . Collections . Generic;
using System . Linq;

namespace CarpenterBll . Dao
{
    public class TransmitDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,TRA001,TRA002 FROM MOXTRA ORDER BY TRA001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ); 
        }

        DateTime dt ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GETDATE() t" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) ) )
                    return DateTime . Parse ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) );
                else
                    return DateTime . Now;
            }
            else
                return DateTime . Now;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,string userName )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            CarpenterEntity . TransmitEntity model = new CarpenterEntity . TransmitEntity ( );

            strSql . Append ( "SELECT TRA001,TRA002 FROM MOXTRA" );

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            List<int> strList = new List<int> ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                model . TRA001 = table . Rows [ i ] [ "TRA001" ] . ToString ( );
                model . TRA002 = table . Rows [ i ] [ "TRA002" ] . ToString ( );
                model . TRA003 = dt ( );
                model . TRA004 = userName;

                if ( da . Select ( "TRA001='" + model . TRA001 + "'" ) . Length < 1 )
                {
                    if ( da . Select ( "TRA002='" + model . TRA002 + "'" ) . Length < 1 )
                        add_one ( model ,SQLString ,strSql );
                }
                else
                {
                    if ( strList . Contains ( Convert . ToInt32 ( model . TRA001 ) ) )
                        model . TRA001 = strList . Max ( ) . ToString ( );
                    else
                        model . TRA001 = da . Compute ( "MAX(TRA001)" ,null ) . ToString ( );

                    model . TRA001 = ( Convert . ToInt32 ( model . TRA001 ) + 1 ) . ToString ( );
                    model . TRA001 = model . TRA001 . PadLeft ( 3 ,'0' );
                    strList . Add ( Convert . ToInt32 ( model . TRA001 ) );
                    if ( da . Select ( "TRA002='" + model . TRA002 + "'" ) . Length < 1 )
                        add_one ( model ,SQLString ,strSql );
                }

                //if ( da . Select ( "TRA001='" + model . TRA001 + "' AND TRA002='" + model . TRA002 + "'" ) . Length < 1 )
                //    add_one ( model ,SQLString ,strSql );
                //else
                //    edit_one ( model ,SQLString ,strSql );
            }

            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    model . TRA001 = da . Rows [ i ] [ "TRA001" ] . ToString ( );
                    model . TRA002 = da . Rows [ i ] [ "TRA002" ] . ToString ( );

                    if ( table . Select ( "TRA001='" + model . TRA001 + "' AND TRA002='" + model . TRA002 + "'" ) . Length < 1 )
                        delete ( model ,SQLString ,strSql );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        void add_one ( CarpenterEntity . TransmitEntity model,Hashtable SQLString,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXTRA (" );
            strSql . Append ( "TRA001,TRA002,TRA003,TRA004)" );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@TRA001,@TRA002,@TRA003,@TRA004)" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@TRA001",SqlDbType.NVarChar,20),
                new SqlParameter("@TRA002",SqlDbType.NVarChar,50),
                new SqlParameter("@TRA003",SqlDbType.Date),
                new SqlParameter("@TRA004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = model . TRA001;
            parameter [ 1 ] . Value = model . TRA002;
            parameter [ 2 ] . Value = model . TRA003;
            parameter [ 3 ] . Value = model . TRA004;

            SQLString . Add ( strSql ,parameter );
        }

        void edit_one ( CarpenterEntity . TransmitEntity model ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXTRA SET " );
            strSql . Append ( "TRA003=@TRA003," );
            strSql . Append ( "TRA004=@TRA004 " );
            strSql . Append ( "WHERE TRA001=@TRA001 AND TRA002=@TRA002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@TRA001",SqlDbType.NVarChar,20),
                new SqlParameter("@TRA002",SqlDbType.NVarChar,50),
                new SqlParameter("@TRA003",SqlDbType.Date),
                new SqlParameter("@TRA004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = model . TRA001;
            parameter [ 1 ] . Value = model . TRA002;
            parameter [ 2 ] . Value = model . TRA003;
            parameter [ 3 ] . Value = model . TRA004;

            SQLString . Add ( strSql ,parameter );
        }

        void delete ( CarpenterEntity . TransmitEntity model ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXTRA " );
            strSql . Append ( "WHERE TRA001=@TRA001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@TRA001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = model . TRA001;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXTRA " );
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

    }
}
