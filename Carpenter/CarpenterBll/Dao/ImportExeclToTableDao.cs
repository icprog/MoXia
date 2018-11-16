using System . Data;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;
using System;
using System . IO;
using NPOI . HSSF . UserModel;
using System . Drawing;
using NPOI . XSSF . UserModel;
using System . Collections . Generic;
using System . Linq;

namespace CarpenterBll . Dao
{
    public class ImportExeclToTableDao
    {
        /// <summary>
        /// 导入传票数据到库
        /// </summary>
        /// <param name="table"></param>
        /// <returns>0:成功  1:产品信息表中无此产品  2:失败</returns>
        public int Add ( DataTable table )
        {
            //, headI = 0
            int num = 0, para = 0;decimal dlNum = 0;
            string productInformation = string . Empty, rice = string . Empty, with = string . Empty, length = string . Empty, every = string . Empty, cp = string . Empty, dlyq = string . Empty, cz = string . Empty, pf = string . Empty, jjg = string . Empty, bz = string . Empty;
            bool isOk = false;
            DataTable dt;
            List<int> intList = new List<int> ( );
            List<string> strList = new List<string> ( );
            Hashtable SQLString = new Hashtable ( );
            CarpenterEntity . BomWorkPlanWOQEntity _modelOne = new CarpenterEntity . BomWorkPlanWOQEntity ( );
            CarpenterEntity . BomWorkPlanWOREntity _modelTwo = new CarpenterEntity . BomWorkPlanWOREntity ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                for ( int j = 0 ; j < table . Columns . Count ; j++ )
                {
                    productInformation = table . Rows [ i ] [ j ] . ToString ( );
                    if ( productInformation . Equals ( "产品信息" ) )
                    {
                        if ( _modelOne . WOQ008 == null )
                        {
                            _modelOne . WOQ008 = table . Rows [ i ] [ j + 1 ] . ToString ( );
                        }
                    }
                    cp = table . Rows [ i ] [ j ] . ToString ( );
                    cp = cp . Replace ( " " ,"" );
                    if ( cp . Contains ( "作业传票" ) )
                    {
                        foreach ( string s in ColumnValues . strWorkType )
                        {
                            if ( cp . Contains ( s ) )
                                _modelTwo . WOR016 = s;
                        }
                    }
                }

                if ( _modelOne . WOQ008 != null )
                {
                    for ( int j = 0 ; j < table . Columns . Count ; j++ )
                    {
                        productInformation = table . Rows [ i ] [ j ] . ToString ( );
                        if ( productInformation . Equals ( "产品信息" ) )
                        {
                            _modelTwo . WOR006 = table . Rows [ i + 1 ] [ j + 1 ] . ToString ( );
                        }

                        dlyq = table . Rows [ i ] [ j ] . ToString ( );
                        if ( dlyq . Contains ( " " ) )
                            dlyq = dlyq . Replace ( " " ,"" );
                        if ( dlyq . Equals ( "断料要求" ) )
                        {
                            _modelTwo . WOR027 = table . Rows [ i ] [ j + 1 ] . ToString ( );
                            if ( _modelTwo . WOR027 . Contains ( "=" ) )
                                _modelTwo . WOR027 = _modelTwo . WOR027 . Substring ( 0 ,_modelTwo . WOR027 . IndexOf ( "=" ) );
                        }
                        rice = table . Rows [ i ] [ j ] . ToString ( ) . Replace ( " " ,"" );
                        if ( rice . Equals ( "米" ) )
                        {
                            _modelTwo . WOR007 = table . Rows [ i ] [ j + 1 ] . ToString ( ) + table . Rows [ i ] [ j + 2 ] . ToString ( );
                            _modelTwo . WOR010 = table . Rows [ i ] [ j + 4 ] . ToString ( ) + table . Rows [ i ] [ j + 5 ] . ToString ( );
                            _modelTwo . WOR013 = table . Rows [ i ] [ j + 7 ] . ToString ( ) + table . Rows [ i ] [ j + 8 ] . ToString ( );
                        }
                        cz = table . Rows [ i ] [ j ] . ToString ( );
                        if ( cz . Contains ( " " ) )
                            cz = cz . Replace ( " " ,"" );
                        if ( cz . Equals ( "材质" ) )
                        {
                            _modelTwo . WOR018 = table . Rows [ i ] [ j + 1 ] . ToString ( );
                        }
                        pf = table . Rows [ i ] [ j ] . ToString ( );
                        if ( pf . Contains ( " " ) )
                            pf = pf . Replace ( " " ,"" );
                        if ( pf . Equals ( "拼法" ) )
                        {
                            _modelTwo . WOR025 = table . Rows [ i ] [ j + 1 ] . ToString ( );
                            with = table . Rows [ i ] [ j + 4 ] . ToString ( );
                            if ( with . Contains ( "宽" ) )
                                with = with . Substring ( 1 ,with . IndexOf ( "宽" )-1 );
                            para = 0;
                            if ( !string . IsNullOrEmpty ( with ) && int . TryParse ( with ,out para ) == true )
                                _modelTwo . WOR028 = para;
                            else
                                _modelTwo . WOR028 = 0;
                            length = table . Rows [ i ] [ j + 7 ] . ToString ( );
                            para = 0;
                            if ( !string . IsNullOrEmpty ( length ) && int . TryParse ( length ,out para ) == true )
                                _modelTwo . WOR029 = para;
                            else
                                _modelTwo . WOR029 = 0;
                        }
                        jjg = table . Rows [ i ] [ j ] . ToString ( );
                        if ( jjg . Contains ( " " ) )
                            jjg = jjg . Replace ( " " ,"" );
                        if ( jjg . Equals ( "机加工要求" ) )
                        {
                            _modelTwo . WOR026 = table . Rows [ i ] [ j + 1 ] . ToString ( ) + table . Rows [ i ] [ j + 4 ] . ToString ( );
                        }
                        every = table . Rows [ i ] [ j ] . ToString ( );
                        if ( every . Contains ( " " ) )
                            every = every . Replace ( " " ,"" );
                        if ( every . Equals ( "总单量" ) )
                        {
                            every = table . Rows [ i ] [ j + 1 ] . ToString ( );
                            dlNum = 0M;
                            if ( !string . IsNullOrEmpty ( every ) && decimal . TryParse ( every ,out dlNum ) == true )
                                _modelTwo . WOR017 = dlNum;
                            else
                                _modelTwo . WOR017 = 0;
                        }
                        bz = table . Rows [ i ] [ j ] . ToString ( );
                        if ( bz . Contains ( " " ) )
                            bz = bz . Replace ( " " ,"" );
                        if ( bz . Equals ( "备注" ) )
                        {
                            _modelTwo . WOR022 = table . Rows [ i ] [ j + 1 ] . ToString ( );
                        }

                        if ( table . Rows [ i ] [ j ] . ToString ( ) . Contains ( "手砂" ) )
                        {
                            isOk = true;
                            break;
                        }
                    }

                    if ( isOk == true )
                    {
                        isOk = false;

                        dt = tableProduct ( _modelOne . WOQ008 );
                        if ( dt!=null && dt.Rows.Count>0 )
                        {
                            _modelOne . WOQ001 = _modelTwo . WOR001 = dt . Rows [ 0 ] [ "OPI001" ] . ToString ( );
                            //_modelOne . WOQ009 = dt . Rows [ 0 ] [ "OPI005" ] . ToString ( );

                            _modelTwo . WOR019 = 0;
                            _modelTwo . WOR023 = UserInformation . dt ( );
                            _modelTwo . WOR024 = UserInformation . UserName;
                            _modelTwo . WOR034 = new byte [ 0 ];
                            if ( !string . IsNullOrEmpty ( _modelTwo . WOR006 ) )
                            {
                                if ( Exists_partName ( _modelTwo ) )
                                {
                                    if ( edit_wor ( _modelTwo ) == false )
                                    {
                                        num = 3;
                                        break;
                                    }
                                }
                                else
                                {
                                    if ( !strList . Contains ( "零件名称：" + _modelTwo . WOR006 + " 规格：" + _modelTwo . WOR007 + "*" + _modelTwo . WOR010 + "*" + _modelTwo . WOR013 ) )
                                        strList . Add ( "零件名称：" + _modelTwo . WOR006 + " 规格：" + _modelTwo . WOR007 + "*" + _modelTwo . WOR010 + "*" + _modelTwo . WOR013 );
                                }
                            }

                        }
                        else
                        {
                            num = 1;
                            break;
                        }

                        //_modelTwo . WOR005 = i . ToString ( );
                        //_modelTwo . WOR005 = _modelTwo . WOR005 . PadLeft ( 3 ,'0' );
                        //dl = partNum ( _modelOne . WOQ001 );
                        //if ( dl != null && dl . Rows . Count > 0 )
                        //{
                        //    if ( dl . Select ( "WOR005='" + _modelTwo . WOR005 + "'" ) . Length < 1 )
                        //    {
                        //        if ( intList . Contains ( Convert . ToInt32 ( _modelTwo . WOR005 ) ) )
                        //        {
                        //            _modelTwo . WOR005 = ( intList . Max ( ) + 1 ) . ToString ( );
                        //            intList . Add ( Convert . ToInt32 ( _modelTwo . WOR005 ) );
                        //        }
                        //        else
                        //        {
                        //            intList . Add ( Convert . ToInt32 ( _modelTwo . WOR005 ) );
                        //        }
                        //    }
                        //    else
                        //    {
                        //        _modelTwo . WOR005 = dl . Compute ( "MAX(WOR005)" ,null ) . ToString ( );
                        //        _modelTwo . WOR005 = ( Convert . ToInt32 ( _modelTwo . WOR005 ) + 1 ) . ToString ( );
                        //        if ( intList . Contains ( Convert . ToInt32 ( _modelTwo . WOR005 ) ) )
                        //        {
                        //            _modelTwo . WOR005 = ( intList . Max ( ) + 1 ) . ToString ( );
                        //            intList . Add ( Convert . ToInt32 ( _modelTwo . WOR005 ) );
                        //        }
                        //        else
                        //        {
                        //            intList . Add ( Convert . ToInt32 ( _modelTwo . WOR005 ) );
                        //        }
                        //    }
                        //}

                        //_modelOne . WOQ002 = UserInformation . dt ( );
                        //_modelOne . WOQ003 = UserInformation . dt ( );
                        //_modelOne . WOQ004 = string . Empty;
                        //_modelOne . WOQ005 = UserInformation . dt ( );
                        //_modelOne . WOQ006 = UserInformation . UserName;
                        //_modelOne . WOQ007 = false;
                        //_modelOne . WOQ010 = false;


                        //dt = tablePart ( _modelTwo . WOR001 ,_modelTwo . WOR006 );
                        //if ( dt != null && dt . Rows . Count > 0 )
                        //{
                        //    if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "WOR005" ] . ToString ( ) ) )
                        //    {
                        //        //if ( getNum ( _modelTwo . WOR001 ) != string . Empty )
                        //        //    _modelTwo . WOR005 = getNum ( _modelTwo . WOR001 );
                        //        if ( headI == 0 && Exists ( _modelOne . WOQ001 ) == false )
                        //            add_woq ( SQLString ,_modelOne );

                        //        add_wor ( SQLString ,_modelTwo );
                        //        headI++;
                        //        _modelTwo = new CarpenterEntity . BomWorkPlanWOREntity ( );
                        //    }
                        //}
                        //else
                        //{
                        //    if ( headI == 0 )
                        //        add_woq ( SQLString ,_modelOne );
                        //    add_wor ( SQLString ,_modelTwo );
                        //    headI++;
                        //    _modelTwo = new CarpenterEntity . BomWorkPlanWOREntity ( );
                        //}

                    }
                }
                if ( num == 3 )
                    break;
            }

