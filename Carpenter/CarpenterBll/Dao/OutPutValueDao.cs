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
    public class OutPutValueDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable getTableView ( int year,int month )
        {
            Hashtable SQLString = new Hashtable ( );
            CarpenterEntity . OutPutValueEntity model = new CarpenterEntity . OutPutValueEntity ( );
            model . OPV001 = year;
            model . OPV002 = month;

            List<int> modelList = getModel ( year ,month );
            if ( modelList == null )
                modelList = new List<int> ( );

            #region 备料
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DAY(PDK012) D1,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PDK007*ISNULL(OPI004,0)))) A1 FROM MOXOPI B  INNER JOIN MOXPDK A ON A.PDK003=B.OPI001 INNER JOIN MOXPST C ON A.PDK002=C.PST001 AND A.PDK003=C.PST002 WHERE YEAR(PDK012)={0} AND MONTH(PDK012)={1} GROUP BY DAY(PDK012)" ,year ,month );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table != null && table . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    model . OPV003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "D1" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "D1" ] . ToString ( ) );
                    model . OPV004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "A1" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "A1" ] . ToString ( ) );
                    if ( model . OPV004 != 0 )
                    {
                        if ( modelList . Exists ( x => x == model . OPV003 ) )
                            EditBL ( SQLString ,strSql ,model );
                        else
                            AddBL ( SQLString ,strSql ,model );
                    }
                }
            }
            #endregion

            #region 机加工
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                modelList= getModel ( year ,month );
                if ( modelList == null )
                    modelList = new List<int> ( );

                SQLString . Clear ( );
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "SELECT DAY(PME012) D2,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PME007*ISNULL(OPI004,0)))) A2 FROM MOXPME A INNER JOIN MOXOPI B ON A.PME003=B.OPI001 INNER JOIN MOXPST C ON A.PME002=C.PST001 AND A.PME003=C.PST002 WHERE YEAR(PME012)={0} AND MONTH(PME012)={1} GROUP BY DAY(PME012)" ,year ,month );

                table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( table != null && table . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < table . Rows . Count ; i++ )
                    {
                        model . OPV003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "D2" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "D2" ] . ToString ( ) );
                        model . OPV005 = string . IsNullOrEmpty ( table . Rows [ i ] [ "A2" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "A2" ] . ToString ( ) );
                        if ( model . OPV005 != 0 )
                        {
                            if ( modelList . Exists ( x => x == model . OPV003 ) )
                                EditJ ( SQLString ,strSql ,model );
                            else
                                AddJ ( SQLString ,strSql ,model );
                        }
                    }
                }
            }
            #endregion

            #region 组装
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                modelList = getModel ( year ,month );
                if ( modelList == null )
                    modelList = new List<int> ( );
                SQLString . Clear ( );
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "SELECT DAY(PLF012) D3,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PLF007*ISNULL(OPI004,0)))) A3 FROM MOXPLF A INNER JOIN MOXOPI B ON A.PLF003=B.OPI001 INNER JOIN MOXPAS C ON A.PLF002=C.PAS001 AND A.PLF003=C.PAS002 WHERE YEAR(PLF012)={0} AND MONTH(PLF012)={1} GROUP BY DAY(PLF012)" ,year ,month );

                table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( table != null && table . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < table . Rows . Count ; i++ )
                    {
                        model . OPV003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "D3" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "D3" ] . ToString ( ) );
                        model . OPV006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "A3" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "A3" ] . ToString ( ) );
                        if ( model . OPV006 != 0 )
                        {
                            if ( modelList . Exists ( x => x == model . OPV003 ) )
                                EditZ ( SQLString ,strSql ,model );
                            else
                                AddZ ( SQLString ,strSql ,model );
                        }
                    }
                }
            }
            #endregion

            #region 油漆
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                modelList = getModel ( year ,month );
                if ( modelList == null )
                    modelList = new List<int> ( );
                SQLString . Clear ( );
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "SELECT DAY(PWF012) D4,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PWF007*ISNULL(OPI004,0)))) A4,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PWF008*ISNULL(OPI004,0)))) A5,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PWF010*ISNULL(OPI004,0)))) A6,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PWF016*ISNULL(OPI004,0)))) A7 FROM MOXPWF A INNER JOIN MOXOPI B ON A.PWF003=B.OPI001  INNER JOIN MOXPDP C ON A.PWF002=C.PDP001 AND A.PWF003=C.PDP002 WHERE YEAR(PWF012)={0} AND MONTH(PWF012)={1}  GROUP BY DAY(PWF012)" ,year ,month );

                table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( table != null && table . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < table . Rows . Count ; i++ )
                    {
                        model . OPV003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "D4" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "D4" ] . ToString ( ) );
                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "A4" ] . ToString ( ) ) )
                            model . OPV007 = null;
                        else
                            model . OPV007 = Convert . ToDecimal ( table . Rows [ i ] [ "A4" ] . ToString ( ) );
                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "A5" ] . ToString ( ) ) )
                            model . OPV008 = null;
                        else
                            model . OPV008 = Convert . ToDecimal ( table . Rows [ i ] [ "A5" ] . ToString ( ) );
                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "A6" ] . ToString ( ) ) )
                            model . OPV009 = null;
                        else
                            model . OPV009 = Convert . ToDecimal ( table . Rows [ i ] [ "A6" ] . ToString ( ) );
                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "A7" ] . ToString ( ) ) )
                            model . OPV010 = null;
                        else
                            model . OPV010 = Convert . ToDecimal ( table . Rows [ i ] [ "A7" ] . ToString ( ) );

                        if ( model . OPV007 == 0 )
                            model . OPV007 = null;
                        if ( model . OPV008 == 0 )
                            model . OPV008 = null;
                        if ( model . OPV009 == 0 )
                            model . OPV009 = null;
                        if ( model . OPV010 == 0 )
                            model . OPV010 = null;

                        if ( model . OPV007 != null || model . OPV008 != null || model . OPV009 != null || model . OPV010 != null )
                        {
                            if ( modelList . Exists ( x => x == model . OPV003 ) )
                                EditY ( SQLString ,strSql ,model );
                            else
                                AddY ( SQLString ,strSql ,model );
                        }
                    }
                }
            }
            #endregion

            #region 断料
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                modelList = getModel ( year ,month );
                if ( modelList == null )
                    modelList = new List<int> ( );
                SQLString . Clear ( );
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "SELECT DAY(PDW012) D8,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),SUM(PDW007*ISNULL(OPI004,0)))) A8 FROM MOXPDW A INNER JOIN MOXOPI B ON A.PDW003=B.OPI001 INNER JOIN MOXPST C ON A.PDW002=C.PST001 AND A.PDW003=C.PST002 WHERE YEAR(PDW012)={0} AND MONTH(PDW012)={1} GROUP BY DAY(PDW012)" ,year ,month );

                table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( table != null && table . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < table . Rows . Count ; i++ )
                    {
                        model . OPV003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "D8" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "D8" ] . ToString ( ) );
                        model . OPV011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "A8" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "A8" ] . ToString ( ) );
                        if ( model . OPV011 != 0 )
                        {
                            if ( modelList . Exists ( x => x == model . OPV003 ) )
                                EditD ( SQLString ,strSql ,model );
                            else
                                AddD ( SQLString ,strSql ,model );
                        }
                    }
                }
            }
            #endregion

            SqlHelper . ExecuteSqlTran ( SQLString );

            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT OPV001,OPV002,OPV003,OPV004,OPV005,OPV006,OPV007,OPV008,OPV009,OPV010,OPV011 FROM MOXOPV WHERE OPV001={0} AND OPV002={1} ORDER BY OPV001,OPV002,OPV003" ,year ,month );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public List<int> getModel ( int year ,int month )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT OPV003 FROM MOXOPV WHERE OPV001={0} AND OPV002={1}" ,year ,month );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table != null && table . Rows . Count > 0 )
            {
                List<int> modelList = new List<int> ( );
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    modelList . Add ( string . IsNullOrEmpty ( table . Rows [ i ] [ "OPV003" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "OPV003" ] . ToString ( ) ) );
                }
                return modelList;
            }
            else
                return null;
        }

        void AddBL ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . OutPutValueEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into MOXOPV(" );
            strSql . Append ( "OPV001,OPV002,OPV003,OPV004)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@OPV001,@OPV002,@OPV003,@OPV004)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@OPV001", SqlDbType.Int,4),
                    new SqlParameter("@OPV002", SqlDbType.Int,4),
                    new SqlParameter("@OPV003", SqlDbType.Int,4),
                    new SqlParameter("@OPV004", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . OPV001;
            parameters [ 1 ] . Value = model . OPV002;
            parameters [ 2 ] . Value = model . OPV003;
            parameters [ 3 ] . Value = model . OPV004;

            SQLString . Add ( strSql ,parameters );
        }

        void EditBL ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . OutPutValueEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXOPV set " );
            strSql . Append ( "OPV004=@OPV004 " );
            strSql . Append ( " where OPV001=@OPV001 and " );
            strSql . Append ( "OPV002=@OPV002 and " );
            strSql . Append ( "OPV003=@OPV003" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@OPV001", SqlDbType.Int,4),
                    new SqlParameter("@OPV002", SqlDbType.Int,4),
                    new SqlParameter("@OPV003", SqlDbType.Int,4),
                    new SqlParameter("@OPV004", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . OPV001;
            parameters [ 1 ] . Value = model . OPV002;
            parameters [ 2 ] . Value = model . OPV003;
            parameters [ 3 ] . Value = model . OPV004;

            SQLString . Add ( strSql ,parameters );
        }

        void AddJ ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . OutPutValueEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into MOXOPV(" );
            strSql . Append ( "OPV001,OPV002,OPV003,OPV005)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@OPV001,@OPV002,@OPV003,@OPV005)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@OPV001", SqlDbType.Int,4),
                    new SqlParameter("@OPV002", SqlDbType.Int,4),
                    new SqlParameter("@OPV003", SqlDbType.Int,4),
                    new SqlParameter("@OPV005", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . OPV001;
            parameters [ 1 ] . Value = model . OPV002;
            parameters [ 2 ] . Value = model . OPV003;
            parameters [ 3 ] . Value = model . OPV005;

            SQLString . Add ( strSql ,parameters );
        }

        void EditJ ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . OutPutValueEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXOPV set " );
            strSql . Append ( "OPV005=@OPV005 " );
            strSql . Append ( " where OPV001=@OPV001 and " );
            strSql . Append ( "OPV002=@OPV002 and " );
            strSql . Append ( "OPV003=@OPV003" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@OPV001", SqlDbType.Int,4),
                    new SqlParameter("@OPV002", SqlDbType.Int,4),
                    new SqlParameter("@OPV003", SqlDbType.Int,4),
                    new SqlParameter("@OPV005", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . OPV001;
            parameters [ 1 ] . Value = model . OPV002;
            parameters [ 2 ] . Value = model . OPV003;
            parameters [ 3 ] . Value = model . OPV005;

            SQLString . Add ( strSql ,parameters );
        }

        void AddZ ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . OutPutValueEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into MOXOPV(" );
            strSql . Append ( "OPV001,OPV002,OPV003,OPV006)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@OPV001,@OPV002,@OPV003,@OPV006)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@OPV001", SqlDbType.Int,4),
                    new SqlParameter("@OPV002", SqlDbType.Int,4),
                    new SqlParameter("@OPV003", SqlDbType.Int,4),
                    new SqlParameter("@OPV006", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . OPV001;
            parameters [ 1 ] . Value = model . OPV002;
            parameters [ 2 ] . Value = model . OPV003;
            parameters [ 3 ] . Value = model . OPV006;

            SQLString . Add ( strSql ,parameters );
        }

        void EditZ ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . OutPutValueEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXOPV set " );
            strSql . Append ( "OPV006=@OPV006 " );
            strSql . Append ( " where OPV001=@OPV001 and " );
            strSql . Append ( "OPV002=@OPV002 and " );
            strSql . Append ( "OPV003=@OPV003" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@OPV001", SqlDbType.Int,4),
                    new SqlParameter("@OPV002", SqlDbType.Int,4),
                    new SqlParameter("@OPV003", SqlDbType.Int,4),
                    new SqlParameter("@OPV006", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . OPV001;
            parameters [ 1 ] . Value = model . OPV002;
            parameters [ 2 ] . Value = model . OPV003;
            parameters [ 3 ] . Value = model . OPV006;

            SQLString . Add ( strSql ,parameters );
        }

        void AddY ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . OutPutValueEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into MOXOPV(" );
            strSql . Append ( "OPV001,OPV002,OPV003,OPV007,OPV008,OPV009,OPV010)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@OPV001,@OPV002,@OPV003,@OPV007,@OPV008,@OPV009,@OPV010)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@OPV001", SqlDbType.Int,4),
                    new SqlParameter("@OPV002", SqlDbType.Int,4),
                    new SqlParameter("@OPV003", SqlDbType.Int,4),
                    new SqlParameter("@OPV007", SqlDbType.Decimal,9),
                    new SqlParameter("@OPV008", SqlDbType.Decimal,9),
                    new SqlParameter("@OPV009", SqlDbType.Decimal,9),
                    new SqlParameter("@OPV010", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . OPV001;
            parameters [ 1 ] . Value = model . OPV002;
            parameters [ 2 ] . Value = model . OPV003;
            parameters [ 3 ] . Value = model . OPV007;
            parameters [ 4 ] . Value = model . OPV008;
            parameters [ 5 ] . Value = model . OPV009;
            parameters [ 6 ] . Value = model . OPV010;

            SQLString . Add ( strSql ,parameters );
        }

        void EditY ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . OutPutValueEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXOPV set " );
            strSql . Append ( "OPV007=@OPV007," );
            strSql . Append ( "OPV008=@OPV008," );
            strSql . Append ( "OPV009=@OPV009," );
            strSql . Append ( "OPV010=@OPV010 " );
            strSql . Append ( " where OPV001=@OPV001 and " );
            strSql . Append ( "OPV002=@OPV002 and " );
            strSql . Append ( "OPV003=@OPV003" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@OPV001", SqlDbType.Int,4),
                    new SqlParameter("@OPV002", SqlDbType.Int,4),
                    new SqlParameter("@OPV003", SqlDbType.Int,4),
                    new SqlParameter("@OPV007", SqlDbType.Decimal,9),
                    new SqlParameter("@OPV008", SqlDbType.Decimal,9),
                    new SqlParameter("@OPV009", SqlDbType.Decimal,9),
                    new SqlParameter("@OPV010", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . OPV001;
            parameters [ 1 ] . Value = model . OPV002;
            parameters [ 2 ] . Value = model . OPV003;
            parameters [ 3 ] . Value = model . OPV007;
            parameters [ 4 ] . Value = model . OPV008;
            parameters [ 5 ] . Value = model . OPV009;
            parameters [ 6 ] . Value = model . OPV010;

            SQLString . Add ( strSql ,parameters );
        }

        void AddD ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . OutPutValueEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into MOXOPV(" );
            strSql . Append ( "OPV001,OPV002,OPV003,OPV011)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@OPV001,@OPV002,@OPV003,@OPV011)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@OPV001", SqlDbType.Int,4),
                    new SqlParameter("@OPV002", SqlDbType.Int,4),
                    new SqlParameter("@OPV003", SqlDbType.Int,4),
                    new SqlParameter("@OPV011", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . OPV001;
            parameters [ 1 ] . Value = model . OPV002;
            parameters [ 2 ] . Value = model . OPV003;
            parameters [ 3 ] . Value = model . OPV011;

            SQLString . Add ( strSql ,parameters );
        }

        void EditD ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . OutPutValueEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update MOXOPV set " );
            strSql . Append ( "OPV011=@OPV011 " );
            strSql . Append ( " where OPV001=@OPV001 and " );
            strSql . Append ( "OPV002=@OPV002 and " );
            strSql . Append ( "OPV003=@OPV003" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@OPV001", SqlDbType.Int,4),
                    new SqlParameter("@OPV002", SqlDbType.Int,4),
                    new SqlParameter("@OPV003", SqlDbType.Int,4),
                    new SqlParameter("@OPV011", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . OPV001;
            parameters [ 1 ] . Value = model . OPV002;
            parameters [ 2 ] . Value = model . OPV003;
            parameters [ 3 ] . Value = model . OPV011;

            SQLString . Add ( strSql ,parameters );
        }

    }
}
