using System . Data;
using System . Windows . Forms;
using NPOI . XSSF . UserModel;
using NPOI . HSSF . UserModel;
using NPOI . SS . UserModel;
using System . IO;
using System;
using System . Reflection;
using DevExpress . XtraEditors;
using System . Collections . Generic;

namespace Carpenter
{
    public partial class FormImportExeclToTable :FormBase
    {
        DataTable tableView,tableViewOrder;
        CarpenterBll.Bll.ImportExeclToTableBll _bll=null; int sheetNum=0;
        public FormImportExeclToTable ( )
        {
            InitializeComponent ( );
            tableView = new DataTable ( );
            tableViewOrder = new DataTable ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );
            _bll = new CarpenterBll . Bll . ImportExeclToTableBll ( );
        }
        
        //选择文件
        string extendName=string.Empty;
        private void btnChoise_Click ( object sender ,System . EventArgs e )
        {
            Choise ( txtChoise  ,"传票" );
        }
        private void btnChoiseOrder_Click ( object sender ,EventArgs e )
        {
            Choise ( txtOrder  ,"清单" );
        }

        void Choise ( TextEdit edit ,string sign )
        {
            OpenFileDialog open = new OpenFileDialog ( );
            open . Filter = "Execl文件|*.xlx;*.xlsx;*.xls";
            if ( open . ShowDialog ( ) == DialogResult . OK )
            {
                edit . Text = open . FileName;
                extendName = Path . GetExtension ( edit . Text );
                if ( extendName . Equals ( ".xls" ) || extendName . Equals ( ".xlx" ) )
                {
                    if ( sign . Equals ( "传票" ) )
                        InitializeWorkB ( edit . Text );
                    else if ( sign . Equals ( "清单" ) )
                        InitializeWorkBOrder ( edit . Text );
                }
                else if ( extendName . Equals ( ".xlsx" ) )
                {
                    if ( sign . Equals ( "传票" ) )
                        InitializeWorkBook ( edit . Text );
                    else if ( sign . Equals ( "清单" ) )
                        InitializeWorkBookOrder ( edit . Text );
                }
            }
        }

        //保存到库
        private void btnSave_Click ( object sender ,System . EventArgs e )
        {
            if ( tableView == null || tableView . Rows . Count < 1 )
            {
                MessageBox . Show ( "请选择文件" );
                return;
            }
            if ( tableViewOrder == null || tableViewOrder . Rows . Count < 1 )
            {
                MessageBox . Show ( "请选择清单文件" );
                return;
            }

            CarpenterBll . UserInformation . TypeOfOper = "导入BOM保存传票";

            string cpProductName = string . Empty, orderProductName = string . Empty;

            for ( int i = 0 ; i < tableView . Rows . Count ; i++ )
            {
                for ( int j = 0 ; j < tableView . Columns . Count ; j++ )
                {
                    orderProductName = tableView . Rows [ i ] [ j ] . ToString ( );
                    if ( orderProductName . Equals ( "产品信息" ) )
                    {
                        cpProductName = tableView . Rows [ i ] [ j + 1 ] . ToString ( );
                        break;
                    }
                }
                if ( !string . IsNullOrEmpty ( cpProductName ) )
                    break;
            }

            orderProductName = tableViewOrder . Rows [ 0 ] [ 0 ] . ToString ( );
            if ( !orderProductName . Trim ( ) . Equals ( cpProductName . Trim ( ) ) )
            {
                XtraMessageBox . Show ( "清单产品名称:" + orderProductName . Trim ( ) + ",传票产品名称:" + cpProductName . Trim ( ) + ",不相符,不允许传票导入" );
                return;
            }

            int num = _bll . Add ( tableView );
            if ( num == 2 )
            {
                string message = string . Empty;
                List<string> strList = new List<string> ( );
                strList = CarpenterBll . UserInformation . StrList;
                if ( strList . Count > 0 )
                {
                    foreach ( string str in strList )
                    {
                        if ( message == string . Empty )
                            message = str;
                        else
                            message = message + "\n\r" + str;
                    }
                }
                if ( message == string . Empty )
                    XtraMessageBox . Show ( "导入成功" );
                else
                    XtraMessageBox . Show ( "部分导入成功,以下内容与清单不符,请核实：" + "\n\r" + "" + message ,"提示" );
            }
            else if ( num == 1 )
                XtraMessageBox . Show ( "产品信息表中没有此产品的信息,无法保存" );
            else if ( num == 3 )
                XtraMessageBox . Show ( "导入失败" );

        }
        
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

