using System . Data;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;
using System;
using System . Collections;
using System . Collections . Generic;

namespace CarpenterBll . Dao
{
    public class EquipmentDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,EQU001,EQU002,EQU003,EQU004,EQU005,EQU007,EQU010 FROM MOXEQU ORDER BY EQU001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="EQU001"></param>
        /// <returns></returns>
        public DataTable GetDataTableV ( string EQU001 )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,EQV001,EQV002,EQV003,EQV004,EQV005 FROM MOXEQV " );
            strSql . Append ( " WHERE EQV001=@EQV001 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EQV001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = EQU001;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取设备编号
        /// </summary>
        /// <returns></returns>
        public string GetNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(EQU001) EQU001 FROM MOXEQU" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "EQU001" ] . ToString ( ) ) )
                    return string . Empty;
                else
                    return dt . Rows [ 0 ] [ "EQU001" ] . ToString ( );
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
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );   
            strSql . Append ( "DELETE FROM MOXEQV WHERE EQV001=(SELECT EQU001 FROM MOXEQU " );
            strSql . AppendFormat ( "WHERE idx={0})" ,idx );
            SQLString . Add ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXEQU " );
            strSql . AppendFormat ( "WHERE idx={0}" ,idx );
            SQLString . Add ( strSql . ToString ( ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取工艺信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableArt ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT ART001,ART001 ART,ART002 FROM MOXART WHERE ART008=0" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_modelOne"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Add ( CarpenterEntity . EquimentEntity _modelOne ,DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            add_equ ( SQLString ,strSql ,_modelOne );

            CarpenterEntity . EquimentChildEntity _model = new CarpenterEntity . EquimentChildEntity ( );
            _model . EQV001 = _modelOne . EQU001;
            _model . EQV004 = _modelOne . EQU008;
            _model . EQV005 = _modelOne . EQU009;

            DataView dv = table . DefaultView;
            table = dv . ToTable ( "TABLE" ,true ,new string [ ] { "EQV002" ,"EQV003" } );

            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . EQV002 = table . Rows [ i ] [ "EQV002" ] . ToString ( );
                _model . EQV003 = table . Rows [ i ] [ "EQV003" ] . ToString ( );

                if ( !Exists ( _model ) )
                    saveTo ( _model ,strSql ,SQLString );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 是否存在同设备编号，同工艺编号，同工艺名称
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        bool Exists ( CarpenterEntity . EquimentChildEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXEQV WHERE EQV001='{0}' AND EQV002='{1}'" ,_model . EQV001 ,_model . EQV002 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_modelOne"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . EquimentEntity _modelOne ,DataTable table ,List<int> idxList)
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            edit_equ ( SQLString ,strSql ,_modelOne );

            DataTable tableOne = GetDataTableV ( _modelOne . EQU001 );

            CarpenterEntity . EquimentChildEntity _model = new CarpenterEntity . EquimentChildEntity ( );
            _model . EQV001 = _modelOne . EQU001;
            _model . EQV004 = _modelOne . EQU008;
            _model . EQV005 = _modelOne . EQU009;

            if ( tableOne != null && tableOne . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _model . EQV002 = table . Rows [ i ] [ "EQV002" ] . ToString ( );
                    _model . EQV003 = table . Rows [ i ] [ "EQV003" ] . ToString ( );
                    if ( tableOne . Select ( "EQV002='" + _model . EQV002 + "' AND EQV003='" + _model . EQV003 + "'" ) . Length > 0 )
                        EditTo ( _model ,strSql ,SQLString );
                    else
                    {
                        _model . EQV002 = table . Rows [ i ] [ "EQV002" ] . ToString ( );
                        _model . EQV003 = table . Rows [ i ] [ "EQV003" ] . ToString ( );
                        if ( !string . IsNullOrEmpty ( _model . EQV002 ) && !string . IsNullOrEmpty ( _model . EQV003 ) )
                            saveTo ( _model ,strSql ,SQLString );
                    }
                }

                //for ( int i = 0 ; i < tableOne . Rows . Count ; i++ )
                //{
                //    _model . EQV002 = tableOne . Rows [ i ] [ "EQV002" ] . ToString ( );
                //    _model . EQV003 = tableOne . Rows [ i ] [ "EQV003" ] . ToString ( );
                //    if ( table . Select ( "EQV002='" + _model . EQV002 + "' AND EQV003='" + _model . EQV003 + "'" ) . Length < 1 )
                //        DeleteTo ( _model ,strSql ,SQLString );
                //}
            }
            else
            {
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _model . EQV002 = table . Rows [ i ] [ "EQV002" ] . ToString ( );
                    _model . EQV003 = table . Rows [ i ] [ "EQV003" ] . ToString ( );
                    saveTo ( _model ,strSql ,SQLString );
                }
            }

            foreach ( int k in idxList )
            {
                if ( k > 0 )
                {
                    _model . idx = k;
                    DeleteTo ( _model ,strSql ,SQLString );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_equ ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . EquimentEntity _modelOne )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXEQU (" );
            strSql . Append ( "EQU001,EQU002,EQU003,EQU004,EQU005,EQU007,EQU008,EQU009,EQU010) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EQU001,@EQU002,@EQU003,@EQU004,@EQU005,@EQU007,@EQU008,@EQU009,@EQU010)" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EQU001",SqlDbType.NVarChar,20),
                new SqlParameter("@EQU002",SqlDbType.NVarChar,20),
                new SqlParameter("@EQU003",SqlDbType.NVarChar,20),
                new SqlParameter("@EQU004",SqlDbType.NVarChar,20),
                new SqlParameter("@EQU005",SqlDbType.NVarChar,20),
                new SqlParameter("@EQU007",SqlDbType.Bit),
                new SqlParameter("@EQU008",SqlDbType.DateTime),
                new SqlParameter("@EQU009",SqlDbType.NVarChar,20),
                new SqlParameter("@EQU010",SqlDbType.NVarChar,500)
                    };
            parameter [ 0 ] . Value = _modelOne . EQU001;
            parameter [ 1 ] . Value = _modelOne . EQU002;
            parameter [ 2 ] . Value = _modelOne . EQU003;
            parameter [ 3 ] . Value = _modelOne . EQU004;
            parameter [ 4 ] . Value = _modelOne . EQU005;
            parameter [ 5 ] . Value = _modelOne . EQU007;
            parameter [ 6 ] . Value = _modelOne . EQU008;
            parameter [ 7 ] . Value = _modelOne . EQU009;
            parameter [ 8 ] . Value = _modelOne . EQU010;

            SQLString . Add ( strSql ,parameter );
        }

        void edit_equ ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . EquimentEntity _modelOne )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXEQU SET " );
            strSql . Append ( "EQU001=@EQU001," );
            strSql . Append ( "EQU002=@EQU002," );
            strSql . Append ( "EQU003=@EQU003," );
            strSql . Append ( "EQU004=@EQU004," );
            strSql . Append ( "EQU005=@EQU005," );
            strSql . Append ( "EQU007=@EQU007," );
            strSql . Append ( "EQU008=@EQU008," );
            strSql . Append ( "EQU009=@EQU009," );
            strSql . Append ( "EQU010=@EQU010 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EQU001",SqlDbType.NVarChar,20),
                new SqlParameter("@EQU002",SqlDbType.NVarChar,20),
                new SqlParameter("@EQU003",SqlDbType.NVarChar,20),
                new SqlParameter("@EQU004",SqlDbType.NVarChar,20),
                new SqlParameter("@EQU005",SqlDbType.NVarChar,20),
                new SqlParameter("@EQU007",SqlDbType.Bit),
                new SqlParameter("@EQU008",SqlDbType.DateTime),
                new SqlParameter("@EQU009",SqlDbType.NVarChar,20),
                new SqlParameter("@EQU010",SqlDbType.NVarChar,500),
                new SqlParameter("@idx",SqlDbType.Int)
                    };
            parameter [ 0 ] . Value = _modelOne . EQU001;
            parameter [ 1 ] . Value = _modelOne . EQU002;
            parameter [ 2 ] . Value = _modelOne . EQU003;
            parameter [ 3 ] . Value = _modelOne . EQU004;
            parameter [ 4 ] . Value = _modelOne . EQU005;
            parameter [ 5 ] . Value = _modelOne . EQU007;
            parameter [ 6 ] . Value = _modelOne . EQU008;
            parameter [ 7 ] . Value = _modelOne . EQU009;
            parameter [ 8 ] . Value = _modelOne . EQU010;
            parameter [ 9 ] . Value = _modelOne . idx;

