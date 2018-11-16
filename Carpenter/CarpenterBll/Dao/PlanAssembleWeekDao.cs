using System . Data;
using System . Text;
using StudentMgr;
using System;
using System . Collections;
using System . Data . SqlClient;
using System . Collections . Generic;

namespace CarpenterBll . Dao
{
    public class PlanAssembleWeekDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLA001,PLA009,PLA003,PLA004,PLA005,SUM(OPI004*PLB014) PLB014 FROM MOXPLA A INNER JOIN MOXPLB B ON A.PLA001=B.PLB001 INNER JOIN MOXOPI C ON B.PLB004=C.OPI001 GROUP BY PLA001,PLA009,PLA003,PLA004,PLA005 ORDER BY PLA001 DESC" );
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableView ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,A.PLB001,PLB002,PLB003,OPI003,PLB004,PLB005,PLB006,OPI004,OPI006,OPI007,PLB007,PLB009,CASE PLB010 WHEN 0 THEN '正式' ELSE '预排' END PLB010,PLB014,PLB016,PAS011,PRS010  FROM MOXPLB A LEFT JOIN MOXOPI B ON A.PLB004=B.OPI001 LEFT JOIN MOXPAS C ON A.PLB003=C.PAS001 AND A.PLB004=C.PAS002 LEFT JOIN MOXPRS D ON A.PLB003=D.PRS001 AND A.PLB004=D.PRS002 " );
            strSql . AppendFormat ( "WHERE PLB001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public CarpenterEntity . PlanAssembleWeekPLAEntity GetDataTableHead ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLA001,PLA003,PLA004,PLA005,PLA007,PLA008,PLA009 FROM MOXPLA " );
            strSql . AppendFormat ( "WHERE PLA001='{0}'" ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                return GetModel ( dt . Rows [ 0 ] );
            }
            else
                return null;
        }

        public CarpenterEntity . PlanAssembleWeekPLAEntity GetModel ( DataRow row )
        {
            CarpenterEntity . PlanAssembleWeekPLAEntity model = new CarpenterEntity . PlanAssembleWeekPLAEntity ( );

            if ( row != null )
            {
                if ( row [ "PLA001" ] != null )
                {
                    model . PLA001 = row [ "PLA001" ] . ToString ( );
                }
                //if ( row [ "PLA002" ] != null && row [ "PLA002" ] . ToString ( ) != "" )
                //{
                //    model . PLA002 = DateTime . Parse ( row [ "PLA002" ] . ToString ( ) );
                //}
                if ( row [ "PLA003" ] != null && row [ "PLA003" ] . ToString ( ) != "" )
                {
                    model . PLA003 = DateTime . Parse ( row [ "PLA003" ] . ToString ( ) );
                }
                if ( row [ "PLA004" ] != null && row [ "PLA004" ] . ToString ( ) != "" )
                {
                    model . PLA004 = DateTime . Parse ( row [ "PLA004" ] . ToString ( ) );
                }
                if ( row [ "PLA005" ] != null && row [ "PLA005" ] . ToString ( ) != "" )
                {
                    model . PLA005 = DateTime . Parse ( row [ "PLA005" ] . ToString ( ) );
                }
                //if ( row [ "PLA006" ] != null )
                //{
                //    model . PLA006 = row [ "PLA006" ] . ToString ( );
                //}
                if ( row [ "PLA007" ] != null && row [ "PLA007" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "PLA007" ] . ToString ( ) == "1" ) || ( row [ "PLA007" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . PLA007 = true;
                    }
                    else
                    {
                        model . PLA007 = false;
                    }
                }
                if ( row [ "PLA008" ] != null && row [ "PLA008" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "PLA008" ] . ToString ( ) == "1" ) || ( row [ "PLA008" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . PLA008 = true;
                    }
                    else
                    {
                        model . PLA008 = false;
                    }
                }
                if ( row [ "PLA009" ] != null )
                {
                    model . PLA009 = row [ "PLA009" ] . ToString ( );
                }
                //if ( row [ "PLA010" ] != null )
                //{
                //    model . PLA010 = row [ "PLA010" ] . ToString ( );
                //}
                //if ( row [ "PLA011" ] != null )
                //{
                //    model . PLA011 = row [ "PLA011" ] . ToString ( );
                //}
                //if ( row [ "PLA012" ] != null )
                //{
                //    model . PLA012 = row [ "PLA012" ] . ToString ( );
                //}
                //if ( row [ "PLA013" ] != null )
                //{
                //    model . PLA013 = row [ "PLA013" ] . ToString ( );
                //}
                //if ( row [ "PLA014" ] != null )
                //{
                //    model . PLA014 = row [ "PLA014" ] . ToString ( );
                //}
                //if ( row [ "PLA015" ] != null )
                //{
                //    model . PLA015 = row [ "PLA015" ] . ToString ( );
                //}
                //if ( row [ "PLA016" ] != null )
                //{
                //    model . PLA016 = row [ "PLA016" ] . ToString ( );
                //}
                //if ( row [ "PLA017" ] != null )
                //{
                //    model . PLA017 = row [ "PLA017" ] . ToString ( );
                //}
                //if ( row [ "PLA018" ] != null )
                //{
                //    model . PLA018 = row [ "PLA018" ] . ToString ( );
                //}
            }
            return model;
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            if ( table != null && table . Rows . Count > 0 )
            {
                CarpenterEntity . PlanAssembleWeekPLBEntity _plb = new CarpenterEntity . PlanAssembleWeekPLBEntity ( );
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _plb . PLB002 = table . Rows [ i ] [ "PLB002" ] . ToString ( );
                    _plb . PLB003 = table . Rows [ i ] [ "PLB003" ] . ToString ( );
                    _plb . PLB004 = table . Rows [ i ] [ "PLB004" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( _plb . PLB002 ) )
                    {
                        editPAS ( SQLString ,strSql ,_plb );
                        _plb . PLB016 = null;
                        edit_Prs ( _plb ,strSql ,SQLString );
                        _plb . PLB016 = null;
                        if ( _plb . PLB010 == false && Exists_edit_Pas ( _plb . PLB003 ,_plb . PLB004 ) == true )
                            edit_Pas ( _plb ,strSql ,SQLString );
                    }

                    edit_pas ( SQLString ,strSql ,_plb ,false );

                }
            }

            strSql = new StringBuilder ( );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPLB " );
            strSql . Append ( " WHERE PLB001=@PLB001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PLB001", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = oddNum;
            SQLString . Add ( strSql ,parameters );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPLA " );
            strSql . Append ( " WHERE PLA001=@PLA001" );
            SqlParameter [ ] parameter = {
                    new SqlParameter("@PLA001", SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 编辑组装跟踪表计划完成时间/周计划计划完成日为空
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="_modePLT"></param>
        void editPAS ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanAssembleWeekPLBEntity _modePLT )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXPAS SET PAS029='' WHERE PAS001='{0}' AND PAS002='{1}'" ,_modePLT . PLB003 ,_modePLT . PLB004 );
            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// 编辑跟踪表状态
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="model"></param>
        /// <param name="state"></param>
        void edit_pas ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanAssembleWeekPLBEntity model ,bool state )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPAS SET " );
            strSql . Append ( "PAS030=@PAS030 " );
            strSql . Append ( "WHERE PAS001=@PAS001 AND PAS002=@PAS002" );
            SqlParameter [ ] parameter = {
                   new SqlParameter("@PAS001",SqlDbType.NVarChar,20),
                   new SqlParameter("@PAS002",SqlDbType.NVarChar,20),
                   new SqlParameter("@PAS030",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = model . PLB003;
            parameter [ 1 ] . Value = model . PLB004;
            parameter [ 2 ] . Value = state;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 编辑生产部生产进度跟踪表组装计划完成时间
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_Prs ( CarpenterEntity . PlanAssembleWeekPLBEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPRS SET " );
            strSql . Append ( "PRS011=@PRS011 " );
            strSql . Append ( "WHERE PRS001=@PRS001 AND PRS002=@PRS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PRS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS011",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _modelPLT . PLB003;
            parameter [ 1 ] . Value = _modelPLT . PLB004;
            parameter [ 2 ] . Value = _modelPLT . PLB016;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 编辑保存数据
        /// </summary>
        /// <param name="_pmc"></param>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . PlanAssembleWeekPLAEntity _pla ,DataTable tableView )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _pla . PLA002 = UserInformation . dt ( );
            _pla . PLA006 = UserInformation . UserName;
            edit_pmc ( SQLString ,strSql ,_pla );

            CarpenterEntity . PlanAssembleWeekPLBEntity _plb = new CarpenterEntity . PlanAssembleWeekPLBEntity ( );
            _plb . PLB001 = _pla . PLA001;
            _plb . PLB011 = UserInformation . dt ( );
            _plb . PLB012 = UserInformation . UserName;
            DataTable dt = GetDataTable ( _plb . PLB001 );
            for ( int i = 0 ; i < tableView . Rows . Count ; i++ )
            {
                _plb . PLB002 = tableView . Rows [ i ] [ "PLB002" ] . ToString ( );
                _plb . PLB003 = tableView . Rows [ i ] [ "PLB003" ] . ToString ( );
                _plb . PLB004 = tableView . Rows [ i ] [ "PLB004" ] . ToString ( );
                _plb . PLB005 = tableView . Rows [ i ] [ "PLB005" ] . ToString ( );
                _plb . PLB006 = tableView . Rows [ i ] [ "PLB006" ] . ToString ( );
                _plb . PLB007 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PLB007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "PLB007" ] . ToString ( ) );
                _plb . PLB009 = tableView . Rows [ i ] [ "PLB009" ] . ToString ( );
                //_plb . PLB010 = ( bool ) tableView . Rows [ i ] [ "PLB010" ];
                _plb . PLB010 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PLB010" ] . ToString ( ) ) == true ? false : tableView . Rows [ i ] [ "PLB010" ] . ToString ( ) . Equals ( "正式" ) == true ? false : true;
                _plb . PLB014 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PLB014" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "PLB014" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PLB016" ] . ToString ( ) ) )
                    _plb . PLB016 = null;
                else
                    _plb . PLB016 = Convert . ToDateTime ( tableView . Rows [ i ] [ "PLB016" ] . ToString ( ) );
                _plb . idx = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( _plb . idx > 0 )
                    //if ( dt . Select ( "PLB002='" + _plb . PLB002 + "' AND PLB003='" + _plb . PLB003 + "' AND PLB004='" + _plb . PLB004 + "'" ) . Length > 0 )
                    edit_pmd ( SQLString ,strSql ,_plb );

                if ( _plb . PLB010 == false && Exists_edit_Prs ( _plb . PLB003 ,_plb . PLB004 ) == true )
                    edit_Prs ( _plb ,strSql ,SQLString );
                
                if ( _plb . PLB010 == false && Exists_edit_Pas ( _plb . PLB003 ,_plb . PLB004 ) == true )
                    edit_Pas ( _plb ,strSql ,SQLString );
            }

            for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            {
                _plb . PLB002 = dt . Rows [ i ] [ "PLB002" ] . ToString ( );
                _plb . PLB003 = dt . Rows [ i ] [ "PLB003" ] . ToString ( );
                _plb . PLB004 = dt . Rows [ i ] [ "PLB004" ] . ToString ( );
                _plb . idx = string . IsNullOrEmpty ( dt . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( tableView . Select ( "PLB002='" + _plb . PLB002 + "' AND PLB003='" + _plb . PLB003 + "' AND PLB004='" + _plb . PLB004 + "'" ) . Length < 1 )
                {
                    delete_pmd ( SQLString ,strSql ,_plb );
                    editPAS ( SQLString ,strSql ,_plb );
                    _plb . PLB016 = null;
                    if ( _plb . PLB010 == false && Exists_edit_Pas ( _plb . PLB003 ,_plb . PLB004 ) == true )
                        edit_Pas ( _plb ,strSql ,SQLString );

                    edit_pas ( SQLString ,strSql ,_plb ,false );
                }
            }


            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        void edit_pmc ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanAssembleWeekPLAEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPLA SET " );
            strSql . Append ( "PLA002=@PLA002," );
            strSql . Append ( "PLA003=@PLA003," );
            strSql . Append ( "PLA004=@PLA004," );
            strSql . Append ( "PLA005=@PLA005," );
            strSql . Append ( "PLA006=@PLA006 " );
            strSql . Append ( " where PLA001=@PLA001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PLA001", SqlDbType.VarChar,20),
                    new SqlParameter("@PLA002", SqlDbType.Date,3),
                    new SqlParameter("@PLA003", SqlDbType.Date,3),
                    new SqlParameter("@PLA004", SqlDbType.Date,3),
                    new SqlParameter("@PLA005", SqlDbType.Date,3),
                    new SqlParameter("@PLA006", SqlDbType.VarChar,20)
            };
            parameters [ 0 ] . Value = model . PLA001;
            parameters [ 1 ] . Value = model . PLA002;
            parameters [ 2 ] . Value = model . PLA003;
            parameters [ 3 ] . Value = model . PLA004;
            parameters [ 4 ] . Value = model . PLA005;
            parameters [ 5 ] . Value = model . PLA006;
            SQLString . Add ( strSql ,parameters );
        }

        void edit_pmd ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanAssembleWeekPLBEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXPLB set " );
            strSql . Append ( "PLB009=@PLB009," );
            strSql . Append ( "PLB011=@PLB011," );
            strSql . Append ( "PLB012=@PLB012, " );
            strSql . Append ( "PLB014=@PLB014, " );
            strSql . Append ( "PLB016=@PLB016 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PLB009", SqlDbType.VarChar,200),
                    new SqlParameter("@PLB011", SqlDbType.Date,3),
                    new SqlParameter("@PLB012", SqlDbType.VarChar,20),
                    new SqlParameter("@PLB014", SqlDbType.Int,4),
                    new SqlParameter("@PLB016", SqlDbType.Date,3),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . PLB009;
            parameters [ 1 ] . Value = model . PLB011;
            parameters [ 2 ] . Value = model . PLB012;
            parameters [ 3 ] . Value = model . PLB014;
            parameters [ 4 ] . Value = model . PLB016;
            parameters [ 5 ] . Value = model . idx;
            SQLString . Add ( strSql ,parameters );
        }

        void delete_pmd ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanAssembleWeekPLBEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPLB " );
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
            strSql . Append ( "SELECT idx,PLB002,PLB003,PLB004 " );
            strSql . Append ( " FROM MOXPLB " );
            strSql . Append ( " WHERE PLB001=@PLB001" );
            SqlParameter [ ] parameters = {
                new SqlParameter("@PLB001",SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = oddNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameters );
        }


        /// <summary>
        /// 生产部生产跟踪表是否有此数据
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        bool Exists_edit_Prs ( string weekEnds ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXPRS " );
            strSql . AppendFormat ( "WHERE PRS001='{0}' AND PRS002='{1}'" ,weekEnds ,productNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 组装跟踪表是否有此数据
        /// </summary>
        /// <returns></returns>
        bool Exists_edit_Pas ( string weekEnds ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXPAS " );
            strSql . AppendFormat ( "WHERE PAS001='{0}' AND PAS002='{1}'" ,weekEnds ,productNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 编辑组装生产进度跟踪表组装计划完成时间
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_Pas ( CarpenterEntity . PlanAssembleWeekPLBEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPAS SET " );
            strSql . Append ( "PAS007=@PAS007 " );
            strSql . Append ( "WHERE PAS001=@PAS001 AND PAS002=@PAS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PAS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PAS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PAS007",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _modelPLT . PLB003;
            parameter [ 1 ] . Value = _modelPLT . PLB004;
            parameter [ 2 ] . Value = _modelPLT . PLB016;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examine ( string oddNum ,bool state ,string programId ,DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPLA SET " );
            strSql . Append ( "PLA007=@PLA007," );
            strSql . Append ( "PLA002=@PLA002," );
            strSql . Append ( "PLA006=@PLA006 " );
            strSql . Append ( "WHERE PLA001=@PLA001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLA007",SqlDbType.Bit),
                new SqlParameter("@PLA001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLA002",SqlDbType.Date,3),
                new SqlParameter("@PLA006",SqlDbType.NVarChar,20)
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

            if ( table != null && table . Rows . Count > 0 )
            {
                CarpenterEntity . PlanAssembleWeekPLBEntity model = new CarpenterEntity . PlanAssembleWeekPLBEntity ( );

                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    model . PLB003 = table . Rows [ i ] [ "PLB003" ] . ToString ( );
                    model . PLB004 = table . Rows [ i ] [ "PLB004" ] . ToString ( );
                    if ( state )
                        edit_pas ( SQLString ,strSql ,model ,false );
                    else
                        edit_pas ( SQLString ,strSql ,model ,true );
                }
            }

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
            strSql . Append ( "UPDATE MOXPLA SET " );
            strSql . Append ( "PLA008=@PLA008," );
            strSql . Append ( "PLA002=@PLA002," );
            strSql . Append ( "PLA006=@PLA006 " );
            strSql . Append ( "WHERE PLA001=@PLA001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLA008",SqlDbType.Bit),
                new SqlParameter("@PLA001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLA002",SqlDbType.Date,3),
                new SqlParameter("@PLA006",SqlDbType.NVarChar,20)
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
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (SELECT PLB003,CASE WHEN PLB002!='' THEN '上周遗留' WHEN PLB010=1 THEN '预排' ELSE OPI003 END OPI003,PLB005,PLB006,OPI006,OPI007,PLB007,PLB009,PLB014,PLB016,PAS011,PRS010 FROM MOXPLB A LEFT JOIN MOXOPI B ON A.PLB004=B.OPI001 LEFT JOIN MOXPAS C ON A.PLB003=C.PAS001 AND A.PLB004=C.PAS002 LEFT JOIN MOXPRS D ON A.PLB003=D.PRS001 AND A.PLB004=D.PRS002 " );
            strSql . AppendFormat ( "WHERE PLB001='{0}') " ,oddNum );
            strSql . Append ( "SELECT *,CASE OPI003 WHEN '上周遗留' THEN 1 WHEN '预排' THEN 3 ELSE 2 END OPI FROM CET ORDER BY OPI,OPI003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLA009,PLA003,PLA004,PLA005,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PLB014*OPI004))) PLB FROM MOXPLA B LEFT JOIN MOXPLB A ON A.PLB001=B.PLA001 LEFT JOIN MOXOPI C ON A.PLB004=C.OPI001 " );
            strSql . AppendFormat ( "WHERE PLA001='{0}'" ,oddNum );
            strSql . Append ( "GROUP BY PLA009 ,PLA003 ,PLA004 ,PLA005" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
