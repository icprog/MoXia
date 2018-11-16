using System;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;
using System . Collections;
using System . Data;

namespace CarpenterBll . Dao
{
    public class PlanMachinWorkDao
    {
        /// <summary>
        /// 是否有报工记录，若有则不可删除
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists_BG ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPMY WHERE PMY016='{0}'" ,oddNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string work )
        {
            DateTime? dtTime = null;
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            DataTable da = SqlHelper . ExecuteDataTable ( "SELECT PMX003,PMX004 FROM MOXPMX WHERE PMX001='" + oddNum + "' " );
            if ( da != null && da . Rows . Count > 0 )
            {
                CarpenterEntity . PlanMachinWorkPMXEntity _modelPSX = new CarpenterEntity . PlanMachinWorkPMXEntity ( );
                CarpenterEntity . PlanMachinWorkPMWEntity _model = new CarpenterEntity . PlanMachinWorkPMWEntity ( );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPSX . PMX003 = da . Rows [ i ] [ "PMX003" ] . ToString ( );
                    _modelPSX . PMX004 = da . Rows [ i ] [ "PMX004" ] . ToString ( );
                    dtTime = getMaxTime ( _modelPSX . PMX003 ,_modelPSX . PMX004 ,oddNum ,work );
                    edit_pst ( _modelPSX ,SQLString ,strSql ,work ,dtTime );
                }
            }

            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPMW " );
            strSql . Append ( " WHERE PMW001=@PMW001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PMW001", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = oddNum;
            SQLString . Add ( strSql ,parameters );
            
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPMX " );
            strSql . Append ( " WHERE PMX001=@PMX001" );
            SqlParameter [ ] parameter = {
                    new SqlParameter("@PMX001", SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        DateTime? getMaxTime ( string piNum,string pingNum ,string oddNum ,string work)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PMW003 FROM MOXPMW WHERE PMW001=(SELECT MAX(PMX001) FROM MOXPMX WHERE PMX003='{0}' AND PMX004='{1}' AND PMX001!='{2}') AND PMW002='{3}' " ,piNum ,pingNum ,oddNum ,work );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PMW003" ] . ToString ( ) ) )
                    return null;
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "PMW003" ] . ToString ( ) );
            }
            else
                return null;
        }

        void edit_pst ( CarpenterEntity . PlanMachinWorkPMXEntity _modelPSX,Hashtable SQLString,StringBuilder strSql,string work,DateTime? dtTime )
        {
            if ( work . Equals ( ColumnValues . jjg_jgzx ) )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE MOXPST SET PST017=@PST017 WHERE PST001='{0}' AND PST002='{1}'" ,_modelPSX . PMX003 ,_modelPSX . PMX004  );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PST017",SqlDbType.Date,3)
                };
                parameter [ 0 ] . Value = dtTime;
                SQLString . Add ( strSql ,parameter );
            }
            if ( work . Equals ( ColumnValues . jjg_kszk ) )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE MOXPST SET PST019=@PST019 WHERE PST001='{0}' AND PST002='{1}'" ,_modelPSX . PMX003 ,_modelPSX . PMX004 );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PST019",SqlDbType.Date,3)
                };
                parameter [ 0 ] . Value = dtTime;
                SQLString . Add ( strSql ,parameter );
            }
            if ( work . Equals ( ColumnValues . jjg_dy ) )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE MOXPST SET PST021=@PST021 WHERE PST001='{0}' AND PST002='{1}'" ,_modelPSX . PMX003 ,_modelPSX . PMX004 );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PST021",SqlDbType.Date,3)
                };
                parameter [ 0 ] . Value = dtTime;
                SQLString . Add ( strSql ,parameter );
            }
        }
        
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_psw"></param>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . PlanMachinWorkPMWEntity _psw ,DataTable tableView )
        {
            DateTime? dtTime = null;
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _psw . PMW007 = UserInformation . dt ( );
            _psw . PMW008 = UserInformation . UserName;
            edit_psw ( SQLString ,strSql ,_psw );

            CarpenterEntity . PlanMachinWorkPMXEntity _pmx = new CarpenterEntity . PlanMachinWorkPMXEntity ( );
            _pmx . PMX001 = _psw . PMW001;
            _pmx . PMX009 = UserInformation . dt ( );
            _pmx . PMX010 = UserInformation . UserName;
            DataTable dt = GetDataTable ( _psw . PMW001 );
            for ( int i = 0 ; i < tableView . Rows . Count ; i++ )
            {
                _pmx . PMX002 = tableView . Rows [ i ] [ "PMX002" ] . ToString ( );
                _pmx . PMX003 = tableView . Rows [ i ] [ "PMX003" ] . ToString ( );
                _pmx . PMX004 = tableView . Rows [ i ] [ "PMX004" ] . ToString ( );
                _pmx . PMX005 = tableView . Rows [ i ] [ "PMX005" ] . ToString ( );
                _pmx . PMX006 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PMX006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "PMX006" ] . ToString ( ) );
                _pmx . PMX007 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PMX007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "PMX007" ] . ToString ( ) );
                _pmx . PMX008 = tableView . Rows [ i ] [ "PMX008" ] . ToString ( );
                _pmx . idx = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( dt . Select ( "PMX003='" + _pmx . PMX003 + "' AND PMX004='" + _pmx . PMX004 + "'" ) . Length > 0 )
                    edit_psx ( SQLString ,strSql ,_pmx );

                //dtTime = getMaxTime ( _pmx . PMX003 ,_pmx . PMX004 ,_psw . PMW001 ,_psw . PMW002 );
                //if ( dtTime != null && dtTime > _psw . PMW003 )
                //    dtTime = _psw . PMW003;
                dtTime = _psw . PMW003;
                edit_pst ( _pmx ,SQLString ,strSql ,_psw . PMW002 ,dtTime );
            }

            for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            {
                _pmx . PMX003 = dt . Rows [ i ] [ "PMX003" ] . ToString ( );
                _pmx . PMX004 = dt . Rows [ i ] [ "PMX004" ] . ToString ( );
                _pmx . idx = string . IsNullOrEmpty ( dt . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( tableView . Select ( "PMX003='" + _pmx . PMX003 + "' AND PMX004='" + _pmx . PMX004 + "'" ) . Length < 1 )
                {
                    delete_psx ( SQLString ,strSql ,_pmx );
                    dtTime = getMaxTime ( _pmx . PMX003 ,_pmx . PMX004 ,_psw . PMW001 ,_psw . PMW002 );
                    edit_pst ( _pmx ,SQLString ,strSql ,_psw . PMW002 ,dtTime );
                }
            }


            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        void edit_psw ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanMachinWorkPMWEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXPMW set " );
            strSql . Append ( "PMW002=@PMW002," );
            strSql . Append ( "PMW003=@PMW003," );
            strSql . Append ( "PMW004=@PMW004," );
            strSql . Append ( "PMW007=@PMW007," );
            strSql . Append ( "PMW008=@PMW008," );
            strSql . Append ( "PMW009=@PMW009," );
            strSql . Append ( "PMW010=@PMW010 " );
            strSql . Append ( " where PMW001=@PMW001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PMW002", SqlDbType.NVarChar,20),
                    new SqlParameter("@PMW003", SqlDbType.Date,3),
                    new SqlParameter("@PMW004", SqlDbType.Date,3),
                    new SqlParameter("@PMW007", SqlDbType.Date,3),
                    new SqlParameter("@PMW008", SqlDbType.NVarChar,20),
                    new SqlParameter("@PMW009", SqlDbType.Decimal,9),
                    new SqlParameter("@PMW010", SqlDbType.Date,3),
                    new SqlParameter("@PMW001", SqlDbType.NVarChar,20)};
            parameters [ 0 ] . Value = model . PMW002;
            parameters [ 1 ] . Value = model . PMW003;
            parameters [ 2 ] . Value = model . PMW004;
            parameters [ 3 ] . Value = model . PMW007;
            parameters [ 4 ] . Value = model . PMW008;
            parameters [ 5 ] . Value = model . PMW009;
            parameters [ 6 ] . Value = model . PMW010;
            parameters [ 7 ] . Value = model . PMW001;
            SQLString . Add ( strSql ,parameters );
        }

        void edit_psx ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanMachinWorkPMXEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXPMX set " );
            strSql . Append ( "PMX001=@PMX001," );
            strSql . Append ( "PMX002=@PMX002," );
            strSql . Append ( "PMX003=@PMX003," );
            strSql . Append ( "PMX004=@PMX004," );
            strSql . Append ( "PMX005=@PMX005," );
            strSql . Append ( "PMX006=@PMX006," );
            strSql . Append ( "PMX007=@PMX007," );
            strSql . Append ( "PMX008=@PMX008," );
            strSql . Append ( "PMX009=@PMX009," );
            strSql . Append ( "PMX010=@PMX010 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PMX001", SqlDbType.NVarChar,20),
                    new SqlParameter("@PMX002", SqlDbType.NVarChar,20),
                    new SqlParameter("@PMX003", SqlDbType.NVarChar,20),
                    new SqlParameter("@PMX004", SqlDbType.NVarChar,20),
                    new SqlParameter("@PMX005", SqlDbType.NVarChar,20),
                    new SqlParameter("@PMX006", SqlDbType.Int,4),
                    new SqlParameter("@PMX007", SqlDbType.Int,4),
                    new SqlParameter("@PMX008", SqlDbType.NVarChar,200),
                    new SqlParameter("@PMX009", SqlDbType.Date,3),
                    new SqlParameter("@PMX010", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)};
            parameters [ 0 ] . Value = model . PMX001;
            parameters [ 1 ] . Value = model . PMX002;
            parameters [ 2 ] . Value = model . PMX003;
            parameters [ 3 ] . Value = model . PMX004;
            parameters [ 4 ] . Value = model . PMX005;
            parameters [ 5 ] . Value = model . PMX006;
            parameters [ 6 ] . Value = model . PMX007;
            parameters [ 7 ] . Value = model . PMX008;
            parameters [ 8 ] . Value = model . PMX009;
            parameters [ 9 ] . Value = model . PMX010;
            parameters [ 10 ] . Value = model . idx;
            SQLString . Add ( strSql ,parameters );
        }

        void delete_psx ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanMachinWorkPMXEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPMX " );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)};
            parameters [ 0 ] . Value = model . idx;
            SQLString . Add ( strSql ,parameters );
        }

        DataTable GetDataTable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,PMX003,PMX004 FROM MOXPMX " );
            strSql . Append ( "WHERE PMX001=@PMX001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMX001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="programName"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examine ( string oddNum ,string programName ,bool state )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( state == false )
                CarpenterBll . Examine . writeToReview ( programName ,oddNum ,UserInformation . UserName ,SQLString );
            else
                CarpenterBll . Examine . deleteToReview ( programName ,oddNum ,UserInformation . UserName ,SQLString );
            
            strSql . Append ( "UPDATE MOXPMW SET " );
            strSql . Append ( "PMW006=@PMW006," );
            strSql . Append ( "PMW007=@PMW007," );
            strSql . Append ( "PMW008=@PMW008 " );
            strSql . Append ( "WHERE PMW001=@PMW001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMW001",SqlDbType.NVarChar,20),
                new SqlParameter("@PMW006",SqlDbType.Bit),
                new SqlParameter("@PMW007",SqlDbType.Date),
                new SqlParameter("@PMW008",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;
            parameter [ 1 ] . Value = state;
            parameter [ 2 ] . Value = UserInformation . dt ( );
            parameter [ 3 ] . Value = UserInformation . UserName;
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Cancellation ( string oddNum ,bool state )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPMW SET " );
            strSql . Append ( "PMW006=@PMW006," );
            strSql . Append ( "PMW007=@PMW007," );
            strSql . Append ( "PMW008=@PMW008 " );
            strSql . Append ( "WHERE PMW001=@PMW001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMW001",SqlDbType.NVarChar,20),
                new SqlParameter("@PMW006",SqlDbType.Bit),
                new SqlParameter("@PMW007",SqlDbType.Date),
                new SqlParameter("@PMW008",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;
            parameter [ 1 ] . Value = state;
            parameter [ 2 ] . Value = UserInformation . dt ( );
            parameter [ 3 ] . Value = UserInformation . UserName;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PMW001,PMW002,PMW003,PMW004,SUM(PMX007*OPI004) PMW010,PMW009 FROM MOXPMW A LEFT JOIN MOXPMX B ON A.PMW001=B.PMX001 LEFT JOIN MOXOPI C ON B.PMX004=C.OPI001 GROUP BY PMW001,PMW002,PMW003,PMW004,PMW009 ORDER BY PMW001 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public CarpenterEntity . PlanMachinWorkPMWEntity GetList ( string oddNum,string workShop )
        {
            EditRate ( oddNum ,workShop );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT * FROM MOXPMW " );
            strSql . Append ( "WHERE PMW001=@PMW001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMW001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                return DataRowToModel ( dt . Rows [ 0 ] );
            }
            else
                return null;
        }

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CarpenterEntity . PlanMachinWorkPMWEntity DataRowToModel ( DataRow row )
        {
            CarpenterEntity . PlanMachinWorkPMWEntity  model = new CarpenterEntity . PlanMachinWorkPMWEntity  ( );
            if ( row != null )
            {
                if ( row [ "idx" ] != null && row [ "idx" ] . ToString ( ) != "" )
                {
                    model . idx = int . Parse ( row [ "idx" ] . ToString ( ) );
                }
                if ( row [ "PMW001" ] != null )
                {
                    model . PMW001 = row [ "PMW001" ] . ToString ( );
                }
                if ( row [ "PMW002" ] != null )
                {
                    model . PMW002 = row [ "PMW002" ] . ToString ( );
                }
                if ( row [ "PMW003" ] != null && row [ "PMW003" ] . ToString ( ) != "" )
                {
                    model . PMW003 = DateTime . Parse ( row [ "PMW003" ] . ToString ( ) );
                }
                if ( row [ "PMW004" ] != null && row [ "PMW004" ] . ToString ( ) != "" )
                {
                    model . PMW004 = DateTime . Parse ( row [ "PMW004" ] . ToString ( ) );
                }
                if ( row [ "PMW005" ] != null && row [ "PMW005" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "PMW005" ] . ToString ( ) == "1" ) || ( row [ "PMW005" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . PMW005 = true;
                    }
                    else
                    {
                        model . PMW005 = false;
                    }
                }
                if ( row [ "PMW006" ] != null && row [ "PMW006" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "PMW006" ] . ToString ( ) == "1" ) || ( row [ "PMW006" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . PMW006 = true;
                    }
                    else
                    {
                        model . PMW006 = false;
                    }
                }
                if ( row [ "PMW007" ] != null && row [ "PMW007" ] . ToString ( ) != "" )
                {
                    model . PMW007 = DateTime . Parse ( row [ "PMW007" ] . ToString ( ) );
                }
                if ( row [ "PMW008" ] != null )
                {
                    model . PMW008 = row [ "PMW008" ] . ToString ( );
                }
                if ( row [ "PMW009" ] != null && row [ "PMW009" ] . ToString ( ) != "" )
                {
                    model . PMW009 = decimal . Parse ( row [ "PMW009" ] . ToString ( ) );
                }
                if ( row [ "PMW010" ] != null && row [ "PMW010" ] . ToString ( ) != "" )
                {
                    model . PMW010 = DateTime . Parse ( row [ "PMW010" ] . ToString ( ) );
                }
            }
            return model;
        }

        void EditRate ( string oddNum ,string workShop)
        {
            CarpenterEntity . PlanMachinWorkPMWEntity _modelPSW = new CarpenterEntity . PlanMachinWorkPMWEntity ( );
            DataTable dt = completionRate ( oddNum ,workShop );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( !string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PMW003" ] . ToString ( ) ) )
                    _modelPSW . PMW010 = Convert . ToDateTime ( dt . Rows [ 0 ] [ "PMW003" ] . ToString ( ) );
                else
                    _modelPSW . PMW010 = null;
                if ( !string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "CO" ] . ToString ( ) ) )
                    _modelPSW . PMW009 = Convert . ToDecimal ( dt . Rows [ 0 ] [ "CO" ] . ToString ( ) );
                else
                    _modelPSW . PMW009 = 0;
            }
            else
            {
                _modelPSW . PMW009 = 0;
                _modelPSW . PMW010 = null;
            }

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPMW SET " );
            strSql . Append ( "PMW009=@PMW009," );
            strSql . Append ( "PMW010=@PMW010 " );
            strSql . Append ( "WHERE PMW001=@PMW001" );
            SqlParameter [ ] parameter = {
                    new SqlParameter("@PMW009",SqlDbType.Decimal,10),
                    new SqlParameter("@PMW010",SqlDbType.Date,3),
                    new SqlParameter("@PMW001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelPSW . PMW009;
            if ( _modelPSW . PMW010 != null )
                parameter [ 1 ] . Value = _modelPSW . PMW010;
            else
                parameter [ 1 ] . Value = DBNull . Value;
            parameter [ 2 ] . Value = oddNum;

            SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取完成率和工作日日期
        /// </summary>
        /// <returns></returns>
        DataTable completionRate ( string oddNum ,string workShop )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS(SELECT SUM(CASE PMW002 WHEN '加工中心' THEN PMY007 WHEN '开榫钻孔' THEN PMY008 WHEN '倒圆' THEN PMY009 END)*1.0/PMX007 PMX007,PMW003,PMX003,PMX004 FROM MOXPMW A INNER JOIN MOXPMX B ON A.PMW001=B.PMX001 INNER JOIN MOXPMY C ON B.PMX003=C.PMY002 AND B.PMX004=C.PMY003 AND B.PMX001=C.PMY016 WHERE A.PMW001=(SELECT MAX(PMW001) FROM MOXPMW WHERE PMW001<'{0}' AND PMW002='{1}') AND B.PMX012=0 GROUP BY PMX007,PMW003,PMX003,PMX004)," ,oddNum ,workShop );
            strSql . AppendFormat ( "CFT AS (SELECT COUNT(1) COUN,PMX003,PMX004 FROM MOXPMW A INNER JOIN MOXPMX B ON A.PMW001=B.PMX001 WHERE A.PMW001=(SELECT MAX(PMW001) FROM MOXPMW WHERE PMW001<'{0}' AND PMW002='{1}') AND B.PMX012=0 GROUP BY PMX003,PMX004)" ,oddNum ,workShop );
            //strSql . Append ( "SELECT CONVERT(DECIMAL(11,2),SUM(PMX007)/SUM(COUN)*100) CO,A.PMW003 FROM CET A INNER JOIN CFT B ON A.PMX003=B.PMX003 AND A.PMX004=B.PMX004 GROUP BY PMW003" );
            strSql . Append ( "SELECT CONVERT(DECIMAL(11,2),SUM(PMX007)/(SELECT SUM(COUN) FROM CFT)*100) CO,PMW003 FROM CET GROUP BY PMW003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableView ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,PMX001,CASE PMX012 WHEN 0 THEN '正式' ELSE '预排' END PMX012,PMX003,PMX004,PMX005,OPI006,OPI007,OPI004,PMX006,PMX007,PMX008,PMX002,PMX013 FROM MOXPMX A INNER JOIN MOXOPI B ON A.PMX004=B.OPI001 " );
            strSql . AppendFormat ( "WHERE PMX001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT '机加工车间'+PMW002+'工段生产日计划' PMW002,PMW003,PMW004,CONVERT(VARCHAR,PMW010,23)+PMW002+'计划完成率：'+CONVERT(VARCHAR,PMW009)+'%' PMW,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PMX007*OPI004))) PMX FROM MOXPMW A LEFT JOIN MOXPMX B ON A.PMW001=B.PMX001 LEFT JOIN MOXOPI C ON B.PMX004=C.OPI001 " );
            strSql . AppendFormat ( "WHERE PMW001='{0}' " ,oddNum );
            strSql . Append ( "GROUP BY PMW002,PMW003,PMW004,PMW009,PMW010" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS(SELECT CASE WHEN PMX013!='' THEN '上周遗留' WHEN PMX012=1 THEN '预排' ELSE ''+OPI006 END OPI006,PMX003,PMX005,PMX006,PMX007,PMX008 FROM MOXPMX A LEFT JOIN MOXOPI B ON A.PMX004=B.OPI001 " );
            strSql . AppendFormat ( "WHERE PMX001='{0}') " ,oddNum );
            strSql . Append ( " SELECT *,CASE WHEN OPI006='上周遗留' THEN '1' WHEN OPI006='预排' THEN '3' ELSE '2' END OPI FROM CET ORDER BY OPI,OPI006" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否已经报工
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="batNum"></param>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public bool Exists ( string oddNum ,string batNum ,string proNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT count(1) FROM MOXPMY WHERE PMY016='{0}' AND PMY002='{1}' AND PMY003='{2}'" ,oddNum ,batNum ,proNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

    }
}

