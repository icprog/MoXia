using DevExpress . XtraEditors;
using DevExpress . XtraGrid . Views . Grid . ViewInfo;
using System . Collections . Generic;
using System . Data;
using System . Drawing;
using System . Reflection;
using System . Windows . Forms;
using System;

namespace Carpenter
{
    public partial class FormProductionPaint :FormChild
    {
        CarpenterEntity.ProductionPaintEntity _model=null;
        CarpenterBll.Bll.ProductionPaintBll _bll=null;
        ControlUser . DLPlanDayPort plan =null;
        DataTable tableView,Ptable,PTable;bool isOk=false;int num=0,checkAll=0; string strWhere="1=1";
        
        public FormProductionPaint ( )
        {
            InitializeComponent ( );

            _model = new CarpenterEntity . ProductionPaintEntity ( );
            _bll = new CarpenterBll . Bll . ProductionPaintBll ( );
            plan = new ControlUser . DLPlanDayPort ( );
            splitContainerControl1 . Panel2 . Controls . Add ( plan );
            plan . Dock = System . Windows . Forms . DockStyle . Fill;
            
            Utility . GridViewMoHuSelect . SetFilter ( bandedGridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolPrint ,toolCancellation ,toolExamin ,toolReview ,toolAdd } );


            bandedGridView1 . OptionsBehavior . Editable = false;
            wait . Hide ( );

            lupProduct . Properties . DataSource = _bll . GetOnly ( "PDP001" );
            lupProduct . Properties . DisplayMember = "PDP001";
            luporcu . Properties . DataSource = _bll . GetOnly ( "PDP002 OPI001,PDP003 OPI002" );
            luporcu . Properties . DisplayMember = "OPI002";
            lupColor . Properties . DataSource = _bll . GetColor ( );
            lupColor . Properties . DisplayMember = "OPI006";
        }
        
        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;

