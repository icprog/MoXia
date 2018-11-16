
using DevExpress . XtraEditors;
using System;
using System . ComponentModel;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormTransmit :FormChild
    {
        //MOXTRA
        
        CarpenterEntity.TransmitEntity model=new CarpenterEntity.TransmitEntity();
        CarpenterBll.Bll.TransmitBll _bll=new CarpenterBll.Bll.TransmitBll();
        DataTable tableQuery;bool result=false;int num=0;
        
        public FormTransmit ( )
        {
            InitializeComponent ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] {  toolExport ,toolPrint ,toolCancellation ,toolExamin ,toolReview ,toolEdit } );

            gridView1 . OptionsBehavior . Editable = false;

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

            tableQuery = _bll . GetDataTable ( );
            gridControl1 . DataSource = tableQuery;

            addTool ( );
            gridView1 . OptionsBehavior . Editable = true;

            return base . Add ( );
        }
        protected override int Save ( )
        {
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            wait . Show ( );
            backgroundWorker2 . RunWorkerAsync ( );

            return base . Save ( );
        }
        protected override int Cancel ( )
        {
            cancelTool ( "add" );

            gridView1 . OptionsBehavior . Editable = false;

            return base . Cancel ( );
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
                XtraMessageBox . Show ( "删除成功" );

                Query ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        #endregion

        #region Event
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
        private void backgroundWorker2_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            result = _bll . Save ( tableQuery ,UserLogin . userName );
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );

                if ( result == true )
                {
                    XtraMessageBox . Show ( "保存成功" );

                    saveTool ( );

                    gridView1 . OptionsBehavior . Editable = false;
                }
                else
                    XtraMessageBox . Show ( "保存失败" );
            }
        }
        private void gridView1_InitNewRow ( object sender ,DevExpress . XtraGrid . Views . Grid . InitNewRowEventArgs e )
        {
            DevExpress . XtraGrid . Views . Grid . GridView view = sender as DevExpress . XtraGrid . Views . Grid . GridView;
            model.TRA001= ( gridView1 . DataRowCount + 1 ) . ToString ( );
            model . TRA001 = model . TRA001 . PadLeft ( 3 ,'0' );
            gridView1 . SetRowCellValue ( e . RowHandle ,view . Columns [ "TRA001" ] ,model . TRA001 );
        }
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridControl1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            //num = gridView1 . FocusedRowHandle;
            if ( e . KeyChar == 13 )
            {
                //if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
                //{
                model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                tableQuery . Rows . Remove ( row );
                gridControl1 . RefreshDataSource ( );
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
        protected override void OnClosing ( CancelEventArgs e )
        {
            if ( toolSave . Visibility == DevExpress . XtraBars . BarItemVisibility . Always )
            {
                if ( XtraMessageBox . Show ( "是否保存?" ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
                {
                    Save ( );
                    e . Cancel = true;
                }
            }
            base . OnClosing ( e );
        }
        #endregion

    }
}
