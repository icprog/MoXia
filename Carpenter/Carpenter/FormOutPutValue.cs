using DevExpress . Utils . Paint;
using DevExpress . XtraEditors;
using System;
using System . Data;
using System . Reflection;

namespace Carpenter
{
    public partial class FormOutPutValue :FormChild
    {
        CarpenterBll.Bll.OutPutValueBll _bll=null;

        public FormOutPutValue ( )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . OutPutValueBll ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave ,toolPrint ,toolCancellation ,toolExamin ,toolReview ,toolDelete ,toolEdit ,toolAdd } );

        }

        protected override int Query ( )
        {
            if ( string . IsNullOrEmpty ( dateEdit1 . Text ) )
            {
                XtraMessageBox . Show ( "请选择日期" );
                return 0;
            }
            DataTable tableView = _bll . getTableView ( Convert . ToDateTime ( dateEdit1 . Text ) . Year ,Convert . ToDateTime ( dateEdit1 . Text ) . Month );
            gridControl1 . DataSource = tableView;
            toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;

            return base . Query ( );
        }

        protected override int Export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,this . gridControl1 );

            return base . Export ( );
        }

    }
}
