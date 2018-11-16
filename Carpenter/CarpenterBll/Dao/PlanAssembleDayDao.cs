using System . Data;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;
using System;
using System . Collections;
using System . Collections . Generic;

namespace CarpenterBll . Dao
{
    public class PlanAssembleDayDao
    {

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLD001,PLD002,PLD003,PLD004,SUM(PLE007*OPI004) PLD010,PLD009 FROM MOXPLD A LEFT JOIN MOXPLE B ON A.PLD001=B.PLE001 LEFT JOIN MOXOPI C ON B.PLE004=C.OPI001 GROUP BY PLD001,PLD002,PLD003,PLD004,PLD009 ORDER BY PLD001 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public CarpenterEntity . PlanAssembleDayPLDEntity GetList ( string oddNum )
        {
            EditRate ( oddNum );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT * FROM MOXPLD " );
            strSql . Append ( "WHERE PLD001=@PLD001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLD001",SqlDbType.NVarChar,20)
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
		public CarpenterEntity . PlanAssembleDayPLDEntity DataRowToModel ( DataRow row )
        {
            CarpenterEntity . PlanAssembleDayPLDEntity model = new CarpenterEntity . PlanAssembleDayPLDEntity ( );
            if ( row != null )
            {
                if ( row [ "idx" ] != null && row [ "idx" ] . ToString ( ) != "" )
                {
                    model . idx = int . Parse ( row [ "idx" ] . ToString ( ) );
                }
                if ( row [ "PLD001" ] != null )
                {
                    model . PLD001 = row [ "PLD001" ] . ToString ( );
                }
                if ( row [ "PLD002" ] != null )
                {
                    model . PLD002 = row [ "PLD002" ] . ToString ( );
                }
                if ( row [ "PLD003" ] != null && row [ "PLD003" ] . ToString ( ) != "" )
                {
                    model . PLD003 = DateTime . Parse ( row [ "PLD003" ] . ToString ( ) );
                }
                if ( row [ "PLD004" ] != null && row [ "PLD004" ] . ToString ( ) != "" )
                {
                    model . PLD004 = DateTime . Parse ( row [ "PLD004" ] . ToString ( ) );
                }
                if ( row [ "PLD005" ] != null && row [ "PLD005" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "PLD005" ] . ToString ( ) == "1" ) || ( row [ "PLD005" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . PLD005 = true;
                    }
                    else
                    {
                        model . PLD005 = false;
                    }
                }
                if ( row [ "PLD006" ] != null && row [ "PLD006" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "PLD006" ] . ToString ( ) == "1" ) || ( row [ "PLD006" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . PLD006 = true;
                    }
                    else
                    {
                        model . PLD006 = false;
                    }
                }
                if ( row [ "PLD007" ] != null && row [ "PLD007" ] . ToString ( ) != "" )
                {
                    model . PLD007 = DateTime . Parse ( row [ "PLD007" ] . ToString ( ) );
                }
                if ( row [ "PLD008" ] != null )
                {
                    model . PLD008 = row [ "PLD008" ] . ToString ( );
                }
                if ( row [ "PLD009" ] != null && row [ "PLD009" ] . ToString ( ) != "" )
                {
                    model . PLD009 = decimal . Parse ( row [ "PLD009" ] . ToString ( ) );
                }
                if ( row [ "PLD010" ] != null && row [ "PLD010" ] . ToString ( ) != "" )
                {
                    model . PLD010 = DateTime . Parse ( row [ "PLD010" ] . ToString ( ) );
                }
                if ( row [ "PLD011" ] != null )
                {
                    model . PLD011 = row [ "PLD011" ] . ToString ( );
                }
                if ( row [ "PLD012" ] != null )
                {
                    model . PLD012 = row [ "PLD012" ] . ToString ( );
                }
                if ( row [ "PLD013" ] != null )
                {
                    model . PLD013 = row [ "PLD013" ] . ToString ( );
                }
                if ( row [ "PLD014" ] != null )
                {
                    model . PLD014 = row [ "PLD014" ] . ToString ( );
                }
                if ( row [ "PLD015" ] != null )
                {
                    model . PLD015 = row [ "PLD015" ] . ToString ( );
                }
                if ( row [ "PLD016" ] != null )
                {
                    model . PLD016 = row [ "PLD016" ] . ToString ( );
                }
                if ( row [ "PLD017" ] != null )
                {
                    model . PLD017 = row [ "PLD017" ] . ToString ( );
                }
                if ( row [ "PLD018" ] != null )
                {
                    model . PLD018 = row [ "PLD018" ] . ToString ( );
                }
                if ( row [ "PLD019" ] != null )
                {
                    model . PLD019 = row [ "PLD019" ] . ToString ( );
                }
                if ( row [ "PLD020" ] != null )
                {
                    model . PLD020 = row [ "PLD020" ] . ToString ( );
                }
            }
            return model;
        }

        void EditRate ( string oddNum )
        {
            DataTable dt = completionRate ( oddNum );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                CarpenterEntity . PlanAssembleDayPLDEntity _modelPSW = new CarpenterEntity . PlanAssembleDayPLDEntity ( );
                if ( !string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PLD003" ] . ToString ( ) ) )
                    _modelPSW . PLD010 = Convert . ToDateTime ( dt . Rows [ 0 ] [ "PLD003" ] . ToString ( ) );
                else
                    _modelPSW . PLD010 = null;
                if ( !string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "CO" ] . ToString ( ) ) )
                    _modelPSW . PLD009 = Convert . ToDecimal ( dt . Rows [ 0 ] [ "CO" ] . ToString ( ) );
                else
                    _modelPSW . PLD009 = 0;

                StringBuilder strSql = new StringBuilder ( );
                strSql . Append ( "UPDATE MOXPLD SET " );
                strSql . Append ( "PLD009=@PLD009," );
                strSql . Append ( "PLD010=@PLD010 " );
                strSql . Append ( "WHERE PLD001=@PLD001" );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@PLD009",SqlDbType.Decimal,10),
                    new SqlParameter("@PLD010",SqlDbType.Date,3),
                    new SqlParameter("@PLD001",SqlDbType.NVarChar,20)
                };
                parameter [ 0 ] . Value = _modelPSW . PLD009;
                parameter [ 1 ] . Value = _modelPSW . PLD010;
                parameter [ 2 ] . Value = oddNum;

                SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            }
        }

        /// <summary>
        /// 获取完成率和工作日日期
        /// </summary>
        /// <returns></returns>
        DataTable completionRate ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS(SELECT CASE WHEN PLE007=0 THEN 0 ELSE SUM(ISNULL(PLF007,0))*1.0/PLE007 END PLE007,PLD003,PLE003,PLE004 FROM MOXPLD A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001 LEFT JOIN MOXPLF C ON B.PLE003=C.PLF002 AND B.PLE004=C.PLF003 AND B.PLE001=C.PLF010 WHERE A.PLD001=(SELECT MAX(PLD001) FROM MOXPLD WHERE PLD001<'{0}') AND B.PLE012=0 GROUP BY PLE007,PLD003,PLE003,PLE004)," ,oddNum );
            strSql . AppendFormat ( "CFT AS (SELECT COUNT(1) COUN,PLE003,PLE004 FROM MOXPLD A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001 WHERE A.PLD001=(SELECT MAX(PLD001) FROM MOXPLD WHERE PLD001<'{0}') AND B.PLE012=0 GROUP BY PLE003,PLE004)" ,oddNum );
            //strSql . Append ( "SELECT CONVERT(DECIMAL(11,2),SUM(PLE007)/SUM(COUN)*100) CO,A.PLD003 FROM CET A INNER JOIN CFT B ON A.PLE003=B.PLE003 AND A.PLE004=B.PLE004 GROUP BY PLD003" );
            strSql . Append ( "SELECT CONVERT(DECIMAL(11,2),SUM(PLE007)/(SELECT SUM(COUN) FROM CFT)*100) CO,PLD003 FROM CET GROUP BY PLD003" );

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
            strSql . Append ( "SELECT A.idx,PLE001,CASE PLE012 WHEN 0 THEN '正式' ELSE '预排' END PLE012,PLE003,PLE004,PLE005,OPI006,OPI007,OPI004,PLE006,PLE007,PLE008,PLE002,PLE013 FROM MOXPLE A LEFT JOIN MOXOPI B ON A.PLE004=B.OPI001 LEFT JOIN MOXPAS C ON A.PLE003=C.PAS001 AND A.PLE004=C.PAS002 " );
            strSql . AppendFormat ( "WHERE PLE001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否已经报工,若已经报工则不允许删除
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists_BG ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPLF WHERE PLF010='{0}'" ,oddNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum  )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            DataTable getTable = GetDataTable ( oddNum );
            if ( getTable != null && getTable . Rows . Count > 0 )
            {
                DateTime? dt = null;
                CarpenterEntity . PlanAssembleDayPLEEntity _ple = new CarpenterEntity . PlanAssembleDayPLEEntity ( );
                for ( int i = 0 ; i < getTable . Rows . Count ; i++ )
                {
                    _ple . PLE003 = getTable . Rows [ i ] [ "PLE003" ] . ToString ( );
                    _ple . PLE004 = getTable . Rows [ i ] [ "PLE004" ] . ToString ( );
                    _ple . PLE012 = string . IsNullOrEmpty ( getTable . Rows [ i ] [ "PLE012" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( getTable . Rows [ i ] [ "PLE012" ] . ToString ( ) );
                    if ( _ple . PLE012 == false )
                    {
                        dt = getMaxDayTime ( oddNum ,_ple . PLE003 ,_ple . PLE004 );
                        edit_bl_date_delete ( _ple ,dt ,strSql ,SQLString );
                    }
                }
            }

            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPLD " );
            strSql . Append ( " WHERE PLD001=@PLD001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PLD001", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = oddNum;
            SQLString . Add ( strSql ,parameters );

            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPLE " );
            strSql . Append ( " WHERE PLE001=@PLE001" );
            SqlParameter [ ] parameter = {
                    new SqlParameter("@PLE001", SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        DateTime? getMaxDayTime ( string oddNum ,string piNum ,string pingNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MAX(PLD004) PLD004 FROM MOXPLD A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001 WHERE PLE003='{0}' AND PLE004='{1}' AND PLE001!='{2}' " ,piNum ,pingNum ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PLD004" ] . ToString ( ) ) )
                    return null;
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "PLD004" ] . ToString ( ) );
            }
            else
                return null;
        }

        /// <summary>
        /// 编辑日计划计划完成日期
        /// </summary>
        /// <param name="_modelPLX"></param>
        /// <param name="planTime"></param>
        /// <param name="BLgd"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_bl_date_delete ( CarpenterEntity . PlanAssembleDayPLEEntity _modelPLX ,DateTime? planTime ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXPAS SET PAS005=@PAS005 WHERE PAS001='{0}' AND PAS002='{1}'" ,_modelPLX . PLE003 ,_modelPLX . PLE004 );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PAS005",SqlDbType.Date,3)
            };
            parameter [ 0 ] . Value = planTime;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_psw"></param>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . PlanAssembleDayPLDEntity _pld ,DataTable tableView ,List<string> strList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _pld . PLD007 = UserInformation . dt ( );
            _pld . PLD008 = UserInformation . UserName;
            edit_psw ( SQLString ,strSql ,_pld );

            CarpenterEntity . PlanAssembleDayPLEEntity _ple = new CarpenterEntity . PlanAssembleDayPLEEntity ( );
            _ple . PLE001 = _pld . PLD001;
            _ple . PLE009 = UserInformation . dt ( );
            _ple . PLE010 = UserInformation . UserName;
            //DataTable dt = GetDataTable ( _pld . PLD001 );
            for ( int i = 0 ; i < tableView . Rows . Count ; i++ )
            {
                _ple . PLE002 = tableView . Rows [ i ] [ "PLE002" ] . ToString ( );
                _ple . PLE003 = tableView . Rows [ i ] [ "PLE003" ] . ToString ( );
                _ple . PLE004 = tableView . Rows [ i ] [ "PLE004" ] . ToString ( );
                _ple . PLE005 = tableView . Rows [ i ] [ "PLE005" ] . ToString ( );
                _ple . PLE006 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PLE006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "PLE006" ] . ToString ( ) );
                _ple . PLE007 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PLE007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "PLE007" ] . ToString ( ) );
                _ple . PLE008 = tableView . Rows [ i ] [ "PLE008" ] . ToString ( );
                _ple . idx = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) );

                if ( _ple . idx > 0 )
                {
                    edit_psx ( SQLString ,strSql ,_ple );
                }

                //if ( dt . Select ( "PLE003='" + _ple . PLE003 + "' AND PLE004='" + _ple . PLE004 + "'" ) . Length > 0 )
                //    edit_psx ( SQLString ,strSql ,_ple );

                if ( _ple . PLE012 == false )
                    edit_bl_date ( _ple ,_pld . PLD004 ,strSql ,SQLString );
            }

            //for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            //{
            //    _ple . PLE003 = dt . Rows [ i ] [ "PLE003" ] . ToString ( );
            //    _ple . PLE004 = dt . Rows [ i ] [ "PLE004" ] . ToString ( );
            //    _ple . idx = string . IsNullOrEmpty ( dt . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "idx" ] . ToString ( ) );
            //    if ( tableView . Select ( "PLE003='" + _ple . PLE003 + "' AND PLE004='" + _ple . PLE004 + "'" ) . Length < 1 )
            //        delete_psx ( SQLString ,strSql ,_ple );
            //}

            if ( strList . Count > 0 )
            {
                foreach ( string s in strList )
                {
                    _ple . idx = Convert . ToInt32 ( s );
                    delete_psx ( SQLString ,strSql ,_ple );
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
            strSql . AppendFormat ( "SELECT count(1) FROM MOXPLF WHERE PLF010='{0}' AND PLF002='{1}' AND PLF003='{2}'" ,oddNum ,batNum ,proNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void edit_psw ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanAssembleDayPLDEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXPLD set " );
            //strSql . Append ( "PLD002=PLD002," );
            strSql . Append ( "PLD003=@PLD003," );
            strSql . Append ( "PLD004=@PLD004," );
            strSql . Append ( "PLD007=@PLD007," );
            strSql . Append ( "PLD008=@PLD008," );
            strSql . Append ( "PLD009=@PLD009," );
            strSql . Append ( "PLD010=@PLD010 " );
            strSql . Append ( " where PLD001=@PLD001" );
            SqlParameter [ ] parameters = {
                    //new SqlParameter("PLD002", SqlDbType.NVarChar,20),
                    new SqlParameter("@PLD003", SqlDbType.Date,3),
                    new SqlParameter("@PLD004", SqlDbType.Date,3),
                    new SqlParameter("@PLD007", SqlDbType.Date,3),
                    new SqlParameter("@PLD008", SqlDbType.NVarChar,20),
                    new SqlParameter("@PLD009", SqlDbType.Decimal,9),
                    new SqlParameter("@PLD010", SqlDbType.Date,3),
                    new SqlParameter("@PLD001", SqlDbType.NVarChar,20)};
            //parameters [ 0 ] . Value = model . PLD002;
            parameters [ 0 ] . Value = model . PLD003;
            parameters [ 1 ] . Value = model . PLD004;
            parameters [ 2 ] . Value = model . PLD007;
            parameters [ 3 ] . Value = model . PLD008;
            parameters [ 4 ] . Value = model . PLD009;
            parameters [ 5 ] . Value = model . PLD010;
            parameters [ 6 ] . Value = model . PLD001;
            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// 编辑单身
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="model"></param>
        void edit_psx ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanAssembleDayPLEEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXPLE set " );
            strSql . Append ( "PLE002=@PLE002," );
            strSql . Append ( "PLE007=@PLE007," );
            strSql . Append ( "PLE008=@PLE008," );
            strSql . Append ( "PLE009=@PLE009," );
            strSql . Append ( "PLE010=@PLE010 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PLE002", SqlDbType.NVarChar,20),
                    new SqlParameter("@PLE007", SqlDbType.Int,4),
                    new SqlParameter("@PLE008", SqlDbType.NVarChar,200),
                    new SqlParameter("@PLE009", SqlDbType.Date,3),
                    new SqlParameter("@PLE010", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)};
            parameters [ 0 ] . Value = model . PLE002;
            parameters [ 1 ] . Value = model . PLE007;
            parameters [ 2 ] . Value = model . PLE008;
            parameters [ 3 ] . Value = model . PLE009;
            parameters [ 4 ] . Value = model . PLE010;
            parameters [ 5 ] . Value = model . idx;
            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// 删除单身
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="model"></param>
        void delete_psx ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanAssembleDayPLEEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPLE " );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)};
            parameters [ 0 ] . Value = model . idx;
            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// 编辑日计划计划完成日期
        /// </summary>
        /// <param name="_modelPLX"></param>
        /// <param name="planTime"></param>
        /// <param name="BLgd"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_bl_date ( CarpenterEntity . PlanAssembleDayPLEEntity _modelPLX ,DateTime? planTime ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXPAS SET PAS005='{0}' WHERE PAS001='{1}' AND PAS002='{2}'" ,planTime ,_modelPLX . PLE003 ,_modelPLX . PLE004 );
            SQLString . Add ( strSql ,null );
        }

        DataTable GetDataTable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,PLE003,PLE004,PLE012 FROM MOXPLE " );
            strSql . Append ( "WHERE PLE001=@PLE001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLE001",SqlDbType.NVarChar,20)
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

            strSql . Append ( "UPDATE MOXPLD SET " );
            strSql . Append ( "PLD006=@PLD006," );
            strSql . Append ( "PLD007=@PLD007," );
            strSql . Append ( "PLD008=@PLD008 " );
            strSql . Append ( "WHERE PLD001=@PLD001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLD001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLD006",SqlDbType.Bit),
                new SqlParameter("@PLD007",SqlDbType.Date),
                new SqlParameter("@PLD008",SqlDbType.NVarChar,20)
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
            strSql . Append ( "UPDATE MOXPLD SET " );
            strSql . Append ( "PLD006=@PLD006," );
            strSql . Append ( "PLD007=@PLD007," );
            strSql . Append ( "PLD008=@PLD008 " );
            strSql . Append ( "WHERE PLD001=@PLD001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLD001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLD006",SqlDbType.Bit),
                new SqlParameter("@PLD007",SqlDbType.Date),
                new SqlParameter("@PLD008",SqlDbType.NVarChar,20)
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
            strSql . Append ( "SELECT PLD003,PLD004,CONVERT(VARCHAR,PLD010,23)+PLD002+'计划完成率：'+CONVERT(VARCHAR,PLD009)+'%' PLD,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PLE007*OPI004))) PLE FROM MOXPLD A LEFT JOIN MOXPLE B ON A.PLD001=B.PLE001 LEFT JOIN MOXOPI C ON B.PLE004=C.OPI001 " );
            strSql . AppendFormat ( "WHERE PLD001='{0}' " ,oddNum );
            strSql . Append ( "GROUP BY PLD002,PLD003,PLD004,PLD009,PLD010" );

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
            strSql . Append ( "WITH CET AS(SELECT CASE WHEN PLE013!='' THEN '上周遗留' WHEN PLE012=1 THEN '预排' ELSE ''+OPI006 END OPI006,PLE003,PLE005,PLE006,PLE007,PLE008,SUM(ISNULL(PLF007,0)) PLF007 FROM MOXPLE A LEFT JOIN MOXOPI B ON A.PLE004=B.OPI001 LEFT JOIN MOXPLF C ON A.PLE001=C.PLF010 AND A.PLE003=C.PLF002 AND A.PLE004=C.PLF003  " );
            strSql . AppendFormat ( "WHERE PLE001='{0}'  GROUP BY PLE013,PLE012,OPI006,PLE003,PLE005,PLE006,PLE007,PLE008) " ,oddNum );
            strSql . Append ( "SELECT *,CASE WHEN OPI006='上周遗留' THEN '1' WHEN OPI006='预排' THEN '3' ELSE '2' END OPI FROM CET ORDER BY OPI,OPI006" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