        XSSFWorkbook hssfworkbook; XSSFSheet sheet;
        //打开文件流 execl 2007以上版本
        void InitializeWorkBook ( string path )
        {
            using ( FileStream file = new FileStream ( path ,FileMode . Open ,FileAccess . Read ) )
            {
                hssfworkbook = new XSSFWorkbook ( file );

                sheetNum = hssfworkbook . NumberOfSheets;

                tableView = new DataTable ( );
                for ( int i = 0 ; i < 40 ; i++ )
                {
                    //tableView . Columns . Add ( Convert . ToChar ( ( ( int ) 'A' ) + i ) . ToString ( ) );
                    tableView . Columns . Add ( ( i + 1 ) . ToString ( ) );
                }

                for ( int k = 0 ; k < sheetNum ; k++ )
                {
                    sheet = ( XSSFSheet ) hssfworkbook . GetSheetAt ( k );
                    System . Collections . IEnumerator rows = sheet . GetRowEnumerator ( );

                    while ( rows . MoveNext ( ) )
                    {
                        XSSFRow row = ( XSSFRow ) rows . Current;
                        DataRow dr = tableView . NewRow ( );

                        for ( int i = 0 ; i < row . LastCellNum ; i++ )
                        {
                            XSSFCell cell = ( XSSFCell ) row . GetCell ( i );
                            if ( cell == null )
                            {
                                dr [ i ] = null;
                            }
                            else
                            {
                                dr [ i ] = cell . ToString ( ) . Trim ( );
                            }
                        }

                        tableView . Rows . Add ( dr );
                    }
                }
                gridControl1 . DataSource = tableView;
            }
        }

        void InitializeWorkBookOrder ( string path )
        {
            using ( FileStream file = new FileStream ( path ,FileMode . Open ,FileAccess . Read ) )
            {
                hssfworkbook = new XSSFWorkbook ( file );

                sheetNum = hssfworkbook . NumberOfSheets;

                tableViewOrder = new DataTable ( );
                for ( int i = 0 ; i < 40 ; i++ )
                {
                    //tableView . Columns . Add ( Convert . ToChar ( ( ( int ) 'A' ) + i ) . ToString ( ) );
                    tableViewOrder . Columns . Add ( ( i + 1 ) . ToString ( ) );
                }

                sheet = ( XSSFSheet ) hssfworkbook . GetSheetAt ( 0 );
                System . Collections . IEnumerator rows = sheet . GetRowEnumerator ( );

                while ( rows . MoveNext ( ) )
                {
                    XSSFRow row = ( XSSFRow ) rows . Current;
                    DataRow dr = tableViewOrder . NewRow ( );

                    for ( int i = 0 ; i < row . LastCellNum ; i++ )
                    {
                        XSSFCell cell = ( XSSFCell ) row . GetCell ( i );
                        if ( cell == null )
                        {
                            dr [ i ] = null;
                        }
                        else
                        {
                            dr [ i ] = cell . ToString ( ) . Trim ( );
                        }
                    }

                    tableViewOrder . Rows . Add ( dr );
                }
                gridControl2 . DataSource = tableViewOrder;
            }
        }

