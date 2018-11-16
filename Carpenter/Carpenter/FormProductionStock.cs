using CarpenterBll;
using DevExpress . XtraEditors;
using DevExpress . XtraGrid . Views . Grid . ViewInfo;
using System;
using System . Collections . Generic;
using System . Data;
using System . Drawing;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormProductionStock :FormChild
    {
        DataTable tableQuery,BLTable,tablePlan;
        CarpenterBll.Bll.ProductionStockBll _bll=null;
        ControlUser . DLPlanDayPort plan =null;
        bool isOk =false; int num=0,checkAll=0;string strWhere="1=1";
        
        public FormProductionStock ( )
        {
            InitializeComponent ( );
            
            _bll = new CarpenterBll . Bll . ProductionStockBll ( );
            plan = new ControlUser . DLPlanDayPort ( );
            splitContainerControl1 . Panel2 . Controls . Add ( plan );
            plan . Dock = System . Windows . Forms . DockStyle . Fill;

            tablePlan = null;

            Utility . GridViewMoHuSelect . SetFilter ( bandedGridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] {  toolPrint ,toolCancellation ,toolExamin ,toolReview  ,toolAdd } );


            splitContainerControl1 . Panel1 . Enabled = false;
            bandedGridView1 . OptionsBehavior . Editable = false;
            wait . Hide ( );

            lupProduct . Properties . DataSource = _bll . GetOnly ( "PST001" );
            lupProduct . Properties . DisplayMember = "PST001";
            luporcu . Properties . DataSource = _bll . GetOnly ( "PST002 OPI001,PST003 OPI002" );
            luporcu . Properties . DisplayMember = "OPI002";
            lupColor . Properties . DataSource = _bll . GetColor ( );
            lupColor . Properties . DisplayMember = "OPI006";

            foreach ( var item in ColumnValues . bl )
            {
                cmbWorkShop . Properties . Items . Add ( item );
            }
            foreach ( var item in ColumnValues . jjg )
            {
                cmbWorkShop . Properties . Items . Add ( item );
            }
        }
        
        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;

            selectTable ( );
            strWhere += " AND (PST033 IS NULL OR PST033='' OR PST033='0')";

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Edit ( )
        {
            editTool ( );
            bandedGridView1 . OptionsBehavior . Editable = true;
            splitContainerControl1 . Panel1 . Enabled = false;

            return base . Edit ( );
        }
        protected override int Save ( )
        {
            bandedGridView1 . CloseEditor ( );
            bandedGridView1 . UpdateCurrentRow ( );

            wait . Show ( );
            backgroundWorker2 . RunWorkerAsync ( );

            return base . Save ( );
        }
        protected override int Cancel ( )
        {
            cancelTool ( "edit" );
            bandedGridView1 . OptionsBehavior . Editable = false;

            return base . Cancel ( );
        }
        protected override int Delete ( )
        {
            List<string> idxList = new List<string> ( );
            DataRow row = null;
            for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
            {
                row = bandedGridView1 . GetDataRow ( i );
                if ( row [ "check" ] . ToString ( ) == "True" )
                    idxList . Add ( row [ "idx" ] . ToString ( ) );
            }

            if ( idxList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要删除的内容" );
                return 0;
            }
            if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            if ( _bll . ExistsBLW ( idxList ) )
            {
                XtraMessageBox . Show ( "备料周计划存在选中的记录,不允许删除" );
                return 0;
            }
            if ( _bll . ExistsBLD ( idxList ) )
            {
                XtraMessageBox . Show ( "备料日计划存在选中的记录,不允许删除" );
                return 0;
            }
            if ( _bll . ExistsJD ( idxList ) )
            {
                XtraMessageBox . Show ( "机加工周计划存在选中的记录,不允许删除" );
                return 0;
            }
            if ( _bll . ExistsJW ( idxList ) )
            {
                XtraMessageBox . Show ( "机加工日计划存在选中的记录,不允许删除" );
                return 0;
            }

            bool result = _bll . Delete ( idxList );
            if ( result )
            {
                XtraMessageBox . Show ( "成功删除" );
                Query ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        protected override int Export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            return base . Export ( );
        }
        #endregion

        #region Event
        private void bandedGridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
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

                tableQuery . Columns . Add ( "check" ,typeof ( System . Boolean ) );
                gridControl1 . DataSource = tableQuery;
                splitContainerControl1 . Panel1 . Enabled = true;
                bandedGridView1 . OptionsBehavior . Editable = false;

                QueryTool ( );
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }
        private void backgroundWorker2_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            isOk = _bll . Edit ( tableQuery ,UserLogin . userName );       
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );

                if ( isOk == true )
                {
                    XtraMessageBox . Show ( "保存成功" );
                    saveTool ( );

                    splitContainerControl1 . Panel1 . Enabled = true;
                    bandedGridView1 . OptionsBehavior . Editable = false;
                }
                else
                    XtraMessageBox . Show ( "保存失败" );
            }
        }
        private void bandedGridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            int num = bandedGridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= bandedGridView1 . DataRowCount - 1 )
            {
                if ( bandedGridView1 . GetDataRow ( num ) [ "check" ] . ToString ( ) == "True" )
                    bandedGridView1 . GetDataRow ( num ) [ "check" ] = false;
                else
                    bandedGridView1 . GetDataRow ( num ) [ "check" ] = true;
            }
        }
        private void gridControl1_DoubleClick ( object sender ,EventArgs e )
        {
            Point pt = gridControl1 . PointToClient ( Control . MousePosition );
            GridHitInfo info = bandedGridView1 . CalcHitInfo ( pt );
            if ( info . Column == null )
                return;
            if ( !info . InRowCell && info . Column . AbsoluteIndex == 1 )
            {
                if ( checkAll == 0 )
                {
                    CheckAll ( sender ,e );
                }
                else if ( checkAll == 1 )
                {
                    UnCheckAll ( sender ,e );
                }
            }
        }
        private void CheckAll ( object sender ,EventArgs e )
        {
            int columnCount = bandedGridView1 . DataRowCount;
            for ( int i = 0 ; i < columnCount ; i++ )
            {
                bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "check" ] ,true );
            }
            gridControl1 . Refresh ( );
            checkAll = 1;
        }
        private void UnCheckAll ( object sender ,EventArgs e )
        {
            int columnCount = bandedGridView1 . DataRowCount;
            for ( int i = 0 ; i < columnCount ; i++ )
            {
                bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "check" ] ,false );
            }
            gridControl1 . Refresh ( );
            checkAll = 0;
        }
        private void bandedGridView1_CustomDrawCell ( object sender ,DevExpress . XtraGrid . Views . Base . RowCellCustomDrawEventArgs e )
        {
            //if ( e . RowHandle >= 0 && e . RowHandle <= bandedGridView1 . DataRowCount - 1 )
            //{
            //    DevExpress . Utils . AppearanceDefault appRed = new DevExpress . Utils . AppearanceDefault
            //            ( Color . Black ,Color . Red ,Color . Empty ,Color . SeaShell ,System . Drawing . Drawing2D . LinearGradientMode . Horizontal );
            //    if ( e . Column . FieldName == "PST001" || e . Column . FieldName == "PST002" || e . Column . FieldName == "PST003" )
            //    {
            //        bool yesOrNo = Convert . ToBoolean ( bandedGridView1 . GetDataRow ( e . RowHandle ) [ "PST030" ] . ToString ( ) );
            //        if ( yesOrNo )
            //        {
            //            DevExpress . Utils . AppearanceHelper . Apply ( e . Appearance ,appRed );
            //        }
            //    }
            //}
        }
        private void bandedGridView1_RowStyle ( object sender ,DevExpress . XtraGrid . Views . Grid . RowStyleEventArgs e )
        {
            if ( e . RowHandle >= 0 && e . RowHandle <= bandedGridView1 . DataRowCount - 1 )
            {
                bool yesOrNo = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( e . RowHandle ) [ "PST030" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( bandedGridView1 . GetDataRow ( e . RowHandle ) [ "PST030" ] . ToString ( ) );
                if ( yesOrNo )
                {
                    e . Appearance . BackColor = Color . Pink;
                }
            }
        }       
        //显示子表
        private void bandedGridView1_RowCellClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowCellClickEventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            //num = bandedGridView1 . FocusedRowHandle;
            //if ( num < 0 || num > bandedGridView1 . DataRowCount - 1 )
            //    return;
            if ( row == null )
                return;

            CarpenterEntity . ProductionStockEntity _model = new CarpenterEntity . ProductionStockEntity ( );
            _model . PST001 = row [ "PST001" ] . ToString ( );
            _model . PST002 = row [ "PST002" ] . ToString ( );

            tablePlan = null;

            if ( e . Column . FieldName == "PST029" )
            {
                tablePlan = _bll . GetDataTableBL ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . bl_dl );
            }
            else if ( e . Column . FieldName == "PST007" )
            {
                tablePlan = _bll . GetDataTableBL ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . bl_xb );
            }
            else if ( e . Column . FieldName == "PST009" )
            {
                tablePlan = _bll . GetDataTableBL ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . bl_cj );
            }
            else if ( e . Column . FieldName == "PST011" )
            {
                tablePlan = _bll . GetDataTableBL ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . bl_pb );
            }
            else if ( e . Column . FieldName == "PST013" )
            {
                tablePlan = _bll . GetDataTableBL ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . bl_pc );
            }
            else if ( e . Column . FieldName == "PST006" )
            {
                tablePlan = _bll . getDataTableBL ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . bl_dl );
            }
            else if ( e . Column . FieldName == "PST008" )
            {
                tablePlan = _bll . getDataTableBL ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . bl_xb );
            }
            else if ( e . Column . FieldName == "PST010" )
            {
                tablePlan = _bll . getDataTableBL ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . bl_cj );
            }
            else if ( e . Column . FieldName == "PST012" )
            {
                tablePlan = _bll . getDataTableBL ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . bl_pb );
            }
            else if ( e . Column . FieldName == "PST014" )
            {
                tablePlan = _bll . getDataTableBL ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . bl_pc );
            }
            else if ( e . Column . FieldName == "PST017" )
            {
                tablePlan = _bll . GetDataTableJ ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . jjg_jgzx );
            }
            else if ( e . Column . FieldName == "PST021" )
            {
                tablePlan = _bll . GetDataTableJ ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . jjg_dy );
            }
            else if ( e . Column . FieldName == "PST019" )
            {
                tablePlan = _bll . GetDataTableJ ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . jjg_kszk );
            }
            else if ( e . Column . FieldName == "PST018" )
            {
                tablePlan = _bll . getDataTableJ ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . jjg_jgzx );
            }
            else if ( e . Column . FieldName == "PST020" )
            {
                tablePlan = _bll . getDataTableJ ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . jjg_kszk );
            }
            else if ( e . Column . FieldName == "PST022" )
            {
                tablePlan = _bll . getDataTableJ ( _model . PST001 ,_model . PST002 ,CarpenterBll . ColumnValues . jjg_dy );
            }

            if ( tablePlan != null )
                plan . gridControl1 . DataSource = tablePlan;
        }
        #endregion
        
        #region Click
        List<string> intList=new List<string>();
        //备料周计划
        private void btnObtain_Click ( object sender ,EventArgs e )
        {
            if ( intList != null )
                intList . Clear ( );

            getList_bl_week ( );

            if (intList==null || intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要排计划的产品" );
                return;
            }
            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "备料生产周计划" ,"BLWeeklyPlan" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterEntity . PlanStockPLSEntity _model = from . GetPLS;
                if ( string . IsNullOrEmpty ( _model . PLS002 ) )
                {
                    XtraMessageBox . Show ( "请填写周次" );
                    return;
                }
                CarpenterBll . UserInformation . TypeOfOper = "备料周计划";
                int resu = _bll . Exists ( _model . PLS002 ,_model . PLS008 ,intList );
                if ( resu == 2 )
                {
                    XtraMessageBox . Show ( "本年已经存在周次:" + _model . PLS002 + ",且已注销,不允许生成" );
                    return;
                }
                if ( resu == 3 )
                {
                    XtraMessageBox . Show ( "本年已经存在周次:" + _model . PLS002 + ",且已审核,不允许生成" );
                    return;
                }
                if ( resu == 4 )
                {
                    XtraMessageBox . Show ( "选择产品已经全部排产,不允许预排" );
                    return;
                }
                if ( resu == 6 )
                {
                    XtraMessageBox . Show ( "选择产品已经全部排产或全部预排报工,不允许排产" );
                    return;
                }
                if ( resu == 1 )
                {
                    //if ( XtraMessageBox . Show ( "本年已经存在周次:" + _model . PLS002 + ",是否覆盖?" ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    //    return;
                    isOk = _bll . Edit_BL ( _model ,intList ,UserLogin . userName ,_model . PLS008 );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "生成备料周计划成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "生成备料周计划失败" );
                }
                else if(resu==5)
                {
                    isOk = _bll . Add_BL ( _model ,intList ,UserLogin . userName ,_model . PLS008 );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "生成备料周计划成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "生成备料周计划失败" );
                }
            }
        }
        //备料周计划报工
        private void btnObtainbg_Click ( object sender ,EventArgs e )
        {
            if ( intList != null )
                intList . Clear ( );
            getList ( );

            if (intList==null || intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }

            CarpenterBll . Bll . PlanStockDailyWeekBll bll = new CarpenterBll . Bll . PlanStockDailyWeekBll ( );

            int proArr = bll . ExistsProductAttr ( intList );

            //按计划报工
            if ( proArr == 0 || proArr == 1 )
            {
                BLTable = bll . GetDataTablePlanWeek ( intList );
                CarpenterBll . ColumnValues . pro_cg = "常规";
            }
            //按非计划报工
            else if ( proArr == 2 || proArr == 4 )
            {
                BLTable = bll . GetDataTablePlanWeekOther ( intList );
                CarpenterBll . ColumnValues . pro_cg = "其它";
            }
            else if ( proArr == 3 )
            {
                XtraMessageBox . Show ( "您选择的产品属性包括常规和其他类型,不允许报工,请选择单一属性的产品" );
                return;
            }
            
            Carpenter . Query . FormWeekDailyWork from = new Carpenter . Query . FormWeekDailyWork ( "备料周计划报工"  ,BLTable );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterBll . UserInformation . TypeOfOper = "备料周计划报工";
                DataTable dt = from . GetTable;
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    isOk = _bll . BLDailyWeek ( dt ,UserLogin . userName ,false );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "备料报工成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "备料报工失败" );
                }
            }

        }
        //备料周计划预排报工
        private void btnBLbgWeek_Click ( object sender ,EventArgs e )
        {
            if ( intList != null )
                intList . Clear ( );
            getList ( );

            if (intList==null || intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }
            CarpenterBll . Bll . PlanStockDailyWeekBll bll = new CarpenterBll . Bll . PlanStockDailyWeekBll ( );
            intList = bll . idxList ( intList );
            if ( intList == null || intList . Count < 1 )
            {
                XtraMessageBox . Show ( "所选产品已排正式计划，不允许报工" );
                intList = new List<string> ( );
                return;
            }
            BLTable = bll . GetDataTablePlanWeekDaily ( intList );
            Carpenter . Query . FormWeekDailyWork from = new Carpenter . Query . FormWeekDailyWork ( "备料周计划预排报工" ,BLTable );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterBll . UserInformation . TypeOfOper = "备料周计划预排报工";
                DataTable dt = from . GetTable;
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    isOk = _bll . BLDailyWeek ( dt ,UserLogin . userName ,true );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "备料报工成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "备料报工失败" );
                }
            }
        }
        //备料日计划
        private void btnBLr_Click ( object sender ,EventArgs e )
        {
            if ( intList != null )
                intList . Clear ( );
            getList_bl_day ( );

            if ( intList==null || intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要排计划的产品" );
                return;
            }

            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "备料生产日计划" ,"BLDayPlan" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterEntity . PlanStockWorkPSWEntity _model = from . getDayBL;
                if ( string . IsNullOrEmpty ( _model . PSW002 ) )
                {
                    XtraMessageBox . Show ( "请选择工段" );
                    return;
                }
                CarpenterBll . UserInformation . TypeOfOper = "备料日计划";
                _model . PSW008 = UserLogin . userName;
               
                int resu = _bll . Exists_Day ( _model . PSW002 ,_model . PSW003 ,intList ,_model . PSW005 );
                if ( resu . Equals ( 2 ) )
                {
                    XtraMessageBox . Show ( "工段:" + _model . PSW002 + "\n\r计划日期:" + _model . PSW003 . ToString ( "yyyy-MM-dd" ) + "\n\r的日计划已经注销,不允许生成" );
                    return;
                }
                if ( resu . Equals ( 3 ) )
                {
                    XtraMessageBox . Show ( "工段:" + _model . PSW002 + "\n\r计划日期:" + _model . PSW003 . ToString ( "yyyy-MM-dd" ) + "\n\r的日计划已经审核,不允许生成" );
                    return;
                }
                if ( resu . Equals ( 4 ) )
                {
                    XtraMessageBox . Show ( "选择产品已经全部生成日计划,不允许预排" );
                    return;
                }
                if ( resu . Equals ( 6 ) )
                {
                    XtraMessageBox . Show ( "选择产品已经全部生成日计划,且最后一次排产完工状态为完工,不允许排产" );
                    return;
                }
                if ( resu . Equals ( 7 ) )
                {
                    XtraMessageBox . Show ( "选择产品已经全部预排,不允许排产" );
                    return;
                }
                if ( resu . Equals ( 1 )  )
                {
                    num = _bll . Esit_BL_Day ( _model ,intList ,_model . PSW005 );
                    if ( num . Equals ( 1 ) )
                        XtraMessageBox . Show ( "覆盖错误,请核实" );
                    else if ( num . Equals ( 2 ) )
                        XtraMessageBox . Show ( "选择产品所在工段已经存在日计划,不允许重复生成" );
                    else if ( num . Equals ( 3 ) )
                        XtraMessageBox . Show ( "生成成功" );
                    else
                        XtraMessageBox . Show ( "生成失败" );
                }
                else if ( resu . Equals ( 5 ) )
                {
                    isOk = _bll . Add_BL_Day ( _model ,intList ,_model . PSW005 );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "生成日计划成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "生成日计划失败" );
                }
            }
        }
        //备料报工
        private void btnBLbg_Click ( object sender ,EventArgs e )
        {
            if ( intList != null )
                intList . Clear ( );
            getList ( );
            if ( intList == null || intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }

            //CarpenterBll . Bll . PlanStockDailyWorkBll bll = new CarpenterBll . Bll . PlanStockDailyWorkBll ( );
            //BLTable = bll . GetDataTable ( intList );
            CarpenterBll . Bll . PlanStockDailyWeekBll bll = new CarpenterBll . Bll . PlanStockDailyWeekBll ( );
            int proArr = bll . ExistsProductAttr ( intList );

            //按计划报工
            if ( proArr == 0 || proArr == 1 )
            {
                CarpenterBll . ColumnValues . pro_cg = "常规";
            }
            //按非计划报工
            else if ( proArr == 2 || proArr == 4 )
            {
                CarpenterBll . ColumnValues . pro_cg = "其它";
            }
            else if ( proArr == 3 )
            {
                XtraMessageBox . Show ( "您选择的产品属性包括常规和其他类型,不允许报工,请选择单一属性的产品" );
                return;
            }

            CarpenterBll . UserInformation . TypeOfOper = "备料日计划报工";
            BLTable = null;
            BLbg ( false );
        }
        //备料日计划预排报工
        private void btnBLbgPlan_Click ( object sender ,EventArgs e )
        {
            if ( intList != null )
                intList . Clear ( );
            getList ( );
            if ( intList == null || intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }

            //CarpenterBll . Bll . PlanStockDailyWorkBll bll = new CarpenterBll . Bll . PlanStockDailyWorkBll ( );
            //BLTable = bll . GetDataTablePlan ( intList );
            CarpenterBll . UserInformation . TypeOfOper = "备料日计划预排报工";
            BLTable = null;
            BLbg ( true );
        }
        //机加工周计划
        private void btnWeekJ_Click ( object sender ,EventArgs e )
        {
            if ( intList != null )
                intList . Clear ( );

            getList_j_week ( );

            if ( intList == null || intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要排计划的产品" );
                return;
            }

            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "机加工生产周计划" ,"BLWeeklyPlan" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterEntity . PlanStockPLSEntity _model = from . GetPLS;
                CarpenterEntity . PlanMachinPMCEntity entity = new CarpenterEntity . PlanMachinPMCEntity ( );
                entity . PMC003 = _model . PLS003;
                entity . PMC004 = _model . PLS004;
                entity . PMC005 = _model . PLS005;
                entity . PMC009 = _model . PLS002;
                entity . PMC008 = _model . PLS008;
                if ( string . IsNullOrEmpty ( entity . PMC009 ) )
                {
                    XtraMessageBox . Show ( "请填写周次" );
                    return;
                }
                CarpenterBll . UserInformation . TypeOfOper = "机加工周计划";
                int resu = _bll . Exists_Machine ( entity . PMC009 ,entity . PMC008 ,intList );
                if ( resu == 2 )
                {
                    XtraMessageBox . Show ( "本年已经存在周次:" + entity . PMC009 + ",且已注销,不允许生成" );
                    return;
                }
                if ( resu == 3 )
                {
                    XtraMessageBox . Show ( "本年已经存在周次:" + entity . PMC009 + ",且已审核,不允许生成" );
                    return;
                }
                if ( resu == 4 )
                {
                    XtraMessageBox . Show ( "选择产品已经全部排产,不允许预排" );
                    return;
                }
                if ( resu == 6 )
                {
                    XtraMessageBox . Show ( "选择产品已经全部排产,不允许排产" );
                    return;
                }
                if ( resu == 1 )
                {
                    //if ( XtraMessageBox . Show ( "本年已经存在周次:" + entity . PMC009 + ",是否覆盖?" ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    //    return;
                    isOk = _bll . Edit_BL_Machine ( entity ,intList ,entity . PMC008 );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "生成机加工周计划成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "生成机加工周计划失败" );
                }
                else if ( resu == 5 )
                {
                    isOk = _bll . Add_BL_Machine ( entity ,intList ,entity . PMC008 );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "生成机加工周计划成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "生成机加工周计划失败" );
                }
            }
        }
        //机加工周计划报工
        private void btnWeekDailyJ_Click ( object sender ,EventArgs e )
        {
            if ( intList != null )
                intList . Clear ( );
            getList ( );

            if ( intList == null || intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }
            
            CarpenterBll . Bll . PlanMachinWeekDailyWorkBll bll = new CarpenterBll . Bll . PlanMachinWeekDailyWorkBll ( );

            int proArr = bll . ExistsProductAttr ( intList );
            //按计划报工
            if ( proArr == 0 || proArr == 1 )
            {
                BLTable = bll . GetDataTablePlanWeekJ ( intList );
                CarpenterBll . ColumnValues . pro_cg = "常规";
            }
            //按非计划报工
            else if ( proArr == 2 || proArr == 4 )
            {
                BLTable = bll . GetDataTablePlanWeekJOther ( intList );
                CarpenterBll . ColumnValues . pro_cg = "其它";
            }
            else if ( proArr == 3 )
            {
                XtraMessageBox . Show ( "您选择的产品属性包括常规和其他类型,不允许报工,请选择单一属性的产品" );
                return;
            }

            Carpenter . Query . FormWeekDailyWork from = new Carpenter . Query . FormWeekDailyWork ( "机加工周计划报工" ,BLTable );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterBll . UserInformation . TypeOfOper = "机加工周计划报工";
                DataTable dt = from . GetTableJ;
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    isOk = _bll . JDailyWeek ( dt  ,false );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "机加工报工成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "机加工报工失败" );
                }
            }
        }
        //机加工周计划预排报工
        private void btnWeekDailyPlanJ_Click ( object sender ,EventArgs e )
        {
            if ( intList != null )
                intList . Clear ( );
            getList ( );

            if ( intList == null || intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }

            CarpenterBll . Bll . PlanMachinWeekDailyWorkBll bll = new CarpenterBll . Bll . PlanMachinWeekDailyWorkBll ( );
            intList = bll . idxList ( intList );
            if ( intList == null || intList . Count < 1 )
            {
                XtraMessageBox . Show ( "所选产品已排正式计划，不允许报工" );
                intList = new List<string> ( );
                return;
            }
            BLTable = bll . GetDataTablePlanWeekDailyJ ( intList );
            Carpenter . Query . FormWeekDailyWork from = new Carpenter . Query . FormWeekDailyWork ( "机加工周计划预排报工" ,BLTable );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterBll . UserInformation . TypeOfOper = "机加工周计划预排报工";
                DataTable dt = from . GetTableJ;
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    isOk = _bll . JDailyWeek ( dt ,true );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "机加工报工成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "机加工报工失败" );
                }
            }
        }
        //机加工日计划
        private void btnDayJ_Click ( object sender ,EventArgs e )
        {
            if ( intList != null )
                intList . Clear ( );
            getList_j_day ( );

            if ( intList == null || intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要排计划的产品" );
                return;
            }

            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "机加工生产日计划" ,"JDayPlan" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterEntity . PlanMachinWorkPMWEntity _model = from . getDayJ;
                if ( string . IsNullOrEmpty ( _model . PMW002 ) )
                {
                    XtraMessageBox . Show ( "请选择工段" );
                    return;
                }
                CarpenterBll . UserInformation . TypeOfOper = "机加工日计划";
               
                int resu = _bll . Exists_Day_Machine ( _model . PMW002 ,_model . PMW003 ,intList ,_model . PMW005 );
                if ( resu . Equals ( 2 ) )
                {
                    XtraMessageBox . Show ( "工段:" + _model . PMW002 + "\n\r计划日期:" + _model . PMW003 . ToString ( "yyyy-MM-dd" ) + "\n\r的日计划已经注销,不允许生成" );
                    return;
                }
                if ( resu . Equals ( 3 ) )
                {
                    XtraMessageBox . Show ( "工段:" + _model . PMW002 + "\n\r计划日期:" + _model . PMW003 . ToString ( "yyyy-MM-dd" ) + "\n\r的日计划已经审核,不允许生成" );
                    return;
                }
                if ( resu . Equals ( 4 ) )
                {
                    XtraMessageBox . Show ( "选择产品已经全部生成日计划,不允许预排" );
                    return;
                }
                if ( resu . Equals ( 6 ) )
                {
                    XtraMessageBox . Show ( "选择产品已经全部生成日计划,且最后一次排产完工状态为完工,不允许排产" );
                    return;
                }
                if ( resu . Equals ( 7 ) )
                {
                    XtraMessageBox . Show ( "选择产品已经全部预排,不允许排产" );
                    return;
                }
                if ( resu . Equals ( 1 ) )
                {
                    num = _bll . Esit_J_Day ( _model ,intList ,_model . PMW005 );
                    if ( num . Equals ( 1 ) )
                        XtraMessageBox . Show ( "覆盖错误,请核实" );
                    else if ( num . Equals ( 2 ) )
                        XtraMessageBox . Show ( "选择产品所在工段已经存在日计划,不允许重复生成" );
                    else if ( num . Equals ( 3 ) )
                        XtraMessageBox . Show ( "生成成功" );
                    else
                        XtraMessageBox . Show ( "生成失败" );
                }
                else if ( resu . Equals ( 5 ) )
                {
                    isOk = _bll . Add_J_Day ( _model ,intList ,_model . PMW005 );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "生成日计划成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "生成日计划失败" );
                }
            }
        }
        //机加工日计划报工
        private void btnDayDailyJ_Click ( object sender ,EventArgs e )
        {
            if ( intList != null )
                intList . Clear ( );
            getList ( );
            if ( intList == null || intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }

            //CarpenterBll . Bll . PlanMachinDayDailyWorkBll bll = new CarpenterBll . Bll . PlanMachinDayDailyWorkBll ( );
            //BLTable = bll . GetDataTable ( intList );
            CarpenterBll . Bll . PlanMachinWeekDailyWorkBll bll = new CarpenterBll . Bll . PlanMachinWeekDailyWorkBll ( );
            int proArr = bll . ExistsProductAttr ( intList );
            //按计划报工
            if ( proArr == 0 || proArr == 1 )
            {
                CarpenterBll . ColumnValues . pro_cg = "常规";
            }
            //按非计划报工
            else if ( proArr == 2 || proArr == 4 )
            {
                CarpenterBll . ColumnValues . pro_cg = "其它";
            }
            else if ( proArr == 3 )
            {
                XtraMessageBox . Show ( "您选择的产品属性包括常规和其他类型,不允许报工,请选择单一属性的产品" );
                return;
            }


            CarpenterBll . UserInformation . TypeOfOper = "机加工日计划报工";
            BLTable = null;
            Jbg ( false );
        }
        //机加工日计划预排报工
        private void btnDayDailyPlanJ_Click ( object sender ,EventArgs e )
        {
            if ( intList != null )
                intList . Clear ( );
            getList ( );
            if ( intList == null || intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }

            //CarpenterBll . Bll . PlanMachinDayDailyWorkBll bll = new CarpenterBll . Bll . PlanMachinDayDailyWorkBll ( );
            //BLTable = bll . GetDataTablePlan ( intList );
            CarpenterBll . UserInformation . TypeOfOper = "机加工日计划预排报工";
            BLTable = null;
            Jbg ( true );
        }
        //隐藏显示
        private void contextMenuStrip1_ItemClicked ( object sender ,ToolStripItemClickedEventArgs e )
        {
            //备料信息
            if ( (e . ClickedItem) . Name ==  "MenuItemOne" )
            {
                gridBand8 . Visible = gridBand9 . Visible = gridBand10 . Visible = gridBand11 . Visible = false;
                gridBand2 . Visible = gridBand3 . Visible = gridBand4 . Visible = gridBand5 . Visible = gridBand6 . Visible = gridBand7 . Visible = true;
            }

            //机加工信息
            if ( ( e . ClickedItem ) . Name == "MenuItemTwo" )
            {
                gridBand8 . Visible = gridBand9 . Visible = gridBand10 . Visible = gridBand11 . Visible = true;
                gridBand2 . Visible = gridBand3 . Visible = gridBand4 . Visible = gridBand5 . Visible = gridBand6 . Visible = gridBand7 . Visible = false;
            }
        }
        private void btnCl_Click ( object sender ,EventArgs e )
        {
            lupColor . EditValue = luporcu . EditValue = lupProduct . EditValue = null;
            dtStart . Text = dtEnd . Text = string . Empty;
        }
        private void btnQueryAll_Click ( object sender ,EventArgs e )
        {
            selectTable ( );
            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );
        }
        #endregion

        #region Method
        void getList_bl_week ( )
        {
            intList . Clear ( );
            for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
            {
                if ( bandedGridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
                {
                    //if ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "PST015" ] . ToString ( ) ) )
                    //{
                        if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                        {
                            if ( intList != null && !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                                intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                        }
                    //}
                    //else
                    //    bandedGridView1 . GetDataRow ( i ) [ "check" ] = false;
                }
            }
        }
        void getList_bl_day ( )
        {
            intList . Clear ( );
            string dl = string . Empty, xb = string . Empty, cj = string . Empty, pb = string . Empty, pc = string . Empty;
            for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
            {
                if ( bandedGridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
                {
                    //dl = bandedGridView1 . GetDataRow ( i ) [ "PST029" ] . ToString ( );
                    //if ( string . IsNullOrEmpty ( dl ) )
                    //{
                    //    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //    {
                    //        if ( !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //            intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                    //    }
                    //}

                    //xb = bandedGridView1 . GetDataRow ( i ) [ "PST007" ] . ToString ( );
                    //if ( string . IsNullOrEmpty ( xb ) )
                    //{
                    //    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //    {
                    //        if ( !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //            intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                    //    }
                    //}

                    //cj = bandedGridView1 . GetDataRow ( i ) [ "PST009" ] . ToString ( );
                    //if ( string . IsNullOrEmpty ( cj ) )
                    //{
                    //    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //    {
                    //        if ( !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //            intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                    //    }
                    //}

                    //pb = bandedGridView1 . GetDataRow ( i ) [ "PST011" ] . ToString ( );
                    //if ( string . IsNullOrEmpty ( pb ) )
                    //{
                    //    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //    {
                    //        if ( !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //            intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                    //    }
                    //}

                    //pc = bandedGridView1 . GetDataRow ( i ) [ "PST013" ] . ToString ( );
                    //if ( string . IsNullOrEmpty ( pc ) )
                    //{
                    //    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //    {
                    //        if ( !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //            intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                    //    }
                    //}

                    //if ( !string . IsNullOrEmpty ( dl ) && !string . IsNullOrEmpty ( xb ) && !string . IsNullOrEmpty ( cj ) && !string . IsNullOrEmpty ( pb ) && !string . IsNullOrEmpty ( pc ) )
                    //    bandedGridView1 . GetDataRow ( i ) [ "idx" ] = false;

                    intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                }
            }
        }
        void getList ( )
        {
            if ( intList != null )
                intList . Clear ( );
            for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
            {
                if ( bandedGridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
                {
                    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    {
                        if (intList!=null && !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                            intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                    }
                }
            }
        }
        void getList_j_week ( )
        {
            if ( intList != null )
                intList . Clear ( );
            for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
            {
                if ( bandedGridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
                {
                    if ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "PST023" ] . ToString ( ) ) )
                    {
                        if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                        {
                            if ( intList != null && !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                                intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                        }
                    }
                    else
                        bandedGridView1 . GetDataRow ( i ) [ "check" ] = false;
                }
            }
        }
        void getList_j_day ( )
        {
            if ( intList != null )
                intList . Clear ( );

            string dl = string . Empty, xb = string . Empty, cj = string . Empty;
            for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
            {
                if ( bandedGridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
                {
                    intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                }
                //if ( bandedGridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
                //{
                    //dl = bandedGridView1 . GetDataRow ( i ) [ "PST017" ] . ToString ( );
                    //if ( string . IsNullOrEmpty ( dl ) )
                    //{
                    //    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //    {
                    //        if ( !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //            intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                    //    }
                    //}

                    //xb = bandedGridView1 . GetDataRow ( i ) [ "PST019" ] . ToString ( );
                    //if ( string . IsNullOrEmpty ( xb ) )
                    //{
                    //    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //    {
                    //        if ( !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //            intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                    //    }
                    //}

                    //cj = bandedGridView1 . GetDataRow ( i ) [ "PST021" ] . ToString ( );
                    //if ( string . IsNullOrEmpty ( cj ) )
                    //{
                    //    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //    {
                    //        if ( !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    //            intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                    //    }
                    //}

                    //if ( !string . IsNullOrEmpty ( dl ) && !string . IsNullOrEmpty ( xb ) && !string . IsNullOrEmpty ( cj ) )
                    //    bandedGridView1 . GetDataRow ( i ) [ "idx" ] = false;
                //}
            }
        }
        void BLbg ( bool plan )
        {
            string formText = string . Empty;
            if ( plan == false )
                formText = "备料日计划报工";
            else
                formText = "备料日计划计划报工";

            Carpenter . Query . FormControlOne from = new Carpenter . Query . FormControlOne ( formText ,"BLDailyWork" ,BLTable ,intList );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                DataTable dt = from . getDataDailyBL;
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    isOk = _bll . BLDailyWork ( dt ,UserLogin . userName,plan );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "备料报工成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "备料报工失败" );
                }
            }
        }
        void Jbg ( bool plan )
        {
            string formText = string . Empty;
            if ( plan == false )
                formText = "机加工日计划报工";
            else
                formText = "机加工日计划计划报工";
            Carpenter . Query . FormControlOne from = new Carpenter . Query . FormControlOne ( formText ,"JDailyWork" ,BLTable ,intList );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                DataTable dt = from . getDataDailyJ;
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    isOk = _bll . JDailyWork ( dt ,UserLogin . userName ,plan );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "机加工报工成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "机加工报工失败" );
                }
            }
        }
        void selectTable ( )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupProduct . Text ) )
                strWhere += " AND PST001='" + lupProduct . Text + "'";
            if ( !string . IsNullOrEmpty ( luporcu . Text ) )
                strWhere += " AND PST003='" + luporcu . Text + "'";
            if ( !string . IsNullOrEmpty ( lupColor . Text ) )
                strWhere += " AND OPI006='" + lupColor . Text + "'";
            if ( !string . IsNullOrEmpty ( cmbWorkShop . Text ) )
            {
                if ( cmbWorkShop . Text . Equals ( ColumnValues . bl_dl ) )
                {
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PST006>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PST006<='" + dtStart . Text + "'";
                }
                if ( cmbWorkShop . Text . Equals ( ColumnValues . bl_cj ) )
                {
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PST010>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PST010<='" + dtStart . Text + "'";
                }
                if ( cmbWorkShop . Text . Equals ( ColumnValues . bl_pb ) )
                {
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PST012>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PST012<='" + dtStart . Text + "'";
                }
                if ( cmbWorkShop . Text . Equals ( ColumnValues . bl_pc ) )
                {
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PST014>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PST014<='" + dtStart . Text + "'";
                }
                if ( cmbWorkShop . Text . Equals ( ColumnValues . bl_xb ) )
                {
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PST008>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PST008<='" + dtStart . Text + "'";
                }
                if ( cmbWorkShop . Text . Equals ( ColumnValues . jjg_dy ) )
                {
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PST022>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PST022<='" + dtStart . Text + "'";
                }
                if ( cmbWorkShop . Text . Equals ( ColumnValues . jjg_jgzx ) )
                {
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PST018>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PST018<='" + dtStart . Text + "'";
                }
                if ( cmbWorkShop . Text . Equals ( ColumnValues . jjg_kszk ) )
                {
                    if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                        strWhere += " AND PST020>='" + dtStart . Text + "'";
                    if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                        strWhere += " AND PST020<='" + dtStart . Text + "'";
                }
            }
        }
        #endregion

    }
}





