
using Carpenter . OrderEdit;
using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . Data;
using System . Reflection;
using System . Threading;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormOPI :FormChild
    {
        CarpenterEntity.OPIEntity _model=new CarpenterEntity.OPIEntity();
        CarpenterBll.Bll.OPIBll _bll=new CarpenterBll.Bll.OPIBll();
        int num=0; DataTable tableQuery;
        bool result=false; string strWhere = "1=1";
        
        public FormOPI ( )
        {
            InitializeComponent ( );


            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave ,toolPrint ,toolExamin ,toolReview } );

            wait . Hide ( );
            //SetImage . setImage ( Concell1 . pictureBox1 ,"zhuxiao.png" );
            //Concell1 . Hide ( );

            comstate . Properties . Items . Add ( "" );
            comstate . Properties . Items . Add ( "在产" );
            comstate . Properties . Items . Add ( "停产" );
            comstate . Properties . Items . Add ( "样品" );
            comUnit . Properties . Items . Add ( "" );
            comUnit . Properties . Items . Add ( "PCS" );
            comUnit . Properties . Items . Add ( "平方" );
            comUnit . Properties . Items . Add ( "立方" );
            comUnit . Properties . Items . Add ( "公斤" );
            comClass . Properties . Items . Add ( "" );
            comClass . Properties . Items . Add ( "木材" );
            comClass . Properties . Items . Add ( "油漆" );
            comClass . Properties . Items . Add ( "成品" );
            comAtt . Properties . Items . Add ( "" );
            comAtt . Properties . Items . Add ( "常规" );
            comAtt . Properties . Items . Add ( "定制" );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );
        }
        
        public delegate void gridControlDelegate ( );
        
        private void FormOPI_Load ( object sender ,EventArgs e )
        {
            Thread thread = new Thread ( new ThreadStart ( readQuery ) );
            thread . Start ( );
        }

        void readQuery ( )
        {
            try
            {
                Thread . Sleep ( 1000 );
                gridControlDelegate gD = new gridControlDelegate ( queryColumn );
                BeginInvoke ( gD ,null );
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteLog ( ex . StackTrace );
            }
        }

        void queryColumn ( )
        {           
            lupProduct . Properties . DataSource = _bll . GetDataTableOne ( );
            lupProduct . Properties . DisplayMember = "OPI002";
            lupProduct . Properties . ValueMember = "OPI001";
            lupSpeci . Properties . DataSource = _bll . GetDataTableOnly ( "OPI005" );
            lupSpeci . Properties . DisplayMember = "OPI005";
            lupType . Properties . DataSource = _bll . GetDataTableOnly ( "OPI003" );
            lupType . Properties . DisplayMember = "OPI003";
            lupColor . Properties . DataSource = _bll . GetDataTableOnly ( "OPI006" );
            lupColor . Properties . DisplayMember = "OPI006";

        }
        
        #region Main
        protected override int Query ( )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupProduct . Text ) )
            {
                strWhere = strWhere + " AND OPI001='" + lupProduct . EditValue . ToString ( ) + "'";
            }
            if ( !string . IsNullOrEmpty ( comClass . Text ) )
            {
                strWhere = strWhere + " AND OPI010='" + comClass . Text + "'";
            }
            if ( !string . IsNullOrEmpty ( lupColor . Text ) )
            {
                strWhere = strWhere + " AND OPI006='" + lupColor . Text + "'";
            }
            if ( !string . IsNullOrEmpty ( comAtt . Text ) )
            {
                strWhere = strWhere + " AND OPI009='" + comAtt . Text + "'";
            }
            if ( !string . IsNullOrEmpty ( lupSpeci . Text ) )
            {
                strWhere = strWhere + " AND OPI005='" + lupSpeci . Text + "'";
            }
            if ( !string . IsNullOrEmpty ( comstate . Text ) )
            {
                strWhere = strWhere + " AND OPI008='" + comstate . Text + "'";
            }
            if ( !string . IsNullOrEmpty ( lupType . Text ) )
            {
                strWhere = strWhere + " AND OPI003='" + lupType . Text + "'";
            }
            if ( !string . IsNullOrEmpty ( comUnit . Text ) )
            {
                strWhere = strWhere + " AND OPI007='" + comUnit . Text + "'";
            }

            queryColumn ( );

            lupProduct . EditValue = null;

            toolQuery . Enabled = false;
            toolAdd . Enabled = false;

            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return 0;
        }
        protected override int Add ( )
        {
            if ( tableQuery == null )
                tableQuery = _bll . GetDataTable ( "1=2" );
            //numOfProduct ( );
            Carpenter . Query . OPIEdit form = new Carpenter . Query . OPIEdit ( "新增" ,_model ,false );
            DialogResult result = form . ShowDialog ( );
            if ( result == System . Windows . Forms . DialogResult . OK )
            {
                _model = form . getModel;
                if ( tableQuery == null )
                    Query ( );
                else
                {
                    DataRow row = tableQuery . NewRow ( );
                    row [ "idx" ] = _model . idx;
                    row [ "OPI001" ] = _model . OPI001;
                    row [ "OPI002" ] = _model . OPI002;
                    row [ "OPI003" ] = _model . OPI003;
                    row [ "OPI004" ] = _model . OPI004;
                    row [ "OPI005" ] = _model . OPI005;
                    row [ "OPI006" ] = _model . OPI006;
                    row [ "OPI007" ] = _model . OPI007;
                    row [ "OPI008" ] = _model . OPI008;
                    row [ "OPI009" ] = _model . OPI009;
                    row [ "OPI010" ] = _model . OPI010;
                    row [ "OPI011" ] = _model . OPI011;
                    row [ "OPI012" ] = _model . OPI012;
                    tableQuery . Rows . Add ( row );
                    toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                }
            }

            return 0;
        }
        protected override int Edit ( )
        {
            if ( _model . idx < 1 )
            {
                XtraMessageBox . Show ( "请选择需要编辑的内容" );
                return 0;
            }
            result = false;
            if ( _bll . Exists ( _model . idx ) )
                result = true;
            edit ( );
            toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;

            return 0;
        }
        protected override int Delete ( )
        {
            if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            if ( _model . idx < 1 )
            {
                XtraMessageBox . Show ( "请选择需要删除的内容" );
                return 0;
            }
            if ( _bll . Exists ( _model . idx ) )
            {
                XtraMessageBox . Show ( "此产品已经在BOM清单或开料周计划中存在,不允许删除" );
                return 0;
            }
            result = _bll . Delete ( _model . idx );
            if ( result == true )
            {
                XtraMessageBox . Show ( "成功删除" );
                //gridView1 . DeleteRow ( num );
                tableQuery . Rows . RemoveAt ( num );
            }
            else
                XtraMessageBox . Show ( "删除失败,请重试" );

            return 0;
        }
        protected override int Cancellation ( )
        {
            if ( _model . idx < 1 )
            {
                XtraMessageBox . Show ( "请选择需要删除的内容" );
                return 0;
            }
            if ( toolCancellation . Caption == "注销" )
            {
                _model . OPI011 = true;
                result = _bll . Cancellation ( _model . idx ,_model . OPI011 );
                if ( result == true )
                {
                    XtraMessageBox . Show ( "注销成功" );
                    Graph . gra ( splitContainerControl1 ,"注销" );
                    splitContainerControl1 . Panel1 . Refresh ( );
                    //Concell1 . Show ( );
                    toolCancellation . Caption = "反注销";
                    DataRow row = tableQuery . Rows [ num ];
                    row . BeginEdit ( );
                    row [ "OPI011" ] = _model . OPI011;
                    row . EndEdit ( );
                }
                else
                    XtraMessageBox . Show ( "注销失败,请重试" );
            }
            else if ( toolCancellation . Caption == "反注销" )
            {
                _model . OPI011 = false;
                result = _bll . Cancellation ( _model . idx ,_model . OPI011 );
                if ( result == true )
                {
                    XtraMessageBox . Show ( "反注销成功" );
                    Graph . gra ( splitContainerControl1 ,"反" );
                    splitContainerControl1 . Panel1 . Refresh ( );
                    //Concell1 . Show ( );
                    toolCancellation . Caption = "注销";
                    DataRow row = tableQuery . Rows [ num ];
                    row . BeginEdit ( );
                    row [ "OPI011" ] = _model . OPI011;
                    row . EndEdit ( );
                }
                else
                    XtraMessageBox . Show ( "反注销失败,请重试" );
            }

            return 0;
        }
        protected override int Export ( )
        {
            GridControlExport . ExportToExcel ( this . Text ,this . gridControl1 );

            return base . Export ( );
        }
        #endregion

        #region Event
        private void btnCl_Click ( object sender ,System . EventArgs e )
        {
             lupColor . EditValue = lupProduct . EditValue = lupSpeci . EditValue =  lupType . EditValue = null;
            comAtt . Text = comClass . Text = comUnit . Text = comstate . Text = "";
        }
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            num = gridView1 . FocusedRowHandle;
            click ( num );
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
                toolAdd . Enabled = true;

                gridControl1 . DataSource = tableQuery;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;         
            }
        }
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            num = gridView1 . FocusedRowHandle;
            click ( num );
            if ( _model . OPI011 == false )
            {
                result = false;
                if ( _bll . Exists ( _model . idx ) )
                    result = true;
                edit ( );
            }
        }
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        //批量编辑
        private void btnBatch_Click ( object sender ,EventArgs e )
        {
            int [ ] selectRows = gridView1 . GetSelectedRows ( );
            if ( selectRows . Length < 1 )
            {
                XtraMessageBox . Show ( "请选择需要批量编辑的产品" );
                return;
            }
            List<string> piStr = new List<string> ( );
            DataRow row;
            foreach ( int i in selectRows )
            {
                row = gridView1 . GetDataRow ( i );
                piStr . Add ( row [ "OPI001" ] . ToString ( ) );
            }

            FormBatchProduct from = new FormBatchProduct ( piStr );
            from . ShowDialog ( );
        }
        #endregion

        #region Method
        void numOfProduct ( )
        {
            _model . OPI001 = _bll . GetNum ( );
            if ( _model . OPI001 == string . Empty )
                _model . OPI001 = DateTime . Now . ToString ( "yyyyMMdd" ) + "001";
            else
            {
                if ( _model . OPI001 . Substring ( 0 ,8 ) == DateTime . Now . ToString ( "yyyyMMdd" ) )
                    _model . OPI001 = ( Convert . ToInt64 ( _model . OPI001 ) + 1 ) . ToString ( );
                else
                    _model.OPI001= DateTime . Now . ToString ( "yyyyMMdd" ) + "001";
            }
        }
        void click ( int num )
        {
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                DataRow row = gridView1 . GetDataRow ( num );
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                _model . OPI001 = row [ "OPI001" ] . ToString ( );
                _model . OPI002 = row [ "OPI002" ] . ToString ( );
                _model . OPI003 = row [ "OPI003" ] . ToString ( );
                _model . OPI004 = string . IsNullOrEmpty ( row [ "OPI004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "OPI004" ] . ToString ( ) );
                _model . OPI005 = row [ "OPI005" ] . ToString ( );
                _model . OPI006 = row [ "OPI006" ] . ToString ( );
                _model . OPI007 = row [ "OPI007" ] . ToString ( );
                _model . OPI008 = row [ "OPI008" ] . ToString ( );
                _model . OPI009 = row [ "OPI009" ] . ToString ( );
                _model . OPI010 = row [ "OPI010" ] . ToString ( );
                _model . OPI011 = ( bool ) row [ "OPI011" ];
                if ( _model . OPI011 == true )
                {
                    Graph . gra ( splitContainerControl1 ,"注销" );
                    splitContainerControl1 . Panel1 . Refresh ( );
                    //Concell1 . Show ( );
                    //Concell1 . Show ( );
                    toolCancellation . Caption = "反注销";
                }
                else
                {
                    Graph . gra ( splitContainerControl1 ,"反" );
                    splitContainerControl1 . Panel1 . Refresh ( );
                    //Concell1 . Show ( );
                    //Concell1 . Hide ( );
                    toolCancellation . Caption = "注销";
                }
                QueryTool ( );
                if ( row [ "OPI012" ] != null && row [ "OPI012" ] . ToString ( ) != "" )
                    _model . OPI012 = ( byte [ ] ) row [ "OPI012" ];
                else
                    _model . OPI012 = new byte [ 0 ];
            }
        }
        void edit ( )
        {
            Carpenter . Query . OPIEdit form = new Carpenter . Query . OPIEdit ( "编辑" ,_model ,this . result );
            DialogResult result = form . ShowDialog ( );
            if ( result == System . Windows . Forms . DialogResult . OK )
            {
                _model = form . getModel;
                DataRow row = tableQuery . Rows [ num ];
                row . BeginEdit ( );
                row [ "idx" ] = _model . idx;
                row [ "OPI001" ] = _model . OPI001;
                row [ "OPI002" ] = _model . OPI002;
                row [ "OPI003" ] = _model . OPI003;
                row [ "OPI004" ] = _model . OPI004;
                row [ "OPI005" ] = _model . OPI005;
                row [ "OPI006" ] = _model . OPI006;
                row [ "OPI007" ] = _model . OPI007;
                row [ "OPI008" ] = _model . OPI008;
                row [ "OPI009" ] = _model . OPI009;
                row [ "OPI010" ] = _model . OPI010;
                row . EndEdit ( );

            }
        }
        #endregion

    }
}
