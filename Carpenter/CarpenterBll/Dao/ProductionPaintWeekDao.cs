using StudentMgr;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Linq;
using System . Text;

namespace CarpenterBll . Dao
{
    public class ProductionPaintWeekDao
    {

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PWG001,PWG009,PWG003,PWG004,PWG005,SUM(OPI004*PWH014) PWH014 FROM MOXPWG A INNER JOIN MOXPWH B ON A.PWG001=B.PWH001 INNER JOIN MOXOPI C ON B.PWH004=C.OPI001 GROUP BY PWG001,PWG009,PWG003,PWG004,PWG005 ORDER BY PWG001 DESC" );
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            strSql . Append ( "DELETE FROM MOXPWH " );
            strSql . Append ( " WHERE PWH001=@PWH001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PWH001", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = oddNum;
            SQLString . Add ( strSql ,parameters );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPWG " );
            strSql . Append ( " WHERE PWG001=@PWG001" );
            SqlParameter [ ] parameter = {
                    new SqlParameter("@PWG001", SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 编辑保存数据
        /// </summary>
        /// <param name="_pmc"></param>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . ProductionPaintWeekPWGEntity _pla ,DataTable tableView )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _pla . PWG002 = UserInformation . dt ( );
            _pla . PWG006 = UserInformation . UserName;
            edit_pmc ( SQLString ,strSql ,_pla );

            CarpenterEntity . ProductionPaintWeekPWHEntity _plb = new CarpenterEntity . ProductionPaintWeekPWHEntity ( );
            _plb . PWH001 = _pla . PWG001;
            _plb . PWH011 = UserInformation . dt ( );
            _plb . PWH012 = UserInformation . UserName;
            DataTable dt = GetDataTable ( _plb . PWH001 );
            for ( int i = 0 ; i < tableView . Rows . Count ; i++ )
            {
                _plb . PWH002 = tableView . Rows [ i ] [ "PWH002" ] . ToString ( );
                _plb . PWH003 = tableView . Rows [ i ] [ "PWH003" ] . ToString ( );
                _plb . PWH004 = tableView . Rows [ i ] [ "PWH004" ] . ToString ( );
                _plb . PWH005 = tableView . Rows [ i ] [ "PWH005" ] . ToString ( );
                _plb . PWH006 = tableView . Rows [ i ] [ "PWH006" ] . ToString ( );
                _plb . PWH007 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PWH007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "PWH007" ] . ToString ( ) );
                _plb . PWH009 = tableView . Rows [ i ] [ "PWH009" ] . ToString ( );
                _plb . PWH010 = ( bool ) tableView . Rows [ i ] [ "PWH010" ];
                _plb . PWH014 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PWH014" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "PWH014" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PWH016" ] . ToString ( ) ) )
                    _plb . PWH016 = null;
                else
                    _plb . PWH016 = Convert . ToDateTime ( tableView . Rows [ i ] [ "PWH016" ] . ToString ( ) );
                _plb . idx = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( dt . Select ( "PWH002='" + _plb . PWH002 + "' AND PWH003='" + _plb . PWH003 + "' AND PWH004='" + _plb . PWH004 + "'" ) . Length > 0 )
                    edit_pmd ( SQLString ,strSql ,_plb );

                //if ( _plb . PWH010 == false && Exists_edit_Prs ( _plb . PWH003 ,_plb . PWH004 ) == true )
                //    edit_Prs ( _plb ,strSql ,SQLString );