            UserInformation . StrList = strList;

            if ( num == 1 )
                return 1;
            else if ( num == 3 )
                return 3;
            else
                return 2;
        }

        /// <summary>
        /// 是否存在此品号对应的零件
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        DataTable tablePart ( string productNum,string partName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MAX(WOR005) WOR005 FROM MOXWOR WHERE WOR001='{0}' AND WOR006='{1}'" ,productNum ,partName );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取零件编号
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        DataTable partNum ( string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT WOR005 FROM  MOXWOR WHERE WOR001='{0}'" ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// BOM清单里面是否有此品号
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        bool Exists ( string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXWOQ " );
            strSql . AppendFormat ( "WHERE WOQ001='{0}'" ,productNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在产品
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        bool tableProductBool ( string productName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXWOQ " );
            strSql . AppendFormat ( "WHERE WOQ008='{0}'" ,productName );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        DataTable tableProduct ( string productName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT OPI001,OPI005 FROM MOXOPI " );
            strSql . AppendFormat ( "WHERE OPI002='{0}' AND OPI011=0" ,productName );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        string getNum ( string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MAX(WOR005) WOR005 FROM MOXWOR WHERE WOR001='{0}'" ,productNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "WOR005" ] . ToString ( ) ) )
                    return string . Empty;
                else
                {
                    return ( Convert . ToInt32 ( dt . Rows [ 0 ] [ "WOR005" ] . ToString ( ) ) + 1 ) . ToString ( ) . PadLeft ( 3 ,'0' );
                }
            }
            else
                return string . Empty;
        }

        void add_woq ( Hashtable SQLString,CarpenterEntity . BomWorkPlanWOQEntity _modelOne )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXWOQ (" );
            strSql . Append ( "WOQ001,WOQ002,WOQ003,WOQ004,WOQ005,WOQ006,WOQ007,WOQ008,WOQ009,WOQ010) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@WOQ001,@WOQ002,@WOQ003,@WOQ004,@WOQ005,@WOQ006,@WOQ007,@WOQ008,@WOQ009,@WOQ010) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WOQ001",SqlDbType.NVarChar,20),
                new SqlParameter("@WOQ002",SqlDbType.Date),
                new SqlParameter("@WOQ003",SqlDbType.Date),
                new SqlParameter("@WOQ004",SqlDbType.NVarChar,20),
                new SqlParameter("@WOQ005",SqlDbType.Date),
                new SqlParameter("@WOQ006",SqlDbType.NVarChar,20),
                new SqlParameter("@WOQ007",SqlDbType.Bit),
                new SqlParameter("@WOQ008",SqlDbType.NVarChar,20),
                new SqlParameter("@WOQ009",SqlDbType.NVarChar,20),
                new SqlParameter("@WOQ010",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _modelOne . WOQ001;
            parameter [ 1 ] . Value = _modelOne . WOQ002;
            parameter [ 2 ] . Value = _modelOne . WOQ003;
            parameter [ 3 ] . Value = _modelOne . WOQ004;
            parameter [ 4 ] . Value = _modelOne . WOQ005;
            parameter [ 5 ] . Value = _modelOne . WOQ006;
            parameter [ 6 ] . Value = _modelOne . WOQ007;
            parameter [ 7 ] . Value = _modelOne . WOQ008;
            parameter [ 8 ] . Value = _modelOne . WOQ009;
            parameter [ 9 ] . Value = _modelOne . WOQ010;
            SQLString . Add ( strSql ,parameter );
        }

        void add_wor ( Hashtable SQLString ,CarpenterEntity . BomWorkPlanWOREntity _modelTwo )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXWOR (" );
            strSql . Append ( "WOR001,WOR005,WOR006,WOR007,WOR010,WOR013,WOR016,WOR017,WOR018,WOR019,WOR022,WOR023,WOR024,WOR025,WOR026,WOR027,WOR028,WOR029,WOR034) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@WOR001,@WOR005,@WOR006,@WOR007,@WOR010,@WOR013,@WOR016,@WOR017,@WOR018,@WOR019,@WOR022,@WOR023,@WOR024,@WOR025,@WOR026,@WOR027,@WOR028,@WOR029,@WOR034) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WOR001",SqlDbType.NVarChar,20),
                new SqlParameter("@WOR005",SqlDbType.NVarChar,20),
                new SqlParameter("@WOR006",SqlDbType.NVarChar,20),
                new SqlParameter("@WOR007",SqlDbType.NVarChar,10),
                new SqlParameter("@WOR010",SqlDbType.NVarChar,10),
                new SqlParameter("@WOR013",SqlDbType.NVarChar,10),
                new SqlParameter("@WOR016",SqlDbType.NVarChar,10),
                new SqlParameter("@WOR017",SqlDbType.Decimal,5),
                new SqlParameter("@WOR018",SqlDbType.NVarChar,50),
                new SqlParameter("@WOR019",SqlDbType.Int),
                new SqlParameter("@WOR022",SqlDbType.NVarChar,500),
                new SqlParameter("@WOR023",SqlDbType.Date),
                new SqlParameter("@WOR024",SqlDbType.NVarChar,20),
                new SqlParameter("@WOR025",SqlDbType.NVarChar,50),
                new SqlParameter("@WOR026",SqlDbType.NVarChar,50),
                new SqlParameter("@WOR027",SqlDbType.NVarChar,50),
                new SqlParameter("@WOR028",SqlDbType.Int),
                new SqlParameter("@WOR029",SqlDbType.Int),
                new SqlParameter("@WOR034",SqlDbType.Image)
            };
            parameter [ 0 ] . Value = _modelTwo . WOR001 . Trim ( );
            parameter [ 1 ] . Value = _modelTwo . WOR005 . Trim ( );
            parameter [ 2 ] . Value = _modelTwo . WOR006 . Trim ( );
            parameter [ 3 ] . Value = _modelTwo . WOR007 . Trim ( );
            parameter [ 4 ] . Value = _modelTwo . WOR010 . Trim ( );
            parameter [ 5 ] . Value = _modelTwo . WOR013 . Trim ( );
            parameter [ 6 ] . Value = _modelTwo . WOR016 . Trim ( );
            parameter [ 7 ] . Value = _modelTwo . WOR017;
            parameter [ 8 ] . Value = _modelTwo . WOR018 . Trim ( );
            parameter [ 9 ] . Value = _modelTwo . WOR019;
            parameter [ 10 ] . Value = _modelTwo . WOR022 . Trim ( );
            parameter [ 11 ] . Value = _modelTwo . WOR023;
            parameter [ 12 ] . Value = _modelTwo . WOR024 . Trim ( );
            parameter [ 13 ] . Value = _modelTwo . WOR025 . Trim ( );
            parameter [ 14 ] . Value = _modelTwo . WOR026 . Trim ( );
            parameter [ 15 ] . Value = _modelTwo . WOR027 . Trim ( );
            parameter [ 16 ] . Value = _modelTwo . WOR028;
            parameter [ 17 ] . Value = _modelTwo . WOR029;
            parameter [ 18 ] . Value = _modelTwo . WOR034;
            SQLString . Add ( strSql ,parameter );
        }

        bool edit_wor (  CarpenterEntity . BomWorkPlanWOREntity _modelTwo )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWOR SET " );
            strSql . Append ( "WOR016=@WOR016,WOR017=@WOR017,WOR018=@WOR018,WOR019=@WOR019,WOR022=@WOR022,WOR023=@WOR023,WOR024=@WOR024,WOR025=@WOR025,WOR026=@WOR026,WOR027=@WOR027,WOR028=@WOR028,WOR029=@WOR029,WOR034=@WOR034 " );
            strSql . Append ( "WHERE WOR001=@WOR001 AND WOR006=@WOR006 AND WOR007=@WOR007 AND WOR010=@WOR010 AND WOR013=@WOR013" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WOR001",SqlDbType.NVarChar,20),
                new SqlParameter("@WOR006",SqlDbType.NVarChar,20),
                new SqlParameter("@WOR007",SqlDbType.NVarChar,10),
                new SqlParameter("@WOR010",SqlDbType.NVarChar,10),
                new SqlParameter("@WOR013",SqlDbType.NVarChar,10),
                new SqlParameter("@WOR016",SqlDbType.NVarChar,10),
                new SqlParameter("@WOR017",SqlDbType.Decimal,5),
                new SqlParameter("@WOR018",SqlDbType.NVarChar,50),
                new SqlParameter("@WOR019",SqlDbType.Int),
                new SqlParameter("@WOR022",SqlDbType.NVarChar,500),
                new SqlParameter("@WOR023",SqlDbType.Date),
                new SqlParameter("@WOR024",SqlDbType.NVarChar,20),
                new SqlParameter("@WOR025",SqlDbType.NVarChar,50),
                new SqlParameter("@WOR026",SqlDbType.NVarChar,50),
                new SqlParameter("@WOR027",SqlDbType.NVarChar,50),
                new SqlParameter("@WOR028",SqlDbType.Int),
                new SqlParameter("@WOR029",SqlDbType.Int),
                new SqlParameter("@WOR034",SqlDbType.Image)
            };
            parameter [ 0 ] . Value = _modelTwo . WOR001 . Trim ( );
            parameter [ 1 ] . Value = _modelTwo . WOR006 . Trim ( );
            parameter [ 2 ] . Value = _modelTwo . WOR007 . Trim ( );
            parameter [ 3 ] . Value = _modelTwo . WOR010 . Trim ( );
            parameter [ 4 ] . Value = _modelTwo . WOR013 . Trim ( );
            parameter [ 5 ] . Value = _modelTwo . WOR016 . Trim ( );
            parameter [ 6 ] . Value = _modelTwo . WOR017;
            parameter [ 7 ] . Value = _modelTwo . WOR018 . Trim ( );
            parameter [ 8 ] . Value = _modelTwo . WOR019;
            parameter [ 9 ] . Value = _modelTwo . WOR022 . Trim ( );
            parameter [ 10 ] . Value = _modelTwo . WOR023;
            parameter [ 11 ] . Value = _modelTwo . WOR024 . Trim ( );
            parameter [ 12 ] . Value = _modelTwo . WOR025 . Trim ( );
            parameter [ 13 ] . Value = _modelTwo . WOR026 . Trim ( );
            parameter [ 14 ] . Value = _modelTwo . WOR027 . Trim ( );
            parameter [ 15 ] . Value = _modelTwo . WOR028;
            parameter [ 16 ] . Value = _modelTwo . WOR029;
            parameter [ 17 ] . Value = _modelTwo . WOR034;
        
            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 保存图片到指定文件夹下面
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        public bool ExeclToImage ( string filePath ,string savePath ,DataTable table ,string Version )
        {
            try
            {
                string productInformation = string . Empty;
                CarpenterEntity . BomWorkPlanWOQEntity _modelOne = new CarpenterEntity . BomWorkPlanWOQEntity ( );
                bool isOk = true;
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    for ( int j = 0 ; j < table . Columns . Count ; j++ )
                    {
                        productInformation = table . Rows [ i ] [ j ] . ToString ( );
                        if ( productInformation . Equals ( "产品信息" ) )
                        {
                            if ( _modelOne . WOQ008 == null )
                            {
                                _modelOne . WOQ008 = table . Rows [ i ] [ j + 1 ] . ToString ( );
                                isOk = false;
                                break;
                            }
                        }
                    }
                    if ( isOk == false )
                        break;
                }

                if ( Version . Equals ( ".xls" ) )
                {
                    xls ( filePath ,savePath ,_modelOne . WOQ008 );
                }
                if ( Version . Equals ( ".xlsx" ) )
                {
                    xlsx ( filePath ,savePath ,_modelOne . WOQ008 );
                }

            }
            catch (Exception ex){
                Utility . LogHelper . WriteLog ( ex . Message + "\n\r" + ex . StackTrace );
                return false;
            }

            return true;
        }

        void xlsx ( string filePath ,string savePath ,string productName )
        {
            using ( FileStream fsReader = File . OpenRead ( filePath ) )
            {
                XSSFWorkbook wk = new XSSFWorkbook ( fsReader );
                IList pictures = wk . GetAllPictures ( );
                int i = 0;

                if ( string . IsNullOrEmpty ( productName ) )
                    savePath = Path . Combine ( savePath ,"产品零件图片\\" );
                else
                    savePath = Path . Combine ( savePath ,productName + "\\" );
                if ( !Directory . Exists ( savePath ) )//判断是否存在保存文件夹，没有则新建
                    Directory . CreateDirectory ( savePath );
                else
                    i = System . IO . Directory . GetFiles ( savePath ) . Length;

                foreach ( XSSFPictureData pic in pictures )
                {
                    //if (pic.Data.Length == 19504) //跳过不需要保存的图片，其中pic.data有图片长度
                    //    continue;
                    string ext = pic . SuggestFileExtension ( );//获取扩展名
                    string path = string . Empty;
                    //if ( ext . Equals ( "jpg" ) )
                    //{
                    Image jpg = Image . FromStream ( new MemoryStream ( pic . Data ) );//从pic.Data数据流创建图片
                    path = Path . Combine ( savePath ,string . Format ( "pic{0}." + ext ,i++ ) );
                    jpg . Save ( path );//保存
                    //}
                    //else if ( ext . Equals ( "png" ) )
                    //{
                    //    Image png = Image . FromStream ( new MemoryStream ( pic . Data ) );
                    //    path = Path . Combine ( savePath ,string . Format ( "pic{0}.png" ,i++ ) );
                    //    png . Save ( path );
                    //}
                    //else if ( ext . Equals ( "jpeg" ) )
                    //{
                    //    Image png = Image . FromStream ( new MemoryStream ( pic . Data ) );
                    //    path = Path . Combine ( savePath ,string . Format ( "pic{0}.jpeg" ,i++ ) );
                    //    png . Save ( path );
                    //}

                }
            }
        }

        void xls ( string filePath ,string savePath ,string productName )
        {
            using ( FileStream fsReader = File . OpenRead ( filePath ) )
            {
                HSSFWorkbook wk = new HSSFWorkbook ( fsReader );
                IList pictures = wk . GetAllPictures ( );
                int i = 0;

                if ( string . IsNullOrEmpty ( productName ) )
                    savePath = Path . Combine ( savePath ,"产品零件图片\\" );
                else
                    savePath = Path . Combine ( savePath ,productName + "\\" );
                if ( !Directory . Exists ( savePath ) )//判断是否存在保存文件夹，没有则新建
                    Directory . CreateDirectory ( savePath );
                else
                    i = System . IO . Directory . GetFiles ( savePath ) . Length;

                foreach ( HSSFPictureData pic in pictures )
                {
                    //if (pic.Data.Length == 19504) //跳过不需要保存的图片，其中pic.data有图片长度
                    //    continue;
                    string ext = pic . SuggestFileExtension ( );//获取扩展名
                    string path = string . Empty;
                    if ( ext . Equals ( "jpg" ) )
                    {
                        Image jpg = Image . FromStream ( new MemoryStream ( pic . Data ) );//从pic.Data数据流创建图片
                        path = Path . Combine ( savePath ,string . Format ( "pic{0}.jpg" ,i++ ) );
                        jpg . Save ( path );//保存
                    }
                    else if ( ext . Equals ( "png" ) )
                    {
                        Image png = Image . FromStream ( new MemoryStream ( pic . Data ) );
                        path = Path . Combine ( savePath ,string . Format ( "pic{0}.png" ,i++ ) );
                        png . Save ( path );
                    }
                    //if ( !string . IsNullOrEmpty ( path ) )
                    //    listPath . Add ( path );
                }
            }
        }

        /// <summary>
        /// 导入清单
        /// </summary>
        /// <param name="table"></param>
        /// <returns>1：清单上面的产品不存在于产品信息  2：部分零件没有规格 3：正常</returns>
        public int ExeclToOrder ( DataTable table )
        {
            CarpenterEntity . BomWorkPlanWOQEntity _modelOne = new CarpenterEntity . BomWorkPlanWOQEntity ( );
            CarpenterEntity . BomWorkPlanWOREntity _modelTwo = new CarpenterEntity . BomWorkPlanWOREntity ( );

            DataTable dt;
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            string partName = string . Empty, partSpace = string . Empty, partSpaceTable = string . Empty, partNumOf = string . Empty, len = string . Empty, width = string . Empty, heigh = string . Empty, partNames = string . Empty, partSpaces = string . Empty, orderNum = string . Empty;
            int partNum = 0, num = 0, idx = 0;
            _modelOne . WOQ008 =  table . Rows [ 0 ] [ 0 ] . ToString ( );
            dt = tableProduct ( _modelOne . WOQ008 );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "OPI001" ] . ToString ( ) ) )
                    return 1;
                else
                {
                    _modelOne . WOQ001 = _modelTwo . WOR001 = dt . Rows [ 0 ] [ "OPI001" ] . ToString ( ) . Trim ( );
                    _modelOne . WOQ002 = UserInformation . dt ( );
                    _modelOne . WOQ003 = UserInformation . dt ( );
                    _modelOne . WOQ004 = string . Empty;
                    _modelOne . WOQ005 = UserInformation . dt ( );
                    _modelOne . WOQ006 = UserInformation . UserName;
                    _modelOne . WOQ007 = false;
                    _modelOne . WOQ009 = dt . Rows [ 0 ] [ "OPI005" ] . ToString ( ) . Trim ( );
                    _modelOne . WOQ010 = false;

                    if ( Exists_woq ( _modelOne . WOQ001 ) == false )
                    {
                        if ( add_woq ( strSql ,_modelOne ) == false )
                            return 3;
                    }
                }
            }
            else
                return 1;


            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                for ( int j = 0 ; j < table . Columns . Count ; j++ )
                {
                    partName = table . Rows [ i ] [ j ] . ToString ( );
                    if ( partName . Contains ( " " ) )
                        partName = partName . Replace ( " " ,"" );
                    if ( partName . Equals ( "零件名称" ) )
                    {
                        partNum = 0;
                        while ( true )
                        {
                            partNum++;
                            _modelTwo . WOR005 = partNum . ToString ( ) . PadLeft ( 3 ,'0' ) . Trim ( );
                            _modelTwo . WOR006 = table . Rows [ i + 1 ] [ j ] . ToString ( ) . Trim ( );
                            _modelTwo . WOR030 = table . Rows [ i + 1 ] [ j+5 ] . ToString ( ) . Trim ( );
                            partSpace = table . Rows [ i + 1 ] [ j + 1 ] . ToString ( ) . Trim ( );
                            if ( !string . IsNullOrEmpty ( partSpace ) )
                            {
                                string [ ] str = partSpace . Split ( '*' );
                                if ( str . Length > 2 )
                                {
                                    _modelTwo . WOR007 = str [ 0 ] . Trim ( );
                                    _modelTwo . WOR010 = str [ 1 ] . Trim ( );
                                    _modelTwo . WOR013 = str [ 2 ] . Trim ( );
                                }
                                else if ( str . Length > 1 )
                                {
                                    _modelTwo . WOR007 = str [ 0 ] . Trim ( );
                                    _modelTwo . WOR010 = str [ 1 ] . Trim ( );
                                    _modelTwo . WOR013 = string . Empty;
                                }
                                else if ( str . Length == 1 )
                                {
                                    _modelTwo . WOR007 = str [ 0 ] . Trim ( );
                                    _modelTwo . WOR010 = string . Empty;
                                    _modelTwo . WOR013 = string . Empty;
                                }
                                else
                                {
                                    _modelTwo . WOR007 = string . Empty;
                                    _modelTwo . WOR010 = string . Empty;
                                    _modelTwo . WOR013 = string . Empty;
                                }
                            }
                            else
                            {
                                _modelTwo . WOR007 = string . Empty;
                                _modelTwo . WOR010 = string . Empty;
                                _modelTwo . WOR013 = string . Empty;
                            }

                            int orNum = 0;
                            orderNum = table . Rows [ i + 1 ] [ j + 2 ] . ToString ( );
                            if ( !string . IsNullOrEmpty ( orderNum ) && int . TryParse ( orderNum ,out orNum ) == true )
                                _modelTwo . WOR017 = string . IsNullOrEmpty ( table . Rows [ i + 1 ] [ j + 2 ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i + 1 ] [ j + 2 ] . ToString ( ) );
                            else
                                _modelTwo . WOR017 = 0;

                            if ( !string . IsNullOrEmpty ( _modelTwo . WOR006 ) )
                            {
                                if ( !string . IsNullOrEmpty ( _modelTwo . WOR007 ) )
                                {
                                    //存在品号  零件名称  规格
                                    if ( Exists_partName ( _modelTwo ) )
                                    {
                                        partNumOf = getPartNum ( _modelTwo );
                                        //导入和已经存在的一致
                                        if ( partNumOf . Equals ( _modelTwo . WOR005 ) )
                                        {
                                            if ( edit_wor ( strSql ,_modelTwo ) == false )
                                            {
                                                num = 3;
                                                break;
                                            }
                                        }
                                        //导入和已经存在的不一致
                                        else
                                        {
                                            if ( Exists_partNum ( _modelTwo . WOR005 ,_modelTwo . WOR001 ) )
                                            {
                                                _modelTwo . idx = idxWor ( _modelTwo . WOR001 ,_modelTwo . WOR005 );

                                                partNumOf = getMaxPartNum ( _modelTwo . WOR001 );
                                                partNumOf = ( Convert . ToInt32 ( partNumOf ) + 1 ) . ToString ( ) . PadLeft ( 3 ,'0' ) . Trim ( );

                                                if ( edit_wor ( strSql ,_modelTwo . idx ,partNumOf ) == false )
                                                {
                                                    num = 3;
                                                    break;
                                                }
                                                else
                                                {
                                                    if ( edit_wor ( strSql ,_modelTwo ) == false )
                                                    {
                                                        num = 3;
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if ( edit_wor ( strSql ,_modelTwo ) == false )
                                                {
                                                    num = 3;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    //不存在品号  零件名称  规格
                                    else
                                    {
                                        if ( Exists_partNum ( _modelTwo . WOR005 ,_modelTwo . WOR001 ) )
                                        {
                                            _modelTwo . idx = idxWor ( _modelTwo . WOR001 ,_modelTwo . WOR005 );
                                            partNumOf = getMaxPartNum ( _modelTwo . WOR001 );
                                            partNumOf = ( Convert . ToInt32 ( partNumOf ) + 1 ) . ToString ( ) . PadLeft ( 3 ,'0' ) . Trim ( );

                                            if ( edit_wor ( strSql ,_modelTwo . idx ,partNumOf ) == false )
                                            {
                                                num = 3;
                                                break;
                                            }
                                            else
                                            {
                                                if ( add_wor ( strSql ,_modelTwo ) == false )
                                                {
                                                    num = 3;
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if ( add_wor ( strSql ,_modelTwo ) == false )
                                            {
                                                num = 3;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                    num = 2;
                            }

                            i++;
                            if ( i == table . Rows . Count - 1 )
                            {
                                break;
                            }
                        }

                        dt = partInformation ( _modelTwo . WOR001 );
                        if ( dt != null && dt . Rows . Count > 0 )
                        {
                            for ( int k = 0 ; k < dt . Rows . Count ; k++ )
                            {
                                DataRow row = dt . Rows [ k ];
                                _modelTwo . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                                _modelTwo . WOR006 = row [ "WOR006" ] . ToString ( );
                                _modelTwo . WOR007 = row [ "WOR" ] . ToString ( );

                                while ( true )
                                {
                                    if ( _modelTwo . WOR007 . Substring ( _modelTwo . WOR007 . Length - 1 ,1 ) . Equals ( "*" ) )
                                        _modelTwo . WOR007 = _modelTwo . WOR007 . Substring ( 0 ,_modelTwo . WOR007 . Length - 1 );
                                    else
                                        break;
                                }

                                idx = 0;

                                for ( int m = 0 ; m < table . Rows . Count ; m++ )
                                {
                                    for ( int n = 0 ; n < table . Columns . Count ; n++ )
                                    {
                                        partNames = table . Rows [ m ] [ n ] . ToString ( ) . Trim ( );
                                        if ( partNames . Equals ( "零件名称" ) )
                                        {

                                            if ( table . Select ( "[" + ( n + 1 ) + "]='" + _modelTwo . WOR006 + "' AND [" + ( n + 2 ) + "]='" + _modelTwo . WOR007 + "'" ) . Length < 1 )
                                            {
                                                if ( delete_wor ( strSql ,_modelTwo . idx ) == false )
                                                {
                                                    num = 3;
                                                    break;
                                                }
                                            }


                                            idx = 1;
                                            break;

                                        }
                                    }

                                    if ( idx == 1 )
                                        break;
                                }
                            }
                            if ( num == 3 )
                                break;
                        }

                    }
                }

                if ( num == 3 )
                    break;
            }

            if ( num == 3 )
            {
                return 3;
            }
            else
            {
                if ( num == 2 )
                    return 2;
                else
                    return 4;
            }
        }


        /// <summary>
        /// 是否存在表头
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        bool Exists_woq ( string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXWOQ " );
            strSql . AppendFormat ( "WHERE WOQ001='{0}'" ,productNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        bool add_woq ( StringBuilder strSql ,CarpenterEntity . BomWorkPlanWOQEntity _modelOne )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXWOQ (" );
            strSql . Append ( "WOQ001,WOQ002,WOQ003,WOQ004,WOQ005,WOQ006,WOQ007,WOQ008,WOQ009,WOQ010) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@WOQ001,@WOQ002,@WOQ003,@WOQ004,@WOQ005,@WOQ006,@WOQ007,@WOQ008,@WOQ009,@WOQ010) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WOQ001",SqlDbType.NVarChar,20),
                new SqlParameter("@WOQ002",SqlDbType.Date),
                new SqlParameter("@WOQ003",SqlDbType.Date),
                new SqlParameter("@WOQ004",SqlDbType.NVarChar,20),
                new SqlParameter("@WOQ005",SqlDbType.Date),
                new SqlParameter("@WOQ006",SqlDbType.NVarChar,20),
                new SqlParameter("@WOQ007",SqlDbType.Bit),
                new SqlParameter("@WOQ008",SqlDbType.NVarChar,20),
                new SqlParameter("@WOQ009",SqlDbType.NVarChar,20),
                new SqlParameter("@WOQ010",SqlDbType.Bit)
            };
            parameter [ 0 ] . Value = _modelOne . WOQ001;
            parameter [ 1 ] . Value = _modelOne . WOQ002;
            parameter [ 2 ] . Value = _modelOne . WOQ003;
            parameter [ 3 ] . Value = _modelOne . WOQ004;
            parameter [ 4 ] . Value = _modelOne . WOQ005;
            parameter [ 5 ] . Value = _modelOne . WOQ006;
            parameter [ 6 ] . Value = _modelOne . WOQ007;
            parameter [ 7 ] . Value = _modelOne . WOQ008;
            parameter [ 8 ] . Value = _modelOne . WOQ009;
            parameter [ 9 ] . Value = _modelOne . WOQ010;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取所有大于导入的零件编号
        /// </summary>
        /// <param name="partNum"></param>
        /// <returns></returns>
        DataTable tableWor ( string partNum ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,WOR005 FROM MOXWOR WHERE WOR001='{1}' AND WOR005>='{0}' ORDER BY WOR005 DESC" ,partNum ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        bool edit_wor (StringBuilder strSql, int idx,string partNum )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWOR SET " );
            strSql . Append ( "WOR005=@WOR005 " );
            strSql . Append ( "WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WOR005",SqlDbType.NVarChar,20),
                new SqlParameter("@idx",SqlDbType.Int,4)
            };
            parameter [ 0 ] . Value = partNum;
            parameter [ 1 ] . Value = idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        bool add_wor ( StringBuilder strSql ,CarpenterEntity . BomWorkPlanWOREntity _wor )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXWOR " );
            strSql . Append ( "(WOR001,WOR005,WOR006,WOR007,WOR010,WOR013,WOR017,WOR030) " );
            strSql . Append ( "VALUES ( " );
            strSql . Append ( "@WOR001,@WOR005,@WOR006,@WOR007,@WOR010,@WOR013,@WOR017,@WOR030) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WOR001",SqlDbType.NVarChar,20),
                new SqlParameter("@WOR005",SqlDbType.NVarChar,20),
                new SqlParameter("@WOR006",SqlDbType.NVarChar,20),
                new SqlParameter("@WOR007",SqlDbType.NVarChar,10),
                new SqlParameter("@WOR010",SqlDbType.NVarChar,10),
                new SqlParameter("@WOR013",SqlDbType.NVarChar,10),
                new SqlParameter("@WOR017",SqlDbType.Decimal,10),
                new SqlParameter("@WOR030",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _wor . WOR001;
            parameter [ 1 ] . Value = _wor . WOR005;
            parameter [ 2 ] . Value = _wor . WOR006;
            parameter [ 3 ] . Value = _wor . WOR007;
            parameter [ 4 ] . Value = _wor . WOR010;
            parameter [ 5 ] . Value = _wor . WOR013;
            parameter [ 6 ] . Value = _wor . WOR017;
            parameter [ 7 ] . Value = _wor . WOR030;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在零件编号
        /// </summary>
        /// <param name="partNum"></param>
        /// <returns></returns>
        bool Exists_partNum ( string partNum ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXWOR " );
            strSql . AppendFormat ( "WHERE WOR001='{1}' AND WOR005='{0}'" ,partNum ,productNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取零件信息
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        DataTable partInformation ( string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,WOR006,WOR007+'*'+WOR010+'*'+WOR013 WOR FROM MOXWOR WHERE WOR001='{0}' " ,productNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 根据品号获取最大零件编号
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        string getMaxPartNum ( string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(WOR005) WOR005 FROM MOXWOR " );
            strSql . AppendFormat ( "WHERE WOR001='{0}'" ,productNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "WOR005" ] . ToString ( ) ) )
                    return string . Empty;
                else
                    return dt . Rows [ 0 ] [ "WOR005" ] . ToString ( );
            }
            else
                return string . Empty;
        }

        /// <summary>
        /// 根据零件编号和品号获取零件名称
        /// </summary>
        /// <param name="partNum"></param>
        /// <returns></returns>
        DataTable getPartName (string partNum ,string productNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT WOR006,WOR007+'*'+WOR010+'*'+WOR013 WOR FROM MOXWOR " );
            strSql . AppendFormat ( "WHERE WOR001='{1}' AND WOR005='{0}'" ,partNum ,productNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return dt;
            else
                return null;
        }
  
        /// <summary>
        /// 是否存在零件名称 和 规格
        /// </summary>
        /// <param name="partNum"></param>
        /// <returns></returns>
        bool Exists_partName ( CarpenterEntity . BomWorkPlanWOREntity _wor )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXWOR " );
            strSql . AppendFormat ( "WHERE WOR001='{0}' AND WOR006='{1}' AND WOR007='{2}' AND WOR010='{3}' AND WOR013='{4}'" ,_wor . WOR001 ,_wor . WOR006 ,_wor . WOR007 ,_wor . WOR010 ,_wor . WOR013 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 根据零件名称 规格 品号  获取零件编号
        /// </summary>
        /// <param name="_wor"></param>
        /// <returns></returns>
        string getPartNum ( CarpenterEntity . BomWorkPlanWOREntity _wor )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT WOR005 FROM MOXWOR " );
            strSql . AppendFormat ( "WHERE WOR001='{0}' AND WOR006='{1}' AND WOR007='{2}' AND WOR010='{3}' AND WOR013='{4}'" ,_wor . WOR001 ,_wor . WOR006 ,_wor . WOR007 ,_wor . WOR010 ,_wor . WOR013 );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "WOR005" ] . ToString ( ) ) )
                    return string . Empty;
                else
                    return dt . Rows [ 0 ] [ "WOR005" ] . ToString ( );
            }
            else
                return string . Empty;
        }

        /// <summary>
        /// 是否存在零件名称  品号
        /// </summary>
        /// <param name="productNum"></param>
        /// <param name="partName"></param>
        /// <returns></returns>
        bool Exists_PartName ( string productNum ,string partName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM MOXWOR " );
            strSql . AppendFormat ( "WHERE WOR001='{0}' AND WOR006='{1}'" ,productNum ,partName );

            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                return true;
            else
                return false;
        }

        bool delete_wor ( StringBuilder strSql,int idx)
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM MOXWOR " );
            strSql . Append ( "WHERE idx=@idx " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@idx",SqlDbType.Int,4)
            };
            parameter [ 0 ] . Value = idx;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;

        }

        bool edit_wor ( StringBuilder strSql ,CarpenterEntity . BomWorkPlanWOREntity _modelTwo  )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE MOXWOR SET " );
            strSql . Append ( "WOR005=@WOR005," );
            strSql . Append ( "WOR017=@WOR017," );
            strSql . Append ( "WOR030=@WOR030 " );
            strSql . Append ( "WHERE WOR001=@WOR001 AND WOR006=@WOR006 AND WOR007=@WOR007 AND WOR010=@WOR010 AND WOR013=@WOR013" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@WOR001",SqlDbType.NVarChar,20),
                new SqlParameter("@WOR005",SqlDbType.NVarChar,20),
                new SqlParameter("@WOR006",SqlDbType.NVarChar,20),
                new SqlParameter("@WOR007",SqlDbType.NVarChar,10),
                new SqlParameter("@WOR010",SqlDbType.NVarChar,10),
                new SqlParameter("@WOR013",SqlDbType.NVarChar,10),
                new SqlParameter("@WOR017",SqlDbType.Decimal,10),
                new SqlParameter("@WOR030",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _modelTwo . WOR001;
            parameter [ 1 ] . Value = _modelTwo . WOR005;
            parameter [ 2 ] . Value = _modelTwo . WOR006;
            parameter [ 3 ] . Value = _modelTwo . WOR007;
            parameter [ 4 ] . Value = _modelTwo . WOR010;
            parameter [ 5 ] . Value = _modelTwo . WOR013;
            parameter [ 6 ] . Value = _modelTwo . WOR017;
            parameter [ 7 ] . Value = _modelTwo . WOR030;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 品号和零件编号获取idx
        /// </summary>
        /// <param name="productNum"></param>
        /// <param name="partNum"></param>
        /// <returns></returns>
        int idxWor ( string productNum,string partNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx FROM MOXWOR " );
            strSql . AppendFormat ( "WHERE WOR001='{0}' AND WOR005='{1}'" ,productNum ,partNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
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

    }
}
