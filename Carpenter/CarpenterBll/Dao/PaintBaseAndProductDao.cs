using System;
using System . Collections . Generic;
using System . Data;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class PaintBaseAndProductDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView (string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,PBA001,PBA002,PBA003,CONVERT(FLOAT,PBA004) PBA004,PBA005 FROM MOXPBA  WHERE {0} ORDER BY PBA001" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Delete ( List<string> idxList )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            foreach(string s in idxList)
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "DELETE FROM MOXPBA WHERE idx={0}" ,s );
                SQLString . Add ( strSql . ToString ( ) );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public bool Save ( DataTable tableView)
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            CarpenterEntity . PaintBaseAndProductEntity model = new CarpenterEntity . PaintBaseAndProductEntity ( );
            for ( int i = 0 ; i < tableView . Rows . Count ; i++ )
            {
                model . idx = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableView . Rows [ i ] [ "idx" ] . ToString ( ) );
                model . PBA001 = tableView . Rows [ i ] [ "PBA001" ] . ToString ( );
                model . PBA002 = tableView . Rows [ i ] [ "PBA002" ] . ToString ( );
                model . PBA003 = tableView . Rows [ i ] [ "PBA003" ] . ToString ( );
                model . PBA004 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "PBA004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableView . Rows [ i ] [ "PBA004" ] . ToString ( ) );
                model . PBA005 = tableView . Rows [ i ] [ "PBA005" ] . ToString ( );
                if ( model . idx > 0 )
                    Edit ( SQLString ,strSql ,model );
                else
                    Add ( SQLString ,strSql ,model );
            }


            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void Add ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PaintBaseAndProductEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into MOXPBA(" );
            strSql . Append ( "PBA001,PBA002,PBA003,PBA004,PBA005)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@PBA001,@PBA002,@PBA003,@PBA004,@PBA005)" );
            strSql . Append ( ";select @@IDENTITY" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PBA001", SqlDbType.NVarChar,50),
                    new SqlParameter("@PBA002", SqlDbType.NVarChar,50),
                    new SqlParameter("@PBA003", SqlDbType.NVarChar,50),
                    new SqlParameter("@PBA004", SqlDbType.Decimal,9),
                    new SqlParameter("@PBA005", SqlDbType.NVarChar,50)
            };
            parameters [ 0 ] . Value = model . PBA001;
            parameters [ 1 ] . Value = model . PBA002;
            parameters [ 2 ] . Value = model . PBA003;
            parameters [ 3 ] . Value = model . PBA004;
            parameters [ 4 ] . Value = model . PBA005;
            SQLString . Add ( strSql ,parameters );
        }

        void Edit ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PaintBaseAndProductEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXPBA set " );
            strSql . Append ( "PBA001=@PBA001," );
            strSql . Append ( "PBA002=@PBA002," );
            strSql . Append ( "PBA003=@PBA003," );
            strSql . Append ( "PBA004=@PBA004," );
            strSql . Append ( "PBA005=@PBA005 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PBA001", SqlDbType.NVarChar,50),
                    new SqlParameter("@PBA002", SqlDbType.NVarChar,50),
                    new SqlParameter("@PBA003", SqlDbType.NVarChar,50),
                    new SqlParameter("@PBA004", SqlDbType.Decimal,9),
                    new SqlParameter("@PBA005", SqlDbType.NVarChar,50),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . PBA001;
            parameters [ 1 ] . Value = model . PBA002;
            parameters [ 2 ] . Value = model . PBA003;
            parameters [ 3 ] . Value = model . PBA004;
            parameters [ 4 ] . Value = model . PBA005;
            parameters [ 5 ] . Value = model . idx;
            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        public DataTable getTablePro ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT OPI001 PBA001,OPI002 PBA002,OPI003 PBA005 FROM MOXOPI WHERE OPI011=0" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取此系列的
        /// </summary>
        /// <param name="xl"></param>
        /// <returns></returns>
        public DataTable getColumns ( string xl )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT PBA005,PBA003 FROM MOXPBA WHERE PBA005='{0}' ORDER BY PBA003" ,xl );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
