using System . Reflection;
using DevExpress . Utils . Paint;
using System . Data;
using DevExpress . XtraEditors;
using System;
using System . Windows . Forms;
using System . ComponentModel;

namespace Carpenter
{
    public partial class FormExoendBasePaint :FormChild
    {
        CarpenterBll.Bll.ExoendBasePaintBll _bll=null;
        CarpenterEntity.ExoendBasePaintEntity _model=null;
        DataTable tableView;bool result=false;
        
        public FormExoendBasePaint ( )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . ExoendBasePaintBll ( );
            _model = new CarpenterEntity . ExoendBasePaintEntity ( );
            tableView = new DataTable ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            FieldInfo fi = typeof ( XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );


            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolExport ,toolPrint ,toolCancellation ,toolExamin ,toolReview } );

            wait . Hide ( );
            gridView1 . OptionsBehavior . Editable = false;
        }
        
        #region Main
        protected override int Query ( )
        {
            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Add ( )
        {
            wait . Show ( );
            backgroundWorker2 . RunWorkerAsync ( );

            return base . Add ( );
        }
        protected override int Edit ( )
        {
            editTool ( );
            gridView1 . OptionsBehavior . Editable = true;

            return base . Edit ( );
        }
        protected override int Save ( )
        {
            if ( checkView ( ) == false )
                return 0;

            result = _bll . Add ( tableView );
            if ( result )
            {
                XtraMessageBox . Show ( "成功保存" );
                saveTool ( );
                gridView1 . OptionsBehavior . Editable = false;
                getColumnData ( );
            }
            else
                XtraMessageBox . Show ( "保存失败" );

            return base . Save ( );
        }
        protected override int Cancel ( )
        {
            cancelTool ( "edit" );
            gridView1 . OptionsBehavior . Editable = false;

            return base . Cancel ( );
        }
        protected override int Delete ( )
        {
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            if ( gridView1 . DataRowCount < 1 )
            {
                XtraMessageBox . Show ( "请选择需要删除的内容" );
                return 0;
            }

            result = _bll . Delete ( tableView );
            if ( result )
            {
                XtraMessageBox . Show ( "成功删除" );
                deleteTool ( );
                gridView1 . OptionsBehavior . Editable = false;
                gridControl1 . DataSource = null;
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
            tableView = _bll . getTableView ( );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                gridControl1 . DataSource = tableView;
                QueryTool ( );
                gridView1 . OptionsBehavior . Editable = false;
                getColumnData ( );
            }
        }
        private void backgroundWorker2_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            tableView = _bll . getTableView ( );
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                if ( e . Error == null )
                {
                    wait . Hide ( );
                    gridControl1 . DataSource = tableView;
                    addTool ( );
                    gridView1 . OptionsBehavior . Editable = true;
                    getColumnData ( );
                }
            }
        }
        private void gridControl1_KeyPress ( object sender ,System . Windows . Forms . KeyPressEventArgs e )
        {
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return ;
            if ( e . KeyChar == 13 )
            {
                int num = gridView1 . FocusedRowHandle;
                if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
                {
                    tableView . Rows . RemoveAt ( num );
                    gridControl1 . Refresh ( );
                }
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

        #region Method
        void getColumnData ( )
        {
            //lupWoodType . DataSource = _bll . getWood ( );
            //lupWoodType . DisplayMember = "EBP001";
            //lupWoodType . ValueMember = "EBP001";

            cmbWoodType . Items . Clear ( );
            DataTable dt = _bll . getWood ( );
            foreach ( DataRow row in dt . Rows )
            {
                cmbWoodType . Items . Add ( row [ "EBP001" ] . ToString ( ) );
            }

            cmbWorkProcedure . Items . Clear ( );
            dt = _bll . getWorkProcedure ( );
            foreach ( DataRow row in dt . Rows )
            {
                cmbWorkProcedure . Items . Add ( row [ "EBP002" ] . ToString ( ) );
            }

            cmbPaintName . Items . Clear ( );
            dt = _bll . getPaintName ( );
            foreach ( DataRow row in dt . Rows )
            {
                cmbPaintName . Items . Add ( row [ "EBP003" ] . ToString ( ) );
            }

            //cmbPaintType . Items . Clear ( );
            //dt = _bll . getPaintType ( );
            //foreach ( DataRow row in dt . Rows )
            //{
            //    cmbPaintType . Items . Add ( row [ "EBP004" ] . ToString ( ) );
            //}
        }
        bool checkView ( )
        {
            result = true;
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            DataRow row;
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                row = gridView1 . GetDataRow ( i );
                _model . EBP001 = row [ "EBP001" ] . ToString ( );
                _model . EBP002 = row [ "EBP002" ] . ToString ( );
                _model . EBP003 = row [ "EBP003" ] . ToString ( );
                //_model . EBP004 = row [ "EBP004" ] . ToString ( );
                _model . EBP005 = string . IsNullOrEmpty ( row [ "EBP005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "EBP005" ] . ToString ( ) );
                _model . EBP006 = string . IsNullOrEmpty ( row [ "EBP006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "EBP006" ] . ToString ( ) );

                row . ClearErrors ( );
                if ( string . IsNullOrEmpty ( _model . EBP001 ) )
                {
                    row . SetColumnError ( "EBP001" ,"不可为空" );
                    result = false;
                    break;
                }
                if ( string . IsNullOrEmpty ( _model . EBP002 ) )
                {
                    row . SetColumnError ( "EBP002" ,"不可为空" );
                    result = false;
                    break;
                }
                if ( string . IsNullOrEmpty ( _model . EBP003 ) )
                {
                    row . SetColumnError ( "EBP003" ,"不可为空" );
                    result = false;
                    break;
                }
                //if ( string . IsNullOrEmpty ( _model . EBP004 ) )
                //{
                //    row . SetColumnError ( "EBP004" ,"不可为空" );
                //    result = false;
                //    break;
                //}
                if ( _model . EBP005 <= 0 )
                {
                    row . SetColumnError ( "EBP005" ,"不可小于零" );
                    result = false;
                    break;
                }
                if ( _model . EBP006 <= 0 )
                {
                    row . SetColumnError ( "EBP006" ,"不可小于零" );
                    result = false;
                    break;
                }
            }

            return result;
        }
        #endregion

    }
}