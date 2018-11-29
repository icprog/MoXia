using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Linq;
using System . Windows . Forms;
using DevExpress . XtraEditors;
using System . Reflection;

namespace Carpenter
{
    public partial class FormProPartArt :FormChild
    {
        CarpenterBll.Bll.ProPartArtBll _bll=null;

        DataTable tableInfo,tableView;
        
        public FormProPartArt ( )
        {
            InitializeComponent ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave ,toolExport,toolPrint,toolCancellation ,toolExamin ,toolReview ,toolDelete,toolEdit ,toolAdd } );

            _bll = new CarpenterBll . Bll . ProPartArtBll ( );

            getTable ( );
        }
        
        void getTable ( )
        {
            tableInfo = _bll . getTableForInfo ( );

            lupProduct . Properties . DataSource = tableInfo . DefaultView . ToTable ( true ,new string [ ] { "PPA002" ,"PPA001" } );
            lupProduct . Properties . DisplayMember = "PPA002";
            lupProduct . Properties . ValueMember = "PPA001";

            lupPart . Properties . DataSource = tableInfo . Copy ( ) . DefaultView . ToTable ( true ,new string [ ] { "PPA003" ,"PPA004" } );
            lupPart . Properties . DisplayMember = "PPA004";
            lupPart . Properties . ValueMember = "PPA003";
        }

        protected override int Query ( )
        {
            string strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupProduct . Text ) )
                strWhere = strWhere + " AND PPA001='" + lupProduct . EditValue + "'";
            if ( !string . IsNullOrEmpty ( lupPart . Text ) )
                strWhere = strWhere + " AND PPA003='" + lupPart . EditValue + "'";

            tableView = _bll . getTableView ( strWhere );
            gridControl1 . DataSource = tableView;

            return base . Query ( );
        }

    }
}