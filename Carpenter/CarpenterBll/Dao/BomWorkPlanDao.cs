using StudentMgr;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace CarpenterBll . Dao
{
    public class BomWorkPlanDao
    {

        /// <summary>
        /// 替换直径符号等
        /// </summary>
        /// <returns></returns>
        public string editOther ( )
        {
            Task ts = new Task ( editOtherWPC );
            ts . Start ( );

            return string . Empty;
        }

        void editOtherWPC ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWPC SET WPC006= REPLACE(WPC006,'直径','Φ') WHERE WPC006 LIKE '直径%'" );
            strSql . Append ( ";UPDATE MOXWPC SET WPC006= REPLACE(WPC006,'￠','Φ') WHERE WPC006 LIKE '￠%'" );
            strSql . Append ( ";UPDATE MOXWPC SET WPC006= REPLACE(WPC006,'∮','Φ') WHERE WPC006 LIKE '∮%'" );
            strSql . Append ( ";UPDATE MOXWOR SET WOR007= REPLACE(WOR007,'直径','Φ') WHERE WOR007 LIKE '直径%'" );
            strSql . Append ( ";UPDATE MOXWOR SET WOR007=REPLACE(WOR007,'￠','Φ') WHERE WOR007 LIKE '￠%'" );
            strSql . Append ( ";UPDATE MOXWOR SET WOR007=REPLACE(WOR007,'∮','Φ') WHERE WOR007 LIKE '∮%'" );

            SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableProduct ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT OPI001,OPI002,OPI003,OPI005,OPI006,OPI007,OPI012 FROM MOXOPI WHERE OPI011=0 ORDER BY OPI001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePerson ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT EMP001,EMP002 FROM MOXEMP WHERE EMP001!='00001' AND EMP008=0" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePro ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT WOQ001,OPI002 FROM MOXWOQ A LEFT JOIN MOXOPI B ON A.WOQ001=B.OPI001 " );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public bool Delete ( string productNum )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXWOQ WHERE WOQ001='{0}'" ,productNum );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXWOR WHERE WOR001='{0}'" ,productNum );
            SQLString . Add ( strSql . ToString ( ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="productNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Cancellation ( string productNum ,bool state )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWOQ SET WOQ007=@WOQ007 WHERE WOQ001=@WOQ001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WOQ001",SqlDbType.NVarChar,20),
                new SqlParameter("@WOQ007",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = productNum;
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
        /// <param name="productNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examine ( string productNum ,bool state )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWOQ SET WOQ010=@WOQ010 WHERE WOQ001=@WOQ001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WOQ001",SqlDbType.NVarChar,20),
                new SqlParameter("@WOQ010",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = productNum;
            parameter [ 1 ] . Value = state;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取单头数据列表
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOne ( string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT WOQ001,WOQ002,WOQ003,WOQ004,WOQ008,WOQ009,WOQ007,WOQ010 FROM MOXWOQ " );
            strSql . Append ( "WHERE WOQ001=@WOQ001" );
            SqlParameter[] parameter ={
                new SqlParameter("@WOQ001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = productNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );

        }

        /// <summary>
        /// 获取单身数据列表
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo ( string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,WOR001,WOR005,WOR006,WOR007,WOR008,WOR009,WOR010,WOR011,WOR012,WOR013,WOR014,WOR015,WOR016,CONVERT(FLOAT,WOR017)  WOR017,WOR018,WOR019,WOR020,WOR021,WOR022,WOR025,WOR026,WOR027,WOR028,WOR029,WOR030,WOR034,WOR035,WOR036,WOR037,CONVERT(FLOAT,WOR002) WOR002 FROM MOXWOR " );
            strSql . Append ( "WHERE WOR001=@WOR001" );
            SqlParameter [ ] parameter ={
                new SqlParameter("@WOR001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = productNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 增加一单记录
        /// </summary>
        /// <param name="tableQuery"></param>
        /// <param name="_modelOne"></param>
        /// <returns></returns>
        public bool Add ( DataTable tableQuery ,CarpenterEntity . BomWorkPlanWOQEntity _modelOne )
        {
            Hashtable SQLSting = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            InsertWoq ( SQLSting ,strSql ,_modelOne );

            CarpenterEntity . BomWorkPlanWOREntity _modelTwo = new CarpenterEntity . BomWorkPlanWOREntity ( );
            _modelTwo . WOR001 = _modelOne . WOQ001;
            _modelTwo . WOR023 = _modelOne . WOQ005;
            _modelTwo . WOR024 = _modelOne . WOQ006;

            for ( int i = 0 ; i < tableQuery . Rows . Count ; i++ )
            {
                _modelTwo . WOR002 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR002" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQuery . Rows [ i ] [ "WOR002" ] . ToString ( ) );
                _modelTwo . WOR005 = tableQuery . Rows [ i ] [ "WOR005" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR006 = tableQuery . Rows [ i ] [ "WOR006" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR007 = tableQuery . Rows [ i ] [ "WOR007" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR008 = tableQuery . Rows [ i ] [ "WOR008" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR009 = tableQuery . Rows [ i ] [ "WOR009" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR010 = tableQuery . Rows [ i ] [ "WOR010" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR011 = tableQuery . Rows [ i ] [ "WOR011" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR012 = tableQuery . Rows [ i ] [ "WOR012" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR013 = tableQuery . Rows [ i ] [ "WOR013" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR014 = tableQuery . Rows [ i ] [ "WOR014" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR015 = tableQuery . Rows [ i ] [ "WOR015" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR016 = tableQuery . Rows [ i ] [ "WOR016" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR017 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQuery . Rows [ i ] [ "WOR017" ] . ToString ( ) );
                _modelTwo . WOR018 = tableQuery . Rows [ i ] [ "WOR018" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR019 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR019" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR019" ] . ToString ( ) );
                _modelTwo . WOR020 = tableQuery . Rows [ i ] [ "WOR020" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR021 = tableQuery . Rows [ i ] [ "WOR021" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR022 = tableQuery . Rows [ i ] [ "WOR022" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR025 = tableQuery . Rows [ i ] [ "WOR025" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR026 = tableQuery . Rows [ i ] [ "WOR026" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR027 = tableQuery . Rows [ i ] [ "WOR027" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR028 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR028" ] . ToString ( ) );
                _modelTwo . WOR029 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR029" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR029" ] . ToString ( ) );
                _modelTwo . WOR030 = tableQuery . Rows [ i ] [ "WOR030" ] . ToString ( ) . Trim ( );
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR034" ] . ToString ( ) ) )
                    _modelTwo . WOR034 = new byte [ 0 ];
                else
                    _modelTwo . WOR034 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR034" ];
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR035" ] . ToString ( ) ) )
                    _modelTwo . WOR035 = new byte [ 0 ];
                else
                    _modelTwo . WOR035 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR035" ];
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR036" ] . ToString ( ) ) )
                    _modelTwo . WOR036 = new byte [ 0 ];
                else
                    _modelTwo . WOR036 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR036" ];
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR037" ] . ToString ( ) ) )
                    _modelTwo . WOR037 = new byte [ 0 ];
                else
                    _modelTwo . WOR037 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR037" ];
                if ( _modelTwo . WOR006 . Trim ( ) != string . Empty )
                    InsertWor ( SQLSting ,strSql ,_modelTwo );
            }

            return SqlHelper . ExecuteSqlTran ( SQLSting );
        }
        
        /// <summary>
        /// 编辑一单记录
        /// </summary>
        /// <param name="tableQuery"></param>
        /// <param name="_modelOne"></param>
        /// <param name="tableQueryOne"></param>
        /// <returns></returns>
        public bool Edit ( DataTable tableQuery ,CarpenterEntity . BomWorkPlanWOQEntity _modelOne ,List<string> idxList )
        {
            bool result = false;
            Hashtable SQLSting = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx FROM MOXWOR WHERE WOR001='{0}'" ,_modelOne . WOQ001 );
            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                result = true;

            EditWoq ( SQLSting ,strSql ,_modelOne );

            CarpenterEntity . BomWorkPlanWOREntity _modelTwo = new CarpenterEntity . BomWorkPlanWOREntity ( );
            _modelTwo . WOR001 = _modelOne . WOQ001;
            _modelTwo . WOR023 = _modelOne . WOQ005;
            _modelTwo . WOR024 = _modelOne . WOQ006;

            for ( int i = 0 ; i < tableQuery . Rows . Count ; i++ )
            {
                _modelTwo . WOR002 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR002" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQuery . Rows [ i ] [ "WOR002" ] . ToString ( ) );
                _modelTwo . WOR005 = tableQuery . Rows [ i ] [ "WOR005" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR006 = tableQuery . Rows [ i ] [ "WOR006" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR007 = tableQuery . Rows [ i ] [ "WOR007" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR008 = tableQuery . Rows [ i ] [ "WOR008" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR009 = tableQuery . Rows [ i ] [ "WOR009" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR010 = tableQuery . Rows [ i ] [ "WOR010" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR011 = tableQuery . Rows [ i ] [ "WOR011" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR012 = tableQuery . Rows [ i ] [ "WOR012" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR013 = tableQuery . Rows [ i ] [ "WOR013" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR014 = tableQuery . Rows [ i ] [ "WOR014" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR015 = tableQuery . Rows [ i ] [ "WOR015" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR016 = tableQuery . Rows [ i ] [ "WOR016" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR017 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQuery . Rows [ i ] [ "WOR017" ] . ToString ( ) );
                _modelTwo . WOR018 = tableQuery . Rows [ i ] [ "WOR018" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR019 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR019" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR019" ] . ToString ( ) );
                _modelTwo . WOR020 = tableQuery . Rows [ i ] [ "WOR020" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR021 = tableQuery . Rows [ i ] [ "WOR021" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR022 = tableQuery . Rows [ i ] [ "WOR022" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR025 = tableQuery . Rows [ i ] [ "WOR025" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR026 = tableQuery . Rows [ i ] [ "WOR026" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR027 = tableQuery . Rows [ i ] [ "WOR027" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR028 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR028" ] . ToString ( ) );
                _modelTwo . WOR029 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR029" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR029" ] . ToString ( ) );
                _modelTwo . WOR030 = tableQuery . Rows [ i ] [ "WOR030" ] . ToString ( ) . Trim ( );
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR034" ] . ToString ( ) ) )
                    _modelTwo . WOR034 = new byte [ 0 ];
                else
                    _modelTwo . WOR034 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR034" ];
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR035" ] . ToString ( ) ) )
                    _modelTwo . WOR035 = new byte [ 0 ];
                else
                    _modelTwo . WOR035 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR035" ];
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR036" ] . ToString ( ) ) )
                    _modelTwo . WOR036 = new byte [ 0 ];
                else
                    _modelTwo . WOR036 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR036" ];
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR037" ] . ToString ( ) ) )
                    _modelTwo . WOR037 = new byte [ 0 ];
                else
                    _modelTwo . WOR037 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR037" ];
                _modelTwo . idx = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( result == false && _modelTwo . WOR006.Trim() != string . Empty )
                    InsertWor ( SQLSting ,strSql ,_modelTwo );
                else
                {
                    if ( dt . Select ( "idx='" + _modelTwo . idx + "'" ) . Length < 1 && _modelTwo . WOR006.Trim() != string . Empty )
                        InsertWor ( SQLSting ,strSql ,_modelTwo );
                    else if ( _modelTwo . WOR006 . Trim() != string . Empty )
                        EditWor ( SQLSting ,strSql ,_modelTwo );
                }
            }

            if ( idxList != null && idxList . Count > 0 )
            {
                foreach ( string id in idxList )
                {
                    _modelTwo . idx = Convert . ToInt32 ( id );
                    DeleteWor ( SQLSting ,strSql ,_modelTwo );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLSting );
        }

        void InsertWoq ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . BomWorkPlanWOQEntity _modelOne )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXWOQ (" );
            strSql . Append ( "WOQ001,WOQ002,WOQ003,WOQ004,WOQ005,WOQ006,WOQ007,WOQ008,WOQ009,WOQ010) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@WOQ001," );
            if ( _modelOne . WOQ002 == null )
                strSql . Append ( "NULL," );
            else
                strSql . AppendFormat ( "'{0}'," ,_modelOne . WOQ002 );
            if ( _modelOne . WOQ003 == null )
                strSql . Append ( "NULL," );
            else
                strSql . AppendFormat ( "'{0}'," ,_modelOne . WOQ003 );
            strSql . Append ( "@WOQ004,@WOQ005,@WOQ006,@WOQ007,@WOQ008,@WOQ009,@WOQ010);" );
            SqlParameter [ ] parameter = {
                        new SqlParameter("@WOQ001",SqlDbType.NVarChar,20),
                        new SqlParameter("@WOQ004",SqlDbType.NVarChar,20),
                        new SqlParameter("@WOQ005",SqlDbType.Date),
                        new SqlParameter("@WOQ006",SqlDbType.NVarChar,20),
                        new SqlParameter("@WOQ007",SqlDbType.Bit),
                        new SqlParameter("@WOQ008",SqlDbType.NVarChar,20),
                        new SqlParameter("@WOQ009",SqlDbType.NVarChar,20),
                        new SqlParameter("@WOQ010",SqlDbType.Bit)
                    };
            parameter [ 0 ] . Value = _modelOne . WOQ001 . Trim ( );
            parameter [ 1 ] . Value = _modelOne . WOQ004 . Trim ( );
            parameter [ 2 ] . Value = _modelOne . WOQ005;
            parameter [ 3 ] . Value = _modelOne . WOQ006 . Trim ( );
            parameter [ 4 ] . Value = _modelOne . WOQ007;
            parameter [ 5 ] . Value = _modelOne . WOQ008 . Trim ( );
            parameter [ 6 ] . Value = _modelOne . WOQ009 . Trim ( );
            parameter [ 7 ] . Value = _modelOne . WOQ010;

            SQLString . Add ( strSql ,parameter );
        }

        void EditWoq ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . BomWorkPlanWOQEntity _modelOne )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWOQ SET " );
            if ( _modelOne . WOQ002 == null )
                strSql . Append ( "WOQ002=NULL," );
            else
                strSql . AppendFormat ( "WOQ002='{0}'," ,_modelOne . WOQ002 );
            if ( _modelOne . WOQ003 == null )
                strSql . Append ( "WOQ003=NULL," );
            else
                strSql . AppendFormat ( "WOQ003='{0}'," ,_modelOne . WOQ003 );
            strSql . Append ( "WOQ004=@WOQ004," );
            strSql . Append ( "WOQ005=@WOQ005," );
            strSql . Append ( "WOQ006=@WOQ006 " );
            strSql . Append ( "WHERE WOQ001=@WOQ001" );
            SqlParameter [ ] parameter = {
                   new SqlParameter("@WOQ001",SqlDbType.NVarChar,20),
                   //new SqlParameter("@WOQ002",SqlDbType.Date),
                   //new SqlParameter("@WOQ003",SqlDbType.Date),
                   new SqlParameter("@WOQ004",SqlDbType.NVarChar,20),
                   new SqlParameter("@WOQ005",SqlDbType.Date),
                   new SqlParameter("@WOQ006",SqlDbType.NVarChar,20)
            };
            //parameter [ 0 ] . Value = _modelOne . WOQ002;
            //parameter [ 1 ] . Value = _modelOne . WOQ003;
            parameter [ 0 ] . Value = _modelOne . WOQ001;
            parameter [ 1 ] . Value = _modelOne . WOQ004;
            parameter [ 2 ] . Value = _modelOne . WOQ005;
            parameter [ 3 ] . Value = _modelOne . WOQ006;

            SQLString . Add ( strSql ,parameter );
        }

        void InsertWor ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . BomWorkPlanWOREntity _modelTwo )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXWOR (" );
            strSql . Append ( "WOR001,WOR005,WOR006,WOR007,WOR008,WOR009,WOR010,WOR011,WOR012,WOR013,WOR014,WOR015,WOR016,WOR017,WOR018,WOR019,WOR020,WOR021,WOR022,WOR023,WOR024,WOR025,WOR026,WOR027,WOR028,WOR029,WOR030,WOR034,WOR035,WOR036,WOR037,WOR002) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@WOR001,@WOR005,@WOR006,@WOR007,@WOR008,@WOR009,@WOR010,@WOR011,@WOR012,@WOR013,@WOR014,@WOR015,@WOR016,@WOR017,@WOR018,@WOR019,@WOR020,@WOR021,@WOR022,@WOR023,@WOR024,@WOR025,@WOR026,@WOR027,@WOR028,@WOR029,@WOR030,@WOR034,@WOR035,@WOR036,@WOR037,@WOR002)" );
            SqlParameter [ ] parameter = {
                    new SqlParameter("@WOR001",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR005",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR006",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR007",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR008",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR009",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR010",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR011",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR012",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR013",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR014",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR015",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR016",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR017",SqlDbType.Decimal,10),
                    new SqlParameter("@WOR018",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR019",SqlDbType.Int),
                    new SqlParameter("@WOR020",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR021",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR022",SqlDbType.NVarChar,500),
                    new SqlParameter("@WOR023",SqlDbType.Date),
                    new SqlParameter("@WOR024",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR025",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR026",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR027",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR028",SqlDbType.Int),
                    new SqlParameter("@WOR029",SqlDbType.Int),
                    new SqlParameter("@WOR030",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR034",SqlDbType.Image),
                    new SqlParameter("@WOR035",SqlDbType.Image),
                    new SqlParameter("@WOR036",SqlDbType.Image),
                    new SqlParameter("@WOR037",SqlDbType.Image),
                    new SqlParameter("@WOR002",SqlDbType.Decimal,9)
                };
            parameter [ 0 ] . Value = _modelTwo . WOR001;
            parameter [ 1 ] . Value = _modelTwo . WOR005;
            parameter [ 2 ] . Value = _modelTwo . WOR006;
            parameter [ 3 ] . Value = _modelTwo . WOR007;
            parameter [ 4 ] . Value = _modelTwo . WOR008;
            parameter [ 5 ] . Value = _modelTwo . WOR009;
            parameter [ 6 ] . Value = _modelTwo . WOR010;
            parameter [ 7 ] . Value = _modelTwo . WOR011;
            parameter [ 8 ] . Value = _modelTwo . WOR012;
            parameter [ 9 ] . Value = _modelTwo . WOR013;
            parameter [ 10 ] . Value = _modelTwo . WOR014;
            parameter [ 11 ] . Value = _modelTwo . WOR015;
            parameter [ 12 ] . Value = _modelTwo . WOR016;
            parameter [ 13 ] . Value = _modelTwo . WOR017;
            parameter [ 14 ] . Value = _modelTwo . WOR018;
            parameter [ 15 ] . Value = _modelTwo . WOR019;
            parameter [ 16 ] . Value = _modelTwo . WOR020;
            parameter [ 17 ] . Value = _modelTwo . WOR021;
            parameter [ 18 ] . Value = _modelTwo . WOR022;
            parameter [ 19 ] . Value = _modelTwo . WOR023;
            parameter [ 20 ] . Value = _modelTwo . WOR024;
            parameter [ 21 ] . Value = _modelTwo . WOR025;
            parameter [ 22 ] . Value = _modelTwo . WOR026;
            parameter [ 23 ] . Value = _modelTwo . WOR027;
            parameter [ 24 ] . Value = _modelTwo . WOR028;
            parameter [ 25 ] . Value = _modelTwo . WOR029;
            parameter [ 26 ] . Value = _modelTwo . WOR030;
            parameter [ 27 ] . Value = _modelTwo . WOR034;
            parameter [ 28 ] . Value = _modelTwo . WOR035;
            parameter [ 29 ] . Value = _modelTwo . WOR036;
            parameter [ 30 ] . Value = _modelTwo . WOR037;
            parameter [ 31 ] . Value = _modelTwo . WOR002;

            SQLString . Add ( strSql ,parameter );
        }

        void EditWor ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . BomWorkPlanWOREntity _modelTwo )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWOR SET " );
            strSql . Append ( "WOR006=@WOR006," );
            strSql . Append ( "WOR007=@WOR007," );
            strSql . Append ( "WOR008=@WOR008," );
            strSql . Append ( "WOR009=@WOR009," );
            strSql . Append ( "WOR010=@WOR010," );
            strSql . Append ( "WOR011=@WOR011," );
            strSql . Append ( "WOR012=@WOR012," );
            strSql . Append ( "WOR013=@WOR013," );
            strSql . Append ( "WOR014=@WOR014," );
            strSql . Append ( "WOR015=@WOR015," );
            strSql . Append ( "WOR016=@WOR016," );
            strSql . Append ( "WOR017=@WOR017," );
            strSql . Append ( "WOR018=@WOR018," );
            strSql . Append ( "WOR019=@WOR019," );
            strSql . Append ( "WOR020=@WOR020," );
            strSql . Append ( "WOR021=@WOR021," );
            strSql . Append ( "WOR022=@WOR022," );
            strSql . Append ( "WOR023=@WOR023," );
            strSql . Append ( "WOR024=@WOR024," );
            strSql . Append ( "WOR025=@WOR025," );
            strSql . Append ( "WOR026=@WOR026," );
            strSql . Append ( "WOR027=@WOR027," );
            strSql . Append ( "WOR028=@WOR028," );
            strSql . Append ( "WOR029=@WOR029," );
            strSql . Append ( "WOR030=@WOR030," );
            strSql . Append ( "WOR034=@WOR034," );
            strSql . Append ( "WOR035=@WOR035," );
            strSql . Append ( "WOR036=@WOR036," );
            strSql . Append ( "WOR037=@WOR037," );
            strSql . Append ( "WOR002=@WOR002," );
            strSql . Append ( "WOR005=@WOR005 " );
            strSql . Append ( "WHERE idx=@idx " );
            SqlParameter [ ] parameter = {
                    new SqlParameter("@idx",SqlDbType.Int,4),
                    new SqlParameter("@WOR005",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR006",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR007",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR008",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR009",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR010",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR011",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR012",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR013",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR014",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR015",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR016",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR017",SqlDbType.Decimal,10),
                    new SqlParameter("@WOR018",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR019",SqlDbType.Int),
                    new SqlParameter("@WOR020",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR021",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR022",SqlDbType.NVarChar,500),
                    new SqlParameter("@WOR023",SqlDbType.Date),
                    new SqlParameter("@WOR024",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR025",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR026",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR027",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR028",SqlDbType.Int),
                    new SqlParameter("@WOR029",SqlDbType.Int),
                    new SqlParameter("@WOR030",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR034",SqlDbType.Image),
                    new SqlParameter("@WOR035",SqlDbType.Image),
                    new SqlParameter("@WOR036",SqlDbType.Image),
                    new SqlParameter("@WOR037",SqlDbType.Image),
                    new SqlParameter("@WOR002",SqlDbType.Decimal,9)
                };
            parameter [ 0 ] . Value = _modelTwo . idx;
            parameter [ 1 ] . Value = _modelTwo . WOR005;
            parameter [ 2 ] . Value = _modelTwo . WOR006;
            parameter [ 3 ] . Value = _modelTwo . WOR007;
            parameter [ 4 ] . Value = _modelTwo . WOR008;
            parameter [ 5 ] . Value = _modelTwo . WOR009;
            parameter [ 6 ] . Value = _modelTwo . WOR010;
            parameter [ 7 ] . Value = _modelTwo . WOR011;
            parameter [ 8 ] . Value = _modelTwo . WOR012;
            parameter [ 9 ] . Value = _modelTwo . WOR013;
            parameter [ 10 ] . Value = _modelTwo . WOR014;
            parameter [ 11 ] . Value = _modelTwo . WOR015;
            parameter [ 12 ] . Value = _modelTwo . WOR016;
            parameter [ 13 ] . Value = _modelTwo . WOR017;
            parameter [ 14 ] . Value = _modelTwo . WOR018;
            parameter [ 15 ] . Value = _modelTwo . WOR019;
            parameter [ 16 ] . Value = _modelTwo . WOR020;
            parameter [ 17 ] . Value = _modelTwo . WOR021;
            parameter [ 18 ] . Value = _modelTwo . WOR022;
            parameter [ 19 ] . Value = _modelTwo . WOR023;
            parameter [ 20 ] . Value = _modelTwo . WOR024;
            parameter [ 21 ] . Value = _modelTwo . WOR025;
            parameter [ 22 ] . Value = _modelTwo . WOR026;
            parameter [ 23 ] . Value = _modelTwo . WOR027;
            parameter [ 24 ] . Value = _modelTwo . WOR028;
            parameter [ 25 ] . Value = _modelTwo . WOR029;
            parameter [ 26 ] . Value = _modelTwo . WOR030;
            parameter [ 27 ] . Value = _modelTwo . WOR034;
            parameter [ 28 ] . Value = _modelTwo . WOR035;
            parameter [ 29 ] . Value = _modelTwo . WOR036;
            parameter [ 30 ] . Value = _modelTwo . WOR037;
            parameter [ 31 ] . Value = _modelTwo . WOR002;
            SQLString . Add ( strSql ,parameter );
        }

        void DeleteWor ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . BomWorkPlanWOREntity _modelTwo )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXWOR WHERE idx={0}" ,_modelTwo . idx );
            SQLString . Add ( strSql ,null );
        }

        void InsertWOR (DataTable tableQuery ,StringBuilder strSql,CarpenterEntity . BomWorkPlanWOREntity _modelTwo ,SqlCommand cmd,SqlConnection conn,SqlTransaction tran)
        {
            if ( tableQuery == null || tableQuery . Rows . Count < 1 )
                return;

            for ( int i = 0 ; i < tableQuery . Rows . Count ; i++ )
            {
                _modelTwo . WOR002 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR002" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQuery . Rows [ i ] [ "WOR002" ] . ToString ( ) );
                _modelTwo . WOR005 = tableQuery . Rows [ i ] [ "WOR005" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR006 = tableQuery . Rows [ i ] [ "WOR006" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR007 = tableQuery . Rows [ i ] [ "WOR007" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR008 = tableQuery . Rows [ i ] [ "WOR008" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR009 = tableQuery . Rows [ i ] [ "WOR009" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR010 = tableQuery . Rows [ i ] [ "WOR010" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR011 = tableQuery . Rows [ i ] [ "WOR011" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR012 = tableQuery . Rows [ i ] [ "WOR012" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR013 = tableQuery . Rows [ i ] [ "WOR013" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR014 = tableQuery . Rows [ i ] [ "WOR014" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR015 = tableQuery . Rows [ i ] [ "WOR015" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR016 = tableQuery . Rows [ i ] [ "WOR016" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR017 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQuery . Rows [ i ] [ "WOR017" ] . ToString ( ) );
                _modelTwo . WOR018 = tableQuery . Rows [ i ] [ "WOR018" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR019 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR019" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR019" ] . ToString ( ) );
                _modelTwo . WOR020 = tableQuery . Rows [ i ] [ "WOR020" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR021 = tableQuery . Rows [ i ] [ "WOR021" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR022 = tableQuery . Rows [ i ] [ "WOR022" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR025 = tableQuery . Rows [ i ] [ "WOR025" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR026 = tableQuery . Rows [ i ] [ "WOR026" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR027 = tableQuery . Rows [ i ] [ "WOR027" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR028 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR028" ] . ToString ( ) );
                _modelTwo . WOR029 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR029" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR029" ] . ToString ( ) );
                _modelTwo . WOR030 = tableQuery . Rows [ i ] [ "WOR030" ] . ToString ( ) . Trim ( );
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR034" ] . ToString ( ) ) )
                    _modelTwo . WOR034 = new byte [ 0 ];
                else
                    _modelTwo . WOR034 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR034" ];
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR035" ] . ToString ( ) ) )
                    _modelTwo . WOR035 = new byte [ 0 ];
                else
                    _modelTwo . WOR035 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR035" ];
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR036" ] . ToString ( ) ) )
                    _modelTwo . WOR036 = new byte [ 0 ];
                else
                    _modelTwo . WOR036 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR036" ];
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR037" ] . ToString ( ) ) )
                    _modelTwo . WOR037 = new byte [ 0 ];
                else
                    _modelTwo . WOR037 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR037" ];
                strSql = new StringBuilder ( );
                strSql . Append ( "INSERT INTO MOXWOR (" );
                strSql . Append ( "WOR001,WOR005,WOR006,WOR007,WOR008,WOR009,WOR010,WOR011,WOR012,WOR013,WOR014,WOR015,WOR016,WOR017,WOR018,WOR019,WOR020,WOR021,WOR022,WOR023,WOR024,WOR025,WOR026,WOR027,WOR028,WOR029,WOR030,WOR034,WOR035,WOR036,WOR037,WOR002) " );
                strSql . Append ( "VALUES (" );
                strSql . Append ( "@WOR001,@WOR005,@WOR006,@WOR007,@WOR008,@WOR009,@WOR010,@WOR011,@WOR012,@WOR013,@WOR014,@WOR015,@WOR016,@WOR017,@WOR018,@WOR019,@WOR020,@WOR021,@WOR022,@WOR023,@WOR024,@WOR025,@WOR026,@WOR027,@WOR028,@WOR029,@WOR030,@WOR034,@WOR035,@WOR036,@WOR037,@WOR002)" );
                SqlParameter [ ] parameter = {
                    new SqlParameter("@WOR001",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR005",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR006",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR007",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR008",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR009",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR010",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR011",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR012",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR013",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR014",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR015",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR016",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR017",SqlDbType.Decimal,10),
                    new SqlParameter("@WOR018",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR019",SqlDbType.Int),
                    new SqlParameter("@WOR020",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR021",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR022",SqlDbType.NVarChar,500),
                    new SqlParameter("@WOR023",SqlDbType.Date),
                    new SqlParameter("@WOR024",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR025",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR026",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR027",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR028",SqlDbType.Int),
                    new SqlParameter("@WOR029",SqlDbType.Int),
                    new SqlParameter("@WOR030",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR034",SqlDbType.Image),
                    new SqlParameter("@WOR035",SqlDbType.Image),
                    new SqlParameter("@WOR036",SqlDbType.Image),
                    new SqlParameter("@WOR037",SqlDbType.Image),
                    new SqlParameter("@WOR002",SqlDbType.Decimal,9)
                };
                parameter [ 0 ] . Value = _modelTwo . WOR001;
                parameter [ 1 ] . Value = _modelTwo . WOR005;
                parameter [ 2 ] . Value = _modelTwo . WOR006;
                parameter [ 3 ] . Value = _modelTwo . WOR007;
                parameter [ 4 ] . Value = _modelTwo . WOR008;
                parameter [ 5 ] . Value = _modelTwo . WOR009;
                parameter [ 6 ] . Value = _modelTwo . WOR010;
                parameter [ 7 ] . Value = _modelTwo . WOR011;
                parameter [ 8 ] . Value = _modelTwo . WOR012;
                parameter [ 9 ] . Value = _modelTwo . WOR013;
                parameter [ 10 ] . Value = _modelTwo . WOR014;
                parameter [ 11 ] . Value = _modelTwo . WOR015;
                parameter [ 12 ] . Value = _modelTwo . WOR016;
                parameter [ 13 ] . Value = _modelTwo . WOR017;
                parameter [ 14 ] . Value = _modelTwo . WOR018;
                parameter [ 15 ] . Value = _modelTwo . WOR019;
                parameter [ 16 ] . Value = _modelTwo . WOR020;
                parameter [ 17 ] . Value = _modelTwo . WOR021;
                parameter [ 18 ] . Value = _modelTwo . WOR022;
                parameter [ 19 ] . Value = _modelTwo . WOR023;
                parameter [ 20 ] . Value = _modelTwo . WOR024;
                parameter [ 21 ] . Value = _modelTwo . WOR025;
                parameter [ 22 ] . Value = _modelTwo . WOR026;
                parameter [ 23 ] . Value = _modelTwo . WOR027;
                parameter [ 24 ] . Value = _modelTwo . WOR028;
                parameter [ 25 ] . Value = _modelTwo . WOR029;
                parameter [ 26 ] . Value = _modelTwo . WOR030;
                parameter [ 27 ] . Value = _modelTwo . WOR034;
                parameter [ 28 ] . Value = _modelTwo . WOR035;
                parameter [ 29 ] . Value = _modelTwo . WOR036;
                parameter [ 30 ] . Value = _modelTwo . WOR037;
                parameter [ 31 ] . Value = _modelTwo . WOR002;

                cmd . Parameters . Clear ( );
                SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,parameter );
                cmd . CommandText = strSql . ToString ( );
                cmd . ExecuteNonQuery ( );
                try
                {
                    LogHelperToSql . SaveLog ( strSql . ToString ( ) ,parameter );
                }
                catch ( Exception ex ) { Utility . LogHelper . WriteLog ( ex . Message + "\n\r" + ex . StackTrace ); }
            }
        }

        void EditWor ( DataTable dt ,DataTable tableQuery ,StringBuilder strSql ,CarpenterEntity . BomWorkPlanWOREntity _modelTwo ,SqlCommand cmd ,SqlConnection conn ,SqlTransaction tran )
        {
            if ( tableQuery == null || tableQuery . Rows . Count < 1 )
                return;

            for ( int i = 0 ; i < tableQuery . Rows . Count ; i++ )
            {
                _modelTwo . WOR002 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR002" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQuery . Rows [ i ] [ "WOR002" ] . ToString ( ) );
                _modelTwo . WOR005 = tableQuery . Rows [ i ] [ "WOR005" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR006 = tableQuery . Rows [ i ] [ "WOR006" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR007 = tableQuery . Rows [ i ] [ "WOR007" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR008 = tableQuery . Rows [ i ] [ "WOR008" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR009 = tableQuery . Rows [ i ] [ "WOR009" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR010 = tableQuery . Rows [ i ] [ "WOR010" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR011 = tableQuery . Rows [ i ] [ "WOR011" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR012 = tableQuery . Rows [ i ] [ "WOR012" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR013 = tableQuery . Rows [ i ] [ "WOR013" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR014 = tableQuery . Rows [ i ] [ "WOR014" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR015 = tableQuery . Rows [ i ] [ "WOR015" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR016 = tableQuery . Rows [ i ] [ "WOR016" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR017 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQuery . Rows [ i ] [ "WOR017" ] . ToString ( ) );
                _modelTwo . WOR018 = tableQuery . Rows [ i ] [ "WOR018" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR019 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR019" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR019" ] . ToString ( ) );
                _modelTwo . WOR020 = tableQuery . Rows [ i ] [ "WOR020" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR021 = tableQuery . Rows [ i ] [ "WOR021" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR022 = tableQuery . Rows [ i ] [ "WOR022" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR025 = tableQuery . Rows [ i ] [ "WOR025" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR026 = tableQuery . Rows [ i ] [ "WOR026" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR027 = tableQuery . Rows [ i ] [ "WOR027" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR028 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR028" ] . ToString ( ) );
                _modelTwo . WOR029 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR029" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR029" ] . ToString ( ) );
                _modelTwo . WOR030 = tableQuery . Rows [ i ] [ "WOR030" ] . ToString ( ) . Trim ( );

                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR034" ] . ToString ( ) ) )
                    _modelTwo . WOR034 = new byte [ 0 ];
                else
                    _modelTwo . WOR034 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR034" ];

                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR035" ] . ToString ( ) ) )
                    _modelTwo . WOR035 = new byte [ 0 ];
                else
                    _modelTwo . WOR035 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR035" ];

                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR036" ] . ToString ( ) ) )
                    _modelTwo . WOR036 = new byte [ 0 ];
                else
                    _modelTwo . WOR036 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR036" ];

                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR037" ] . ToString ( ) ) )
                    _modelTwo . WOR037 = new byte [ 0 ];
                else
                    _modelTwo . WOR037 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR037" ];

                strSql = new StringBuilder ( );
                if ( dt . Select ( " WOR006='" + _modelTwo . WOR006 + "' AND WOR007='" + _modelTwo . WOR007 + "' AND WOR010='" + _modelTwo . WOR010 + "' AND WOR013='" + _modelTwo . WOR013 + "'" ) . Length > 0 )
                {
                    _modelTwo . WOR005 = dt . Select ( " WOR006='" + _modelTwo . WOR006 + "' AND WOR007='" + _modelTwo . WOR007 + "' AND WOR010='" + _modelTwo . WOR010 + "' AND WOR013='" + _modelTwo . WOR013 + "'" ) [ 0 ] [ "WOR005" ] . ToString ( );

                    strSql . Append ( "UPDATE MOXWOR SET " );
                    strSql . Append ( "WOR006=@WOR006," );
                    strSql . Append ( "WOR007=@WOR007," );
                    strSql . Append ( "WOR008=@WOR008," );
                    strSql . Append ( "WOR009=@WOR009," );
                    strSql . Append ( "WOR010=@WOR010," );
                    strSql . Append ( "WOR011=@WOR011," );
                    strSql . Append ( "WOR012=@WOR012," );
                    strSql . Append ( "WOR013=@WOR013," );
                    strSql . Append ( "WOR014=@WOR014," );
                    strSql . Append ( "WOR015=@WOR015," );
                    strSql . Append ( "WOR016=@WOR016," );
                    strSql . Append ( "WOR017=@WOR017," );
                    strSql . Append ( "WOR018=@WOR018," );
                    strSql . Append ( "WOR019=@WOR019," );
                    strSql . Append ( "WOR020=@WOR020," );
                    strSql . Append ( "WOR021=@WOR021," );
                    strSql . Append ( "WOR022=@WOR022," );
                    strSql . Append ( "WOR023=@WOR023," );
                    strSql . Append ( "WOR024=@WOR024," );
                    strSql . Append ( "WOR025=@WOR025," );
                    strSql . Append ( "WOR026=@WOR026," );
                    strSql . Append ( "WOR027=@WOR027," );
                    strSql . Append ( "WOR028=@WOR028," );
                    strSql . Append ( "WOR029=@WOR029," );
                    strSql . Append ( "WOR030=@WOR030," );
                    strSql . Append ( "WOR034=@WOR034," );
                    strSql . Append ( "WOR035=@WOR035," );
                    strSql . Append ( "WOR036=@WOR036," );
                    strSql . Append ( "WOR037=@WOR037," );
                    strSql . Append ( "WOR002=@WOR002 " );
                    strSql . Append ( "WHERE WOR001=@WOR001 AND " );
                    strSql . Append ( "WOR005=@WOR005" );
                }
                else
                {
                    strSql . Append ( "INSERT INTO MOXWOR (" );
                    strSql . Append ( "WOR001,WOR005,WOR006,WOR007,WOR008,WOR009,WOR010,WOR011,WOR012,WOR013,WOR014,WOR015,WOR016,WOR017,WOR018,WOR019,WOR020,WOR021,WOR022,WOR023,WOR024,WOR025,WOR026,WOR027,WOR028,WOR029,WOR030,WOR034,WOR035,WOR036,WOR037,WOR002) " );
                    strSql . Append ( "VALUES (" );
                    strSql . Append ( "@WOR001,@WOR005,@WOR006,@WOR007,@WOR008,@WOR009,@WOR010,@WOR011,@WOR012,@WOR013,@WOR014,@WOR015,@WOR016,@WOR017,@WOR018,@WOR019,@WOR020,@WOR021,@WOR022,@WOR023,@WOR024,@WOR025,@WOR026,@WOR027,@WOR028,@WOR029,@WOR030,@WOR034,@WOR035,@WOR036,@WOR037,@WOR002)" );
                }

                SqlParameter [ ] parameter = {
                    new SqlParameter("@WOR001",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR005",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR006",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR007",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR008",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR009",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR010",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR011",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR012",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR013",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR014",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR015",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR016",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR017",SqlDbType.Decimal,10),
                    new SqlParameter("@WOR018",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR019",SqlDbType.Int),
                    new SqlParameter("@WOR020",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR021",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR022",SqlDbType.NVarChar,500),
                    new SqlParameter("@WOR023",SqlDbType.Date),
                    new SqlParameter("@WOR024",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR025",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR026",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR027",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR028",SqlDbType.Int),
                    new SqlParameter("@WOR029",SqlDbType.Int),
                    new SqlParameter("@WOR030",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR034",SqlDbType.Image),
                    new SqlParameter("@WOR035",SqlDbType.Image),
                    new SqlParameter("@WOR036",SqlDbType.Image),
                    new SqlParameter("@WOR037",SqlDbType.Image),
                    new SqlParameter("@WOR002",SqlDbType.Decimal,9)
                };
                parameter [ 0 ] . Value = _modelTwo . WOR001;
                parameter [ 1 ] . Value = _modelTwo . WOR005;
                parameter [ 2 ] . Value = _modelTwo . WOR006;
                parameter [ 3 ] . Value = _modelTwo . WOR007;
                parameter [ 4 ] . Value = _modelTwo . WOR008;
                parameter [ 5 ] . Value = _modelTwo . WOR009;
                parameter [ 6 ] . Value = _modelTwo . WOR010;
                parameter [ 7 ] . Value = _modelTwo . WOR011;
                parameter [ 8 ] . Value = _modelTwo . WOR012;
                parameter [ 9 ] . Value = _modelTwo . WOR013;
                parameter [ 10 ] . Value = _modelTwo . WOR014;
                parameter [ 11 ] . Value = _modelTwo . WOR015;
                parameter [ 12 ] . Value = _modelTwo . WOR016;
                parameter [ 13 ] . Value = _modelTwo . WOR017;
                parameter [ 14 ] . Value = _modelTwo . WOR018;
                parameter [ 15 ] . Value = _modelTwo . WOR019;
                parameter [ 16 ] . Value = _modelTwo . WOR020;
                parameter [ 17 ] . Value = _modelTwo . WOR021;
                parameter [ 18 ] . Value = _modelTwo . WOR022;
                parameter [ 19 ] . Value = _modelTwo . WOR023;
                parameter [ 20 ] . Value = _modelTwo . WOR024;
                parameter [ 21 ] . Value = _modelTwo . WOR025;
                parameter [ 22 ] . Value = _modelTwo . WOR026;
                parameter [ 23 ] . Value = _modelTwo . WOR027;
                parameter [ 24 ] . Value = _modelTwo . WOR028;
                parameter [ 25 ] . Value = _modelTwo . WOR029;
                parameter [ 26 ] . Value = _modelTwo . WOR030;
                parameter [ 27 ] . Value = _modelTwo . WOR034;
                parameter [ 28 ] . Value = _modelTwo . WOR035;
                parameter [ 29 ] . Value = _modelTwo . WOR036;
                parameter [ 30 ] . Value = _modelTwo . WOR037;
                parameter [ 31 ] . Value = _modelTwo . WOR002;

                cmd . Parameters . Clear ( );
                SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,parameter );
                cmd . CommandText = strSql . ToString ( );
                cmd . ExecuteNonQuery ( );
                try
                {
                    LogHelperToSql . SaveLog ( strSql . ToString ( ) ,parameter );
                }
                catch ( Exception ex ) { Utility . LogHelper . WriteLog ( ex . Message + "\n\r" + ex . StackTrace ); }
            }
        }

        void EditWor ( DataTable dt ,DataTable tableQuery ,StringBuilder strSql ,CarpenterEntity . BomWorkPlanWOREntity _modelTwo ,SqlCommand cmd ,SqlConnection conn ,SqlTransaction tran ,DataTable tableQueryOne )
        {
            for ( int i = 0 ; i < tableQuery . Rows . Count ; i++ )
            {
                _modelTwo . WOR002 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR002" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQuery . Rows [ i ] [ "WOR002" ] . ToString ( ) );
                _modelTwo . WOR005 = tableQuery . Rows [ i ] [ "WOR005" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR006 = tableQuery . Rows [ i ] [ "WOR006" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR007 = tableQuery . Rows [ i ] [ "WOR007" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR008 = tableQuery . Rows [ i ] [ "WOR008" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR009 = tableQuery . Rows [ i ] [ "WOR009" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR010 = tableQuery . Rows [ i ] [ "WOR010" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR011 = tableQuery . Rows [ i ] [ "WOR011" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR012 = tableQuery . Rows [ i ] [ "WOR012" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR013 = tableQuery . Rows [ i ] [ "WOR013" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR014 = tableQuery . Rows [ i ] [ "WOR014" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR015 = tableQuery . Rows [ i ] [ "WOR015" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR016 = tableQuery . Rows [ i ] [ "WOR016" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR017 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR017" ] . ToString ( ) ) == true ? 0 :  Convert . ToDecimal ( tableQuery . Rows [ i ] [ "WOR017" ] . ToString ( )  );
                _modelTwo . WOR018 = tableQuery . Rows [ i ] [ "WOR018" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR019 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR019" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR019" ] . ToString ( ) );
                _modelTwo . WOR020 = tableQuery . Rows [ i ] [ "WOR020" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR021 = tableQuery . Rows [ i ] [ "WOR021" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR022 = tableQuery . Rows [ i ] [ "WOR022" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR025 = tableQuery . Rows [ i ] [ "WOR025" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR026 = tableQuery . Rows [ i ] [ "WOR026" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR027 = tableQuery . Rows [ i ] [ "WOR027" ] . ToString ( ) . Trim ( );
                _modelTwo . WOR028 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR028" ] . ToString ( ) );
                _modelTwo . WOR029 = string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR029" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ i ] [ "WOR029" ] . ToString ( ) );
                _modelTwo . WOR030 = tableQuery . Rows [ i ] [ "WOR030" ] . ToString ( ) . Trim ( );
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR034" ] . ToString ( ) ) )
                    _modelTwo . WOR034 = new byte [ 0 ];
                else
                    _modelTwo . WOR034 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR034" ];
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR035" ] . ToString ( ) ) )
                    _modelTwo . WOR035 = new byte [ 0 ];
                else
                    _modelTwo . WOR035 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR035" ];
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR036" ] . ToString ( ) ) )
                    _modelTwo . WOR036 = new byte [ 0 ];
                else
                    _modelTwo . WOR036 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR036" ];
                if ( string . IsNullOrEmpty ( tableQuery . Rows [ i ] [ "WOR037" ] . ToString ( ) ) )
                    _modelTwo . WOR037 = new byte [ 0 ];
                else
                    _modelTwo . WOR037 = ( byte [ ] ) tableQuery . Rows [ i ] [ "WOR037" ];

                strSql = new StringBuilder ( );

                if ( dt . Select ( " WOR005='" + _modelTwo . WOR005 + "'" ) . Length > 0 )
                {
                    strSql . Append ( "UPDATE MOXWOR SET " );
                    strSql . Append ( "WOR006=@WOR006," );
                    strSql . Append ( "WOR007=@WOR007," );
                    strSql . Append ( "WOR008=@WOR008," );
                    strSql . Append ( "WOR009=@WOR009," );
                    strSql . Append ( "WOR010=@WOR010," );
                    strSql . Append ( "WOR011=@WOR011," );
                    strSql . Append ( "WOR012=@WOR012," );
                    strSql . Append ( "WOR013=@WOR013," );
                    strSql . Append ( "WOR014=@WOR014," );
                    strSql . Append ( "WOR015=@WOR015," );
                    strSql . Append ( "WOR016=@WOR016," );
                    strSql . Append ( "WOR017=@WOR017," );
                    strSql . Append ( "WOR018=@WOR018," );
                    strSql . Append ( "WOR019=@WOR019," );
                    strSql . Append ( "WOR020=@WOR020," );
                    strSql . Append ( "WOR021=@WOR021," );
                    strSql . Append ( "WOR022=@WOR022," );
                    strSql . Append ( "WOR023=@WOR023," );
                    strSql . Append ( "WOR024=@WOR024," );
                    strSql . Append ( "WOR025=@WOR025," );
                    strSql . Append ( "WOR026=@WOR026," );
                    strSql . Append ( "WOR027=@WOR027," );
                    strSql . Append ( "WOR028=@WOR028," );
                    strSql . Append ( "WOR029=@WOR029," );
                    strSql . Append ( "WOR030=@WOR030," );
                    strSql . Append ( "WOR034=@WOR034," );
                    strSql . Append ( "WOR035=@WOR035," );
                    strSql . Append ( "WOR036=@WOR036," );
                    strSql . Append ( "WOR037=@WOR037," );
                    strSql . Append ( "WOR002=@WOR002 " );
                    strSql . Append ( "WHERE WOR001=@WOR001 AND " );
                    strSql . Append ( "WOR005=@WOR005" );
                }
                else
                {
                    strSql . Append ( "INSERT INTO MOXWOR (" );
                    strSql . Append ( "WOR001,WOR005,WOR006,WOR007,WOR008,WOR009,WOR010,WOR011,WOR012,WOR013,WOR014,WOR015,WOR016,WOR017,WOR018,WOR019,WOR020,WOR021,WOR022,WOR023,WOR024,WOR025,WOR026,WOR027,WOR028,WOR029,WOR030,WOR034,WOR035,WOR036,WOR037,WOR002) " );
                    strSql . Append ( "VALUES (" );
                    strSql . Append ( "@WOR001,@WOR005,@WOR006,@WOR007,@WOR008,@WOR009,@WOR010,@WOR011,@WOR012,@WOR013,@WOR014,@WOR015,@WOR016,@WOR017,@WOR018,@WOR019,@WOR020,@WOR021,@WOR022,@WOR023,@WOR024,@WOR025,@WOR026,@WOR027,@WOR028,@WOR029,@WOR030,@WOR034,@WOR035,@WOR036,@WOR037,@WOR002)" );
                }

                SqlParameter [ ] parameter = {
                    new SqlParameter("@WOR001",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR005",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR006",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR007",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR008",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR009",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR010",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR011",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR012",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR013",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR014",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR015",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR016",SqlDbType.NVarChar,10),
                    new SqlParameter("@WOR017",SqlDbType.Decimal,10),
                    new SqlParameter("@WOR018",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR019",SqlDbType.Int),
                    new SqlParameter("@WOR020",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR021",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR022",SqlDbType.NVarChar,500),
                    new SqlParameter("@WOR023",SqlDbType.Date),
                    new SqlParameter("@WOR024",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR025",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR026",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR027",SqlDbType.NVarChar,50),
                    new SqlParameter("@WOR028",SqlDbType.Int),
                    new SqlParameter("@WOR029",SqlDbType.Int),
                    new SqlParameter("@WOR030",SqlDbType.NVarChar,20),
                    new SqlParameter("@WOR034",SqlDbType.Image),
                    new SqlParameter("@WOR035",SqlDbType.Image),
                    new SqlParameter("@WOR036",SqlDbType.Image),
                    new SqlParameter("@WOR037",SqlDbType.Image),
                    new SqlParameter("@WOR002",SqlDbType.Decimal,9)
                };
                parameter [ 0 ] . Value = _modelTwo . WOR001;
                parameter [ 1 ] . Value = _modelTwo . WOR005;
                parameter [ 2 ] . Value = _modelTwo . WOR006;
                parameter [ 3 ] . Value = _modelTwo . WOR007;
                parameter [ 4 ] . Value = _modelTwo . WOR008;
                parameter [ 5 ] . Value = _modelTwo . WOR009;
                parameter [ 6 ] . Value = _modelTwo . WOR010;
                parameter [ 7 ] . Value = _modelTwo . WOR011;
                parameter [ 8 ] . Value = _modelTwo . WOR012;
                parameter [ 9 ] . Value = _modelTwo . WOR013;
                parameter [ 10 ] . Value = _modelTwo . WOR014;
                parameter [ 11 ] . Value = _modelTwo . WOR015;
                parameter [ 12 ] . Value = _modelTwo . WOR016;
                parameter [ 13 ] . Value = _modelTwo . WOR017;
                parameter [ 14 ] . Value = _modelTwo . WOR018;
                parameter [ 15 ] . Value = _modelTwo . WOR019;
                parameter [ 16 ] . Value = _modelTwo . WOR020;
                parameter [ 17 ] . Value = _modelTwo . WOR021;
                parameter [ 18 ] . Value = _modelTwo . WOR022;
                parameter [ 19 ] . Value = _modelTwo . WOR023;
                parameter [ 20 ] . Value = _modelTwo . WOR024;
                parameter [ 21 ] . Value = _modelTwo . WOR025;
                parameter [ 22 ] . Value = _modelTwo . WOR026;
                parameter [ 23 ] . Value = _modelTwo . WOR027;
                parameter [ 24 ] . Value = _modelTwo . WOR028;
                parameter [ 25 ] . Value = _modelTwo . WOR029;
                parameter [ 26 ] . Value = _modelTwo . WOR030;
                parameter [ 27 ] . Value = _modelTwo . WOR034;
                parameter [ 28 ] . Value = _modelTwo . WOR035;
                parameter [ 29 ] . Value = _modelTwo . WOR036;
                parameter [ 30 ] . Value = _modelTwo . WOR037;
                parameter [ 31 ] . Value = _modelTwo . WOR002;

                cmd . Parameters . Clear ( );
                SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,parameter );
                cmd . CommandText = strSql . ToString ( );
                cmd . ExecuteNonQuery ( );
                try
                {
                    LogHelperToSql . SaveLog ( strSql . ToString ( ) ,parameter );
                }
                catch ( Exception ex ) { Utility . LogHelper . WriteLog ( ex . Message + "\n\r" + ex . StackTrace ); }
            }


            if ( tableQueryOne != null && tableQueryOne . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < tableQueryOne . Rows . Count ; i++ )
                {
                    _modelTwo . WOR005 = tableQueryOne . Rows [ i ] [ "WOR005" ] . ToString ( );

                    if ( tableQuery . Select ( "WOR005='" + _modelTwo . WOR005 + "'" ) . Length > 0 )
                    {
                        tableQueryOne . Rows . RemoveAt ( i );
                    }
                }
            }

            if ( tableQueryOne != null && tableQueryOne . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < tableQueryOne . Rows . Count ; i++ )
                {
                    _modelTwo . WOR005 = tableQueryOne . Rows [ i ] [ "WOR005" ] . ToString ( );
                    if ( dt . Select ( "WOR005='" + _modelTwo . WOR005 + "'" ) . Length > 0 )
                    {
                        strSql = new StringBuilder ( );
                        strSql . Append ( "DELETE FROM MOXWOR " );
                        strSql . Append ( "WHERE WOR001=@WOR001 AND WOR005=@WOR005" );
                        SqlParameter [ ] paramete = {
                                new SqlParameter("@WOR001",SqlDbType.NVarChar,20),
                                new SqlParameter("@WOR005",SqlDbType.NVarChar,20)
                            };
                        paramete [ 0 ] . Value = _modelTwo . WOR001;
                        paramete [ 1 ] . Value = _modelTwo . WOR005;

                        cmd . Parameters . Clear ( );
                        SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,paramete );
                        cmd . CommandText = strSql . ToString ( );
                        cmd . ExecuteNonQuery ( );
                        try
                        {
                            LogHelperToSql . SaveLog ( strSql . ToString ( ) ,paramete );
                        }
                        catch ( Exception ex ) { Utility . LogHelper . WriteLog ( ex . Message + "\n\r" + ex . StackTrace ); }
                    }
                }
            }
        }


        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT WOQ001 OPI001,WOQ008 OPI002,WOQ009 OPI005,OPI010 FROM MOXWOQ A LEFT JOIN MOXOPI B ON A.WOQ001=B.OPI001 " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取产品其它信息
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableProduct ( string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT OPI006,OPI007,OPI003,OPI012 FROM MOXOPI " );
            strSql . Append ( "WHERE OPI001=@OPI001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@OPI001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = productNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOPI ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT OPI001,OPI002,OPI003,OPI005,OPI006,OPI007 FROM MOXOPI WHERE OPI001 NOT IN (SELECT WOQ001 FROM MOXWOQ) AND OPI011=0 ORDER BY OPI001 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取批号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWeek ( string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT CUT001 FROM MOXCUT  A INNER JOIN MOXCUU B ON A.CUT001=B.CUU001 WHERE CUT008=1 AND CUU002='{0}'" ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="idxList"></param>
        /// <param name="weekEnds"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint (List<int> idxList ,string weekEnds,string productNum)
        {
            bool result = true;
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            string idxStr = string . Empty;

            foreach ( int idx in idxList )
            {
                if ( idxStr == string . Empty )
                    idxStr = idx . ToString ( );
                else
                    idxStr += "," + idx . ToString ( );
            }
            List<string> strList = new List<string> ( );
            DataTable dt = GetInformation ( idxStr ,weekEnds );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                CarpenterEntity . BomWorkPlanCodeEntity _model = new CarpenterEntity . BomWorkPlanCodeEntity ( );
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _model . WPC001 = weekEnds;
                    _model . WPC002 = dt . Rows [ i ] [ "WOQ001" ] . ToString ( );
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

                    if ( string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR034" ] . ToString ( ) ) || dt . Rows [ i ] [ "WOR034" ] . ToString ( ) . Contains ( "System.Byte[]" ) )
                        _model . WPC030 = new byte [ 0 ];
                    else
                        _model . WPC030 = ( byte [ ] ) dt . Rows [ i ] [ "WOR034" ];
                    if ( string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR035" ] . ToString ( ) ) || dt . Rows [ i ] [ "WOR035" ] . ToString ( ) . Contains ( "System.Byte[]" ) )
                        _model . WPC031 = new byte [ 0 ];
                    else
                        _model . WPC031 = ( byte [ ] ) dt . Rows [ i ] [ "WOR035" ];
                    if ( string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR036" ] . ToString ( ) ) || dt . Rows [ i ] [ "WOR036" ] . ToString ( ) . Contains ( "System.Byte[]" ) )
                        _model . WPC032 = new byte [ 0 ];
                    else
                        _model . WPC032 = ( byte [ ] ) dt . Rows [ i ] [ "WOR036" ];
                    if ( string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR037" ] . ToString ( ) ) || dt . Rows [ i ] [ "WOR037" ] . ToString ( ) . Contains ( "System.Byte[]" ) )
                        _model . WPC033 = new byte [ 0 ];
                    else
                        _model . WPC033 = ( byte [ ] ) dt . Rows [ i ] [ "WOR037" ];
                    _model . WPC035 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "WOR002" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "WOR002" ] . ToString ( ) );

                    if ( Exists ( _model . WPC001 ,_model . WPC002 ,_model . WPC004 ,_model . WPC006 ,_model . WPC009 ,_model . WPC012 ) == false )
                    {
                        _model . WPC005 = getOddNum ( );
                        if ( strList . Contains ( _model . WPC005 ) )
                        {
                            _model . WPC005 = strList . Max ( );
                            _model . WPC005 = ( Convert . ToInt64 ( _model . WPC005 ) + 1 ) . ToString ( );
                            strList . Add ( _model . WPC005 );
                        }
                        else
                            strList . Add ( _model . WPC005 );

                        add_code ( SQLString ,strSql ,_model );
                    }
                    else
                        edit_code ( SQLString ,strSql ,_model );
                }
                result = SqlHelper . ExecuteSqlTran ( SQLString );
            }
            else
                result = false;

            if ( result == false )
                return null;
            else
                return printOne ( weekEnds ,idxStr ,productNum );
        }

        /// <summary>
        /// 获取需要打印的品号和零件信息
        /// </summary>
        /// <param name="idxStr"></param>
        /// <returns></returns>
        DataTable GetInformation ( string idxStr ,string weekEnds)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.WOQ001,B.WOR002,B.WOR005,B.WOR006,WOR007,WOR008,WOR009,WOR010,WOR011,WOR012,WOR013,WOR014,WOR015,WOR016,WOR017,WOR018,WOR019,WOR020,WOR021,WOR022,WOR023,WOR024,WOR025,WOR026,WOR027,WOR028,WOR029,WOR030,WOR034,WOR035,WOR036,WOR037 FROM MOXWOQ A INNER JOIN MOXWOR B ON A.WOQ001=B.WOR001 INNER JOIN MOXCUU C ON A.WOQ001=C.CUU002 " );
            strSql . AppendFormat ( "WHERE B.idx IN (" + idxStr + ") AND CUU001='{0}'" ,weekEnds );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在批号  品号  零件名称的条码
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="partName"></param>
        /// <returns></returns>
        bool Exists (string weekEnds,string productNum,string partName ,string len,string width,string heigth )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXWPC " );
            strSql . AppendFormat ( "WHERE WPC001='{0}' AND WPC002='{1}' AND WPC004='{2}' AND WPC006='{3}' AND WPC009='{4}' AND WPC012='{5}'" ,weekEnds ,productNum ,partName ,len ,width ,heigth );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取条码
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="partName"></param>
        /// <returns></returns>
        string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(WPC005) WPC005 FROM MOXWPC " );
            //strSql . AppendFormat ( "WHERE WPC001='{0}' AND WPC002='{1}' AND WPC005 LIKE '{2}%' AND WPC010='{3}'" ,weekEnds ,productNum ,UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) ,spe );// AND WPC003='{2}'

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
                return  UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

        /// <summary>
        /// 插入条码
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="_model"></param>
        void add_code ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . BomWorkPlanCodeEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXWPC (" );
            strSql . Append ( "WPC001,WPC002,WPC003,WPC004,WPC005,WPC006,WPC007,WPC008,WPC009,WPC010,WPC011,WPC012,WPC013,WPC014,WPC015,WPC016,WPC017,WPC018,WPC019,WPC020,WPC021,WPC022,WPC023,WPC024,WPC025,WPC026,WPC027,WPC028,WPC029,WPC030,WPC031,WPC032,WPC033,WPC035) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@WPC001,@WPC002,@WPC003,@WPC004,@WPC005,@WPC006,@WPC007,@WPC008,@WPC009,@WPC010,@WPC011,@WPC012,@WPC013,@WPC014,@WPC015,@WPC016,@WPC017,@WPC018,@WPC019,@WPC020,@WPC021,@WPC022,@WPC023,@WPC024,@WPC025,@WPC026,@WPC027,@WPC028,@WPC029,@WPC030,@WPC031,@WPC032,@WPC033,@WPC035) " );
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
                new SqlParameter("@WPC030",SqlDbType.Image),
                new SqlParameter("@WPC031",SqlDbType.Image),
                new SqlParameter("@WPC032",SqlDbType.Image),
                new SqlParameter("@WPC033",SqlDbType.Image),
                new SqlParameter("@WPC035",SqlDbType.Decimal,11)
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
            parameter [ 29 ] . Value = _model . WPC030;
            parameter [ 30 ] . Value = _model . WPC031;
            parameter [ 31 ] . Value = _model . WPC032;
            parameter [ 32 ] . Value = _model . WPC033;
            parameter [ 33 ] . Value = _model . WPC035;
            SQLString . Add ( strSql ,parameter );
        }

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
            strSql . Append ( "WPC030=@WPC030," );
            strSql . Append ( "WPC031=@WPC031," );
            strSql . Append ( "WPC032=@WPC032," );
            strSql . Append ( "WPC033=@WPC033," );
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
                new SqlParameter("@WPC030",SqlDbType.Image),
                new SqlParameter("@WPC031",SqlDbType.Image),
                new SqlParameter("@WPC032",SqlDbType.Image),
                new SqlParameter("@WPC033",SqlDbType.Image),
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
            parameter [ 28 ] . Value = _model . WPC030;
            parameter [ 29 ] . Value = _model . WPC031;
            parameter [ 30 ] . Value = _model . WPC032;
            parameter [ 31 ] . Value = _model . WPC033;
            parameter [ 32 ] . Value = _model . WPC035;
        
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 获取打印传票的数据列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="idxStr"></param>
        /// <returns></returns>
        public DataTable printOne ( string weekEnds ,string idxStr,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS(SELECT COUNT(WOR016) WOR,WOR016 FROM MOXWOR WHERE WOR001='{0}' GROUP BY WOR016" ,productNum );
            strSql . Append ( "),CIT AS( " );
            strSql . AppendFormat ( "SELECT WOR001,WOR005,dbo.USF_ExtractNumeric(WOR010) WOR010 FROM MOXWOR WHERE WOR010 LIKE '%/%' AND WOR001='{0}' " ,productNum );
            strSql . Append ( "),CGT AS( " );
            strSql . Append ( "SELECT WOR001,WOR005,CASE WHEN WOR010 LIKE '%/%' THEN dbo.Fun_GetStrArrayStrOfIndex(WOR010,'/',0) ELSE WOR010 END WOR010 FROM CIT " );
            strSql . Append ( "),CHT AS (" );
            strSql . Append ( "SELECT WOR001,WOR005,CASE WHEN WOR010 LIKE '%/%' THEN dbo.Fun_GetStrArrayStrOfIndex(WOR010,'/',2) ELSE WOR010 END WOR010 FROM CIT " );
            strSql . Append ( "),CJT AS(" );
            strSql . Append ( "SELECT A.WOR005,(CONVERT(DECIMAL(11,2),A.WOR010)+CONVERT(DECIMAL(11,2),B.WOR010))/2 WOR010 FROM CGT A INNER JOIN CHT B ON A.WOR001=B.WOR001 AND A.WOR005=B.WOR005)" );
            strSql . Append ( ",CFT AS (" );
            strSql . Append ( "SELECT WOR016+'作业传票' WOR,WOR030,WOR016,A.WOQ008,CUU003,WOR006,CONVERT(FLOAT,WOR017*CUU003) WOR017,WOR018,WOR027,WOR025,WOR026,'拼'+CONVERT(VARCHAR,WOR028)+'宽画'+CONVERT(VARCHAR,WOR029)+'根' WOR028,CONVERT(DECIMAL(11,0),CASE WHEN WOR029=0 THEN 0 ELSE WOR017*CUU003/WOR029 END) WOR029 ,WOR034,WOR035,WOR036,WOR037,WOR022,WPC005,CUU001,CASE WHEN WOR007!='' THEN WOR007 ELSE WOR008 END WOR008,CASE WHEN B.WOR010!='' THEN B.WOR010 ELSE WOR011 END WOR010,CASE WHEN WOR013!='' THEN WOR013 ELSE WOR014 END WOR013,CONVERT(DECIMAL(11,2),CASE WHEN dbo.USF_ExtractNumeric(B.WOR010)='' THEN 0 WHEN B.WOR010 LIKE '%/%' THEN WOR017*CONVERT(DECIMAL(11,2),E.WOR010)*WOR002/1000 ELSE WOR017*CONVERT(DECIMAL(11,2),dbo.USF_ExtractNumeric(B.WOR010))*WOR002/1000 END) WOR0101 FROM MOXWOQ A INNER JOIN MOXWOR B ON A.WOQ001=B.WOR001 LEFT JOIN MOXCUU C ON A.WOQ001=C.CUU002 LEFT JOIN MOXWPC D ON B.WOR001=D.WPC002 AND B.WOR006=D.WPC004 AND B.WOR007=D.WPC006 AND B.WOR010=D.WPC009 AND B.WOR013=D.WPC012 AND D.WPC001=C.CUU001 LEFT JOIN CJT E ON B.WOR005=E.WOR005 " );
            strSql . AppendFormat ( "WHERE CUU001='{0}' AND WOR016!='' AND B.idx IN ({1})" ,weekEnds ,idxStr );
            strSql . Append ( ") " );
            strSql . Append ( "SELECT distinct B.*,'NO.'+CONVERT(VARCHAR,A.WOR)+'_'+CONVERT(VARCHAR,WOR030)+'('+A.WOR016+')' WORNUM FROM CET A INNER JOIN CFT B ON A.WOR016=B.WOR016" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取清单列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string weekEnds,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT row,WOQ008,WOQ009,CUU003,CUU001 FROM MOXWOQ A LEFT JOIN (SELECT ROW_NUMBER() OVER(ORDER BY CUU002) row,CUU002,CUU001,CUU003 FROM MOXCUU WHERE CUU001='{0}') B ON A.WOQ001=B.CUU002 WHERE CUU001='{0}' AND WOQ001='{1}'" ,weekEnds ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取清单列表
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "WITH CET AS( SELECT COUNT(WOR016) WOR,WOR016 FROM MOXWOR WHERE WOR001='{0}' GROUP BY WOR016" ,productNum );
            //strSql . Append ( "),CFT AS (" );
            strSql . AppendFormat ( "SELECT WOR006,WOR007+'*'+WOR010+'*'+WOR013 WOR,CONVERT(FLOAT,WOR017) WOR017,WOR018,WOR019,WOR020,WOR021,REPLACE(REPLACE(WOR022,char(13),''),CHAR(10),'') WOR022,WOR016,WOR030 FROM MOXWOR WHERE WOR001='{0}'" ,productNum );
            //strSql . Append ( ")  SELECT B.*,'NO.'+CONVERT(VARCHAR,A.WOR)+'_'+CONVERT(VARCHAR,WOR030) WORNUM FROM CET A INNER JOIN CFT B ON A.WOR016=B.WOR016" );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="weekEnd"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public bool Exists_WeekProduct ( string weekEnd,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXWOQ A INNER JOIN MOXCUU B ON A.WOQ001=B.CUU002 WHERE CUU001='{0}' AND CUU002='{1}' " ,weekEnd ,productNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印传票的数据列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="idxStr"></param>
        /// <returns></returns>
        public DataTable printOne ( List<string> idxList )
        {
            string proStr = string . Empty;
            var a = from o in idxList select o;
            proStr = string . Join ( "," ,a . ToArray ( ) );
            
            //部分打印不出来是应为没有作业类型

            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS(SELECT COUNT(WPC015) WOR,WPC015 FROM MOXWPC WHERE idx IN ({0}) AND WPC015!='' GROUP BY WPC015 " ,proStr );
            strSql . AppendFormat ( "),CIT AS( SELECT WPC002,WPC003,dbo.USF_ExtractNumeric(WPC009) WPC009 FROM MOXWPC WHERE WPC009 LIKE '%/%' AND idx IN ({0}) " ,proStr );
            strSql . Append ( "),CGT AS(SELECT WPC002,WPC003,CASE WHEN WPC009 LIKE '%/%' THEN dbo.Fun_GetStrArrayStrOfIndex(WPC009,'/',0) ELSE WPC009 END WPC009 FROM CIT  " );
            strSql . Append ( "),CHT AS (SELECT WPC002,WPC003,CASE WHEN WPC009 LIKE '%/%' THEN dbo.Fun_GetStrArrayStrOfIndex(WPC009,'/',2) ELSE WPC009 END WPC009 FROM CIT" );
            strSql . Append ( "),CJT AS(SELECT A.WPC003,A.WPC002,(CONVERT(DECIMAL(11,2),A.WPC009)+CONVERT(DECIMAL(11,2),B.WPC009))/2 WPC009 FROM CGT A INNER JOIN CHT B ON A.WPC002=B.WPC002 AND A.WPC003=B.WPC003" );
            strSql . AppendFormat ( "),CFT AS (SELECT OPI003+WPC015+'作业传票' WOR,WPC029 WOR030,WPC015 WOR016,CASE WHEN CUU008='' OR CUU008 IS NULL THEN WPC036 ELSE CUU008 END WOQ008,CUU003,WPC004 WOR006,CONVERT(FLOAT,WPC016*CUU003) WOR017,WPC017 WOR018,WPC026 WOR027,WPC024 WOR025,WPC025 WOR026,'拼'+CONVERT(VARCHAR,WPC027)+'宽画'+CONVERT(VARCHAR,WPC028)+'根' WOR028,CONVERT(DECIMAL(11,0),CASE	WHEN WPC028=0 THEN 0 ELSE WPC016*CUU003/WPC028 END) WOR029 ,WPC030 WOR034,WPC031 WOR035,WPC032 WOR036,WPC033 WOR037,WPC021 WOR022,WPC005,CASE WHEN CUU001='' OR CUU001 IS NULL THEN WPC001 ELSE CUU001 END CUU001,CASE WHEN WPC006!='' THEN WPC006 ELSE WPC007 END WOR008,CASE WHEN B.WPC009!='' THEN B.WPC009 ELSE WPC010 END WOR010,CASE WHEN WPC012!='' THEN WPC012 ELSE WPC013 END WOR013,CONVERT(DECIMAL(11,2),CASE WHEN dbo.USF_ExtractNumeric(B.WPC009)='' THEN 0 WHEN B.WPC009 LIKE '%/%' THEN WPC016*CONVERT(DECIMAL(11,2),E.WPC009)*WPC035/1000 ELSE WPC016*CONVERT(DECIMAL(11,2),dbo.USF_ExtractNumeric(B.WPC009))*WPC035/1000 END) WOR0101 FROM MOXWPC B LEFT JOIN MOXCUU C ON B.WPC002=C.CUU002 AND B.WPC001 = C.CUU001 LEFT JOIN CJT E ON B.WPC003 = E.WPC003 AND B.WPC002 = E.WPC002 INNER JOIN MOXOPI F ON B.WPC002=F.OPI001 WHERE WPC015!= '' AND B.idx IN ({0})" ,proStr );
            strSql . Append ( ") SELECT B.*,'NO.'+CONVERT(VARCHAR,A.WOR)+'_'+CONVERT(VARCHAR,WOR030)+'('+A.WPC015+')' WORNUM FROM CET A INNER JOIN CFT B ON A.WPC015=B.WOR016 ORDER BY WOQ008,WOR,CONVERT(INT,WOR030)" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
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
            
            SqlHelper . StoreProcedure ( "PRINTPRODUCTCP" );
            SqlParameter [ ] parameter = {
                new SqlParameter("PRODUCTNUM",proStr ),
                new SqlParameter("PNUM",weekEnds)
                };

            return SqlHelper . ExecuteNoStoreTable ( parameter );
        }

        /// <summary>
        /// 是否存在品号
        /// </summary>
        /// <param name="pinNum"></param>
        /// <returns></returns>
        public bool Exists ( string pinNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXWOQ WHERE WOQ001='{0}'" ,pinNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

    }
}
