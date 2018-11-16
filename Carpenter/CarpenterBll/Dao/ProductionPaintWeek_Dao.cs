using System . Collections . Generic;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;
using System . Data;
using System;

namespace CarpenterBll . Dao
{
    public class ProductionPaintWeek_Dao
    {
        /// <summary>
        /// 本年是否有此周次
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <returns></returns>
        public int Exists ( string weekEnds ,bool planCheck ,List<string> strList )
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
            strSql . Append ( "SELECT COUNT(1) FROM MOXPWG " );
            strSql . AppendFormat ( "WHERE PWG009='{0}' AND PWG001 LIKE '{1}%'" ,weekEnds ,UserInformation . dt ( ) . ToString ( "yyyy" ) );
            
            if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
            {
                x = 1;

                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPWG " );
                strSql . AppendFormat ( "WHERE PWG009='{0}' AND PWG001 LIKE '{1}%' AND PWG008=1" ,weekEnds ,UserInformation.dt ( ) . ToString ( "yyyy" ) );

                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return 2;//注销

                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPWG " );
                strSql . AppendFormat ( "WHERE PWG009='{0}' AND PWG001 LIKE '{1}%' AND PWG007=1" ,weekEnds ,UserInformation.dt ( ) . ToString ( "yyyy" ) );

                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return 3;//审核

                strSql = new StringBuilder ( );
                if ( planCheck )
                {
                    strSql . Append ( "SELECT PDP001 FROM MOXPDP " );
                    strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN MOXPWH B ON A.PDP001=B.PWH003 AND A.PDP002=B.PWH004 WHERE A.idx IN (" + idxList + ")) AND idx IN (" + idxList + ")" );

                    x = SqlHelper . returnCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4;
                    else
                        x = 1;
                }
                else
                {
                    strSql . Append ( "SELECT PDP001 FROM MOXPDP " );
                    strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN MOXPWH B ON A.PDP001=B.PWH003 AND A.PDP002=B.PWH004 INNER JOIN MOXPWG C ON B.PWH001=C.PWG001 WHERE A.idx IN (" + idxList + ")  AND PWG009='" + weekEnds + "' AND PWG001 LIKE '" + UserInformation . dt
                        ( ) . ToString ( "yyyy" ) + "%') AND idx IN (" + idxList + ")" );

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
                    strSql . Append ( "SELECT PDP001 FROM MOXPDP " );
                    strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN MOXPWH B ON A.PDP001=B.PWH003 AND A.PDP002=B.PWH004 WHERE A.idx IN (" + idxList + ")) AND idx IN (" + idxList + ")" );

