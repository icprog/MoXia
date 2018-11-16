using StudentMgr;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Text;

namespace CarpenterBll . Dao
{
    public class ProductionPaintDayDao
    {

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PWD001,PWD002,PWD003,PWD004,SUM(PWE007*OPI004) PWD010,PWD009 FROM MOXPWD A LEFT JOIN MOXPWE B ON A.PWD001=B.PWE001 LEFT JOIN MOXOPI C ON B.PWE004=C.OPI001 GROUP BY PWD001,PWD002,PWD003,PWD004,PWD009 ORDER BY PWD001 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否报工，若有则不能删除
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists_BG ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPWF WHERE PWF017='{0}'" ,oddNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string work)
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            DataTable dt = new DataTable ( );
            CarpenterEntity . ProductionPaintDayPWEEntity model = new CarpenterEntity . ProductionPaintDayPWEEntity ( );

            if ( maxOdd ( oddNum ,work ) )
            {
                //string odd = maxOdd ( oddNum ,work ,dt );
                //if ( odd != string . Empty )
                //{
                dt = tableMaxOdd ( oddNum );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                    {
                        model . PWE003 = dt . Rows [ i ] [ "PWE003" ] . ToString ( );
                        model . PWE004 = dt . Rows [ i ] [ "PWE004" ] . ToString ( );
                        //model . PWE007 = maxOdd ( model . PWE003 ,model . PWE004 ,oddNum );

                        model . PWE007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PWE007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PWE007" ] . ToString ( ) );

                        edit_pdp ( SQLString ,strSql ,model ,work );
                    }
                }
                //}
                //else
                //{
                //    dt = SqlHelper . ExecuteDataTable ( "SELECT PWE003,PWE004 FROM MOXPWE WHERE PWE001='" + oddNum + "'" );
                //    if ( dt != null && dt . Rows . Count > 0 )
                //    {
                //        for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                //        {
                //            model . PWE003 = dt . Rows [ i ] [ "PWE003" ] . ToString ( );
                //            model . PWE004 = dt . Rows [ i ] [ "PWE004" ] . ToString ( );
                //            model . PWE007 = 0;
                //            strSql = new StringBuilder ( );
                //            if ( work . Equals ( ColumnValues . yq_dq ) )
                //            {
                //                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP008=0 FROM MOXPDP A INNER JOIN MOXPWE B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE PWE001='{0}'" ,oddNum );
                //                SQLString . Add ( strSql . ToString ( ) );
                //            }
                //            else if ( work . Equals ( ColumnValues . yq_ym ) )
                //            {
                //                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP011=0 FROM MOXPDP A INNER JOIN MOXPWE B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE PWE001='{0}'" ,oddNum );
                //                SQLString . Add ( strSql . ToString ( ) );
                //            }
                //            else if ( work . Equals ( ColumnValues . yq_xs ) )
                //            {
                //                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP014=0 FROM MOXPDP A INNER JOIN MOXPWE B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE PWE001='{0}'" ,oddNum );
                //                SQLString . Add ( strSql . ToString ( ) );
                //            }
                //            else if ( work . Equals ( ColumnValues . yq_mq ) )
                //            {
                //                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP017=0 FROM MOXPDP A INNER JOIN MOXPWE B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE PWE001='{0}'" ,oddNum );
                //                SQLString . Add ( strSql . ToString ( ) );
                //            }
                //        }
                //    }
                //}
            }

            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPWD " );
            strSql . AppendFormat ( " WHERE PWD001='{0}'" ,oddNum );

            SQLString . Add ( strSql . ToString ( ) );

            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPWE " );
            strSql . AppendFormat ( " WHERE PWE001='{0}'" ,oddNum );

