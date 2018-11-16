using System . ComponentModel;
using System . Data;
using System . Reflection;
using DevExpress . Utils . Paint;
using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . Windows . Forms;
using FastReport;

namespace Carpenter
{
    public partial class FormExpendPaintAnalysis :FormChild
    {
        CarpenterEntity.ExpendPaintAnalysisEntity _model=null;
        CarpenterBll.Bll.ExpendPaintAnalysisBll _bll=null;
        DataTable tableView,printTable,exportTable;
        string strWhere="1=1";bool result=false;
        List<int> intList=new List<int>();
        
        public FormExpendPaintAnalysis ( )
        {
            InitializeComponent ( );
            
            _model = new CarpenterEntity . ExpendPaintAnalysisEntity ( );
            _bll = new CarpenterBll . Bll . ExpendPaintAnalysisBll ( );
            tableView = new DataTable ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            FieldInfo fi = typeof ( XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] {toolPrint, toolCancellation ,toolExamin ,toolReview ,toolAdd } );

            wait . Hide ( );
            gridView1 . OptionsBehavior . Editable = false;
        }
        
        #region Main
        protected override int Query ( )
        {
            if ( string . IsNullOrEmpty ( dateEdit . Text ) )
            {
                XtraMessageBox . Show ( "年月不可为空" );
                return 0;
            }

            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( dateEdit . Text ) )
                strWhere += " AND EPA001='" +  dateEdit . Text  + "'";

            _model . EPA001 = dateEdit . Text;
            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Edit ( )
        {
            editTool ( );
            gridView1 . OptionsBehavior . Editable = true;
            intList . Clear ( );

            return base . Edit ( );
        }
        protected override int Delete ( )
        {
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            if ( string . IsNullOrEmpty ( dateEdit . Text ) )
            {
                XtraMessageBox . Show ( "请选择年月" );
                return 0;
            }
            _model . EPA001 = dateEdit . Text;

            result = _bll . Delete ( _model . EPA001 );
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
        protected override int Save ( )
        {
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            result = _bll . Add ( tableView ,_model . EPA001 ,intList );
            if ( result )
            {
                XtraMessageBox . Show ( "保存成功" );
                saveTool ( );
                gridView1 . OptionsBehavior . Editable = false;
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
        protected override int Print ( )
        {
            if ( string . IsNullOrEmpty ( dateEdit . Text ) )
            {
                XtraMessageBox . Show ( "请选择年月" );
                return 0;
            }
            getPrint ( );

            Print ( new DataTable [ ] { printTable,exportTable } ,"油漆耗用分析表.frx" );

            return base . Print ( );
        }
        protected override int Export ( )
        {
            if ( string . IsNullOrEmpty ( dateEdit . Text ) )
            {
                XtraMessageBox . Show ( "请选择年月" );
                return 0;
            }
            getPrint ( );

            Export ( new DataTable [ ] { printTable ,exportTable } ,"油漆耗用分析表.frx" );

            //ViewExport . ExportToExcel ( this . Text ,this . gridControl1 );

            return base . Export ( );
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
        private void backgroundWorker1_DoWork ( object sender ,DoWorkEventArgs e )
        {
            tableView = _bll . getTableView ( strWhere );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                gridControl1 . DataSource = tableView;
                QueryTool ( );
                gridView1 . OptionsBehavior . Editable = false;
                toolPrint . Visibility = toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }
        private void gridControl1_KeyPress ( object sender ,System . Windows . Forms . KeyPressEventArgs e )
        {
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return ;
            if ( e . KeyChar == 13 )
            {
                DataRow row = gridView1 . GetFocusedDataRow ( );
                if ( row != null )
                {
                    _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                    if ( _model . idx > 0 && !intList . Contains ( _model . idx ) )
                    {
                        intList . Add ( _model . idx );
                    }
                    tableView . Rows . Remove ( row );
                    gridControl1 . Refresh ( );
                }
            }
        }
        private void backgroundWorker2_DoWork ( object sender ,DoWorkEventArgs e )
        {
             result = _bll . Generate ( dateEdit . Text );
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                if ( result == false )
                    XtraMessageBox . Show ( "生成失败,请重试" );
                else if ( result )
                {
                    XtraMessageBox . Show ( "生成成功" );
                    Query ( );
                    DataTable warnTable = _bll . proList ( dateEdit . Text );
                    if ( warnTable == null || warnTable . Rows . Count < 1 )
                        return;
                    OrderEdit . FormExpendWarn from = new OrderEdit . FormExpendWarn ( warnTable ,dateEdit . Text );
                    from . Show ( );
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
        //读取
        private void btnRead_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( dateEdit . Text ) )
            {
                XtraMessageBox . Show ( "请选择年月" );
                return;
            }

            wait . Show ( );
            backgroundWorker2 . RunWorkerAsync ( );
        }
        #endregion

        #region Method
        void getPrint ( )
        {
            printTable = _bll . getPrintTable ( dateEdit . Text );
            printTable . TableName = "Table";

            exportTable = _bll . getPrintTableTwo ( dateEdit . Text . Substring ( 0 ,4 ) );
            exportTable . TableName = "TableOne";
        }
        #endregion

    }
}