            SQLString . Add ( strSql ,parameter );
        }

        void saveTo ( CarpenterEntity . EquimentChildEntity _modelTwo ,StringBuilder strSql ,Hashtable SQLString  )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXEQV (" );
            strSql . Append ( "EQV001,EQV002,EQV003,EQV004,EQV005) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@EQV001,@EQV002,@EQV003,@EQV004,@EQV005) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EQV001",SqlDbType.NVarChar,20),
                new SqlParameter("@EQV002",SqlDbType.NVarChar,20),
                new SqlParameter("@EQV003",SqlDbType.NVarChar,20),
                new SqlParameter("@EQV004",SqlDbType.DateTime),
                new SqlParameter("@EQV005",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelTwo . EQV001;
            parameter [ 1 ] . Value = _modelTwo . EQV002;
            parameter [ 2 ] . Value = _modelTwo . EQV003;
            parameter [ 3 ] . Value = _modelTwo . EQV004;
            parameter [ 4 ] . Value = _modelTwo . EQV005;

            SQLString . Add ( strSql ,parameter );
        }

        void EditTo ( CarpenterEntity . EquimentChildEntity _modelTwo ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXEQV SET " );          
            strSql . Append ( "EQV004=@EQV004," );
            strSql . Append ( "EQV005=@EQV005 " );
            strSql . Append ( "WHERE EQV001=@EQV001 " );
            strSql . Append ( "AND EQV002=@EQV002 " );
            strSql . Append ( "AND EQV003=@EQV003" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EQV001",SqlDbType.NVarChar,20),
                new SqlParameter("@EQV002",SqlDbType.NVarChar,20),
                new SqlParameter("@EQV003",SqlDbType.NVarChar,20),
                new SqlParameter("@EQV004",SqlDbType.DateTime),
                new SqlParameter("@EQV005",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelTwo . EQV001;
            parameter [ 1 ] . Value = _modelTwo . EQV002;
            parameter [ 2 ] . Value = _modelTwo . EQV003;
            parameter [ 3 ] . Value = _modelTwo . EQV004;
            parameter [ 4 ] . Value = _modelTwo . EQV005;

            SQLString . Add ( strSql ,parameter );
        }

        void DeleteTo ( CarpenterEntity . EquimentChildEntity _modelTwo ,StringBuilder strSql ,Hashtable SQLString )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXEQV WHERE idx={0}" ,_modelTwo . idx );
            //strSql . Append ( "WHERE EQV001=@EQV001 " );
            //strSql . Append ( "AND EQV002=@EQV002 " );
            //strSql . Append ( "AND EQV003=@EQV003" );
            //SqlParameter [ ] parameter = {
            //    new SqlParameter("@EQV001",SqlDbType.NVarChar,20),
            //    new SqlParameter("@EQV002",SqlDbType.NVarChar,20),
            //    new SqlParameter("@EQV003",SqlDbType.NVarChar,20)
            //};
            //parameter [ 0 ] . Value = _modelTwo . EQV001;
            //parameter [ 1 ] . Value = _modelTwo . EQV002;
            //parameter [ 2 ] . Value = _modelTwo . EQV003;

            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// 是否注销
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Cancel ( int idx ,bool state)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXEQU SET " );
            strSql . Append ( "EQU007=@EQU007 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@EQU007",SqlDbType.NVarChar,20),
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
        /// 获取工作中心
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWork ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DEP001,DEP002 FROM MOXDEP WHERE DEP004=1" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在此设备编码
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXEQU " );
            strSql . AppendFormat ( "WHERE EQU001='{0}'" ,oddNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool getIdxCount ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXEQU " );
            strSql . AppendFormat ( "WHERE EQU001={0}" ,oddNum );

            int row = SqlHelper . returnSumCount ( strSql . ToString ( ) );
            if ( row > 0 )
            {
                if ( row > 1 )
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="intList"></param>
        /// <returns></returns>
        public DataTable PrintOne ( List<int> intList )
        {
            StringBuilder strSql = new StringBuilder ( );
            if ( intList . Count < 1 )
                strSql . Append ( "SELECT EQU001,EQU002,EQU005 FROM MOXEQU" );
            else
            {
                string str = string . Empty;
                foreach ( int i in intList )
                {
                    if ( str == string . Empty )
                        str = i . ToString ( );
                    else
                        str = str + "," + i . ToString ( );
                }
                strSql . Append ( "SELECT EQU001,EQU002,EQU005 FROM MOXEQU " );
                strSql . AppendFormat ( "WHERE idx IN ({0})" ,str );
            }

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
