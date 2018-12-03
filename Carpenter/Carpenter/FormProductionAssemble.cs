using DevExpress . XtraEditors;
using DevExpress . XtraGrid . Views . Grid . ViewInfo;
using System;
using System . Collections . Generic;
using System . Data;
using System . Drawing;
using System . Linq;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormProductionAssemble :FormChild
    {
        CarpenterEntity.ProductionAssembleEntity _model=null;
        CarpenterBll.Bll.ProductionAssembleBll _bll=null;
        ControlUser . ZPlanDayPort plan =null;
        ControlUser.AssembleWorkOrder order=null;
        bool isOk =false; int num=0,checkAll=0; string strWhere="1=1";
        DataTable tableView,ZTable,tablePlan,tableOrder;
        
        public FormProductionAssemble ( )
        {
            InitializeComponent ( );
            
            _model = new CarpenterEntity . ProductionAssembleEntity ( );
            _bll = new CarpenterBll . Bll . ProductionAssembleBll ( );
            tableView = new DataTable ( );
            ZTable = new DataTable ( );
            tablePlan = null;
            plan = new ControlUser . ZPlanDayPort ( );
            splitContainerControl1 . Panel2 . Controls . Add ( plan );
            plan . Dock = System . Windows . Forms . DockStyle . Fill;
            order = new ControlUser . AssembleWorkOrder ( );
            panelControl2 . Controls . Add ( order );
            order . Dock = System . Windows . Forms . DockStyle . Fill;

            Utility . GridViewMoHuSelect . SetFilter ( bandedGridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolPrint,toolCancellation ,toolExamin,toolReview ,toolAdd } );


            splitContainerControl1 . Panel1 . Enabled = false;
            bandedGridView1 . OptionsBehavior . Editable = false;
            wait . Hide ( );

            lupProduct . Properties . DataSource = _bll . GetOnly ( "PAS001" );
            lupProduct . Properties . DisplayMember = "PAS001";
            luporcu . Properties . DataSource = _bll . GetOnly ( "PAS002 OPI001,PAS003 OPI002" );
            luporcu . Properties . DisplayMember = "OPI002";
            lupColor . Properties . DataSource = _bll . GetColor ( );
            lupColor . Properties . DisplayMember = "OPI006";
        }
        
        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;

            selectTable ( );
            strWhere += " AND (PAS018 IS NULL OR PAS018='' OR PAS018='0')";

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
            if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            if ( idxList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要删除的内容" );
                return 0;
            }

            if ( _bll . ExistsZW ( idxList ) )
            {
                XtraMessageBox . Show ( "组装周计划中存在选中记录,不允许删除" );
                return 0;
            }
            if ( _bll . ExistsZD ( idxList ) )
            {
                XtraMessageBox . Show ( "组装日计划中存在选中记录,不允许删除" );
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
            tableView = _bll . GetTableView ( strWhere );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );

                toolQuery . Enabled = true;
                tableView . Columns . Add ( "check" ,typeof ( System . Boolean ) );
                gridControl1 . DataSource = tableView;
                splitContainerControl1 . Panel1 . Enabled = true;
                bandedGridView1 . OptionsBehavior . Editable = false;

                QueryTool ( );
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }
        private void backgroundWorker2_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            isOk = _bll . Save ( tableView );
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
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                if ( row [ "check" ] . ToString ( ) == "True" )
                    row [ "check" ] = false;
                else
                    row [ "check" ] = true;

                _model . PAS001 = row [ "PAS001" ] . ToString ( );
                _model . PAS002 = row [ "PAS002" ] . ToString ( );
                _model . PAS003 = row [ "PAS003" ] . ToString ( );

                tablePlan = _bll . GetDataTableZ ( _model . PAS001 ,_model . PAS002 );
                plan . gridControl1 . DataSource = tablePlan;

                tableOrder = _bll . GetTableOrder ( _model . PAS001 ,_model . PAS002 );
                order . gridControl1 . DataSource = tableOrder;

                if ( bandedGridView1 . FocusedColumn . FieldName == "PAS011" || bandedGridView1 . FocusedColumn . FieldName == "PAS012" )
                {
                    tablePlan = _bll . GetDataTableZB ( _model . PAS001 ,_model . PAS002 );
                    plan . gridControl1 . DataSource = tablePlan;
                }

            }
        }
        private void gridControl1_DoubleClick ( object sender ,System . EventArgs e )
        {
            Point pt = gridControl1 . PointToClient ( Control . MousePosition );
            GridHitInfo info = bandedGridView1 . CalcHitInfo ( pt );

            if ( !info . InRowCell && info.Column!=null && info . Column . AbsoluteIndex == 1 )
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
            //    if ( e . Column . FieldName == "PAS001" || e . Column . FieldName == "PAS002" || e . Column . FieldName == "PAS003" )
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
                bool yesOrNo = Convert . ToBoolean ( bandedGridView1 . GetDataRow ( e . RowHandle ) [ "PAS030" ] . ToString ( ) );
                if ( yesOrNo )
                {
                    e . Appearance . BackColor = Color . Pink;
                }
            }
        }
        #endregion
        
        #region Click
        List<string> intList=new List<string>();
        //组装周计划
        private void btnWeekPlan_Click ( object sender ,System . EventArgs e )
        {
            intList . Clear ( );
            getList_week ( );

            if ( intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要排计划的产品" );
                return;
            }
            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "组装生产周计划" ,"BLWeeklyPlan" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterEntity . PlanStockPLSEntity entity = from . GetPLS;
                CarpenterEntity . PlanAssembleWeekPLAEntity _model = new CarpenterEntity . PlanAssembleWeekPLAEntity ( );
                _model . PLA003 = entity . PLS003;
                _model . PLA004 = entity . PLS004;
                _model . PLA005 = entity . PLS005;
                _model . PLA009 = entity . PLS002;
                _model . PLA008 = entity . PLS008;
                if ( string . IsNullOrEmpty ( _model . PLA009 ) )
                {
                    XtraMessageBox . Show ( "请填写周次" );
                    return;
                }
                CarpenterBll . UserInformation . TypeOfOper = "组装周计划";
                int resu = _bll . Exists_Machine ( _model . PLA009 ,_model . PLA008 ,intList );
                if ( resu == 2 )
                {
                    XtraMessageBox . Show ( "本年已经存在周次:" + _model . PLA009 + ",且已注销,不允许生成" );
                    return;
                }
                if ( resu == 3 )
                {
                    XtraMessageBox . Show ( "本年已经存在周次:" + _model . PLA009 + ",且已审核,不允许生成" );
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
                    //if ( XtraMessageBox . Show ( "本年已经存在周次:" + _model . PLA009 + ",是否覆盖?" ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    //    return;
                    isOk = _bll . Edit_BL_Machine ( _model ,intList ,_model . PLA008 );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "生成组装周计划成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "生成组装周计划失败" );
                }
                else if ( resu == 5 )
                {
                    isOk = _bll . Add_BL_Machine ( _model ,intList ,_model . PLA008 );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "生成组装周计划成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "生成组装周计划失败" );
                }
            }

        }
        //组装周计划报工
        private void btnWeekDaily_Click ( object sender ,System . EventArgs e )
        {
            intList . Clear ( );
            getList ( );

            if ( intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }

            ZTable = _bll . GetDataTablePlanWeekJ ( intList );
            Carpenter . Query . FormWeekDailyWork from = new Carpenter . Query . FormWeekDailyWork ( "组装周计划报工" ,ZTable );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterBll . UserInformation . TypeOfOper = "组装周计划报工";
                DataTable dt = from . GetTableZ;
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    isOk = _bll . ZDailyWeek ( dt ,false );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "组装报工成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "组装报工失败" );
                }
            }

        }
        //组装周计划预排报工
        private void btnWeelDailyPlan_Click ( object sender ,System . EventArgs e )
        {
            intList . Clear ( );
            getList ( );

            if ( intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }

            ZTable = _bll . GetDataTablePlanWeekDailyJ ( intList );
            Carpenter . Query . FormWeekDailyWork from = new Carpenter . Query . FormWeekDailyWork ( "组装周计划预排报工" ,ZTable );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterBll . UserInformation . TypeOfOper = "组装周计划预排报工";
                DataTable dt = from . GetTableZ;
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    isOk = _bll . ZDailyWeek ( dt ,true );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "组装报工成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "组装报工失败" );
                }
            }
        }
        //组装日计划
        private void btnDayPlan_Click ( object sender ,System . EventArgs e )
        {
            intList . Clear ( );
            getList_j_day ( );

            if ( intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要排计划的产品" );
                return;
            }
            int proArr = _bll . ExistsProductAttr ( intList );
            if ( proArr == 2 || proArr == 4 || proArr == 3 )
            {
                XtraMessageBox . Show ( "您选择的产品属性包括定制,定制不允许排计划" );
                return;
            }
            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "组装生产日计划" ,"ZDayPlan" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterEntity . PlanAssembleDayPLDEntity _model = from . getPld;
                CarpenterBll . UserInformation . TypeOfOper = "组装日计划";
                int resu = _bll . Exists_Day_Assemeble ( _model . PLD002 ,_model . PLD003 ,intList ,_model . PLD005 );
                if ( resu . Equals ( 2 ) )
                {
                    XtraMessageBox . Show ( "工段:" + _model . PLD002 + "\n\r计划日期:" + _model . PLD003 . ToString ( "yyyy-MM-dd" ) + "\n\r的日计划已经注销,不允许生成" );
                    return;
                }
                if ( resu . Equals ( 3 ) )
                {
                    XtraMessageBox . Show ( "工段:" + _model . PLD002 + "\n\r计划日期:" + _model . PLD003 . ToString ( "yyyy-MM-dd" ) + "\n\r的日计划已经审核,不允许生成" );
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
                    num = _bll . Esit_J_Day ( _model ,intList ,_model . PLD005 );
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
                    isOk = _bll . Add_J_Day ( _model ,intList ,_model . PLD005 );
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
        //组装日计划报工
        private void btnDayDaily_Click ( object sender ,System . EventArgs e )
        {
            intList . Clear ( );
            getList ( );
            if ( intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }

            int proArr = _bll . ExistsProductAttr ( intList );
            //计划报工
            if ( proArr == 0 || proArr == 1 )
            {
                CarpenterBll . ColumnValues . pro_cg = "常规";
            }
            //非计划报工
            else if ( proArr == 2 || proArr == 4 )
            {
                CarpenterBll . ColumnValues . pro_cg = "其它";
            }
            else if ( proArr == 3 )
            {
                XtraMessageBox . Show ( "您选择的产品属性包括常规和其他类型,不允许报工,请选择单一属性的产品" );
                return;
            }

            CarpenterBll . UserInformation . TypeOfOper = "组装报工日计划";
            Zbg ( false );
        }
        //组装日计划预排报工
        private void btnDayDailyPlan_Click ( object sender ,System . EventArgs e )
        {
            intList . Clear ( );
            getList ( );
            if ( intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }
            CarpenterBll . UserInformation . TypeOfOper = "组装报工预排日计划";
            Zbg ( true );
        }
        //组装派工单
        private void btnWeekOrder_Click ( object sender ,System . EventArgs e )
        {
            //1、日计划有了才能有派工单
            intList . Clear ( );
            getPai ( );

            if ( intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要派工的产品" );
                return;
            }
            //if ( intList . Count > 1 )
            //{
            //    XtraMessageBox . Show ( "每次只能选择一个产品派工单" );
            //    return;
            //}
            CarpenterBll . UserInformation . TypeOfOper = "组装派工单";
            Carpenter . Query . FormWorkOrder from = new Carpenter . Query . FormWorkOrder ( intList );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                XtraMessageBox . Show ( "派工成功" );
            }
        }
        //组装派工报工
        private void btnDayDailyP_Click ( object sender ,EventArgs e )
        {
            intList . Clear ( );
            getList ( );
            if ( intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }
            ZTable = _bll . GetDataTable ( intList );
            if ( ZTable == null || ZTable . Rows . Count < 1 )
            {
                XtraMessageBox . Show ( "请重新选择,所选产品不符合报工条件" );
                return;
            }
            CarpenterBll . UserInformation . TypeOfOper = "组装日计划报工";
            Jbg ( false );
        }
        //组装派工预排报工
        private void button1_Click ( object sender ,EventArgs e )
        {
            intList . Clear ( );
            getList ( );
            if ( intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }
            ZTable = _bll . GetDataTablePlan ( intList );
            if ( ZTable == null || ZTable . Rows . Count < 1 )
            {
                XtraMessageBox . Show ( "请重新选择,所选产品不符合报工条件" );
                return;
            }
            CarpenterBll . UserInformation . TypeOfOper = "组装日计划预排报工";
            Jbg ( true );
        }
        private void btnCl_Click ( object sender ,System . EventArgs e )
        {
            lupColor . EditValue = luporcu . EditValue = lupProduct . EditValue = null;
            dtStart . Text = dtEnd . Text = string . Empty;
        }
        //全部查询
        private void btnQueryAll_Click ( object sender ,EventArgs e )
        {
            selectTable ( );
            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );
        }
        #endregion

        #region Method
        void getList_week ( )
        {
            intList . Clear ( );
            for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
            {
                if ( bandedGridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
                {
                    if ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "PAS029" ] . ToString ( ) ) )
                    {
                        if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                        {
                            if ( !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                                intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                        }
                    }
                    else
                        bandedGridView1 . GetDataRow ( i ) [ "check" ] = false;
                }
            }
        }
        void getList ( )
        {
            intList . Clear ( );
            for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
            {
                if ( bandedGridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
                {
                    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    {
                        if ( !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                            intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                    }
                }
            }
        }
        void getList_j_day ( )
        {
            intList . Clear ( );
            string dl = string . Empty;
            for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
            {
                if ( bandedGridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
                {
                    //dl = bandedGridView1 . GetDataRow ( i ) [ "PAS012" ] . ToString ( );
                    //if ( string . IsNullOrEmpty ( dl ) )
                    //{
                        if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                        {
                            if ( !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                                intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                        }
                    //}
                }
            }
        }
        void getPai ( )
        {
            intList . Clear ( );
            for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
            {
                if ( bandedGridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
                {
                    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                    {
                        if ( !intList . Contains ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) )
                        {
                            intList . Add ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                            _model . PAS001 = bandedGridView1 . GetDataRow ( i ) [ "PAS001" ] . ToString ( );
                            _model . PAS002 = bandedGridView1 . GetDataRow ( i ) [ "PAS002" ] . ToString ( );
                            _model . PAS003 = bandedGridView1 . GetDataRow ( i ) [ "PAS003" ] . ToString ( );
                        }
                    }
                }
            }
        }
        void Jbg ( bool plan )
        {
            string formText = string . Empty;
            if ( plan == false )
                formText = "组装派工报工";
            else
                formText = "组装派工计划报工";
            Carpenter . Query . FormControlOne from = new Carpenter . Query . FormControlOne ( formText ,"ZDailyWork" ,ZTable ,null );
            from . ShowDialog ( );
            //if ( result == DialogResult . OK )
            //{
            //    DataTable dt = from . getTable;
            //    if ( dt != null && dt . Rows . Count > 0 )
            //    {
            //        isOk = _bll . ZDailyWork ( dt ,plan );
            //        if ( isOk == true )
            //        {
            //            XtraMessageBox . Show ( "组装报工成功" );
            //            Query ( );
            //        }
            //        else
            //            XtraMessageBox . Show ( "组装报工失败" );
            //    }
            //}
        }
        void Zbg ( bool plan )
        {
            string formText = string . Empty;
            if ( plan == false )
                formText = "组装报工日计划";
            else
                formText = "组装报工预排日计划";

            Carpenter . Query . FormControlOne from = new Carpenter . Query . FormControlOne ( formText ,"ZDayDailyWork" ,null ,intList );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                DataTable dt = from . getDataDayDailyZ;
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    isOk = _bll . ZDayDailyWork ( dt ,plan );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "组装报工成功" );
                        Query ( );
                        List<string> strList = new List<string> ( );

                        if ( CarpenterBll . UserInformation . ZPai != null && CarpenterBll . UserInformation . ZPai . Count > 0 )
                        {
                            formText = string . Join ( "\n\r" ,( from x in CarpenterBll . UserInformation . ZPai select x ) . ToArray ( ) );
                            XtraMessageBox . Show ( "您有以下产品未派工:\n\r" + formText + "" ,"提示" ,MessageBoxButtons . OKCancel );
                        }                    }
                    else
                        XtraMessageBox . Show ( "组装报工失败" );
                }
            }
        }
        void selectTable ( )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupProduct . Text ) )
                strWhere += " AND PAS001='" + lupProduct . Text + "'";
            if ( !string . IsNullOrEmpty ( luporcu . Text ) )
                strWhere += " AND PAS003='" + luporcu . Text + "'";
            if ( !string . IsNullOrEmpty ( lupColor . Text ) )
                strWhere += " AND OPI006='" + lupColor . Text + "'";
            if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                strWhere += " AND PAS012>='" + dtStart . Text + "'";
            if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                strWhere += " AND PAS012<='" + dtEnd . Text + "'";
        }
        #endregion

    }
}



