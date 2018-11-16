using System . Collections . Generic;
using System . Text;
using StudentMgr;
using System . Data;
using System . Collections;
using System;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class PlanAssembleWeekDailyDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public DataTable GetOnly ( string columnName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM MOXPLC ORDER BY {0}" ,columnName );

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
            strSql . Append ( "DELETE FROM MOXPLC " );
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
            strSql . Append ( "SELECT A.idx,PLC001,PLC002,PLC003,PLC004,PLC005,PLC006,PLC007,PLC012,OPI006,OPI007,CASE PLC008 WHEN 0 THEN '正式' ELSE '预排' END PLC008 FROM MOXPLC A LEFT JOIN MOXOPI B ON A.PLC003=B.OPI001 " );
            strSql . Append ( " WHERE " + strWhere );
            strSql . Append ( " ORDER BY PLC001 DESC,PLC002 DESC,PLC003 DESC " );

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
            strSql . Append ( "SELECT PLA009,PLC014,SUM(PLB007*OPI004) PSX FROM MOXPLC A INNER JOIN MOXPLB B ON A.PLC002=B.PLB003 AND A.PLC003=B.PLB004 INNER JOIN MOXOPI C ON A.PLC003=C.OPI001 INNER JOIN MOXPLA D ON B.PLB001=D.PLA001  " );
            strSql . AppendFormat ( "WHERE PLC001 LIKE '{0}%' AND PLA009='{1}' AND  PLC014='{2}' " ,year ,week ,userName );
            strSql . Append ( " GROUP BY PLA009,PLC014" );

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
            strSql . AppendFormat ( "SELECT A.PLC002,A.PLC003,PLC004,OPI003,PLC006,PLC007 PDK,PLC012,PLB009,PD FROM MOXPLC A INNER JOIN MOXOPI B ON A.PLC003=B.OPI001 INNER JOIN MOXPLB C ON A.PLC002=C.PLB003 AND A.PLC003=C.PLB004 INNER JOIN MOXPLA D ON C.PLB001=D.PLA001 INNER JOIN (SELECT SUM(PLC007) PD,PLC002,PLC003 FROM MOXPLC   WHERE PLC001 LIKE '{0}%' AND PLC014='{1}' GROUP BY PLC002,PLC003) E ON A.PLC002=E.PLC002 AND A.PLC003=E.PLC003 WHERE PLC001 LIKE '{0}%' AND PLA009='{2}' AND PLC014='{1}'" ,year ,userName ,week );
            strSql . Append ( " ORDER BY A.PLC002,A.PLC003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取年
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableYear ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT SUBSTRING(PLC001,0,5) PLC001 FROM MOXPLC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取操作者
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePerson ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PLC014 FROM MOXPLC" );

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
            strSql . Append ( "SELECT DISTINCT PLA009 FROM MOXPLC A INNER JOIN MOXPLB B ON A.PLC002=B.PLB003 AND A.PLC003=B.PLB004 INNER JOIN MOXPLA C ON B.PLB001=C.PLA001  " );
            strSql . AppendFormat ( "WHERE PLC001 LIKE '{0}%'" ,year );

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
            strSql . Append ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS016,PAS016-SUM(ISNULL(PLC007,0)) DL,GETDATE() PLC012,OPI006,OPI007,SUM(ISNULL(PLC007,0)) PLC007 FROM MOXPAS A LEFT JOIN MOXPLC B ON A.PAS001=B.PLC002 AND A.PAS002=B.PLC003 LEFT JOIN MOXOPI C ON A.PAS002=C.OPI001 INNER JOIN (SELECT PLB003,PLB004 FROM MOXPLB D INNER JOIN MOXPLA E ON D.PLB001=E.PLA001 WHERE PLB010=0 AND PLA007=1 GROUP BY PLB003,PLB004 ) D ON A.PAS001=D.PLB003 AND A.PAS002=D.PLB004  " );
            strSql . AppendFormat ( "WHERE A.idx IN ({0}) " ,str );
            strSql . Append ( " GROUP BY PAS001,PAS002,PAS003,PAS004,PAS016,OPI006,OPI007 " );
            strSql . Append ( " HAVING SUM(ISNULL(PLC007,0))<PAS016 ORDER BY PAS001 DESC,PAS002 DESC" );

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
            strSql . Append ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS016,PAS016-SUM(ISNULL(PLC007,0)) DL,GETDATE() PLC012,OPI006,OPI007,SUM(ISNULL(PLC007,0)) PLC007 FROM MOXPAS A LEFT JOIN MOXPLC B ON A.PAS001=B.PLC002 AND A.PAS002=B.PLC003 LEFT JOIN MOXOPI C ON A.PAS002=C.OPI001 INNER JOIN (SELECT PLB003,PLB004 FROM MOXPLB D INNER JOIN MOXPLA E ON D.PLB001=E.PLA001 WHERE PLB010=1 AND PLA007=1 GROUP BY PLB003,PLB004 ) D ON A.PAS001=D.PLB003 AND A.PAS002=D.PLB004  " );
            strSql . AppendFormat ( "WHERE A.idx IN ({0}) " ,str );
            strSql . Append ( " GROUP BY PAS001,PAS002,PAS003,PAS004,PAS016,OPI006,OPI007 " );
            strSql . Append ( " HAVING SUM(ISNULL(PLC007,0))<PAS016 ORDER BY PAS001 DESC,PAS002 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 周计划组装报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ZDailyWeek ( DataTable table ,bool state )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . PlanAssembleWeekDailyEntity _model = new CarpenterEntity . PlanAssembleWeekDailyEntity ( );
            _model . PLC001 = DailyWeekOddNum ( );
            _model . PLC013 = UserInformation . dt ( );
            _model . PLC014 = UserInformation . UserName;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . PLC002 = table . Rows [ i ] [ "PAS001" ] . ToString ( );
                _model . PLC003 = table . Rows [ i ] [ "PAS002" ] . ToString ( );
                _model . PLC004 = table . Rows [ i ] [ "PAS003" ] . ToString ( );
                _model . PLC005 = table . Rows [ i ] [ "PAS004" ] . ToString ( );
                _model . PLC006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PAS016" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PAS016" ] . ToString ( ) );
                _model . PLC007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DL" ] . ToString ( ) );
                _model . PLC008 = state;
                _model . PLC012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PLC012" ] . ToString ( ) ) == true ? UserInformation . dt ( ) : Convert . ToDateTime ( table . Rows [ i ] [ "PLC012" ] . ToString ( ) );
                edit_BL_DailyWork ( _model ,strSql ,SQLString );
                if ( Exists_bl_day ( _model . PLC002 ,_model . PLC003 ,_model . PLC007 ) == true )
                {
                    edit_bl_day ( _model . PLC002 ,_model . PLC003 ,SQLString ,strSql );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        string DailyWeekOddNum ( )
        {
            DataTable dt = SqlHelper . ExecuteDataTable ( "SELECT MAX(PLC001) PLC001 FROM MOXPLC " );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PLC001" ] . ToString ( ) ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PLC001" ] . ToString ( ) . Substring ( 0 ,8 ) == UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PLC001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        void edit_BL_DailyWork ( CarpenterEntity . PlanAssembleWeekDailyEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPLC (" );//,PDK009,PDK010,PDK011,
            strSql . Append ( "PLC001,PLC002,PLC003,PLC004,PLC005,PLC006,PLC007,PLC008,PLC012,PLC013,PLC014) " );
            strSql . Append ( "VALUES (" );//,PDK009,PDK010,PDK011,
            strSql . Append ( "@PLC001,@PLC002,@PLC003,@PLC004,@PLC005,@PLC006,@PLC007,@PLC008,@PLC012,@PLC013,@PLC014) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLC001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLC002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLC003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLC004",SqlDbType.NVarChar,20),
                new SqlParameter("@PLC005",SqlDbType.NVarChar,20),
                new SqlParameter("@PLC006",SqlDbType.Int),
                new SqlParameter("@PLC007",SqlDbType.Int),
                new SqlParameter("@PLC008",SqlDbType.Bit),
                //new SqlParameter("PDK009",SqlDbType.Int),
                //new SqlParameter("PDK010",SqlDbType.Int),
                //new SqlParameter("PDK011",SqlDbType.Int),
                new SqlParameter("@PLC012",SqlDbType.Date),
                new SqlParameter("@PLC013",SqlDbType.Date),
                new SqlParameter("@PLC014",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PLC001;
            parameter [ 1 ] . Value = _model . PLC002;
            parameter [ 2 ] . Value = _model . PLC003;
            parameter [ 3 ] . Value = _model . PLC004;
            parameter [ 4 ] . Value = _model . PLC005;
            parameter [ 5 ] . Value = _model . PLC006;
            parameter [ 6 ] . Value = _model . PLC007;
            parameter [ 7 ] . Value = _model . PLC008;
            //parameter [ 8 ] . Value = _model . PDK009;
            //parameter [ 9 ] . Value = _model . PDK010;
            //parameter [ 10 ] . Value = _model . PDK011;
            parameter [ 8 ] . Value = _model . PLC012;
            parameter [ 9 ] . Value = _model . PLC013;
            parameter [ 10 ] . Value = _model . PLC014;
            SQLString . Add ( strSql ,parameter );
        }

        //周计划中是否存在此批号和品号
        bool Exists_bl_day ( string weekEnds ,string productNum ,int nums )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT SUM(PLB007) PLB007 FROM MOXPLB " );
            strSql . Append ( "WHERE PLB003=@PLB003 AND PLB004=@PLB004 AND PLB010=0" );
            strSql . Append ( "GROUP BY PLB003,PLB004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLB003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLB004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PLB007" ] . ToString ( ) ) )
                    return false;
                int num = Convert . ToInt32 ( da . Rows [ 0 ] [ "PLB007" ] . ToString ( ) );
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
            strSql . Append ( "UPDATE MOXPLB SET " );
            strSql . Append ( "PLB013=1 " );
            strSql . Append ( "WHERE PLB003=@PLB003 AND PLB004=@PLB004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLB003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLB004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            SQLString . Add ( strSql ,parameter );
        }

    }
}
