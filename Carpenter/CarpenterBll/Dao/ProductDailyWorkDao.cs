using System . Data;
using StudentMgr;
using System . Text;
using System . Collections;
using System;
using System . Data . SqlClient;
using System . Collections . Generic;

namespace CarpenterBll . Dao
{
    public class ProductDailyWorkDao
    {
        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable equExists ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT EQU001,EQU002 FROM MOXEQU " );
            strSql . AppendFormat ( "WHERE EQU001='{0}'" ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取设备对应工艺信息
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetArt ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT EQV002,EQV003 FROM MOXEQV WHERE EQV001='{0}'" ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable perExists ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT EMP001,EMP002,DEP002 FROM MOXEMP A LEFT JOIN MOXDEP B ON A.EMP003=B.DEP001 WHERE EMP001='{0}'" ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取传票信息
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable cpExists ( string num ,string equNum ,string process )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT WPC001,WPC002,WOQ008,WOQ009,WPC004,WPC005,CUU003,WPC006+'*'+WPC009+'*'+WPC012 WOR FROM MOXWPC A INNER JOIN MOXWOQ B ON A.WPC002=B.WOQ001 LEFT JOIN MOXCUU F ON A.WPC001=F.CUU001 AND A.WPC002=F.CUU002 " );
            strSql . AppendFormat ( "WHERE WPC005='{0}' " ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否开工或完工闭合
        /// </summary>
        /// <returns></returns>
        public string ExistsSign ( CarpenterEntity . ProductDailyWorkEntity _model ,DataTable table )
        {
            string result = string . Empty;
            StringBuilder strSql = new StringBuilder ( );
            if ( table != null && table . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _model . PRD004 = table . Rows [ i ] [ "PRD004" ] . ToString ( );
                    _model . PRD005 = table . Rows [ i ] [ "PRD005" ] . ToString ( );
                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPRD WHERE PRD001='{0}' AND PRD004='{1}' AND PRD006='{2}' AND PRD003='{3}'" ,_model . PRD001 ,_model . PRD004 ,_model . PRD006 ,_model . PRD003 );
                    if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                    {
                        strSql = new StringBuilder ( );
                        if ( _model . PRD014 )
                            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPRD WHERE PRD001='{0}' AND PRD004='{1}' AND PRD006='{2}' AND PRD014={3} AND PRD003='{4}' AND PRD013=(SELECT MAX(PRD013) FROM MOXPRD WHERE PRD001='{0}' AND PRD004='{1}' AND PRD006='{2}' AND PRD003='{4}' )" ,_model . PRD001 ,_model . PRD004 ,_model . PRD006 ,0 ,_model . PRD003 );
                        else
                            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPRD WHERE PRD001='{0}' AND PRD004='{1}' AND PRD006='{2}' AND PRD014={3} AND PRD003='{4}' AND PRD013=(SELECT MAX(PRD013) FROM MOXPRD WHERE PRD001='{0}' AND PRD004='{1}' AND PRD006='{2}' AND PRD003='{4}')" ,_model . PRD001 ,_model . PRD004 ,_model . PRD006 ,1 ,_model . PRD003 );

                        bool isok = SqlHelper . Exists ( strSql . ToString ( ) );
                        if ( SqlHelper . Exists ( strSql . ToString ( ) ) == false )
                        {
                            result = _model . PRD005;
                            break;
                        }
                    }
                    else if ( _model . PRD014 == false )
                    {
                        result = _model . PRD005;
                        break;
                    }
                    else
                        result = string . Empty;
                }
            }
            else
                result = string . Empty;

            return result;
        }

        /// <summary>
        ///  是否开工或完工闭合
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public int ExistsSignStart ( CarpenterEntity . ProductDailyWorkEntity _model ,DataTable table )
        {
            int result = -1;
            StringBuilder strSql = new StringBuilder ( );
            if ( table != null && table . Rows . Count > 0 )
            {
                string userNum = string . Empty;
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    _model . PRD004 = table . Rows [ i ] [ "PRD004" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( userNum ) )
                        userNum = "'" + _model . PRD004 + "'";
                    else
                        userNum = userNum + "," + "'" + _model . PRD004 + "'";
                }
                //1、先查最大的报工记录  不管开工  完工
                strSql . Append ( " WITH CET AS (" );
                strSql . AppendFormat ( "SELECT idx,PRD001,PRD004,PRD006,PRD003,PRD014,PRD015,PRD013 FROM MOXPRD WHERE PRD014=1 AND PRD001='{0}' AND PRD004 IN ({1}) AND PRD006='{2}' AND PRD003='{3}') " ,_model . PRD001 ,userNum ,_model . PRD006 ,_model . PRD003 );
                strSql . Append ( ",CFT AS (" );
                strSql . AppendFormat ( "SELECT idx,PRD001,PRD004,PRD006,PRD003,PRD014,PRD015,PRD013 FROM MOXPRD WHERE PRD014=0 AND PRD001='{0}' AND PRD004 IN ({1}) AND PRD006='{2}' AND PRD003='{3}') " ,_model . PRD001 ,userNum ,_model . PRD006 ,_model . PRD003 );
                strSql . AppendFormat ( ",CHT AS(SELECT a.idx idaa,b.idx FROM CET A INNER JOIN CFT B ON A.PRD001=B.PRD001 AND A.PRD003=B.PRD003 AND A.PRD004=B.PRD004 AND A.PRD006=B.PRD006 AND A.PRD015=B.PRD015) " );
                strSql . AppendFormat ( "SELECT DISTINCT PRD004,PRD014,PRD015 FROM MOXPRD WHERE idx NOT IN (SELECT idx FROM CHT) AND idx NOT IN (SELECT idaa FROM CHT)  AND PRD001='{0}' AND PRD004 IN ({1}) AND PRD006='{2}' AND PRD003='{3}'" ,_model . PRD001 ,userNum ,_model . PRD006 ,_model . PRD003 );

                DataTable tableResult = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( tableResult == null || tableResult . Rows . Count < 1 )
                    //可以开工  不可以完工
                    return 0;
                string uName = string . Empty, groupU = string . Empty;
                bool state = false;
                if ( tableResult . Rows . Count == 1 )
                {
                    if ( tableResult . Rows . Count == table . Rows . Count )
                    {
                        state = string . IsNullOrEmpty ( tableResult . Rows [ 0 ] [ "PRD014" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( tableResult . Rows [ 0 ] [ "PRD014" ] );
                        if ( state  == false )
                            //有完工  没开工  数据异常  需要后台检查
                            return 1;
                        else
                        {
                            //有开工  没完工
                            groupU = tableResult . Rows [ 0 ] [ "PRD015" ] . ToString ( );
                            strSql = new StringBuilder ( );
                            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPRD WHERE PRD015='{0}' AND PRD004 NOT IN ({1})" ,groupU ,userNum );
                            if ( SqlHelper . Exists ( strSql . ToString ( ) ) == false )
                                //只能完工
                                return 2;
                            else
                                //只能开工
                                return 0;
                        }
                    }
                    else
                        //表示没有开工和完工  只能开工
                        return 0;
                }
                else
                {
                    DataTable tableState = tableResult . DefaultView . ToTable ( true ,"PRD014" );
                    if ( tableState . Rows . Count > 1 )
                        //有完工  有开工  异常
                        return 1;
                    tableState = tableResult . DefaultView . ToTable ( true ,"PRD015" );
                    groupU = tableState . Rows [ 0 ] [ "PRD015" ] . ToString ( );
                    if ( tableState . Rows . Count == 1 )
                    {
                        state = Convert . ToBoolean ( tableResult . Select ( "PRD015='" + groupU + "'" ) [ 0 ] [ "PRD014" ] . ToString ( ) );
                        if ( Convert . ToBoolean ( state ) == false )
                        {
                            //可以开工  不可以完工
                            return 0;
                        }
                        else
                        {
                            //可以完工  不可以开工
                            return 2;
                        }
                    }

                    foreach ( DataRow row in tableState . Rows )
                    {
                        groupU = row [ "PRD015" ] . ToString ( );
                        strSql = new StringBuilder ( );
                        state = Convert . ToBoolean ( tableResult . Select ( "PRD015='" + groupU + "'" ) [ 0 ] [ "PRD014" ] . ToString ( ) );
                        strSql . AppendFormat ( "SELECT PRD004 FROM MOXPRD WHERE PRD015='{0}'" ,groupU );
                        DataTable tableTwo = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                        if ( tableTwo == null || tableTwo . Rows . Count < 1 )
                            continue;
                        if ( tableTwo . Rows . Count > table . Rows . Count )
                        {
                            DataRow [ ] rs = tableTwo . Select ( "PRD004 NOT IN (" + userNum + ")" );
                            if ( rs == null || rs . Length < 1 )
                            {
                                if ( state == false )
                                {
                                    //可以开工  不可以完工
                                    result = 0;
                                    break;
                                }
                                else
                                {
                                    //可以完工  不可以开工
                                    result = 2;
                                    break;
                                }
                            }
                            else
                                //可以开工  不可以完工
                                result = 0;
                        }
                        else
                        {
                            string userNames = string . Empty;
                            foreach ( DataRow r in tableTwo . Rows )
                            {
                                if ( string . IsNullOrEmpty ( userNames ) )
                                    userNames = r [ "PRD004" ] . ToString ( );
                                else
                                    userNames = userNames + "," + r [ "PRD004" ] . ToString ( );

                                if ( !userNum . Contains ( r [ "PRD004" ] . ToString ( ) ) )
                                {
                                    //只能开工  不能完工
                                    result = 0;
                                    break;
                                }
                            }
                            if ( result != -1 )
                                break;
                            foreach ( DataRow r in tableResult . Rows )
                            {
                                if ( !userNames . Contains ( r [ "PRD004" ] . ToString ( ) ) )
                                {
                                    //只能开工  不能完工
                                    result = 0;
                                    break;
                                }
                            }
                            if ( result != -1 )
                                break;
                            if ( state == false )
                            {
                                //可以开工  不可以完工
                                result = 0;
                                break;
                            }
                            else
                            {
                                //可以完工  不可以开工
                                result = 2;
                                break;
                            }
                            if ( result != -1 )
                                break;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 保存记录
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Save ( CarpenterEntity . ProductDailyWorkEntity _model ,DataTable table )
        {
            bool result = true;
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _model . PRD017 = _model . PRD013 = UserInformation . dt ( );
            _model . PRD018 = UserInformation . UserName;
            if ( _model . PRD014 )
            {
                while ( result )
                {
                    _model . PRD015 = getGroup ( _model ,0 );
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPRF WHERE PRF001='{0}' " ,_model . PRD015 );
                    if ( SqlHelper . Exists ( strSql . ToString ( ) ) == false )
                        result = false;
                }
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "INSERT INTO MOXPRF (PRF001) VALUES ('{0}')" ,_model . PRD015 );
                SqlHelper . ExecuteNonQueryBool ( strSql . ToString ( ) );
            }
            _model . PRD021 = false;
            //_model . PRD033 = getSaTy ( _model . PRD032 );
            List<string> userList = new List<string> ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                userList . Add ( table . Rows [ i ] [ "PRD004" ] . ToString ( ) );
            }
            _model . PRD043 = Convert . ToInt32 ( getGroup ( userList ,_model . PRD001 ) );
            _model . PRD004 = string . Empty;
            foreach ( DataRow row in table . Rows )
            {
                if ( string . IsNullOrEmpty ( _model . PRD004 ) )
                    _model . PRD004 = "'" + row [ "PRD004" ] . ToString ( ) + "'";
                else
                    _model . PRD004 = _model . PRD004 + "," + "'" + row [ "PRD004" ] . ToString ( ) + "'";
            }

            if ( _model . PRD014 == false )
                _model . PRD015 = getGroup ( _model ,table . Rows . Count );

            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . PRD004 = table . Rows [ i ] [ "PRD004" ] . ToString ( );
                _model . PRD005 = table . Rows [ i ] [ "PRD005" ] . ToString ( );
                _model . PRD044 = table . Rows [ i ] [ "DEP002" ] . ToString ( );
                
                add ( SQLString ,strSql ,_model );
            }
            
            DataTable dt = getStandard ( _model . PRD032 );
            CarpenterEntity . ProductDailyWorkPREEntity _entity = new CarpenterEntity . ProductDailyWorkPREEntity ( );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                _model . PRD033 = dt . Rows [ 0 ] [ "ART011" ] . ToString ( );
                _entity . PRE007 = string . Empty;
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _entity . PRE001 = _model . PRD015;
                    _entity . PRE002 = dt . Rows [ i ] [ "ARU002" ] . ToString ( );
                    _entity . PRE003 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "ARU003" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "ARU003" ] . ToString ( ) );
                    _entity . PRE004 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "ARU004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "ARU004" ] . ToString ( ) );
                    _entity . PRE005 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "ARU005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "ARU005" ] . ToString ( ) );
                    _entity . PRE008 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "ARU007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "ARU007" ] . ToString ( ) );
                    _entity . PRE009 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "ARU008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "ARU008" ] . ToString ( ) );
                    _entity . PRE010 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "ARU009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "ARU009" ] . ToString ( ) );
                    _entity . PRE011 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "ARU010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "ARU010" ] . ToString ( ) );
                    _entity . PRE006 = dt . Rows [ i ] [ "ARU006" ] . ToString ( );
                    add_pre ( SQLString ,strSql ,_entity );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取组别,用来得到同组生产的记录
        /// </summary>
        /// <returns></returns>
        string getGroup ( CarpenterEntity . ProductDailyWorkEntity _model ,int num  )
        {
            DataTable dt;
            string codeForGroup = string . Empty;
            StringBuilder strSql = new StringBuilder ( );
            if ( _model . PRD014 )
            {
                //strSql . Append ( "SELECT  MAX(CONVERT(INT,PRD015)) PRD015 FROM MOXPRD " );
                strSql . Append ( "SELECT  MAX(CONVERT(INT,PRF001)) PRD015 FROM MOXPRF " );
                dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    codeForGroup = dt . Rows [ 0 ] [ "PRD015" ] . ToString ( );
                    if ( _model . PRD014 )
                    {
                        if ( string . IsNullOrEmpty ( codeForGroup ) )
                            return 1 . ToString ( );
                        else
                            return ( Convert . ToInt32 ( codeForGroup ) + 1 ) . ToString ( );
                    }
                    else
                    {
                        //如果没有对应的开工记录  则完工记录的组别是0  异常数据
                        if ( string . IsNullOrEmpty ( codeForGroup ) )
                            return 0 . ToString ( );
                        else
                            return codeForGroup;
                    }
                }
                else
                {
                    if ( _model . PRD014 )
                        return 1 . ToString ( );
                    else
                        return 0 . ToString ( );
                }
            }
            else
            {
                strSql . Append ( "WITH CET AS (" );
                strSql . AppendFormat ( "SELECT idx,PRD001,PRD004,PRD006,PRD003,PRD014,PRD015,PRD013 FROM MOXPRD WHERE PRD014=1 AND PRD001='{0}' AND PRD004 IN ({1}) AND PRD006='{2}' AND PRD003='{3}'" ,_model . PRD001 ,_model . PRD004 ,_model . PRD006 ,_model . PRD003 );
                strSql . Append ( ") ,CFT AS (" );
                strSql . AppendFormat ( "SELECT idx,PRD001,PRD004,PRD006,PRD003,PRD014,PRD015,PRD013 FROM MOXPRD WHERE PRD014=0 AND PRD001='{0}' AND PRD004 IN ({1}) AND PRD006='{2}' AND PRD003='{3}'" ,_model . PRD001 ,_model . PRD004 ,_model . PRD006 ,_model . PRD003 );
                strSql . Append ( ") ,CHT AS(" );
                strSql . Append ( "SELECT a.idx idaa,b.idx FROM CET A INNER JOIN CFT B ON A.PRD001=B.PRD001 AND A.PRD003=B.PRD003 AND A.PRD004=B.PRD004 AND A.PRD006=B.PRD006 AND A.PRD015=B.PRD015) " );
                strSql . AppendFormat ( "SELECT PRD015,COUNT(1) COUN FROM MOXPRD WHERE idx NOT IN (SELECT idx FROM CHT) AND idx NOT IN (SELECT idaa FROM CHT)  AND PRD001='{0}' AND PRD004 IN ({1}) AND PRD006='{2}' AND PRD003='{3}' AND PRD014=1 GROUP BY PRD015 " ,_model . PRD001 ,_model . PRD004 ,_model . PRD006 ,_model . PRD003 );
                dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    int count = 0;
                    foreach ( DataRow row in dt . Rows )
                    {
                        codeForGroup = row [ "PRD015" ] . ToString ( );
                        count = string . IsNullOrEmpty ( row [ "COUN" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "COUN" ] );
                        if ( num == count )
                            break;
                    }
                }
                else
                {
                    if ( _model . PRD014 )
                        return 1 . ToString ( );
                    else
                        return 0 . ToString ( );
                }
            }

            return codeForGroup;
        }

        /// <summary>
        /// 获取生产分组，用来分配工资系数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        string getGroup ( List<string> userList ,string departNum )
        {
            string group = string . Empty, users = string . Empty;
            foreach ( string user in userList )
            {
                if ( string . IsNullOrEmpty ( users ) )
                    users = "'" + user + "'";
                else
                    users = users + "," + "'" + user + "'";
            }

            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS(SELECT DISTINCT PRD001,PRD004,PRD043 FROM MOXPRD WHERE PRD004 IN ({0}) AND PRD001='{1}') SELECT PRD001,PRD004,PRD043 FROM MOXPRD WHERE PRD043 IN (SELECT PRD043 FROM CET) GROUP BY PRD004,PRD043,PRD001" ,users ,departNum );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table != null && table . Rows . Count > 0 )
            {
                int result = 0;
                List<string> groupList = new List<string> ( );
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    result = 0;
                    group = table . Rows [ i ] [ "PRD043" ] . ToString ( );
                    if ( !groupList . Contains ( group ) )
                    {
                        groupList . Add ( group );
                        if ( table . Select ( "PRD043='" + group + "'" ) . Length == userList . Count )
                        {
                            foreach ( string user in userList )
                            {
                                if ( table . Select ( "PRD043='" + group + "' AND PRD004='" + user + "'" ) . Length < 1 )
                                {
                                    result = 1;
                                    break;
                                }
                            }
                            if ( result == 0 )
                                break;
                            if ( i == table . Rows . Count - 1 )
                            {
                                group = getMaxGroup ( );
                                group = ( Convert . ToInt32 ( group ) + 1 ) . ToString ( );
                            }
                        }
                        else if ( i == table . Rows . Count - 1 )
                        {
                            group = getMaxGroup ( );
                            group = ( Convert . ToInt32 ( group ) + 1 ) . ToString ( );
                        }
                    }
                    else if ( i == table . Rows . Count - 1 )
                    {
                        group = getMaxGroup ( );
                        group = ( Convert . ToInt32 ( group ) + 1 ) . ToString ( );
                    }
                }
            }
            else
            {
                group = getMaxGroup ( );
                group = ( Convert . ToInt32 ( group ) + 1 ) . ToString ( );
            }
            return group;
        }

