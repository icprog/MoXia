using DevExpress . XtraEditors;
using System;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormBomWoodPaint :FormChild
    {
        CarpenterBll.Bll.WoodPaintBll _bll=new CarpenterBll.Bll.WoodPaintBll();
        CarpenterEntity.WOODEntity _modelWood=new CarpenterEntity.WOODEntity();
        CarpenterEntity.PAITEntity _modelPaint=new CarpenterEntity.PAITEntity();
        CarpenterEntity.PAIJEntity _modelOne=new CarpenterEntity.PAIJEntity();
        int num=0; DataRow row;bool result=false;
        DataTable queryWood,queryPaint,queryOne;
        
        public FormBomWoodPaint ( )
        {
            InitializeComponent ( );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave ,toolExport ,toolPrint ,toolExamin ,toolReview } );

            wait . Hide ( );
            //SetImage . setImage ( Concell1 . pictureBox1 ,"zhuxiao.png" );
            //Concell1 . Hide ( );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            Utility . GridViewMoHuSelect . SetFilter ( gridView2 );
            Utility . GridViewMoHuSelect . SetFilter ( gridView3 );
            Utility . GridViewMoHuSelect . SetFilter ( gridView4 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );
        }
        
        #region Main
        protected override int Query ( )
        {
            //if ( string . IsNullOrEmpty ( lupProduct . Text ) )
            //{
            //    XtraMessageBox . Show ( "请选择产品" );
            //    return 0;
            //}
            if ( !string . IsNullOrEmpty ( texNumProduct . Text ) )
            {
                _modelWood . WOD004 = _modelPaint . PAI004 = _modelOne . PAJ004 = texNumProduct . Text;
            }
            else
                _modelWood . WOD004 = _modelPaint . PAI004 = _modelOne . PAJ004 = string . Empty;

            tabPageOne . Show ( );
            tabControl1 . SelectedIndex = 0;

            toolQuery . Enabled = true;
            toolAdd . Enabled = true;
            wait . Show ( );
            backgroundWorker1 . RunWorkerAsync ( );

            return 0;
        }
        protected override int Add ( )
        {
            if ( tabControl1 . SelectedTab == tabPageOne )
            {
                Carpenter . Query . FormWoodEdit from = new Carpenter . Query . FormWoodEdit ( "新增" ,_modelWood );
                DialogResult result = from . ShowDialog ( );
                if ( result == DialogResult . OK )
                {
                    _modelWood = from . getMood;
                    if ( queryWood == null )
                        Query ( );
                    else
                    {
                        row = queryWood . NewRow ( );
                        wood ( );
                        queryWood . Rows . Add ( row );
                    }
                }
            }
            else if ( tabControl1 . SelectedTab == tabPageTwo )
            {
                Carpenter . Query . FormPaintEdit from = new Carpenter . Query . FormPaintEdit ( "新增" ,_modelPaint );
                DialogResult result = from . ShowDialog ( );
                if ( result == DialogResult . OK )
                {
                    _modelPaint = from . getPaint;
                    if ( queryPaint == null )
                        Query ( );
                    else
                    {
                        row = queryPaint . NewRow ( );
                        paint ( );
                        queryPaint . Rows . Add ( row );
                    }
                }
            }
            else if ( tabControl1 . SelectedTab == tabPageTre )
            {
                _modelOne . PAJ004 = texNumProduct . Text;
                Carpenter . Query . FormPaintWorkProcedureEdit from = new Carpenter . Query . FormPaintWorkProcedureEdit ( "新增" ,_modelOne );
                DialogResult result = from . ShowDialog ( );
                if ( result == System . Windows . Forms . DialogResult . OK )
                {
                    _modelOne = from . getModel;
                    if ( queryOne == null )
                        Query ( );
                    else
                    {
                        row = queryOne . NewRow ( );
                        paintOne ( );
                        queryOne . Rows . Add ( row );
                    }
                }
            }
            else if ( tabControl1 . SelectedTab == tabPageFor )
            {

            }

            return 0;
        }
        protected override int Edit ( )
        {
            if ( tabControl1 . SelectedTab == tabPageOne )
            {                
                edit_one ( );               
            }
            else if ( tabControl1 . SelectedTab == tabPageTwo )
            {
                edit_two ( );
            }
            else if ( tabControl1 . SelectedTab == tabPageTre )
            {
                edit_tre ( );
            }
            else if ( tabControl1 . SelectedTab == tabPageFor )
            {

            }

            return 0;
        }
        protected override int Delete ( )
        {
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            if ( tabControl1 . SelectedTab == tabPageOne )
            {
                if ( _modelWood . idx < 1 )
                {
                    XtraMessageBox . Show ( "请选择需要删除的内容" );
                    return 0;
                }
                result = _bll . Delete ( _modelWood . idx ,"MOXWOD" );
                if ( result == true )
                {
                    XtraMessageBox . Show ( "删除成功" );
                    queryWood . Rows . RemoveAt ( num );
                }
                else
                    XtraMessageBox . Show ( "删除失败,请重试" );
            }
            else if ( tabControl1 . SelectedTab == tabPageTwo )
            {
                if ( _modelPaint . idx < 1 )
                {
                    XtraMessageBox . Show ( "请选择需要删除的内容" );
                    return 0;
                }
                result = _bll . Delete ( _modelWood . idx ,"MOXPAI" );
                if ( result == true )
                {
                    XtraMessageBox . Show ( "删除成功" );
                    queryPaint . Rows . RemoveAt ( num );
                }
                else
                    XtraMessageBox . Show ( "删除失败,请重试" );
            }
            else if ( tabControl1 . SelectedTab == tabPageTre )
            {
                if ( _modelOne . idx < 1 )
                {
                    XtraMessageBox . Show ( "请选择需要删除的内容" );
                    return 0;
                }
                result = _bll . Delete ( _modelOne . idx ,"MOXPAJ" );
                if ( result == true )
                {
                    XtraMessageBox . Show ( "删除成功" );
                    queryOne . Rows . RemoveAt ( num );
                }
                else
                    XtraMessageBox . Show ( "删除失败,请重试" );
            }
            else if ( tabControl1 . SelectedTab == tabPageFor )
            {

            }

            return 0;
        }
        protected override int Cancellation ( )
        {
            string textOf = toolCancellation . Caption;
            if ( textOf .Equals( "注销" ))
            {
                _modelWood . WOD011 = true;
                _modelPaint . PAI012 = true;
                _modelOne . PAJ013 = true;
            }
            else
            {
                _modelWood . WOD011 = false;
                _modelPaint . PAI012 = false;
                _modelOne . PAJ013 = false;
            }

            if ( tabControl1 . SelectedTab == tabPageOne )
            {
                if ( _modelWood . idx < 1 )
                {
                    XtraMessageBox . Show ( "请选择需要" + textOf + "的内容" );
                    return 0;
                }

                result = _bll . Cancellation ( _modelWood . idx ,"MOXWOD" ,"WOD011" ,_modelWood . WOD011 );
                if ( result == true )
                {
                    XtraMessageBox . Show ( "" + textOf + "成功" );
                    row = queryWood . Rows [ num ];
                    row . BeginEdit ( );
                    wood ( );
                    row . EndEdit ( );
                }
                else
                    XtraMessageBox . Show ( "" + textOf + "失败,请重试" );
            }
            else if ( tabControl1 . SelectedTab == tabPageTwo )
            {
                if ( _modelPaint . idx < 1 )
                {
                    XtraMessageBox . Show ( "请选择需要"+textOf+"的内容" );
                    return 0;
                }
                result = _bll . Cancellation ( _modelPaint . idx ,"MOXPAI" ,"PAI012" ,_modelPaint . PAI012 );
                if ( result == true )
                {
                    XtraMessageBox . Show ( ""+textOf+"成功" );
                    row = queryPaint . Rows [ num ];
                    row . BeginEdit ( );
                    paint ( );
                    row . EndEdit ( );
                }
                else
                    XtraMessageBox . Show ( "" + textOf + "失败,请重试" );
            }
            else if ( tabControl1 . SelectedTab == tabPageTre )
            {
                if ( _modelOne . idx < 1 )
                {
                    XtraMessageBox . Show ( "请选择需要" + textOf + "的内容" );
                    return 0;
                }
                result = _bll . Cancellation ( _modelOne . idx ,"MOXPAJ" ,"PAJ013" ,_modelOne . PAJ013 );
                if ( result == true )
                {
                    XtraMessageBox . Show ( "" + textOf + "成功" );
                    row = queryOne . Rows [ num ];
                    row . BeginEdit ( );
                    paintOne ( );
                    row . EndEdit ( );
                }
                else
                    XtraMessageBox . Show ( "" + textOf + "失败,请重试" );
            }
            else if ( tabControl1 . SelectedTab == tabPageFor )
            {

            }

            if ( result == true )
            {
                if ( textOf . Equals ( "注销" ) )
                {
                    Graph . gra ( splitContainerControl1 ,"注销" );
                    //Concell1 . Show ( );
                    toolCancellation . Caption = "反注销";
                }
                else
                {
                    Graph . gra ( splitContainerControl1 ,"反" );
                    //Concell1 . Hide ( );
                    toolCancellation . Caption = "注销";
                }
                splitContainerControl1 . Panel1 . Refresh ( );
            }

            return 0;
        }
        #endregion

        #region Event
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            num = gridView1 . FocusedRowHandle;
            click_one ( num );
        }
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            num = gridView1 . FocusedRowHandle;
            click_one ( num );
            if ( _modelWood . WOD011 == false )
            {
                edit_one ( );
            }
        }
        private void gridView2_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            num = gridView2 . FocusedRowHandle;
            click_two ( num );
        }
        private void gridView2_DoubleClick ( object sender ,EventArgs e )
        {
            num = gridView2 . FocusedRowHandle;
            click_two ( num );
            if ( _modelPaint . PAI012 == false )
            {
                edit_two ( );
            }
        }
        private void gridView3_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            num = gridView3 . FocusedRowHandle;
            click_tre ( num );
        }
        private void gridView3_DoubleClick ( object sender ,EventArgs e )
        {
            num = gridView3 . FocusedRowHandle;
            click_tre ( num );
            if ( _modelOne . PAJ013 == false )
            {
                edit_tre ( );
            }
        }
        private void backgroundWorker1_DoWork ( object sender ,System . ComponentModel . DoWorkEventArgs e )
        {
            queryWood = _bll . GetDataTableOfWood ( _modelWood.WOD004 );
            queryPaint = _bll . GetDataTablePaint ( _modelPaint.PAI004 );
            queryOne = _bll . GetDataTableOne ( _modelOne.PAJ004 );
        }
        private void backgroundWorker1_RunWorkerCompleted ( object sender ,System . ComponentModel . RunWorkerCompletedEventArgs e )
        {
            if ( e . Error == null )
            {
                gridControl1 . DataSource = queryWood;
                gridControl2 . DataSource = queryPaint;
                gridControl3 . DataSource = queryOne;

                wait . Hide ( );
            }
        }
        private void texNameProduct_DoubleClick ( object sender ,EventArgs e )
        {
            Carpenter . Query . FormBomWorkPlanQuery from = new Carpenter . Query . FormBomWorkPlanQuery ( "产品信息查询" ,"FormBomWoodPaint" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                CarpenterEntity . OPIEntity _model = from . getModel;
                texNumProduct . Text = _model . OPI001;
                texNameProduct . Text = _model . OPI002;
                texSpeci . Text = _model . OPI005;
                texClass . Text = _model . OPI010;
            }
        }
        private void texNameProduct_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e . KeyChar == 0x8 )
            {
                texNumProduct . Text = texNameProduct . Text = texClass . Text = texSpeci . Text = string . Empty;
            }
        }
        private void texNumProduct_TextChanged ( object sender ,EventArgs e )
        {
            texClass . Text = _bll . GetClass ( texNumProduct . Text );
        }
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridView4_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridView2_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridView3_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        #endregion

        #region Method
        void cancell ( bool bol )
        {
            if ( bol == true )
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
            splitContainerControl1 . Panel1 . Refresh ( );
        }
        void wood ( )
        {
            row [ "idx" ] = _modelWood . idx;
            row [ "WOD004" ] = _modelWood . WOD004;
            row [ "WOD005" ] = _modelWood . WOD005;
            row [ "WOD006" ] = _modelWood . WOD006;
            row [ "WOD007" ] = _modelWood . WOD007;
            row [ "WOD008" ] = _modelWood . WOD008;
            row [ "WOD011" ] = _modelWood . WOD011;         
        }
        void paint ( )
        {
            row [ "idx_one" ] = _modelPaint . idx;
            row [ "PAI004" ] = _modelPaint . PAI004;
            row [ "PAI005" ] = _modelPaint . PAI005;
            row [ "PAI006" ] = _modelPaint . PAI006;
            row [ "PAI007" ] = _modelPaint . PAI007;
            row [ "PAI008" ] = _modelPaint . PAI008;
            row [ "PAI009" ] = _modelPaint . PAI009;
            row [ "PAI012" ] = _modelPaint . PAI012;         
        }
        void paintOne ( )
        {
            row [ "idx_two" ] = _modelOne . idx;
            row [ "PAJ002" ] = _modelOne . PAJ002;
            row [ "PAJ004" ] = _modelOne . PAJ004;
            row [ "PAJ014" ] = _modelOne . PAJ014;      
            row [ "PAJ005" ] = _modelOne . PAJ005;
            row [ "PAJ006" ] = _modelOne . PAJ006;
            row [ "PAJ007" ] = _modelOne . PAJ007;
            row [ "PAJ008" ] = _modelOne . PAJ008;
            row [ "PAJ009" ] = _modelOne . PAJ009;
            row [ "PAJ010" ] = _modelOne . PAJ010;
            row [ "PAJ013" ] = _modelOne . PAJ013;
            row [ "PAJ015" ] = _modelOne . PAJ015;
        }
        void click_one (int num )
        {
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                row = gridView1 . GetDataRow ( num );
                _modelWood . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                //_modelWood . WOD001 = row [ "WOD001" ] . ToString ( );
                //_modelWood . WOD002 = row [ "WOD002" ] . ToString ( );
                //_modelWood . WOD003 = row [ "WOD003" ] . ToString ( );
                texNumProduct . Text = _modelWood . WOD004 = row [ "WOD004" ] . ToString ( );
                texNameProduct . Text = _modelWood . WOD005 = row [ "WOD005" ] . ToString ( );
                texSpeci . Text = _modelWood . WOD006 = row [ "WOD006" ] . ToString ( );
                _modelWood . WOD007 = row [ "WOD007" ] . ToString ( );
                _modelWood . WOD008 = string . IsNullOrEmpty ( row [ "WOD008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "WOD008" ] . ToString ( ) );
                //lupProduct . Text = _modelWood . WOD005;
                _modelWood . WOD011 = ( bool ) row [ "WOD011" ];
                cancell ( _modelWood . WOD011 );
            }
        }
        void edit_one ( )
        {
            if ( _modelWood . idx < 1 )
            {
                XtraMessageBox . Show ( "请选择需要编辑的内容" );
                return ;
            }
            Carpenter . Query . FormWoodEdit from = new Carpenter . Query . FormWoodEdit ( "编辑" ,_modelWood );
            DialogResult result = from . ShowDialog ( );
            if ( result == System . Windows . Forms . DialogResult . OK )
            {
                _modelWood = from . getMood;
                row = queryWood . Rows [ num ];
                row . BeginEdit ( );
                wood ( );
                row . EndEdit ( );
            }
        }
        void click_two ( int num )
        {
            if ( num >= 0 && num <= gridView2 . DataRowCount - 1 )
            {
                row = gridView2 . GetDataRow ( num );
                _modelPaint . idx = string . IsNullOrEmpty ( row [ "idx_one" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx_one" ] . ToString ( ) );
                //_modelPaint . PAI001 = row [ "PAI001" ] . ToString ( );
                //_modelPaint . PAI002 = row [ "PAI002" ] . ToString ( );
                //_modelPaint . PAI003 = row [ "PAI003" ] . ToString ( );
                texNumProduct . Text = _modelPaint . PAI004 = row [ "PAI004" ] . ToString ( );
                texNameProduct . Text = _modelPaint . PAI005 = row [ "PAI005" ] . ToString ( );
                texSpeci . Text = _modelPaint . PAI006 = row [ "PAI006" ] . ToString ( );
                _modelPaint . PAI007 = row [ "PAI007" ] . ToString ( );
                _modelPaint . PAI008 = string . IsNullOrEmpty ( row [ "PAI008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PAI008" ] . ToString ( ) );
                _modelPaint . PAI009 = row [ "PAI009" ] . ToString ( );
                //lupProduct . Text = _modelPaint . PAI005;
                _modelPaint . PAI012 = ( bool ) row [ "PAI012" ];
                cancell ( _modelPaint . PAI012 );
            }
        }
        void edit_two ( )
        {
            if ( _modelPaint . idx < 1 )
            {
                XtraMessageBox . Show ( "请选择需要编辑的内容" );
                return ;
            }

            Carpenter . Query . FormPaintEdit from = new Carpenter . Query . FormPaintEdit ( "编辑" ,_modelPaint );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                _modelPaint = from . getPaint;
                row = queryPaint . Rows [ num ];
                row . BeginEdit ( );
                paint ( );
                row . EndEdit ( );
            }
        }
        void click_tre ( int num )
        {
            if ( num >= 0 && num <= gridView3 . DataRowCount - 1 )
            {
                row = gridView3 . GetDataRow ( num );
                _modelOne . idx = string . IsNullOrEmpty ( row [ "idx_two" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx_two" ] . ToString ( ) );
                //_modelOne . PAJ001 = row [ "PAJ001" ] . ToString ( );
                _modelOne . PAJ002 = row [ "PAJ002" ] . ToString ( );
                //_modelOne . PAJ003 = row [ "PAJ003" ] . ToString ( );
                texNumProduct . Text = _modelOne . PAJ004 = row [ "PAJ004" ] . ToString ( );
                _modelOne . PAJ005 = string . IsNullOrEmpty ( row [ "PAJ005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PAJ005" ] . ToString ( ) );
                _modelOne . PAJ006 = string . IsNullOrEmpty ( row [ "PAJ006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PAJ006" ] . ToString ( ) );
                _modelOne . PAJ007 = string . IsNullOrEmpty ( row [ "PAJ007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PAJ007" ] . ToString ( ) );
                _modelOne . PAJ008 = string . IsNullOrEmpty ( row [ "PAJ008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PAJ008" ] . ToString ( ) );
                _modelOne . PAJ009 = string . IsNullOrEmpty ( row [ "PAJ009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PAJ009" ] . ToString ( ) );
                _modelOne . PAJ010 = string . IsNullOrEmpty ( row [ "PAJ010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PAJ010" ] . ToString ( ) );
                //lupProduct . Text = row [ "PAI005_one" ] . ToString ( );
                _modelOne . PAJ013 = ( bool ) row [ "PAJ013" ];
                texNameProduct . Text = _modelOne . PAJ014 = row [ "PAJ014" ] . ToString ( );
                texSpeci . Text = _modelOne . PAJ015 = row [ "PAJ015" ] . ToString ( );
                cancell ( _modelOne . PAJ013 );
            }
        }
        void edit_tre ( )
        {
            if ( _modelOne . idx < 1 )
            {
                XtraMessageBox . Show ( "请选择需要编辑的内容" );
                return ;
            }

            Carpenter . Query . FormPaintWorkProcedureEdit from = new Carpenter . Query . FormPaintWorkProcedureEdit ( "编辑" ,_modelOne );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                _modelOne = from . getModel;
                row = queryOne . Rows [ num ];
                row . BeginEdit ( );
                paintOne ( );
                row . EndEdit ( );
            }
        }
        #endregion

    }
}
