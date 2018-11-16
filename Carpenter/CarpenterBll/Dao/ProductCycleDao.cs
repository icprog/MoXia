using System . Data;
using System . Text;
using StudentMgr;

namespace CarpenterBll . Dao
{
    public class ProductCycleDao
    {
        /// <summary>
        /// get data from database to view
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable getTableView ( string piNum,string pinNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT CUU001,CUU002,CUU008,CUU009,OPI006,OPI007,CUU003,CASE WHEN PRD013 IS NULL THEN CUT002 ELSE PRD013 END PRD013,K.PWF012,CASE WHEN PRD013 IS NULL THEN DATEDIFF(DAY,CUT002,MAX(PDK012)) ELSE DATEDIFF(DAY,PRD013,MAX(PDK012)) END PDK012,DATEDIFF(DAY,MAX(PDK012),MAX(PME012)) PME012,DATEDIFF(DAY,MAX(PME012),MAX(PLF012)) PLF012,DATEDIFF(DAY,MAX(PLF012),D.PWF012) PWF012M,DATEDIFF(DAY,D.PWF012,K.PWF012) PWF012Z FROM " );
            strSql . Append ( "MOXCUU A LEFT JOIN MOXCUT L ON A.CUU001=L.CUT001 LEFT JOIN MOXOPI B ON A.CUU002=B.OPI001 " );
            if ( string . IsNullOrEmpty ( piNum ) && string . IsNullOrEmpty ( pinNum ) )
                strSql . Append ( "LEFT JOIN (SELECT MIN(PRD013) PRD013,PRD007,PRD008 FROM MOXPRD WHERE PRD014=1 AND PRD020=1 GROUP BY PRD007,PRD008) C ON A.CUU001=C.PRD007 AND A.CUU002=C.PRD008 " );
            else if ( !string . IsNullOrEmpty ( piNum ) && !string . IsNullOrEmpty ( pinNum ) )
                strSql . AppendFormat ( "LEFT JOIN (SELECT MIN(PRD013) PRD013,PRD007,PRD008 FROM MOXPRD WHERE PRD014=1 AND PRD020=1 AND PRD007='{0}' AND PRD008='{1}' GROUP BY PRD007,PRD008) C ON A.CUU001=C.PRD007 AND A.CUU002=C.PRD008 " ,piNum ,pinNum );
            else if ( !string . IsNullOrEmpty ( piNum ) && string . IsNullOrEmpty ( pinNum ) )
                strSql . AppendFormat ( "LEFT JOIN (SELECT MIN(PRD013) PRD013,PRD007,PRD008 FROM MOXPRD WHERE PRD014=1 AND PRD020=1 AND PRD007='{0}' GROUP BY PRD007,PRD008) C ON A.CUU001=C.PRD007 AND A.CUU002=C.PRD008 " ,piNum );
            else if ( !string . IsNullOrEmpty ( pinNum ) && string . IsNullOrEmpty ( piNum ) )
                strSql . AppendFormat ( "LEFT JOIN (SELECT MIN(PRD013) PRD013,PRD007,PRD008 FROM MOXPRD WHERE PRD014=1 AND PRD020=1 AND PRD008='{0}' GROUP BY PRD007,PRD008) C ON A.CUU001=C.PRD007 AND A.CUU002=C.PRD008 " ,pinNum );
            strSql . Append ( "LEFT JOIN MOXPLT E ON A.CUU001=E.PLT003 AND A.CUU002=E.PLT004 LEFT JOIN MOXPDK F ON E.PLT001=F.PDK009 AND E.PLT003=F.PDK002 AND E.PLT004=F.PDK003 LEFT JOIN MOXPMD G ON A.CUU001=G.PMD003 AND A.CUU002=G.PMD004 LEFT JOIN MOXPME H ON G.PMD001=H.PME009 AND G.PMD003=H.PME002 AND G.PMD004=H.PME003 LEFT JOIN MOXPLE I ON A.CUU001=I.PLE003 AND A.CUU002=I.PLE004 LEFT JOIN MOXPLF J ON I.PLE001=J.PLF010 AND I.PLE003=J.PLF002 AND I.PLE004=J.PLF003 " );
            if ( string . IsNullOrEmpty ( piNum ) && string . IsNullOrEmpty ( pinNum ) )
                strSql . Append ( "LEFT JOIN (SELECT MAX(PWF012) PWF012,PWE003,PWE004 FROM MOXPWD LEFT JOIN MOXPWE ON PWD001=PWE001 LEFT JOIN MOXPWF ON PWE001=PWF017 AND PWE003=PWF002 AND PWE004=PWF003  WHERE PWD002='面漆' GROUP BY PWE003,PWE004 ) D ON A.CUU001=D.PWE003 AND A.CUU002=D.PWE004 LEFT JOIN (SELECT MAX(PWF012) PWF012,PWE003,PWE004 FROM MOXPWD LEFT JOIN MOXPWE ON PWD001=PWE001 LEFT JOIN MOXPWF ON  PWE003=PWF002 AND PWE004=PWF003  GROUP BY PWE003,PWE004 ) K ON A.CUU001=K.PWE003 AND A.CUU002=K.PWE004 " );//WHERE  PWD002='包装' PWE001=PWF017 AND
            else if ( !string . IsNullOrEmpty ( piNum ) && !string . IsNullOrEmpty ( pinNum ) )
                strSql . AppendFormat ( "LEFT JOIN (SELECT MAX(PWF012) PWF012,PWE003,PWE004 FROM MOXPWD LEFT JOIN MOXPWE ON PWD001=PWE001 LEFT JOIN MOXPWF ON PWE001=PWF017 AND PWE003=PWF002 AND PWE004=PWF003  WHERE PWD002='面漆' AND PWE003='{0}' AND PWE004='{1}' GROUP BY PWE003,PWE004 ) D ON A.CUU001=D.PWE003 AND A.CUU002=D.PWE004 LEFT JOIN (SELECT MAX(PWF012) PWF012,PWE003,PWE004 FROM MOXPWD LEFT JOIN MOXPWE ON PWD001=PWE001 LEFT JOIN MOXPWF ON PWE003=PWF002 AND PWE004=PWF003 WHERE PWE003='{0}' AND PWE004='{1}' GROUP BY PWE003,PWE004 ) K ON A.CUU001=K.PWE003 AND A.CUU002=K.PWE004 " ,piNum ,pinNum );//  PWD002='包装' AND  PWE001=PWF017 AND
            else if(!string.IsNullOrEmpty(piNum) && string.IsNullOrEmpty(pinNum))
                strSql . AppendFormat ( "LEFT JOIN (SELECT MAX(PWF012) PWF012,PWE003,PWE004 FROM MOXPWD LEFT JOIN MOXPWE ON PWD001=PWE001 LEFT JOIN MOXPWF ON PWE001=PWF017 AND PWE003=PWF002 AND PWE004=PWF003  WHERE PWD002='面漆' AND PWE003='{0}' GROUP BY PWE003,PWE004 ) D ON A.CUU001=D.PWE003 AND A.CUU002=D.PWE004 LEFT JOIN (SELECT MAX(PWF012) PWF012,PWE003,PWE004 FROM MOXPWD LEFT JOIN MOXPWE ON PWD001=PWE001 LEFT JOIN MOXPWF ON PWE003=PWF002 AND PWE004=PWF003  WHERE PWE003='{0}' GROUP BY PWE003,PWE004 ) K ON A.CUU001=K.PWE003 AND A.CUU002=K.PWE004 " ,piNum  );//WHERE  PWD002='包装' PWE001=PWF017 AND 
            else if ( string . IsNullOrEmpty ( piNum ) && !string . IsNullOrEmpty ( pinNum ) )
                strSql . AppendFormat ( "LEFT JOIN (SELECT MAX(PWF012) PWF012,PWE003,PWE004 FROM MOXPWD LEFT JOIN MOXPWE ON PWD001=PWE001 LEFT JOIN MOXPWF ON PWE001=PWF017 AND PWE003=PWF002 AND PWE004=PWF003  WHERE PWD002='面漆' AND PWE004='{0}' GROUP BY PWE003,PWE004 ) D ON A.CUU001=D.PWE003 AND A.CUU002=D.PWE004 LEFT JOIN (SELECT MAX(PWF012) PWF012,PWE003,PWE004 FROM MOXPWD LEFT JOIN MOXPWE ON PWD001=PWE001 LEFT JOIN MOXPWF ON PWE003=PWF002 AND PWE004=PWF003 WHERE PWE004='{0}' GROUP BY PWE003,PWE004 ) K ON A.CUU001=K.PWE003 AND A.CUU002=K.PWE004 " ,pinNum );// WHERE  PWD002='包装' PWE001=PWF017 AND
            if ( !string . IsNullOrEmpty ( piNum ) && !string . IsNullOrEmpty ( pinNum ) )
                strSql . AppendFormat ( " WHERE CUU001='{0}' AND CUU002='{1}' " ,piNum ,pinNum );
            else if ( !string . IsNullOrEmpty ( piNum ) && string . IsNullOrEmpty ( pinNum ) )
                strSql . AppendFormat ( " WHERE CUU001='{0}' " ,piNum );
            else if ( string . IsNullOrEmpty ( piNum ) && !string . IsNullOrEmpty ( pinNum ) )
                strSql . AppendFormat ( " WHERE CUU002='{0}' " ,pinNum );
            strSql . AppendFormat ( "GROUP BY CUU001,CUU002,CUU008,CUU009,OPI006,OPI007,CUU003,C.PRD013,D.PWF012,K.PWF012,CUT002 )" );
            strSql . Append ( "SELECT *,ISNULL(PDK012,0)+ISNULL(PME012,0)+ISNULL(PLF012,0)+ISNULL(PWF012M,0)+ISNULL(PWF012Z,0) U0 FROM CET ORDER BY CUU001,CUU002" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from database to export
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable getTableExport ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CONVERT(VARCHAR,YEAR(PRD013))+'年产品周期表' PRD ,A.CUU001,A.CUU002,A.CUU008,A.CUU009,A.CUU003,PRD013,PWF012,DATEDIFF(DAY,PRD013,PWF012) CHA FROM MOXCUU A INNER JOIN (SELECT MIN(PRD013) PRD013,PRD007,PRD008 FROM MOXPRD GROUP BY PRD007,PRD008) B ON A.CUU001=B.PRD007 AND A.CUU002=B.PRD008 INNER JOIN MOXPWF C ON A.CUU001=C.PWF002 AND A.CUU002=C.PWF003 " );
            strSql . AppendFormat ( "WHERE YEAR(PRD013)={0} " ,year );
            strSql . Append ( "GROUP BY  A.CUU001,A.CUU002,A.CUU008,A.CUU009,A.CUU003,PRD013,PWF012 HAVING SUM(PWF016)=CUU003 ORDER BY CUU001,CUU002" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from database to query column value
        /// </summary>
        /// <returns></returns>
        public DataTable getTableColumn ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CUU001,CUU002,OPI002 FROM MOXCUU A INNER JOIN MOXOPI B ON A.CUU002=B.OPI001 INNER JOIN MOXCUT D ON A.CUU001=D.CUT001 WHERE CUT008=1" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
    }
}
