using System;
using System . Collections . Generic;
using System . Data;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{

    public class PiceWageStatisticalTableDao
    {
        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <returns></returns>
        public DataTable getTableUser ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PRD004,PRD005 FROM MOXPRD ORDER BY PRD004 " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
         /// get data from database
         /// </summary>
        DataTable getTableGenerate ( string yearAndMonth )
        {
            //string year = yearAndMonth . Substring ( 0 ,4 );
            //string month = yearAndMonth . Substring ( 4 ,2 );
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT PRD005,PRD004,PRD007,PRD008,PRD009,PRD010,CUU003,PRD013,PRD011,PRD034,PRD032,PRD003,PRD033,PRD025,PRD026,PRD019,PRD023,PRD022,PRD015,PRD036,PRD037,PRD038,PRD039,PRD040,PRD041 FROM MOXPRD A LEFT JOIN MOXCUU B ON A.PRD007=B.CUU001 AND A.PRD008=B.CUU002 " );
            //strSql . AppendFormat ( "WHERE YEAR(PRD013)={0} AND MONTH(PRD013)={1} AND PRD020=1 AND PRD021=0 AND PRD014=1" ,year ,month );
            strSql . Append ( "WITH CET AS (" );
            strSql . AppendFormat ( "SELECT PRD001,PRD002,PRD043,PRD005,PRD004,PRD007,PRD008,PRD009,PRD010,PRD042,PRD013,PRD011,PRD032,PRD003,PRD033,PRD025,PRD026,PRD034,PRD019,PRD023,PRD022,PRD015 FROM MOXPRD WHERE  PRD020=1 AND PRD021=0 AND PRD014=0 AND (PRD034!='' AND PRD034 IS NOT NULL) AND PRD019!=0 AND {0}" ,yearAndMonth );//YEAR(PRD013)={0} AND MONTH(PRD013)={1} AND
            strSql . Append ( "UNION ALL " );
            strSql . AppendFormat ( "SELECT PRD001,PRD002,PRD043,PRD005,PRD004,PRD007,PRD008,PRD009,PRD010,PRD042,PRD013,PRD011,PRD032,PRD003,PRD033,PRD025,PRD026,PRD036,PRD037,PRD023,PRD022,PRD015 FROM MOXPRD WHERE  PRD020=1 AND PRD021=0 AND PRD014=0 AND (PRD036!='' AND PRD036 IS NOT NULL) AND PRD037!=0 AND {0}" ,yearAndMonth );//YEAR(PRD013)={0} AND MONTH(PRD013)={1} AND
            strSql . Append ( "UNION ALL " );
            strSql . AppendFormat ( "SELECT PRD001,PRD002,PRD043,PRD005,PRD004,PRD007,PRD008,PRD009,PRD010,PRD042,PRD013,PRD011,PRD032,PRD003,PRD033,PRD025,PRD026,PRD038,PRD039,PRD023,PRD022,PRD015 FROM MOXPRD WHERE  PRD020=1 AND PRD021=0 AND PRD014=0 AND (PRD038!='' AND PRD038 IS NOT NULL) AND PRD039!=0 AND {0}" ,yearAndMonth );//YEAR(PRD013)={0} AND MONTH(PRD013)={1} AND
            strSql . Append ( "UNION ALL " );
            strSql . AppendFormat ( "SELECT PRD001,PRD002,PRD043,PRD005,PRD004,PRD007,PRD008,PRD009,PRD010,PRD042,PRD013,PRD011,PRD032,PRD003,PRD033,PRD025,PRD026,PRD040,PRD041,PRD023,PRD022,PRD015 FROM MOXPRD WHERE  PRD020=1 AND PRD021=0 AND PRD014=0 AND (PRD040!='' AND PRD040 IS NOT NULL) AND PRD041!=0 AND {0}" ,yearAndMonth );//YEAR(PRD013)={0} AND MONTH(PRD013)={1} AND
            strSql . Append ( ") " );
            strSql . Append ( "SELECT PRD001,PRD002,PRD043,PRD005,PRD004,PRD007,PRD008,PRD009,PRD010,PRD042,PRD013,PRD011,PRD032,PRD003,PRD033,PRD025,PRD026,PRD034,SUM(PRD019) PRD019,PRD023,PRD022,PRD015 FROM CET GROUP BY PRD001,PRD002,PRD043,PRD005,PRD004,PRD007,PRD008,PRD009,PRD010,PRD042,PRD013,PRD011,PRD032,PRD003,PRD033,PRD025,PRD026,PRD034,PRD022,PRD015,PRD023" );
            //WHERE PRD007='1815' AND PRD008='51-1.007.04.001' AND PRD011='中柱' AND PRD034='1540*35/25*35/25' AND PRD003='平刨（双面）'

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        private  string xLen = 0 . ToString ( ), xWidth = 0 . ToString ( ), xHeigh = 0 . ToString ( );

        /// <summary>
        /// add data to database
        /// </summary>
        /// <param name="yearAndMonth"></param>
        /// <returns></returns>
        public int Generate ( string yearAndMonth )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            CarpenterEntity . PiceWageStatisticalTableEntity _model = new CarpenterEntity . PiceWageStatisticalTableEntity ( );

            DataTable table = getTableGenerate ( yearAndMonth );
            if ( table != null && table . Rows . Count > 0 )
            {
                int zb = 0;
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    xLen = 0 . ToString ( );
                    xWidth = 0 . ToString ( );
                    xHeigh = 0 . ToString ( );

                    _model . PWS001 = table . Rows [ i ] [ "PRD004" ] . ToString ( );
                    _model . PWS002 = table . Rows [ i ] [ "PRD005" ] . ToString ( );
                    _model . PWS003 = table . Rows [ i ] [ "PRD007" ] . ToString ( );
                    _model . PWS004 = table . Rows [ i ] [ "PRD008" ] . ToString ( );
                    _model . PWS005 = table . Rows [ i ] [ "PRD009" ] . ToString ( );
                    _model . PWS006 = table . Rows [ i ] [ "PRD010" ] . ToString ( );
                    _model . PWS007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PRD042" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PRD042" ] . ToString ( ) );
                    if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PRD013" ] . ToString ( ) ) )
                        _model . PWS008 = null;
                    else
                        _model . PWS008 = Convert . ToDateTime ( table . Rows [ i ] [ "PRD013" ] . ToString ( ) );
                    _model . PWS009 = table . Rows [ i ] [ "PRD011" ] . ToString ( );
                    _model . PWS010 = table . Rows [ i ] [ "PRD034" ] . ToString ( );

                    if ( !Exists ( _model ) )
                    {
                        _model . PWS011 = table . Rows [ i ] [ "PRD032" ] . ToString ( );
                        _model . PWS012 = table . Rows [ i ] [ "PRD003" ] . ToString ( );
                        _model . PWS013 = table . Rows [ i ] [ "PRD033" ] . ToString ( );

                        _model . PWS016 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PRD025" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PRD025" ] . ToString ( ) );
                        //_model . PWS020 = table . Rows [ i ] [ "PRD005" ] . ToString ( );
                        _model . PWS021 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PRD019" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PRD019" ] . ToString ( ) );
                        _model . PWS023 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PRD023" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PRD023" ] . ToString ( ) );
                        _model . PWS024 = table . Rows [ i ] [ "PRD022" ] . ToString ( );
                        _model . PWS025 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PRD043" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PRD043" ] . ToString ( ) );
                        _model . PWS027 = table . Rows [ i ] [ "PRD026" ] . ToString ( );
                        zb = string . IsNullOrEmpty ( table . Rows [ i ] [ "PRD015" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PRD015" ] . ToString ( ) );
                        _model . PWS014 = 0;
                        _model . PWS015 = 0;
                        _model . PWS028 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PRD013" ] . ToString ( ) ) == true ? DateTime . MinValue . ToString ( "yyyyMMdd" ) : Convert . ToDateTime ( table . Rows [ i ] [ "PRD013" ] ) . ToString ( "yyyyMMdd" );
                        _model . PWS029 = _model . PWS030 = _model . PWS031 = _model . PWS032 = 0;
                        _model . PWS022 = 0;
                        _model . PWS033 = table . Rows [ i ] [ "PRD001" ] . ToString ( );
                        _model . PWS034 = table . Rows [ i ] [ "PRD002" ] . ToString ( );
                        _model . PWS035 = 1M;

                        calculationOfWages ( _model ,zb ,SQLString ,strSql );
                    }
                }
            }
            else
                return 0;

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
                return 1;
            else
                return 2;

        }
        
        void calculationOfWages ( CarpenterEntity . PiceWageStatisticalTableEntity _model ,int zb,Hashtable SQLString,StringBuilder strSql)
        {
            getLWH ( _model . PWS010 );

            if ( xLen . Contains ( "Φ" ) || xWidth . Contains ( "Φ" ) )
            {
                if ( xLen . Contains ( "Φ" ) && !xWidth . Contains ( "Φ" ) )
                {
                    xHeigh = xWidth;
                    xLen = xWidth = xLen . Replace ( "Φ" ,"" ) . Trim ( );

                    //_model . PWS017 = Convert . ToDecimal ( Math . PI * Math . Pow ( ( Convert . ToDouble ( xLen ) / 1000 ) ,2 ) * Convert . ToDouble ( xWidth ) / 1000 );
                    _model . PWS017 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xWidth ) / 1000 * Convert . ToDecimal ( xHeigh ) / 1000 );
                    //_model . PWS018 = Convert . ToDecimal ( Math . PI * Convert . ToDouble ( xLen ) / 1000 );

                    if ( _model . PWS013 . Equals ( "长宽平方" ) )
                        _model . PWS018 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xWidth ) / 1000 );
                    else if ( _model . PWS013 . Equals ( "长厚平方" ) )
                        _model . PWS018 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xHeigh ) / 1000 );
                    else if ( _model . PWS013 . Equals ( "两面平方" ) )
                        _model . PWS018 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xHeigh ) / 1000 + Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xWidth ) / 1000 );
                    else
                        _model . PWS018 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xWidth ) / 1000 );

                    _model . PWS019 = Convert . ToDecimal ( xLen ) / 1000;
                    //_model . PWS019 = 0;
                }
                else if ( xWidth . Contains ( "Φ" ) && !xLen . Contains ( "Φ" ) )
                {
                    xHeigh = xLen;

                    xLen = xWidth = xWidth . Replace ( "Φ" ,"" ) . Trim ( );
                    //_model . PWS017 = Convert . ToDecimal ( Math . PI * Math . Pow ( ( Convert . ToDouble ( xWidth ) / 1000 ) ,2 ) * Convert . ToDouble ( xLen ) / 1000 );
                    _model . PWS017 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xWidth ) / 1000 * Convert . ToDecimal ( xHeigh ) / 1000 );
                    //_model . PWS018 = Convert . ToDecimal ( Math . PI * Convert . ToDouble ( xWidth ) / 1000 );
                    //_model . PWS019 = 0;
                    if ( _model . PWS013 . Equals ( "长宽平方" ) )
                        _model . PWS018 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xWidth ) / 1000 );
                    else if ( _model . PWS013 . Equals ( "长厚平方" ) )
                        _model . PWS018 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xHeigh ) / 1000 );
                    else if ( _model . PWS013 . Equals ( "两面平方" ) )
                        _model . PWS018 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xHeigh ) / 1000 + Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xWidth ) / 1000 );
                    else
                        _model . PWS018 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xWidth ) / 1000 );

                    _model . PWS019 = Convert . ToDecimal ( xLen ) / 1000;
                }
                else if ( xWidth . Contains ( "Φ" ) && xLen . Contains ( "Φ" ) )
                {
                    //应该不可能吧，如果是，逻辑咋写
                }
            }
            else
            {
                _model . PWS017 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xWidth ) / 1000 * Convert . ToDecimal ( xHeigh ) / 1000 );
                if ( _model . PWS013 . Equals ( "长宽平方" ) )
                    _model . PWS018 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xWidth ) / 1000 );
                else if ( _model . PWS013 . Equals ( "长厚平方" ) )
                    _model . PWS018 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xHeigh ) / 1000 );
                else if ( _model . PWS013 . Equals ( "两面平方" ) )
                    _model . PWS018 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xHeigh ) / 1000 + Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xWidth ) / 1000 );
                else if ( _model . PWS013 . Equals ( ColumnValues . lenAndWith ) )
                    _model . PWS018 = Convert . ToDecimal ( xLen ) / 1000 + Convert . ToDecimal ( xWidth ) / 1000;
                else if ( _model . PWS013 . Equals ( ColumnValues . lenAndTwoWith ) )
                    _model . PWS018 = Convert . ToDecimal ( xLen ) / 1000 + Convert . ToDecimal ( xWidth ) / 1000 * 2;
                else if ( _model . PWS013 . Equals ( ColumnValues . twoLenAndTwoWith ) )
                    _model . PWS018 = ( Convert . ToDecimal ( xLen ) / 1000 + Convert . ToDecimal ( xWidth ) / 1000 ) * 2;
                else if ( _model . PWS013 . Equals ( ColumnValues . twoLenAndWith ) )
                    _model . PWS018 = Convert . ToDecimal ( xLen ) / 1000 * 2 + Convert . ToDecimal ( xWidth ) / 1000;
                else
                    _model . PWS018 = Convert . ToDecimal ( Convert . ToDecimal ( xLen ) / 1000 * Convert . ToDecimal ( xWidth ) / 1000 );
                _model . PWS019 = Convert . ToDecimal ( xLen ) / 1000;
            }

            if ( _model . PWS016 > 0 )
                _model . PWS026 = 0;
            else
            {
                DataTable dt = null;

                if ( !_model . PWS013 . Equals ( ColumnValues . twoLenAndTwoWith ) && !_model . PWS013 . Equals ( ColumnValues . twoLenAndWith ) && !_model . PWS013 . Equals ( ColumnValues . lenAndTwoWith ) && !_model . PWS013 . Equals ( ColumnValues . lenAndWith ) )
                    dt = getSpace ( zb ,xLen ,xWidth ,xHeigh );
                else
                    dt = getSpaceForOtherCalcu ( zb ,xLen ,xWidth ,xHeigh );

                if ( dt != null && dt . Rows . Count > 0 )
                {
                    CarpenterEntity . AruEntity _modelOne = new CarpenterEntity . AruEntity ( );
                    _modelOne . ARU002 = dt . Rows [ 0 ] [ "PRE002" ] . ToString ( );

                    _model . PWS014 = string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PRE003" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "PRE003" ] . ToString ( ) );
                    _model . PWS015 = string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PRE004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "PRE004" ] . ToString ( ) );
                    _model . PWS029 = string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PRE008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "PRE008" ] . ToString ( ) );
                    _model . PWS030 = string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PRE009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "PRE009" ] . ToString ( ) );
                    _model . PWS031 = string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PRE010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "PRE010" ] . ToString ( ) );
                    _model . PWS032 = string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PRE011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "PRE011" ] . ToString ( ) );
                    _model . PWS022 = string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PRE005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "PRE005" ] . ToString ( ) );
                }
                else
                {
                    CarpenterEntity . AruEntity _modelOne = new CarpenterEntity . AruEntity ( );
                    _modelOne . ARU002 = "";

                    _model . PWS014 = 0;
                    _model . PWS015 = 0;
                    _model . PWS029 = 0;
                    _model . PWS030 = 0;
                    _model . PWS031 = 0;
                    _model . PWS032 = 0;
                    _model . PWS022 = 0;
                }

                _model . PWS018 = Math . Round ( Convert . ToDecimal ( _model . PWS018 ) ,4 );

                if ( _model . PWS013 . Equals ( ColumnValues . cube ) )
                    _model . PWS026 = _model . PWS017 * _model . PWS022 * _model . PWS023 * _model . PWS021;
                else if ( _model . PWS013 . Equals ( ColumnValues . lwSquare ) )
                    _model . PWS026 = _model . PWS018 * _model . PWS022 * _model . PWS023 * _model . PWS021;
                else if ( _model . PWS013 . Equals ( ColumnValues . lhSquare ) )
                    _model . PWS026 = _model . PWS018 * _model . PWS022 * _model . PWS023 * _model . PWS021;
                else if ( _model . PWS013 . Equals ( ColumnValues . lwlhSquare ) )
                    _model . PWS026 = _model . PWS018 * _model . PWS022 * _model . PWS023 * _model . PWS021;
                else if ( _model . PWS013 . Equals ( ColumnValues . lenth ) )
                    _model . PWS026 = _model . PWS019 * _model . PWS022 * _model . PWS023 * _model . PWS021;
                else if ( _model . PWS013 . Equals ( ColumnValues . pieceNum ) )
                    _model . PWS026 = _model . PWS022 * _model . PWS023 * _model . PWS021;
                else if ( _model . PWS013 . Equals ( ColumnValues . timeNum ) )
                    _model . PWS026 = 0;
                else if ( _model . PWS013 . Equals ( ColumnValues . lenAndWith ) || _model . PWS013 . Equals ( ColumnValues . lenAndTwoWith ) || _model . PWS013 . Equals ( ColumnValues . twoLenAndTwoWith ) || _model . PWS013 . Equals ( ColumnValues . twoLenAndWith ) )
                    _model . PWS026 = _model . PWS018 * _model . PWS021 * _model . PWS022 * _model . PWS023;
                else
                    _model . PWS026 = 0;

                _model . PWS026 = Math . Round ( Convert . ToDecimal ( _model . PWS026 ) ,2 );
            }

            
                add_pws ( SQLString ,strSql ,_model );
        }

        void getLWH ( string ge )
        {
            string [ ] spe;
            string len = 0 . ToString ( ), width = 0 . ToString ( ), heigh = 0 . ToString ( );
            decimal resu = 0;

            if ( ge . Contains ( "*" ) )
            {
                spe = ge . Split ( '*' );
                if ( spe . Length >= 3 )
                {
                    len = spe [ 0 ];
                    width = spe [ 1 ];
                    heigh = spe [ 2 ];
                }
                else if ( spe . Length == 2 )
                {
                    len = spe [ 0 ];
                    width = spe [ 1 ];
                    heigh = 0 . ToString ( );
                }
                else if ( spe . Length == 1 )
                {
                    len = spe [ 0 ];
                    width = 0 . ToString ( );
                    heigh = 0 . ToString ( );
                }
                else
                    len = width = heigh = 0 . ToString ( );
            }
            else
                len = width = heigh = 0 . ToString ( );

            if ( !len . Equals ( 0 . ToString ( ) ) )
            {
                foreach ( char c in len )
                {
                    if ( c >= 48 && c <= 57 )
                    {
                        xLen += c . ToString ( );
                    }
                    else if ( c . ToString ( ) . Equals ( "/" ) || c . ToString ( ) . Equals ( "\\" ) || c.ToString().Equals( "Φ" ) || c . ToString ( ) . Equals ( "." ) )
                        xLen += c . ToString ( );
                }

            }
            else
                xLen = 0 . ToString ( );

            if ( !width . Equals ( 0 . ToString ( ) ) )
            {
                foreach ( char c in width )
                {
                    if ( c >= 48 && c <= 57 )
                    {
                        xWidth += c . ToString ( );
                    }
                    else if ( c . ToString ( ) . Equals ( "/" ) || c . ToString ( ) . Equals ( "\\" ) || c . ToString ( ) . Equals ( "Φ" ) || c . ToString ( ) . Equals ( "." ) )
                        xWidth += c . ToString ( );
                }
            }
            else
                xWidth = 0 . ToString ( );

            if ( !heigh . Equals ( 0 . ToString ( ) ) )
            {
                foreach ( char c in heigh )
                {
                    if ( c >= 48 && c <= 57 )
                    {
                        xHeigh += c . ToString ( );
                    }
                    else if ( c . ToString ( ) . Equals ( "/" ) || c . ToString ( ) . Equals ( "\\" ) || c . ToString ( ) . Equals ( "Φ" ) || c . ToString ( ) . Equals ( "." ) )
                        xHeigh += c . ToString ( );

                }
            }
            else
                xHeigh = 0 . ToString ( );

            if ( xLen . Contains ( "\\" ) )
            {
                spe = xLen . Split ( '\\' );
                xLen = string . Empty;
                for ( int k = 0 ; k < spe . Length ; k++ )
                {
                    resu += Convert . ToDecimal ( spe [ k ] );
                }
                resu /= spe . Length;
                xLen = resu . ToString ( );
            }
            resu = 0;
            if ( xLen . Contains ( "/" ) )
            {
                spe = xLen . Split ( '/' );
                xLen = string . Empty;
                for ( int k = 0 ; k < spe . Length ; k++ )
                {
                    resu += Convert . ToDecimal ( spe [ k ] );
                }
                resu /= spe . Length;
                xLen = resu . ToString ( );
            }

            resu = 0;
            if ( xWidth . Contains ( "\\" ) )
            {
                spe = xWidth . Split ( '\\' );
                xWidth = string . Empty;
                for ( int k = 0 ; k < spe . Length ; k++ )
                {
                    resu += Convert . ToDecimal ( spe [ k ] );
                }
                resu /= spe . Length;
                xWidth = resu . ToString ( );
            }
            resu = 0;
            if ( xWidth . Contains ( "/" ) )
            {
                spe = xWidth . Split ( '/' );
                xWidth = string . Empty;
                for ( int k = 0 ; k < spe . Length ; k++ )
                {
                    resu += Convert . ToDecimal ( spe [ k ] );
                }
                resu /= spe . Length;
                xWidth = resu . ToString ( );
            }
            resu = 0;
            if ( xHeigh . Contains ( "\\" ) )
            {
                spe = xHeigh . Split ( '\\' );
                xHeigh = string . Empty;
                for ( int k = 0 ; k < spe . Length ; k++ )
                {
                    resu += Convert . ToDecimal ( spe [ k ] );
                }
                resu /= spe . Length;
                xHeigh = resu . ToString ( );
            }
            resu = 0;
            if ( xHeigh . Contains ( "/" ) )
            {
                spe = xHeigh . Split ( '/' );
                xHeigh = string . Empty;
                for ( int k = 0 ; k < spe . Length ; k++ )
                {
                    resu += Convert . ToDecimal ( spe [ k ] );
                }
                resu /= spe . Length;
                xHeigh = resu . ToString ( );
            }

        }

        bool Exists ( CarpenterEntity . PiceWageStatisticalTableEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXPWS " );
            strSql . Append ( " WHERE PWS001=@PWS001 AND PWS008=@PWS008 AND PWS010=@PWS010" );
            SqlParameter [ ] parameters = {
                new SqlParameter("@PWS001", SqlDbType.NVarChar,50),
                new SqlParameter("@PWS008", SqlDbType.DateTime),
                new SqlParameter("@PWS010", SqlDbType.NVarChar,50)
            };
            parameters [ 0 ] . Value = _model . PWS001;
            parameters [ 1 ] . Value = _model . PWS008;
            parameters [ 2 ] . Value = _model . PWS010;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameters );
        }

        void add_pws ( Hashtable SQLString,StringBuilder strSql,CarpenterEntity.PiceWageStatisticalTableEntity model)
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into MOXPWS(" );
            strSql . Append ( "PWS001,PWS002,PWS003,PWS004,PWS005,PWS006,PWS007,PWS008,PWS009,PWS010,PWS011,PWS012,PWS013,PWS014,PWS015,PWS016,PWS017,PWS018,PWS019,PWS021,PWS022,PWS023,PWS024,PWS025,PWS026,PWS027,PWS028,PWS029,PWS030,PWS031,PWS032,PWS033,PWS034,PWS035)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@PWS001,@PWS002,@PWS003,@PWS004,@PWS005,@PWS006,@PWS007,@PWS008,@PWS009,@PWS010,@PWS011,@PWS012,@PWS013,@PWS014,@PWS015,@PWS016,@PWS017,@PWS018,@PWS019,@PWS021,@PWS022,@PWS023,@PWS024,@PWS025,@PWS026,@PWS027,@PWS028,@PWS029,@PWS030,@PWS031,@PWS032,@PWS033,@PWS034,@PWS035)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PWS001", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS002", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS003", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS004", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS005", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS006", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS007", SqlDbType.Int,4),
                    new SqlParameter("@PWS008", SqlDbType.DateTime),
                    new SqlParameter("@PWS009", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS010", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS011", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS012", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS013", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS014", SqlDbType.Decimal,9),
                    new SqlParameter("@PWS015", SqlDbType.Decimal,9),
                    new SqlParameter("@PWS016", SqlDbType.Decimal,9),
                    new SqlParameter("@PWS017", SqlDbType.Decimal,9),
                    new SqlParameter("@PWS018", SqlDbType.Decimal,9),
                    new SqlParameter("@PWS019", SqlDbType.Decimal,9),
                    new SqlParameter("@PWS021", SqlDbType.Decimal,9),
                    new SqlParameter("@PWS022", SqlDbType.Decimal,18),
                    new SqlParameter("@PWS023", SqlDbType.Int,4),
                    new SqlParameter("@PWS024", SqlDbType.NVarChar,100),
                    new SqlParameter("@PWS025", SqlDbType.Int,4),
                    new SqlParameter("@PWS026", SqlDbType.Decimal,9),
                    new SqlParameter("@PWS027", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS028", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS029", SqlDbType.Decimal,16),
                    new SqlParameter("@PWS030", SqlDbType.Decimal,16),
                    new SqlParameter("@PWS031", SqlDbType.Decimal,16),
                    new SqlParameter("@PWS032", SqlDbType.Decimal,16),
                    new SqlParameter("@PWS033", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS034", SqlDbType.NVarChar,50),
                    new SqlParameter("@PWS035", SqlDbType.Decimal,18)
            };
            parameters [ 0 ] . Value = model . PWS001;
            parameters [ 1 ] . Value = model . PWS002;
            parameters [ 2 ] . Value = model . PWS003;
            parameters [ 3 ] . Value = model . PWS004;
            parameters [ 4 ] . Value = model . PWS005;
            parameters [ 5 ] . Value = model . PWS006;
            parameters [ 6 ] . Value = model . PWS007;
            parameters [ 7 ] . Value = model . PWS008;
            parameters [ 8 ] . Value = model . PWS009;
            parameters [ 9 ] . Value = model . PWS010;
            parameters [ 10 ] . Value = model . PWS011;
            parameters [ 11 ] . Value = model . PWS012;
            parameters [ 12 ] . Value = model . PWS013;
            parameters [ 13 ] . Value = model . PWS014;
            parameters [ 14 ] . Value = model . PWS015;
            parameters [ 15 ] . Value = model . PWS016;
            parameters [ 16 ] . Value = model . PWS017;
            parameters [ 17 ] . Value = model . PWS018;
            parameters [ 18 ] . Value = model . PWS019;
            parameters [ 19 ] . Value = model . PWS021;
            parameters [ 20 ] . Value = model . PWS022;
            parameters [ 21 ] . Value = model . PWS023;
            parameters [ 22 ] . Value = model . PWS024;
            parameters [ 23 ] . Value = model . PWS025;
            parameters [ 24 ] . Value = model . PWS026;
            parameters [ 25 ] . Value = model . PWS027;
            parameters [ 26 ] . Value = model . PWS028;
            parameters [ 27 ] . Value = model . PWS029;
            parameters [ 28 ] . Value = model . PWS030;
            parameters [ 29 ] . Value = model . PWS031;
            parameters [ 30 ] . Value = model . PWS032;
            parameters [ 31 ] . Value = model . PWS033;
            parameters [ 32 ] . Value = model . PWS034;
            parameters [ 33 ] . Value = model . PWS035;

            SQLString . Add ( strSql ,parameters );
        }

        DataTable getSpace ( int zb ,string xLen ,string xWidth ,string xHeight )
        {
            StringBuilder strSql = new StringBuilder ( );
            //长宽高
            strSql . AppendFormat ( "SELECT PRE002,PRE003,PRE004,PRE005,PRE006,PRE008,PRE009,PRE010,PRE011 FROM MOXPRE WHERE PRE002!='非标' AND PRE001={0} AND {1} BETWEEN PRE003 AND PRE004 AND {2} BETWEEN PRE010 AND PRE011 AND {3} BETWEEN PRE008 AND PRE009" ,zb ,xLen ,xHeigh ,xWidth );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt == null || dt . Rows . Count < 1 )
            {
                //长高
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "SELECT PRE002,PRE003,PRE004,PRE005,PRE006,PRE008,PRE009,PRE010,PRE011 FROM MOXPRE WHERE PRE002!='非标' AND PRE001={0} AND {1} BETWEEN PRE003 AND PRE004 AND {2} BETWEEN PRE010 AND PRE011" ,zb ,xLen ,xHeigh );
                dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( dt == null || dt . Rows . Count < 1 )
                {
                    //长宽
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "SELECT PRE002,PRE003,PRE004,PRE005,PRE006,PRE008,PRE009,PRE010,PRE011 FROM MOXPRE WHERE PRE002!='非标' AND PRE001={0} AND {1} BETWEEN PRE003 AND PRE004 AND {2} BETWEEN PRE008 AND PRE009" ,zb ,xLen ,xWidth );
                    dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                    if ( dt == null || dt . Rows . Count < 1 )
                    {
                        //高宽
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "SELECT PRE002,PRE003,PRE004,PRE005,PRE006,PRE008,PRE009,PRE010,PRE011 FROM MOXPRE WHERE PRE002!='非标' AND PRE001={0} AND {1} BETWEEN PRE010 AND PRE011 AND {2} BETWEEN PRE008 AND PRE009" ,zb ,xHeigh ,xWidth );
                        dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                        if ( dt == null || dt . Rows . Count < 1 )
                        {
                            //长
                            strSql = new StringBuilder ( );
                            strSql . AppendFormat ( "SELECT PRE002,PRE003,PRE004,PRE005,PRE006,PRE008,PRE009,PRE010,PRE011 FROM MOXPRE WHERE PRE002!='非标' AND PRE001={0} AND {1} BETWEEN PRE003 AND PRE004 " ,zb ,xLen );
                            dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                            if ( dt == null || dt . Rows . Count < 1 )
                            {
                                //宽
                                strSql = new StringBuilder ( );
                                strSql . AppendFormat ( "SELECT PRE002,PRE003,PRE004,PRE005,PRE006,PRE008,PRE009,PRE010,PRE011 FROM MOXPRE WHERE PRE002!='非标' AND PRE001={0} AND {1} BETWEEN PRE008 AND PRE009 " ,zb ,xWidth );
                                dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                                if ( dt == null || dt . Rows . Count < 1 )
                                {
                                    //高
                                    strSql = new StringBuilder ( );
                                    strSql . AppendFormat ( "SELECT PRE002,PRE003,PRE004,PRE005,PRE006,PRE008,PRE009,PRE010,PRE011 FROM MOXPRE WHERE PRE002!='非标' AND PRE001={0} AND {1} BETWEEN PRE010 AND PRE011 " ,zb ,xHeigh );
                                    dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                                }
                            }
                        }
                    }
                }
            }

            return dt;
        }

        DataTable getSpaceForOtherCalcu ( int zb ,string xLen ,string xWidth ,string xHeight )
        {
            StringBuilder strSql = new StringBuilder ( );
            /*
            长在长区间+厚在厚区间
            宽在长区间+厚在厚区间
             */
            strSql . AppendFormat ( "SELECT PRE002,PRE003,PRE004,PRE005,PRE006,PRE008,PRE009,PRE010,PRE011 FROM MOXPRE WHERE PRE002!='非标' AND PRE001={0} AND {1} BETWEEN PRE003 AND PRE004 AND {2} BETWEEN PRE003 AND PRE004 AND {3} BETWEEN PRE010 AND PRE011" ,zb ,xLen ,xWidth ,xHeigh );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from database to view 
        /// </summary>
        /// <param name="yearAndMonth"></param>
        /// <returns></returns>
        public DataTable getTableView ( string yearAndMonth )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,PWS001,PWS002,PWS003,PWS004,PWS005,PWS006,PWS007,PWS008,PWS009,PWS010,PWS011,PWS012,PWS013,CONVERT(FLOAT,PWS014) PWS014,CONVERT(FLOAT,PWS015) PWS015,CONVERT(FLOAT,PWS016) PWS016,CONVERT(FLOAT,PWS017) PWS017,CONVERT(FLOAT,PWS018) PWS018,CONVERT(FLOAT,PWS019) PWS019,CONVERT(FLOAT,PWS021) PWS021,CONVERT(FLOAT,PWS022) PWS022,PWS023,PWS024,PWS025,CONVERT(FLOAT,PWS026) PWS026,PWS027,PWS028,CONVERT(FLOAT,PWS029) PWS029,CONVERT(FLOAT,PWS030) PWS030,CONVERT(FLOAT,PWS031) PWS031,CONVERT(FLOAT,PWS032) PWS032,PWS033,PWS034,CONVERT(FLOAT,PWS035) PWS035,CONVERT(FLOAT,PWS035*PWS026) U0  FROM MOXPWS " );
            strSql . AppendFormat ( "WHERE {0}" ,yearAndMonth );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// delete data from database 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Delete ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPWS WHERE " + strWhere );

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// edit data to database from view
        /// </summary>
        /// <param name="table"></param>
        /// <param name="intList"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table,List<int> intList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            CarpenterEntity . PiceWageStatisticalTableEntity _model = new CarpenterEntity . PiceWageStatisticalTableEntity ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                _model . PWS025 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PWS025" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PWS025" ] . ToString ( ) );
                if ( Exists ( _model . idx ) )
                    edit_pws ( SQLString ,strSql ,_model );
            }

            if ( intList . Count > 0 )
            {
                foreach ( int i in intList )
                {
                    _model . idx = i;
                    if ( !Exists ( _model . idx ) )
                        delete_pws ( SQLString ,strSql ,_model );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        bool Exists ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXPWS " );
            strSql . AppendFormat ( "WHERE idx={0}" ,idx );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void edit_pws (Hashtable SQLString,StringBuilder strSql,CarpenterEntity.PiceWageStatisticalTableEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPWS SET " );
            strSql . Append ( "PWS025=@PWS025 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PWS025", SqlDbType.Int,4),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . PWS025;
            parameters [ 1 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_pws ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . PiceWageStatisticalTableEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPWS " );
            strSql . AppendFormat ( "WHERE idx={0}" ,model . idx );

            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// get data from database to export
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getPrintTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,PWS001,PWS002,PWS003,PWS004,PWS005,PWS006,PWS007,PWS008,PWS009,PWS010,PWS011,PWS012,PWS013,CONVERT(FLOAT,PWS014) PWS014,CONVERT(FLOAT,PWS015) PWS015,CONVERT(FLOAT,PWS016) PWS016,CONVERT(FLOAT,PWS017) PWS017,CONVERT(FLOAT,PWS018) PWS018,CONVERT(FLOAT,PWS019) PWS019,CONVERT(FLOAT,PWS021) PWS021,CONVERT(FLOAT,PWS022) PWS022,PWS023,PWS024,CONVERT(FLOAT,PWS035) PWS035,CONVERT(FLOAT,PWS035*PWS026) PWS026,PWS027,PWS028+'计件工资统计表' PWS028 FROM MOXPWS " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 编辑工艺单价
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditArtPrice ( CarpenterEntity . PiceWageStatisticalTableEntity model )
        {
            int idx = 0;
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT B.idx FROM MOXPRD A INNER JOIN MOXPRE B ON A.PRD015=B.PRE001 WHERE CONVERT(VARCHAR,PRD013,112) LIKE '%{0}%' AND PRD032='{1}' AND PRE003='{2}' AND PRE004='{3}' AND PRE008='{4}' AND PRE009='{5}' AND PRE010='{6}' AND PRE011='{7}'" ,model . PWS028 ,model . PWS011 ,model . PWS014 ,model . PWS015 ,model . PWS029 ,model . PWS030 ,model . PWS031 ,model . PWS032 );
            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            //编辑车间报工记录表的工艺单价
            if ( table != null && table . Rows . Count > 0 )
            {
                foreach ( DataRow row in table . Rows )
                {
                    idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] );
                    if ( idx > 0 )
                        EditPRD ( SQLString ,model ,idx );
                }
            }
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT B.idx FROM MOXART A INNER JOIN MOXARU B ON A.ART001=B.ARU001 WHERE ART001='{0}' AND ARU003='{1}' AND ARU004='{2}' AND ARU007='{3}' AND ARU008='{4}' AND ARU009='{5}' AND ARU010='{6}'" ,model . PWS011 ,model . PWS014 ,model . PWS015 ,model . PWS029 ,model . PWS030 ,model . PWS031 ,model . PWS032 );
            table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table != null && table . Rows . Count > 0 )
            {
                foreach ( DataRow row in table . Rows )
                {
                    idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] );
                    if ( idx > 0 )
                        EditARU ( SQLString ,model ,idx );
                }
            }

            EditPWS ( SQLString ,model );
            
            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void EditPRD ( Hashtable SQLString ,CarpenterEntity . PiceWageStatisticalTableEntity model,int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXPRE SET PRE005='{0}' WHERE idx={1}" ,model . PWS022 ,  idx );
            SQLString . Add ( strSql ,null );
        }
        void EditARU ( Hashtable SQLString ,CarpenterEntity . PiceWageStatisticalTableEntity model ,int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXARU SET ARU005='{0}' WHERE idx={1}" ,model . PWS022 ,idx );
            SQLString . Add ( strSql ,null );
        }
        void EditPWS ( Hashtable SQLString ,CarpenterEntity . PiceWageStatisticalTableEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE MOXPWS SET PWS022='{0}' WHERE PWS028 LIKE '{1}%' AND PWS014='{2}' AND PWS015='{3}' AND PWS029='{4}' AND PWS030='{5}' AND PWS031='{6}' AND PWS032='{7}' " ,model . PWS022 ,model . PWS028 ,model . PWS014 ,model . PWS015 ,model . PWS029 ,model . PWS030 ,model . PWS031 ,model . PWS032 );
            SQLString . Add ( strSql ,null );
        }
    }
}
