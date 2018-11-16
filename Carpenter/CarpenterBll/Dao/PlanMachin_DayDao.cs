using System;
using System . Collections . Generic;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class PlanMachin_DayDao
    {
        /// <summary>
        /// 是否存在生产机加工日计划   相同的工段和计划日期
        /// </summary>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public int Exists_Day_Machine ( string workShop ,DateTime dt ,List<string> intList ,bool planCheck )
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
            if ( workShop . Equals ( ColumnValues . jjg_jgzx ) )
                columns = "PMY007";
            else if ( workShop . Equals ( ColumnValues . jjg_kszk ) )
                columns = "PMY008";
            else if ( workShop . Equals ( ColumnValues . jjg_dy ) )
                columns = "PMY009";

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXPMW " );
            strSql . AppendFormat ( "WHERE PMW002='{0}' AND PMW003='{1}'" ,workShop , dt  );

            if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
            {
                x = 1; //编辑

                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPMW " );
                strSql . AppendFormat ( "WHERE PMW002='{0}' AND PMW003='{1}' AND PMW005=1" ,workShop , dt );
                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return 2; //已注销


                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPMW " );
                strSql . AppendFormat ( "WHERE PMW002='{0}' AND PMW003='{1}' AND PMW006=1" ,workShop , dt  );
                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return 3; //已审核

                strSql = new StringBuilder ( );
                if ( planCheck )
                {
                    //同批号和品号只能排一次
                    //strSql . Append ( "SELECT COUNT(1) COUNT FROM MOXPST WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPMX B ON A.PST001=B.PMX003 AND A.PST002=B.PMX004 INNER JOIN MOXPMW C ON B.PMX001=C.PMW001 " );
                    //strSql . Append ( "WHERE A.idx IN (" + idxStr + ") AND PMW002='" + workShop + "' AND PMW003='" + dt  + "') AND idx IN (" + idxStr + ")" );

                    //同批号和品号，只要报工数量少于订单数量，则可以多次预排
                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPST A LEFT JOIN MOXPMY C ON A.PST001=C.PMY002 AND A.PST002=C.PMY003 WHERE A.idx IN ({0}) AND PST001+PST002 NOT IN (SELECT A.PMX003+A.PMX004 FROM MOXPMX A INNER JOIN MOXPMW D ON A.PMX001=D.PMW001 INNER JOIN MOXPST C ON A.PMX003=C.PST001 AND A.PMX004=C.PST002 WHERE D.PMW002='{1}' AND PMW003='{2}') GROUP BY PST028,PST001,PST002 HAVING PST028>SUM(ISNULL({3},0))" ,idxStr ,workShop ,dt ,columns );

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4; //预排产品已经存在  不允许排
                    else
                        x = 1;  //编辑
                }
                else
                {
                    strSql . AppendFormat ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN (SELECT PMX003,PMX004,PMX002 FROM (SELECT PMX001,PMX003,PMX004,PMX002 FROM MOXPMX WHERE PMX001 IN (SELECT MAX(PMX001) FROM MOXPMX WHERE PMX012=0 GROUP BY PMX003,PMX004)) A INNER JOIN MOXPMW B ON A.PMX001=B.PMW001 WHERE PMX002='完工' AND PMW002='{1}' AND PMW003='{2}') B  ON A.PST001=B.PMX003 AND A.PST002=B.PMX004 WHERE A.idx in ({0})) ORDER BY PST001,PST002" ,idxStr ,workShop , dt  );

                    x = SqlHelper . returnCount ( strSql . ToString ( ) );
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
                    //同批号和品号只能排一次
                    //strSql . Append ( "SELECT COUNT(1) COUNT FROM MOXPST WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPMX B ON A.PST001=B.PMX003 AND A.PST002=B.PMX004 INNER JOIN MOXPMW C ON B.PMX001=C.PMW001 " );
                    //strSql . Append ( "WHERE A.idx IN (" + idxStr + ") AND PMW002='" + workShop + "') AND idx IN (" + idxStr + ")" );

                    //同批号和品号，只要报工数量少于订单数量，则可以多次预排
                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPST A LEFT JOIN MOXPMY C ON A.PST001=C.PMY002 AND A.PST002=C.PMY003 WHERE A.idx IN ({0}) AND PST001+PST002 NOT IN (SELECT A.PMX003+A.PMX004 FROM MOXPMX A INNER JOIN MOXPMW D ON A.PMX001=D.PMW001 INNER JOIN MOXPST C ON A.PMX003=C.PST001 AND A.PMX004=C.PST002 WHERE D.PMW002='{1}' AND PMW003='{2}') GROUP BY PST028,PST001,PST002 HAVING PST028>SUM(ISNULL({3},0))" ,idxStr ,workShop ,dt ,columns );

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4; //预排产品已经存在  不允许排
                    else
                        x = 5;  //新增
                }
                else
                {
                    //查询已经排正式且未完工的产品 预排的不管
                    strSql . AppendFormat ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN (SELECT PMX003,PMX004,PMX002 FROM (SELECT PMX001,PMX003,PMX004,PMX002 FROM MOXPMX WHERE PMX001 IN (SELECT MAX(PMX001) FROM MOXPMX WHERE PMX012=0 GROUP BY PMX003,PMX004)) A INNER JOIN MOXPMW B ON A.PMX001=B.PMW001 WHERE PMX002='完工' AND PMW002='{1}') B  ON A.PST001=B.PMX003 AND A.PST002=B.PMX004 WHERE A.idx in ({0})) ORDER BY PST001,PST002" ,idxStr ,workShop );

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
        /// 生成机加工日计划覆盖
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns>1:无此单号  2:选择产品不允许重复生成  3:生成成功  4:生成失败</returns>
        public int Esit_J_Day ( CarpenterEntity . PlanMachinWorkPMWEntity _model ,List<string> strList ,bool planScheduling )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PMW001 FROM MOXPMW " );
            strSql . AppendFormat ( "WHERE PMW002='{0}' AND PMW003='{1}'" ,_model . PMW002 ,_model . PMW003 );

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PMW001" ] . ToString ( ) ) )
                    _model . PMW001 = string . Empty;
                else
                    _model . PMW001 = da . Rows [ 0 ] [ "PMW001" ] . ToString ( );
            }
            else
                _model . PMW001 = string . Empty;

            if ( _model . PMW001 == string . Empty )
                return 1;

            strSql = new StringBuilder ( );
            _model . PMW005 = false;
            _model . PMW006 = false;
            _model . PMW007 = UserInformation . dt ( );

            strSql . Append ( "UPDATE MOXPMW SET " );
            strSql . Append ( "PMW002=@PMW002," );
            strSql . Append ( "PMW003=@PMW003," );
            strSql . Append ( "PMW004=@PMW004," );
            strSql . Append ( "PMW005=@PMW005," );
            strSql . Append ( "PMW006=@PMW006," );
            strSql . Append ( "PMW007=@PMW007," );
            strSql . Append ( "PMW008=@PMW008," );
            strSql . Append ( "PMW009=@PMW009," );
            strSql . Append ( "PMW010=@PMW010 " );
            strSql . Append ( "WHERE PMW001=@PMW001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMW001",SqlDbType.NVarChar,20),
                new SqlParameter("@PMW002",SqlDbType.NVarChar,20),
                new SqlParameter("@PMW003",SqlDbType.Date),
                new SqlParameter("@PMW004",SqlDbType.Date),
                new SqlParameter("@PMW005",SqlDbType.Bit),
                new SqlParameter("@PMW006",SqlDbType.Bit),
                new SqlParameter("@PMW007",SqlDbType.Date),
                new SqlParameter("@PMW008",SqlDbType.NVarChar,20),
                new SqlParameter("@PMW009",SqlDbType.Decimal,10),
                new SqlParameter("@PMW010",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . PMW001;
            parameter [ 1 ] . Value = _model . PMW002;
            parameter [ 2 ] . Value = _model . PMW003;
            parameter [ 3 ] . Value = _model . PMW004;
            parameter [ 4 ] . Value = _model . PMW005;
            parameter [ 5 ] . Value = _model . PMW006;
            parameter [ 6 ] . Value = _model . PMW007;
            parameter [ 7 ] . Value = _model . PMW008;
            parameter [ 8 ] . Value = _model . PMW009;
            parameter [ 9 ] . Value = _model . PMW010;
            SQLString . Add ( strSql ,parameter );

            CarpenterEntity . PlanMachinWorkPMXEntity _modelPLX = new CarpenterEntity . PlanMachinWorkPMXEntity ( );

            string idxList = "";
            foreach ( string str in strList )
            {
                if ( idxList == "" )
                    idxList = "'" + str + "'";
                else
                    idxList += "," + "'" + str + "'";
            }
            DataTable dt;

            da = null;
            da = GetDataTablePMX ( _model . PMW001 );

            dt = getTableOfLeaveOver ( _model . PMW001 ,_model . PMW002 );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPLX . PMX001 = _model . PMW001;
                _modelPLX . PMX009 = _model . PMW007;
                _modelPLX . PMX010 = _model . PMW008;
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPLX . PMX002 = "未完工";
                    _modelPLX . PMX003 = dt . Rows [ i ] [ "PMX003" ] . ToString ( );
                    _modelPLX . PMX004 = dt . Rows [ i ] [ "PMX004" ] . ToString ( );
                    _modelPLX . PMX005 = dt . Rows [ i ] [ "PMX005" ] . ToString ( );
                    _modelPLX . PMX006 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PMX006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PMX006" ] . ToString ( ) );
                    _modelPLX . PMX007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PMX007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PMX007" ] . ToString ( ) );
                    _modelPLX . PMX008 = dt . Rows [ i ] [ "PMX008" ] . ToString ( );
                    _modelPLX . PMX011 = false;
                    _modelPLX . PMX012 = false;
                    _modelPLX . PMX013 = dt . Rows [ i ] [ "PMX001" ] . ToString ( );

                    if ( da . Select ( "PMX003='" + _modelPLX . PMX003 + "' AND PMX004='" + _modelPLX . PMX004 + "' AND PMX013='" + _modelPLX . PMX013 + "'" ) . Length < 1 )
                    {
                        if ( _modelPLX . PMX007 != 0 )
                            add_bl_day ( _modelPLX ,strSql ,SQLString );
                    }
                    else
                        edit_bl_day ( _modelPLX ,strSql ,SQLString );
                }
            }

            if ( planScheduling == true )
                dt = GetDataTableBLPlan ( idxList ,_model . PMW002 ,_model . PMW003 );
            else
                dt = GetDataTableBL ( idxList ,_model . PMW001 );
            
            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPLX . PMX001 = _model . PMW001;
                _modelPLX . PMX009 = _model . PMW007;
                _modelPLX . PMX010 = _model . PMW008;
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelPLX . PMX002 = "未完工";
                    _modelPLX . PMX003 = dt . Rows [ i ] [ "PST001" ] . ToString ( );
                    _modelPLX . PMX004 = dt . Rows [ i ] [ "PST002" ] . ToString ( );
                    _modelPLX . PMX005 = dt . Rows [ i ] [ "PST003" ] . ToString ( );
                    _modelPLX . PMX006 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PST028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PST028" ] . ToString ( ) );
                    _modelPLX . PMX007 = _modelPLX . PMX006;
                    _modelPLX . PMX008 = string . Empty;
                    _modelPLX . PMX011 = false;
                    _modelPLX . PMX012 = planScheduling;
                    _modelPLX . PMX013 = string . Empty;

                    if ( da . Select ( "PMX002='" + _modelPLX . PMX002 + "' AND PMX003='" + _modelPLX . PMX003 + "' AND PMX004='" + _modelPLX . PMX004 + "' AND PMX013='" + _modelPLX . PMX013 + "'" ) . Length < 1 )
                    {
                        if ( _modelPLX . PMX012 == false )
                        {
                            if ( ExistsNum ( _modelPLX ) )
                            {
                                //计划数量=计划数量-预排报工数量
                                _modelPLX . PMX007 = _modelPLX . PMX007 - getPlanNum ( _modelPLX ,_model . PMW002 );
                            }
                        }
                        if ( _modelPLX . PMX007 != 0 )
                            add_bl_day ( _modelPLX ,strSql ,SQLString );
                    }
                    else
                        edit_bl_day ( _modelPLX ,strSql ,SQLString );

                    if ( planScheduling == false )
                    {
                        //if ( Exists_bl_date ( _modelPLX ,_model . PMW002 ) == true )
                        edit_bl_date ( _modelPLX ,_model . PMW003 ,_model . PMW002 ,strSql ,SQLString );
                    }
                }
            }

            if ( SQLString . Count < 1 )
                return 2;


            bool result = SqlHelper . ExecuteSqlTran ( SQLString );
            if ( result == true )
                return 3;
            else
                return 4;
        }
        
        /// <summary>
        /// 生成机加工日计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Add_J_Day ( CarpenterEntity . PlanMachinWorkPMWEntity _model ,List<string> strList ,bool planScheduling )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _model . PMW001 = GetBLOddNumDay ( strSql );

            DataTable da = completionRate ( );
            if ( da != null && da . Rows . Count > 0 )
            {
                _model . PMW009 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "CO" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "CO" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PMW003" ] . ToString ( ) ) )
                    _model . PMW010 = UserInformation . dt ( );
                else
                    _model . PMW010 = Convert . ToDateTime ( da . Rows [ 0 ] [ "PMW003" ] . ToString ( ) );
            }
            strSql = new StringBuilder ( );
            _model . PMW005 = false;
            _model . PMW006 = false;
            _model . PMW007 = UserInformation . dt ( );
            strSql . Append ( "INSERT INTO MOXPMW (" );
            strSql . Append ( "PMW001,PMW002,PMW003,PMW004,PMW005,PMW006,PMW007,PMW008,PMW009,PMW010) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PMW001,@PMW002,@PMW003,@PMW004,@PMW005,@PMW006,@PMW007,@PMW008,@PMW009,@PMW010) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMW001",SqlDbType.NVarChar,20),
                new SqlParameter("@PMW002",SqlDbType.NVarChar,20),
                new SqlParameter("@PMW003",SqlDbType.Date),
                new SqlParameter("@PMW004",SqlDbType.Date),
                new SqlParameter("@PMW005",SqlDbType.Bit),
                new SqlParameter("@PMW006",SqlDbType.Bit),
                new SqlParameter("@PMW007",SqlDbType.Date),
                new SqlParameter("@PMW008",SqlDbType.NVarChar,20),
                new SqlParameter("@PMW009",SqlDbType.Decimal,10),
                new SqlParameter("@PMW010",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . PMW001;
            parameter [ 1 ] . Value = _model . PMW002;
            parameter [ 2 ] . Value = _model . PMW003;
            parameter [ 3 ] . Value = _model . PMW004;
            parameter [ 4 ] . Value = _model . PMW005;
            parameter [ 5 ] . Value = _model . PMW006;
            parameter [ 6 ] . Value = _model . PMW007;
            parameter [ 7 ] . Value = _model . PMW008;
            parameter [ 8 ] . Value = _model . PMW009;
            parameter [ 9 ] . Value = _model . PMW010;
            SQLString . Add ( strSql ,parameter );

            CarpenterEntity . PlanMachinWorkPMXEntity _modelPLX = new CarpenterEntity . PlanMachinWorkPMXEntity ( );

            string idxList = "";
            foreach ( string str in strList )
            {
                if ( idxList == "" )
                    idxList = "'" + str + "'";
                else
                    idxList += "," + "'" + str + "'";
            }

            if ( planScheduling )
                da = GetDataTableBLPlan ( idxList ,_model . PMW002 ,_model . PMW003 );
            else
                da = GetDataTableBL_Add ( idxList ,_model . PMW002 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPLX . PMX001 = _model . PMW001;
                _modelPLX . PMX009 = _model . PMW007;
                _modelPLX . PMX010 = _model . PMW008;
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPLX . PMX002 = "未完工";
                    _modelPLX . PMX003 = da . Rows [ i ] [ "PST001" ] . ToString ( );
                    _modelPLX . PMX004 = da . Rows [ i ] [ "PST002" ] . ToString ( );
                    _modelPLX . PMX005 = da . Rows [ i ] [ "PST003" ] . ToString ( );
                    _modelPLX . PMX006 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PST028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PST028" ] . ToString ( ) );
                    _modelPLX . PMX007 = _modelPLX . PMX006;
                    _modelPLX . PMX008 = string . Empty;
                    _modelPLX . PMX011 = false;
                    _modelPLX . PMX012 = planScheduling;
                    _modelPLX . PMX013 = string . Empty;

                    if ( _modelPLX . PMX012 == false )
                    {
                        if ( ExistsNum ( _modelPLX ) )
                        {
                            //计划数量=计划数量-预排报工数量
                            _modelPLX . PMX007 = _modelPLX . PMX007 - getPlanNum ( _modelPLX ,_model . PMW002 );
                        }
                    }
                    if ( _modelPLX . PMX007 != 0 )
                        add_bl_day ( _modelPLX ,strSql ,SQLString );
                    //回写计划完成时间
                    if ( planScheduling == false )
                    {
                        //if ( Exists_bl_date ( _modelPLX  ,_model . PMW002 ) == true )
                        edit_bl_date ( _modelPLX ,_model . PMW003 ,_model . PMW002 ,strSql ,SQLString );
                    }
                }
            }

            da = getTableOfLeaveOver ( _model . PMW001 ,_model . PMW002 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPLX . PMX001 = _model . PMW001;
                _modelPLX . PMX009 = _model . PMW007;
                _modelPLX . PMX010 = _model . PMW008;
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPLX . PMX002 = "未完工";
                    _modelPLX . PMX003 = da . Rows [ i ] [ "PMX003" ] . ToString ( );
                    _modelPLX . PMX004 = da . Rows [ i ] [ "PMX004" ] . ToString ( );
                    _modelPLX . PMX005 = da . Rows [ i ] [ "PMX005" ] . ToString ( );
                    _modelPLX . PMX006 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PMX006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PMX006" ] . ToString ( ) );
                    _modelPLX . PMX007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PMX007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PMX007" ] . ToString ( ) );
                    _modelPLX . PMX008 = da . Rows [ i ] [ "PMX008" ] . ToString ( );
                    _modelPLX . PMX011 = false;
                    _modelPLX . PMX012 = false;
                    _modelPLX . PMX013 = da . Rows [ i ] [ "PMX001" ] . ToString ( );

                    if ( _modelPLX . PMX007 != 0 )
                        add_bl_day ( _modelPLX ,strSql ,SQLString );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取机加工日计划遗留
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="workShop"></param>
        /// <returns></returns>
        DataTable getTableOfLeaveOver ( string oddNum ,string workShop )
        {
            string colomn = string . Empty;
            if ( workShop . Equals ( ColumnValues . jjg_dy ) )
                colomn = "PMY009";
            else if ( workShop . Equals ( ColumnValues . jjg_jgzx ) )
                colomn = "PMY007";
            else if ( workShop . Equals ( ColumnValues . jjg_kszk ) )
                colomn = "PMY008";

            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "WITH CET AS (" );
            //strSql . Append ( "SELECT PMX001,PMX003,PMX004,PMX005,PMX006,PMX007,PMX008 FROM MOXPMW A INNER JOIN MOXPMX B ON A.PMW001=B.PMX001 INNER JOIN MOXPMY C ON B.PMX003=C.PMY002 AND B.PMX004=C.PMY003 AND B.PMX001!=C.PMY016 " );
            //strSql . AppendFormat ( "WHERE PMW001=(SELECT MAX(PMW001) FROM MOXPMW WHERE PMW001<'{0}') " ,oddNum );
            //strSql . AppendFormat ( " AND PMX012=0 AND PMW002='{0}' " ,workShop );
            ////strSql . Append ( "GROUP BY PMX001,PMX003,PMX004,PMX005,PMX006,PMX007,PMX008 " );
            //strSql . Append ( "),CFT AS ( " );
            //strSql . AppendFormat ( "SELECT PMX001,PMX003,PMX004,PMX005,PMX006,PMX007-SUM(ISNULL({0},0)) PMX007,PMX008 FROM MOXPMW A INNER JOIN MOXPMX B ON A.PMW001=B.PMX001 INNER JOIN MOXPMY C ON B.PMX003=C.PMY002 AND B.PMX004=C.PMY003 AND B.PMX001=C.PMY016 " ,colomn );
            //strSql . AppendFormat ( "WHERE PMW001=(SELECT MAX(PMW001) FROM MOXPMW WHERE PMW001<'{0}') " ,oddNum );
            //strSql . AppendFormat ( "AND PMX012=0 AND PMW002='{0}' " ,workShop );
            //strSql . AppendFormat ( "GROUP BY PMX001,PMX003,PMX004,PMX005,PMX006,PMX007,PMX008 HAVING SUM(ISNULL({0},0))<PMX007) " ,colomn );
            //strSql . Append ( "SELECT * FROM CET UNION  SELECT * FROM CFT" );
            strSql . AppendFormat ( "SELECT PMX001,PMX003,PMX004,PMX005,PMX006,PMX007-SUM(ISNULL({0},0)) PMX007,PMX008 FROM (SELECT MAX(PMW001) PMW001,PMW002 FROM MOXPMW WHERE PMW002='{1}' GROUP BY PMW002) A INNER JOIN MOXPMX B ON A.PMW001=B.PMX001 LEFT JOIN MOXPMY C ON B.PMX003=C.PMY002 AND B.PMX004=C.PMY003 AND B.PMX001=C.PMY016 " ,colomn ,workShop );
            strSql . AppendFormat ( "WHERE PMW001=(SELECT MAX(PMW001) FROM MOXPMW WHERE PMW001<'{0}' AND PMW002='{1}') " ,oddNum ,workShop );
            strSql . AppendFormat ( "AND PMX012=0 AND PMW002='{0}' " ,workShop );
            strSql . AppendFormat ( "GROUP BY PMX001,PMX003,PMX004,PMX005,PMX006,PMX007,PMX008 HAVING SUM(ISNULL({0},0))<PMX007 " ,colomn );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取机加工日计划单号
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        string GetBLOddNumDay ( StringBuilder strSql )
        {
            strSql . Append ( "SELECT MAX(PMW001) PMW001 FROM MOXPMW" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PMW001" ] . ToString ( ) ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PMW001" ] . ToString ( ) . Substring ( 0 ,8 ) == UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PMW001" ] . ToString ( ) ) + 1 ) . ToString ( );
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
        DataTable completionRate ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS(SELECT SUM(CASE PMW002 WHEN '加工中心' THEN PMY007 WHEN '开榫钻孔' THEN PMY008 WHEN '倒圆' THEN PMY009 END)*1.0/PMX007 PMX007,PMW003,PMX003,PMX004 FROM MOXPMW A INNER JOIN MOXPMX B ON A.PMW001=B.PMX001 INNER JOIN MOXPMY C ON B.PMX003=C.PMY002 AND B.PMX004=C.PMY003 AND B.PMX001=C.PMY016 WHERE A.idx=(SELECT MAX(idx) FROM MOXPMW) AND B.PMX012=0 GROUP BY PMX007,PMW003,PMX003,PMX004)," );
            strSql . Append ( "CFT AS (SELECT COUNT(1) COUN,PMX003,PMX004 FROM MOXPMW A INNER JOIN MOXPMX B ON A.PMW001=B.PMX001 WHERE A.idx=(SELECT MAX(idx) FROM MOXPMW) AND B.PMX012=0 GROUP BY PMX003,PMX004)" );
            strSql . Append ( "SELECT CONVERT(DECIMAL(11,2),SUM(PMX007)/SUM(COUN)*100) CO,A.PMW003 FROM CET A INNER JOIN CFT B ON A.PMX003=B.PMX003 AND A.PMX004=B.PMX004 GROUP BY PMW003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取机加工单据 预排
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableBLPlan ( string strWhere ,string workShop ,DateTime dt)
        {
            StringBuilder strSql = new StringBuilder ( );
            //同批号和品号只能排一次
            //strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST " );
            //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPMX B ON A.PST001=B.PMX003 AND A.PST002=B.PMX004 INNER JOIN MOXPMW C ON B.PMX001=C.PMW001 WHERE A.idx IN (" + strWhere + ") AND PMW002='" + workShop + "') AND idx IN (" + strWhere + ")" );

            //同批号和品号只要报工数量少于订单量,则可以多次预排
            string columns = string . Empty;
            if ( workShop . Equals ( ColumnValues . jjg_jgzx ) )
                columns = "PMY007";
            else if ( workShop . Equals ( ColumnValues . jjg_kszk ) )
                columns = "PMY008";
            else if ( workShop . Equals ( ColumnValues . jjg_dy ) )
                columns = "PMY009";

            strSql . AppendFormat ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028-SUM(ISNULL({2},0)) PST028 FROM MOXPST A LEFT JOIN MOXPMY C ON A.PST001=C.PMY002 AND A.PST002=C.PMY003 WHERE A.idx IN ({0}) AND PST001+PST002 NOT IN (SELECT A.PMX003+A.PMX004 FROM MOXPMX A INNER JOIN MOXPMW D ON A.PMX001=D.PMW001 INNER JOIN MOXPST C ON A.PMX003=C.PST001 AND A.PMX004=C.PST002 WHERE D.PMW002='{1}' AND PMW003='{3}') GROUP BY PST028,PST001,PST002,PST003,PST004,PST025 HAVING PST028>SUM(ISNULL({2},0))" ,strWhere ,workShop ,columns ,dt );


            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取机加工单据 非预排
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableBL ( string strWhere ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST WHERE idx IN (" + strWhere + ") AND idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPMX B ON A.PST001=B.PMX003 AND A.PST002=B.PMX004 WHERE A.idx IN (" + strWhere + ") AND B.idx IN (SELECT idx FROM MOXPMX WHERE (PMX001='" + oddNum + "' AND PMX012=1) OR (PMX012=0 AND PMX002='完工')))" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取备料单据  正排  增加
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public DataTable GetDataTableBL_Add ( string strWhere ,string workShop )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN (SELECT PMX003,PMX004,PMX002 FROM (SELECT PMX001,PMX003,PMX004,PMX002 FROM MOXPMX WHERE PMX001 IN (SELECT MAX(PMX001) FROM MOXPMX WHERE PMX012=0 GROUP BY PMX003,PMX004)) A INNER JOIN MOXPMW B ON A.PMX001=B.PMW001 WHERE PMX002='完工' AND PMW002='{1}') B ON A.PST001=B.PMX003 AND A.PST002=B.PMX004 WHERE A.idx in ({0})) ORDER BY PST001,PST002" ,strWhere ,workShop );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取相同单号的日计划
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePMX ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PMX002,PMX003,PMX004,PMX013 FROM MOXPMX " );
            strSql . AppendFormat ( "WHERE PMX001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void add_bl_day ( CarpenterEntity . PlanMachinWorkPMXEntity _modelPLX ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPMX (" );
            strSql . Append ( "PMX001,PMX002,PMX003,PMX004,PMX005,PMX006,PMX007,PMX008,PMX009,PMX010,PMX011,PMX012,PMX013) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PMX001,@PMX002,@PMX003,@PMX004,@PMX005,@PMX006,@PMX007,@PMX008,@PMX009,@PMX010,@PMX011,@PMX012,@PMX013) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMX001",SqlDbType.NVarChar,20),
                new SqlParameter("@PMX002",SqlDbType.NVarChar,20),
                new SqlParameter("@PMX003",SqlDbType.NVarChar,20),
                new SqlParameter("@PMX004",SqlDbType.NVarChar,20),
                new SqlParameter("@PMX005",SqlDbType.NVarChar,20),
                new SqlParameter("@PMX006",SqlDbType.Int),
                new SqlParameter("@PMX007",SqlDbType.Int),
                new SqlParameter("@PMX008",SqlDbType.NVarChar,200),
                new SqlParameter("@PMX009",SqlDbType.Date),
                new SqlParameter("@PMX010",SqlDbType.NVarChar,20),
                new SqlParameter("@PMX011",SqlDbType.Bit),
                new SqlParameter("@PMX012",SqlDbType.Bit),
                new SqlParameter("@PMX013",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelPLX . PMX001;
            parameter [ 1 ] . Value = _modelPLX . PMX002;
            parameter [ 2 ] . Value = _modelPLX . PMX003;
            parameter [ 3 ] . Value = _modelPLX . PMX004;
            parameter [ 4 ] . Value = _modelPLX . PMX005;
            parameter [ 5 ] . Value = _modelPLX . PMX006;
            parameter [ 6 ] . Value = _modelPLX . PMX007;
            parameter [ 7 ] . Value = _modelPLX . PMX008;
            parameter [ 8 ] . Value = _modelPLX . PMX009;
            parameter [ 9 ] . Value = _modelPLX . PMX010;
            parameter [ 10 ] . Value = _modelPLX . PMX011;
            parameter [ 11 ] . Value = _modelPLX . PMX012;
            parameter [ 12 ] . Value = _modelPLX . PMX013;

            SQLString . Add ( strSql ,parameter );
        }

        void edit_bl_day ( CarpenterEntity . PlanMachinWorkPMXEntity _modelPLX ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPMX SET " );
            strSql . Append ( "PMX005=@PMX005," );
            strSql . Append ( "PMX006=@PMX006," );
            strSql . Append ( "PMX007=@PMX007," );
            strSql . Append ( "PMX008=@PMX008," );
            strSql . Append ( "PMX009=@PMX009," );
            strSql . Append ( "PMX010=@PMX010," );
            strSql . Append ( "PMX012=@PMX012 " );
            strSql . Append ( "WHERE PMX001=@PMX001 AND " );
            //strSql . Append ( "PMX002=PMX002 AND " );
            strSql . Append ( "PMX003=@PMX003 AND " );
            strSql . Append ( "PMX004=@PMX004 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMX001",SqlDbType.NVarChar,20),
                //new SqlParameter("PMX002",SqlDbType.NVarChar,20),
                new SqlParameter("@PMX003",SqlDbType.NVarChar,20),
                new SqlParameter("@PMX004",SqlDbType.NVarChar,20),
                new SqlParameter("@PMX005",SqlDbType.NVarChar,20),
                new SqlParameter("@PMX006",SqlDbType.Int),
                new SqlParameter("@PMX007",SqlDbType.Int),
                new SqlParameter("@PMX008",SqlDbType.NVarChar,200),
                new SqlParameter("@PMX009",SqlDbType.Date),
                new SqlParameter("@PMX010",SqlDbType.NVarChar,20),
                new SqlParameter("@PMX012",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _modelPLX . PMX001;
            //parameter [ 1 ] . Value = _modelPLX . PMX002;
            parameter [ 1 ] . Value = _modelPLX . PMX003;
            parameter [ 2 ] . Value = _modelPLX . PMX004;
            parameter [ 3 ] . Value = _modelPLX . PMX005;
            parameter [ 4 ] . Value = _modelPLX . PMX006;
            parameter [ 5 ] . Value = _modelPLX . PMX007;
            parameter [ 6 ] . Value = _modelPLX . PMX008;
            parameter [ 7 ] . Value = _modelPLX . PMX009;
            parameter [ 8 ] . Value = _modelPLX . PMX010;
            parameter [ 9 ] . Value = _modelPLX . PMX012;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 是否预排过
        /// </summary>
        /// <returns></returns>
        bool ExistsNum ( CarpenterEntity . PlanMachinWorkPMXEntity _modelPLT )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPMX WHERE PMX003='{0}' AND PMX004='{1}' AND PMX012=1 AND PMX001=(SELECT MAX(PMX001) FROM MOXPMX WHERE PMX001<'{2}')" ,_modelPLT . PMX003 ,_modelPLT . PMX004 ,_modelPLT . PMX001 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取预排报工数量
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <returns></returns>
        int getPlanNum ( CarpenterEntity . PlanMachinWorkPMXEntity _modelPLT ,string workShop )
        {
            StringBuilder strSql = new StringBuilder ( );
            string column = string . Empty;
            if ( workShop . Equals (   ColumnValues . jjg_jgzx ) )
                column = "PMY007";
            if ( workShop . Equals ( ColumnValues . jjg_kszk ) )
                column = "PMY008";
            if ( workShop . Equals ( ColumnValues . jjg_dy ) )
                column = "PMY009";

            strSql . AppendFormat ( "SELECT SUM({2}) {2} FROM MOXPMX A INNER JOIN MOXPMY B ON A.PMX003=B.PMY002 AND A.PMX004=B.PMY003 WHERE PMY015=1 AND PMX003='{0}' AND PMX004='{1}' AND PMX001=(SELECT MAX(PMX001) FROM MOXPMX WHERE PMX001<'{3}') GROUP BY PMX003,PMX004,PMX007" ,_modelPLT . PMX003 ,_modelPLT . PMX004 ,column ,_modelPLT . PMX001 );

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
        /// 看计划完成时间是否有
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        bool Exists_bl_date ( CarpenterEntity . PlanMachinWorkPMXEntity _modelPLX ,string gongDaun )
        {
            StringBuilder strSql = new StringBuilder ( );
            if ( gongDaun . Equals ( ColumnValues . jjg_jgzx ) )
                strSql . Append ( "SELECT PST017 PST FROM MOXPST " );
            if ( gongDaun . Equals ( ColumnValues . jjg_kszk ) )
                strSql . Append ( "SELECT PST019 PST FROM MOXPST  " );
            if ( gongDaun . Equals ( ColumnValues . jjg_dy ) )
                strSql . Append ( "SELECT PST021 PST FROM MOXPST  " );
            strSql . Append ( "WHERE PST001=@PST001 AND PST002=@PST002 " );

            SqlParameter [ ] parameter = {
                new SqlParameter("@PST001",SqlDbType.NVarChar,20),
                new SqlParameter("@PST002",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelPLX . PMX003;
            parameter [ 1 ] . Value = _modelPLX . PMX004;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PST" ] . ToString ( ) ) )
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        /// <summary>
        /// 日计划生产时编辑各工段计划完成日期
        /// </summary>
        /// <param name="_modelPLX"></param>
        /// <param name="planTime"></param>
        /// <param name="BLgd"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_bl_date ( CarpenterEntity . PlanMachinWorkPMXEntity _modelPLX ,DateTime? planTime ,string BLgd ,StringBuilder strSql ,Hashtable SQLString )
        {

            strSql = new StringBuilder ( );
            if ( BLgd . Equals ( ColumnValues . jjg_jgzx ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST017='{0}' WHERE PST001='{1}' AND PST002='{2}'" ,planTime ,_modelPLX . PMX003 ,_modelPLX . PMX004 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( BLgd . Equals ( ColumnValues . jjg_kszk ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST019='{0}' WHERE PST001='{1}' AND PST002='{2}'" ,planTime ,_modelPLX . PMX003 ,_modelPLX . PMX004 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( BLgd . Equals ( ColumnValues . jjg_dy ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST021='{0}' WHERE PST001='{1}' AND PST002='{2}'" ,planTime ,_modelPLX . PMX003 ,_modelPLX . PMX004 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }

        }

    }
}
