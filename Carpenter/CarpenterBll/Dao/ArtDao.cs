
using StudentMgr;
using System;
using System . Collections;
using System . Data;
using System . Data . SqlClient;
using System . Text;

namespace CarpenterBll . Dao
{
    public class ArtDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT A.idx,ART001,ART002,ART003,ART004,ART005,ART006,ART007,ART008,ART009,ART010,ART011,DEP002 FROM MOXART A LEFT JOIN MOXDEP B ON A.ART006=B.DEP001 ORDER BY ART001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 获取工艺信息  区间信息
        /// </summary>
        /// <param name="artNum"></param>
        /// <returns></returns>
        public DataTable tableView ( string artNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,ARU001,ARU002,ARU003,ARU004,ARU005,ARU006,ARU007,ARU008,ARU009,ARU010 FROM MOXARU " );
            strSql . AppendFormat ( "WHERE ARU001='{0}'" ,artNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取编号
        /// </summary>
        /// <returns></returns>
        public string GetNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(ART001) ART001 FROM MOXART " );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "ART001" ] . ToString ( ) ) )
                    return string . Empty;
                else
                    return dt . Rows [ 0 ] [ "ART001" ] . ToString ( );
            }
            else
                return string . Empty;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXART " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Add ( CarpenterEntity . ArtEntity _model ,DataTable table)
        {
            Hashtable SQLString = new Hashtable ( );

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXART (" );
            strSql . Append ( "ART001,ART002,ART003,ART004,ART005,ART006,ART007,ART008,ART009,ART010,ART011) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@ART001,@ART002,@ART003,@ART004,@ART005,@ART006,@ART007,@ART008,@ART009,@ART010,@ART011); " );
            strSql . Append ( "SELECT SCOPE_IDENTITY();" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@ART001",SqlDbType.NVarChar,20),
                new SqlParameter("@ART002",SqlDbType.NVarChar,50),
                new SqlParameter("@ART003",SqlDbType.NVarChar,200),
                new SqlParameter("@ART004",SqlDbType.NVarChar,20),
                new SqlParameter("@ART005",SqlDbType.NVarChar,20),
                new SqlParameter("@ART006",SqlDbType.NVarChar,20),
                new SqlParameter("@ART007",SqlDbType.NVarChar,200),
                new SqlParameter("@ART008",SqlDbType.Bit),
                new SqlParameter("@ART009",SqlDbType.DateTime),
                new SqlParameter("@ART010",SqlDbType.NVarChar,20),
                new SqlParameter("@ART011",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . ART001;
            parameter [ 1 ] . Value = _model . ART002;
            parameter [ 2 ] . Value = _model . ART003;
            parameter [ 3 ] . Value = _model . ART004;
            parameter [ 4 ] . Value = _model . ART005;
            parameter [ 5 ] . Value = _model . ART006;
            parameter [ 6 ] . Value = _model . ART007;
            parameter [ 7 ] . Value = _model . ART008;
            parameter [ 8 ] . Value = _model . ART009;
            parameter [ 9 ] . Value = _model . ART010;
            parameter [ 10 ] . Value = _model . ART011;

            SQLString . Add ( strSql ,parameter );

            CarpenterEntity . AruEntity _modelOne = new CarpenterEntity . AruEntity ( );
            _modelOne . ARU001 = _model . ART001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _modelOne . ARU002 = table . Rows [ i ] [ "ARU002" ] . ToString ( );
                _modelOne . ARU003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ARU003" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ARU003" ] . ToString ( ) );
                _modelOne . ARU004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ARU004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ARU004" ] . ToString ( ) );
                _modelOne . ARU005 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ARU005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ARU005" ] . ToString ( ) );
                _modelOne . ARU007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ARU007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ARU007" ] . ToString ( ) );
                _modelOne . ARU008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ARU008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ARU008" ] . ToString ( ) );
                _modelOne . ARU009 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ARU009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ARU009" ] . ToString ( ) );
                _modelOne . ARU010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ARU010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ARU010" ] . ToString ( ) );
                _modelOne . ARU006 = table . Rows [ i ] [ "ARU006" ] . ToString ( );
                add_aru ( SQLString ,strSql ,_modelOne );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . ArtEntity _model ,DataTable table)
        {
            Hashtable SQLString = new Hashtable ( );

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXART SET " );
            strSql . Append ( "ART001=@ART001," );
            strSql . Append ( "ART002=@ART002," );
            strSql . Append ( "ART003=@ART003," );
            strSql . Append ( "ART004=@ART004," );
            strSql . Append ( "ART005=@ART005," );
            strSql . Append ( "ART006=@ART006," );
            strSql . Append ( "ART007=@ART007," );
            //strSql . Append ( "ART008=ART008," );
            strSql . Append ( "ART009=@ART009," );
            strSql . Append ( "ART010=@ART010," );
            strSql . Append ( "ART011=@ART011 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@ART001",SqlDbType.NVarChar,20),
                new SqlParameter("@ART002",SqlDbType.NVarChar,50),
                new SqlParameter("@ART003",SqlDbType.NVarChar,200),
                new SqlParameter("@ART004",SqlDbType.NVarChar,20),
                new SqlParameter("@ART005",SqlDbType.NVarChar,20),
                new SqlParameter("@ART006",SqlDbType.NVarChar,20),
                new SqlParameter("@ART007",SqlDbType.NVarChar,200),
                //new SqlParameter("ART008",SqlDbType.Bit),
                new SqlParameter("@ART009",SqlDbType.DateTime),
                new SqlParameter("@ART010",SqlDbType.NVarChar,20),
                new SqlParameter("@ART011",SqlDbType.NVarChar,20),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _model . ART001;
            parameter [ 1 ] . Value = _model . ART002;
            parameter [ 2 ] . Value = _model . ART003;
            parameter [ 3 ] . Value = _model . ART004;
            parameter [ 4 ] . Value = _model . ART005;
            parameter [ 5 ] . Value = _model . ART006;
            parameter [ 6 ] . Value = _model . ART007;
            //parameter [ 7 ] . Value = _model . ART008;
            parameter [ 7 ] . Value = _model . ART009;
            parameter [ 8 ] . Value = _model . ART010;
            parameter [ 9 ] . Value = _model . ART011;
            parameter [ 10 ] . Value = _model . idx;

            SQLString . Add ( strSql ,parameter );

            CarpenterEntity . AruEntity _modelOne = new CarpenterEntity . AruEntity ( );
            _modelOne . ARU001 = _model . ART001;
            DataTable dt = tableSpace ( _modelOne . ARU001 );
            if ( table != null && table . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _modelOne . ARU002 = table . Rows [ i ] [ "ARU002" ] . ToString ( );
                    _modelOne . ARU003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ARU003" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ARU003" ] . ToString ( ) );
                    _modelOne . ARU004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ARU004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ARU004" ] . ToString ( ) );
                    _modelOne . ARU005 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ARU005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ARU005" ] . ToString ( ) );
                    _modelOne . ARU006 = table . Rows [ i ] [ "ARU006" ] . ToString ( );
                    _modelOne . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                    _modelOne . ARU007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ARU007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ARU007" ] . ToString ( ) );
                    _modelOne . ARU008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ARU008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ARU008" ] . ToString ( ) );
                    _modelOne . ARU009 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ARU009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ARU009" ] . ToString ( ) );
                    _modelOne . ARU010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "ARU010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "ARU010" ] . ToString ( ) );

                    if ( Exists ( _modelOne . idx ) )
                        edit_aru ( SQLString ,strSql ,_modelOne );
                    else
                        add_aru ( SQLString ,strSql ,_modelOne );
                    //if ( !_modelOne . ARU002 . Equals ( "非标" ) )
                    //{
                    //    if ( dt . Select ( "ARU002='" + _modelOne . ARU002 + "'" ) . Length > 0 )
                    //    {
                    //        _modelOne . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                    //        edit_aru ( SQLString ,strSql ,_modelOne );
                    //    }
                    //    else
                    //        add_aru ( SQLString ,strSql ,_modelOne );
                    //}
                    //else
                    //{
                    //    if ( dt . Select ( "ARU002='" + _modelOne . ARU002 + "' AND ARU005='" + _modelOne . ARU005 + "' AND ARU006='" + _modelOne . ARU006 . Trim ( ) + "'" ) . Length > 0 )
                    //    {
                    //        _modelOne . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                    //        edit_aru ( SQLString ,strSql ,_modelOne );
                    //    }
                    //    else
                    //        add_aru ( SQLString ,strSql ,_modelOne );
                    //}
                }
            }
            for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            {
                //_modelOne . ARU002 = dt . Rows [ i ] [ "ARU002" ] . ToString ( );
                //_modelOne . ARU005 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "ARU005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "ARU005" ] . ToString ( ) );
                //_modelOne . ARU006 = dt . Rows [ i ] [ "ARU006" ] . ToString ( );
                //_modelOne . idx = string . IsNullOrEmpty ( dt . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "idx" ] . ToString ( ) );
                //if ( !_modelOne . ARU002 . Equals ( "非标" ) )
                //{
                //    if ( table . Select ( "ARU002='" + _modelOne . ARU002 + "'" ) . Length < 1 )
                //        delete_aru ( SQLString ,strSql ,_modelOne );
                //}
                //else
                //{
                //    if ( table . Select ( "ARU002='" + _modelOne . ARU002 + "' AND ARU005='" + _modelOne . ARU005 + "' AND ARU006='" + _modelOne . ARU006 + "'" ) . Length < 1 )
                //        delete_aru ( SQLString ,strSql ,_modelOne );
                //}

                _modelOne . idx = string . IsNullOrEmpty ( dt . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( table . Select ( "idx='" + _modelOne . idx + "'" ) . Length < 1 )
                    delete_aru ( SQLString ,strSql ,_modelOne );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_aru (Hashtable SQLString ,StringBuilder strSql,CarpenterEntity.AruEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXARU (" );
            strSql . Append ( "ARU001,ARU002,ARU003,ARU004,ARU005,ARU006,ARU007,ARU008,ARU009,ARU010) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@ARU001,@ARU002,@ARU003,@ARU004,@ARU005,@ARU006,@ARU007,@ARU008,@ARU009,@ARU010) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@ARU001",SqlDbType.NVarChar,20),
                new SqlParameter("@ARU002",SqlDbType.NVarChar,20),
                new SqlParameter("@ARU003",SqlDbType.Decimal,18),
                new SqlParameter("@ARU004",SqlDbType.Decimal,18),
                new SqlParameter("@ARU005",SqlDbType.Decimal,18),
                new SqlParameter("@ARU006",SqlDbType.NVarChar,100),
                new SqlParameter("@ARU007",SqlDbType.Decimal,18),
                new SqlParameter("@ARU008",SqlDbType.Decimal,18),
                new SqlParameter("@ARU009",SqlDbType.Decimal,18),
                new SqlParameter("@ARU010",SqlDbType.Decimal,18)
            };
            parameter [ 0 ] . Value = _model . ARU001;
            parameter [ 1 ] . Value = _model . ARU002;
            parameter [ 2 ] . Value = _model . ARU003;
            parameter [ 3 ] . Value = _model . ARU004;
            parameter [ 4 ] . Value = _model . ARU005;
            parameter [ 5 ] . Value = _model . ARU006;
            parameter [ 6 ] . Value = _model . ARU007;
            parameter [ 7 ] . Value = _model . ARU008;
            parameter [ 8 ] . Value = _model . ARU009;
            parameter [ 9 ] . Value = _model . ARU010;

            SQLString . Add ( strSql ,parameter );
        }

        void edit_aru ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . AruEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXARU SET " );
            strSql . Append ( "ARU001=@ARU001," );
            strSql . Append ( "ARU002=@ARU002," );
            strSql . Append ( "ARU003=@ARU003," );
            strSql . Append ( "ARU004=@ARU004," );
            strSql . Append ( "ARU005=@ARU005," );
            strSql . Append ( "ARU006=@ARU006," );
            strSql . Append ( "ARU007=@ARU007," );
            strSql . Append ( "ARU008=@ARU008," );
            strSql . Append ( "ARU009=@ARU009," );
            strSql . Append ( "ARU010=@ARU010 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@ARU001",SqlDbType.NVarChar,20),
                new SqlParameter("@ARU002",SqlDbType.NVarChar,20),
                new SqlParameter("@ARU003",SqlDbType.Decimal,18),
                new SqlParameter("@ARU004",SqlDbType.Decimal,18),
                new SqlParameter("@ARU005",SqlDbType.Decimal,18),
                new SqlParameter("@ARU006",SqlDbType.NVarChar,100),                
                new SqlParameter("@ARU007",SqlDbType.Decimal,18),
                new SqlParameter("@ARU008",SqlDbType.Decimal,18),
                new SqlParameter("@ARU009",SqlDbType.Decimal,18),
                new SqlParameter("@ARU010",SqlDbType.Decimal,18),
                new SqlParameter("@idx",SqlDbType.Int,4)
            };
            parameter [ 0 ] . Value = _model . ARU001;
            parameter [ 1 ] . Value = _model . ARU002;
            parameter [ 2 ] . Value = _model . ARU003;
            parameter [ 3 ] . Value = _model . ARU004;
            parameter [ 4 ] . Value = _model . ARU005;
            parameter [ 5 ] . Value = _model . ARU006;
            parameter [ 6 ] . Value = _model . ARU007;
            parameter [ 7 ] . Value = _model . ARU008;
            parameter [ 8 ] . Value = _model . ARU009;
            parameter [ 9 ] . Value = _model . ARU010;
            parameter [ 10 ] . Value = _model . idx;

            SQLString . Add ( strSql ,parameter );
        }

        void delete_aru ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . AruEntity _model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXARU " );
            strSql . AppendFormat ( "WHERE idx={0}" ,_model . idx );
            SQLString . Add ( strSql ,null );
        }

        DataTable tableSpace ( string artNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx FROM MOXARU " );
            strSql . AppendFormat ( "WHERE ARU001='{0}'" ,artNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        bool Exists ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXARU " );
            strSql . AppendFormat ( "WHERE idx={0}" ,idx );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Cancel ( int idx ,bool state )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXART SET " );
            strSql . Append ( "ART008=@ART008 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@ART008",SqlDbType.Bit),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = state;
            parameter [ 1 ] . Value = idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取部门
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepart ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DEP001,DEP002 FROM MOXDEP WHERE DEP004=1 ORDER BY DEP001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