            selectTable ( );
            strWhere += " AND (PDP027 IS NULL OR PDP027='' OR PDP027='0')";

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return base . Query ( );
        }
        protected override int Edit ( )
        {
            //editTool ( );
            //bandedGridView1 . OptionsBehavior . Editable = true;

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
            if ( _bll . ExistsYW ( idxList ) )
            {
                XtraMessageBox . Show ( "油漆周计划存在选中的记录,不允许删除" );
                return 0;
            }
            if ( _bll . ExistsYD ( idxList ) )
            {
                XtraMessageBox . Show ( "油漆日计划存在选中的记录,不允许删除" );
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
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            tableView = _bll . GetDataTableView ( strWhere );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                toolQuery . Enabled = true;

                tableView . Columns . Add ( "check" ,typeof ( System . Boolean ) );
                gridControl1 . DataSource = tableView;
                QueryTool ( );
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }
        private void backgroundWorker2_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            //isOk = _bll . Save ( tableView );
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                if ( isOk )
                {
                    XtraMessageBox . Show ( "保存成功" );
                    QueryTool ( );
                    bandedGridView1 . OptionsBehavior . Editable = false;
                }
                else
                    XtraMessageBox . Show ( "保存失败" );
            }
        }
        private void bandedGridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void bandedGridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            num = bandedGridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= bandedGridView1 . DataRowCount - 1 )
            {
                if ( bandedGridView1 . GetDataRow ( num ) [ "check" ] . ToString ( ) == "True" )
                    bandedGridView1 . GetDataRow ( num ) [ "check" ] = false;
                else
                    bandedGridView1 . GetDataRow ( num ) [ "check" ] = true;
            }
        }
        private void gridControl1_DoubleClick ( object sender ,System . EventArgs e )
        {
            Point pt = gridControl1 . PointToClient ( Control . MousePosition );
            GridHitInfo info = bandedGridView1 . CalcHitInfo ( pt );
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
        private void bandedGridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( toolEdit . Visibility == DevExpress . XtraBars . BarItemVisibility . Always && toolEdit . Enabled == true )
            {
                DataRow row = bandedGridView1 . GetFocusedDataRow ( );
                if ( row == null )
                    return;

                _model . PDP005 = string . IsNullOrEmpty ( row [ "PDP005" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PDP005" ] . ToString ( ) );
                _model . PDP006 = row [ "PDP006" ] . ToString ( );
                if ( bandedGridView1 . FocusedColumn . FieldName == "PDP005" || bandedGridView1 . FocusedColumn . FieldName == "PDP006" || bandedGridView1 . FocusedColumn . FieldName == "PDP007" || bandedGridView1 . FocusedColumn . FieldName == "PDP020" || bandedGridView1 . FocusedColumn . FieldName == "PDP021" )
                {
                    if ( string . IsNullOrEmpty ( row [ "PDP007" ] . ToString ( ) ) )
                        _model . PDP007 = null;
                    else
                        _model . PDP007 = Convert . ToDateTime ( row [ "PDP007" ] . ToString ( ) );
                    _model . PDP020 = string . IsNullOrEmpty ( row [ "PDP020" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PDP020" ] . ToString ( ) );
                    _model . PDP021 = row [ "PDP021" ] . ToString ( );
                    _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );

                    Carpenter . OrderEdit . PaintAllInfoEdit from = new OrderEdit . PaintAllInfoEdit ( "油漆白坯、软包编辑" ,_model );
                    if ( from . ShowDialog ( ) == DialogResult . OK )
                    {
                        _model = from . getModel;
                        row = tableView . Select ( "idx=" + _model . idx + "" ) [ 0 ];
                        row . BeginEdit ( );
                        row [ "PDP005" ] = _model . PDP005;
                        row [ "PDP006" ] = _model . PDP006;
                        if ( _model . PDP007 == null )
                            row [ "PDP007" ] = DBNull . Value;
                        else
                            row [ "PDP007" ] = _model . PDP007;
                        row [ "PDP020" ] = _model . PDP020;
                        row [ "PDP021" ] = _model . PDP021;
                        row . EndEdit ( );
                        gridControl1 . DataSource = tableView;
                        gridControl1 . RefreshDataSource ( );
                    }
                }
            }
        }
        #endregion
        
        #region Click
        List<string> intList=new List<string>();
        //周计划
        private void btnWeekPlan_Click ( object sender ,System . EventArgs e )
        {
            intList . Clear ( );
            getList ( );
            if ( intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要排计划的产品" );
                return;
            }
            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "油漆生产周计划" ,"BLWeeklyPlan" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterEntity . PlanStockPLSEntity _model = from . GetPLS;
                if ( string . IsNullOrEmpty ( _model . PLS002 ) )
                {
                    XtraMessageBox . Show ( "请填写周次" );
                    return;
                }
                CarpenterEntity . ProductionPaintWeekPWGEntity _pwg = new CarpenterEntity . ProductionPaintWeekPWGEntity ( );
                _pwg . PWG003 = _model . PLS003;
                _pwg . PWG004 = _model . PLS004;
                _pwg . PWG005 = _model . PLS005;
                _pwg . PWG009 = _model . PLS002;
                _pwg . PWG008 = _model . PLS008;
                CarpenterBll . UserInformation . TypeOfOper = "油漆周计划";
                int resu = _bll . Exists ( _pwg . PWG009 ,_pwg . PWG008 ,intList );
                if ( resu == 2 )
                {
                    XtraMessageBox . Show ( "本年已经存在周次:" + _pwg . PWG009 + ",且已注销,不允许生成" );
                    return;
                }
                if ( resu == 3 )
                {
                    XtraMessageBox . Show ( "本年已经存在周次:" + _pwg . PWG009 + ",且已审核,不允许生成" );
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
                    //if ( XtraMessageBox . Show ( "本年已经存在周次:" + _pwg . PWG009 + ",是否覆盖?" ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    //    return;
                    isOk = _bll . Edit_BL ( _pwg ,intList  ,_model . PLS008 );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "生成油漆周计划成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "生成油漆周计划失败" );
                }
                else if ( resu == 5 )
                {
                    isOk = _bll . Add_BL ( _pwg ,intList   ,_model . PLS008 );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "生成油漆周计划成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "生成油漆周计划失败" );
                }
            }
        }
        //周计划报工
        private void btnWeekDaily_Click ( object sender ,System . EventArgs e )
        {
            intList . Clear ( );
            getList ( );

            if ( intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }

            Ptable = _bll . GetDataTablePlanWeekJ ( intList );
            Carpenter . Query . FormWeekDailyWork from = new Carpenter . Query . FormWeekDailyWork ( "油漆周计划报工" ,Ptable );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterBll . UserInformation . TypeOfOper = "油漆周计划报工";
                DataTable dt = from . GetTableP;
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    isOk = _bll . PDailyWeek ( dt ,false );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "油漆报工成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "油漆报工失败" );
                }
            }
        }
        //周计划预排报工
        private void btnWeelDailyPlan_Click ( object sender ,System . EventArgs e )
        {
            intList . Clear ( );
            getList ( );

            if ( intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }

            Ptable = _bll . GetDataTablePlanWeekDailyJ ( intList );
            Carpenter . Query . FormWeekDailyWork from = new Carpenter . Query . FormWeekDailyWork ( "油漆周计划预排报工" ,Ptable );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterBll . UserInformation . TypeOfOper = "油漆周计划预排报工";
                DataTable dt = from . GetTableP;
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    isOk = _bll . PDailyWeek ( dt ,false );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "油漆报工成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "油漆报工失败" );
                }
            }
        }
        //日计划
        private void btnDayPlan_Click ( object sender ,System . EventArgs e )
        {
            intList . Clear ( );
            getList ( );

            if ( intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要排计划的产品" );
                return;
            }
            int proArr = _bll . ExistsProductAttr ( intList );
            if ( proArr == 3 || proArr == 2 || proArr == 4 )
            {
                XtraMessageBox . Show ( "您选择的产品属性包括定制,定制不允许排计划" );
                return;
            }
            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "油漆生产日计划" ,"PDayPlan" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterEntity . ProductionPaintDayPWDEntity _model = from . getPwd;
                if ( string . IsNullOrEmpty ( _model . PWD002 ) )
                {
                    XtraMessageBox . Show ( "请选择工段" );
                    return;
                }
                CarpenterBll . UserInformation . TypeOfOper = "油漆日计划";
                int resu = _bll . Exists_Day ( _model . PWD002 ,_model . PWD003 ,intList ,_model . PWD005 );
                if ( resu . Equals ( 2 ) )
                {
                    XtraMessageBox . Show ( "工段:" + _model . PWD002 + "\n\r计划日期:" + _model . PWD003 . ToString ( "yyyy-MM-dd" ) + "\n\r的日计划已经注销,不允许生成" );
                    return;
                }
                if ( resu . Equals ( 3 ) )
                {
                    XtraMessageBox . Show ( "工段:" + _model . PWD002 + "\n\r计划日期:" + _model . PWD003 . ToString ( "yyyy-MM-dd" ) + "\n\r的日计划已经审核,不允许生成" );
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
                    num = _bll . Esit_BL_Day ( _model ,intList ,_model . PWD005 );
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
                    isOk = _bll . Add_BL_Day ( _model ,intList ,_model . PWD005 );
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
        //日计划报工
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

            //PTable = _bll . GetDataTable ( intList );
            CarpenterBll . UserInformation . TypeOfOper = "油漆日计划报工";
            PTable = null;
            BLbg ( false );
        }
        //日计划预排
        private void btnDayDailyPlan_Click ( object sender ,System . EventArgs e )
        {
            intList . Clear ( );
            getList ( );
            if ( intList . Count < 1 )
            {
                XtraMessageBox . Show ( "请选择需要报工的产品" );
                return;
            }

            //PTable = _bll . GetDataTablePlan ( intList );
            CarpenterBll . UserInformation . TypeOfOper = "油漆日计划预排报工";
            PTable = null;
            BLbg ( true );
        }
        //显示子表
        private void bandedGridView1_RowCellClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowCellClickEventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            _model . PDP001 = row [ "PDP001" ] . ToString ( );
            _model . PDP002 = row [ "PDP002" ] . ToString ( );

            DataTable tablePlan = null;

            if ( e . Column . FieldName == "PDP009" )
            {
                tablePlan = _bll . getDataTable ( _model . PDP001 ,_model . PDP002 ,CarpenterBll . ColumnValues . yq_dq );
            }
            else if ( e . Column . FieldName == "PDP012" )
            {
                tablePlan = _bll . getDataTable ( _model . PDP001 ,_model . PDP002 ,CarpenterBll . ColumnValues . yq_ym );
            }
            else if ( e . Column . FieldName == "PDP015" )
            {
                tablePlan = _bll . getDataTable ( _model . PDP001 ,_model . PDP002 ,CarpenterBll . ColumnValues . yq_xs );
            }
            else if ( e . Column . FieldName == "PDP018" )
            {
                tablePlan = _bll . getDataTable ( _model . PDP001 ,_model . PDP002 ,CarpenterBll . ColumnValues . yq_mq );
            }
            else if ( e . Column . FieldName == "PDP022" )
            {
                tablePlan = _bll . getDataTable ( _model . PDP001 ,_model . PDP002 ,CarpenterBll . ColumnValues . yq_bz );
            }
            else if ( e . Column . FieldName == "PDP008" )
            {
                tablePlan = _bll . GetDataTable ( _model . PDP001 ,_model . PDP002 ,CarpenterBll . ColumnValues . yq_dq );
            }
            else if ( e . Column . FieldName == "PDP011" )
            {
                tablePlan = _bll . GetDataTable ( _model . PDP001 ,_model . PDP002 ,CarpenterBll . ColumnValues . yq_ym );
            }
            else if ( e . Column . FieldName == "PDP014" )
            {
                tablePlan = _bll . GetDataTable ( _model . PDP001 ,_model . PDP002 ,CarpenterBll . ColumnValues . yq_xs );
            }
            else if ( e . Column . FieldName == "PDP017" )
            {
                tablePlan = _bll . GetDataTable ( _model . PDP001 ,_model . PDP002 ,CarpenterBll . ColumnValues . yq_mq );
            }
            else if ( e . Column . FieldName == "PDP028" )
            {
                tablePlan = _bll . GetDataTable ( _model . PDP001 ,_model . PDP002 ,CarpenterBll . ColumnValues . yq_bz );
            }

            plan . gridControl1 . DataSource = tablePlan;
        }
        //全查
        private void btnQueryAll_Click ( object sender ,EventArgs e )
        {
            selectTable ( );
            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );
        }
        //清除
        private void btnCl_Click ( object sender ,System . EventArgs e )
        {
            lupColor . EditValue = luporcu . EditValue = lupProduct . EditValue = null;
            dtStart . Text = dtEnd . Text = string . Empty;
        }       
        #endregion

        #region Method
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
        void BLbg ( bool plan )
        {
            string formText = string . Empty;
            if ( plan == false )
                formText = "油漆日计划报工";
            else
                formText = "油漆日计划计划报工";
            Carpenter . Query . FormControlOne from = new Carpenter . Query . FormControlOne ( formText ,"PDailyWork" ,PTable ,intList );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                DataTable dt = from . getDataDailyP;
                string work = from . getStr;
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    isOk = _bll . BLDailyWork ( dt ,plan ,work );
                    if ( isOk == true )
                    {
                        XtraMessageBox . Show ( "油漆报工成功" );
                        Query ( );
                    }
                    else
                        XtraMessageBox . Show ( "油漆报工失败" );
                }
            }
        }
        void selectTable ( )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupProduct . Text ) )
                strWhere += " AND PDP001='" + lupProduct . Text + "'";
            if ( !string . IsNullOrEmpty ( luporcu . Text ) )
                strWhere += " AND PDP003='" + luporcu . Text + "'";
            if ( !string . IsNullOrEmpty ( lupColor . Text ) )
                strWhere += " AND OPI006='" + lupColor . Text + "'";
            if ( !string . IsNullOrEmpty ( dtStart . Text ) )
                strWhere += " AND PAS012>='" + dtStart . Text + "'";
            if ( !string . IsNullOrEmpty ( dtEnd . Text ) )
                strWhere += " AND PAS012>='" + dtEnd . Text + "'";
        }
        #endregion

    }
}
