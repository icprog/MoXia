using System;
using System . Collections . Generic;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;
using System . Data;

namespace CarpenterBll . Dao
{
    public class PlanAssembleWeek_Dao
    {
        /// <summary>
        /// 本年是否有此周次
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <returns></returns>
        public int Exists_Machine ( string weekEnds ,bool planCheck ,List<string> strList )
        {
            int x = 0;
            string idxList = string . Empty;
            foreach ( string idx in strList )
            {
                if ( idxList == string . Empty )
                    idxList = idx;
                else
                    idxList += "," + idx;
            }
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXPLA " );
            strSql . AppendFormat ( "WHERE PLA009='{0}' AND PLA001 LIKE '{1}%'" ,weekEnds ,UserInformation . dt ( ) . ToString ( "yyyy" ) );

            if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
            {
                x = 1;

                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPLA " );
                strSql . AppendFormat ( "WHERE PLA009='{0}' AND PLA001 LIKE '{1}%' AND PLA008=1" ,weekEnds ,UserInformation . dt ( ) . ToString ( "yyyy" ) );

                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return 2;

                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPLA " );
                strSql . AppendFormat ( "WHERE PLA009='{0}' AND PLA001 LIKE '{1}%' AND PLA007=1" ,weekEnds ,UserInformation . dt ( ) . ToString ( "yyyy" ) );

                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return 3;

                strSql = new StringBuilder ( );
                if ( planCheck )
                {
                    //同批号和品号只能预排一次
                    //strSql . Append ( "SELECT PAS001 FROM MOXPAS " );
                    //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN MOXPLB B ON A.PAS001=B.PLB003 AND A.PAS002=B.PLB004 WHERE A.idx IN (" + idxList + ")) AND idx IN (" + idxList + ")" );

                    //同批号和品号可以预排多次(报工数量小于订单数量)
                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPAS A LEFT JOIN (SELECT SUM(ISNULL(PLF007,0)) PLF007,PLB003,PLB004 FROM MOXPLB B LEFT JOIN MOXPLF C ON B.PLB003=C.PLF002 AND B.PLB004=C.PLF003 LEFT JOIN MOXPAS D ON B.PLB003=D.PAS001 AND B.PLB004=D.PAS002 WHERE PLB010=1 AND D.idx IN ({0}) GROUP BY PLB003,PLB004) B ON A.PAS001=B.PLB003 AND A.PAS002=B.PLB004 WHERE A.idx IN ({0}) GROUP BY PAS016,ISNULL(PLF007,0) HAVING PAS016>ISNULL(PLF007,0)" ,idxList );

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4;
                    else
                        x = 1;
                }
                else
                {
                    strSql . Append ( "SELECT PAS001 FROM MOXPAS " );
                    strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN MOXPLB B ON A.PAS001=B.PLB003 AND A.PAS002=B.PLB004 INNER JOIN MOXPLA C ON B.PLB001=C.PLA001 WHERE A.idx IN (" + idxList + ") AND  PLA009='" + weekEnds + "' AND PLA001 LIKE '" + UserInformation . dt ( ) . ToString ( "yyyy" ) + "%' ) AND idx IN (" + idxList + ")" );

                    x = SqlHelper . returnCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 6;
                    else
                        x = 1;
                }

            }
            else
            {
                strSql = new StringBuilder ( );

                if ( planCheck )
                {
                    //同批号和品号只能预排一次
                    //strSql . Append ( "SELECT PAS001 FROM MOXPAS " );
                    //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN MOXPLB B ON A.PAS001=B.PLB003 AND A.PAS002=B.PLB004 WHERE A.idx IN (" + idxList + ")) AND idx IN (" + idxList + ")" );

                    //同批号和品号可以预排多次(报工数量小于订单数量)
                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPAS A LEFT JOIN (SELECT SUM(ISNULL(PLF007,0)) PLF007,PLB003,PLB004 FROM MOXPLB B LEFT JOIN MOXPLF C ON B.PLB003=C.PLF002 AND B.PLB004=C.PLF003 LEFT JOIN MOXPAS D ON B.PLB003=D.PAS001 AND B.PLB004=D.PAS002 WHERE PLB010=1 AND D.idx IN ({0}) GROUP BY PLB003,PLB004) B ON A.PAS001=B.PLB003 AND A.PAS002=B.PLB004 WHERE A.idx IN ({0}) GROUP BY PAS016,ISNULL(PLF007,0) HAVING PAS016>ISNULL(PLF007,0)" ,idxList );

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4;
                    else
                        x = 5;
                }
                else
                {
                    strSql . Append ( "SELECT PAS001 FROM MOXPAS " );
                    strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN MOXPLB B ON A.PAS001=B.PLB003 AND A.PAS002=B.PLB004 WHERE A.idx IN (" + idxList + ") AND PLB010=0) AND idx IN (" + idxList + ")" );

                    x = SqlHelper . returnCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 6;
                    else
                        x = 5;
                }
            }

