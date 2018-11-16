using System . Data;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Linq;
using System . Data . SqlClient;
using System;

namespace CarpenterBll . Dao
{
    public class PayrollReportDao
    {
        /// <summary>
        /// get data from database to view 
        /// </summary>
        /// <param name="yearAndMonth"></param>
        /// <returns></returns>
        public DataTable getTableQuery ( string yearAndMonth )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS( " );
            strSql . AppendFormat ( "SELECT PAY001,PAY002,CONVERT(FLOAT,PAY004) PAY004,CONVERT(FLOAT,PAY005) PAY005,CONVERT(FLOAT,PAY006) PAY006,CONVERT(FLOAT,PAY007) PAY007,CONVERT(FLOAT,PAY008) PAY008,CONVERT(FLOAT,PAY009) PAY009,CONVERT(FLOAT,PAY010) PAY010,CONVERT(FLOAT,PAY011) PAY011,CONVERT(FLOAT,PAY012) PAY012,CONVERT(FLOAT,PAY013) PAY013,CONVERT(FLOAT,PAY014) PAY014,CONVERT(FLOAT,PAY015) PAY015,CONVERT(FLOAT,PAY016) PAY016,CONVERT(FLOAT,PAY017) PAY017,CONVERT(FLOAT,PAY018) PAY018,CONVERT(FLOAT,PAY019) PAY019,CONVERT(FLOAT,PAY020) PAY020,CONVERT(FLOAT,PAY021) PAY021,CONVERT(FLOAT,PAY022) PAY022,CONVERT(FLOAT,PAY023) PAY023,CONVERT(FLOAT,PAY024) PAY024,CONVERT(FLOAT,PAY025) PAY025,CONVERT(FLOAT,PAY026) PAY026,CONVERT(FLOAT,PAY027) PAY027,CONVERT(FLOAT,PAY028) PAY028,CONVERT(FLOAT,PAY029) PAY029,CONVERT(FLOAT,PAY030) PAY030,CONVERT(FLOAT,PAY031) PAY031,CONVERT(FLOAT,PAY032) PAY032,CONVERT(FLOAT,PAY033) PAY033,CONVERT(FLOAT,PAY034) PAY034 FROM MOXPAY WHERE PAY003='{0}') " ,yearAndMonth );
            strSql . Append ( " SELECT *,CONVERT(FLOAT,ISNULL(PAY004,0)+ISNULL(PAY005,0)+ISNULL(PAY006,0)+ISNULL(PAY007,0)+ISNULL(PAY008,0)+ISNULL(PAY009,0)+ISNULL(PAY010,0)+ISNULL(PAY011,0)+ISNULL(PAY012,0)+ISNULL(PAY013,0)+ISNULL(PAY014,0)+ISNULL(PAY015,0)+ISNULL(PAY016,0)+ISNULL(PAY017,0)+ISNULL(PAY018,0)+ISNULL(PAY019,0)+ISNULL(PAY020,0)+ISNULL(PAY021,0)+ISNULL(PAY022,0)+ISNULL(PAY023,0)+ISNULL(PAY024,0)+ISNULL(PAY025,0)+ISNULL(PAY026,0)+ISNULL(PAY027,0)+ISNULL(PAY028,0)+ISNULL(PAY029,0)+ISNULL(PAY030,0)+ISNULL(PAY031,0)+ISNULL(PAY032,0)+ISNULL(PAY033,0)+ISNULL(PAY034,0)) U0 FROM CET " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 生成工资
        /// </summary>
        /// <param name="yearAndMonth"></param>
        /// <returns>-1 没有工资  1成功  2失败</returns>
        public int Read ( string yearAndMonth )
        {
            decimal? res = 0M; 
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PWS001,PWS002,DAY(PWS008) PD,CONVERT(FLOAT,SUM(PWS035*PWS026)) U0 FROM MOXPWS " );
            strSql . AppendFormat ( "WHERE SUBSTRING(CONVERT(VARCHAR,PWS008,112),0,7)='{0}'" ,yearAndMonth );
            strSql . Append ( "GROUP BY PWS001,PWS002,DAY(PWS008) ORDER BY PWS001,DAY(PWS008)" );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                //工资表中没有数据
                return -1;
            CarpenterEntity . PayrollReportEntity model = new CarpenterEntity . PayrollReportEntity ( );
            var query = from p in table . AsEnumerable ( )
                        group p by new
                        {
                            t1 = p . Field<string> ( "PWS001" ) ,
                            t2 = p . Field<string> ( "PWS002" )
                        } into m
                        select new
                        {
                            pws001 = m . Key . t1 ,
                            pws002 = m . Key . t2
                        };
            
            foreach ( var user in query )
            {
                model . PAY001 = user . pws001;
                model . PAY002 = user . pws002;
                //var result = table . AsEnumerable ( )
                //            . Where ( p => p . Field<string> ( "PWS001" ) . Equals ( model . PAY001 ) )
                //            . Select ( p => new
                //            {
                //                pd = p . Field<int> ( "PD" ) ,
                //                pu = p . Field<decimal> ( "U0" )
                //            } );
                DataRow [ ] rows = table . Select ( "PWS001='" + model . PAY001 + "'" );

                model . PAY004 = model . PAY005 = model . PAY006 = model . PAY007 = model . PAY008 = model . PAY009 = model . PAY010 = model . PAY011 = model . PAY012 = model . PAY013 = model . PAY014 = model . PAY015 = model . PAY016 = model . PAY017 = model . PAY018 = model . PAY019 = model . PAY020 = model . PAY021 = model . PAY022 = model . PAY023 = model . PAY024 = model . PAY025 = model . PAY026 = model . PAY027 = model . PAY028 = model . PAY029 = model . PAY030 = model . PAY031 = model . PAY032 = model . PAY033 = model . PAY034 = null;
                model . PAY003 = yearAndMonth;

                foreach ( DataRow row in rows )
                {
                    if ( string . IsNullOrEmpty ( row [ "U0" ] . ToString ( ) ) )
                        res = null;
                    else
                        res = Convert . ToDecimal ( row [ "U0" ] . ToString ( ) );

                    if ( res == 0 )
                        res = null;

                    if ( row [ "PD" ] . Equals ( 1 ) )
                        model . PAY004 = res;
                    else if ( row [ "PD" ] . Equals ( 2 ) )
                        model . PAY005 = res;
                    else if ( row [ "PD" ] . Equals ( 3 ) )
                        model . PAY006 = res;
                    else if ( row [ "PD" ] . Equals ( 4 ) )
                        model . PAY007 = res;
                    else if ( row [ "PD" ] . Equals ( 5 ) )
                        model . PAY008 = res;
                    else if ( row [ "PD" ] . Equals ( 6 ) )
                        model . PAY009 = res;
                    else if ( row [ "PD" ] . Equals ( 7 ) )
                        model . PAY010 = res;
                    else if ( row [ "PD" ] . Equals ( 8 ) )
                        model . PAY011 = res;
                    else if ( row [ "PD" ] . Equals ( 9 ) )
                        model . PAY012 = res;
                    else if ( row [ "PD" ] . Equals ( 10 ) )
                        model . PAY013 = res;
                    else if ( row [ "PD" ] . Equals ( 11 ) )
                        model . PAY014 = res;
                    else if ( row [ "PD" ] . Equals ( 12 ) )
                        model . PAY015 = res;
                    else if ( row [ "PD" ] . Equals ( 13 ) )
                        model . PAY016 = res;
                    else if ( row [ "PD" ] . Equals ( 14 ) )
                        model . PAY017 = res;
                    else if ( row [ "PD" ] . Equals ( 15 ) )
                        model . PAY018 = res;
                    else if ( row [ "PD" ] . Equals ( 16 ) )
                        model . PAY019 = res;
                    else if ( row [ "PD" ] . Equals ( 17 ) )
                        model . PAY020 = res;
                    else if ( row [ "PD" ] . Equals ( 18 ) )
                        model . PAY021 = res;
                    else if ( row [ "PD" ] . Equals ( 19 ) )
                        model . PAY022 = res;
                    else if ( row [ "PD" ] . Equals ( 20 ) )
                        model . PAY023 = res;
                    else if ( row [ "PD" ] . Equals ( 21 ) )
                        model . PAY024 = res;
                    else if ( row [ "PD" ] . Equals ( 22 ) )
                        model . PAY025 = res;
                    else if ( row [ "PD" ] . Equals ( 23 ) )
                        model . PAY026 = res;
                    else if ( row [ "PD" ] . Equals ( 24 ) )
                        model . PAY027 = res;
                    else if ( row [ "PD" ] . Equals ( 25 ) )
                        model . PAY028 = res;
                    else if ( row [ "PD" ] . Equals ( 26 ) )
                        model . PAY029 = res;
                    else if ( row [ "PD" ] . Equals ( 27 ) )
                        model . PAY030 = res;
                    else if ( row [ "PD" ] . Equals ( 28 ) )
                        model . PAY031 = res;
                    else if ( row [ "PD" ] . Equals ( 29 ) )
                        model . PAY032 = res;
                    else if ( row [ "PD" ] . Equals ( 30 ) )
                        model . PAY033 = res;
                    else if ( row [ "PD" ] . Equals ( 31 ) )
                        model . PAY034 = res;
                }
                if ( Exists ( model ) )
                    Edit ( SQLString ,strSql ,model );
                else
                    Add ( SQLString ,strSql ,model );
            }


            bool resul= SqlHelper . ExecuteSqlTran ( SQLString );
            return resul == true ? 1 : 2;
        }

        bool Exists (CarpenterEntity.PayrollReportEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPAY WHERE PAY001='{0}' AND PAY003='{1}'" ,model . PAY001 ,model . PAY003 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void Edit ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PayrollReportEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXPAY set " );            
            strSql . Append ( "PAY002=@PAY002," );
            strSql . Append ( "PAY004=@PAY004," );
            strSql . Append ( "PAY005=@PAY005," );
            strSql . Append ( "PAY006=@PAY006," );
            strSql . Append ( "PAY007=@PAY007," );
            strSql . Append ( "PAY008=@PAY008," );
            strSql . Append ( "PAY009=@PAY009," );
            strSql . Append ( "PAY010=@PAY010," );
            strSql . Append ( "PAY011=@PAY011," );
            strSql . Append ( "PAY012=@PAY012," );
            strSql . Append ( "PAY013=@PAY013," );
            strSql . Append ( "PAY014=@PAY014," );
            strSql . Append ( "PAY015=@PAY015," );
            strSql . Append ( "PAY016=@PAY016," );
            strSql . Append ( "PAY017=@PAY017," );
            strSql . Append ( "PAY018=@PAY018," );
            strSql . Append ( "PAY019=@PAY019," );
            strSql . Append ( "PAY020=@PAY020," );
            strSql . Append ( "PAY021=@PAY021," );
            strSql . Append ( "PAY022=@PAY022," );
            strSql . Append ( "PAY023=@PAY023," );
            strSql . Append ( "PAY024=@PAY024," );
            strSql . Append ( "PAY025=@PAY025," );
            strSql . Append ( "PAY026=@PAY026," );
            strSql . Append ( "PAY027=@PAY027," );
            strSql . Append ( "PAY028=@PAY028," );
            strSql . Append ( "PAY029=@PAY029," );
            strSql . Append ( "PAY030=@PAY030," );
            strSql . Append ( "PAY031=@PAY031," );
            strSql . Append ( "PAY032=@PAY032," );
            strSql . Append ( "PAY033=@PAY033," );
            strSql . Append ( "PAY034=@PAY034 " );
            strSql . Append ( "WHERE PAY001=@PAY001 AND " );
            strSql . Append ( "PAY003=@PAY003" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PAY001", SqlDbType.NVarChar,20),
                    new SqlParameter("@PAY002", SqlDbType.NVarChar,20),
                    new SqlParameter("@PAY003", SqlDbType.NVarChar,10),
                    new SqlParameter("@PAY004", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY005", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY006", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY007", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY008", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY009", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY010", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY011", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY012", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY013", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY014", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY015", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY016", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY017", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY018", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY019", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY020", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY021", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY022", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY023", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY024", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY025", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY026", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY027", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY028", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY029", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY030", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY031", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY032", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY033", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY034", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . PAY001;
            parameters [ 1 ] . Value = model . PAY002;
            parameters [ 2 ] . Value = model . PAY003;
            parameters [ 3 ] . Value = model . PAY004;
            parameters [ 4 ] . Value = model . PAY005;
            parameters [ 5 ] . Value = model . PAY006;
            parameters [ 6 ] . Value = model . PAY007;
            parameters [ 7 ] . Value = model . PAY008;
            parameters [ 8 ] . Value = model . PAY009;
            parameters [ 9 ] . Value = model . PAY010;
            parameters [ 10 ] . Value = model . PAY011;
            parameters [ 11 ] . Value = model . PAY012;
            parameters [ 12 ] . Value = model . PAY013;
            parameters [ 13 ] . Value = model . PAY014;
            parameters [ 14 ] . Value = model . PAY015;
            parameters [ 15 ] . Value = model . PAY016;
            parameters [ 16 ] . Value = model . PAY017;
            parameters [ 17 ] . Value = model . PAY018;
            parameters [ 18 ] . Value = model . PAY019;
            parameters [ 19 ] . Value = model . PAY020;
            parameters [ 20 ] . Value = model . PAY021;
            parameters [ 21 ] . Value = model . PAY022;
            parameters [ 22 ] . Value = model . PAY023;
            parameters [ 23 ] . Value = model . PAY024;
            parameters [ 24 ] . Value = model . PAY025;
            parameters [ 25 ] . Value = model . PAY026;
            parameters [ 26 ] . Value = model . PAY027;
            parameters [ 27 ] . Value = model . PAY028;
            parameters [ 28 ] . Value = model . PAY029;
            parameters [ 29 ] . Value = model . PAY030;
            parameters [ 30 ] . Value = model . PAY031;
            parameters [ 31 ] . Value = model . PAY032;
            parameters [ 32 ] . Value = model . PAY033;
            parameters [ 33 ] . Value = model . PAY034;

            SQLString . Add ( strSql ,parameters );
        }

        void Add ( Hashtable SQLString,StringBuilder strSql,CarpenterEntity.PayrollReportEntity model)
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into MOXPAY(" );
            strSql . Append ( "PAY001,PAY002,PAY003,PAY004,PAY005,PAY006,PAY007,PAY008,PAY009,PAY010,PAY011,PAY012,PAY013,PAY014,PAY015,PAY016,PAY017,PAY018,PAY019,PAY020,PAY021,PAY022,PAY023,PAY024,PAY025,PAY026,PAY027,PAY028,PAY029,PAY030,PAY031,PAY032,PAY033,PAY034)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@PAY001,@PAY002,@PAY003,@PAY004,@PAY005,@PAY006,@PAY007,@PAY008,@PAY009,@PAY010,@PAY011,@PAY012,@PAY013,@PAY014,@PAY015,@PAY016,@PAY017,@PAY018,@PAY019,@PAY020,@PAY021,@PAY022,@PAY023,@PAY024,@PAY025,@PAY026,@PAY027,@PAY028,@PAY029,@PAY030,@PAY031,@PAY032,@PAY033,@PAY034)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PAY001", SqlDbType.NVarChar,20),
                    new SqlParameter("@PAY002", SqlDbType.NVarChar,20),
                    new SqlParameter("@PAY003", SqlDbType.NVarChar,10),
                    new SqlParameter("@PAY004", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY005", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY006", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY007", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY008", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY009", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY010", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY011", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY012", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY013", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY014", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY015", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY016", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY017", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY018", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY019", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY020", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY021", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY022", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY023", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY024", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY025", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY026", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY027", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY028", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY029", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY030", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY031", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY032", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY033", SqlDbType.Decimal,9),
                    new SqlParameter("@PAY034", SqlDbType.Decimal,9)};
            parameters [ 0 ] . Value = model . PAY001;
            parameters [ 1 ] . Value = model . PAY002;
            parameters [ 2 ] . Value = model . PAY003;
            parameters [ 3 ] . Value = model . PAY004;
            parameters [ 4 ] . Value = model . PAY005;
            parameters [ 5 ] . Value = model . PAY006;
            parameters [ 6 ] . Value = model . PAY007;
            parameters [ 7 ] . Value = model . PAY008;
            parameters [ 8 ] . Value = model . PAY009;
            parameters [ 9 ] . Value = model . PAY010;
            parameters [ 10 ] . Value = model . PAY011;
            parameters [ 11 ] . Value = model . PAY012;
            parameters [ 12 ] . Value = model . PAY013;
            parameters [ 13 ] . Value = model . PAY014;
            parameters [ 14 ] . Value = model . PAY015;
            parameters [ 15 ] . Value = model . PAY016;
            parameters [ 16 ] . Value = model . PAY017;
            parameters [ 17 ] . Value = model . PAY018;
            parameters [ 18 ] . Value = model . PAY019;
            parameters [ 19 ] . Value = model . PAY020;
            parameters [ 20 ] . Value = model . PAY021;
            parameters [ 21 ] . Value = model . PAY022;
            parameters [ 22 ] . Value = model . PAY023;
            parameters [ 23 ] . Value = model . PAY024;
            parameters [ 24 ] . Value = model . PAY025;
            parameters [ 25 ] . Value = model . PAY026;
            parameters [ 26 ] . Value = model . PAY027;
            parameters [ 27 ] . Value = model . PAY028;
            parameters [ 28 ] . Value = model . PAY029;
            parameters [ 29 ] . Value = model . PAY030;
            parameters [ 30 ] . Value = model . PAY031;
            parameters [ 31 ] . Value = model . PAY032;
            parameters [ 32 ] . Value = model . PAY033;
            parameters [ 33 ] . Value = model . PAY034;
            SQLString . Add ( strSql ,parameters );
        }

    }

}