        string getMaxGroup ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(PRD043) PRD043 FROM MOXPRD" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PRD043" ] . ToString ( ) ) == true ? "0" : dt . Rows [ 0 ] [ "PRD043" ] . ToString ( );
            else
                return "0";
        }

        DataTable getStandard ( string artNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT ARU002,ARU003,ARU004,ARU005,ARU006,ARU007,ARU008,ARU009,ARU010,ART011 FROM MOXARU A INNER JOIN MOXART B ON A.ARU001=B.ART001 " );
            strSql . AppendFormat ( "WHERE ART001='{0}'" ,artNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        string getSaTy ( string artNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT ART011 FROM MOXART WHERE ART001='{0}' " ,artNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return dt . Rows [ 0 ] [ "ART011" ] . ToString ( );
            else
                return string . Empty;
        }

        void add ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ProductDailyWorkEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into MOXPRD(" );
            strSql . Append ( "PRD001,PRD002,PRD003,PRD004,PRD005,PRD006,PRD007,PRD008,PRD009,PRD010,PRD011,PRD012,PRD013,PRD014,PRD015,PRD016,PRD017,PRD018,PRD019,PRD020,PRD021,PRD022,PRD023,PRD024,PRD025,PRD026,PRD027,PRD028,PRD029,PRD030,PRD031,PRD032,PRD033,PRD034,PRD035,PRD036,PRD037,PRD038,PRD039,PRD040,PRD041,PRD042,PRD043,PRD044)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@PRD001,@PRD002,@PRD003,@PRD004,@PRD005,@PRD006,@PRD007,@PRD008,@PRD009,@PRD010,@PRD011,@PRD012,@PRD013,@PRD014,@PRD015,@PRD016,@PRD017,@PRD018,@PRD019,@PRD020,@PRD021,@PRD022,@PRD023,@PRD024,@PRD025,@PRD026,@PRD027,@PRD028,@PRD029,@PRD030,@PRD031,@PRD032,@PRD033,@PRD034,@PRD035,@PRD036,@PRD037,@PRD038,@PRD039,@PRD040,@PRD041,@PRD042,@PRD043,@PRD044)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PRD001", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD002", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD003", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD004", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD005", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD006", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD007", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD008", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD009", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD010", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD011", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD012", SqlDbType.Decimal,11),
                    new SqlParameter("@PRD013", SqlDbType.DateTime),
                    new SqlParameter("@PRD014", SqlDbType.Bit,1),
                    new SqlParameter("@PRD015", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD016", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD017", SqlDbType.DateTime),
                    new SqlParameter("@PRD018", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD019", SqlDbType.Decimal,9),
                    new SqlParameter("@PRD020", SqlDbType.Bit),
                    new SqlParameter("@PRD021", SqlDbType.Bit),
                    new SqlParameter("@PRD022", SqlDbType.NVarChar,100),
                    new SqlParameter("@PRD023", SqlDbType.Int,4),
                    new SqlParameter("@PRD024", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD025", SqlDbType.Decimal,9),
                    new SqlParameter("@PRD026", SqlDbType.NVarChar,100),
                    new SqlParameter("@PRD027", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD028", SqlDbType.Decimal,9),
                    new SqlParameter("@PRD029", SqlDbType.Decimal,9),
                    new SqlParameter("@PRD030", SqlDbType.Decimal,9),
                    new SqlParameter("@PRD031", SqlDbType.NVarChar,100),
                    new SqlParameter("@PRD032", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD033", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD034", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD035", SqlDbType.Bit),
                    new SqlParameter("@PRD036", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD037", SqlDbType.Decimal,11),
                    new SqlParameter("@PRD038", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD039", SqlDbType.Decimal,11),
                    new SqlParameter("@PRD040", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRD041", SqlDbType.Decimal,11),
                    new SqlParameter("@PRD042", SqlDbType.Int,4),
                    new SqlParameter("@PRD043", SqlDbType.Int,4),
                    new SqlParameter("@PRD044", SqlDbType.NVarChar,50)
            };
            parameters [ 0 ] . Value = model . PRD001;
            parameters [ 1 ] . Value = model . PRD002;
            parameters [ 2 ] . Value = model . PRD003;
            parameters [ 3 ] . Value = model . PRD004;
            parameters [ 4 ] . Value = model . PRD005;
            parameters [ 5 ] . Value = model . PRD006;
            parameters [ 6 ] . Value = model . PRD007;
            parameters [ 7 ] . Value = model . PRD008;
            parameters [ 8 ] . Value = model . PRD009;
            parameters [ 9 ] . Value = model . PRD010;
            parameters [ 10 ] . Value = model . PRD011;
            parameters [ 11 ] . Value = model . PRD012;
            parameters [ 12 ] . Value = model . PRD013;
            parameters [ 13 ] . Value = model . PRD014;
            parameters [ 14 ] . Value = model . PRD015;
            parameters [ 15 ] . Value = model . PRD016;
            parameters [ 16 ] . Value = model . PRD017;
            parameters [ 17 ] . Value = model . PRD018;
            parameters [ 18 ] . Value = model . PRD019;
            parameters [ 19 ] . Value = model . PRD020;
            parameters [ 20 ] . Value = model . PRD021;
            parameters [ 21 ] . Value = model . PRD022;
            parameters [ 22 ] . Value = model . PRD023;
            parameters [ 23 ] . Value = model . PRD024;
            parameters [ 24 ] . Value = model . PRD025;
            parameters [ 25 ] . Value = model . PRD026;
            parameters [ 26 ] . Value = model . PRD027;
            parameters [ 27 ] . Value = model . PRD028;
            parameters [ 28 ] . Value = model . PRD029;
            parameters [ 29 ] . Value = model . PRD030;
            parameters [ 30 ] . Value = model . PRD031;
            parameters [ 31 ] . Value = model . PRD032;
            parameters [ 32 ] . Value = model . PRD033;
            parameters [ 33 ] . Value = model . PRD034;
            parameters [ 34 ] . Value = model . PRD035;
            parameters [ 35 ] . Value = model . PRD036;
            parameters [ 36 ] . Value = model . PRD037;
            parameters [ 37 ] . Value = model . PRD038;
            parameters [ 38 ] . Value = model . PRD039;
            parameters [ 39 ] . Value = model . PRD040;
            parameters [ 40 ] . Value = model . PRD041;
            parameters [ 41 ] . Value = model . PRD042;
            parameters [ 42 ] . Value = model . PRD043;
            parameters [ 43 ] . Value = model . PRD044;

            SQLString . Add ( strSql ,parameters );
        }

        void add_pre ( Hashtable SQLString ,StringBuilder strSql ,CarpenterEntity . ProductDailyWorkPREEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into MOXPRE(" );
            strSql . Append ( "PRE001,PRE002,PRE003,PRE004,PRE005,PRE006,PRE007,PRE008,PRE009,PRE010,PRE011)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@PRE001,@PRE002,@PRE003,@PRE004,@PRE005,@PRE006,@PRE007,@PRE008,@PRE009,@PRE010,@PRE011)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PRE001", SqlDbType.NVarChar,20),
                    new SqlParameter("@PRE002", SqlDbType.NVarChar,20),
                    new SqlParameter("@PRE003", SqlDbType.Decimal,18),
                    new SqlParameter("@PRE004", SqlDbType.Decimal,18),
                    new SqlParameter("@PRE005", SqlDbType.Decimal,18),
                    new SqlParameter("@PRE006", SqlDbType.NVarChar,100),
                    new SqlParameter("@PRE007", SqlDbType.NVarChar,50),
                    new SqlParameter("@PRE008", SqlDbType.Decimal,18),
                    new SqlParameter("@PRE009", SqlDbType.Decimal,18),
                    new SqlParameter("@PRE010", SqlDbType.Decimal,18),
                    new SqlParameter("@PRE011", SqlDbType.Decimal,18)
            };
            parameters [ 0 ] . Value = model . PRE001;
            parameters [ 1 ] . Value = model . PRE002;
            parameters [ 2 ] . Value = model . PRE003;
            parameters [ 3 ] . Value = model . PRE004;
            parameters [ 4 ] . Value = model . PRE005;
            parameters [ 5 ] . Value = model . PRE006;
            parameters [ 6 ] . Value = model . PRE007;
            parameters [ 7 ] . Value = model . PRE008;
            parameters [ 8 ] . Value = model . PRE009;
            parameters [ 9 ] . Value = model . PRE010;
            parameters [ 10 ] . Value = model . PRE011;

            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PRD001,PRD002,PRD003,PRD004,PRD005,PRD007,PRD008,PRD009,PRD010,PRD011 FROM MOXPRD" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM MOXPRE WHERE idx IN (SELECT A.idx FROM MOXPRE A INNER JOIN MOXPRD B ON PRE001=PRD015 WHERE B.idx={0})" ,idx );//AND PRE007=PRD004
            SQLString . Add ( strSql ,null );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXPRD " );
            strSql . AppendFormat ( "WHERE idx={0}" ,idx );
            SQLString . Add ( strSql ,null );
            
            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,PRD001,PRD002,PRD003,PRD004,PRD005,PRD006,PRD007,PRD008,PRD009,PRD010,PRD011,PRD012,PRD013,PRD014,PRD015,PRD016,PRD017,PRD018,PRD019,PRD020,PRD021,PRD022,PRD023,PRD024,PRD025,PRD026,PRD032,PRD033,PRD034,PRD035,PRD036,PRD037,PRD038,PRD039,PRD040,PRD041,PRD042,PRD043,PRD044 FROM MOXPRD " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取开工和完工不配对的异常数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWarnTitle ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (SELECT idx,PRD001,PRD004,PRD006,PRD003,PRD014,PRD015,PRD013 FROM MOXPRD WHERE PRD014=1) ,CFT AS (SELECT idx,PRD001,PRD004,PRD006,PRD003,PRD014,PRD015,PRD013 FROM MOXPRD WHERE PRD014=0),CHT AS(SELECT a.idx idaa,b.idx FROM CET A INNER JOIN CFT B ON A.PRD001=B.PRD001 AND A.PRD003=B.PRD003 AND A.PRD004=B.PRD004 AND A.PRD006=B.PRD006 AND A.PRD015=B.PRD015) SELECT idx FROM MOXPRD WHERE idx NOT IN (SELECT idx FROM CHT) AND idx NOT IN (SELECT idaa FROM CHT)" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT idx,PRE001,PRE002,PRE003,PRE004,PRE005,PRE006,PRE008,PRE009,PRE010,PRE011 FROM MOXPRE " );
            strSql . AppendFormat ( "WHERE PRE001='{0}'" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取零件数量
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public decimal numOfPart ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CUU003*ISNULL(WPC016,0) CUU003 FROM MOXWPC A LEFT JOIN MOXCUU B ON A.WPC001=B.CUU001 AND A.WPC002=B.CUU002 " );
            strSql . AppendFormat ( "WHERE WPC005='{0}'" ,code );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "CUU003" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToDecimal ( dt . Rows [ 0 ] [ "CUU003" ] . ToString ( ) );
            }
            else
                return 0;
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Examin ( List<string> strList )
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
            strSql . Append ( "UPDATE MOXPRD SET " );
            strSql . Append ( "PRD020=1 " );
            strSql . AppendFormat ( "WHERE idx IN ({0})" ,str );

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Cancella ( List<string> strList )
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
            strSql . Append ( "UPDATE MOXPRD SET " );
            strSql . Append ( "PRD021=1 " );
            strSql . AppendFormat ( "WHERE idx IN ({0})" ,str );

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑记工数量
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder ( );
            Hashtable SQLString = new Hashtable ( );
            CarpenterEntity . ProductDailyWorkEntity _model = new CarpenterEntity . ProductDailyWorkEntity ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                _model . PRD019 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PRD019" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PRD019" ] . ToString ( ) );
                _model . PRD016 = table . Rows [ i ] [ "PRD016" ] . ToString ( );
                _model . PRD020 = ( bool ) table . Rows [ i ] [ "PRD020" ];
                _model . PRD021 = ( bool ) table . Rows [ i ] [ "PRD021" ];
                _model . PRD023 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PRD023" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PRD023" ] . ToString ( ) );
                _model . PRD025 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PRD025" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PRD025" ] . ToString ( ) );
                _model . PRD033 = table . Rows [ i ] [ "PRD033" ] . ToString ( );

                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE MOXPRD SET PRD019={0},PRD016='{2}',PRD020=@PRD020,PRD021=@PRD021,PRD023={3},PRD025={4},PRD033='{5}' WHERE idx={1}" ,_model . PRD019 ,_model . idx ,_model . PRD016 ,_model . PRD023 ,_model . PRD025 ,_model . PRD033 );

                SqlParameter [ ] parameter = {
                    new SqlParameter("@PRD020",SqlDbType.Bit),
                    new SqlParameter("@PRD021",SqlDbType.Bit)
                };
                parameter [ 0 ] . Value = _model . PRD020;
                parameter [ 1 ] . Value = _model . PRD021;
                SQLString . Add ( strSql . ToString ( ) ,parameter );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取设备备注
        /// </summary>
        /// <param name="equimentNum"></param>
        /// <returns></returns>
        public DataTable tableRemark ( string equimentNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT EQU010 FROM MOXEQU " );
            strSql . AppendFormat ( "WHERE EQU001='{0}'" ,equimentNum );

            DataTable table = new DataTable ( );
            table . Columns . Add ( "EQU010" ,typeof ( System . String ) );
            DataRow row = table . NewRow ( );
            row [ "EQU010" ] = string . Empty;
            table . Rows . Add ( row );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "EQU010" ] . ToString ( ) ) )
                    return dt;
                else
                {
                    string [ ] str = dt . Rows [ 0 ] [ "EQU010" ] . ToString ( ) . Split ( new string [ ] { "\r\n" } ,StringSplitOptions . None );
                    for ( int i = 0 ; i < str . Length ; i++ )
                    {
                        row = table . NewRow ( );
                        row [ "EQU010" ] = str [ i ];
                        table . Rows . Add ( row );
                    }

                    return table;
                }
            }
            else
                return dt;
        }

        /// <summary>
        /// 获取区间标准
        /// </summary>
        /// <param name="equimentNum"></param>
        /// <param name="artName"></param>
        /// <returns></returns>
        public DataTable tableSpace ( string equimentNum ,string artName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT A.idx,ARU002,ARU005,ARU006 FROM MOXARU A INNER JOIN MOXART B ON A.ARU001=B.ART001 WHERE ART001=(SELECT EQV002 FROM MOXEQV WHERE EQV001='{0}' AND EQV003='{1}') AND ARU002='非标' " ,equimentNum ,artName );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取工资类型
        /// </summary>
        /// <param name="equimentNum"></param>
        /// <returns></returns>
        public DataTable tableSalary ( string equimentNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT ART011 FROM MOXART " );
            strSql . AppendFormat ( " WHERE ART001='{0}' AND ART011 IS NOT NULL" ,equimentNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否强制完工
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool isOver ( CarpenterEntity . ProductDailyWorkEntity _model )
        {
        
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPRD WHERE PRD006='{0}' AND PRD003='{1}' AND PRD035=1" ,_model . PRD006 ,_model . PRD003 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 同零件和工艺是否订单数量等于记工数量，若等则提示已报工完成
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool isOverForSave ( CarpenterEntity . ProductDailyWorkEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM MOXPRD A INNER JOIN MOXWPC B ON A.PRD006=B.WPC005 INNER JOIN MOXCUU C ON B.WPC001=C.CUU001 AND B.WPC002=C.CUU002 WHERE PRD003='{0}' AND PRD006='{1}' AND PRD014=0 GROUP BY WPC016,CUU003 HAVING SUM(PRD019)=WPC016*CUU003" ,_model . PRD003 ,_model . PRD006 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 同传票编号和工艺已经记工的数量是多少
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public decimal getOverNum ( CarpenterEntity . ProductDailyWorkEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT SUM(PRD019) PRD019 FROM MOXPRD WHERE PRD003=@PRD003 AND PRD006=@PRD006 AND PRD014=@PRD014" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PRD003",SqlDbType.NVarChar,20),
                new SqlParameter("@PRD006",SqlDbType.NVarChar,20),
                new SqlParameter("@PRD014",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _model . PRD003;
            parameter [ 1 ] . Value = _model . PRD006;
            parameter [ 2 ] . Value = _model . PRD014;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( dt != null && dt . Rows . Count > 0 )
                return string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PRD019" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "PRD019" ] . ToString ( ) );
            else
                return 0;
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getPrintTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT PRD005,CONVERT(VARCHAR,PRD013,111) PRD013,PRD007,PRD008,PRD009,PRD011,PRD034,PRD003,PRD019,PRD023 FROM MOXPRD WHERE {0}" ,strWhere );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getPrintUser ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT PRD004 FROM MOXPRD WHERE {0}" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . ProductDailyWorkEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPRD SET " );
            strSql . AppendFormat ( "PRD003='{0}'," ,model . PRD003 );
            strSql . AppendFormat ( "PRD012='{0}'," ,model . PRD012 );
            strSql . AppendFormat ( "PRD032='{0}'," ,model . PRD032 );
            strSql . AppendFormat ( "PRD034='{0}'," ,model . PRD034 );
            strSql . AppendFormat ( "PRD020={0}," ,model . PRD020 == true ? 1 : 0 );
            strSql . AppendFormat ( "PRD021={0}," ,model . PRD021 == true ? 1 : 0 );
            strSql . AppendFormat ( "PRD023={0}," ,model . PRD023 );
            strSql . AppendFormat ( "PRD033='{0}'," ,model . PRD033 );
            strSql . AppendFormat ( "PRD036='{0}'," ,model . PRD036 );
            strSql . AppendFormat ( "PRD037={0}," ,model . PRD037 );
            strSql . AppendFormat ( "PRD038='{0}'," ,model . PRD038 );
            strSql . AppendFormat ( "PRD039={0}," ,model . PRD039 );
            strSql . AppendFormat ( "PRD040='{0}'," ,model . PRD040 );
            strSql . AppendFormat ( "PRD041={0} " ,model . PRD041 );
            strSql . AppendFormat ( "WHERE idx={0}" ,model . idx );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            return rows > 0 == true ? true : false;
        }

        /// <summary>
        /// 获取没有同时扫描完工的人员信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tableUser"></param>
        /// <returns></returns>
        public Dictionary<string ,string> isOver ( CarpenterEntity . ProductDailyWorkEntity model ,DataTable tableUser )
        {
            Dictionary<string ,string> userList = new Dictionary<string ,string> ( );
            model . PRD004 = string . Empty;
            foreach ( DataRow row in tableUser . Rows )
            {
                if ( model . PRD004 == string . Empty )
                    model . PRD004 = "'" + row [ "PRD004" ] . ToString ( ) + "'";
                else
                    model . PRD004 = model . PRD004 + "," + "'" + row [ "PRD004" ] . ToString ( ) + "'";
            }
            
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS (SELECT idx,PRD001,PRD004,PRD006,PRD003,PRD014,PRD015,PRD013 FROM MOXPRD WHERE PRD014=1 AND PRD001='{0}' AND PRD004 IN ({1}) AND PRD006='{2}' AND PRD003='{3}') " ,model . PRD001 ,model . PRD004 ,model . PRD006 ,model . PRD003 );
            strSql . AppendFormat ( ",CFT AS (SELECT idx,PRD001,PRD004,PRD006,PRD003,PRD014,PRD015,PRD013 FROM MOXPRD WHERE PRD014=0 AND PRD001='{0}' AND PRD004 IN ({1}) AND PRD006='{2}' AND PRD003='{3}') " ,model . PRD001 ,model . PRD004 ,model . PRD006 ,model . PRD003 );
            strSql . AppendFormat ( ",CHT AS(SELECT a.idx idaa,b.idx FROM CET A INNER JOIN CFT B ON A.PRD001=B.PRD001 AND A.PRD003=B.PRD003 AND A.PRD004=B.PRD004 AND A.PRD006=B.PRD006 AND A.PRD015=B.PRD015)" );
            strSql . AppendFormat ( " SELECT DISTINCT PRD004,PRD014,PRD015 FROM MOXPRD WHERE idx NOT IN (SELECT idx FROM CHT) AND idx NOT IN (SELECT idaa FROM CHT)  AND PRD001='{0}' AND PRD004 IN ({1}) AND PRD006='{2}' AND PRD003='{3}'" ,model . PRD001 ,model . PRD004 ,model . PRD006 ,model . PRD003 );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                return null;
            else
            {
                foreach ( DataRow row in table . Rows )
                {
                    if ( tableUser . Select ( "PRD004='" + row [ "PRD004" ] + "'" ) . Length < 1 )
                    {
                        userList . Add ( row [ "PRD004" ] . ToString ( ) ,row [ "PRD005" ] . ToString ( ) );
                    }
                }
                return userList;
            }
        }

        /// <summary>
        /// 编辑工艺信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool editArt ( CarpenterEntity . ProductDailyWorkPREEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXPRE SET " );
            strSql . Append ( "PRE003=@PRE003," );
            strSql . Append ( "PRE004=@PRE004," );
            strSql . Append ( "PRE005=@PRE005," );
            strSql . Append ( "PRE006=@PRE006," );
            strSql . Append ( "PRE008=@PRE008," );
            strSql . Append ( "PRE009=@PRE009," );
            strSql . Append ( "PRE010=@PRE010," );
            strSql . Append ( "PRE011=@PRE011 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PRE003",SqlDbType.Decimal,12),
                new SqlParameter("@PRE004",SqlDbType.Decimal,12),
                new SqlParameter("@PRE005",SqlDbType.Decimal,12),
                new SqlParameter("@PRE006",SqlDbType.NVarChar,100),
                new SqlParameter("@PRE008",SqlDbType.Decimal,12),
                new SqlParameter("@PRE009",SqlDbType.Decimal,12),
                new SqlParameter("@PRE010",SqlDbType.Decimal,12),
                new SqlParameter("@PRE011",SqlDbType.Decimal,12),
                new SqlParameter("@idx",SqlDbType.Int,4)
            };
            parameter [ 0 ] . Value = model . PRE003;
            parameter [ 1 ] . Value = model . PRE004;
            parameter [ 2 ] . Value = model . PRE005;
            parameter [ 3 ] . Value = model . PRE006;
            parameter [ 4 ] . Value = model . PRE008;
            parameter [ 5 ] . Value = model . PRE009;
            parameter [ 6 ] . Value = model . PRE010;
            parameter [ 7 ] . Value = model . PRE011;
            parameter [ 8 ] . Value = model . idx;

            return SqlHelper . ExecuteNonQueryBool ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 获取工艺信息根据设备
        /// </summary>
        /// <param name="equCode"></param>
        /// <returns></returns>
        public DataTable getTableForArt ( string equCode )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT EQV002,EQV003 FROM MOXEQV WHERE EQV001='{0}'" ,equCode );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
