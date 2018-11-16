using System;
using System . Collections . Generic;
using System . Data;
using System . Reflection;

namespace Carpenter . ControlUser
{
    public partial class JDailyWork :DevExpress . XtraEditors . XtraUserControl
    {
        DataTable tableView; CarpenterBll . Bll . PlanMachinDayDailyWorkBll bll =null;
        string workShop=string.Empty;
        public JDailyWork ( bool plan,string workShopSection,List<string> strList )
        {
            InitializeComponent ( );
            
            dateTimePicker1 . Value = CarpenterBll . UserInformation . dt ( );
            workShop = workShopSection;
            setVisible ( workShopSection );
            
            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );
            
            bll = new CarpenterBll . Bll . PlanMachinDayDailyWorkBll ( );

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
                    row [ "PMY012" ] = Convert . ToDateTime ( dateTimePicker1 . Value . ToString ( "yyyy-MM-dd" ) );
                    switch ( workShop )
                    {
                        case "加工中心":
                        row [ "XB" ] = 0;
                        row [ "CJ" ] = 0;
                        break;
                        case "开榫钻孔":
                        row [ "DL" ] = 0;
                        row [ "CJ" ] = 0;
                        break;
                        case "倒圆":
                        row [ "XB" ] = 0;
                        row [ "DL" ] = 0;
                        break;
                    }
                    row . EndEdit ( );
                }
                return this . tableView;
            }
        }

        void setVisible ( string workShopSection )
        {
            //PDW007 . Visible = false;
            //DL . Visible = false;

            if ( workShopSection . Equals ( CarpenterBll.ColumnValues.jjg_jgzx ) )
            {
                PMY007 . Visible = true;
                DL . Visible = true;
                PMY008 . Visible = false;
                XB . Visible = false;
                PMY009 . Visible = false;
                CJ . Visible = false;
            }
            if ( workShopSection . Equals ( CarpenterBll . ColumnValues . jjg_kszk ) )
            {
                PMY007 . Visible = false;
                DL . Visible = false;
                PMY008 . Visible = true;
                XB . Visible = true;
                PMY009 . Visible = false;
                CJ . Visible = false;
            }
            if ( workShopSection . Equals ( CarpenterBll . ColumnValues . jjg_dy ) )
            {
                PMY007 . Visible = false;
                DL . Visible = false;
                PMY008 . Visible = false;
                XB . Visible = false;
                PMY009 . Visible = true;
                CJ . Visible = true;
            }
        }

        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

    }
}
