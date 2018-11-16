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
    public class ProductionStockDao
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
            strSql . Append ( "SELECT A.idx,PST001,PST002,PST003,PST004,OPI006,OPI007,PST028,PST005,PST006,PST029,PST007,PST008,PST009,PST010,PST011,PST012,PST013,PST014,PST015,PST016,PST017,PST018,PST019,PST020,PST021,PST022,PST023,PST024,PST025,PST026,PST030,CASE WHEN PST031=0 THEN '未完工' WHEN PST031='1' THEN '完工' ELSE '未排' END PST031,CASE WHEN PST032=0 THEN '未完工' WHEN PST032='1' THEN '完工' ELSE '未排' END PST032,PRS031 FROM MOXPST A LEFT JOIN MOXCUU B ON A.PST001=B.CUU001 AND A.PST002=B.CUU002 LEFT JOIN MOXOPI C ON A.PST002=C.OPI001 LEFT JOIN MOXPRS D ON A.PST001=D.PRS001 AND A.PST002=D.PRS002 " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( " ORDER BY PST031 DESC,PST032 DESC,PST001,OPI006" );

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
        /// 保存
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Edit (DataTable table,string name )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . ProductionStockEntity _model = new CarpenterEntity . ProductionStockEntity ( );
            _model . PST026 = GetDate ( );
            _model . PST027 = name;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . PST001 = table . Rows [ i ] [ "PST001" ] . ToString ( );
                _model . PST002 = table . Rows [ i ] [ "PST002" ] . ToString ( );
                if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "PST006" ] . ToString ( ) ) )
                    _model . PST006 = Convert . ToDateTime ( table . Rows [ i ] [ "PST006" ] . ToString ( ) );
                else
                    _model . PST006 = null;
                if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "PST008" ] . ToString ( ) ) )
                    _model . PST008 = Convert . ToDateTime ( table . Rows [ i ] [ "PST008" ] . ToString ( ) );
                else
                    _model . PST008 = null;
                if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "PST010" ] . ToString ( ) ) )
                    _model . PST010 = Convert . ToDateTime ( table . Rows [ i ] [ "PST010" ] . ToString ( ) );
                else
                    _model . PST010 = null;
                if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "PST012" ] . ToString ( ) ) )
                    _model . PST012 = Convert . ToDateTime ( table . Rows [ i ] [ "PST012" ] . ToString ( ) );
                else
                    _model . PST012 = null;
                if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "PST014" ] . ToString ( ) ) )
                    _model . PST014 = Convert . ToDateTime ( table . Rows [ i ] [ "PST014" ] . ToString ( ) );
                else
                    _model . PST014 = null;
                _model . PST015 = table . Rows [ i ] [ "PST015" ] . ToString ( );
                if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "PST016" ] . ToString ( ) ) )
                    _model . PST016 = Convert . ToDateTime ( table . Rows [ i ] [ "PST016" ] . ToString ( ) );
                else
                    _model . PST016 = null;
                if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "PST018" ] . ToString ( ) ) )
                    _model . PST018 = Convert . ToDateTime ( table . Rows [ i ] [ "PST018" ] . ToString ( ) );
                else
                    _model . PST018 = null;
                if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "PST020" ] . ToString ( ) ) )
                    _model . PST020 = Convert . ToDateTime ( table . Rows [ i ] [ "PST020" ] . ToString ( ) );
                else
                    _model . PST020 = null;
                if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "PST022" ] . ToString ( ) ) )
                    _model . PST022 = Convert . ToDateTime ( table . Rows [ i ] [ "PST022" ] . ToString ( ) );
                else
                    _model . PST022 = null;
                _model . PST023 = table . Rows [ i ] [ "PST023" ] . ToString ( );
                if ( !string . IsNullOrEmpty ( table . Rows [ i ] [ "PST024" ] . ToString ( ) ) )
                    _model . PST024 = Convert . ToDateTime ( table . Rows [ i ] [ "PST024" ] . ToString ( ) );
                else
                    _model . PST024 = null;

                edit_bl ( _model ,strSql ,SQLString );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        DateTime GetDate ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GETDATE() t" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) ) )
                    return DateTime . Now;
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) );
            }
            else
                return DateTime . Now;
        }

        void edit_bl ( CarpenterEntity . ProductionStockEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPST SET " );
            strSql . Append ( "PST006=@PST006," );
            strSql . Append ( "PST008=@PST008," );
            strSql . Append ( "PST010=@PST010," );
            strSql . Append ( "PST012=@PST012," );
            strSql . Append ( "PST014=@PST014," );
            strSql . Append ( "PST015=@PST015," );
            strSql . Append ( "PST016=@PST016," );
            strSql . Append ( "PST018=@PST018," );
            strSql . Append ( "PST020=@PST020," );
            strSql . Append ( "PST022=@PST022," );
            strSql . Append ( "PST023=@PST023," );
            strSql . Append ( "PST024=@PST024," );
            strSql . Append ( "PST026=@PST026," );
            strSql . Append ( "PST027=@PST027 " );
            strSql . Append ( "WHERE PST001=@PST001 " );
            strSql . Append ( "AND PST002=@PST002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PST001",SqlDbType.NVarChar,20),
                new SqlParameter("@PST002",SqlDbType.NVarChar,20),
                new SqlParameter("@PST006",SqlDbType.Date),
                new SqlParameter("@PST008",SqlDbType.Date),
                new SqlParameter("@PST010",SqlDbType.Date),
                new SqlParameter("@PST012",SqlDbType.Date),
                new SqlParameter("@PST014",SqlDbType.Date),
                new SqlParameter("@PST015",SqlDbType.NVarChar,20),
                new SqlParameter("@PST016",SqlDbType.Date),
                new SqlParameter("@PST018",SqlDbType.Date),
                new SqlParameter("@PST020",SqlDbType.Date),
                new SqlParameter("@PST022",SqlDbType.Date),
                new SqlParameter("@PST023",SqlDbType.NVarChar,20),
                new SqlParameter("@PST024",SqlDbType.Date),
                new SqlParameter("@PST026",SqlDbType.Date),
                new SqlParameter("@PST027",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PST001;
            parameter [ 1 ] . Value = _model . PST002;
            parameter [ 2 ] . Value = _model . PST006;
            parameter [ 3 ] . Value = _model . PST008;
            parameter [ 4 ] . Value = _model . PST010;
            parameter [ 5 ] . Value = _model . PST012;
            parameter [ 6 ] . Value = _model . PST014;
            parameter [ 7 ] . Value = _model . PST015;
            parameter [ 8 ] . Value = _model . PST016;
            parameter [ 9 ] . Value = _model . PST018;
            parameter [ 10 ] . Value = _model . PST020;
            parameter [ 11 ] . Value = _model . PST022;
            parameter [ 12 ] . Value = _model . PST023;
            parameter [ 13 ] . Value = _model . PST024;
            parameter [ 14 ] . Value = _model . PST026;
            parameter [ 15 ] . Value = _model . PST027;

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
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM MOXPST " ,columns );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <returns></returns>
        public DataTable GetColor ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT OPI006 FROM MOXPST A LEFT JOIN MOXOPI B ON A.PST002=B.OPI001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 备料日计划是否存在记录
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsBLD ( List<string> idxList )
        {
            string str = string . Join ( "," ,idxList );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPST A INNER JOIN MOXPSX B ON PSX003=PST001 AND PSX004=PST002 WHERE A.idx IN ({0})" ,str );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 备料周计划是否存在记录
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsBLW ( List<string> idxList )
        {
            string str = string . Join ( "," ,idxList );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPLT A INNER JOIN MOXPST B ON PST001=PLT003 AND PST002=PLT004 WHERE B.idx IN ({0})" ,str );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 机加工周计划是否存在记录
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsJD ( List<string> idxList )
        {
            string str = string . Join ( "," ,idxList );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPST A INNER JOIN MOXPMD B ON A.PST001=B.PMD003 AND A.PST002=B.PMD004 WHERE A.idx IN ({0})" ,str );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 机加工日计划是否存在记录
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsJW ( List<string> idxList )
        {
            string str = string . Join ( "," ,idxList );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPST A INNER JOIN MOXPMX B ON A.PST001=B.PMX003 AND A.PST002=B.PMX004 WHERE A.idx IN ({0})" ,str );

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
            strSql . AppendFormat ( "DELETE FROM MOXPST WHERE idx IN ({0})" ,str );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

    }
}