            SQLString . Add ( strSql . ToString ( ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        int maxOdd ( string oddNum,string piHao,string pinHao )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PWE007 FROM MOXPWE WHERE PWE003='{0}' AND PWE004='{1}' AND PWE001=(SELECT MAX(PWE001) FROM MOXPWE WHERE PWE001!='{2}')" ,piHao ,pinHao ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PWE007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ 0 ] [ "PWE007" ] . ToString ( ) );
            else
                return 0;
        }

        /// <summary>
        /// 获取此工段的倒数第二个单号
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="work"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        string maxOdd ( string oddNum ,string work,DataTable dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MAX(PWD001) PWD001 FROM MOXPWD WHERE PWD002='{0}' AND PWD001<'{1}'" ,work ,oddNum );
            dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( !string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PWD001" ] . ToString ( ) ) )
                {
                    return dt . Rows [ 0 ] [ "PWD001" ] . ToString ( );
                }
                else
                    return string . Empty;
            }
            else
                return string . Empty;
        }

        DataTable tableMaxOdd ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PWE003,PWE004,PWE007 FROM MOXPWE WHERE PWE001='{0}'" ,oddNum );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
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

            strSql . Append ( "UPDATE MOXPWD SET " );
            strSql . Append ( "PWD006=@PWD006," );
            strSql . Append ( "PWD007=@PWD007," );
            strSql . Append ( "PWD008=@PWD008 " );
            strSql . Append ( "WHERE PWD001=@PWD001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWD001",SqlDbType.NVarChar,20),
                new SqlParameter("@PWD006",SqlDbType.Bit),
                new SqlParameter("@PWD007",SqlDbType.Date),
                new SqlParameter("@PWD008",SqlDbType.NVarChar,20)
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
            strSql . Append ( "UPDATE MOXPWD SET " );
            strSql . Append ( "PWD006=@PWD006," );
            strSql . Append ( "PWD007=@PWD007," );
            strSql . Append ( "PWD008=@PWD008 " );
            strSql . Append ( "WHERE PWD001=@PWD001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWD001",SqlDbType.NVarChar,20),
                new SqlParameter("@PWD006",SqlDbType.Bit),
                new SqlParameter("@PWD007",SqlDbType.Date),
                new SqlParameter("@PWD008",SqlDbType.NVarChar,20)
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
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PWD003,PWD004,CONVERT(VARCHAR,PWD010,23)+PWD002+'计划完成率：'+CONVERT(VARCHAR,PWD009)+'%' PWD,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PWE007*OPI004))) PWE FROM MOXPWD A LEFT JOIN MOXPWE B ON A.PWD001=B.PWE001 LEFT JOIN MOXOPI C ON B.PWE004=C.OPI001 " );
            strSql . AppendFormat ( "WHERE PWD001='{0}' " ,oddNum );
            strSql . Append ( "GROUP BY PWD002,PWD003,PWD004,PWD009,PWD010" );

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
            strSql . Append ( "SELECT PWE003,PWE005,PWE006,PWE007,PWE008,OPI006 FROM MOXPWE A LEFT JOIN MOXOPI B ON A.PWE004=B.OPI001  " );
            strSql . AppendFormat ( "WHERE PWE001='{0}' " ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public CarpenterEntity . ProductionPaintDayPWDEntity GetList ( string oddNum ,string workShop )
        {
            EditRate ( oddNum ,workShop );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT * FROM MOXPWD " );
            strSql . Append ( "WHERE PWD001=@PWD001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWD001",SqlDbType.NVarChar,20)
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
		public CarpenterEntity . ProductionPaintDayPWDEntity DataRowToModel ( DataRow row )
        {
            CarpenterEntity . ProductionPaintDayPWDEntity model = new CarpenterEntity . ProductionPaintDayPWDEntity ( );
            if ( row != null )
            {
                if ( row [ "idx" ] != null && row [ "idx" ] . ToString ( ) != "" )
                {
                    model . idx = int . Parse ( row [ "idx" ] . ToString ( ) );
                }
                if ( row [ "PWD001" ] != null )
                {
                    model . PWD001 = row [ "PWD001" ] . ToString ( );
                }
                if ( row [ "PWD002" ] != null )
                {
                    model . PWD002 = row [ "PWD002" ] . ToString ( );
                }
                if ( row [ "PWD003" ] != null && row [ "PWD003" ] . ToString ( ) != "" )
                {
                    model . PWD003 = DateTime . Parse ( row [ "PWD003" ] . ToString ( ) );
                }
                if ( row [ "PWD004" ] != null && row [ "PWD004" ] . ToString ( ) != "" )
                {
                    model . PWD004 = DateTime . Parse ( row [ "PWD004" ] . ToString ( ) );
                }
                if ( row [ "PWD005" ] != null && row [ "PWD005" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "PWD005" ] . ToString ( ) == "1" ) || ( row [ "PWD005" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . PWD005 = true;
                    }
                    else
                    {
                        model . PWD005 = false;
                    }
                }
                if ( row [ "PWD006" ] != null && row [ "PWD006" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "PWD006" ] . ToString ( ) == "1" ) || ( row [ "PWD006" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . PWD006 = true;
                    }
                    else
                    {
                        model . PWD006 = false;
                    }
                }
                if ( row [ "PWD007" ] != null && row [ "PWD007" ] . ToString ( ) != "" )
                {
                    model . PWD007 = DateTime . Parse ( row [ "PWD007" ] . ToString ( ) );
                }
                if ( row [ "PWD008" ] != null )
                {
                    model . PWD008 = row [ "PWD008" ] . ToString ( );
                }
                if ( row [ "PWD009" ] != null && row [ "PWD009" ] . ToString ( ) != "" )
                {
                    model . PWD009 = decimal . Parse ( row [ "PWD009" ] . ToString ( ) );
                }
                if ( row [ "PWD010" ] != null && row [ "PWD010" ] . ToString ( ) != "" )
                {
                    model . PWD010 = DateTime . Parse ( row [ "PWD010" ] . ToString ( ) );
                }
                if ( row [ "PWD011" ] != null )
                {
                    model . PWD011 = row [ "PWD011" ] . ToString ( );
                }
                if ( row [ "PWD012" ] != null )
                {
                    model . PWD012 = row [ "PWD012" ] . ToString ( );
                }
                if ( row [ "PWD013" ] != null )
                {
                    model . PWD013 = row [ "PWD013" ] . ToString ( );
                }
                if ( row [ "PWD014" ] != null )
                {
                    model . PWD014 = row [ "PWD014" ] . ToString ( );
                }
                if ( row [ "PWD015" ] != null )
                {
                    model . PWD015 = row [ "PWD015" ] . ToString ( );
                }
                if ( row [ "PWD016" ] != null )
                {
                    model . PWD016 = row [ "PWD016" ] . ToString ( );
                }
                if ( row [ "PWD017" ] != null )
                {
                    model . PWD017 = row [ "PWD017" ] . ToString ( );
                }
                if ( row [ "PWD018" ] != null )
                {
                    model . PWD018 = row [ "PWD018" ] . ToString ( );
                }
                if ( row [ "PWD019" ] != null )
                {
                    model . PWD019 = row [ "PWD019" ] . ToString ( );
                }
                if ( row [ "PWD020" ] != null )
                {
                    model . PWD020 = row [ "PWD020" ] . ToString ( );
                }
            }
            return model;
        }

        void EditRate ( string oddNum ,string workShop)
        {
            DataTable dt = completionRate ( oddNum ,workShop );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                CarpenterEntity . ProductionPaintDayPWDEntity _modelPSW = new CarpenterEntity . ProductionPaintDayPWDEntity ( );
                if ( !string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PWD003" ] . ToString ( ) ) )
                    _modelPSW . PWD010 = Convert . ToDateTime ( dt . Rows [ 0 ] [ "PWD003" ] . ToString ( ) );
                else
                    _modelPSW . PWD010 = null;
                if ( !string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "CO" ] . ToString ( ) ) )
                    _modelPSW . PWD009 = Convert . ToDecimal ( dt . Rows [ 0 ] [ "CO" ] . ToString ( ) );
                else
                    _modelPSW . PWD009 = 0;
                if ( _modelPSW . PWD009 > 100 )
                    _modelPSW . PWD009 = 100.00M;
                StringBuilder strSql = new StringBuilder ( );
                strSql . Append ( "UPDATE MOXPWD SET " );
                strSql . Append ( "PWD009=@PWD009," );
                strSql . Append ( "PWD010=@PWD010 " );
                strSql . Append ( "WHERE PWD001=@PWD001" );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PWD009",SqlDbType.Decimal,10),
                    new SqlParameter("@PWD010",SqlDbType.Date,3),
                    new SqlParameter("@PWD001",SqlDbType.NVarChar,20)
                };
                parameter [ 0 ] . Value = _modelPSW . PWD009;
                parameter [ 1 ] . Value = _modelPSW . PWD010;
                parameter [ 2 ] . Value = oddNum;

                SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            }
        }

        /// <summary>
        /// 获取完成率和工作日日期
        /// </summary>
        /// <returns></returns>
        DataTable completionRate (string oddNum,string workShop )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS(SELECT SUM(CASE PWD002 WHEN '底漆' THEN PWF007 WHEN '油磨' THEN PWF008 WHEN '修色' THEN PWF009 WHEN '面漆' THEN PWF010  WHEN '软包' THEN PWF011 END)*1.0/PWE007 PWE007,PWD003,PWE003,PWE004 FROM MOXPWD A LEFT JOIN MOXPWE B ON A.PWD001=B.PWE001 LEFT JOIN MOXPWF C ON B.PWE003=C.PWF002 AND B.PWE004=C.PWF003 AND B.PWE001=C.PWF017 WHERE A.PWD001=(SELECT MAX(PWD001) FROM MOXPWD WHERE PWD001<'{0}' AND PWD002='{1}') AND B.PWE012=0 AND PWD002=(SELECT PWD002 FROM MOXPWD WHERE PWD001='{0}') GROUP BY PWE007,PWD003,PWE003,PWE004)," ,oddNum ,workShop );
            strSql . AppendFormat ( "CFT AS (SELECT COUNT(1) COUN,PWE003,PWE004 FROM MOXPWD A INNER JOIN MOXPWE B ON A.PWD001=B.PWE001 WHERE A.PWD001=(SELECT MAX(PWD001) FROM MOXPWD WHERE PWD001<'{0}' AND PWD002='{1}') AND B.PWE012=0 GROUP BY PWE003,PWE004) " ,oddNum ,workShop );
            //strSql . Append ( "SELECT CONVERT(DECIMAL(11,2),SUM(ISNULL(PWE007,0))/SUM(COUN)*100) CO,A.PWD003 FROM CET A INNER JOIN CFT B ON A.PWE003=B.PWE003 AND A.PWE004=B.PWE004 GROUP BY PWD003" );
            strSql . Append ( "SELECT CONVERT(DECIMAL(11,2),SUM(ISNULL(PWE007,0))/(SELECT SUM(COUN) FROM CFT)*100) CO,PWD003 FROM CET GROUP BY PWD003" );

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
            strSql . Append ( "SELECT A.idx,PWE001,CASE PWE012 WHEN 0 THEN '正式' ELSE '预排' END PWE012,PWE003,PWE004,PWE005,OPI006,OPI007,OPI004,PWE006,PWE007,PWE008,PWE002 FROM MOXPWE A LEFT JOIN MOXOPI B ON A.PWE004=B.OPI001 " );
            strSql . AppendFormat ( "WHERE PWE001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_psw"></param>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . ProductionPaintDayPWDEntity _pld ,DataTable tableView )
        {
            
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _pld . PWD007 = UserInformation . dt ( );
            _pld . PWD008 = UserInformation . UserName;
            edit_psw ( SQLString ,strSql ,_pld );

            CarpenterEntity . ProductionPaintDayPWEEntity _ple = new CarpenterEntity . ProductionPaintDayPWEEntity ( );
            _ple . PWE001 = _pld . PWD001;
            _ple . PWE009 = UserInformation . dt ( );
            _ple . PWE010 = UserInformation . UserName;
            bool result = maxOdd ( _ple . PWE001 ,_pld . PWD002 );
            DataTable dt = GetDataTable ( _pld . PWD001 );
            for ( int i = 0 ; i < tableView . Rows . Count ; i++ )
            {
                _ple . PWE002 = tableView . Rows [ i ] [ "PWE002" ] . ToString ( );
                _ple . PWE003 = tableView . Rows [ i ] [ "PWE003" ] . ToString ( );
                _ple . PWE004 = tableView . Rows [ i ] [ "PWE004" ] . ToString ( );
                _ple . PWE005 = tableView . Rows [ i ] [ "PWE005" ] . ToString ( );
                _ple . PWE006 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PWE006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "PWE006" ] . ToString ( ) );
                _ple . PWE007 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PWE007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "PWE007" ] . ToString ( ) );
                _ple . PWE008 = tableView . Rows [ i ] [ "PWE008" ] . ToString ( );
                _ple . idx = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( dt . Select ( "PWE003='" + _ple . PWE003 + "' AND PWE004='" + _ple . PWE004 + "'" ) . Length > 0 )
                    edit_psx ( SQLString ,strSql ,_ple );
                
                _ple . PWE007 = _ple . PWE007 + getNum ( _ple . PWE001 ,_ple . PWE003 ,_ple . PWE004 ,_pld . PWD002 ) - getBNum ( _ple . PWE003 ,_ple . PWE004 ,_pld . PWD002 );
                //if ( result )
                //{
                edit_pdp ( SQLString ,strSql ,_ple ,_pld . PWD002 );
                //}
            }
            DataTable da = new DataTable ( );
            string odd = maxOdd ( _pld . PWD001 ,_pld . PWD002 ,da );
            if ( odd != string . Empty )
                da = tableMaxOdd ( odd );
            else
                da = null;
            for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            {
                _ple . PWE003 = dt . Rows [ i ] [ "PWE003" ] . ToString ( );
                _ple . PWE004 = dt . Rows [ i ] [ "PWE004" ] . ToString ( );
                _ple . idx = string . IsNullOrEmpty ( dt . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( tableView . Select ( "PWE003='" + _ple . PWE003 + "' AND PWE004='" + _ple . PWE004 + "'" ) . Length < 1 )
                {
                    delete_psx ( SQLString ,strSql ,_ple );

                    if ( da != null && da . Rows . Count > 0 )
                    {
                        if ( da . Select ( "PWE003='" + _ple . PWE003 + "' AND PWE004='" + _ple . PWE004 + "'" ) . Length > 0 )
                        {
                            _ple . PWE007 = Convert . ToInt32 ( da . Select ( "PWE003='" + _ple . PWE003 + "' AND PWE004='" + _ple . PWE004 + "'" ) [ 0 ] [ "PWE007" ] . ToString ( ) );
                            edit_pdp ( SQLString ,strSql ,_ple ,_pld . PWD002 );
                        }
                        else
                        {
                            _ple . PWE007 = 0;
                            edit_pdp ( SQLString ,strSql ,_ple ,_pld . PWD002 );
                        }
                    }
                    else
                    {
                        if ( result )
                        {
                            _ple . PWE007 = 0;
                            edit_pdp ( SQLString ,strSql ,_ple ,_pld . PWD002 );
                        }
                    }
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 是否已经报工
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="batNum"></param>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public bool exists ( string oddNum ,string batNum ,string proNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPWF WHERE PWF017='{0}' AND PWF002='{1}' AND PWF003='{2}'" ,oddNum ,batNum ,proNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void edit_psw ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ProductionPaintDayPWDEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXPWD set " );
            //strSql . Append ( "PWD002=PWD002," );
            strSql . Append ( "PWD003=@PWD003," );
            strSql . Append ( "PWD004=@PWD004," );
            strSql . Append ( "PWD007=@PWD007," );
            strSql . Append ( "PWD008=@PWD008," );
            strSql . Append ( "PWD009=@PWD009," );
            strSql . Append ( "PWD010=@PWD010 " );
            strSql . Append ( " where PWD001=@PWD001" );
            SqlParameter [ ] parameters = {
                    //new SqlParameter("PWD002", SqlDbType.NVarChar,20),
                    new SqlParameter("@PWD003", SqlDbType.Date,3),
                    new SqlParameter("@PWD004", SqlDbType.Date,3),
                    new SqlParameter("@PWD007", SqlDbType.Date,3),
                    new SqlParameter("@PWD008", SqlDbType.NVarChar,20),
                    new SqlParameter("@PWD009", SqlDbType.Decimal,9),
                    new SqlParameter("@PWD010", SqlDbType.Date,3),
                    new SqlParameter("@PWD001", SqlDbType.NVarChar,20)};
            //parameters [ 0 ] . Value = model . PWD002;
            parameters [ 0 ] . Value = model . PWD003;
            parameters [ 1 ] . Value = model . PWD004;
            parameters [ 2 ] . Value = model . PWD007;
            parameters [ 3 ] . Value = model . PWD008;
            parameters [ 4 ] . Value = model . PWD009;
            parameters [ 5 ] . Value = model . PWD010;
            parameters [ 6 ] . Value = model . PWD001;
            SQLString . Add ( strSql ,parameters );
        }

        void edit_psx ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ProductionPaintDayPWEEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXPWE set " );
            strSql . Append ( "PWE002=@PWE002," );
            strSql . Append ( "PWE007=@PWE007," );
            strSql . Append ( "PWE008=@PWE008," );
            strSql . Append ( "PWE009=@PWE009," );
            strSql . Append ( "PWE010=@PWE010 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PWE002", SqlDbType.NVarChar,20),
                    new SqlParameter("@PWE007", SqlDbType.Int,4),
                    new SqlParameter("@PWE008", SqlDbType.NVarChar,200),
                    new SqlParameter("@PWE009", SqlDbType.Date,3),
                    new SqlParameter("@PWE010", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)};
            parameters [ 0 ] . Value = model . PWE002;
            parameters [ 1 ] . Value = model . PWE007;
            parameters [ 2 ] . Value = model . PWE008;
            parameters [ 3 ] . Value = model . PWE009;
            parameters [ 4 ] . Value = model . PWE010;
            parameters [ 5 ] . Value = model . idx;
            SQLString . Add ( strSql ,parameters );
        }

        void delete_psx ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ProductionPaintDayPWEEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPWE" );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)};
            parameters [ 0 ] . Value = model . idx;
            SQLString . Add ( strSql ,parameters );
        }

        DataTable GetDataTable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,PWE003,PWE004,PWE007 FROM MOXPWE " );
            strSql . Append ( "WHERE PWE001=@PWE001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWE001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 是否是本工段最后一天
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        bool maxOdd ( string oddNum,string work )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MAX(PWD001) PWD001 FROM MOXPWD WHERE PWD002='{0}'" ,work );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( !string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PWD001" ] . ToString ( ) ) )
                {
                    if ( dt . Rows [ 0 ] [ "PWD001" ] . ToString ( ) . Equals ( oddNum ) )
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            } else
                return false;
        }

        /// <summary>
        /// 获取计划量
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="piNum"></param>
        /// <param name="pingNum"></param>
        /// <returns></returns>
        int getNum ( string oddNum,string piNum,string pingNum ,string workShop )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT SUM(PWE007) PW FROM MOXPWE  A INNER JOIN MOXPWD B ON A.PWE001=B.PWD001 WHERE PWE001!='{0}' AND PWE003='{1}' AND PWE004='{2}' AND PWD002='{3}'" ,oddNum ,piNum ,pingNum ,workShop );
             
            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PW" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ 0 ] [ "PW" ] . ToString ( ) );
            else
                return 0;
        }

        /// <summary>
        /// 获取报工量
        /// </summary>
        /// <param name="piNum"></param>
        /// <param name="pingNum"></param>
        /// <returns></returns>
        int getBNum ( string piNum ,string pingNum,string workShop )
        {
            string cloumns = string . Empty;
            if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_dq ) )
                cloumns = "PWF007";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_ym ) )
                cloumns = "PWF008";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_xs ) )
                cloumns = "PWF009";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_mq ) )
                cloumns = "PWF010";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_rb ) )
                cloumns = "PWF011";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . yq_bz ) )
                cloumns = "PWF016";

            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT SUM(ISNULL({2},0)) PW FROM MOXPWF WHERE PWF002='{0}' AND PWF003='{1}'" ,piNum ,pingNum ,cloumns );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PW" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ 0 ] [ "PW" ] . ToString ( ) );
            else
                return 0;
        }

        /// <summary>
        /// 修改跟踪表当日计划量
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="model"></param>
        /// <param name="work"></param>
        void edit_pdp ( ArrayList SQLString ,StringBuilder strSql ,CarpenterEntity . ProductionPaintDayPWEEntity model ,string work )
        {
            strSql = new StringBuilder ( );
            if ( work . Equals ( ColumnValues . yq_dq ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP008=ISNULL(PDP008,0)-{0} WHERE PDP001='{1}' AND PDP002='{2}'" ,model . PWE007 ,model . PWE003 ,model . PWE004 );
            }
            else if ( work . Equals ( ColumnValues . yq_ym ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP011=ISNULL(PDP011,0)-{0} WHERE PDP001='{1}' AND PDP002='{2}'" ,model . PWE007 ,model . PWE003 ,model . PWE004 );
            }
            else if ( work . Equals ( ColumnValues . yq_xs ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP014=ISNULL(PDP014,0)-{0} WHERE PDP001='{1}' AND PDP002='{2}'" ,model . PWE007 ,model . PWE003 ,model . PWE004 );
            }
            else if ( work . Equals ( ColumnValues . yq_mq ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP017=ISNULL(PDP017,0)-{0} WHERE PDP001='{1}' AND PDP002='{2}'" ,model . PWE007 ,model . PWE003 ,model . PWE004 );
            }
            else if ( work . Equals ( ColumnValues . yq_bz ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP028=ISNULL(PDP028,0)-{0} WHERE PDP001='{1}' AND PDP002='{2}'" ,model . PWE007 ,model . PWE003 ,model . PWE004 );
            }
            if ( !string . IsNullOrEmpty ( strSql . ToString ( ) ) )
                SQLString . Add ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 修改跟踪表未完成量
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="model"></param>
        /// <param name="work"></param>
        void edit_pdp ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ProductionPaintDayPWEEntity model ,string work )
        {
            strSql = new StringBuilder ( );
            if ( work . Equals ( ColumnValues . yq_dq ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP008={0} WHERE PDP001='{1}' AND PDP002='{2}'" ,model . PWE007 ,model . PWE003 ,model . PWE004 );
            }
            else if ( work . Equals ( ColumnValues . yq_ym ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP011={0} WHERE PDP001='{1}' AND PDP002='{2}'" ,model . PWE007 ,model . PWE003 ,model . PWE004 );
            }
            else if ( work . Equals ( ColumnValues . yq_xs ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP014={0} WHERE PDP001='{1}' AND PDP002='{2}'" ,model . PWE007 ,model . PWE003 ,model . PWE004 );
            }
            else if ( work . Equals ( ColumnValues . yq_mq ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP017={0} WHERE PDP001='{1}' AND PDP002='{2}'" ,model . PWE007 ,model . PWE003 ,model . PWE004 );
            }
            else if ( work . Equals ( ColumnValues . yq_bz ) )
            {
                strSql . AppendFormat ( "UPDATE MOXPDP SET PDP028={0} WHERE PDP001='{1}' AND PDP002='{2}'" ,model . PWE007 ,model . PWE003 ,model . PWE004 );
            }
            if ( !string . IsNullOrEmpty ( strSql . ToString ( ) ) )
                SQLString . Add ( strSql ,null );
        }

    }
}
