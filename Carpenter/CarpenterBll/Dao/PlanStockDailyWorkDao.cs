using System . Data;
using System . Text;
using StudentMgr;
using System . Collections . Generic;
using System . Collections;

namespace CarpenterBll . Dao
{
    public class PlanStockDailyWorkDao
    {
        /// <summary>
        /// 获取需要查询的内容
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string item )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM MOXPDW ORDER BY {0} DESC" ,item );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,PDW001,PDW002,PDW003,PDW004,PDW005,PDW006,CASE WHEN PDW007=0 THEN NULL ELSE PDW007 END PDW007,CASE WHEN PDW008=0 THEN NULL ELSE PDW008 END PDW008,CASE WHEN PDW009=0 THEN NULL ELSE PDW009 END PDW009,CASE WHEN PDW010=0 THEN NULL ELSE PDW010 END PDW010,CASE WHEN PDW011=0 THEN NULL ELSE PDW011 END PDW011,PDW012,CONVERT(FLOAT,ISNULL(OPI004,0)) OPI004,CONVERT(FLOAT,ISNULL(OPI004,0)*(PDW007+PDW008+PDW009+PDW010+PDW011)) U0,OPI006,OPI007,CASE PDW015 WHEN 0 THEN '正式' ELSE '预排' END PDW015,PDW016,PST028,PDW014 FROM MOXPDW A LEFT JOIN MOXOPI B ON A.PDW003=B.OPI001 INNER JOIN MOXPST C ON A.PDW002=C.PST001 AND A.PDW003=C.PST002 " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( " ORDER BY PDW001 DESC,PDW002 DESC,PDW003 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取报工清单  常规
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable (List<string> inList,string work)
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

            //1strSql . Append ( "WITH CET AS(SELECT PSX001,PSX003 PST001,PSX004 PST002,PSX005 PST003,PSX007,SUM(ISNULL(PDW007,0)) PDW007,PSX007-SUM(ISNULL(PDW007,0)) DL,SUM(ISNULL(PDW008,0)) PDW008,PSX007-SUM(ISNULL(PDW008,0)) XB,SUM(ISNULL(PDW009,0)) PDW009,PSX007-SUM(ISNULL(PDW009,0)) CJ,SUM(ISNULL(PDW010,0)) PDW010,PSX007-SUM(ISNULL(PDW010,0)) PB,SUM(ISNULL(PDW011,0)) PDW011,PSX007-SUM(ISNULL(PDW011,0)) PC,PDW012,OPI005 PST004,PSX013 FROM (SELECT MAX(PSW001) PSW001,PSW006,PSW002 FROM MOXPSW GROUP BY PSW006,PSW002) A INNER JOIN MOXPSX B ON A.PSW001=B.PSX001 LEFT JOIN MOXPDW C ON C.PDW002=B.PSX003 AND C.PDW003=B.PSX004 AND C.PDW016=B.PSX001 AND C.PDW017=B.PSX013 LEFT JOIN MOXOPI D ON B.PSX004=D.OPI001 INNER JOIN MOXPST E ON B.PSX003=E.PST001 AND B.PSX004=E.PST002 " );
            //1strSql . AppendFormat ( "WHERE E.idx IN ({1}) AND PSW006=1 AND PSX002='完工' AND PSX012=0 AND PSW002='{0}' " ,work ,str );
            //1strSql . Append ( "GROUP BY PSX001,PSX003,PSX004,PSX005,PDW012,OPI005,PSX007,PSX013 " );
            strSql . AppendFormat ( "WITH CET AS (SELECT MAX(A.idx) idx FROM MOXPSX A INNER JOIN MOXPST C ON A.PSX003=C.PST001 AND A.PSX004=C.PST002 INNER JOIN MOXPSW D ON A.PSX001=D.PSW001 WHERE C.idx IN ({0}) AND PSW002='{1}' GROUP BY PST001,PST002) " ,str ,work );
            strSql . AppendFormat ( "SELECT PSX001,PSX003 PST001,PSX004 PST002,PSX005 PST003,PSX007,SUM(ISNULL(PDW007,0)) PDW007,PSX007-SUM(ISNULL(PDW007,0)) DL,SUM(ISNULL(PDW008,0)) PDW008,PSX007-SUM(ISNULL(PDW008,0)) XB,SUM(ISNULL(PDW009,0)) PDW009,PSX007-SUM(ISNULL(PDW009,0)) CJ,SUM(ISNULL(PDW010,0)) PDW010,PSX007-SUM(ISNULL(PDW010,0)) PB,SUM(ISNULL(PDW011,0)) PDW011,PSX007-SUM(ISNULL(PDW011,0)) PC,GETDATE() PDW012,OPI005 PST004,PSX013 FROM MOXPSW A INNER JOIN MOXPSX B ON A.PSW001=B.PSX001 LEFT JOIN MOXPDW C ON C.PDW002=B.PSX003 AND C.PDW003=B.PSX004 AND C.PDW016=B.PSX001 AND C.PDW017=B.PSX013 LEFT JOIN MOXOPI D ON B.PSX004=D.OPI001 INNER JOIN MOXPST E ON B.PSX003=E.PST001 AND B.PSX004=E.PST002 INNER JOIN CET F ON B.idx=F.idx WHERE E.idx IN ({1}) AND PSW006=1 AND PSX002='完工' AND PSX012=0 AND PSW002='{0}' GROUP BY PSX001,PSX003,PSX004,PSX005,OPI005,PSX007,PSX013  " ,work ,str );
            
            str = string . Empty;
            if ( work . Equals ( CarpenterBll.ColumnValues.bl_dl ) )
            {
                str = "PDW007";
            }else if ( work . Equals ( ColumnValues.bl_xb ) )
            {
                str = "PDW008";
            }
            else if ( work . Equals ( ColumnValues.bl_cj ) )
            {
                str = "PDW009";
            }
            else if ( work . Equals ( ColumnValues.bl_pb ) )
            {
                str = "PDW010";
            }
            else if ( work . Equals ( ColumnValues.bl_pc ) )
            {
                str = "PDW011";
            }
            //1strSql . AppendFormat ( "HAVING SUM(ISNULL({0},0))<PSX007 " ,str );
            //1strSql . Append ( ") SELECT * FROM CET " );
            strSql . AppendFormat ( " HAVING SUM(ISNULL({0},0))<PSX007 " ,str );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取报工清单  非常规
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOther ( List<string> inList ,string work )
        {
            string str = string . Join ( "," ,inList . ToArray ( ) );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT '' PSX001,PST001,PST002,PST003,PST028 PSX007,SUM(ISNULL(PDW007,0)) PDW007,PST028-SUM(ISNULL(PDW007,0)) DL,SUM(ISNULL(PDW008,0)) PDW008,PST028-SUM(ISNULL(PDW008,0)) XB,SUM(ISNULL(PDW009,0)) PDW009,PST028-SUM(ISNULL(PDW009,0)) CJ,SUM(ISNULL(PDW010,0)) PDW010,PST028-SUM(ISNULL(PDW010,0)) PB,SUM(ISNULL(PDW011,0)) PDW011,PST028-SUM(ISNULL(PDW011,0)) PC,GETDATE() PDW012,OPI005 PST004,'' PSX013 FROM MOXPST A LEFT JOIN MOXPDW B ON A.PST001=B.PDW002 AND A.PST002=B.PDW003 INNER JOIN MOXOPI C ON A.PST002=C.OPI001 WHERE A.idx IN ({0}) GROUP BY PST001,PST002,PST003,PST028,OPI005 " ,str );

            str = string . Empty;
            if ( work . Equals ( CarpenterBll . ColumnValues . bl_dl ) )
            {
                str = "PDW007";
            }
            else if ( work . Equals ( ColumnValues . bl_xb ) )
            {
                str = "PDW008";
            }
            else if ( work . Equals ( ColumnValues . bl_cj ) )
            {
                str = "PDW009";
            }
            else if ( work . Equals ( ColumnValues . bl_pb ) )
            {
                str = "PDW010";
            }
            else if ( work . Equals ( ColumnValues . bl_pc ) )
            {
                str = "PDW011";
            }
            strSql . AppendFormat ( " HAVING SUM(ISNULL({0},0))<PST028 " ,str );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取计划报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlan ( List<string> inList,string work )
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
            //SUM(PSX007) PSX007
            //1strSql . Append ( "WITH CET AS(SELECT PSX001,PSX003 PST001,PSX004 PST002,PSX005 PST003,PSX007,SUM(ISNULL(PDW007,0)) PDW007,PSX007-SUM(ISNULL(PDW007,0)) DL,SUM(ISNULL(PDW008,0)) PDW008,PSX007-SUM(ISNULL(PDW008,0)) XB,SUM(ISNULL(PDW009,0)) PDW009,PSX007-SUM(ISNULL(PDW009,0)) CJ,SUM(ISNULL(PDW010,0)) PDW010,PSX007-SUM(ISNULL(PDW010,0)) PB,SUM(ISNULL(PDW011,0)) PDW011,PSX007-SUM(ISNULL(PDW011,0)) PC,PDW012,OPI005 PST004,PSX013 FROM (SELECT MAX(PSW001) PSW001,PSW006,PSW002 FROM MOXPSW GROUP BY PSW006,PSW002) A INNER JOIN MOXPSX B ON A.PSW001=B.PSX001 LEFT JOIN MOXPDW C ON C.PDW002=B.PSX003 AND C.PDW003=B.PSX004 AND C.PDW016=B.PSX001 AND C.PDW017=B.PSX013 LEFT JOIN MOXOPI D ON B.PSX004=D.OPI001 INNER JOIN MOXPST E ON B.PSX003=E.PST001 AND B.PSX004=E.PST002 " );
            //1strSql . AppendFormat ( "WHERE E.idx IN ({1}) AND PSW006=1 AND (PSX012=1 OR PSX002='未完工') AND PSW002='{0}' " ,work ,str );
            //1strSql . Append ( "GROUP BY PSX001,PSX003,PSX004,PSX005,PDW012,OPI005,PSX007,PSX013 " );

            strSql . AppendFormat ( "WITH CET AS (SELECT MAX(A.idx) idx FROM MOXPSX A INNER JOIN MOXPST C ON A.PSX003=C.PST001 AND A.PSX004=C.PST002 INNER JOIN MOXPSW D ON A.PSX001=D.PSW001 WHERE C.idx IN ({0})  AND PSW002='{1}' GROUP BY PST001,PST002) " ,str ,work );
            strSql . AppendFormat ( "SELECT PSX001,PSX003 PST001,PSX004 PST002,PSX005 PST003,PSX007,SUM(ISNULL(PDW007,0)) PDW007,PSX007-SUM(ISNULL(PDW007,0)) DL,SUM(ISNULL(PDW008,0)) PDW008,PSX007-SUM(ISNULL(PDW008,0)) XB,SUM(ISNULL(PDW009,0)) PDW009,PSX007-SUM(ISNULL(PDW009,0)) CJ,SUM(ISNULL(PDW010,0)) PDW010,PSX007-SUM(ISNULL(PDW010,0)) PB,SUM(ISNULL(PDW011,0)) PDW011,PSX007-SUM(ISNULL(PDW011,0)) PC,GETDATE() PDW012,OPI005 PST004,PSX013 FROM MOXPSW A INNER JOIN MOXPSX B ON A.PSW001=B.PSX001   LEFT JOIN MOXPDW C ON C.PDW002=B.PSX003 AND C.PDW003=B.PSX004 AND C.PDW016=B.PSX001 AND C.PDW017=B.PSX013  LEFT JOIN MOXOPI D ON B.PSX004=D.OPI001  INNER JOIN MOXPST E ON B.PSX003=E.PST001 AND B.PSX004=E.PST002 INNER JOIN CET F ON B.idx=F.idx WHERE E.idx IN ({0}) AND PSW006=1 AND (PSX012=1 OR PSX002='未完工') AND PSW002='{1}' GROUP BY PSX001,PSX003,PSX004,PSX005,OPI005,PSX007,PSX013  " ,str ,work );

            str = string . Empty;
            if ( work . Equals ( ColumnValues.bl_dl ) )
            {
                str = "PDW007";
            }
            else if ( work . Equals ( ColumnValues . bl_xb ) )
            {
                str = "PDW008";
            }
            else if ( work . Equals ( ColumnValues . bl_cj ) )
            {
                str = "PDW009";
            }
            else if ( work . Equals ( ColumnValues . bl_pb ) )
            {
                str = "PDW010";
            }
            else if ( work . Equals ( ColumnValues . bl_pc ) )
            {
                str = "PDW011";
            }
            
            //1strSql . AppendFormat ( "HAVING SUM(ISNULL({0},0))<PSX007 " ,str );//SUM(PSX007)
            //1strSql . Append ( ") SELECT * FROM CET" );
            strSql . AppendFormat ( "  HAVING SUM(ISNULL({0},0))<PSX007 " ,str );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取报工人
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableDWPerson ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PDW014 FROM MOXPDW" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="workShop"></param>
        /// <param name="dateTime"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string workShop ,string dateTime ,string person )
        {
            string column = string . Empty;
            StringBuilder strSql = new StringBuilder ( );
            if ( workShop . Equals ( ColumnValues . bl_dl ) )
                column = "PDW007";
            else if ( workShop . Equals ( ColumnValues . bl_xb ) )
                column = "PDW008";
            else if ( workShop . Equals ( ColumnValues . bl_cj ) )
                column = "PDW009";
            else if ( workShop . Equals ( ColumnValues . bl_pb ) )
                column = "PDW010";
            else if ( workShop . Equals ( ColumnValues . bl_pc ) )
                column = "PDW011";
            strSql . Append ( "WITH CET AS (" );
            strSql . AppendFormat ( "SELECT PDW002,PDW003,PDW004,PST028,OPI006,PSX008,{0} PDW FROM MOXPDW A INNER JOIN MOXPSX B ON A.PDW002=B.PSX003 AND A.PDW003=B.PSX004 AND A.PDW016=B.PSX001 INNER JOIN MOXOPI C ON A.PDW003=C.OPI001 INNER JOIN MOXPSW D ON B.PSX001=D.PSW001 INNER JOIN MOXPST E ON A.PDW002=E.PST001 AND A.PDW003=E.PST002 " ,column );
            strSql . AppendFormat ( "WHERE PDW012='{0}' AND PDW014='{1}' AND PSW002='{2}' AND {3}>0" ,dateTime ,person ,workShop ,column );
            strSql . Append ( "),CFT AS (" );
            strSql . AppendFormat ( "SELECT A.PDW002,A.PDW003,SUM(A.{0}) PDW FROM MOXPDW A INNER JOIN CET B ON A.PDW002=B.PDW002 AND A.PDW003=B.PDW003 WHERE PDW012<'{1}' GROUP BY A.PDW002,A.PDW003) " ,column ,dateTime );
            strSql . Append ( " SELECT A.*,B.PDW PDWSUM,A.PST028-A.PDW-B.PDW RES FROM CET A LEFT JOIN CFT B ON A.PDW002=B.PDW002 AND A.PDW003=B.PDW003 ORDER BY A.PDW002,A.PDW003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="workShop"></param>
        /// <param name="dateTime"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo (string workShop,string dateTime,string person )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PDW012,PDW014,PSW002,CONVERT(FLOAT,SUM(PSX007*OPI004)) PSX FROM MOXPDW A INNER JOIN MOXPSX B ON A.PDW002=B.PSX003 AND A.PDW003=B.PSX004 AND A.PDW016=B.PSX001 INNER JOIN MOXOPI C ON A.PDW003=C.OPI001 INNER JOIN MOXPSW D ON B.PSX001=D.PSW001 " );
            strSql . AppendFormat ( "WHERE PDW012='{0}' AND PDW014='{1}' AND PSW002='{2}' " ,dateTime ,person ,workShop );
            strSql . Append ( "GROUP BY PDW012,PDW014,PSW002" );

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
            strSql . AppendFormat ( "SELECT PDW002,PDW003,PSW002 FROM MOXPDW A INNER JOIN MOXPSW B ON A.PDW016=B.PSW001 WHERE A.idx IN ({0})" ,idxStr );
            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                CarpenterEntity . PlanStockWorkPSWEntity model = new CarpenterEntity . PlanStockWorkPSWEntity ( );
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    model . PSW001 = dt . Rows [ i ] [ "PDW002" ] . ToString ( );
                    model . PSW011 = dt . Rows [ i ] [ "PDW003" ] . ToString ( );
                    model . PSW002 = dt . Rows [ i ] [ "PSW002" ] . ToString ( );
                    if ( model . PSW002 . Equals ( ColumnValues . bl_dl ) )
                    {
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE MOXPST SET PST006=NULL WHERE PST001='{0}' AND PST002='{1}'" ,model . PSW001 ,model . PSW011 );
                        SQLString . Add ( strSql ,null );
                    }
                    if ( model . PSW002 . Equals ( ColumnValues . bl_xb ) )
                    {
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE MOXPST SET PST008=NULL WHERE PST001='{0}' AND PST002='{1}'" ,model . PSW001 ,model . PSW011 );
                        SQLString . Add ( strSql ,null );
                    }
                    if ( model . PSW002 . Equals ( ColumnValues . bl_cj ) )
                    {
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE MOXPST SET PST010=NULL WHERE PST001='{0}' AND PST002='{1}'" ,model . PSW001 ,model . PSW011 );
                        SQLString . Add ( strSql ,null );
                    }
                    if ( model . PSW002 . Equals ( ColumnValues . bl_pb ) )
                    {
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE MOXPST SET PST012=NULL WHERE PST001='{0}' AND PST002='{1}'" ,model . PSW001 ,model . PSW011 );
                        SQLString . Add ( strSql ,null );
                    }
                    if ( model . PSW002 . Equals ( ColumnValues . bl_pc ) )
                    {
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE MOXPST SET PST014=NULL WHERE PST001='{0}' AND PST002='{1}'" ,model . PSW001 ,model . PSW011 );
                        SQLString . Add ( strSql ,null );
                    }
                }
            }
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPDW " );
            strSql . Append ( "WHERE idx IN (" + idxStr + ")" );
            SQLString . Add ( strSql ,null );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

    }
}
