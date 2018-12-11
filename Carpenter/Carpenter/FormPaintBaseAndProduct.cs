using System . ComponentModel;
using System . Data;
using System . Windows . Forms;
using DevExpress . XtraEditors;
using System . Collections . Generic;
using System;
using System . Reflection;
using DevExpress . Utils . Paint;
using System . Linq;

namespace Carpenter
{
    public partial class FormPaintBaseAndProduct :FormChild
    {
        CarpenterBll.Bll.PaintBaseAndProductBll _bll=null;
        DataTable tableView,tablePro;
        bool result=false;
        List<string> idxList=new List<string>();
        string piNum=string.Empty;
        
        public FormPaintBaseAndProduct ( )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . PaintBaseAndProductBll ( );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] {  toolCancellation ,toolExamin ,toolReview } );

            controlUnEnable ( );

            Utility . GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,viewP } );
            FieldInfo fi = typeof ( XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            tablePro = _bll . getTablePro ( );
            gridL . DataSource = tablePro;
            gridL . DisplayMember = "PBA001";
            gridL . ValueMember = "PBA001";
            wait . Hide ( );

            toolPrint . Caption = "导入";
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
            controlEnable ( );
            addTool ( );

            tableView = _bll . getTableView ( "1=2" );
            gridControl1 . DataSource = tableView;

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
            int [ ] select = gridView1 . GetSelectedRows ( );
            if ( select . Length < 1 )
            {
                XtraMessageBox . Show ( "请选择需要删除的内容" );
                return 0;
            }

            if ( XtraMessageBox . Show ( "确认删除?" ,"提示" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;

            CarpenterEntity . PaintBaseAndProductEntity model = new CarpenterEntity . PaintBaseAndProductEntity ( );
            foreach ( int i in select )
            {
                model . idx = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                if ( model . idx > 0 && !idxList . Contains ( model . idx . ToString ( ) ) )
                    idxList . Add ( model . idx . ToString ( ) );
            }

            if ( idxList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要删除的内容" );
                return 0;
            }

            result = _bll . Delete ( idxList );
            if ( result )
            {
                XtraMessageBox . Show ( "成功删除" );
                controlUnEnable ( );
                gridControl1 . DataSource = null;
                idxList . Clear ( );
                deleteTool ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            return base . Delete ( );
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
            cancelTool ( "edit" );
            controlUnEnable ( );

            return base . Cancel ( );
        }
        protected override int Export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            return base . Export ( );
        }
        protected override int Print ( )
        {
            DataTable table = ExeclToDataSource . Choise ( );

            if ( table == null || table . Rows . Count < 1 )
                return 0;

            if ( checkTable ( table ) == false )
                return 0;

            result = _bll . SaveTable ( table );
            if ( result )
                XtraMessageBox . Show ( "成功保存,请查询" );
            else
                XtraMessageBox . Show ( "保存失败,请重试" );

            return base . Print ( );
        }
        #endregion

        #region Event
        private void backgroundWorker1_DoWork ( object sender ,DoWorkEventArgs e )
        {
            tableView = _bll . getTableView ( "1=1" );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                gridControl1 . DataSource = tableView;
                QueryTool ( );
                controlUnEnable ( );
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }
        private void backgroundWorker2_DoWork ( object sender ,DoWorkEventArgs e )
        {
            result = _bll . Save ( tableView );
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                if ( result )
                {
                    XtraMessageBox . Show ( "成功保存" );
                    controlUnEnable ( );
                    saveTool ( );
                }
                else
                    XtraMessageBox . Show ( "保存失败" );
            }
        }
        private void gridL_EditValueChanged ( object sender ,EventArgs e )
        {
            DevExpress . XtraEditors . BaseEdit edit = gridView1 . ActiveEditor;
            if ( gridView1 . FocusedColumn . FieldName == "PBA001" )
            {
                if ( edit . EditValue == null )
                    return;
                piNum = edit . EditValue . ToString ( );
                gridView1 . SetFocusedRowCellValue ( gridView1 . Columns [ "PBA002" ] ,tablePro . Select ( "PBA001='" + edit . EditValue . ToString ( ) + "'" ) [ 0 ] [ "PBA002" ] . ToString ( ) );
                //gridView1 . SetFocusedRowCellValue ( gridView1 . Columns [ "PBA005" ] ,tablePro . Select ( "PBA001='" + edit . EditValue . ToString ( ) + "'" ) [ 0 ] [ "PBA005" ] . ToString ( ) );
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
        private void gridView1_CellValueChanged ( object sender ,DevExpress . XtraGrid . Views . Base . CellValueChangedEventArgs e )
        {
            DataRow row = gridView1 . GetDataRow ( e . RowHandle );
            if ( e . Column . FieldName == "PBA002" && ( e . Value != null && e . Value . ToString ( ) != string . Empty ) )
            {
                if ( row [ "PBA005" ] != null && row [ "PBA005" ] . ToString ( ) != string . Empty )
                {
                    foreach ( DataRow r in tableView . Rows )
                    {
                        if ( r [ "PBA005" ] . ToString ( ) . Equals ( row [ "PBA005" ] . ToString ( ) ) && ( r [ "PBA002" ] == null || r [ "PBA002" ] . ToString ( ) == string . Empty ) )
                        {
                            r [ "PBA001" ] = piNum;
                            r [ "PBA002" ] = e . Value;
                        }
                    }
                }
            }
            if ( e . Column . FieldName == "PBA005" && ( e . Value == null || e . Value . ToString ( ) == string . Empty ) )
                return;
            DataTable table = _bll . getColumns ( e . Value . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                return;
            int i = 0;
            foreach ( DataRow ro in table . Rows )
            {
                if ( i == 0 )
                    row [ "PBA003" ] = ro [ "PBA003" ];
                else
                {
                    DataRow r = tableView . NewRow ( );
                    r [ "PBA005" ] = ro [ "PBA005" ];
                    r [ "PBA003" ] = ro [ "PBA003" ];
                    r [ "PBA001" ] = row [ "PBA001" ];
                    r [ "PBA002" ] = row [ "PBA002" ];
                    tableView . Rows . Add ( r );
                }
                i++;
            }
            gridControl1 . RefreshDataSource ( );
        }
        #endregion

        #region Method
        void controlUnEnable ( )
        {
            gridView1 . OptionsBehavior . Editable = false;
        }
        void controlEnable ( )
        {
            gridView1 . OptionsBehavior . Editable = true;
        }
        bool checkTable ( DataTable table )
        {
            result = true;

            var query = from p in table . AsEnumerable ( )
                        group p by new
                        {
                            p2 = p . Field<string> ( "2" ) ,
                            p3 = p . Field<string> ( "3" ) ,
                            p4 = p . Field<string> ( "4" ) ,
                            p5 = p . Field<string> ( "5" ) 
                        } into m
                        select new
                        {
                            epp002 = m . Key . p2 ,
                            epp003 = m . Key . p3 ,
                            epp004 = m . Key . p4 ,
                            epp005 = m . Key . p5 ,
                            rowcount = m . Count ( )
                        };

            if ( query != null )
            {
                foreach ( var x in query )
                {
                    if ( x . rowcount > 1 )
                    {
                        XtraMessageBox . Show ( "系列:" + x . epp002 + "\n\r品号:" + x . epp003 + "\n\r品名:" + x . epp004 + "\n\r部件:" + x . epp005 + "\n\r重复,请核实" ,"提示" );
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }
        #endregion

    }
}