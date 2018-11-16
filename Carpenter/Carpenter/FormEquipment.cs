using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . Data;
using System . Reflection;
using System . Windows . Forms;
using System . ComponentModel;

namespace Carpenter
{
    //全部打印：不选择直接打印即可
    public partial class FormEquipment :FormChild
    {
        DataTable tableQuery,tableQueryV,table,print;
        CarpenterBll . Bll . EquipmentBll _bll = new CarpenterBll . Bll . EquipmentBll ( );
        CarpenterEntity.EquimentEntity _modelOne=new CarpenterEntity.EquimentEntity();
        CarpenterEntity.EquimentChildEntity _modelTwo=new CarpenterEntity.EquimentChildEntity();
        string state=string.Empty,statePrevious=string.Empty;
        bool isOk=true;
        int count=0;
        List<int> intList=new List<int>();
        List<int> idxList=new List<int>();
        
        public FormEquipment ( )
        {
            InitializeComponent ( );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolExamin ,toolReview } );

            UnEable ( );
            gridView2 . OptionsBehavior . Editable = false;

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            //Utility . GridViewMoHuSelect . SetFilter ( gridView2 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            wait . Hide ( );
            //SetImage . setImage ( Concell1 . pictureBox1 ,"zhuxiao.png" );
            //Concell1 . Hide ( );

            table = _bll . GetDataTableArt ( );
            repositoryItemGridLookUpEdit1 . DataSource = table;
            repositoryItemGridLookUpEdit1 . DisplayMember = "ART001";
            repositoryItemGridLookUpEdit1 . ValueMember = "ART";

