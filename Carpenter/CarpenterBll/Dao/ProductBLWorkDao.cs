using System . Data;
using System . Text;
using StudentMgr;

namespace CarpenterBll . Dao
{
    public class ProductBLWorkDao
    {
        /// <summary>
        /// get table form bl
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PST001,PST002,PST003 FROM MOXPST" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data table from moxprd
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getDataTableToView (string strWhere )
        {
            //满足条件  必须是完工标记的  必须是扫描之后审核过的  必须是开料周计划审核过的
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PRD007 PBW001,PRD008 PBW002,PRD009 PBW003,CUU003 PBW004,PRD011 PBW005,WPC006+'*'+WPC009+'*'+WPC012 PBW013,WPC016 PBW006,PRD012 PBW007,PRD003 PBW008,PRD004 PBW010,PRD005 PBW014,PRD013 PBW009,PRD019 PBW011,PRD016 PBW012 FROM MOXPRD A INNER JOIN MOXWPC B ON A.PRD006=B.WPC005 AND A.PRD007=B.WPC001 AND A.PRD008=B.WPC002 INNER JOIN MOXCUU C ON A.PRD007=C.CUU001 AND A.PRD008=C.CUU002 INNER JOIN MOXCUT D ON C.CUU001=D.CUT001 " );
            strSql . AppendFormat ( "WHERE PRD014=0 AND PRD020=1 AND CUT008=1 {0}" ,strWhere );
            strSql . Append ( " ORDER BY PBW001,PBW002,PBW005,PBW008,PBW014,PBW009" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
