using DevExpress . XtraEditors;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Reflection;

namespace Carpenter . Query
{
    public partial class FormWorkOrder :FormBase
    {
        CarpenterBll . Bll . AssembleWorkOrderBll _bll = null;
        DataTable tableQuery,tableView;
        int proNum=0,sumNum=0;
        bool result=false;
        List<CarpenterBll . Paramete> paList = new List<CarpenterBll . Paramete> ( );
        Hashtable hsTable=new Hashtable();
        string pNum=string.Empty;
        string pingNum=string.Empty;

        public FormWorkOrder ( List<string> strIdx )
        {
            InitializeComponent ( );
            
            _bll = new CarpenterBll . Bll . AssembleWorkOrderBll ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            tableView = _bll . proNum ( strIdx );

            if ( tableView != null && tableView . Rows . Count > 0 )
            {
                foreach ( DataRow row in tableView . Rows )
                {
                    row [ "USERS" ] = UserLogin . userName;
                }
            }
            gridControl2 . DataSource = tableView;          
        }

        private void btnOk_Click ( object sender ,System . EventArgs e )
        {
            if ( tableQuery != null && !string . IsNullOrEmpty ( pNum ) && !string . IsNullOrEmpty ( pingNum ) )
            {
                gridView1 . CloseEditor ( );
                gridView1 . UpdateCurrentRow ( );
                sumNum = string . IsNullOrEmpty ( tableQuery . Compute ( "SUM(Num)" ,null ) . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Compute ( "SUM(Num)" ,null ) );
                if ( proNum < sumNum )
                {
                    XtraMessageBox . Show ( "派工数量多余剩余数量,请核实" );
                    return;
                }
                if ( hsTable . ContainsKey ( pNum + pingNum ) )
                {
                    hsTable . Remove ( pNum + pingNum );
                    hsTable . Add ( pNum + pingNum ,tableQuery );
                }
                else
                    hsTable . Add ( pNum + pingNum ,tableQuery );
            }

            result = _bll . Save ( hsTable ,tableView );
            if ( result )
            {
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
            }
            else
                XtraMessageBox . Show ( "派工失败" );
        }

        private void btnCancel_Click ( object sender ,System . EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }

        private void gridView2_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle > 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle > 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        
        private void gridView2_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            if ( tableQuery != null && !string . IsNullOrEmpty ( pNum ) && !string . IsNullOrEmpty ( pingNum ) )
            {
                gridView1 . CloseEditor ( );
                gridView1 . UpdateCurrentRow ( );
                sumNum = string . IsNullOrEmpty ( tableQuery . Compute ( "SUM(Num)" ,null ) . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Compute ( "SUM(Num)" ,null ) );
                if ( proNum < sumNum )
                {
                    XtraMessageBox . Show ( "派工数量多余剩余数量,请核实" );
                    return;
                }
                if ( hsTable . ContainsKey ( pNum + pingNum ) )
                {
                    hsTable . Remove ( pNum + pingNum );
                    hsTable . Add ( pNum + pingNum ,tableQuery );
                }
                else
                    hsTable . Add ( pNum + pingNum ,tableQuery );
            }

            DataRow row = gridView2 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            pNum = row [ "PAS001" ] . ToString ( );
            pingNum = row [ "PAS002" ] . ToString ( );
            proNum = string . IsNullOrEmpty ( row [ "AWQ006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "AWQ006" ] . ToString ( ) );
            if ( hsTable . ContainsKey ( pNum + pingNum ) )
                tableQuery = ( DataTable ) hsTable [ pNum + pingNum ];
            else
                tableQuery = _bll . GetTableQueryPerson ( );
            gridControl1 . DataSource = tableQuery;
        }

    }
}
