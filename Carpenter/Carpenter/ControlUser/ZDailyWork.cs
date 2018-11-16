using DevExpress . XtraEditors;
using System;
using System . Collections;
using System . Data;
using System . Reflection;

namespace Carpenter . ControlUser
{
    public partial class ZDailyWork :DevExpress . XtraEditors . XtraUserControl
    {
        DataTable tableView,tablePer;int num=0;
        CarpenterBll.Bll.AssembleWorkOrderBll _bll=null;
        Hashtable hasTable=new Hashtable();bool isOk=true,plan=false;
        
        public ZDailyWork ( DataTable tableQuery ,bool plan)
        {
            InitializeComponent ( );
            
            this . plan = plan;

            _bll = new CarpenterBll . Bll . AssembleWorkOrderBll ( );
            tablePer = new DataTable ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            this . tableView = tableQuery;

            gridControl1 . DataSource = tableView;

            this . dateTimePicker1 . Value = CarpenterBll . UserInformation . dt ( ) . AddDays ( -1 );
        }
  
        string week,productNum;

        int proNum=0,proSum=0,proNow=0;

        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            isOk = true;
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                DataRow row;
                for ( int i = 0 ; i < gridView2 . DataRowCount ; i++ )
                {
                    row = gridView2 . GetDataRow ( i );
                    row . ClearErrors ( );
                    if ( row != null )
                    {
                        proSum = string . IsNullOrEmpty ( row [ "PLF007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PLF007" ] . ToString ( ) );
                        proNow = string . IsNullOrEmpty ( row [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "DL" ] . ToString ( ) );
                        proNum = string . IsNullOrEmpty ( row [ "AWQ006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "AWQ006" ] . ToString ( ) );
                        if ( proNum < proSum + proNow )
                        {
                            row . SetColumnError ( "DL" ,"数量错误" );
                            isOk = false;
                            break;
                        }
                    }
                }
            }
            if ( isOk == false )
                return;

            if ( tablePer != null && !string . IsNullOrEmpty ( week ) && !string . IsNullOrEmpty ( productNum ) )
            {
                gridView2 . CloseEditor ( );
                gridView2 . UpdateCurrentRow ( );
                if ( hasTable . ContainsKey ( week + productNum ) )
                {
                    hasTable . Remove ( week + productNum );
                    hasTable . Add ( week + productNum ,tablePer );
                }
                else
                    hasTable . Add ( week + productNum ,tablePer );
            }

            num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                week = gridView1 . GetDataRow ( num ) [ "PAS001" ] . ToString ( );
                productNum = gridView1 . GetDataRow ( num ) [ "PAS002" ] . ToString ( );
                tablePer = _bll . tableOne ( week ,productNum );
                gridControl2 . DataSource = tablePer;
            }
        }

        private void btnOk_Click ( object sender ,System . EventArgs e )
        {
            isOk = true;
            DataRow row;
            for ( int i = 0 ; i < gridView2 . DataRowCount ; i++ )
            {
                row = gridView2 . GetDataRow ( i );
                row . ClearErrors ( );
                if ( row != null )
                {
                    proSum = string . IsNullOrEmpty ( row [ "PLF007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PLF007" ] . ToString ( ) );
                    proNow = string . IsNullOrEmpty ( row [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "DL" ] . ToString ( ) );
                    proNum = string . IsNullOrEmpty ( row [ "AWQ006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "AWQ006" ] . ToString ( ) );
                    if ( proNum < proSum + proNow )
                    {
                        row . SetColumnError ( "DL" ,"数量错误" );
                        isOk = false;
                        break;
                    }
                }
            }
            if ( isOk == false )
                return;
            if ( tablePer != null && !string . IsNullOrEmpty ( week ) && !string . IsNullOrEmpty ( productNum ) )
            {
                gridView2 . CloseEditor ( );
                gridView2 . UpdateCurrentRow ( );
                if ( hasTable . ContainsKey ( week + productNum ) )
                {
                    hasTable . Remove ( week + productNum );
                    hasTable . Add ( week + productNum ,tablePer );
                }else
                    hasTable . Add ( week + productNum ,tablePer );
            }


            isOk = _bll . ZDailyWork ( tableView ,plan ,hasTable ,Convert . ToDateTime ( dateTimePicker1 . Value . ToString ( "yyyy-MM-dd" ) ) );
            if ( isOk==false )
            {
                XtraMessageBox . Show ( "报工失败" );
            }else
                XtraMessageBox . Show ( "报工成功" );
        }

        public bool getisOk
        {
            get
            {
                return isOk;
            }
        }

        private void gridView2_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
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
