using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Data;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class BomWorkPlanCodeDao
    {
        public BomWorkPlanCodeDao ( )
        {
        }
        
        /// <summary>
        /// 获取批号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWeekend ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT WPC001 FROM MOXWPC ORDER BY WPC001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取品名  品号 BOM清单
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePorductNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT WPC002,WOQ002 FROM MOXWPC A INNER JOIN MOXWOQ B ON A.WPC002=B.WOQ001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取零件名称  零件编号  BOM清单
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePartNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT WPC003,WPC004 FROM MOXWPC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,WPC001,WPC002,CASE WHEN WOQ008='' OR WOQ008 IS NULL THEN WPC036 ELSE WOQ008 END WOQ008,WPC003,WPC004,WPC005,WPC006,WPC007,WPC008,WPC009,WPC010,WPC011,WPC012,WPC013,WPC014,WPC015,WPC016,WPC017,WPC018,WPC019,WPC020,WPC021,WPC022,WPC023,WPC024,WPC025,WPC026,WPC027,WPC028,WPC029,WPC030,WPC031,WPC032,WPC033,CONVERT(FLOAT,WPC035) WPC035 FROM MOXWPC A LEFT JOIN MOXWOQ B ON A.WPC002=B.WOQ001 " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXWPC " );
            strSql . AppendFormat ( "WHERE idx={0}" ,idx );

           return   SqlHelper . ExecuteNonQueryBool ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取条码
        /// </summary>
        /// <returns></returns>
        public string getCodeNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(WPC005) WPC005 FROM MOXWPC" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string code = dt . Rows [ 0 ] [ "WPC005" ] . ToString ( );
                if ( string . IsNullOrEmpty ( code ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    if ( UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) . Equals ( code . Substring ( 0 ,8 ) ) )
                        return ( Convert . ToInt64 ( code ) + 1 ) . ToString ( );
                    else
                        return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                }
            }
            else
                return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        public DataTable getProductInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT OPI001,OPI002 FROM MOXOPI" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Save ( CarpenterEntity . BomWorkPlanCodeEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            _model . WPC005 = getCodeNum ( );
            strSql . Append ( "INSERT INTO MOXWPC (" );
            strSql . Append ( "WPC001,WPC002,WPC003,WPC004,WPC005,WPC006,WPC007,WPC008,WPC009,WPC010,WPC011,WPC012,WPC013,WPC014,WPC015,WPC016,WPC017,WPC018,WPC019,WPC020,WPC021,WPC022,WPC023,WPC024,WPC025,WPC026,WPC027,WPC028,WPC029,WPC030,WPC031,WPC032,WPC033,WPC035,WPC036) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@WPC001,@WPC002,@WPC003,@WPC004,@WPC005,@WPC006,@WPC007,@WPC008,@WPC009,@WPC010,@WPC011,@WPC012,@WPC013,@WPC014,@WPC015,@WPC016,@WPC017,@WPC018,@WPC019,@WPC020,@WPC021,@WPC022,@WPC023,@WPC024,@WPC025,@WPC026,@WPC027,@WPC028,@WPC029,@WPC030,@WPC031,@WPC032,@WPC033,@WPC035,@WPC036) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WPC001",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC002",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC003",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC004",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC005",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC006",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC007",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC008",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC009",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC010",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC011",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC012",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC013",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC014",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC015",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC016",SqlDbType.Decimal,11),
                new SqlParameter("@WPC017",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC018",SqlDbType.Int,4),
                new SqlParameter("@WPC019",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC020",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC021",SqlDbType.NVarChar,500),
                new SqlParameter("@WPC022",SqlDbType.Date,3),
                new SqlParameter("@WPC023",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC024",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC025",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC026",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC027",SqlDbType.Int,4),
                new SqlParameter("@WPC028",SqlDbType.Int,4),
                new SqlParameter("@WPC029",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC030",SqlDbType.Image),
                new SqlParameter("@WPC031",SqlDbType.Image),
                new SqlParameter("@WPC032",SqlDbType.Image),
                new SqlParameter("@WPC033",SqlDbType.Image),
                new SqlParameter("@WPC035",SqlDbType.Decimal,11),
                new SqlParameter("@WPC036",SqlDbType.NVarChar,100)
            };
            parameter [ 0 ] . Value = _model . WPC001;
            parameter [ 1 ] . Value = _model . WPC002;
            parameter [ 2 ] . Value = _model . WPC003;
            parameter [ 3 ] . Value = _model . WPC004;
            parameter [ 4 ] . Value = _model . WPC005;
            parameter [ 5 ] . Value = _model . WPC006;
            parameter [ 6 ] . Value = _model . WPC007;
            parameter [ 7 ] . Value = _model . WPC008;
            parameter [ 8 ] . Value = _model . WPC009;
            parameter [ 9 ] . Value = _model . WPC010;
            parameter [ 10 ] . Value = _model . WPC011;
            parameter [ 11 ] . Value = _model . WPC012;
            parameter [ 12 ] . Value = _model . WPC013;
            parameter [ 13 ] . Value = _model . WPC014;
            parameter [ 14 ] . Value = _model . WPC015;
            parameter [ 15 ] . Value = _model . WPC016;
            parameter [ 16 ] . Value = _model . WPC017;
            parameter [ 17 ] . Value = _model . WPC018;
            parameter [ 18 ] . Value = _model . WPC019;
            parameter [ 19 ] . Value = _model . WPC020;
            parameter [ 20 ] . Value = _model . WPC021;
            parameter [ 21 ] . Value = _model . WPC022;
            parameter [ 22 ] . Value = _model . WPC023;
            parameter [ 23 ] . Value = _model . WPC024;
            parameter [ 24 ] . Value = _model . WPC025;
            parameter [ 25 ] . Value = _model . WPC026;
            parameter [ 26 ] . Value = _model . WPC027;
            parameter [ 27 ] . Value = _model . WPC028;
            parameter [ 28 ] . Value = _model . WPC029;
            parameter [ 29 ] . Value = _model . WPC030;
            parameter [ 30 ] . Value = _model . WPC031;
            parameter [ 31 ] . Value = _model . WPC032;
            parameter [ 32 ] . Value = _model . WPC033;
            parameter [ 33 ] . Value = _model . WPC035;
            parameter [ 34 ] . Value = _model . WPC036;

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

    }
}



