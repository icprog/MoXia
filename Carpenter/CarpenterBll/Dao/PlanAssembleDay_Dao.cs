using System;
using System . Collections . Generic;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class PlanAssembleDay_Dao
    {
        /// <summary>
        /// 是否存在生产组装日计划   相同的工段和计划日期
        /// </summary>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public int Exists_Day_Assemeble ( string workShop ,DateTime dt ,List<string> intList ,bool planCheck )
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
            
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXPLD " );
            strSql . AppendFormat ( "WHERE PLD002='{0}' AND PLD003='{1}'" ,workShop ,dt );

            if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
            {
                x = 1; //编辑

                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPLD " );
                strSql . AppendFormat ( "WHERE PLD002='{0}' AND PLD003='{1}' AND PLD005=1" ,workShop ,dt );
                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return 2; //已注销
                

                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPLD " );
                strSql . AppendFormat ( "WHERE PLD002='{0}' AND PLD003='{1}' AND PLD006=1" ,workShop ,dt );
                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return 3; //已审核

                strSql = new StringBuilder ( );
                if ( planCheck )
                {
                    //同批号和品号只能排一次预排
                    //strSql . Append ( "SELECT COUNT(1) COUNT FROM MOXPAS WHERE idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN MOXPLE B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 INNER JOIN MOXPLD C ON B.PLE001=C.PLD001 " );
                    //strSql . Append ( "WHERE A.idx IN (" + idxStr + ") AND PLD002='" + workShop + "' AND PLD003='" + dt + "') AND idx IN (" + idxStr + ")" );

                    //同批号和品号可以排多次预排
                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPAS A LEFT JOIN MOXPLF C ON A.PAS001=C.PLF002 AND A.PAS002=C.PLF003 WHERE A.idx IN ({0}) AND PAS001+PAS002 NOT IN (SELECT A.PLE003+A.PLE004 FROM MOXPLE A INNER JOIN MOXPLD D ON A.PLE001=D.PLD001 INNER JOIN MOXPAS C ON A.PLE003=C.PAS001 AND A.PLE004=C.PAS002 WHERE D.PLD002='{1}' AND PLD003='{2}') GROUP BY PAS016,PAS001,PAS002 HAVING PAS016>SUM(ISNULL(PLF007,0)) " ,idxStr ,workShop ,dt );

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4; //预排产品已经存在  不允许排
                    else
                        x = 1;  //编辑
                }
                else
                {
                    //strSql . AppendFormat ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS025,PAS028 FROM MOXPAS WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN (SELECT PLE003,PLE004,PLE002 FROM (SELECT PLE001,PLE003,PLE004,PLE002 FROM MOXPLE WHERE PLE001 IN (SELECT MAX(PLE001) FROM MOXPLE WHERE PLE012=0 GROUP BY PLE003,PLE004)) A INNER JOIN MOXPLD B ON A.PLE001=B.PLD001 WHERE PLE002='完工' AND PLD002='{1}' AND PLD003='{2}') B  ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 WHERE A.idx in ({0})) ORDER BY PAS001,PAS002" ,idxStr ,workShop ,dt );
                    //strSql . AppendFormat ( "SELECT PAS001,PAS002,PAS003,PAS004 FROM MOXPAS WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN (SELECT PLE003,PLE004,PLE002 FROM (SELECT PLE001,PLE003,PLE004,PLE002,PLE007 FROM MOXPLE WHERE PLE001 IN (SELECT MAX(PLE001) FROM MOXPLE WHERE PLE012=0 GROUP BY PLE003,PLE004)) A INNER JOIN MOXPLD B ON A.PLE001=B.PLD001 INNER JOIN MOXPAS C ON A.PLE003=C.PAS001 AND A.PLE004=C.PAS002 WHERE PLE002='完工' AND PLD002='{1}' GROUP BY PLE003,PLE004,PLE002,PAS016 HAVING PAS016<=SUM(ISNULL(PLE007,0))) B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 WHERE A.idx in ({0})) ORDER BY PAS001,PAS002" ,idxStr ,workShop );
                    strSql . AppendFormat ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS013,PAS016-ISNULL(PLE007,0) PAS016 FROM MOXPAS A LEFT JOIN (SELECT SUM(ISNULL(PLE007,0)) PLE007,PLE003,PLE004 FROM MOXPLE WHERE PLE001 IN (SELECT MAX(PLE001) FROM MOXPLE A LEFT JOIN MOXPAS B ON A.PLE003=B.PAS001 AND A.PLE004=B.PAS002 WHERE PLE002='完工' AND B.idx IN ({0}) ) GROUP BY PLE003,PLE004) B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 WHERE A.idx in ({0}) AND A.idx NOT IN (SELECT A.idx FROM MOXPAS A LEFT JOIN MOXPLE B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 LEFT JOIN MOXPLD C ON B.PLE001=C.PLD001 WHERE B.PLE002='完工' AND B.PLE013='' AND PLD003='{1}' AND A.idx IN ({0})) GROUP BY PAS001,PAS002,PAS003,PAS004,PAS013,PAS016,PLE007 HAVING PAS016>ISNULL(PLE007,0) ORDER BY PAS001,PAS002" ,idxStr ,dt );

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
                    //strSql . Append ( "SELECT COUNT(1) COUNT FROM MOXPAS WHERE idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN MOXPLE B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 INNER JOIN MOXPLD C ON B.PLE001=C.PLD001 " );
                    //strSql . Append ( "WHERE A.idx IN (" + idxStr + ") AND PLD002='" + workShop + "') AND idx IN (" + idxStr + ")" );

                    //同批号和品号可以排多次预排
                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPAS A LEFT JOIN MOXPLF C ON A.PAS001=C.PLF002 AND A.PAS002=C.PLF003 WHERE A.idx IN ({0}) AND PAS001+PAS002 NOT IN (SELECT A.PLE003+A.PLE004 FROM MOXPLE A INNER JOIN MOXPLD D ON A.PLE001=D.PLD001 INNER JOIN MOXPAS C ON A.PLE003=C.PAS001 AND A.PLE004=C.PAS002 WHERE D.PLD002='{1}' AND PLD003='{2}') GROUP BY PAS016,PAS001,PAS002 HAVING PAS016>SUM(ISNULL(PLF007,0)) " ,idxStr ,workShop ,dt );

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4; //预排产品已经存在  不允许排
                    else
                        x = 5;  //新增
                }
                else
                {
                    //查询已经排正式且未完工的产品 预排的不管
                    //strSql . AppendFormat ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS025,PAS028 FROM MOXPAS WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN (SELECT PLE003,PLE004,PLE002 FROM (SELECT PLE001,PLE003,PLE004,PLE002 FROM MOXPLE WHERE PLE001 IN (SELECT MAX(PLE001) FROM MOXPLE WHERE PLE012=0 GROUP BY PLE003,PLE004)) A INNER JOIN MOXPLD B ON A.PLE001=B.PLD001 WHERE PLE002='完工' AND PLD002='{1}') B  ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 WHERE A.idx in ({0})) ORDER BY PAS001,PAS002" ,idxStr ,workShop );
                    //strSql . AppendFormat ( "SELECT PAS001,PAS002,PAS003,PAS004 FROM MOXPAS WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN (SELECT PLE003,PLE004,PLE002 FROM (SELECT PLE001,PLE003,PLE004,PLE002,PLE007 FROM MOXPLE WHERE PLE001 IN (SELECT MAX(PLE001) FROM MOXPLE WHERE PLE012=0 GROUP BY PLE003,PLE004)) A INNER JOIN MOXPLD B ON A.PLE001=B.PLD001 INNER JOIN MOXPAS C ON A.PLE003=C.PAS001 AND A.PLE004=C.PAS002 WHERE PLD002='{1}' AND PLE002='完工' GROUP BY PLE003,PLE004,PLE002,PLE002,PAS016,PLD002 HAVING PAS016<=SUM(ISNULL(PLE007,0)) ) B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 WHERE A.idx in ({0})) ORDER BY PAS001,PAS002" ,idxStr ,workShop );
                    strSql . AppendFormat ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS013,PAS016-ISNULL(PLE007,0) PAS016 FROM MOXPAS A LEFT JOIN (SELECT SUM(ISNULL(PLE007,0)) PLE007,PLE003,PLE004 FROM MOXPLE WHERE PLE001 IN (SELECT MAX(PLE001) FROM MOXPLE A LEFT JOIN MOXPAS B ON A.PLE003=B.PAS001 AND A.PLE004=B.PAS002 WHERE PLE002='完工' AND B.idx IN ({0})) GROUP BY PLE003,PLE004) B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 WHERE A.idx in ({0}) GROUP BY PAS001,PAS002,PAS003,PAS004,PAS013,PAS016,ISNULL(PLE007,0) HAVING PAS016>ISNULL(PLE007,0) ORDER BY PAS001,PAS002" ,idxStr );

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
        /// 生成组装日计划覆盖
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns>1:无此单号  2:选择产品不允许重复生成  3:生成成功  4:生成失败</returns>
        public int Esit_J_Day ( CarpenterEntity . PlanAssembleDayPLDEntity _model ,List<string> strList ,bool planScheduling )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLD001 FROM MOXPLD " );
            strSql . AppendFormat ( "WHERE PLD002='{0}' AND PLD003='{1}'" ,_model . PLD002 ,_model . PLD003 );

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PLD001" ] . ToString ( ) ) )
                    _model . PLD001 = string . Empty;
                else
                    _model . PLD001 = da . Rows [ 0 ] [ "PLD001" ] . ToString ( );
            }
            else
                _model . PLD001 = string . Empty;

            if ( _model . PLD001 == string . Empty )
                return 1;

            strSql = new StringBuilder ( );
            _model . PLD005 = false;
            _model . PLD006 = false;
            _model . PLD007 = UserInformation . dt ( );

            strSql . Append ( "UPDATE MOXPLD SET " );
            strSql . Append ( "PLD002=@PLD002," );
            strSql . Append ( "PLD003=@PLD003," );
            strSql . Append ( "PLD004=@PLD004," );
            strSql . Append ( "PLD005=@PLD005," );
            strSql . Append ( "PLD006=@PLD006," );
            strSql . Append ( "PLD007=@PLD007," );
            strSql . Append ( "PLD008=@PLD008," );
            strSql . Append ( "PLD009=@PLD009," );
            strSql . Append ( "PLD010=@PLD010 " );
            strSql . Append ( "WHERE PLD001=@PLD001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLD001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLD002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLD003",SqlDbType.Date),
                new SqlParameter("@PLD004",SqlDbType.Date),
                new SqlParameter("@PLD005",SqlDbType.Bit),
                new SqlParameter("@PLD006",SqlDbType.Bit),
                new SqlParameter("@PLD007",SqlDbType.Date),
                new SqlParameter("@PLD008",SqlDbType.NVarChar,20),
                new SqlParameter("@PLD009",SqlDbType.Decimal,10),
                new SqlParameter("@PLD010",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . PLD001;
            parameter [ 1 ] . Value = _model . PLD002;
            parameter [ 2 ] . Value = _model . PLD003;
            parameter [ 3 ] . Value = _model . PLD004;
            parameter [ 4 ] . Value = _model . PLD005;
            parameter [ 5 ] . Value = _model . PLD006;
            parameter [ 6 ] . Value = _model . PLD007;
            parameter [ 7 ] . Value = _model . PLD008;
            parameter [ 8 ] . Value = _model . PLD009;
            parameter [ 9 ] . Value = _model . PLD010;
            SQLString . Add ( strSql ,parameter );

            CarpenterEntity . PlanAssembleDayPLEEntity _modelPLX = new CarpenterEntity . PlanAssembleDayPLEEntity ( );

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
            da = GetDataTablePLE ( _model . PLD001 );

            dt = getTableOfLeaveOver ( _model . PLD001 );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPLX . PLE001 = _model . PLD001;
                _modelPLX . PLE009 = _model . PLD007;
                _modelPLX . PLE010 = _model . PLD008;
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelPLX . PLE002 = "完工";
                    _modelPLX . PLE003 = dt . Rows [ i ] [ "PLE003" ] . ToString ( );
                    _modelPLX . PLE004 = dt . Rows [ i ] [ "PLE004" ] . ToString ( );
                    _modelPLX . PLE005 = dt . Rows [ i ] [ "PLE005" ] . ToString ( );
                    _modelPLX . PLE006 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PLE006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PLE006" ] . ToString ( ) );
                    _modelPLX . PLE007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PLE007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PLE007" ] . ToString ( ) );
                    _modelPLX . PLE008 = dt . Rows [ i ] [ "PLE008" ] . ToString ( );
                    _modelPLX . PLE011 = false;
                    _modelPLX . PLE012 = false;
                    _modelPLX . PLE013 = dt . Rows [ i ] [ "PLE001" ] . ToString ( );
                    if ( da . Select ( "PLE003='" + _modelPLX . PLE003 + "' AND PLE004='" + _modelPLX . PLE004 + "' AND PLE013='" + _modelPLX . PLE013 + "'" ) . Length < 1 )
                    {
                        if ( _modelPLX . PLE007 != 0 )
                            add_bl_day ( _modelPLX ,strSql ,SQLString );
                    }
                    else
                        edit_bl_day ( _modelPLX ,strSql ,SQLString );
                }
            }

            if ( planScheduling == true )
                dt = GetDataTableBLPlan ( idxList ,_model . PLD002 ,_model . PLD003 );
            else
                dt = GetDataTableBL ( idxList ,_model . PLD001 );
            
            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPLX . PLE001 = _model . PLD001;
                _modelPLX . PLE009 = _model . PLD007;
                _modelPLX . PLE010 = _model . PLD008;
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelPLX . PLE002 = "完工";
                    _modelPLX . PLE003 = dt . Rows [ i ] [ "PAS001" ] . ToString ( );
                    _modelPLX . PLE004 = dt . Rows [ i ] [ "PAS002" ] . ToString ( );
                    _modelPLX . PLE005 = dt . Rows [ i ] [ "PAS003" ] . ToString ( );
                    _modelPLX . PLE006 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PAS016" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PAS016" ] . ToString ( ) );
                    _modelPLX . PLE007 = _modelPLX . PLE006;
                    _modelPLX . PLE008 = dt . Rows [ i ] [ "PAS013" ] . ToString ( );
                    _modelPLX . PLE011 = false;
                    _modelPLX . PLE012 = planScheduling;
                    _modelPLX . PLE013 = string . Empty;

                    if ( da . Select ( "PLE002='" + _modelPLX . PLE002 + "' AND PLE003='" + _modelPLX . PLE003 + "' AND PLE004='" + _modelPLX . PLE004 + "' AND PLE013='" + _modelPLX . PLE013 + "'" ) . Length < 1 )
                    {
                        if ( _modelPLX . PLE012 == false )
                        {
                            if ( ExistsNum ( _modelPLX ) )
                            {
                                //计划数量=计划数量-预排报工数量
                                _modelPLX . PLE007 = _modelPLX . PLE007 - getPlanNum ( _modelPLX ,_model . PLD002 );
                            }
                        }
                        if ( _modelPLX . PLE007 != 0 )
                            add_bl_day ( _modelPLX ,strSql ,SQLString );
                    }
                    else
                        edit_bl_day ( _modelPLX ,strSql ,SQLString );

                    //编辑日计划计划完成日期
                    if ( planScheduling == false )
                    {
                        //if ( Exists_bl_date ( _modelPLX ,_model . PLD003 ,_model . PLD002 ) == true )
                        edit_bl_date ( _modelPLX ,_model . PLD004 ,strSql ,SQLString );
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
        
        /// <summary>
        /// 生成组装日计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Add_J_Day ( CarpenterEntity . PlanAssembleDayPLDEntity _model ,List<string> strList ,bool planScheduling )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _model . PLD001 = GetBLOddNumDay ( strSql );

            DataTable da = completionRate ( );
            if ( da != null && da . Rows . Count > 0 )
            {
                _model . PLD009 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "CO" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "CO" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PLD003" ] . ToString ( ) ) )
                    _model . PLD010 = UserInformation . dt ( );
                else
                    _model . PLD010 = Convert . ToDateTime ( da . Rows [ 0 ] [ "PLD003" ] . ToString ( ) );
            }
            strSql = new StringBuilder ( );
            _model . PLD005 = false;
            _model . PLD006 = false;
            _model . PLD007 = UserInformation . dt ( );
            strSql . Append ( "INSERT INTO MOXPLD (" );
            strSql . Append ( "PLD001,PLD002,PLD003,PLD004,PLD005,PLD006,PLD007,PLD008,PLD009,PLD010) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PLD001,@PLD002,@PLD003,@PLD004,@PLD005,@PLD006,@PLD007,@PLD008,@PLD009,@PLD010) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLD001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLD002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLD003",SqlDbType.Date),
                new SqlParameter("@PLD004",SqlDbType.Date),
                new SqlParameter("@PLD005",SqlDbType.Bit),
                new SqlParameter("@PLD006",SqlDbType.Bit),
                new SqlParameter("@PLD007",SqlDbType.Date),
                new SqlParameter("@PLD008",SqlDbType.NVarChar,20),
                new SqlParameter("@PLD009",SqlDbType.Decimal,10),
                new SqlParameter("@PLD010",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . PLD001;
            parameter [ 1 ] . Value = _model . PLD002;
            parameter [ 2 ] . Value = _model . PLD003;
            parameter [ 3 ] . Value = _model . PLD004;
            parameter [ 4 ] . Value = _model . PLD005;
            parameter [ 5 ] . Value = _model . PLD006;
            parameter [ 6 ] . Value = _model . PLD007;
            parameter [ 7 ] . Value = _model . PLD008;
            parameter [ 8 ] . Value = _model . PLD009;
            parameter [ 9 ] . Value = _model . PLD010;
            SQLString . Add ( strSql ,parameter );

            CarpenterEntity . PlanAssembleDayPLEEntity _modelPLX = new CarpenterEntity . PlanAssembleDayPLEEntity ( );

            string idxList = "";
            foreach ( string str in strList )
            {
                if ( idxList == "" )
                    idxList = "'" + str + "'";
                else
                    idxList += "," + "'" + str + "'";
            }

            da = getTableOfLeaveOver ( _model . PLD001 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPLX . PLE001 = _model . PLD001;
                _modelPLX . PLE009 = _model . PLD007;
                _modelPLX . PLE010 = _model . PLD008;
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPLX . PLE002 = "完工";
                    _modelPLX . PLE003 = da . Rows [ i ] [ "PLE003" ] . ToString ( );
                    _modelPLX . PLE004 = da . Rows [ i ] [ "PLE004" ] . ToString ( );
                    _modelPLX . PLE005 = da . Rows [ i ] [ "PLE005" ] . ToString ( );
                    _modelPLX . PLE006 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PLE007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PLE007" ] . ToString ( ) );
                    _modelPLX . PLE007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PLE007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PLE007" ] . ToString ( ) );
                    _modelPLX . PLE008 = da . Rows [ i ] [ "PLE008" ] . ToString ( );
                    _modelPLX . PLE011 = false;
                    _modelPLX . PLE012 = false;
                    _modelPLX . PLE013 = da . Rows [ i ] [ "PLE001" ] . ToString ( );

                    if ( _modelPLX . PLE007 != 0 )
                        add_bl_day ( _modelPLX ,strSql ,SQLString );
                }
            }

            if ( planScheduling )
                da = GetDataTableBLPlan ( idxList ,_model . PLD002 ,_model . PLD003 );
            else
                da = GetDataTableBL_Add ( idxList ,_model . PLD002 );

            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPLX . PLE001 = _model . PLD001;
                _modelPLX . PLE009 = _model . PLD007;
                _modelPLX . PLE010 = _model . PLD008;
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPLX . PLE002 = "完工";
                    _modelPLX . PLE003 = da . Rows [ i ] [ "PAS001" ] . ToString ( );
                    _modelPLX . PLE004 = da . Rows [ i ] [ "PAS002" ] . ToString ( );
                    _modelPLX . PLE005 = da . Rows [ i ] [ "PAS003" ] . ToString ( );
                    _modelPLX . PLE006 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PAS016" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PAS016" ] . ToString ( ) );
                    _modelPLX . PLE007 = _modelPLX . PLE006;
                    _modelPLX . PLE008 = da . Rows [ i ] [ "PAS013" ] . ToString ( );
                    _modelPLX . PLE011 = false;
                    _modelPLX . PLE012 = planScheduling;
                    _modelPLX . PLE013 = string . Empty;

                    if ( _modelPLX . PLE012 == false )
                    {
                        if ( ExistsNum ( _modelPLX ) )
                        {
                            //计划数量=计划数量-预排报工数量
                            _modelPLX . PLE007 = _modelPLX . PLE007 - getPlanNum ( _modelPLX ,_model . PLD002 );
                        }
                    }
                    if ( _modelPLX . PLE007 != 0 )
                        add_bl_day ( _modelPLX ,strSql ,SQLString );

                    //回写日计划计划完成时间
                    if ( planScheduling == false )
                    {
                        //if ( Exists_bl_date ( _modelPLX ,_model . PLD003 ,_model . PLD002 ) == true )
                        edit_bl_date ( _modelPLX ,_model . PLD004  ,strSql ,SQLString );
                    }
                }
            }
            else
                return false;

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取组装日计划遗留
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="workShop"></param>
        /// <returns></returns>
        DataTable getTableOfLeaveOver ( string oddNum  )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "WITH CET AS (" );
            //strSql . Append ( "SELECT PLE001,PLE003,PLE004,PLE005,PLE006,PLE007,PLE008 FROM MOXPLD A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001 INNER JOIN MOXPLF C ON B.PLE003=C.PLF002 AND B.PLE004=C.PLF003 AND B.PLE001!=C.PLF010 " );
            //strSql . AppendFormat ( "WHERE PLD001=(SELECT MAX(PLD001) FROM MOXPLD WHERE PLD001<'{0}') " ,oddNum );
            //strSql . Append ( " AND PLE012=0 AND PLD002='组装' " );
            //strSql . Append ( "),CFT AS ( " );
            //strSql . Append ( "SELECT PLE001,PLE003,PLE004,PLE005,PLE006,PLE007-SUM(ISNULL(PLF007,0)) PLE007,PLE008 FROM  MOXPLD A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001 INNER JOIN MOXPLF C ON B.PLE003=C.PLF002 AND B.PLE004=C.PLF003 AND B.PLE001=C.PLF010 " );
            //strSql . AppendFormat ( "WHERE PLD001=(SELECT MAX(PLD001) FROM MOXPLD WHERE PLD001<'{0}') AND PLE012=0 " ,oddNum );
            //strSql . Append ( "AND PLD002='组装' " );
            //strSql . Append ( "GROUP BY PLE001,PLE003,PLE004,PLE005,PLE006,PLE008,PLE007 HAVING SUM(ISNULL(PLF007,0))<PLE007) " );
            //strSql . Append ( "SELECT * FROM CET UNION  SELECT * FROM CFT" );
            
            strSql . Append ( "SELECT PLE001,PLE003,PLE004,PLE005,PLE007-SUM(ISNULL(PLF007,0)) PLE007,PLE008 FROM  (SELECT MAX(PLD001) PLD001,PLD002 FROM MOXPLD GROUP BY PLD002) A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001 LEFT JOIN MOXPLF C ON B.PLE003=C.PLF002 AND B.PLE004=C.PLF003 AND B.PLE001=C.PLF010 " );
            strSql . AppendFormat ( "WHERE PLD001=(SELECT MAX(PLD001) FROM MOXPLD WHERE PLD001<'{0}') AND PLE012=0 " ,oddNum );
            strSql . Append ( "AND PLD002='组装' " );
            strSql . Append ( "GROUP BY PLE001,PLE003,PLE004,PLE005,PLE007,PLE008 HAVING PLE007>SUM(ISNULL(PLF007,0))" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取组装日计划单号
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        string GetBLOddNumDay ( StringBuilder strSql )
        {
            strSql . Append ( "SELECT MAX(PLD001) PLD001 FROM MOXPLD" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PLD001" ] . ToString ( ) ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PLD001" ] . ToString ( ) . Substring ( 0 ,8 ) == UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PLD001" ] . ToString ( ) ) + 1 ) . ToString ( );
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
            strSql . Append ( "WITH CET AS(SELECT CASE WHEN PLE007=0 THEN 0 ELSE SUM(ISNULL(PLF007,0))*1.0/PLE007 END PLE007,PLD003,PLE003,PLE004 FROM MOXPLD A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001 LEFT JOIN MOXPLF C ON B.PLE003=C.PLF002 AND B.PLE004=C.PLF003 WHERE A.idx=(SELECT MAX(idx) FROM MOXPLD) AND B.PLE012=0 GROUP BY PLE007,PLD003,PLE003,PLE004)," );
            strSql . Append ( "CFT AS (SELECT COUNT(1) COUN,PLE003,PLE004 FROM MOXPLD A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001 WHERE A.idx=(SELECT MAX(idx) FROM MOXPLD) AND B.PLE012=0 GROUP BY PLE003,PLE004)" );
            strSql . Append ( "SELECT CONVERT(DECIMAL(11,2),SUM(PLE007)/SUM(COUN)*100) CO,A.PLD003 FROM CET A INNER JOIN CFT B ON A.PLE003=B.PLE003 AND A.PLE004=B.PLE004 GROUP BY PLD003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取组装单据 预排
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableBLPlan ( string strWhere ,string workShop ,DateTime dt )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS013,PAS016 FROM MOXPAS " );
            //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN MOXPLE B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 INNER JOIN MOXPLD C ON B.PLE001=C.PLD001 WHERE A.idx IN (" + strWhere + ") AND PLD002='" + workShop + "') AND idx IN (" + strWhere + ")" );

            //同批号和品号可以排多次预排
            strSql . AppendFormat ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS013,PAS016-SUM(ISNULL(PLF007,0)) PAS016 FROM MOXPAS A LEFT JOIN MOXPLF C ON A.PAS001=C.PLF002 AND A.PAS002=C.PLF003 WHERE A.idx IN ({0}) AND PAS001+PAS002 NOT IN (SELECT A.PLE003+A.PLE004 FROM MOXPLE A INNER JOIN MOXPLD D ON A.PLE001=D.PLD001 INNER JOIN MOXPAS C ON A.PLE003=C.PAS001 AND A.PLE004=C.PAS002 WHERE D.PLD002='{1}' AND PLD003='{2}') GROUP BY PAS001,PAS002,PAS003,PAS004,PAS013,PAS016 HAVING PAS016>SUM(ISNULL(PLF007,0)) " ,strWhere ,workShop ,dt );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取组装单据 非预排
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableBL ( string strWhere ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS013,PAS016 FROM MOXPAS WHERE idx IN (" + strWhere + ") AND idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN MOXPLE B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 WHERE A.idx IN (" + strWhere + ") AND B.idx IN (SELECT idx FROM MOXPLE WHERE (PLE001='" + oddNum + "' AND PLE012=1) OR (PLE012=0 AND PLE002='完工')))" );
            //strSql . Append ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS013,PAS016-SUM(ISNULL(PLE007,0)) PAS016 FROM MOXPAS A LEFT JOIN MOXPLE B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 " );
            //strSql . AppendFormat ( "WHERE A.idx IN ({0}) " ,strWhere );
            //strSql . Append ( "GROUP BY PAS001,PAS002,PAS003,PAS004,PAS013,PAS016 HAVING PAS016>SUM(ISNULL(PLE007,0))" );

            strSql . AppendFormat ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS013,PAS016-ISNULL(PLE007,0) PAS016 FROM MOXPAS A LEFT JOIN (SELECT SUM(ISNULL(PLE007,0)) PLE007,PLE003,PLE004 FROM MOXPLE WHERE PLE001 IN (SELECT MAX(PLE001) FROM MOXPLE A LEFT JOIN MOXPAS B ON A.PLE003=B.PAS001 AND A.PLE004=B.PAS002 WHERE PLE002='完工' AND B.idx IN ({0}) GROUP BY PLE001 ) GROUP BY PLE003,PLE004) B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 WHERE A.idx in ({0}) AND A.idx NOT IN (SELECT A.idx FROM MOXPAS A LEFT JOIN MOXPLE B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 WHERE B.PLE002='完工' AND B.PLE013='' AND PLE001='{1}' AND A.idx IN ({0})) GROUP BY PAS001,PAS002,PAS003,PAS004,PAS013,PAS016,PLE007 HAVING PAS016>ISNULL(PLE007,0) ORDER BY PAS001,PAS002" ,strWhere ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取组装单据  正排  增加
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public DataTable GetDataTableBL_Add ( string strWhere ,string workShop )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS013,PAS016 FROM MOXPAS WHERE idx in ({0}) AND idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN (SELECT PLE003,PLE004,PLE002 FROM (SELECT PLE001,PLE003,PLE004,PLE002 FROM MOXPLE WHERE PLE001 IN (SELECT MAX(PLE001) FROM MOXPLE WHERE PLE012=0 GROUP BY PLE003,PLE004)) A INNER JOIN MOXPLD B ON A.PLE001=B.PLD001 WHERE PLE002='完工' AND PLD002='{1}') B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 WHERE A.idx in ({0})) ORDER BY PAS001,PAS002" ,strWhere ,workShop );

            //2017-12-13注销
            //strSql . AppendFormat ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS013,PAS016-ISNULL(PLE007,0) PAS016 FROM MOXPAS A LEFT JOIN (SELECT SUM(ISNULL(PLE007,0)) PLE007,PLE003,PLE004 FROM MOXPLE WHERE PLE001=(SELECT MAX(PLE001) FROM MOXPLE A LEFT JOIN MOXPAS B ON A.PLE003=B.PAS001 AND A.PLE004=B.PAS002 WHERE B.idx IN ({0})) GROUP BY PLE003,PLE004) B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 WHERE A.idx in ({0}) AND A.idx NOT IN (SELECT A.idx FROM MOXPAS A INNER JOIN (SELECT PLE003,PLE004,PLE002,PLE007 FROM (SELECT PLE001,PLE003,PLE004,PLE002,PLE007 FROM MOXPLE WHERE PLE001 IN (SELECT MAX(PLE001) FROM MOXPLE WHERE PLE012=0 GROUP BY PLE003,PLE004)) A INNER JOIN MOXPLD B ON A.PLE001=B.PLD001 WHERE PLE002='完工' AND PLD002='{1}') B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 WHERE A.idx in ({0}) GROUP BY PAS016,idx HAVING PAS016<=SUM(ISNULL(PLE007,0)))  ORDER BY PAS001,PAS002" ,strWhere ,workShop );
            
            //2017-12-13生成
            strSql . AppendFormat ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS013,PAS016-ISNULL(PLE007,0) PAS016 FROM MOXPAS A LEFT JOIN (SELECT SUM(ISNULL(PLE007,0)) PLE007,PLE003,PLE004 FROM MOXPLE WHERE PLE001 IN (SELECT PLE001 FROM MOXPLE A LEFT JOIN MOXPAS B ON A.PLE003=B.PAS001 AND A.PLE004=B.PAS002 WHERE PLE002='完工' AND B.idx IN ({0})) GROUP BY PLE003,PLE004) B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 WHERE A.idx in ({0}) GROUP BY PAS001,PAS002,PAS003,PAS004,PAS013,PAS016,ISNULL(PLE007,0) HAVING PAS016>ISNULL(PLE007,0) ORDER BY PAS001,PAS002" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取相同单号的日计划
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePLE ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLE002,PLE003,PLE004,PLE013 FROM MOXPLE " );
            strSql . AppendFormat ( "WHERE PLE001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否预排过
        /// </summary>
        /// <returns></returns>
        bool ExistsNum ( CarpenterEntity . PlanAssembleDayPLEEntity _modelPLT )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPLE WHERE PLE003='{0}' AND PLE004='{1}' AND PLE012=1" ,_modelPLT . PLE003 ,_modelPLT . PLE004 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取预排报工数量
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <returns></returns>
        int getPlanNum ( CarpenterEntity . PlanAssembleDayPLEEntity _modelPLT ,string workShop )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT SUM(PLF007) PLF007 FROM MOXPLE A INNER JOIN MOXPLF B ON A.PLE003=B.PLF002 AND A.PLE004=B.PLF003 WHERE PLF015=1 AND PLE003='{0}' AND PLE004='{1}'" ,_modelPLT . PLE003 ,_modelPLT . PLE004  );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PLF007" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToInt32 ( dt . Rows [ 0 ] [ "PLF007" ] . ToString ( ) );
            }
            else
                return 0;
        }

        void add_bl_day ( CarpenterEntity . PlanAssembleDayPLEEntity _modelPLX ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPLE (" );
            strSql . Append ( "PLE001,PLE002,PLE003,PLE004,PLE005,PLE006,PLE007,PLE008,PLE009,PLE010,PLE011,PLE012,PLE013) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PLE001,@PLE002,@PLE003,@PLE004,@PLE005,@PLE006,@PLE007,@PLE008,@PLE009,@PLE010,@PLE011,@PLE012,@PLE013) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLE001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLE002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLE003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLE004",SqlDbType.NVarChar,20),
                new SqlParameter("@PLE005",SqlDbType.NVarChar,20),
                new SqlParameter("@PLE006",SqlDbType.Int),
                new SqlParameter("@PLE007",SqlDbType.Int),
                new SqlParameter("@PLE008",SqlDbType.NVarChar,200),
                new SqlParameter("@PLE009",SqlDbType.Date),
                new SqlParameter("@PLE010",SqlDbType.NVarChar,20),
                new SqlParameter("@PLE011",SqlDbType.Bit),
                new SqlParameter("@PLE012",SqlDbType.Bit),
                new SqlParameter("@PLE013",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelPLX . PLE001;
            parameter [ 1 ] . Value = _modelPLX . PLE002;
            parameter [ 2 ] . Value = _modelPLX . PLE003;
            parameter [ 3 ] . Value = _modelPLX . PLE004;
            parameter [ 4 ] . Value = _modelPLX . PLE005;
            parameter [ 5 ] . Value = _modelPLX . PLE006;
            parameter [ 6 ] . Value = _modelPLX . PLE007;
            parameter [ 7 ] . Value = _modelPLX . PLE008;
            parameter [ 8 ] . Value = _modelPLX . PLE009;
            parameter [ 9 ] . Value = _modelPLX . PLE010;
            parameter [ 10 ] . Value = _modelPLX . PLE011;
            parameter [ 11 ] . Value = _modelPLX . PLE012;
            parameter [ 12 ] . Value = _modelPLX . PLE013;

            SQLString . Add ( strSql ,parameter );
        }

        void edit_bl_day ( CarpenterEntity . PlanAssembleDayPLEEntity _modelPLX ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPLE SET " );
            strSql . Append ( "PLE005=@PLE005," );
            strSql . Append ( "PLE006=@PLE006," );
            strSql . Append ( "PLE007=@PLE007," );
            strSql . Append ( "PLE008=@PLE008," );
            strSql . Append ( "PLE009=@PLE009," );
            strSql . Append ( "PLE010=@PLE010," );
            strSql . Append ( "PLE012=@PLE012 " );
            strSql . Append ( "WHERE PLE001=@PLE001 AND " );
            //strSql . Append ( "PLE002=PLE002 AND " );
            strSql . Append ( "PLE003=@PLE003 AND " );
            strSql . Append ( "PLE004=@PLE004 AND " );
            strSql . Append ( "PLE013=@PLE013 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLE001",SqlDbType.NVarChar,20),
                //new SqlParameter("PLE002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLE003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLE004",SqlDbType.NVarChar,20),
                new SqlParameter("@PLE005",SqlDbType.NVarChar,20),
                new SqlParameter("@PLE006",SqlDbType.Int),
                new SqlParameter("@PLE007",SqlDbType.Int),
                new SqlParameter("@PLE008",SqlDbType.NVarChar,200),
                new SqlParameter("@PLE009",SqlDbType.Date),
                new SqlParameter("@PLE010",SqlDbType.NVarChar,20),
                new SqlParameter("@PLE012",SqlDbType.Bit),
                new SqlParameter("@PLE013",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelPLX . PLE001;
            //parameter [ 1 ] . Value = _modelPLX . PLE002;
            parameter [ 1 ] . Value = _modelPLX . PLE003;
            parameter [ 2 ] . Value = _modelPLX . PLE004;
            parameter [ 3 ] . Value = _modelPLX . PLE005;
            parameter [ 4 ] . Value = _modelPLX . PLE006;
            parameter [ 5 ] . Value = _modelPLX . PLE007;
            parameter [ 6 ] . Value = _modelPLX . PLE008;
            parameter [ 7 ] . Value = _modelPLX . PLE009;
            parameter [ 8 ] . Value = _modelPLX . PLE010;
            parameter [ 9 ] . Value = _modelPLX . PLE012;
            parameter [ 10 ] . Value = _modelPLX . PLE013;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 看计划完成时间是否有
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        bool Exists_bl_date ( CarpenterEntity . PlanAssembleDayPLEEntity _modelPLX ,DateTime dtOne ,string gongDaun )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PAS012 PST FROM MOXPAS " );
            strSql . Append ( "WHERE PAS001=@PAS001 AND PAS002=@PAS002 " );

            SqlParameter [ ] parameter = {
                new SqlParameter("@PAS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PAS002",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelPLX . PLE003;
            parameter [ 1 ] . Value = _modelPLX . PLE004;

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
        /// 编辑日计划计划完成日期
        /// </summary>
        /// <param name="_modelPLX"></param>
        /// <param name="planTime"></param>
        /// <param name="BLgd"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_bl_date ( CarpenterEntity . PlanAssembleDayPLEEntity _modelPLX ,DateTime planTime ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXPAS SET PAS005='{0}' WHERE PAS001='{1}' AND PAS002='{2}'" ,planTime ,_modelPLX . PLE003 ,_modelPLX . PLE004 );
            SQLString . Add ( strSql ,null );
        }

    }
}
