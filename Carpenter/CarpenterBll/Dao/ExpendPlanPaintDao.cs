using System . Data;
using System . Text;
using StudentMgr;
using System . Collections;
using System;
using System . Data . SqlClient;
using System . Collections . Generic;

namespace CarpenterBll . Dao
{
    public class ExpendPlanPaintDao
    {
        /// <summary>
        /// get product info from database to lookupedit
        /// </summary>
        /// <returns></returns>
        public DataTable getTableProduct ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PBA005 FROM MOXPBA" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get column data from database
        /// </summary>
        /// <returns></returns>
        public DataTable getTableColumn ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PBA003 FROM MOXPBA" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        /// <summary>
        /// 获取部件
        /// </summary>
        /// <returns></returns>
        public DataTable getTablePart ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT EPP003,EPP005,EPP004 FROM MOXEPP" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from database to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,EPP001,EPP002,EPP003,EPP004,EPP005,CONVERT(FLOAT,EPP006) EPP006,EPP007 FROM MOXEPP " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// add data to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="intList"></param>
        /// <returns></returns>
        public bool Add ( DataTable table ,List<int?> intList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            CarpenterEntity . ExpendPlanPaintEntity _model = new CarpenterEntity . ExpendPlanPaintEntity ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . EPP001 = table . Rows [ i ] [ "EPP001" ] . ToString ( );
                _model . EPP002 = table . Rows [ i ] [ "EPP002" ] . ToString ( );
                _model . EPP003 = table . Rows [ i ] [ "EPP003" ] . ToString ( );
                _model . EPP004 = table . Rows [ i ] [ "EPP004" ] . ToString ( );
                _model . EPP005 = table . Rows [ i ] [ "EPP005" ] . ToString ( );
                _model . EPP006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EPP006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EPP006" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "EPP007" ] . ToString ( ) ) )
                    _model . EPP007 = null;
                else
                    _model . EPP007 = Convert . ToDateTime ( table . Rows [ i ] [ "EPP007" ] . ToString ( ) );
                _model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );

                if ( _model . idx < 1 )
                {
                    if ( Exists ( _model ) == false )
                        add_epp ( SQLString ,strSql ,_model );
                }
                else
                {
                    if ( Exists ( _model . idx ) )
                        edit_epp ( SQLString ,strSql ,_model );
                }
            }

            if ( intList . Count > 0 )
            {
                foreach ( int? i in intList )
                {
                    if ( Exists ( i ) )
                    {
                        _model . idx = i;
                        delete_epp ( SQLString ,strSql ,_model );
                    }
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_epp ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExpendPlanPaintEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXEPP(" );
            strSql . Append ( "EPP001,EPP002,EPP003,EPP004,EPP005,EPP006,EPP007)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@EPP001,@EPP002,@EPP003,@EPP004,@EPP005,@EPP006,@EPP007)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@EPP001", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPP002", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPP003", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPP004", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPP005", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPP006", SqlDbType.Decimal,9),
                    new SqlParameter("@EPP007", SqlDbType.NVarChar,50)
            };
            parameters [ 0 ] . Value = model . EPP001;
            parameters [ 1 ] . Value = model . EPP002;
            parameters [ 2 ] . Value = model . EPP003;
            parameters [ 3 ] . Value = model . EPP004;
            parameters [ 4 ] . Value = model . EPP005;
            parameters [ 5 ] . Value = model . EPP006;
            parameters [ 6 ] . Value = model . EPP007;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_epp ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExpendPlanPaintEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXEPP set " );
            strSql . Append ( "EPP001=@EPP001," );
            strSql . Append ( "EPP002=@EPP002," );
            strSql . Append ( "EPP003=@EPP003," );
            strSql . Append ( "EPP004=@EPP004," );
            strSql . Append ( "EPP005=@EPP005," );
            strSql . Append ( "EPP006=@EPP006," );
            strSql . Append ( "EPP007=@EPP007 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@EPP001", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPP002", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPP003", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPP004", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPP005", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPP006", SqlDbType.Decimal,9),
                    new SqlParameter("@EPP007", SqlDbType.NVarChar,50),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . EPP001;
            parameters [ 1 ] . Value = model . EPP002;
            parameters [ 2 ] . Value = model . EPP003;
            parameters [ 3 ] . Value = model . EPP004;
            parameters [ 4 ] . Value = model . EPP005;
            parameters [ 5 ] . Value = model . EPP006;
            parameters [ 6 ] . Value = model . EPP007;
            parameters [ 7 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_epp ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExpendPlanPaintEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXEPP " );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        bool Exists ( CarpenterEntity . ExpendPlanPaintEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXEPP " );
            strSql . AppendFormat ( "WHERE EPP001='{0}' AND EPP002='{1}' AND EPP003='{2}' AND EPP004='{3}' AND EPP005='{4}' AND EPP007='{5}'" ,model . EPP001 ,model . EPP002 ,model . EPP003 ,model . EPP004 ,model . EPP005 ,model . EPP007 );
            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        bool Exists ( int? idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXEPP " );
            strSql . AppendFormat ( "WHERE idx={0}" ,idx );

            return SqlHelper . Exists ( strSql . ToString ( ) );
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

            CarpenterEntity . ExpendPlanPaintEntity _model = new CarpenterEntity . ExpendPlanPaintEntity ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( Exists ( _model . idx ) )
                    delete_epp ( SQLString ,strSql ,_model );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// get product info from database
        /// </summary>
        /// <returns></returns>
        public DataTable getTableProductInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT OPI001 EPP001,OPI002 EPP002 FROM MOXOPI WHERE OPI011=0 AND OPI008='在产'" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get other info from database
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOther ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT idx,EBP001 EPP003,EBP002 EPP007,EBP003 EPP008,EBP004 EPP009,EBP005 EPP011,EBP006 EPP010 FROM MOXEBP" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
