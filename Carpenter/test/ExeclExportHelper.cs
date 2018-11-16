
using NPOI . HSSF . UserModel;
using NPOI . SS . UserModel;
using NPOI . XSSF . UserModel;
using System;
using System . Collections . Generic;
using System . Data;
using System . IO;
using System . Linq;
using System . Text;

namespace test
{
    /// <summary>
    /// 用nopi导入execl
    /// </summary>
    public static class ExeclExportHelper
    {
        static int sheetNum;

        static XSSFWorkbook hssfworkbook;
        static  XSSFSheet sheet;
        static DataTable dt;

        /// <summary>
        ///   open file stream of more than execl 2007 version
        ///   export first one sheet from execl
        /// </summary>
        /// <param name="path"></param>
        /// <param name="columnCount"></param>
        /// <returns></returns>
        public static DataTable InitializeWorkBook ( string path ,int columnCount )
        {
            using ( FileStream file = new FileStream ( path ,FileMode . Open ,FileAccess . Read ) )
            {
                hssfworkbook = new XSSFWorkbook ( file );

                sheet = ( XSSFSheet ) hssfworkbook . GetSheetAt ( 0 );
                
                System . Collections . IEnumerator rows = sheet . GetRowEnumerator ( );

                dt = new DataTable ( );
                for ( int i = 0 ; i <= columnCount ; i++ )
                {
                    dt . Columns . Add (  (  i+1 ) . ToString ( ) );
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
                return dt;
            }
        }

        /// <summary>
        ///  open file stream of more than  execl 2007 versions
        ///  export all sheet from execl
        /// </summary>
        /// <param name="path"></param>
        /// <param name="columnCount"></param>
        /// <returns></returns>
        public static DataTable InitializeWorkBookAll ( string path ,int columnCount )
        {
            using ( FileStream file = new FileStream ( path ,FileMode . Open ,FileAccess . Read ) )
            {
                hssfworkbook = new XSSFWorkbook ( file );

                sheetNum = hssfworkbook . NumberOfSheets;

                dt = new DataTable ( );
                for ( int i = 0 ; i <= columnCount ; i++ )
                {
                    dt . Columns . Add ( ( i + 1 ) . ToString ( ) );
                }

                for ( int k = 0 ; k < sheetNum ; k++ )
                {
                    sheet = ( XSSFSheet ) hssfworkbook . GetSheetAt ( k );

                    System . Collections . IEnumerator rows = sheet . GetRowEnumerator ( );

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
                }
                return dt;
            }
        }

        static HSSFWorkbook hssfwork;
        static ISheet shet;
        /// <summary>
        /// open file stream of execl 2003-2007 version
        /// export first one sheet from execl
        /// </summary>
        /// <param name="path"></param>
        /// <param name="columnCount"></param>
        /// <returns></returns>
        public static DataTable InitializeWorkB ( string path ,int columnCount )
        {
            using ( FileStream file = new FileStream ( path ,FileMode . Open ,FileAccess . Read ) )
            {
                hssfwork = new HSSFWorkbook ( file );

                shet = ( ISheet ) hssfwork . GetSheetAt ( 0 );
                System . Collections . IEnumerator rows = shet . GetRowEnumerator ( );

                dt = new DataTable ( );
                
                for ( int i = 0 ; i < columnCount ; i++ )
                {
                    dt . Columns . Add ( ( i + 1 ) . ToString ( ) );
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
                return dt;
            }
        }

        /// <summary>
        /// opern file stream of execl 2003-2007 version
        /// export all sheet from execl
        /// </summary>
        /// <param name="path"></param>
        /// <param name="columnCount"></param>
        /// <returns></returns>
        public static DataTable InitializeWorkBAll ( string path ,int columnCount )
        {
            using ( FileStream file = new FileStream ( path ,FileMode . Open ,FileAccess . Read ) )
            {
                hssfwork = new HSSFWorkbook ( file );

                sheetNum = hssfwork . NumberOfSheets;

                dt = new DataTable ( );
                for ( int i = 0 ; i < columnCount ; i++ )
                {
                    dt . Columns . Add ( ( i + 1 ) . ToString ( ) );
                }

                for ( int k = 0 ; k < sheetNum ; k++ )
                {
                    shet = ( ISheet ) hssfwork . GetSheetAt ( k );
                    System . Collections . IEnumerator rows = shet . GetRowEnumerator ( );

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
                }
                return dt;
            }
        }

    }
}
