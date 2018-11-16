using NPOI . XSSF . UserModel;
using System;
using System . Collections;
using System . Data;
using System . IO;
using System . Text;
using System . Windows . Forms;
using StudentMgr;
using NPOI . HSSF . UserModel;
using NPOI . SS . UserModel;
using DevExpress . XtraEditors;

namespace test
{
    public partial class Form1 :Form
    {
        public Form1 ( )
        {
            InitializeComponent ( );
        }
        string path = "D:\\chuanpiao.xlsx";

        //导入
        private void button1_Click ( object sender ,EventArgs e )
        {
            InitializeWorkBook ( path );
        }

        DataTable dt;
        XSSFWorkbook hssfworkbook; XSSFSheet sheet;
        //打开文件流 execl 2007以上版本
        void InitializeWorkBook ( string path )
        {
            using ( FileStream file = new FileStream ( path ,FileMode.Open,FileAccess.Read) )
            {
                hssfworkbook = new XSSFWorkbook ( file );

                sheet = ( XSSFSheet ) hssfworkbook . GetSheetAt ( 0 );
                System . Collections . IEnumerator rows = sheet . GetRowEnumerator ( );

                dt = new DataTable ( );
                for ( int i = 0 ; i < 20 ; i++ )
                {
                    dt . Columns . Add ( Convert . ToChar ( ( ( int ) 'A' ) + i ) . ToString ( ) );
                }

                while ( rows . MoveNext ( ) )
                {
                    XSSFRow row = ( XSSFRow ) rows . Current;
                    DataRow dr = dt . NewRow ( );

                    for ( int i = 0 ; i < row . LastCellNum ; i++ )
                    {
                        XSSFCell cell = ( XSSFCell ) row . GetCell ( i );
                        if ( cell == null )
                        {
                            dr [ i ] = null;
                        }
                        else
                        {
                            dr [ i ] = cell . ToString ( );
                        }
                    }

                    dt . Rows . Add ( dr );
                }
                gridControl1 . DataSource = dt;
                label1 . Text = dt . Rows . Count . ToString ( );
            }
        }

        //打开文件流  execl 2003-2007
        HSSFWorkbook hssfwork;ISheet shet;
        void InitializeWorkB ( string path )
        {
            using ( FileStream file = new FileStream ( path ,FileMode . Open ,FileAccess . Read ) )
            {
                hssfwork = new HSSFWorkbook ( file );

                shet = ( ISheet ) hssfwork . GetSheetAt ( 0 );
                System . Collections . IEnumerator rows = shet . GetRowEnumerator ( );

                dt = new DataTable ( );
                //HSSFRow row = ( HSSFRow ) row
                for ( int i = 0 ; i < 23 ; i++ )
                {
                    dt . Columns . Add ( Convert . ToChar ( ( ( int ) 'A' ) + i ) . ToString ( ) );
                }

                while ( rows . MoveNext ( ) )
                {
                    HSSFRow row = ( HSSFRow ) rows . Current;
                    DataRow dr = dt . NewRow ( );

                    for ( int i = 0 ; i < row . LastCellNum ; i++ )
                    {
                        HSSFCell cell = ( HSSFCell ) row . GetCell ( i );
                        if ( cell == null )
                        {
                            dr [ i ] = null;
                        }
                        else
                        {
                            dr [ i ] = cell . ToString ( );
                        }
                    }

                    dt . Rows . Add ( dr );
                }
                gridControl1 . DataSource = dt;
                label1 . Text = dt . Rows . Count . ToString ( );
            }
        }

        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( dt != null && dt . Rows . Count > 0 )
            {
                ArrayList SQLString = new ArrayList ( );
                StringBuilder strSql = new StringBuilder ( );
                string name = string . Empty;
                decimal price = 0;
                for ( int i = 1 ; i < dt . Rows . Count ; i++ )
                {
                    name = dt . Rows [ i ] [ 0 ] . ToString ( );
                    price = string . IsNullOrEmpty ( dt . Rows [ i ] [ 1 ] . ToString ( ) ) == true ? 0 : Math . Round ( Convert . ToDecimal ( dt . Rows [ i ] [ 1 ] . ToString ( ) ) / 10 ,3 );
                    add ( SQLString ,strSql ,name ,price );
                }

                bool result= SqlHelper . ExecuteSqlTran ( SQLString );
                XtraMessageBox . Show ( result . ToString ( ) );
            }
        }

