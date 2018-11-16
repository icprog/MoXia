
using DevExpress . XtraEditors;
using System;
using System . ComponentModel;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormArt :FormChild
    {
        CarpenterEntity.ArtEntity _model=new CarpenterEntity.ArtEntity();
        CarpenterEntity.AruEntity _modelOne=new CarpenterEntity.AruEntity();
        CarpenterBll.Bll.ArtBll _bll=new CarpenterBll.Bll.ArtBll();
        DataTable tableQuery,tableView;
        string state=string.Empty,statePrevious=string.Empty;
        int count=0;bool result=false, isOk = false;
        
        public FormArt ( )
        {
            InitializeComponent ( );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolExport ,toolPrint ,toolExamin ,toolReview  } );

            UnEnable ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            Utility . GridViewMoHuSelect . SetFilter ( gridView2 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            wait . Hide ( );

            gridView2 . OptionsBehavior . Editable = false;

            //SetImage . setImage ( Concell1 . pictureBox1 ,"zhuxiao.png" );
            //Concell1 . Hide ( );

            comNature . Properties . Items . Add ( "自制" );
            comNature . Properties . Items . Add ( "委外" );
            comType . Properties . Items . Add ( "计时" );
            comType . Properties . Items . Add ( "计件" );

            //cmdSalary . Properties . Items . Add ( "" );
            //foreach ( string s in CarpenterBll . ColumnValues . artSaType )
            //{
            //    cmdSalary . Properties . Items . Add ( s );
            //}
            foreach ( string s in CarpenterBll . ColumnValues . artSpaceType )
            {
                repositoryItemComboBox1 . Items . Add ( s );
            }
            checkSalary . Properties . Items . Add ( "" );
            foreach ( string s in CarpenterBll . ColumnValues . artSaType )
            {
                checkSalary . Properties . Items . Add ( s );
            }
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

            numOfPerson ( );

            addTool ( );

            btnFirst . Enabled = false;
            btnLast . Enabled = false;
            btnNext . Enabled = false;
            btnPrevious . Enabled = false;

            //Concell1 . Hide ( );
            Graph . gra ( splitContainerControl1 ,"反" ,1000 );
            splitContainerControl1 . Refresh ( );

            state = "add";

            tableView = _bll . tableView ( string . Empty );
            gridControl2 . DataSource = tableView;

            return base . Add ( );
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

            //tableView = _bll . tableView ( this . texNumArt . Text );
            //gridControl2 . DataSource = tableView;

            state = "edit";

            return 0;
        }
        protected override int Delete ( )
        {
            if ( string . IsNullOrEmpty ( texNumArt . Text ) )
            {
                XtraMessageBox . Show ( "请选择需要删除的工艺" );
                return 0;
            }

            if ( XtraMessageBox . Show ( "删除" ,"确定要删除整条信息?" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
            {
                bool result = _bll . Delete ( Convert . ToInt32 ( texNumArt . Tag ) );
                if ( result == true )
                {
                    if ( gridView1 . DataRowCount < 1 )
                    {
                        clear ( );

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

                    Query ( );
                }
                else
                    XtraMessageBox . Show ( "删除失败,请重试" );
            }

            return 0;
        }
        protected override int Save ( )
        {
             isOk= true;
            errorProvider1 . Clear ( );
            if ( string . IsNullOrEmpty ( texNumArt . Text ) )
            {
                errorProvider1 . SetError ( texNumArt ,"工艺编号不可为空" );
                isOk = false;
            }
            if ( string . IsNullOrEmpty ( texNameArt . Text ) )
            {
                errorProvider1 . SetError ( texNameArt ,"工艺名称不可为空" );
                isOk = false;
            }
            if ( isOk == false )
                return 0;

            if(checkView()==false)
                return 0;
            
            serial ( );
            if ( state .Equals( "add" ))
            {
                numOfPerson ( );
                _model . ART008 = false;
                result = _bll . Add ( _model ,tableView );

                if ( result )
                {
                    //texNumArt . Tag = _model . idx;
                    isOk = true;
                }
                else
                    XtraMessageBox . Show ( "保存失败,请重试" );
            }
            else if ( state .Equals( "edit" ))
            {
                _model . idx = ( int ) texNumArt . Tag;
                isOk = _bll . Edit ( _model ,tableView );
                if ( isOk == false )
                    XtraMessageBox . Show ( "编辑失败,请重试" );
            }

            if ( isOk == true )
            {
                XtraMessageBox . Show ( "保存数据成功" );

                UnEnable ( );
                btnFirst . Enabled = true;
                btnLast . Enabled = true;
                btnNext . Enabled = true;
                btnPrevious . Enabled = true;

                saveTool ( );
                //threadStart ( );
                Query ( );
            }

            return 0;
        }
        protected override int Cancel ( )
        {
            cancelTool ( state );
            
            if ( state .Equals( "add" ))
            {
                gridView2 . OptionsBehavior . Editable = false;
                clear ( );
                UnEnable ( );
                if ( gridView1 . DataRowCount > 0 )
                {
                    if ( count >= 0 && count <= gridView1 . DataRowCount - 1 )
                    {
                        DataRow row = gridView1 . GetDataRow ( count );
                        _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                        assignMent ( row ,_model );
                    }
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
                }
            }
            else if ( state .Equals( "edit" ))
            {
                gridView2 . OptionsBehavior . Editable = false;
                UnEnable ( );
                btnFirst . Enabled = true;
                btnLast . Enabled = true;
                btnNext . Enabled = true;
                btnPrevious . Enabled = true;
            }
            
            return 0;
        }
        protected override int Cancellation ( )
        {
            if ( string . IsNullOrEmpty ( texNumArt . Tag . ToString ( ) ) )
            {
                XtraMessageBox . Show ( "请选择需要注销的工艺" );
                return 0;
            }

            bool result = false;
            if ( toolCancellation . Caption .Equals( "注销" ))
            {
                result = _bll . Cancel ( Convert . ToInt32 ( texNumArt . Tag ) ,true );
                if ( result == true )
                {
                    Graph . gra ( splitContainerControl1 ,"注销" ,1000 );
                    splitContainerControl1 . Refresh ( );
                    //Concell1 . Show ( );
                    Query ( );
                }
                else
                    XtraMessageBox . Show ( "注销失败" );
            }
            else if ( toolCancellation . Caption .Equals( "反注销" ))
            {
                result = _bll . Cancel ( Convert . ToInt32 ( texNumArt . Tag ) ,false );
                if ( result == true )
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
            tableQuery = _bll . GetDataTable ( );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                gridView2 . OptionsBehavior . Editable = false;
                toolQuery . Enabled = true;
                toolAdd . Enabled = true;

                gridControl1 . DataSource = tableQuery;
                if ( gridView1 . DataRowCount > 0 )
                {
                    QueryTool ( );

                    btnFirst . Enabled = true;
                    btnLast . Enabled = true;
                    btnNext . Enabled = true;
                    btnPrevious . Enabled = true;

                    DataRow row;
                    if ( statePrevious != "" )
                        row = tableQuery . Select ( "ART001='" + statePrevious + "'" ) [ 0 ];
                    else
                        row = gridView1 . GetDataRow ( 0 );

                    CarpenterEntity . ArtEntity _model = new CarpenterEntity . ArtEntity ( );
                    _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                    assignMent ( row ,_model );
                }
            }
        }
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            int num = count = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                DataRow row = gridView1 . GetDataRow ( num );
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                assignMent ( row ,_model );
                TabPageOne . Show ( );
                xtraTabControl1 . SelectedTabPageIndex = 0;
            }
        }
        private void btnFirst_Click ( object sender ,EventArgs e )
        {
            count = 0;
            if ( count >= 0 && count <= gridView1 . DataRowCount - 1 )
            {
                DataRow row = gridView1 . GetDataRow ( count );
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                assignMent ( row ,_model );
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
                DataRow row = gridView1 . GetDataRow ( count );
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                assignMent ( row ,_model );
            }
        }
        private void btnNext_Click ( object sender ,EventArgs e )
        {
            if ( count < gridView1 . DataRowCount - 1 )
                count = count + 1;
            if ( count >= 0 && count <= gridView1 . DataRowCount - 1 )
            {
                DataRow row = gridView1 . GetDataRow ( count );
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                assignMent ( row ,_model );
            }
        }
        private void btnLast_Click ( object sender ,EventArgs e )
        {
            count = gridView1 . DataRowCount - 1;
            if ( count >= 0 && count <= gridView1 . DataRowCount - 1 )
            {
                DataRow row = gridView1 . GetDataRow ( count );
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                assignMent ( row ,_model );
            }
        }
        private void btnDepart_Click ( object sender ,EventArgs e )
        {
            Carpenter . Query . DepartSelection form = new Carpenter . Query . DepartSelection ( "工作中心查询" );
            DialogResult result = form . ShowDialog ( );
            if ( result == System . Windows . Forms . DialogResult . OK )
            {
                CarpenterEntity . DepartMentEntity _model = form . getDou;
                texDepartNum . Text = _model . DEP001;
                texDepartName . Text = _model . DEP002;
            }
        }
        private void texNumArt_TextChanged ( object sender ,EventArgs e )
        {
            
        }
        private void texNumArt_EditValueChanged ( object sender ,EventArgs e )
        {
            tableView = _bll . tableView ( this . texNumArt . Text );
            gridControl2 . DataSource = tableView;
        }
        private void gridControl2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            if ( e . KeyChar == 13 )
            {
                DataRow row = gridView2 . GetFocusedDataRow ( );
                if ( row != null )
                {
                    tableView . Rows . Remove ( row );
                    gridControl1 . RefreshDataSource ( );
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
        #endregion

        #region Method
        void numOfPerson ( )
        {
            _model . ART001 = _bll . GetNum ( );
            if ( string . IsNullOrEmpty ( _model . ART001 ) )
                _model . ART001 = "0001";
            else
            {
                _model . ART001 = ( Convert . ToInt32 ( _model . ART001 ) + 1 ) . ToString ( );
                _model . ART001 = _model . ART001 . PadLeft ( 4 ,'0' );
            }
            texNumArt . Text = _model . ART001;
        }
        void assignMent ( DataRow row ,CarpenterEntity . ArtEntity _model )
        {
            if ( _model . idx < 0 )
                return;
            texNumArt . Tag = _model . idx;
            texNumArt . Text = row [ "ART001" ] . ToString ( );
            texNameArt . Text = row [ "ART002" ] . ToString ( );     
            richArtExplain . Text = row [ "ART003" ] . ToString ( );
            comNature . Text = row [ "ART004" ] . ToString ( );
            comType . Text = row [ "ART005" ] . ToString ( );
            texDepartNum . Text = row [ "ART006" ] . ToString ( );
            texDepartName . Text = row [ "DEP002" ] . ToString ( );
            richRemark . Text = row [ "ART007" ] . ToString ( );
            checkSalary . Text = row [ "ART011" ] . ToString ( );
            _model . ART008 = ( bool ) row [ "ART008" ];
            if ( _model . ART008 == true )
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
        }
        void serial ( )
        {
            _model . ART001 = texNumArt . Text;
            _model . ART002 = texNameArt . Text;
            _model . ART003 = richArtExplain . Text;
            _model . ART004 = comNature . Text;
            _model . ART005 = comType . Text;
            _model . ART006 = texDepartNum . Text;
            _model . ART007 = richRemark . Text;
            _model . ART009 = DateTime . Now;
            _model . ART010 = UserLogin . userNum;
            _model . ART011 = checkSalary . Text;
        }
        bool checkView ( )
        {
            bool result = true;string spaceStandard = string . Empty;

            gridView2 . CloseEditor ( );
            gridView2 . UpdateCurrentRow ( );

            if ( gridView2 . DataRowCount > 0 )
            {
                if ( string . IsNullOrEmpty ( checkSalary . Text ) )
                {
                    XtraMessageBox . Show ( "请选择工资类型" );
                    result = false;
                    return result;
                }
            }

            DataRow row;

            for ( int i = 0 ; i < gridView2 . DataRowCount ; i++ )
            {
                row = gridView2 . GetDataRow ( i );
                row . ClearErrors ( );
                _modelOne . ARU002 = row [ "ARU002" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _modelOne . ARU002 ) )
                {
                    row . SetColumnError ( "ARU002" ,"请选择区间标准" );
                    result = false;
                    break;
                }
                if ( result == false )
                    break;
            }

            return result;
        }
        void UnEnable ( )
        {
            texNumArt . Enabled = texNameArt . Enabled = richArtExplain . Enabled = comNature . Enabled = comType . Enabled = texDepartNum . Enabled = richRemark . Enabled = checkSalary . Enabled = false;
        }
        void Enable ( )
        {
            texNumArt . Enabled = texNameArt . Enabled = richArtExplain . Enabled = comNature . Enabled = comType . Enabled = texDepartNum . Enabled = richRemark . Enabled = checkSalary . Enabled = true;
        }
        void clear ( )
        {
            texNumArt . Text = texNameArt . Text = richArtExplain . Text = comNature . Text = comType . Text = texDepartNum . Text = richRemark . Text = checkSalary . Text = string . Empty;
        }
        #endregion

    }
}