                //if ( _plb . PWH010 == false && Exists_edit_Pas ( _plb . PWH003 ,_plb . PWH004 ) == true )
                //    edit_Pas ( _plb ,strSql ,SQLString );
            }

            for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            {
                _plb . PWH002 = dt . Rows [ i ] [ "PWH002" ] . ToString ( );
                _plb . PWH003 = dt . Rows [ i ] [ "PWH003" ] . ToString ( );
                _plb . PWH004 = dt . Rows [ i ] [ "PWH004" ] . ToString ( );
                _plb . idx = string . IsNullOrEmpty ( dt . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( tableView . Select ( "PWH002='" + _plb . PWH002 + "' AND PWH003='" + _plb . PWH003 + "' AND PWH004='" + _plb . PWH004 + "'" ) . Length < 1 )
                {
                    delete_pmd ( SQLString ,strSql ,_plb );
                    //editPAS ( SQLString ,strSql ,_plb );
                    //_plb . PWH016 = null;
                    //if ( _plb . PWH010 == false && Exists_edit_Pas ( _plb . PWH003 ,_plb . PWH004 ) == true )
                    //    edit_Pas ( _plb ,strSql ,SQLString );
                }
            }


            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void edit_pmc ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ProductionPaintWeekPWGEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPWG SET " );
            strSql . Append ( "PWG002=@PWG002," );
            strSql . Append ( "PWG003=@PWG003," );
            strSql . Append ( "PWG004=@PWG004," );
            strSql . Append ( "PWG005=@PWG005," );
            strSql . Append ( "PWG006=@PWG006 " );
            strSql . Append ( " where PWG001=@PWG001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PWG001", SqlDbType.VarChar,20),
                    new SqlParameter("@PWG002", SqlDbType.Date,3),
                    new SqlParameter("@PWG003", SqlDbType.Date,3),
                    new SqlParameter("@PWG004", SqlDbType.Date,3),
                    new SqlParameter("@PWG005", SqlDbType.Date,3),
                    new SqlParameter("@PWG006", SqlDbType.VarChar,20)
            };
            parameters [ 0 ] . Value = model . PWG001;
            parameters [ 1 ] . Value = model . PWG002;
            parameters [ 2 ] . Value = model . PWG003;
            parameters [ 3 ] . Value = model . PWG004;
            parameters [ 4 ] . Value = model . PWG005;
            parameters [ 5 ] . Value = model . PWG006;
            SQLString . Add ( strSql ,parameters );
        }

        void edit_pmd ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ProductionPaintWeekPWHEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXPWH set " );
            strSql . Append ( "PWH009=@PWH009," );
            strSql . Append ( "PWH011=@PWH011," );
            strSql . Append ( "PWH012=@PWH012, " );
            strSql . Append ( "PWH014=@PWH014, " );
            strSql . Append ( "PWH016=@PWH016 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PWH009", SqlDbType.VarChar,200),
                    new SqlParameter("@PWH011", SqlDbType.Date,3),
                    new SqlParameter("@PWH012", SqlDbType.VarChar,20),
                    new SqlParameter("@PWH014", SqlDbType.Int,4),
                    new SqlParameter("@PWH016", SqlDbType.Date,3),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . PWH009;
            parameters [ 1 ] . Value = model . PWH011;
            parameters [ 2 ] . Value = model . PWH012;
            parameters [ 3 ] . Value = model . PWH014;
            parameters [ 4 ] . Value = model . PWH016;
            parameters [ 5 ] . Value = model . idx;
            SQLString . Add ( strSql ,parameters );
        }

        void delete_pmd ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ProductionPaintWeekPWHEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPWH " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = model . idx;
            SQLString . Add ( strSql ,parameter );
        }

        DataTable GetDataTable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,PWH002,PWH003,PWH004 " );
            strSql . Append ( " FROM MOXPWH " );
            strSql . Append ( " WHERE PWH001=@PWH001" );
            SqlParameter [ ] parameters = {
                new SqlParameter("@PWH001",SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = oddNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameters );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examine ( string oddNum ,bool state ,string programId )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPWG SET " );
            strSql . Append ( "PWG007=@PWG007," );
            strSql . Append ( "PWG002=@PWG002," );
            strSql . Append ( "PWG006=@PWG006 " );
            strSql . Append ( "WHERE PWG001=@PWG001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWG007",SqlDbType.Bit),
                new SqlParameter("@PWG001",SqlDbType.NVarChar,20),
                new SqlParameter("@PWG002",SqlDbType.Date,3),
                new SqlParameter("@PWG006",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = state;
            parameter [ 1 ] . Value = oddNum;
            parameter [ 2 ] . Value = UserInformation . dt ( );
            parameter [ 3 ] . Value = UserInformation . UserName;
            SQLString . Add ( strSql ,parameter );
            if ( state == false )
                CarpenterBll . Examine . writeToReview ( programId ,oddNum ,UserInformation . UserName ,SQLString );
            else
                CarpenterBll . Examine . deleteToReview ( programId ,oddNum ,UserInformation . UserName ,SQLString );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Cancellation ( string oddNum ,bool state )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPWG SET " );
            strSql . Append ( "PWG008=@PWG008," );
            strSql . Append ( "PWG002=@PWG002," );
            strSql . Append ( "PWG006=@PWG006 " );
            strSql . Append ( "WHERE PWG001=@PWG001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PWG008",SqlDbType.Bit),
                new SqlParameter("@PWG001",SqlDbType.NVarChar,20),
                new SqlParameter("@PWG002",SqlDbType.Date,3),
                new SqlParameter("@PWG006",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = state;
            parameter [ 1 ] . Value = oddNum;
            parameter [ 2 ] . Value = UserInformation . dt ( );
            parameter [ 3 ] . Value = UserInformation . UserName;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableView ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,PWH001,PWH002,PWH003,PWH004,PWH005,PWH006,PWH007,PWH009,CASE PWH010 WHEN 0 THEN '正式' ELSE '预排' END PWH010,PWH014,PWH016,OPI003,OPI004,OPI006,OPI007,PRS013 FROM MOXPWH A LEFT JOIN MOXOPI B ON A.PWH004=B.OPI001 LEFT JOIN MOXPRS C ON A.PWH003=C.PRS001 AND A.PWH004=C.PRS002 " );
            strSql . AppendFormat ( "WHERE PWH001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public CarpenterEntity . ProductionPaintWeekPWGEntity GetDataTableHead ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PWG001,PWG003,PWG004,PWG005,PWG007,PWG008,PWG009 FROM MOXPWG " );
            strSql . AppendFormat ( "WHERE PWG001='{0}'" ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                return GetModel ( dt . Rows [ 0 ] );
            }
            else
                return null;
        }

        public CarpenterEntity . ProductionPaintWeekPWGEntity GetModel ( DataRow row )
        {
            CarpenterEntity . ProductionPaintWeekPWGEntity model = new CarpenterEntity . ProductionPaintWeekPWGEntity ( );

            if ( row != null )
            {
                if ( row [ "PWG001" ] != null )
                {
                    model . PWG001 = row [ "PWG001" ] . ToString ( );
                }
                //if ( row [ "PWG002" ] != null && row [ "PWG002" ] . ToString ( ) != "" )
                //{
                //    model . PWG002 = DateTime . Parse ( row [ "PWG002" ] . ToString ( ) );
                //}
                if ( row [ "PWG003" ] != null && row [ "PWG003" ] . ToString ( ) != "" )
                {
                    model . PWG003 = DateTime . Parse ( row [ "PWG003" ] . ToString ( ) );
                }
                if ( row [ "PWG004" ] != null && row [ "PWG004" ] . ToString ( ) != "" )
                {
                    model . PWG004 = DateTime . Parse ( row [ "PWG004" ] . ToString ( ) );
                }
                if ( row [ "PWG005" ] != null && row [ "PWG005" ] . ToString ( ) != "" )
                {
                    model . PWG005 = DateTime . Parse ( row [ "PWG005" ] . ToString ( ) );
                }
                //if ( row [ "PWG006" ] != null )
                //{
                //    model . PWG006 = row [ "PWG006" ] . ToString ( );
                //}
                if ( row [ "PWG007" ] != null && row [ "PWG007" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "PWG007" ] . ToString ( ) == "1" ) || ( row [ "PWG007" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . PWG007 = true;
                    }
                    else
                    {
                        model . PWG007 = false;
                    }
                }
                if ( row [ "PWG008" ] != null && row [ "PWG008" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "PWG008" ] . ToString ( ) == "1" ) || ( row [ "PWG008" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . PWG008 = true;
                    }
                    else
                    {
                        model . PWG008 = false;
                    }
                }
                if ( row [ "PWG009" ] != null )
                {
                    model . PWG009 = row [ "PWG009" ] . ToString ( );
                }
                //if ( row [ "PWG010" ] != null )
                //{
                //    model . PWG010 = row [ "PWG010" ] . ToString ( );
                //}
                //if ( row [ "PWG011" ] != null )
                //{
                //    model . PWG011 = row [ "PWG011" ] . ToString ( );
                //}
                //if ( row [ "PWG012" ] != null )
                //{
                //    model . PWG012 = row [ "PWG012" ] . ToString ( );
                //}
                //if ( row [ "PWG013" ] != null )
                //{
                //    model . PWG013 = row [ "PWG013" ] . ToString ( );
                //}
                //if ( row [ "PWG014" ] != null )
                //{
                //    model . PWG014 = row [ "PWG014" ] . ToString ( );
                //}
                //if ( row [ "PWG015" ] != null )
                //{
                //    model . PWG015 = row [ "PWG015" ] . ToString ( );
                //}
                //if ( row [ "PWG016" ] != null )
                //{
                //    model . PWG016 = row [ "PWG016" ] . ToString ( );
                //}
                //if ( row [ "PWG017" ] != null )
                //{
                //    model . PWG017 = row [ "PWG017" ] . ToString ( );
                //}
                //if ( row [ "PWG018" ] != null )
                //{
                //    model . PWG018 = row [ "PWG018" ] . ToString ( );
                //}
            }
            return model;
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable TablePrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (SELECT PWH003,CASE WHEN PWH002!='' THEN '上周遗留' WHEN PWH010=1 THEN '预排' ELSE OPI003 END OPI003,PWH005,PWH006,OPI006,OPI007,PWH007,PWH009,PWH014,PWH016,PRS010 FROM MOXPWH A LEFT JOIN MOXOPI B ON A.PWH004=B.OPI001  LEFT JOIN MOXPDP C ON A.PWH003=C.PDP001 AND A.PWH004=C.PDP002 LEFT JOIN MOXPRS D ON A.PWH003=D.PRS001 AND A.PWH004=D.PRS002 " );
            strSql . AppendFormat ( "WHERE PWH001='{0}') " ,oddNum );
            strSql . Append ( "SELECT *,CASE WHEN OPI003='上周遗留' THEN 1 WHEN OPI003='预排' THEN 3 ELSE 2 END OPI FROM CET ORDER BY OPI" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable TablePrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PWG009,PWG003,PWG004,PWG005,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PWH014*OPI004))) PWH FROM MOXPWG B LEFT JOIN MOXPWH A ON A.PWH001=B.PWG001  LEFT JOIN MOXOPI C ON A.PWH004=C.OPI001 " );
            strSql . AppendFormat ( "WHERE PWG001='{0}' " ,oddNum );
            strSql . Append ( "GROUP BY PWG009 ,PWG003 ,PWG004 ,PWG005" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
