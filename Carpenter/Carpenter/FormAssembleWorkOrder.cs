using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormAssembleWorkOrder :FormChild
    {
        CarpenterEntity .AssembleWorkOrderAWOEntity _awo=null;
        CarpenterEntity .AssembleWorkOrderAWQEntity _awq=null;
        CarpenterBll.Bll.AssembleWorkOrderBll _bll=null;
        DataTable tableViewTwo,printOne;bool isOk=false;
        int num=0;string state=string.Empty;
        List<string> strList=new List<string>();
        
        public FormAssembleWorkOrder ( )
        {
            InitializeComponent ( );

            _awo = new CarpenterEntity . AssembleWorkOrderAWOEntity ( );
            _awq = new CarpenterEntity . AssembleWorkOrderAWQEntity ( );
            _bll = new CarpenterBll . Bll . AssembleWorkOrderBll ( );
            tableViewTwo = new DataTable ( );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolAdd } );


            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            wait . Hide ( );
            Unenable ( );
            //SetImage . setImage ( Concell1 . pictureBox1 ,"zhuxiao.png" );
            //Concell1 . Hide ( );
            //SetImage . setImage ( Concell2 . pictureBox1 ,"shenhe.png" );
            //Concell2 . Hide ( );
        }
        
        #region Main
        protected override int Query ( )
        {
            toolQuery . Enabled = false;

            Carpenter . Query . FormControl from = new Carpenter . Query . FormControl ( "组装派工单查询" ,"FormAssembleWorkOrder" );
            if ( from . ShowDialog ( ) == System . Windows . Forms . DialogResult . OK )
            {
                workPerson . Tag = from . getOdd;
                _awo . AWO001 = from . getOdd;
                if ( !string . IsNullOrEmpty ( _awo . AWO001 ) )
                    backgroundWorker1 . RunWorkerAsync ( );
            }else
                toolQuery . Enabled = true;

            return base . Query ( );
        }
        protected override int Edit ( )
        {
            Enable ( );
            editTool ( );

            return base . Edit ( );
        }
        protected override int Delete ( )
        {
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            _awo . AWO001 = workPerson . Tag . ToString ( );
            isOk = _bll . Delete ( _awo . AWO001 );
            if ( isOk )
            {
                XtraMessageBox . Show ( "成功删除" );
                deleteTool ( );
                Clear ( );
                Unenable ( );
                Graph . gra ( splitContainerControl1 ,"反" );
                splitContainerControl1 . Panel1 . Refresh ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );


            return base . Delete ( );
        }
        protected override int Save ( )
        {
            if ( getValue ( ) == false )
                return 0;

            if ( checkNum ( ) == false )
                return 0;
            wait . Show ( );
            backgroundWorker2 . RunWorkerAsync ( );

            return base . Save ( );
        }
        protected override int Cancel ( )
        {
            cancelTool ( "edit" );
            Unenable ( );

            return base . Cancel ( );
        }
        protected override int Examine ( )
        {
            _awo . AWO001 = workPerson . Tag . ToString ( );
            if ( toolExamin . Caption . Equals ( "审核" ) )
            {
                state = "审核";
                _awo . AWO005 = true;
            }
            else
            {
                state = "反审核";
                _awo . AWO005 = false;
            }
            isOk = _bll . Examine ( _awo . AWO001 ,this . Name ,_awo . AWO005 );
            if ( isOk )
            {
                XtraMessageBox . Show ( "" + state + "成功" );
                if ( state . Equals ( "审核" ) )
                {
                    Graph . gra ( splitContainerControl1 ,"审核" );
                    //Concell2 . Show ( );
                }
                else if ( state . Equals ( "反审核" ) )
                {
                    Graph . gra ( splitContainerControl1 ,"反" );
                    //Concell2 . Hide ( );
                }

                splitContainerControl1 . Panel1 . Refresh ( );
                examineTool ( state );
            }
            else
                XtraMessageBox . Show ( "" + state + "失败" );


            return base . Examine ( );
        }
        protected override int Cancellation ( )
        {
            _awo . AWO001 = workPerson . Tag . ToString ( );
            if ( toolCancellation . Caption . Equals ( "注销" ) )
            {
                state = "注销";
                _awo . AWO006 = true;
            }
            else
            {
                state = "反注销";
                _awo . AWO006 = false;
            }
            isOk = _bll . Cancellation ( _awo . AWO001 ,_awo . AWO006 );
            if ( isOk )
            {
                XtraMessageBox . Show ( "" + state + "成功" );
                if ( state . Equals ( "注销" ) )
                {
                    Graph . gra ( splitContainerControl1 ,"注销" );
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
                XtraMessageBox . Show ( "" + state + "失败" );

            return base . Cancellation ( );
        }
        protected override int Review ( )
        {
            _awo . AWO001 = workPerson . Tag . ToString ( );

            Review ( _awo . AWO001 ,this . Name );

            return base . Review ( );
        }
        protected override int Print ( )
        {
            if ( printOrExport ( ) == false )
                return 0;
            Print ( new DataTable [ ] { printOne  } ,"组装派工单.frx" );

            return base . Print ( );
        }
        protected override int Export ( )
        {
            if ( printOrExport ( ) == false )
                return 0;
            Export ( new DataTable [ ] { printOne  } ,"组装派工单.frx" );

            return base . Export ( );
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
        private void gridControl1_KeyPress ( object sender ,System . Windows . Forms . KeyPressEventArgs e )
        {
            num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                if ( e . KeyChar == 13 )
                {
                    if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                        return;
                    tableViewTwo . Rows . RemoveAt ( num );
                    gridControl1 . RefreshDataSource ( );
                }
            }
        }
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            _awo = _bll . GetList ( _awo . AWO001 );
            tableViewTwo = _bll . tableViewTwo ( _awo . AWO001 );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                toolQuery . Enabled = true;
                tableViewTwo . Columns . Add ( "checks" ,typeof ( System . Boolean ) );
                gridControl1 . DataSource = tableViewTwo;
                DateTime dt;
                DateTime . TryParse ( _awo . AWO002 . ToString ( ) ,out dt );
                workStartDate . Text = dt . ToString ( "yyyy/MM/dd" );
                if ( _awo . AWO004 < DateTime . MinValue && _awo . AWO004 > DateTime . MaxValue || _awo . AWO004 == null || _awo . AWO004 . ToString ( ) == string . Empty )
                {
                    workEndDate . Text = string . Empty;
                }
                else
                {
                    DateTime . TryParse ( _awo . AWO004 . ToString ( ) ,out dt );
                    workEndDate . Text = dt . ToString ( "yyyy/MM/dd" );
                }
                workPerson . Text = _awo . AWO003;
                workPerson . Tag = _awo . AWO001;
                if ( _awo . AWO006 == true )
                {
                    Graph . gra ( splitContainerControl1 ,"注销" );
                    //Concell1 . Show ( );
                    toolCancellation . Caption = "反注销";
                }
                else
                {
                    //Concell1 . Hide ( );
                    toolCancellation . Caption = "注销";
                }
                if ( _awo . AWO005 == true )
                {
                    Graph . gra ( splitContainerControl1 ,"审核" );
                    //Concell2 . Show ( );
                    toolExamin . Caption = "反审核";
                }
                else
                {
                    //Concell2 . Hide ( );
                    toolExamin . Caption = "审核";
                }
                if ( _awo . AWO005 == false && _awo . AWO006 == false )
                    Graph . gra ( splitContainerControl1 ,"反" );
                splitContainerControl1 . Panel1 . Refresh ( );
                QueryTool ( );
            }
        }
        private void backgroundWorker2_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            isOk = _bll . Edit ( _awo  ,tableViewTwo );
        }
        private void backgroundWorker2_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                wait . Hide ( );
                if ( isOk )
                {
                    XtraMessageBox . Show ( "保存成功" );
                    saveTool ( );
                    Unenable ( );
                }
                else
                    XtraMessageBox . Show ( "保存失败" );
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            if ( gridView1 . OptionsBehavior . Editable == false )
            {
                num = gridView1 . FocusedRowHandle;
                if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
                {
                    _awq . idx = string . IsNullOrEmpty ( gridView1 . GetDataRow ( num ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( num ) [ "idx" ] . ToString ( ) );
                    if ( gridView1 . GetDataRow ( num ) [ "checks" ] . ToString ( ) == "True" )
                    {
                        gridView1 . GetDataRow ( num ) [ "checks" ] = false;
                        if ( strList . Contains ( _awq . idx . ToString ( ) ) )
                            strList . Remove ( _awq . idx . ToString ( ) );
                    }
                    else
                    {
                        gridView1 . GetDataRow ( num ) [ "checks" ] = true;
                        strList . Add ( _awq . idx . ToString ( ) );
                    }
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
        void Enable ( )
        {
            workStartDate . Enabled = workEndDate . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;
        }
        void Unenable ( )
        {
            workStartDate . Enabled = workEndDate . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;
        }
        void Clear ( )
        {
            workStartDate . Text = workEndDate . Text = workPerson . Text = string . Empty;
            tableViewTwo = null;
            gridControl1 . DataSource = tableViewTwo;
        }
        bool getValue ( )
        {
            isOk = true;
            _awo . AWO001 = _awq . AWQ001 =  workPerson . Tag . ToString ( );
            if ( string . IsNullOrEmpty ( workStartDate . Text ) )
                _awo . AWO002 = null;
            else
                _awo . AWO002 = Convert . ToDateTime ( workStartDate . Text );
            _awo . AWO003 = workPerson . Text . ToString ( );
            if ( string . IsNullOrEmpty ( workEndDate . Text ) )
                _awo . AWO004 = null;
            else
                _awo . AWO004 = Convert . ToDateTime ( workEndDate . Text );
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );
            if ( gridView1 . DataRowCount < 1 )
            {
                XtraMessageBox . Show ( "请选择产品" );
                return false;
            }
            DataRow row;
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                row = gridView1 . GetDataRow ( i );
                row . ClearErrors ( );
                if ( row != null )
                {
                    _awq . AWQ002 = row [ "AWQ002" ] . ToString ( );
                    _awq . AWQ003 = row [ "AWQ003" ] . ToString ( );
                    _awq . AWQ006 = string . IsNullOrEmpty ( row [ "AWQ006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "AWQ006" ] . ToString ( ) );
                    if ( _awq . AWQ006 == 0 )
                    {
                        row . SetColumnError ( "AWQ006" ,"数量不可为零" );
                        isOk = false;
                        break;
                    }
                    //num = _bll . GetNum ( _awq . AWQ002 ,_awq . AWQ003 ,_awq . AWQ001 );
                    //string str = "剩:" + num + "";
                    //if ( num < _awq . AWQ006 )
                    //{
                    //    row . SetColumnError ( "AWQ006" ,"" + str + "" );
                    //    isOk = false;
                    //    break;
                    //}
                }
            }

            return isOk;
        }
        bool printOrExport ( )
        {
            isOk = true;
            _awo . AWO001 = workPerson . Tag . ToString ( );
            printOne = _bll . printOne ( "'" + _awo . AWO001 + "'" );
            printOne . TableName = "TableOne";

            return isOk;
        }
        bool checkNum ( )
        {
            isOk = true;
            if ( gridView1 . DataRowCount > 0 )
            {
                _awq . AWQ002 = gridView1 . GetDataRow ( 0 ) [ "AWQ002" ] . ToString ( );
                _awq . AWQ003 = gridView1 . GetDataRow ( 0 ) [ "AWQ003" ] . ToString ( );
                _awq . AWQ006 = _bll . proNum ( _awq . AWQ002 ,_awq . AWQ003 ,_awq . AWQ001 );
                int sumNum = 0;
                DataRow row;
                for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
                {
                    row = gridView1 . GetDataRow ( i );
                    row . ClearErrors ( );
                    if ( row != null )
                    {
                        num = string . IsNullOrEmpty ( row [ "AWQ006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "AWQ006" ] . ToString ( ) );
                        sumNum += num;
                        if ( num > _awq . AWQ006 )
                        {
                            row . SetColumnError ( "AWQ006" ,"数量多于剩余数量" );
                            isOk = false;
                            break;
                        }
                        if ( sumNum > _awq . AWQ006 )
                        {
                            row . SetColumnError ( "AWQ006" ,"总数量多于剩余数量" );
                            isOk = false;
                            break;
                        }
                    }
                }
            }
            else
                isOk = false;

            return isOk;
        }
        #endregion

    }
}


/*
 组装派工单：                        
 1、同批号、品号可以生成多张派工单、依据派工单数量之和=订单量为结束标记    
 2、派工单、日计划报工一致。选择产品，根据所选产品、查找此产品在派工单的员工、勾选做报工                        
 3、派工单打印需要勾选一个员工和多个产品      
 
1、日计划有了才能有派工单    
*/
