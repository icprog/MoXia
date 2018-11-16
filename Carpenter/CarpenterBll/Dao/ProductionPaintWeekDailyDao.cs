using StudentMgr;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Text;

namespace CarpenterBll . Dao
{
    public class ProductionPaintWeekDailyDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public DataTable GetOnly ( string columnName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM MOXPWI ORDER BY {0}" ,columnName );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Delete ( List<string> strList )
        {
            string idxList = string . Empty;
            foreach ( string s in strList )
            {
                if ( idxList == string . Empty )
                    idxList = s;
                else
                    idxList = idxList + "," + s;
            }
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPWI " );
            strSql . Append ( "WHERE idx IN (" + idxList + ")" );

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,PWI001,PWI002,PWI003,PWI004,PWI005,PWI006,PWI007,PWI012,OPI006,OPI007,CASE PWI008 WHEN 0 THEN '正式' ELSE '预排' END PWI008,PWI009 FROM MOXPWI A LEFT JOIN MOXOPI B ON A.PWI003=B.OPI001 " );
            strSql . Append ( " WHERE " + strWhere );
            strSql . Append ( " ORDER BY PWI001 DESC,PWI002 DESC,PWI003 DESC " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

        }

        /// <summary>
        /// 获取年
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableYear ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT SUBSTRING(PWI001,0,5) PWI001 FROM MOXPWI" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取操作者
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePerson ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PWI014 FROM MOXPWI" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取周次
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableWeek ( string year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PWG009 FROM MOXPWI A INNER JOIN MOXPWH B ON A.PWI002=B.PWH003 AND A.PWI003=B.PWH004 INNER JOIN MOXPWG C ON B.PWH001=C.PWG001  " );
            strSql . AppendFormat ( "WHERE PWI001 LIKE '{0}%'" ,year );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string year ,string week ,string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PWG009,PWI014,SUM(PWH007*OPI004) PSX FROM MOXPWI A INNER JOIN MOXPWH B ON A.PWI002=B.PWH003 AND A.PWI003=B.PWH004 INNER JOIN MOXOPI C ON A.PWI003=C.OPI001 INNER JOIN MOXPWG D ON B.PWH001=D.PWG001  " );
            strSql . AppendFormat ( "WHERE PWI001 LIKE '{0}%' AND PWG009='{1}' AND  PWI014='{2}' " ,year ,week ,userName );
            strSql . Append ( " GROUP BY PWG009,PWI014" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string year ,string week ,string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT A.PWI002,A.PWI003,PWI004,OPI003,PWI006,PWI007 PDK,PWI012,PWH009,PD FROM MOXPWI A INNER JOIN MOXOPI B ON A.PWI003=B.OPI001 INNER JOIN MOXPWH C ON A.PWI002=C.PWH003 AND A.PWI003=C.PWH004 INNER JOIN MOXPWG D ON C.PWH001=D.PWG001 INNER JOIN (SELECT SUM(PWI007) PD,PWI002,PWI003 FROM MOXPWI   WHERE PWI001 LIKE '{0}%' AND PWI014='{1}' GROUP BY PWI002,PWI003) E ON A.PWI002=E.PWI002 AND A.PWI003=E.PWI003 WHERE PWI001 LIKE '{0}%' AND PWG009='{2}' AND PWI014='{1}'" ,year ,userName ,week );
            strSql . Append ( " ORDER BY A.PWI002,A.PWI003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取周计划报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeekJ ( List<string> inList )
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
            strSql . Append ( "SELECT PDP001,PDP002,PDP003,PDP004,PDP025,0 DL,GETDATE() PWI012,OPI006,OPI007,SUM(ISNULL(PWI007,0)) PWI007,PWH001 FROM MOXPDP A LEFT JOIN MOXPWI B ON A.PDP001=B.PWI002 AND A.PDP002=B.PWI003 LEFT JOIN MOXOPI C ON A.PDP002=C.OPI001 INNER JOIN (SELECT PWH001,PWH003,PWH004 FROM MOXPWH D INNER JOIN MOXPWG E ON D.PWH001=E.PWG001 WHERE PWH010=0 AND PWG007=1 GROUP BY PWH003,PWH004,PWH001 ) D ON A.PDP001=D.PWH003 AND A.PDP002=D.PWH004 " );
            strSql . AppendFormat ( "WHERE A.idx IN ({0}) " ,str );
            strSql . Append ( " GROUP BY PDP001,PDP002,PDP003,PDP004,PDP025,OPI006,OPI007,PWH001 " );
            strSql . Append ( " HAVING SUM(ISNULL(PWI007,0))<PDP025 ORDER BY PDP001 DESC,PDP002 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

        }
        
        /// <summary>
        /// 获取周计划预排报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeekDailyJ ( List<string> inList )
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
            strSql . Append ( "SELECT PDP001,PDP002,PDP003,PDP004,PDP025,0 DL,GETDATE() PWI012,OPI006,OPI007,SUM(ISNULL(PWI007,0)) PWI007,PWH001 FROM MOXPDP A LEFT JOIN MOXPWI B ON A.PDP001=B.PWI002 AND A.PDP002=B.PWI003 LEFT JOIN MOXOPI C ON A.PDP002=C.OPI001 INNER JOIN (SELECT PWH003,PWH004,PWH001 FROM MOXPWH D INNER JOIN MOXPWG E ON D.PWH001=E.PWG001 WHERE PWH010=1 AND PWG007=1 GROUP BY PWH003,PWH004,PWH001 ) D ON A.PDP001=D.PWH003 AND A.PDP002=D.PWH004 " );
            strSql . AppendFormat ( "WHERE A.idx IN ({0}) " ,str );
            strSql . Append ( " GROUP BY PDP001,PDP002,PDP003,PDP004,PDP025,OPI006,OPI007,PWH001 " );
            strSql . Append ( " HAVING SUM(ISNULL(PWI007,0))<PDP025 ORDER BY PDP001 DESC,PDP002 DESC" );


            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 周计划组装报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool PDailyWeek ( DataTable table ,bool state )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . ProductionPaintWeekDailyEntity _model = new CarpenterEntity . ProductionPaintWeekDailyEntity ( );
            _model . PWI001 = DailyWeekOddNum ( );
            _model . PWI013 = UserInformation . dt ( );
            _model . PWI014 = UserInformation . UserName;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . PWI002 = table . Rows [ i ] [ "PDP001" ] . ToString ( );
                _model . PWI003 = table . Rows [ i ] [ "PDP002" ] . ToString ( );
                _model . PWI004 = table . Rows [ i ] [ "PDP003" ] . ToString ( );
                _model . PWI005 = table . Rows [ i ] [ "PDP004" ] . ToString ( );
                _model . PWI006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PDP025" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PDP025" ] . ToString ( ) );
                _model . PWI007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DL" ] . ToString ( ) );
                _model . PWI008 = state;
                _model . PWI009 = table . Rows [ i ] [ "PWH001" ] . ToString ( );
                _model . PWI012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PWI012" ] . ToString ( ) ) == true ? UserInformation . dt ( ) : Convert . ToDateTime ( table . Rows [ i ] [ "PWI012" ] . ToString ( ) );
                edit_BL_DailyWork ( _model ,strSql ,SQLString );
                if ( Exists_bl_day ( _model . PWI002 ,_model . PWI003 ,_model . PWI007 ) == true )
                {
                    edit_bl_day ( _model . PWI002 ,_model . PWI003 ,SQLString ,strSql );
                }

                //若报工总数量=生产数量  则回写完工时间到生产部生产进度跟踪表的对应工段完工时间
                //_model . PWI007 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PWI007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PWI007" ] . ToString ( ) );

                //if ( Exists_bl_day ( _model . PWI002 ,_model . PWI003 ,_model . PWI007 ) == true )
                //{
                //    edit_BL_Prs ( _model ,strSql ,SQLString );
                //}

            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        string DailyWeekOddNum ( )
        {
            DataTable dt = SqlHelper . ExecuteDataTable ( "SELECT MAX(PWI001) PWI001 FROM MOXPWI " );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PWI001" ] . ToString ( ) ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PWI001" ] . ToString ( ) . Substring ( 0 ,8 ) == UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PWI001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        void edit_BL_DailyWork ( CarpenterEntity . ProductionPaintWeekDailyEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPWI (" );//,PDK009,PDK010,PDK011,
            strSql . Append ( "PWI001,PWI002,PWI003,PWI004,PWI005,PWI006,PWI007,PWI008,PWI012,PWI013,PWI014,PWI009) " );
            strSql . Append ( "VALUES (" );//,PDK009,PDK010,PDK011,
            strSql . Append ( "@PWI001,@PWI002,@PWI003,@PWI004,@PWI005,@PWI006,@PWI007,@PWI008,@PWI012,@PWI013,@PWI014,@PWI009) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWI001",SqlDbType.NVarChar,20),
                new SqlParameter("@PWI002",SqlDbType.NVarChar,20),
                new SqlParameter("@PWI003",SqlDbType.NVarChar,20),
                new SqlParameter("@PWI004",SqlDbType.NVarChar,20),
                new SqlParameter("@PWI005",SqlDbType.NVarChar,20),
                new SqlParameter("@PWI006",SqlDbType.Int),
                new SqlParameter("@PWI007",SqlDbType.Int),
                new SqlParameter("@PWI008",SqlDbType.Bit),
                //new SqlParameter("PDK010",SqlDbType.Int),
                //new SqlParameter("PDK011",SqlDbType.Int),
                new SqlParameter("@PWI012",SqlDbType.Date),
                new SqlParameter("@PWI013",SqlDbType.Date),
                new SqlParameter("@PWI014",SqlDbType.NVarChar,20),
                new SqlParameter("@PWI009",SqlDbType.NVarChar,50)
            };
            parameter [ 0 ] . Value = _model . PWI001;
            parameter [ 1 ] . Value = _model . PWI002;
            parameter [ 2 ] . Value = _model . PWI003;
            parameter [ 3 ] . Value = _model . PWI004;
            parameter [ 4 ] . Value = _model . PWI005;
            parameter [ 5 ] . Value = _model . PWI006;
            parameter [ 6 ] . Value = _model . PWI007;
            parameter [ 7 ] . Value = _model . PWI008;
            //parameter [ 9 ] . Value = _model . PDK010;
            //parameter [ 10 ] . Value = _model . PDK011;
            parameter [ 8 ] . Value = _model . PWI012;
            parameter [ 9 ] . Value = _model . PWI013;
            parameter [ 10 ] . Value = _model . PWI014;
            parameter [ 11 ] . Value = _model . PWI009;

            SQLString . Add ( strSql ,parameter );
        }

        //周计划中是否存在此批号和品号
        bool Exists_bl_day ( string weekEnds ,string productNum ,int nums )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT SUM(PWH007) PWH007 FROM MOXPWH " );
            strSql . Append ( "WHERE PWH003=@PWH003 AND PWH004=@PWH004 AND PWH010=0" );
            strSql . Append ( "GROUP BY PWH003,PWH004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWH003",SqlDbType.NVarChar,20),
                new SqlParameter("@PWH004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PWH007" ] . ToString ( ) ) )
                    return false;
                int num = Convert . ToInt32 ( da . Rows [ 0 ] [ "PWH007" ] . ToString ( ) );
                if ( num == nums )
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        //编辑完工标记
        void edit_bl_day ( string weekEnds ,string productNum ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPWH SET " );
            strSql . Append ( "PWH013=1 " );
            strSql . Append ( "WHERE PWH003=@PWH003 AND PWH004=@PWH004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWH003",SqlDbType.NVarChar,20),
                new SqlParameter("@PWH004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            SQLString . Add ( strSql ,parameter );
        }

    }
}
