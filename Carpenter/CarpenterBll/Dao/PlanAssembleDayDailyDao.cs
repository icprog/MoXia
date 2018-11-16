using System;
using System . Collections . Generic;
using System . Data;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class PlanAssembleDayDailyDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string columnName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM MOXPLF ORDER BY {0} DESC" ,columnName );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Delete ( List<string> strList )
        {
            Hashtable SQLString = new Hashtable ( );
            string idxStr = string . Empty;
            foreach ( string s in strList )
            {
                if ( idxStr == string . Empty )
                    idxStr = s;
                else
                    idxStr = idxStr + "," + s;
            }

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLF002,PLF003,PLF006,SUM(PLF007) PLF007,PLF015 FROM MOXPLF " );
            strSql . AppendFormat ( "WHERE idx IN ({0}) " ,idxStr );
            strSql . Append ( "GROUP BY PLF002,PLF003,PLF006,PLF015" );
            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                CarpenterEntity . PlanAssemebleDayDailyEntity _model = new CarpenterEntity . PlanAssemebleDayDailyEntity ( );
                int x = 0;DateTime? dateT = null;
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _model . PLF002 = dt . Rows [ i ] [ "PLF002" ] . ToString ( );
                    _model . PLF003 = dt . Rows [ i ] [ "PLF003" ] . ToString ( );
                    _model . PLF006 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PLF006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PLF006" ] . ToString ( ) );
                    _model . PLF007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PLF007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PLF007" ] . ToString ( ) );
                    _model . PLF015 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PLF015" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( dt . Rows [ i ] [ "PLF015" ] . ToString ( ) );
                    if ( _model . PLF015 == false )
                    {
                        x = getPas ( _model );
                        _model . PLF007 = x - _model . PLF007;
                        if ( _model . PLF007 >= 0 )
                        {
                            if ( _model . PLF007 > 0 )
                            {
                                if ( getPlf ( _model ,idxStr ) )
                                    dateT = getPlfT ( _model ,idxStr );
                                else
                                    dateT = null;
                            }
                            else if ( _model . PLF007 == 0 )
                                dateT = null;
                            edit_pas ( _model ,SQLString ,strSql ,dateT );
                        }

                        edit_awq ( SQLString ,strSql ,_model );
                    }

                    //x = getPrs ( _model );
                    //_model . PLF007 = x - _model . PLF007;
                    //if ( _model . PLF007 >= 0 )
                    //{
                    //    if ( _model . PLF007 > 0 )
                    //    {
                    //        if ( getPlf ( _model ,idxStr ) )
                    //            dateT = getPlfT ( _model ,idxStr );
                    //        else
                    //            dateT = null;
                    //    }
                    //    else if ( _model . PLF007 == 0 )
                    //        dateT = null;
                    //    edit_prs ( _model ,SQLString ,strSql ,dateT );
                    //}
                }
            }

            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPLF " );
            strSql . Append ( "WHERE idx IN (" + idxStr + ")" );
            SQLString . Add ( strSql ,null );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取跟踪表完工数量
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        int getPas ( CarpenterEntity . PlanAssemebleDayDailyEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PAS011 FROM MOXPAS WHERE PAS001='{0}' AND PAS002='{1}'" ,_model . PLF002 ,_model . PLF003 );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PAS011" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToInt32 ( dt . Rows [ 0 ] [ "PAS011" ] . ToString ( ) );
            }
            else
                return 0;
        }

        /// <summary>
        /// 是否有完工时间
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="idxStr"></param>
        /// <returns></returns>
        bool getPlf ( CarpenterEntity . PlanAssemebleDayDailyEntity _model,string idxStr )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MAX(PLF012) PLF012 FROM MOXPLF WHERE idx NOT IN ({0}) AND PLF001='{1}' AND PLF002='{2}'" ,idxStr ,_model . PLF002 ,_model . PLF003 );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PLF012" ] . ToString ( ) ) )
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 获取最大的报工时间
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="idxStr"></param>
        /// <returns></returns>
        DateTime getPlfT ( CarpenterEntity . PlanAssemebleDayDailyEntity _model ,string idxStr )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MAX(PLF012) PLF012 FROM MOXPLF WHERE idx NOT IN ({0}) AND PLF001='{1}' AND PLF002='{2}'" ,idxStr ,_model . PLF002 ,_model . PLF003 );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PLF012" ] . ToString ( ) ) )
                    return UserInformation . dt ( );
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "PLF012" ] . ToString ( ) );
            }
            else
                return UserInformation . dt ( );
        }

        /// <summary>
        /// 编辑跟踪表完工数量和完工时间
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="dateT"></param>
        void edit_pas ( CarpenterEntity . PlanAssemebleDayDailyEntity _model ,Hashtable SQLString ,StringBuilder strSql ,DateTime? dateT )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPAS SET " );
            strSql . Append ( "PAS011=@PAS011," );
            strSql . Append ( "PAS012=@PAS012 " );
            strSql . Append ( "WHERE PAS001=@PAS001 AND PAS002=@PAS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PAS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PAS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PAS011",SqlDbType.Int),
                new SqlParameter("@PAS012",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . PLF002;
            parameter [ 1 ] . Value = _model . PLF003;
            parameter [ 2 ] . Value = _model . PLF007;
            parameter [ 3 ] . Value = dateT;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 获取总跟踪表完工数量
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        int getPrs ( CarpenterEntity . PlanAssemebleDayDailyEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PRS012 FROM MOXPRS WHERE PRS001='{0}' AND PRS002='{1}'" ,_model . PLF002 ,_model . PLF003 );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PRS012" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToInt32 ( dt . Rows [ 0 ] [ "PRS012" ] . ToString ( ) );
            }
            else
                return 0;
        }

        /// <summary>
        /// 编辑总跟踪表完工数量和完工时间
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="dateT"></param>
        void edit_prs ( CarpenterEntity . PlanAssemebleDayDailyEntity _model ,Hashtable SQLString ,StringBuilder strSql ,DateTime? dateT )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPRS SET " );
            strSql . Append ( "PRS012=@PRS012," );
            strSql . Append ( "PRS013=@PRS013 " );
            strSql . Append ( "WHERE PRS001=@PRS001 AND PRS002=@PRS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PRS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS012",SqlDbType.Int),
                new SqlParameter("@PRS013",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . PLF002;
            parameter [ 1 ] . Value = _model . PLF003;
            parameter [ 2 ] . Value = _model . PLF007;
            parameter [ 3 ] . Value = dateT;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 编辑派工单的完工时间为空
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="_model"></param>
        void edit_awq ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanAssemebleDayDailyEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXAWO SET AWO004=NULL WHERE AWO001 IN (SELECT AWQ001 FROM MOXAWQ WHERE AWQ002='{0}' AND AWQ003='{1}')" ,_model . PLF002 ,_model . PLF003 );

            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,PLF001,PLF002,PLF003,PLF004,PLF005,PAS016,PLF006,PLF007,CONVERT(FLOAT,ISNULL(OPI004,0)) OPI004,CONVERT(FLOAT,PLF007*ISNULL(OPI004,0)) U0,PLF008,PLF009,PLF010,PLF012,OPI006,OPI007,CASE PLF015 WHEN 0 THEN '正式' ELSE '预排' END PLF015,PLF016,PLF014 FROM MOXPLF A LEFT JOIN MOXOPI B ON A.PLF003=B.OPI001 INNER JOIN MOXPAS C ON A.PLF002=C.PAS001 AND A.PLF003=C.PAS002 " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( "ORDER BY PLF001 DESC,PLF002 DESC,PLF003 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableDWPerson ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PLF014 FROM MOXPLF" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="workShop"></param>
        /// <param name="dateTime"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string workShop ,string dateTime ,string person )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT PLF002,PLF003,PLF004,OPI006,PLE008,PLF007,PAS016 FROM MOXPLF A INNER JOIN MOXPLE B ON A.PLF002=B.PLE003 AND A.PLF003=B.PLE004 AND A.PLF010=B.PLE001 INNER JOIN MOXOPI C ON A.PLF003=C.OPI001 INNER JOIN MOXPLD D ON B.PLE001=D.PLD001 INNER JOIN MOXPAS E ON A.PLF002=E.PAS001 AND A.PLF003=E.PAS002  " );
            strSql . AppendFormat ( "WHERE PLF012='{0}' AND PLF014='{1}' AND PLD002='{2}' AND PLE012=0 " ,dateTime ,person ,workShop );
            strSql . Append ( " UNION ALL " );
            strSql . AppendFormat ( "SELECT PLF002,PLF003,PLF004,OPI006,CUU005 PLE008,PLF007,PAS016 FROM MOXPLF A INNER JOIN MOXOPI C ON A.PLF003=C.OPI001 INNER JOIN MOXPAS E ON A.PLF002=E.PAS001 AND A.PLF003=E.PAS002 INNER JOIN MOXCUU ON PLF002=CUU001 AND PLF003=CUU002 WHERE PLF012='{0}' AND PLF014='{1}' AND PLF010=''" ,dateTime ,person );
            strSql . Append ( "),CFT AS (" );
            strSql . AppendFormat ( "SELECT A.PLF002,A.PLF003,SUM(A.PLF007) PLF007 FROM MOXPLF A INNER JOIN CET B ON A.PLF002=B.PLF002 AND A.PLF003=B.PLF003 WHERE PLF012<'{0}' GROUP BY A.PLF002,A.PLF003)  " ,dateTime );
            strSql . Append ( "SELECT A.*,ISNULL(B.PLF007,0) PLFSUM,A.PAS016-A.PLF007-ISNULL(B.PLF007,0) RES FROM CET A LEFT JOIN CFT B ON A.PLF002=B.PLF002 AND A.PLF003=B.PLF003 ORDER BY A.PLF002,A.PLF003" );

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
            strSql . Append ( "SELECT PLF012,PLF014,PLD002,CONVERT(FLOAT,SUM(PLE007*OPI004)) PLE FROM MOXPLF A INNER JOIN MOXPLE B ON A.PLF002=B.PLE003 AND A.PLF003=B.PLE004 AND A.PLF010=B.PLE001 INNER JOIN MOXOPI C ON A.PLF003=C.OPI001 INNER JOIN MOXPLD D ON B.PLE001=D.PLD001 " );
            strSql . AppendFormat ( "WHERE PLF012='{0}' AND PLF014='{1}' AND PLD002='{2}' " ,dateTime ,person ,workShop );
            strSql . Append ( "GROUP BY PLF012,PLF014,PLD002" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取派工报工清单
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( List<string> inList )
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
            strSql . Append ( "WITH CET AS (SELECT PAS001,PAS002,PAS003,PAS004,PAS016,OPI006,OPI007,AWQ006,AWQ009,AWQ001 FROM MOXPAS A LEFT JOIN MOXOPI C ON A.PAS002=C.OPI001 INNER JOIN MOXPLE D ON A.PAS001=D.PLE003 AND A.PAS002=D.PLE004 INNER JOIN MOXPLD E ON D.PLE001=E.PLD001 INNER JOIN MOXAWQ F ON D.PLE003=F.AWQ002 AND D.PLE004=F.AWQ003 INNER JOIN MOXAWO G ON F.AWQ001=G.AWO001 LEFT JOIN MOXPLF H ON H.PLF002=F.AWQ002 AND H.PLF003=F.AWQ003 AND H.PLF008=F.AWQ009 AND H.PLF016=F.AWQ001 " );
            strSql . Append ( "WHERE A.idx IN (" + str + ") AND PLD006=1 AND PLE012=0 AND PLE002='完工' AND AWO005=1 " );
            strSql . Append ( "GROUP BY PAS001,PAS002,PAS003,PAS004,PAS016,OPI006,OPI007,AWQ006,AWQ009,AWQ001 " );
            strSql . Append ( "HAVING SUM(ISNULL(PLF007,0))<AWQ006) " );
            strSql . Append ( "SELECT DISTINCT PAS001,PAS002,PAS003,PAS004,PAS016,OPI006,OPI007 FROM CET" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取派工计划报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlan ( List<string> inList )
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
            strSql . Append ( "WITH CET AS (SELECT PAS001,PAS002,PAS003,PAS004,PAS016,OPI006,OPI007,AWQ006,AWQ009,AWQ001 FROM MOXPAS A LEFT JOIN MOXOPI C ON A.PAS002=C.OPI001 INNER JOIN MOXPLE D ON A.PAS001=D.PLE003 AND A.PAS002=D.PLE004 INNER JOIN MOXPLD E ON D.PLE001=E.PLD001 INNER JOIN MOXAWQ F ON D.PLE003=F.AWQ002 AND D.PLE004=F.AWQ003 INNER JOIN MOXAWO G ON F.AWQ001=G.AWO001 LEFT JOIN MOXPLF H ON H.PLF002=F.AWQ002 AND H.PLF003=F.AWQ003 AND H.PLF008=F.AWQ009 AND H.PLF016=F.AWQ001 " );
            strSql . Append ( "WHERE A.idx IN (" + str + ") AND PLD006=1 AND (PLE012=1 OR PLE002='未完工') AND AWO005=1 " );
            strSql . Append ( "GROUP BY PAS001,PAS002,PAS003,PAS004,PAS016,OPI006,OPI007,AWQ006,AWQ009,AWQ001 " );
            strSql . Append ( "HAVING SUM(ISNULL(PLF007,0))<AWQ006) " );
            strSql . Append ( "SELECT DISTINCT PAS001,PAS002,PAS003,PAS004,PAS016,OPI006,OPI007 FROM CET" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 组装派工报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ZDailyWork ( DataTable table ,bool plan ,Hashtable hasTable,DateTime dt)
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . PlanAssemebleDayDailyEntity _model = new CarpenterEntity . PlanAssemebleDayDailyEntity ( );
            _model . PLF001 = GetDataTableDailyWorkOddNum ( );
            _model . PLF013 = UserInformation . dt ( );
            _model . PLF014 = UserInformation . UserName;
            _model . PLF015 = plan;
            _model . PLF012 = dt;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . PLF002 = table . Rows [ i ] [ "PAS001" ] . ToString ( );
                _model . PLF003 = table . Rows [ i ] [ "PAS002" ] . ToString ( );
                _model . PLF004 = table . Rows [ i ] [ "PAS003" ] . ToString ( );
                _model . PLF005 = table . Rows [ i ] [ "PAS004" ] . ToString ( );
                _model . PLF006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PAS016" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PAS016" ] . ToString ( ) );
                if ( hasTable . ContainsKey ( _model . PLF002 + _model . PLF003 ) )
                {
                    DataTable tableOne = ( DataTable ) hasTable [ _model . PLF002 + _model . PLF003 ];
                    for ( int k = 0 ; k < tableOne . Rows . Count ; k++ )
                    {
                        _model . PLF007 = string . IsNullOrEmpty ( tableOne . Rows [ k ] [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOne . Rows [ k ] [ "DL" ] . ToString ( ) );
                        _model . PLF008 = tableOne . Rows [ k ] [ "AWQ009" ] . ToString ( );
                        _model . PLF009 = tableOne . Rows [ k ] [ "AWQ010" ] . ToString ( );
                        _model . PLF016 = tableOne . Rows [ k ] [ "AWQ001" ] . ToString ( );
                        _model . PLF010 = string . Empty;
                        _model . PLF017 = string . Empty;
                        if ( _model . PLF007 != 0 )
                            edit_BL_DailyWork ( _model ,strSql ,SQLString );

                        edit_BL_OverTime ( _model ,strSql ,SQLString );
                        //若报工总数量=生产数量  则回写完工时间到组装跟踪表的对应工段完工时间和完成数量
                        _model . PLF007 = string . IsNullOrEmpty ( tableOne . Rows [ k ] [ "PLF007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOne . Rows [ k ] [ "PLF007" ] . ToString ( ) );
                        _model . PLF007 = _model . PLF007 + ( string . IsNullOrEmpty ( tableOne . Compute ( "SUM(DL)" ,null ) . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOne . Compute ( "SUM(DL)" ,null ) . ToString ( ) ) );
                        //if ( _model . PLF006 == _model . PLF007 )
                        if ( Exists_bl_day ( _model . PLF002 ,_model . PLF003 ,new int [ ] { _model . PLF007 } ) == true )
                            edit_bl_day ( _model . PLF002 ,_model . PLF003 ,SQLString ,strSql ,plan );
                    }
                }
            }
            
            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取组装报工的单号
        /// </summary>
        /// <returns></returns>
        string GetDataTableDailyWorkOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(PLF001) PLF001 FROM MOXPLF" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PLF001" ] . ToString ( ) ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PLF001" ] . ToString ( ) . Substring ( 0 ,8 ) == UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PLF001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        /// <summary>
        /// 插入报工记录
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_BL_DailyWork ( CarpenterEntity . PlanAssemebleDayDailyEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPLF (" );
            strSql . Append ( "PLF001,PLF002,PLF003,PLF004,PLF005,PLF006,PLF007,PLF008,PLF009,PLF010,PLF012,PLF013,PLF014,PLF015,PLF016,PLF017) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PLF001,@PLF002,@PLF003,@PLF004,@PLF005,@PLF006,@PLF007,@PLF008,@PLF009,@PLF010,@PLF012,@PLF013,@PLF014,@PLF015,@PLF016,@PLF017) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLF001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLF002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLF003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLF004",SqlDbType.NVarChar,20),
                new SqlParameter("@PLF005",SqlDbType.NVarChar,20),
                new SqlParameter("@PLF006",SqlDbType.Int),
                new SqlParameter("@PLF007",SqlDbType.Int),
                new SqlParameter("@PLF008",SqlDbType.NVarChar,20),
                new SqlParameter("@PLF009",SqlDbType.NVarChar,20),
                new SqlParameter("@PLF012",SqlDbType.Date),
                new SqlParameter("@PLF013",SqlDbType.Date),
                new SqlParameter("@PLF014",SqlDbType.NVarChar,20),
                new SqlParameter("@PLF015",SqlDbType.Bit),
                new SqlParameter("@PLF016",SqlDbType.NVarChar,20),
                new SqlParameter("@PLF010",SqlDbType.NVarChar,20),
                new SqlParameter("@PLF017",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PLF001;
            parameter [ 1 ] . Value = _model . PLF002;
            parameter [ 2 ] . Value = _model . PLF003;
            parameter [ 3 ] . Value = _model . PLF004;
            parameter [ 4 ] . Value = _model . PLF005;
            parameter [ 5 ] . Value = _model . PLF006;
            parameter [ 6 ] . Value = _model . PLF007;
            parameter [ 7 ] . Value = _model . PLF008;
            parameter [ 8 ] . Value = _model . PLF009;
            parameter [ 9 ] . Value = _model . PLF012;
            parameter [ 10 ] . Value = _model . PLF013;
            parameter [ 11 ] . Value = _model . PLF014;
            parameter [ 12 ] . Value = _model . PLF015;
            parameter [ 13 ] . Value = _model . PLF016;
            parameter [ 14 ] . Value = _model . PLF010;
            parameter [ 15 ] . Value = _model . PLF017;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 回写组装工段对应批号产品实际完工时间
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_BL_OverTime ( CarpenterEntity . PlanAssemebleDayDailyEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXPAS SET PAS012='{0}',PAS011=ISNULL(PAS011,0)+'{3}' WHERE PAS001='{1}' AND PAS002='{2}'" ,_model . PLF012 ,_model . PLF002 ,_model . PLF003 ,_model . PLF007 );
            SQLString . Add ( strSql ,null );
            //strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "UPDATE MOXPRS SET PRS013='{0}',PRS012='{3}' WHERE PRS001='{1}' AND PRS002='{2}'" ,_model . PLF012 ,_model . PLF002 ,_model . PLF003 ,_model . PLF007 );
            //SQLString . Add ( strSql ,null );
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
            strSql . Append ( "SELECT SUM(PLE007) PLE007 FROM MOXPLE A INNER JOIN MOXPLD B ON A.PLE001=B.PLD001 " );
            strSql . Append ( "WHERE PLE003=@PLE003 AND PLE004=@PLE004 " );
            strSql . Append ( "GROUP BY PLE003,PLE004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLE003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLE004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PLE007" ] . ToString ( ) ) )
                    return false;
                int num = Convert . ToInt32 ( da . Rows [ 0 ] [ "PLE007" ] . ToString ( ) );
                if ( num == nums [ 0 ] )
                    return true;
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
            strSql . Append ( "UPDATE MOXPLE SET " );
            strSql . Append ( "PLE011=1 " );
            if ( plan )
                strSql . Append ( "WHERE PLE003=@PLE003 AND PLE004=@PLE004 AND PLE012=1" );
            else
                strSql . Append ( "WHERE PLE003=@PLE003 AND PLE004=@PLE004 AND PLE012=0" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLE003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLE004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 获取组装日计划明细
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableZ ( string weekEnds ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLD001 workShopSection,PLD003 PlanTime,PLE007 Remark,PLE008 commen,'组装' workshop FROM MOXPLD A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001   " );
            strSql . AppendFormat ( "WHERE  PLE003='{0}' AND PLE004='{1}' AND PLD005=0  " ,weekEnds ,productNum );
            strSql . Append ( "ORDER BY PLD002,PLD003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取组装日计划报工信息
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableZB ( string weekEnds,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PLF001 workShopSection,PLF012 PlanTime,PLF007 Remark,PLE008 commen FROM MOXPLF  A LEFT JOIN MOXPLE B ON A.PLF010=B.PLE001 AND A.PLF002=B.PLE003 AND A.PLF003=B.PLE004 WHERE PLF002='{0}' AND PLF003='{1}' ORDER BY PLF001,PLF012 " ,weekEnds ,productNum );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取日计划报工记录  常规
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTableDaily ( List<string> inList )
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
            strSql . AppendFormat ( "SELECT PLE001,B.PLE003 PST001,B.PLE004 PST002,PLE005 PST003,PLE007,SUM(ISNULL(PLF007,0)) PLF007,PLE007-SUM(ISNULL(PLF007,0)) DL,GETDATE() PLF012,OPI005 PST004,PLE013 FROM (SELECT MAX(PLD001) PLD001,PLD006,PLE003,PLE004 FROM MOXPLD A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001 INNER JOIN MOXPAS C ON B.PLE003=C.PAS001 AND B.PLE004=C.PAS002 WHERE C.idx IN({0}) GROUP BY PLD006,PLE003,PLE004) A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001 LEFT JOIN MOXPLF C ON C.PLF002=B.PLE003 AND C.PLF003=B.PLE004 AND C.PLF010=B.PLE001 AND C.PLF017=B.PLE013 LEFT JOIN MOXOPI D ON B.PLE004=D.OPI001  INNER JOIN MOXPAS E ON B.PLE003=E.PAS001 AND B.PLE004=E.PAS002 " ,str );
            strSql . AppendFormat ( "WHERE E.idx IN ({0}) AND PLD006=1 AND PLE012=0 " ,str );
            strSql . AppendFormat ( "GROUP BY PLE001,B.PLE003,B.PLE004,PLE005,OPI005,PLE007,PLE013 " );
            strSql . AppendFormat ( "HAVING SUM(ISNULL(PLF007,0))<PLE007 ORDER BY PST001,PST002" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取日计划报工记录  非常规
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTableDailyOnley ( List<string> inList )
        {
            string str = string . Join ( "," ,inList . ToArray ( ) );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT '' PLE001,'' PLE013,PAS001 PST001,PAS002 PST002,PAS003 PST003,PAS016 PLE007,SUM(ISNULL(PLF007,0)) PLF007,PAS016-SUM(ISNULL(PLF007,0)) DL,GETDATE() PLF012,OPI005 PST004 FROM MOXPAS A INNER JOIN MOXOPI B ON A.PAS002=B.OPI001 LEFT JOIN MOXPLF C ON A.PAS001=C.PLF002 AND A.PAS002=C.PLF003 WHERE A.idx IN ({0}) GROUP BY PAS001,PAS002,PAS003,PAS016,OPI005 HAVING SUM(ISNULL(PLF007,0))<PAS016 ORDER BY PST001,PST002" ,str );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取日计划预排报工记录
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTableDailyPlan ( List<string> inList )
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
            //(SELECT MAX(PLD001) PLD001,PLD006 FROM MOXPLD GROUP BY PLD006)
            //strSql . Append ( "SELECT PLE001,PLE003 PST001,PLE004 PST002,PLE005 PST003,PLE007,SUM(ISNULL(PLF007,0)) PLF007,PLE007-SUM(ISNULL(PLF007,0)) DL,PLF012,OPI005 PST004,PLE013 FROM MOXPLD A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001 LEFT JOIN MOXPLF C ON C.PLF002=B.PLE003 AND C.PLF003=B.PLE004 AND C.PLF010=B.PLE001 AND C.PLF017=B.PLE013 LEFT JOIN MOXOPI D ON B.PLE004=D.OPI001 INNER JOIN MOXPAS E ON B.PLE003=E.PAS001 AND B.PLE004=E.PAS002 " );
            //strSql . AppendFormat ( "WHERE E.idx IN ({0}) AND PLD006=1 AND PLE012=1 " ,str );
            //strSql . AppendFormat ( "GROUP BY PLE001,PLE003,PLE004,PLE005,PLF012,OPI005,PLE007,PLE013 " );
            //strSql . AppendFormat ( "HAVING SUM(ISNULL(PLF007,0))<PLE007 ORDER BY PST001,PST002" );

            strSql . AppendFormat ( "SELECT PLE001,PLE003 PST001,PLE004 PST002,PLE005 PST003,PLE007,SUM(ISNULL(PLF007,0)) PLF007,PLE007-SUM(ISNULL(PLF007,0)) DL,GETDATE()  PLF012,OPI005 PST004,PLE013 FROM (SELECT MAX(PLD001) PLD001 FROM MOXPLD A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001 INNER JOIN MOXPAS C ON PLE003=C.PAS001 AND PLE004=C.PAS002 WHERE PLD006='1' AND C.idx IN ({0}) GROUP BY PAS001,PAS002) A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001 LEFT JOIN MOXPLF C ON C.PLF002=B.PLE003 AND C.PLF003=B.PLE004 AND C.PLF010=B.PLE001 AND C.PLF017=B.PLE013 LEFT JOIN MOXOPI D ON B.PLE004=D.OPI001 INNER JOIN MOXPAS E ON B.PLE003=E.PAS001 AND B.PLE004=E.PAS002 WHERE E.idx IN ({0}) AND PLE012=1 GROUP BY PLE003,PLE004,PLE005,OPI005,PLE007,PLE013,PLE001 HAVING SUM(ISNULL(PLF007,0))<PLE007 ORDER BY PST001,PST002" ,str );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 组装报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="plan"></param>
        /// <returns></returns>
        public bool ZDayDailyWork ( DataTable table,bool plan )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . PlanAssemebleDayDailyEntity _model = new CarpenterEntity . PlanAssemebleDayDailyEntity ( );
            _model . PLF001 = GetDataTableDailyWorkOddNum ( );
            _model . PLF013 = UserInformation . dt ( );
            _model . PLF014 = UserInformation . UserName;
            _model . PLF015 = plan;


            List<string> strList = new List<string> ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . PLF002 = table . Rows [ i ] [ "PST001" ] . ToString ( );
                _model . PLF003 = table . Rows [ i ] [ "PST002" ] . ToString ( );
                _model . PLF004 = table . Rows [ i ] [ "PST003" ] . ToString ( );
                _model . PLF005 = table . Rows [ i ] [ "PST004" ] . ToString ( );
                _model . PLF006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PLE007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PLE007" ] . ToString ( ) );
                _model . PLF007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DL" ] . ToString ( ) );
                _model . PLF008 = _model . PLF009 = _model . PLF016 = string . Empty;              
                _model . PLF012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PLF012" ] . ToString ( ) ) == true ? UserInformation . dt ( ) : Convert . ToDateTime ( table . Rows [ i ] [ "PLF012" ] . ToString ( ) );
                _model . PLF010 = table . Rows [ i ] [ "PLE001" ] . ToString ( );
                _model . PLF017 = table . Rows [ i ] [ "PLE013" ] . ToString ( );
                if ( _model . PLF007 != 0 )
                    edit_BL_DailyWork ( _model ,strSql ,SQLString );

                if ( _model . PLF015 == false )
                {
                    if ( ExistsOk ( _model . PLF002 ,_model . PLF003 ,_model . PLF007 ) )
                        edit_zz_pg ( SQLString ,strSql ,_model );
                }

                if ( _model . PLF015 == false )
                    edit_BL_OverTime ( _model ,strSql ,SQLString );

                //若报工总数量=生产数量  则回写完工时间到组装跟踪表的对应工段完工时间和完成数量
                _model . PLF007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PLF007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PLF007" ] . ToString ( ) );
                _model . PLF007 = _model . PLF007 + ( string . IsNullOrEmpty ( table . Compute ( "SUM(DL)" ,"PST001='" + _model . PLF002 + "' AND PST002='" + _model . PLF003 + "'" ) . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Compute ( "SUM(DL)" ,"PST001='" + _model . PLF002 + "' AND PST002='" + _model . PLF003 + "'" ) . ToString ( ) ) );
                //if ( _model . PLF006 == _model . PLF007 )
               

                if ( Exists_bl_day ( _model . PLF002 ,_model . PLF003 ,new int [ ] { _model . PLF007 } ) == true )
                    edit_bl_day ( _model . PLF002 ,_model . PLF003 ,SQLString ,strSql ,plan );
                

                if ( !ExistsPai ( _model . PLF002 ,_model . PLF003 ) )
                {
                    strList . Add ( _model . PLF003 );
                }

            }
            if ( strList . Count > 0 )
                UserInformation . ZPai = strList;

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 是否派工
        /// </summary>
        /// <param name="piNum"></param>
        /// <param name="pingNum"></param>
        /// <returns></returns>
        bool ExistsPai ( string piNum,string pingNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXAWQ WHERE AWQ002='{0}' and AWQ003='{1}'" ,piNum ,pingNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 报工数量是否等于订单数量
        /// </summary>
        /// <param name="piNum"></param>
        /// <param name="pingNum"></param>
        /// <returns></returns>
        bool ExistsOk ( string piNum,string pingNum,int num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM (SELECT PLF002,PLF003,SUM(ISNULL(PLF007,0)) PLF007 FROM MOXPLF WHERE PLF015=0 AND PLF002='{0}' AND PLF003='{1}'  GROUP BY PLF002,PLF003) A RIGHT JOIN MOXPAS B ON A.PLF002=B.PAS001 AND A.PLF003=B.PAS002 WHERE PAS001='{0}' AND PAS002='{1}' GROUP BY PAS016,ISNULL(PLF007,0) HAVING PAS016=ISNULL(PLF007,0)+{2} " ,piNum ,pingNum ,num );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 编辑派工单的完工时间
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="_model"></param>
        void edit_zz_pg ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanAssemebleDayDailyEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXAWO SET AWO004='{0}' WHERE AWO001 IN (SELECT AWQ001 FROM MOXAWQ WHERE AWQ002='{1}' AND AWQ003='{2}' )" ,_model . PLF012 ,_model . PLF002 ,_model . PLF003 );

            SQLString . Add ( strSql ,null );
        }

    }
}
