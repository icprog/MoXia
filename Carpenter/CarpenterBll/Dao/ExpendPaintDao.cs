using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class ExpendPaintDao
    {
        /// <summary>
        /// get data from database to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,WXP001,WXP002,WXP003,WXP004,WXP005,CONVERT(FLOAT,WXP006) WXP006 FROM MOXWXP " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// add data to database from view 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Add (DataTable table,string oddNum ,List<string> idxList )
        {
            StringBuilder strSql = new StringBuilder ( );
            Hashtable SQLString = new Hashtable ( );

            CarpenterEntity . ExpendPaintEntity _model = new CarpenterEntity . ExpendPaintEntity ( );
            _model . WXP001 = oddNum;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . WXP002 = table . Rows [ i ] [ "WXP002" ] . ToString ( );
                _model . WXP003 = table . Rows [ i ] [ "WXP003" ] . ToString ( );
                _model . WXP004 = table . Rows [ i ] [ "WXP004" ] . ToString ( );
                _model . WXP005 = string . IsNullOrEmpty ( table . Rows [ i ] [ "WXP005" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "WXP005" ] . ToString ( ) );
                _model . WXP006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "WXP006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "WXP006" ] . ToString ( ) );
                _model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );

                if ( _model . idx < 1 )
                    add_wxp ( strSql ,SQLString ,_model );
                else
                {
                    if ( Exists ( _model . idx ) )
                        edit_wxp ( strSql ,SQLString ,_model );
                    else
                        delete_wxp ( strSql ,SQLString ,_model . idx );
                }
            }

            foreach ( string s in idxList )
            {
                _model . idx = string . IsNullOrEmpty ( s ) == true ? 0 : Convert . ToInt32 ( s );
                delete_wxp ( strSql ,SQLString ,_model . idx );
            }
            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_wxp ( StringBuilder strSql ,Hashtable SQLString ,CarpenterEntity . ExpendPaintEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXWXP(" );
            strSql . Append ( "WXP001,WXP002,WXP003,WXP004,WXP005,WXP006)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@WXP001,@WXP002,@WXP003,@WXP004,@WXP005,@WXP006)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@WXP001", SqlDbType.NVarChar,50),
                    new SqlParameter("@WXP002", SqlDbType.NVarChar,50),
                    new SqlParameter("@WXP003", SqlDbType.NVarChar,50),
                    new SqlParameter("@WXP004", SqlDbType.NVarChar,50),
                    new SqlParameter("@WXP005", SqlDbType.Int,4),
                    new SqlParameter("@WXP006", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . WXP001;
            parameters [ 1 ] . Value = model . WXP002;
            parameters [ 2 ] . Value = model . WXP003;
            parameters [ 3 ] . Value = model . WXP004;
            parameters [ 4 ] . Value = model . WXP005;
            parameters [ 5 ] . Value = model . WXP006;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_wxp ( StringBuilder strSql ,Hashtable SQLString ,CarpenterEntity . ExpendPaintEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWXP SET " );
            strSql . Append ( "WXP001=@WXP001," );
            strSql . Append ( "WXP002=@WXP002," );
            strSql . Append ( "WXP003=@WXP003," );
            strSql . Append ( "WXP004=@WXP004," );
            strSql . Append ( "WXP005=@WXP005," );
            strSql . Append ( "WXP006=@WXP006 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@WXP001", SqlDbType.NVarChar,50),
                    new SqlParameter("@WXP002", SqlDbType.NVarChar,50),
                    new SqlParameter("@WXP003", SqlDbType.NVarChar,50),
                    new SqlParameter("@WXP004", SqlDbType.NVarChar,50),
                    new SqlParameter("@WXP005", SqlDbType.Int,4),
                    new SqlParameter("@WXP006", SqlDbType.Decimal,9),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . WXP001;
            parameters [ 1 ] . Value = model . WXP002;
            parameters [ 2 ] . Value = model . WXP003;
            parameters [ 3 ] . Value = model . WXP004;
            parameters [ 4 ] . Value = model . WXP005;
            parameters [ 5 ] . Value = model . WXP006;
            parameters [ 6 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_wxp ( StringBuilder strSql ,Hashtable SQLString ,int idx )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXWXP " );
            strSql . AppendFormat ( "WHERE idx={0}" ,idx );

            SQLString . Add ( strSql ,null );
        }

        bool Exists ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXWXP " );
            strSql . AppendFormat ( "WHERE idx={0}" ,idx );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        DataTable getTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx FROM MOXWXP" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// does it exists of oddNum
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXWXP " );
            strSql . AppendFormat ( "WHERE WXP001='{0}'" ,oddNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// delete data from database
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXWXP " );
            strSql . AppendFormat ( "WHERE WXP001='{0}'" ,oddNum );

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// get oddNum from database
        /// </summary>
        /// <returns></returns>
        public DataTable getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT WXP001 FROM MOXWXP ORDER BY WXP001 DESC " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get paint name from database
        /// </summary>
        /// <returns></returns>
        public DataTable getPaintName ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT EPP005 FROM MOXEPP " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否已经存在此日期
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool ExistsDate ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXWXP WHERE WXP001='{0}'" ,code );
            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from database to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT 0 idx,'' WXP001,WXP002,WXP003,WXP004,0 WXP005,CONVERT(FLOAT,WXP006) WXP006 FROM MOXWXP " );
            strSql . Append ( "WHERE WXP001=(SELECT MAX(WXP001) FROM MOXWXP)" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
