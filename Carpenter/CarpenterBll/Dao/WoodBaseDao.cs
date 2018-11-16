using System;
using System . Collections . Generic;
using System . Data;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class WoodBaseDao
    {
        /// <summary>
        /// get wood from database 
        /// </summary>
        /// <returns></returns>
        public DataTable getWood ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT OPI003 WOB003 FROM MOXOPI" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get part num from moxcut
        /// </summary>
        /// <returns></returns>
        public DataTable getPartNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CUT001 FROM MOXCUT" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get table from database
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,WOB001,WOB002,WOB003,WOB004,WOB005,WOB006 FROM MOXWOB " );
            strSql . Append ( "WHERE " + strWhere );           

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

            CarpenterEntity . WoodBaseEntity _model = new CarpenterEntity . WoodBaseEntity ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "DELETE FROM MOXWOB WHERE idx={0}" ,_model . idx );
                SQLString . Add ( strSql ,null );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// add or edit data to database
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Add ( DataTable table,List<int> intList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            CarpenterEntity . WoodBaseEntity _model = new CarpenterEntity . WoodBaseEntity ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . WOB001 = table . Rows [ i ] [ "WOB001" ] . ToString ( );
                _model . WOB002 = table . Rows [ i ] [ "WOB002" ] . ToString ( );
                _model . WOB003 = table . Rows [ i ] [ "WOB003" ] . ToString ( );
                _model . WOB004 = table . Rows [ i ] [ "WOB004" ] . ToString ( );
                _model . WOB005 = string . IsNullOrEmpty ( table . Rows [ i ] [ "WOB005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "WOB005" ] . ToString ( ) );
                _model . WOB006 = table . Rows [ i ] [ "WOB006" ] . ToString ( );
                _model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );

                if ( _model . idx < 1 )
                {
                    if ( !Exists ( _model . WOB001 ,_model . WOB003 ) )
                        add_wob ( SQLString ,strSql ,_model );
                }
                else
                {
                    if ( Exists ( _model . idx ) )
                        edit_wob ( SQLString ,strSql ,_model );
                    else
                        delete_wob ( SQLString ,strSql ,_model . idx );
                }
            }

            //DataTable dt = getTable ( );
            //for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            //{
            //    _model . idx = string . IsNullOrEmpty ( dt . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "idx" ] . ToString ( ) );
            //    if ( table . Select ( "idx='" + _model . idx + "'" ) . Length < 1 )
            //        delete_wob ( SQLString ,strSql ,_model . idx );
            //}
            if ( intList . Count > 0 )
            {
                foreach ( int i in intList )
                {
                    _model . idx = i;
                    if ( !Exists ( _model . idx ) )
                        delete_wob ( SQLString ,strSql ,_model . idx );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        bool Exists ( string productNum ,string wood )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXWOB " );
            strSql . AppendFormat ( "WHERE WOB001='{0}' AND WOB003='{1}'" ,productNum ,wood );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void add_wob ( Hashtable SQLString,StringBuilder strSql ,CarpenterEntity . WoodBaseEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXWOB(" );
            strSql . Append ( "WOB001,WOB002,WOB003,WOB004,WOB005,WOB006)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@WOB001,@WOB002,@WOB003,@WOB004,@WOB005,@WOB006)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@WOB001", SqlDbType.NVarChar,50),
                    new SqlParameter("@WOB002", SqlDbType.NVarChar,50),
                    new SqlParameter("@WOB003", SqlDbType.NVarChar,50),
                    new SqlParameter("@WOB004", SqlDbType.NVarChar,50),
                    new SqlParameter("@WOB005", SqlDbType.Decimal,9),
                    new SqlParameter("@WOB006", SqlDbType.NVarChar,100)
            };
            parameters [ 0 ] . Value = model . WOB001;
            parameters [ 1 ] . Value = model . WOB002;
            parameters [ 2 ] . Value = model . WOB003;
            parameters [ 3 ] . Value = model . WOB004;
            parameters [ 4 ] . Value = model . WOB005;
            parameters [ 5 ] . Value = model . WOB006;

            SQLString . Add ( strSql ,parameters );
        }

        bool Exists ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXWOB WHERE idx={0}" ,idx );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void edit_wob ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . WoodBaseEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWOB SET " );
            strSql . Append ( "WOB001=@WOB001," );
            strSql . Append ( "WOB002=@WOB002," );
            strSql . Append ( "WOB003=@WOB003," );
            strSql . Append ( "WOB004=@WOB004," );
            strSql . Append ( "WOB005=@WOB005," );
            strSql . Append ( "WOB006=@WOB006 " );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@WOB001", SqlDbType.NVarChar,50),
                    new SqlParameter("@WOB002", SqlDbType.NVarChar,50),
                    new SqlParameter("@WOB003", SqlDbType.NVarChar,50),
                    new SqlParameter("@WOB004", SqlDbType.NVarChar,50),
                    new SqlParameter("@WOB005", SqlDbType.Decimal,9),
                    new SqlParameter("@WOB006", SqlDbType.NVarChar,100),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . WOB001;
            parameters [ 1 ] . Value = model . WOB002;
            parameters [ 2 ] . Value = model . WOB003;
            parameters [ 3 ] . Value = model . WOB004;
            parameters [ 4 ] . Value = model . WOB005;
            parameters [ 5 ] . Value = model . WOB006;
            parameters [ 6 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_wob ( Hashtable SQLString ,StringBuilder strSql ,int idx )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXWOB " );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = idx;

            SQLString . Add ( strSql ,parameters );
        }

        DataTable getTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx FROM MOXWOB " );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get table from database to product
        /// </summary>
        /// <returns></returns>
        public DataTable getTableProduct ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT OPI001 WOB001,OPI001 WOB,OPI002 WOB002,OPI003 WOB003 FROM MOXOPI WHERE OPI011=0 AND OPI008='在产'" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get table from database to wood type
        /// </summary>
        /// <returns></returns>
        public DataTable getTableType ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT WOB004 FROM MOXWOB " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }



    }
}
