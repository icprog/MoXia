using System;
using System . Collections . Generic;
using System . Data;
using System . Reflection;

namespace Carpenter . ControlUser
{
    public partial class PDailyWork :DevExpress . XtraEditors . XtraUserControl
    {
        DataTable tableView;
        string work=string.Empty; CarpenterBll . Bll . ProductionPaintBll _bll = null;

        public PDailyWork ( bool plan ,string workShopSection ,List<string> strList )
        {
            InitializeComponent ( );

            dateTimePicker1 . Value = CarpenterBll . UserInformation . dt ( );
            
            _bll = new CarpenterBll . Bll . ProductionPaintBll ( );
            this . work = workShopSection;

            setVisible ( workShopSection );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            //if ( workShopSection . Equals ( CarpenterBll.ColumnValues.yq_bz ) )
            //    tableView = _bll . GetDataTableBZ ( strList );
            //else 

            if ( CarpenterBll . ColumnValues . pro_cg . Equals ( "其它" ) )
                tableView = _bll . GetDataTableOther ( strList ,work );
            else
            {
                if ( plan == false )
                    tableView = _bll . GetDataTable ( strList ,work );
                else if ( plan )
                    tableView = _bll . GetDataTablePlan ( strList ,work );
            }

            gridControl1 . DataSource = tableView;

            this . dateTimePicker1 . Value = CarpenterBll . UserInformation . dt ( ) . AddDays ( -1 );
        }
        
        void setVisible ( string workShopSection )
        {
            if ( workShopSection . Equals ( CarpenterBll.ColumnValues.yq_dq ) )
            {
                PWF007 . Visible = true;
                DQ . Visible = true;
                PWF008 . Visible = false;
                YM . Visible = false;
                PWF009 . Visible = false;
                XS . Visible = false;
                PWF010 . Visible = false;
                MQ . Visible = false;
                PWF011 . Visible = false;
                RB . Visible = false;
                PWF016 . Visible = false;
                BZ . Visible = false;
            }
            if ( workShopSection . Equals ( CarpenterBll.ColumnValues.yq_ym ) )
            {
                PWF007 . Visible = false;
                DQ . Visible = false;
                PWF008 . Visible = true;
                YM . Visible = true;
                PWF009 . Visible = false;
                XS . Visible = false;
                PWF010 . Visible = false;
                MQ . Visible = false;
                PWF011 . Visible = false;
                RB . Visible = false;
                PWF016 . Visible = false;
                BZ . Visible = false;
            }
            if ( workShopSection . Equals ( CarpenterBll.ColumnValues.yq_xs ) )
            {
                PWF007 . Visible = false;
                DQ . Visible = false;
                PWF008 . Visible = false;
                YM . Visible = false;
                PWF009 . Visible = true;
                XS . Visible = true;
                PWF010 . Visible = false;
                MQ . Visible = false;
                PWF011 . Visible = false;
                RB . Visible = false;
                PWF016 . Visible = false;
                BZ . Visible = false;
            }
            if ( workShopSection . Equals ( CarpenterBll.ColumnValues.yq_mq ) )
            {
                PWF007 . Visible = false;
                DQ . Visible = false;
                PWF008 . Visible = false;
                YM . Visible = false;
                PWF009 . Visible = false;
                XS . Visible = false;
                PWF010 . Visible = true;
                MQ . Visible = true;
                PWF011 . Visible = false;
                RB . Visible = false;
                PWF016 . Visible = false;
                BZ . Visible = false;
            }
            if ( workShopSection . Equals ( CarpenterBll.ColumnValues.yq_rb ) )
            {
                PWF007 . Visible = false;
                DQ . Visible = false;
                PWF008 . Visible = false;
                YM . Visible = false;
                PWF009 . Visible = false;
                XS . Visible = false;
                PWF010 . Visible = false;
                MQ . Visible = false;
                PWF011 . Visible = true;
                RB . Visible = true;
                PWF016 . Visible = false;
                BZ . Visible = false;
            }
            if ( workShopSection . Equals ( CarpenterBll.ColumnValues.yq_bz ) )
            {
                PWF007 . Visible = false;
                DQ . Visible = false;
                PWF008 . Visible = false;
                YM . Visible = false;
                PWF009 . Visible = false;
                XS . Visible = false;
                PWF010 . Visible = false;
                MQ . Visible = false;
                PWF011 . Visible = false;
                RB . Visible = false;
                PWF016 . Visible = true;
                BZ . Visible = true;
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

        public DataTable getTable
        {
            get
            {
                gridView1 . CloseEditor ( );
                gridView1 . UpdateCurrentRow ( );
                foreach ( DataRow row in tableView . Rows )
                {
                    row . BeginEdit ( );
                    row [ "PWF012" ] = Convert . ToDateTime ( dateTimePicker1 . Value . ToString ( "yyyy-MM-dd HH:mm:ss" ) );
                    switch ( work )
                    {
                        case "底漆":
                        row [ "YM" ] = 0;
                        row [ "XS" ] = 0;
                        row [ "MQ" ] = 0;
                        row [ "RB" ] = 0;
                        row [ "BZ" ] = 0;
                        break;
                        case "油磨":
                        row [ "DQ" ] = 0;
                        row [ "XS" ] = 0;
                        row [ "MQ" ] = 0;
                        row [ "RB" ] = 0;
                        row [ "BZ" ] = 0;
                        break;
                        case "修色":
                        row [ "YM" ] = 0;
                        row [ "DQ" ] = 0;
                        row [ "MQ" ] = 0;
                        row [ "RB" ] = 0;
                        row [ "BZ" ] = 0;
                        break;
                        case "面漆":
                        row [ "YM" ] = 0;
                        row [ "XS" ] = 0;
                        row [ "DQ" ] = 0;
                        row [ "RB" ] = 0;
                        row [ "BZ" ] = 0;
                        break;
                        case "软包":
                        row [ "YM" ] = 0;
                        row [ "XS" ] = 0;
                        row [ "MQ" ] = 0;
                        row [ "DQ" ] = 0;
                        row [ "BZ" ] = 0;
                        break;
                        case "包装":
                        row [ "YM" ] = 0;
                        row [ "XS" ] = 0;
                        row [ "MQ" ] = 0;
                        row [ "RB" ] = 0;
                        row [ "DQ" ] = 0;
                        break;
                    }
                    row . EndEdit ( );
                }
                return this . tableView;
            }
        }

        public string getStr
        {
            get
            {
                return this . work;
            }
        }

    }
}
