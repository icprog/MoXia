using StudentMgr;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Linq;
using System . Text;

namespace CarpenterBll . Dao
{
    public class ExpendWoodDao
    {
        /// <summary>
        /// get oddNum from database 
        /// </summary>
        /// <returns></returns>
        public DataTable getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT EXW001 FROM MOXEXW " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// read data from the database to view as required
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,EXW001,EXW002,EXW003,EXW004,EXW005,EXW006,EXW007,EXW008 FROM MOXEXW " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// delete data from database
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXEXW " );
            strSql . AppendFormat ( "WHERE EXW001='{0}'" ,oddNum );

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// is there a singular number
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists_Odd ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXEXW " );
            strSql . AppendFormat ( "WHERE EXW001='{0}'" ,oddNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// add data to database 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Add (DataTable table,string oddNum )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . ExpendWoodEntity _model = new CarpenterEntity . ExpendWoodEntity ( );
            _model . EXW001 = oddNum;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {          
                _model . EXW002 = table . Rows [ i ] [ "EXW002" ] . ToString ( );
                _model . EXW003 = table . Rows [ i ] [ "EXW003" ] . ToString ( );
                _model . EXW004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EXW004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EXW004" ] . ToString ( ) );
                _model . EXW005 = table . Rows [ i ] [ "EXW005" ] . ToString ( );
                _model . EXW006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EXW006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EXW006" ] . ToString ( ) );
                _model . EXW007 = table . Rows [ i ] [ "EXW007" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "EXW008" ] . ToString ( ) ) )
                    _model . EXW008 = null;
                else
                    _model . EXW008 = Convert . ToDateTime ( table . Rows [ i ] [ "EXW008" ] . ToString ( ) );
                add_exw ( SQLString ,strSql ,_model );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_exw ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExpendWoodEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXEXW ( " );
            strSql . Append ( "EXW001,EXW002,EXW003,EXW004,EXW005,EXW006,EXW007,EXW008)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@EXW001,@EXW002,@EXW003,@EXW004,@EXW005,@EXW006,@EXW007,@EXW008)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@EXW001", SqlDbType.NVarChar,50),
                    new SqlParameter("@EXW002", SqlDbType.NVarChar,50),
                    new SqlParameter("@EXW003", SqlDbType.NVarChar,50),
                    new SqlParameter("@EXW004", SqlDbType.Decimal,9),
                    new SqlParameter("@EXW005", SqlDbType.NVarChar,50),
                    new SqlParameter("@EXW006", SqlDbType.Decimal,9),
                    new SqlParameter("@EXW007", SqlDbType.NVarChar,100),
                    new SqlParameter("@EXW008", SqlDbType.Date,3)};
            parameters [ 0 ] . Value = model . EXW001;
            parameters [ 1 ] . Value = model . EXW002;
            parameters [ 2 ] . Value = model . EXW003;
            parameters [ 3 ] . Value = model . EXW004;
            parameters [ 4 ] . Value = model . EXW005;
            parameters [ 5 ] . Value = model . EXW006;
            parameters [ 6 ] . Value = model . EXW007;
            parameters [ 7 ] . Value = model . EXW008;

            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// change database data
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table,string oddNum )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            
            CarpenterEntity . ExpendWoodEntity _model = new CarpenterEntity . ExpendWoodEntity ( );
            _model . EXW001 = oddNum;
            DataTable dt = getDataTable ( _model . EXW001 );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . EXW002 = table . Rows [ i ] [ "EXW002" ] . ToString ( );
                _model . EXW003 = table . Rows [ i ] [ "EXW003" ] . ToString ( );
                _model . EXW004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EXW004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EXW004" ] . ToString ( ) );
                _model . EXW005 = table . Rows [ i ] [ "EXW005" ] . ToString ( );
                _model . EXW006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EXW006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EXW006" ] . ToString ( ) );
                _model . EXW007 = table . Rows [ i ] [ "EXW007" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "EXW008" ] . ToString ( ) ) )
                    _model . EXW008 = null;
                else
                    _model . EXW008 = Convert . ToDateTime ( table . Rows [ i ] [ "EXW008" ] . ToString ( ) );
                _model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );

                if ( _model . idx < 1 )
                    add_exw ( SQLString ,strSql ,_model );
                else
                    edit_exw ( SQLString ,strSql ,_model );
            }

            for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            {
                _model . idx = string . IsNullOrEmpty ( dt . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( table . Select ( "idx='" + _model . idx + "'" ) . Length < 1 )
                    delete_exw ( SQLString ,strSql ,_model );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        DataTable getDataTable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx FROM MOXEXW " );
            strSql . AppendFormat ( "WHERE EXW001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void edit_exw ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExpendWoodEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXEXW SET " );
            strSql . Append ( "EXW001=@EXW001," );
            strSql . Append ( "EXW002=@EXW002," );
            strSql . Append ( "EXW003=@EXW003," );
            strSql . Append ( "EXW004=@EXW004," );
            strSql . Append ( "EXW005=@EXW005," );
            strSql . Append ( "EXW006=@EXW006," );
            strSql . Append ( "EXW007=@EXW007," );
            strSql . Append ( "EXW008=@EXW008 " );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@EXW001", SqlDbType.NVarChar,50),
                    new SqlParameter("@EXW002", SqlDbType.NVarChar,50),
                    new SqlParameter("@EXW003", SqlDbType.NVarChar,50),
                    new SqlParameter("@EXW004", SqlDbType.Decimal,9),
                    new SqlParameter("@EXW005", SqlDbType.NVarChar,50),
                    new SqlParameter("@EXW006", SqlDbType.Decimal,9),
                    new SqlParameter("@EXW007", SqlDbType.NVarChar,100),
                    new SqlParameter("@EXW008", SqlDbType.Date,3),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . EXW001;
            parameters [ 1 ] . Value = model . EXW002;
            parameters [ 2 ] . Value = model . EXW003;
            parameters [ 3 ] . Value = model . EXW004;
            parameters [ 4 ] . Value = model . EXW005;
            parameters [ 5 ] . Value = model . EXW006;
            parameters [ 6 ] . Value = model . EXW007;
            parameters [ 7 ] . Value = model . EXW008;
            parameters [ 8 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_exw ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExpendWoodEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXEXW " );
            strSql . AppendFormat ( "WHERE idx={0}" ,model . idx );

            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// get wood grade from database 
        /// </summary>
        /// <returns></returns>
        public DataTable getCmbGrade ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT EXW005 FROM MOXEXW " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get wood type from database 
        /// </summary>
        /// <returns></returns>
        public DataTable getCmbType ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT DISTINCT EXW003 FROM MOXEXW " );
            strSql . Append ( "SELECT DISTINCT OPI003 EXW003 FROM MOXOPI" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
