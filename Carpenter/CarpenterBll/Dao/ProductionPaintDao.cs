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
    public class ProductionPaintDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableView ( string strWhere )
        {
            Task ts = new Task ( editDayNum );
            ts . Start ( );
            //editDayNum ( );

            StringBuilder strSql = new StringBuilder ( );

            strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,PDP001,PDP002,PDP003,PDP004,PDP005,PDP006,PDP007,PDP008,PDP009,PDP010,PDP011,PDP012,PDP013,PDP014,PDP015,PDP016,PDP017,PDP018,PDP019,PDP020,PDP021,PDP022,PDP023,PDP024,PDP025,OPI006,PAS011,PAS012,CASE WHEN PDP026=0 THEN '未完工' WHEN PDP026=1 THEN '完工' ELSE '未排' END PDP026,PRS031,PDP028 FROM MOXPDP A LEFT JOIN MOXOPI B ON A.PDP002=B.OPI001 LEFT JOIN MOXPAS C ON A.PDP001=C.PAS001 AND A.PDP002=C.PAS002 LEFT JOIN MOXPRS D ON A.PDP001=D.PRS001 AND A.PDP002=D.PRS002 " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( "  ORDER BY PDP026 DESC,PDP001,OPI006" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        void editDayNum ( )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "UPDATE MOXPDP SET PDP008=NULL WHERE PDP009=PDP025 AND ISNULL(PDP008,0)!=0" );
            //SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET PDP008=NULL WHERE PDP008=0" );
            SQLString . Add ( strSql . ToString ( ) );
            //strSql = new StringBuilder ( );
            //strSql . Append ( "UPDATE MOXPDP SET PDP011=NULL WHERE PDP012=PDP025 AND ISNULL(PDP011,0)!=0" );
            //SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET PDP011=NULL WHERE PDP011=0" );
            SQLString . Add ( strSql . ToString ( ) );
            //strSql = new StringBuilder ( );
            //strSql . Append ( "UPDATE MOXPDP SET PDP014=NULL WHERE PDP015=PDP025 AND ISNULL(PDP014,0)!=0" );
            //SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET PDP014=NULL WHERE PDP014=0" );
            SQLString . Add ( strSql . ToString ( ) );
            //strSql = new StringBuilder ( );
            //strSql . Append ( "UPDATE MOXPDP SET PDP017=NULL WHERE PDP018=PDP025 AND ISNULL(PDP017,0)!=0" );
            //SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET PDP017=NULL WHERE PDP017=0" );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET PDP028=NULL WHERE PDP028=0" );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET PDP026=1 WHERE PDP023 IS NOT NULL OR PDP023!=''" );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET PDP026=0 WHERE PDP023 IS NULL OR PDP023=''" );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET PDP023=NULL WHERE PDP022=0 OR PDP022 IS NULL OR PDP022=''" );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET PDP022=NULL WHERE PDP022=0" );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET PDP027=1 WHERE PDP022=PDP025 AND (PDP027 IS NULL OR PDP027='' OR PDP027='')" );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET PDP027='0' WHERE PDP022!=PDP025 AND PDP027='1'" );
            SQLString . Add ( strSql . ToString ( ) );

            SqlHelper . ExecuteSqlTran ( SQLString );
        }


        /*

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public bool Save ( DataTable tableView )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            CarpenterEntity . ProductionPaintEntity _model = new CarpenterEntity . ProductionPaintEntity ( );
            for ( int i = 0 ; i < tableView . Rows . Count ; i++ )
            {
                _model . idx = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) );
                _model.PDP005= string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PDP005" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "PDP005" ] . ToString ( ) );
                _model . PDP006 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PDP006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "PDP006" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PDP007" ] . ToString ( ) ) )
                    _model . PDP007 = null;
                else
                    _model . PDP007 = Convert . ToDateTime ( tableView . Rows [ i ] [ "PDP007" ] . ToString ( ) );
                _model . PDP022 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PDP022" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "PDP022" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PDP023" ] . ToString ( ) ) )
                    _model . PDP023 = null;
                else
                    _model . PDP023 = Convert . ToDateTime ( tableView . Rows [ i ] [ "PDP023" ] . ToString ( ) );
                _model . PDP024 = tableView . Rows [ i ] [ "PDP024" ] . ToString ( );
                _model . PDP001 = tableView . Rows [ i ] [ "PDP001" ] . ToString ( );
                _model . PDP002 = tableView . Rows [ i ] [ "PDP002" ] . ToString ( );
                save ( _model ,SQLString ,strSql );

                //白坯完成数量和完工时间回写到总跟踪进度表

                //edit_prs ( SQLString ,strSql ,_model );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        */

        void save ( CarpenterEntity . ProductionPaintEntity _model ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET " );
            strSql . Append ( "PDP005=@PDP005," );
            strSql . Append ( "PDP006=@PDP006," );
            strSql . Append ( "PDP007=@PDP007," );
            strSql . Append ( "PDP022=@PDP022," );
            strSql . Append ( "PDP023=@PDP023," );
            strSql . Append ( "PDP024=@PDP024 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PDP005",SqlDbType.Int,4),
                new SqlParameter("@PDP006",SqlDbType.Int,4),
                new SqlParameter("@PDP007",SqlDbType.Date,3),
                new SqlParameter("@PDP022",SqlDbType.Int,4),
                new SqlParameter("@PDP023",SqlDbType.Date,4),
                new SqlParameter("@PDP024",SqlDbType.NVarChar,200),
                new SqlParameter("@idx",SqlDbType.Int,4)
            };
            parameter [ 0 ] . Value = _model . PDP005;
            parameter [ 1 ] . Value = _model . PDP006;
            parameter [ 2 ] . Value = _model . PDP007;
            parameter [ 3 ] . Value = _model . PDP022;
            parameter [ 4 ] . Value = _model . PDP023;
            parameter [ 5 ] . Value = _model . PDP024;
            parameter [ 6 ] . Value = _model . idx;
            SQLString . Add ( strSql ,parameter );
        }

        void edit_prs ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ProductionPaintEntity model )
        {
            //model . PDP005 = model . PDP005 + model . PDP006;
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPRS SET " );
            strSql . Append ( "PRS014=@PRS014," );
            strSql . Append ( "PRS015=@PRS015 " );
            strSql . Append ( "WHERE PRS001=@PRS001 AND PRS002=@PRS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PRS014",SqlDbType.Int,4),
                new SqlParameter("@PRS015",SqlDbType.Date,3),
                new SqlParameter("@PRS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS002",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = 8;
            parameter [ 1 ] . Value = model . PDP007;
            parameter [ 2 ] . Value = model . PDP001;
            parameter [ 3 ] . Value = model . PDP002;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 获取数据列
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public DataTable GetOnly ( string columns )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM MOXPDP " ,columns );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <returns></returns>
        public DataTable GetColor ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT OPI006 FROM MOXPDP A LEFT JOIN MOXOPI B ON A.PDP002=B.OPI001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 编辑白坯和软包的内容
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . ProductionPaintEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET " );
            strSql . Append ( "PDP005=@PDP005," );
            strSql . Append ( "PDP006=@PDP006," );
            strSql . Append ( "PDP007=@PDP007," );
            strSql . Append ( "PDP020=@PDP020," );
            strSql . Append ( "PDP021=@PDP021 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PDP005",SqlDbType.Int,4),
                new SqlParameter("@PDP006",SqlDbType.NVarChar,200),
                new SqlParameter("@PDP007",SqlDbType.Date,3),
                new SqlParameter("@PDP020",SqlDbType.Int,4),
                new SqlParameter("@PDP021",SqlDbType.NVarChar,200),
                new SqlParameter("@idx",SqlDbType.Int,4)
            };
            parameter [ 0 ] . Value = _model . PDP005;
            parameter [ 1 ] . Value = _model . PDP006;
            if ( _model . PDP007 == null )
                parameter [ 2 ] . Value = DBNull . Value;
            else
                parameter [ 2 ] . Value = _model . PDP007;
            parameter [ 3 ] . Value = _model . PDP020;
            parameter [ 4 ] . Value = _model . PDP021;
            parameter [ 5 ] . Value = _model . idx;

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在周计划记录
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsYW ( List<string> idxList )
        {
            string str = string . Join ( "," ,idxList );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPDP A INNER JOIN MOXPWH B ON A.PDP001=B.PWH003 AND A.PDP002=B.PWH004 WHERE A.idx IN ({0})" ,str );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在日计划记录
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsYD ( List<string> idxList )
        {
            string str = string . Join ( "," ,idxList );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPDP A INNER JOIN MOXPWE B ON A.PDP001=B.PWE003 AND A.PDP002=B.PWE004 WHERE A .idx IN ({0})" ,str );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool Delete ( List<string> idxList )
        {
            string str = string . Join ( "," ,idxList );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPDP WHERE idx IN ({0})" ,str );

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
            strSql . AppendFormat ( "SELECT DISTINCT OPI009 FROM MOXPDP A INNER JOIN MOXOPI B ON A.PDP002=B.OPI001 WHERE A.idx IN ({0})" ,str );

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
