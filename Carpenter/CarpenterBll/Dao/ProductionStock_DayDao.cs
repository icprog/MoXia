using StudentMgr;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Text;

namespace CarpenterBll . Dao
{
    public class ProductionStock_DayDao
    {
        /// <summary>
        /// 生成备料日计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Add_BL_Day ( CarpenterEntity . PlanStockWorkPSWEntity _model ,List<string> strList ,bool planScheduling  )
        {
            DateTime? dtTime;
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _model . PSW001 = GetBLOddNumDay ( strSql );

            DataTable da = completionRate ( );
            if ( da != null && da . Rows . Count > 0 )
            {
                _model . PSW009 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "CO" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "CO" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PSW003" ] . ToString ( ) ) )
                    _model . PSW010 = null;
                else
                    _model . PSW010 = Convert . ToDateTime ( da . Rows [ 0 ] [ "PSW003" ] . ToString ( ) );
            }
            strSql = new StringBuilder ( );
            _model . PSW005 = false;
            _model . PSW006 = false;
            _model . PSW007 = GetDate ( );
            _model . PSW008 = UserInformation . UserName;
            strSql . Append ( "INSERT INTO MOXPSW (" );
            strSql . Append ( "PSW001,PSW002,PSW003,PSW004,PSW005,PSW006,PSW007,PSW008,PSW009,PSW010) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PSW001,@PSW002,@PSW003,@PSW004,@PSW005,@PSW006,@PSW007,@PSW008,@PSW009,@PSW010) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PSW001",SqlDbType.NVarChar,20),
                new SqlParameter("@PSW002",SqlDbType.NVarChar,20),
                new SqlParameter("@PSW003",SqlDbType.Date),
                new SqlParameter("@PSW004",SqlDbType.Date),
                new SqlParameter("@PSW005",SqlDbType.Bit),
                new SqlParameter("@PSW006",SqlDbType.Bit),
                new SqlParameter("@PSW007",SqlDbType.Date),
                new SqlParameter("@PSW008",SqlDbType.NVarChar,20),
                new SqlParameter("@PSW009",SqlDbType.Decimal,10),
                new SqlParameter("@PSW010",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . PSW001;
            parameter [ 1 ] . Value = _model . PSW002;
            parameter [ 2 ] . Value = _model . PSW003;
            parameter [ 3 ] . Value = _model . PSW004;
            parameter [ 4 ] . Value = _model . PSW005;
            parameter [ 5 ] . Value = _model . PSW006;
            parameter [ 6 ] . Value = _model . PSW007;
            parameter [ 7 ] . Value = _model . PSW008;
            parameter [ 8 ] . Value = _model . PSW009;
            parameter [ 9 ] . Value = _model . PSW010;
            SQLString . Add ( strSql ,parameter );

            CarpenterEntity . PlanStockWorkPSXEntity _modelPLX = new CarpenterEntity . PlanStockWorkPSXEntity ( );

            string idxList = "";
            foreach ( string str in strList )
            {
                if ( idxList == "" )
                    idxList = "'" + str + "'";
                else
                    idxList += "," + "'" + str + "'";
            }

            if ( planScheduling )
                da = GetDataTableBLPlan ( idxList ,_model . PSW002 ,_model . PSW003 );
            else
                da = GetDataTableBL_Add ( idxList ,_model . PSW002 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPLX . PSX001 = _model . PSW001;
                _modelPLX . PSX009 = _model . PSW007;
                _modelPLX . PSX010 = _model . PSW008;
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPLX . PSX002 = "未完工";
                    _modelPLX . PSX003 = da . Rows [ i ] [ "PST001" ] . ToString ( );
                    _modelPLX . PSX004 = da . Rows [ i ] [ "PST002" ] . ToString ( );
                    _modelPLX . PSX005 = da . Rows [ i ] [ "PST003" ] . ToString ( );
                    _modelPLX . PSX006 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PST028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PST028" ] . ToString ( ) );
                    _modelPLX . PSX007 = _modelPLX . PSX006;
                    _modelPLX . PSX008 = da . Rows [ i ] [ "PST025" ] . ToString ( );
                    _modelPLX . PSX011 = false;
                    _modelPLX . PSX012 = planScheduling;
                    _modelPLX . PSX013 = string . Empty;

                    if ( _modelPLX . PSX012 == false )
                    {
                        if ( ExistsNum ( _modelPLX ) )
                        {
                            //计划数量=计划数量-预排报工数量
                            _modelPLX . PSX007 = _modelPLX . PSX007 - getPlanNum ( _modelPLX ,_model . PSW002 );
                        }
                    }
                    if ( _modelPLX . PSX007 != 0 )
                        add_bl_day ( _modelPLX ,strSql ,SQLString );

                    //回写计划完成时间
                    if ( planScheduling == false )
                    {
                        //dtTime = Exists_bl_date ( _modelPLX ,_model . PSW002 );
                        dtTime = _model . PSW003;
                        edit_bl_date ( _modelPLX ,dtTime ,_model . PSW002 ,strSql ,SQLString );
                    }
                }
            }

            da = getTableOfLeaveOver ( _model . PSW001 ,_model . PSW002 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPLX . PSX001 = _model . PSW001;
                _modelPLX . PSX009 = _model . PSW007;
                _modelPLX . PSX010 = _model . PSW008;
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPLX . PSX002 = "未完工";
                    _modelPLX . PSX003 = da . Rows [ i ] [ "PSX003" ] . ToString ( );
                    _modelPLX . PSX004 = da . Rows [ i ] [ "PSX004" ] . ToString ( );
                    _modelPLX . PSX005 = da . Rows [ i ] [ "PSX005" ] . ToString ( );
                    _modelPLX . PSX006 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PSX006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PSX006" ] . ToString ( ) );
                    _modelPLX . PSX007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PSX007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PSX007" ] . ToString ( ) );
                    _modelPLX . PSX008 = da . Rows [ i ] [ "PSX008" ] . ToString ( );
                    _modelPLX . PSX011 = false;
                    _modelPLX . PSX012 = false;
                    _modelPLX . PSX013 = da . Rows [ i ] [ "PSX001" ] . ToString ( );
                    if ( _modelPLX . PSX007 != 0 )
                        add_bl_day ( _modelPLX ,strSql ,SQLString );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        /// <summary>
        /// 生成备料日计划覆盖
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns>1:无此单号  2:选择产品不允许重复生成  3:生成成功  4:生成失败</returns>
        public int Esit_BL_Day ( CarpenterEntity . PlanStockWorkPSWEntity _model ,List<string> strList ,bool planScheduling )
        {
            DateTime? dtTime = null;
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PSW001 FROM MOXPSW " );
            strSql . AppendFormat ( "WHERE PSW002='{0}' AND PSW003='{1}'" ,_model . PSW002 ,_model . PSW003 );

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PSW001" ] . ToString ( ) ) )
                    _model . PSW001 = string . Empty;
                else
                    _model . PSW001 = da . Rows [ 0 ] [ "PSW001" ] . ToString ( );
            }
            else
                _model . PSW001 = string . Empty;

            if ( _model . PSW001 == string . Empty )
                return 1;

            strSql = new StringBuilder ( );
            _model . PSW005 = false;
            _model . PSW006 = false;
            _model . PSW007 = GetDate ( );

            strSql . Append ( "UPDATE MOXPSW SET " );
            strSql . Append ( "PSW002=@PSW002," );
            strSql . Append ( "PSW003=@PSW003," );
            strSql . Append ( "PSW004=@PSW004," );
            strSql . Append ( "PSW005=@PSW005," );
            strSql . Append ( "PSW006=@PSW006," );
            strSql . Append ( "PSW007=@PSW007," );
            strSql . Append ( "PSW008=@PSW008," );
            strSql . Append ( "PSW009=@PSW009," );
            strSql . Append ( "PSW010=@PSW010 " );
            strSql . Append ( "WHERE PSW001=@PSW001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PSW001",SqlDbType.NVarChar,20),
                new SqlParameter("@PSW002",SqlDbType.NVarChar,20),
                new SqlParameter("@PSW003",SqlDbType.Date),
                new SqlParameter("@PSW004",SqlDbType.Date),
                new SqlParameter("@PSW005",SqlDbType.Bit),
                new SqlParameter("@PSW006",SqlDbType.Bit),
                new SqlParameter("@PSW007",SqlDbType.Date),
                new SqlParameter("@PSW008",SqlDbType.NVarChar,20),
                new SqlParameter("@PSW009",SqlDbType.Decimal,10),
                new SqlParameter("@PSW010",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . PSW001;
            parameter [ 1 ] . Value = _model . PSW002;
            parameter [ 2 ] . Value = _model . PSW003;
            parameter [ 3 ] . Value = _model . PSW004;
            parameter [ 4 ] . Value = _model . PSW005;
            parameter [ 5 ] . Value = _model . PSW006;
            parameter [ 6 ] . Value = _model . PSW007;
            parameter [ 7 ] . Value = _model . PSW008;
            parameter [ 8 ] . Value = _model . PSW009;
            parameter [ 9 ] . Value = _model . PSW010;
            SQLString . Add ( strSql ,parameter );

            CarpenterEntity . PlanStockWorkPSXEntity _modelPLX = new CarpenterEntity . PlanStockWorkPSXEntity ( );
            
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
            da = GetDataTablePSX ( _model . PSW001 );

            dt = getTableOfLeaveOver ( _model . PSW001 ,_model . PSW002 );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPLX . PSX001 = _model . PSW001;
                _modelPLX . PSX009 = _model . PSW007;
                _modelPLX . PSX010 = _model . PSW008;
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelPLX . PSX002 = "未完工";
                    _modelPLX . PSX003 = dt . Rows [ i ] [ "PSX003" ] . ToString ( );
                    _modelPLX . PSX004 = dt . Rows [ i ] [ "PSX004" ] . ToString ( );
                    _modelPLX . PSX005 = dt . Rows [ i ] [ "PSX005" ] . ToString ( );
                    _modelPLX . PSX006 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PSX006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PSX006" ] . ToString ( ) );
                    _modelPLX . PSX007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PSX007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PSX007" ] . ToString ( ) );
                    _modelPLX . PSX008 = dt . Rows [ i ] [ "PSX008" ] . ToString ( );
                    _modelPLX . PSX011 = false;
                    _modelPLX . PSX012 = false;
                    _modelPLX . PSX013 = dt . Rows [ i ] [ "PSX001" ] . ToString ( );

                    if ( da . Select ( "PSX003='" + _modelPLX . PSX003 + "' AND PSX004='" + _modelPLX . PSX004 + "' AND PSX013='" + _modelPLX . PSX013 + "'" ) . Length < 1 )
                    {
                        if ( _modelPLX . PSX007 != 0 )
                            add_bl_day ( _modelPLX ,strSql ,SQLString );
                    }
                    else
                        edit_bl_day ( _modelPLX ,strSql ,SQLString );
                }
            }

            if ( planScheduling == true )
                dt = GetDataTableBLPlan ( idxList ,_model . PSW002 ,_model . PSW003 );
            else
                dt = GetDataTableBL ( idxList ,_model . PSW001 );
           
            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPLX . PSX001 = _model . PSW001;
                _modelPLX . PSX009 = _model . PSW007;
                _modelPLX . PSX010 = _model . PSW008;
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelPLX . PSX002 = "未完工";
                    _modelPLX . PSX003 = dt . Rows [ i ] [ "PST001" ] . ToString ( );
                    _modelPLX . PSX004 = dt . Rows [ i ] [ "PST002" ] . ToString ( );
                    _modelPLX . PSX005 = dt . Rows [ i ] [ "PST003" ] . ToString ( );
                    _modelPLX . PSX006 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PST028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PST028" ] . ToString ( ) );
                    _modelPLX . PSX007 = _modelPLX . PSX006;
                    _modelPLX . PSX008 = string . Empty;
                    _modelPLX . PSX011 = false;
                    _modelPLX . PSX012 = planScheduling;
                    _modelPLX . PSX013 = string . Empty;

                    if ( da . Select ( "PSX002='" + _modelPLX . PSX002 + "' AND PSX003='" + _modelPLX . PSX003 + "' AND PSX004='" + _modelPLX . PSX004 + "' AND PSX013='" + _modelPLX . PSX013 + "'" ) . Length < 1 )
                    {
                        if ( _modelPLX . PSX012 == false )
                        {
                            if ( ExistsNum ( _modelPLX ) )
                            {
                                //计划数量=计划数量-预排报工数量
                                _modelPLX . PSX007 = _modelPLX . PSX007 - getPlanNum ( _modelPLX ,_model . PSW002 );
                            }
                        }
                        if ( _modelPLX . PSX007 != 0 )
                            add_bl_day ( _modelPLX ,strSql ,SQLString );
                    }
                    else
                        edit_bl_day ( _modelPLX ,strSql ,SQLString );

                    if ( planScheduling == false )
                    {
                        //if ( Exists_bl_date ( _modelPLX ,_model . PSW002 ) == true )
                        dtTime = _model . PSW003;
                        edit_bl_date ( _modelPLX ,dtTime ,_model . PSW002 ,strSql ,SQLString );
                    }
                }
            }
            //else
            //    return 2;

