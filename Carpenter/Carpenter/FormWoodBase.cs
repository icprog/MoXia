using DevExpress . Utils . Paint;
using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormWoodBase :FormChild
    {
        CarpenterEntity.WoodBaseEntity _model=null;
        CarpenterBll.Bll.WoodBaseBll _bll=null;
        DataTable tableView,tableProduct;
        string strWhere="1=1",state=string.Empty;
        bool result=false;List<int> intList=new List<int>();
        
        public FormWoodBase ( )
        {
            InitializeComponent ( );

            _model = new CarpenterEntity . WoodBaseEntity ( );
            _bll = new CarpenterBll . Bll . WoodBaseBll ( );
            tableView = new DataTable ( );

            Utility . GridViewMoHuSelect . SetFilter ( repositoryItemSearchLookUpEdit1View );
            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            
            FieldInfo fi = typeof ( XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] {toolExport ,toolPrint ,toolCancellation ,toolExamin ,toolReview  } );

            wait . Hide ( );
            getWood ( );
            binding ( );
            gridView1 . OptionsBehavior . Editable = false;
        }

        #region Main
        protected override int Query ( )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupWood . Text ) )
                strWhere = strWhere + " AND WOB003='" + lupWood . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPartNum . Text ) )
                strWhere = strWhere + " AND WOB001 IN (SELECT CUU002 FROM MOXCUU WHERE CUU001='" + lupPartNum . Text + "')";

            wait . Hide ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Add ( )
        {
            state = "add";
            tableView = _bll . getTableView ( "1=2" );
            gridControl1 . DataSource = tableView;
            addTool ( );
            gridView1 . OptionsBehavior . Editable = true;

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
            if ( gridView1 . DataRowCount <1 )
            {
                XtraMessageBox . Show ( "请查询需要删除的内容" );
                return 0;
            }
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            result = _bll . Delete ( tableView );
            if ( result )
            {
                XtraMessageBox . Show ( "成功删除" );
                gridControl1 . DataSource = null;
                gridView1 . OptionsBehavior . Editable = false;
                deleteTool ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        protected override int Save ( )
        {
            if ( checkView ( ) == false )
                return 0;

            result = _bll . Add ( tableView ,intList );
            if ( result )
            {
                XtraMessageBox . Show ( "成功保存" );
                saveTool ( );
                gridView1 . OptionsBehavior . Editable = false;
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

        #region Method
        void getWood ( )
        {
            lupWood . Properties . DataSource = _bll . getWood ( );
            lupWood . Properties . DisplayMember = "WOB003";
            lupPartNum . Properties . DataSource = _bll . getPartNum ( );
            lupPartNum . Properties . DisplayMember = "CUT001";
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
                _model . WOB001 = row [ "WOB001" ] . ToString ( );
                _model . WOB003 = row [ "WOB003" ] . ToString ( );
                _model . WOB004 = row [ "WOB004" ] . ToString ( );
                _model . WOB005 = string . IsNullOrEmpty ( row [ "WOB005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "WOB005" ] . ToString ( ) );
                row . ClearErrors ( );
                if ( string . IsNullOrEmpty ( _model . WOB001 ) )
                {
                    row . SetColumnError ( "WOB001" ,"不可为空" );
                    result = false;
                    break;
                }
                if ( string . IsNullOrEmpty ( _model . WOB003 ) )
                {
                    row . SetColumnError ( "WOB003" ,"不可为空" );
                    result = false;
                    break;
                }
                if ( string . IsNullOrEmpty ( _model . WOB004 ) )
                {
                    row . SetColumnError ( "WOB004" ,"不可为空" );
                    result = false;
                    break;
                }
                if ( _model . WOB005 <= 0 )
                {
                    row . SetColumnError ( "WOB005" ,"请重新输入" );
                    result = false;
                    break;
                }
            }

            return result;
        }
        void binding ( )
        {
            tableProduct = _bll . getTableProduct ( );
            secProduct . DataSource = tableProduct;
            secProduct . DisplayMember = "WOB001";
            secProduct . ValueMember = "WOB001";

            //lupProduct . DataSource = tableProduct;
            //lupProduct . DisplayMember = "WOB001";
            //lupProduct . ValueMember = "WOB001";

            //lupWoodColor . DataSource = _bll . getWood ( );
            //lupWoodColor . DisplayMember = "WOB003";
            //lupWoodColor . ValueMember = "WOB003";

            DataTable dt = _bll . getTableType ( );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    if ( !cmbType . Items . Contains ( dt . Rows [ i ] [ "WOB004" ] . ToString ( ) ) )
                        cmbType . Items . Add ( dt . Rows [ i ] [ "WOB004" ] . ToString ( ) );
                }
            }
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
                gridView1 . OptionsBehavior . Editable = false;
                QueryTool ( );
            }
        }
        private void secProduct_EditValueChanged ( object sender ,EventArgs e )
        {
            DevExpress . XtraEditors . BaseEdit edit = gridView1 . ActiveEditor;
            switch ( gridView1 . FocusedColumn . FieldName )
            {
                case "WOB001":
                if ( edit . EditValue != null )
                {
                    _model . WOB002 = tableProduct . Select ( "WOB001='" + edit . EditValue + "'" ) [ 0 ] [ "WOB002" ] . ToString ( );
                    _model . WOB003 = tableProduct . Select ( "WOB001='" + edit . EditValue + "'" ) [ 0 ] [ "WOB003" ] . ToString ( );
                    gridView1 . SetFocusedRowCellValue ( gridView1 . Columns [ "WOB002" ] ,_model . WOB002 );
                    gridView1 . SetFocusedRowCellValue ( gridView1 . Columns [ "WOB003" ] ,_model . WOB003 );
                }
                break;
            }
        }
        private void lupProduct_EditValueChanged ( object sender ,EventArgs e )
        {
           
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
                    _model . idx = string . IsNullOrEmpty ( gridView1 . GetDataRow ( num ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( num ) [ "idx" ] . ToString ( ) );

                    if ( _model . idx > 0 && !intList . Contains ( _model . idx ) )
                        intList . Add ( _model . idx );

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

    }
}