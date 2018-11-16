using System . Data;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;
using System . Collections;
using System;

namespace CarpenterBll . Dao
{
    public class PlanStockDao
    {
        /// <summary>
        /// 获取备料查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLS001,PLS002,PLS003,PLS004,PLS005,SUM(PLT012*OPI004) PLS006 FROM MOXPLS A LEFT JOIN MOXPLT B ON A.PLS001=B.PLT001 LEFT JOIN MOXOPI C ON B.PLT004=C.OPI001 GROUP BY PLS001,PLS002,PLS003,PLS004,PLS005" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableHeader ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLS001,PLS002,PLS003,PLS004,PLS005,PLS008,PLS009 FROM MOXPLS " );
            strSql . Append ( "WHERE PLS001=@PLS001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLS001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableBody ( string oddNum )
        {
            //CASE WHEN PLT002!='' THEN '上周遗留' ELSE OPI003 END OPI003
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLT001,PLT002,PLT003,PLT004,PLT005,PLT006,PLT007,PLT008,PLT012,OPI003,OPI006,OPI007,OPI004,CASE PLT013 WHEN 0 THEN '正式' ELSE '预排' END PLT013 FROM MOXPLT A LEFT JOIN MOXOPI B ON A.PLT004=B.OPI001 " );
            strSql . Append ( "WHERE PLT001=@PLT001 " );
            strSql . Append ( "ORDER BY PLT002 DESC,PLT004 ASC " );
            //strSql . Append ( "ORDER BY OPI003 ASC,PLT003 ASC,PLT004 DESC" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLT001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,DataTable table)
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            //编辑备料跟踪表的周次为空
            strSql = new StringBuilder ( );

            if ( table != null && table . Rows . Count > 0 )
            {
                CarpenterEntity . PlanStockPLTEntity _modePLT = new CarpenterEntity . PlanStockPLTEntity ( );
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _modePLT . PLT002 = table . Rows [ i ] [ "PLT002" ] . ToString ( );
                    _modePLT . PLT003 = table . Rows [ i ] [ "PLT003" ] . ToString ( );
                    _modePLT . PLT004 = table . Rows [ i ] [ "PLT004" ] . ToString ( );
                    //遗留删除不改变跟踪表数据
                    if ( string . IsNullOrEmpty ( _modePLT . PLT002 ) )
                    {
                        editPST ( SQLString ,strSql ,_modePLT );
                        _modePLT . PLT007 = null;
                        edit_Prs ( _modePLT ,strSql ,SQLString );
                    }

                    edit_pas ( SQLString ,strSql ,_modePLT ,false );
                }
            }

            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPLS " );
            strSql . Append ( "WHERE PLS001=@PLS001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLS001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;
            SQLString . Add ( strSql ,parameter );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPLT " );
            strSql . Append ( "WHERE PLT001=@PLT001" );
            SqlParameter [ ] paramete = {
                new SqlParameter("@PLT001",SqlDbType.NVarChar,20)
            };
            paramete [ 0 ] . Value = oddNum;
            SQLString . Add ( strSql ,paramete );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Concell ( string oddNum,bool state )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPLS SET " );
            strSql . Append ( "PLS008=@PLS008 " );
            strSql . Append ( "WHERE PLS001=@PLS001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLS008",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = oddNum;
            parameter [ 1 ] . Value = state;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_modePLS"></param>
        /// <param name="tableQuery"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . PlanStockPLSEntity _modePLS ,DataTable tableQuery )
        {
            Hashtable SQLString = new Hashtable ( );
            _modePLS . PLS006 = getDate ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPLS SET " );
            strSql . Append ( "PLS002=@PLS002," );
            strSql . Append ( "PLS003=@PLS003," );
            strSql . Append ( "PLS004=@PLS004," );
            strSql . Append ( "PLS005=@PLS005," );
            strSql . Append ( "PLS006=@PLS006," );
            strSql . Append ( "PLS007=@PLS007 " );
            strSql . Append ( "WHERE PLS001=@PLS001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLS003",SqlDbType.Date),
                new SqlParameter("@PLS004",SqlDbType.Date),
                new SqlParameter("@PLS005",SqlDbType.Date),
                new SqlParameter("@PLS006",SqlDbType.Date),
                new SqlParameter("@PLS007",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modePLS . PLS001;
            parameter [ 1 ] . Value = _modePLS . PLS002;
            parameter [ 2 ] . Value = _modePLS . PLS003;
            parameter [ 3 ] . Value = _modePLS . PLS004;
            parameter [ 4 ] . Value = _modePLS . PLS005;
            parameter [ 5 ] . Value = _modePLS . PLS006;
            parameter [ 6 ] . Value = _modePLS . PLS007;
            SQLString . Add ( strSql ,parameter );

            CarpenterEntity . PlanStockPLTEntity _modePLT = new CarpenterEntity . PlanStockPLTEntity ( );
            _modePLT . PLT001 = _modePLS . PLS001;
            _modePLT . PLT009 = _modePLS . PLS006;
            _modePLT . PLT010 = _modePLS . PLS007;

            DataTable da = SqlHelper . ExecuteDataTable ( "SELECT PLT002,PLT003,PLT004 FROM MOXPLT WHERE PLT001='" + _modePLT . PLT001 + "'" );
            for ( int i = 0 ; i < tableQuery . Rows . Count ; i++ )
            {
                _modePLT . PLT002 = tableQuery . Rows [ i ] [ "PLT002" ] . ToString ( );
                _modePLT . PLT003 = tableQuery . Rows [ i ] [ "PLT003" ] . ToString ( );
                _modePLT . PLT004 = tableQuery . Rows [ i ] [ "PLT004" ] . ToString ( );
                _modePLT . PLT005 = tableQuery . Rows [ i ] [ "PLT005" ] . ToString ( );
                _modePLT . PLT006 = tableQuery . Rows [ i ] [ "PLT006" ] . ToString ( );
                _modePLT . PLT007 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "PLT007" ] . ToString ( ) ) == true ? getDate ( ) : Convert . ToDateTime ( tableQuery . Rows [ i ] [ "PLT007" ] . ToString ( ) );
                _modePLT . PLT008 = tableQuery . Rows [ i ] [ "PLT008" ] . ToString ( );
                _modePLT . PLT012 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "PLT012" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "PLT012" ] . ToString ( ) );
                //_modePLT . PLT013 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "PLT013" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( tableQuery . Rows [ i ] [ "PLT013" ] . ToString ( ) );
                _modePLT . PLT013 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "PLT013" ] . ToString ( ) ) == true ? false : tableQuery . Rows [ i ] [ "PLT013" ] . ToString ( ) . Equals ( "正式" ) == true ? false : true;
                if ( da . Select ( "PLT002='" + _modePLT . PLT002 + "' AND PLT003='" + _modePLT . PLT003 + "' AND PLT004='" + _modePLT . PLT004 + "'" ) . Length > 0 )
                    edit ( _modePLT ,strSql ,SQLString );

