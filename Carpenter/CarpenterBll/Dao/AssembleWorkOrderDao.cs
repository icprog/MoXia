using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class AssembleWorkOrderDao
    {

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable tableViewTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,AWQ001,AWQ002,AWQ003,AWQ004,AWQ005,AWQ006,AWQ007,AWQ008,AWQ009,AWQ010,OPI006 FROM MOXAWQ A INNER JOIN MOXOPI B ON A.AWQ003=B.OPI001 " );
            strSql . AppendFormat ( "WHERE AWQ001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public CarpenterEntity . AssembleWorkOrderAWOEntity GetList ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AWO001,AWO002,AWO003,AWO004,AWO005,AWO006 FROM MOXAWO " );
            strSql . AppendFormat ( "WHERE AWO001='{0}'" ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                return GetModel ( dt . Rows [ 0 ] );
            }
            else
                return null;
        }

        public CarpenterEntity . AssembleWorkOrderAWOEntity GetModel ( DataRow row )
        {
            CarpenterEntity . AssembleWorkOrderAWOEntity _model = new CarpenterEntity . AssembleWorkOrderAWOEntity ( );

            if ( row != null )
            {
                if ( row [ "AWO001" ] != null )
                    _model . AWO001 = row [ "AWO001" ] . ToString ( );
                if ( row [ "AWO002" ] != null )
                    _model . AWO002 = DateTime . Parse ( row [ "AWO002" ] . ToString ( ) );
                if ( row [ "AWO003" ] != null )
                    _model . AWO003 = row [ "AWO003" ] . ToString ( );
                if ( row [ "AWO004" ] != null && row [ "AWO004" ] . ToString ( ) != "" )
                    _model . AWO004 = DateTime . Parse ( row [ "AWO004" ] . ToString ( ) );
                if ( row [ "AWO005" ] != null )
                    _model . AWO005 = bool . Parse ( row [ "AWO005" ] . ToString ( ) );
                if ( row [ "AWO006" ] != null )
                    _model . AWO006 = bool . Parse ( row [ "AWO006" ] . ToString ( ) );
            }

            return _model;

        }

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public DataTable table ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AWO001,AWO002,AWQ005,AWO004,AWO005,AWO006,AWQ002,AWQ003,AWQ004,AWQ006,AWQ010,AWQ007,AWQ008,OPI006 FROM MOXAWO A INNER JOIN MOXAWQ B ON A.AWO001=B.AWQ001 INNER JOIN MOXOPI C ON B.AWQ003=C.OPI001 ORDER BY AWO001 DESC " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT AWQ002,AWQ003 FROM MOXAWQ WHERE AWQ001='{0}'" ,oddNum );
            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                CarpenterEntity . AssembleWorkOrderAWOEntity model = new CarpenterEntity . AssembleWorkOrderAWOEntity ( );
                CarpenterEntity . AssembleWorkOrderAWQEntity modelOne = new CarpenterEntity . AssembleWorkOrderAWQEntity ( );
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    modelOne . AWQ002 = dt . Rows [ i ] [ "AWQ002" ] . ToString ( );
                    modelOne . AWQ003 = dt . Rows [ i ] [ "AWQ003" ] . ToString ( );
                    model . AWO002 = getMaxTime ( modelOne . AWQ002 ,modelOne . AWQ003 ,oddNum );
                    edit_pas ( model ,modelOne ,SQLString ,strSql );
                }
            }
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXAWO " );
            strSql . AppendFormat ( " WHERE AWO001='{0}'" ,oddNum );
            SQLString . Add ( strSql ,null );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXAWQ " );
            strSql . AppendFormat ( " WHERE AWQ001='{0}'" ,oddNum );
            SQLString . Add ( strSql ,null );

            return  SqlHelper . ExecuteSqlTran ( SQLString );
        }

        DateTime? getMaxTime ( string piNum ,string pingNum ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT AWO002 FROM  MOXAWO WHERE AWO001=(SELECT MAX(AWO001) AWO001 FROM MOXAWO A INNER JOIN MOXAWQ B ON A.AWO001=B.AWQ001 WHERE AWQ002='{0}' AND AWQ003='{1}' AND AWQ001!='{2}')" ,piNum ,pingNum ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "AWO002" ] . ToString ( ) ) )
                    return null;
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "AWO002" ] . ToString ( ) );
            }
            else
                return null;
        }

        /// <summary>
        /// 获取剩余数量
        /// </summary>
        /// <param name="week"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public int GetNum ( string week ,string productNum,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT SUM(PAS016)-SUM(ISNULL(PLF007,0)) COUNT FROM MOXPAS A LEFT JOIN MOXPLF B ON A.PAS001=B.PLF002 AND A.PAS002=B.PLF003 " );
            strSql . AppendFormat ( "WHERE PAS001='{0}' AND PAS002='{1}'" ,week ,productNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "COUNT" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToInt32 ( dt . Rows [ 0 ] [ "COUNT" ] . ToString ( ) );
            }
            else
                return 0;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_awo"></param>
        /// <param name="strList"></param>
        /// <param name="getHash"></param>
        /// <returns></returns>
        public bool Save ( Hashtable hsTable,DataTable tableView )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . AssembleWorkOrderAWOEntity _awo = new CarpenterEntity . AssembleWorkOrderAWOEntity ( );
            List<string> strOdd = new List<string> ( );
            for ( int i = 0 ; i < tableView . Rows . Count ; i++ )
            {
                CarpenterEntity . AssembleWorkOrderAWQEntity _awq = new CarpenterEntity . AssembleWorkOrderAWQEntity ( );
                _awo . AWO001 = getOdd ( );
                if ( !strOdd . Contains ( _awo . AWO001 ) )
                    strOdd . Add ( _awo . AWO001 );
                else
                {
                    _awo . AWO001 = strOdd . Max ( );
                    _awo . AWO001 = ( Convert . ToInt64 ( _awo . AWO001 ) + 1 ) . ToString ( );
                    strOdd . Add ( _awo . AWO001 );
                }
                _awo . AWO002 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "DT" ] . ToString ( ) ) == true ? UserInformation . dt ( ) : Convert . ToDateTime ( tableView . Rows [ i ] [ "DT" ] . ToString ( ) );
                _awo . AWO003 = tableView . Rows [ i ] [ "USERS" ] . ToString ( );
                _awo . AWO004 = null;
                _awo . AWO005 = true;
                _awo . AWO006 = false;
                add_one ( _awo ,SQLString ,strSql );

                _awq . AWQ001 = _awo . AWO001;
                _awq . AWQ002 = tableView . Rows [ i ] [ "PAS001" ] . ToString ( );
                _awq . AWQ003 = tableView . Rows [ i ] [ "PAS002" ] . ToString ( );
                _awq . AWQ004 = tableView . Rows [ i ] [ "PAS003" ] . ToString ( );
                _awq . AWQ005 = tableView . Rows [ i ] [ "PAS004" ] . ToString ( );
                _awq . AWQ007 = 0;
                _awq . AWQ008 = tableView . Rows [ i ] [ "PAS013" ] . ToString ( );
                edit_pas ( _awo ,_awq ,SQLString ,strSql );

                DataTable dt = ( DataTable ) hsTable [ _awq . AWQ002 + _awq . AWQ003 ];
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    for ( int j = 0 ; j < dt . Rows . Count ; j++ )
                    {
                        _awq . AWQ006 = string . IsNullOrEmpty ( dt . Rows [ j ] [ "Num" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ j ] [ "Num" ] . ToString ( ) );
                        if ( _awq . AWQ006 > 0 )
                        {
                            _awq . AWQ009 = dt . Rows [ j ] [ "EMP001" ] . ToString ( );
                            _awq . AWQ010 = dt . Rows [ j ] [ "EMP002" ] . ToString ( );
                            add_tre ( _awq ,SQLString ,strSql );
                        }
                    }
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_awo"></param>
        /// <param name="tableOne"></param>
        /// <param name="tableTwo"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . AssembleWorkOrderAWOEntity _awo ,DataTable tableTwo )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            edit_one ( _awo ,SQLString ,strSql );
            
            CarpenterEntity . AssembleWorkOrderAWQEntity _awq = new CarpenterEntity . AssembleWorkOrderAWQEntity ( );
             _awq . AWQ001 = _awo . AWO001;
            DataTable dt = table ( _awq . AWQ001 );
            for ( int i = 0 ; i < tableTwo . Rows . Count ; i++ )
            {
                _awq . idx = string . IsNullOrEmpty ( tableTwo . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableTwo . Rows [ i ] [ "idx" ] . ToString ( ) );
                _awq . AWQ002 = tableTwo . Rows [ i ] [ "AWQ002" ] . ToString ( );
                _awq . AWQ003 = tableTwo . Rows [ i ] [ "AWQ003" ] . ToString ( );
                _awq . AWQ006 = string . IsNullOrEmpty ( tableTwo . Rows [ i ] [ "AWQ006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableTwo . Rows [ i ] [ "AWQ006" ] . ToString ( ) );
                _awq . AWQ007 = string . IsNullOrEmpty ( tableTwo . Rows [ i ] [ "AWQ007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableTwo . Rows [ i ] [ "AWQ007" ] . ToString ( ) );
                _awq . AWQ008 = tableTwo . Rows [ i ] [ "AWQ008" ] . ToString ( );
                if ( dt . Select ( "AWQ002='" + _awq . AWQ002 + "' AND AWQ003='" + _awq . AWQ003 + "'" ) . Length < 1 )
                    add_tre ( _awq ,SQLString ,strSql );
                else
                    edit_tre ( _awq ,SQLString ,strSql );

                edit_pas ( _awo ,_awq ,SQLString ,strSql );
            }
            for ( int j = 0 ; j < dt . Rows . Count ; j++ )
            {
                _awq . AWQ002 = dt . Rows [ j ] [ "AWQ002" ] . ToString ( );
                _awq . AWQ003 = dt . Rows [ j ] [ "AWQ003" ] . ToString ( );
                _awq . idx = string . IsNullOrEmpty ( dt . Rows [ j ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ j ] [ "idx" ] . ToString ( ) );
                if ( tableTwo . Select ( "AWQ002='" + _awq . AWQ002 + "' AND AWQ003='" + _awq . AWQ003 + "'" ) . Length < 1 )
                {
                    delete_tre ( _awq ,SQLString ,strSql );

                    _awo . AWO002 = getMaxTime ( _awq . AWQ002 ,_awq . AWQ003 ,_awo . AWO001 );
                    edit_pas ( _awo ,_awq ,SQLString ,strSql );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        void edit_one ( CarpenterEntity . AssembleWorkOrderAWOEntity _awo ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXAWO SET " );
            strSql . Append ( "AWO002=@AWO002," );
            strSql . Append ( "AWO003=@AWO003 " );
            strSql . Append ( "WHERE AWO001=@AWO001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AWO002",SqlDbType.Date,3),
                new SqlParameter("@AWO003",SqlDbType.NVarChar,20),
                new SqlParameter("@AWO001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _awo . AWO002;
            parameter [ 1 ] . Value = _awo . AWO003;
            parameter [ 2 ] . Value = _awo . AWO001;

            SQLString . Add ( strSql ,parameter );
        }

        void add_one ( CarpenterEntity . AssembleWorkOrderAWOEntity _awo ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXAWO (" );
            strSql . Append ( "AWO001,AWO002,AWO003,AWO004,AWO005,AWO006) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@AWO001,@AWO002,@AWO003,@AWO004,@AWO005,@AWO006) " );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@AWO001", SqlDbType.VarChar,20),
                    new SqlParameter("@AWO002", SqlDbType.Date,3),
                    new SqlParameter("@AWO003", SqlDbType.VarChar,20),
                    new SqlParameter("@AWO004", SqlDbType.Date,3),
                    new SqlParameter("@AWO005", SqlDbType.Bit,1),
                    new SqlParameter("@AWO006", SqlDbType.Bit,1)
            };
            parameters [ 0 ] . Value = _awo . AWO001;
            parameters [ 1 ] . Value = _awo . AWO002;
            parameters [ 2 ] . Value = _awo . AWO003;
            parameters [ 3 ] . Value = _awo . AWO004;
            parameters [ 4 ] . Value = _awo . AWO005;
            parameters [ 5 ] . Value = _awo . AWO006;
            SQLString . Add ( strSql ,parameters );
        }

        public DataTable table ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,AWQ002,AWQ003 FROM MOXAWQ " );
            strSql . AppendFormat ( "WHERE AWQ001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void add_tre ( CarpenterEntity . AssembleWorkOrderAWQEntity _awq ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXAWQ( " );
            strSql . Append ( "AWQ001,AWQ002,AWQ003,AWQ004,AWQ005,AWQ006,AWQ007,AWQ008,AWQ009,AWQ010) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@AWQ001,@AWQ002,@AWQ003,@AWQ004,@AWQ005,@AWQ006,@AWQ007,@AWQ008,@AWQ009,@AWQ010)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@AWQ001", SqlDbType.VarChar,20),
                    new SqlParameter("@AWQ002", SqlDbType.VarChar,20),
                    new SqlParameter("@AWQ003", SqlDbType.VarChar,20),
                    new SqlParameter("@AWQ004", SqlDbType.VarChar,20),
                    new SqlParameter("@AWQ005", SqlDbType.VarChar,20),
                    new SqlParameter("@AWQ006", SqlDbType.Int,4),
                    new SqlParameter("@AWQ007", SqlDbType.Decimal,9),
                    new SqlParameter("@AWQ008", SqlDbType.VarChar,50),
                    new SqlParameter("@AWQ009", SqlDbType.VarChar,20),
                    new SqlParameter("@AWQ010", SqlDbType.VarChar,20)
            };
            parameters [ 0 ] . Value = _awq . AWQ001;
            parameters [ 1 ] . Value = _awq . AWQ002;
            parameters [ 2 ] . Value = _awq . AWQ003;
            parameters [ 3 ] . Value = _awq . AWQ004;
            parameters [ 4 ] . Value = _awq . AWQ005;
            parameters [ 5 ] . Value = _awq . AWQ006;
            parameters [ 6 ] . Value = _awq . AWQ007;
            parameters [ 7 ] . Value = _awq . AWQ008;
            parameters [ 8 ] . Value = _awq . AWQ009;
            parameters [ 9 ] . Value = _awq . AWQ010;
            SQLString . Add ( strSql ,parameters );
        }

        void edit_tre ( CarpenterEntity . AssembleWorkOrderAWQEntity _awq ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXAWQ SET " );
            strSql . Append ( "AWQ006=@AWQ006," );
            strSql . Append ( "AWQ007=@AWQ007," );
            strSql . Append ( "AWQ008=@AWQ008 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4),
                    new SqlParameter("@AWQ006", SqlDbType.Int,4),
                    new SqlParameter("@AWQ007", SqlDbType.Decimal,9),
                    new SqlParameter("@AWQ008", SqlDbType.VarChar,50) };
            parameters [ 0 ] . Value = _awq . idx;
            parameters [ 1 ] . Value = _awq . AWQ006;
            parameters [ 2 ] . Value = _awq . AWQ007;
            parameters [ 3 ] . Value = _awq . AWQ008;
            SQLString . Add ( strSql ,parameters );
        }

        void delete_tre ( CarpenterEntity . AssembleWorkOrderAWQEntity _awq ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXAWQ " );
            strSql . AppendFormat ( "WHERE idx={0}" ,_awq . idx );
            SQLString . Add ( strSql ,null );
        }

        void edit_pas ( CarpenterEntity . AssembleWorkOrderAWOEntity model,CarpenterEntity . AssembleWorkOrderAWQEntity modelOne ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPAS SET " );
            strSql . Append ( "PAS008=@PAS008 " );
            strSql . Append ( "WHERE PAS001=@PAS001 AND PAS002=@PAS002" );
            SqlParameter [ ] parameter = {
                   new SqlParameter("@PAS001",SqlDbType.NVarChar,20),
                   new SqlParameter("@PAS002",SqlDbType.NVarChar,20),
                   new SqlParameter("@PAS008",SqlDbType.Date,3)
            };
            parameter [ 0 ] . Value = modelOne . AWQ002;
            parameter [ 1 ] . Value = modelOne . AWQ003;
            if ( model . AWO002 != null )
                parameter [ 2 ] . Value = model . AWO002;
            else
                parameter [ 2 ] . Value = DBNull . Value;


            SQLString . Add ( strSql ,parameter );
        }

        string getOdd ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(AWO001) AWO001 FROM MOXAWO" );
            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "AWO001" ] . ToString ( ) ) )
                    return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "AWO001" ] . ToString ( ) . Substring ( 0 ,8 ) == UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "AWO001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return UserInformation . dt ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        DataTable tableProduct (string week,string proNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PAS001,PAS002,PAS003,PAS004,PAS013 FROM MOXPAS " );
            strSql . AppendFormat ( "WHERE PAS001='{0}' AND PAS002='{1}'" ,week ,proNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="programName"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examine ( string oddNum ,string programName ,bool state )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( state == false )
                CarpenterBll . Examine . writeToReview ( programName ,oddNum ,UserInformation . UserName ,SQLString );
            else
                CarpenterBll . Examine . deleteToReview ( programName ,oddNum ,UserInformation . UserName ,SQLString );

            strSql . Append ( "UPDATE MOXAWO SET " );
            strSql . Append ( "AWO005=@AWO005 " );
            strSql . Append ( "WHERE AWO001=@AWO001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AWO001",SqlDbType.NVarChar,20),
                new SqlParameter("@AWO005",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = oddNum;
            parameter [ 1 ] . Value = state;
            SQLString . Add ( strSql ,parameter );

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
            strSql . Append ( "UPDATE MOXAWO SET " );
            strSql . Append ( "AWO006=@AWO006 " );
            strSql . Append ( "WHERE AWO001=@AWO001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AWO001",SqlDbType.NVarChar,20),
                new SqlParameter("@AWO006",SqlDbType.Bit)
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
        /// 获取派工单数据
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public List<string> GetStrList ( List<string> strList )
        {
            List<string> intList = new List<string> ( );
            string str = string . Empty;
            foreach ( string s in strList )
            {
                if ( str == string . Empty )
                    str = s;
                else
                    str = str + "," + s;
            }
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT A.idx FROM MOXPAS A LEFT JOIN MOXAWQ B ON A.PAS001=B.AWQ002 AND A.PAS002=B.AWQ002 INNER JOIN MOXPLE C ON A.PAS001=C.PLE003 AND A.PAS002=C.PLE004 WHERE A.idx IN ({0})  GROUP BY A.idx,PAS016 HAVING SUM(ISNULL(AWQ006,0))<PAS016" ,str );
            
            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    intList . Add ( dt . Rows [ i ] [ "idx" ] . ToString ( ) );
                }
                return intList;
            }
            else
                return intList;
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable printOne ( string oddNum  )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AWQ002,AWQ004,AWQ005,AWQ006,AWQ007,AWQ008,OPI006,AWO002,AWO003,AWO004,AWQ010 FROM MOXAWQ A LEFT JOIN MOXOPI B ON A.AWQ003=B.OPI001 INNER JOIN MOXAWO C ON A.AWQ001=C.AWO001 " );
            strSql . AppendFormat ( "WHERE AWO001 IN ({0})" ,oddNum  );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public DataTable printTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AWQ002,AWQ004,AWQ005,AWQ006,AWQ007,AWQ008,OPI006,AWO002,AWO003,AWO004,AWQ010 FROM MOXAWQ A LEFT JOIN MOXOPI B ON A.AWQ003=B.OPI001 INNER JOIN MOXAWO C ON A.AWQ001=C.AWO001 " );
            strSql . AppendFormat ( "WHERE AWO001 IN ({0}) ORDER BY AWQ010,AWO002" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable printTwo ( string oddNum ,List<string> strList )
        {
            string str = string . Empty;
            foreach ( string s in strList )
            {
                if ( str == string . Empty )
                    str = s;
                else
                    str = str + "," + s;
            }

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AWQ002,AWQ004,AWQ005,AWQ006,AWQ007,AWQ008,OPI006 FROM MOXAWQ A LEFT JOIN MOXOPI B ON A.AWQ003=B.OPI001 " );
            strSql . AppendFormat ( "WHERE AWQ001='{0}' AND A.idx IN ({1})" ,oddNum ,str );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取报工列表
        /// </summary>
        /// <param name="week"></param>
        /// <param name="produceNum"></param>
        /// <returns></returns>
        public DataTable tableOne ( string week ,string produceNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AWQ009,AWQ010,AWQ006,SUM(ISNULL(PLF007,0)) PLF007,0 DL,AWQ001 FROM MOXAWQ B LEFT JOIN MOXPLF C ON B.AWQ002=C.PLF002 AND B.AWQ003=C.PLF003 AND B.AWQ009=C.PLF008 AND B.AWQ001=C.PLF016 " );
            strSql . AppendFormat ( "WHERE AWQ002='{0}' AND AWQ003='{1}' " ,week ,produceNum );
            strSql . Append ( " GROUP BY AWQ009,AWQ010,AWQ001,AWQ006 HAVING AWQ006>SUM(ISNULL(PLF007,0))  " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetTableQueryPerson ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT EMP001,EMP002,DEP002,0 Num FROM MOXEMP A LEFT JOIN MOXDEP B ON A.EMP003=B.DEP001 WHERE EMP008=0 AND EMP001!='00001' AND EMP012='组装派工'" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }



        /// <summary>
        /// 获取剩余数量
        /// </summary>
        /// <param name="week"></param>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public DataTable proNum ( List<string> strIdx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PAS016-SUM(ISNULL(AWQ006,0)) AWQ006,PAS001,PAS002,PAS003,PAS004,PAS013,CONVERT(NVARCHAR,GETDATE(),102) DT,'' USERS FROM MOXPAS A LEFT JOIN MOXAWQ B ON A.PAS001=B.AWQ002 AND A.PAS002=B.AWQ003 " );
            strSql . AppendFormat ( "WHERE A.idx IN ({0}) " ,string . Join ( "," ,strIdx . ToArray ( ) ) );
            strSql . Append ( "GROUP BY PAS016,PAS001,PAS002,PAS003,PAS004,PAS013 HAVING PAS016-SUM(ISNULL(AWQ006,0))>0 " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取剩余数量
        /// </summary>
        /// <param name="week"></param>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public int proNum ( string week ,string proNum ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PAS016-ISNULL(AWQ006,0) AWQ006,PAS001,PAS002 FROM MOXPAS A LEFT JOIN (SELECT AWQ002,AWQ003,SUM(AWQ006) AWQ006 FROM MOXAWQ WHERE  AWQ001!='{0}' GROUP BY AWQ002,AWQ003 ) B ON A.PAS001=B.AWQ002 AND A.PAS002=B.AWQ003 " ,oddNum );
            strSql . AppendFormat ( "WHERE PAS001='{0}' AND PAS002='{1}' " ,week ,proNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "AWQ006" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToInt32 ( dt . Rows [ 0 ] [ "AWQ006" ] . ToString ( ) );
            }
            else
                return 0;
        }

    }
}
