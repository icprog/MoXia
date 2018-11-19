using System . Data;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;
using System . Collections;
using System . Threading . Tasks;

namespace CarpenterBll . Dao
{
    public class ProductScheduleDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            Task ts = new Task ( updateSign );
            ts . Start ( );

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT  PRS001,PRS002,PRS003,PRS004,OPI006,OPI007,CUU003,CUU005,CUT002,PRS006,PRS007,PST016,PRS009,PST024,PAS007,PAS011,PAS012,PDP006,PDP007,PDP009,PDP010,PDP012,PDP013,PDP015,PDP016,PDP018,PDP019,PDP022,PDP023,CASE WHEN PST031=0 THEN '未完工' WHEN PST031=1 THEN '完工' ELSE '未排' END PST031,CASE WHEN PST032=0 THEN '未完工' WHEN PST032=1 THEN '完工' ELSE '未排' END PST032,CASE CONVERT(BIT,CASE WHEN ISNULL(PAS011,0)=PAS016 THEN 1 ELSE 0 END) WHEN 0 THEN '未完工' WHEN 1 THEN '完工' END PAS017,CASE WHEN PDP026=0 THEN '未完工' WHEN PDP026=1 THEN '完工' ELSE '未排' END PDP026,CASE WHEN COUNT(WPC004)=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),COUNT(PRD011)*1.0/COUNT(WPC004)*100) END COU,PRS031 FROM MOXPRS A LEFT JOIN MOXOPI B ON A.PRS002=B.OPI001 LEFT JOIN MOXCUU C ON A.PRS001=C.CUU001 AND A.PRS002=C.CUU002 LEFT JOIN MOXCUT D ON C.CUU001=D.CUT001 LEFT JOIN MOXPST E ON A.PRS001=E.PST001 AND A.PRS002=E.PST002 LEFT JOIN MOXPAS F ON A.PRS001=F.PAS001 AND A.PRS002=F.PAS002 LEFT JOIN MOXPDP G ON A.PRS001=G.PDP001 AND A.PRS002=G.PDP002 LEFT JOIN MOXWPC H ON C.CUU001=H.WPC001 AND C.CUU002=H.WPC002 LEFT JOIN (SELECT PRD007,PRD008,PRD011,PRD034 FROM MOXPRD GROUP BY PRD007,PRD008,PRD011,PRD034) I ON H.WPC001=I.PRD007 AND H.WPC002=I.PRD008 AND H.WPC004=I.PRD011 AND H.WPC006+'*'+H.WPC009+'*'+H.WPC012=I.PRD034 " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( " GROUP BY  PRS001,PRS002,PRS003,PRS004,OPI006,OPI007,CUU003,CUU005,CUT002,PRS006,PRS007,PST016,PRS009,PST024,PAS007,PAS011,PAS012,PDP006,PDP007,PDP009,PDP010,PDP012,PDP013,PDP015,PDP016,PDP018,PDP019,PDP022,PDP023,PST031,PST032,PDP026,PAS016,PRS031 ORDER BY PST031 DESC,PST032 DESC,PAS017 DESC,PDP026 DESC,PRS001,OPI006" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void updateSign ( )
        {
            //ArrayList SQLString = new ArrayList ( );
            //StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "UPDATE MOXPST SET PST031=1 WHERE (PST014 IS NOT NULL OR PST014!='')" );
            //SQLString . Add ( strSql . ToString ( ) );
            //strSql . Append ( "UPDATE MOXPST SET PST031=0 WHERE (PST014 IS NULL OR PST014='')" );
            //SQLString . Add ( strSql . ToString ( ) );
            //strSql . Append ( "UPDATE MOXPST SET PST032=1 WHERE (PST022 IS NOT NULL OR PST022!='')" );
            //SQLString . Add ( strSql . ToString ( ) );
            //strSql . Append ( "UPDATE MOXPST SET PST032=0 WHERE (PST022 IS NULL OR PST022='')" );
            //SQLString . Add ( strSql . ToString ( ) );

            //SqlHelper . ExecuteSqlTran ( SQLString );


            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPST SET PST033=1 FROM MOXPDP WHERE PST001=PDP001 AND PST002=PDP002 AND PDP022=PDP025 AND (PST033 IS NULL OR PST033='' OR PST033='0') " );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPST SET PST033=0 FROM MOXPDP WHERE PST001=PDP001 AND PST002=PDP002 AND PDP022-PDP025!=0 AND PST033='1' " );
            SQLString . Add ( strSql . ToString ( ) );
            SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取备料日计划明细
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableBL ( string weekEnds ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PSW002 workShopSection,PSW003 PlanTime,PSX008 Remark FROM MOXPSW A INNER JOIN MOXPSX B ON A.PSW001=B.PSX001 " );
            strSql . AppendFormat ( "WHERE  PSX003='{0}' AND PSX004='{1}' AND PSW005=0 " ,weekEnds ,productNum );
            strSql . Append ( "ORDER BY PSW002,PSW003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 查询字段值
        /// </summary>
        /// <param name="coloumn"></param>
        /// <returns></returns>
        public DataTable GetOnly ( string coloumn )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM MOXPRS " ,coloumn );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <returns></returns>
        public DataTable GetColor ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT B.OPI006 FROM MOXPRS A LEFT JOIN MOXOPI B ON A.PRS002=B.OPI001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取备料所有日计划
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable getTableBLPlan ( string weekEnds,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PSX001 workShopSection,PSX007 Remark,PSW003 PlanTime,PSW002 workShop,PSX008 commen FROM MOXPSX A INNER JOIN MOXPSW B ON A.PSX001=B.PSW001 WHERE PSX003='{0}' AND PSX004='{1}' ORDER BY PSW002,PSX001" ,weekEnds ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取备料所有报工记录
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable getTableBLBG ( string weekEnds ,string  productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PDW001 workShopSection,PDW012 PlanTime,PSW002 workShop,CASE PSW002 WHEN '断料' THEN PDW007 WHEN '修边' THEN PDW008 WHEN '齿接' THEN PDW009 WHEN '拼板' THEN PDW011 WHEN '刨床' THEN PDW010 END Remark,PSX008 commen FROM MOXPDW A INNER JOIN MOXPSX B ON A.PDW002=B.PSX003 AND A.PDW003=B.PSX004 AND A.PDW016=B.PSX001 INNER JOIN MOXPSW C ON B.PSX001=C.PSW001 WHERE PDW002='{0}' AND PDW003='{1}'" ,weekEnds ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 获取机加工所有日计划
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable getTableJPlan ( string weekEnds ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PMX001 workShopSection,PMX007 Remark,PMW003 PlanTime,PMW002 workShop,PMX008 commen FROM MOXPMX A INNER JOIN MOXPMW B ON A.PMX001=B.PMW001 WHERE PMX003='{0}' AND PMX004='{1}' ORDER BY PMW002,PMX001" ,weekEnds ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取备料所有报工记录
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable getTableJBG ( string weekEnds ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PMY001 workShopSection,PMY012 PlanTime,PMW002 workShop,CASE PMW002 WHEN '加工中心' THEN PMY007 WHEN '开榫钻孔' THEN PMY008 WHEN '倒圆' THEN PMY009 END Remark,PMX008 commen FROM MOXPMY A INNER JOIN MOXPMX B ON A.PMY002=B.PMX003 AND A.PMY003=B.PMX004 AND A.PMY016=B.PMX001 INNER JOIN MOXPMW C ON B.PMX001=C.PMW001 WHERE PMY002='{0}' AND PMY003='{1}'" ,weekEnds ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否已经存在计划
        /// </summary>
        /// <returns></returns>
        public bool Exists ( string part,string proNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPLT WHERE PLT003='{0}' AND PLT004='{1}'" ,part ,proNum );
            //备料周计划是否排产
            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return false;

            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPSX WHERE PSX003='{0}' AND PSX004='{1}'" ,part ,proNum );
            //备料日计划是否排产
            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return false;

            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPMD WHERE PMD003='{0}' AND PMD004='{1}'" ,part ,proNum );
            //机加周计划是否排产
            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return false;

            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPMX WHERE PMX003='{0}' AND PMX004='{1}'" ,part ,proNum );
            //机加日计划是否排产
            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return false;

            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPLB WHERE PLB003='{0}' AND PLB004='{1}'" ,part ,proNum );
            //组装周计划是否排产
            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return false;

            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPLE WHERE PLE003='{0}' AND PLE004='{1}'" ,part ,proNum );
            //组装日计划是否排产
            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return false;

            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPWE WHERE PWE003='{0}' AND PWE004='{1}'" ,part ,proNum );
            //油漆日计划是否排产
            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return false;

            return true;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool Delete ( DataRow row )
        {
            string prs001 = row [ "PRS001" ] . ToString ( );
            string prs002 = row [ "PRS002" ] . ToString ( );

            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            //油漆日计划报工
            strSql . AppendFormat ( "DELETE FROM MOXPWF WHERE PWF002='{0}' AND PWF003='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //油漆日计划
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPWD FROM MOXPWE WHERE PWD001=PWE001 AND PWE003='{0}' AND PWE004='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPWE WHERE PWE003='{0}' AND PWE004='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //组装日计划报工
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPLF WHERE PLF002='{0}' AND PLF003='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //组装日计划
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPLD FROM MOXPLE WHERE PLD001=PLE001 AND PLE003='{0}' AND PLE004='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPLE WHERE PLE003='{0}' AND PLE004='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //组装周计划
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPMC FROM MOXPMD WHERE PMC001=PMD001 AND PMD003='{0}' AND PMD004='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPMD WHERE PMD003='{0}' AND PMD004='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //组装派工单
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXAWO FROM MOXAWQ WHERE AWO001=AWQ001 AND AWQ002='{0}' AND AWQ003='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXAWQ WHERE AWQ002='{0}' AND AWQ003='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //机加工日计划报工
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPMY WHERE PMY002='{0}' AND PMY003='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //机加工日计划
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPMW FROM MOXPMX WHERE PMW001=PMX001 AND PMX003='{0}' AND PMX004='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPMX WHERE PMX003='{0}' AND PMX004='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //机加工周计划报工
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPME WHERE PME002='{0}' AND PME003='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //机加工周计划
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPMC FROM MOXPMD WHERE PMC001=PMD001 AND PMD003='{0}' AND PMD004='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPMD WHERE PMD003='{0}' AND PMD004='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //备料日计划报工
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPDW WHERE PDW002='{0}' AND PDW003='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //备料日计划
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPSW FROM MOXPSX WHERE PSW001=PSX001 AND PSX003='{0}' AND PSX004='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPSX WHERE PSX003='{0}' AND PSX004='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //备料周计划报工
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPDK WHERE PDK002='{0}' AND PDK003='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //备料周计划
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPLS FROM MOXPLT WHERE PLS001=PLT001 AND PLT003='{0}' AND PLT004='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPLT WHERE PLT003='{0}' AND PLT004='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );

            //备料跟踪表
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPST WHERE PST001='{0}' AND PST002='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //组装跟踪表
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPAS WHERE PAS001='{0}' AND PAS002='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //油漆跟踪表
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPDP WHERE PDP001='{0}' AND PDP002='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );
            //总跟踪表
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPRS WHERE PRS001='{0}' AND PRS002='{1}'" ,prs001 ,prs002 );
            SQLString . Add ( strSql . ToString ( ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 编辑加急日期
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditDate ( CarpenterEntity.ProductScheduleEntity model)
        {
            StringBuilder strSql = new StringBuilder ( );
            if ( model . PRS031 == null )
                strSql . Append ( "UPDATE MOXPRS SET PRS031=NULL WHERE PRS001=@PRS001 AND PRS002=@PRS002" );
            else
                strSql . AppendFormat ( "UPDATE MOXPRS SET PRS031='{0}' WHERE PRS001=@PRS001 AND PRS002=@PRS002" ,model . PRS031 );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PRS001",SqlDbType.NVarChar),
                new SqlParameter("@PRS002",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = model . PRS001;
            parameter [ 1 ] . Value = model . PRS002;

            return SqlHelper . ExecuteNonQueryBool ( strSql . ToString ( ) ,parameter );
        }

    }
}
