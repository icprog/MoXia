using StudentMgr;
using System;
using System . Collections;
using System . Data;
using System . Data . SqlClient;
using System . Text;

namespace CarpenterBll . Dao
{
    public class ProductionStock_DailyworkDao
    {
        /// <summary>
        /// 备料报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool BLDailyWork ( DataTable table ,string userName ,bool plan)
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . PlanStockDailyWorkEntity _model = new CarpenterEntity . PlanStockDailyWorkEntity ( );
            _model . PDW001 = GetDataTableDailyWorkOddNum ( );
            _model . PDW013 = GetDate ( );
            _model . PDW014 = userName;
            _model . PDW015 = plan;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . PDW002 = table . Rows [ i ] [ "PST001" ] . ToString ( );
                _model . PDW003 = table . Rows [ i ] [ "PST002" ] . ToString ( );
                _model . PDW004 = table . Rows [ i ] [ "PST003" ] . ToString ( );
                _model . PDW005 = table . Rows [ i ] [ "PST004" ] . ToString ( );
                _model . PDW006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PSX007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PSX007" ] . ToString ( ) );
                _model . PDW007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DL" ] . ToString ( ) );
                _model . PDW008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "XB" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "XB" ] . ToString ( ) );
                _model . PDW009 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CJ" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CJ" ] . ToString ( ) );
                _model . PDW010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PB" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PB" ] . ToString ( ) );
                _model . PDW011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PC" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PC" ] . ToString ( ) );
                _model . PDW012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PDW012" ] . ToString ( ) ) == true ? GetDate ( ) : Convert . ToDateTime ( table . Rows [ i ] [ "PDW012" ] . ToString ( ) );
                _model . PDW016 = table . Rows [ i ] [ "PSX001" ] . ToString ( );
                _model . PDW017 = table . Rows [ i ] [ "PSX013" ] . ToString ( );
                if ( _model . PDW007 != 0 || _model . PDW008 != 0 || _model . PDW009 != 0 || _model . PDW010 != 0 || _model . PDW011 != 0 )
                    edit_BL_DailyWork ( _model ,strSql ,SQLString );
                //若报工总数量=生产数量  则回写完工时间到备料跟踪表的对应工段完工时间
                _model . PDW007 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PDW007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PDW007" ] . ToString ( ) );
                _model . PDW008 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PDW008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PDW008" ] . ToString ( ) );
                _model . PDW009 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PDW009" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PDW009" ] . ToString ( ) );
                _model . PDW010 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PDW010" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PDW010" ] . ToString ( ) );
                _model . PDW011 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PDW011" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PDW011" ] . ToString ( ) );
                edit_BL_OverTime ( _model ,strSql ,SQLString );

                //if ( Exists_bl_weekEnds ( _model . PDW002 ,_model . PDW003 ,_model . PDW011 ) == true )
                //    edit_bl_weekEnds ( _model . PDW002 ,_model . PDW003 ,SQLString ,strSql );

                if ( Exists_bl_day ( _model . PDW002 ,_model . PDW003 ,new int [ ] { _model . PDW007 ,_model . PDW008 ,_model . PDW009 ,_model . PDW010 ,_model . PDW011 } ) == true )
                    edit_bl_day ( _model . PDW002 ,_model . PDW003 ,SQLString ,strSql ,plan );

                //if(_model.PDW015==false && )
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        /// <summary>
        /// 获取备料报工的单号
        /// </summary>
        /// <returns></returns>
        string GetDataTableDailyWorkOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(PDW001) PDW001 FROM MOXPDW" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PDW001" ] . ToString ( ) ) )
                    return GetDate ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PDW001" ] . ToString ( ) . Substring ( 0 ,8 ) == GetDate ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PDW001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return GetDate ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return GetDate ( ) . ToString ( "yyyyMMdd" ) + "001";
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

        void edit_BL_DailyWork ( CarpenterEntity . PlanStockDailyWorkEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPDW (" );
            strSql . Append ( "PDW001,PDW002,PDW003,PDW004,PDW005,PDW006,PDW007,PDW008,PDW009,PDW010,PDW011,PDW012,PDW013,PDW014,PDW015,PDW016,PDW017) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PDW001,@PDW002,@PDW003,@PDW004,@PDW005,@PDW006,@PDW007,@PDW008,@PDW009,@PDW010,@PDW011,@PDW012,@PDW013,@PDW014,@PDW015,@PDW016,@PDW017) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PDW001",SqlDbType.NVarChar,20),
                new SqlParameter("@PDW002",SqlDbType.NVarChar,20),
                new SqlParameter("@PDW003",SqlDbType.NVarChar,20),
                new SqlParameter("@PDW004",SqlDbType.NVarChar,20),
                new SqlParameter("@PDW005",SqlDbType.NVarChar,20),
                new SqlParameter("@PDW006",SqlDbType.Int),
                new SqlParameter("@PDW007",SqlDbType.Int),
                new SqlParameter("@PDW008",SqlDbType.Int),
                new SqlParameter("@PDW009",SqlDbType.Int),
                new SqlParameter("@PDW010",SqlDbType.Int),
                new SqlParameter("@PDW011",SqlDbType.Int),
                new SqlParameter("@PDW012",SqlDbType.Date),
                new SqlParameter("@PDW013",SqlDbType.Date),
                new SqlParameter("@PDW014",SqlDbType.NVarChar,20),
                new SqlParameter("@PDW015",SqlDbType.Bit),
                new SqlParameter("@PDW016",SqlDbType.NVarChar,20),
                new SqlParameter("@PDW017",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PDW001;
            parameter [ 1 ] . Value = _model . PDW002;
            parameter [ 2 ] . Value = _model . PDW003;
            parameter [ 3 ] . Value = _model . PDW004;
            parameter [ 4 ] . Value = _model . PDW005;
            parameter [ 5 ] . Value = _model . PDW006;
            parameter [ 6 ] . Value = _model . PDW007;
            parameter [ 7 ] . Value = _model . PDW008;
            parameter [ 8 ] . Value = _model . PDW009;
            parameter [ 9 ] . Value = _model . PDW010;
            parameter [ 10 ] . Value = _model . PDW011;
            parameter [ 11 ] . Value = _model . PDW012;
            parameter [ 12 ] . Value = _model . PDW013;
            parameter [ 13 ] . Value = _model . PDW014;
            parameter [ 14 ] . Value = _model . PDW015;
            parameter [ 15 ] . Value = _model . PDW016;
            parameter [ 16 ] . Value = _model . PDW017;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 回写备料工段对应批号产品实际完工时间
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_BL_OverTime ( CarpenterEntity . PlanStockDailyWorkEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            if ( _model . PDW006 == _model . PDW007 )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST006='{0}' WHERE PST001='{1}' AND PST002='{2}'" ,_model . PDW012 ,_model . PDW002 ,_model . PDW003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( _model . PDW006 == _model . PDW008 )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST008='{0}' WHERE PST001='{1}' AND PST002='{2}'" ,_model . PDW012 ,_model . PDW002 ,_model . PDW003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( _model . PDW006 == _model . PDW009 )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST010='{0}' WHERE PST001='{1}' AND PST002='{2}'" ,_model . PDW012 ,_model . PDW002 ,_model . PDW003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( _model . PDW006 == _model . PDW010 )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST012='{0}' WHERE PST001='{1}' AND PST002='{2}'" ,_model . PDW012 ,_model . PDW002 ,_model . PDW003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
            if ( _model . PDW006 == _model . PDW011 )
            {
                strSql . AppendFormat ( "UPDATE MOXPST SET PST014='{0}' WHERE PST001='{1}' AND PST002='{2}'" ,_model . PDW012 ,_model . PDW002 ,_model . PDW003 );
                SQLString . Add ( strSql ,null );
                strSql = new StringBuilder ( );
            }
        }

        //报工时  与周计划的生产数量做对比  若一致  则回写周计划的完成状态
        //周计划中是否存在此批号和品号
        bool Exists_bl_weekEnds ( string weekEnds ,string productNum ,int dailyWork )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT SUM(PLT012) PLT012 FROM MOXPLT " );
            strSql . Append ( "WHERE PLT003=@PLT003 AND PLT004=@PLT004 " );
            strSql . Append ( "GROUP BY PLT003,PLT004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLT003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PLT012" ] . ToString ( ) ) )
                    return false;
                else
                {
                    if ( Convert . ToInt32 ( da . Rows [ 0 ] [ "PLT012" ] . ToString ( ) ) == dailyWork )
                        return true;
                    else
                        return false;
                }
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
        void edit_bl_weekEnds ( string weekEnds ,string productNum ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPLT SET " );
            strSql . Append ( "PLT011=1 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLT003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;
            SQLString . Add ( strSql ,parameter );
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
            strSql . Append ( "SELECT PSW002,SUM(PSX007) PSX007 FROM MOXPSX A INNER JOIN MOXPSW B ON A.PSX001=B.PSW001 " );
            strSql . Append ( "WHERE PSX003=@PSX003 AND PSX004=@PSX004 " );
            strSql . Append ( "GROUP BY PSW002,PSX003,PSX004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PSX003",SqlDbType.NVarChar,20),
                new SqlParameter("@PSX004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PSW002" ] . ToString ( ) ) )
                    return false;
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PSX007" ] . ToString ( ) ) )
                    return false;
                string procedure = da . Rows [ 0 ] [ "PSW002" ] . ToString ( );
                int num = Convert . ToInt32 ( da . Rows [ 0 ] [ "PSX007" ] . ToString ( ) );
                if ( procedure . Equals ( ColumnValues.bl_dl ) )
                {
                    if ( num == nums [ 0 ] )
                        return true;
                    else
                        return false;
                }
                else if ( procedure . Equals ( ColumnValues.bl_xb ) )
                {
                    if ( num == nums [ 0 ] )
                        return true;
                    else
                        return false;
                }
                else if ( procedure . Equals ( ColumnValues.bl_cj ) )
                {
                    if ( num == nums [ 0 ] )
                        return true;
                    else
                        return false;
                }
                else if ( procedure . Equals ( ColumnValues.bl_pb ) )
                {
                    if ( num == nums [ 0 ] )
                        return true;
                    else
                        return false;
                }
                else if ( procedure . Equals ( ColumnValues.bl_pc ) )
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
        void edit_bl_day ( string weekEnds ,string productNum ,Hashtable SQLString ,StringBuilder strSql,bool plan )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPSX SET " );
            strSql . Append ( "PSX011=1 " );
            if ( plan )
                strSql . Append ( "WHERE PSX003=@PSX003 AND PSX004=@PSX004 AND PSX012=1" );
            else
                strSql . Append ( "WHERE PSX003=@PSX003 AND PSX004=@PSX004 AND PSX012=0" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PSX003",SqlDbType.NVarChar,20),
                new SqlParameter("@PSX004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            SQLString . Add ( strSql ,parameter );
        }
    }
}
