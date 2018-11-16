using System . Data;
using System . Text;
using StudentMgr;
using System . Collections;
using System;
using System . Data . SqlClient;
using System . Threading . Tasks;
using System . Collections . Generic;

namespace CarpenterBll . Dao
{
    public class ProductionAssembleDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTableView ( string strWhere )
        {
            Task ts = new Task ( updateSign );
            ts . Start ( );

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT A.idx,PAS001,PAS002,PAS003,PAS004,PAS005,OPI006,OPI007,PAS016,PRS008,PRS010,PAS029,PAS007,PAS008,PAS009,PST022,PAS011,PAS012,PAS013,PAS030,CONVERT(BIT,CASE WHEN ISNULL(PAS011,0)=PAS016 THEN 1 ELSE 0 END) PAS017,PRS031 FROM MOXPAS A LEFT JOIN MOXPRS B ON A.PAS001=B.PRS001 AND A.PAS002=B.PRS002 LEFT JOIN MOXOPI C ON A.PAS002=C.OPI001 LEFT JOIN MOXPST D ON A.PAS001=D.PST001 AND A.PAS002=D.PST002 " );
            strSql . AppendFormat ( "WHERE {0})" ,strWhere );
            strSql . AppendFormat ( "SELECT idx,PAS001,PAS002,PAS003,PAS004,PAS005,OPI006,OPI007,PAS016,PRS008,PRS010,PAS029,PAS007,PAS008,PAS009,PST022,PAS011,PAS012,PAS013,PAS030,CASE WHEN PAS017=0 THEN '未完工' WHEN PAS017='1' THEN '完工' ELSE '未排' END PAS017,PRS031 FROM CET" );
            strSql . Append ( " ORDER BY PAS017 DESC,PAS001,OPI006" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        void updateSign ( )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "UPDATE MOXPAS SET PAS017=1 WHERE PAS012 IS NOT NULL OR PAS012!='' " );
            //SQLString . Add ( strSql . ToString ( ) );
            //strSql . Append ( "UPDATE MOXPAS SET PAS017=0 WHERE PAS012 IS NULL OR PAS012=''" );
            //SQLString . Add ( strSql . ToString ( ) );

            strSql . Append ( "UPDATE MOXPAS SET PAS018=1 FROM MOXPDP WHERE PAS001=PDP001 AND PAS002=PDP002 AND PDP022=PDP025 AND (PAS018='' OR PAS018='0' OR PAS018 IS NULL)" );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPAS SET PAS018=0 FROM MOXPDP WHERE PAS001=PDP001 AND PAS002=PDP002 AND PDP022!=PDP025 AND PAS018='1'" );
            SQLString . Add ( strSql . ToString ( ) );

            SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Save (DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . ProductionAssembleEntity _model = new CarpenterEntity . ProductionAssembleEntity ( );
            _model . PAS014 = UserInformation . dt ( );
            _model . PAS015 = UserInformation . UserName;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PAS007" ] . ToString ( ) ) )
                    _model . PAS007 = null;
                else
                    _model . PAS007 = Convert . ToDateTime ( table . Rows [ i ] [ "PAS007" ] . ToString ( ) );
                _model . PAS013 = table . Rows [ i ] [ "PAS013" ] . ToString ( );
                edit_pas ( SQLString ,strSql ,_model );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void edit_pas ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ProductionAssembleEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPAS SET " );
            strSql . Append ( "PAS007=@PAS007," );
            strSql . Append ( "PAS013=@PAS013 " );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameters = {
                new SqlParameter("@PAS007", SqlDbType.Date,3),
                new SqlParameter("@PAS013", SqlDbType.NVarChar,200),
                new SqlParameter("@idx", SqlDbType.Int,4) };
            parameters [ 0 ] . Value = _model . PAS007;
            parameters [ 1 ] . Value = _model . PAS013;
            parameters [ 2 ] . Value = _model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// 获取数据列
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public DataTable GetOnly ( string columns )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM MOXPAS " ,columns );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <returns></returns>
        public DataTable GetColor ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT OPI006 FROM MOXPAS A LEFT JOIN MOXOPI B ON A.PAS002=B.OPI001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取派工信息
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public DataTable GetTableOrder ( string weekEnds,string productName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.AWQ006,A.AWQ007,A.AWQ009,A.AWQ010,B.AWO002 FROM MOXAWQ A LEFT JOIN MOXAWO B ON A.AWQ001=B.AWO001 " );
            strSql . AppendFormat ( "WHERE AWQ002='{0}' AND AWQ003='{1}'" ,weekEnds ,productName );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在组装周计划
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsZW ( List<string> idxList )
        {
            string str = string . Join ( "," ,idxList );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPAS A INNER JOIN MOXPLB B ON A.PAS001=B.PLB003 AND A.PAS002=B.PLB004 WHERE A.idx IN ({0})" ,str );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在组装日计划
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsZD ( List<string> idxList )
        {
            string str = string . Join ( "," ,idxList );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPAS A INNER JOIN MOXPLE B ON A.PAS001=B.PLE003 AND A.PAS002=B.PLE004 WHERE A.idx IN ({0})" ,str );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool Delete ( List<string> idxList )
        {
            string str = string . Join ( "," ,idxList );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPAS WHERE idx IN ({0})" ,str );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
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
            strSql . AppendFormat ( "SELECT DISTINCT OPI009 FROM MOXPAS A INNER JOIN MOXOPI B ON A.PAS002=B.OPI001 WHERE A.idx IN ({0})" ,str );

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

    }
}
