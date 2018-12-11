using NPOI . HSSF . UserModel;
using NPOI . SS . UserModel;
using NPOI . XSSF . UserModel;
using System;
using System . Collections . Generic;
using System . Data;
using System . IO;
using System . Linq;
using System . Text;
using System . Windows . Forms;

namespace Carpenter
{
    public class ExeclToDataSource
    {
        /// <summary>
        /// 转Execl为DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable  Choise ( )
        {
            string path = string . Empty, extendName = string . Empty;
            OpenFileDialog open = new OpenFileDialog ( );
            open . Filter = "Execl文件|*.xlx;*.xlsx;*.xls";
            if ( open . ShowDialog ( ) == DialogResult . OK )
            {
                path = open . FileName;
                extendName = Path . GetExtension ( path );
                if ( extendName . Equals ( ".xls" ) || extendName . Equals ( ".xlx" ) )
                    return InitializeWorkBOrder ( path );
                else if ( extendName . Equals ( ".xlsx" ) )
                    return InitializeWorkBookOrder ( path );
                else
                    return null;
            }
            else
                return null;
        }

        private static  XSSFWorkbook hssfworkbook;
        private static XSSFSheet sheet;

        private static HSSFWorkbook hssfwork;
        private static  ISheet shet;

        private static  int sheetNum=0;

        private static DataTable InitializeWorkBOrder ( string path )
        {
            DataTable tableViewOrder;
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
            }
            return tableViewOrder;
        }

        private static DataTable InitializeWorkBookOrder ( string path )
        {
            DataTable tableViewOrder;
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
            }
            return tableViewOrder;
        }

    }
}
