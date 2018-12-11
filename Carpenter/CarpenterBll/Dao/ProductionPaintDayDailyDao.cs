using StudentMgr;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Text;

namespace CarpenterBll . Dao
{
    public class ProductionPaintDayDailyDao
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string columns )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM MOXPWF ORDER BY {0} DESC" ,columns );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Delete ( List<string> strList )
        {
            string idxStr = string . Empty;
            foreach ( string s in strList )
            {
                if ( idxStr == string . Empty )
                    idxStr = s;
                else
                    idxStr = idxStr + "," + s;
            }
            
            StringBuilder strSql = new StringBuilder ( );
            Hashtable SQLString = new Hashtable ( );

            strSql . AppendFormat ( "SELECT PWF002,PWF003,SUM(ISNULL(PWF007,0)) PWF007,SUM(ISNULL(PWF008,0)) PWF008,SUM(ISNULL(PWF009,0)) PWF009,SUM(ISNULL(PWF010,0)) PWF010,SUM(ISNULL(PWF011,0)) PWF011,SUM(ISNULL(PWF016,0)) PWF016 FROM MOXPWF WHERE idx IN ({0}) GROUP BY PWF002,PWF003" ,idxStr );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                CarpenterEntity . ProductionPaintDayDailyEntity model = new CarpenterEntity . ProductionPaintDayDailyEntity ( );
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    model . PWF002 = dt . Rows [ i ] [ "PWF002" ] . ToString ( );
                    model . PWF003 = dt . Rows [ i ] [ "PWF003" ] . ToString ( );
                    model . PWF007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PWF007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PWF007" ] . ToString ( ) );
                    model . PWF008 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PWF008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PWF008" ] . ToString ( ) );
                    model . PWF009 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PWF009" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PWF009" ] . ToString ( ) );
                    model . PWF010 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PWF010" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PWF010" ] . ToString ( ) );
                    model . PWF011 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PWF011" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PWF011" ] . ToString ( ) );
                    model . PWF016 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PWF016" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PWF016" ] . ToString ( ) );
                    edit_pdp ( SQLString ,strSql ,model );
                }
            }

            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPWF " );
            strSql . Append ( "WHERE idx IN (" + idxStr + ")" );
            SQLString . Add ( strSql ,null );

            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PWD002,PWE003,PWE004 FROM MOXPWD A INNER JOIN MOXPWE B ON A.PWD001=B.PWE001 INNER JOIN MOXPWF C ON B.PWE001=C.PWF017 AND B.PWE004=C.PWF003 AND B.PWE003=C.PWF002 WHERE C.idx IN ({0})" ,idxStr );
            dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    CarpenterEntity . ProductionPaintDayDailyEntity model = new CarpenterEntity . ProductionPaintDayDailyEntity ( );
                    for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                    {
                        model . PWF001 = dt . Rows [ i ] [ "PWD002" ] . ToString ( );
                        model . PWF002 = dt . Rows [ i ] [ "PWE003" ] . ToString ( );
                        model . PWF003 = dt . Rows [ i ] [ "PWE004" ] . ToString ( );
                        model . PWF012 = getDt ( model );
                        edit_pdpTime ( SQLString ,strSql ,model );              
                    }
                }
            }
            else
                return false;
            
            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void edit_pdp ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ProductionPaintDayDailyEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXPDP SET PDP008=ISNULL(PDP008,0)+{0},PDP009=ISNULL(PDP009,0)-{0},PDP011=ISNULL(PDP011,0)+{1},PDP012=ISNULL(PDP012,0)-{1},PDP014=ISNULL(PDP014,0)+{2},PDP015=ISNULL(PDP015,0)-{2},PDP017=ISNULL(PDP017,0)+{3},PDP018=ISNULL(PDP018,0)-{3},PDP022=ISNULL(PDP022,0)-{4},PDP028=ISNULL(PDP028,0)+{4} WHERE PDP001='{5}' AND PDP002='{6}'" ,model . PWF007 ,model . PWF008 ,model . PWF009 ,model . PWF010,model . PWF016 ,model . PWF002 ,model . PWF003 );
            SQLString . Add ( strSql ,null );
        }

        DateTime? getDt ( CarpenterEntity . ProductionPaintDayDailyEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MAX(PWF012) PWF012 FROM MOXPWF WHERE PWF002='{0}' AND PWF003='{1}'" ,model . PWF002 ,model . PWF003 );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PWF012" ] . ToString ( ) ) )
                    return null;
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "PWF012" ] . ToString ( ) );
            }
            else
                return null;
        }

        void edit_pdpTime ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ProductionPaintDayDailyEntity model )
        {
            model . PWF017 = string . Empty;
            if ( model . PWF001 . Equals ( ColumnValues . yq_dq ) )
                model . PWF017 = "PDP010";
            else if ( model . PWF001 . Equals ( ColumnValues . yq_mq ) )
                model . PWF017 = "PDP019";
            else if ( model . PWF001 . Equals ( ColumnValues . yq_ym ) )
                model . PWF017 = "PDP013";
            else if ( model . PWF001 . Equals ( ColumnValues . yq_rb ) )
                model . PWF017 = "PDP021";
            else if ( model . PWF001 . Equals ( ColumnValues . yq_xs ) )
                model . PWF017 = "PDP016";
            else if ( model . PWF001 . Equals ( ColumnValues . yq_bz ) )
                model . PWF017 = "PDP023";

            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET " );
            strSql . AppendFormat ( "{0}=@DATE " ,model . PWF017 );
            strSql . Append ( "WHERE PDP001=@PDP001 AND PDP002=@PDP002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@DATE",SqlDbType.Date,3),
                new SqlParameter("@PDP001",SqlDbType.NVarChar,20),
                new SqlParameter("@PDP002",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = model . PWF012;
            parameter [ 1 ] . Value = model . PWF002;
            parameter [ 2 ] . Value = model . PWF003;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,PWF001,PWF002,PWF003,PWF004,PWF005,PDP025,PWF006,CASE WHEN PWF007=0 THEN NULL ELSE PWF007 END PWF007,CASE WHEN PWF008=0 THEN NULL ELSE PWF008 END PWF008,CASE WHEN PWF009=0 THEN NULL ELSE PWF009 END PWF009,CASE WHEN PWF010=0 THEN NULL ELSE PWF010 END PWF010,CASE WHEN PWF011=0 THEN NULL ELSE PWF011 END PWF011,PWF012,OPI006,OPI007,CASE PWF015 WHEN 0 THEN '正式' ELSE '预排' END PWF015,CASE WHEN PWF016=0 THEN NULL ELSE PWF016 END PWF016,PWF017,CONVERT(FLOAT,ISNULL(OPI004,0)) OPI004,CONVERT(FLOAT,ISNULL(OPI004,0)*(PWF007+PWF008+PWF009+PWF010+PWF011+PWF016)) U0,PWF014 FROM MOXPWF A LEFT JOIN MOXOPI B ON A.PWF003=B.OPI001 INNER JOIN MOXPDP C ON A.PWF002=C.PDP001 AND A.PWF003=C.PDP002 " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( " ORDER BY PWF001 DESC,PWF002 DESC,PWF003 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="workShop"></param>
        /// <param name="dateTime"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string workShop ,string dateTime ,string person )
        {
            string column = string . Empty;
            StringBuilder strSql = new StringBuilder ( );
            //if ( workShop . Equals ( "包装" ) )
            //{
            //    strSql . Append ( "SELECT PWF002,PWF003,PWF004,PDP025,OPI006,PDP024 PWE008,PWF016 PWF,0 PWFSUM,PDP025-PWF016 RES FROM MOXPWF A LEFT JOIN MOXPDP B ON A.PWF002=B.PDP001 AND A.PWF003=B.PDP002 LEFT JOIN MOXOPI C ON A.PWF003=C.OPI001  " );
            //    strSql . AppendFormat ( "WHERE PWF012='{0}' AND PWF014='{1}' AND PWF016>0 ORDER BY PWF002,PWF003" ,dateTime ,person );
            //}
            //else
            //{
            if ( workShop . Equals ( ColumnValues . yq_dq ) )
                column = "PWF007";
            else if ( workShop . Equals ( ColumnValues . yq_ym ) )
                column = "PWF008";
            else if ( workShop . Equals ( ColumnValues . yq_xs ) )
                column = "PWF009";
            else if ( workShop . Equals ( ColumnValues . yq_mq ) )
                column = "PWF010";
            else if ( workShop . Equals ( ColumnValues . yq_rb ) )
                column = "PWF011";
            else if ( workShop . Equals ( ColumnValues . yq_bz ) )
                column = "PWF016";

            strSql . Append ( "WITH CET AS (" );
            strSql . AppendFormat ( "SELECT PWF002,PWF003,PWF004,PDP025,OPI006,PWE008,{0} PWF FROM MOXPWF A INNER JOIN MOXPWE B ON A.PWF002=B.PWE003 AND A.PWF003=B.PWE004 AND A.PWF017=B.PWE001 INNER JOIN MOXOPI C ON A.PWF003=C.OPI001 INNER JOIN MOXPWD D ON B.PWE001=D.PWD001 INNER JOIN MOXPDP E ON A.PWF002=E.PDP001 AND A.PWF003=E.PDP002 " ,column );
            strSql . AppendFormat ( "WHERE PWF012='{0}' AND PWF014='{1}' AND PWD002='{2}' AND {3}>0" ,dateTime ,person ,workShop ,column );
            strSql . Append ( " UNION ALL " );
            strSql . AppendFormat ( "SELECT PWF002,PWF003,PWF004,PDP025,OPI006,CUU005 PWE008,{0} PWF FROM MOXPWF A INNER JOIN MOXPWE B ON A.PWF002=B.PWE003 AND A.PWF003=B.PWE004 INNER JOIN MOXOPI C ON A.PWF003=C.OPI001 INNER JOIN MOXPWD D ON B.PWE001=D.PWD001 INNER JOIN MOXPDP E ON A.PWF002=E.PDP001 AND A.PWF003=E.PDP002 INNER JOIN MOXCUU F ON A.PWF002=CUU001 AND PWF003=CUU002  " ,column );
            strSql . AppendFormat ( "WHERE PWF012='{0}' AND PWF014='{1}' AND PWD002='{2}' AND {3}>0 AND PWF017='' " ,dateTime ,person ,workShop ,column );
            strSql . Append ( " UNION ALL " );
            strSql . AppendFormat ( "SELECT PWF002,PWF003,PWF004,PDP025,OPI006,CUU005 PWE008,{2} PWF FROM MOXPWF A INNER JOIN MOXOPI B ON A.PWF003=B.OPI001 INNER JOIN MOXPDP C ON A.PWF002=C.PDP001 AND A.PWF003=C.PDP002 INNER JOIN MOXCUU D ON A.PWF002=D.CUU001 AND A.PWF003=D.CUU002 WHERE PWF012='{0}' AND PWF014='{1}' AND {2}>0 AND PWF017=''" ,dateTime ,person ,column );
            strSql . Append ( "), CFT AS (" );
            strSql . AppendFormat ( "SELECT A.PWF002,A.PWF003,SUM(A.{0}) PWF FROM MOXPWF A INNER JOIN CET B ON A.PWF002=B.PWF002 AND A.PWF003=B.PWF003 WHERE PWF012<'{1}' GROUP BY A.PWF002,A.PWF003) " ,column ,dateTime );
            strSql . Append ( "SELECT A.*,ISNULL(B.PWF,0) PWFSUM,A.PDP025-A.PWF-ISNULL(B.PWF,0) RES FROM CET A LEFT JOIN CFT B ON A.PWF002=B.PWF002 AND A.PWF003=B.PWF003 ORDER BY A.PWF002,A.PWF003" );
            //}

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="workShop"></param>
        /// <param name="dateTime"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string workShop ,string dateTime ,string person )
        {
            StringBuilder strSql = new StringBuilder ( );
            if ( workShop . Equals ( "包装" ) )
            {
                strSql . Append ( "WITH CET AS (" );
                strSql . Append ( "SELECT PWF012,PWF014,'包装' PWD002,CONVERT(FLOAT,SUM(PWF016*OPI004)) PWE FROM MOXPWF A LEFT JOIN MOXOPI C ON A.PWF003=C.OPI001  " );
                strSql . AppendFormat ( "WHERE PWF012='{0}' AND PWF014='{1}' " ,dateTime ,person  );
                strSql . Append ( "GROUP BY PWF012,PWF014 " );
                strSql . AppendFormat ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT PWF012,PWF014,'包装',CONVERT(FLOAT,SUM(PWF016*OPI004)) PWF FROM MOXPWF A INNER JOIN MOXOPI B ON A.PWF003=B.OPI001 WHERE PWF012='{0}' AND PWF014='{1}' AND PWF016>0 AND PWF017='' GROUP BY PWF012,PWF014) "  ,dateTime ,person  );
                strSql . AppendFormat ( "SELECT PWF012,PWF014,PWD002,SUM(PWE) PWE FROM CET GROUP BY PWF012,PWF014,PWD002" );
            }
            else
            {
                string column = string . Empty;
                if ( workShop . Equals ( ColumnValues . yq_dq ) )
                    column = "PWF007";
                else if ( workShop . Equals ( ColumnValues . yq_mq ) )
                    column = "PWF010";
                else if ( workShop . Equals ( ColumnValues . yq_rb ) )
                    column = "PWF011";
                else if ( workShop . Equals ( ColumnValues . yq_xs ) )
                    column = "PWF009";
                else if ( workShop . Equals ( ColumnValues . yq_ym ) )
                    column = "PWF008";

                strSql . Append ( "WITH CET AS (" );
                strSql . AppendFormat ( "SELECT PWF012,PWF014,PWD002,CONVERT(FLOAT,SUM({0}*OPI004)) PWE FROM MOXPWF A INNER JOIN MOXPWE B ON A.PWF002=B.PWE003 AND A.PWF003=B.PWE004 AND A.PWF017=B.PWE001 INNER JOIN MOXOPI C ON A.PWF003=C.OPI001 INNER JOIN MOXPWD D ON B.PWE001=D.PWD001 " ,column );
                strSql . AppendFormat ( "WHERE PWF012='{0}' AND PWF014='{1}' AND PWD002='{2}' " ,dateTime ,person ,workShop );
                strSql . Append ( "GROUP BY PWF012,PWF014,PWD002" );
                strSql . AppendFormat ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT PWF012,PWF014,'{0}',CONVERT(FLOAT,SUM({3}*OPI004)) PWF FROM MOXPWF A INNER JOIN MOXOPI B ON A.PWF003=B.OPI001 WHERE PWF012='{1}' AND PWF014='{2}' AND {3}>0 AND PWF017='' GROUP BY PWF012,PWF014) " ,workShop ,dateTime ,person ,column );
                strSql . AppendFormat ( "SELECT PWF012,PWF014,PWD002,SUM(PWE) PWE FROM CET GROUP BY PWF012,PWF014,PWD002" );
            }

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取报工人
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableDWPerson ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PWF014 FROM MOXPWF" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取报工清单  常规产品
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( List<string> inList ,string work )
        {
            string str = string . Empty;
            foreach ( string intX in inList )
            {
                if ( str == string . Empty )
                    str = intX;
                else
                    str = str + "," + intX;
            }

            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT PDP001,PDP002,PDP003,PDP004,PWE007,PDP025,0 DQ,0 YM,0 XS,0 MQ,0 RB,0 BZ,GETDATE() PWF012,OPI006,OPI007,SUM(ISNULL(PWF007,0)) PWF007,SUM(ISNULL(PWF008,0)) PWF008,SUM(ISNULL(PWF009,0)) PWF009,SUM(ISNULL(PWF010,0)) PWF010,SUM(ISNULL(PWF011,0)) PWF011,SUM(ISNULL(PWF016,0)) PWF016,PWD002 FROM MOXPDP A LEFT JOIN MOXPWF B ON A.PDP001=B.PWF002 AND A.PDP002=B.PWF003 LEFT JOIN MOXOPI C ON A.PDP002=C.OPI001 INNER JOIN (SELECT PWD002,PWE003,PWE004,SUM(PWE007) PWE007 FROM MOXPWE D INNER JOIN MOXPWD E ON D.PWE001=E.PWD001 " );
            //strSql . AppendFormat ( "WHERE PWD002='{0}' AND PWD006=1 AND PWE012=0 AND PWE002='完工' " ,work );
            //strSql . Append ( "GROUP BY PWD002,PWE003,PWE004) D ON A.PDP001=D.PWE003 AND A.PDP002=D.PWE004 " );
            //strSql . AppendFormat ( " WHERE A.idx IN ({0}) " ,str );
            //strSql . Append ( "GROUP BY PDP001,PDP002,PDP003,PDP004,OPI006,OPI007,PWD002,PWE007,PDP025 " );
            
            strSql . Append ( "SELECT PWE001,PWE003 PDP001,PWE004 PDP002,PWE005 PDP003,PWE007,SUM(ISNULL(PWF007,0)) PWF007,SUM(ISNULL(PWF008,0)) PWF008,SUM(ISNULL(PWF009,0)) PWF009,SUM(ISNULL(PWF010,0)) PWF010,SUM(ISNULL(PWF011,0)) PWF011,0 PWF016,PWE007-SUM(ISNULL(PWF007,0)) DQ,PWE007-SUM(ISNULL(PWF008,0)) YM,PWE007-SUM(ISNULL(PWF009,0)) XS,PWE007-SUM(ISNULL(PWF010,0)) MQ,PWE007-SUM(ISNULL(PWF011,0)) RB,PWE007-SUM(ISNULL(PWF016,0)) BZ,GETDATE() PWF012,OPI005 PDP004 FROM MOXPWD A INNER JOIN MOXPWE B ON A.PWD001=B.PWE001 LEFT JOIN MOXPWF C ON C.PWF002=B.PWE003 AND C.PWF003=B.PWE004 AND C.PWF017=B.PWE001 LEFT JOIN MOXOPI D ON B.PWE004=D.OPI001 INNER JOIN MOXPDP E ON B.PWE003=E.PDP001 AND B.PWE004=E.PDP002  " );
            strSql . AppendFormat ( "WHERE E.idx IN ({1}) AND PWD006=1 AND PWE012=0 AND PWE002='完工' AND PWD002='{0}' " ,work ,str );
            strSql . Append ( "GROUP BY PWE001,PWE003,PWE004,PWE005,OPI005,PWE007 " );
            str = string . Empty;
            if ( work . Equals ( ColumnValues.yq_dq ) )
            {
                str = "PWF007";
            }
            else if ( work . Equals ( ColumnValues . yq_ym ) )
            {
                str = "PWF008";
            }
            else if ( work . Equals ( ColumnValues . yq_xs ) )
            {
                str = "PWF009";
            }
            else if ( work . Equals ( ColumnValues . yq_mq ) )
            {
                str = "PWF010";
            }
            else if ( work . Equals ( ColumnValues . yq_rb ) )
            {
                str = "PWF011";
            }
            else if ( work . Equals ( ColumnValues . yq_bz ) )
            {
                str = "PWF016";
            }


            strSql . AppendFormat ( "HAVING  SUM(ISNULL({0},0))<PWE007 ORDER BY PWE003 DESC,PWE004 DESC " ,str );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取报工清单 非常规产品
        /// </summary>
        /// <param name="inList"></param>
        /// <param name="work"></param>
        /// <returns></returns>
        public DataTable GetDataTableOther ( List<string> inList ,string work )
        {
            string str = string . Join ( "," ,inList . ToArray ( ) );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT '' PWE001,PDP001,PDP002,PDP003,PDP025 PWE007,SUM(ISNULL(PWF007,0)) PWF007,SUM(ISNULL(PWF008,0)) PWF008,SUM(ISNULL(PWF009,0)) PWF009,SUM(ISNULL(PWF010,0)) PWF010,SUM(ISNULL(PWF011,0)) PWF011,0 PWF016,PDP025-SUM(ISNULL(PWF007,0)) DQ,PDP025-SUM(ISNULL(PWF008,0)) YM,PDP025-SUM(ISNULL(PWF009,0)) XS,PDP025-SUM(ISNULL(PWF010,0)) MQ,PDP025-SUM(ISNULL(PWF011,0)) RB,PDP025-SUM(ISNULL(PWF016,0)) BZ,GETDATE() PWF012,OPI005 PDP004 FROM MOXPDP A INNER JOIN MOXOPI B ON A.PDP002=B.OPI001 LEFT JOIN MOXPWF C ON A.PDP001=C.PWF002 AND A.PDP002=C.PWF003 WHERE A.idx IN ({0}) GROUP BY PDP001,PDP002,PDP003,PDP025,OPI005  " ,str );
            str = string . Empty;
            if ( work . Equals ( ColumnValues . yq_dq ) )
            {
                str = "PWF007";
            }
            else if ( work . Equals ( ColumnValues . yq_ym ) )
            {
                str = "PWF008";
            }
            else if ( work . Equals ( ColumnValues . yq_xs ) )
            {
                str = "PWF009";
            }
            else if ( work . Equals ( ColumnValues . yq_mq ) )
            {
                str = "PWF010";
            }
            else if ( work . Equals ( ColumnValues . yq_rb ) )
            {
                str = "PWF011";
            }
            else if ( work . Equals ( ColumnValues . yq_bz ) )
            {
                str = "PWF016";
            }
            strSql . AppendFormat ( "HAVING SUM(ISNULL({0},0))<PDP025 ORDER BY PDP001 DESC,PDP002 DESC" ,str );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取包装报工清单
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableBZ ( List<string> inList )
        {
            string str = string . Empty;
            foreach ( string intX in inList )
            {
                if ( str == string . Empty )
                    str = intX;
                else
                    str = str + "," + intX;
            }

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT '' PWE001,PDP001,PDP002,PDP003,PDP004,PDP025 PWE007,PDP025-SUM(ISNULL(PWF007,0)) DQ,PDP025-SUM(ISNULL(PWF008,0)) YM,PDP025-SUM(ISNULL(PWF009,0)) XS,PDP025-SUM(ISNULL(PWF010,0)) MQ,PDP025-SUM(ISNULL(PWF011,0)) RB,PDP025-SUM(ISNULL(PWF016,0)) BZ,GETDATE() PWF012,SUM(ISNULL(PWF007,0)) PWF007,SUM(ISNULL(PWF008,0)) PWF008,SUM(ISNULL(PWF009,0)) PWF009,SUM(ISNULL(PWF010,0)) PWF010,SUM(ISNULL(PWF011,0)) PWF011,SUM(ISNULL(PWF016,0)) PWF016 FROM MOXPDP A LEFT JOIN MOXPWF B ON A.PDP001=B.PWF002 AND A.PDP002=B.PWF003 LEFT JOIN MOXOPI C ON A.PDP002=C.OPI001 " );
            strSql . Append ( "WHERE A.idx IN (" + str + ") " );
            strSql . Append ( "GROUP BY PDP001,PDP002,PDP003,PDP004,PDP025,OPI006,OPI007 " );
            strSql . Append ( "HAVING SUM(ISNULL(PWF016,0))<PDP025 " );
            strSql . Append ( "ORDER BY PDP001 DESC,PDP002 DESC   " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取计划报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlan ( List<string> inList ,string work )
        {
            string str = string . Empty;
            foreach ( string intX in inList )
            {
                if ( str == string . Empty )
                    str = intX;
                else
                    str = str + "," + intX;
            }

            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT PDP001,PDP002,PDP003,PDP004,PWE007,PDP025,0 DQ,0 YM,0 XS,0 MQ,0 RB,0 BZ,GETDATE() PWF012,OPI006,OPI007,SUM(ISNULL(PWF007,0)) PWF007,SUM(ISNULL(PWF008,0)) PWF008,SUM(ISNULL(PWF009,0)) PWF009,SUM(ISNULL(PWF010,0)) PWF010,SUM(ISNULL(PWF011,0)) PWF011,SUM(ISNULL(PWF016,0)) PWF016,PWD002 FROM MOXPDP A LEFT JOIN MOXPWF B ON A.PDP001=B.PWF002 AND A.PDP002=B.PWF003 LEFT JOIN MOXOPI C ON A.PDP002=C.OPI001 INNER JOIN (SELECT PWD002,PWE003,PWE004,SUM(PWE007) PWE007 FROM MOXPWE D INNER JOIN MOXPWD E ON D.PWE001=E.PWD001 " );
            //strSql . AppendFormat ( "WHERE PWD002='{0}' AND PWD006=1 AND (PWE012=1 OR PWE002='未完工')" ,work );
            //strSql . Append ( "GROUP BY PWD002,PWE003,PWE004) D ON A.PDP001=D.PWE003 AND A.PDP002=D.PWE004 " );
            //strSql . AppendFormat ( " WHERE A.idx IN ({0}) " ,str );
            //strSql . Append ( "GROUP BY PDP001,PDP002,PDP003,PDP004,OPI006,OPI007,PWD002,PWE007,PDP025 " );

            strSql . AppendFormat ( "SELECT PWE001,PWE003 PDP001,PWE004 PDP002,PWE005 PDP003,PWE007,SUM(ISNULL(PWF007,0)) PWF007,SUM(ISNULL(PWF008,0)) PWF008,SUM(ISNULL(PWF009,0)) PWF009,SUM(ISNULL(PWF010,0)) PWF010,SUM(ISNULL(PWF011,0)) PWF011,0 PWF016,PWE007-SUM(ISNULL(PWF007,0)) DQ,PWE007-SUM(ISNULL(PWF008,0)) YM,PWE007-SUM(ISNULL(PWF009,0)) XS,PWE007-SUM(ISNULL(PWF010,0)) MQ,PWE007-SUM(ISNULL(PWF011,0)) RB,PWE007-SUM(ISNULL(PWF016,0)) BZ,GETDATE() PWF012,OPI005 PDP004 FROM (SELECT MAX ( PWD001 ) PWD001 FROM MOXPWD A INNER JOIN MOXPWE B ON A . PWD001 = B . PWE001 INNER JOIN MOXPDP E ON B . PWE003 = E . PDP001 AND B . PWE004 = E . PDP002 WHERE PWD006 = 1 AND PWD002 = '{1}' AND E.idx IN ( {0} )) A INNER JOIN MOXPWE B ON A.PWD001=B.PWE001 LEFT JOIN MOXPWF C ON C.PWF002=B.PWE003 AND C.PWF003=B.PWE004 AND C.PWF017=B.PWE001 LEFT JOIN MOXOPI D ON B.PWE004=D.OPI001 INNER JOIN MOXPDP E ON B.PWE003=E.PDP001 AND B.PWE004=E.PDP002 " ,str ,work );
            strSql . AppendFormat ( "WHERE E.idx IN ({0}) AND (PWE012=1 OR PWE002='未完工')" ,str );
            strSql . Append ( "GROUP BY PWE001,PWE003,PWE004,PWE005,OPI005,PWE007 " );

            str = string . Empty;
            if ( work . Equals ( ColumnValues . yq_dq ) )
            {
                str = "PWF007";
            }
            else if ( work . Equals ( ColumnValues . yq_ym ) )
            {
                str = "PWF008";
            }
            else if ( work . Equals ( ColumnValues . yq_xs ) )
            {
                str = "PWF009";
            }
            else if ( work . Equals ( ColumnValues . yq_mq ) )
            {
                str = "PWF010";
            }
            else if ( work . Equals ( ColumnValues . yq_rb ) )
            {
                str = "PWF011";
            }

            strSql . AppendFormat ( "HAVING  SUM(ISNULL({0},0))<PWE007 ORDER BY PWE003 DESC,PWE004 DESC " ,str );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 油漆报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool BLDailyWork ( DataTable table ,bool plan,string work )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . ProductionPaintDayDailyEntity _model = new CarpenterEntity . ProductionPaintDayDailyEntity ( );
            _model . PWF001 = GetDataTableDailyWorkOddNum ( );
            _model . PWF013 = UserInformation . dt ( );
            _model . PWF014 = UserInformation . UserName;
            _model . PWF015 = plan;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . PWF002 = table . Rows [ i ] [ "PDP001" ] . ToString ( );
                _model . PWF003 = table . Rows [ i ] [ "PDP002" ] . ToString ( );
                _model . PWF004 = table . Rows [ i ] [ "PDP003" ] . ToString ( );
                _model . PWF005 = table . Rows [ i ] [ "PDP004" ] . ToString ( );
                _model . PWF006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PWE007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PWE007" ] . ToString ( ) );
                _model . PWF007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DQ" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DQ" ] . ToString ( ) );
                _model . PWF008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "YM" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "YM" ] . ToString ( ) );
                _model . PWF009 = string . IsNullOrEmpty ( table . Rows [ i ] [ "XS" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "XS" ] . ToString ( ) );
                _model . PWF010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "MQ" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "MQ" ] . ToString ( ) );
                _model . PWF011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "RB" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "RB" ] . ToString ( ) );
                _model . PWF016 = string . IsNullOrEmpty ( table . Rows [ i ] [ "BZ" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "BZ" ] . ToString ( ) );
                _model . PWF017 = table . Rows [ i ] [ "PWE001" ] . ToString ( );

                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PWF012" ] . ToString ( ) ) )
                    _model . PWF012 = null;
                else
                    _model . PWF012 = Convert . ToDateTime ( table . Rows [ i ] [ "PWF012" ] . ToString ( ) );

                if ( _model . PWF007 != 0 || _model . PWF008 != 0 || _model . PWF009 != 0 || _model . PWF010 != 0 || _model . PWF011 != 0 || _model . PWF016 != 0 )
                    edit_BL_DailyWork ( _model ,strSql ,SQLString );
                //若报工总数量=生产数量  则回写完工时间到备料跟踪表的对应工段完工时间
                //_model . PWF007 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PWF007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PWF007" ] . ToString ( ) );
                //_model . PWF008 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PWF008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PWF008" ] . ToString ( ) );
                //_model . PWF009 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PWF009" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PWF009" ] . ToString ( ) );
                //_model . PWF010 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PWF010" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PWF010" ] . ToString ( ) );
                //_model . PWF011 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PWF011" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PWF011" ] . ToString ( ) );
                //_model . PWF016 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PWF016" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PWF016" ] . ToString ( ) );
                if ( _model . PWF015 == false )
                {
                    if ( _model . PWF017 == string . Empty )
                        edit_BL_OverTime_NoPlan ( _model ,strSql ,SQLString ,work );
                    else
                        edit_BL_OverTime ( _model ,strSql ,SQLString ,work );
                }

                //if ( Exists_bl_weekEnds ( _model . PWF002 ,_model . PWF003 ,_model . PWF011 ) == true )
                //    edit_bl_weekEnds ( _model . PWF002 ,_model . PWF003 ,SQLString ,strSql );
                
                if ( Exists_bl_day ( _model . PWF002 ,_model . PWF003 ,new int [ ] { _model . PWF007 ,_model . PWF008 ,_model . PWF009 ,_model . PWF010 ,_model . PWF011 } ) == true )
                    edit_bl_day ( _model . PWF002 ,_model . PWF003 ,SQLString ,strSql ,plan );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取油漆报工的单号
        /// </summary>
        /// <returns></returns>
        string GetDataTableDailyWorkOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(PWF001) PWF001 FROM MOXPWF" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PWF001" ] . ToString ( ) ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PWF001" ] . ToString ( ) . Substring ( 0 ,8 ) == UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PWF001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        void edit_BL_DailyWork ( CarpenterEntity . ProductionPaintDayDailyEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPWF (" );
            strSql . Append ( "PWF001,PWF002,PWF003,PWF004,PWF005,PWF006,PWF007,PWF008,PWF009,PWF010,PWF011,PWF012,PWF013,PWF014,PWF015,PWF016,PWF017) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PWF001,@PWF002,@PWF003,@PWF004,@PWF005,@PWF006,@PWF007,@PWF008,@PWF009,@PWF010,@PWF011,@PWF012,@PWF013,@PWF014,@PWF015,@PWF016,@PWF017) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWF001",SqlDbType.NVarChar,20),
                new SqlParameter("@PWF002",SqlDbType.NVarChar,20),
                new SqlParameter("@PWF003",SqlDbType.NVarChar,20),
                new SqlParameter("@PWF004",SqlDbType.NVarChar,20),
                new SqlParameter("@PWF005",SqlDbType.NVarChar,20),
                new SqlParameter("@PWF006",SqlDbType.Int),
                new SqlParameter("@PWF007",SqlDbType.Int),
                new SqlParameter("@PWF008",SqlDbType.Int),
                new SqlParameter("@PWF009",SqlDbType.Int),
                new SqlParameter("@PWF010",SqlDbType.Int),
                new SqlParameter("@PWF011",SqlDbType.Int),
                new SqlParameter("@PWF012",SqlDbType.Date),
                new SqlParameter("@PWF013",SqlDbType.Date),
                new SqlParameter("@PWF014",SqlDbType.NVarChar,20),
                new SqlParameter("@PWF015",SqlDbType.Bit),
                new SqlParameter("@PWF016",SqlDbType.Int),
                new SqlParameter("@PWF017",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PWF001;
            parameter [ 1 ] . Value = _model . PWF002;
            parameter [ 2 ] . Value = _model . PWF003;
            parameter [ 3 ] . Value = _model . PWF004;
            parameter [ 4 ] . Value = _model . PWF005;
            parameter [ 5 ] . Value = _model . PWF006;
            parameter [ 6 ] . Value = _model . PWF007;
            parameter [ 7 ] . Value = _model . PWF008;
            parameter [ 8 ] . Value = _model . PWF009;
            parameter [ 9 ] . Value = _model . PWF010;
            parameter [ 10 ] . Value = _model . PWF011;
            parameter [ 11 ] . Value = _model . PWF012;
            parameter [ 12 ] . Value = _model . PWF013;
            parameter [ 13 ] . Value = _model . PWF014;
            parameter [ 14 ] . Value = _model . PWF015;
            parameter [ 15 ] . Value = _model . PWF016;
            parameter [ 16 ] . Value = _model . PWF017;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 
        ///回写油漆工段对应批号产品实际完工时间
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        /// <param name="work"></param>
        void edit_BL_OverTime ( CarpenterEntity . ProductionPaintDayDailyEntity _model ,StringBuilder strSql ,Hashtable SQLString ,string work )
        {
            strSql = new StringBuilder ( );
            if ( work.Equals( ColumnValues.yq_dq ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP008=ISNULL(PDP008,0)-{0},PDP009=ISNULL(PDP009,0)+{0},PDP010='{1}' WHERE PDP001='{2}' AND PDP002='{3}'" ,_model . PWF007 ,_model . PWF012 ,_model . PWF002 ,_model . PWF003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( work . Equals ( ColumnValues . yq_ym ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP011=ISNULL(PDP011,0)-{0},PDP012=ISNULL(PDP012,0)+{0},PDP013='{1}' WHERE PDP001='{2}' AND PDP002='{3}'" ,_model . PWF008 ,_model . PWF012 ,_model . PWF002 ,_model . PWF003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( work . Equals ( ColumnValues . yq_xs ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP014=ISNULL(PDP014,0)-{0},PDP015=ISNULL(PDP015,0)+{0},PDP016='{1}' WHERE PDP001='{2}' AND PDP002='{3}'" ,_model . PWF009 ,_model . PWF012 ,_model . PWF002 ,_model . PWF003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( work . Equals ( ColumnValues . yq_mq ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP017=ISNULL(PDP017,0)-{0},PDP018=ISNULL(PDP018,0)+{0},PDP019='{1}' WHERE PDP001='{2}' AND PDP002='{3}'" ,_model . PWF010 ,_model . PWF012 ,_model . PWF002 ,_model . PWF003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            //if ( work . Equals ( ColumnValues . yq_rb ) )
            //{
            //    strSql . AppendFormat ( "UPDATE MOXPDP SET PDP020=ISNULL(PDP020,0)+'{0}',PDP021='{1}' WHERE PDP001='{2}' AND PDP002='{3}'" ,_model . PWF011 ,_model . PWF012 ,_model . PWF002 ,_model . PWF003 );
            //    SQLString . Add ( strSql ,null );
            //    strSql = new StringBuilder ( );
            //}
            if ( work . Equals ( ColumnValues . yq_bz ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP028=ISNULL(PDP028,0)-{0},PDP022=ISNULL(PDP022,0)+{0},PDP023='{1}' WHERE PDP001='{2}' AND PDP002='{3}'" ,_model . PWF016 ,_model . PWF012 ,_model . PWF002 ,_model . PWF003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
        }

        /// <summary>
        /// 回写油漆工段对应批号产品实际完工时间   非计划产品
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        /// <param name="work"></param>
        void edit_BL_OverTime_NoPlan ( CarpenterEntity . ProductionPaintDayDailyEntity _model ,StringBuilder strSql ,Hashtable SQLString ,string work )
        {
            strSql = new StringBuilder ( );
            if ( work . Equals ( ColumnValues . yq_dq ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP009=ISNULL(PDP009,0)+{0},PDP010='{1}' WHERE PDP001='{2}' AND PDP002='{3}'" ,_model . PWF007 ,_model . PWF012 ,_model . PWF002 ,_model . PWF003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( work . Equals ( ColumnValues . yq_ym ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP012=ISNULL(PDP012,0)+{0},PDP013='{1}' WHERE PDP001='{2}' AND PDP002='{3}'" ,_model . PWF008 ,_model . PWF012 ,_model . PWF002 ,_model . PWF003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( work . Equals ( ColumnValues . yq_xs ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP015=ISNULL(PDP015,0)+{0},PDP016='{1}' WHERE PDP001='{2}' AND PDP002='{3}'" ,_model . PWF009 ,_model . PWF012 ,_model . PWF002 ,_model . PWF003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( work . Equals ( ColumnValues . yq_mq ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP018=ISNULL(PDP018,0)+{0},PDP019='{1}' WHERE PDP001='{2}' AND PDP002='{3}'" ,_model . PWF010 ,_model . PWF012 ,_model . PWF002 ,_model . PWF003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            //if ( work . Equals ( ColumnValues . yq_rb ) )
            //{
            //    strSql . AppendFormat ( "UPDATE MOXPDP SET PDP020=ISNULL(PDP020,0)+'{0}',PDP021='{1}' WHERE PDP001='{2}' AND PDP002='{3}'" ,_model . PWF011 ,_model . PWF012 ,_model . PWF002 ,_model . PWF003 );
            //    SQLString . Add ( strSql ,null );
            //    strSql = new StringBuilder ( );
            //}
            if ( work . Equals ( ColumnValues . yq_bz ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP022=ISNULL(PDP022,0)+{0},PDP023='{1}' WHERE PDP001='{2}' AND PDP002='{3}'" ,_model . PWF016 ,_model . PWF012 ,_model . PWF002 ,_model . PWF003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
        }

        /// <summary>
        /// 日计划中是否存在此批号和品号
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        bool Exists_bl_day ( string weekEnds ,string productNum ,int [ ] nums )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PWD002,SUM(PWE007) PWE007 FROM MOXPWE A INNER JOIN MOXPWD B ON A.PWE001=B.PWD001 " );
            strSql . Append ( "WHERE PWE003=@PWE003 AND PWE004=@PWE004 " );
            strSql . Append ( "GROUP BY PWD002,PWE003,PWE004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWE003",SqlDbType.NVarChar,20),
                new SqlParameter("@PWE004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PWD002" ] . ToString ( ) ) )
                    return false;
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PWE007" ] . ToString ( ) ) )
                    return false;
                string procedure = da . Rows [ 0 ] [ "PWD002" ] . ToString ( );
                int num = Convert . ToInt32 ( da . Rows [ 0 ] [ "PWE007" ] . ToString ( ) );
                if ( procedure . Equals ( ColumnValues . yq_dq ) )
                {
                    if ( num == nums [ 0 ] )
                        return true;
                    else
                        return false;
                }
                else if ( procedure . Equals ( ColumnValues . yq_ym ) )
                {
                    if ( num == nums [ 0 ] )
                        return true;
                    else
                        return false;
                }
                else if ( procedure . Equals ( ColumnValues . yq_xs ) )
                {
                    if ( num == nums [ 0 ] )
                        return true;
                    else
                        return false;
                }
                else if ( procedure . Equals ( ColumnValues . yq_mq ) )
                {
                    if ( num == nums [ 0 ] )
                        return true;
                    else
                        return false;
                }
                else if ( procedure . Equals ( ColumnValues . yq_rb ) )
                {
                    if ( num == nums [ 0 ] )
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 编辑完工标记
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="plan"></param>
        void edit_bl_day ( string weekEnds ,string productNum ,Hashtable SQLString ,StringBuilder strSql ,bool plan )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPWE SET " );
            strSql . Append ( "PWE011=1 " );
            if ( plan )
                strSql . Append ( "WHERE PWE003=@PWE003 AND PWE004=@PWE004 AND PWE012=1" );
            else
                strSql . Append ( "WHERE PWE003=@PWE003 AND PWE004=@PWE004 AND PWE012=0" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWE003",SqlDbType.NVarChar,20),
                new SqlParameter("@PWE004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            SQLString . Add ( strSql ,parameter );
        }

    }
}
