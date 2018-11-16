using System;
using System . Data;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;
using System . Linq;

namespace CarpenterBll . Dao
{
    public class WageCoefDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            Read ( strWhere );
            setWAC ( strWhere );

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,WAC001,WAC002,WAC003,WAC004,WAC005,CONVERT(FLOAT,WAC006) WAC006,CONVERT(FLOAT,WAC007) WAC007,CONVERT(FLOAT,WAC009) WAC009 FROM MOXWAC " );
            strSql . AppendFormat ( "WHERE WAC008='{0}' ORDER BY WAC001,WAC003" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        void setWAC ( string strWhere )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "SELECT PWS033,PWS025,CONVERT(FLOAT,SUM(PWS026*PWS035)) PWS FROM MOXPWS INNER JOIN MOXWAC ON PWS001=WAC004 AND PWS033=WAC001 AND PWS025=WAC003 WHERE CONVERT(VARCHAR,PWS008,112) LIKE '{0}%' GROUP BY PWS033,PWS025" ,strWhere );
            strSql . AppendFormat ( "WITH CET AS (SELECT MOXPWS.idx,PWS033,PWS001,PWS025,PWS026*PWS035 PWS FROM MOXPWS INNER JOIN MOXWAC ON PWS001=WAC004 AND PWS033=WAC001 AND PWS025=WAC003 WHERE CONVERT(VARCHAR,PWS008,112) LIKE '{0}%' AND WAC008='{0}') " ,strWhere );
            strSql . Append ( "SELECT PWS033,PWS025,PWS001,CONVERT(FLOAT,SUM(PWS)) PWS FROM CET GROUP BY PWS033,PWS025,PWS001" );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table != null && table . Rows . Count > 0 )
            {
                CarpenterEntity . WageCoefEntity model = new CarpenterEntity . WageCoefEntity ( );
                model . WAC008 = strWhere;
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    model . WAC001 = table . Rows [ i ] [ "PWS033" ] . ToString ( );
                    model . WAC003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PWS025" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PWS025" ] . ToString ( ) );
                    //model . WAC004 = table . Rows [ i ] [ "PWS001" ] . ToString ( );
                    model . WAC007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PWS" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PWS" ] . ToString ( ) );
                    model . WAC004 = table . Rows [ i ] [ "PWS001" ] . ToString ( );
                    EditWAC ( SQLString ,strSql ,model );
                }
            }

            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS (SELECT MOXPWS.idx,PWS033,PWS025,PWS026*PWS035 PWS FROM MOXPWS INNER JOIN MOXWAC ON PWS001=WAC004 AND PWS033=WAC001 AND PWS025=WAC003 WHERE CONVERT(VARCHAR,PWS008,112) LIKE '{0}%' AND WAC008='{0}') " ,strWhere );
            strSql . Append ( "SELECT PWS033,PWS025,CONVERT(FLOAT,SUM(PWS)) PWS FROM CET GROUP BY PWS033,PWS025" );

            table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table != null && table . Rows . Count > 0 )
            {
                CarpenterEntity . WageCoefEntity model = new CarpenterEntity . WageCoefEntity ( );
                model . WAC008 = strWhere;
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    model . WAC001 = table . Rows [ i ] [ "PWS033" ] . ToString ( );
                    model . WAC003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PWS025" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PWS025" ] . ToString ( ) );
                    model . WAC009 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PWS" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PWS" ] . ToString ( ) );
                    EditWACA ( SQLString ,strSql ,model );
                }
            }

            SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void EditWAC ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . WageCoefEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWAC SET " );
            strSql . AppendFormat ( "WAC007='{0}' " ,model . WAC007 );
            strSql . AppendFormat ( "WHERE WAC001='{0}' AND WAC003='{1}' AND WAC008='{2}' AND WAC004='{3}'" ,model . WAC001 ,model . WAC003 ,model . WAC008 ,model . WAC004 );
            SQLString . Add ( strSql ,null );
        }

        void EditWACA ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . WageCoefEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWAC SET " );
            strSql . AppendFormat ( "WAC009='{0}' " ,model . WAC009 );
            strSql . AppendFormat ( "WHERE WAC001='{0}' AND WAC003='{1}' AND WAC008='{2}'" ,model . WAC001 ,model . WAC003 ,model . WAC008 );
            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Delete ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXWAC WHERE WAC008='{0}'" ,strWhere );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="yearAndMonth"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,string strWhere )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . WageCoefEntity model = new CarpenterEntity . WageCoefEntity ( );

            bool result = false;
            DataTable tableOne = getTableWages ( strWhere );
            if ( tableOne != null && tableOne . Rows . Count > 0 )
                result = true;

            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                model . WAC001 = table . Rows [ i ] [ "WAC001" ] . ToString ( );
                model . WAC003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "WAC003" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "WAC003" ] . ToString ( ) );
                model . WAC004 = table . Rows [ i ] [ "WAC004" ] . ToString ( );
                model . WAC006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "WAC006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "WAC006" ] . ToString ( ) );
                Edit ( SQLString ,strSql ,model );
                if ( result && tableOne . Select ( "PWS033='" + model . WAC001 + "' AND PWS001='" + model . WAC004 + "' AND PWS025='" + model . WAC003 + "'" ) . Length > 0 )
                {
                    EditWages ( SQLString ,strSql ,model );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        void Edit ( Hashtable SQLString ,StringBuilder strSql,CarpenterEntity.WageCoefEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWAC SET " );
            strSql . Append ( "WAC006=@WAC006 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WAC006",SqlDbType.Decimal),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = model . WAC006;
            parameter [ 1 ] . Value = model . idx;
            SQLString . Add ( strSql ,parameter );
        }

        DataTable getTableWages ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PWS033,PWS001,PWS025 FROM MOXPWS WHERE CONVERT(VARCHAR,PWS008,112) LIKE '{0}%' " ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void EditWages ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . WageCoefEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPWS SET " );
            strSql . AppendFormat ( "PWS035='{0}' " ,model . WAC006 );
            strSql . AppendFormat ( "WHERE CONVERT(VARCHAR,PWS008,112) LIKE '{0}%'" ,model . WAC008 );
            strSql . AppendFormat ( " AND PWS033='{0}' AND PWS001='{1}' AND PWS025='{2}'" ,model . WAC001 ,model . WAC004 ,model . WAC003 );

            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Read ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT PRD001,PRD002,PRD004,PRD005,PRD043 FROM MOXPRD WHERE PRD014=0 AND CONVERT(VARCHAR,PRD013,112) LIKE '{0}%'" ,strWhere );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                return false;
            Hashtable SQLString = new Hashtable ( );
            CarpenterEntity . WageCoefEntity model = new CarpenterEntity . WageCoefEntity ( );
            model . WAC008 = strWhere;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                model . WAC001 = table . Rows [ i ] [ "PRD001" ] . ToString ( );
                model . WAC002 = table . Rows [ i ] [ "PRD002" ] . ToString ( );
                model . WAC003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PRD043" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PRD043" ] . ToString ( ) );
                model . WAC004 = table . Rows [ i ] [ "PRD004" ] . ToString ( );
                model . WAC005 = table . Rows [ i ] [ "PRD005" ] . ToString ( );
                model . WAC006 = 1M;
                model . WAC007 = 0;
                if ( model . WAC003 != 0 )
                {
                    if ( Exists ( model ) == false )
                        Add ( SQLString ,strSql ,model );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        bool Exists ( CarpenterEntity.WageCoefEntity model)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXWAC " );
            strSql . Append ( "WHERE WAC001=@WAC001 AND WAC004=@WAC004 AND WAC003=@WAC003 AND WAC008=@WAC008" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WAC001",SqlDbType.NVarChar),
                new SqlParameter("@WAC003",SqlDbType.Int),
                new SqlParameter("@WAC004",SqlDbType.NVarChar),
                new SqlParameter("@WAC008",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = model . WAC001;
            parameter [ 1 ] . Value = model . WAC003;
            parameter [ 2 ] . Value = model . WAC004;
            parameter [ 3 ] . Value = model . WAC008;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        void Add (Hashtable SQLString,StringBuilder strSql,CarpenterEntity.WageCoefEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into MOXWAC(" );
            strSql . Append ( "WAC001,WAC002,WAC003,WAC004,WAC005,WAC006,WAC007,WAC008)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@WAC001,@WAC002,@WAC003,@WAC004,@WAC005,@WAC006,@WAC007,@WAC008)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@WAC001", SqlDbType.NVarChar,50),
                    new SqlParameter("@WAC002", SqlDbType.NVarChar,50),
                    new SqlParameter("@WAC003", SqlDbType.Int,4),
                    new SqlParameter("@WAC004", SqlDbType.NVarChar,20),
                    new SqlParameter("@WAC005", SqlDbType.NVarChar,20),
                    new SqlParameter("@WAC006", SqlDbType.Decimal,9),
                    new SqlParameter("@WAC007", SqlDbType.Decimal,9),
                    new SqlParameter("@WAC008", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . WAC001;
            parameters [ 1 ] . Value = model . WAC002;
            parameters [ 2 ] . Value = model . WAC003;
            parameters [ 3 ] . Value = model . WAC004;
            parameters [ 4 ] . Value = model . WAC005;
            parameters [ 5 ] . Value = model . WAC006;
            parameters [ 6 ] . Value = model . WAC007;
            parameters [ 7 ] . Value = model . WAC008;

            SQLString . Add ( strSql ,parameters );
        }

    }
}
