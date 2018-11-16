using System . Data;
using System . Text;
using StudentMgr;
using System . Collections;
using System;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class ExoendBasePaintDao
    {
        /// <summary>
        /// get data from database to view
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,EBP001,EBP002,EBP003,EBP005,EBP006,CONVERT(FLOAT,EBP007) EBP007 FROM MOXEBP " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get wood data from database 
        /// </summary>
        /// <returns></returns>
        public DataTable getWood ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT EBP001 FROM MOXEBP " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// get work procedure data from database
        /// </summary>
        /// <returns></returns>
        public DataTable getWorkProcedure ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT EBP002 FROM MOXEBP " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get paint name from database
        /// </summary>
        /// <returns></returns>
        public DataTable getPaintName ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT EBP003 FROM MOXEBP" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get paint type from database
        /// </summary>
        /// <returns></returns>
        public DataTable getPaintType ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT EBP004 FROM MOXEBP" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// add data to database
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Add ( DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            CarpenterEntity . ExoendBasePaintEntity _model = new CarpenterEntity . ExoendBasePaintEntity ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . EBP001 = table . Rows [ i ] [ "EBP001" ] . ToString ( );
                _model . EBP002 = table . Rows [ i ] [ "EBP002" ] . ToString ( );
                _model . EBP003 = table . Rows [ i ] [ "EBP003" ] . ToString ( );
                //_model . EBP004 = table . Rows [ i ] [ "EBP004" ] . ToString ( );
                _model . EBP005 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EBP005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EBP005" ] . ToString ( ) );
                _model . EBP006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EBP006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "EBP006" ] . ToString ( ) );
                _model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                _model . EBP007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EBP007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EBP007" ] . ToString ( ) );

                if ( _model . idx < 1 )
                    add_ebp ( SQLString ,strSql ,_model );
                else
                {
                    if ( Exists ( _model . idx ) )
                        edit_ebp ( SQLString ,strSql ,_model );
                    else
                        delete_ebp ( SQLString ,strSql ,_model );
                }
            }

            DataTable dt = getTable ( );
            for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            {
                _model . idx = string . IsNullOrEmpty ( dt . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( table . Select ( "idx='" + _model . idx + "'" ) . Length < 1 )
                    delete_ebp ( SQLString ,strSql ,_model );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_ebp ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExoendBasePaintEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXEBP(" );
            strSql . Append ( "EBP001,EBP002,EBP003,EBP005,EBP006,EBP007)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@EBP001,@EBP002,@EBP003,@EBP005,@EBP006,@EBP007)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@EBP001", SqlDbType.NVarChar,50),
                    new SqlParameter("@EBP002", SqlDbType.NVarChar,50),
                    new SqlParameter("@EBP003", SqlDbType.NVarChar,50),
                    //new SqlParameter("@EBP004", SqlDbType.NVarChar,50),
                    new SqlParameter("@EBP005", SqlDbType.Decimal,9),
                    new SqlParameter("@EBP006", SqlDbType.Int,4),
                    new SqlParameter("@EBP007", SqlDbType.Decimal,18)
            };
            parameters [ 0 ] . Value = model . EBP001;
            parameters [ 1 ] . Value = model . EBP002;
            parameters [ 2 ] . Value = model . EBP003;
            //parameters [ 3 ] . Value = model . EBP004;
            parameters [ 3 ] . Value = model . EBP005;
            parameters [ 4 ] . Value = model . EBP006;
            parameters [ 5 ] . Value = model . EBP007;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_ebp ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExoendBasePaintEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXEBP SET " );
            strSql . Append ( "EBP001=@EBP001," );
            strSql . Append ( "EBP002=@EBP002," );
            strSql . Append ( "EBP003=@EBP003," );
            //strSql . Append ( "EBP004=@EBP004," );
            strSql . Append ( "EBP005=@EBP005," );
            strSql . Append ( "EBP006=@EBP006," );
            strSql . Append ( "EBP007=@EBP007 " );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@EBP001", SqlDbType.NVarChar,50),
                    new SqlParameter("@EBP002", SqlDbType.NVarChar,50),
                    new SqlParameter("@EBP003", SqlDbType.NVarChar,50),
                    //new SqlParameter("@EBP004", SqlDbType.NVarChar,50),
                    new SqlParameter("@EBP005", SqlDbType.Decimal,9),
                    new SqlParameter("@EBP006", SqlDbType.Int,4),
                    new SqlParameter("@idx", SqlDbType.Int,4),
                    new SqlParameter("@EBP007", SqlDbType.Decimal,18)
            };
            parameters [ 0 ] . Value = model . EBP001;
            parameters [ 1 ] . Value = model . EBP002;
            parameters [ 2 ] . Value = model . EBP003;
            //parameters [ 3 ] . Value = model . EBP004;
            parameters [ 3 ] . Value = model . EBP005;
            parameters [ 4 ] . Value = model . EBP006;
            parameters [ 5 ] . Value = model . idx;
            parameters [ 6 ] . Value = model . EBP007;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_ebp ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExoendBasePaintEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXEBP " );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        bool Exists ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXEBP " );
            strSql . AppendFormat ( " WHERE idx={0}" ,idx );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        DataTable getTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx FROM MOXEBP" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// delete data from database
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Delete ( DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            CarpenterEntity . ExoendBasePaintEntity _model = new CarpenterEntity . ExoendBasePaintEntity ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( Exists ( _model . idx ) )
                    delete_ebp ( SQLString ,strSql ,_model );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

    }
}
