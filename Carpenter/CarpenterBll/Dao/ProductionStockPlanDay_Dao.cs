using System . Data;
using System . Text;
using StudentMgr;

namespace CarpenterBll . Dao
{
    public class ProductionStockPlanDay_Dao
    {
        /// <summary>
        /// 获取备料日计划明细
        /// </summary>
        /// <param name="workShopSection"></param>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableBL ( string weekEnds ,string productNum ,string workShop )
        {
            //string columns = string . Empty;
            //if ( workShop . Equals ( CarpenterBll . ColumnValues . bl_dl ) )
            //    columns = "PDW007";
            //else if ( workShop . Equals ( CarpenterBll . ColumnValues . bl_xb ) )
            //    columns = "PDW008";
            //else if ( workShop . Equals ( CarpenterBll . ColumnValues . bl_cj ) )
            //    columns = "PDW009";
            //else if ( workShop . Equals ( CarpenterBll . ColumnValues . bl_pb ) )
            //    columns = "PDW010";
            //else if ( workShop . Equals ( CarpenterBll . ColumnValues . bl_pc ) )
            //    columns = "PDW011";

            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "SELECT PSX001 workShopSection,SUM(PSX007)-SUM(ISNULL({0},0)) Remark,PSW003 PlanTime,PSX008 commen FROM MOXPSW A INNER JOIN MOXPSX B ON A.PSW001=B.PSX001 LEFT JOIN (SELECT PDW002,PDW003,PDW016,SUM({0}) {0} FROM MOXPDW A INNER JOIN MOXPSX B ON A.PDW002=B.PSX003 AND A.PDW003=B.PSX004 AND A.PDW016=B.PSX001 WHERE PDW002='{1}' AND PDW003='{2}' GROUP BY PDW002,PDW003,PDW016) C ON B.PSX003=C.PDW002 AND B.PSX004=C.PDW003 AND B.PSX001=C.PDW016 WHERE PSX003='{1}' AND PSX004='{2}' AND PSW002='{3}' GROUP BY PSX001,PSW003,PSX008 HAVING SUM(PSX007)>SUM(ISNULL({0},0)) " ,columns ,weekEnds ,productNum ,workShop );
            strSql . AppendFormat ( "SELECT PSX001 workShopSection,PSX007 Remark,PSW003 PlanTime,PSX008 commen FROM MOXPSW A INNER JOIN MOXPSX B ON A.PSW001=B.PSX001 WHERE PSX003='{0}' AND PSX004='{1}' ORDER BY PSW002,PSX001" ,weekEnds ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取备料报工记录
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public DataTable getDataTableBL ( string weekEnds ,string productNum ,string workShop )
        {
            string columns = string . Empty;
            if ( workShop . Equals ( CarpenterBll . ColumnValues . bl_dl ) )
                columns = "PDW007";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . bl_xb ) )
                columns = "PDW008";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . bl_cj ) )
                columns = "PDW009";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . bl_pb ) )
                columns = "PDW010";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . bl_pc ) )
                columns = "PDW011";

            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PDW001 workShopSection,SUM({0}) Remark,PDW012 PlanTime,PSX008 commen FROM MOXPDW A LEFT JOIN MOXPSX ON PDW016=PSX001 AND PDW002=PSX003 AND PDW003=PSX004 WHERE PDW002='{1}' AND PDW003='{2}' AND {0}>0 GROUP BY PDW001,PDW012,PSX008 ORDER BY PDW001 " ,columns ,weekEnds ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        

        /// <summary>
        /// 获取机加工日计划明细
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableJ ( string weekEnds ,string productNum ,string workShop )
        {
            //string columns = string . Empty;
            //if ( workShop . Equals ( CarpenterBll . ColumnValues . jjg_jgzx ) )
            //    columns = "PMY007";
            //else if ( workShop . Equals ( CarpenterBll . ColumnValues . jjg_kszk ) )
            //    columns = "PMY008";
            //else if ( workShop . Equals ( CarpenterBll . ColumnValues . jjg_dy ) )
            //    columns = "PMY009";

            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "SELECT PMX001 workShopSection,SUM(PMX007)-SUM(ISNULL({0},0)) Remark,PMW003 PlanTime,PMX008 commen FROM MOXPMW A INNER JOIN MOXPMX B ON A.PMW001=B.PMX001 LEFT JOIN (SELECT PMY002,PMY003,PMY016,SUM({0}) {0} FROM MOXPMY A INNER JOIN MOXPMX B ON A.PMY002=B.PMX003 AND A.PMY003=B.PMX004 AND A.PMY016=B.PMX001 WHERE PMY002='{1}' AND PMY003='{2}' GROUP BY PMY002,PMY003,PMY016) C ON B.PMX003=C.PMY002 AND B.PMX004=C.PMY003 AND B.PMX001=C.PMY016 WHERE PMX003='{1}' AND PMX004='{2}' AND PMW002='{3}' GROUP BY PMX001,PMW003,PMX008 HAVING SUM(PMX007)>SUM(ISNULL({0},0))" ,columns ,weekEnds ,productNum ,workShop );
            strSql . AppendFormat ( "SELECT PMX001 workShopSection,PMX007 Remark,PMW003 PlanTime,PMX008 commen FROM MOXPMW A INNER JOIN MOXPMX B ON A.PMW001=B.PMX001 WHERE  PMX003='{0}' AND PMX004='{1}' ORDER BY PMW002,PMX001" ,weekEnds ,productNum );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取机加工报工记录
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public DataTable getDataTableJ ( string weekEnds ,string productNum ,string workShop )
        {
            string columns = string . Empty;
            if ( workShop . Equals ( CarpenterBll . ColumnValues . jjg_jgzx ) )
                columns = "PMY007";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . jjg_kszk ) )
                columns = "PMY008";
            else if ( workShop . Equals ( CarpenterBll . ColumnValues . jjg_dy ) )
                columns = "PMY009";

            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PMY001 workShopSection,SUM({0}) Remark,PMY012 PlanTime,PMX008 commen FROM MOXPMY LEFT JOIN MOXPMX ON PMX001=PMY016 AND PMX003=PMY002 AND PMX004=PMY003 WHERE PMY002='{1}' AND PMY003='{2}' AND {0}>0 GROUP BY PMY001,PMY012,PMX008 ORDER BY PMY001 " ,columns ,weekEnds ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取组装日计划明细
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableZ ( string weekEnds ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLE001 workShopSection,PLE007 Remark,PLD003 PlanTime,PLD002 workShop,PLE008 commen FROM MOXPLD A INNER JOIN MOXPLE B ON A.PLD001=B.PLE001   " );
            strSql . AppendFormat ( "WHERE  PLE003='{0}' AND PLE004='{1}'   " ,weekEnds ,productNum );//AND PLD005=0
            strSql . Append ( "ORDER BY PLD002,PLD003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取组装日计划报工
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableZBG ( string weekEnds ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PLF001 workShopSection,PLF012 PlanTime,PLD002 workShop,PLF007 Remark,PLE008 commen FROM MOXPLF A INNER JOIN MOXPLE B ON A.PLF002=B.PLE003 AND A.PLF003=B.PLE004 AND A.PLF010=B.PLE001 INNER JOIN MOXPLD C ON B.PLE001=C.PLD001 WHERE PLF002='{0}' AND PLF003='{1}' " ,weekEnds ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 获取油漆日计划明细
        /// </summary>
        /// <param name="workShopSection"></param>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string weekEnds ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PWD001 workShopSection,PWD003 PlanTime,PWE007 Remark,PWD002 workShop,PWE008 commen FROM MOXPWD A INNER JOIN MOXPWE B ON A.PWD001=B.PWE001 " );
            strSql . AppendFormat ( "WHERE  PWE003='{0}' AND PWE004='{1}'  " ,weekEnds ,productNum );//AND PWD005=0
            strSql . Append ( "ORDER BY PWD002,PWD003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取油漆日计划报工记录
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePaintBG ( string weekEnds,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PWF001 workShopSection,PWF012 PlanTime,PWD002 workShop,CASE PWD002 WHEN '底漆' THEN PWF007 WHEN '油磨' THEN PWF008 WHEN '修色' THEN PWF009 WHEN '面漆' THEN PWF010 WHEN '包装' THEN PWF016 END Remark,PWE008 commen FROM MOXPWF A INNER JOIN MOXPWE B ON A.PWF002=B.PWE003 AND A.PWF003=B.PWE004 AND A.PWF017=B.PWE001 INNER JOIN MOXPWD C ON B.PWE001=C.PWD001 WHERE PWF002='{0}' AND PWF003='{1}'" ,weekEnds ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
