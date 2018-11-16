
using System . Text;
using StudentMgr;
using System . Data;
using System . Collections . Generic;
using System . Collections;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class PlanMachinWeekDailyWorkDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public DataTable GetOnly ( string columnName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM MOXPME ORDER BY {0}" ,columnName );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableView (string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,PME001,PME002,PME003,PME004,PME005,PST028,PME006,PME007,CONVERT(FLOAT,ISNULL(OPI004,0)) OPI004,CONVERT(FLOAT,ISNULL(OPI004,0)*PME007) U0,PME012,OPI006,OPI007,CASE PME008 WHEN 0 THEN '正式' ELSE '预排' END PME008,PME009,PME014 FROM MOXPME A LEFT JOIN MOXOPI B ON A.PME003=B.OPI001  INNER JOIN MOXPST C ON A.PME002=C.PST001 AND A.PME003=C.PST002 " );
            strSql . Append ( " WHERE " + strWhere );
            strSql . Append ( " ORDER BY PME001 DESC,PME002 DESC,PME003 DESC " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

        }

        /// <summary>
        /// 获取周计划报工清单  常规产品
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeekJ ( List<string> inList )
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
            strSql . AppendFormat ( "WITH CET AS (SELECT PMD001,PMD003,PMD004,PMD002,PMC007 FROM MOXPMD D INNER JOIN MOXPMC E ON D.PMD001=E.PMC001 INNER JOIN MOXPST F ON D.PMD003=F.PST001 AND D.PMD004=F.PST002 WHERE F.idx IN ({0}) AND PMD010=0 GROUP BY PMD003,PMD004,PMD001,PMD002,PMC007) ,CFT AS( SELECT * FROM CET WHERE PMD001+PMD003+PMD004 NOT IN (SELECT PMD002+PMD003+PMD004 FROM CET) AND PMC007=1)" ,str );
            strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST005,PST028,PST028-SUM(ISNULL(PME007,0)) DL,GETDATE() PME012,OPI006,OPI007,SUM(ISNULL(PME007,0)) PME007,PMD001,PMD002 FROM MOXPST A LEFT JOIN MOXPME B ON A.PST001=B.PME002 AND A.PST002=B.PME003 LEFT JOIN MOXOPI C ON A.PST002=C.OPI001 INNER JOIN CFT D ON A.PST001=D.PMD003 AND A.PST002=D.PMD004  " );
            strSql . AppendFormat ( "WHERE A.idx IN ({0}) " ,str );
            strSql . Append ( " GROUP BY PST001,PST002,PST003,PST004,PST005,PST028,OPI006,OPI007,PMD001,PMD002 " );
            strSql . Append ( " HAVING SUM(ISNULL(PME007,0))<PST028 ORDER BY PST001 DESC,PST002 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

        }

        /// <summary>
        /// 获取周计划报工清单  非常规产品
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeekJOther ( List<string> inList )
        {
            string str = string . Join ( "," ,inList . ToArray ( ) );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PST001,PST002,PST003,PST004,PST005,PST028,OPI006,OPI007,SUM(ISNULL(PME007,0)) PME007,'' PMD001,PST028-SUM(ISNULL(PME007,0)) DL,GETDATE() PME012 FROM MOXPST A INNER JOIN MOXOPI B ON A.PST002=B.OPI001 LEFT JOIN MOXPME C ON A.PST001=C.PME002 AND A.PST002=C.PME003 WHERE A.idx IN ({0}) GROUP BY PST001,PST002,PST003,PST004,PST005,PST028,OPI006,OPI007  HAVING PST028-SUM(ISNULL(PME007,0))>0 " ,str );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取周计划预排报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeekDailyJ ( List<string> inList )
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
            strSql . Append ( "SELECT PST001,PST002,PST003,PST004,PST005,PST028,PST028-SUM(ISNULL(PME007,0)) DL,GETDATE() PME012,OPI006,OPI007,SUM(ISNULL(PME007,0)) PME007,PMD001 FROM MOXPST A LEFT JOIN MOXPME B ON A.PST001=B.PME002 AND A.PST002=B.PME003 LEFT JOIN MOXOPI C ON A.PST002=C.OPI001 INNER JOIN (SELECT PMD003,PMD004,PMD001 FROM MOXPMD D INNER JOIN MOXPMC E ON D.PMD001=E.PMC001 WHERE PMD010=1 AND PMC007=1 GROUP BY PMD003,PMD004,PMD001 ) D ON A.PST001=D.PMD003 AND A.PST002=D.PMD004  " );
            strSql . AppendFormat ( "WHERE A.idx IN ({0}) " ,str );
            strSql . Append ( " GROUP BY PST001,PST002,PST003,PST004,PST005,PST028,OPI006,OPI007,PMD001 " );
            strSql . Append ( " HAVING SUM(ISNULL(PME007,0))<PST028 ORDER BY PST001 DESC,PST002 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Delete ( List<string> strList )
        {
            ArrayList SQLString = new ArrayList ( );
            string idxList = string . Empty;
            foreach ( string s in strList )
            {
                if ( idxList == string . Empty )
                    idxList = s;
                else
                    idxList = idxList + "," + s;
            }

            StringBuilder strSql = new StringBuilder ( );
            DataTable dt = SqlHelper . ExecuteDataTable ( "SELECT PME002,PME003 FROM MOXPME WHERE PME008=0 AND idx IN (" + idxList + ")" );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                CarpenterEntity . PlanMachinPMDEntity _pmd = new CarpenterEntity . PlanMachinPMDEntity ( );
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _pmd . PMD003 = dt . Rows [ i ] [ "PME002" ] . ToString ( );
                    _pmd . PMD004 = dt . Rows [ i ] [ "PME003" ] . ToString ( );
                    edit_pst ( SQLString ,strSql ,_pmd );
                    //edit_prs ( SQLString ,strSql ,_pmd );
                }
            }

            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPME " );
            strSql . Append ( "WHERE idx IN (" + idxList + ")" );
            SQLString . Add ( strSql . ToString ( ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void edit_pst (ArrayList SQLString ,StringBuilder strSql ,CarpenterEntity . PlanMachinPMDEntity model)
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXPST SET PST032=0,PST024=NULL WHERE PST001='{0}' AND PST002='{1}'" ,model . PMD003 ,model . PMD004 );

            SQLString . Add ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除机加工实际完成时间
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="_model"></param>
        void edit_prs ( ArrayList SQLString ,StringBuilder strSql ,CarpenterEntity . PlanMachinPMDEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPRS SET " );
            strSql . Append ( "PRS010=NULL " );
            strSql . AppendFormat ( "WHERE PRS001='{0}' AND PRS002='{1}'" ,_model . PMD003 ,_model . PMD004 );

            SQLString . Add ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 获取年
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableYear ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT SUBSTRING(PME001,0,5) PME001 FROM MOXPME" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取操作者
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePerson ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PME014 FROM MOXPME" );

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
            strSql . Append ( "SELECT DISTINCT PMC009 FROM MOXPME A INNER JOIN MOXPMD B ON A.PME002=B.PMD003 AND A.PME003=B.PMD004 INNER JOIN MOXPMC C ON B.PMD001=C.PMC001  " );
            strSql . AppendFormat ( "WHERE PME001 LIKE '{0}%'" ,year );

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
            strSql . Append ( "SELECT PMC009,PME014,CONVERT(FLOAT,SUM(PMD007*OPI004)) PSX FROM MOXPME A INNER JOIN MOXPMD B ON A.PME002=B.PMD003 AND A.PME003=B.PMD004 AND A.PME009=B.PMD001 INNER JOIN MOXOPI C ON A.PME003=C.OPI001 INNER JOIN MOXPMC D ON B.PMD001=D.PMC001 " );
            strSql . AppendFormat ( "WHERE PME001 LIKE '{0}%' AND PMC009='{1}' AND  PME014='{2}' " ,year ,week ,userName );
            strSql . Append ( " GROUP BY PMC009,PME014" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public DataTable GetDataTablePrintOne ( string date ,string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT '' PMC009,PME014,CONVERT(FLOAT,SUM(PME007*OPI004)) PSX FROM MOXPME A INNER JOIN MOXOPI B ON A.PME003=B.OPI001 " );
            strSql . AppendFormat ( "WHERE CONVERT(NVARCHAR(20),PME012,112)='{0}' AND  PME014='{1}' " ,date ,userName );
            strSql . Append ( " GROUP BY PME014" );

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
            strSql . AppendFormat ( "SELECT A.PME002,A.PME003,PME004,OPI003,PST028,PME006,PME007 PDK,PME012,PMD009,PD FROM MOXPME A INNER JOIN MOXOPI B ON A.PME003=B.OPI001 INNER JOIN MOXPMD C ON A.PME002=C.PMD003 AND A.PME003=C.PMD004 INNER JOIN MOXPMC D ON C.PMD001=D.PMC001 INNER JOIN (SELECT SUM(PME007) PD,PME002,PME003 FROM MOXPME  WHERE PME001 LIKE '{0}%' AND PME014='{1}' GROUP BY PME002,PME003) E ON A.PME002=E.PME002 AND A.PME003=E.PME003  INNER JOIN MOXPST F ON A.PME002=F.PST001 AND A.PME003=F.PST002 WHERE PME001 LIKE '{0}%' AND PMC009='{2}' AND PME014='{1}'" ,year ,userName ,week );
            strSql . Append ( " ORDER BY A.PME002,A.PME003" );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public DataTable GetDataTablePrintTwo ( string date ,string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT A.PME002,A.PME003,PME004,OPI003,PST028,PME006,PME007 PDK,PME012,PST025 PMD009,PD FROM MOXPME A INNER JOIN MOXOPI B ON A.PME003=B.OPI001 INNER JOIN (SELECT SUM(PME007) PD,PME002,PME003 FROM MOXPME  WHERE CONVERT(NVARCHAR(20),PME012,112)='{0}' AND PME014='{1}' GROUP BY PME002,PME003) E ON A.PME002=E.PME002 AND A.PME003=E.PME003  INNER JOIN MOXPST F ON A.PME002=F.PST001 AND A.PME003=F.PST002 WHERE CONVERT(NVARCHAR(20),PME012,112)='{0}' AND PME014='{1}'" ,date ,userName );
            strSql . Append ( " ORDER BY A.PME002,A.PME003" );

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
            strSql . AppendFormat ( "SELECT idx FROM MOXPST WHERE NOT EXISTS (SELECT A.idx FROM MOXPST A INNER JOIN MOXPMD B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 WHERE A.idx IN ({0}) AND PMD010=0) AND idx IN ({0})" ,strIdx );

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
        /// 获取机加工报工人
        /// </summary>
        /// <returns></returns>
        public DataTable getTableForName ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PME014 NAME FROM MOXPME" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
