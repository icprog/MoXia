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
    public partial class FormPiceWageStatisticalTable :FormChild
    {
        CarpenterEntity.PiceWageStatisticalTableEntity _model=null;
        CarpenterBll.Bll.PiceWageStatisticalTableBll _bll=null;
        DataTable tableView,tablePrint;
        int resu=0,selectIdx=0;bool result=false; string strWhere = "1=1";
        List<int> intList=new List<int>();
        DataRow row;
        
        public FormPiceWageStatisticalTable ( )
        {
            InitializeComponent ( );

            _model = new CarpenterEntity . PiceWageStatisticalTableEntity ( );
            _bll = new CarpenterBll . Bll . PiceWageStatisticalTableBll ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            FieldInfo fi = typeof ( XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );


            txtUser . Properties . DataSource = _bll . getTableUser ( );
            txtUser . Properties . DisplayMember = "PRD005";
            txtUser . Properties . ValueMember = "PRD004";

            wait . Hide ( );
            gridView1 . OptionsBehavior . Editable = false;

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolPrint ,toolCancellation ,toolExamin ,toolReview  ,toolAdd } );

        }
        
        #region Main
        protected override int Query ( )
        {
            if ( string . IsNullOrEmpty ( dtOne . Text ) && string . IsNullOrEmpty ( dtTwo . Text ) && string.IsNullOrEmpty(txtUser.Text) )
            {
                XtraMessageBox . Show ( "请至少选择一个条件" );
                return 0;
            }
            if ( !string . IsNullOrEmpty ( dtOne . Text ) && !string . IsNullOrEmpty ( dtTwo . Text ) )
            {
                dtTwo . Text = string . Empty;
            }

            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( dtOne . Text ) )
                strWhere += " AND PWS028 LIKE '" +  dtOne . Text  + "%'";
            if ( !string . IsNullOrEmpty ( dtTwo . Text ) )
                strWhere += " AND PWS028='" + dtTwo . Text + "'";
            if ( txtUser . EditValue != null && !string . IsNullOrEmpty ( txtUser . EditValue . ToString ( ) ) )
                strWhere += " AND PWS001='" + txtUser . EditValue . ToString ( ) + "'";

            wait . Show ( );
            backgroundWorker2 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Edit ( )
        {
            //intList . Clear ( );
            //editTool ( );
            //gridView1 . OptionsBehavior . Editable = true;
            if ( row == null )
            {
                XtraMessageBox . Show ( "请选择需要编辑的内容" );
                return 0;
            }
            if ( string . IsNullOrEmpty ( dtOne . Text )  )
            {
                XtraMessageBox . Show ( "请选择年月" );
                return 0;
            }
            row [ "PWS028" ] = dtOne . Text;
            OrderEdit . FormPiceWageStatisticalTableEdit from = new OrderEdit . FormPiceWageStatisticalTableEdit ( row );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                Query ( );
            }

            return base . Edit ( );
        }
        protected override int Delete ( )
        {
            if ( string . IsNullOrEmpty ( dtOne . Text ) && string . IsNullOrEmpty ( dtTwo . Text ) && string . IsNullOrEmpty ( txtUser . Text ) )
            {
                XtraMessageBox . Show ( "请至少选择一个条件" );
                return 0;
            }
            if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            if ( !string . IsNullOrEmpty ( dtOne . Text ) && !string . IsNullOrEmpty ( dtTwo . Text ) )
            {
                dtTwo . Text = string . Empty;
            }

            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( dtOne . Text ) )
                strWhere += " AND PWS028 LIKE '" + dtOne . Text + "%'";
            if ( !string . IsNullOrEmpty ( dtTwo . Text ) )
                strWhere += " AND PWS028='" + dtTwo . Text + "'";
            if ( txtUser . EditValue != null && !string . IsNullOrEmpty ( txtUser . EditValue . ToString ( ) ) )
                strWhere += " AND PWS001='" + txtUser . EditValue . ToString ( ) + "'";

            result = _bll . Delete ( strWhere );
            if ( result )
            {
                XtraMessageBox . Show ( "删除成功" );
                deleteTool ( );
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

            result = _bll . Edit ( tableView ,intList );
            if ( result )
            {
                XtraMessageBox . Show ( "保存成功" );
                saveTool ( );
                gridView1 . OptionsBehavior . Editable = false;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
            else
                XtraMessageBox . Show ( "保存失败" );

            return base . Save ( );
        }
        protected override int Cancel ( )
        {
            cancelTool ( "edit" );
            gridView1 . OptionsBehavior . Editable = false;
            toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;

            return base . Cancel ( );
        }
        protected override int Export ( )
        {
            if ( string . IsNullOrEmpty ( dtOne . Text ) && string . IsNullOrEmpty ( dtTwo . Text ) && string . IsNullOrEmpty ( txtUser . Text ) )
            {
                XtraMessageBox . Show ( "请至少选择一个条件" );
                return 0;
            }
            if ( !string . IsNullOrEmpty ( dtOne . Text ) && !string . IsNullOrEmpty ( dtTwo . Text ) )
            {
                dtTwo . Text = string . Empty;
            }

            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( dtOne . Text ) )
                strWhere += " AND PWS028 LIKE '" + dtOne . Text + "%'";
            if ( !string . IsNullOrEmpty ( dtTwo . Text ) )
                strWhere += " AND PWS028='" + dtTwo . Text + "'";
            if ( txtUser . EditValue != null && !string . IsNullOrEmpty ( txtUser . EditValue . ToString ( ) ) )
                strWhere += " AND PWS001='" + txtUser . EditValue . ToString ( ) + "'";

            tablePrint = _bll . getPrintTable ( strWhere );
            tablePrint . TableName = "TableOne";

            Export ( new DataTable [ ] { tablePrint } ,"计件工资统计表.frx" );

            return base . Export ( );
        }
        #endregion

        #region Event
        //Generate
        private void btnGenert_Click ( object sender ,System . EventArgs e )
        {
            if ( string . IsNullOrEmpty ( dtOne . Text ) && string . IsNullOrEmpty ( dtTwo . Text ) )
            {
                XtraMessageBox . Show ( "请选择年月或年月日" );
                return;
            }
            if ( !string . IsNullOrEmpty ( dtOne . Text ) && !string . IsNullOrEmpty ( dtTwo . Text ) )
            {
                dtTwo . Text = string . Empty;
            }

            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( dtOne . Text ) )
                strWhere += " AND CONVERT(VARCHAR,PRD013,112) LIKE '" + dtOne . Text + "%'";
            if ( !string . IsNullOrEmpty ( dtTwo . Text ) )
                strWhere += " AND CONVERT(VARCHAR,PRD013,112)='" + dtTwo . Text + "'";
            if ( txtUser . EditValue != null && !string . IsNullOrEmpty ( txtUser . EditValue . ToString ( ) ) )
                strWhere += " AND PRD004='" + txtUser . EditValue . ToString ( ) + "'";

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );
        }
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            resu = _bll . Generate ( strWhere );
        }
        private void btnClear_Click ( object sender ,EventArgs e )
        {
            dtOne . Text = dtTwo . Text = txtUser . Text = string . Empty;
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                if ( resu == 0 )
                    XtraMessageBox . Show ( "无数据" );
                else if ( resu == 1 )
                {
                    XtraMessageBox . Show ( "生成成功" );
                    Query ( );
                }
                else
                    XtraMessageBox . Show ( "生成失败" );
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
                QueryTool ( );
                gridView1 . OptionsBehavior . Editable = false;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }
        private void gridControl1_KeyPress ( object sender ,System . Windows . Forms . KeyPressEventArgs e )
        {
            //if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
            //    return ;
            //if ( e . KeyChar == 13 )
            //{
            //    DataRow row = gridView1 . GetFocusedDataRow ( );
            //    if ( row != null )
            //    {
            //        _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
            //        if ( _model . idx > 0 && !intList . Contains ( _model . idx ) )
            //            intList . Add ( _model . idx );
            //    }

            //    tableView . Rows . Remove ( row );
            //    gridControl1 . Refresh ( );
            //}
        }
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        //Delete
        private void btnDelete_Click ( object sender ,EventArgs e )
        {
            if ( selectIdx == 0 )
            {
                XtraMessageBox . Show ( "请选择需要删除的内容" );
                return;
            }
            strWhere = "1=1";
            strWhere += " AND idx=" + selectIdx + "";
            result = _bll . Delete ( strWhere );
            if ( result )
            {
                XtraMessageBox . Show ( "删除成功" );
                tableView . Rows . Remove ( row );
                gridControl1 . RefreshDataSource ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );
        }
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            selectIdx = 0;
            row = gridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            selectIdx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
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