using System . Reflection;
using DevExpress . Utils . Paint;
using System . Data;
using System . Collections . Generic;
using System;
using DevExpress . XtraEditors;
using System . Windows . Forms;
using System . ComponentModel;
using System . Linq;

namespace Carpenter
{
    public partial class FormExpendPlanPaint :FormChild
    {
        CarpenterEntity.ExpendPlanPaintEntity _model=null;
        CarpenterBll.Bll.ExpendPlanPaintBll _bll=null;
        string strWhere="1=1";bool result=false;
        DataTable tableView,tableProduct;
        List<int?> intList=new List<int?>();
        
        public FormExpendPlanPaint ( )
        {
            InitializeComponent ( );

            _model = new CarpenterEntity . ExpendPlanPaintEntity ( );
            _bll = new CarpenterBll . Bll . ExpendPlanPaintBll ( );
            tableView = new DataTable ( );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolExport,toolPrint,toolCancellation ,toolExamin ,toolReview  } );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            wait . Hide ( );
            gridView1 . OptionsBehavior . Editable = false;
            getColumnData ( );
        }
        
        #region Main
        protected override int Query ( )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupProduct . Text ) )
                strWhere += " AND EPP001='" + lupProduct . EditValue . ToString ( ) + "'";
            if ( !string . IsNullOrEmpty ( lupWoodQuery . Text ) )
                strWhere += " AND EPP002='" + lupWoodQuery . Text + "'";
            if ( !string . IsNullOrEmpty ( lupWorkProcedure . Text ) )
                strWhere += " AND EPP003='" + lupWorkProcedure . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPaintName . Text ) )
                strWhere += " AND EPP004='" + lupPaintName . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPaintType . Text ) )
                strWhere += " AND EPP005='" + lupPaintType . Text + "'";

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Add ( )
        {
            tableView = _bll . getTableView ( "1=2" );
            gridControl1 . DataSource = tableView;
            addTool ( );
            gridView1 . OptionsBehavior . Editable = true;
            intList . Clear ( );

            return base . Add ( );
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
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            if ( tableView . Rows . Count < 1 )
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
            cancelTool ( "edit" );
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
        private void gridControl1_KeyPress ( object sender ,System . Windows . Forms . KeyPressEventArgs e )
        {
            if ( toolSave . Visibility != DevExpress . XtraBars . BarItemVisibility . Always )
                return;
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return ;
            if ( e . KeyChar == 13 )
            {
                DataRow row = gridView1 . GetFocusedDataRow ( );
                if ( row != null )
                {
                    _model . idx = string . IsNullOrEmpty ( row[ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                    if ( _model . idx > 0 && !intList . Contains ( _model . idx ) )
                    {
                        intList . Add ( _model . idx );
                    }

                    tableView . Rows . Remove ( row );
                    gridControl1 . Refresh ( );
                }
            }
        }
        private void btnClear_Click ( object sender ,EventArgs e )
        {
            lupProduct . EditValue = lupWoodQuery . EditValue = lupWorkProcedure . EditValue = lupPaintName . EditValue = lupPaintType . EditValue = null;
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
            tableProduct = _bll . getTableProduct ( );
            lupProduct . Properties . DataSource = tableProduct;
            lupProduct . Properties . DisplayMember = "PBA005";
            lupProduct . Properties . ValueMember = "PBA005";
            if ( tableProduct != null && tableProduct . Rows . Count > 0 )
            {
                cmbXL . Items . Clear ( );
                foreach ( DataRow row in tableProduct . Rows )
                {
                    cmbXL . Items . Add ( row [ "PBA005" ] );
                }
            }
            

            DataTable dt = _bll . getTableColumn ( );
            lupWoodQuery . Properties . DataSource = dt;
            lupWoodQuery . Properties . DisplayMember = "PBA003";
            if ( dt != null && dt . Rows . Count > 0 )
            {
                cmbBJ . Items . Clear ( );
                foreach ( DataRow row in dt . Rows )
                {
                    cmbBJ . Items . Add ( row [ "PBA003" ] );
                }
            }

            DataTable part = _bll . getTablePart ( );
            lupWorkProcedure . Properties . DataSource = part . DefaultView . ToTable ( true ,"EPP003" );
            lupWorkProcedure . Properties . DisplayMember = "EPP003";
            lupPaintName . Properties . DataSource = part . DefaultView . ToTable ( true ,"EPP004" );
            lupPaintName . Properties . DisplayMember = "EPP004";
            lupPaintType . Properties . DataSource = part . DefaultView . ToTable ( true ,"EPP005" );
            lupPaintType . Properties . DisplayMember = "EPP005";
            if ( part != null && part . Rows . Count > 0 )
            {
                cmbName . Items . Clear ( );
                foreach ( DataRow row in part . DefaultView . ToTable ( true ,"EPP003" ) . Rows )
                {
                    cmbName . Items . Add ( row [ "EPP003" ] );
                }
            }
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
                row . ClearErrors ( );

                _model . EPP001 = row [ "EPP001" ] . ToString ( );
                _model . EPP002 = row [ "EPP002" ] . ToString ( );
                _model . EPP003 = row [ "EPP003" ] . ToString ( );
                _model . EPP004 = row [ "EPP004" ] . ToString ( );
                _model . EPP005 = row [ "EPP005" ] . ToString ( );
                if ( row [ "EPP007" ] == null || row [ "EPP007" ] . ToString ( ) == string . Empty )
                    _model . EPP007 = null;
                else
                    _model . EPP007 = Convert . ToDateTime ( row [ "EPP007" ] . ToString ( ) );

                if ( string . IsNullOrEmpty ( _model . EPP001 ) )
                {
                    row . SetColumnError ( "EPP001" ,"请选择" );
                    result = false;
                    break;
                }
                if ( string . IsNullOrEmpty ( _model . EPP002 ) )
                {
                    row . SetColumnError ( "EPP002" ,"不可为空" );
                    result = false;
                    break;
                }
                if ( string . IsNullOrEmpty ( _model . EPP003 ) )
                {
                    row . SetColumnError ( "EPP003" ,"不可为空" );
                    result = false;
                    break;
                }
                if ( string . IsNullOrEmpty ( _model . EPP004 ) )
                {
                    row . SetColumnError ( "EPP004" ,"不可为空" );
                    result = false;
                    break;
                }
                if ( string . IsNullOrEmpty ( _model . EPP005 ) )
                {
                    row . SetColumnError ( "EPP004" ,"不可为空" );
                    result = false;
                    break;
                }
                if ( _model . EPP007 == null )
                {
                    row . SetColumnError ( "EPP007" ,"不可为空" );
                    result = false;
                    break;
                }

            }

            if ( result == false )
                return false;

            var query = from p in tableView . AsEnumerable ( )
                        group p by new
                        {
                            p1 = p . Field<string> ( "EPP001" ) ,
                            p2 = p . Field<string> ( "EPP002" ) ,
                            p3 = p . Field<string> ( "EPP003" ) ,
                            p4 = p . Field<string> ( "EPP004" ) ,
                            p5 = p . Field<string> ( "EPP005" ),
                            p7 = p . Field<DateTime> ( "EPP007" )
                        } into m
                        select new
                        {
                            epp001 = m . Key . p1 ,
                            epp002 = m . Key . p2 ,
                            epp003 = m . Key . p3 ,
                            epp004 = m . Key . p4 ,
                            epp005 = m . Key . p5 ,
                            epp007 = m . Key . p7 ,
                            rowcount = m . Count ( )
                        };
            if ( query != null )
            {
                foreach ( var x in query )
                {
                    if ( x . rowcount > 1 )
                    {
                        XtraMessageBox . Show ( "系列:" + x . epp001 + "\n\r部件:" + x . epp002 + "\n\r名称:" + x . epp003 + "\n\r工序:" + x . epp004 + "\n\r油漆:" + x . epp005 + "\n\r日期:" + x . epp007 + "\n\r重复,请核实" ,"提示" );
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




