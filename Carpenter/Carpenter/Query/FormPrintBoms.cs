using System;
using System . Collections . Generic;
using System . Data;

namespace Carpenter . Query
{
    public partial class FormPrintBoms :FormBase
    {
        List<string> proList=new List<string>();
        string weekEnds=string.Empty;
        CarpenterBll.Bll.PlanCuttingBll _bll=null;

        public FormPrintBoms ( string text ,List<string> proList,string weekEnds)
        {
            InitializeComponent ( );

            this . Text = text;
            this . proList = proList;
            this . weekEnds = weekEnds;
            _bll = new CarpenterBll . Bll . PlanCuttingBll ( );

            _bll . editOther ( );
        }
        
        //print bom order
        private void btnPrintOrder_Click ( object sender ,EventArgs e )
        {
            foreach ( string s in proList )
            {
                DataTable printOne = _bll . getPrintOne ( weekEnds ,s );
                if ( printOne != null && printOne . Rows . Count > 0 )
                {
                    printOne . TableName = "WOQ";
                    DataTable printTwo = _bll . getPrintTwo ( s );
                    printTwo . TableName = "WOR";

                    Print ( new DataTable [ ] { printOne ,printTwo } ,"BOM清单.frx" );
                }
            }
            string [ ] typeOfWork = new string [ ] { "拼板" ,"实木包拼" ,"抽斗" };
            List<string> typeOfPro = _bll . getTypeOfPro ( );
            string proNum = string . Empty;
            foreach ( string s in proList )
            {
                if ( proNum == string . Empty )
                    proNum = "'" + s + "'";
                else
                    proNum = proNum + "," + "'" + s + "'";
            }
            //for ( int i = 0 ; i < typeOfWork . Length ; i++ )
            //{
            //    foreach ( string s in typeOfPro )
            //    {
            //        DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,typeOfWork [ i ],proNum );
            //        if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
            //        {
            //            printTypeOfPro . TableName = "Table";
            //            Print ( new DataTable [ ] { printTypeOfPro } ,"包拼拼板抽斗汇总.frx" );
            //        }
            //    }
            //}

            foreach ( string s in typeOfPro )
            {
                DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,"抽斗" ,proNum );
                if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
                {
                    printTypeOfPro . TableName = "Table";
                    Print ( new DataTable [ ] { printTypeOfPro } ,"抽斗汇总.frx" );
                }
            }
            foreach ( string s in typeOfPro )
            {
                DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,"实木包拼" ,proNum );
                if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
                {
                    printTypeOfPro . TableName = "Table";
                    Print ( new DataTable [ ] { printTypeOfPro } ,"实木包拼汇总.frx" );
                }
            }
            foreach ( string s in typeOfPro )
            {
                DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,"拼板" ,proNum );
                if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
                {
                    printTypeOfPro . TableName = "Table";
                    Print ( new DataTable [ ] { printTypeOfPro } ,"拼板汇总.frx" );
                }
            }
            foreach ( string s in typeOfPro )
            {
                DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,proNum );
                if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
                {
                    printTypeOfPro . TableName = "Table";
                    Print ( new DataTable [ ] { printTypeOfPro } ,"拼板分汇总.frx" );
                }
            }
            foreach ( string s in typeOfPro )
            {
                DataTable printPartFB = _bll . getPartFB ( weekEnds ,s ,proNum );
                if ( printPartFB != null && printPartFB . Rows . Count > 0 )
                {
                    printPartFB . TableName = "Table";
                    Print ( new DataTable [ ] { printPartFB } ,"包拼汇总.frx" );
                }
            }
        }
        //print bom cp
        private void btnPrintCp_Click ( object sender ,EventArgs e )
        {
            try
            {
                DataTable print = _bll . printOne ( weekEnds ,proList );
                if ( print != null && print . Rows . Count > 0 )
                {
                    DataColumn dc = new DataColumn ( "UserName" ,typeof ( String ) );
                    dc . DefaultValue = UserLogin . userName;
                    print . Columns . Add ( dc );
                    dc = new DataColumn ( "PTime" ,typeof ( DateTime ) );
                    dc . DefaultValue = CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyy-MM-dd" );
                    print . Columns . Add ( dc );

                    print . TableName = "TableOne";

                    Print ( new DataTable [ ] { print } ,"传票.frx" );
                }
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteLog ( ex . StackTrace + ex . Message );
                throw new Exception ( ex . Message );
            }
        }
        //export bom cp
        private void btnExportCP_Click ( object sender ,EventArgs e )
        {
            DataTable print = _bll . printOne ( weekEnds ,proList );
            if ( print != null && print . Rows . Count > 0 )
            {
                print . TableName = "TableOne";

                Export ( new DataTable [ ] { print } ,"传票.frx" );
            }
        }
        //export bom order
        private void btnExportOrder_Click ( object sender ,EventArgs e )
        {
            foreach ( string s in proList )
            {
                DataTable printOne = _bll . getPrintOne ( weekEnds ,s );
                if ( printOne != null && printOne . Rows . Count > 0 )
                {
                    printOne . TableName = "WOQ";
                    DataTable printTwo = _bll . getPrintTwo ( s );
                    printTwo . TableName = "WOR";

                    Export ( new DataTable [ ] { printOne ,printTwo } ,"BOM清单.frx" );
                }
            }
            string [ ] typeOfWork = new string [ ] { "拼板" ,"实木包拼" ,"抽斗" };
            List<string> typeOfPro = _bll . getTypeOfPro ( );
            string proNum = string . Empty;
            foreach ( string s in proList )
            {
                if ( proNum == string . Empty )
                    proNum = "'" + s + "'";
                else
                    proNum = proNum + "," + "'" + s + "'";
            }
            //for ( int i = 0 ; i < typeOfWork . Length ; i++ )
            //{
            //    foreach ( string s in typeOfPro )
            //    {
            //        DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,typeOfWork [ i ],proNum );
            //        if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
            //        {
            //            printTypeOfPro . TableName = "Table";
            //            Print ( new DataTable [ ] { printTypeOfPro } ,"包拼拼板抽斗汇总.frx" );
            //        }
            //    }
            //}

            foreach ( string s in typeOfPro )
            {
                DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,"抽斗" ,proNum );
                if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
                {
                    printTypeOfPro . TableName = "Table";
                    Export ( new DataTable [ ] { printTypeOfPro } ,"抽斗汇总.frx" );
                }
            }
            foreach ( string s in typeOfPro )
            {
                DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,"实木包拼" ,proNum );
                if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
                {
                    printTypeOfPro . TableName = "Table";
                    Export ( new DataTable [ ] { printTypeOfPro } ,"实木包拼汇总.frx" );
                }
            }
            foreach ( string s in typeOfPro )
            {
                DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,"拼板" ,proNum );
                if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
                {
                    printTypeOfPro . TableName = "Table";
                    Export ( new DataTable [ ] { printTypeOfPro } ,"拼板汇总.frx" );
                }
            }
            foreach ( string s in typeOfPro )
            {
                DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,proNum );
                if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
                {
                    printTypeOfPro . TableName = "Table";
                    Export ( new DataTable [ ] { printTypeOfPro } ,"拼板分汇总.frx" );
                }
            }
            foreach ( string s in typeOfPro )
            {
                DataTable printPartFB = _bll . getPartFB ( weekEnds ,s ,proNum );
                if ( printPartFB != null && printPartFB . Rows . Count > 0 )
                {
                    printPartFB . TableName = "Table";
                    Export ( new DataTable [ ] { printPartFB } ,"包拼汇总.frx" );
                }
            }
            //foreach ( string s in proList )
            //{
            //    DataTable printOne = _bll . getPrintOne ( weekEnds ,s );
            //    if ( printOne != null && printOne . Rows . Count > 0 )
            //    {
            //        printOne . TableName = "WOQ";
            //        DataTable printTwo = _bll . getPrintTwo ( s );
            //        printTwo . TableName = "WOR";

            //        Export ( new DataTable [ ] { printOne ,printTwo } ,"BOM清单.frx" );
            //    }
            //}
            //string [ ] typeOfWork = new string [ ] { "拼板" ,"实木包拼" ,"抽斗" };
            //List<string> typeOfPro = _bll . getTypeOfPro ( );
            //string proNum = string . Empty;
            //foreach ( string s in proList )
            //{
            //    if ( proNum == string . Empty )
            //        proNum = "'" + s + "'";
            //    else
            //        proNum = proNum + "," + "'" + s + "'";
            //}
            ////for ( int i = 0 ; i < typeOfWork . Length ; i++ )
            ////{
            ////    foreach ( string s in typeOfPro )
            ////    {
            ////        DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,typeOfWork [ i ],proNum );
            ////        if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
            ////        {
            ////            printTypeOfPro . TableName = "Table";
            ////            Print ( new DataTable [ ] { printTypeOfPro } ,"包拼拼板抽斗汇总.frx" );
            ////        }
            ////    }
            ////}

            //foreach ( string s in typeOfPro )
            //{
            //    DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,"抽斗" ,proNum );
            //    if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
            //    {
            //        printTypeOfPro . TableName = "Table";
            //        Export ( new DataTable [ ] { printTypeOfPro } ,"抽斗汇总.frx" );
            //    }
            //}
            //foreach ( string s in typeOfPro )
            //{
            //    DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,"实木包拼" ,proNum );
            //    if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
            //    {
            //        printTypeOfPro . TableName = "Table";
            //        Export ( new DataTable [ ] { printTypeOfPro } ,"包拼汇总.frx" );
            //    }
            //}
            //foreach ( string s in typeOfPro )
            //{
            //    DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,"拼板" ,proNum );
            //    if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
            //    {
            //        printTypeOfPro . TableName = "Table";
            //        Export ( new DataTable [ ] { printTypeOfPro } ,"拼板汇总.frx" );
            //    }
            //}
            //foreach ( string s in typeOfPro )
            //{
            //    DataTable printTypeOfPro = _bll . getOrderTable ( weekEnds ,s ,proNum );
            //    if ( printTypeOfPro != null && printTypeOfPro . Rows . Count > 0 )
            //    {
            //        printTypeOfPro . TableName = "Table";
            //        Export ( new DataTable [ ] { printTypeOfPro } ,"拼板分汇总.frx" );
            //    }
            //}
            //foreach ( string s in typeOfPro )
            //{
            //    DataTable printPartFB = _bll . getPartFB ( weekEnds ,s ,proNum );
            //    if ( printPartFB != null && printPartFB . Rows . Count > 0 )
            //    {
            //        printPartFB . TableName = "Table";
            //        Export ( new DataTable [ ] { printPartFB } ,"包拼(封边)汇总.frx" );
            //    }
            //}
        }

    }
}