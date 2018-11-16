using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormSetTransmit :FormChild
    {
        DataTable tableQuery;
        CarpenterEntity.SetTransmitEntity model=new CarpenterEntity.SetTransmitEntity();
        CarpenterBll.Bll.SetTransmitBll _bll=new CarpenterBll.Bll.SetTransmitBll();
        bool result=false;    int num=0;   
        
        public FormSetTransmit ( )
        {
            InitializeComponent ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave ,toolExport ,toolPrint ,toolCancellation ,toolExamin ,toolReview,toolEdit } );

            toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;

            wait . Hide ( );
        }
        
        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;
            toolAdd . Enabled = false;

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Add ( )
        {
            List<CarpenterBll . Paramete> hashT = new List<CarpenterBll . Paramete> ( );
            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "工作联系单权限新增" ,"FormSetTransmit" );
            DialogResult isOk = from . ShowDialog ( );
            if ( isOk == DialogResult . OK )
            {
                hashT . Clear ( );
                hashT = from . getHash;
                result = _bll . Add ( hashT ,UserLogin . userName );
                if ( result == true )
                {
                    XtraMessageBox . Show ( "新增成功" );
                    Query ( );
                }
                else
                    XtraMessageBox . Show ( "新增失败" );
            }

            return base . Add ( );
        }
        protected override int Delete ( )
        {
            
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            if ( model . idx < 1 )
            {
                XtraMessageBox . Show ( "请选择需要删除的内容" );
                return 0;
            }
            result = _bll . Delete ( model . idx );
            if ( result )
            {
                XtraMessageBox . Show ( "成功删除" );
                Query ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        #endregion

        #region Event
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            tableQuery = _bll . GetDataTable ( );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                toolQuery . Enabled = true;
                toolAdd . Enabled = true;
                gridControl1 . DataSource = tableQuery;
                QueryTool ( );
            }
        }
        private void gridControl1_KeyPress ( object sender ,System . Windows . Forms . KeyPressEventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            //num = gridView1 . FocusedRowHandle;
            if ( e . KeyChar == 13 )
            {
                //if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
                //{
                    if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                        return;
                if ( gridView1 . OptionsBehavior . Editable == false )
                {
                    model . STR001 = row [ "STR001" ] . ToString ( );
                    model . STR002 = row [ "STR002" ] . ToString ( );
                    model . STR003 = row [ "STR003" ] . ToString ( );
                    model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                    result = _bll . Delete ( model . idx );
                    if ( result == true )
                    {
                        XtraMessageBox . Show ( "删除成功" );
                        tableQuery . Rows . Remove ( row );
                    }
                    else
                        XtraMessageBox . Show ( "删除失败" );
                }
                else
                {
                    tableQuery . Rows . Remove ( row );
                    gridControl1 . RefreshDataSource ( );
                }
                //}
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                model . idx = string . IsNullOrEmpty ( gridView1 . GetDataRow ( num ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( num ) [ "idx" ] . ToString ( ) );
            }
        }
        #endregion


    }
}
