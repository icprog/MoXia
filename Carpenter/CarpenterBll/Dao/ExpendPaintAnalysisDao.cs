using System . Data;
using System . Text;
using StudentMgr;
using System . Collections;
using System;
using System . Data . SqlClient;
using System . Collections . Generic;

namespace CarpenterBll . Dao
{
    public class ExpendPaintAnalysisDao
    {
        /// <summary>
        /// get data from database to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,EPA001,EPA002,CONVERT(FLOAT,EPA003) EPA003,CONVERT(FLOAT,EPA004) EPA004,CONVERT(FLOAT,EPA005) EPA005,CONVERT(FLOAT,EPA006) EPA006,EPA007,CONVERT(FLOAT,EPA008) EPA008,CONVERT(FLOAT,ISNULL(EPA006,0)+ISNULL(EPA005,0)-ISNULL(EPA004,0)-ISNULL(EPA008,0)) U0 FROM MOXEPA " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( "  ORDER BY REVERSE(EPA002)" );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// delete data from database
        /// </summary>
        /// <param name="dateEdit"></param>
        /// <returns></returns>
        public bool Delete ( string dateEdit )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXEPA " );
            strSql . AppendFormat ( "WHERE EPA001='{0}'" ,dateEdit );

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// add data to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="dateEdit"></param>
        /// <param name="intList"></param>
        /// <returns></returns>
        public bool Add ( DataTable table ,string dateEdit ,List<int> intList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            CarpenterEntity . ExpendPaintAnalysisEntity _model = new CarpenterEntity . ExpendPaintAnalysisEntity ( );
            _model . EPA001 = dateEdit;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . EPA002 = table . Rows [ i ] [ "EPA002" ] . ToString ( );
                _model . EPA003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EPA003" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EPA003" ] . ToString ( ) );
                _model . EPA004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EPA004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EPA004" ] . ToString ( ) );
                _model . EPA005 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EPA005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EPA005" ] . ToString ( ) );
                _model . EPA006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EPA006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "EPA006" ] . ToString ( ) );
                _model . EPA007 = table . Rows [ i ] [ "EPA007" ] . ToString ( );
                _model . EPA008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "EPA008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "EPA008" ] . ToString ( ) );
                _model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );

                if ( _model . idx < 1 )
                {
                    if ( !Exists ( _model . EPA002 ,_model . EPA001 ) )
                        add_epa ( SQLString ,strSql ,_model );
                }
                else
                {
                    if ( Exists ( _model . idx ) )
                        edit_epa ( SQLString ,strSql ,_model );
                    else
                        delete_epa ( SQLString ,strSql ,_model );
                }
            }

            if ( intList . Count > 0 )
            {
                foreach ( int i in intList )
                {
                    if ( Exists ( i ) )
                    {
                        _model . idx = i;
                        delete_epa ( SQLString ,strSql ,_model );
                    }
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_epa ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExpendPaintAnalysisEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXEPA(" );
            strSql . Append ( "EPA001,EPA002,EPA003,EPA004,EPA005,EPA006,EPA007,EPA008)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@EPA001,@EPA002,@EPA003,@EPA004,@EPA005,@EPA006,@EPA007,@EPA008)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@EPA001", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPA002", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPA003", SqlDbType.Decimal,9),
                    new SqlParameter("@EPA004", SqlDbType.Decimal,9),
                    new SqlParameter("@EPA005", SqlDbType.Decimal,9),
                    new SqlParameter("@EPA006", SqlDbType.Decimal,9),
                    new SqlParameter("@EPA007", SqlDbType.NVarChar,100),
                    new SqlParameter("@EPA008", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . EPA001;
            parameters [ 1 ] . Value = model . EPA002;
            parameters [ 2 ] . Value = model . EPA003;
            parameters [ 3 ] . Value = model . EPA004;
            parameters [ 4 ] . Value = model . EPA005;
            parameters [ 5 ] . Value = model . EPA006;
            parameters [ 6 ] . Value = model . EPA007;
            parameters [ 7 ] . Value = model . EPA008;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_epa ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExpendPaintAnalysisEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXEPA SET " );
            strSql . Append ( "EPA001=@EPA001," );
            strSql . Append ( "EPA002=@EPA002," );
            strSql . Append ( "EPA003=@EPA003," );
            strSql . Append ( "EPA004=@EPA004," );
            strSql . Append ( "EPA005=@EPA005," );
            strSql . Append ( "EPA006=@EPA006," );
            strSql . Append ( "EPA007=@EPA007," );
            strSql . Append ( "EPA008=@EPA008 " );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@EPA001", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPA002", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPA003", SqlDbType.Decimal,9),
                    new SqlParameter("@EPA004", SqlDbType.Decimal,9),
                    new SqlParameter("@EPA005", SqlDbType.Decimal,9),
                    new SqlParameter("@EPA006", SqlDbType.Decimal,9),
                    new SqlParameter("@EPA007", SqlDbType.NVarChar,100),
                    new SqlParameter("@EPA008", SqlDbType.Int,4),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . EPA001;
            parameters [ 1 ] . Value = model . EPA002;
            parameters [ 2 ] . Value = model . EPA003;
            parameters [ 3 ] . Value = model . EPA004;
            parameters [ 4 ] . Value = model . EPA005;
            parameters [ 5 ] . Value = model . EPA006;
            parameters [ 6 ] . Value = model . EPA007;
            parameters [ 7 ] . Value = model . EPA008;
            parameters [ 8 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_epa ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExpendPaintAnalysisEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXEPA " );
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
            strSql . Append ( "SELECT COUNT(1) FROM MOXEPA " );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// generate the data to database
        /// </summary>
        /// <param name="yearAndMonth"></param>
        /// <returns></returns>
        public bool Generate ( string yearAndMonth )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            CarpenterEntity . ExpendPaintAnalysisEntity _model = new CarpenterEntity . ExpendPaintAnalysisEntity ( );
            _model . EPA001 = yearAndMonth;
            DataTable dt = getGenerate ( yearAndMonth );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _model . EPA002 = dt . Rows [ i ] [ "WXP002" ] . ToString ( );
                    _model . EPA008 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "WXP005" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "WXP005" ] . ToString ( ) );
                    _model . EPA003 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "WXP006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "WXP006" ] . ToString ( ) );

                    if ( Exists ( _model . EPA002 ,_model . EPA001 ) )
                        edit_sj ( SQLString ,strSql ,_model );
                    else
                        add_sj ( SQLString ,strSql ,_model );
                }
            }

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                dt = getGenerateS ( yearAndMonth );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                    {
                        _model . EPA002 = dt . Rows [ i ] [ "EPP005" ] . ToString ( );
                        _model . EPA006 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PWF" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "PWF" ] . ToString ( ) );

                        if ( Exists ( _model . EPA002 ,_model . EPA001 ) )
                            edit_l ( SQLString ,strSql ,_model );
                        else
                            add_l ( SQLString ,strSql ,_model );
                    }
                }
            }

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                dt = getGenerateES ( yearAndMonth );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                    {
                        _model . EPA002 = dt . Rows [ i ] [ "EPA002" ] . ToString ( );
                        _model . EPA004 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "EPA005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "EPA005" ] . ToString ( ) );
                        if ( Exists ( _model . EPA002 ,_model . EPA001 ) )
                            edit_qc ( SQLString ,strSql ,_model );
                    }
                }
            }


            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        DataTable getGenerate ( string yearAndMonth )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT WXP002,WXP005,WXP006 FROM MOXWXP WHERE WXP001='{0}'" ,yearAndMonth );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        DataTable getGenerateS ( string yearAndMonth )
        {
            string year = yearAndMonth . Substring ( 0 ,4 );
            string month = yearAndMonth . Substring ( 4 ,2 );
            
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT PBA001,SUM(PBA004*EPP006) PBA004,PBA005,EPP004,EPP005,EPP007 FROM MOXPBA A INNER JOIN MOXEPP B ON A.PBA005=B.EPP001 AND A.PBA003=B.EPP002 GROUP BY PBA001,PBA005,EPP004,EPP005,EPP007) " );
            strSql . Append ( ",CFT AS(" );
            strSql . Append ( "SELECT PWF003,SUM(ISNULL(PWF007,0)+ISNULL(PWF009,0)+ISNULL(PWF010,0)) PWF,PWF012,PWD002 FROM MOXPWF A INNER JOIN MOXPWE B ON A.PWF002=B.PWE003 AND A.PWF003=B.PWE004 AND A.PWF017=B.PWE001 INNER JOIN MOXPWD C ON C.PWD001=B.PWE001 " );
            strSql . AppendFormat ( "WHERE YEAR(PWF012)={0} AND MONTH(PWF012)={1} AND PWD002 IN ('面漆','底漆','修色') GROUP BY PWF003,PWF012,PWD002) " ,year ,month );
            strSql . Append ( ",CHT AS (SELECT A.EPP005,SUM(A.PBA004*B.PWF) PWF FROM CET A INNER JOIN CFT B ON A.PBA001=B.PWF003 AND A.EPP004=B.PWD002 GROUP BY A.EPP005,B.PWF012 HAVING B.PWF012>=MAX(A.EPP007)) " );
            strSql . Append ( "SELECT EPP005,SUM(PWF) PWF FROM CHT GROUP BY EPP005" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        DataTable getGenerateES ( string yearAndMonth )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT EPA002,EPA005 FROM MOXEPA WHERE EPA001=(SELECT MAX(EPA001) FROM MOXEPA WHERE EPA001<'{0}')" ,yearAndMonth );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        bool Exists ( string paintName,string yearAndMonth )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXEPA " );
            strSql . AppendFormat ( "WHERE EPA001='{0}' AND EPA002='{1}' " ,yearAndMonth ,paintName );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void edit_sj ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExpendPaintAnalysisEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXEPA SET " );
            strSql . Append ( "EPA008=@EPA008," );
            strSql . Append ( "EPA003=@EPA003 " );
            strSql . Append ( "WHERE EPA001=@EPA001 AND EPA002=@EPA002" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@EPA001", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPA002", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPA008", SqlDbType.Decimal,9),
                    new SqlParameter("@EPA003", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . EPA001;
            parameters [ 1 ] . Value = model . EPA002;
            parameters [ 2 ] . Value = model . EPA008;
            parameters [ 3 ] . Value = model . EPA003;

            SQLString . Add ( strSql ,parameters );
        }
        void add_sj ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExpendPaintAnalysisEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append( "INSERT INTO MOXEPA (" );
            strSql . Append ( "EPA001,EPA002,EPA008,EPA003) " );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@EPA001,@EPA002,@EPA008,@EPA003) " );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@EPA001", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPA002", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPA008", SqlDbType.Decimal,9),
                    new SqlParameter("@EPA003", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . EPA001;
            parameters [ 1 ] . Value = model . EPA002;
            parameters [ 2 ] . Value = model . EPA008;
            parameters [ 3 ] . Value = model . EPA003;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_l ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExpendPaintAnalysisEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXEPA SET " );
            strSql . Append ( "EPA006=@EPA006 " );
            strSql . Append ( "WHERE EPA001=@EPA001 AND EPA002=@EPA002" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@EPA001", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPA002", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPA006", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . EPA001;
            parameters [ 1 ] . Value = model . EPA002;
            parameters [ 2 ] . Value = model . EPA006;

            SQLString . Add ( strSql ,parameters );
        }
        void add_l ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExpendPaintAnalysisEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXEPA (" );
            strSql . Append ( "EPA001,EPA002,EPA006) " );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@EPA001,@EPA002,@EPA006) " );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@EPA001", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPA002", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPA006", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . EPA001;
            parameters [ 1 ] . Value = model . EPA002;
            parameters [ 2 ] . Value = model . EPA006;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_qc ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ExpendPaintAnalysisEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXEPA SET " );
            strSql . Append ( "EPA004=@EPA004 " );
            strSql . Append ( "WHERE EPA001=@EPA001 AND EPA002=@EPA002" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@EPA001", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPA002", SqlDbType.NVarChar,50),
                    new SqlParameter("@EPA004", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . EPA001;
            parameters [ 1 ] . Value = model . EPA002;
            parameters [ 2 ] . Value = model . EPA004;

            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// 获取不在本月的油漆名称的数据
        /// </summary>
        /// <param name="yearAndMonth"></param>
        /// <returns></returns>
        public DataTable proList ( string yearAndMonth )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT PWF003,PWF004 FROM MOXPWF WHERE  SUBSTRING(CONVERT(NVARCHAR(20),PWF012,112),0,7)={0} AND (SELECT COUNT(1) FROM MOXPBA WHERE PBA001=PWF003)=0" ,yearAndMonth );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get print data from database
        /// </summary>
        /// <param name="yearAndMonth"></param>
        /// <returns></returns>
        public DataTable getPrintTable ( string yearAndMonth)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT EPA001,EPA002,CONVERT(FLOAT,EPA003) EPA003,CONVERT(FLOAT,EPA004) EPA004,CONVERT(FLOAT,EPA005) EPA005,CONVERT(FLOAT,EPA006) EPA006,EPA007,CONVERT(FLOAT,EPA008) EPA008,CONVERT(FLOAT,ISNULL(EPA006,0)+ISNULL(EPA005,0)-ISNULL(EPA004,0)-ISNULL(EPA008,0)) U0,CONVERT(FLOAT,ISNULL(EPA004,0)+ISNULL(EPA008,0)-ISNULL(EPA005,0)) U2,CONVERT(FLOAT,(ISNULL(EPA006,0)+ISNULL(EPA005,0)-ISNULL(EPA004,0)-ISNULL(EPA008,0))*EPA003) U1 FROM MOXEPA " );
            strSql . AppendFormat ( "WHERE EPA001='{0}'" ,yearAndMonth );
            strSql . Append ( "  ORDER BY REVERSE(EPA002) " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable getPrintTableTwo ( string year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS(SELECT SUBSTRING(EPA001,0,5)+'年各月油漆耗用小计汇总' YEA,CONVERT(INT,SUBSTRING(EPA001,5,3)) MONT,SUM(CONVERT(FLOAT,(ISNULL(EPA006,0)+ISNULL(EPA005,0)-ISNULL(EPA004,0)-ISNULL(EPA008,0))*EPA003)) U1 FROM MOXEPA WHERE EPA001 LIKE '{0}%' GROUP BY EPA001) SELECT YEA,SUM(CASE WHEN MONT=1 THEN ISNULL(CONVERT(DECIMAL(18,1),U1),0) ELSE 0 END) ONE,SUM(CASE WHEN MONT=2 THEN ISNULL(CONVERT(DECIMAL(18,1),U1),0) ELSE 0 END) TWO,SUM(CASE WHEN MONT=3 THEN ISNULL(CONVERT(DECIMAL(18,1),U1),0) ELSE 0 END) THREE,SUM(CASE WHEN MONT=4 THEN ISNULL(CONVERT(DECIMAL(18,1),U1),0) ELSE 0 END) FORE,SUM(CASE WHEN MONT=5 THEN ISNULL(CONVERT(DECIMAL(18,1),U1),0) ELSE 0 END) FIV,SUM(CASE WHEN MONT=6 THEN ISNULL(CONVERT(DECIMAL(18,1),U1),0) ELSE 0 END) SIX,SUM(CASE WHEN MONT=7 THEN ISNULL(CONVERT(DECIMAL(18,1),U1),0) ELSE 0 END) SEVEN,SUM(CASE WHEN MONT=8 THEN ISNULL(CONVERT(DECIMAL(18,1),U1),0) ELSE 0 END) EIGTH,SUM(CASE WHEN MONT=9 THEN ISNULL(CONVERT(DECIMAL(18,1),U1),0) ELSE 0 END) NINE,SUM(CASE WHEN MONT=10 THEN ISNULL(CONVERT(DECIMAL(18,1),U1),0) ELSE 0 END) TEN,SUM(CASE WHEN MONT=11 THEN ISNULL(CONVERT(DECIMAL(18,1),U1),0) ELSE 0 END) ELE,SUM(CASE WHEN MONT=12 THEN ISNULL(CONVERT(DECIMAL(18,1),U1),0) ELSE 0 END) TWE FROM CET GROUP BY YEA" ,year );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
