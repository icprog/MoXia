using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormEmployee :FormChild
    {
        CarpenterBll . Bll . EmployeeBll _bll = null;
        CarpenterEntity . EmployeeEntity _model = null;
        string state=string.Empty;
        string statePrevious=string.Empty;
        DataTable tableQuery,print;
        int count=0;
        List<int> intList=new List<int>();
        bool isOk =false;


        public FormEmployee ( )
        {
            InitializeComponent ( );

            _bll = new CarpenterBll . Bll . EmployeeBll ( );
            _model = new CarpenterEntity . EmployeeEntity ( );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolExamin ,toolReview } );

            UnEnable ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            wait . Hide ( );
            //SetImage . setImage ( Concell1 . pictureBox1 ,"zhuxiao.png" );
            //Concell1 . Hide ( );
        }
        
        #region Main
        protected override int Add ( )
        {
            clear ( );
            Enable ( );

            addTool ( );         

            btnFirst . Enabled = false;
            btnLast . Enabled = false;
            btnNext . Enabled = false;
            btnPrevious . Enabled = false;

            //Concell1 . Hide ( );
            Graph . gra ( xtraTabControl1 ,"反" );
            tabPageOne . Refresh ( );

            state = "add";

            return 0;
        }
        protected override int Query ( )
        {
            toolQuery . Enabled = false;
            toolAdd . Enabled = false;

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return 0;
        }
        protected override int Edit ( )
        {
            Enable ( );

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
            if ( string . IsNullOrEmpty ( texNumPerson . Text ) )
            {
                XtraMessageBox . Show ( "请选择需要删除的用户" );
                return 0;
            }

            if ( XtraMessageBox . Show ( "确定要删除整条信息?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
            {
                bool result = _bll . Delete ( Convert . ToInt32 ( texNumPerson . Tag ) );
                if ( result == true )
                {
                    if ( gridView1 . DataRowCount < 1 )
                    {
                        ControlState . ControlClear ( tabPageOne );

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
                    Graph . gra ( xtraTabControl1 ,"反" );
                    tabPageOne . Refresh ( );
                    Query ( );
                }
                else
                    XtraMessageBox . Show ( "删除失败,请重试" );
            }

            return 0;
        }
        protected override int Save ( )
        {
            isOk = true;
            errorProvider1 . Clear ( );
            if ( string . IsNullOrEmpty ( texNumPerson . Text ) )
            {
                errorProvider1 . SetError ( texNumPerson ,"用户编号不可为空" );
                isOk = false;
            }
            if ( string . IsNullOrEmpty ( texNamePerson . Text ) )
            {
                errorProvider1 . SetError ( texNamePerson ,"用户姓名不可为空" );
                isOk = false;
            }
            decimal salary = 0M;
            if ( !string . IsNullOrEmpty ( texSalary . Text ) && decimal . TryParse ( texSalary . Text ,out salary ) == false )
            {
                errorProvider1 . SetError ( texSalary ,"请填写数字" );
                isOk = false;
            }
            if ( isOk == false )
                return 0;

            if ( texNamePerson . Text . Trim ( ) . Equals ( "系统管理员" ) )
            {
                XtraMessageBox . Show ( "系统管理员已经存在,请核实" );
                return 0;
            }

            serial ( _model );
            if ( state . Equals ( "add" ) )
            {
                //numOfPerson ( );

                if ( _bll . Exists ( _model . EMP001 ) == true )
                {
                    XtraMessageBox . Show ( "人员编号:" + _model . EMP001 + "已经存在,请核实" );
                    return 0;
                }

                _model . EMP009 = Utility . DesEncryptUtil . EncryptMD5 ( "123456" );
                _model . idx = _bll . Add ( _model );

                if ( _model . idx > 0 )
                {
                    texNumPerson . Tag = _model . idx;
                    isOk = true;
                }
                else
                    XtraMessageBox . Show ( "保存失败,请重试" );
            }
            else if ( state . Equals ( "edit" ) )
            {
                _model . idx = ( int ) texNumPerson . Tag;
                isOk = _bll . Edit ( _model );
                if ( isOk == false )
                    XtraMessageBox . Show ( "编辑失败,请重试" );
            }

            if ( isOk == true )
            {
                XtraMessageBox . Show ( "保存数据成功" );

                //ControlState . ControlUnEnable ( tabPageOne );

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

            if ( state . Equals ( "add" ) )
            {
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
                }
            }
            else if ( state . Equals ( "edit" ) )
            {
                UnEnable ( );
                btnFirst . Enabled = true;
                btnLast . Enabled = true;
                btnNext . Enabled = true;
                btnPrevious . Enabled = true;
                toolPrint . Visibility = toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }

            return 0;
        }
        protected override int Cancellation ( )
        {
            if ( string . IsNullOrEmpty ( texNumPerson . Tag . ToString ( ) ) )
            {
                XtraMessageBox . Show ( "请选择需要注销的用户" );
                return 0;
            }

            bool result = false;
            if ( toolCancellation . Caption . Equals ( "注销" ) )
            {
                result = _bll . Cancel ( Convert . ToInt32 ( texNumPerson . Tag ) ,true );
                if ( result == true )
                {
                    Graph . gra ( xtraTabControl1 ,"注销" );
                    tabPageOne . Refresh ( );
                    //Concell1 . Show ( );
                    Query ( );
                    cancelltionTool ( "反注销" );
                }
                else
                    XtraMessageBox . Show ( "注销失败" );
            }
            else if ( toolCancellation . Caption . Equals ( "反注销" ) )
            {
                result = _bll . Cancel ( Convert . ToInt32 ( texNumPerson . Tag ) ,false );
                if ( result == true )
                {
                    Graph . gra ( xtraTabControl1 ,"反" );
                    tabPageOne . Refresh ( );
                    //Concell1 . Hide ( );
                    Query ( );
                    cancelltionTool ( "注销" );
                }
                else
                    XtraMessageBox . Show ( "反注销失败" );
            }

            return 0;
        }
        protected override int Print ( )
        {
            if ( intList . Count < 1 )
            {
                if ( XtraMessageBox . Show ( "全部打印?" ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return 0;
                printOrExport ( );
            }
            else
                printOrExport ( );
            Print ( new DataTable [ ] { print } ,"人员信息.frx" );

            return base . Print ( );
        }
        protected override int Export ( )
        {
            if ( intList . Count < 1 )
            {
                if ( XtraMessageBox . Show ( "全部导出?" ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return 0;
                printOrExport ( );
            }
            else
                printOrExport ( );
            Export ( new DataTable [ ] { print } ,"人员信息.frx" );

            return base . Export ( );
        }
        #endregion

        #region Method
        void numOfPerson ( )
        {
            _model . EMP001 = _bll . GetNum ( );
            if ( string . IsNullOrEmpty ( _model . EMP001 ) )
                _model . EMP001 = "00001";
            else
            {
                _model . EMP001 = ( Convert . ToInt32 ( _model . EMP001 ) + 1 ) . ToString ( );
                _model . EMP001 = _model . EMP001 . PadLeft ( 5 ,'0' );
            }
            texNumPerson . Text = _model . EMP001;          
        }
        void serial ( CarpenterEntity . EmployeeEntity _model )
        {
            _model . EMP001 = texNumPerson . Text;
            _model . EMP002 = texNamePerson . Text;
            _model . EMP003 = texDepartNum . Text;
            _model . EMP004 = texTel . Text;
            _model . EMP005 = texPhone . Text;
            _model . EMP006 = texEmail . Text;
            _model . EMP007 = richRemark . Text;
            _model . EMP008 = false;
            _model . EMP010 = comSex . Text;
            _model . EMP011 = string . IsNullOrEmpty ( texSalary . Text ) == true ? 0 : Convert . ToDecimal ( texSalary . Text );
            _model . EMP012 = txtEMP012 . Text;
            statePrevious = _model . EMP001;
        }
        void assignMent ( DataRow row ,CarpenterEntity.EmployeeEntity _model)
        {
            if ( _model . idx < 0 )
                return;
            texNumPerson . Tag = _model . idx;
            texNumPerson . Text = row [ "EMP001" ] . ToString ( );
            texNamePerson . Text = row [ "EMP002" ] . ToString ( );
            texDepartNum.Text = row [ "EMP003" ] . ToString ( );
            texDepartName.Text= row [ "DEP002" ] . ToString ( );
            texTel.Text= row [ "EMP004" ] . ToString ( );
            texPhone.Text = row [ "EMP005" ] . ToString ( );
            texEmail.Text= row [ "EMP006" ] . ToString ( );
            richRemark.Text= row [ "EMP007" ] . ToString ( );
            comSex.Text= row [ "EMP010" ] . ToString ( );
            texSalary . Text = row [ "EMP011" ] . ToString ( );
            txtEMP012 . Text = row [ "EMP012" ] . ToString ( );
            _model . EMP008 = ( bool ) row [ "EMP008" ];
            if ( _model . EMP008 == true )
            {
                Graph . gra ( xtraTabControl1 ,"注销" );
                //Concell1 . Show ( );
                toolCancellation . Caption = "反注销";
            }
            else
            {
                Graph . gra ( xtraTabControl1 ,"反" );
                //Concell1 . Hide ( );
                toolCancellation . Caption = "注销";
            }
            tabPageOne . Refresh ( );
        }
        void printOrExport ( )
        {
            print = _bll . printOne ( intList );
            print . TableName = "TableOne";
        }
        void UnEnable ( )
        {
            texDepartName . Enabled = texDepartNum . Enabled = texNamePerson . Enabled = texNumPerson . Enabled = texTel . Enabled = texPhone . Enabled = texEmail . Enabled = richRemark . Enabled = comSex . Enabled = texSalary . Enabled =txtEMP012.Enabled= false;
        }
        void Enable ( )
        {
            texDepartName . Enabled = texDepartNum . Enabled = texNamePerson . Enabled = texNumPerson . Enabled = texTel . Enabled = texPhone . Enabled = texEmail . Enabled = richRemark . Enabled = comSex . Enabled = texSalary . Enabled = txtEMP012 . Enabled = true;
        }
        void clear ( )
        {
            texDepartName . Text = texDepartNum . Text = texNamePerson . Text = texNumPerson . Text = texTel . Text = texPhone . Text = texEmail . Text = richRemark . Text = comSex . Text = texSalary . Text = txtEMP012 . Text = string . Empty;
        }
        #endregion
        
        #region Event
        private void btnDepart_Click ( object sender ,EventArgs e )
        {
            Carpenter . Query . FormDepartQueryOfPerson form = new Carpenter . Query . FormDepartQueryOfPerson ( );
            form . StartPosition = FormStartPosition . CenterScreen;
            DialogResult result = form . ShowDialog ( );
            if ( result == System . Windows . Forms . DialogResult . OK )
            {
                CarpenterEntity . DepartMentEntity _model = form . GetModel;
                texDepartNum . Text = _model . DEP001;
                texDepartName . Text = _model . DEP002;
            }
        }
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            tableQuery = _bll . GetDataTableAll ( );
            //gridControl1 . DataSource = tableQuery;
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                toolQuery . Enabled = true;
                toolAdd . Enabled = true;

                tableQuery . Columns . Add ( "check" ,typeof ( System . Boolean ) );
                gridControl1 . DataSource = tableQuery;
                if ( gridView1 . DataRowCount > 0 )
                {

                    btnFirst . Enabled = true;
                    btnLast . Enabled = true;
                    btnNext . Enabled = true;
                    btnPrevious . Enabled = true;

                    DataRow row;
                    if ( statePrevious != "" )
                        row = tableQuery . Select ( "EMP001='" + statePrevious + "'" ) [ 0 ];
                    else
                        row = gridView1 . GetDataRow ( 0 );
                    
                    _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                    assignMent ( row ,_model );

                    QueryTool ( );
                    toolPrint . Visibility = toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                }             
            }
        }
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
            assignMent ( row ,_model );
            tabPageOne . Show ( );
            xtraTabControl1 . SelectedTabPageIndex = 0;
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
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            count = gridView1 . FocusedRowHandle;
            if ( count >= 0 && count <= gridView1 . DataRowCount - 1 )
            {
                DataRow row = gridView1 . GetDataRow ( count );
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                if ( row [ "check" ] . ToString ( ) == "True" )
                {
                    row [ "check" ] = false;
                    if ( intList . Contains ( _model . idx ) )
                        intList . Remove ( _model . idx );
                }
                else
                {
                    row [ "check" ] = true;
                    intList . Add ( _model . idx );
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

    }
}
