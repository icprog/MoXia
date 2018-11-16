using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;
using System . Collections;

namespace CarpenterBll . Dao
{
    public class PlanMachinDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableView ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,PMD001,PMD002,OPI003,PMD003,PMD004,PMD005,PMD006,OPI006,OPI007,OPI004,PMD007,PMD008,PMD009,CASE PMD010 WHEN 0 THEN '正式' ELSE '预排' END PMD010 FROM MOXPMD A INNER JOIN MOXOPI B ON A.PMD004=B.OPI001 " );
            strSql . AppendFormat ( "WHERE PMD001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PMC001,PMC009,PMC003,PMC004,PMC005,SUM(OPI004*PMD007) PMD007 FROM MOXPMC A INNER JOIN MOXPMD B ON A.PMC001=B.PMD001 INNER JOIN MOXOPI C ON B.PMD004=C.OPI001 GROUP BY PMC001,PMC009,PMC003,PMC004,PMC005 ORDER BY PMC001 DESC" );
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public CarpenterEntity.PlanMachinPMCEntity GetDataTableMain ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PMC001,PMC003,PMC004,PMC005,PMC007,PMC008,PMC009 FROM MOXPMC " );
            strSql . Append ( "WHERE PMC001=@PMC001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMC001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
                return GetList ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public CarpenterEntity . PlanMachinPMCEntity GetList ( DataRow row )
        {
            CarpenterEntity . PlanMachinPMCEntity model = new CarpenterEntity . PlanMachinPMCEntity ( );

            if ( row != null )
            {
                if ( row [ "PMC001" ] != null )
                {
                    model . PMC001 = row [ "PMC001" ] . ToString ( );
                }
                if ( row [ "PMC003" ] != null && row [ "PMC003" ] . ToString ( ) != "" )
                {
                    model . PMC003 = DateTime . Parse ( row [ "PMC003" ] . ToString ( ) );
                }
                if ( row [ "PMC004" ] != null && row [ "PMC004" ] . ToString ( ) != "" )
                {
                    model . PMC004 = DateTime . Parse ( row [ "PMC004" ] . ToString ( ) );
                }
                if ( row [ "PMC005" ] != null && row [ "PMC005" ] . ToString ( ) != "" )
                {
                    model . PMC005 = DateTime . Parse ( row [ "PMC005" ] . ToString ( ) );
                }
                if ( row [ "PMC007" ] != null && row [ "PMC007" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "PMC007" ] . ToString ( ) == "1" ) || ( row [ "PMC007" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . PMC007 = true;
                    }
                    else
                    {
                        model . PMC007 = false;
                    }
                }
                if ( row [ "PMC008" ] != null && row [ "PMC008" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "PMC008" ] . ToString ( ) == "1" ) || ( row [ "PMC008" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . PMC008 = true;
                    }
                    else
                    {
                        model . PMC008 = false;
                    }
                }
                if ( row [ "PMC009" ] != null )
                {
                    model . PMC009 = row [ "PMC009" ] . ToString ( );
                }
            }

            return model;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,DataTable table)
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            if ( table != null && table . Rows . Count > 0 )
            {
                CarpenterEntity . PlanMachinPMDEntity _modePLT = new CarpenterEntity . PlanMachinPMDEntity ( );
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _modePLT . PMD002 = table . Rows [ i ] [ "PMD002" ] . ToString ( );
                    _modePLT . PMD003 = table . Rows [ i ] [ "PMD003" ] . ToString ( );
                    _modePLT . PMD004 = table . Rows [ i ] [ "PMD004" ] . ToString ( );
                    //遗留删除不改变跟踪表数据
                    if ( string . IsNullOrEmpty ( _modePLT . PMD002 ) )
                    {
                        editPST ( SQLString ,strSql ,_modePLT );
                        _modePLT . PMD008 = null;
                        edit_Prs ( _modePLT ,strSql ,SQLString );
                    }

                    edit_pas ( SQLString ,strSql ,_modePLT ,false );
                }
            }

            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPMD " );
            strSql . Append ( " WHERE PMD001=@PMD001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PMD001", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = oddNum;
            SQLString . Add ( strSql ,parameters );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPMC " );
            strSql . Append ( " WHERE PMC001=@PMC001" );
            SqlParameter [ ] parameter = {
                    new SqlParameter("@PMC001", SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;
            SQLString . Add ( strSql ,parameter );


            return SqlHelper . ExecuteSqlTran ( SQLString );
        }


        /// <summary>
        /// 编辑机加工跟踪表周次为空
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="_modePLT"></param>
        void editPST ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanMachinPMDEntity _modePLT )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXPST SET PST023='' WHERE PST001='{0}' AND PST002='{1}'" ,_modePLT . PMD003 ,_modePLT . PMD004 );
            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// 编辑生产部生产进度跟踪表机加工计划完成时间
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_Prs ( CarpenterEntity . PlanMachinPMDEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPRS SET " );
            strSql . Append ( "PRS009=@PRS009 " );
            strSql . Append ( "WHERE PRS001=@PRS001 AND PRS002=@PRS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PRS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS009",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _modelPLT . PMD003;
            parameter [ 1 ] . Value = _modelPLT . PMD004;
            parameter [ 2 ] . Value = _modelPLT . PMD008;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 编辑跟踪表周计划是否审核的比较
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="model"></param>
        /// <param name="state"></param>
        void edit_pas ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanMachinPMDEntity model ,bool state )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPST SET " );
            strSql . Append ( "PST030=@PST030 " );
            strSql . Append ( "WHERE PST001=@PST001 AND PST002=@PST002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PST001",SqlDbType.NVarChar,20),
                new SqlParameter("@PST002",SqlDbType.NVarChar,20),
                new SqlParameter("@PST030",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = model . PMD003;
            parameter [ 1 ] . Value = model . PMD004;
            parameter [ 2 ] . Value = state;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 编辑保存数据
        /// </summary>
        /// <param name="_pmc"></param>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public bool Edit (CarpenterEntity.PlanMachinPMCEntity _pmc,DataTable tableView )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _pmc . PMC002 = UserInformation . dt ( );
            _pmc . PMC006 = UserInformation . UserName;
            edit_pmc ( SQLString ,strSql ,_pmc );

            CarpenterEntity . PlanMachinPMDEntity _pmd = new CarpenterEntity . PlanMachinPMDEntity ( );
            _pmd . PMD001 = _pmc . PMC001;
            _pmd . PMD011 = UserInformation . dt ( );
            _pmd . PMD012 = UserInformation . UserName;
            DataTable dt = GetDataTable ( _pmd . PMD001 );
            for ( int i = 0 ; i < tableView . Rows . Count ; i++ )
            {
                _pmd . PMD002 = tableView . Rows [ i ] [ "PMD002" ] . ToString ( );
                _pmd . PMD003 = tableView . Rows [ i ] [ "PMD003" ] . ToString ( );
                _pmd . PMD004 = tableView . Rows [ i ] [ "PMD004" ] . ToString ( );
                _pmd . PMD005 = tableView . Rows [ i ] [ "PMD005" ] . ToString ( );
                _pmd . PMD006 = tableView . Rows [ i ] [ "PMD006" ] . ToString ( );
                _pmd . PMD007 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PMD007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "PMD007" ] . ToString ( ) );
                _pmd . PMD008 = Convert . ToDateTime ( tableView . Rows [ i ] [ "PMD008" ] . ToString ( ) );
                _pmd . PMD009 = tableView . Rows [ i ] [ "PMD009" ] . ToString ( );
                //_pmd . PMD010 = ( bool ) tableView . Rows [ i ] [ "PMD010" ];
                _pmd . PMD010 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PMD010" ] . ToString ( ) ) == true ? false : tableView . Rows [ i ] [ "PMD010" ] . ToString ( ) . Equals ( "正式" ) == true ? false : true;
                _pmd . idx = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( dt . Select ( "PMD002='" + _pmd . PMD002 + "' AND PMD003='" + _pmd . PMD003 + "' AND PMD004='" + _pmd . PMD004 + "'" ) . Length > 0 )
                    edit_pmd ( SQLString ,strSql ,_pmd );

                if ( _pmd . PMD010 == false && Exists_edit_Prs ( _pmd . PMD003 ,_pmd . PMD004 ) == true )
                    edit_Prs ( _pmd ,strSql ,SQLString );
            }

            for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            {
                _pmd . PMD002 = dt . Rows [ i ] [ "PMD002" ] . ToString ( );
                _pmd . PMD003 = dt . Rows [ i ] [ "PMD003" ] . ToString ( );
                _pmd . PMD004 = dt . Rows [ i ] [ "PMD004" ] . ToString ( );
                _pmd . idx = string . IsNullOrEmpty ( dt . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( tableView . Select ( "PMD002='" + _pmd . PMD002 + "' AND PMD003='" + _pmd . PMD003 + "' AND PMD004='" + _pmd . PMD004 + "'" ) . Length < 1 )
                {
                    delete_pmd ( SQLString ,strSql ,_pmd );
                    editPST ( SQLString ,strSql ,_pmd );
                    edit_pas ( SQLString ,strSql ,_pmd ,false );
                    _pmd . PMD008 = null;
                    edit_Prs ( _pmd ,strSql ,SQLString );
                }
            }


            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        void edit_pmc ( Hashtable SQLString ,StringBuilder strSql,CarpenterEntity . PlanMachinPMCEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXPMC set " );
            strSql . Append ( "PMC002=@PMC002," );
            strSql . Append ( "PMC003=@PMC003," );
            strSql . Append ( "PMC004=@PMC004," );
            strSql . Append ( "PMC005=@PMC005," );
            strSql . Append ( "PMC006=@PMC006 " );
            strSql . Append ( " where PMC001=@PMC001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PMC001", SqlDbType.VarChar,20),
                    new SqlParameter("@PMC002", SqlDbType.Date,3),
                    new SqlParameter("@PMC003", SqlDbType.Date,3),
                    new SqlParameter("@PMC004", SqlDbType.Date,3),
                    new SqlParameter("@PMC005", SqlDbType.Date,3),
                    new SqlParameter("@PMC006", SqlDbType.VarChar,20)
            };
            parameters [ 0 ] . Value = model . PMC001;
            parameters [ 1 ] . Value = model . PMC002;
            parameters [ 2 ] . Value = model . PMC003;
            parameters [ 3 ] . Value = model . PMC004;
            parameters [ 4 ] . Value = model . PMC005;
            parameters [ 5 ] . Value = model . PMC006;
            SQLString . Add ( strSql ,parameters );
        }

        void edit_pmd ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanMachinPMDEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXPMD set " );
            strSql . Append ( "PMD001=@PMD001," );
            strSql . Append ( "PMD002=@PMD002," );
            strSql . Append ( "PMD003=@PMD003," );
            strSql . Append ( "PMD004=@PMD004," );
            strSql . Append ( "PMD005=@PMD005," );
            strSql . Append ( "PMD006=@PMD006," );
            strSql . Append ( "PMD007=@PMD007," );
            strSql . Append ( "PMD008=@PMD008," );
            strSql . Append ( "PMD009=@PMD009," );
            //strSql . Append ( "PMD010=@PMD010," );
            strSql . Append ( "PMD011=@PMD011," );
            strSql . Append ( "PMD012=@PMD012 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PMD001", SqlDbType.VarChar,20),
                    new SqlParameter("@PMD002", SqlDbType.VarChar,20),
                    new SqlParameter("@PMD003", SqlDbType.VarChar,20),
                    new SqlParameter("@PMD004", SqlDbType.VarChar,20),
                    new SqlParameter("@PMD005", SqlDbType.VarChar,20),
                    new SqlParameter("@PMD006", SqlDbType.VarChar,20),
                    new SqlParameter("@PMD007", SqlDbType.Int,4),
                    new SqlParameter("@PMD008", SqlDbType.Date,3),
                    new SqlParameter("@PMD009", SqlDbType.VarChar,200),
                    //new SqlParameter("@PMD010", SqlDbType.VarChar,20),
                    new SqlParameter("@PMD011", SqlDbType.Date,3),
                    new SqlParameter("@PMD012", SqlDbType.VarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)};
            parameters [ 0 ] . Value = model . PMD001;
            parameters [ 1 ] . Value = model . PMD002;
            parameters [ 2 ] . Value = model . PMD003;
            parameters [ 3 ] . Value = model . PMD004;
            parameters [ 4 ] . Value = model . PMD005;
            parameters [ 5 ] . Value = model . PMD006;
            parameters [ 6 ] . Value = model . PMD007;
            parameters [ 7 ] . Value = model . PMD008;
            parameters [ 8 ] . Value = model . PMD009;
            //parameters [ 9 ] . Value = model . PMD010;
            parameters [ 9 ] . Value = model . PMD011;
            parameters [ 10 ] . Value = model . PMD012;
            parameters [ 11 ] . Value = model . idx;
            SQLString . Add ( strSql ,parameters );
        }

        void delete_pmd ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanMachinPMDEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPMD " );
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
            strSql . Append ( "SELECT idx,PMD002,PMD003,PMD004 " );
            strSql . Append ( " FROM MOXPMD " );
            strSql . Append ( " WHERE PMD001=@PMD001" );
            SqlParameter [ ] parameters = {
                new SqlParameter("@PMD001",SqlDbType.NVarChar,20)
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
        /// 审核
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examine ( string oddNum ,bool state ,string programId ,string userNum ,DataTable table)
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPMC SET " );
            strSql . Append ( "PMC007=@PMC007," );
            strSql . Append ( "PMC002=@PMC002," );
            strSql . Append ( "PMC006=@PMC006 " );
            strSql . Append ( "WHERE PMC001=@PMC001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMC007",SqlDbType.Bit),
                new SqlParameter("@PMC001",SqlDbType.NVarChar,20),
                new SqlParameter("@PMC002",SqlDbType.Date,3),
                new SqlParameter("@PMC006",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = state;
            parameter [ 1 ] . Value = oddNum;
            parameter [ 2 ] . Value = UserInformation . dt ( );
            parameter [ 3 ] . Value = UserInformation . UserName;
            SQLString . Add ( strSql ,parameter );
            if ( state == false )
                CarpenterBll . Examine . writeToReview ( programId ,oddNum ,userNum ,SQLString );
            else
                CarpenterBll . Examine . deleteToReview ( programId ,oddNum ,userNum ,SQLString );

            CarpenterEntity . PlanMachinPMDEntity model = new CarpenterEntity . PlanMachinPMDEntity ( );

            if ( table != null && table . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    model . PMD003 = table . Rows [ i ] [ "PMD003" ] . ToString ( );
                    model . PMD004 = table . Rows [ i ] [ "PMD004" ] . ToString ( );
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
            strSql . Append ( "UPDATE MOXPMC SET " );
            strSql . Append ( "PMC008=@PMC008," );
            strSql . Append ( "PMC002=@PMC002," );
            strSql . Append ( "PMC006=@PMC006 " );
            strSql . Append ( "WHERE PMC001=@PMC001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PMC008",SqlDbType.Bit),
                new SqlParameter("@PMC001",SqlDbType.NVarChar,20),
                new SqlParameter("@PMC002",SqlDbType.Date,3),
                new SqlParameter("@PMC006",SqlDbType.NVarChar,20)
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
        public DataTable GetDataTablePrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (SELECT CASE WHEN PMD002!='' THEN '上周遗留' WHEN PMD010=1 THEN '预排' ELSE OPI003 END OPI003,PMD003,PMD005,PMD006,OPI006,OPI007,PMD007,SUBSTRING(CONVERT(VARCHAR,PMD008, 11),4,5) PMD008,PMD009 FROM MOXPMD A LEFT JOIN MOXOPI B ON A.PMD004=B.OPI001 " );
            strSql . AppendFormat ( "WHERE PMD001='{0}') " ,oddNum );
            strSql . Append ( "SELECT *,CASE WHEN OPI003='上周遗留' THEN 1 WHEN OPI003='预排' THEN '3' ELSE '2' END OPI FROM CET ORDER BY OPI,OPI003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PMC009,PMC003,PMC004,PMC005,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PMD007*OPI004))) PLS FROM MOXPMC A LEFT JOIN MOXPMD B ON A.PMC001=B.PMD001 LEFT JOIN MOXOPI C ON B.PMD004=C.OPI001 " );
            strSql . AppendFormat ( "WHERE PMC001='{0}'" ,oddNum );
            strSql . Append ( "GROUP BY PMC009,PMC003,PMC004,PMC005" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="batNum"></param>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public bool Exists ( string oddNum ,string batNum ,string proNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPME WHERE PME009='{0}' AND PME002='{1}' AND PME003='{2}'" ,oddNum ,batNum ,proNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

    }
}
