using System;
using System . Collections;
using System . Data;
using System . Data . SqlClient;
using System . Text;
using StudentMgr;

namespace CarpenterBll . Dao
{
    public class ExportPaintDao
    {
        /// <summary>
        /// save paint base data to database
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool SavePaintBase ( DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            CarpenterEntity . ExoendBasePaintEntity _model = new CarpenterEntity . ExoendBasePaintEntity ( );
            string mc = string . Empty, gx = string . Empty;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                mc = table . Rows [ i ] [ 0 ] . ToString ( );
                if ( mc . Contains ( "油漆用量" ) )
                {
                    _model . EBP001 = mc . Replace ( "油漆用量" ,"" ) . Trim ( );
                }
                
                for ( int l = 0 ; l < table . Columns . Count ; l++ )
                {
                    gx = string . Empty;
                    gx = table . Rows [ i ] [ l ] . ToString ( );
                    if ( gx . Contains ( "油漆名称" ) )
                    {
                        gx = table . Rows [ i ] [ l-1 ] . ToString ( );
                        _model . EBP002 = gx;
                        if ( gx . Contains ( "（" ) && gx . Contains ( "）" ) )
                        {
                            _model . EBP002 = gx . Substring ( 0 ,gx . IndexOf ( "（" ) );
                            _model . EBP003 = gx . Substring ( gx . IndexOf ( "（" ) + 1 ,gx . LastIndexOf ( "）" ) - gx . IndexOf ( "（" ) - 1 );
                        }
                        else
                            _model . EBP003 = string . Empty;

                        for ( int k = 2 ; k < 5 ; k++ )
                        {
                            _model . EBP004 = table . Rows [ i ] [ k ] . ToString ( );
                            _model . EBP005 = string . IsNullOrEmpty ( table . Rows [ i + 2 ] [ k ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i + 2 ] [ k ] . ToString ( ) );
                            if ( !string . IsNullOrEmpty ( _model . EBP004 ) )
                                add_expendBase ( SQLString ,strSql ,_model );
                        }
                    }
                }

            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_expendBase ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExoendBasePaintEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXEBP (" );
            strSql . Append ( "EBP001,EBP002,EBP003,EBP004,EBP005,EBP006 )" );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EBP001,@EBP002,@EBP003,@EBP004,@EBP005,@EBP006 )" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EBP001",SqlDbType.NVarChar,50),
                new SqlParameter("@EBP002",SqlDbType.NVarChar,50),
                new SqlParameter("@EBP003",SqlDbType.NVarChar,50),
                new SqlParameter("@EBP004",SqlDbType.NVarChar,50),
                new SqlParameter("@EBP005",SqlDbType.Decimal,6),
                new SqlParameter("@EBP006",SqlDbType.Int,4)
            };
            parameter [ 0 ] . Value = _model . EBP001;
            parameter [ 1 ] . Value = _model . EBP002;
            parameter [ 2 ] . Value = _model . EBP003;
            parameter [ 3 ] . Value = _model . EBP004;
            parameter [ 4 ] . Value = _model . EBP005;
            parameter [ 5 ] . Value = 1;

            SQLString . Add ( strSql ,parameter );
        }

    }
}
