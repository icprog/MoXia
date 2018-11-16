using System . Reflection;
using DevExpress . Utils . Paint;
using DevExpress . XtraEditors;
using System . Data;
using System;
using System . Windows . Forms;
using System . ComponentModel;
using System . Collections . Generic;

namespace Carpenter
{
    public partial class FormExpendPaint :FormChild
    {
        CarpenterEntity.ExpendPaintEntity _model=null;
        CarpenterBll.Bll.ExpendPaintBll _bll=null;
        string strWhere="1=1",state=string.Empty;
        bool result=false;
        DataTable tableView;
        List<string> idxList=new List<string>();
        
        public FormExpendPaint ( )
        {
            InitializeComponent ( );

            _model = new CarpenterEntity . ExpendPaintEntity ( );
            _bll = new CarpenterBll . Bll . ExpendPaintBll ( );
            tableView = new DataTable ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            FieldInfo fi = typeof ( XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolExport ,toolPrint ,toolCancellation ,toolExamin ,toolReview } );

            wait . Hide ( );
            gridView1 . OptionsBehavior . Editable = false;
            getOdd ( );
        }
        
        #region Main
        protected override int Query ( )
        {
            if ( string . IsNullOrEmpty ( lupOdd . Text ) )
            {
                XtraMessageBox . Show ( "请选择年月" );
                return 0;
            }
            strWhere = "1=1";

            if ( !string . IsNullOrEmpty ( lupOdd . Text ) )
                strWhere += " AND WXP001='" + lupOdd . Text + "'";

            _model . WXP001 = lupOdd . Text;
            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Add ( )
        {
            //_model . WXP001 =lupOdd.Text= CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyyMM" );
            _model . WXP001 = string . Empty;
            if ( _bll . Exists ( _model . WXP001 ) )
            {
                strWhere = "1=1";
                strWhere = strWhere + " AND WXP001='" + _model . WXP001 + "'";

                wait . Show ( );
                backgroundWorker2 . RunWorkerAsync ( );
            }
            else
            {
                tableView = _bll . getTableView ( "1=2" );
                gridControl1 . DataSource = tableView;
                state = "add";
                addTool ( );
                gridView1 . OptionsBehavior . Editable = true;
            }

            return base . Add ( );
        }
        protected override int Edit ( )
        {
            state = "edit";
            editTool ( );
            gridView1 . OptionsBehavior . Editable = true;

            return base . Edit ( );
        }
        protected override int Delete ( )
        {
            if ( string . IsNullOrEmpty ( lupOdd . Text ) )
            {
                XtraMessageBox . Show ( "请选择年月" );
                return 0;
            }
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            _model . WXP001 = lupOdd . Text;
            result = _bll . Delete ( _model . WXP001 );
            if ( result )
            {
                XtraMessageBox . Show ( "成功删除" );
                deleteTool ( );
                gridView1 . OptionsBehavior . Editable = false;
                gridControl1 . DataSource = null;
                getOdd ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        protected override int Save ( )
        {
            if ( checkView ( ) == false )
                return 0;

            result = _bll . Add ( tableView ,_model . WXP001 ,idxList );
            if ( result )
            {
                XtraMessageBox . Show ( "保存成功" );
                saveTool ( );
                gridView1 . OptionsBehavior . Editable = false;
                getOdd ( );
            }
            else
                XtraMessageBox . Show ( "保存失败" );

            return base . Save ( );
        }
        protected override int Cancel ( )
        {
            cancelTool ( state );
            gridView1 . OptionsBehavior . Editable = false;

            return base . Cancel ( );
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
            tableView = _bll . getTableView ( strWhere );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                gridControl1 . DataSource = tableView;
                QueryTool ( );
                gridView1 . OptionsBehavior . Editable = false;
            }
        }
        private void backgroundWorker2_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            tableView = _bll . getTableView ( strWhere );
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                gridControl1 . DataSource = tableView;
                addTool ( );
                gridView1 . OptionsBehavior . Editable = true;
                state = "edit";
                getOdd ( );
            }
        }
        private void gridControl1_KeyPress ( object sender ,System . Windows . Forms . KeyPressEventArgs e )
        {
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return ;
            if ( e . KeyChar == 13 )
            {
                DataRow row = gridView1 . GetFocusedDataRow ( );
                if ( row == null )
                    return;

                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                if ( _model . idx > 0 && !idxList . Contains ( _model . idx . ToString ( ) ) )
                    idxList . Add ( _model . idx . ToString ( ) );
                tableView . Rows . Remove ( row );
                gridControl1 . Refresh ( );
            }
        }
        private void gridView1_InitNewRow ( object sender ,DevExpress . XtraGrid . Views . Grid . InitNewRowEventArgs e )
        {
            DevExpress . XtraGrid . Views . Grid . GridView view = sender as DevExpress . XtraGrid . Views . Grid . GridView;
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "WXP004" ] ,"公斤" );
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
        private void lupOdd_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( toolSave . Visibility != DevExpress . XtraBars . BarItemVisibility . Always )
                return;
            if ( lupOdd . Text == string . Empty )
                return;
            if ( _bll . ExistsDate ( lupOdd . Text ) )
            {
                strWhere = "1=1";
                strWhere += " AND WXP001='" + lupOdd . Text + "'";
                tableView = _bll . getTableView ( strWhere );
                gridControl1 . DataSource = tableView;
                state = "edit";
            }
            else
            {
                tableView = _bll . getView ( "1=1" );
                gridControl1 . DataSource = tableView;
                state = "add";
            }
        }
        #endregion

        #region Method
        void getOdd ( )
        {
            LookUpEdit . DataSource = _bll . getPaintName ( );
            LookUpEdit . DisplayMember = "EPP005";
            LookUpEdit . ValueMember = "EPP005";

            //lupOdd . Properties . DataSource = _bll . getOddNum ( );
            //lupOdd . Properties . DisplayMember = "WXP001";
        }
        bool checkView ( )
        {
            result = true;


            if ( string . IsNullOrEmpty ( lupOdd . Text ) )
            {
                XtraMessageBox . Show ( "请选择年月" );
                return false;
            }

            _model . WXP001 = lupOdd . Text;

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );


            DataRow row;
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                row = gridView1 . GetDataRow ( i );
                _model . WXP002 = row [ "WXP002" ] . ToString ( );
                _model . WXP004 = row [ "WXP004" ] . ToString ( );
                _model . WXP005 = string . IsNullOrEmpty ( row [ "WXP005" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "WXP005" ] . ToString ( ) );
                _model . WXP006 = string . IsNullOrEmpty ( row [ "WXP006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "WXP006" ] . ToString ( ) );
                row . ClearErrors ( );
                if ( string . IsNullOrEmpty ( _model . WXP002 )  )
                {
                    row . SetColumnError ( "WXP002" ,"不可为空" );
                    result = false;
                    break;
                }
                if ( string . IsNullOrEmpty ( _model . WXP004 ) )
                {
                    row . SetColumnError ( "WXP004" ,"不可为空" );
                    result = false;
                    break;
                }
                if ( _model . WXP005 < 0 )
                {
                    row . SetColumnError ( "WXP005" ,"请填写数量" );
                    result = false;
                    break;
                }
                if ( _model . WXP006 < 0 )
                {
                    row . SetColumnError ( "WXP006" ,"请填写单价" );
                    result = false;
                    break;
                }
            }

            return result;
        }
        #endregion

    }
}