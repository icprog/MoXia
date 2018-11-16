using StudentMgr;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Text;

namespace CarpenterBll . Dao
{
    public class PlanMachin_WeekDao
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
            strSql . Append ( "SELECT COUNT(1) FROM MOXPMC " );
            strSql . AppendFormat ( "WHERE PMC009='{0}' AND PMC001 LIKE '{1}%'" ,weekEnds ,UserInformation . dt ( ) . ToString ( "yyyy" ) );

            if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
            {
                x = 1;

                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPMC " );
                strSql . AppendFormat ( "WHERE PMC009='{0}' AND PMC001 LIKE '{1}%' AND PMC008=1" ,weekEnds ,UserInformation . dt ( ) . ToString ( "yyyy" ) );

                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return  2;

                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPMC " );
                strSql . AppendFormat ( "WHERE PMC009='{0}' AND PMC001 LIKE '{1}%' AND PMC007=1" ,weekEnds ,UserInformation . dt ( ) . ToString ( "yyyy" ) );

                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return  3;

                strSql = new StringBuilder ( );
                if ( planCheck )
                {
                    //strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST " );
                    //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPMD B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 WHERE A.idx IN (" + idxList + ")) AND idx IN (" + idxList + ")" );

                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPST A LEFT JOIN (SELECT SUM(ISNULL(PME007,0)) PDK007,PMD003,PMD004 FROM MOXPMD B LEFT JOIN MOXPME C ON B.PMD003=C.PME002 AND B.PMD004=C.PME003 AND B.PMD001=C.PME009 LEFT JOIN MOXPST D ON B.PMD003=D.PST001 AND B.PMD004=D.PST002 WHERE PMD010=1 AND D.idx IN ({0}) GROUP BY PMD003,PMD004) B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 WHERE A.idx IN ({0}) GROUP BY PST028,ISNULL(PDK007,0) HAVING PST028>ISNULL(PDK007,0)" ,idxList );

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4;
                    else
                        x = 1;
                }
                else
                {
                    strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST " );
                    strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPMD B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 INNER JOIN MOXPMC C ON B.PMD001=C.PMC001 WHERE A.idx IN (" + idxList + ") AND  PMC009='"+weekEnds+"' AND PMC001 LIKE '"+UserInformation.dt().ToString("yyyy")+"%' ) AND idx IN (" + idxList + ")" );

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
                    strSql . Append ( "SELECT COUNT(1) FROM MOXPST " );
                    strSql . AppendFormat ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPMD B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 WHERE A.idx IN ({0})) AND idx IN ({0})" ,idxList );//PMD010=0 AND 

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4;
                    else
                        x = 5;
                }
                else
                {
                    //strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST " );
                    //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPMD B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 WHERE A.idx IN (" + idxList + ") AND PMD010=0) AND idx IN (" + idxList + ")" );
                    strSql . AppendFormat ( "WITH CET AS (SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPMD B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 WHERE A.idx IN ({0}) AND PMD010=0) AND idx IN ({0}))" ,idxList );
                    strSql . AppendFormat ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028-ISNULL(PME007,0) PST028 FROM CET A LEFT JOIN (SELECT PMD003,PMD004,SUM(ISNULL(PME007,0)) PME007 FROM MOXPST C INNER JOIN MOXPMD A ON C.PST001=A.PMD003 AND C.PST002=A.PMD004 INNER JOIN MOXPME B ON A.PMD001=B.PME009 AND A.PMD003=B.PME002 AND A.PMD004=B.PME003 WHERE PMD010=1 AND C.idx IN ({0}) GROUP BY PMD003,PMD004) B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 GROUP BY PST001,PST002,PST003,PST004,PST025,PST028,PME007 HAVING PST028>ISNULL(PME007,0)" ,idxList );

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
        /// 生成机加工周计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Add_BL_Machine ( CarpenterEntity . PlanMachinPMCEntity _model ,List<string> strList  ,bool planCheck )
        {
            Hashtable SQLString = new Hashtable ( );

            StringBuilder strSql = new StringBuilder ( );
            _model . PMC001 = GetBLOddNum ( strSql );

            strSql = new StringBuilder ( );
            _model . PMC006 = UserInformation . UserName;
            _model . PMC002 = UserInformation . dt ( );
            _model . PMC007 = false;
            _model . PMC008 = false;
            strSql . Append ( "INSERT INTO MOXPMC (" );
            strSql . Append ( "PMC001,PMC002,PMC003,PMC004,PMC005,PMC006,PMC007,PMC008,PMC009) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PMC001,@PMC002,@PMC003,@PMC004,@PMC005,@PMC006,@PMC007,@PMC008,@PMC009) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMC001",SqlDbType.NVarChar,20),
                new SqlParameter("@PMC002",SqlDbType.NVarChar,20),
                new SqlParameter("@PMC003",SqlDbType.Date),
                new SqlParameter("@PMC004",SqlDbType.Date),
                new SqlParameter("@PMC005",SqlDbType.Date),
                new SqlParameter("@PMC006",SqlDbType.NVarChar,20),
                new SqlParameter("@PMC007",SqlDbType.Bit),
                new SqlParameter("@PMC008",SqlDbType.Bit),
                new SqlParameter("@PMC009",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PMC001;
            parameter [ 1 ] . Value = _model . PMC002;
            parameter [ 2 ] . Value = _model . PMC003;
            parameter [ 3 ] . Value = _model . PMC004;
            parameter [ 4 ] . Value = _model . PMC005;
            parameter [ 5 ] . Value = _model . PMC006;
            parameter [ 6 ] . Value = _model . PMC007;
            parameter [ 7 ] . Value = _model . PMC008;
            parameter [ 8 ] . Value = _model . PMC009;
            SQLString . Add ( strSql ,parameter );

            string name = "";
            foreach ( string str in strList )
            {
                if ( name == "" )
                    name = "'" + str + "'";
                else
                    name += "," + "'" + str + "'";
            }

            CarpenterEntity . PlanMachinPMDEntity _modelPLT = new CarpenterEntity . PlanMachinPMDEntity ( );
            DataTable dt;
            if ( planCheck )
                dt = GetDataTableBLPlane_Add ( name );
            else
                dt = GetDataTableBL_Add ( name );

            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPLT . PMD001 = _model . PMC001;
                _modelPLT . PMD011 = _model . PMC002;
                _modelPLT . PMD012 = _model . PMC006;

                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelPLT . PMD002 = string . Empty;
                    _modelPLT . PMD003 = dt . Rows [ i ] [ "PST001" ] . ToString ( );
                    _modelPLT . PMD004 = dt . Rows [ i ] [ "PST002" ] . ToString ( );
                    _modelPLT . PMD005 = dt . Rows [ i ] [ "PST003" ] . ToString ( );
                    _modelPLT . PMD006 = dt . Rows [ i ] [ "PST004" ] . ToString ( );
                    _modelPLT . PMD008 = _model . PMC004;
                    _modelPLT . PMD009 = dt . Rows [ i ] [ "PST025" ] . ToString ( );
                    _modelPLT . PMD013 = false;
                    _modelPLT . PMD007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PST028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PST028" ] . ToString ( ) );
                    _modelPLT . PMD010 = planCheck;

                        //if ( _modelPLT . PMD010 == false )
                        //{
                        //    if ( ExistsNum ( _modelPLT ) )
                        //    {
                        //        //订单量=订单量-预排报工数量
                        //        _modelPLT . PMD007 = _modelPLT . PMD007 - getPlanNum ( _modelPLT );
                        //    }
                        //}
                        add_bl ( _modelPLT ,strSql ,SQLString );

                    if ( _modelPLT . PMD010 == false && Exists_edit_bl ( _modelPLT . PMD003 ,_modelPLT . PMD004 ) == true )
                        edit_bl ( _modelPLT ,strSql ,SQLString ,_model . PMC009 );

                    edit_pas ( _modelPLT ,SQLString );

                    if ( _modelPLT . PMD010 == false && Exists_edit_Prs ( _modelPLT . PMD003 ,_modelPLT . PMD004 ) == true )
                        edit_Prs ( _modelPLT ,strSql ,SQLString );
                }
            }

            dt = GetDataTableBLP ( _model . PMC001 );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPLT . PMD001 = _model . PMC001;
                _modelPLT . PMD011 = _model . PMC002;
                _modelPLT . PMD012 = _model . PMC006;
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelPLT . PMD002 = dt . Rows [ i ] [ "PMD001" ] . ToString ( );
                    _modelPLT . PMD003 = dt . Rows [ i ] [ "PMD003" ] . ToString ( );
                    _modelPLT . PMD004 = dt . Rows [ i ] [ "PMD004" ] . ToString ( );
                    _modelPLT . PMD005 = dt . Rows [ i ] [ "PMD005" ] . ToString ( );
                    _modelPLT . PMD006 = dt . Rows [ i ] [ "PMD006" ] . ToString ( );
                    _modelPLT . PMD007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PMD007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PMD007" ] . ToString ( ) );
                    if ( string . IsNullOrEmpty ( dt . Rows [ i ] [ "PMD008" ] . ToString ( ) ) )
                        _modelPLT . PMD008 = null;
                    else
                        _modelPLT . PMD008 = Convert . ToDateTime ( dt . Rows [ i ] [ "PMD008" ] . ToString ( ) );
                    _modelPLT . PMD009 = dt . Rows [ i ] [ "PMD009" ] . ToString ( );
                    _modelPLT . PMD010 = false;
                    _modelPLT . PMD013 = false;
                    add_bl ( _modelPLT ,strSql ,SQLString );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 生产部生产跟踪表是否有此数据
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        bool Exists_edit_Prs ( string weekEnds ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXPRS " );
            strSql . AppendFormat ( "WHERE PRS001='{0}' AND PRS002='{1}'" ,weekEnds ,productNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 编辑生产部生产进度跟踪表机加工计划完成时间
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_Prs ( CarpenterEntity . PlanMachinPMDEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPRS SET " );
            strSql . Append ( "PRS009=@PRS009 " );
            strSql . Append ( "WHERE PRS001=@PRS001 AND PRS002=@PRS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PRS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS009",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _modelPLT . PMD003;
            parameter [ 1 ] . Value = _modelPLT . PMD004;
            parameter [ 2 ] . Value = _modelPLT . PMD008;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 覆盖机加工周计划  但不删除之前的内容
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Edit_BL_Machine ( CarpenterEntity . PlanMachinPMCEntity _model ,List<string> strList  ,bool planCheck )
        {
            Hashtable SQLString = new Hashtable ( );

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PMC001 FROM MOXPMC " );
            strSql . AppendFormat ( "WHERE PMC009='{0}' AND PMC001 LIKE '{1}%'" ,_model . PMC009 ,UserInformation . dt ( ) . ToString ( "yyyy" ) );

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( !string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PMC001" ] . ToString ( ) ) )
                    _model . PMC001 = da . Rows [ 0 ] [ "PMC001" ] . ToString ( );
                else
                    _model . PMC001 = string . Empty;
            }
            else
                _model . PMC001 = string . Empty;

            if ( _model . PMC001 == string . Empty )
                return false;

            strSql = new StringBuilder ( );
            _model . PMC006 = UserInformation . UserName;
            _model . PMC002 = UserInformation . dt ( );
            _model . PMC007 = false;
            _model . PMC008 = false;
            strSql . Append ( "UPDATE MOXPMC SET " );
            strSql . Append ( "PMC002=@PMC002," );
            strSql . Append ( "PMC003=@PMC003," );
            strSql . Append ( "PMC004=@PMC004," );
            strSql . Append ( "PMC005=@PMC005," );
            strSql . Append ( "PMC006=@PMC006," );
            strSql . Append ( "PMC007=@PMC007," );
            strSql . Append ( "PMC008=@PMC008 " );
            strSql . Append ( "WHERE PMC001=@PMC001 AND " );
            strSql . Append ( "PMC009=@PMC009" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMC001",SqlDbType.NVarChar,20),
                new SqlParameter("@PMC002",SqlDbType.Date),
                new SqlParameter("@PMC003",SqlDbType.Date),
                new SqlParameter("@PMC004",SqlDbType.Date),
                new SqlParameter("@PMC005",SqlDbType.Date),
                new SqlParameter("@PMC006",SqlDbType.NVarChar,20),
                new SqlParameter("@PMC007",SqlDbType.Bit),
                new SqlParameter("@PMC008",SqlDbType.Bit),
                new SqlParameter("@PMC009",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PMC001;
            parameter [ 1 ] . Value = _model . PMC002;
            parameter [ 2 ] . Value = _model . PMC003;
            parameter [ 3 ] . Value = _model . PMC004;
            parameter [ 4 ] . Value = _model . PMC005;
            parameter [ 5 ] . Value = _model . PMC006;
            parameter [ 6 ] . Value = _model . PMC007;
            parameter [ 7 ] . Value = _model . PMC008;
            parameter [ 8 ] . Value = _model . PMC009;
            SQLString . Add ( strSql ,parameter );

            da = null;
            CarpenterEntity . PlanMachinPMDEntity _modelPLT = new CarpenterEntity . PlanMachinPMDEntity ( );
            string name = "";
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

            DataTable dt = GetDataTablePLT ( _model . PMC001 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPLT . PMD001 = _model . PMC001;
                _modelPLT . PMD011 = _model . PMC002;
                _modelPLT . PMD012 = _model . PMC006;

                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPLT . PMD002 = string . Empty;
                    _modelPLT . PMD003 = da . Rows [ i ] [ "PST001" ] . ToString ( );
                    _modelPLT . PMD004 = da . Rows [ i ] [ "PST002" ] . ToString ( );
                    _modelPLT . PMD005 = da . Rows [ i ] [ "PST003" ] . ToString ( );
                    _modelPLT . PMD006 = da . Rows [ i ] [ "PST004" ] . ToString ( );
                    _modelPLT . PMD008 = _model . PMC004;
                    _modelPLT . PMD009 = da . Rows [ i ] [ "PST025" ] . ToString ( );
                    _modelPLT . PMD013 = false;
                    _modelPLT . PMD007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PST028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PST028" ] . ToString ( ) );
                    _modelPLT . PMD010 = planCheck;
                    if ( dt . Select ( "PMD002='" + _modelPLT . PMD002 + "' AND PMD003='" + _modelPLT . PMD003 + "' AND PMD004='" + _modelPLT . PMD004 + "'" ) . Length < 1 )
                    {
                        //if ( _modelPLT . PMD010 == false )
                        //{
                        //    if ( ExistsNum ( _modelPLT ) )
                        //    {
                        //        //订单量=订单量-预排报工数量
                        //        _modelPLT . PMD007 = _modelPLT . PMD007 - getPlanNum ( _modelPLT );
                        //    }
                        //}
                        add_bl ( _modelPLT ,strSql ,SQLString );
                    }
                    else
                        edit_bl ( _modelPLT ,strSql ,SQLString );

                    if ( _modelPLT . PMD010 == false && Exists_edit_bl ( _modelPLT . PMD003 ,_modelPLT . PMD004 ) == true )
                        edit_bl ( _modelPLT ,strSql ,SQLString ,_model . PMC009 );

                    edit_pas ( _modelPLT ,SQLString );

                }
            }

            da = GetDataTableBLP ( _model . PMC001 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPLT . PMD001 = _model . PMC001;
                _modelPLT . PMD011 = _model . PMC002;
                _modelPLT . PMD012 = _model . PMC006;
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPLT . PMD002 = da . Rows [ i ] [ "PMD001" ] . ToString ( );
                    _modelPLT . PMD003 = da . Rows [ i ] [ "PMD003" ] . ToString ( );
                    _modelPLT . PMD004 = da . Rows [ i ] [ "PMD004" ] . ToString ( );
                    _modelPLT . PMD005 = da . Rows [ i ] [ "PMD005" ] . ToString ( );
                    _modelPLT . PMD006 = da . Rows [ i ] [ "PMD006" ] . ToString ( );
                    _modelPLT . PMD007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PMD007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PMD007" ] . ToString ( ) );
                    _modelPLT . PMD010 = false;

                    if ( string . IsNullOrEmpty ( da . Rows [ i ] [ "PMD008" ] . ToString ( ) ) )
                        _modelPLT . PMD008 = null;
                    else
                        _modelPLT . PMD008 = Convert . ToDateTime ( da . Rows [ i ] [ "PMD008" ] . ToString ( ) );
                    _modelPLT . PMD009 = da . Rows [ i ] [ "PMD009" ] . ToString ( );
                    _modelPLT . PMD013 = false;
                    if ( dt . Select ( "PMD002='" + _modelPLT . PMD002 + "' AND PMD003='" + _modelPLT . PMD003 + "' AND PMD004='" + _modelPLT . PMD004 + "'" ) . Length < 1 )
                        add_bl ( _modelPLT ,strSql ,SQLString );
                    else
                        edit_bl ( _modelPLT ,strSql ,SQLString );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 周计划 预排
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableBLPlane_Add ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST " );
            //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPMD B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 WHERE A.idx IN (" + strWhere + ")) AND idx IN (" + strWhere + ")" );

            strSql . AppendFormat ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028-SUM(ISNULL(PME007,0)) PST028 FROM MOXPST A LEFT JOIN MOXPMD B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 LEFT JOIN MOXPME C ON B.PMD003=C.PME002 AND B.PMD004=C.PME003 AND B.PMD001=C.PME009 WHERE A.idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPMD B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 WHERE A.idx IN ({0})) AND A.idx IN ({0}) GROUP BY PST001,PST002,PST003,PST004,PST025,PST028 HAVING PST028>SUM(ISNULL(PME007,0))" ,strWhere );

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
            //strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST " );
            //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPMD B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 WHERE A.idx IN (" + strWhere + ") AND PMD010=0) AND idx IN (" + strWhere + ")" );

            strSql . AppendFormat ( "WITH CET AS (SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPMD B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 WHERE A.idx IN ({0}) AND PMD010=0) AND idx IN ({0}))" ,strWhere );
            strSql . AppendFormat ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028-ISNULL(PME007,0) PST028 FROM CET A LEFT JOIN (SELECT PMD003,PMD004,SUM(ISNULL(PME007,0)) PME007 FROM MOXPST C INNER JOIN MOXPMD A ON C.PST001=A.PMD003 AND C.PST002=A.PMD004 INNER JOIN MOXPME B ON A.PMD001=B.PME009 AND A.PMD003=B.PME002 AND A.PMD004=B.PME003 WHERE PMD010=1 AND C.idx IN ({0}) GROUP BY PMD003,PMD004) B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 GROUP BY PST001,PST002,PST003,PST004,PST025,PST028,PME007 HAVING PST028>ISNULL(PME007,0)" ,strWhere );

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
            strSql . Append ( "SELECT PMD002,PMD003,PMD004 FROM MOXPMD " );
            strSql . AppendFormat ( "WHERE PMD001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void add_bl ( CarpenterEntity . PlanMachinPMDEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPMD (" );
            strSql . Append ( "PMD001,PMD002,PMD003,PMD004,PMD005,PMD006,PMD007,PMD008,PMD009,PMD010,PMD011,PMD012,PMD013) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PMD001,@PMD002,@PMD003,@PMD004,@PMD005,@PMD006,@PMD007,@PMD008,@PMD009,@PMD010,@PMD011,@PMD012,@PMD013) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMD001",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD002",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD003",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD004",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD005",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD006",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD007",SqlDbType.Int),
                new SqlParameter("@PMD008",SqlDbType.Date),
                new SqlParameter("@PMD009",SqlDbType.NVarChar,200),
                new SqlParameter("@PMD010",SqlDbType.Bit),
                new SqlParameter("@PMD011",SqlDbType.Date),
                new SqlParameter("@PMD012",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD013",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _modelPLT . PMD001;
            parameter [ 1 ] . Value = _modelPLT . PMD002;
            parameter [ 2 ] . Value = _modelPLT . PMD003;
            parameter [ 3 ] . Value = _modelPLT . PMD004;
            parameter [ 4 ] . Value = _modelPLT . PMD005;
            parameter [ 5 ] . Value = _modelPLT . PMD006;
            parameter [ 6 ] . Value = _modelPLT . PMD007;
            parameter [ 7 ] . Value = _modelPLT . PMD008;
            parameter [ 8 ] . Value = _modelPLT . PMD009;
            parameter [ 9 ] . Value = _modelPLT . PMD010;
            parameter [ 10 ] . Value = _modelPLT . PMD011;
            parameter [ 11 ] . Value = _modelPLT . PMD012;
            parameter [ 12 ] . Value = _modelPLT . PMD013;
            SQLString . Add ( strSql ,parameter );
        }

        void edit_bl ( CarpenterEntity . PlanMachinPMDEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPMD SET " );
            strSql . Append ( "PMD005=@PMD005," );
            strSql . Append ( "PMD006=@PMD006," );
            strSql . Append ( "PMD007=@PMD007," );
            strSql . Append ( "PMD008=@PMD008," );
            strSql . Append ( "PMD009=@PMD009," );
            //strSql . Append ( "PMD010=PMD010," );
            strSql . Append ( "PMD011=@PMD011," );
            strSql . Append ( "PMD012=@PMD012 " );
            strSql . Append ( "WHERE PMD001=@PMD001 AND " );
            strSql . Append ( "PMD002=@PMD002 AND " );
            strSql . Append ( "PMD003=@PMD003 AND " );
            strSql . Append ( "PMD004=@PMD004 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMD001",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD002",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD003",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD004",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD005",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD006",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD007",SqlDbType.Int),
                new SqlParameter("@PMD008",SqlDbType.Date),
                new SqlParameter("@PMD009",SqlDbType.NVarChar,200),
                //new SqlParameter("PMD010",SqlDbType.Bit),
                new SqlParameter("@PMD011",SqlDbType.Date),
                new SqlParameter("@PMD012",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelPLT . PMD001;
            parameter [ 1 ] . Value = _modelPLT . PMD002;
            parameter [ 2 ] . Value = _modelPLT . PMD003;
            parameter [ 3 ] . Value = _modelPLT . PMD004;
            parameter [ 4 ] . Value = _modelPLT . PMD005;
            parameter [ 5 ] . Value = _modelPLT . PMD006;
            parameter [ 6 ] . Value = _modelPLT . PMD007;
            parameter [ 7 ] . Value = _modelPLT . PMD008;
            parameter [ 8 ] . Value = _modelPLT . PMD009;
            //parameter [ 9 ] . Value = _modelPLT . PMD010;
            parameter [ 9 ] . Value = _modelPLT . PMD011;
            parameter [ 10 ] . Value = _modelPLT . PMD012;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 是否预排过
        /// </summary>
        /// <returns></returns>
        bool ExistsNum ( CarpenterEntity . PlanMachinPMDEntity _modelPLT )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPMD WHERE PMD003='{0}' AND PMD004='{1}' AND PMD010=1" ,_modelPLT . PMD003 ,_modelPLT . PMD004 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取预排报工数量
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <returns></returns>
        int getPlanNum ( CarpenterEntity . PlanMachinPMDEntity _modelPLT )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT SUM(PME007) PME007 FROM MOXPMD A INNER JOIN MOXPME B ON A.PMD003=B.PME002 AND A.PMD004=B.PME003 WHERE PME008=1 AND PMD003='{0}' AND PMD004='{1}'" ,_modelPLT . PMD003 ,_modelPLT . PMD004 );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PME007" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToInt32 ( dt . Rows [ 0 ] [ "PME007" ] . ToString ( ) );
            }
            else
                return 0;
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
            strSql . Append ( "SELECT PST023 FROM MOXPST " );
            strSql . Append ( "WHERE PST001=@PST001 AND PST002=@PST002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PST001",SqlDbType.NVarChar,20),
                new SqlParameter("@PST002",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PST023" ] . ToString ( ) ) )
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        /// <summary>
        /// 周计划生成时编辑机加工计划完成时间批次周次
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        /// <param name="weekNum"></param>
        void edit_bl ( CarpenterEntity . PlanMachinPMDEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString ,string weekNum )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPST SET " );
            strSql . Append ( "PST023=@PST023 " );
            strSql . Append ( "WHERE PST001=@PST001 AND PST002=@PST002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PST001",SqlDbType.NVarChar,20),
                new SqlParameter("@PST002",SqlDbType.NVarChar,20),
                new SqlParameter("@PST023",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelPLT . PMD003;
            parameter [ 1 ] . Value = _modelPLT . PMD004;
            parameter [ 2 ] . Value = "第" + weekNum + "周";

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 标记已排计划未审核的记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="SQLString"></param>
        void edit_pas ( CarpenterEntity . PlanMachinPMDEntity model ,Hashtable SQLString )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPST SET " );
            strSql . Append ( "PST030=@PST030 " );
            strSql . Append ( "WHERE PST001=@PST001 AND PST002=@PST002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PST001",SqlDbType.NVarChar,20),
                new SqlParameter("@PST002",SqlDbType.NVarChar,20),
                new SqlParameter("@PST030",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = model . PMD003;
            parameter [ 1 ] . Value = model . PMD004;
            parameter [ 2 ] . Value = true;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 获取机加工上次遗留
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableBLP ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PMD001,PMD002,PMD003,PMD004,PMD005,PMD006,PMD008,PMD007-SUM(ISNULL(PME007,0)) PMD012,PMD007,PMD009 FROM MOXPMD A LEFT JOIN MOXPME B ON A.PMD003=B.PME002 and A.PMD004=B.PME003 " );
            strSql . Append ( "WHERE PMD001=(SELECT MAX(PMD001) PMD001 FROM MOXPMD WHERE PMD001<@PMD001) AND PMD013=0 AND PMD010=0 " );
            strSql . Append ( "GROUP BY PMD001,PMD002,PMD003,PMD004,PMD005,PMD006,PMD008,PMD012,PMD007,PMD009 " );
            strSql . Append ( "HAVING SUM(ISNULL(PME007,0))<PMD007  " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMD001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取机加工周计划单号
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        string GetBLOddNum ( StringBuilder strSql )
        {
            strSql . Append ( "SELECT MAX(PMC001) PMC001 FROM MOXPMC" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PMC001" ] . ToString ( ) ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PMC001" ] . ToString ( ) . Substring ( 0 ,8 ) == UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PMC001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
        }


        /// <summary>
        /// 周计划机加工报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool JDailyWeek ( DataTable table  ,bool state )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . PlanMachinWeekDailyWorkEntity _model = new CarpenterEntity . PlanMachinWeekDailyWorkEntity ( );
            _model . PME001 = DailyWeekOddNum ( );
            _model . PME013 = UserInformation . dt ( );
            _model . PME014 = UserInformation . UserName;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . PME002 = table . Rows [ i ] [ "PST001" ] . ToString ( );
                _model . PME003 = table . Rows [ i ] [ "PST002" ] . ToString ( );
                _model . PME004 = table . Rows [ i ] [ "PST003" ] . ToString ( );
                _model . PME005 = table . Rows [ i ] [ "PST004" ] . ToString ( );
                _model . PME006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PST028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PST028" ] . ToString ( ) );
                _model . PME007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DL" ] . ToString ( ) );
                _model . PME008 = state;
                _model . PME009 = table . Rows [ i ] [ "PMD001" ] . ToString ( );
                _model . PME012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PME012" ] . ToString ( ) ) == true ? UserInformation . dt ( ) : Convert . ToDateTime ( table . Rows [ i ] [ "PME012" ] . ToString ( ) );
                edit_BL_DailyWork ( _model ,strSql ,SQLString );
                //edit_J_Table ( _model ,strSql ,SQLString );
                if ( Exists_bl_day ( _model . PME002 ,_model . PME003 ,_model . PME007 ) == true )
                {
                    edit_bl_day ( _model . PME002 ,_model . PME003 ,SQLString ,strSql );
                }

                //若报工总数量=生产数量  则回写完工时间到生产部生产进度跟踪表的对应工段完工时间
                _model . PME007 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PME007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PME007" ] . ToString ( ) );

                if ( Exists_bl_day ( _model . PME002 ,_model . PME003 ,_model . PME007 ,_model . PME008 ) == true && CarpenterBll . ColumnValues . pro_cg . Equals ( "常规" ) )
                {
                    //edit_BL_Prs ( _model ,strSql ,SQLString );
                    edit_BL_PST ( _model ,strSql ,SQLString );
                }
                else if ( Exists_bl_dayOther ( _model . PME002 ,_model . PME003 ,_model . PME007 ) == true && CarpenterBll . ColumnValues . pro_cg . Equals ( "其它" ) )
                {
                    //edit_BL_Prs ( _model ,strSql ,SQLString );
                    edit_BL_PST ( _model ,strSql ,SQLString );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        
        string DailyWeekOddNum ( )
        {
            DataTable dt = SqlHelper . ExecuteDataTable ( "SELECT MAX(PME001) PME001 FROM MOXPME " );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PME001" ] . ToString ( ) ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PME001" ] . ToString ( ) . Substring ( 0 ,8 ) == UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PME001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        void edit_BL_DailyWork ( CarpenterEntity . PlanMachinWeekDailyWorkEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPME (" );//,PDK009,PDK010,PDK011,
            strSql . Append ( "PME001,PME002,PME003,PME004,PME005,PME006,PME007,PME008,PME012,PME013,PME014,PME009) " );
            strSql . Append ( "VALUES (" );//,PDK009,PDK010,PDK011,
            strSql . Append ( "@PME001,@PME002,@PME003,@PME004,@PME005,@PME006,@PME007,@PME008,@PME012,@PME013,@PME014,@PME009) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PME001",SqlDbType.NVarChar,20),
                new SqlParameter("@PME002",SqlDbType.NVarChar,20),
                new SqlParameter("@PME003",SqlDbType.NVarChar,20),
                new SqlParameter("@PME004",SqlDbType.NVarChar,20),
                new SqlParameter("@PME005",SqlDbType.NVarChar,20),
                new SqlParameter("@PME006",SqlDbType.Int),
                new SqlParameter("@PME007",SqlDbType.Int),
                new SqlParameter("@PME008",SqlDbType.Bit),               
                //new SqlParameter("PDK010",SqlDbType.Int),
                //new SqlParameter("PDK011",SqlDbType.Int),
                new SqlParameter("@PME012",SqlDbType.Date),
                new SqlParameter("@PME013",SqlDbType.Date),
                new SqlParameter("@PME014",SqlDbType.NVarChar,20),
                new SqlParameter("@PME009",SqlDbType.NVarChar,50)
            };
            parameter [ 0 ] . Value = _model . PME001;
            parameter [ 1 ] . Value = _model . PME002;
            parameter [ 2 ] . Value = _model . PME003;
            parameter [ 3 ] . Value = _model . PME004;
            parameter [ 4 ] . Value = _model . PME005;
            parameter [ 5 ] . Value = _model . PME006;
            parameter [ 6 ] . Value = _model . PME007;
            parameter [ 7 ] . Value = _model . PME008;          
            //parameter [ 9 ] . Value = _model . PDK010;
            //parameter [ 10 ] . Value = _model . PDK011;
            parameter [ 8 ] . Value = _model . PME012;
            parameter [ 9 ] . Value = _model . PME013;
            parameter [ 10 ] . Value = _model . PME014;
            parameter [ 11 ] . Value = _model . PME009;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 写报工时间到机加工跟踪表的机加工完成时间
        /// </summary>
        void edit_J_Table ( CarpenterEntity . PlanMachinWeekDailyWorkEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPST SET PST024=@PST024 WHERE PST001=@PST001 AND PST002=@PST002" );
            SqlParameter [ ] parameterr = {
                new SqlParameter("@PST001",SqlDbType.NVarChar,20),
                new SqlParameter("@PST002",SqlDbType.NVarChar,20),
                new SqlParameter("@PST024",SqlDbType.Date)
            };
            parameterr [ 0 ] . Value = _model . PME002;
            parameterr [ 1 ] . Value = _model . PME003;
            parameterr [ 2 ] . Value = _model . PME012;
            SQLString . Add ( strSql ,parameterr );
        }

        /// <summary>
        /// 周计划中是否存在此批号和品号
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        bool Exists_bl_day ( string weekEnds ,string productNum ,int nums )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT SUM(PMD007) PMD007 FROM MOXPMD " );
            strSql . Append ( "WHERE PMD003=@PMD003 AND PMD004=@PMD004 " ); //AND PMD010=0
            strSql . Append ( "GROUP BY PMD003,PMD004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMD003",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PMD007" ] . ToString ( ) ) )
                    return false;
                int num = Convert . ToInt32 ( da . Rows [ 0 ] [ "PMD007" ] . ToString ( ) );
                if ( num == nums )
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 是否达到回写条件：1、若是预排，则检测预排订单量是否等于报工量  2、若是正排，则检测正排订单量+预排报工量是否等于报工量
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        bool Exists_bl_day ( string weekEnds ,string productNum ,int nums ,bool state )
        {
            StringBuilder strSql = new StringBuilder ( );
            
            if ( state )
                //strSql . AppendFormat ( "SELECT SUM(PMD007) PMD007 FROM MOXPMD WHERE PMD003='{0}' AND PMD004='{1}' AND PMD010=1" ,weekEnds ,productNum );
                strSql . AppendFormat ( "SELECT SUM(PMD007) PMD007 FROM MOXPMD A INNER JOIN (SELECT MAX(PMD001) PMD001,PMD003,PMD004 FROM MOXPMD WHERE PMD003='{0}' AND PMD004='{1}' AND PMD010=1 GROUP BY PMD003,PMD004) B ON A.PMD001=B.PMD001 AND A.PMD003=B.PMD003 AND A.PMD004=B.PMD004 WHERE A.PMD003='{0}' AND A.PMD004='{1}' AND PMD010=1" ,weekEnds ,productNum );
            else
                //strSql . AppendFormat ( "SELECT SUM(PMD007)+ ISNULL(PME007,0) PMD007 FROM MOXPMD A LEFT JOIN (SELECT SUM(ISNULL(PME007,0)) PME007,PME002,PME003 FROM MOXPME WHERE PME008=1 AND PME002='{0}' AND PME003='{1}' GROUP BY PME002,PME003) B ON A.PMD003=B.PME002 AND A.PMD004=B.PME003 WHERE PMD010=0 AND PMD003='{0}' AND PMD004='{1}' GROUP BY  ISNULL(PME007,0)" ,weekEnds ,productNum );   1814    51-1.001.02.008
                strSql . AppendFormat ( "SELECT SUM(PMD007)+ ISNULL(PME007,0) PMD007 FROM MOXPMD A INNER JOIN (SELECT MAX(PMD001) PMD001,PMD003,PMD004 FROM MOXPMD WHERE PMD010=0 AND PMD003='{0}' AND PMD004='{1}' GROUP BY PMD003,PMD004) C ON A.PMD001=C.PMD001 AND A.PMD003=C.PMD003 AND A.PMD004=C.PMD004 LEFT JOIN (SELECT SUM(ISNULL(PME007,0)) PME007,PME002,PME003 FROM MOXPME WHERE PME008=1 AND PME002='{0}' AND PME003='{1}' GROUP BY PME002,PME003) B ON A.PMD003=B.PME002 AND A.PMD004=B.PME003 WHERE PMD010=0 AND A.PMD003='{0}' AND A.PMD004='{1}' GROUP BY  ISNULL(PME007,0)" ,weekEnds ,productNum );

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PMD007" ] . ToString ( ) ) )
                    return false;
                int num = Convert . ToInt32 ( da . Rows [ 0 ] [ "PMD007" ] . ToString ( ) );
                if ( num == nums )
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 是否达到回写条件：检测正排订单量是否等于报工量
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        bool Exists_bl_dayOther ( string weekEnds ,string productNum ,int nums )
        {
            StringBuilder strSql = new StringBuilder ( );

            strSql . AppendFormat ( "SELECT PST028-SUM(ISNULL(PME007,0))-{2} PMD007 FROM MOXPST A LEFT JOIN MOXPME B ON A.PST001=B.PME002 AND A.PST002=B.PME003 WHERE PST001='{0}' AND PST002='{1}' GROUP BY PST028" ,weekEnds ,productNum ,nums );

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PMD007" ] . ToString ( ) ) )
                    return false;
                int num = Convert . ToInt32 ( da . Rows [ 0 ] [ "PMD007" ] . ToString ( ) );
                if ( num ==0 )
                    return true;
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
        void edit_bl_day ( string weekEnds ,string productNum ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPMD SET " );
            strSql . Append ( "PMD013=1 " );
            strSql . Append ( "WHERE PMD003=@PMD003 AND PMD004=@PMD004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMD003",SqlDbType.NVarChar,20),
                new SqlParameter("@PMD004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = weekEnds;
            parameter [ 1 ] . Value = productNum;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 回写完工日期到生产部生产进度跟踪表
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_BL_Prs ( CarpenterEntity . PlanMachinWeekDailyWorkEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPRS SET " );
            strSql . Append ( "PRS010=@PRS010 " );
            strSql . Append ( "WHERE PRS001=@PRS001 AND PRS002=@PRS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PRS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS010",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . PME002;
            parameter [ 1 ] . Value = _model . PME003;
            parameter [ 2 ] . Value = _model . PME013;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 回写完工标记到跟踪表
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_BL_PST ( CarpenterEntity . PlanMachinWeekDailyWorkEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXPST SET PST032=1,PST024='{2}' WHERE PST001='{0}' AND PST002='{1}' " ,_model . PME002 ,_model . PME003 ,_model . PME012 );

            SQLString . Add ( strSql ,null );
        }

    }
}
