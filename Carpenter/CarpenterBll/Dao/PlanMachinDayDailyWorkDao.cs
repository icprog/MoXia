using System . Data;
using System . Text;
using StudentMgr;
using System . Collections . Generic;
using System . Collections;

namespace CarpenterBll . Dao
{
    public class PlanMachinDayDailyWorkDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string columnName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM MOXPMY ORDER BY {0} DESC" ,columnName );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,PMY001,PMY002,PMY003,PMY004,PST028,PMY005,PMY006,CASE WHEN PMY007=0 THEN NULL ELSE PMY007 END PMY007,CASE WHEN PMY008=0 THEN NULL ELSE PMY008 END PMY008,CASE WHEN PMY009=0 THEN NULL ELSE PMY009 END PMY009,CONVERT(FLOAT,ISNULL(OPI004,0)) OPI004,CONVERT(FLOAT,ISNULL(OPI004,0)*(PMY007+PMY008+PMY009)) U0,PMY012,OPI006,OPI007,CASE PMY015 WHEN 0 THEN '正式' ELSE '预排' END PMY015,PMY016,PMY014 FROM MOXPMY A LEFT JOIN MOXOPI B ON A.PMY003=B.OPI001 INNER JOIN MOXPST C ON A.PMY002=C.PST001 AND A.PMY003=C.PST002 " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( "ORDER BY PMY001 DESC,PMY002 DESC,PMY003 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取报工清单  常规
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( List<string> inList,string work )
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

            //1strSql . Append ( "WITH CET AS (SELECT PMX001,PMX003 PST001,PMX004 PST002,PMX005 PST003,PMX007,SUM(ISNULL(PMY007,0)) PMY007,PMX007-SUM(ISNULL(PMY007,0)) DL,SUM(ISNULL(PMY008,0)) PMY008,PMX007-SUM(ISNULL(PMY008,0)) XB,SUM(ISNULL(PMY009,0)) PMY009,PMX007-SUM(ISNULL(PMY009,0)) CJ,0 PC,PMY012,OPI005 PST004,PMX013 FROM (SELECT MAX(PMW001) PMW001,PMW006,PMW002 FROM MOXPMW GROUP BY PMW006,PMW002) A INNER JOIN MOXPMX B ON A.PMW001=B.PMX001 LEFT JOIN MOXPMY C ON C.PMY002=B.PMX003 AND C.PMY003=B.PMX004 AND C.PMY016=B.PMX001 AND C.PMY017=B.PMX013 LEFT JOIN MOXOPI D ON B.PMX004=D.OPI001 INNER JOIN MOXPST E ON B.PMX003=E.PST001 AND B.PMX004=E.PST002 " );
            //1strSql . AppendFormat ( "WHERE E.idx IN ({1}) AND PMW006=1 AND PMX012=0 AND PMX002='完工' AND PMW002='{0}' " ,work ,str );
            //1strSql . Append ( "GROUP BY PMX001,PMX003,PMX004,PMX005,PMY012,OPI005,PMX007,PMX013 " );
            strSql . AppendFormat ( "WITH CET AS (SELECT MAX(A.idx) idx FROM MOXPMX A INNER JOIN MOXPST B ON A.PMX003=B.PST001 AND A.PMX004=B.PST002 INNER JOIN MOXPMW C ON A.PMX001=C.PMW001 WHERE B.idx IN ({0}) AND PMW002='{1}' GROUP BY PMX003,PMX004) " ,str ,work );
            strSql . AppendFormat ( "SELECT PMX001,PMX003 PST001,PMX004 PST002,PMX005 PST003,PMX007,SUM(ISNULL(PMY007,0)) PMY007,PMX007-SUM(ISNULL(PMY007,0)) DL,SUM(ISNULL(PMY008,0)) PMY008,PMX007-SUM(ISNULL(PMY008,0)) XB,SUM(ISNULL(PMY009,0)) PMY009,PMX007-SUM(ISNULL(PMY009,0)) CJ,0 PC,GETDATE() PMY012,OPI005 PST004,PMX013 FROM MOXPMW A INNER JOIN MOXPMX B ON A.PMW001=B.PMX001 LEFT JOIN MOXPMY C ON C.PMY002=B.PMX003 AND C.PMY003=B.PMX004 AND C.PMY016=B.PMX001 AND C.PMY017=B.PMX013 LEFT JOIN MOXOPI D ON B.PMX004=D.OPI001 INNER JOIN MOXPST E ON B.PMX003=E.PST001 AND B.PMX004=E.PST002 INNER JOIN CET F ON B.idx=F.idx WHERE E.idx IN ({1}) AND PMW006=1 AND PMX012=0 AND PMX002='完工' AND PMW002='{0}' GROUP BY PMX001,PMX003,PMX004,PMX005,OPI005,PMX007,PMX013  " ,work ,str );

            str = string . Empty;
            if ( work . Equals ( ColumnValues.jjg_jgzx ) )
            {
                str = "PMY007";
            }
            else if ( work . Equals ( ColumnValues . jjg_kszk ) )
            {
                str = "PMY008";
            }
            else if ( work . Equals ( ColumnValues . jjg_dy ) )
            {
                str = "PMY009";
            }
            strSql . AppendFormat ( " HAVING SUM(ISNULL({0},0))<PMX007 " ,str );
            //1strSql . AppendFormat ( "HAVING SUM(ISNULL({0},0))<PMX007 " ,str );
            //1strSql . Append ( ") SELECT * FROM CET " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取报工清单  非常规
        /// </summary>
        /// <param name="inList"></param>
        /// <param name="work"></param>
        /// <returns></returns>
        public DataTable GetDataTableOther ( List<string> inList ,string work )
        {
            string str = string . Join ( "," ,inList . ToArray ( ) );

            StringBuilder strSql = new StringBuilder ( );

            strSql . AppendFormat ( "SELECT '' PMX001,PST001,PST002,PST003,PST028 PMX007,SUM(ISNULL(PMY007,0)) PMY007,PST028-SUM(ISNULL(PMY007,0)) DL,SUM(ISNULL(PMY008,0)) PMY008,PST028-SUM(ISNULL(PMY008,0)) XB,SUM(ISNULL(PMY009,0)) PMY009,PST028-SUM(ISNULL(PMY009,0)) CJ,0 PC,GETDATE() PMY012,OPI005 PST004,'' PMX013 FROM MOXPST A INNER JOIN MOXOPI B ON A.PST002=B.OPI001 LEFT JOIN MOXPMY C ON A.PST001=C.PMY002 AND A.PST002=C.PMY003 WHERE A.idx IN ({0}) GROUP BY PST001,PST002,PST003,PST028,OPI005  " ,str );

            str = string . Empty;
            if ( work . Equals ( ColumnValues . jjg_jgzx ) )
            {
                str = "PMY007";
            }
            else if ( work . Equals ( ColumnValues . jjg_kszk ) )
            {
                str = "PMY008";
            }
            else if ( work . Equals ( ColumnValues . jjg_dy ) )
            {
                str = "PMY009";
            }
            strSql . AppendFormat ( " HAVING SUM(ISNULL({0},0))<PST028 " ,str );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取计划报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlan ( List<string> inList ,string work )
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

            //1strSql . Append ( "WITH CET AS(SELECT PMX001,PMX003 PST001,PMX004 PST002,PMX005 PST003,SUM(PMX007) PMX007,SUM(ISNULL(PMY007,0)) PMY007,SUM(PMX007)-SUM(ISNULL(PMY007,0)) DL,SUM(ISNULL(PMY008,0)) PMY008,SUM(PMX007)-SUM(ISNULL(PMY008,0)) XB,SUM(ISNULL(PMY009,0)) PMY009,SUM(PMX007)-SUM(ISNULL(PMY009,0)) CJ,0 PC,PMY012,OPI005 PST004,PMX013 FROM (SELECT MAX(PMW001) PMW001,PMW002,PMW006 FROM MOXPMW GROUP BY PMW002,PMW006) A INNER JOIN MOXPMX B ON A.PMW001=B.PMX001 LEFT JOIN MOXPMY C ON C.PMY002=B.PMX003 AND C.PMY003=B.PMX004 AND C.PMY016=B.PMX001 AND C.PMY017=B.PMX013 LEFT JOIN MOXOPI D ON B.PMX004=D.OPI001 INNER JOIN MOXPST E ON B.PMX003=E.PST001 AND B.PMX004=E.PST002 " );
            //1strSql . AppendFormat ( "WHERE E.idx IN ({1}) AND PMW006=1 AND (PMX012=1 OR PMX002='未完工') AND PMW002='{0}' " ,work ,str );
            //1strSql . Append ( "GROUP BY PMX001,PMX003,PMX004,PMX005,PMY012,OPI005,PMX007,PMX013 " );
            strSql . AppendFormat ( "WITH CET AS (SELECT MAX(A.idx) idx FROM MOXPMX A INNER JOIN MOXPST B ON A.PMX003=B.PST001 AND A.PMX004=B.PST002 INNER JOIN MOXPMW C ON A.PMX001=C.PMW001 WHERE B.idx IN ({0}) AND PMW002='{1}' GROUP BY PMX003,PMX004) " ,str ,work );
            strSql . AppendFormat ( "SELECT PMX001,PMX003 PST001,PMX004 PST002,PMX005 PST003,SUM(PMX007) PMX007,SUM(ISNULL(PMY007,0)) PMY007,SUM(PMX007)-SUM(ISNULL(PMY007,0)) DL,SUM(ISNULL(PMY008,0)) PMY008,SUM(PMX007)-SUM(ISNULL(PMY008,0)) XB,SUM(ISNULL(PMY009,0)) PMY009,SUM(PMX007)-SUM(ISNULL(PMY009,0)) CJ,0 PC,GETDATE() PMY012,OPI005 PST004,PMX013 FROM MOXPMW A INNER JOIN MOXPMX B ON A.PMW001=B.PMX001 LEFT JOIN MOXPMY C ON C.PMY002=B.PMX003 AND C.PMY003=B.PMX004 AND C.PMY016=B.PMX001 AND C.PMY017=B.PMX013 LEFT JOIN MOXOPI D ON B.PMX004=D.OPI001 INNER JOIN MOXPST E ON B.PMX003=E.PST001 AND B.PMX004=E.PST002 INNER JOIN CET F ON B.idx=F.idx WHERE E.idx IN ({1}) AND PMW006=1 AND (PMX012=1 OR PMX002='未完工') AND PMW002='{0}' GROUP BY PMX001,PMX003,PMX004,PMX005,OPI005,PMX007,PMX013 " ,work ,str );

            str = string . Empty;
            if ( work . Equals ( ColumnValues . jjg_jgzx ) )
            {
                str = "PMY007";
            }
            else if ( work . Equals ( ColumnValues . jjg_kszk ) )
            {
                str = "PMY008";
            }
            else if ( work . Equals ( ColumnValues . jjg_dy ) )
            {
                str = "PMY009";
            }
            strSql . AppendFormat ( "HAVING SUM(ISNULL({0},0))<PMX007" ,str );
            //1strSql . AppendFormat ( "HAVING SUM(ISNULL({0},0))<PMX007 " ,str );
            //1strSql . Append ( ") SELECT * FROM CET " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableDWPerson ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PMY014 FROM MOXPMY" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="workShop"></param>
        /// <param name="dateTime"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string workShop ,string dateTime ,string person )
        {
            StringBuilder strSql = new StringBuilder ( );
            string column = string . Empty;
            if(workShop.Equals( ColumnValues . jjg_jgzx ) )
                column = "PMY007";
            else if ( workShop . Equals ( ColumnValues . jjg_kszk ) )
                column = "PMY008";
            else if ( workShop . Equals ( ColumnValues . jjg_dy ) )
                column = "PMY009";

            strSql . Append ( "WITH CET AS (" );
            strSql . AppendFormat ( "SELECT PMY002,PMY003,PMY004,PST028,OPI006,PMX008,{0} PMY FROM MOXPMY A INNER JOIN MOXPMX B ON A.PMY002=B.PMX003 AND A.PMY003=B.PMX004 AND A.PMY016=B.PMX001 INNER JOIN MOXOPI C ON A.PMY003=C.OPI001 INNER JOIN MOXPMW D ON B.PMX001=D.PMW001 INNER JOIN MOXPST E ON A.PMY002=E.PST001 AND A.PMY003=E.PST002 " ,column );
            strSql . AppendFormat ( "WHERE PMY012='{0}' AND PMY014='{1}' AND PMW002='{2}' AND {3}>0" ,dateTime ,person ,workShop ,column );
            strSql . Append ( " UNION ALL " );
            strSql . AppendFormat ( "SELECT PMY002,PMY003,PMY004,PST028,OPI006,CUU008,{0} PMY FROM MOXPMY A INNER JOIN MOXOPI C ON A.PMY003=C.OPI001 INNER JOIN MOXPST E ON A.PMY002=E.PST001 AND A.PMY003=E.PST002 INNER JOIN MOXCUU B ON A.PMY002=B.CUU001 AND A.PMY003=B.CUU002 WHERE PMY012='{1}' AND PMY014='{2}' AND {0}>0 AND PMY016=''" ,column ,dateTime ,person );
            strSql . Append ( "),CFT AS (" );
            strSql . AppendFormat ( "SELECT A.PMY002,A.PMY003,MAX(A.{0}) PMY FROM MOXPMY A INNER JOIN CET B ON A.PMY002=B.PMY002 AND A.PMY003=B.PMY003 WHERE PMY012<'{1}' GROUP BY A.PMY002,A.PMY003) " ,column ,dateTime );
            strSql . Append ( "SELECT A.*,B.PMY PMYSUM,A.PST028-A.PMY-B.PMY RES FROM CET A LEFT JOIN CFT B ON A.PMY002=B.PMY002 AND A.PMY003=B.PMY003 ORDER BY A.PMY002,A.PMY003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="workShop"></param>
        /// <param name="dateTime"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string workShop ,string dateTime ,string person )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS(" );
            strSql . Append ( "SELECT PMY012,PMY014,PMW002,CONVERT(FLOAT,SUM(PMX007*OPI004)) PSX FROM MOXPMY A INNER JOIN MOXPMX B ON A.PMY002=B.PMX003 AND A.PMY003=B.PMX004 AND A.PMY016=B.PMX001 INNER JOIN MOXOPI C ON A.PMY003=C.OPI001 INNER JOIN MOXPMW D ON B.PMX001=D.PMW001 " );
            strSql . AppendFormat ( "WHERE PMY012='{0}' AND PMY014='{1}' AND PMW002='{2}' " ,dateTime ,person ,workShop );
            strSql . Append ( "GROUP BY PMY012,PMY014,PMW002" );
            strSql . Append ( " UNION ALL " );
            strSql . AppendFormat ( "SELECT PMY012,PMY014,'{2}',CONVERT(FLOAT,SUM(PST028*OPI004)) PSX FROM MOXPMY A INNER JOIN MOXPST E ON A.PMY002=E.PST001 AND A.PMY003=E.PST002 INNER JOIN MOXOPI C ON A.PMY003=C.OPI001 WHERE PMY012='{0}' AND PMY014='{1}'  AND PMY016='' GROUP BY PMY012,PMY014)" ,dateTime ,person ,workShop );
            strSql . AppendFormat ( " SELECT PMY012,PMY014,PMW002,SUM(PSX) PSX FROM CET GROUP BY PMY012,PMY014,PMW002 " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Delete ( List<string> strList )
        {
            Hashtable SQLString = new Hashtable ( );
            string idxStr = string . Empty;
            foreach ( string s in strList )
            {
                if ( idxStr == string . Empty )
                    idxStr = s;
                else
                    idxStr = idxStr + "," + s;
            }
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PMY002,PMY003,PMW002 FROM MOXPMY A INNER JOIN MOXPMW B ON A.PMY016=B.PMW001 WHERE A.idx IN ({0})" ,idxStr );
            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                CarpenterEntity . PlanMachinWorkPMWEntity model = new CarpenterEntity . PlanMachinWorkPMWEntity ( );
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    model . PMW002 = dt . Rows [ i ] [ "PMW002" ] . ToString ( );
                    model . PMW008 = dt . Rows [ i ] [ "PMY002" ] . ToString ( );
                    model . PMW011 = dt . Rows [ i ] [ "PMY003" ] . ToString ( );
                    if ( model . PMW002 . Equals ( ColumnValues . jjg_jgzx ) )
                    {
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE MOXPST SET PST018=NULL WHERE PST001='{0}' AND PST002='{1}'" ,model . PMW008 ,model . PMW011 );
                        SQLString . Add ( strSql ,null );
                    }
                    if ( model . PMW002 . Equals ( ColumnValues . jjg_kszk ) )
                    {
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE MOXPST SET PST020=NULL WHERE PST001='{0}' AND PST002='{1}'" ,model . PMW008 ,model . PMW011 );
                        SQLString . Add ( strSql ,null );
                    }
                    if ( model . PMW002 . Equals ( ColumnValues . jjg_dy ) )
                    {
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE MOXPST SET PST022=NULL WHERE PST001='{0}' AND PST002='{1}'" ,model . PMW008 ,model . PMW011 );
                        SQLString . Add ( strSql ,null );
                    }
                }
            }
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPMY " );
            strSql . Append ( "WHERE idx IN (" + idxStr + ")" );
            SQLString . Add ( strSql ,null );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

    }
}