            if ( SQLString . Count < 1 )
                return 2;

            bool result = SqlHelper . ExecuteSqlTran ( SQLString );
            if ( result == true )
                return 3;
            else
                return 4;
        }
        
        DateTime GetDate ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GETDATE() t" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) ) )
                    return DateTime . Now;
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) );
            }
            else
                return DateTime . Now;
        }

        /// <summary>
        /// 获取备料日计划单号
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        string GetBLOddNumDay ( StringBuilder strSql )
        {
            strSql . Append ( "SELECT MAX(PSW001) PSW001 FROM MOXPSW" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PSW001" ] . ToString ( ) ) )
                    return GetDate ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PSW001" ] . ToString ( ) . Substring ( 0 ,8 ) == GetDate ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PSW001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return GetDate ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return GetDate ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        /// <summary>
        /// 获取完成率和工作日日期
        /// </summary>
        /// <returns></returns>
        DataTable completionRate ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS(SELECT SUM(CASE PSW002 WHEN '断料' THEN PDW007  WHEN '齿接' THEN PDW009  WHEN '修边' THEN PDW008 WHEN '拼板' THEN PDW010 WHEN '刨床' THEN PDW011 END)*1.0/PSX007 PSX007,PSW003,PSX003,PSX004 FROM MOXPSW A INNER JOIN MOXPSX B ON A.PSW001=B.PSX001 INNER JOIN MOXPDW C ON B.PSX003=C.PDW002 AND B.PSX004=C.PDW003  AND B.PSX001=C.PDW016 WHERE A.idx=(SELECT MAX(idx) FROM MOXPSW) AND B.PSX012=0 GROUP BY PSX007,PSW003,PSX003,PSX004)," );
            strSql . Append ( "CFT AS (SELECT COUNT(1) COUN,PSX003,PSX004 FROM MOXPSW A INNER JOIN MOXPSX B ON A.PSW001=B.PSX001 WHERE A.idx=(SELECT MAX(idx) FROM MOXPSW) AND B.PSX012=0 GROUP BY PSX003,PSX004)" );
            strSql . Append ( "SELECT CONVERT(DECIMAL(11,2),SUM(PSX007)/SUM(COUN)*100) CO,A.PSW003 FROM CET A INNER JOIN CFT B ON A.PSX003=B.PSX003 AND A.PSX004=B.PSX004 GROUP BY PSW003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取备料日计划遗留
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="workShop"></param>
        /// <returns></returns>
        DataTable getTableOfLeaveOver ( string oddNum ,string workShop )
        {
            string colomn = string . Empty;
            if ( workShop . Equals ( ColumnValues . bl_dl ) )
                colomn = "PDW007";
            else if ( workShop . Equals ( ColumnValues . bl_xb ) )
                colomn = "PDW008";
            else if ( workShop . Equals ( ColumnValues . bl_cj ) )
                colomn = "PDW009";
            else if ( workShop . Equals ( ColumnValues . bl_pb ) )
                colomn = "PDW010";
            else if ( workShop . Equals ( ColumnValues . bl_pc ) )
                colomn = "PDW011";
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "WITH CET AS (" );
            //strSql . Append ( "SELECT PSX001,PSX003,PSX004,PSX005,PSX006,PSX007,PSX008 FROM MOXPSW A INNER JOIN MOXPSX B ON A.PSW001=B.PSX001 INNER JOIN MOXPDW C ON B.PSX003=C.PDW002 AND B.PSX004=C.PDW003 AND B.PSX001!=C.PDW016 " );
            //strSql . AppendFormat ( "WHERE PSW001=(SELECT MAX(PSW001) FROM MOXPSW WHERE PSW001<'{0}') " ,oddNum );
            //strSql . AppendFormat ( "AND PSX012=0 AND PSW002='{0}' " ,workShop );
            ////strSql . Append ( "GROUP BY PSX001,PSX003,PSX004,PSX005,PSX006,PSX007,PSX008 " );
            //strSql . Append ( "),CFT AS ( " );
            //strSql . AppendFormat ( "SELECT PSX001,PSX003,PSX004,PSX005,PSX006,PSX007-SUM(ISNULL({0},0)) PSX007,PSX008 FROM MOXPSW A INNER JOIN MOXPSX B ON A.PSW001=B.PSX001 INNER JOIN MOXPDW C ON B.PSX003=C.PDW002 AND B.PSX004=C.PDW003 AND B.PSX001=C.PDW016 " ,colomn );
            //strSql . AppendFormat ( "WHERE PSW001=(SELECT MAX(PSW001) FROM MOXPSW WHERE PSW001<'{0}') " ,oddNum );
            //strSql . AppendFormat ( "AND PSX012=0 AND PSW002='{0}' " ,workShop );
            //strSql . AppendFormat ( "GROUP BY PSX001,PSX003,PSX004,PSX005,PSX006,PSX007,PSX008 HAVING SUM(ISNULL({0},0))<PSX007 ) " ,colomn );
            //strSql . Append ( "SELECT * FROM CET UNION  SELECT * FROM CFT" );
            strSql . AppendFormat ( "SELECT PSX001,PSX003,PSX004,PSX005,PSX006,PSX007-SUM(ISNULL({0},0)) PSX007,PSX008 FROM (SELECT MAX(PSW001) PSW001,PSW002 FROM MOXPSW  WHERE PSW002='{1}' GROUP BY PSW002) A INNER JOIN MOXPSX B ON A.PSW001=B.PSX001 LEFT JOIN MOXPDW C ON B.PSX003=C.PDW002 AND B.PSX004=C.PDW003 AND B.PSX001=C.PDW016 " ,colomn ,workShop );
            strSql . AppendFormat ( "WHERE PSW001=(SELECT MAX(PSW001) FROM MOXPSW WHERE PSW001<'{0}'  AND PSW002='{1}') AND PSX012=0 AND PSW002='{1}' GROUP BY PSX001,PSX003,PSX004,PSX005,PSX006,PSX007,PSX008 HAVING SUM(ISNULL({2},0))<PSX007 " ,oddNum ,workShop ,colomn );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取备料单据 非预排
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableBL ( string strWhere ,string oddNum)
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST " );
            //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPSX B ON A.PST001=B.PSX003 AND A.PST002=B.PSX004 WHERE A.idx IN (" + strWhere + ")  AND B.idx NOT IN (SELECT idx FROM MOXPSX WHERE PSX001='"+oddNum+ "' AND PSX012=1) AND PSX012=0 AND PSX002='完工') AND idx IN (" + strWhere + ")" );
            strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST WHERE idx IN ("+strWhere+ ") AND idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPSX B ON A.PST001=B.PSX003 AND A.PST002=B.PSX004 WHERE A.idx IN ("+strWhere+ ") AND B.idx IN (SELECT idx FROM MOXPSX WHERE (PSX001='"+oddNum+"' AND PSX012=1) OR (PSX012=0 AND PSX002='完工')))" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取备料单据 预排
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableBLPlan ( string strWhere ,string workShop ,DateTime dt)
        {
            StringBuilder strSql = new StringBuilder ( );
            //同批号和品号只能预排一次
            //strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST " );
            //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPST A LEFT JOIN MOXPSX B ON A.PST001=B.PSX003 AND A.PST002=B.PSX004 LEFT JOIN MOXPSW C ON B.PSX001=C.PSW001 WHERE A.idx IN (" + strWhere + ") AND PSW002='" + workShop + "') AND idx IN (" + strWhere + ")" );
            string columns = string . Empty;
            if ( workShop . Equals ( ColumnValues . bl_dl ) )
                columns = "PDW007";
            else if ( workShop . Equals ( ColumnValues . bl_xb ) )
                columns = "PDW008";
            else if ( workShop . Equals ( ColumnValues . bl_cj ) )
                columns = "PDW009";
            else if ( workShop . Equals ( ColumnValues . bl_pb ) )
                columns = "PDW010";
            else if ( workShop . Equals ( ColumnValues . bl_pc ) )
                columns = "PDW011";
            //同批号和品号，报工数量少于订单数量就可以持续预排
            strSql . AppendFormat ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028-SUM(ISNULL({3},0)) PST028 FROM MOXPST A LEFT JOIN MOXPDW C ON A.PST001=C.PDW002 AND A.PST002=C.PDW003  WHERE A.idx IN ({0}) AND PST001+PST002 NOT IN (SELECT A.PSX003+A.PSX004 FROM MOXPSX A INNER JOIN MOXPSW D ON A.PSX001=D.PSW001 INNER JOIN MOXPST C ON A.PSX003=C.PST001 AND A.PSX004=C.PST002 WHERE D.PSW002='{1}' AND PSW003='{2}') GROUP BY PST028,PST001,PST002,PST003,PST004,PST025 HAVING PST028>SUM(ISNULL({3},0)) " ,strWhere ,workShop ,dt ,columns );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取备料单据  正排  增加
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public DataTable GetDataTableBL_Add ( string strWhere ,string workShop)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN (SELECT PSX003,PSX004,PSX002 FROM (SELECT PSX001,PSX003,PSX004,PSX002 FROM MOXPSX WHERE PSX001 IN (SELECT MAX(PSX001) FROM MOXPSX WHERE PSX012=0 GROUP BY PSX003,PSX004)) A INNER JOIN MOXPSW B ON A.PSX001=B.PSW001 WHERE PSX002='完工' AND PSW002='{1}') B ON A.PST001=B.PSX003 AND A.PST002=B.PSX004 WHERE A.idx in ({0})) ORDER BY PST001,PST002" ,strWhere ,workShop );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 是否存在生产备料日计划   相同的工段和计划日期
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
            if ( workShop . Equals ( ColumnValues . bl_dl ) )
                columns = "PDW007";
            else if ( workShop . Equals ( ColumnValues . bl_xb ) )
                columns = "PDW008";
            else if ( workShop . Equals ( ColumnValues . bl_cj ) )
                columns = "PDW009";
            else if ( workShop . Equals ( ColumnValues . bl_pb ) )
                columns = "PDW010";
            else if ( workShop . Equals ( ColumnValues . bl_pc ) )
                columns = "PDW011";

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXPSW " );
            strSql . AppendFormat ( "WHERE PSW002='{0}' AND PSW003='{1}'" ,workShop ,dt );

            if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
            {
                x = 1; //编辑

                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPSW " );
                strSql . AppendFormat ( "WHERE PSW002='{0}' AND PSW003='{1}' AND PSW005=1" ,workShop ,dt );
                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return 2; //已注销


                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPSW " );
                strSql . AppendFormat ( "WHERE PSW002='{0}' AND PSW003='{1}' AND PSW006=1" ,workShop ,dt );
                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return 3; //已审核

                strSql = new StringBuilder ( );
                if ( planCheck )
                {
                    //strSql . Append ( "SELECT COUNT(1) COUNT FROM MOXPST WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPSX B ON A.PST001=B.PSX003 AND A.PST002=B.PSX004 INNER JOIN MOXPSW C ON B.PSX001=C.PSW001 " );
                    //strSql . Append ( "WHERE A.idx IN (" + idxStr + ") AND PSW002='" + workShop + "' AND PSW003='" + dt + "') AND idx IN (" + idxStr + ")" );


                    //同产品若预排报工少于订单数量,可多次预排,但是同单中只能预排一次
                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPST A LEFT JOIN MOXPDW C ON A.PST001=C.PDW002 AND A.PST002=C.PDW003 WHERE A.idx IN (334,331) AND PST001+PST002 NOT IN (SELECT A.PSX003+A.PSX004 FROM MOXPSX A INNER JOIN MOXPSW D ON A.PSX001=D.PSW001 INNER JOIN MOXPST C ON A.PSX003=C.PST001 AND A.PSX004=C.PST002 WHERE D.PSW002='{1}' AND PSW003='{2}') GROUP BY PST028,PST001,PST002 HAVING PST028>SUM(ISNULL({3},0))" ,idxStr ,workShop ,dt ,columns );

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4; //预排产品已经存在  不允许排
                    else
                        x = 1;  //编辑
                }
                else
                {
                    strSql . AppendFormat ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN (SELECT PSX003,PSX004,PSX002 FROM (SELECT PSX001,PSX003,PSX004,PSX002 FROM MOXPSX WHERE PSX001 IN (SELECT MAX(PSX001) FROM MOXPSX WHERE PSX012=0 GROUP BY PSX003,PSX004)) A INNER JOIN MOXPSW B ON A.PSX001=B.PSW001 WHERE PSX002='完工' AND PSW002='{1}' AND PSW003='{2}') B ON A.PST001=B.PSX003 AND A.PST002=B.PSX004 WHERE A.idx in ({0})) ORDER BY PST001,PST002" ,idxStr ,workShop ,dt );

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
                    //strSql . Append ( "SELECT COUNT(1) COUN FROM MOXPST A INNER JOIN MOXPSX B ON A.PST001=B.PSX003 AND A.PST002=B.PSX004 INNER JOIN MOXPSW C ON B.PSX001=C.PSW001 " );
                    //strSql . Append ( "WHERE A.idx IN(" + idxStr + ") AND C.PSW002='" + workShop + "'" );

                    //一次预排之后不可再预排
                    //strSql . Append ( "SELECT COUNT(1) COUNT FROM MOXPST WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPSX B ON A.PST001=B.PSX003 AND A.PST002=B.PSX004 INNER JOIN MOXPSW C ON B.PSX001=C.PSW001 " );
                    //strSql . Append ( "WHERE A.idx IN (" + idxStr + ") AND PSW002='" + workShop + "') AND idx IN (" + idxStr + ")" );

                    //同产品若预排报工少于订单数量,可多次预排
                    //strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPST A LEFT JOIN MOXPDW C ON A.PST001=C.PDW002 AND A.PST002=C.PDW003 LEFT JOIN MOXPSX B ON A.PST001=B.PSX003 AND A.PST002=B.PSX004 LEFT JOIN (SELECT PSW001 FROM MOXPSW WHERE PSW002='{1}') D ON B.PSX001=D.PSW001 WHERE A.idx IN ({0}) GROUP BY PST028 HAVING PST028>SUM(ISNULL({2},0))" ,idxStr ,workShop ,columns );
                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPST A LEFT JOIN MOXPDW C ON A.PST001=C.PDW002 AND A.PST002=C.PDW003 WHERE A.idx IN (334,331) AND PST001+PST002 NOT IN (SELECT A.PSX003+A.PSX004 FROM MOXPSX A INNER JOIN MOXPSW D ON A.PSX001=D.PSW001 INNER JOIN MOXPST C ON A.PSX003=C.PST001 AND A.PSX004=C.PST002 WHERE D.PSW002='{1}' AND PSW003='{2}') GROUP BY PST028,PST001,PST002 HAVING PST028>SUM(ISNULL({3},0))" ,idxStr ,workShop ,dt ,columns );

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4; //预排产品已经存在  不允许排
                    else
                        x = 5;  //新增
                }
                else
                {
                    //查询已经排正式且未完工的产品 预排的不管

                    //strSql . AppendFormat ( "SELECT COUNT(1) COUN FROM MOXPSX WHERE idx IN (SELECT MAX(A.idx) FROM MOXPSX A INNER JOIN MOXPST B ON A.PSX003=B.PST001 AND A.PSX004=B.PST002 INNER JOIN MOXPSW C ON A.PSX001=C.PSW001 WHERE B.idx IN(" + idxStr + ") AND C.PSW002='" + workShop + "' AND PSX012=0 AND PSX002='未完工' GROUP BY PSX003,PSX004)" );
                    strSql . AppendFormat ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN (SELECT PSX003,PSX004,PSX002 FROM (SELECT PSX001,PSX003,PSX004,PSX002 FROM MOXPSX WHERE PSX001 IN (SELECT MAX(PSX001) FROM MOXPSX WHERE PSX012=0 GROUP BY PSX003,PSX004)) A INNER JOIN MOXPSW B ON A.PSX001=B.PSW001 WHERE PSX002='完工' AND PSW002='{1}') B ON A.PST001=B.PSX003 AND A.PST002=B.PSX004 WHERE A.idx in ({0})) ORDER BY PST001,PST002" ,idxStr ,workShop );

                    x = SqlHelper . returnCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 6; //正式产品已经存在 不允许排
                    else
                        x = 5; //新增 
                }
            }

            return x;
        }
        
        void add_bl_day ( CarpenterEntity . PlanStockWorkPSXEntity _modelPLX ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPSX (" );
            strSql . Append ( "PSX001,PSX002,PSX003,PSX004,PSX005,PSX006,PSX007,PSX008,PSX009,PSX010,PSX011,PSX012,PSX013) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PSX001,@PSX002,@PSX003,@PSX004,@PSX005,@PSX006,@PSX007,@PSX008,@PSX009,@PSX010,@PSX011,@PSX012,@PSX013) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PSX001",SqlDbType.NVarChar,20),
                new SqlParameter("@PSX002",SqlDbType.NVarChar,20),
                new SqlParameter("@PSX003",SqlDbType.NVarChar,20),
                new SqlParameter("@PSX004",SqlDbType.NVarChar,20),
                new SqlParameter("@PSX005",SqlDbType.NVarChar,20),
                new SqlParameter("@PSX006",SqlDbType.Int),
                new SqlParameter("@PSX007",SqlDbType.Int),
                new SqlParameter("@PSX008",SqlDbType.NVarChar,200),
                new SqlParameter("@PSX009",SqlDbType.Date),
                new SqlParameter("@PSX010",SqlDbType.NVarChar,20),
                new SqlParameter("@PSX011",SqlDbType.Bit),
                new SqlParameter("@PSX012",SqlDbType.Bit),
                new SqlParameter("@PSX013",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelPLX . PSX001;
            parameter [ 1 ] . Value = _modelPLX . PSX002;
            parameter [ 2 ] . Value = _modelPLX . PSX003;
            parameter [ 3 ] . Value = _modelPLX . PSX004;
            parameter [ 4 ] . Value = _modelPLX . PSX005;
            parameter [ 5 ] . Value = _modelPLX . PSX006;
            parameter [ 6 ] . Value = _modelPLX . PSX007;
            parameter [ 7 ] . Value = _modelPLX . PSX008;
            parameter [ 8 ] . Value = _modelPLX . PSX009;
            parameter [ 9 ] . Value = _modelPLX . PSX010;
            parameter [ 10 ] . Value = _modelPLX . PSX011;
            parameter [ 11 ] . Value = _modelPLX . PSX012;
            parameter [ 12 ] . Value = _modelPLX . PSX013;


            SQLString . Add ( strSql ,parameter );
        }

        void edit_bl_day ( CarpenterEntity . PlanStockWorkPSXEntity _modelPLX ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPSX SET " );
            strSql . Append ( "PSX005=@PSX005," );
            strSql . Append ( "PSX006=@PSX006," );
            strSql . Append ( "PSX007=@PSX007," );
            strSql . Append ( "PSX008=@PSX008," );
            strSql . Append ( "PSX009=@PSX009," );
            strSql . Append ( "PSX010=@PSX010," );
            strSql . Append ( "PSX012=@PSX012 " );
            strSql . Append ( "WHERE PSX001=@PSX001 AND " );
            //strSql . Append ( "PSX002=PSX002 AND " );
            strSql . Append ( "PSX003=@PSX003 AND " );
            strSql . Append ( "PSX004=@PSX004 AND " );
            strSql . Append ( "PSX013=@PSX013 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PSX001",SqlDbType.NVarChar,20),
                //new SqlParameter("PSX002",SqlDbType.NVarChar,20),
                new SqlParameter("@PSX003",SqlDbType.NVarChar,20),
                new SqlParameter("@PSX004",SqlDbType.NVarChar,20),
                new SqlParameter("@PSX005",SqlDbType.NVarChar,20),
                new SqlParameter("@PSX006",SqlDbType.Int),
                new SqlParameter("@PSX007",SqlDbType.Int),
                new SqlParameter("@PSX008",SqlDbType.NVarChar,200),
                new SqlParameter("@PSX009",SqlDbType.Date),
                new SqlParameter("@PSX010",SqlDbType.NVarChar,20),
                new SqlParameter("@PSX012",SqlDbType.Bit),
                new SqlParameter("@PSX013",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelPLX . PSX001;
            //parameter [ 1 ] . Value = _modelPLX . PSX002;
            parameter [ 1 ] . Value = _modelPLX . PSX003;
            parameter [ 2 ] . Value = _modelPLX . PSX004;
            parameter [ 3 ] . Value = _modelPLX . PSX005;
            parameter [ 4 ] . Value = _modelPLX . PSX006;
            parameter [ 5 ] . Value = _modelPLX . PSX007;
            parameter [ 6 ] . Value = _modelPLX . PSX008;
            parameter [ 7 ] . Value = _modelPLX . PSX009;
            parameter [ 8 ] . Value = _modelPLX . PSX010;
            parameter [ 9 ] . Value = _modelPLX . PSX012;
            parameter [ 10 ] . Value = _modelPLX . PSX013;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 是否预排过
        /// </summary>
        /// <returns></returns>
        bool ExistsNum ( CarpenterEntity . PlanStockWorkPSXEntity _modelPLT )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPSX WHERE PSX003='{0}' AND PSX004='{1}' AND PSX012=1 AND PSX001=(SELECT MAX(PSX001) FROM MOXPSX WHERE PSX001<'{2}')" ,_modelPLT . PSX003 ,_modelPLT . PSX004 ,_modelPLT . PSX001 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取预排报工数量
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <returns></returns>
        int getPlanNum ( CarpenterEntity . PlanStockWorkPSXEntity _modelPLT ,string workShop )
        {
            StringBuilder strSql = new StringBuilder ( );
            string column = string . Empty;
            if ( workShop . Equals ( ColumnValues.bl_dl ) )
                column = "PDW007";
            else if ( workShop . Equals ( ColumnValues . bl_xb ) )
                column = "PDW008";
            else if ( workShop . Equals ( ColumnValues . bl_cj ) )
                column = "PDW009";
            else if ( workShop . Equals ( ColumnValues . bl_pb ) )
                column = "PDW010";
            else if ( workShop . Equals ( ColumnValues . bl_pc ) )
                column = "PDW011";

            strSql . AppendFormat ( "SELECT SUM({2}) {2} FROM MOXPSX A INNER JOIN MOXPDW B ON A.PSX003=B.PDW002 AND A.PSX004=B.PDW003 WHERE PDW015=1 AND PSX003='{0}' AND PSX004='{1}' AND PSX001=(SELECT MAX(PSX001) FROM MOXPSX WHERE PSX001<'{3}') GROUP BY PSX003,PSX004,PSX007" ,_modelPLT . PSX003 ,_modelPLT . PSX004 ,column ,_modelPLT . PSX001 );

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
        DateTime? Exists_bl_date ( CarpenterEntity . PlanStockWorkPSXEntity _modelPLX ,string gongDaun )
        {
            StringBuilder strSql = new StringBuilder ( );
            if ( gongDaun . Equals ( ColumnValues.bl_dl ) )
                strSql . Append ( "SELECT PST029 PST FROM MOXPST " );
            else if ( gongDaun . Equals ( ColumnValues . bl_xb ) )
                strSql . Append ( "SELECT PST007 PST FROM MOXPST  " );
            else if ( gongDaun . Equals ( ColumnValues . bl_cj ) )
                strSql . Append ( "SELECT PST009 PST FROM MOXPST  " );
            else if ( gongDaun . Equals ( ColumnValues . bl_pb ) )
                strSql . Append ( "SELECT PST011 PST FROM MOXPST  " );
            else if ( gongDaun . Equals ( ColumnValues . bl_pc ) )
                strSql . Append ( "SELECT PST013 PST FROM MOXPST " );
            strSql . Append ( "WHERE PST001=@PST001 AND PST002=@PST002 " );

            SqlParameter [ ] parameter = {
                new SqlParameter("@PST001",SqlDbType.NVarChar,20),
                new SqlParameter("@PST002",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelPLX . PSX003;
            parameter [ 1 ] . Value = _modelPLX . PSX004;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PST" ] . ToString ( ) ) )
                    return null;
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "PST" ] . ToString ( ) );
            }
            else
                return null;
        }


        /// <summary>
        /// 日计划生产时编辑各工段计划完成日期
        /// </summary>
        /// <param name="_modelPLX"></param>
        /// <param name="planTime"></param>
        /// <param name="BLgd"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_bl_date ( CarpenterEntity . PlanStockWorkPSXEntity _modelPLX ,DateTime? planTime ,string BLgd ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            if ( BLgd . Equals ( ColumnValues . bl_dl ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST029=@PST029 WHERE PST001='{0}' AND PST002='{1}'" ,_modelPLX . PSX003 ,_modelPLX . PSX004 );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PST029",SqlDbType.Date,3)
                };
                if ( planTime != null )
                    parameter [ 0 ] . Value = planTime;
                else
                    parameter [ 0 ] . Value = DBNull . Value;
                SQLString . Add ( strSql ,parameter );
                strSql = new StringBuilder ( );
            }
            if ( BLgd . Equals ( ColumnValues . bl_xb ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST007=@PST007 WHERE PST001='{0}' AND PST002='{1}'" ,_modelPLX . PSX003 ,_modelPLX . PSX004 );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PST007",SqlDbType.Date,3)
                };
                if ( planTime != null )
                    parameter [ 0 ] . Value = planTime;
                else
                    parameter [ 0 ] . Value = DBNull . Value;
                SQLString . Add ( strSql ,parameter );
                strSql = new StringBuilder ( );
            }
            if ( BLgd . Equals ( ColumnValues . bl_cj ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST009=@PST009 WHERE PST001='{1}' AND PST002='{2}'" ,planTime ,_modelPLX . PSX003 ,_modelPLX . PSX004 );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PST009",SqlDbType.Date,3)
                };
                if ( planTime != null )
                    parameter [ 0 ] . Value = planTime;
                else
                    parameter [ 0 ] . Value = DBNull . Value;
                SQLString . Add ( strSql ,parameter );
                strSql = new StringBuilder ( );
            }
            if ( BLgd . Equals ( ColumnValues . bl_pb ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST011=@PST011 WHERE PST001='{1}' AND PST002='{2}'" ,planTime ,_modelPLX . PSX003 ,_modelPLX . PSX004 );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PST011",SqlDbType.Date,3)
                };
                if ( planTime != null )
                    parameter [ 0 ] . Value = planTime;
                else
                    parameter [ 0 ] . Value = DBNull . Value;
                SQLString . Add ( strSql ,parameter );
                strSql = new StringBuilder ( );
            }
            if ( BLgd . Equals ( ColumnValues . bl_pc ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST013=@PST013 WHERE PST001='{1}' AND PST002='{2}'" ,planTime ,_modelPLX . PSX003 ,_modelPLX . PSX004 );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PST013",SqlDbType.Date,3)
                };
                if ( planTime != null )
                    parameter [ 0 ] . Value = planTime;
                else
                    parameter [ 0 ] . Value = DBNull . Value;
                SQLString . Add ( strSql ,parameter );
            }

        }


        /// <summary>
        /// 获取上次遗留信息
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePSXLast ( string oddNum ,string workD )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PSX001,PSX003,PSX004,PSX005,PSX006,PSX006-PSX007 PSX007,PSX008 FROM MOXPSX " );
            strSql . AppendFormat ( "WHERE PSX001=(SELECT MAX(PSX001) FROM MOXPSX A INNER JOIN MOXPSW B ON A.PSX001=B.PSW001 WHERE PSX001!='{0}' AND PSW002='{1}') AND PSX011=1" ,oddNum ,workD );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取相同单号的日计划
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePSX ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PSX002,PSX003,PSX004,PSX013 FROM MOXPSX " );
            strSql . AppendFormat ( "WHERE PSX001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
