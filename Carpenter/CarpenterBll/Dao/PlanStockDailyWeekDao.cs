using System . Data;
using System . Text;
using StudentMgr;
using System . Collections . Generic;
using System . Collections;
using System . Data . SqlClient;
using System;

namespace CarpenterBll . Dao
{
    public class PlanStockDailyWeekDao
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string columns )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM MOXPDK ORDER BY {0} DESC" ,columns );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,PDK001,PDK002,PDK003,PDK004,PDK005,PST028,PDK006,PDK007,PDK012,OPI006,OPI007,CONVERT(FLOAT,ISNULL(OPI004,0)) OPI004,CONVERT(FLOAT,PDK007*ISNULL(OPI004,0)) U0,CASE PDK008 WHEN 0 THEN '正式' ELSE '预排' END PDK008,PDK016,PDK009,PDK014 FROM MOXPDK A LEFT JOIN MOXOPI B ON A.PDK003=B.OPI001 INNER JOIN MOXPST C ON A.PDK002=C.PST001 AND A.PDK003=C.PST002 " );
            strSql . Append ( " WHERE " + strWhere );
            strSql . Append ( " ORDER BY PDK001 DESC,PDK002 DESC,PDK003 DESC" );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string year ,string week ,string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLS002,PDK014,CONVERT(FLOAT,SUM(PLT012*OPI004)) PSX FROM MOXPDK A INNER JOIN MOXPLT B ON A.PDK002=B.PLT003 AND A.PDK003=B.PLT004 AND A.PDK009=B.PLT001 INNER JOIN MOXOPI C ON A.PDK003=C.OPI001 INNER JOIN MOXPLS D ON B.PLT001=D.PLS001 " );
            strSql . AppendFormat ( "WHERE PDK001 LIKE '{0}%' AND PLS002='{1}' AND  PDK014='{2}' " ,year ,week ,userName );
            strSql . Append ( " GROUP BY PLS002,PDK014" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public DataTable GetDataTablePrintOne ( string date ,string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT '' PLS002,PDK014,CONVERT(FLOAT,SUM(PDK007*OPI004)) PSX FROM MOXPDK A INNER JOIN MOXOPI C ON A.PDK003=C.OPI001 " );
            strSql . AppendFormat ( "WHERE CONVERT(NVARCHAR(20),PDK012,112)='{0}' AND  PDK014='{1}' " ,date ,userName );
            strSql . Append ( " GROUP BY PDK014" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string year ,string week ,string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT A.PDK002,A.PDK003,PDK004,OPI003,PST028,PDK006,PDK007 PDK,PDK012,PLT008,PD FROM MOXPDK A INNER JOIN MOXOPI B ON A.PDK003=B.OPI001 INNER JOIN MOXPLT C ON A.PDK002=C.PLT003 AND A.PDK003=C.PLT004 INNER JOIN MOXPLS D ON C.PLT001=D.PLS001 INNER JOIN ( SELECT SUM(PDK007) PD,PDK002,PDK003 FROM MOXPDK WHERE PDK001 LIKE '{0}%' AND PDK014='{1}' GROUP BY PDK002,PDK003) E ON A.PDK002=E.PDK002 AND A.PDK003=E.PDK003  INNER JOIN MOXPST F ON A.PDK002=F.PST001 AND A.PDK003=F.PST002 WHERE PDK001 LIKE '{0}%' AND PLS002='{2}' AND PDK014='{1}'" ,year ,userName ,week );
            strSql . Append ( " ORDER BY A.PDK002,A.PDK003 " );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public DataTable GetDataTablePrintTwo ( string date ,string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT A.PDK002,PDK004,OPI003,PST028,PDK006,PDK007 PDK,PDK012,PST025 PLT008,PDK PD FROM MOXPDK A INNER JOIN MOXOPI B ON A.PDK003=B.OPI001 INNER JOIN MOXPST C ON A.PDK002=C.PST001 AND A.PDK003=C.PST002 INNER JOIN (SELECT SUM(PDK007) PDK,PDK002,PDK003 FROM MOXPDK A WHERE  CONVERT(NVARCHAR(20),PDK012,112)='{0}' AND  PDK014='{1}' GROUP BY PDK002,PDK003) D ON A.PDK002=D.PDK002 AND A.PDK003=D.PDK003 WHERE CONVERT(NVARCHAR(20),PDK012,112)='{0}' AND  PDK014='{1}'  " ,date ,userName );
            strSql . Append ( " ORDER BY A.PDK002,A.PDK003 " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 是否是同产品属性
        /// </summary>
        /// <param name="inList"></param>
        /// <returns>0:表示没有数据,按计划报工 1:表示全部是常规,按计划报工  2:表示没有常规,按非计划报工 3:表示有常规和非常规,不让报工  4:表示都是非常规,按非计划报工</returns>
        public int ExistsProductAttr ( List<string> inList )
        {
            string str = string . Join ( "," ,inList . ToArray ( ) );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT OPI009 FROM MOXPST A INNER JOIN MOXOPI B ON A.PST002=B.OPI001 WHERE A.idx IN ({0})" ,str );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                return 0;
            else
            {
                if ( table . Rows . Count == 1 && table . Rows [ 0 ] [ "OPI009" ] . ToString ( ) . Equals ( "常规" ) )
                    return 1;
                else if ( table . Rows . Count == 1 && !table . Rows [ 0 ] [ "OPI009" ] . ToString ( ) . Equals ( "常规" ) )
                    return 2;
                else
                {
                    foreach ( DataRow row in table . Rows )
                    {
                        if ( row [ "OPI009" ] . ToString ( ) . Equals ( "常规" ) )
                            return 3;
                    }
                    return 4;
                }
            }
        }
        
        /// <summary>
        /// 获取周计划报工清单  常规产品
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeek ( List<string> inList )
        {
            string str = string . Empty;
            foreach ( string intX in inList )
            {
                if ( str == string . Empty )
                    str = intX;
                else
                    str = str + "," + intX;
            }
            
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS (SELECT PLT003,PLT004,PLT001,PLT002,PLS009 FROM MOXPLT D INNER JOIN MOXPLS E ON D.PLT001=E.PLS001 INNER JOIN MOXPST F ON D.PLT003=F.PST001 AND D.PLT004=F.PST002 WHERE F.idx IN ({0}) AND PLT013=0 GROUP BY PLS009,PLT003,PLT004,PLT001,PLT002),CFT AS(SELECT * FROM CET WHERE PLT001+PLT003+PLT004 NOT IN (SELECT PLT002+PLT003+PLT004 FROM CET) AND PLS009=1)" ,str );
            strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST005,PST028,PST028-SUM(ISNULL(PDK007,0)) DL,GETDATE() PDK012,OPI006,OPI007,SUM(ISNULL(PDK007,0)) PDK007,PLT001 FROM MOXPST A LEFT JOIN MOXOPI C ON A.PST002=C.OPI001 INNER JOIN CFT D ON A.PST001=D.PLT003 AND A.PST002=D.PLT004 LEFT JOIN MOXPDK B ON A.PST001=B.PDK002 AND A.PST002=B.PDK003 " );//,PLT001   AND B.PDK016=D.PLT001 ,PLT001
            strSql . AppendFormat ( "WHERE A.idx IN ({0}) " ,str );
            strSql . Append ( " GROUP BY PST001,PST002,PST003,PST004,PST005,OPI006,OPI007,PST028,PLT001 " );
            strSql . Append ( " HAVING SUM(ISNULL(PDK007,0))<PST028 ORDER BY PST001 DESC,PST002 DESC " );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

        }

        /// <summary>
        /// 获取非常规产品报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeekOther ( List<string> inList )
        {
            string proList = string . Join ( "," ,inList . ToArray ( ) );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT '' PLT001,PST001,PST002,PST003,PST004,OPI006,OPI007,PST028,PST005,SUM(ISNULL(PDK007,0)) PDK007,PST028-SUM(PDK007) DL,GETDATE() PDK012 FROM MOXPST A LEFT JOIN MOXPDK B ON A.PST001=B.PDK002 AND A.PST002=B.PDK003 INNER JOIN MOXOPI C ON A.PST002=C.OPI001 WHERE A.idx IN ({0}) GROUP BY PST001,PST002,PST003,PST004,OPI006,OPI007,PST028,PDK012,PST005 HAVING SUM(ISNULL(PDK007,0))<PST028 ORDER BY PST001 DESC,PST002 DESC " ,proList );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 预排报工  先减掉周计划正式排产的产品
        /// </summary>
        /// <param name="idxLi"></param>
        /// <returns></returns>
        public List<string> idxList ( List<string> idxLi )
        {
            List<string> idxListCount = new List<string> ( );
            string strIdx = string . Join ( "," ,idxLi );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx FROM MOXPST WHERE idx NOT IN (SELECT A.idx FROM MOXPST A INNER JOIN MOXPLT B ON A.PST001=B.PLT003 AND A.PST002=B.PLT004 WHERE A.idx IN ({0}) AND PLT013=0) AND idx IN ({0})" ,strIdx );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    idxListCount . Add ( dt . Rows [ i ] [ "idx" ] . ToString ( ) );
                }
                return idxListCount;
            }
            else
                return null;
        }

        /// <summary>
        /// 获取周计划预排报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeekDaily ( List<string> inList )
        {
            string str = string . Empty;
            foreach ( string intX in inList )
            {
                if ( str == string . Empty )
                    str = intX;
                else
                    str = str + "," + intX;
            }

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST005,PST028,PST028-SUM(ISNULL(PDK007,0)) DL,GETDATE() PDK012,OPI006,OPI007 ,SUM(ISNULL(PDK007,0)) PDK007,PLT001 FROM MOXPST A LEFT JOIN MOXOPI C ON A.PST002=C.OPI001 INNER JOIN (SELECT MAX(PLT001) PLT001,PLT003,PLT004 FROM MOXPLT D INNER JOIN MOXPLS E ON D.PLT001=E.PLS001 WHERE PLT013=1 AND PLS009=1 GROUP BY PLT003,PLT004) D ON A.PST001=D.PLT003 AND A.PST002=D.PLT004 LEFT JOIN MOXPDK B ON A.PST001=B.PDK002 AND A.PST002=B.PDK003 " );//,PLT001   AND B.PDK016=D.PLT001 ,PLT001
            strSql . AppendFormat ( "WHERE A.idx IN ({0}) " ,str );
            strSql . Append ( " GROUP BY PST001,PST002,PST003,PST004,PST005,OPI006,OPI007,PST028,PLT001  " );
            strSql . Append ( " HAVING SUM(ISNULL(PDK007,0))<PST028 ORDER BY PST001 DESC,PST002 DESC " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取年
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableYear ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT SUBSTRING(PDK001,0,5) PDK001 FROM MOXPDK" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取周次
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableWeek ( string year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PLS002 FROM MOXPDK A INNER JOIN MOXPLT B ON A.PDK002=B.PLT003 AND A.PDK003=B.PLT004 INNER JOIN MOXPLS C ON B.PLT001=C.PLS001     " );
            strSql . AppendFormat ( "WHERE PDK001 LIKE '{0}%'" ,year );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePerson ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PDK014 FROM MOXPDK" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Delete ( List<string> strList )
        {
            string idxStr = string . Empty;
            foreach ( string s in strList )
            {
                if ( idxStr == string . Empty )
                    idxStr = s;
                else
                    idxStr = idxStr + "," + s;
            }

            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            DataTable dt = SqlHelper . ExecuteDataTable ( "SELECT PDK002,PDK003,PDK008 FROM MOXPDK WHERE idx IN (" + idxStr + ")" );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                CarpenterEntity . PlanStockDailyWeekEntity _model = new CarpenterEntity . PlanStockDailyWeekEntity ( );
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _model . PDK002 = dt . Rows [ i ] [ "PDK002" ] . ToString ( );
                    _model . PDK003 = dt . Rows [ i ] [ "PDK003" ] . ToString ( );
                    _model . PDK008 = ( bool ) dt . Rows [ i ] [ "PDK008" ];
                    //if ( _model . PDK008 == false )
                    //{
                        edit_prs ( SQLString ,strSql ,_model );
                        edit_pst ( SQLString ,strSql ,_model );
                    //}
                    edit_plt ( SQLString ,strSql ,_model );
                }
            }

            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPDK " );
            strSql . Append ( "WHERE idx IN (" + idxStr + ")" );
            SQLString . Add ( strSql ,null );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        /// <summary>
        /// 删除备料实际完成时间
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="_model"></param>
        void edit_prs ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanStockDailyWeekEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPST SET " );
            strSql . Append ( "PST016=@PST016 " );
            strSql . Append ( "WHERE PST001=@PST001 AND PST002=@PST002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PST001",SqlDbType.NVarChar,20),
                new SqlParameter("@PST002",SqlDbType.NVarChar,20),
                new SqlParameter("@PST016",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _model . PDK002;
            parameter [ 1 ] . Value = _model . PDK003;
            parameter [ 2 ] . Value = null;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 编辑周计划是否完成为未完成
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="_model"></param>
        void edit_plt ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanStockDailyWeekEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPLT SET " );
            strSql . Append ( "PLT011=@PLT011 " );
            strSql . Append ( "WHERE PLT003=@PLT003 AND PLT004=@PLT004 AND PLT013=@PLT013" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLT003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT004",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT013",SqlDbType.Bit),
                new SqlParameter("@PLT011",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _model . PDK002;
            parameter [ 1 ] . Value = _model . PDK003;
            parameter [ 2 ] . Value = _model . PDK008;
            parameter [ 2 ] . Value = false;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 编辑跟踪表完成标记为未完成
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="_model"></param>
        void edit_pst ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanStockDailyWeekEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXPST SET PST031=0 WHERE PST001='{0}' AND PST002='{1}'" ,_model . PDK002 ,_model . PDK003 );

            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// 获取报工人
        /// </summary>
        /// <returns></returns>
        public DataTable getTableForName ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PDK014 NAME FROM MOXPDK" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }

}
