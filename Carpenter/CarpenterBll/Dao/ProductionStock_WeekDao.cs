using System;
using System . Collections . Generic;
using System . Text;
using StudentMgr;
using System . Data;
using System . Collections;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class ProductionStock_WeekDao
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
            strSql . Append ( "SELECT COUNT(1) FROM MOXPLS " );
            strSql . AppendFormat ( "WHERE PLS002='{0}' AND PLS001 LIKE '{1}%'" ,weekEnds ,GetDate ( ) . ToString ( "yyyy" ) );

            if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
            {
                x = 1;

                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPLS " );
                strSql . AppendFormat ( "WHERE PLS002='{0}' AND PLS001 LIKE '{1}%' AND PLS008=1" ,weekEnds ,GetDate ( ) . ToString ( "yyyy" ) );

                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return 2;

                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT COUNT(1) FROM MOXPLS " );
                strSql . AppendFormat ( "WHERE PLS002='{0}' AND PLS001 LIKE '{1}%' AND PLS009=1" ,weekEnds ,GetDate ( ) . ToString ( "yyyy" ) );

                if ( SqlHelper . Exists ( strSql . ToString ( ) ) == true )
                    return 3;

                strSql = new StringBuilder ( );
                if ( planCheck )
                {
                    //预排一次就不可再次预排
                    //strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST " );
                    //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPLT B ON A.PST001=B.PLT003 AND A.PST002=B.PLT004 WHERE A.idx IN (" + idxList + ")) AND idx IN (" + idxList + ")" );

                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPST A LEFT JOIN (SELECT SUM(ISNULL(PDK007,0)) PDK007,PLT003,PLT004 FROM MOXPLT B LEFT JOIN MOXPDK C ON B.PLT003=C.PDK002 AND B.PLT004=C.PDK003 AND B.PLT001=C.PDK009 LEFT JOIN MOXPST D ON B.PLT003=D.PST001 AND B.PLT004=D.PST002 WHERE PLT013=1 AND D.idx IN ({0}) GROUP BY PLT003,PLT004) B ON A.PST001=B.PLT003 AND A.PST002=B.PLT004 WHERE A.idx IN ({0}) GROUP BY PST028,ISNULL(PDK007,0) HAVING PST028>ISNULL(PDK007,0)" ,idxList );

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4;
                    else
                        x = 1;
                }
                else
                {
                    strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST " );
                    strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPLT B ON A.PST001=B.PLT003 AND A.PST002=B.PLT004 INNER JOIN MOXPLS C ON B.PLT001=C.PLS001 WHERE A.idx IN (" + idxList + ")  AND PLS002='" + weekEnds + "' AND PLS001 LIKE '" + UserInformation . dt
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
                    strSql . Append ( "SELECT COUNT(1) FROM MOXPST A WHERE A.idx NOT IN ( " );
                    strSql . AppendFormat ( "SELECT D.idx FROM MOXPLT B INNER JOIN MOXPST D ON B.PLT003=D.PST001 AND B.PLT004=D.PST002 WHERE  D.idx IN ({0})) AND A.idx IN ({0})" ,idxList );//PLT013=0 AND

                    //strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPST A LEFT JOIN (SELECT SUM(ISNULL(PDK007,0)) PDK007,PLT003,PLT004 FROM MOXPLT B LEFT JOIN MOXPDK C ON B.PLT003=C.PDK002 AND B.PLT004=C.PDK003 AND B.PLT001=C.PDK009 LEFT JOIN MOXPST D ON B.PLT003=D.PST001 AND B.PLT004=D.PST002 WHERE PLT013=1 AND D.idx IN ({0}) GROUP BY PLT003,PLT004) B ON A.PST001=B.PLT003 AND A.PST002=B.PLT004 WHERE A.idx IN ({0}) GROUP BY PST028,ISNULL(PDK007,0) HAVING PST028>ISNULL(PDK007,0)" ,idxList );

                    x = SqlHelper . returnSumCount ( strSql . ToString ( ) );
                    if ( x == 0 )
                        x = 4;
                    else
                        x = 5;
                }
                else
                {
                    //strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST " );
                    //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPLT B ON A.PST001=B.PLT003 AND A.PST002=B.PLT004 WHERE A.idx IN (" + idxList + ") AND PLT013=0) AND idx IN (" + idxList + ")" );

                    strSql . AppendFormat ( "WITH CET AS (SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPLT B ON A.PST001=B.PLT003 AND A.PST002=B.PLT004 WHERE A.idx IN ({0}) AND PLT013=0) AND idx IN ({0}))" ,idxList );
                    strSql . AppendFormat ( " SELECT PST001,PST002,PST003,PST004,PST025,PST028-ISNULL(PDK007,0) PST028 FROM CET A LEFT JOIN (SELECT PLT003,PLT004,SUM(ISNULL(PDK007,0)) PDK007 FROM MOXPST C INNER JOIN MOXPLT A ON C.PST001=A.PLT003 AND C.PST002=A.PLT004 INNER JOIN MOXPDK B ON A.PLT001=B.PDK009 AND A.PLT003=B.PDK002 AND A.PLT004=B.PDK003  WHERE PLT013=1 AND C.idx IN ({0}) GROUP BY PLT003,PLT004) B ON A.PST001=B.PLT003 AND A.PST002=B.PLT004 GROUP BY PST001,PST002,PST003,PST004,PST025,PST028,ISNULL(PDK007,0) HAVING PST028>ISNULL(PDK007,0)" ,idxList );

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
        /// 生成备料周计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Add_BL ( CarpenterEntity . PlanStockPLSEntity _model ,List<string> strList ,string name ,bool planCheck )
        {
            Hashtable SQLString = new Hashtable ( );

            StringBuilder strSql = new StringBuilder ( );
            _model . PLS001 = GetBLOddNum ( strSql );

            strSql = new StringBuilder ( );
            _model . PLS007 = name;
            _model . PLS006 = GetDate ( );
            _model . PLS008 = false;
            _model . PLS009 = false;
            strSql . Append ( "INSERT INTO MOXPLS (" );
            strSql . Append ( "PLS001,PLS002,PLS003,PLS004,PLS005,PLS006,PLS007,PLS008,PLS009) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PLS001,@PLS002,@PLS003,@PLS004,@PLS005,@PLS006,@PLS007,@PLS008,@PLS009) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLS003",SqlDbType.Date),
                new SqlParameter("@PLS004",SqlDbType.Date),
                new SqlParameter("@PLS005",SqlDbType.Date),
                new SqlParameter("@PLS006",SqlDbType.Date),
                new SqlParameter("@PLS007",SqlDbType.NVarChar,20),
                new SqlParameter("@PLS008",SqlDbType.Bit),
                new SqlParameter("@PLS009",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _model . PLS001;
            parameter [ 1 ] . Value = _model . PLS002;
            parameter [ 2 ] . Value = _model . PLS003;
            parameter [ 3 ] . Value = _model . PLS004;
            parameter [ 4 ] . Value = _model . PLS005;
            parameter [ 5 ] . Value = _model . PLS006;
            parameter [ 6 ] . Value = _model . PLS007;
            parameter [ 7 ] . Value = _model . PLS008;
            parameter [ 8 ] . Value = _model . PLS009;
            SQLString . Add ( strSql ,parameter );

            name = "";
            foreach ( string str in strList )
            {
                if ( name == "" )
                    name = "'" + str + "'";
                else
                    name += "," + "'" + str + "'";
            }

            CarpenterEntity . PlanStockPLTEntity _modelPLT = new CarpenterEntity . PlanStockPLTEntity ( );
            DataTable dt;
            if ( planCheck )
                dt = GetDataTableBLPlane_Add ( name );
            else
                dt = GetDataTableBL_Add ( name );

            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPLT . PLT001 = _model . PLS001;
                _modelPLT . PLT009 = _model . PLS006;
                _modelPLT . PLT010 = _model . PLS007;

                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelPLT . PLT002 = string . Empty;
                    _modelPLT . PLT003 = dt . Rows [ i ] [ "PST001" ] . ToString ( );
                    _modelPLT . PLT004 = dt . Rows [ i ] [ "PST002" ] . ToString ( );
                    _modelPLT . PLT005 = dt . Rows [ i ] [ "PST003" ] . ToString ( );
                    _modelPLT . PLT006 = dt . Rows [ i ] [ "PST004" ] . ToString ( );
                    _modelPLT . PLT007 = _model . PLS004;
                    _modelPLT . PLT008 = dt . Rows [ i ] [ "PST025" ] . ToString ( );
                    _modelPLT . PLT011 = false;
                    _modelPLT . PLT012 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PST028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PST028" ] . ToString ( ) );
                    _modelPLT . PLT013 = planCheck;

                    //if ( _modelPLT . PLT013 == false )
                    //{
                    //    name = ExistsNum ( _modelPLT );
                    //    if ( name != string . Empty )
                    //        //订单量=订单量-预排报工数量
                    //        _modelPLT . PLT012 = _modelPLT . PLT012 - getPlanNum ( _modelPLT ,name );
                    //}

                    add_bl ( _modelPLT ,strSql ,SQLString );

                    if ( _modelPLT . PLT013 == false && Exists_edit_bl ( _modelPLT . PLT003 ,_modelPLT . PLT004 ) == true )
                        edit_bl ( _modelPLT ,strSql ,SQLString ,_model . PLS002 );

                    edit_pas ( _modelPLT ,SQLString );

                    if ( _modelPLT . PLT013 == false && Exists_edit_Prs ( _modelPLT . PLT003 ,_modelPLT . PLT004 ) == true )
                        edit_Prs ( _modelPLT ,strSql ,SQLString );
                }
            }

            dt = GetDataTableBLP ( _model . PLS001 );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                _modelPLT . PLT001 = _model . PLS001;
                _modelPLT . PLT009 = _model . PLS006;
                _modelPLT . PLT010 = _model . PLS007;
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelPLT . PLT002 = dt . Rows [ i ] [ "PLT001" ] . ToString ( );
                    _modelPLT . PLT003 = dt . Rows [ i ] [ "PLT003" ] . ToString ( );
                    _modelPLT . PLT004 = dt . Rows [ i ] [ "PLT004" ] . ToString ( );
                    _modelPLT . PLT005 = dt . Rows [ i ] [ "PLT005" ] . ToString ( );
                    _modelPLT . PLT006 = dt . Rows [ i ] [ "PLT006" ] . ToString ( );
                    _modelPLT . PLT012 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PLT012" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PLT012" ] . ToString ( ) );

                    //订单量=订单量-报工数量
                    //_modelPLT . PLT012 = _modelPLT . PLT012 - getPlanNum ( _modelPLT ,_modelPLT . PLT002 );

                    if ( string . IsNullOrEmpty ( dt . Rows [ i ] [ "PLT007" ] . ToString ( ) ) )
                        _modelPLT . PLT007 = null;
                    else
                        _modelPLT . PLT007 = Convert . ToDateTime ( dt . Rows [ i ] [ "PLT007" ] . ToString ( ) );
                    _modelPLT . PLT008 = dt . Rows [ i ] [ "PLT008" ] . ToString ( );
                    _modelPLT . PLT011 = false;
                    _modelPLT . PLT013 = false;
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
        /// 编辑备料计划完成时间
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_Prs ( CarpenterEntity . PlanStockPLTEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPRS SET " );
            strSql . Append ( "PRS007=@PRS007 " );
            strSql . Append ( "WHERE PRS001=@PRS001 AND PRS002=@PRS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PRS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS007",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _modelPLT . PLT003;
            parameter [ 1 ] . Value = _modelPLT . PLT004;
            parameter [ 2 ] . Value = _modelPLT . PLT007;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 覆盖备料周计划  但不删除之前的内容
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Edit_BL ( CarpenterEntity . PlanStockPLSEntity _model ,List<string> strList ,string name ,bool planCheck )
        {
            Hashtable SQLString = new Hashtable ( );

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLS001 FROM MOXPLS " );
            strSql . AppendFormat ( "WHERE PLS002='{0}' AND PLS001 LIKE '{1}%'" ,_model . PLS002 ,GetDate ( ) . ToString ( "yyyy" ) );

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( !string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PLS001" ] . ToString ( ) ) )
                    _model . PLS001 = da . Rows [ 0 ] [ "PLS001" ] . ToString ( );
                else
                    _model . PLS001 = string . Empty;
            }
            else
                _model . PLS001 = string . Empty;

            if ( _model . PLS001 == string . Empty )
                return false;

            strSql = new StringBuilder ( );
            _model . PLS007 = name;
            _model . PLS006 = GetDate ( );
            _model . PLS008 = false;
            _model . PLS009 = false;
            strSql . Append ( "UPDATE MOXPLS SET " );
            strSql . Append ( "PLS003=@PLS003," );
            strSql . Append ( "PLS004=@PLS004," );
            strSql . Append ( "PLS005=@PLS005," );
            strSql . Append ( "PLS006=@PLS006," );
            strSql . Append ( "PLS007=@PLS007," );
            strSql . Append ( "PLS008=@PLS008," );
            strSql . Append ( "PLS009=@PLS009 " );
            strSql . Append ( "WHERE PLS001=@PLS001 AND " );
            strSql . Append ( "PLS002=@PLS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLS003",SqlDbType.Date),
                new SqlParameter("@PLS004",SqlDbType.Date),
                new SqlParameter("@PLS005",SqlDbType.Date),
                new SqlParameter("@PLS006",SqlDbType.Date),
                new SqlParameter("@PLS007",SqlDbType.NVarChar,20),
                new SqlParameter("@PLS008",SqlDbType.Bit),
                new SqlParameter("@PLS009",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _model . PLS001;
            parameter [ 1 ] . Value = _model . PLS002;
            parameter [ 2 ] . Value = _model . PLS003;
            parameter [ 3 ] . Value = _model . PLS004;
            parameter [ 4 ] . Value = _model . PLS005;
            parameter [ 5 ] . Value = _model . PLS006;
            parameter [ 6 ] . Value = _model . PLS007;
            parameter [ 7 ] . Value = _model . PLS008;
            parameter [ 8 ] . Value = _model . PLS009;
            SQLString . Add ( strSql ,parameter );

            da = null;
            CarpenterEntity . PlanStockPLTEntity _modelPLT = new CarpenterEntity . PlanStockPLTEntity ( );
            name = "";
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

            DataTable dt = GetDataTablePLT ( _model . PLS001 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPLT . PLT001 = _model . PLS001;
                _modelPLT . PLT009 = _model . PLS006;
                _modelPLT . PLT010 = _model . PLS007;

                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPLT . PLT002 = string . Empty;
                    _modelPLT . PLT003 = da . Rows [ i ] [ "PST001" ] . ToString ( );
                    _modelPLT . PLT004 = da . Rows [ i ] [ "PST002" ] . ToString ( );
                    _modelPLT . PLT005 = da . Rows [ i ] [ "PST003" ] . ToString ( );
                    _modelPLT . PLT006 = da . Rows [ i ] [ "PST004" ] . ToString ( );
                    _modelPLT . PLT007 = _model . PLS004;
                    _modelPLT . PLT008 = da . Rows [ i ] [ "PST025" ] . ToString ( );
                    _modelPLT . PLT011 = false;
                    _modelPLT . PLT012 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PST028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PST028" ] . ToString ( ) );
                    _modelPLT . PLT013 = planCheck;
                    if ( dt . Select ( "PLT002='" + _modelPLT . PLT002 + "' AND PLT003='" + _modelPLT . PLT003 + "' AND PLT004='" + _modelPLT . PLT004 + "'" ) . Length < 1 )
                    {
                        //name = ExistsNum ( _modelPLT );
                        //if ( name != string . Empty )
                        //    //订单量=订单量-预排报工数量
                        //    _modelPLT . PLT012 = _modelPLT . PLT012 - getPlanNum ( _modelPLT ,name );

                        add_bl ( _modelPLT ,strSql ,SQLString );
                    }
                    else
                        edit_bl ( _modelPLT ,strSql ,SQLString );
                    //回写备料跟踪表计划完成日期
                    if ( _modelPLT . PLT013 == false && Exists_edit_bl ( _modelPLT . PLT003 ,_modelPLT . PLT004 ) == true )
                        edit_bl ( _modelPLT ,strSql ,SQLString ,_model . PLS002 );
                    //回写生产部生产跟踪表备料计划完成日期
                    //if ( _modelPLT . PLT013 == false && Exists_edit_sc ( _modelPLT . PLT003 ,_modelPLT . PLT004 ) == true )
                    //    edit_bl ( _modelPLT ,strSql ,SQLString ,_model . PLS002 );

                    edit_pas ( _modelPLT ,SQLString );
                    if ( _modelPLT . PLT013 == false && Exists_edit_Prs ( _modelPLT . PLT003 ,_modelPLT . PLT004 ) == true )
                        edit_Prs ( _modelPLT ,strSql ,SQLString );
                }
            }
            
            da = GetDataTableBLP ( _model . PLS001 );
            if ( da != null && da . Rows . Count > 0 )
            {
                _modelPLT . PLT001 = _model . PLS001;
                _modelPLT . PLT009 = _model . PLS006;
                _modelPLT . PLT010 = _model . PLS007;
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modelPLT . PLT002 = da . Rows [ i ] [ "PLT001" ] . ToString ( );
                    _modelPLT . PLT003 = da . Rows [ i ] [ "PLT003" ] . ToString ( );
                    _modelPLT . PLT004 = da . Rows [ i ] [ "PLT004" ] . ToString ( );
                    _modelPLT . PLT005 = da . Rows [ i ] [ "PLT005" ] . ToString ( );
                    _modelPLT . PLT006 = da . Rows [ i ] [ "PLT006" ] . ToString ( );
                    _modelPLT . PLT012 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PLT012" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PLT012" ] . ToString ( ) );
                    _modelPLT . PLT013 = false;

                    //订单量=订单量-报工数量
                    //_modelPLT . PLT012 = _modelPLT . PLT012 - getPlanNum ( _modelPLT ,_modelPLT . PLT002 );


                    if ( string . IsNullOrEmpty ( da . Rows [ i ] [ "PLT007" ] . ToString ( ) ) )
                        _modelPLT . PLT007 = null;
                    else
                        _modelPLT . PLT007 = Convert . ToDateTime ( da . Rows [ i ] [ "PLT007" ] . ToString ( ) );

                    _modelPLT . PLT008 = da . Rows [ i ] [ "PLT008" ] . ToString ( );
                    _modelPLT . PLT011 = false;
                    if ( dt . Select ( "PLT002='" + _modelPLT . PLT002 + "' AND PLT003='" + _modelPLT . PLT003 + "' AND PLT004='" + _modelPLT . PLT004 + "'" ) . Length < 1 )
                        add_bl ( _modelPLT ,strSql ,SQLString );
                    else
                        edit_bl ( _modelPLT ,strSql ,SQLString );

                    //edit_pas ( _modelPLT ,SQLString );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
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
        /// 获取备料周计划单号
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        string GetBLOddNum ( StringBuilder strSql )
        {
            strSql . Append ( "SELECT MAX(PLS001) PLS001 FROM MOXPLS" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PLS001" ] . ToString ( ) ) )
                    return GetDate ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PLS001" ] . ToString ( ) . Substring ( 0 ,8 ) == GetDate ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PLS001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return GetDate ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return GetDate ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        /// <summary>
        /// 备料周计划单身插入数据
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void add_bl ( CarpenterEntity . PlanStockPLTEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPLT (" );
            strSql . Append ( "PLT001,PLT002,PLT003,PLT004,PLT005,PLT006,PLT007,PLT008,PLT009,PLT010,PLT011,PLT012,PLT013) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PLT001,@PLT002,@PLT003,@PLT004,@PLT005,@PLT006,@PLT007,@PLT008,@PLT009,@PLT010,@PLT011,@PLT012,@PLT013) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLT001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT004",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT005",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT006",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT007",SqlDbType.Date),
                new SqlParameter("@PLT008",SqlDbType.NVarChar,200),
                new SqlParameter("@PLT009",SqlDbType.Date),
                new SqlParameter("@PLT010",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT011",SqlDbType.Bit),
                new SqlParameter("@PLT012",SqlDbType.Int),
                new SqlParameter("@PLT013",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _modelPLT . PLT001;
            parameter [ 1 ] . Value = _modelPLT . PLT002;
            parameter [ 2 ] . Value = _modelPLT . PLT003;
            parameter [ 3 ] . Value = _modelPLT . PLT004;
            parameter [ 4 ] . Value = _modelPLT . PLT005;
            parameter [ 5 ] . Value = _modelPLT . PLT006;
            parameter [ 6 ] . Value = _modelPLT . PLT007;
            parameter [ 7 ] . Value = _modelPLT . PLT008;
            parameter [ 8 ] . Value = _modelPLT . PLT009;
            parameter [ 9 ] . Value = _modelPLT . PLT010;
            parameter [ 10 ] . Value = _modelPLT . PLT011;
            parameter [ 11 ] . Value = _modelPLT . PLT012;
            parameter [ 12 ] . Value = _modelPLT . PLT013;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 备料周计划单身修改数据
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_bl ( CarpenterEntity . PlanStockPLTEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPLT SET " );
            strSql . Append ( "PLT005=@PLT005," );
            strSql . Append ( "PLT006=@PLT006," );
            strSql . Append ( "PLT007=@PLT007," );
            strSql . Append ( "PLT008=@PLT008," );
            strSql . Append ( "PLT009=@PLT009," );
            strSql . Append ( "PLT010=@PLT010," );
            //strSql . Append ( "PLT011=PLT011," );
            strSql . Append ( "PLT012=@PLT012 " );
            strSql . Append ( "WHERE PLT001=@PLT001 AND " );
            strSql . Append ( "PLT002=@PLT002 AND " );
            strSql . Append ( "PLT003=@PLT003 AND " );
            strSql . Append ( "PLT004=@PLT004 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLT001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT004",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT005",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT006",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT007",SqlDbType.Date),
                new SqlParameter("@PLT008",SqlDbType.NVarChar,200),
                new SqlParameter("@PLT009",SqlDbType.Date),
                new SqlParameter("@PLT010",SqlDbType.NVarChar,20),
                //new SqlParameter("PLT011",SqlDbType.Bit),
                new SqlParameter("@PLT012",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _modelPLT . PLT001;
            parameter [ 1 ] . Value = _modelPLT . PLT002;
            parameter [ 2 ] . Value = _modelPLT . PLT003;
            parameter [ 3 ] . Value = _modelPLT . PLT004;
            parameter [ 4 ] . Value = _modelPLT . PLT005;
            parameter [ 5 ] . Value = _modelPLT . PLT006;
            parameter [ 6 ] . Value = _modelPLT . PLT007;
            parameter [ 7 ] . Value = _modelPLT . PLT008;
            parameter [ 8 ] . Value = _modelPLT . PLT009;
            parameter [ 9 ] . Value = _modelPLT . PLT010;
            //parameter [ 10 ] . Value = _modelPLT . PLT011;
            parameter [ 10 ] . Value = _modelPLT . PLT012;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 获取预排单号
        /// </summary>
        /// <returns></returns>
        string ExistsNum ( CarpenterEntity . PlanStockPLTEntity _modelPLT )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PLT001 FROM MOXPLT WHERE PLT003='{0}' AND PLT004='{1}' AND PLT013=1" ,_modelPLT . PLT003 ,_modelPLT . PLT004 );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PLT001" ] . ToString ( ) ) )
                    return string . Empty;
                else
                    return dt . Rows [ 0 ] [ "PLT001" ] . ToString ( );
            } else
                return string . Empty;
        }

        /// <summary>
        /// 获取预排报工数量
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <returns></returns>
        int getPlanNum ( CarpenterEntity . PlanStockPLTEntity _modelPLT ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT SUM(PDK007) PDK007 FROM MOXPLT A INNER JOIN MOXPDK B ON A.PLT003=B.PDK002 AND A.PLT004=B.PDK003 AND A.PLT001=B.PDK016 WHERE  PLT003='{0}' AND PLT004='{1}' AND PLT001='{2}'" ,_modelPLT . PLT003 ,_modelPLT . PLT004 ,oddNum );//PDK008=1 AND

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PDK007" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToInt32 ( dt . Rows [ 0 ] [ "PDK007" ] . ToString ( ) );
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
            strSql . Append ( "SELECT PST015 FROM MOXPST " );
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
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PST015" ] . ToString ( ) ) )
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        /// <summary>
        /// 周计划生成时编辑备料计划完成时间批次周次
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        /// <param name="weekNum"></param>
        void edit_bl ( CarpenterEntity . PlanStockPLTEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString ,string weekNum )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPST SET " );
            strSql . Append ( "PST015=@PST015 " );
            strSql . Append ( "WHERE PST001=@PST001 AND PST002=@PST002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PST001",SqlDbType.NVarChar,20),
                new SqlParameter("@PST002",SqlDbType.NVarChar,20),
                new SqlParameter("@PST015",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelPLT . PLT003;
            parameter [ 1 ] . Value = _modelPLT . PLT004;
            parameter [ 2 ] . Value = "第" + weekNum + "周";

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 标记已排计划未审核的记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="SQLString"></param>
        void edit_pas ( CarpenterEntity . PlanStockPLTEntity model ,Hashtable SQLString)
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
            parameter [ 0 ] . Value = model . PLT003;
            parameter [ 1 ] . Value = model . PLT004;
            parameter [ 2 ] . Value = true;

            SQLString . Add ( strSql ,parameter );
        }

        ///// <summary>
        ///// 周计划完成周次 是否存在  若存在则返回false  不覆盖
        ///// </summary>
        ///// <param name="weekEnds"></param>
        ///// <param name="productNum"></param>
        ///// <returns></returns>
        //bool Exists_edit_sc ( string weekEnds ,string productNum )
        //{
        //    StringBuilder strSql = new StringBuilder ( );
        //    strSql . Append ( "SELECT PRS007 FROM MOXPRS " );
        //    strSql . Append ( "WHERE PRS001=PRS001 AND PRS002=PRS002" );
        //    SqlParameter [ ] parameter = {
        //        new SqlParameter("PRS001",SqlDbType.NVarChar,20),
        //        new SqlParameter("PRS002",SqlDbType.NVarChar,20)
        //    };
        //    parameter [ 0 ] . Value = weekEnds;
        //    parameter [ 1 ] . Value = productNum;

        //    DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        //    if ( dt != null && dt . Rows . Count > 0 )
        //    {
        //        if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PRS007" ] . ToString ( ) ) )
        //            return true;
        //        else
        //            return false;
        //    }
        //    else
        //        return true;
        //}

        ///// <summary>
        ///// 周计划生成时编辑生产部生产进度跟踪表备料计划完成时间
        ///// </summary>
        ///// <param name="_modelPLT"></param>
        ///// <param name="strSql"></param>
        ///// <param name="SQLString"></param>
        ///// <param name="weekNum"></param>
        //void edit_bl_sc ( CarpenterEntity . PlanStockPLTEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString ,string weekNum )
        //{
        //    strSql = new StringBuilder ( );
        //    strSql . Append ( "UPDATE MOXPRS SET " );
        //    strSql . Append ( "PRS007=PRS007 " );
        //    strSql . Append ( "WHERE PRS001=PRS001 AND PRS002=PRS002" );
        //    SqlParameter [ ] parameter = {
        //        new SqlParameter("PRS001",SqlDbType.NVarChar,20),
        //        new SqlParameter("PRS002",SqlDbType.NVarChar,20),
        //        new SqlParameter("PRS007",SqlDbType.NVarChar,20)
        //    };
        //    parameter [ 0 ] . Value = _modelPLT . PLT003;
        //    parameter [ 1 ] . Value = _modelPLT . PLT004;
        //    parameter [ 2 ] . Value = "第" + weekNum + "周";

        //    SQLString . Add ( strSql ,parameter );
        //}

        /// <summary>
        /// 获取备料上次遗留
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableBLP ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLT001,PLT002,PLT003,PLT004,PLT005,PLT006,PLT007,PLT010,PLT012-SUM(ISNULL(PDK007,0)) PLT012,PLT008 FROM MOXPLT A LEFT JOIN MOXPDK B ON A.PLT003=B.PDK002 AND A.PLT004=B.PDK003  " );// AND A.PLT001=B.PDK016
            strSql . Append ( "WHERE PLT001=(SELECT MAX(PLT001) PLT001 FROM MOXPLT WHERE PLT001<@PLT001) AND PLT013=0 " );//
            strSql . Append ( "GROUP BY PLT001,PLT002,PLT003,PLT004,PLT005,PLT006,PLT007,PLT010,PLT012,PLT008 " );
            strSql . Append ( "HAVING SUM(ISNULL(PDK007,0))<PLT012" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLT001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
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
            //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPLT B ON A.PST001=B.PLT003 AND A.PST002=B.PLT004 WHERE A.idx IN (" + strWhere + ") AND PLT013=0) AND idx IN (" + strWhere + ")" );

            strSql . AppendFormat ( "WITH CET AS (SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPLT B ON A.PST001=B.PLT003 AND A.PST002=B.PLT004 WHERE A.idx IN ({0}) AND PLT013=0) AND idx IN ({0}))" ,strWhere );
            strSql . AppendFormat ( " SELECT PST001,PST002,PST003,PST004,PST025,PST028-ISNULL(PDK007,0) PST028 FROM CET A LEFT JOIN (SELECT PLT003,PLT004,SUM(ISNULL(PDK007,0)) PDK007 FROM MOXPST C INNER JOIN MOXPLT A ON C.PST001=A.PLT003 AND C.PST002=A.PLT004 INNER JOIN MOXPDK B ON A.PLT001=B.PDK009 AND A.PLT003=B.PDK002 AND A.PLT004=B.PDK003  WHERE PLT013=1 AND C.idx IN ({0}) GROUP BY PLT003,PLT004) B ON A.PST001=B.PLT003 AND A.PST002=B.PLT004 GROUP BY PST001,PST002,PST003,PST004,PST025,PST028,PDK007 HAVING PST028>ISNULL(PDK007,0)" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 周计划 预排
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableBLPlane_Add ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028 FROM MOXPST " );
            //strSql . Append ( "WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPLT B ON A.PST001=B.PLT003 AND A.PST002=B.PLT004 WHERE A.idx IN (" + strWhere + ")) AND idx IN (" + strWhere + ")" );
            
            strSql . AppendFormat ( "SELECT PST001,PST002,PST003,PST004,PST025,PST028-SUM(ISNULL(PDK007,0)) PST028 FROM MOXPST A LEFT JOIN MOXPLT B ON A.PST001=B.PLT003 AND A.PST002=B.PLT004 LEFT JOIN MOXPDK C ON B.PLT003=C.PDK002 AND B.PLT004=C.PDK003 AND B.PLT001=C.PDK009 WHERE A.idx NOT IN (SELECT D.idx FROM MOXPLT B INNER JOIN MOXPST D ON B.PLT003=D.PST001 AND B.PLT004=D.PST002 WHERE D.idx IN ({0})) AND A.idx IN ({0}) GROUP BY PST001,PST002,PST003,PST004,PST025,PST028 HAVING  PST028>SUM(ISNULL(PDK007,0))" ,strWhere );

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
            strSql . Append ( "SELECT PLT002,PLT003,PLT004 FROM MOXPLT " );
            strSql . AppendFormat ( "WHERE PLT001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 周计划备料报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool BLDailyWeek ( DataTable table ,string userName ,bool state )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . PlanStockDailyWeekEntity _model = new CarpenterEntity . PlanStockDailyWeekEntity ( );
            _model . PDK001 = DailyWeekOddNum ( );
            _model . PDK013 = GetDate ( );
            _model . PDK014 = userName;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . PDK002 = table . Rows [ i ] [ "PST001" ] . ToString ( );
                _model . PDK003 = table . Rows [ i ] [ "PST002" ] . ToString ( );
                _model . PDK004 = table . Rows [ i ] [ "PST003" ] . ToString ( );
                _model . PDK005 = table . Rows [ i ] [ "PST004" ] . ToString ( );
                _model . PDK006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PST028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PST028" ] . ToString ( ) );
                _model . PDK007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DL" ] . ToString ( ) );
                _model . PDK008 = state;
                //_model . PDK008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "XB" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "XB" ] . ToString ( ) );
                _model . PDK009 = table . Rows [ i ] [ "PLT001" ] . ToString ( );
                //_model . PDK010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PB" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PB" ] . ToString ( ) );
                //_model . PDK011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PC" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PC" ] . ToString ( ) );
                _model . PDK012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PDK012" ] . ToString ( ) ) == true ? GetDate ( ) : Convert . ToDateTime ( table . Rows [ i ] [ "PDK012" ] . ToString ( ) );
                //_model . PDK016 = table . Rows [ i ] [ "PLT001" ] . ToString ( );
                edit_BL_DailyWork ( _model ,strSql ,SQLString );
               
                if ( Exists_bl_day ( _model . PDK002 ,_model . PDK003 ,_model . PDK007 ) == true )
                {
                    edit_bl_day ( _model . PDK002 ,_model . PDK003 ,SQLString ,strSql );
                }

                //若报工总数量=生产数量  则回写完工时间到生产部生产进度跟踪表的对应工段完工时间
                _model . PDK007 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PDK007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PDK007" ] . ToString ( ) );
                //_model . PDK008 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PDW008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PDW008" ] . ToString ( ) );
                //_model . PDK009 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PDW009" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PDW009" ] . ToString ( ) );
                //_model . PDK010 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PDW010" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PDW010" ] . ToString ( ) );
                //_model . PDK011 += string . IsNullOrEmpty ( table . Rows [ i ] [ "PDW011" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PDW011" ] . ToString ( ) );
                //edit_BL_OverTime ( _model ,strSql ,SQLString );

                //if ( Exists_bl_weekEnds ( _model . PDK002 ,_model . PDK003 ,_model . PDK011 ) == true )
                //    edit_bl_weekEnds ( _model . PDK002 ,_model . PDK003 ,SQLString ,strSql );
                if ( Exists_bl_day ( _model . PDK002 ,_model . PDK003 ,_model . PDK007 ,_model . PDK008 ) == true && CarpenterBll . ColumnValues . pro_cg . Equals ( "常规" ) )
                {
                    edit_BL_Table ( _model ,strSql ,SQLString );
                    //edit_BL_Prs ( _model ,strSql ,SQLString );
                    edit_BL_PST ( _model ,strSql ,SQLString );
                }
                else if ( Exists_bl_dayOther ( _model . PDK002 ,_model . PDK003 ,_model . PDK007 ) == true && CarpenterBll . ColumnValues . pro_cg . Equals ( "其它" ) )
                {
                    edit_BL_Table ( _model ,strSql ,SQLString );
                    //edit_BL_Prs ( _model ,strSql ,SQLString );
                    edit_BL_PST ( _model ,strSql ,SQLString );
                }

            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        string DailyWeekOddNum ( )
        {
            DataTable dt = SqlHelper . ExecuteDataTable ( "SELECT MAX(PDK001) PDK001 FROM MOXPDK " );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PDK001" ] . ToString ( ) ) )
                    return GetDate ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "PDK001" ] . ToString ( ) . Substring ( 0 ,8 ) == GetDate ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "PDK001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return GetDate ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return GetDate ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        void edit_BL_DailyWork ( CarpenterEntity . PlanStockDailyWeekEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPDK (" );//,PDK009,PDK010,PDK011, ,PDK016,PDK016
            strSql . Append ( "PDK001,PDK002,PDK003,PDK004,PDK005,PDK006,PDK007,PDK008,PDK012,PDK013,PDK014,PDK009) " );
            strSql . Append ( "VALUES (" );//,PDK009,PDK010,PDK011,
            strSql . Append ( "@PDK001,@PDK002,@PDK003,@PDK004,@PDK005,@PDK006,@PDK007,@PDK008,@PDK012,@PDK013,@PDK014,@PDK009) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PDK001",SqlDbType.NVarChar,20),
                new SqlParameter("@PDK002",SqlDbType.NVarChar,20),
                new SqlParameter("@PDK003",SqlDbType.NVarChar,20),
                new SqlParameter("@PDK004",SqlDbType.NVarChar,20),
                new SqlParameter("@PDK005",SqlDbType.NVarChar,20),
                new SqlParameter("@PDK006",SqlDbType.Int),
                new SqlParameter("@PDK007",SqlDbType.Int),
                new SqlParameter("@PDK008",SqlDbType.Bit),
                //new SqlParameter("PDK010",SqlDbType.Int),
                //new SqlParameter("PDK011",SqlDbType.Int),
                new SqlParameter("@PDK012",SqlDbType.Date),
                new SqlParameter("@PDK013",SqlDbType.Date),
                new SqlParameter("@PDK014",SqlDbType.NVarChar,20),
                new SqlParameter("@PDK009",SqlDbType.NVarChar,50)
                //new SqlParameter("PDK016",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PDK001;
            parameter [ 1 ] . Value = _model . PDK002;
            parameter [ 2 ] . Value = _model . PDK003;
            parameter [ 3 ] . Value = _model . PDK004;
            parameter [ 4 ] . Value = _model . PDK005;
            parameter [ 5 ] . Value = _model . PDK006;
            parameter [ 6 ] . Value = _model . PDK007;
            parameter [ 7 ] . Value = _model . PDK008;
            //parameter [ 9 ] . Value = _model . PDK010;
            //parameter [ 10 ] . Value = _model . PDK011;
            parameter [ 8 ] . Value = _model . PDK012;
            parameter [ 9 ] . Value = _model . PDK013;
            parameter [ 10 ] . Value = _model . PDK014;
            parameter [ 11 ] . Value = _model . PDK009;
            //parameter [ 11 ] . Value = _model . PDK016;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 编辑备料跟踪表的配套报工时间
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_BL_Table ( CarpenterEntity . PlanStockDailyWeekEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPST SET PST016=@PST016 WHERE PST001=@PST001 AND PST002=@PST002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PST001",SqlDbType.NVarChar,20),
                new SqlParameter("@PST002",SqlDbType.NVarChar,20),
                new SqlParameter("@PST016",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . PDK002;
            parameter [ 1 ] . Value = _model . PDK003;
            parameter [ 2 ] . Value = _model . PDK012;
            SQLString . Add ( strSql ,parameter );
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
            strSql . Append ( "SELECT SUM(PLT012) PLT012 FROM MOXPLT " );
            strSql . Append ( "WHERE PLT003=@PLT003 AND PLT004=@PLT004 " );//AND PLT013=0
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
                int num = Convert . ToInt32 ( da . Rows [ 0 ] [ "PLT012" ] . ToString ( ) );
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
        /// <param name="state"></param>
        /// <returns></returns>
        bool Exists_bl_day ( string weekEnds ,string productNum ,int nums ,bool state )
        {
            StringBuilder strSql = new StringBuilder ( );

            if ( state )
                //strSql . AppendFormat ( "SELECT SUM(PLT012) PLT012 FROM MOXPLT WHERE PLT003='{0}' AND PLT004='{1}' AND PLT013=1" ,weekEnds ,productNum );
                strSql . AppendFormat ( "SELECT SUM(PLT012) PLT012 FROM MOXPLT A INNER JOIN (SELECT MAX(PLT001) PLT001,PLT003,PLT004 FROM MOXPLT WHERE PLT003='{0}' AND PLT004='{1}' AND PLT013=1  GROUP BY PLT003,PLT004) C ON A.PLT001=C.PLT001 AND A.PLT003=C.PLT003 AND A.PLT004=C.PLT004 WHERE PLT013=1 AND A.PLT003='{0}' AND A.PLT004='{1}'" ,weekEnds ,productNum );
            else
                //strSql . AppendFormat ( "SELECT SUM(PLT012)+ISNULL(PDK007,0) PLT012 FROM MOXPLT A LEFT JOIN (SELECT SUM(PDK007) PDK007,PDK002,PDK003 FROM MOXPDK WHERE PDK002='{0}' AND PDK003='{1}' AND PDK008=1 GROUP BY PDK002,PDK003) B ON A.PLT003=B.PDK002 AND A.PLT004=B.PDK003 WHERE PLT013=0 AND PLT003='{0}' AND PLT004='{1}' GROUP BY ISNULL(PDK007,0)" ,weekEnds ,productNum );//1823-4    51-1.004.01.007
                strSql . AppendFormat ( "SELECT SUM(PLT012)+ISNULL(PDK007,0) PLT012 FROM MOXPLT A INNER JOIN (SELECT MAX(PLT001) PLT001,PLT003,PLT004 FROM MOXPLT WHERE PLT013=0 AND PLT003='{0}' AND PLT004='{1}' GROUP BY PLT003,PLT004) C ON A.PLT001=C.PLT001 AND A.PLT003=C.PLT003 AND A.PLT004=C.PLT004 LEFT JOIN (SELECT SUM(PDK007) PDK007,MAX(PDK001) PDK001,PDK002,PDK003 FROM MOXPDK WHERE PDK002='{0}' AND PDK003='{1}' AND PDK008=1 GROUP BY PDK002,PDK003) B ON A.PLT003=B.PDK002 AND A.PLT004=B.PDK003 WHERE PLT013=0 AND A.PLT003='{0}' AND A.PLT004='{1}' GROUP BY ISNULL(PDK007,0)" ,weekEnds ,productNum );

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( da != null && da . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PLT012" ] . ToString ( ) ) )
                    return false;
                int num = Convert . ToInt32 ( da . Rows [ 0 ] [ "PLT012" ] . ToString ( ) );
                if ( num == nums )
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 非常规产品回写条件  检测正排订单量是否等于报工量
        /// </summary>
        /// <param name="productNum"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        bool Exists_bl_dayOther ( string weekEnds ,string productNum ,int nums )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PST028-SUM(ISNULL(PDK007,0))-{2} PDK FROM MOXPST A LEFT JOIN MOXPDK B ON A.PST001=B.PDK002 AND A.PST002=B.PDK003  WHERE PST001 ='{0}' AND PST002='{1}' GROUP BY PST028" ,weekEnds ,productNum ,nums );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table != null && table . Rows . Count > 0 )
            {
                string num = table . Rows [ 0 ] [ "PDK" ] . ToString ( );
                if ( string . IsNullOrEmpty ( num ) )
                    return false;
                else
                {
                    if ( Convert . ToInt32 ( num ) == 0 )
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
        void edit_bl_day ( string weekEnds ,string productNum ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPLT SET " );
            strSql . Append ( "PLT011=1 " );
            strSql . Append ( "WHERE PLT003=@PLT003 AND PLT004=@PLT004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLT003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT004",SqlDbType.NVarChar,20)
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
        void edit_BL_Prs ( CarpenterEntity . PlanStockDailyWeekEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPRS SET " );
            strSql . Append ( "PRS008=@PRS008 " );
            strSql . Append ( "WHERE PRS001=@PRS001 AND PRS002=@PRS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PRS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS008",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . PDK002;
            parameter [ 1 ] . Value = _model . PDK003;
            parameter [ 2 ] . Value = _model . PDK012;

            SQLString . Add ( strSql  ,parameter );
        }

        /// <summary>
        /// 回写完工标记到跟踪表
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_BL_PST ( CarpenterEntity . PlanStockDailyWeekEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXPST SET PST031=1 WHERE PST001='{0}' AND PST002='{1}'" ,_model . PDK002 ,_model . PDK003 );

            SQLString . Add ( strSql ,null );
        }

    }
}
