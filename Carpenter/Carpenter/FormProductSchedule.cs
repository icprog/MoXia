
using CarpenterBll;
using DevExpress . XtraEditors;
using System;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormProductSchedule :FormChild
    {
        DataTable tableQuery,tablePlan;
        CarpenterBll.Bll.ProductScheduleBll _bll=null;
        ControlUser . ZPlanDayPort plan = new ControlUser . ZPlanDayPort ( );
        string strWhere="1=1";
        DataRow row;
        
        public FormProductSchedule ( )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . ProductScheduleBll ( );
            plan = new ControlUser . ZPlanDayPort ( );
            panelControl1 . Controls . Add ( plan );
            plan . Dock = System . Windows . Forms . DockStyle . Fill;

            Utility . GridViewMoHuSelect . SetFilter ( bandedGridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave ,toolCancellation ,toolExamin ,toolReview ,toolEdit ,toolAdd } );

            wait . Hide ( );

            lupProduct . Properties . DataSource = _bll . GetOnly ( "PRS001" );
            lupProduct . Properties . DisplayMember = "PRS001";
            luporcu . Properties . DataSource = _bll . GetOnly ( "PRS002 OPI001,PRS003 OPI002" );
            luporcu . Properties . DisplayMember = "OPI002";
            lupColor . Properties . DataSource = _bll . GetColor ( );
            lupColor . Properties . DisplayMember = "OPI006";


            cmbWorkShop . Properties . Items . Add ( "备料" );
            cmbWorkShop . Properties . Items . Add ( "机加工" );
            foreach ( var item in ColumnValues . yq )
            {
                cmbWorkShop . Properties . Items . Add ( item );
            }
            cmbWorkShop . Properties . Items . Add ( "组装" );
        }
        
        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;

            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupProduct . Text ) )
                strWhere += " AND PRS001='" + lupProduct . Text + "'";
            if ( !string . IsNullOrEmpty ( luporcu . Text ) )
                strWhere += " AND PRS003='" + luporcu . Text + "'";
            if ( !string . IsNullOrEmpty ( lupColor . Text ) )
                strWhere += " AND OPI006='" + lupColor . Text + "'";

            strWhere += " AND (PST033 IS NULL OR PST033='' OR PST033='0')";

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Delete ( )
        {
            if ( row == null )
            {
                XtraMessageBox . Show ( "请选择需要删除的内容" );
                return 0;
            }

            if ( _bll . Exists ( row [ "PRS001" ] . ToString ( ) ,row [ "PRS002" ] . ToString ( ) ) == false )
            {
                if ( XtraMessageBox . Show ( "部分工序已经排产且报工,是否删除?" ,"提示" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                    return 0;
            }

            bool result = _bll . Delete ( row );
            if ( result )
            {
                XtraMessageBox . Show ( "成功删除" );
                tableQuery . Rows . Remove ( row );
                gridControl1 . RefreshDataSource ( );
                row = null;
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            bandedGridView1 . OptionsBehavior . Editable = false;

            return base . Delete ( );
        }
        protected override int Export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            return base . Export ( );
        }
        #endregion

        #region Event
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            tableQuery = _bll . GetDataTable ( strWhere );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                toolQuery . Enabled = true;

                gridControl1 . DataSource = tableQuery;
                toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }
        private void bandedGridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void bandedGridView1_RowCellClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowCellClickEventArgs e )
        {
            //int num = bandedGridView1 . FocusedRowHandle;
            //if ( num < 0 || num > bandedGridView1 . DataRowCount - 1 )
            //    return;
            row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            CarpenterEntity . ProductScheduleEntity model = new CarpenterEntity . ProductScheduleEntity ( );
            model . PRS001 = row [ "PRS001" ] . ToString ( );
            model . PRS002 = row [ "PRS002" ] . ToString ( );

            decimal cou = string . IsNullOrEmpty ( row [ "COU" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "COU" ] . ToString ( ) );

            tablePlan = null;

            if ( e . Column . Name == "PRS007" )
                tablePlan = _bll . getTableBLPlan ( model . PRS001 ,model . PRS002 );
            else if ( e . Column . Name == "PST016" )
                tablePlan = _bll . getTableBLBG ( model . PRS001 ,model . PRS002 );
            else if ( e . Column . Name == "PRS009" )
                tablePlan = _bll . getTableJPlan ( model . PRS001 ,model . PRS002 );
            else if ( e . Column . Name == "PST024" )
                tablePlan = _bll . getTableJBG ( model . PRS001 ,model . PRS002 );
            else if ( e . Column . Name == "PAS007" )
                tablePlan = _bll . GetDataTableZ ( model . PRS001 ,model . PRS002 );
            else if ( e . Column . Name == "PAS011" || e . Column . Name == "PAS012" )
                tablePlan = _bll . GetDataTableZBG ( model . PRS001 ,model . PRS002 );
            else if ( e . Column . Name == "PDP009" || e . Column . Name == "PDP012" || e . Column . Name == "PDP015" || e . Column . Name == "PDP018" || e . Column . Name == "PDP022" )
                tablePlan = _bll . GetDataTable ( model . PRS001 ,model . PRS002 );
            else if ( e . Column . Name == "PDP010" || e . Column . Name == "PDP013" || e . Column . Name == "PDP016" || e . Column . Name == "PDP019" || e . Column . Name == "PDP023" )
                tablePlan = _bll . GetDataTablePaintBG ( model . PRS001 ,model . PRS002 );
            else if ( e . Column . Name == "COU" && cou != 0 )
            {
                FormProductScheduleTrackTable from = new FormProductScheduleTrackTable ( " AND PRD007='" + model . PRS001 + "' AND PRD008='" + model . PRS002 + "'" );
                from . ShowDialog ( );
            }

            if ( tablePlan != null )
                plan . gridControl1 . DataSource = tablePlan;
        }
        private void btnCl_Click ( object sender ,System . EventArgs e )
        {
            lupProduct . EditValue = luporcu . EditValue = lupColor . EditValue = null;
        }
        private void bandedGridView1_DoubleClick ( object sender ,EventArgs e )
        {
            row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            OrderEdit . FormProductScheduleDateEdit from = new OrderEdit . FormProductScheduleDateEdit ( row );
            from . StartPosition = FormStartPosition . CenterScreen;
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                strWhere = from . getDate;
                if ( strWhere == string . Empty )
                    row [ "PRS031" ] = DBNull . Value;
                else
                    row [ "PRS031" ] = strWhere;
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void btnQueryAll_Click ( object sender ,EventArgs e )
        {
            selectTable ( );
            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );
        }
        void selectTable ( )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupProduct . Text ) )
                strWhere += " AND PRS001='" + lupProduct . Text + "'";
            if ( !string . IsNullOrEmpty ( luporcu . Text ) )
                strWhere += " AND PRS002='" + luporcu . Text + "'";
            if ( !string . IsNullOrEmpty ( lupColor . Text ) )
                strWhere += " AND OPI006='" + lupColor . Text + "'";
            if ( !string . IsNullOrEmpty ( cmbWorkShop . Text ) )
            {
                switch ( cmbWorkShop . Text )
                {
                    case "备料":
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PST016>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PST016<='" + dtEnd . Text + "'";
                    break;
                    case "机加工":
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PST024>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PST024<='" + dtEnd . Text + "'";
                    break;
                    case "组装":
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PAS012>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PAS012<='" + dtEnd . Text + "'";
                    break;
                    case "底漆":
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PDP010>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PDP010<='" + dtEnd . Text + "'";
                    break;
                    case "油磨":
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PDP013>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PDP013<='" + dtEnd . Text + "'";
                    break;
                    case "修色":
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PDP016>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PDP016<='" + dtEnd . Text + "'";
                    break;
                    case "面漆":
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PDP019>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PDP019<='" + dtEnd . Text + "'";
                    break;
                    case "包装":
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PDP023>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PDP023<='" + dtEnd . Text + "'";
                    break;
                }
            }
        }
        #endregion

    }
}


/*
 备注：
 1、备料实际完成时间是备料周计划报工完成后回写
 2、机加工倒圆完成时间是机加工跟踪表读取
 3、
 4、
 5、
*/