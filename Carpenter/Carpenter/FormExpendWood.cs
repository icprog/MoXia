using DevExpress . Utils . Paint;
using DevExpress . XtraEditors;
using System;
using System . ComponentModel;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormExpendWood :FormChild
    {
        CarpenterBll.Bll.ExpendWoodBll _bll=null;
        CarpenterEntity.ExpendWoodEntity _model=null;
        string strWhere="1=1",state=string.Empty; bool result=false;
        DataTable tableView;
        
        public FormExpendWood ( )
        {
            InitializeComponent ( );
                   
            _bll = new CarpenterBll . Bll . ExpendWoodBll ( );
            _model = new CarpenterEntity . ExpendWoodEntity ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            FieldInfo fi = typeof ( XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolExport ,toolPrint ,toolCancellation ,toolExamin ,toolReview } );

            getOdd ( );
            gridView1 . OptionsBehavior . Editable = false;
            wait . Hide ( );
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
                strWhere = strWhere + " AND EXW001='" + lupOdd . Text + "'";

            _model . EXW001 = lupOdd . Text;
            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Add ( )
        {
            _model . EXW001 = CarpenterBll . UserInformation . dt ( ) . ToString ( "yyyyMM" );

            if ( _bll . Exists_Odd ( _model . EXW001 ) )
            {
                strWhere = "1=1";
                strWhere = strWhere + " AND EXW001='" + _model . EXW001 + "'";

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
            _model . EXW001 = lupOdd . Text;
            result = _bll . Delete ( _model . EXW001 );
            if ( result )
            {
                XtraMessageBox . Show ( "删除成功" );
                gridView1 . OptionsBehavior . Editable = false;
                gridControl1 . DataSource = null;
                deleteTool ( );
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

            if ( state . Equals ( "add" ) )
                result = _bll . Add ( tableView ,_model . EXW001 );
            else
                result = _bll . Edit ( tableView ,_model . EXW001 );

            if ( result )
            {
                XtraMessageBox . Show ( "保存成功" );
                saveTool ( );
                getOdd ( );
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
            }
        }
        private void gridView1_CustomRowCellEdit ( object sender ,DevExpress . XtraGrid . Views . Grid . CustomRowCellEditEventArgs e )
        {
            DataTable dt;
            if ( e . Column . FieldName == "EXW003" )
            {
                dt = _bll . getCmbType ( );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                    {
                        if ( !cmbType . Items . Contains ( dt . Rows [ i ] [ "EXW003" ] . ToString ( ) ) )
                            cmbType . Items . Add ( dt . Rows [ i ] [ "EXW003" ] . ToString ( ) );
                    }
                }
            }
            if ( e . Column . FieldName == "EXW005" )
            {
                dt = _bll . getCmbGrade ( );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                    {
                        if ( !cmbGrade . Items . Contains ( dt . Rows [ i ] [ "EXW005" ] . ToString ( ) ) )
                            cmbGrade . Items . Add ( dt . Rows [ i ] [ "EXW005" ] . ToString ( ) );
                    }
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
        private void gridView1_InitNewRow ( object sender ,DevExpress . XtraGrid . Views . Grid . InitNewRowEventArgs e )
        {
            DevExpress . XtraGrid . Views . Grid . GridView view = sender as DevExpress . XtraGrid . Views . Grid . GridView;
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "EXW008" ] ,CarpenterBll . UserInformation . dt ( ) );
        }
        protected override void WndProc ( ref Message msg )
        {
            //if ( m . Msg == WM_NCHITTEST )
            //{
            //    switch ( m . Result . ToInt32 ( ) )
            //    {
            //        //case 1://客户区 
            //        //m.Result = new IntPtr(2); break;  

            //        case 2://标题栏      
            //        m . Result = new IntPtr ( 1 );
            //        gridControl . OnValidatingEditor ( gridControl ,new 事件参数);
            //        break;
            //    }
            //}

            base . WndProc ( ref msg );
        }
        private void gridView1_ValidateRow ( object sender ,DevExpress . XtraGrid . Views . Base . ValidateRowEventArgs e )
        {
            //for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            //{
            //    string str = gridView1 . GetDataRow ( i ) [ "EXW003" ] . ToString ( );
            //    if ( string . IsNullOrEmpty ( str ) )
            //    {
            //        e . ErrorText = "不可为空";
            //        e . Valid = false;
            //    }
            //}
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
        void getOdd ( )
        {
            lupOdd . Properties . DataSource = _bll . getOddNum ( );
            lupOdd . Properties . DisplayMember = "EXW001";
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
                _model . EXW002 = row [ "EXW002" ] . ToString ( );
                _model . EXW003 = row [ "EXW003" ] . ToString ( );
                _model . EXW004 = string . IsNullOrEmpty ( row [ "EXW004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "EXW004" ] . ToString ( ) );
                _model . EXW006 = string . IsNullOrEmpty ( row [ "EXW006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "EXW006" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( row [ "EXW008" ] . ToString ( ) ) )
                    _model . EXW008 = null;
                else
                    _model . EXW008 = Convert . ToDateTime ( row [ "EXW008" ] . ToString ( ) );
                row . ClearErrors ( );
                if ( string . IsNullOrEmpty ( _model . EXW002 ) )
                {
                    row . SetColumnError ( "EXW002" ,"不可为空" );
                    result = false;
                    break;
                }
                if ( string . IsNullOrEmpty ( _model . EXW003 ) )
                {
                    row . SetColumnError ( "EXW003" ,"不可为空" );
                    result = false;
                    break;
                }
                if ( _model . EXW004 <= 0 )
                {
                    row . SetColumnError ( "EXW004" ,"请填写正确厚度" );
                    result = false;
                    break;
                }
                if ( _model . EXW006 <= 0 )
                {
                    row . SetColumnError ( "EXW006" ,"请填写正确木材立方" );
                    result = false;
                    break;
                }
                if ( string . IsNullOrEmpty ( _model . EXW008 . ToString ( ) ) )
                {
                    row . SetColumnError ( "EXW008" ,"不可为空" );
                    result = false;
                    break;
                }
            }

            return result;
        }
        #endregion

    }
}