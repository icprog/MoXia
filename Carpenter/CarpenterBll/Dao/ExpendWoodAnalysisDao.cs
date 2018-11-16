using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;

namespace CarpenterBll . Dao
{
    public class ExpendWoodAnalysisDao
    {
        /// <summary>
        /// get the batch num from databse 
        /// </summary>
        /// <returns></returns>
        public DataTable getTableBatchNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CUT001 FROM MOXCUT WHERE CUT008=1 ORDER BY CUT001 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get datatable from database to view
        /// </summary>
        /// <param name="batchNum"></param>
        /// <returns></returns>
        public DataTable getTableView ( string batchNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS(" );
            strSql . Append ( "SELECT CUT001,OPI003,OPI006,SUM(CUU003*WOB005) WOB005 FROM MOXWOB A INNER JOIN MOXCUU B ON A.WOB001=B.CUU002 INNER JOIN MOXCUT C ON B.CUU001=C.CUT001 INNER JOIN MOXOPI D ON A.WOB001=D.OPI001 " );
            strSql . AppendFormat ( "WHERE A.idx NOT IN (SELECT idx FROM MOXWOB WHERE WOB004 LIKE '%包芯%') AND CUT001='{0}' " ,batchNum );
            strSql . Append ( "GROUP BY CUT001,OPI003,OPI006)," );
            strSql . Append ( "CFT AS(" );
            strSql . Append ( "SELECT SUM(EXW006) EXW006,EXW002,EXW003,OPI006 FROM (SELECT EXW002,EXW003,OPI006,EXW006 FROM MOXEXW A INNER JOIN MOXCUT B ON A.EXW002=B.CUT001 INNER JOIN MOXCUU C ON B.CUT001=C.CUU001 INNER JOIN MOXOPI D ON C.CUU002=D.OPI001 AND A.EXW003=D.OPI003 " );
            strSql . AppendFormat ( "WHERE CUT001='{0}' " ,batchNum );
            strSql . Append ( "GROUP BY EXW002,EXW003,OPI006,EXW006) A GROUP BY EXW002,EXW003,OPI006 )," );
            strSql . Append ( "CHT AS(" );
            strSql . Append ( "SELECT CUT001,OPI003,OPI006,SUM(CUU003*WOB005) WOB004 FROM MOXWOB A INNER JOIN MOXCUU B ON A.WOB001=B.CUU002 INNER JOIN MOXCUT C ON B.CUU001=C.CUT001 INNER JOIN MOXOPI D ON A.WOB001=D.OPI001 " );
            strSql . AppendFormat ( "WHERE WOB004 LIKE '%包芯%' AND CUT001='{0}'" ,batchNum );
            strSql . Append ( "GROUP BY CUT001,OPI003,OPI006) " );
            strSql . Append ( "SELECT A.CUT001 PIH,A.OPI003 MCLX,A.OPI006 CPXL,A.WOB005 LHY,B.EXW006 SHY,CASE WHEN EXW006=0 THEN 0 ELSE CONVERT(DECIMAL(11,2),WOB005/EXW006) END BFB,ISNULL(C.WOB004,0) BXH FROM CET A INNER JOIN CFT B ON A.CUT001=B.EXW002 AND A.OPI003=B.EXW003 AND A.OPI006=B.OPI006 LEFT JOIN CHT C ON A.CUT001=C.CUT001 AND A.OPI003=C.OPI003 AND A.OPI006=C.OPI006" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


    }
}