        void add ( ArrayList SQLString ,StringBuilder strSql,string name,decimal price )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "INSERT INTO AA (A01,A02) VALUES ('{0}',{1})" ,name ,price );
            SQLString . Add ( strSql );
        }

        private void button3_Click ( object sender ,EventArgs e )
        {
            string [ ] str = { "51-1","54-1","55-1","56-1","58-1","59-1","61-1","64-1","65-2" };
            DataTable dt;
            ArrayList SQLString = new ArrayList ( );
            string num = string . Empty, name = string . Empty, speci = string . Empty, color = string . Empty, types = string . Empty;
            decimal price = 0;
            foreach ( string s in str )
            {
                if ( s . Equals ( "51-1" ) )
                {
                    types = "兰卡威";
                    color = "金柚";
                }
                if ( s . Equals ( "54-1" ) )
                {
                    types = "墨客";
                    color = "原柚";
                }
                if ( s . Equals ( "55-1" ) )
                {
                    types = "墨客";
                    color = "缅柚";
                }
                if ( s . Equals ( "56-1" ) )
                {
                    types = "墨客";
                    color = "樱桃木";
                }
                if ( s . Equals ( "58-1" ) )
                {
                    types = "悦木";
                    color = "榆木";
                }
                if ( s . Equals ( "59-1" ) )
                {
                    types = "悦木";
                    color = "黑胡桃";
                }
                if ( s . Equals ( "61-1" ) )
                {
                    types = "致简";
                    color = "浅胡桃";
                }
                if ( s . Equals ( "64-1" ) )
                {
                    types = "莫尼克";
                    color = "樱桃木";
                }
                if ( s . Equals ( "65-2" ) )
                {
                    types = "莫尼克";
                    color = "沙比利";
                }
                dt = SqlHelper . ExecuteDataTable ( "SELECT FNumber,FName,FModel,B.A02 FROM T_OPI A LEFT JOIN AA B ON A.FName=B.A01 WHERE A.FNumber like '" + s + "%'" );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dt . Rows . Count ; i++)
                    {
                        num = dt . Rows [ i ] [ "FNumber" ] . ToString ( );
                        name = dt . Rows [ i ] [ "FName" ] . ToString ( );
                        speci = dt . Rows [ i ] [ "FModel" ] . ToString ( );
                        price = string . IsNullOrEmpty ( dt . Rows [ i ] [ "A02" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "A02" ] . ToString ( ) );
                        add_opi ( num ,name ,speci ,price ,color ,types ,SQLString );
                    }
                }
            }

            bool result = SqlHelper . ExecuteSqlTran ( SQLString );
            XtraMessageBox . Show ( result . ToString ( ) );
        }

        void add_opi ( string num,string name,string speci,decimal price,string color,string types,ArrayList SQLString)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXOPI (" );
            strSql . Append ( "OPI001,OPI002,OPI003,OPI004,OPI005,OPI006,OPI007,OPI008,OPI009,OPI010,OPI011) " );
            strSql . Append ( "VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}') " ,num ,name ,types ,price ,speci ,color ,"PCS" ,"在产" ,"常规" ,"成品" ,0 );
            SQLString . Add ( strSql . ToString ( ) );
        }

        private void button4_Click ( object sender ,EventArgs e )
        {
            string [ ] str = { "52-2" ,"53-2" ,"54-2" ,"57-2" ,"58-2" ,"59-2" ,"60-2" };
            DataTable dt;
            ArrayList SQLString = new ArrayList ( );
            string num = string . Empty, name = string . Empty, speci = string . Empty, color = string . Empty, types = string . Empty;
            foreach ( string s in str )
            {
                if ( s . Equals ( "52-2" ) || s . Equals ( "53-2" ) )
                {
                    types = "兰卡威";
                    color = "金柚";
                }
                if ( s . Equals ( "54-2" ) )
                {
                    types = "墨客";
                    color = "原柚";
                }
                if ( s . Equals ( "57-2" ) )
                {
                    types = "墨客";
                    color = "榆木";
                }
                if ( s . Equals ( "58-2" ) )
                {
                    types = "悦木";
                    color = "榆木";
                }
                if ( s . Equals ( "59-2" ) || s . Equals ( "60-2" ) )
                {
                    types = "悦木";
                    color = "黑胡桃";
                }              
                dt = SqlHelper . ExecuteDataTable ( "SELECT FNumber,FName,FModel FROM T_OPI A WHERE A.FNumber like '" + s + "%'" );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                    {
                        num = dt . Rows [ i ] [ "FNumber" ] . ToString ( );
                        name = dt . Rows [ i ] [ "FName" ] . ToString ( );
                        speci = dt . Rows [ i ] [ "FModel" ] . ToString ( );
                        add_opi ( num ,name ,speci ,color ,types ,SQLString );
                    }
                }
            }

            bool result = SqlHelper . ExecuteSqlTran ( SQLString );
            XtraMessageBox . Show ( result . ToString ( ) );
        }

        void add_opi ( string num ,string name ,string speci ,string color ,string types ,ArrayList SQLString )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXOPI (" );
            strSql . Append ( "OPI001,OPI002,OPI003,OPI004,OPI005,OPI006,OPI007,OPI008,OPI009,OPI010,OPI011) " );
            strSql . Append ( "VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}') " ,num ,name ,types ,0 ,speci ,color ,"PCS" ,"停产" ,"常规" ,"成品" ,0 );
            SQLString . Add ( strSql . ToString ( ) );
        }

        private void button5_Click ( object sender ,EventArgs e )
        {
            InitializeWorkB ( path );
        }

        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( dt != null && dt . Rows . Count > 0 )
            {
                ArrayList SQLString = new ArrayList ( );
                string name = string . Empty, num = string . Empty, workSpace = string . Empty;
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    name = dt . Rows [ i ] [ 1 ] . ToString ( );
                    num = dt . Rows [ i ] [ 0 ] . ToString ( );
                    workSpace = dt . Rows [ i ] [ 2 ] . ToString ( );
                    add_person ( SQLString ,name ,num ,workSpace );
                }

                bool result = SqlHelper . ExecuteSqlTran ( SQLString );
                XtraMessageBox . Show ( result . ToString ( ) );
            }
        }

        void add_person ( ArrayList SQLString ,string name ,string num ,string workSpace )
        {
            string numOfWork = string . Empty;
            if ( workSpace . Equals ( "备料车间" ) )
                numOfWork = "0004";
            if ( workSpace . Equals ( "组装车间" ) )
                numOfWork = "0006";
            if ( workSpace . Equals ( "机加工车间" ) )
                numOfWork = "0005";
            if ( workSpace . Equals ( "生产运营" ) )
                numOfWork = "0002";
            if ( workSpace . Equals ( "油漆车间" ) )
                numOfWork = "0007";
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXEMP (" );
            strSql . Append ( "EMP001,EMP002,EMP003,EMP008,EMP009) " );
            strSql . Append ( "VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}',0,'cebfd1559b68d67688884d7a3d3e8c') " ,num ,name ,numOfWork );
            SQLString . Add ( strSql );
        }

    }



}