                if ( _modePLT . PLT013 == false && Exists_edit_Prs ( _modePLT . PLT003 ,_modePLT . PLT004 ) == true )
                    edit_Prs ( _modePLT ,strSql ,SQLString );
            }

            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _modePLT . PLT002 = da . Rows [ i ] [ "PLT002" ] . ToString ( );
                    _modePLT . PLT003 = da . Rows [ i ] [ "PLT003" ] . ToString ( );
                    _modePLT . PLT004 = da . Rows [ i ] [ "PLT004" ] . ToString ( );
                    if ( tableQuery . Select ( "PLT002='" + _modePLT . PLT002 + "' AND PLT003='" + _modePLT . PLT003 + "' AND PLT004='" + _modePLT . PLT004 + "'" ) . Length < 1 )
                    {
                        delete ( _modePLT ,strSql ,SQLString );
                        editPST ( SQLString ,strSql ,_modePLT );
                        edit_pas ( SQLString ,strSql ,_modePLT ,false );
                        _modePLT . PLT007 = null;
                        edit_Prs ( _modePLT ,strSql ,SQLString );
                    }
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        /// <summary>
        /// 编辑备料跟踪表周次为空
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="_modePLT"></param>
        void editPST ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanStockPLTEntity _modePLT )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXPST SET PST015='' WHERE PST001='{0}' AND PST002='{1}'" ,_modePLT . PLT003 ,_modePLT . PLT004 );
            SQLString . Add ( strSql ,null );
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
        /// 编辑备料计划完成时间
        /// </summary>
        /// <param name="_modelPLT"></param>
        /// <param name="strSql"></param>
        /// <param name="SQLString"></param>
        void edit_Prs ( CarpenterEntity . PlanStockPLTEntity _modelPLT ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPRS SET " );
            strSql . Append ( "PRS007=@PRS007 " );
            strSql . Append ( "WHERE PRS001=@PRS001 AND PRS002=@PRS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PRS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS007",SqlDbType.Date)
            };
            parameter [ 0 ] . Value = _modelPLT . PLT003;
            parameter [ 1 ] . Value = _modelPLT . PLT004;
            parameter [ 2 ] . Value = _modelPLT . PLT007;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 获取服务器日期
        /// </summary>
        /// <returns></returns>
        DateTime getDate ( )
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

        void edit ( CarpenterEntity . PlanStockPLTEntity _modePLT ,StringBuilder strSql,Hashtable SQLString)
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPLT SET " );
            strSql . Append ( "PLT007=@PLT007," );
            strSql . Append ( "PLT008=@PLT008," );
            strSql . Append ( "PLT009=@PLT009," );
            strSql . Append ( "PLT010=@PLT010," );
            strSql . Append ( "PLT012=@PLT012 " );
            strSql . Append ( "WHERE PLT001=@PLT001 AND PLT002=@PLT002 AND PLT003=@PLT003 AND PLT004=@PLT004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLT001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT004",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT007",SqlDbType.Date),
                new SqlParameter("@PLT008",SqlDbType.NVarChar,200),
                new SqlParameter("@PLT009",SqlDbType.Date),
                new SqlParameter("@PLT010",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT012",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _modePLT . PLT001;
            parameter [ 1 ] . Value = _modePLT . PLT002;
            parameter [ 2 ] . Value = _modePLT . PLT003;
            parameter [ 3 ] . Value = _modePLT . PLT004;
            parameter [ 4 ] . Value = _modePLT . PLT007;
            parameter [ 5 ] . Value = _modePLT . PLT008;
            parameter [ 6 ] . Value = _modePLT . PLT009;
            parameter [ 7 ] . Value = _modePLT . PLT010;
            parameter [ 8 ] . Value = _modePLT . PLT012;

            SQLString . Add ( strSql ,parameter );
        }

        void delete ( CarpenterEntity . PlanStockPLTEntity _modePLT ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPLT " );
            strSql . Append ( "WHERE PLT001=@PLT001 AND PLT002=@PLT002 AND PLT003=@PLT003 AND PLT004=@PLT004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLT001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT002",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT003",SqlDbType.NVarChar,20),
                new SqlParameter("@PLT004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modePLT . PLT001;
            parameter [ 1 ] . Value = _modePLT . PLT002;
            parameter [ 2 ] . Value = _modePLT . PLT003;
            parameter [ 3 ] . Value = _modePLT . PLT004;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="programName"></param>
        /// <param name="userNane"></param>
        /// <param name="userNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examin ( string oddNum ,string programName ,string userNane ,string userNum ,bool state ,DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( state == false )
                CarpenterBll . Examine . writeToReview ( programName ,oddNum ,userNum ,SQLString );
            else
                CarpenterBll . Examine . deleteToReview ( programName ,oddNum ,userNum ,SQLString );
            strSql . Append ( "UPDATE MOXPLS SET " );
            strSql . Append ( "PLS009=@PLS009," );
            strSql . Append ( "PLS006=@PLS006," );
            strSql . Append ( "PLS007=@PLS007 " );
            strSql . Append ( "WHERE PLS001=@PLS001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PLS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PLS006",SqlDbType.Date),
                new SqlParameter("@PLS007",SqlDbType.NVarChar,20),
                new SqlParameter("@PLS009",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = oddNum;
            parameter [ 1 ] . Value = getDate ( );
            parameter [ 2 ] . Value = userNane;
            parameter [ 3 ] . Value = state;

            SQLString . Add ( strSql ,parameter );

            CarpenterEntity . PlanStockPLTEntity model = new CarpenterEntity . PlanStockPLTEntity ( );

            if ( table != null && table . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    model . PLT003 = table . Rows [ i ] [ "PLT003" ] . ToString ( );
                    model . PLT004 = table . Rows [ i ] [ "PLT004" ] . ToString ( );
                    if ( state )
                        edit_pas ( SQLString ,strSql ,model ,false );
                    else
                        edit_pas ( SQLString ,strSql ,model ,true );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 编辑跟踪表周计划是否审核的比较
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="model"></param>
        /// <param name="state"></param>
        void edit_pas ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PlanStockPLTEntity model,bool state )
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
            parameter [ 0 ] . Value = model . PLT003;
            parameter [ 1 ] . Value = model . PLT004;
            parameter [ 2 ] . Value = state;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable printOne (string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (SELECT CASE WHEN PLT002!='' THEN '上周遗留' WHEN PLT013=1 THEN '预排' ELSE ''+OPI003 END OPI003,PLT003,PLT005,PLT006,OPI006,OPI007,PLT012,SUBSTRING(CONVERT(VARCHAR,PLT007, 11),4,5) PLT007,PLT008 FROM MOXPLT A LEFT JOIN MOXOPI B ON A.PLT004=B.OPI001 " );
            strSql . Append ( "WHERE PLT001='" + oddNum + "') " );
            strSql . Append ( " SELECT *,CASE WHEN OPI003='上周遗留' THEN 1 WHEN OPI003='预排' THEN '3' ELSE '2' END OPI FROM CET ORDER BY OPI,OPI003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable printTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PLS002,PLS003,PLS004,PLS005,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PLT012*OPI004))) PLS FROM MOXPLS A LEFT JOIN MOXPLT B ON A.PLS001=B.PLT001 LEFT JOIN MOXOPI C ON B.PLT004=C.OPI001 " );
            strSql . Append ( "WHERE PLS001='" + oddNum + "'" );
            strSql . Append ( " GROUP BY PLS002,PLS003,PLS004,PLS005" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="batNum"></param>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public bool Exists (string oddNum,string batNum,string proNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPDK WHERE PDK009='{0}' AND PDK002='{1}' AND PDK003='{2}'" ,oddNum ,batNum ,proNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

    }
}
