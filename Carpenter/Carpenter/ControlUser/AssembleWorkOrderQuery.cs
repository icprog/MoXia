using System . Data;
using System . Reflection;

namespace Carpenter . ControlUser
{
    public partial class AssembleWorkOrderQuery :DevExpress . XtraEditors . XtraUserControl
    {
        DataTable printOne,printTwo;
        CarpenterBll . Bll . AssembleWorkOrderBll _bll =null; 
        public AssembleWorkOrderQuery ( DataTable table )
        {
            InitializeComponent ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );
            _bll = new CarpenterBll . Bll . AssembleWorkOrderBll ( );

            gridControl1 . DataSource = table;
        }

        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

        public string getOdd
        {
            get
            {
                int num = gridView1 . FocusedRowHandle;
                if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
                {
                    return gridView1 . GetDataRow ( num ) [ "AWO001" ] . ToString ( );
                }
                else
                    return string . Empty;
            }
        }
        
        //右键打印或导出
        private void contextMenuStrip1_ItemClicked ( object sender ,System . Windows . Forms . ToolStripItemClickedEventArgs e )
        {
            string oddNum = string . Empty;
            int [ ] idxL = gridView1 . GetSelectedRows ( );
           
            for ( int i = 0 ; i < idxL . Length ; i++ )
            {
                DataRow row = gridView1 . GetDataRow ( idxL [ i ] );
                if ( oddNum == string . Empty )
                    oddNum = "'" + row [ "AWO001" ] . ToString ( ) + "'";
                else
                    oddNum = oddNum + "," + "'" + row [ "AWO001" ] . ToString ( ) + "'";
            }

            if ( !string . IsNullOrEmpty ( oddNum ) )
            {
                printOrExport ( oddNum );

                if ( ( e . ClickedItem ) . Name == "tolPrint" )
                {
                    OrderPrintAndExport . Print ( new DataTable [ ] { printOne } ,"组装派工单.frx" );
                }
                else if ( ( e . ClickedItem ) . Name == "tolExport" )
                {
                    OrderPrintAndExport . Export ( new DataTable [ ] { printOne } ,"组装派工单.frx" );
                }
                else if ( ( e . ClickedItem ) . Name == "tolPrintOrder" )
                {
                    OrderPrintAndExport . Print ( new DataTable [ ] { printTwo } ,"组装派工单清单.frx" );
                }
                else if ( ( e . ClickedItem ) . Name == "tolExportOrder" )
                {
                    OrderPrintAndExport . Export ( new DataTable [ ] { printTwo } ,"组装派工单清单.frx" );
                }
            }

        }

        void printOrExport ( string oddNum )
        {
            printOne = _bll . printOne ( oddNum );
            printOne . TableName = "TableOne";
            printTwo = _bll . printTwo ( oddNum );
            printTwo . TableName = "TableOne";
        }

    }
}