/*
 --备料计划完成时间
--UPDATE MOXPRS SET PRS007=PLT007 FROM MOXPLT WHERE PRS001=PLT003 AND PRS002=PLT004 AND PLT013=0
--备料时间完成时间
--WITH CET AS(
--SELECT PDK002,PDK003,PDK012,SUM(PDK007)-PST028 PDK007 FROM MOXPST A INNER JOIN MOXPDK B ON A.PST001=B.PDK002 AND A.PST002=B.PDK003 WHERE PDK008=0 GROUP BY 

PDK002,PDK003,PDK012,PST028
--)
--UPDATE MOXPST SET PST016=PDK012 FROM CET WHERE PST001=PDK002 AND PST002=PDK003 AND PDK007=0
--机加工计划完成时间
--UPDATE MOXPRS SET PRS009=PMD008 FROM MOXPMD WHERE PRS001=PMD003 AND PRS002=PMD004  AND PMD010=0
--机加工实际完成时间
--WITH CET AS (
--SELECT PME002,PME003,PME012,SUM(PME007)-PST028 PME007 FROM MOXPST A INNER JOIN MOXPME B ON A.PST001=B.PME002 AND A.PST002=B.PME003 WHERE PME008=0
--GROUP BY PME002,PME003,PST028,PME012
--)
--UPDATE MOXPST SET PST024=PME012 FROM CET WHERE PST001=PME002 AND PST002=PME003 AND PME007=0 
     */
