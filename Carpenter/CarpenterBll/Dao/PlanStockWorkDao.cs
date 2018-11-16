using StudentMgr;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Text;

namespace CarpenterBll . Dao
{
    public class PlanStockWorkDao
    {
        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PSW001,PSW002,PSW003,PSW004,SUM(PSX007*OPI004) PSW006,PSW009 FROM MOXPSW A LEFT JOIN MOXPSX B ON A.PSW001=B.PSX001 LEFT JOIN MOXOPI C ON B.PSX004=C.OPI001 GROUP BY PSW001,PSW002,PSW003,PSW004,PSW009 ORDER BY PSW001 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOne ( string oddNum ,string workShop )
        {
            EditRate ( oddNum ,workShop );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PSW001,PSW002,PSW003,PSW004,PSW005,PSW006,PSW009,PSW010 FROM MOXPSW " );
            strSql . Append ( "WHERE PSW001=@PSW001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PSW001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        void EditRate ( string oddNum ,string workShop)
        {
            CarpenterEntity . PlanStockWorkPSWEntity _modelPSW = new CarpenterEntity . PlanStockWorkPSWEntity ( );
            DataTable dt = completionRate ( oddNum ,workShop );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( !string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PSW003" ] . ToString ( ) ) )
                    _modelPSW . PSW010 = Convert . ToDateTime ( dt . Rows [ 0 ] [ "PSW003" ] . ToString ( ) );
                else
                    _modelPSW . PSW010 = null;
                if ( !string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "CO" ] . ToString ( ) ) )
                    _modelPSW . PSW009 = Convert . ToDecimal ( dt . Rows [ 0 ] [ "CO" ] . ToString ( ) );
                else
                    _modelPSW . PSW009 = 0;
            }
            else
            {
                _modelPSW . PSW010 = null;
                _modelPSW . PSW009 = 0;
            }

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPSW SET " );
            strSql . Append ( "PSW009=@PSW009," );
            strSql . Append ( "PSW010=@PSW010 " );
            strSql . Append ( "WHERE PSW001=@PSW001" );
            SqlParameter [ ] parameter = {
                    new SqlParameter("@PSW009",SqlDbType.Decimal,10),
                    new SqlParameter("@PSW010",SqlDbType.Date,3),
                    new SqlParameter("@PSW001",SqlDbType.NVarChar,20)
                };
            parameter [ 0 ] . Value = _modelPSW . PSW009;
            if ( _modelPSW . PSW010 != null )
                parameter [ 1 ] . Value = _modelPSW . PSW010;
            else
                parameter [ 1 ] . Value = DBNull . Value;
            parameter [ 2 ] . Value = oddNum;

            SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取完成率和工作日日期
        /// </summary>
        /// <returns></returns>
        public DataTable completionRate ( string oddNum,string workShop )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS(SELECT SUM(CASE PSW002 WHEN '断料' THEN PDW007  WHEN '齿接' THEN PDW009  WHEN '修边' THEN PDW008 WHEN '拼板' THEN PDW010 WHEN '刨床' THEN PDW011 END)*1.0/PSX007 PSX007,PSW003,PSX003,PSX004 FROM MOXPSW A INNER JOIN MOXPSX B ON A.PSW001=B.PSX001 INNER JOIN MOXPDW C ON B.PSX003=C.PDW002 AND B.PSX004=C.PDW003 AND B.PSX001=C.PDW016 WHERE A.PSW001=(SELECT MAX(PSW001) FROM MOXPSW WHERE PSW001<'{0}' AND PSW002='{1}') AND B.PSX012=0 GROUP BY PSX007,PSW003,PSX003,PSX004)," ,oddNum ,workShop );
            strSql . AppendFormat ( "CFT AS (SELECT COUNT(1) COUN,PSX003,PSX004 FROM MOXPSW A INNER JOIN MOXPSX B ON A.PSW001=B.PSX001 WHERE A.PSW001=(SELECT MAX(PSW001) FROM MOXPSW WHERE PSW001<'{0}' AND PSW002='{1}') AND B.PSX012=0 GROUP BY PSX003,PSX004)" ,oddNum ,workShop );
            //strSql . Append ( "SELECT CONVERT(DECIMAL(11,2),SUM(PSX007)/SUM(COUN)*100) CO,A.PSW003 FROM CET A INNER JOIN CFT B ON A.PSX003=B.PSX003 AND A.PSX004=B.PSX004 GROUP BY PSW003" );
            strSql . Append ( "SELECT CONVERT(DECIMAL(11,2),SUM(PSX007)/(SELECT SUM(COUN) FROM CFT)*100) CO,PSW003 FROM CET GROUP BY PSW003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo ( string oddNum )
        {
            //CASE PSX012 WHEN 0 THEN '' WHEN 1 THEN '预排' END
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,PSX001,CASE PSX012 WHEN 0 THEN '正式' ELSE '预排' END PSX012,PSX002,PSX003,PSX004,PSX005,PSX006,PSX007,PSX008,PSX013,OPI004,OPI006,OPI007 FROM MOXPSX A LEFT JOIN MOXOPI B ON A.PSX004=B.OPI001 " );
            strSql . Append ( "WHERE PSX001=@PSX001 " );
            strSql . Append ( "ORDER BY PSX012 ASC,PSX004 ASC " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PSX001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 是否已经报工,且没有删除
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists_BG (  string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPDW WHERE PDW016='{0}'" ,oddNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string work ,DateTime? dt)
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            DataTable da = SqlHelper . ExecuteDataTable ( "SELECT PSX003,PSX004 FROM MOXPSX WHERE PSX001='" + oddNum + "' " );
            if ( da != null && da . Rows . Count > 0 )
            {
                DateTime? dtTime = null;
                CarpenterEntity . PlanStockWorkPSXEntity _modelPSX = new CarpenterEntity . PlanStockWorkPSXEntity ( );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPSX . PSX003 = da . Rows [ i ] [ "PSX003" ] . ToString ( );
                    _modelPSX . PSX004 = da . Rows [ i ] [ "PSX004" ] . ToString ( );
                    dtTime = getMaxTime ( _modelPSX . PSX003 ,_modelPSX . PSX004 ,oddNum ,work );
                    edit_psx ( SQLString ,strSql ,_modelPSX ,dtTime ,work );
                }
            }
            
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPSW " );
            strSql . Append ( "WHERE PSW001=@PSW001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PSW001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;
            SQLString . Add ( strSql ,parameter );


            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPSX " );
            strSql . Append ( "WHERE PSX001=@PSX001" );
            SqlParameter [ ] paramete = {
                new SqlParameter("@PSX001",SqlDbType.NVarChar,20)
            };
            paramete [ 0 ] . Value = oddNum;
            SQLString . Add ( strSql ,paramete );
            
            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        DateTime? getMaxTime (string piNum,string pingNum,string oddNum,string work )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PSW003 FROM MOXPSW WHERE PSW001=(SELECT MAX(PSX001) FROM MOXPSX WHERE PSX003='{0}' AND PSX004='{1}' AND PSX001!='{2}') AND PSW002='{3}'" ,piNum ,pingNum ,oddNum ,work );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PSW003" ] . ToString ( ) ) )
                    return null;
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "PSW003" ] . ToString ( ) );
            }
            else
                return null;
        }

        void edit_psx ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanStockWorkPSXEntity _modelPSX ,DateTime? dtTime ,string work )
        {
            if ( work . Equals ( ColumnValues . bl_dl ) )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE MOXPST SET PST029=@PST029 WHERE PST001='{0}' AND PST002='{1}'" ,_modelPSX . PSX003 ,_modelPSX . PSX004 );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PST029",SqlDbType.Date,3)
                };
                parameter [ 0 ] . Value = dtTime;
                SQLString . Add ( strSql ,parameter );
            }
            if ( work . Equals ( ColumnValues . bl_xb ) )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE MOXPST SET PST007=@PST007 WHERE PST001='{0}' AND PST002='{1}'" ,_modelPSX . PSX003 ,_modelPSX . PSX004  );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PST007",SqlDbType.Date,3)
                };
                parameter [ 0 ] . Value = dtTime;
                SQLString . Add ( strSql ,parameter );
            }
            if ( work . Equals ( ColumnValues . bl_cj ) )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE MOXPST SET PST009=@PST009 WHERE PST001='{0}' AND PST002='{1}'" ,_modelPSX . PSX003 ,_modelPSX . PSX004  );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PST009",SqlDbType.Date,3)
                };
                parameter [ 0 ] . Value = dtTime;
                SQLString . Add ( strSql ,parameter );
            }
            if ( work . Equals ( ColumnValues . bl_pb ) )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE MOXPST SET PST011=@PST011 WHERE PST001='{0}' AND PST002='{1}'" ,_modelPSX . PSX003 ,_modelPSX . PSX004  );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PST011",SqlDbType.Date,3)
                };
                parameter [ 0 ] . Value = dtTime;
                SQLString . Add ( strSql ,parameter );
            }
            if ( work . Equals ( ColumnValues . bl_pc ) )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE MOXPST SET PST013=@PST013 WHERE PST001='{0}' AND PST002='{1}'" ,_modelPSX . PSX003 ,_modelPSX . PSX004  );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PST013",SqlDbType.Date,3)
                };
                parameter [ 0 ] . Value = dtTime;
                SQLString . Add ( strSql ,parameter );
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Concell ( string oddNum ,bool state )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPSW SET " );
            strSql . Append ( "PSW005=@PSW005 " );
            strSql . Append ( "WHERE PSW001=@PSW001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PSW001",SqlDbType.NVarChar,20),
                new SqlParameter("@PSW005",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = oddNum;
            parameter [ 1 ] . Value = state;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;

        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="_modelPSW"></param>
        /// <param name="tableQuery"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . PlanStockWorkPSWEntity _modelPSW ,DataTable tableQuery,List<string> bodyList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _modelPSW . PSW007 = getDate ( );
            strSql . Append ( "UPDATE MOXPSW SET " );
            strSql . Append ( "PSW002=@PSW002," );
            strSql . Append ( "PSW003=@PSW003," );
            strSql . Append ( "PSW004=@PSW004," );
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
                new SqlParameter("@PSW007",SqlDbType.Date),
                new SqlParameter("@PSW008",SqlDbType.NVarChar,20),
                new SqlParameter("@PSW009",SqlDbType.Decimal,10),
                new SqlParameter("@PSW010",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _modelPSW . PSW001;
            parameter [ 1 ] . Value = _modelPSW . PSW002;
            parameter [ 2 ] . Value = _modelPSW . PSW003;
            parameter [ 3 ] . Value = _modelPSW . PSW004;
            parameter [ 4 ] . Value = _modelPSW . PSW007;
            parameter [ 5 ] . Value = _modelPSW . PSW008;
            parameter [ 6 ] . Value = _modelPSW . PSW009;
            parameter [ 7 ] . Value = _modelPSW . PSW010;
            SQLString . Add ( strSql ,parameter );

            CarpenterEntity . PlanStockWorkPSXEntity _modelPSX = new CarpenterEntity . PlanStockWorkPSXEntity ( );
            _modelPSX . PSX001 = _modelPSW . PSW001;
            _modelPSX . PSX009 = getDate ( );
            _modelPSX . PSX010 = _modelPSW . PSW008;
            //DataTable da = SqlHelper . ExecuteDataTable ( "SELECT PSX003,PSX004 FROM MOXPSX WHERE PSX001='" + _modelPSW . PSW001 + "'" );
            DateTime? dtTime = null;
            for ( int i = 0 ; i < tableQuery . Rows . Count ; i++ )
            {
                _modelPSX . PSX002 = tableQuery . Rows [ i ] [ "PSX002" ] . ToString ( );
                _modelPSX . PSX003 = tableQuery . Rows [ i ] [ "PSX003" ] . ToString ( );
                _modelPSX . PSX004 = tableQuery . Rows [ i ] [ "PSX004" ] . ToString ( );
                _modelPSX . PSX007 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "PSX007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "PSX007" ] . ToString ( ) );
                _modelPSX . idx = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "idx" ] . ToString ( ) );
                _modelPSX . PSX008 = tableQuery . Rows [ i ] [ "PSX008" ] . ToString ( );

                if ( _modelPSX . idx > 0 )
                    edit ( _modelPSX ,strSql ,SQLString );

                //dtTime = getMaxTime ( _modelPSX . PSX003 ,_modelPSX . PSX004 ,_modelPSX . PSX001 ,_modelPSW . PSW002 );
                //if ( dtTime != null && dtTime > _modelPSW . PSW003 )
                //    dtTime = _modelPSW . PSW003;

                dtTime = _modelPSW . PSW003;
                edit_psx ( SQLString ,strSql ,_modelPSX ,dtTime ,_modelPSW . PSW002 );
            }

            if ( bodyList . Count > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "SELECT PSX003,PSX004 FROM MOXPSX WHERE idx IN ({0})" ,string . Join ( "," ,bodyList ) );
                DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( da != null && da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        _modelPSX . PSX003 = da . Rows [ i ] [ "PSX003" ] . ToString ( );
                        _modelPSX . PSX004 = da . Rows [ i ] [ "PSX004" ] . ToString ( );
                        dtTime = getMaxTime ( _modelPSX . PSX003 ,_modelPSX . PSX004 ,_modelPSX . PSX001 ,_modelPSW . PSW002 );
                        edit_psx ( SQLString ,strSql ,_modelPSX ,dtTime ,_modelPSW . PSW002 );
                    }
                }
                foreach ( string s in bodyList )
                {
                    _modelPSX . idx = Convert . ToInt32 ( s );
                    delete ( _modelPSX ,strSql ,SQLString );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        DateTime getDate ( )
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

        void edit ( CarpenterEntity . PlanStockWorkPSXEntity _modelPSX ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPSX SET " );
            strSql . Append ( "PSX002=@PSX002," );
            strSql . Append ( "PSX007=@PSX007," );
            strSql . Append ( "PSX008=@PSX008," );
            strSql . Append ( "PSX009=@PSX009," );
            strSql . Append ( "PSX010=@PSX010 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PSX002",SqlDbType.NVarChar,20),
                new SqlParameter("@PSX007",SqlDbType.Int),
                new SqlParameter("@PSX008",SqlDbType.NVarChar,200),
                new SqlParameter("@PSX009",SqlDbType.Date),
                new SqlParameter("@PSX010",SqlDbType.NVarChar,20),
                new SqlParameter("@idx",SqlDbType.Int,4)
            };
            parameter [ 0 ] . Value = _modelPSX . PSX002;
            parameter [ 1 ] . Value = _modelPSX . PSX007;
            parameter [ 2 ] . Value = _modelPSX . PSX008;
            parameter [ 3 ] . Value = _modelPSX . PSX009;
            parameter [ 4 ] . Value = _modelPSX . PSX010;
            parameter [ 5 ] . Value = _modelPSX . idx;

            SQLString . Add ( strSql ,parameter );
        }

        void delete ( CarpenterEntity . PlanStockWorkPSXEntity _modelPSX ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );//AND PSX002=PSX002
            strSql . Append ( "DELETE FROM MOXPSX " );
            //strSql . Append ( "WHERE PSX001=PSX001  AND PSX003=PSX003 AND PSX004=PSX004" );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                //new SqlParameter("PSX001",SqlDbType.NVarChar,20),
                //new SqlParameter("PSX002",SqlDbType.NVarChar,20),
                //new SqlParameter("PSX003",SqlDbType.NVarChar,20),
                //new SqlParameter("PSX004",SqlDbType.NVarChar,20)
                new SqlParameter("@idx",SqlDbType.Int,4)
            };
            parameter [ 0 ] . Value = _modelPSX . idx;
            //parameter [ 0 ] . Value = _modelPSX . PSX001;
            //parameter [ 1 ] . Value = _modelPSX . PSX002;
            //parameter [ 1 ] . Value = _modelPSX . PSX003;
            //parameter [ 2 ] . Value = _modelPSX . PSX004;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="programName"></param>
        /// <param name="userName"></param>
        /// <param name="userNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examin (string oddNum,string programName,string userName,string userNum,bool state )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( state == false )
                CarpenterBll . Examine . writeToReview ( programName ,oddNum ,userNum ,SQLString );
            else
                CarpenterBll . Examine . deleteToReview ( programName ,oddNum ,userNum ,SQLString );
            strSql . Append ( "UPDATE MOXPSW SET " );
            strSql . Append ( "PSW006=@PSW006," );
            strSql . Append ( "PSW007=@PSW007," );
            strSql . Append ( "PSW008=@PSW008 " );
            strSql . Append ( "WHERE PSW001=@PSW001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PSW001",SqlDbType.NVarChar,20),
                new SqlParameter("@PSW006",SqlDbType.Bit),
                new SqlParameter("@PSW007",SqlDbType.Date),
                new SqlParameter("@PSW008",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;
            parameter [ 1 ] . Value = state;
            parameter [ 2 ] . Value = getDate ( );
            parameter [ 3 ] . Value = userName;
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable printOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT '备料车间'+PSW002+'工段生产日计划' PSW002,PSW003,PSW004,CONVERT(VARCHAR,PSW010,23)+PSW002+'计划完成率：'+CONVERT(VARCHAR,PSW009)+'%' PSW,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PSX007*OPI004))) PSX FROM MOXPSW A LEFT JOIN MOXPSX B ON A.PSW001=B.PSX001 LEFT JOIN MOXOPI C ON B.PSX004=C.OPI001 " );
            strSql . AppendFormat ( "WHERE PSW001='{0}'" ,oddNum );
            strSql . Append ( " GROUP BY PSW002,PSW003,PSW004,PSW009,PSW010" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable printTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (SELECT CASE WHEN PSX013!='' THEN '上周遗留' WHEN PSX012=1 THEN '预排' ELSE ''+OPI006 END OPI006,PSX003,PSX005,PSX006,PSX007,PSX008 FROM MOXPSX A LEFT JOIN MOXOPI B ON A.PSX004=B.OPI001 " );
            strSql . AppendFormat ( "WHERE PSX001='{0}' " ,oddNum );
            strSql . Append ( ") SELECT *,CASE WHEN OPI006='上周遗留' THEN '1' WHEN OPI006='预排' THEN '3' ELSE '2' END OPI FROM CET ORDER BY OPI,OPI006" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="batNum"></param>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public bool Exists ( string oddNum,string batNum,string proNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPDW WHERE PDW016='{0}' AND PDW002='{1}' AND PDW003='{2}'" ,oddNum ,batNum ,proNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

    }
}
