
using System . Windows . Forms;
using System . Reflection;
using System . Data;
using System . Collections . Generic;
using System;

namespace Carpenter . ControlUser
{
    public partial class BLDailyWork :UserControl
    {
        DataTable tableView;
        string workShop=string.Empty;
        CarpenterBll . Bll . PlanStockDailyWorkBll bll=null;
        public BLDailyWork ( bool plan ,string workShopSection ,List<string> strList)
        {
            InitializeComponent ( );

            workShop = workShopSection;
            setVisible ( workShopSection );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            bll = new CarpenterBll . Bll . PlanStockDailyWorkBll ( );

            if ( CarpenterBll . ColumnValues . pro_cg . Equals ( "其它" ) )
                tableView = bll . GetDataTableOther ( strList ,workShopSection );
            else
            {
                if ( plan )
                    tableView = bll . GetDataTablePlan ( strList ,workShopSection );
                else
                    tableView = bll . GetDataTable ( strList ,workShopSection );
            }

            gridControl1 . DataSource = tableView;

            this . dateTimePicker1 . Value = CarpenterBll . UserInformation . dt ( ) . AddDays ( -1 );
        }

        public DataTable getTable
        {           
            get
            {
                gridView1 . CloseEditor ( );
                gridView1 . UpdateCurrentRow ( );
                foreach ( DataRow row in tableView . Rows )
                {
                    row . BeginEdit ( );
                    row [ "PDW012" ] = Convert . ToDateTime ( dateTimePicker1 . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                    switch ( workShop )
                    {
                        case "断料":
                        row [ "XB" ] = 0;
                        row [ "CJ" ] = 0;
                        row [ "PB" ] = 0;
                        row [ "PC" ] = 0;
                        break;
                        case "修边":
                        row [ "DL" ] = 0;
                        row [ "CJ" ] = 0;
                        row [ "PB" ] = 0;
                        row [ "PC" ] = 0;
                        break;
                        case "齿接":
                        row [ "DL" ] = 0;
                        row [ "XB" ] = 0;
                        row [ "PB" ] = 0;
                        row [ "PC" ] = 0;
                        break;
                        case "拼板":
                        row [ "DL" ] = 0;
                        row [ "XB" ] = 0;
                        row [ "CJ" ] = 0;
                        row [ "PC" ] = 0;
                        break;
                        case "刨床":
                        row [ "DL" ] = 0;
                        row [ "XB" ] = 0;
                        row [ "CJ" ] = 0;
                        row [ "PB" ] = 0;
                        break;
                    }
                    row . EndEdit ( );
                }
                return this . tableView;
            }
        }
        
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

        private void btnOk_Click ( object sender ,System . EventArgs e )
        {

        }

        void setVisible ( string workShopSection )
        {
            //PDW007 . Visible = false;
            //DL . Visible = false;
            

            if ( workShopSection . Equals (CarpenterBll.ColumnValues.bl_dl ) )
            {
                PDW007 . Visible = true;
                DL . Visible = true;
                PDW008 . Visible = false;
                XB . Visible = false;
                PDW009 . Visible = false;
                CJ . Visible = false;
                PDW010 . Visible = false;
                PB . Visible = false;
                PDW011 . Visible = false;
                PC . Visible = false;
            }
            if ( workShopSection . Equals ( CarpenterBll.ColumnValues.bl_xb) )
            {
                PDW007 . Visible = false;
                DL . Visible = false;
                PDW008 . Visible = true;
                XB . Visible = true;
                PDW009 . Visible = false;
                CJ . Visible = false;
                PDW010 . Visible = false;
                PB . Visible = false;
                PDW011 . Visible = false;
                PC . Visible = false;
            }
            if ( workShopSection . Equals ( CarpenterBll.ColumnValues.bl_cj ) )
            {
                PDW007 . Visible = false;
                DL . Visible = false;
                PDW008 . Visible = false;
                XB . Visible = false;
                PDW009 . Visible = true;
                CJ . Visible = true;
                PDW010 . Visible = false;
                PB . Visible = false;
                PDW011 . Visible = false;
                PC . Visible = false;
            }
            if ( workShopSection . Equals ( CarpenterBll.ColumnValues.bl_pb ) )
            {
                PDW007 . Visible = false;
                DL . Visible = false;
                PDW008 . Visible = false;
                XB . Visible = false;
                PDW009 . Visible = false;
                CJ . Visible = false;
                PDW010 . Visible = true;
                PB . Visible = true;
                PDW011 . Visible = false;
                PC . Visible = false;
            }
            if ( workShopSection . Equals ( CarpenterBll.ColumnValues.bl_pc ) )
            {
                PDW007 . Visible = false;
                DL . Visible = false;
                PDW008 . Visible = false;
                XB . Visible = false;
                PDW009 . Visible = false;
                CJ . Visible = false;
                PDW010 . Visible = false;
                PB . Visible = false;
                PDW011 . Visible = true;
                PC . Visible = true;
            }
        }

    }
}
