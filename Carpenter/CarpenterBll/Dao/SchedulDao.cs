using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class SchedulDao
    {
        //AIS20091231164539
        private string conS="Data Source=192.168.1.188;Initial Catalog=AIS20091231164539;User Id=sa;Password=123.com";
        //private string conS="Data Source=127.0.0.1;Initial Catalog=AIS20091231164539;User Id=sa;Password=1";
        /// <summary>
        /// get data from database for StoredProcedure
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( )
        {
            /*
            Exec [U_SearchQty] 
            '2017-09-26',
            2017,
            '51-1.001.01.001',
            '65-2.012.01.001',
            '01',
            'C01'
            */

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MIN(OPI001) OPI001,MAX(OPI001) OPI002 FROM MOXOPI WHERE OPI011=0" );
            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                SqlHelper . StoreProcedure ( "U_SearchQty" );
                SqlParameter [ ] parameter = {
                new SqlParameter("FDate", CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyy-MM-dd" )),
                new SqlParameter("FYear",CarpenterBll . UserInformation . dt ( ) . Year),
                new SqlParameter("FNumberStart",dt . Rows [ 0 ] [ "OPI001" ] . ToString ( )),
                new SqlParameter("FNumberEnd",dt . Rows [ 0 ] [ "OPI002" ] . ToString ( )),
                new SqlParameter("FStockStart","01"),
                new SqlParameter("FStockEnd", "C01")
                };
                //parameter [ 0 ] . Value = CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyy-MM-dd" );
                //parameter [ 1 ] . Value = CarpenterBll . UserInformation . dt ( ) . Year;
                //parameter [ 2 ] . Value = dt . Rows [ 0 ] [ "OPI001" ] . ToString ( );
                //parameter [ 3 ] . Value = dt . Rows [ 0 ] [ "OPI002" ] . ToString ( );
                //parameter [ 4 ] . Value = "01";
                //parameter [ 5 ] . Value = "C01";

                dt = SqlHelper . ExecuteNoStore ( conS ,parameter );
            }
            else
                return null;

            return dt;
        }

        /// <summary>
        /// get data from database 
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOne ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MIN(OPI001) OPI001,MAX(OPI001) OPI002 FROM MOXOPI WHERE OPI011=0" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . Append ( "select x1.FItemID,x1.FNumber ,CONVERT(DECIMAL(11,0),ISNULL(a0.FQty,0)) as FQty0 ,CONVERT(DECIMAL(11,0),ISNULL(a1.FQty,0)) as FQty1 ,CONVERT(DECIMAL(11,0),ISNULL(a2.FQty,0)) as FQty2,CONVERT(DECIMAL(11,0),ISNULL(a3.FQty,0)) as FQty3,CONVERT(DECIMAL(11,0),ISNULL(a4.FQty,0)) as FQty4,CONVERT(DECIMAL(11,0),ISNULL(a5.FQty,0)) as FQty5,CONVERT(DECIMAL(11,0),SUM(ISNULL(a0.FQty,0)+ISNULL(a1.FQty,0)+ISNULL(a2.FQty,0)+ISNULL(a3.FQty,0)+ISNULL(a4.FQty,0)+ISNULL(a5.FQty,0))) FQY from t_icitem x1 " );
                //今天
                strSql . Append ( "left join (select t1.FitemID, ISNULL(SUM(t1.FQty-t1.FStockQty),0) as FQty from SEOrderEntry t1 inner join SEOrder t2 on t1.FInterID = t2.FInterID where ISNULL(t1.FMRPClosed,0) = 0 and t2.FClosed = 0 and t2.FCancellation = 0 and Convert(VARCHAR(10),t1.FDate,21) >= Convert(VARCHAR(10),GETDATE(),21) and Convert(VARCHAR(10),t1.FDate,21) <= Convert(VARCHAR(10),GETDATE(),21) group by t1.FItemID ) a0 on x1.FitemID = a0.FItemID  " );
                //10天
                strSql . Append ( "left join (select t1.FitemID, ISNULL(SUM(t1.FQty-t1.FStockQty),0) as FQty from SEOrderEntry t1 inner join SEOrder t2 on t1.FInterID = t2.FInterID where ISNULL(t1.FMRPClosed,0) = 0 and t2.FClosed = 0 and t2.FCancellation = 0 and Convert(VARCHAR(10),t1.FDate,21) >= Convert(VARCHAR(10),GETDATE()+1,21) and Convert(VARCHAR(10),t1.FDate,21) <= Convert(VARCHAR(10),GETDATE()+10,21) group by t1.FItemID ) a1 on x1.FitemID = a1.FItemID " );
                //20天
                strSql . Append ( "left join (select t1.FitemID, ISNULL(SUM(t1.FQty-t1.FStockQty),0) as FQty from SEOrderEntry t1 inner join SEOrder t2 on t1.FInterID = t2.FInterID where ISNULL(t1.FMRPClosed,0) = 0 and t2.FClosed = 0 and t2.FCancellation = 0  and Convert(VARCHAR(10),t1.FDate,21) >= Convert(VARCHAR(10),GETDATE()+11,21) and Convert(VARCHAR(10),t1.FDate,21) <= Convert(VARCHAR(10),GETDATE()+21,21) group by t1.FItemID ) a2 on x1.FitemID = a2.FItemID  " );
                //30天
                strSql . Append ( "left join (select t1.FitemID, ISNULL(SUM(t1.FQty-t1.FStockQty),0) as FQty from SEOrderEntry t1 inner join SEOrder t2 on t1.FInterID = t2.FInterID  where ISNULL(t1.FMRPClosed,0) = 0 and t2.FClosed = 0 and t2.FCancellation = 0 and Convert(VARCHAR(10),t1.FDate,21) >= Convert(VARCHAR(10),GETDATE()+22,21) and Convert(VARCHAR(10),t1.FDate,21) <= Convert(VARCHAR(10),GETDATE()+31,21) group by t1.FItemID ) a3 on x1.FitemID = a3.FItemID " );
                //60天
                strSql . Append ( "left join (select t1.FitemID, ISNULL(SUM(t1.FQty-t1.FStockQty),0) as FQty from SEOrderEntry t1 inner join SEOrder t2 on t1.FInterID = t2.FInterID where ISNULL(t1.FMRPClosed,0) = 0 and t2.FClosed = 0 and t2.FCancellation = 0 and Convert(VARCHAR(10),t1.FDate,21) >= Convert(VARCHAR(10),GETDATE()+32,21) and Convert(VARCHAR(10),t1.FDate,21) <= Convert(VARCHAR(10),GETDATE()+61,21) group by t1.FItemID ) a4 on x1.FitemID = a4.FItemID " );
                //>60天
                strSql . Append ( "left join (select t1.FitemID, ISNULL(SUM(t1.FQty-t1.FStockQty),0) as FQty from SEOrderEntry t1 inner join SEOrder t2 on t1.FInterID = t2.FInterID where ISNULL(t1.FMRPClosed,0) = 0 and t2.FClosed = 0 and t2.FCancellation = 0  and Convert(VARCHAR(10),t1.FDate,21) >= Convert(VARCHAR(10),GETDATE()+62,21) group by t1.FItemID ) a5 on x1.FitemID = a5.FItemID " );
                strSql . AppendFormat ( "where x1.FDeleted = 0  and x1.FNumber >=  '{0}'  and x1.FNumber <=  '{1}' GROUP BY x1.FItemID,x1.FNumber,ISNULL(a0.FQty,0),ISNULL(a1.FQty,0),ISNULL(a2.FQty,0),ISNULL(a3.FQty,0),ISNULL(a4.FQty,0),ISNULL(a5.FQty,0) order by x1.FNumber " ,dt . Rows [ 0 ] [ "OPI001" ] . ToString ( ) ,dt . Rows [ 0 ] [ "OPI002" ] . ToString ( ) );

                dt = SqlHelper . ExecuteDataTable ( conS ,strSql . ToString ( ) );
                return dt;
            }
            else
                return null;
        }

        /// <summary>
        /// get data from database 
        /// </summary>
        /// <returns></returns>
        public DataTable getTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CUU001,CUU002,CUU003-SUM(ISNULL(PWF016,0)) CUU FROM MOXCUU A INNER JOIN MOXOPI B ON A.CUU002=B.OPI001 LEFT JOIN MOXPWF C ON A.CUU001=C.PWF002 AND A.CUU002=C.PWF003 INNER JOIN MOXCUT D ON A.CUU001=D.CUT001 WHERE OPI009='常规' AND CUT008=1 GROUP BY CUU003,CUU001,CUU002 HAVING CUU003>SUM(ISNULL(PWF016,0))  order by CUU001,CUU002" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