            DataTable tableWork = _bll . GetDataTableWork ( );
            if ( tableWork != null && tableWork . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < tableWork . Rows . Count ; i++ )
                {
                    cmdEquWork . Properties . Items . Add ( tableWork . Rows [ i ] [ "DEP002" ] . ToString ( ) );
                }
            }

            Utility . GridViewMoHuSelect . SetFilter ( repositoryItemGridLookUpEdit1View );
            gridViewTwo ( );
        }
        
        private void FormEquipment_Load ( object sender ,EventArgs e )
        {
            comState . Properties . Items . Add ( "正常" );
            comState . Properties . Items . Add ( "维修" );
            comState . Properties . Items . Add ( "报废" );
        }

        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;
            toolAdd . Enabled = false;

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return 0;
        }
        protected override int Add ( )
        {
            clear ( );
            Enable ( );
            gridView2 . OptionsBehavior . Editable = true;
            tableQueryV . Rows . Clear ( );
            gridControl2 . RefreshDataSource ( );

            //numOfEqui ( );

            //Concell1 . Hide ( );
            Graph . gra ( splitContainerControl1 ,"" ,10000 );
            splitContainerControl1 . Refresh ( );

            addTool ( );
            btnFirst . Enabled = false;
            btnLast . Enabled = false;
            btnNext . Enabled = false;
            btnPrevious . Enabled = false;

            state = "add";

            return 0;
        }
        protected override int Edit ( )
        {
            Enable ( );
            gridView2 . OptionsBehavior . Editable = true;
            editTool ( );
            btnFirst . Enabled = false;
            btnLast . Enabled = false;
            btnNext . Enabled = false;
            btnPrevious . Enabled = false;

            state = "edit";

            return 0;
        }
        protected override int Delete ( )
        {
            if ( string . IsNullOrEmpty ( texNumEqui . Text ) )
            {
                XtraMessageBox . Show ( "请选择需要删除的设备" );
                return 0;
            }
            if ( XtraMessageBox . Show ( "确定要删除整条信息?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
            {
                bool result = _bll . Delete ( Convert . ToInt32 ( texNumEqui . Tag ) );
                if ( result == true )
                {
                    //gridView2 . OptionsBehavior . Editable = false;
                    if ( gridView1 . DataRowCount <= 1 )
                    {
                        clear ( );

                        toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                        toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                        toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                        toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                        toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                        toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                        toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                        btnFirst . Enabled = false;
                        btnLast . Enabled = false;
                        btnNext . Enabled = false;
                        btnPrevious . Enabled = false;
                    }
                    else
                    {
                        btnFirst . Enabled = true;
                        btnLast . Enabled = true;
                        btnNext . Enabled = true;
                        btnPrevious . Enabled = true;
                    }
                    statePrevious = string . Empty;
                    Query ( );
                }
                else
                    XtraMessageBox . Show ( "删除失败,请重试" );
            }

            return 0;
        }
        protected override int Save ( )
        {
            errorProvider1 . Clear ( );
            isOk = true;
            if ( string . IsNullOrEmpty ( texNumEqui . Text ) )
            {
                errorProvider1 . SetError ( texNumEqui ,"设备编号不可为空" );
                isOk = false;
            }
            if ( string . IsNullOrEmpty ( texNameEqui . Text ) )
            {
                errorProvider1 . SetError ( texNumEqui ,"设备名称不可为空" );
                isOk = false;
            }
            if ( isOk == false )
                return 0;

            
            gridView2 . CloseEditor ( );
            gridView2 . UpdateCurrentRow ( );

            serial ( );
            
            if ( state . Equals ( "add" ) )
            {
                isOk = _bll . Exists ( _modelOne . EQU001 );
                if ( isOk == true )
                {
                    XtraMessageBox . Show ( "此设备编号已经存在" );
                    return 0;
                }
                //numOfEqui ( );
                _modelOne . EQU007 = false;
                isOk = false;
                wait . Show ( );
                backgroundWorker2 . RunWorkerAsync ( );
            }
            else if ( state . Equals ( "edit" ) )
            {
                isOk = _bll . getIdxCount ( _modelOne . EQU001 );
                if ( isOk == true )
                {
                    XtraMessageBox . Show ( "此设备编号已经存在,不允许编辑" );
                    return 0;
                }
                isOk = false;
                wait . Show ( );
                backgroundWorker3 . RunWorkerAsync ( );
            }

            return 0;
        } 
        protected override int Cancel ( )
        {
            if ( state .Equals( "add" ))
            {
                clear ( );
                UnEable ( );
                gridView2 . OptionsBehavior . Editable = false;
                tableQueryV = null;
                gridControl2 . DataSource = tableQueryV = null;
                if ( gridView1 . DataRowCount > 0 )
                {
                    if ( count >= 0 && count <= gridView1 . DataRowCount - 1 )
                    {
                        CarpenterEntity .EquimentEntity _model = new CarpenterEntity . EquimentEntity ( );
                        DataRow row = gridView1 . GetDataRow ( count );
                        _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                        assignMent ( _model ,row );
                    }
                    toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                    toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                    toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                    toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                    toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                    toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                    toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                    btnFirst . Enabled = true;
                    btnLast . Enabled = true;
                    btnNext . Enabled = true;
                    btnPrevious . Enabled = true;
                }
                else
                {
                    btnFirst . Enabled = false;
                    btnLast . Enabled = false;
                    btnNext . Enabled = false;
                    btnPrevious . Enabled = false;

                    cancelTool ( "add" );
                }
            }
            else if ( state .Equals( "edit" ))
            {
                UnEable ( );
                gridView2 . OptionsBehavior . Editable = false;

                btnFirst . Enabled = true;
                btnLast . Enabled = true;
                btnNext . Enabled = true;
                btnPrevious . Enabled = true;
                cancelTool ( "edit" );
            }

            Query ( );

            return 0;
        }
        protected override int Cancellation ( )
        {
            if ( string . IsNullOrEmpty ( texNumEqui . Tag . ToString ( ) ) )
            {
                XtraMessageBox . Show ( "请选择需要注销的设备" );
                return 0;
            }
            if ( toolCancellation . Caption .Equals( "注销" ))
            {
                isOk = _bll . Cancel ( Convert . ToInt32 ( texNumEqui . Tag ) ,true );
                if ( isOk == true )
                {
                    Graph . gra ( splitContainerControl1 ,"注销" ,1000 );
                    splitContainerControl1 . Refresh ( );
                    //Concell1 . Show ( );
                    Query ( );
                }
                else
                    XtraMessageBox . Show ( "注销失败" );
            }
            else if ( toolCancellation . Caption . Equals( "反注销" ))
            {
                isOk = _bll . Cancel ( Convert . ToInt32 ( texNumEqui . Tag ) ,false );
                if ( isOk == true )
                {
                    Graph . gra ( splitContainerControl1 ,"反" ,1000 );
                    splitContainerControl1 . Refresh ( );
                    //Concell1 . Hide ( );
                    Query ( );
                }
                else
                    XtraMessageBox . Show ( "反注销失败" );
            }

            return 0;
        }
        protected override int Print ( )
        {
            getCheckInfo ( );
            if ( intList . Count < 1 )
            {
                if ( XtraMessageBox . Show ( "全部打印?" ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return 0;
                printOrExport ( );
            }
            else
                printOrExport ( );

            Print ( new DataTable [ ] { print } ,"设备信息.frx" );

            return base . Print ( );
        }
        protected override int Export ( )
        {
            getCheckInfo ( );
            if ( intList . Count < 1 )
            {
                if ( XtraMessageBox . Show ( "全部导出?" ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return 0;
                printOrExport ( );
            }
            else
                printOrExport ( );

            Export ( new DataTable [ ] { print } ,"设备信息.frx" );

            return base . Export ( );
        }
        #endregion

        #region Event
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            tableQuery = _bll . GetDataTable ( );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                toolQuery . Enabled = true;
                toolAdd . Enabled = true;
                //tableQuery . Columns . Add ( "check" ,typeof ( System . Boolean ) );
                gridControl1 . DataSource = tableQuery;
                gridViewTwo ( );
                if ( gridView1 . DataRowCount > 0 )
                {
                    QueryTool ( );
                    toolPrint . Visibility = toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                    btnFirst . Enabled = true;
                    btnLast . Enabled = true;
                    btnNext . Enabled = true;
                    btnPrevious . Enabled = true;
                    gridView2 . OptionsBehavior . Editable = false;

                    DataRow row;
                    if ( statePrevious != "" )
                        row = tableQuery . Select ( "EQU001='" + statePrevious + "'" ) [ 0 ];
                    else
                        row = gridView1 . GetDataRow ( 0 );

                    _modelOne . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                    assignMent ( _modelOne ,row );
                }
            }
        }
        private void gridView2_CellValueChanged ( object sender ,DevExpress . XtraGrid . Views . Base . CellValueChangedEventArgs e )
        {
            if ( e . Column . FieldName == "EQV002" )
            {
                string pqf01 = gridView2 . GetFocusedRowCellValue ( "EQV002" ) . ToString ( );
                for ( int i = 0 ; i < gridView2 . DataRowCount ; i++ )
                {
                    if ( pqf01 != "" && e . RowHandle != i && pqf01 == gridView2 . GetDataRow ( i ) [ "EQV002" ] . ToString ( ) )
                    {
                        XtraMessageBox . Show ( "工艺:" + EQV002 + "已经存在" );
                        pqf01 = "";
                        gridView2 . SetRowCellValue ( e . RowHandle ,"EQV002" ,"" );
                        gridView2 . DeleteRow ( e . RowHandle );
                        break;
                    }
                }
                DataRow [ ] row = table . Select ( string . Format ( "ART001='{0}'" ,pqf01 ) );
                if ( row != null && row . Length > 0 )
                {
                    DataRow rows = row [ 0 ];
                    gridView2 . SetRowCellValue ( e . RowHandle ,"EQV003" ,rows [ "ART002" ] . ToString ( ) );
                }
            }
        }
        private void backgroundWorker2_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            //serial ( );        
            isOk = _bll . Add ( _modelOne ,tableQueryV );
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                if ( isOk == true )
                {
                    wait . Hide ( );

                    XtraMessageBox . Show ( "新增成功" );

                    UnEable ( );
                    gridView2 . OptionsBehavior . Editable = false;

                    btnFirst . Enabled = true;
                    btnLast . Enabled = true;
                    btnNext . Enabled = true;
                    btnPrevious . Enabled = true;
                    saveTool ( );

                    Query ( );
                }
                else
                    XtraMessageBox . Show ( "新增数据失败,请重试" );
            }
        }
        private void backgroundWorker3_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            //serial ( );
            isOk = _bll . Edit ( _modelOne ,tableQueryV ,idxList );
        }
        private void backgroundWorker3_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                if ( isOk == true )
                {
                    wait . Hide ( );

                    XtraMessageBox . Show ( "编辑成功" );

                    UnEable ( );
                    gridView2 . OptionsBehavior . Editable = false;
                    btnFirst . Enabled = true;
                    btnLast . Enabled = true;
                    btnNext . Enabled = true;
                    btnPrevious . Enabled = true;
                    saveTool ( );

                    Query ( );
                }
                else
                    XtraMessageBox . Show ( "编辑数据失败,请重试" );
            }
        }
        private void btnFirst_Click ( object sender ,EventArgs e )
        {
            count = 0;
            if ( count >= 0 && count <= gridView1 . DataRowCount - 1 )
            {
                CarpenterEntity . EquimentEntity _model = new CarpenterEntity . EquimentEntity ( );
                DataRow row = gridView1 . GetDataRow ( count );
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                assignMent ( _model ,row );
            }
        }
        private void btnPrevious_Click ( object sender ,EventArgs e )
        {
            if ( count == 0 )
                return;
            if ( count > 0 )
                count = count - 1;
            if ( count >= 0 && count <= gridView1 . DataRowCount - 1 )
            {
                CarpenterEntity . EquimentEntity _model = new CarpenterEntity . EquimentEntity ( );
                DataRow row = gridView1 . GetDataRow ( count );
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                assignMent ( _model ,row );
            }
        }
        private void btnNext_Click ( object sender ,EventArgs e )
        {
            if ( count < gridView1 . DataRowCount - 1 )
                count = count + 1;
            if ( count >= 0 && count <= gridView1 . DataRowCount - 1 )
            {
                CarpenterEntity . EquimentEntity _model = new CarpenterEntity . EquimentEntity ( );
                DataRow row = gridView1 . GetDataRow ( count );
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                assignMent ( _model ,row );
            }
        }
        private void btnLast_Click ( object sender ,EventArgs e )
        {
            count = gridView1 . DataRowCount - 1;
            if ( count >= 0 && count <= gridView1 . DataRowCount - 1 )
            {
                CarpenterEntity . EquimentEntity _model = new CarpenterEntity . EquimentEntity ( );
                DataRow row = gridView1 . GetDataRow ( count );
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                assignMent ( _model ,row );
            }
        }
        private void gridView2_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridControl2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DataRow row = gridView2 . GetFocusedDataRow ( );
            //count = gridView2 . FocusedRowHandle;
            //if ( count >= 0 && count <= gridView2 . DataRowCount - 1 )
            //{
            //Enter
            if ( e . KeyChar == 13 )
            {
                if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
                {
                    _modelOne . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                    idxList . Add ( _modelOne . idx );
                    tableQueryV . Rows . Remove ( row );
                    gridControl2 . RefreshDataSource ( );
                }
            }
            //}
        }
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            count = gridView1 . FocusedRowHandle;
            if ( count >= 0 && count <= gridView1 . DataRowCount - 1 )
            {
                DataRow row = gridView1 . GetDataRow ( count );
                _modelOne.idx= string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                assignMent ( _modelOne ,row );
                TabPageOne . Show ( );
                xtraTabControl1.SelectedTabPageIndex  = 0;
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            //count = gridView1 . FocusedRowHandle;
            //if ( count >= 0 && count <= gridView1 . DataRowCount - 1 )
            //{
            //    DataRow row = gridView1 . GetDataRow ( count );
            //    _modelOne . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
            //    if ( row [ "check" ] . ToString ( ) == "True" )
            //    {
            //        row [ "check" ] = false;
            //        if ( intList . Contains ( _modelOne . idx ) )
            //            intList . Remove ( _modelOne . idx );
            //    }
            //    else
            //    {
            //        row [ "check" ] = true;
            //        intList . Add ( _modelOne . idx );
            //    }
            //}
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
        void numOfEqui ( )
        {
            _modelOne . EQU001 = _bll . GetNum ( );
            if ( string . IsNullOrEmpty ( _modelOne . EQU001 ) )
                _modelOne . EQU001 = "0001";
            else
            {
                _modelOne . EQU001 = ( Convert . ToInt32 ( _modelOne . EQU001 ) + 1 ) . ToString ( );
                _modelOne . EQU001 = _modelOne . EQU001 . PadLeft ( 4 ,'0' );
            }
            texNumEqui . Text = _modelOne . EQU001;
        }
        void assignMent ( CarpenterEntity . EquimentEntity _modelOne ,DataRow row )
        {
            if ( row == null )
                return;
            texNumEqui . Tag = _modelOne . idx;
            texNumEqui . Text = row [ "EQU001" ] . ToString ( );
            texNameEqui . Text = row [ "EQU002" ] . ToString ( );
            texTypeEqui . Text = row [ "EQU003" ] . ToString ( );
            comState . Text = row [ "EQU004" ] . ToString ( );
            cmdEquWork . Text = row [ "EQU005" ] . ToString ( );
            mEdit . Text = row [ "EQU010" ] . ToString ( );
            _modelOne . EQU007 = ( bool ) row [ "EQU007" ];
            if ( _modelOne . EQU007 == true )
            {
                Graph . gra ( splitContainerControl1 ,"注销" ,1000 );
                splitContainerControl1 . Refresh ( );
                //Concell1 . Show ( );
                toolCancellation . Caption = "反注销";
                toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            }
            else
            {
                Graph . gra ( splitContainerControl1 ,"反" ,1000 );
                splitContainerControl1 . Refresh ( );
                //Concell1 . Hide ( );
                toolCancellation . Caption = "注销";
                toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
            gridViewTwo ( );
        }
        void gridViewTwo ( )
        {
            tableQueryV = _bll . GetDataTableV ( texNumEqui . Text );
            gridControl2 . DataSource = tableQueryV;
        }
        void serial ( )
        {
            _modelOne . idx = texNumEqui . Tag == null ? 0 : Convert . ToInt32 ( texNumEqui . Tag );
            _modelOne . EQU001 = texNumEqui . Text;
            _modelOne . EQU002 = texNameEqui . Text;
            _modelOne . EQU003 = texTypeEqui . Text;
            _modelOne . EQU004 = comState . Text;
            _modelOne . EQU005 = cmdEquWork . Text;
            _modelOne . EQU008 = DateTime . Now;
            _modelOne . EQU009 = UserLogin . userName;
            _modelOne . EQU010 = mEdit . Text;
            statePrevious = _modelOne . EQU001;
        }
        void printOrExport ( )
        {
            print = _bll . PrintOne ( intList );
            print . TableName = "TableOne";
        }
        void UnEable ( )
        {
            texNumEqui . Enabled = texNameEqui . Enabled = texTypeEqui . Enabled = comState . Enabled = cmdEquWork . Enabled = mEdit . Enabled = false;
        }
        void Enable ( )
        {
            texNumEqui . Enabled = texNameEqui . Enabled = texTypeEqui . Enabled = comState . Enabled = cmdEquWork . Enabled = mEdit . Enabled = true;
        }
        void clear ( )
        {
            texNumEqui . Text = texNameEqui . Text = texTypeEqui . Text = comState . Text = cmdEquWork . Text = mEdit . Text = string . Empty;
        }
        void getCheckInfo ( )
        {
            int [ ] rows = gridView1 . GetSelectedRows ( );
            if ( rows . Length > 0 )
            {
                foreach ( int i in rows )
                {
                    _modelOne . idx = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                    intList . Add ( _modelOne . idx );
                }
            }
        }
        #endregion

    }
}
