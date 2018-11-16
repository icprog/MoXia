using System;
using System . ComponentModel;
using System . Data;
using DevExpress . XtraEditors;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormWageCoef :FormChild
    {
        CarpenterBll.Bll.WageCoefBll _bll=null;
        DataTable tableView;
        bool result=false;
        
        public FormWageCoef ( )
        {
            InitializeComponent ( );
            

            _bll = new CarpenterBll . Bll . WageCoefBll ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] {  toolPrint ,toolCancellation ,toolExamin ,toolReview  } );

            controlUnEnable ( );
            wait . Hide ( );
        }
        
        #region Main
        protected override int Query ( )
        {
            if ( string . IsNullOrEmpty ( dtTime . Text ) )
            {
                XtraMessageBox . Show ( "请选择年月" );
                return 0;
            }

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Add ( )
        {
            controlEnable ( );
            addTool ( );

            return base . Add ( );
        }
        protected override int Edit ( )
        {
            controlEnable ( );
            editTool ( );

            return base . Edit ( );
        }
        protected override int Delete ( )
        {
            if ( string . IsNullOrEmpty ( dtTime . Text ) )
            {
                XtraMessageBox . Show ( "请选择年月" );
                return 0;
            }
            if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;

            result = _bll . Delete ( dtTime . Text );
            if ( result )
            {
                XtraMessageBox . Show ( "成功删除" );
                controlClear ( );
                controlUnEnable ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        protected override int Save ( )
        {
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            result = _bll . Save ( tableView ,dtTime . Text );
            if ( result )
            {
                XtraMessageBox . Show ( "成功保存" );
                controlUnEnable ( );
                saveTool ( );
            }
            else
                XtraMessageBox . Show ( "保存失败" );

            return base . Save ( );
        }
        protected override int Cancel ( )
        {
            cancelTool ( "edit" );
            controlUnEnable ( );

            return base . Cancel ( );
        }
        protected override int Export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            return base . Export ( );
        }
        #endregion

        #region Event
        private void backgroundWorker1_DoWork ( object sender ,DoWorkEventArgs e )
        {
            tableView = _bll . getTableView ( dtTime . Text );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                gridControl1 . DataSource = tableView;
                if ( tableView == null || tableView . Rows . Count < 1 )
                    return;
                QueryTool ( );
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }
        private void backgroundWorker2_DoWork ( object sender ,DoWorkEventArgs e )
        {
            result = _bll . Read ( dtTime . Text );
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                if ( result )
                {
                    Query ( );
                }
                else
                    XtraMessageBox . Show ( "读取失败" );
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
        void controlEnable ( )
        {
            gridView1 . OptionsBehavior . Editable = true;
        }
        void controlUnEnable ( )
        {
            gridView1 . OptionsBehavior . Editable = false;
        }
        void controlClear ( )
        {
            dtTime . Text = string . Empty;
            gridControl1 . DataSource = null;
        }
        #endregion

        #region Click
        private void btnRead_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( dtTime . Text ) )
            {
                XtraMessageBox . Show ( "请选择年月" );
                return ;
            }
            wait . Show ( );
            backgroundWorker2 . RunWorkerAsync ( );
        }
        #endregion
    }
}