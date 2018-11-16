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
    public class ProductionPaint_DayDao
    {
        /// <summary>
        /// 是否存在生产油漆日计划   相同的工段和计划日期
        /// </summary>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public int Exists_Day ( string workShop ,DateTime dt ,List<string> intList ,bool planCheck )
        {
            int x = 0;
            string idxStr = string . Empty;
            foreach ( string str in intList )
            {
                if ( idxStr == string . Empty )
                    idxStr = str;
                else
                    idxStr = idxStr + "," + str;
            }

            string columns = string . Empty;
            if ( workShop . Equals ( ColumnValues . yq_dq ) )
                columns = "PWF007";
            else if ( workShop . Equals ( ColumnValues . yq_ym ) )
                columns = "PWF008";
            else if ( workShop . Equals ( ColumnValues . yq_xs ) )
                columns = "PWF009";
            else if ( workShop . Equals ( ColumnValues . yq_mq ) )
                columns = "PWF010";
            else if ( workShop . Equals ( ColumnValues . yq_rb ) )
                columns = "PWF011";

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXPWD " );
            strSql . AppendFormat ( "WHERE PWD002='{0}' AND PWD003='{1}'" ,workShop ,dt );
            
            if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
            {
                x = 1; //编辑

                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPWD " );
                strSql . AppendFormat ( "WHERE PWD002='{0}' AND PWD003='{1}' AND PWD005=1" ,workShop ,dt );
                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return 2; //已注销


                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPWD " );
                strSql . AppendFormat ( "WHERE PWD002='{0}' AND PWD003='{1}' AND PWD006=1" ,workShop ,dt );
                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return 3; //已审核

                strSql = new StringBuilder ( );
                if ( planCheck )
                {
                    //同批号和品号只能预排一次
                    //strSql . Append ( "SELECT COUNT(1) COUNT FROM MOXPDP WHERE idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN MOXPWE B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 INNER JOIN MOXPWD C ON B.PWE001=C.PWD001 " );
                    //strSql . Append ( "WHERE A.idx IN (" + idxStr + ") AND PWD002='" + workShop + "' AND PWD003='" + dt + "') AND idx IN (" + idxStr + ")" );

                    //同批号和品号可以预排多次，知道报工数量等于订单数量
                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPDP A LEFT JOIN MOXPWF C ON A.PDP001=C.PWF002 AND A.PDP002=C.PWF003 WHERE A.idx IN ({0}) AND PDP001+PDP002 NOT IN (SELECT A.PWE003+A.PWE004 FROM MOXPWE A INNER JOIN MOXPWD D ON A.PWE001=D.PWD001 INNER JOIN MOXPDP C ON A.PWE003=C.PDP001 AND A.PWE004=C.PDP002 WHERE D.PWD002='{1}' AND PWD003='{2}') GROUP BY PDP025,PDP001,PDP002 HAVING PDP025>SUM(ISNULL({3},0))" ,idxStr ,workShop ,dt ,columns );

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4; //预排产品已经存在  不允许排
                    else
                        x = 1;  //编辑
                }
                else
                {
                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPDP WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN (SELECT PWE003,PWE004,PWE002 FROM (SELECT PWE001,PWE003,PWE004,PWE002 FROM MOXPWE WHERE PWE001 IN (SELECT MAX(PWE001) FROM MOXPWE WHERE PWE012=0 GROUP BY PWE003,PWE004)) A INNER JOIN MOXPWD B ON A.PWE001=B.PWD001 WHERE PWE002='完工' AND PWD002='{1}' AND PWD003='{2}') B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE A.idx in ({0}))" ,idxStr ,workShop ,dt );
                    //strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPDP A LEFT JOIN MOXPWE B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE A.idx in ({0}) AND A.idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN (SELECT PWE003,PWE004,PWE002,PWE007 FROM (SELECT PWE001,PWE003,PWE004,PWE002,PWE007 FROM MOXPWE WHERE PWE001 IN (SELECT MAX(PWE001) FROM MOXPWE WHERE PWE012=0 GROUP BY PWE003,PWE004)) A INNER JOIN MOXPWD B ON A.PWE001=B.PWD001 WHERE PWE002='完工' AND PWD002='{1}' AND PWD003='{2}') B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE A.idx in ({0})) GROUP BY PDP025HAVING PDP025<SUM(ISNULL(PWE007,0))" ,idxStr ,workShop ,dt );

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 6; //正式产品已经存在 不允许排
                    else
                        x = 1; //编辑
                }
            }
            else
            {
                strSql = new StringBuilder ( );

                //预排
                if ( planCheck )
                {
                    //strSql . Append ( "SELECT COUNT(1) COUN FROM MOXPDP A INNER JOIN MOXPWE B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 INNER JOIN MOXPWD C ON B.PWE001=C.PWD001 " );
                    //strSql . Append ( "WHERE A.idx IN(" + idxStr + ") AND C.PWD002='" + workShop + "'" );

                    //strSql . Append ( "SELECT COUNT(1) COUNT FROM MOXPDP WHERE idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN MOXPWE B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 INNER JOIN MOXPWD C ON B.PWE001=C.PWD001 " );
                    //strSql . Append ( "WHERE A.idx IN (" + idxStr + ") AND PWD002='" + workShop + "') AND idx IN (" + idxStr + ")" );

                    //同批号和品号可以预排多次，知道报工数量等于订单数量
                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPDP A LEFT JOIN MOXPWF C ON A.PDP001=C.PWF002 AND A.PDP002=C.PWF003 WHERE A.idx IN ({0}) AND PDP001+PDP002 NOT IN (SELECT A.PWE003+A.PWE004 FROM MOXPWE A INNER JOIN MOXPWD D ON A.PWE001=D.PWD001 INNER JOIN MOXPDP C ON A.PWE003=C.PDP001 AND A.PWE004=C.PDP002 WHERE D.PWD002='{1}' AND PWD003='{2}') GROUP BY PDP025,PDP001,PDP002 HAVING PDP025>SUM(ISNULL({3},0))" ,idxStr ,workShop ,dt ,columns );

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4; //预排产品已经存在  不允许排
                    else
                        x = 5;  //新增
                }
                else
                {
                    //查询已经排正式且未完工的产品 预排的不管

                    //strSql . AppendFormat ( "SELECT COUNT(1) COUN FROM MOXPWE WHERE idx IN (SELECT MAX(A.idx) FROM MOXPWE A INNER JOIN MOXPDP B ON A.PWE003=B.PDP001 AND A.PWE004=B.PDP002 INNER JOIN MOXPWD C ON A.PWE001=C.PWD001 WHERE B.idx IN(" + idxStr + ") AND C.PWD002='" + workShop + "' AND PWE012=0 AND PWE002='未完工' GROUP BY PWE003,PWE004)" );
                    //strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPDP WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN (SELECT PWE003,PWE004,PWE002 FROM (SELECT PWE001,PWE003,PWE004,PWE002 FROM MOXPWE WHERE PWE001 IN (SELECT MAX(PWE001) FROM MOXPWE WHERE PWE012=0 GROUP BY PWE003,PWE004)) A INNER JOIN MOXPWD B ON A.PWE001=B.PWD001 WHERE PWE002='完工' AND PWD002='{1}') B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE A.idx in ({0}))" ,idxStr ,workShop );
                    //strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPDP WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN (SELECT PWE003,PWE004,PWE002,PWE007 FROM (SELECT PWE001,PWE003,PWE004,PWE002,PWE007 FROM MOXPWE WHERE PWE001 IN (SELECT MAX(PWE001) FROM MOXPWE WHERE PWE012=0 GROUP BY PWE003,PWE004)) A INNER JOIN MOXPWD B ON A.PWE001=B.PWD001 WHERE PWE002='完工' AND PWD002='{1}') B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE A.idx in ({0}) GROUP BY PWE003,PWE004,PWE002,PDP025,idx HAVING PDP025<SUM(ISNULL(PWE007,0)))" ,idxStr ,workShop );

                    //strSql . AppendFormat ( "SELECT PDP001,PDP002 FROM MOXPDP WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN (SELECT PWE003,PWE004,PWE002,PWE007 FROM (SELECT PWE001,PWE003,PWE004,PWE002,SUM(PWE007) PWE007 FROM MOXPWE WHERE PWE001 IN (SELECT MAX(PWE001) FROM MOXPWE WHERE PWE012=0 GROUP BY PWE003,PWE004) GROUP BY PWE001,PWE003,PWE004,PWE002) A INNER JOIN MOXPWD B ON A.PWE001=B.PWD001 WHERE PWE002='完工' AND PWD002='{1}') B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE A.idx in ({0}) GROUP BY PWE003,PWE004,PWE002,PWE007,PDP025,A.idx HAVING PDP025=PWE007) ORDER BY PDP001,PDP002" ,idxStr ,workShop );

                    strSql . AppendFormat ( "SELECT PDP001,PDP002 FROM MOXPDP WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN (SELECT PWE003,PWE004,PWE007 FROM (SELECT MAX(PWE001) PWE001,PWE003,PWE004,SUM(PWE007) PWE007 FROM MOXPWE WHERE PWE012=0 AND PWE002='完工' GROUP BY PWE003,PWE004) A INNER JOIN MOXPWD B ON A.PWE001=B.PWD001 WHERE PWD002='{1}') B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE A.idx in ({0}) GROUP BY PWE003,PWE004,PWE007,PDP025,A.idx HAVING PDP025=PWE007) ORDER BY PDP001,PDP002" ,idxStr ,workShop );

                    x = SqlHelper . returnCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 6; //正式产品已经存在 不允许排
                    else
                        x = 5; //新增 
                }
            }

            return x;
        }
        
        /// <summary>
        /// 生成油漆日计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Add_BL_Day ( CarpenterEntity . ProductionPaintDayPWDEntity _model ,List<string> strList ,bool planScheduling )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _model . PWD001 = GetBLOddNumDay ( strSql );
            
            DataTable da = completionRate ( _model . PWD002 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _model . PWD009 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "CO" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "CO" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PWD003" ] . ToString ( ) ) )
                    _model . PWD010 = null;
                else
                    _model . PWD010 = Convert . ToDateTime ( da . Rows [ 0 ] [ "PWD003" ] . ToString ( ) );
            }
            else
            {
                _model . PWD009 = 0;
                _model . PWD010 = null;
            }
            strSql = new StringBuilder ( );
            _model . PWD005 = false;
            _model . PWD006 = false;
            _model . PWD007 = UserInformation . dt ( );
            _model . PWD008 = UserInformation . UserName;
            strSql . Append ( "INSERT INTO MOXPWD (" );
            strSql . Append ( "PWD001,PWD002,PWD003,PWD004,PWD005,PWD006,PWD007,PWD008,PWD009,PWD010) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PWD001,@PWD002,@PWD003,@PWD004,@PWD005,@PWD006,@PWD007,@PWD008,@PWD009,@PWD010) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWD001",SqlDbType.NVarChar,20),
                new SqlParameter("@PWD002",SqlDbType.NVarChar,20),
                new SqlParameter("@PWD003",SqlDbType.Date),
                new SqlParameter("@PWD004",SqlDbType.Date),
                new SqlParameter("@PWD005",SqlDbType.Bit),
                new SqlParameter("@PWD006",SqlDbType.Bit),
                new SqlParameter("@PWD007",SqlDbType.Date),
                new SqlParameter("@PWD008",SqlDbType.NVarChar,20),
                new SqlParameter("@PWD009",SqlDbType.Decimal,10),
                new SqlParameter("@PWD010",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . PWD001;
            parameter [ 1 ] . Value = _model . PWD002;
            parameter [ 2 ] . Value = _model . PWD003;
            parameter [ 3 ] . Value = _model . PWD004;
            parameter [ 4 ] . Value = _model . PWD005;
            parameter [ 5 ] . Value = _model . PWD006;
            parameter [ 6 ] . Value = _model . PWD007;
            parameter [ 7 ] . Value = _model . PWD008;
            parameter [ 8 ] . Value = _model . PWD009;
            parameter [ 9 ] . Value = _model . PWD010;
            SQLString . Add ( strSql ,parameter );

            CarpenterEntity . ProductionPaintDayPWEEntity _modelPLX = new CarpenterEntity . ProductionPaintDayPWEEntity ( );

            string idxList = "";
            foreach ( string str in strList )
            {
                if ( idxList == "" )
                    idxList = "'" + str + "'";
                else
                    idxList += "," + "'" + str + "'";
            }

            if ( planScheduling )
                da = GetDataTableBLPlan ( idxList ,_model . PWD002 ,_model . PWD003 );
            else
                da = GetDataTableBL_Add ( idxList ,_model . PWD002 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPLX . PWE001 = _model . PWD001;
                _modelPLX . PWE009 = _model . PWD007;
                _modelPLX . PWE010 = _model . PWD008;
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPLX . PWE002 = "完工";
                    _modelPLX . PWE003 = da . Rows [ i ] [ "PDP001" ] . ToString ( );
                    _modelPLX . PWE004 = da . Rows [ i ] [ "PDP002" ] . ToString ( );
                    _modelPLX . PWE005 = da . Rows [ i ] [ "PDP003" ] . ToString ( );
                    _modelPLX . PWE006 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PDP025" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PDP025" ] . ToString ( ) );
                    _modelPLX . PWE007 = _modelPLX . PWE006;
                    _modelPLX . PWE008 = da . Rows [ i ] [ "PDP024" ] . ToString ( );
                    _modelPLX . PWE011 = false;
                    _modelPLX . PWE012 = planScheduling;

                    if ( _modelPLX . PWE012 == false )
                    {
                        if ( ExistsNum ( _modelPLX ) )
                        {
                            //计划数量=计划数量-预排报工数量
                            //_modelPLX . PWE007 = _modelPLX . PWE007 - getPlanNum ( _modelPLX ,_model . PWD002 );
                            _modelPLX . PWE007 = _modelPLX . PWE007 - getPlanNumY ( _modelPLX ,_model . PWD002 );
                        }
                    }

                    if ( _modelPLX . PWE007 != 0 )
                    {
                        _modelPLX . PWE006 = _modelPLX . PWE007;
                        add_bl_day ( _modelPLX ,strSql ,SQLString );
                        //回写计划完成时间
                        if ( planScheduling == false )
                        {
                            edit_bl_date ( _modelPLX ,_model . PWD002 ,strSql ,SQLString );
                        }
                    }                   
                }
            }
            else
                return false;

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        /// <summary>
        /// 生成油漆日计划覆盖
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns>1:无此单号  2:选择产品不允许重复生成  3:生成成功  4:生成失败</returns>
        public int Esit_BL_Day ( CarpenterEntity . ProductionPaintDayPWDEntity _model ,List<string> strList ,bool planScheduling )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PWD001 FROM MOXPWD " );
            strSql . AppendFormat ( "WHERE PWD002='{0}' AND PWD003='{1}'" ,_model . PWD002 ,_model . PWD003 );

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PWD001" ] . ToString ( ) ) )
                    _model . PWD001 = string . Empty;
                else
                    _model . PWD001 = da . Rows [ 0 ] [ "PWD001" ] . ToString ( );
            }
            else
                _model . PWD001 = string . Empty;

            if ( _model . PWD001 == string . Empty )
                return 1;

            strSql = new StringBuilder ( );
            _model . PWD005 = false;
            _model . PWD006 = false;
            _model . PWD007 = UserInformation . dt ( );

            strSql . Append ( "UPDATE MOXPWD SET " );
            strSql . Append ( "PWD002=@PWD002," );
            strSql . Append ( "PWD003=@PWD003," );
            strSql . Append ( "PWD004=@PWD004," );
            strSql . Append ( "PWD005=@PWD005," );
            strSql . Append ( "PWD006=@PWD006," );
            strSql . Append ( "PWD007=@PWD007," );
            strSql . Append ( "PWD008=@PWD008," );
            strSql . Append ( "PWD009=@PWD009," );
            strSql . Append ( "PWD010=@PWD010 " );
            strSql . Append ( "WHERE PWD001=@PWD001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWD001",SqlDbType.NVarChar,20),
                new SqlParameter("@PWD002",SqlDbType.NVarChar,20),
                new SqlParameter("@PWD003",SqlDbType.Date),
                new SqlParameter("@PWD004",SqlDbType.Date),
                new SqlParameter("@PWD005",SqlDbType.Bit),
                new SqlParameter("@PWD006",SqlDbType.Bit),
                new SqlParameter("@PWD007",SqlDbType.Date),
                new SqlParameter("@PWD008",SqlDbType.NVarChar,20),
                new SqlParameter("@PWD009",SqlDbType.Decimal,10),
                new SqlParameter("@PWD010",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . PWD001;
            parameter [ 1 ] . Value = _model . PWD002;
            parameter [ 2 ] . Value = _model . PWD003;
            parameter [ 3 ] . Value = _model . PWD004;
            parameter [ 4 ] . Value = _model . PWD005;
            parameter [ 5 ] . Value = _model . PWD006;
            parameter [ 6 ] . Value = _model . PWD007;
            parameter [ 7 ] . Value = _model . PWD008;
            parameter [ 8 ] . Value = _model . PWD009;
            parameter [ 9 ] . Value = _model . PWD010;
            SQLString . Add ( strSql ,parameter );

            CarpenterEntity . ProductionPaintDayPWEEntity _modelPLX = new CarpenterEntity . ProductionPaintDayPWEEntity ( );

            string idxList = "";
            foreach ( string str in strList )
            {
                if ( idxList == "" )
                    idxList = "'" + str + "'";
                else
                    idxList += "," + "'" + str + "'";
            }
            DataTable dt;
            if ( planScheduling == true )
                dt = GetDataTableBLPlan ( idxList ,_model . PWD002 ,_model . PWD003 );
            else
                dt = GetDataTableBL ( idxList ,_model . PWD002 );
            da = null;
            da = GetDataTablePWE ( _model . PWD001 );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPLX . PWE001 = _model . PWD001;
                _modelPLX . PWE009 = _model . PWD007;
                _modelPLX . PWE010 = _model . PWD008;
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelPLX . PWE002 = "完工";
                    _modelPLX . PWE003 = dt . Rows [ i ] [ "PDP001" ] . ToString ( );
                    _modelPLX . PWE004 = dt . Rows [ i ] [ "PDP002" ] . ToString ( );
                    _modelPLX . PWE005 = dt . Rows [ i ] [ "PDP003" ] . ToString ( );
                    _modelPLX . PWE006 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PDP025" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PDP025" ] . ToString ( ) );
                    _modelPLX . PWE007 = _modelPLX . PWE006;
                    _modelPLX . PWE008 = dt . Rows [ i ] [ "PDP024" ] . ToString ( );
                    _modelPLX . PWE011 = false;
                    _modelPLX . PWE012 = planScheduling;

                    if ( da . Select ( "PWE002='" + _modelPLX . PWE002 + "' AND PWE003='" + _modelPLX . PWE003 + "' AND PWE004='" + _modelPLX . PWE004 + "'" ) . Length < 1 )
                    {
                        //if ( _modelPLX . PWE012 == false )
                        //{
                        //    if ( ExistsNum ( _modelPLX ) )
                        //    {
                        //        //计划数量=计划数量-预排报工数量
                        //        //_modelPLX . PWE007 = _modelPLX . PWE007 - getPlanNum ( _modelPLX ,_model . PWD002 );
                        //        _modelPLX . PWE007 = _modelPLX . PWE007 - getPlanNum ( _modelPLX );
                        //    }
                        //}
                        if ( _modelPLX . PWE007 != 0 )
                        {
                            add_bl_day ( _modelPLX ,strSql ,SQLString );
                            if ( planScheduling == false )
                            {
                                edit_bl_date ( _modelPLX ,_model . PWD002 ,strSql ,SQLString );
                            }
                        }
                    }
                    else
                        edit_bl_day ( _modelPLX ,strSql ,SQLString );             
                }
            }
            else
                return 2;

            bool result = SqlHelper . ExecuteSqlTran ( SQLString );
            if ( result == true )
                return 3;
            else
                return 4;
        }

        /// <summary>
        /// 获取油漆日计划单号
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        string GetBLOddNumDay ( StringBuilder strSql )
        {
            strSql . Append ( "SELECT MAX(PWD001) PWD001 FROM MOXPWD" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PWD001" ] . ToString ( ) ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PWD001" ] . ToString ( ) . Substring ( 0 ,8 ) == UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PWD001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        /// <summary>
        /// 获取完成率和工作日日期
        /// </summary>
        /// <returns></returns>
        DataTable completionRate ( string gx )
        {         
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS(SELECT SUM(CASE PWD002 WHEN '底漆' THEN PWF007 WHEN '油磨' THEN PWF008 WHEN '修色' THEN PWF009 WHEN '面漆' THEN PWF010  WHEN '软包' THEN PWF011 END)*1.0/PWE007 PWE007,PWD003,PWE003,PWE004 FROM MOXPWD A LEFT JOIN MOXPWE B ON A.PWD001=B.PWE001 LEFT JOIN MOXPWF C ON B.PWE003=C.PWF002 AND B.PWE004=C.PWF003 AND B.PWE001=C.PWF017 WHERE A.idx=(SELECT MAX(idx) FROM MOXPWD) AND B.PWE012=0 AND PWD002='{0}' GROUP BY PWE007,PWD003,PWE003,PWE004)," ,gx );
            strSql . Append ( "CFT AS (SELECT COUNT(1) COUN,PWE003,PWE004 FROM MOXPWD A INNER JOIN MOXPWE B ON A.PWD001=B.PWE001 WHERE A.idx=(SELECT MAX(idx) FROM MOXPWD) AND B.PWE012=0 GROUP BY PWE003,PWE004) " );
            strSql . Append ( "SELECT CONVERT(DECIMAL(11,2),SUM(ISNULL(PWE007,0))/SUM(COUN)*100) CO,A.PWD003 FROM CET A INNER JOIN CFT B ON A.PWE003=B.PWE003 AND A.PWE004=B.PWE004 GROUP BY PWD003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取油漆单据 预排
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableBLPlan ( string strWhere ,string workShop ,DateTime dt)
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT PDP001,PDP002,PDP003,PDP004,PDP024,PDP025 FROM MOXPDP " );
            //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPDP A LEFT JOIN MOXPWE B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 LEFT JOIN MOXPWD C ON B.PWE001=C.PWD001 WHERE A.idx IN (" + strWhere + ") AND PWD002='" + workShop + "') AND idx IN (" + strWhere + ")" );

            string columns = string . Empty;
            if ( workShop . Equals ( ColumnValues . yq_dq ) )
                columns = "PWF007";
            else if ( workShop . Equals ( ColumnValues . yq_ym ) )
                columns = "PWF008";
            else if ( workShop . Equals ( ColumnValues . yq_xs ) )
                columns = "PWF009";
            else if ( workShop . Equals ( ColumnValues . yq_mq ) )
                columns = "PWF010";
            else if ( workShop . Equals ( ColumnValues . yq_rb ) )
                columns = "PWF011";

            //同批号和品号可以预排多次，知道报工数量等于订单数量
            strSql . AppendFormat ( "SELECT  PDP001,PDP002,PDP003,PDP004,PDP024,PDP025-SUM(ISNULL({3},0)) PDP025 FROM MOXPDP A LEFT JOIN MOXPWF C ON A.PDP001=C.PWF002 AND A.PDP002=C.PWF003 WHERE A.idx IN ({0}) AND PDP001+PDP002 NOT IN (SELECT A.PWE003+A.PWE004 FROM MOXPWE A INNER JOIN MOXPWD D ON A.PWE001=D.PWD001 INNER JOIN MOXPDP C ON A.PWE003=C.PDP001 AND A.PWE004=C.PDP002 WHERE D.PWD002='{1}' AND PWD003='{2}') GROUP BY PDP001,PDP002,PDP003,PDP004,PDP024,PDP025 HAVING PDP025>SUM(ISNULL({3},0))" ,strWhere ,workShop ,dt ,columns );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取油漆单据  正排  增加
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public DataTable GetDataTableBL_Add ( string strWhere ,string workShop )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "SELECT PDP001,PDP002,PDP003,PDP004,PDP024,PDP025 FROM MOXPDP A LEFT JOIN (SELECT PWE007,PWE003,PWE004 FROM MOXPWE A INNER JOIN MOXPWD B ON A.PWE001=B.PWD001 WHERE PWD002='{0}') B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 " ,workShop );
            //strSql . AppendFormat ( "WHERE A.idx in ({0}) AND A.idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN (SELECT PWE003,PWE004,PWE002,PWE007 FROM (SELECT PWE001,PWE003,PWE004,PWE002,PWE007 FROM MOXPWE WHERE PWE001 IN (SELECT MAX(PWE001) FROM MOXPWE WHERE PWE012=0 GROUP BY PWE003,PWE004)) A INNER JOIN MOXPWD B ON A.PWE001=B.PWD001 WHERE PWE002='完工' AND PWD002='{1}') B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE A.idx in ({0}) GROUP BY PWE003,PWE004,PWE002,PDP025,idx HAVING PDP025<SUM(ISNULL(PWE007,0)) ) GROUP BY PDP001,PDP002,PDP003,PDP004,PDP024,PDP025 ORDER BY PDP001,PDP002" ,strWhere ,workShop );

            strSql . AppendFormat ( "SELECT PDP001,PDP002,PDP003,PDP004,PDP024,PDP025 FROM MOXPDP WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN (SELECT PWE003,PWE004,PWE007 FROM (SELECT MAX(PWE001) PWE001,PWE003,PWE004,SUM(PWE007) PWE007 FROM MOXPWE WHERE PWE012=0 AND PWE002='完工' GROUP BY PWE003,PWE004) A INNER JOIN MOXPWD B ON A.PWE001=B.PWD001 WHERE PWD002='{1}') B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE A.idx in ({0}) GROUP BY PWE003,PWE004,PWE007,PDP025,A.idx HAVING PDP025=PWE007) ORDER BY PDP001,PDP002" ,strWhere ,workShop );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取备料单据 非预排
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableBL ( string strWhere ,string workShop )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT PDP001,PDP002,PDP003,PDP004,PDP024,PDP025 FROM MOXPDP WHERE idx IN (" + strWhere + ") AND idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN MOXPWE B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE A.idx IN (" + strWhere + ") AND B.idx IN (SELECT idx FROM MOXPWE WHERE (PWE001='" + oddNum + "' AND PWE012=1) OR (PWE012=0 AND PWE002='完工')))" );
            strSql . AppendFormat ( "SELECT PDP001,PDP002,PDP003,PDP004,PDP024,PDP025-SUM(ISNULL(PWE007,0)) PDP025 FROM MOXPDP A LEFT JOIN (SELECT PWE007,PWE003,PWE004 FROM MOXPWE A INNER JOIN MOXPWD B ON A.PWE001=B.PWD001 WHERE PWD002='{1}') B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE A.idx IN ({0}) GROUP BY PDP001,PDP002,PDP003,PDP004,PDP024,PDP025 HAVING PDP025>SUM(ISNULL(PWE007,0))" ,strWhere ,workShop );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 获取相同单号的日计划
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePWE ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PWE002,PWE003,PWE004 FROM MOXPWE " );
            strSql . AppendFormat ( "WHERE PWE001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否预排过
        /// </summary>
        /// <returns></returns>
        bool ExistsNum ( CarpenterEntity . ProductionPaintDayPWEEntity _modelPLT )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPWE WHERE PWE003='{0}' AND PWE004='{1}'" ,_modelPLT . PWE003 ,_modelPLT . PWE004 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取预排报工数量
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <returns></returns>
        int getPlanNum ( CarpenterEntity . ProductionPaintDayPWEEntity _modelPLT ,string workShop )
        {
            StringBuilder strSql = new StringBuilder ( );
            string column = string . Empty;
            if ( workShop . Equals ( ColumnValues.yq_dq ) )
                column = "PWF007";
            if ( workShop . Equals ( ColumnValues . yq_ym ) )
                column = "PWF008";
            if ( workShop . Equals ( ColumnValues . yq_xs ) )
                column = "PWF009";
            if ( workShop . Equals ( ColumnValues . yq_mq ) )
                column = "PWF010";
            if ( workShop . Equals ( ColumnValues . yq_rb ) )
                column = "PWF011";

            strSql . AppendFormat ( "SELECT SUM({2}) {2} FROM MOXPWE A INNER JOIN MOXPWF B ON A.PWE003=B.PWF002 AND A.PWE004=B.PWF003 WHERE PWE003='{0}' AND PWE004='{1}'" ,_modelPLT . PWE003 ,_modelPLT . PWE004 ,column );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ column ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToInt32 ( dt . Rows [ 0 ] [ column ] . ToString ( ) );
            }
            else
                return 0;
        }

        /// <summary>
        /// 获取已排数量
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <returns></returns>
        int getPlanNumY ( CarpenterEntity . ProductionPaintDayPWEEntity _modelPLT ,string workShop)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT SUM(ISNULL(PWE007,0)) PWE007 FROM MOXPWE A INNER JOIN MOXPWD B ON A.PWE001=B.PWD001 WHERE PWE001!='{0}' AND PWE003='{1}' AND PWE004='{2}' AND PWE012=0 AND PWD002='{3}'" ,_modelPLT . PWE001 ,_modelPLT . PWE003 ,_modelPLT . PWE004 ,workShop );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PWE007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ 0 ] [ "PWE007" ] . ToString ( ) );
            else
                return 0;
        }

        void add_bl_day ( CarpenterEntity . ProductionPaintDayPWEEntity _modelPLX ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPWE (" );
            strSql . Append ( "PWE001,PWE002,PWE003,PWE004,PWE005,PWE006,PWE007,PWE008,PWE009,PWE010,PWE011,PWE012) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PWE001,@PWE002,@PWE003,@PWE004,@PWE005,@PWE006,@PWE007,@PWE008,@PWE009,@PWE010,@PWE011,@PWE012) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWE001",SqlDbType.NVarChar,20),
                new SqlParameter("@PWE002",SqlDbType.NVarChar,20),
                new SqlParameter("@PWE003",SqlDbType.NVarChar,20),
                new SqlParameter("@PWE004",SqlDbType.NVarChar,20),
                new SqlParameter("@PWE005",SqlDbType.NVarChar,20),
                new SqlParameter("@PWE006",SqlDbType.Int),
                new SqlParameter("@PWE007",SqlDbType.Int),
                new SqlParameter("@PWE008",SqlDbType.NVarChar,200),
                new SqlParameter("@PWE009",SqlDbType.Date),
                new SqlParameter("@PWE010",SqlDbType.NVarChar,20),
                new SqlParameter("@PWE011",SqlDbType.Bit),
                new SqlParameter("@PWE012",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _modelPLX . PWE001;
            parameter [ 1 ] . Value = _modelPLX . PWE002;
            parameter [ 2 ] . Value = _modelPLX . PWE003;
            parameter [ 3 ] . Value = _modelPLX . PWE004;
            parameter [ 4 ] . Value = _modelPLX . PWE005;
            parameter [ 5 ] . Value = _modelPLX . PWE006;
            parameter [ 6 ] . Value = _modelPLX . PWE007;
            parameter [ 7 ] . Value = _modelPLX . PWE008;
            parameter [ 8 ] . Value = _modelPLX . PWE009;
            parameter [ 9 ] . Value = _modelPLX . PWE010;
            parameter [ 10 ] . Value = _modelPLX . PWE011;
            parameter [ 11 ] . Value = _modelPLX . PWE012;
            SQLString . Add ( strSql ,parameter );
        }

        void edit_bl_day ( CarpenterEntity . ProductionPaintDayPWEEntity _modelPLX ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPWE SET " );
            strSql . Append ( "PWE006=@PWE006," );
            strSql . Append ( "PWE007=@PWE007," );
            strSql . Append ( "PWE008=@PWE008," );
            strSql . Append ( "PWE009=@PWE009," );
            strSql . Append ( "PWE010=@PWE010," );
            strSql . Append ( "PWE012=@PWE012 " );
            strSql . Append ( "WHERE PWE001=@PWE001 AND " );
            strSql . Append ( "PWE003=@PWE003 AND " );
            strSql . Append ( "PWE004=@PWE004 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWE001",SqlDbType.NVarChar,20),
                new SqlParameter("@PWE003",SqlDbType.NVarChar,20),
                new SqlParameter("@PWE004",SqlDbType.NVarChar,20),
                new SqlParameter("@PWE006",SqlDbType.Int),
                new SqlParameter("@PWE007",SqlDbType.Int),
                new SqlParameter("@PWE008",SqlDbType.NVarChar,200),
                new SqlParameter("@PWE009",SqlDbType.Date),
                new SqlParameter("@PWE010",SqlDbType.NVarChar,20),
                new SqlParameter("@PWE012",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _modelPLX . PWE001;
            parameter [ 1 ] . Value = _modelPLX . PWE003;
            parameter [ 2 ] . Value = _modelPLX . PWE004;
            parameter [ 3 ] . Value = _modelPLX . PWE006;
            parameter [ 4 ] . Value = _modelPLX . PWE007;
            parameter [ 5 ] . Value = _modelPLX . PWE008;
            parameter [ 6 ] . Value = _modelPLX . PWE009;
            parameter [ 7 ] . Value = _modelPLX . PWE010;
            parameter [ 8 ] . Value = _modelPLX . PWE012;
            SQLString . Add ( strSql ,parameter );
        }


        /// <summary>
        /// 日计划生产时编辑各工段计划完成数量
        /// </summary>
        /// <param name="_modelPLX"></param>
        /// <param name="planTime"></param>
        /// <param name="BLgd"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_bl_date ( CarpenterEntity . ProductionPaintDayPWEEntity _modelPLX ,string BLgd ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            if ( BLgd . Equals ( ColumnValues . yq_dq ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP008=ISNULL(PDP008,0)+'{0}' WHERE PDP001='{1}' AND PDP002='{2}'" ,_modelPLX . PWE007 ,_modelPLX . PWE003 ,_modelPLX . PWE004 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( BLgd . Equals ( ColumnValues . yq_ym ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP011=ISNULL(PDP011,0)+'{0}' WHERE PDP001='{1}' AND PDP002='{2}'" ,_modelPLX . PWE007 ,_modelPLX . PWE003 ,_modelPLX . PWE004 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( BLgd . Equals ( ColumnValues . yq_xs ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP014=ISNULL(PDP014,0)+'{0}' WHERE PDP001='{1}' AND PDP002='{2}'" ,_modelPLX . PWE007 ,_modelPLX . PWE003 ,_modelPLX . PWE004 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( BLgd . Equals ( ColumnValues . yq_mq ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP017=ISNULL(PDP017,0)+'{0}' WHERE PDP001='{1}' AND PDP002='{2}'" ,_modelPLX . PWE007 ,_modelPLX . PWE003 ,_modelPLX . PWE004 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( BLgd . Equals ( ColumnValues . yq_bz ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP028=ISNULL(PDP028,0)+'{0}' WHERE PDP001='{1}' AND PDP002='{2}'" ,_modelPLX . PWE007 ,_modelPLX . PWE003 ,_modelPLX . PWE004 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }

        }

        /// <summary>
        /// 获取油漆日计划明细
        /// </summary>
        /// <param name="workShopSection"></param>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string weekEnds ,string productNum ,string workShop)
        {
            //string columns = string . Empty;
            //if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_dq ) )
            //    columns = "PWF007";
            //else if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_ym ) )
            //    columns = "PWF008";
            //else if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_xs ) )
            //    columns = "PWF009";
            //else if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_mq ) )
            //    columns = "PWF010";
            //else if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_bz ) )
            //    columns = "PWF016";
            
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select PWE001 workShopSection,PWE007 Remark,PWD004 PlanTime,PWE008 commen from MOXPWE A INNER JOIN MOXPWD C ON A.PWE001=C.PWD001 " );
            strSql . AppendFormat ( "WHERE PWE003='{0}' AND PWE004='{1}' ORDER BY PWD002,PWE001 " ,weekEnds ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取油漆报工记录
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public DataTable getDataTable ( string weekEnds ,string productNum ,string workShop )
        {
            string columns = string . Empty;
            if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_dq ) )
                columns = "PWF007";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_ym ) )
                columns = "PWF008";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_xs ) )
                columns = "PWF009";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_mq ) )
                columns = "PWF010";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_bz ) )
                columns = "PWF016";
            
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PWF001 workShopSection,{0} Remark,PWF012 PlanTime,PWE008 commen FROM MOXPWF LEFT JOIN MOXPWE ON PWF017=PWE001 AND PWF002=PWE003 AND PWF003=PWE004 WHERE PWF002='{1}' AND PWF003='{2}' AND {0}>0 ORDER BY PWF001" ,columns ,weekEnds ,productNum );


            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
