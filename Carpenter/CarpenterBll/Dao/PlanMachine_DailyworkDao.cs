using StudentMgr;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Linq;
using System . Text;

namespace CarpenterBll . Dao
{
    public class PlanMachine_DailyworkDao
    {
        /// <summary>
        /// 机加工报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool JDailyWork ( DataTable table ,string userName ,bool plan )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . PlanMachinDayDailyWorkEntity _model = new CarpenterEntity . PlanMachinDayDailyWorkEntity ( );
            _model . PMY001 = GetDataTableDailyWorkOddNum ( );
            _model . PMY013 = UserInformation . dt ( );
            _model . PMY014 = userName;
            _model . PMY015 = plan;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . PMY002 = table . Rows [ i ] [ "PST001" ] . ToString ( );
                _model . PMY003 = table . Rows [ i ] [ "PST002" ] . ToString ( );
                _model . PMY004 = table . Rows [ i ] [ "PST003" ] . ToString ( );
                _model . PMY005 = table . Rows [ i ] [ "PST004" ] . ToString ( );
                _model . PMY006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PMX007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PMX007" ] . ToString ( ) );
                _model . PMY007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DL" ] . ToString ( ) );
                _model . PMY008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "XB" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "XB" ] . ToString ( ) );
                _model . PMY009 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CJ" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CJ" ] . ToString ( ) );
                _model . PMY012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PMY012" ] . ToString ( ) ) == true ? UserInformation . dt ( ) : Convert . ToDateTime ( table . Rows [ i ] [ "PMY012" ] . ToString ( ) );
                _model . PMY016 = table . Rows [ i ] [ "PMX001" ] . ToString ( );
                _model . PMY017 = table . Rows [ i ] [ "PMX013" ] . ToString ( );
                if ( _model . PMY007 != 0 || _model . PMY008 != 0 || _model . PMY009 != 0  )
                    edit_BL_DailyWork ( _model ,strSql ,SQLString );
                //若报工总数量=生产数量  则回写完工时间到机加工跟踪表的对应工段完工时间
                _model . PMY007 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PMY007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PMY007" ] . ToString ( ) );
                _model . PMY008 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PMY008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PMY008" ] . ToString ( ) );
                _model . PMY009 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PMY009" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PMY009" ] . ToString ( ) );
                edit_BL_OverTime ( _model ,strSql ,SQLString );

                //if ( Exists_bl_weekEnds ( _model . PMY002 ,_model . PMY003 ,_model . PMY011 ) == true )
                    //edit_bl_weekEnds ( _model . PMY002 ,_model . PMY003 ,SQLString ,strSql );

                if ( Exists_bl_day ( _model . PMY002 ,_model . PMY003 ,new int [ ] { _model . PMY007 ,_model . PMY008 ,_model . PMY009 } ) == true )
                {
                    edit_bl_day ( _model . PMY002 ,_model . PMY003 ,SQLString ,strSql ,plan );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取机加工报工的单号
        /// </summary>
        /// <returns></returns>
        string GetDataTableDailyWorkOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(PMY001) PMY001 FROM MOXPMY" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PMY001" ] . ToString ( ) ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PMY001" ] . ToString ( ) . Substring ( 0 ,8 ) == UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PMY001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        void edit_BL_DailyWork ( CarpenterEntity . PlanMachinDayDailyWorkEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPMY (" );
            strSql . Append ( "PMY001,PMY002,PMY003,PMY004,PMY005,PMY006,PMY007,PMY008,PMY009,PMY012,PMY013,PMY014,PMY015,PMY016,PMY017) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PMY001,@PMY002,@PMY003,@PMY004,@PMY005,@PMY006,@PMY007,@PMY008,@PMY009,@PMY012,@PMY013,@PMY014,@PMY015,@PMY016,@PMY017) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMY001",SqlDbType.NVarChar,20),
                new SqlParameter("@PMY002",SqlDbType.NVarChar,20),
                new SqlParameter("@PMY003",SqlDbType.NVarChar,20),
                new SqlParameter("@PMY004",SqlDbType.NVarChar,20),
                new SqlParameter("@PMY005",SqlDbType.NVarChar,20),
                new SqlParameter("@PMY006",SqlDbType.Int),
                new SqlParameter("@PMY007",SqlDbType.Int),
                new SqlParameter("@PMY008",SqlDbType.Int),
                new SqlParameter("@PMY009",SqlDbType.Int),
                new SqlParameter("@PMY012",SqlDbType.Date),
                new SqlParameter("@PMY013",SqlDbType.Date),
                new SqlParameter("@PMY014",SqlDbType.NVarChar,20),
                new SqlParameter("@PMY015",SqlDbType.Bit),
                new SqlParameter("@PMY016",SqlDbType.NVarChar,20),
                new SqlParameter("@PMY017",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PMY001;
            parameter [ 1 ] . Value = _model . PMY002;
            parameter [ 2 ] . Value = _model . PMY003;
            parameter [ 3 ] . Value = _model . PMY004;
            parameter [ 4 ] . Value = _model . PMY005;
            parameter [ 5 ] . Value = _model . PMY006;
            parameter [ 6 ] . Value = _model . PMY007;
            parameter [ 7 ] . Value = _model . PMY008;
            parameter [ 8 ] . Value = _model . PMY009;
            parameter [ 9 ] . Value = _model . PMY012;
            parameter [ 10 ] . Value = _model . PMY013;
            parameter [ 11 ] . Value = _model . PMY014;
            parameter [ 12 ] . Value = _model . PMY015;
            parameter [ 13 ] . Value = _model . PMY016;
            parameter [ 14 ] . Value = _model . PMY017;

            SQLString . Add ( strSql ,parameter );
        }

        //回写机加工工段对应批号产品实际完工时间
        void edit_BL_OverTime ( CarpenterEntity . PlanMachinDayDailyWorkEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            if ( _model . PMY006 == _model . PMY007 )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST018='{0}' WHERE PST001='{1}' AND PST002='{2}'" ,_model . PMY012 ,_model . PMY002 ,_model . PMY003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( _model . PMY006 == _model . PMY008 )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST020='{0}' WHERE PST001='{1}' AND PST002='{2}'" ,_model . PMY012 ,_model . PMY002 ,_model . PMY003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( _model . PMY006 == _model . PMY009 )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST022='{0}' WHERE PST001='{1}' AND PST002='{2}'" ,_model . PMY012 ,_model . PMY002 ,_model . PMY003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
        }

        //日计划中是否存在此批号和品号
        bool Exists_bl_day ( string weekEnds ,string productNum ,int [ ] nums )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PMW002,SUM(PMX007) PMX007 FROM MOXPMX A INNER JOIN MOXPMW B ON A.PMX001=B.PMW001 " );
            strSql . Append ( "WHERE PMX003=@PMX003 AND PMX004=@PMX004 " );
            strSql . Append ( "GROUP BY PMW002,PMX003,PMX004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMX003",SqlDbType.NVarChar,20),
                new SqlParameter("@PMX004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PMW002" ] . ToString ( ) ) )
                    return false;
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PMX007" ] . ToString ( ) ) )
                    return false;
                string procedure = da . Rows [ 0 ] [ "PMW002" ] . ToString ( );
                int num = Convert . ToInt32 ( da . Rows [ 0 ] [ "PMX007" ] . ToString ( ) );
                if ( procedure . Equals ( ColumnValues . jjg_jgzx ) )
                {
                    if ( num == nums [ 0 ] )
                        return true;
                    else
                        return false;
                }
                else if ( procedure . Equals ( ColumnValues . jjg_kszk ) )
                {
                    if ( num == nums [ 0 ] )
                        return true;
                    else
                        return false;
                }
                else if ( procedure . Equals ( ColumnValues . jjg_dy ) )
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

        //编辑完工标记
        void edit_bl_day ( string weekEnds ,string productNum ,Hashtable SQLString ,StringBuilder strSql ,bool plan )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPMX SET " );
            strSql . Append ( "PMX011=1 " );
            if ( plan )
                strSql . Append ( "WHERE PMX003=@PMX003 AND PMX004=@PMX004 AND PMX012=1" );
            else
                strSql . Append ( "WHERE PMX003=@PMX003 AND PMX004=@PMX004 AND PMX012=0" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMX003",SqlDbType.NVarChar,20),
                new SqlParameter("@PMX004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            SQLString . Add ( strSql ,parameter );
        }

    }
}
