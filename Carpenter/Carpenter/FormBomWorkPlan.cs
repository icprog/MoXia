using Carpenter . Query;
using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Linq;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormBomWorkPlan :FormChild
    {
        CarpenterEntity.BomWorkPlanWOQEntity _modelOne=new CarpenterEntity.BomWorkPlanWOQEntity();
        CarpenterEntity.BomWorkPlanWOREntity _modelTwo=new CarpenterEntity.BomWorkPlanWOREntity();
        CarpenterBll.Bll.BomWorkPlanBll _bll=new CarpenterBll.Bll.BomWorkPlanBll();
        DataTable tableQueryOne,tableQueryTwo;
        int num=0;
        bool result=false;
        string state=string.Empty,columnName=string.Empty;
        List<string> idxList=new List<string>();
        
        public FormBomWorkPlan ( )
        {
            InitializeComponent ( );

            //splitContainer1 . Panel1 . Enabled = false;
            controlUnEnable ( );
            gridView1 . OptionsBehavior . Editable = false;

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolExport } );


            wait . Hide ( );
            //SetImage . setImage ( Concell1 . pictureBox1 ,"zhuxiao.png" );
            //Concell1 . Hide ( );
            //SetImage . setImage ( Concell2 . pictureBox1 ,"shenhe.png" );
            //Concell2 . Hide ( );

            productRead ( );

            addTools ( );
            toolCopy . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            this . toolCopy . ItemClick += this . toolCopy_ItemClick;
        }
        
        void productRead ( )
        {
            lupPerson . Properties . DataSource = _bll . GetDataTablePerson ( );
            lupPerson . Properties . DisplayMember = "EMP002";
            lupPerson . Properties . ValueMember = "EMP001";

            foreach ( string s in CarpenterBll . ColumnValues . strWorkType )
            {
                repositoryItemComboBox1 . Items . Add ( s );
            }

        }
        
        #region Main
        protected override int Query ( )
        {
            Carpenter . Query . FormBomWorkPlanQuery from = new Carpenter . Query . FormBomWorkPlanQuery ( "BOM清单查询" ,"FormBomWorkPlan" );
            DialogResult result = from . ShowDialog ( );
            if ( result == System . Windows . Forms . DialogResult . OK )
            {
                CarpenterEntity . OPIEntity _model = from . getModel;
                _modelOne . WOQ001 = _model . OPI001;

                wait . Show ( );
                backgroundWorker1 . RunWorkerAsync ( );
                lupWeekend . Enabled = true;
            }
            else
            {
                toolQuery . Enabled = true;
                toolAdd . Enabled = true;
            }

            return 0;
        }
        protected override int Add ( )
        {
            state = "add";

            addTool ( );

            //Concell1 . Hide ( );
            //Concell2 . Hide ( );

            Graph . gra ( splitContainerControl1 ,"反" );
            splitContainerControl1 . Panel1 . Refresh ( );

            clear ( );
            gridView1 . OptionsBehavior . Editable = true;
            //splitContainer1 . Panel1 . Enabled = true;
            controlEnable ( );

            tableQueryOne = null;
            tableQueryTwo = _bll . GetDataTableTwo ( " " );
            tableQueryTwo . Columns . Add ( "check" ,typeof ( System . Boolean ) );
            gridControl1 . DataSource = tableQueryTwo;
            
            lupPerson . EditValue = null;
            ReadOrWriteImageOfPicutre . ClearPicture ( pibProduct );

            return 0;
        }
        protected override int Edit ( )
        {
            state = "edit";

            editTool ( );

            gridView1 . OptionsBehavior . Editable = true;
            splitContainerControl1 . Panel1 . Enabled = true;
            controlEnable ( );

            toolCopy . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;

            return 0;
        }
        protected override int Delete ( )
        {
            if ( string . IsNullOrEmpty ( texProductNum . Text ) )
            {
                XtraMessageBox . Show ( "请选择需要删除的内容" );
                return 0;
            }

            if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;

            result = _bll . Delete ( texProductNum . Text );
            if ( result == true )
            {
                XtraMessageBox . Show ( "删除成功" );

                clear ( );
                tableQueryTwo = null;
                gridControl1 . DataSource = tableQueryTwo;
                //splitContainer1 . Panel1 . Enabled = false;
                gridView1 . OptionsBehavior . Editable = false;
                controlUnEnable ( );

                deleteTool ( );
                Graph . gra ( splitContainerControl1 ,"反" );
                splitContainerControl1 . Panel1 . Refresh ( );
                //Concell1 . Hide ( );
                //Concell2 . Hide ( );
                wait . Hide ( );

                ReadOrWriteImageOfPicutre . ClearPicture ( pibProduct );

                lupPerson . EditValue = null;
            }
            else
                XtraMessageBox . Show ( "删除失败,请重试" );

            return 0;
        }
        protected override int Cancellation ( )
        {
            if ( string . IsNullOrEmpty ( texProductNum . Text ) )
            {
                XtraMessageBox . Show ( "请选择需要注销的内容" );
                return 0;
            }

            state = toolCancellation . Caption;
            if ( state . Equals( "注销" ))
                _modelOne . WOQ007 = true;
            else
                _modelOne . WOQ007 = false;

            result = _bll . Cancellation ( texProductNum . Text ,_modelOne . WOQ007 );
            if ( result == true )
            {
                XtraMessageBox . Show ( "" + state + "成功" );
                if ( state . Equals ( "注销" ) )
                {
                    Graph . gra ( splitContainerControl1 ,"注销" ,1100 );
                    //Concell1 . Show ( );
                }
                else
                {
                    Graph . gra ( splitContainerControl1 ,"反" );
                    //Concell1 . Hide ( );
                }
                splitContainerControl1 . Panel1 . Refresh ( );
                cancelltionTool ( state );
            }
            else
                XtraMessageBox . Show ( "" + state + "失败,请重试" );

            return 0;
        }
        protected override int Save ( )
        {
            errorProvider1 . Clear ( );
            result = true;
            if ( string . IsNullOrEmpty ( texProductNum . Text ) )
            {
                errorProvider1 . SetError ( texProductNum ,"请选择产品" );
                result = false;
            }
            if ( string . IsNullOrEmpty ( lupPerson . Text ) )
            {
                errorProvider1 . SetError ( lupPerson ,"请选择负责人" );
                result = false;
            }
            if ( result == false )
                return 0;

            _modelOne . WOQ001 = texProductNum . Text;
            _modelOne . WOQ002 = _modelOne . WOQ003 = null;
            if ( dtpStart . Text != string . Empty )
                _modelOne . WOQ002 =  Convert . ToDateTime ( dtpStart . Text );
            if ( dtpEnd . Text != string . Empty )
                _modelOne . WOQ003 = Convert . ToDateTime ( dtpEnd . Text );
            _modelOne . WOQ004 = lupPerson . EditValue . ToString ( );
            _modelOne . WOQ005 = DateTime . Now;
            _modelOne . WOQ006 = UserLogin . userName;
            _modelOne . WOQ008 = texProductName . Text;
            _modelOne . WOQ009 = texSpeci . Text;

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            if ( checkTable ( ) == false )
                return 0;

            if ( state . Equals ( "add" ) || state . Equals ( "copy" ) )
            {
                _modelOne . WOQ007 = false;
                _modelOne . WOQ010 = false;
                wait . Show ( );
                backgroundWorker2 . RunWorkerAsync ( );
            }
            else if ( state . Equals ( "edit" ) )
            {
                //若有10条记录  有两人同时操作  一人增加一条记录  一人删除一条记录  同时保存  则永远是10条记录  但有一条记录不同
                wait . Show ( );
                backgroundWorker2 . RunWorkerAsync ( );
            }

            return 0;
        }
        protected override int Cancel ( )
        {
            if ( state . Equals ( "add" ) )
            {
                controlUnEnable ( );
                //splitContainer1 . Panel1 . Enabled = false;
                gridView1 . OptionsBehavior . Editable = false;
                clear ( );
                tableQueryOne = null;
                tableQueryTwo = null;
                gridControl1 . DataSource = tableQueryTwo;

                ReadOrWriteImageOfPicutre . ClearPicture ( pibProduct );

                lupPerson . EditValue = null;

            }
            else if ( state . Equals ( "edit" ) || state . Equals ( "copy" ) )
            {
                //splitContainer1 . Panel1 . Enabled = false;
                controlUnEnable ( );
                gridView1 . OptionsBehavior . Editable = false;

                toolCopy . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }

            cancelltionTool ( state );

            return 0;
        }
        protected override int Examine ( )
        {
            if ( string . IsNullOrEmpty ( texProductNum . Text ) )
            {
                XtraMessageBox . Show ( "请选择需要审核的内容" );
                return 0;
            }
            
            state = toolExamin . Caption;
            if ( state . Equals ( "审核" ) )
                _modelOne . WOQ010 = true;
            else
                _modelOne . WOQ010 = false;

            result = _bll . Examine ( texProductNum . Text ,_modelOne . WOQ010 );
            if ( result == true )
            {
                XtraMessageBox . Show ( "" + state + "成功" );
                if ( state . Equals ( "审核" ) )
                {
                    Graph . gra ( splitContainerControl1 ,"审核" ,1100 );
                    //Concell2 . Show ( );
                }
                else
                {
                    Graph . gra ( splitContainerControl1 ,"反" );
                    //Concell2 . Hide ( );
                }

                splitContainerControl1 . Panel1 . Refresh ( );
                examineTool ( state );
            }
            else
                XtraMessageBox . Show ( "" + state + "失败,请重试" );

            return base . Examine ( );
        }
        protected override int Review ( )
        {
            Review ( texProductNum . Text ,this . Name );

            return base . Review ( );
        }
        protected override int Print ( )
        {
            if ( string . IsNullOrEmpty ( lupWeekend . Text ) )
            {
                XtraMessageBox . Show ( "请选择批号" );
                return 0;
            }

            DataRow row;
            List<int> idxList = new List<int> ( );
            int [ ] x = gridView1 . GetSelectedRows ( );
            foreach ( int y in x )
            {
                row = gridView1 . GetDataRow ( y );
                _modelTwo . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                if ( _modelTwo . idx > 0 )
                {
                    if ( !idxList . Contains ( _modelTwo . idx ) )
                        idxList . Add ( _modelTwo . idx );
                }
            }

            if ( idxList . Count < 1 )
            {
                DataTable printOne = _bll . getPrintOne ( lupWeekend . Text ,texProductNum . Text );
                printOne . TableName = "WOQ";
                DataTable printTwo = _bll . getPrintTwo ( texProductNum . Text );
                printTwo . TableName = "WOR";
                
                Print ( new DataTable [ ] { printOne,printTwo } ,"BOM清单.frx" );
            }
            else
            {
                DataTable print = _bll . GetDataTablePrint ( idxList ,lupWeekend . Text ,texProductNum . Text );
                if ( print == null || print . Rows . Count < 1 )
                {
                    XtraMessageBox . Show ( "批号:" + lupWeekend . Text + "周计划中不存在品号:" + texProductNum . Text + ",请核实" );
                    return 0;
                }
                print . TableName = "TableOne";

                Print ( new DataTable [ ] { print } ,"传票.frx" );
            }  

            return base . Print ( );
        }
        #endregion

        #region Event
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            num = gridView1 . FocusedRowHandle;
            //if ( gridView1 . OptionsBehavior . Editable == false )
            //{
            //    if ( num < 0 || num > gridView1 . DataRowCount - 1 )
            //        return;
            //    if (gridView1. GetDataRow(num) [ "check" ] . ToString ( ) == "True" )
            //        gridView1 . GetDataRow ( num ) [ "check" ] = false;
            //    else
            //        gridView1 . GetDataRow ( num ) [ "check" ] = true;
            //}
            //else
            //{
                if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
                {
                    DataRow row = gridView1 . GetDataRow ( num );
                    _modelTwo . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                    _modelTwo . WOR001 = row [ "WOR001" ] . ToString ( );
                    _modelTwo . WOR005 = row [ "WOR005" ] . ToString ( );
                    _modelTwo . WOR006 = row [ "WOR006" ] . ToString ( );
                    _modelTwo . WOR007 = row [ "WOR007" ] . ToString ( );
                    _modelTwo . WOR008 = row [ "WOR008" ] . ToString ( );
                    _modelTwo . WOR009 = row [ "WOR009" ] . ToString ( );
                    _modelTwo . WOR010 = row [ "WOR010" ] . ToString ( );
                    _modelTwo . WOR011 = row [ "WOR011" ] . ToString ( );
                    _modelTwo . WOR012 = row [ "WOR012" ] . ToString ( );
                    _modelTwo . WOR013 = row [ "WOR013" ] . ToString ( );
                    _modelTwo . WOR014 = row [ "WOR014" ] . ToString ( );
                    _modelTwo . WOR015 = row [ "WOR015" ] . ToString ( );
                    _modelTwo . WOR016 = row [ "WOR016" ] . ToString ( );
                    _modelTwo . WOR017 = string . IsNullOrEmpty ( row [ "WOR017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "WOR017" ] . ToString ( ) );
                    _modelTwo . WOR018 = row [ "WOR018" ] . ToString ( );
                    _modelTwo . WOR019 = string . IsNullOrEmpty ( row [ "WOR019" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "WOR019" ] . ToString ( ) );
                    _modelTwo . WOR020 = row [ "WOR020" ] . ToString ( );
                    _modelTwo . WOR021 = row [ "WOR021" ] . ToString ( );
                    _modelTwo . WOR022 = row [ "WOR022" ] . ToString ( );
                    
                }
            //}
        }
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            tableQueryOne = _bll . GetDataTableOne ( _modelOne . WOQ001 );
            tableQueryTwo = _bll . GetDataTableTwo ( _modelOne . WOQ001 );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );

                if ( tableQueryOne != null && tableQueryOne . Rows . Count > 0 )
                {
                    texProductName . Text = tableQueryOne . Rows [ 0 ] [ "WOQ008" ] . ToString ( );
                    texSpeci . Text = tableQueryOne . Rows [ 0 ] [ "WOQ009" ] . ToString ( );
                    texProductNum . Text = tableQueryOne . Rows [ 0 ] [ "WOQ001" ] . ToString ( );
                    dtpStart . Text = tableQueryOne . Rows [ 0 ] [ "WOQ002" ] . ToString ( );
                    dtpEnd . Text = tableQueryOne . Rows [ 0 ] [ "WOQ003" ] . ToString ( );

                    lupPerson . EditValue = tableQueryOne . Rows [ 0 ] [ "WOQ004" ] . ToString ( );

                    if ( !string . IsNullOrEmpty ( tableQueryOne . Rows [ 0 ] [ "WOQ007" ] . ToString ( ) ) )
                        _modelOne . WOQ007 = ( bool ) tableQueryOne . Rows [ 0 ] [ "WOQ007" ];
                    if ( _modelOne . WOQ007 == true )
                        toolCancellation . Caption = "反注销";
                    else
                        toolCancellation . Caption = "注销";
                    if ( !string . IsNullOrEmpty ( tableQueryOne . Rows [ 0 ] [ "WOQ010" ] . ToString ( ) ) )
                        _modelOne . WOQ010 = ( bool ) tableQueryOne . Rows [ 0 ] [ "WOQ010" ];
                    if ( _modelOne . WOQ010 == true )
                        toolExamin . Caption = "反审核";
                    else
                        toolExamin . Caption = "审核";

                    //tableQueryTwo . Columns . Add ( "check" ,typeof ( System . Boolean ) );
                    gridControl1 . DataSource = tableQueryTwo;
                }

                if ( toolCancellation . Caption . Equals ( "反注销" ) )
                {
                    Graph . gra ( splitContainerControl1 ,"注销" ,1100 );
                    //Concell1 . Show ( );
                }
                if ( toolExamin . Caption . Equals ( "反审核" ) )
                {
                    Graph . gra ( splitContainerControl1 ,"审核" ,1100 );
                    //Concell2 . Show ( );
                }

                if ( _modelOne . WOQ007 == false && _modelOne . WOQ010 == false )
                    Graph . gra ( splitContainerControl1 ,"反" );
                splitContainerControl1 . Panel1 . Refresh ( );

                QueryTool ( );
            }
        }
        private void pibProduct_DoubleClick ( object sender ,EventArgs e )
        {
            if ( pibProduct . Image == null )
                return;
            Carpenter . Query . FormPictureEnlarge from = new Carpenter . Query . FormPictureEnlarge ( "产品图片" ,pibProduct . Image );
            from . ShowDialog ( );
        }
        private void gridView1_InitNewRow ( object sender ,DevExpress . XtraGrid . Views . Grid . InitNewRowEventArgs e )
        {
            DevExpress . XtraGrid . Views . Grid . GridView view = sender as DevExpress . XtraGrid . Views . Grid . GridView;
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "WOR001" ] ,_modelTwo . WOR001 );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "WOR002" ] ,1 );
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );
            _modelTwo . WOR005 = tableQueryTwo . Compute ( "MAX(WOR005)" ,null ) . ToString ( );
            _modelTwo . WOR005 = _modelTwo . WOR005 == string . Empty ? "001" : ( Convert . ToInt32 ( _modelTwo . WOR005 ) + 1 ) . ToString ( ) . PadLeft ( 3 ,'0' );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "WOR005" ] ,_modelTwo . WOR005 );
        }
        private void gridControl1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DataRow rows = gridView1 . GetFocusedDataRow ( );
            if ( rows == null )
                return;
            if ( e . KeyChar == 13 )
            {
                if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
                {
                    _modelTwo . idx = string . IsNullOrEmpty ( rows [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( rows [ "idx" ] . ToString ( ) );
                    if ( _modelTwo . idx > 0 )
                    {
                        if ( !idxList . Contains ( _modelTwo . idx . ToString ( ) ) )
                            idxList . Add ( _modelTwo . idx . ToString ( ) );
                    }
                    tableQueryTwo . Rows . Remove ( rows );

                    //if ( tableQueryTre == null )
                    //{
                    //    tableQueryTre = tableQueryTwo . Copy ( );
                    //    tableQueryTre . Clear ( );
                    //}
                    //_modelTwo . WOR005 = rows [ "WOR005" ] . ToString ( );
                    //if ( tableQueryTre . Select ( "WOR005='" + _modelTwo . WOR005 + "'" ) . Length < 1 )
                    //{
                    //    _modelTwo . WOR007 = rows [ "WOR007" ] . ToString ( );
                    //    _modelTwo . WOR010 = rows [ "WOR010" ] . ToString ( );
                    //    _modelTwo . WOR013 = rows [ "WOR013" ] . ToString ( );
                    //    DataRow row = tableQueryTre . NewRow ( );
                    //    row [ "WOR001" ] = _modelTwo . WOR001;
                    //    row [ "WOR005" ] = _modelTwo . WOR005;
                    //    row [ "WOR007" ] = _modelTwo . WOR007;
                    //    row [ "WOR010" ] = _modelTwo . WOR010;
                    //    row [ "WOR013" ] = _modelTwo . WOR013;
                    //    tableQueryTre . Rows . Add ( row );
                    //}
                    //tableQueryTwo . Rows . Remove ( rows );
                    //gridView1 . DeleteRow ( num );
                }
            }
            //}
        }
        private void backgroundWorker2_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            if ( state . Equals ( "add" ) || state . Equals ( "copy" ) )
                result = _bll . Add ( tableQueryTwo ,_modelOne );
            if ( state . Equals ( "edit" ) )
                result = _bll . Edit ( tableQueryTwo ,_modelOne ,idxList );
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );

                if ( result == true )
                {
                    XtraMessageBox . Show ( "保存成功" );
                    gridView1 . OptionsBehavior . Editable = false;
                    //splitContainer1 . Panel1 . Enabled = false;
                    controlUnEnable ( );

                    saveTool ( );
                    toolCopy . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                }
                else
                    XtraMessageBox . Show ( "保存失败" );
            }
        }
        private void texProductNum_TextChanged ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( texProductNum . Text ) )
            {
                DataTable dt = _bll . GetDataTableProduct ( texProductNum . Text );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    texColor . Text = dt . Rows [ 0 ] [ "OPI006" ] . ToString ( );
                    texUnit . Text = dt . Rows [ 0 ] [ "OPI007" ] . ToString ( );
                    texClass . Text = dt . Rows [ 0 ] [ "OPI003" ] . ToString ( );
                    byte [ ] bt = string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "OPI012" ] . ToString ( ) ) == true ? null : ( byte [ ] ) dt . Rows [ 0 ] [ "OPI012" ];
                    pibProduct . Image = ReadOrWriteImageOfPicutre . ReadPicture ( bt );
                }

                lupWeekend . Properties . DataSource = _bll . GetDataTableWeek ( texProductNum . Text );
                lupWeekend . Properties . DisplayMember = "CUT001";

            }
        }
        private void texProductName_DoubleClick ( object sender ,EventArgs e )
        {
            Carpenter . Query . FormBomWorkPlanQuery from = new Carpenter . Query . FormBomWorkPlanQuery ( "BOM清单查询" ,"FormBomWorkPlanOPI" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterEntity . OPIEntity _modelOpi = from . getModel;
                texProductName . Text = _modelOpi . OPI002;
                texSpeci . Text = _modelOpi . OPI005;
                texProductNum . Text = _modelOpi . OPI001;
            }
        }
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridView1_PopupMenuShowing ( object sender ,DevExpress . XtraGrid . Views . Grid . PopupMenuShowingEventArgs e )
        {
            gridControl1 . ContextMenuStrip = null; 
            DevExpress . XtraGrid . Views . Grid . GridView view = sender as DevExpress . XtraGrid . Views . Grid . GridView;
            DevExpress . XtraGrid . Views . Grid . ViewInfo . GridHitInfo hitInfo = view . CalcHitInfo ( e . Point );
            num = hitInfo . RowHandle;
            if ( num < 0 || num > gridView1 . DataRowCount - 1 )
                return;
            DataRow row = gridView1 . GetDataRow ( num );
            columnName = hitInfo . Column . Name;
            if ( row != null && (hitInfo . Column . Name == "WOR034" || hitInfo . Column . Name == "WOR035" || hitInfo . Column . Name == "WOR036" || hitInfo . Column . Name == "WOR037" ) )
            {
                gridControl1 . ContextMenuStrip = contextMenuStrip1;
                if ( gridView1 . OptionsBehavior . Editable == false )
                {
                    contextMenuStrip1 . Items [ 0 ] . Visible = false;
                    contextMenuStrip1 . Items [ 2 ] . Visible = false;
                }
                else
                {
                    contextMenuStrip1 . Items [ 0 ] . Visible = true;
                    contextMenuStrip1 . Items [ 2 ] . Visible = true;
                }
            }
        }
        private void contextMenuStrip1_ItemClicked ( object sender ,ToolStripItemClickedEventArgs e )
        {
            DataRow row;

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            //导入
            if ( e . ClickedItem == ( ( ContextMenuStrip ) sender ) . Items [ 0 ] )
            {
                if ( columnName . Equals ( "WOR034" ) )
                {
                    _modelTwo . WOR034 = ReadOrWriteImageOfPicutre . ReadColumn ( );
                    if ( _modelTwo . WOR034 != null )
                    {
                        row = tableQueryTwo . Rows [ num ];
                        row . BeginEdit ( );
                        row [ "WOR034" ] = _modelTwo . WOR034;
                        row . EndEdit ( );
                    }
                }
                else if ( columnName . Equals ( "WOR035" ) )
                {
                    _modelTwo . WOR035 = ReadOrWriteImageOfPicutre . ReadColumn ( );
                    if ( _modelTwo . WOR035 != null )
                    {
                        row = tableQueryTwo . Rows [ num ];
                        row . BeginEdit ( );
                        row [ "WOR035" ] = _modelTwo . WOR035;
                        row . EndEdit ( );
                    }
                }
                else if ( columnName . Equals ( "WOR036" ) )
                {
                    _modelTwo . WOR036 = ReadOrWriteImageOfPicutre . ReadColumn ( );
                    if ( _modelTwo . WOR036 != null )
                    {
                        row = tableQueryTwo . Rows [ num ];
                        row . BeginEdit ( );
                        row [ "WOR036" ] = _modelTwo . WOR036;
                        row . EndEdit ( );
                    }
                }
                else if ( columnName . Equals ( "WOR037" ) )
                {
                    _modelTwo . WOR037 = ReadOrWriteImageOfPicutre . ReadColumn ( );
                    if ( _modelTwo . WOR037 != null )
                    {
                        row = tableQueryTwo . Rows [ num ];
                        row . BeginEdit ( );
                        row [ "WOR037" ] = _modelTwo . WOR037;
                        row . EndEdit ( );
                    }
                }

            }
            //预览
            if ( e . ClickedItem == ( ( ContextMenuStrip ) sender ) . Items [ 1 ] )
            {
                _modelTwo . WOR006 = gridView1 . GetDataRow ( num ) [ "WOR006" ] . ToString ( );
                if ( columnName . Equals ( "WOR034" ) )
                {
                    if ( !string . IsNullOrEmpty ( gridView1 . GetDataRow ( num ) [ "WOR034" ] . ToString ( ) ) )
                    {
                        _modelTwo . WOR034 = ( byte [ ] ) gridView1 . GetDataRow ( num ) [ "WOR034" ];                    
                        Image img = ReadOrWriteImageOfPicutre . ReadPicture ( _modelTwo . WOR034 );
                        if ( img == null )
                            return;
                        FormPictureEnlarge from = new FormPictureEnlarge ( _modelTwo . WOR006 + "图片预览" ,img );
                        from . ShowDialog ( );
                    }
                }
                else if ( columnName . Equals ( "WOR035" ) )
                {
                    if ( !string . IsNullOrEmpty ( gridView1 . GetDataRow ( num ) [ "WOR035" ] . ToString ( ) ) )
                    {
                        _modelTwo . WOR035 = ( byte [ ] ) gridView1 . GetDataRow ( num ) [ "WOR035" ];
                        Image img = ReadOrWriteImageOfPicutre . ReadPicture ( _modelTwo . WOR035 );
                        if ( img == null )
                            return;
                        FormPictureEnlarge from = new FormPictureEnlarge ( _modelTwo . WOR006 + "图片预览" ,img );
                        from . ShowDialog ( );
                    }
                }
                else if ( columnName . Equals ( "WOR036" ) )
                {
                    if ( !string . IsNullOrEmpty ( gridView1 . GetDataRow ( num ) [ "WOR035" ] . ToString ( ) ) )
                    {
                        _modelTwo . WOR036 = ( byte [ ] ) gridView1 . GetDataRow ( num ) [ "WOR036" ];
                        Image img = ReadOrWriteImageOfPicutre . ReadPicture ( _modelTwo . WOR036 );
                        if ( img == null )
                            return;
                        FormPictureEnlarge from = new FormPictureEnlarge ( _modelTwo . WOR006 + "图片预览" ,img );
                        from . ShowDialog ( );
                    }
                }
                else if ( columnName . Equals ( "WOR037" ) )
                {
                    if ( !string . IsNullOrEmpty ( gridView1 . GetDataRow ( num ) [ "WOR037" ] . ToString ( ) ) )
                    {
                        _modelTwo . WOR037 = ( byte [ ] ) gridView1 . GetDataRow ( num ) [ "WOR037" ];
                        Image img = ReadOrWriteImageOfPicutre . ReadPicture ( _modelTwo . WOR037 );
                        if ( img == null )
                            return;
                        FormPictureEnlarge from = new FormPictureEnlarge ( _modelTwo . WOR006 + "图片预览" ,img );
                        from . ShowDialog ( );
                    }
                }

            }
            //删除
            if ( e . ClickedItem == ( ( ContextMenuStrip ) sender ) . Items [ 2 ] )
            {
                row = tableQueryTwo . Rows [ num ];
                row . BeginEdit ( );
                if ( columnName . Equals ( "WOR034" ) )
                {
                    row [ "WOR034" ] = null;
                }
                else if ( columnName . Equals ( "WOR035" ) )
                {
                    row [ "WOR035" ] = null;
                }
                else if ( columnName . Equals ( "WOR036" ) )
                {
                    row [ "WOR036" ] = null;
                }
                else if ( columnName . Equals ( "WOR037" ) )
                {
                    row [ "WOR037" ] = null;
                }
                row . EndEdit ( );
            }

        }
        private void lupPerson_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e . KeyChar == 8 )
            {
                lupPerson . EditValue = null;
            }
        }
        private void toolCopy_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            clear ( );
            state = "copy";
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
            texProductName . Enabled = texProductNum . Enabled = texSpeci . Enabled = texUnit . Enabled = texColor . Enabled = texClass . Enabled =dtpStart.Enabled=dtpEnd.Enabled=lupPerson.Enabled=dtpStart.Enabled=dtpEnd.Enabled= true;
        }
        void controlUnEnable ( )
        {
            texProductName . Enabled = texProductNum . Enabled = texSpeci . Enabled = texUnit . Enabled = texColor . Enabled = texClass . Enabled = dtpStart . Enabled = dtpEnd . Enabled = lupPerson . Enabled = dtpStart . Enabled = dtpEnd . Enabled = false;
        }
        void clear ( )
        {
            texProductName . Text = texProductNum . Text = texSpeci . Text = texUnit . Text = texColor . Text = texClass . Text = dtpStart . Text = dtpEnd . Text = lupPerson . Text = dtpStart.Text=dtpEnd.Text= string . Empty;
        }
        void addTools ( )
        {
            DevExpress . XtraBars . BarButtonItem toolCopy = new DevExpress . XtraBars . BarButtonItem ( );
            System . ComponentModel . ComponentResourceManager resources = new System . ComponentModel . ComponentResourceManager ( typeof ( FormChild ) );
            barManager1 . Items . AddRange ( new DevExpress . XtraBars . BarItem [ ] {
            this.toolCopy} );
            barTool . LinksPersistInfo . AddRange ( new DevExpress . XtraBars . LinkPersistInfo [ ] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.toolCopy, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)} );
            this . toolCopy . ActAsDropDown = true;
            this . toolCopy . Caption = "复制";
            this . toolCopy . ItemAppearance . Normal . Font = new System . Drawing . Font ( "宋体" ,10.5F ,System . Drawing . FontStyle . Bold ,System . Drawing . GraphicsUnit . Point ,( ( byte ) ( 134 ) ) );
            this . toolCopy . ItemAppearance . Normal . ForeColor = System . Drawing . Color . Red;
            this . toolCopy . ItemAppearance . Normal . Options . UseFont = true;
            this . toolCopy . ItemAppearance . Normal . Options . UseForeColor = true;
            this . toolCopy . Id = 11;
            this . toolCopy . ImageOptions . Image = ( ( System . Drawing . Image ) ( resources . GetObject ( "barButtonItem1.ImageOptions.Image" ) ) );
            this . toolCopy . ImageOptions . LargeImage = ( ( System . Drawing . Image ) ( resources . GetObject ( "barButtonItem1.ImageOptions.LargeImage" ) ) );
            this . toolCopy . Name = "toolCopy";
        }
        bool checkTable ( )
        {
            result = true;
            if ( tableQueryTwo != null && tableQueryTwo . Rows . Count > 0 )
            {
                var query = from p in tableQueryTwo . AsEnumerable ( )
                            group p by new
                            {
                                p1 = p . Field<string> ( "WOR006" ) ,
                                p2 = p . Field<string> ( "WOR007" ) ,
                                p3 = p . Field<string> ( "WOR010" ) ,
                                p4 = p . Field<string> ( "WOR013" )
                            } into m
                            select new
                            {
                                wor006 = m . Key . p1 ,
                                wor007 = m . Key . p2 ,
                                wor010 = m . Key . p3 ,
                                wor013 = m . Key . p4 ,
                                count = m . Count ( )
                            };
                if ( query != null )
                {
                    foreach ( var x in query )
                    {
                        if ( x . count > 1 )
                        {
                            XtraMessageBox . Show ( "零件名称：" + x . wor006 + "\n\r长：" + x . wor007 + "\n\r宽：" + x . wor010 + "\n\r高：" + x . wor013 + "\n\r重复,请修正" ,"提示" );
                            result = false;
                            break;
                        }
                    }
                }
            }

            return result;
        }
        #endregion

    }
}