            return x;
        }

        /// <summary>
        /// 生成组装周计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Add_BL_Machine ( CarpenterEntity . PlanAssembleWeekPLAEntity _model ,List<string> strList ,bool planCheck )
        {
            Hashtable SQLString = new Hashtable ( );

            StringBuilder strSql = new StringBuilder ( );
            _model . PLA001 = GetBLOddNum ( strSql );

            strSql = new StringBuilder ( );
            _model . PLA006 = UserInformation . UserName;
            _model . PLA002 = UserInformation . dt ( );
            _model . PLA007 = false;
            _model . PLA008 = false;
            strSql . Append ( "INSERT INTO MOXPLA (" );
            strSql . Append ( "PLA001,PLA002,PLA003,PLA004,PLA005,PLA006,PLA007,PLA008,PLA009) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PLA001,@PLA002,@PLA003,@PLA004,@PLA005,@PLA006,@PLA007,@PLA008,@PLA009) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLA001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLA002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLA003",SqlDbType.Date),
                new SqlParameter("@PLA004",SqlDbType.Date),
                new SqlParameter("@PLA005",SqlDbType.Date),
                new SqlParameter("@PLA006",SqlDbType.NVarChar,20),
                new SqlParameter("@PLA007",SqlDbType.Bit),
                new SqlParameter("@PLA008",SqlDbType.Bit),
                new SqlParameter("@PLA009",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PLA001;
            parameter [ 1 ] . Value = _model . PLA002;
            parameter [ 2 ] . Value = _model . PLA003;
            parameter [ 3 ] . Value = _model . PLA004;
            parameter [ 4 ] . Value = _model . PLA005;
            parameter [ 5 ] . Value = _model . PLA006;
            parameter [ 6 ] . Value = _model . PLA007;
            parameter [ 7 ] . Value = _model . PLA008;
            parameter [ 8 ] . Value = _model . PLA009;
            SQLString . Add ( strSql ,parameter );

            string name = "";
            foreach ( string str in strList )
            {
                if ( name == "" )
                    name = "'" + str + "'";
                else
                    name += "," + "'" + str + "'";
            }

            CarpenterEntity . PlanAssembleWeekPLBEntity _modelPLT = new CarpenterEntity . PlanAssembleWeekPLBEntity ( );
            DataTable dt;
            if ( planCheck )
                dt = GetDataTableBLPlane_Add ( name );
            else
                dt = GetDataTableBL_Add ( name );

            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPLT . PLB001 = _model . PLA001;
                _modelPLT . PLB011 = _model . PLA002;
                _modelPLT . PLB012 = _model . PLA006;

                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelPLT . PLB002 = string . Empty;
                    _modelPLT . PLB003 = dt . Rows [ i ] [ "PAS001" ] . ToString ( );
                    _modelPLT . PLB004 = dt . Rows [ i ] [ "PAS002" ] . ToString ( );
                    _modelPLT . PLB005 = dt . Rows [ i ] [ "PAS003" ] . ToString ( );
                    _modelPLT . PLB006 = dt . Rows [ i ] [ "PAS004" ] . ToString ( ); 
                    _modelPLT . PLB007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PAS016" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PAS016" ] . ToString ( ) );
                    _modelPLT . PLB009 = dt . Rows [ i ] [ "PAS013" ] . ToString ( );
                    _modelPLT . PLB010 = planCheck;
                    _modelPLT . PLB013 = false;
                    _modelPLT . PLB014 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PAS016" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PAS016" ] . ToString ( ) );
                    _modelPLT . PLB016 = _model . PLA004;

                    if ( _modelPLT . PLB010 == false )
                    {
                        if ( ExistsNum ( _modelPLT ) )
                        {
                            //订单量=订单量-预排报工数量
                            _modelPLT . PLB014 = _modelPLT . PLB014 - getPlanNum ( _modelPLT );
                        }
                    }
                    add_bl ( _modelPLT ,strSql ,SQLString );

                    if ( _modelPLT . PLB010 == false && Exists_edit_bl ( _modelPLT . PLB003 ,_modelPLT . PLB004 ) == true )
                        edit_bl ( _modelPLT ,strSql ,SQLString ,_model . PLA009 );

                    edit_pas ( _modelPLT ,strSql ,SQLString );

                    //if ( _modelPLT . PLT013 == false && Exists_edit_Prs ( _modelPLT . PLT003 ,_modelPLT . PLT004 ) == true )
                    //    edit_Prs ( _modelPLT ,strSql ,SQLString );
                }
            }

            dt = GetDataTableBLP ( _model . PLA001 );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPLT . PLB001 = _model . PLA001;
                _modelPLT . PLB011 = _model . PLA002;
                _modelPLT . PLB012 = _model . PLA006;
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelPLT . PLB002 = dt . Rows [ i ] [ "PLB001" ] . ToString ( );
                    _modelPLT . PLB003 = dt . Rows [ i ] [ "PLB003" ] . ToString ( );
                    _modelPLT . PLB004 = dt . Rows [ i ] [ "PLB004" ] . ToString ( );
                    _modelPLT . PLB005 = dt . Rows [ i ] [ "PLB005" ] . ToString ( );
                    _modelPLT . PLB006 = dt . Rows [ i ] [ "PLB006" ] . ToString ( );
                    _modelPLT . PLB007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PLB007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PLB007" ] . ToString ( ) );
                    _modelPLT . PLB009 = dt . Rows [ i ] [ "PLB009" ] . ToString ( );
                    _modelPLT . PLB010 = false;
                    _modelPLT . PLB013 = false;
                    _modelPLT . PLB014 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PLB014" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PLB014" ] . ToString ( ) );
                    if ( string . IsNullOrEmpty ( dt . Rows [ i ] [ "PLB016" ] . ToString ( ) ) )
                        _modelPLT . PLB016 = null;
                    else
                        _modelPLT . PLB016 = Convert . ToDateTime ( dt . Rows [ i ] [ "PLB016" ] . ToString ( ) );
                    
                    add_bl ( _modelPLT ,strSql ,SQLString );
                }
            }
            
            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        /// <summary>
        /// 覆盖组装周计划  但不删除之前的内容
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Edit_BL_Machine ( CarpenterEntity . PlanAssembleWeekPLAEntity _model ,List<string> strList ,bool planCheck )
        {
            Hashtable SQLString = new Hashtable ( );

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLA001 FROM MOXPLA " );
            strSql . AppendFormat ( "WHERE PLA009='{0}' AND PLA001 LIKE '{1}%'" ,_model . PLA009 ,UserInformation . dt ( ) . ToString ( "yyyy" ) );

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( !string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PLA001" ] . ToString ( ) ) )
                    _model . PLA001 = da . Rows [ 0 ] [ "PLA001" ] . ToString ( );
                else
                    _model . PLA001 = string . Empty;
            }
            else
                _model . PLA001 = string . Empty;

            if ( _model . PLA001 == string . Empty )
                return false;

            strSql = new StringBuilder ( );
            _model . PLA006 = UserInformation . UserName;
            _model . PLA002 = UserInformation . dt ( );
            _model . PLA007 = false;
            _model . PLA008 = false;
            strSql . Append ( "UPDATE MOXPLA SET " );
            strSql . Append ( "PLA002=@PLA002," );
            strSql . Append ( "PLA003=@PLA003," );
            strSql . Append ( "PLA004=@PLA004," );
            strSql . Append ( "PLA005=@PLA005," );
            strSql . Append ( "PLA006=@PLA006," );
            strSql . Append ( "PLA007=@PLA007," );
            strSql . Append ( "PLA008=@PLA008 " );
            strSql . Append ( "WHERE PLA001=@PLA001 AND " );
            strSql . Append ( "PLA009=@PLA009" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLA001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLA002",SqlDbType.Date),
                new SqlParameter("@PLA003",SqlDbType.Date),
                new SqlParameter("@PLA004",SqlDbType.Date),
                new SqlParameter("@PLA005",SqlDbType.Date),
                new SqlParameter("@PLA006",SqlDbType.NVarChar,20),
                new SqlParameter("@PLA007",SqlDbType.Bit),
                new SqlParameter("@PLA008",SqlDbType.Bit),
                new SqlParameter("@PLA009",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PLA001;
            parameter [ 1 ] . Value = _model . PLA002;
            parameter [ 2 ] . Value = _model . PLA003;
            parameter [ 3 ] . Value = _model . PLA004;
            parameter [ 4 ] . Value = _model . PLA005;
            parameter [ 5 ] . Value = _model . PLA006;
            parameter [ 6 ] . Value = _model . PLA007;
            parameter [ 7 ] . Value = _model . PLA008;
            parameter [ 8 ] . Value = _model . PLA009;
            SQLString . Add ( strSql ,parameter );

            da = null;
            CarpenterEntity . PlanAssembleWeekPLBEntity _modelPLT = new CarpenterEntity . PlanAssembleWeekPLBEntity ( );
            string name = "";
            foreach ( string str in strList )
            {
                if ( name == "" )
                    name = "'" + str + "'";
                else
                    name += "," + "'" + str + "'";
            }

            if ( planCheck == false )
                da = GetDataTableBLPlane_Add ( name );
            else
                da = GetDataTableBL_Add ( name );

            DataTable dt = GetDataTablePLT ( _model . PLA001 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPLT . PLB001 = _model . PLA001;
                _modelPLT . PLB011 = _model . PLA002;
                _modelPLT . PLB012 = _model . PLA006;

                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPLT . PLB002 = string . Empty;
                    _modelPLT . PLB003 = da . Rows [ i ] [ "PAS001" ] . ToString ( );
                    _modelPLT . PLB004 = da . Rows [ i ] [ "PAS002" ] . ToString ( );
                    _modelPLT . PLB005 = da . Rows [ i ] [ "PAS003" ] . ToString ( );
                    _modelPLT . PLB006 = da . Rows [ i ] [ "PAS004" ] . ToString ( );
                    _modelPLT . PLB016 = _model . PLA004;
                    _modelPLT . PLB009 = da . Rows [ i ] [ "PAS013" ] . ToString ( );
                    _modelPLT . PLB013 = false;
                    _modelPLT . PLB007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PAS016" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PAS016" ] . ToString ( ) );
                    _modelPLT . PLB010 = planCheck;
                    _modelPLT . PLB014 = _modelPLT . PLB007;
                    if ( dt . Select ( "PLB002='" + _modelPLT . PLB002 + "' AND PLB003='" + _modelPLT . PLB003 + "' AND PLB004='" + _modelPLT . PLB004 + "'" ) . Length < 1 )
                    {
                        if ( _modelPLT . PLB010 == false )
                        {
                            if ( ExistsNum ( _modelPLT ) )
                            {
                                //订单量=订单量-预排报工数量
                                _modelPLT . PLB007 = _modelPLT . PLB007 - getPlanNum ( _modelPLT );
                            }
                        }
                        add_bl ( _modelPLT ,strSql ,SQLString );
                    }
                    else
                        edit_bl ( _modelPLT ,strSql ,SQLString );
                    
                    if ( _modelPLT . PLB010 == false && Exists_edit_bl ( _modelPLT . PLB003 ,_modelPLT . PLB004 ) == true )
                        edit_bl ( _modelPLT ,strSql ,SQLString ,_model . PLA009 );

                    edit_pas ( _modelPLT ,strSql ,SQLString );

                }
            }

            da = GetDataTableBLP ( _model . PLA001 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPLT . PLB001 = _model . PLA001;
                _modelPLT . PLB011 = _model . PLA002;
                _modelPLT . PLB012 = _model . PLA006;
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPLT . PLB002 = da . Rows [ i ] [ "PLB001" ] . ToString ( );
                    _modelPLT . PLB003 = da . Rows [ i ] [ "PLB003" ] . ToString ( );
                    _modelPLT . PLB004 = da . Rows [ i ] [ "PLB004" ] . ToString ( );
                    _modelPLT . PLB005 = da . Rows [ i ] [ "PLB005" ] . ToString ( );
                    _modelPLT . PLB006 = da . Rows [ i ] [ "PLB006" ] . ToString ( );
                    _modelPLT . PLB007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PLB007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PLB007" ] . ToString ( ) );
                    _modelPLT . PLB010 = false;

                    //if ( string . IsNullOrEmpty ( da . Rows [ i ] [ "PLB008" ] . ToString ( ) ) )
                    //    _modelPLT . PLB008 = null;
                    //else
                    //    _modelPLT . PLB008 = Convert . ToDateTime ( da . Rows [ i ] [ "PLB008" ] . ToString ( ) );
                    _modelPLT . PLB009 = da . Rows [ i ] [ "PLB009" ] . ToString ( );
                    _modelPLT . PLB013 = false;
                    if ( dt . Select ( "PLB002='" + _modelPLT . PLB002 + "' AND PLB003='" + _modelPLT . PLB003 + "' AND PLB004='" + _modelPLT . PLB004 + "'" ) . Length < 1 )
                        add_bl ( _modelPLT ,strSql ,SQLString );
                    else
                        edit_bl ( _modelPLT ,strSql ,SQLString );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        /// <summary>
        /// 获取组装周计划单号
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        string GetBLOddNum ( StringBuilder strSql )
        {
            strSql . Append ( "SELECT MAX(PLA001) PLA001 FROM MOXPLA" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PLA001" ] . ToString ( ) ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PLA001" ] . ToString ( ) . Substring ( 0 ,8 ) == UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PLA001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        /// <summary>
        /// 周计划 预排
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableBLPlane_Add ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS013,PAS016 FROM MOXPAS " );
            //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN MOXPLB B ON A.PAS001=B.PLB003 AND A.PAS002=B.PLB004 WHERE A.idx IN (" + strWhere + ")) AND idx IN (" + strWhere + ")" );

            //可多次预排同批号和品号
            strSql . AppendFormat ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS013,PAS016-ISNULL(PLF007,0) PAS016 FROM MOXPAS  A LEFT JOIN (SELECT SUM(ISNULL(PLF007,0)) PLF007,PLB003,PLB004 FROM MOXPLB B LEFT JOIN MOXPLF C ON B.PLB003=C.PLF002 AND B.PLB004=C.PLF003 LEFT JOIN MOXPAS D ON B.PLB003=D.PAS001 AND B.PLB004=D.PAS002  WHERE PLB010=1 AND D.idx IN ({0}) GROUP BY PLB003,PLB004) B ON A.PAS001=B.PLB003 AND A.PAS002=B.PLB004 WHERE A.idx IN ({0}) GROUP BY PAS001,PAS002,PAS003,PAS004,PAS013,PAS016,ISNULL(PLF007,0) HAVING PAS016>ISNULL(PLF007,0)" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 周计划  正式排产
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableBL_Add ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS013,PAS016 FROM MOXPAS " );
            strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN MOXPLB B ON A.PAS001=B.PLB003 AND A.PAS002=B.PLB004 WHERE A.idx IN (" + strWhere + ") AND PLB010=0) AND idx IN (" + strWhere + ")" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取周计划
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePLT ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLB002,PLB003,PLB004 FROM MOXPLB " );
            strSql . AppendFormat ( "WHERE PLB001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否预排过
        /// </summary>
        /// <returns></returns>
        bool ExistsNum ( CarpenterEntity . PlanAssembleWeekPLBEntity _modelPLT )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPLB WHERE PLB003='{0}' AND PLB004='{1}' AND PLB010=1" ,_modelPLT . PLB003 ,_modelPLT . PLB004 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取预排报工数量
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <returns></returns>
        int getPlanNum ( CarpenterEntity . PlanAssembleWeekPLBEntity _modelPLT )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT SUM(PLC007) PLC007 FROM MOXPLB A INNER JOIN MOXPLC B ON A.PLB003=B.PLC002 AND A.PLB004=B.PLC003 WHERE PLC008=1 AND PLB003='{0}' AND PLB004='{1}'" ,_modelPLT . PLB003 ,_modelPLT . PLB004 );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PLC007" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToInt32 ( dt . Rows [ 0 ] [ "PLC007" ] . ToString ( ) );
            }
            else
                return 0;
        }

        void add_bl ( CarpenterEntity . PlanAssembleWeekPLBEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPLB (" );
            strSql . Append ( "PLB001,PLB002,PLB003,PLB004,PLB005,PLB006,PLB007,PLB009,PLB010,PLB011,PLB012,PLB013,PLB014,PLB016) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PLB001,@PLB002,@PLB003,@PLB004,@PLB005,@PLB006,@PLB007,@PLB009,@PLB010,@PLB011,@PLB012,@PLB013,@PLB014,@PLB016) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLB001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLB002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLB003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLB004",SqlDbType.NVarChar,20),
                new SqlParameter("@PLB005",SqlDbType.NVarChar,20),
                new SqlParameter("@PLB006",SqlDbType.NVarChar,20),
                new SqlParameter("@PLB007",SqlDbType.Int),
                new SqlParameter("@PLB009",SqlDbType.NVarChar,200),
                new SqlParameter("@PLB010",SqlDbType.Bit),
                new SqlParameter("@PLB011",SqlDbType.Date),
                new SqlParameter("@PLB012",SqlDbType.NVarChar,20),
                new SqlParameter("@PLB013",SqlDbType.Bit),
                new SqlParameter("@PLB014",SqlDbType.Int),
                new SqlParameter("@PLB016",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _modelPLT . PLB001;
            parameter [ 1 ] . Value = _modelPLT . PLB002;
            parameter [ 2 ] . Value = _modelPLT . PLB003;
            parameter [ 3 ] . Value = _modelPLT . PLB004;
            parameter [ 4 ] . Value = _modelPLT . PLB005;
            parameter [ 5 ] . Value = _modelPLT . PLB006;
            parameter [ 6 ] . Value = _modelPLT . PLB007;
            parameter [ 7 ] . Value = _modelPLT . PLB009;
            parameter [ 8 ] . Value = _modelPLT . PLB010;
            parameter [ 9 ] . Value = _modelPLT . PLB011;
            parameter [ 10 ] . Value = _modelPLT . PLB012;
            parameter [ 11 ] . Value = _modelPLT . PLB013;
            parameter [ 12 ] . Value = _modelPLT . PLB014;
            parameter [ 13 ] . Value = _modelPLT . PLB016;
            SQLString . Add ( strSql ,parameter );
        }

        void edit_bl ( CarpenterEntity . PlanAssembleWeekPLBEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPLB SET " );
            strSql . Append ( "PLB009=@PLB009," );
            strSql . Append ( "PLB011=@PLB011," );
            strSql . Append ( "PLB012=@PLB012 " );
            strSql . Append ( "WHERE PLB001=@PLB001 AND " );
            strSql . Append ( "PLB002=@PLB002 AND " );
            strSql . Append ( "PLB003=@PLB003 AND " );
            strSql . Append ( "PLB004=@PLB004 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLB001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLB002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLB003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLB004",SqlDbType.NVarChar,20),
                new SqlParameter("@PLB009",SqlDbType.NVarChar,200),
                new SqlParameter("@PLB011",SqlDbType.Date),
                new SqlParameter("@PLB012",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelPLT . PLB001;
            parameter [ 1 ] . Value = _modelPLT . PLB002;
            parameter [ 2 ] . Value = _modelPLT . PLB003;
            parameter [ 3 ] . Value = _modelPLT . PLB004;
            parameter [ 4 ] . Value = _modelPLT . PLB009;
            parameter [ 5 ] . Value = _modelPLT . PLB011;
            parameter [ 6 ] . Value = _modelPLT . PLB012;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 周计划完成周次 是否存在  若存在则返回false  不覆盖
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        bool Exists_edit_bl ( string weekEnds ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PAS029 FROM MOXPAS " );
            strSql . Append ( "WHERE PAS001=@PAS001 AND PAS002=@PAS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PAS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PAS002",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PAS029" ] . ToString ( ) ) )
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        /// <summary>
        /// 周计划生成时编辑组装计划完成时间批次周次
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        /// <param name="weekNum"></param>
        void edit_bl ( CarpenterEntity . PlanAssembleWeekPLBEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString ,string weekNum )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPAS SET " );
            strSql . Append ( "PAS029=@PAS029 " );
            strSql . Append ( "WHERE PAS001=@PAS001 AND PAS002=@PAS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PAS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PAS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PAS029",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelPLT . PLB003;
            parameter [ 1 ] . Value = _modelPLT . PLB004;
            parameter [ 2 ] . Value = "第" + weekNum + "周";

            SQLString . Add ( strSql ,parameter );

        }

        /// <summary>
        /// 编辑已经排周计划但未审核的记录的标记
        /// </summary>
        /// <param name="model"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_pas ( CarpenterEntity . PlanAssembleWeekPLBEntity model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPAS SET " );
            strSql . Append ( "PAS030=@PAS030 " );
            strSql . Append ( "WHERE PAS001=@PAS001 AND PAS002=@PAS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PAS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PAS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PAS030",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = model . PLB003;
            parameter [ 1 ] . Value = model . PLB004;
            parameter [ 2 ] . Value = true;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 获取机加工周计划上次遗留
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableBLP ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            //周计划报工遗留  已经弃用 
            //strSql . Append ( "SELECT PLB001,PLB002,PLB003,PLB004,PLB005,PLB006,PLB007,PLB009,PLB014,PLB016 FROM MOXPLB A LEFT JOIN MOXPLC B ON A.PLB003=B.PLC002 AND A.PLB004=B.PLC003 " );
            //strSql . Append ( "WHERE PLB001=(SELECT MAX(PLB001) PLB001 FROM MOXPLB WHERE PLB001<PLB001) AND PLB010=0 " );
            //strSql . Append ( "GROUP BY PLB001,PLB002,PLB003,PLB004,PLB005,PLB006,PLB007,PLB009,PLB014,PLB016 " );
            //strSql . Append ( "HAVING SUM(ISNULL(PLC007,0))<PLB007 " );

            //周计划报工遗留  改为日计划报工
            strSql . Append ( "SELECT PLB001,PLB002,PLB003,PLB004,PLB005,PLB006,PLB007,PLB009,PLB014,PLB016 FROM MOXPLB A LEFT JOIN MOXPLF B ON A.PLB003=B.PLF002 AND A.PLB004=B.PLF003 WHERE PLB001=(SELECT MAX(PLB001) PLB001 FROM MOXPLB WHERE PLB001<@PLB001) AND PLB010=0 GROUP BY PLB001,PLB002,PLB003,PLB004,PLB005,PLB006,PLB007,PLB009,PLB014,PLB016 HAVING SUM(ISNULL(PLF007,0))<PLB007 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLB001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

    }
}