                    x = SqlHelper . returnCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4;
                    else
                        x = 5;
                }
                else
                {
                    strSql . Append ( "SELECT PDP001,PDP002,PDP003,PDP004,PDP025,PDP028 FROM MOXPDP " );
                    strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN MOXPWH B ON A.PDP001=B.PWH003 AND A.PDP002=B.PWH004 WHERE A.idx IN (" + idxList + ") AND PWH010=0) AND idx IN (" + idxList + ")" );
                    
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
        /// 生成油漆周计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Add_BL ( CarpenterEntity . ProductionPaintWeekPWGEntity _model ,List<string> strList  ,bool planCheck )
        {
            Hashtable SQLString = new Hashtable ( );

            StringBuilder strSql = new StringBuilder ( );
            _model . PWG001 = GetBLOddNum ( strSql );

            strSql = new StringBuilder ( );
            _model . PWG006 = UserInformation . UserName;
            _model . PWG002 = UserInformation . dt ( );
            _model . PWG007 = false;
            _model . PWG008 = false;
            strSql . Append ( "INSERT INTO MOXPWG (" );
            strSql . Append ( "PWG001,PWG002,PWG003,PWG004,PWG005,PWG006,PWG007,PWG008,PWG009) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PWG001,@PWG002,@PWG003,@PWG004,@PWG005,@PWG006,@PWG007,@PWG008,@PWG009) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWG001",SqlDbType.NVarChar,20),
                new SqlParameter("@PWG002",SqlDbType.Date,3),
                new SqlParameter("@PWG003",SqlDbType.Date,3),
                new SqlParameter("@PWG004",SqlDbType.Date,3),
                new SqlParameter("@PWG005",SqlDbType.Date,3),
                new SqlParameter("@PWG006",SqlDbType.NVarChar,20),
                new SqlParameter("@PWG007",SqlDbType.Bit),
                new SqlParameter("@PWG008",SqlDbType.Bit),
                new SqlParameter("@PWG009",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PWG001;
            parameter [ 1 ] . Value = _model . PWG002;
            parameter [ 2 ] . Value = _model . PWG003;
            parameter [ 3 ] . Value = _model . PWG004;
            parameter [ 4 ] . Value = _model . PWG005;
            parameter [ 5 ] . Value = _model . PWG006;
            parameter [ 6 ] . Value = _model . PWG007;
            parameter [ 7 ] . Value = _model . PWG008;
            parameter [ 8 ] . Value = _model . PWG009;
            SQLString . Add ( strSql ,parameter );

            string name = "";
            foreach ( string str in strList )
            {
                if ( name == "" )
                    name = "'" + str + "'";
                else
                    name += "," + "'" + str + "'";
            }

            CarpenterEntity . ProductionPaintWeekPWHEntity _modelPWH = new CarpenterEntity . ProductionPaintWeekPWHEntity ( );
            DataTable dt;
            if ( planCheck )
                dt = GetDataTableBLPlane_Add ( name );
            else
                dt = GetDataTableBL_Add ( name );

            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPWH . PWH001 = _model . PWG001;
                _modelPWH . PWH012 = _model . PWG006;
                _modelPWH . PWH011 = _model . PWG002;

                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelPWH . PWH002 = string . Empty;
                    _modelPWH . PWH003 = dt . Rows [ i ] [ "PDP001" ] . ToString ( );
                    _modelPWH . PWH004 = dt . Rows [ i ] [ "PDP002" ] . ToString ( );
                    _modelPWH . PWH005 = dt . Rows [ i ] [ "PDP003" ] . ToString ( );
                    _modelPWH . PWH006 = dt . Rows [ i ] [ "PDP004" ] . ToString ( );
                    _modelPWH . PWH016 = _model . PWG004;
                    _modelPWH . PWH009 = dt . Rows [ i ] [ "PDP024" ] . ToString ( );
                    _modelPWH . PWH013 = false;
                    _modelPWH . PWH007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PDP025" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PDP025" ] . ToString ( ) );
                    _modelPWH . PWH010 = planCheck;
                    _modelPWH . PWH014 = _modelPWH . PWH007;

                    if ( _modelPWH . PWH010 == false )
                    {
                        if ( ExistsNum ( _modelPWH ) )
                        {
                            //订单量=订单量-预排报工数量
                            _modelPWH . PWH014 = _modelPWH . PWH014 - getPlanNum ( _modelPWH );
                        }
                    }
                    add_bl ( _modelPWH ,strSql ,SQLString );
                }
            }

            dt = GetDataTableBLP ( _model . PWG001 );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPWH . PWH001 = _model . PWG001;
                _modelPWH . PWH012 = _model . PWG006;
                _modelPWH . PWH011 = _model . PWG002;

                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelPWH . PWH002 = dt . Rows [ i ] [ "PWH001" ] . ToString ( );
                    _modelPWH . PWH003 = dt . Rows [ i ] [ "PWH003" ] . ToString ( );
                    _modelPWH . PWH004 = dt . Rows [ i ] [ "PWH004" ] . ToString ( );
                    _modelPWH . PWH005 = dt . Rows [ i ] [ "PWH005" ] . ToString ( );
                    _modelPWH . PWH006 = dt . Rows [ i ] [ "PWH006" ] . ToString ( );
                    _modelPWH . PWH007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PWH007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PWH007" ] . ToString ( ) );
                    _modelPWH . PWH009 = dt . Rows [ i ] [ "PWH009" ] . ToString ( );
                    _modelPWH . PWH010 = false;
                    _modelPWH . PWH014 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PWH014" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PWH014" ] . ToString ( ) );
                    if ( string . IsNullOrEmpty ( dt . Rows [ i ] [ "PWH016" ] . ToString ( ) ) )
                        _modelPWH . PWH016 = null;
                    else
                        _modelPWH . PWH016 = Convert . ToDateTime ( dt . Rows [ i ] [ "PWH016" ] . ToString ( ) );
                    _modelPWH . PWH013 = false;
                    add_bl ( _modelPWH ,strSql ,SQLString );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 覆盖油漆周计划  但不删除之前的内容
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Edit_BL ( CarpenterEntity . ProductionPaintWeekPWGEntity _model ,List<string> strList  ,bool planCheck )
        {
            Hashtable SQLString = new Hashtable ( );

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PWG001 FROM MOXPWG " );
            strSql . AppendFormat ( "WHERE PWG009='{0}' AND PWG001 LIKE '{1}%'" ,_model . PWG009 ,UserInformation . dt ( ) . ToString ( "yyyy" ) );

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( !string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PWG001" ] . ToString ( ) ) )
                    _model . PWG001 = da . Rows [ 0 ] [ "PWG001" ] . ToString ( );
                else
                    _model . PWG001 = string . Empty;
            }
            else
                _model . PWG001 = string . Empty;

            if ( _model . PWG001 == string . Empty )
                return false;

            strSql = new StringBuilder ( );
            _model . PWG006 = UserInformation . UserName;
            _model . PWG002 = UserInformation . dt ( );
            strSql . Append ( "UPDATE MOXPWG SET " );
            strSql . Append ( "PWG002=@PWG002," );
            strSql . Append ( "PWG003=@PWG003," );
            strSql . Append ( "PWG004=@PWG004," );
            strSql . Append ( "PWG005=@PWG005," );
            strSql . Append ( "PWG006=@PWG006 " );
            strSql . Append ( "WHERE PWG001=@PWG001 AND " );
            strSql . Append ( "PWG009=@PWG009" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWG001",SqlDbType.NVarChar,20),
                new SqlParameter("@PWG002",SqlDbType.Date,3),
                new SqlParameter("@PWG003",SqlDbType.Date,3),
                new SqlParameter("@PWG004",SqlDbType.Date,3),
                new SqlParameter("@PWG005",SqlDbType.Date,3),
                new SqlParameter("@PWG006",SqlDbType.NVarChar,20),
                new SqlParameter("@PWG009",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PWG001;
            parameter [ 1 ] . Value = _model . PWG002;
            parameter [ 2 ] . Value = _model . PWG003;
            parameter [ 3 ] . Value = _model . PWG004;
            parameter [ 4 ] . Value = _model . PWG005;
            parameter [ 5 ] . Value = _model . PWG006;
            parameter [ 6 ] . Value = _model . PWG009;
            SQLString . Add ( strSql ,parameter );

            da = null;
            CarpenterEntity . ProductionPaintWeekPWHEntity _modelPWH = new CarpenterEntity . ProductionPaintWeekPWHEntity ( );
            string  name = "";
            foreach ( string str in strList )
            {
                if ( name == "" )
                    name = "'" + str + "'";
                else
                    name += "," + "'" + str + "'";
            }

            if ( planCheck )
                da = GetDataTableBLPlane_Add ( name );
            else
                da = GetDataTableBL_Add ( name );

            DataTable dt = GetDataTablePWH ( _model . PWG001 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPWH . PWH001 = _model . PWG001;
                _modelPWH . PWH012 = _model . PWG006;
                _modelPWH . PWH011 = _model . PWG002;

                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPWH . PWH002 = string . Empty;
                    _modelPWH . PWH003 = da . Rows [ i ] [ "PDP001" ] . ToString ( );
                    _modelPWH . PWH004 = da . Rows [ i ] [ "PDP002" ] . ToString ( );
                    _modelPWH . PWH005 = da . Rows [ i ] [ "PDP003" ] . ToString ( );
                    _modelPWH . PWH006 = da . Rows [ i ] [ "PDP004" ] . ToString ( );
                    _modelPWH . PWH007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PDP025" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PDP025" ] . ToString ( ) );
                    _modelPWH . PWH009 = da . Rows [ i ] [ "PDP024" ] . ToString ( );
                    _modelPWH . PWH010 = planCheck;
                    _modelPWH . PWH013 = false;
                    _modelPWH . PWH014 = _modelPWH . PWH007;
                    _modelPWH . PWH016 = _model . PWG004;

                    if ( dt . Select ( "PWH002='" + _modelPWH . PWH002 + "' AND PWH003='" + _modelPWH . PWH003 + "' AND PWH004='" + _modelPWH . PWH004 + "'" ) . Length < 1 )
                    {
                        if ( _modelPWH . PWH010 == false )
                        {
                            if ( ExistsNum ( _modelPWH ) )
                            {
                                //订单量=订单量-预排报工数量
                                _modelPWH . PWH014 = _modelPWH . PWH014 - getPlanNum ( _modelPWH );
                            }
                        }
                        add_bl ( _modelPWH ,strSql ,SQLString );
                    }
                    else
                        edit_bl ( _modelPWH ,strSql ,SQLString );

                    //回写生产部生产跟踪表备料计划完成日期
                    //if ( _modelPWH . PWH013 == false && Exists_edit_sc ( _modelPWH . PWH003 ,_modelPWH . PWH004 ) == true )
                    //    edit_bl ( _modelPWH ,strSql ,SQLString ,_model . PWG002 );

                }
            }

            da = GetDataTableBLP ( _model . PWG001 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPWH . PWH001 = _model . PWG001;
                _modelPWH . PWH012 = _model . PWG006;
                _modelPWH . PWH011 = _model . PWG002;

                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPWH . PWH002 = da . Rows [ i ] [ "PWH001" ] . ToString ( );
                    _modelPWH . PWH003 = da . Rows [ i ] [ "PWH003" ] . ToString ( );
                    _modelPWH . PWH004 = da . Rows [ i ] [ "PWH004" ] . ToString ( );
                    _modelPWH . PWH005 = da . Rows [ i ] [ "PWH005" ] . ToString ( );
                    _modelPWH . PWH006 = da . Rows [ i ] [ "PWH006" ] . ToString ( );
                    _modelPWH . PWH007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PWH007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PWH007" ] . ToString ( ) );
                    _modelPWH . PWH013 = false;
                    _modelPWH . PWH009 = da . Rows [ i ] [ "PWH009" ] . ToString ( );
                    _modelPWH . PWH010 = false;
                    _modelPWH . PWH013 = false;
                    _modelPWH . PWH014 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PWH014" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PWH014" ] . ToString ( ) );
                    if ( string . IsNullOrEmpty ( da . Rows [ i ] [ "PWH016" ] . ToString ( ) ) )
                        _modelPWH . PWH016 = null;
                    else
                        _modelPWH . PWH016 = Convert . ToDateTime ( da . Rows [ i ] [ "PWH016" ] . ToString ( ) );
                   
                   
                    if ( dt . Select ( "PWH002='" + _modelPWH . PWH002 + "' AND PWH003='" + _modelPWH . PWH003 + "' AND PWH004='" + _modelPWH . PWH004 + "'" ) . Length < 1 )
                        add_bl ( _modelPWH ,strSql ,SQLString );
                    else
                        edit_bl ( _modelPWH ,strSql ,SQLString );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取备料周计划单号
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        string GetBLOddNum ( StringBuilder strSql )
        {
            strSql . Append ( "SELECT MAX(PWG001) PWG001 FROM MOXPWG" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PWG001" ] . ToString ( ) ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PWG001" ] . ToString ( ) . Substring ( 0 ,8 ) == UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PWG001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        void add_bl ( CarpenterEntity . ProductionPaintWeekPWHEntity _modelPWH ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPWH (" );
            strSql . Append ( "PWH001,PWH002,PWH003,PWH004,PWH005,PWH006,PWH007,PWH009,PWH010,PWH011,PWH012,PWH013,PWH014,PWH016) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PWH001,@PWH002,@PWH003,@PWH004,@PWH005,@PWH006,@PWH007,@PWH009,@PWH010,@PWH011,@PWH012,@PWH013,@PWH014,@PWH016) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWH001",SqlDbType.NVarChar,20),
                new SqlParameter("@PWH002",SqlDbType.NVarChar,20),
                new SqlParameter("@PWH003",SqlDbType.NVarChar,20),
                new SqlParameter("@PWH004",SqlDbType.NVarChar,20),
                new SqlParameter("@PWH005",SqlDbType.NVarChar,50),
                new SqlParameter("@PWH006",SqlDbType.NVarChar,20),
                new SqlParameter("@PWH007",SqlDbType.Int,4),
                new SqlParameter("@PWH009",SqlDbType.NVarChar,200),
                new SqlParameter("@PWH010",SqlDbType.Bit),
                new SqlParameter("@PWH011",SqlDbType.Date,3),
                new SqlParameter("@PWH012",SqlDbType.NVarChar,20),
                new SqlParameter("@PWH013",SqlDbType.Bit),
                new SqlParameter("@PWH014",SqlDbType.Int,4),
                new SqlParameter("@PWH016",SqlDbType.Date,3)
            };
            parameter [ 0 ] . Value = _modelPWH . PWH001;
            parameter [ 1 ] . Value = _modelPWH . PWH002;
            parameter [ 2 ] . Value = _modelPWH . PWH003;
            parameter [ 3 ] . Value = _modelPWH . PWH004;
            parameter [ 4 ] . Value = _modelPWH . PWH005;
            parameter [ 5 ] . Value = _modelPWH . PWH006;
            parameter [ 6 ] . Value = _modelPWH . PWH007;
            parameter [ 7 ] . Value = _modelPWH . PWH009;
            parameter [ 8 ] . Value = _modelPWH . PWH010;
            parameter [ 9 ] . Value = _modelPWH . PWH011;
            parameter [ 10 ] . Value = _modelPWH . PWH012;
            parameter [ 11 ] . Value = _modelPWH . PWH013;
            parameter [ 12 ] . Value = _modelPWH . PWH014;
            parameter [ 13 ] . Value = _modelPWH . PWH016;
            SQLString . Add ( strSql ,parameter );
        }

        void edit_bl ( CarpenterEntity . ProductionPaintWeekPWHEntity _modelPWH ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPWH SET " );
            strSql . Append ( "PWH007=@PWH007," );
            strSql . Append ( "PWH009=@PWH009," );
            strSql . Append ( "PWH011=@PWH011," );
            strSql . Append ( "PWH012=@PWH012," );
            strSql . Append ( "PWH014=@PWH014," );
            strSql . Append ( "PWH016=@PWH016 " );
            strSql . Append ( "WHERE PWH001=@PWH001 AND " );
            strSql . Append ( "PWH002=@PWH002 AND " );
            strSql . Append ( "PWH003=@PWH003 AND " );
            strSql . Append ( "PWH004=@PWH004 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWH001",SqlDbType.NVarChar,20),
                new SqlParameter("@PWH002",SqlDbType.NVarChar,20),
                new SqlParameter("@PWH003",SqlDbType.NVarChar,20),
                new SqlParameter("@PWH004",SqlDbType.NVarChar,20),
                new SqlParameter("@PWH007",SqlDbType.Int,4),
                new SqlParameter("@PWH009",SqlDbType.NVarChar,200),
                new SqlParameter("@PWH011",SqlDbType.Date,3),
                new SqlParameter("@PWH012",SqlDbType.NVarChar,20),
                new SqlParameter("@PWH014",SqlDbType.Int,4),
                new SqlParameter("@PWH016",SqlDbType.Date,3)
            };
            parameter [ 0 ] . Value = _modelPWH . PWH001;
            parameter [ 1 ] . Value = _modelPWH . PWH002;
            parameter [ 2 ] . Value = _modelPWH . PWH003;
            parameter [ 3 ] . Value = _modelPWH . PWH004;
            parameter [ 4 ] . Value = _modelPWH . PWH007;
            parameter [ 5 ] . Value = _modelPWH . PWH009;
            parameter [ 6 ] . Value = _modelPWH . PWH011;
            parameter [ 7 ] . Value = _modelPWH . PWH012;
            parameter [ 8 ] . Value = _modelPWH . PWH014;
            parameter [ 9 ] . Value = _modelPWH . PWH016;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 周计划  正式排产
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableBL_Add ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PDP001,PDP002,PDP003,PDP004,PDP024,PDP025 FROM MOXPDP " );
            strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN MOXPWH B ON A.PDP001=B.PWH003 AND A.PDP002=B.PWH004 WHERE A.idx IN (" + strWhere + ") AND PWH010=0) AND idx IN (" + strWhere + ")" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 周计划 预排
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableBLPlane_Add ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PDP001,PDP002,PDP003,PDP004,PDP024,PDP025 FROM MOXPDP  " );
            strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPDP A INNER JOIN MOXPWH B ON A.PDP001=B.PWH003 AND A.PDP002=B.PWH004 WHERE A.idx IN (" + strWhere + ")) AND idx IN (" + strWhere + ")" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否预排过
        /// </summary>
        /// <returns></returns>
        bool ExistsNum ( CarpenterEntity . ProductionPaintWeekPWHEntity _modelPWH )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPWH WHERE PWH003='{0}' AND PWH004='{1}' AND PWH010=1" ,_modelPWH . PWH003 ,_modelPWH . PWH004 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取预排报工数量
        /// </summary>
        /// <param name="_modelPWH"></param>
        /// <returns></returns>
        int getPlanNum ( CarpenterEntity . ProductionPaintWeekPWHEntity _modelPWH )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT SUM(PWI007) PWI007 FROM MOXPWH A INNER JOIN MOXPWI B ON A.PWH003=B.PWI002 AND A.PWH004=B.PWI003 WHERE PWI008=1 AND PWH003='{0}' AND PWH004='{1}'" ,_modelPWH . PWH003 ,_modelPWH . PWH004 );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PWI007" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToInt32 ( dt . Rows [ 0 ] [ "PWI007" ] . ToString ( ) );
            }
            else
                return 0;
        }

        /// <summary>
        /// 获取备料上次遗留
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableBLP ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PWH001,PWH002,PWH003,PWH004,PWH005,PWH006,PWH007,PWH009,PWH010,PWH012,PWH013,PWH014,PWH016 FROM MOXPWH A LEFT JOIN MOXPWI B ON A.PWH003=B.PWI002 AND A.PWH004=B.PWI003 " );
            strSql . Append ( "WHERE PWH001=(SELECT MAX ( PWH001 ) PWH001 FROM MOXPWH WHERE PWH001 <@PWH001) AND PWH010=0 " );
            strSql . Append ( "GROUP BY PWH001,PWH002,PWH003,PWH004,PWH005,PWH006,PWH007,PWH009,PWH010,PWH012,PWH013,PWH014,PWH016 " );
            strSql . Append ( "HAVING SUM(ISNULL(PWI007,0))<PWH007" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWH001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取周计划
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePWH ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PWH002,PWH003,PWH004 FROM MOXPWH " );
            strSql . AppendFormat ( "WHERE PWH001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