        //打开文件流  execl 2003-2007
        HSSFWorkbook hssfwork; ISheet shet;
        void InitializeWorkB ( string path )
        {
            using ( FileStream file = new FileStream ( path ,FileMode . Open ,FileAccess . Read ) )
            {
                hssfwork = new HSSFWorkbook ( file );

                 sheetNum = hssfwork . NumberOfSheets;

                tableView = new DataTable ( );
                //HSSFRow row = ( HSSFRow ) row
                for ( int i = 0 ; i < 40 ; i++ )
                {
                    //tableView . Columns . Add ( Convert . ToChar ( ( ( int ) 'A' ) + i ) . ToString ( ) );
                    tableView . Columns . Add ( ( i + 1 ) . ToString ( ) );
                }

                for ( int k = 0 ; k < sheetNum ; k++ )
                {
                    shet = ( ISheet ) hssfwork . GetSheetAt ( k );
                    System . Collections . IEnumerator rows = shet . GetRowEnumerator ( );

                    while ( rows . MoveNext ( ) )
                    {
                        HSSFRow row = ( HSSFRow ) rows . Current;
                        DataRow dr = tableView . NewRow ( );

                        for ( int i = 0 ; i < row . LastCellNum ; i++ )
                        {
                            HSSFCell cell = ( HSSFCell ) row . GetCell ( i );
                            if ( cell == null )
                            {
                                dr [ i ] = null;
                            }
                            else
                            {
                                dr [ i ] = cell . ToString ( ) . Trim ( );
                            }
                        }

                        tableView . Rows . Add ( dr );
                    }
                }
                gridControl1 . DataSource = tableView;
            }
        }

        void InitializeWorkBOrder ( string path )
        {
            using ( FileStream file = new FileStream ( path ,FileMode . Open ,FileAccess . Read ) )
            {
                hssfwork = new HSSFWorkbook ( file );

                sheetNum = hssfwork . NumberOfSheets;

                tableViewOrder = new DataTable ( );
                //HSSFRow row = ( HSSFRow ) row
                for ( int i = 0 ; i < 40 ; i++ )
                {
                    //tableView . Columns . Add ( Convert . ToChar ( ( ( int ) 'A' ) + i ) . ToString ( ) );
                    tableViewOrder . Columns . Add ( ( i + 1 ) . ToString ( ) );
                }


                shet = ( ISheet ) hssfwork . GetSheetAt ( 0 );
                System . Collections . IEnumerator rows = shet . GetRowEnumerator ( );

                while ( rows . MoveNext ( ) )
                {
                    HSSFRow row = ( HSSFRow ) rows . Current;
                    DataRow dr = tableViewOrder . NewRow ( );

                    for ( int i = 0 ; i < row . LastCellNum ; i++ )
                    {
                        HSSFCell cell = ( HSSFCell ) row . GetCell ( i );
                        if ( cell == null )
                        {
                            dr [ i ] = null;
                        }
                        else
                        {
                            dr [ i ] = cell . ToString ( ) . Trim ( );
                        }
                    }

                    tableViewOrder . Rows . Add ( dr );
                }
                gridControl2 . DataSource = tableViewOrder;
            }
        }

        //图片路径选择
        private void btnChoiseOne_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtChoise . Text ) )
            {
                XtraMessageBox . Show ( "请选择文件" );
                return;
            }
            FolderBrowserDialog folder = new  FolderBrowserDialog ( );
            if ( folder . ShowDialog ( ) == DialogResult . OK )
            {
                txtPath . Text = folder . SelectedPath; 
            }
        }
        //保存图片到指定文件夹
        private void btnSaveOne_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtPath . Text ) )
            {
                XtraMessageBox . Show ( "请选择图片保存路径" );
                return;
            }

            bool isOk = _bll . ExeclToImage ( txtChoise . Text ,txtPath . Text ,tableView ,extendName );
            if ( isOk == true )
                XtraMessageBox . Show ( "导出成功" );
            else
                XtraMessageBox . Show ( "导出失败" );
        }

        //保存清单
        private void btnSaveOrder_Click ( object sender ,EventArgs e )
        {
            if ( tableViewOrder == null || tableViewOrder . Rows . Count < 1 )
            {
                MessageBox . Show ( "请选择文件" );
                return;
            }
            CarpenterBll . UserInformation . TypeOfOper = "导入BOM保存清单";

            int num = _bll . ExeclToOrder ( tableViewOrder );
            if ( num == 2 )
                XtraMessageBox . Show ( "导入成功,有部分零件无规格,不允许导入" );
            else if ( num == 4 )
                XtraMessageBox . Show ( "导入成功" );
            else if ( num == 1 )
                XtraMessageBox . Show ( "清单显示产品名称不存在产品信息中,请核实" );
            else if ( num == 3 )
                XtraMessageBox . Show ( "导入失败" );
        }

    }
}