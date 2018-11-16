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
    public class PlanCuttingDao
    {
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <returns></returns>
        public DataTable GetDataTableOPI ( string weekEnds )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT OPI001,OPI002,OPI003,OPI004,OPI005,OPI006,OPI007 FROM MOXOPI WHERE OPI011=0 AND OPI001 NOT IN (SELECT CUU002 FROM MOXCUU WHERE CUU001='{0}')" ,weekEnds );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableProduct ( string productNum )
        {
            //
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT OPI001,OPI002,OPI003,OPI004,OPI005,OPI006,OPI007 FROM MOXOPI WHERE OPI011=0 AND OPI010='成品' AND OPI008='在产'" );
            if ( productNum != string . Empty )
                strSql . Append ( "AND " + productNum );
            strSql . Append ( " ORDER BY OPI001 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableProduct ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CUT001,CUT002,CUT003,CUT004,CUT007,CUT008,SUM(CUU003*OPI004) CUT009 FROM MOXCUT A LEFT JOIN MOXCUU B ON A.CUT001=B.CUU001 LEFT JOIN MOXOPI C ON B.CUU002=C.OPI001 GROUP BY CUT001,CUT002,CUT003,CUT004,CUT007,CUT008" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取单头数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableQueryOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CUT001,CUT002,CUT003,CUT004,CUT007,CUT008 FROM MOXCUT " );
            strSql . AppendFormat ( "WHERE CUT001='{0}'",strWhere  );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取单身数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableQueryTwo ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CUU001,CUU002,CUU008,CUU009,OPI003,CUU003,CUU004,CUU005,OPI006,OPI007,OPI004 FROM MOXCUU A LEFT JOIN MOXOPI B ON A.CUU002=B.OPI001  " );
            strSql . AppendFormat ( "WHERE CUU001='{0}'" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="batchNum"></param>
        /// <returns></returns>
        public bool Delete ( string batchNum )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXCUU " );
            strSql . AppendFormat ( "WHERE CUU001='{0}'" ,batchNum );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXCUT " );
            strSql . AppendFormat ( "WHERE CUT001='{0}'" ,batchNum );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPRS " );
            strSql . AppendFormat ( "WHERE PRS001='{0}'" ,batchNum );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPST " );
            strSql . AppendFormat ( "WHERE PST001='{0}'" ,batchNum );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPAS " );
            strSql . AppendFormat ( "WHERE PAS001='{0}'" ,batchNum );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPDP " );
            strSql . AppendFormat ( "WHERE PDP001='{0}'" ,batchNum );
            SQLString . Add ( strSql . ToString ( ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="barchNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Concell ( string barchNum ,bool state )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXCUT SET " );
            strSql . Append ( "CUT007=@CUT007 " );
            strSql . Append ( "WHERE CUT001=@CUT001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@CUT001",SqlDbType.NVarChar,20),
                new SqlParameter("@CUT007",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = barchNum;
            parameter [ 1 ] . Value = state;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="barchNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examine ( string barchNum ,bool state ,DataTable tableQuery ,DateTime dtOne ,string userName ,string programName ,string userNum )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXCUT SET " );
            strSql . Append ( "CUT008=@CUT008 " );
            strSql . Append ( "WHERE CUT001=@CUT001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@CUT001",SqlDbType.NVarChar,20),
                new SqlParameter("@CUT008",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = barchNum;
            parameter [ 1 ] . Value = state;

            SQLString . Add ( strSql ,parameter );

            if ( state == true )
            {
                CarpenterBll . Examine . writeToReview ( programName ,barchNum ,userNum ,SQLString );
            }
            else
            {
                CarpenterBll . Examine . deleteToReview ( programName ,barchNum ,userNum ,SQLString );
            }

            if ( state == true )
            {
                if ( tableQuery != null && tableQuery . Rows . Count > 0 )
                {
                    //进度跟踪表
                    CarpenterEntity . ProductScheduleEntity _model = new CarpenterEntity . ProductScheduleEntity ( );
                    //备料车间
                    CarpenterEntity . ProductionStockEntity _modelOne = new CarpenterEntity . ProductionStockEntity ( );
                    //组装车间
                    CarpenterEntity . ProductionAssembleEntity _modelTwo = new CarpenterEntity . ProductionAssembleEntity ( );
                    //油漆车间
                    CarpenterEntity . ProductionPaintEntity _modelTre = new CarpenterEntity . ProductionPaintEntity ( );

                    _model . PRS005 = dtOne;
                    _model . PRS027 = _modelTwo . PAS014 = getDate ( );
                    _modelOne . PST026 = getDate ( );
                    _model . PRS028 = _modelOne . PST027 = _modelTwo . PAS015 = userName;
                    for ( int i = 0 ; i < tableQuery . Rows . Count ; i++ )
                    {
                        _model . PRS001 = _modelOne . PST001 = _modelTwo . PAS001 = _modelTre . PDP001 = tableQuery . Rows [ i ] [ "CUU001" ] . ToString ( );
                        _model . PRS002 = _modelOne . PST002 = _modelTwo . PAS002 = _modelTre . PDP002 = tableQuery . Rows [ i ] [ "CUU002" ] . ToString ( );
                        _model . PRS003 = _modelOne . PST003 = _modelTwo . PAS003 = _modelTre . PDP003 = tableQuery . Rows [ i ] [ "CUU008" ] . ToString ( );
                        _model . PRS004 = _modelOne . PST004 = _modelTwo . PAS004 = _modelTre . PDP004 = tableQuery . Rows [ i ] [ "CUU009" ] . ToString ( );
                        _model . PRS026 = _modelOne . PST025 = _modelTwo . PAS013 = _modelTre . PDP024 = tableQuery . Rows [ i ] [ "CUU005" ] . ToString ( );
                        _model . PRS029 = _modelOne . PST028 = _modelTwo . PAS016 = _modelTre . PDP025 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "CUU003" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "CUU003" ] . ToString ( ) );
                        _modelOne . PST030 = _modelTwo . PAS030 = false;
                        if ( Exists ( _model . PRS001 ,_model . PRS002 ) == false )
                            add_prs ( _model ,strSql ,SQLString );

                        _modelOne . PST005 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "CUU004" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( tableQuery . Rows [ i ] [ "CUU004" ] . ToString ( ) );

                        if ( Exists_BeiLiao ( _modelOne . PST001 ,_modelOne . PST002 ) == false )
                            add_bl ( _modelOne ,strSql ,SQLString );
                        else
                            edit_bl ( _modelOne ,strSql ,SQLString );

                        if ( Exists_Z ( _modelTwo . PAS001 ,_modelTwo . PAS002 ) == false )
                            add_Z ( _modelTwo ,strSql ,SQLString );
                        else
                            edit_Z ( _modelTwo ,strSql ,SQLString );

                        if ( Exists_P ( _modelTre . PDP001 ,_modelTre . PDP002 ) == false )
                            add_P ( _modelTre ,strSql ,SQLString );
                        else
                            edit_P ( _modelTre ,strSql ,SQLString );
                    }
                }
                else
                    return false;
            }


            return SqlHelper . ExecuteSqlTran ( SQLString );

        }

        /// <summary>
        /// 获取系统时间
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

        /// <summary>
        /// 进度跟踪表是否存在
        /// </summary>
        /// <param name="batchNum"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public bool Exists ( string batchNum ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXPRS " );
            strSql . Append ( "WHERE PRS001=@PRS001 AND PRS002=@PRS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PRS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS002",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = batchNum;
            parameter [ 1 ] . Value = productNum;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        public bool ExistsPRS ( string batchNum,string pinNum  )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXPST " );
            strSql . AppendFormat ( "WHERE PST001='{0}' AND PST002='{1}'" ,batchNum ,pinNum );

            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return true;

            strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXPAS " );
            strSql . AppendFormat ( "WHERE PAS001='{0}' AND PAS002='{1}' " ,batchNum ,pinNum );

            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return true;

            strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXPDP " );
            strSql . AppendFormat ( "WHERE PDP001='{0}' AND PDP002='{1}' " ,batchNum ,pinNum );

            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return true;

            return false;
        }
        public bool ExistsPRS ( string batchNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXPST " );
            strSql . AppendFormat ( "WHERE PST001='{0}' " ,batchNum );

            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return true;

            strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXPAS " );
            strSql . AppendFormat ( "WHERE PAS001='{0}' " ,batchNum );

            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return true;

            strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXPDP " );
            strSql . AppendFormat ( "WHERE PDP001='{0}'" ,batchNum );

            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return true;

            return false;
        }

        void add_prs ( CarpenterEntity . ProductScheduleEntity _model ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPRS (" );
            strSql . Append ( "PRS001,PRS002,PRS003,PRS004,PRS005,PRS026,PRS027,PRS028,PRS029,PRS030) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PRS001,@PRS002,@PRS003,@PRS004,@PRS005,@PRS026,@PRS027,@PRS028,@PRS029,@PRS030) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PRS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS002",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS003",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS004",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS005",SqlDbType.Date),
                new SqlParameter("@PRS026",SqlDbType.NVarChar,50),
                new SqlParameter("@PRS027",SqlDbType.Date),
                new SqlParameter("@PRS028",SqlDbType.NVarChar,20),
                new SqlParameter("@PRS029",SqlDbType.Int),
                new SqlParameter("@PRS030",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _model . PRS001;
            parameter [ 1 ] . Value = _model . PRS002;
            parameter [ 2 ] . Value = _model . PRS003;
            parameter [ 3 ] . Value = _model . PRS004;
            parameter [ 4 ] . Value = _model . PRS005;
            parameter [ 5 ] . Value = _model . PRS026;
            parameter [ 6 ] . Value = _model . PRS027;
            parameter [ 7 ] . Value = _model . PRS028;
            parameter [ 8 ] . Value = _model . PRS029;
            parameter [ 9 ] . Value = _model . PRS030;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 备料进度表是否存在
        /// </summary>
        /// <param name="batchNum"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        bool Exists_BeiLiao ( string batchNum ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXPST " );
            strSql . Append ( "WHERE PST001=@PST001 AND PST002=@PST002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PST001",SqlDbType.NVarChar,20),
                new SqlParameter("@PST002",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = batchNum;
            parameter [ 1 ] . Value = productNum;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        void add_bl ( CarpenterEntity . ProductionStockEntity _modelOne ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPST (" );
            strSql . Append ( "PST001,PST002,PST003,PST004,PST005,PST025,PST026,PST027,PST028,PST030) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PST001,@PST002,@PST003,@PST004,@PST005,@PST025,@PST026,@PST027,@PST028,@PST030) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PST001",SqlDbType.NVarChar,20),
                new SqlParameter("@PST002",SqlDbType.NVarChar,20),
                new SqlParameter("@PST003",SqlDbType.NVarChar,20),
                new SqlParameter("@PST004",SqlDbType.NVarChar,20),
                new SqlParameter("@PST005",SqlDbType.Date),
                new SqlParameter("@PST025",SqlDbType.NVarChar,200),
                new SqlParameter("@PST026",SqlDbType.Date),
                new SqlParameter("@PST027",SqlDbType.NVarChar,20),
                new SqlParameter("@PST028",SqlDbType.Int),
                new SqlParameter("@PST030",SqlDbType.Bit)
            };

            parameter [ 0 ] . Value = _modelOne . PST001;
            parameter [ 1 ] . Value = _modelOne . PST002;
            parameter [ 2 ] . Value = _modelOne . PST003;
            parameter [ 3 ] . Value = _modelOne . PST004;
            parameter [ 4 ] . Value = _modelOne . PST005;
            parameter [ 5 ] . Value = _modelOne . PST025;
            parameter [ 6 ] . Value = _modelOne . PST026;
            parameter [ 7 ] . Value = _modelOne . PST027;
            parameter [ 8 ] . Value = _modelOne . PST028;
            parameter [ 9 ] . Value = _modelOne . PST030;

            SQLString . Add ( strSql ,parameter );
        }

        void edit_bl ( CarpenterEntity . ProductionStockEntity _modelOne ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPST SET " );
            strSql . Append ( "PST005=@PST005," );
            strSql . Append ( "PST025=@PST025," );
            strSql . Append ( "PST026=@PST026," );
            strSql . Append ( "PST027=@PST027," );
            strSql . Append ( "PST028=@PST028 " );
            strSql . Append ( "WHERE PST001=@PST001 AND PST002=@PST002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PST001",SqlDbType.NVarChar,20),
                new SqlParameter("@PST002",SqlDbType.NVarChar,20),
                new SqlParameter("@PST005",SqlDbType.Date,3),
                new SqlParameter("@PST025",SqlDbType.NVarChar,200),
                new SqlParameter("@PST026",SqlDbType.Date),
                new SqlParameter("@PST027",SqlDbType.NVarChar,20),
                new SqlParameter("@PST028",SqlDbType.Int)
            };

            parameter [ 0 ] . Value = _modelOne . PST001;
            parameter [ 1 ] . Value = _modelOne . PST002;
            parameter [ 2 ] . Value = _modelOne . PST005;
            parameter [ 3 ] . Value = _modelOne . PST025;
            parameter [ 4 ] . Value = _modelOne . PST026;
            parameter [ 5 ] . Value = _modelOne . PST027;
            parameter [ 6 ] . Value = _modelOne . PST028;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 组装进度表是否存在
        /// </summary>
        /// <param name="batchNum"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        bool Exists_Z ( string batchNum ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXPAS " );
            strSql . Append ( "WHERE PAS001=@PAS001 AND PAS002=@PAS002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PAS001",SqlDbType.NVarChar,20),
                new SqlParameter("@PAS002",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = batchNum;
            parameter [ 1 ] . Value = productNum;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        void add_Z ( CarpenterEntity . ProductionAssembleEntity _modelOne ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPAS (" );
            strSql . Append ( "PAS001,PAS002,PAS003,PAS004,PAS013,PAS014,PAS015,PAS016,PAS030) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PAS001,@PAS002,@PAS003,@PAS004,@PAS013,@PAS014,@PAS015,@PAS016,@PAS030) " );
            SqlParameter [ ] parameter = {
                    new SqlParameter("@PAS001", SqlDbType.NVarChar,20),
                    new SqlParameter("@PAS002", SqlDbType.NVarChar,20),
                    new SqlParameter("@PAS003", SqlDbType.NVarChar,20),
                    new SqlParameter("@PAS004", SqlDbType.NVarChar,20),
                    new SqlParameter("@PAS013", SqlDbType.NVarChar,200),
                    new SqlParameter("@PAS014", SqlDbType.Date,3),
                    new SqlParameter("@PAS015", SqlDbType.NVarChar,20),
                    new SqlParameter("@PAS016", SqlDbType.Int,4),
                    new SqlParameter("@PAS030", SqlDbType.Bit)
            };

            parameter [ 0 ] . Value = _modelOne . PAS001;
            parameter [ 1 ] . Value = _modelOne . PAS002;
            parameter [ 2 ] . Value = _modelOne . PAS003;
            parameter [ 3 ] . Value = _modelOne . PAS004;
            parameter [ 4 ] . Value = _modelOne . PAS013;
            parameter [ 5 ] . Value = _modelOne . PAS014;
            parameter [ 6 ] . Value = _modelOne . PAS015;
            parameter [ 7 ] . Value = _modelOne . PAS016;
            parameter [ 8 ] . Value = _modelOne . PAS030;

            SQLString . Add ( strSql ,parameter );
        }

        void edit_Z ( CarpenterEntity . ProductionAssembleEntity _modelOne ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPAS SET " );
            strSql . Append ( "PAS013=@PAS013," );
            strSql . Append ( "PAS014=@PAS014," );
            strSql . Append ( "PAS015=@PAS015," );
            strSql . Append ( "PAS016=@PAS016 " );
            strSql . Append ( "WHERE PAS001=@PAS001 AND PAS002=@PAS002" );
            SqlParameter [ ] parameter = {
                    new SqlParameter("@PAS001", SqlDbType.NVarChar,20),
                    new SqlParameter("@PAS002", SqlDbType.NVarChar,20),
                    new SqlParameter("@PAS013", SqlDbType.NVarChar,200),
                    new SqlParameter("@PAS014", SqlDbType.Date,3),
                    new SqlParameter("@PAS015", SqlDbType.NVarChar,20),
                    new SqlParameter("@PAS016", SqlDbType.Int,4)
            };

            parameter [ 0 ] . Value = _modelOne . PAS001;
            parameter [ 1 ] . Value = _modelOne . PAS002;
            parameter [ 2 ] . Value = _modelOne . PAS013;
            parameter [ 3 ] . Value = _modelOne . PAS014;
            parameter [ 4 ] . Value = _modelOne . PAS015;
            parameter [ 5 ] . Value = _modelOne . PAS016;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 油漆进度表是否存在
        /// </summary>
        /// <param name="batchNum"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        bool Exists_P ( string batchNum ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXPDP " );
            strSql . Append ( "WHERE PDP001=@PDP001 AND PDP002=@PDP002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PDP001",SqlDbType.NVarChar,20),
                new SqlParameter("@PDP002",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = batchNum;
            parameter [ 1 ] . Value = productNum;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        void add_P ( CarpenterEntity . ProductionPaintEntity _modelOne ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPDP (" );
            strSql . Append ( "PDP001,PDP002,PDP003,PDP004,PDP024,PDP025) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PDP001,@PDP002,@PDP003,@PDP004,@PDP024,@PDP025) " );
            SqlParameter [ ] parameter = {
                    new SqlParameter("@PDP001", SqlDbType.NVarChar,20),
                    new SqlParameter("@PDP002", SqlDbType.NVarChar,20),
                    new SqlParameter("@PDP003", SqlDbType.NVarChar,20),
                    new SqlParameter("@PDP004", SqlDbType.NVarChar,20),
                    new SqlParameter("@PDP024", SqlDbType.NVarChar,200),
                    new SqlParameter("@PDP025", SqlDbType.Int,4)
            };

            parameter [ 0 ] . Value = _modelOne . PDP001;
            parameter [ 1 ] . Value = _modelOne . PDP002;
            parameter [ 2 ] . Value = _modelOne . PDP003;
            parameter [ 3 ] . Value = _modelOne . PDP004;
            parameter [ 4 ] . Value = _modelOne . PDP024;
            parameter [ 5 ] . Value = _modelOne . PDP025;

            SQLString . Add ( strSql ,parameter );
        }

        void edit_P ( CarpenterEntity . ProductionPaintEntity _modelOne ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPDP SET " );
            strSql . Append ( "PDP024=@PDP024, " );
            strSql . Append ( "PDP025=@PDP025 " );
            strSql . Append ( "WHERE PDP001=@PDP001 AND PDP002=@PDP002" );
            SqlParameter [ ] parameter = {
                    new SqlParameter("@PDP001", SqlDbType.NVarChar,20),
                    new SqlParameter("@PDP002", SqlDbType.NVarChar,20),
                    new SqlParameter("@PDP024", SqlDbType.NVarChar,200),
                    new SqlParameter("@PDP025", SqlDbType.Int,4)
            };

            parameter [ 0 ] . Value = _modelOne . PDP001;
            parameter [ 1 ] . Value = _modelOne . PDP002;
            parameter [ 2 ] . Value = _modelOne . PDP024;
            parameter [ 3 ] . Value = _modelOne . PDP025;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="batchNum"></param>
        /// <returns></returns>
        public bool Exists (string batchNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXCUT " );
            strSql . Append ( "WHERE CUT001=@CUT001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@CUT001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = batchNum;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_modelCut"></param>
        /// <param name="tableQuery"></param>
        /// <returns></returns>
        public bool Add ( CarpenterEntity . PlanCutCUTEntity _modelCut ,DataTable tableQuery )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXCUT (" );
            strSql . Append ( "CUT001,CUT002,CUT003,CUT004,CUT005,CUT006,CUT007,CUT008) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@CUT001,@CUT002,@CUT003,@CUT004,@CUT005,@CUT006,@CUT007,@CUT008) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@CUT001",SqlDbType.NVarChar,20),
                new SqlParameter("@CUT002",SqlDbType.Date),
                new SqlParameter("@CUT003",SqlDbType.Date),
                new SqlParameter("@CUT004",SqlDbType.Date),
                new SqlParameter("@CUT005",SqlDbType.Date),
                new SqlParameter("@CUT006",SqlDbType.NVarChar,20),
                new SqlParameter("@CUT007",SqlDbType.Bit),
                new SqlParameter("@CUT008",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _modelCut . CUT001;
            parameter [ 1 ] . Value = _modelCut . CUT002;
            parameter [ 2 ] . Value = _modelCut . CUT003;
            parameter [ 3 ] . Value = _modelCut . CUT004;
            parameter [ 4 ] . Value = _modelCut . CUT005;
            parameter [ 5 ] . Value = _modelCut . CUT006;
            parameter [ 6 ] . Value = _modelCut . CUT007;
            parameter [ 7 ] . Value = _modelCut . CUT008;
            SQLString . Add ( strSql ,parameter );

            CarpenterEntity . PlanCutCUUEntity _modelCuu = new CarpenterEntity . PlanCutCUUEntity ( );
            _modelCuu . CUU001 = _modelCut . CUT001;
            _modelCuu . CUU006 = _modelCut . CUT005;
            _modelCuu . CUU007 = _modelCut . CUT006;
            for ( int i = 0 ; i < tableQuery . Rows . Count ; i++ )
            {
                _modelCuu . CUU002 = tableQuery . Rows [ i ] [ "CUU002" ] . ToString ( );
                _modelCuu . CUU003 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "CUU003" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "CUU003" ] . ToString ( ) );
                _modelCuu . CUU004 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "CUU004" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( tableQuery . Rows [ i ] [ "CUU004" ] . ToString ( ) );
                _modelCuu . CUU005 = tableQuery . Rows [ i ] [ "CUU005" ] . ToString ( );
                _modelCuu . CUU008 = tableQuery . Rows [ i ] [ "CUU008" ] . ToString ( );
                _modelCuu . CUU009 = tableQuery . Rows [ i ] [ "CUU009" ] . ToString ( );
                //_modelCuu . CUU010 = tableQuery . Rows [ i ] [ "CUU010" ] . ToString ( );
                add_cuu ( _modelCuu ,strSql ,SQLString );
            }


            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_cuu ( CarpenterEntity . PlanCutCUUEntity _modelCuu ,StringBuilder strSql,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXCUU (" );
            strSql . Append ( "CUU001,CUU002,CUU003,CUU004,CUU005,CUU006,CUU007,CUU008,CUU009) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@CUU001,@CUU002,@CUU003,@CUU004,@CUU005,@CUU006,@CUU007,@CUU008,@CUU009) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@CUU001",SqlDbType.NVarChar,20),
                new SqlParameter("@CUU002",SqlDbType.NVarChar,20),
                new SqlParameter("@CUU003",SqlDbType.Int),
                new SqlParameter("@CUU004",SqlDbType.Date),
                new SqlParameter("@CUU005",SqlDbType.NVarChar,200),
                new SqlParameter("@CUU006",SqlDbType.Date),
                new SqlParameter("@CUU007",SqlDbType.NVarChar,20),
                new SqlParameter("@CUU008",SqlDbType.NVarChar,20),
                new SqlParameter("@CUU009",SqlDbType.NVarChar,20)
                //new SqlParameter("CUU010",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelCuu . CUU001;
            parameter [ 1 ] . Value = _modelCuu . CUU002;
            parameter [ 2 ] . Value = _modelCuu . CUU003;
            parameter [ 3 ] . Value = _modelCuu . CUU004;
            parameter [ 4 ] . Value = _modelCuu . CUU005;
            parameter [ 5 ] . Value = _modelCuu . CUU006;
            parameter [ 6 ] . Value = _modelCuu . CUU007;
            parameter [ 7 ] . Value = _modelCuu . CUU008;
            parameter [ 8 ] . Value = _modelCuu . CUU009;
            //parameter [ 9 ] . Value = _modelCuu . CUU010;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 获取id
        /// </summary>
        /// <param name="batchNum"></param>
        /// <returns></returns>
        public int id ( string batchNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx FROM MOXCUT " );
            strSql . Append ( "WHERE CUT001=@CUT001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@CUT001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = batchNum;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "idx" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToInt32 ( dt . Rows [ 0 ] [ "idx" ] . ToString ( ) );
            }
            else
                return 0;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="batchNum"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exists ( string batchNum ,int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXCUT " );
            strSql . Append ( "WHERE CUT001=@CUT001 AND idx!=@idx " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@CUT001",SqlDbType.NVarChar,20),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = batchNum;
            parameter [ 1 ] . Value = idx;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 编辑记录
        /// </summary>
        /// <param name="_modelCut"></param>
        /// <param name="tableQuery"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . PlanCutCUTEntity _modelCut ,DataTable tableQuery )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXCUT SET " );
            strSql . Append ( "CUT001=@CUT001," );
            strSql . Append ( "CUT002=@CUT002," );
            strSql . Append ( "CUT003=@CUT003," );
            strSql . Append ( "CUT004=@CUT004," );
            strSql . Append ( "CUT005=@CUT005," );
            strSql . Append ( "CUT006=@CUT006 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@CUT001",SqlDbType.NVarChar,20),
                new SqlParameter("@CUT002",SqlDbType.Date),
                new SqlParameter("@CUT003",SqlDbType.Date),
                new SqlParameter("@CUT004",SqlDbType.Date),
                new SqlParameter("@CUT005",SqlDbType.Date),
                new SqlParameter("@CUT006",SqlDbType.NVarChar,20),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _modelCut . CUT001;
            parameter [ 1 ] . Value = _modelCut . CUT002;
            parameter [ 2 ] . Value = _modelCut . CUT003;
            parameter [ 3 ] . Value = _modelCut . CUT004;
            parameter [ 4 ] . Value = _modelCut . CUT005;
            parameter [ 5 ] . Value = _modelCut . CUT006;
            parameter [ 6 ] . Value = _modelCut . idx;
            SQLString . Add ( strSql . ToString ( ) ,parameter );

            CarpenterEntity . PlanCutCUUEntity _modelCuu = new CarpenterEntity . PlanCutCUUEntity ( );
            _modelCuu . CUU001 = _modelCut . CUT001;
            _modelCuu . CUU006 = _modelCut . CUT005;
            _modelCuu . CUU007 = _modelCut . CUT006;
            for ( int i = 0 ; i < tableQuery . Rows . Count ; i++ )
            {
                _modelCuu . CUU002 = tableQuery . Rows [ i ] [ "CUU002" ] . ToString ( );
                _modelCuu . CUU003 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "CUU003" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "CUU003" ] . ToString ( ) );
                _modelCuu . CUU004 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "CUU004" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( tableQuery . Rows [ i ] [ "CUU004" ] . ToString ( ) );
                _modelCuu . CUU005 = tableQuery . Rows [ i ] [ "CUU005" ] . ToString ( );
                _modelCuu . CUU008 = tableQuery . Rows [ i ] [ "CUU008" ] . ToString ( );
                _modelCuu . CUU009 = tableQuery . Rows [ i ] [ "CUU009" ] . ToString ( );
                //_modelCuu . CUU010 = tableQuery . Rows [ i ] [ "CUU010" ] . ToString ( ); ,_modelCuu . CUU010
                if ( Esists ( _modelCuu . CUU001 ,_modelCuu . CUU002  ) == true )
                    edit ( _modelCuu ,strSql ,SQLString );
                else
                    add_cuu ( _modelCuu ,strSql ,SQLString );
            }

            DataTable dt = SqlHelper . ExecuteDataTable ( "SELECT CUU002 FROM MOXCUU WHERE CUU001='" + _modelCuu . CUU001 + "'" );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _modelCuu . CUU002 = dt . Rows [ i ] [ "CUU002" ] . ToString ( );
                    //_modelCuu . CUU010 = dt . Rows [ i ] [ "CUU010" ] . ToString ( );   AND CUU010='" + _modelCuu . CUU010 + "'
                    if ( tableQuery . Select ( "CUU002='" + _modelCuu . CUU002 + "'" ) . Length < 1 )
                        delete ( _modelCuu ,strSql ,SQLString );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 同批号,同品号是否存在
        /// </summary>
        /// <param name="batchNum"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        //string previous
        bool Esists ( string batchNum ,string productNum  )
        {
            StringBuilder strSql = new StringBuilder ( );// AND CUU010=CUU010
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXCUU " );
            strSql . Append ( "WHERE CUU001=@CUU001 AND CUU002=@CUU002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@CUU001",SqlDbType.NVarChar,20),
                new SqlParameter("@CUU002",SqlDbType.NVarChar,20)
                //new SqlParameter("CUU010",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = batchNum;
            parameter [ 1 ] . Value = productNum;
            //parameter [ 2 ] . Value = previous;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        void edit ( CarpenterEntity . PlanCutCUUEntity _modelCuu ,StringBuilder strSql,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXCUU SET " );
            strSql . Append ( "CUU003=@CUU003," );
            strSql . Append ( "CUU004=@CUU004," );
            strSql . Append ( "CUU005=@CUU005," );
            strSql . Append ( "CUU006=@CUU006," );
            strSql . Append ( "CUU007=@CUU007," );
            strSql . Append ( "CUU008=@CUU008," );
            strSql . Append ( "CUU009=@CUU009 " );
            strSql . Append ( "WHERE CUU001=@CUU001 AND " );
            strSql . Append ( "CUU002=@CUU002  " );
            //strSql . Append ( "AND CUU010=CUU010" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@CUU001",SqlDbType.NVarChar,20),
                new SqlParameter("@CUU002",SqlDbType.NVarChar,20),
                new SqlParameter("@CUU003",SqlDbType.Int),
                new SqlParameter("@CUU004",SqlDbType.Date),
                new SqlParameter("@CUU005",SqlDbType.NVarChar,200),
                new SqlParameter("@CUU006",SqlDbType.Date),
                new SqlParameter("@CUU007",SqlDbType.NVarChar,20),
                new SqlParameter("@CUU008",SqlDbType.NVarChar,20),
                new SqlParameter("@CUU009",SqlDbType.NVarChar,20)
                //new SqlParameter("CUU010",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelCuu . CUU001;
            parameter [ 1 ] . Value = _modelCuu . CUU002;
            parameter [ 2 ] . Value = _modelCuu . CUU003;
            parameter [ 3 ] . Value = _modelCuu . CUU004;
            parameter [ 4 ] . Value = _modelCuu . CUU005;
            parameter [ 5 ] . Value = _modelCuu . CUU006;
            parameter [ 6 ] . Value = _modelCuu . CUU007;
            parameter [ 7 ] . Value = _modelCuu . CUU008;
            parameter [ 8 ] . Value = _modelCuu . CUU009;
            //parameter [ 9 ] . Value = _modelCuu . CUU010;

            SQLString . Add ( strSql ,parameter );
        }

        void delete ( CarpenterEntity . PlanCutCUUEntity _modelCuu ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXCUU " );// AND CUU010=CUU010
            strSql . Append ( "WHERE CUU001=@CUU001 AND CUU002=@CUU002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@CUU001",SqlDbType.NVarChar,20),
                new SqlParameter("@CUU002",SqlDbType.NVarChar,20)
                //new SqlParameter("CUU010",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelCuu . CUU001;
            parameter [ 1 ] . Value = _modelCuu . CUU002;
            //parameter [ 2 ] . Value = _modelCuu . CUU010;

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
            strSql . Append ( "SELECT CUT001,CUT002,SUBSTRING(CONVERT(VARCHAR,CUT003,102),6,5)+' - '+SUBSTRING(CONVERT(VARCHAR,CUT004,102),6,5) CUT,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(CUU003*OPI004))) OPI FROM MOXCUT A LEFT JOIN MOXCUU B ON A.CUT001=B.CUU001 LEFT JOIN MOXOPI C ON B.CUU002=C.OPI001 " );
            strSql . AppendFormat ( "WHERE CUT001='{0}'" ,oddNum );
            strSql . Append ( " GROUP BY CUT001,CUT002,CUT003,CUT004" );

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
            strSql . Append ( "SELECT ROW_NUMBER() OVER(ORDER BY CUU002) row,OPI003,CUU008,CUU009,OPI006,OPI007,CUU003,SUBSTRING(CONVERT(VARCHAR,CUU004,23),6,5) CUU004,CUU005 FROM MOXCUU A LEFT JOIN MOXOPI B ON A.CUU002=B.OPI001 " );
            strSql . AppendFormat ( "WHERE CUU001='{0}'" ,oddNum );
            //strSql . Append ( " ORDER BY OPI003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// generate the code from 
        /// </summary>
        /// <param name="strList"></param>
        /// <param name="weekEnds"></param>
        /// <returns></returns>
        public bool GenerateCodeAndPrint ( List<string> strList ,string weekEnds )
        {
            UserInformation . StrList = new List<string> ( );
            List<string> codeList = new List<string> ( );
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            DataTable dt = new DataTable ( );

            foreach ( string pro in strList )
            {
                //codeList = new List<string> ( );
                if ( Exists_ProBom ( pro ) )
                {
                    dt = GetInformation ( pro );
                    if ( dt != null && dt . Rows . Count > 0 )
                    {                  
                        CarpenterEntity . BomWorkPlanCodeEntity _model = new CarpenterEntity . BomWorkPlanCodeEntity ( );
                        _model . WPC001 = weekEnds;
                        _model . WPC002 = pro;
                        
                        DataTable da = getDa ( _model . WPC001 ,_model . WPC002 );
                        for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                        {
                            //_model . WPC002 = dt . Rows [ i ] [ "WOR001" ] . ToString ( );
                            _model . WPC003 = dt . Rows [ i ] [ "WOR005" ] . ToString ( );
                            _model . WPC004 = dt . Rows [ i ] [ "WOR006" ] . ToString ( ) . Trim ( );
                            _model . WPC006 = dt . Rows [ i ] [ "WOR007" ] . ToString ( ) . Trim ( );
                            _model . WPC007 = dt . Rows [ i ] [ "WOR008" ] . ToString ( ) . Trim ( );
                            _model . WPC008 = dt . Rows [ i ] [ "WOR009" ] . ToString ( ) . Trim ( );
                            _model . WPC009 = dt . Rows [ i ] [ "WOR010" ] . ToString ( ) . Trim ( );
                            _model . WPC010 = dt . Rows [ i ] [ "WOR011" ] . ToString ( ) . Trim ( );
                            _model . WPC011 = dt . Rows [ i ] [ "WOR012" ] . ToString ( ) . Trim ( );
                            _model . WPC012 = dt . Rows [ i ] [ "WOR013" ] . ToString ( ) . Trim ( );
                            _model . WPC013 = dt . Rows [ i ] [ "WOR014" ] . ToString ( ) . Trim ( );
                            _model . WPC014 = dt . Rows [ i ] [ "WOR015" ] . ToString ( ) . Trim ( );
                            _model . WPC015 = dt . Rows [ i ] [ "WOR016" ] . ToString ( );
                            _model . WPC016 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "WOR017" ] . ToString ( ) );
                            _model . WPC017 = dt . Rows [ i ] [ "WOR018" ] . ToString ( );
                            _model . WPC018 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR019" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "WOR019" ] . ToString ( ) );
                            _model . WPC019 = dt . Rows [ i ] [ "WOR020" ] . ToString ( );
                            _model . WPC020 = dt . Rows [ i ] [ "WOR021" ] . ToString ( );
                            _model . WPC021 = dt . Rows [ i ] [ "WOR022" ] . ToString ( );
                            if ( string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR023" ] . ToString ( ) ) )
                                _model . WPC022 = null;
                            else
                                _model . WPC022 = Convert . ToDateTime ( dt . Rows [ i ] [ "WOR023" ] . ToString ( ) );
                            _model . WPC023 = dt . Rows [ i ] [ "WOR024" ] . ToString ( );
                            _model . WPC024 = dt . Rows [ i ] [ "WOR025" ] . ToString ( );
                            _model . WPC025 = dt . Rows [ i ] [ "WOR026" ] . ToString ( );
                            _model . WPC026 = dt . Rows [ i ] [ "WOR027" ] . ToString ( );
                            _model . WPC027 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "WOR028" ] . ToString ( ) );
                            _model . WPC028 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR029" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "WOR029" ] . ToString ( ) );
                            _model . WPC029 = dt . Rows [ i ] [ "WOR030" ] . ToString ( );
                            //string str = dt . Rows [ i ] [ "WOR034" ] . ToString ( );
                            //if ( string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR034" ] . ToString ( ) ) /*|| dt . Rows [ i ] [ "WOR034" ] . ToString ( ) . Contains ( "System.Byte[]" )*/ )
                            //    _model . WPC030 = null;
                            //else
                            //    _model . WPC030 = ( byte? [ ] ) dt . Rows [ i ] [ "WOR034" ];
                            //if ( string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR035" ] . ToString ( ) ) || dt . Rows [ i ] [ "WOR035" ] . ToString ( ) . Contains ( "System.Byte[]" ) )
                            //    _model . WPC031 = null;
                            //else
                            //    _model . WPC031 = ( byte? [ ] ) dt . Rows [ i ] [ "WOR035" ];
                            //if ( string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR036" ] . ToString ( ) ) || dt . Rows [ i ] [ "WOR036" ] . ToString ( ) . Contains ( "System.Byte[]" ) )
                            //    _model . WPC032 = null;
                            //else
                            //    _model . WPC032 = ( byte? [ ] ) dt . Rows [ i ] [ "WOR036" ];
                            //if ( string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR037" ] . ToString ( ) ) || dt . Rows [ i ] [ "WOR037" ] . ToString ( ) . Contains ( "System.Byte[]" ) )
                            //    _model . WPC033 = null;
                            //else
                            //    _model . WPC033 = ( byte? [ ] ) dt . Rows [ i ] [ "WOR037" ];

                            _model . WPC035 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR002" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "WOR002" ] . ToString ( ) );

                            if ( da != null && da . Rows . Count > 0 )
                            {
                                if ( da . Select ( "WPC004='" + _model . WPC004 + "' AND WPC006='" + _model . WPC006 + "' AND WPC009='" + _model . WPC009 + "' AND WPC012='" + _model . WPC012 + "'" ) . Length > 0 )
                                {
                                    edit_code ( SQLString ,strSql ,_model );
                                }
                                else
                                {
                                    _model . WPC005 = getOddNum ( );
                                    if ( codeList . Contains ( _model . WPC005 ) )
                                    {
                                        _model . WPC005 = codeList . Max ( );
                                        _model . WPC005 = ( Convert . ToInt64 ( _model . WPC005 ) + 1 ) . ToString ( );
                                        codeList . Add ( _model . WPC005 );
                                    }
                                    else
                                        codeList . Add ( _model . WPC005 );

                                    add_code ( SQLString ,strSql ,_model );
                                }
                            }
                            else
                            {
                                _model . WPC005 = getOddNum ( );
                                if ( codeList . Contains ( _model . WPC005 ) )
                                {
                                    _model . WPC005 = codeList . Max ( );
                                    _model . WPC005 = ( Convert . ToInt64 ( _model . WPC005 ) + 1 ) . ToString ( );
                                    codeList . Add ( _model . WPC005 );
                                }
                                else
                                    codeList . Add ( _model . WPC005 );

                                add_code ( SQLString ,strSql ,_model );
                            }

                            //    if ( Exists ( _model . WPC001 ,_model . WPC002 ,_model . WPC004 ,_model . WPC006 ,_model . WPC009 ,_model . WPC012 ) == false )
                            //    {
                            //        _model . WPC005 = getOddNum ( );
                            //        if ( codeList . Contains ( _model . WPC005 ) )
                            //        {
                            //            _model . WPC005 = codeList . Max ( );
                            //            _model . WPC005 = ( Convert . ToInt64 ( _model . WPC005 ) + 1 ) . ToString ( );
                            //            codeList . Add ( _model . WPC005 );
                            //        }
                            //        else
                            //            codeList . Add ( _model . WPC005 );

                            //        add_code ( SQLString ,strSql ,_model );
                            //    }
                            
                            //else
                            //    edit_code ( SQLString ,strSql ,_model );
                        }
                    }
                    else
                        UserInformation . StrList . Add ( pro );
                }
                else
                    UserInformation . StrList . Add ( pro );
            }

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString . Clear ( );
                foreach ( string pro in strList )
                {
                    if ( Exists_ProBom ( pro ) )
                    {
                        edit_pic ( SQLString ,pro ,weekEnds );
                    }
                }
            }
            else
                return false;

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void edit_pic ( Hashtable SQLString ,string proNum ,string piNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXWPC SET WPC030=WOR034,WPC031=WOR035,WPC032=WOR036,WPC033=WOR037 FROM MOXWOR A INNER JOIN MOXWPC B ON A.WOR001=B.WPC002 AND A.WOR005=B.WPC003 AND A.WOR006=B.WPC004 AND A.WOR007=B.WPC006 AND A.WOR010=B.WPC009 AND A.WOR013=B.WPC012 WHERE WPC001='{0}' AND WPC002='{1}'" ,piNum ,proNum );

            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// Does Exists productNum in bom
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        bool Exists_ProBom ( string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXWOR WHERE WOR001='{0}'" ,productNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get product info and part info from bom
        /// </summary>
        /// <param name="idxStr"></param>
        /// <returns></returns>
        DataTable GetInformation ( string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT WOR001,WOR005,WOR006,WOR007,WOR008,WOR009,WOR010,WOR011,WOR012,WOR013,WOR014,WOR015,WOR016,WOR017,WOR018,WOR019,WOR020,WOR021,WOR022,WOR023,WOR024,WOR025,WOR026,WOR027,WOR028,WOR029,WOR030,WOR034,WOR035,WOR036,WOR037,WOR002 FROM  MOXWOR " );
            strSql . AppendFormat ( "WHERE WOR001='{0}'" ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// Does exists weekends,productNum,partName,len,width,height in code manager table
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="partName"></param>
        /// <returns></returns>
        bool Exists ( string weekEnds ,string productNum ,string partName ,string len ,string width ,string heigth )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXWPC " );
            strSql . AppendFormat ( "WHERE WPC001='{0}' AND WPC002='{1}' AND WPC004='{2}' AND WPC006='{3}' AND WPC009='{4}' AND WPC012='{5}'" ,weekEnds ,productNum ,partName ,len ,width ,heigth );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get datatable from moxwpc by weekEnds and productnum
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        DataTable getDa ( string weekEnds ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT WPC004,WPC006,WPC009,WPC012 FROM MOXWPC " );
            strSql . AppendFormat ( "WHERE WPC001='{0}' AND WPC002='{1}'" ,weekEnds ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get code from code manager table
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="partName"></param>
        /// <returns></returns>
        string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(WPC005) WPC005 FROM MOXWPC " );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "WPC005" ] . ToString ( ) ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "WPC005" ] . ToString ( ) . Substring ( 0 ,8 ) == UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "WPC005" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                }
            }
            else
                return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

        /// <summary>
        /// add code to code manager table
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="_model"></param>
        void add_code ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . BomWorkPlanCodeEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXWPC (" );
            strSql . Append ( "WPC001,WPC002,WPC003,WPC004,WPC005,WPC006,WPC007,WPC008,WPC009,WPC010,WPC011,WPC012,WPC013,WPC014,WPC015,WPC016,WPC017,WPC018,WPC019,WPC020,WPC021,WPC022,WPC023,WPC024,WPC025,WPC026,WPC027,WPC028,WPC029,WPC035) " );//WPC030,WPC031,WPC032,WPC033,
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@WPC001,@WPC002,@WPC003,@WPC004,@WPC005,@WPC006,@WPC007,@WPC008,@WPC009,@WPC010,@WPC011,@WPC012,@WPC013,@WPC014,@WPC015,@WPC016,@WPC017,@WPC018,@WPC019,@WPC020,@WPC021,@WPC022,@WPC023,@WPC024,@WPC025,@WPC026,@WPC027,@WPC028,@WPC029,@WPC035) " );//WPC030,WPC031,WPC032,WPC033,
            SqlParameter [ ] parameter = {
                new SqlParameter("@WPC001",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC002",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC003",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC004",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC005",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC006",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC007",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC008",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC009",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC010",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC011",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC012",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC013",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC014",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC015",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC016",SqlDbType.Decimal,10),
                new SqlParameter("@WPC017",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC018",SqlDbType.Int),
                new SqlParameter("@WPC019",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC020",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC021",SqlDbType.NVarChar,200),
                new SqlParameter("@WPC022",SqlDbType.Date),
                new SqlParameter("@WPC023",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC024",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC025",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC026",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC027",SqlDbType.Int),
                new SqlParameter("@WPC028",SqlDbType.Int),
                new SqlParameter("@WPC029",SqlDbType.NVarChar,20),
                //new SqlParameter("WPC030",SqlDbType.Image),
                //new SqlParameter("WPC031",SqlDbType.Image),
                //new SqlParameter("WPC032",SqlDbType.Image),
                //new SqlParameter("WPC033",SqlDbType.Image),
                new SqlParameter("@WPC035",SqlDbType.Decimal,9)
            };
            parameter [ 0 ] . Value = _model . WPC001;
            parameter [ 1 ] . Value = _model . WPC002;
            parameter [ 2 ] . Value = _model . WPC003;
            parameter [ 3 ] . Value = _model . WPC004;
            parameter [ 4 ] . Value = _model . WPC005;
            parameter [ 5 ] . Value = _model . WPC006;
            parameter [ 6 ] . Value = _model . WPC007;
            parameter [ 7 ] . Value = _model . WPC008;
            parameter [ 8 ] . Value = _model . WPC009;
            parameter [ 9 ] . Value = _model . WPC010;
            parameter [ 10 ] . Value = _model . WPC011;
            parameter [ 11 ] . Value = _model . WPC012;
            parameter [ 12 ] . Value = _model . WPC013;
            parameter [ 13 ] . Value = _model . WPC014;
            parameter [ 14 ] . Value = _model . WPC015;
            parameter [ 15 ] . Value = _model . WPC016;
            parameter [ 16 ] . Value = _model . WPC017;
            parameter [ 17 ] . Value = _model . WPC018;
            parameter [ 18 ] . Value = _model . WPC019;
            parameter [ 19 ] . Value = _model . WPC020;
            parameter [ 20 ] . Value = _model . WPC021;
            parameter [ 21 ] . Value = _model . WPC022;
            parameter [ 22 ] . Value = _model . WPC023;
            parameter [ 23 ] . Value = _model . WPC024;
            parameter [ 24 ] . Value = _model . WPC025;
            parameter [ 25 ] . Value = _model . WPC026;
            parameter [ 26 ] . Value = _model . WPC027;
            parameter [ 27 ] . Value = _model . WPC028;
            parameter [ 28 ] . Value = _model . WPC029;
            //parameter [ 29 ] . Value = _model . WPC030;
            //parameter [ 30 ] . Value = _model . WPC031;
            //parameter [ 31 ] . Value = _model . WPC032;
            //parameter [ 32 ] . Value = _model . WPC033;
            parameter [ 29 ] . Value = _model . WPC035;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// edit code from code manager table
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="_model"></param>
        void edit_code ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . BomWorkPlanCodeEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWPC SET " );
            strSql . Append ( "WPC003=@WPC003," );
            //strSql . Append ( "WPC005=WPC005," );
            strSql . Append ( "WPC007=@WPC007," );
            strSql . Append ( "WPC008=@WPC008," );
            strSql . Append ( "WPC010=@WPC010," );
            strSql . Append ( "WPC011=@WPC011," );
            strSql . Append ( "WPC013=@WPC013," );
            strSql . Append ( "WPC014=@WPC014," );
            strSql . Append ( "WPC015=@WPC015," );
            strSql . Append ( "WPC016=@WPC016," );
            strSql . Append ( "WPC017=@WPC017," );
            strSql . Append ( "WPC018=@WPC018," );
            strSql . Append ( "WPC019=@WPC019," );
            strSql . Append ( "WPC020=@WPC020," );
            strSql . Append ( "WPC021=@WPC021," );
            strSql . Append ( "WPC022=@WPC022," );
            strSql . Append ( "WPC023=@WPC023," );
            strSql . Append ( "WPC024=@WPC024," );
            strSql . Append ( "WPC025=@WPC025," );
            strSql . Append ( "WPC026=@WPC026," );
            strSql . Append ( "WPC027=@WPC027," );
            strSql . Append ( "WPC028=@WPC028," );
            strSql . Append ( "WPC029=@WPC029," );
            //strSql . Append ( "WPC030=WPC030," );
            //strSql . Append ( "WPC031=WPC031," );
            //strSql . Append ( "WPC032=WPC032," );
            //strSql . Append ( "WPC033=WPC033," );
            strSql . Append ( "WPC035=@WPC035 " );
            strSql . Append ( "WHERE WPC001=@WPC001 AND WPC002=@WPC002 AND WPC004=@WPC004 AND WPC006=@WPC006 AND WPC009=@WPC009 AND WPC012=@WPC012" );

            SqlParameter [ ] parameter = {
                new SqlParameter("@WPC001",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC002",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC003",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC004",SqlDbType.NVarChar,20),
                //new SqlParameter("WPC005",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC006",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC007",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC008",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC009",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC010",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC011",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC012",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC013",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC014",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC015",SqlDbType.NVarChar,20),
                new SqlParameter("@WPC016",SqlDbType.Decimal,10),
                new SqlParameter("@WPC017",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC018",SqlDbType.Int),
                new SqlParameter("@WPC019",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC020",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC021",SqlDbType.NVarChar,200),
                new SqlParameter("@WPC022",SqlDbType.Date),
                new SqlParameter("@WPC023",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC024",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC025",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC026",SqlDbType.NVarChar,50),
                new SqlParameter("@WPC027",SqlDbType.Int),
                new SqlParameter("@WPC028",SqlDbType.Int),
                new SqlParameter("@WPC029",SqlDbType.NVarChar,20),
                //new SqlParameter("WPC030",SqlDbType.Image),
                //new SqlParameter("WPC031",SqlDbType.Image),
                //new SqlParameter("WPC032",SqlDbType.Image),
                //new SqlParameter("WPC033",SqlDbType.Image),
                new SqlParameter("@WPC035",SqlDbType.Decimal,9)
            };
            parameter [ 0 ] . Value = _model . WPC001;
            parameter [ 1 ] . Value = _model . WPC002;
            parameter [ 2 ] . Value = _model . WPC003;
            parameter [ 3 ] . Value = _model . WPC004;
            //parameter [ 4 ] . Value = _model . WPC005;
            parameter [ 4 ] . Value = _model . WPC006;
            parameter [ 5 ] . Value = _model . WPC007;
            parameter [ 6 ] . Value = _model . WPC008;
            parameter [ 7 ] . Value = _model . WPC009;
            parameter [ 8 ] . Value = _model . WPC010;
            parameter [ 9 ] . Value = _model . WPC011;
            parameter [ 10 ] . Value = _model . WPC012;
            parameter [ 11 ] . Value = _model . WPC013;
            parameter [ 12 ] . Value = _model . WPC014;
            parameter [ 13 ] . Value = _model . WPC015;
            parameter [ 14 ] . Value = _model . WPC016;
            parameter [ 15 ] . Value = _model . WPC017;
            parameter [ 16 ] . Value = _model . WPC018;
            parameter [ 17 ] . Value = _model . WPC019;
            parameter [ 18 ] . Value = _model . WPC020;
            parameter [ 19 ] . Value = _model . WPC021;
            parameter [ 20 ] . Value = _model . WPC022;
            parameter [ 21 ] . Value = _model . WPC023;
            parameter [ 22 ] . Value = _model . WPC024;
            parameter [ 23 ] . Value = _model . WPC025;
            parameter [ 24 ] . Value = _model . WPC026;
            parameter [ 25 ] . Value = _model . WPC027;
            parameter [ 26 ] . Value = _model . WPC028;
            parameter [ 27 ] . Value = _model . WPC029;
            //parameter [ 28 ] . Value = _model . WPC030;
            //parameter [ 29 ] . Value = _model . WPC031;
            //parameter [ 30 ] . Value = _model . WPC032;
            //parameter [ 31 ] . Value = _model . WPC033;
            parameter [ 28 ] . Value = _model . WPC035;
            
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 获取打印传票的数据列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="idxStr"></param>
        /// <returns></returns>
        public DataTable printOne ( string weekEnds ,List<string> proList )
        {
            string proStr = string . Empty;
            foreach ( string s in proList )
            {
                if ( proStr == string . Empty )
                    proStr = s;
                else
                    proStr = proStr + "," + s;
            }
            
            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "WITH CET AS(SELECT COUNT(WPC015) WOR,WPC015 FROM MOXWPC WHERE WPC002 IN ({0}) GROUP BY WPC015" ,proStr );
            //strSql . Append ( "),CIT AS( " );
            //strSql . AppendFormat ( "SELECT WPC002,WPC003,dbo.USF_ExtractNumeric(WPC009) WPC009 FROM MOXWPC WHERE WPC009 LIKE '%/%' AND WPC002 IN ({0})  " ,proStr );
            //strSql . Append ( "),CGT AS( " );
            //strSql . Append ( "SELECT WPC002,WPC003,CASE WHEN WPC009 LIKE '%/%' THEN dbo.Fun_GetStrArrayStrOfIndex(WPC009,'/',0) ELSE WPC009 END WPC009 FROM CIT  " );
            //strSql . Append ( "),CHT AS (" );
            //strSql . Append ( "SELECT WPC002,WPC003,CASE WHEN WPC009 LIKE '%/%' THEN dbo.Fun_GetStrArrayStrOfIndex(WPC009,'/',2) ELSE WPC009 END WPC009 FROM CIT " );
            //strSql . Append ( "),CJT AS(" );
            //strSql . Append ( "SELECT A.WPC003,A.WPC002,(CONVERT(DECIMAL(11,2),A.WPC009)+CONVERT(DECIMAL(11,2),B.WPC009))/2 WPC009 FROM CGT A INNER JOIN CHT B ON A.WPC002=B.WPC002 AND A.WPC003=B.WPC003)" );
            //strSql . Append ( ",CFT AS (" );
            //strSql . Append ( "SELECT OPI003+WPC015+'作业传票' WOR,WPC029 WOR030,WPC015 WOR016,CUU008 WOQ008,CUU003,WPC004 WOR006,CONVERT(FLOAT,WPC016*CUU003) WOR017,WPC017 WOR018,WPC026 WOR027,WPC024 WOR025,WPC025 WOR026,'拼'+CONVERT(VARCHAR,WPC027)+'宽画'+CONVERT(VARCHAR,WPC028)+'根' WOR028,CONVERT(DECIMAL(11,0),CASE WHEN WPC028=0 THEN 0 ELSE WPC016*CUU003/WPC028 END) WOR029 ,WPC030 WOR034,WPC031 WOR035,WPC032 WOR036,WPC033 WOR037,WPC021 WOR022,WPC005,CUU001,CASE WHEN WPC006!='' THEN WPC006 ELSE WPC007 END WOR008,CASE WHEN B.WPC009!='' THEN B.WPC009 ELSE WPC010 END WOR010,CASE WHEN WPC012!='' THEN WPC012 ELSE WPC013 END WOR013,CONVERT(DECIMAL(11,2),CASE WHEN dbo.USF_ExtractNumeric(B.WPC009)='' THEN 0 WHEN B.WPC009 LIKE '%/%' THEN WPC016*CONVERT(DECIMAL(11,2),E.WPC009)*WPC035/1000 ELSE WPC016*CONVERT(DECIMAL(11,2),dbo.USF_ExtractNumeric(B.WPC009))*WPC035/1000 END) WOR0101 FROM MOXWPC B LEFT JOIN MOXCUU C ON B.WPC002=C.CUU002 AND B.WPC001=C.CUU001 LEFT JOIN CJT E ON B.WPC003=E.WPC003 AND B.WPC002=E.WPC002 INNER JOIN MOXOPI F ON C.CUU002=F.OPI001 " );
            //strSql . AppendFormat ( "WHERE CUU001='{0}' AND WPC015!='' AND CUU002 IN ({1}) " ,weekEnds ,proStr );
            //strSql . Append ( ") " );
            //strSql . Append ( "SELECT B.*,'NO.'+CONVERT(VARCHAR,A.WOR)+'_'+CONVERT(VARCHAR,WOR030)+'('+A.WPC015+')' WORNUM FROM CET A INNER JOIN CFT B ON A.WPC015=B.WOR016 ORDER BY WOQ008,WOR,CONVERT(INT,WOR030)" );

            //return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            
            SqlHelper . StoreProcedure ( "PRINTPRODUCTCP" );
            SqlParameter [ ] parameter = {
                new SqlParameter("PRODUCTNUM",proStr ),
                new SqlParameter("PNUM",weekEnds)
                };

            return SqlHelper . ExecuteNoStoreTable ( parameter );
        }

        /// <summary>
        /// 获取清单打印列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="typeOfPro"></param>
        /// <param name="typeOfWork"></param>
        /// <returns></returns>
        public DataTable getOrderTable ( string weekEnds,string typeOfPro,string typeOfWork ,string proNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS(SELECT WPC001,WPC002,WPC006,WPC009,WPC012,dbo.Fun_GetStrArrayStrOfIndex(dbo.USF_ExtractNumeric(ISNULL(WPC009,0)),'/',0) WPC9,dbo.Fun_GetStrArrayStrOfIndex(dbo.USF_ExtractNumeric(ISNULL(WPC006,0)),'/',0) WPC06 FROM MOXWPC WHERE WPC001='{0}' AND WPC015='{1}' AND WPC002 IN ({2}) )" ,weekEnds ,typeOfWork ,proNum );
            strSql . Append ( "SELECT distinct OPI003+A.WPC015+'汇总'+'('+A.WPC001+')' WO,A.WPC002,CUU008,A.WPC004,A.WPC006+'*'+A.WPC009+'*'+A.WPC012 WPC,A.WPC017 OPI006,OPI007,CONVERT(FLOAT,A.WPC016) WPC016,CUU003,A.WPC021,CASE WHEN WPC9='' THEN 0 WHEN WPC06='' THEN 0 WHEN A.WPC006 LIKE 'Φ%' THEN CONVERT(DECIMAL,A.WPC016)*CUU003*3.14*CONVERT(DECIMAL,WPC06/200)*CONVERT(DECIMAL,WPC06/200) ELSE CONVERT(DECIMAL,A.WPC016)*CUU003*CONVERT(DECIMAL,WPC9)*CONVERT(DECIMAL,WPC06)/1000000 END WP FROM MOXWPC A INNER JOIN MOXCUU B ON A.WPC001=B.CUU001 AND A.WPC002=B.CUU002 INNER JOIN MOXOPI C ON A.WPC002=C.OPI001 INNER JOIN CET D ON A.WPC001=D.WPC001 AND A.WPC002=D.WPC002 AND A.WPC006=D.WPC006 AND A.WPC009=D.WPC009 AND A.WPC012=D.WPC012 " );
            strSql . AppendFormat ( "WHERE A.WPC001='{0}' AND OPI003='{1}' AND A.WPC015='{2}' AND A.WPC002 IN ({3}) ORDER BY A.WPC002" ,weekEnds ,typeOfPro ,typeOfWork ,proNum );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 获取板材清单打印列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="typeOfPro"></param>
        /// <param name="typeOfWork"></param>
        /// <returns></returns>
        public DataTable getOrderTable ( string weekEnds ,string typeOfPro  ,string proNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS(SELECT WPC001,WPC002,WPC006,WPC009,WPC012,dbo.Fun_GetStrArrayStrOfIndex(dbo.USF_ExtractNumeric(ISNULL(WPC009,0)),'/',0) WPC9,dbo.Fun_GetStrArrayStrOfIndex(dbo.USF_ExtractNumeric(ISNULL(WPC006,0)),'/',0) WPC06,dbo.Fun_GetStrArrayStrOfIndex(dbo.USF_ExtractNumeric(ISNULL(WPC012,0)),'/',0) WPC12 FROM MOXWPC WHERE WPC001='{0}' AND WPC015='拼板' AND WPC002 IN ({1}) )" ,weekEnds ,proNum );
            strSql . Append ( "SELECT OPI003+A.WPC015+'分汇总'+'('+A.WPC001+')' WO,A.WPC002,CUU008,A.WPC004,A.WPC006+'*'+A.WPC009+'*'+A.WPC012 WPC,A.WPC017 OPI006,OPI007,CONVERT(FLOAT,A.WPC016) WPC016,CUU003,A.WPC021,CASE WHEN WPC9='' THEN 0 WHEN WPC06='' THEN 0 WHEN A.WPC006 LIKE 'Φ%' THEN CONVERT(DECIMAL,A.WPC016)*CUU003*3.14*CONVERT(DECIMAL,WPC06/200)*CONVERT(DECIMAL,WPC06/200) ELSE CONVERT(DECIMAL,A.WPC016)*CUU003*CONVERT(DECIMAL,WPC9)*CONVERT(DECIMAL,WPC06)/1000000 END WP,WPC12 FROM MOXWPC A INNER JOIN MOXCUU B ON A.WPC001=B.CUU001 AND A.WPC002=B.CUU002 INNER JOIN MOXOPI C ON A.WPC002=C.OPI001  INNER JOIN CET D ON A.WPC001=D.WPC001 AND A.WPC002=D.WPC002 AND A.WPC006=D.WPC006 AND A.WPC009=D.WPC009 AND A.WPC012=D.WPC012 " );
            strSql . AppendFormat ( "WHERE A.WPC001='{0}' AND OPI003='{1}' AND A.WPC015='拼板' AND A.WPC002 IN ({2}) ORDER BY CUU008 ASC,case ISNUMERIC(A.WPC012) when 1 then CONVERT(DECIMAL,A.WPC012) when 0 then '99999' END ASC" ,weekEnds ,typeOfPro ,proNum );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取产品类别
        /// </summary>
        /// <returns></returns>
        public List<string> getTypeOfPro ( )
        {
            List<string> typeOfPro = new List<string> ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT OPI003 FROM MOXOPI " );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    typeOfPro . Add ( dt . Rows [ i ] [ "OPI003" ] . ToString ( ) );
                }
                return typeOfPro;
            }
            else
                return null;
        }

        /// <summary>
        /// 获取封边清单打印列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="typeOfPro"></param>
        /// <returns></returns>
        public DataTable  getPartFB ( string weekEnds,string typeOfPro,string proNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT row,OPI003+WPC015+'(封边)汇总'+'('+WPC001+')' WO,CUU008,CUU003,WPC004,REPLACE(WPC006,'毛','') WPC006,REPLACE(WPC009,'毛','') WPC009,REPLACE(WPC012,'净','') WPC012,CONVERT(INT,REPLACE(WPC012,'净','')) WPC0122,case ISNUMERIC(REPLACE(WPC006,'毛','')) when 1 then CONVERT(DECIMAL,REPLACE(WPC006,'毛','')) when 0 then '99999' END WPC0006,CONVERT(FLOAT,WPC016) WPC016,CONVERT(FLOAT,CUU003*WPC016) WPC,WPC017 FROM MOXWPC A INNER JOIN (SELECT ROW_NUMBER() over(ORDER BY CUU001) row,CUU001,CUU002,CUU003,CUU008 FROM MOXCUU) B ON A.WPC001=B.CUU001 AND A.WPC002=B.CUU002 INNER JOIN MOXOPI C ON A.WPC002=C.OPI001 " );
            //strSql . AppendFormat ( "WHERE WPC001='{0}' AND OPI003='{1}' AND WPC002 IN ({2}) AND WPC015='包拼' AND WPC004 LIKE '%封边%' ORDER BY CONVERT(INT,REPLACE(WPC012,'净','')) DESC,case ISNUMERIC(REPLACE(WPC006,'毛','')) when 1 then CONVERT(DECIMAL,REPLACE(WPC006,'毛','')) when 0 then '99999' END DESC,WPC004 asc,case ISNUMERIC(WPC009) when 1 then CONVERT(DECIMAL,WPC009) when 0 then '99999' END DESC" ,weekEnds ,typeOfPro ,proNum );

            strSql . Append ( "SELECT row,OPI003+WPC015+'汇总'+'('+WPC001+')' WO,CUU008,CUU003,WPC004,dbo.F_Get_Number(WPC006) WPC006,dbo.F_Get_Number(WPC009) WPC009,dbo.F_Get_Number(WPC012) WPC012,CONVERT(DECIMAL,dbo.F_Get_Number(WPC012)) WPC0122,case ISNUMERIC(dbo.F_Get_Number(WPC006)) when 1 then CONVERT(DECIMAL,dbo.F_Get_Number(WPC006)) when 0 then '99999' END WPC0006,CONVERT(FLOAT,WPC016) WPC016,CONVERT(FLOAT,CUU003*WPC016) WPC,WPC017 FROM MOXWPC A INNER JOIN (SELECT ROW_NUMBER() over(ORDER BY CUU001) row,CUU001,CUU002,CUU003,CUU008 FROM MOXCUU) B ON A.WPC001=B.CUU001 AND A.WPC002=B.CUU002 INNER JOIN MOXOPI C ON A.WPC002=C.OPI001 " );
            //AND WPC004 LIKE '%封边%'
            strSql . AppendFormat ( "WHERE WPC001='{0}' AND OPI003='{1}' AND WPC002 IN ({2}) AND WPC015='包拼' ORDER BY CONVERT(DECIMAL,dbo.F_Get_Number(WPC012)) DESC,case ISNUMERIC(dbo.F_Get_Number(WPC006)) when 1 then CONVERT(DECIMAL,dbo.F_Get_Number(WPC006)) when 0 then '99999' END DESC,WPC004 asc,case ISNUMERIC(WPC009) when 1 then CONVERT(DECIMAL,WPC009) when 0 then '99999' END DESC" ,weekEnds ,typeOfPro ,proNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
