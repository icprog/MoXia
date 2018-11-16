
using StudentMgr;
using System . Data;
using System . Data . SqlClient;
using System . Text;

namespace CarpenterBll . Dao
{
    public class WoodPaintDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfProduct ( string str )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT OPI001,OPI002,OPI005,OPI007,OPI010 FROM MOXOPI WHERE OPI011=0 AND OPI008 IN ('在产','样品') AND OPI010 IN (" + str + ") ORDER BY OPI001 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取油漆BOM表内容
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfPaint ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PAI004 OPI001,PAI005 OPI002,PAI006 OPI005 FROM MOXPAI WHERE PAI012=0 ORDER BY PAI004 DESC " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取木材数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfWood ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,WOD004,WOD005,WOD006,WOD007,WOD008,WOD011 FROM MOXWOD " );
            if ( !string . IsNullOrEmpty ( strWhere ) )
                strSql . AppendFormat ( "WHERE WOD004='{0}'" ,strWhere );
            strSql . Append ( " ORDER BY WOD004" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取油漆数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePaint ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx idx_one,PAI004,PAI005,PAI006,PAI007,PAI008,PAI009,PAI012 FROM MOXPAI " );
            if ( !string . IsNullOrEmpty ( strWhere ) )
                strSql . AppendFormat ( "WHERE PAI004='{0}'" , strWhere );
            strSql . Append ( " ORDER BY PAI004" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取油漆耗材表数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx idx_two,PAJ002,PAJ004,PAJ005,PAJ006,PAJ007,PAJ008,PAJ009,PAJ010,PAJ013,PAJ014,PAJ015 FROM MOXPAJ " );
            if ( !string . IsNullOrEmpty ( strWhere ) )
                strSql . AppendFormat ( "WHERE PAJ004='{0}'" , strWhere );
            strSql . Append ( " ORDER BY PAJ004,PAJ002" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除一条信息
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx,string tableName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM {0} ",tableName );
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
        /// 注销
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Cancellation ( int idx ,string tableName ,string columnName ,bool bol )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE {0} SET " ,tableName );
            strSql . AppendFormat ( "{0}=@{0} " ,columnName );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@"+columnName+"",SqlDbType.Bit),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = bol;
            parameter [ 1 ] . Value = idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="keyName">主键名</param>
        /// <param name="keyPrimary">主键值</param>
        /// <returns></returns>
        public bool Exists ( string tableName,string keyName ,string keyPrimary )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) COUN FROM {0} " ,tableName );
            strSql . AppendFormat ( "WHERE {0}='{1}'" ,keyName ,keyPrimary );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int AddWood ( CarpenterEntity . WOODEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXWOD (" );
            strSql . Append ( "WOD004,WOD005,WOD006,WOD007,WOD008,WOD009,WOD010,WOD011) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@WOD004,@WOD005,@WOD006,@WOD007,@WOD008,@WOD009,@WOD010,@WOD011); " );
            strSql . Append ( "SELECT SCOPE_IDENTITY();" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WOD004",SqlDbType.NVarChar,20),
                new SqlParameter("@WOD005",SqlDbType.NVarChar,20),
                new SqlParameter("@WOD006",SqlDbType.NVarChar,20),
                new SqlParameter("@WOD007",SqlDbType.NVarChar,10),
                new SqlParameter("@WOD008",SqlDbType.Decimal,18),
                new SqlParameter("@WOD009",SqlDbType.DateTime),
                new SqlParameter("@WOD010",SqlDbType.NVarChar,20),
                new SqlParameter("@WOD011",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _model . WOD004;
            parameter [ 1 ] . Value = _model . WOD005;
            parameter [ 2 ] . Value = _model . WOD006;
            parameter [ 3 ] . Value = _model . WOD007;
            parameter [ 4 ] . Value = _model . WOD008;
            parameter [ 5 ] . Value = _model . WOD009;
            parameter [ 6 ] . Value = _model . WOD010;
            parameter [ 7 ] . Value = _model . WOD011;

            return SqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 编辑木材BOM
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool EditWood ( CarpenterEntity . WOODEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWOD SET " );
            strSql . Append ( "WOD004=@WOD004," );
            strSql . Append ( "WOD005=@WOD005," );
            strSql . Append ( "WOD006=@WOD006," );
            strSql . Append ( "WOD007=@WOD007," );
            strSql . Append ( "WOD008=@WOD008," );
            strSql . Append ( "WOD009=@WOD009," );
            strSql . Append ( "WOD010=@WOD010 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WOD004",SqlDbType.NVarChar,20),
                new SqlParameter("@WOD005",SqlDbType.NVarChar,20),
                new SqlParameter("@WOD006",SqlDbType.NVarChar,20),
                new SqlParameter("@WOD007",SqlDbType.NVarChar,10),
                new SqlParameter("@WOD008",SqlDbType.Decimal,6),
                new SqlParameter("@WOD009",SqlDbType.DateTime),
                new SqlParameter("@WOD010",SqlDbType.NVarChar,20),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _model . WOD004;
            parameter [ 1 ] . Value = _model . WOD005;
            parameter [ 2 ] . Value = _model . WOD006;
            parameter [ 3 ] . Value = _model . WOD007;
            parameter [ 4 ] . Value = _model . WOD008;
            parameter [ 5 ] . Value = _model . WOD009;
            parameter [ 6 ] . Value = _model . WOD010;
            parameter [ 7 ] . Value = _model . idx;

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
        public int AddPaint ( CarpenterEntity . PAITEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPAI (" );
            strSql . Append ( "PAI004,PAI005,PAI006,PAI007,PAI008,PAI009,PAI010,PAI011,PAI012) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PAI004,@PAI005,@PAI006,@PAI007,@PAI008,@PAI009,@PAI010,@PAI011,@PAI012); " );
            strSql . Append ( "SELECT SCOPE_IDENTITY();" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PAI004",SqlDbType.NVarChar,20),
                new SqlParameter("@PAI005",SqlDbType.NVarChar,20),
                new SqlParameter("@PAI006",SqlDbType.NVarChar,20),
                new SqlParameter("@PAI007",SqlDbType.NVarChar,10),
                new SqlParameter("@PAI008",SqlDbType.Decimal,18),
                new SqlParameter("@PAI009",SqlDbType.NVarChar,10),
                new SqlParameter("@PAI010",SqlDbType.DateTime),
                new SqlParameter("@PAI011",SqlDbType.NVarChar,20),
                new SqlParameter("@PAI012",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _model . PAI004;
            parameter [ 1 ] . Value = _model . PAI005;
            parameter [ 2 ] . Value = _model . PAI006;
            parameter [ 3 ] . Value = _model . PAI007;
            parameter [ 4 ] . Value = _model . PAI008;
            parameter [ 5 ] . Value = _model . PAI009;
            parameter [ 6 ] . Value = _model . PAI010;
            parameter [ 7 ] . Value = _model . PAI011;
            parameter [ 8 ] . Value = _model . PAI012;

            return SqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 编辑油漆BOM
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool EditPaint ( CarpenterEntity . PAITEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPAI SET " );
            strSql . Append ( "PAI004=@PAI004," );
            strSql . Append ( "PAI005=@PAI005," );
            strSql . Append ( "PAI006=@PAI006," );
            strSql . Append ( "PAI007=@PAI007," );
            strSql . Append ( "PAI008=@PAI008," );
            strSql . Append ( "PAI009=@PAI009," );
            strSql . Append ( "PAI010=@PAI010," );
            strSql . Append ( "PAI011=@PAI011 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PAI004",SqlDbType.NVarChar,20),
                new SqlParameter("@PAI005",SqlDbType.NVarChar,20),
                new SqlParameter("@PAI006",SqlDbType.NVarChar,20),
                new SqlParameter("@PAI007",SqlDbType.NVarChar,10),
                new SqlParameter("@PAI008",SqlDbType.Decimal,4),
                new SqlParameter("@PAI009",SqlDbType.NVarChar,20),
                new SqlParameter("@PAI010",SqlDbType.DateTime),
                new SqlParameter("@PAI011",SqlDbType.NVarChar,20),
                new SqlParameter("@idx",SqlDbType.Int),
            };
            parameter [ 0 ] . Value = _model . PAI004;
            parameter [ 1 ] . Value = _model . PAI005;
            parameter [ 2 ] . Value = _model . PAI006;
            parameter [ 3 ] . Value = _model . PAI007;
            parameter [ 4 ] . Value = _model . PAI008;
            parameter [ 5 ] . Value = _model . PAI009;
            parameter [ 6 ] . Value = _model . PAI010;
            parameter [ 7 ] . Value = _model . PAI011;
            parameter [ 8 ] . Value = _model . idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取油漆工序表最大序号
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public string GetPaintOneNum ( string productName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(PAJ002) PAJ002 FROM MOXPAJ " );
            strSql . Append ( "WHERE PAJ004=@PAJ004" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PAJ004",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = productName;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PAJ002" ] . ToString ( ) ) )
                    return string . Empty;
                else
                    return dt . Rows [ 0 ] [ "PAJ002" ] . ToString ( );
            }
            else
                return string . Empty;
        }

        /// <summary>
        /// 编辑油漆工序表
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool EditPaintWorkProcedure ( CarpenterEntity . PAIJEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPAJ SET " );
            strSql . Append ( "PAJ002=@PAJ002," );
            strSql . Append ( "PAJ004=@PAJ004," );
            strSql . Append ( "PAJ005=@PAJ005," );
            strSql . Append ( "PAJ006=@PAJ006," );
            strSql . Append ( "PAJ007=@PAJ007," );
            strSql . Append ( "PAJ008=@PAJ008," );
            strSql . Append ( "PAJ009=@PAJ009," );
            strSql . Append ( "PAJ010=@PAJ010," );
            strSql . Append ( "PAJ011=@PAJ011," );
            strSql . Append ( "PAJ012=@PAJ012," );
            strSql . Append ( "PAJ014=@PAJ014," );
            strSql . Append ( "PAJ015=@PAJ015 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PAJ002",SqlDbType.NVarChar,10),
                new SqlParameter("@PAJ004",SqlDbType.NVarChar,20),
                new SqlParameter("@PAJ005",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ006",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ007",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ008",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ009",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ010",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ011",SqlDbType.DateTime),
                new SqlParameter("@PAJ012",SqlDbType.NVarChar,20),
                new SqlParameter("@PAJ014",SqlDbType.NVarChar,20),
                new SqlParameter("@PAJ015",SqlDbType.NVarChar,20),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _model . PAJ002;
            parameter [ 1 ] . Value = _model . PAJ004;
            parameter [ 2 ] . Value = _model . PAJ005;
            parameter [ 3 ] . Value = _model . PAJ006;
            parameter [ 4 ] . Value = _model . PAJ007;
            parameter [ 5 ] . Value = _model . PAJ008;
            parameter [ 6 ] . Value = _model . PAJ009;
            parameter [ 7 ] . Value = _model . PAJ010;
            parameter [ 8 ] . Value = _model . PAJ011;
            parameter [ 9 ] . Value = _model . PAJ012;
            parameter [ 10 ] . Value = _model . PAJ014;
            parameter [ 11 ] . Value = _model . PAJ015;
            parameter [ 12 ] . Value = _model . idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Exists ( CarpenterEntity . PAIJEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM MOXPAJ " );
            strSql . Append ( "WHERE PAJ004=@PAJ004 AND " );
            strSql . Append ( "PAJ005=@PAJ005 AND " );
            strSql . Append ( "PAJ006=@PAJ006 AND " );
            strSql . Append ( "PAJ007=@PAJ007 AND " );
            strSql . Append ( "PAJ008=@PAJ008 AND " );
            strSql . Append ( "PAJ009=@PAJ009 AND " );
            strSql . Append ( "PAJ010=@PAJ010 AND " );
            strSql . Append ( "PAJ014=@PAJ014 " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PAJ004",SqlDbType.NVarChar,20),
                new SqlParameter("@PAJ005",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ006",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ007",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ008",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ009",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ010",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ014",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PAJ004;
            parameter [ 1 ] . Value = _model . PAJ005;
            parameter [ 2 ] . Value = _model . PAJ006;
            parameter [ 3 ] . Value = _model . PAJ007;
            parameter [ 4 ] . Value = _model . PAJ008;
            parameter [ 5 ] . Value = _model . PAJ009;
            parameter [ 6 ] . Value = _model . PAJ010;
            parameter [ 7 ] . Value = _model . PAJ014;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 增加油漆工序表
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int AddPaintWorkProcedure ( CarpenterEntity . PAIJEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXPAJ (" );
            strSql . Append ( "PAJ002,PAJ004,PAJ005,PAJ006,PAJ007,PAJ008,PAJ009,PAJ010,PAJ011,PAJ012,PAJ013,PAJ014,PAJ015) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PAJ002,@PAJ004,@PAJ005,@PAJ006,@PAJ007,@PAJ008,@PAJ009,@PAJ010,@PAJ011,@PAJ012,@PAJ013,@PAJ014,@PAJ015); " );
            strSql . Append ( "SELECT SCOPE_IDENTITY();" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PAJ002",SqlDbType.NVarChar,20),
                new SqlParameter("@PAJ004",SqlDbType.NVarChar,20),
                new SqlParameter("@PAJ005",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ006",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ007",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ008",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ009",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ010",SqlDbType.Decimal,18),
                new SqlParameter("@PAJ011",SqlDbType.DateTime),
                new SqlParameter("@PAJ012",SqlDbType.NVarChar,20),
                new SqlParameter("@PAJ013",SqlDbType.Bit),
                new SqlParameter("@PAJ014",SqlDbType.NVarChar,20),
                new SqlParameter("@PAJ015",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . PAJ002;
            parameter [ 1 ] . Value = _model . PAJ004;
            parameter [ 2 ] . Value = _model . PAJ005;
            parameter [ 3 ] . Value = _model . PAJ006;
            parameter [ 4 ] . Value = _model . PAJ007;
            parameter [ 5 ] . Value = _model . PAJ008;
            parameter [ 6 ] . Value = _model . PAJ009;
            parameter [ 7 ] . Value = _model . PAJ010;
            parameter [ 8 ] . Value = _model . PAJ011;
            parameter [ 9 ] . Value = _model . PAJ012;
            parameter [ 10 ] . Value = _model . PAJ013;
            parameter [ 11 ] . Value = _model . PAJ014;
            parameter [ 12 ] . Value = _model . PAJ015;

            return SqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取分类
        /// </summary>
        /// <param name="procudtNum"></param>
        /// <returns></returns>
        public string GetClass ( string procudtNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT OPI010 FROM MOXOPI " );
            strSql . Append ( "WHERE OPI001=@OPI001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@OPI001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = procudtNum;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "OPI010" ] . ToString ( ) ) )
                    return string . Empty;
                else
                    return dt . Rows [ 0 ] [ "OPI010" ] . ToString ( );
            }
            else
                return string . Empty;
        }

    }
}
