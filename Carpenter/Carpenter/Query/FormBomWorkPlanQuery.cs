
using System . Data;
using System . Reflection;

namespace Carpenter . Query
{
    public partial class FormBomWorkPlanQuery :FormBase
    {
        DataTable queryTable;string sign=string.Empty;
        CarpenterEntity . BomWorkPlanWOQEntity _model = new CarpenterEntity . BomWorkPlanWOQEntity ( );
        CarpenterEntity.OPIEntity _modelOpi=new CarpenterEntity.OPIEntity();
         
        public FormBomWorkPlanQuery ( string text ,string sign )
        {
            InitializeComponent ( );
            
            this . Text = text;
            this . sign = sign;

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            CarpenterBll . Bll . BomWorkPlanBll _bll = new CarpenterBll . Bll . BomWorkPlanBll ( );
            gridControl1.DataSource = _bll . GetDataTablePro ( );

            if ( this . sign . Equals ( "FormBomWoodPaint" ) )
                Form_BomWoodPaint ( );
            if ( this . sign . Equals ( "FormWoodEdit" ) )
                Form_WoodEdit ( );
            if ( this . sign . Equals ( "FormPaintEdit" ) )
                From_PaintEdit ( );
            if ( this . sign . Equals ( "FormPaintWorkProcedureEdit" ) )
                Form_PaintWorkProcedureEdit ( );
            if ( this . sign . Equals ( "FormBomWorkPlan" ) )
                Form_BomWorkPlan ( );
            if ( this . sign . Equals ( "FormBomWorkPlanOPI" ) )
                Form_BomWorkPlanOPI ( );

            gridControl1 . DataSource = queryTable;
        }

        void Form_BomWoodPaint ( )
        {
            OPI001 . Visible = true;
            OPI002 . Visible = true;
            OPI003 . Visible = false;
            OPI004 . Visible = false;
            OPI005 . Visible = true;
            OPI006 . Visible = false;
            OPI007 . Visible = false;
            OPI008 . Visible = false;
            OPI009 . Visible = false;
            OPI010 . Visible = true;
            CarpenterBll . Bll . WoodPaintBll _bll = new CarpenterBll . Bll . WoodPaintBll ( );
            queryTable = _bll . GetDataTableOfProduct ( "'木材','油漆'" );       
        }

        void From_BomWoodPaint_Assign ( DataRow row )
        {
            _modelOpi . OPI001 = row [ "OPI001" ] . ToString ( );
            _modelOpi . OPI002 = row [ "OPI002" ] . ToString ( );
            _modelOpi . OPI005 = row [ "OPI005" ] . ToString ( );
            _modelOpi . OPI010 = row [ "OPI010" ] . ToString ( );
        }

        void Form_WoodEdit ( )
        {
            OPI001 . Visible = true;
            OPI002 . Visible = true;
            OPI003 . Visible = false;
            OPI004 . Visible = false;
            OPI005 . Visible = true;
            OPI006 . Visible = false;
            OPI007 . Visible = true;
            OPI008 . Visible = false;
            OPI009 . Visible = false;
            OPI010 . Visible = false;
            CarpenterBll . Bll . WoodPaintBll _bll = new CarpenterBll . Bll . WoodPaintBll ( );
            queryTable = _bll . GetDataTableOfProduct ( "'木材'" );
        }

        void Form_WoodEdit_Assign ( DataRow row )
        {
            _modelOpi . OPI001 = row [ "OPI001" ] . ToString ( );
            _modelOpi . OPI002 = row [ "OPI002" ] . ToString ( );
            _modelOpi . OPI005 = row [ "OPI005" ] . ToString ( );
            _modelOpi . OPI007 = row [ "OPI007" ] . ToString ( );
        }

        void From_PaintEdit ( )
        {
            OPI001 . Visible = true;
            OPI002 . Visible = true;
            OPI003 . Visible = false;
            OPI004 . Visible = false;
            OPI005 . Visible = true;
            OPI006 . Visible = false;
            OPI007 . Visible = true;
            OPI008 . Visible = false;
            OPI009 . Visible = false;
            OPI010 . Visible = false;
            CarpenterBll . Bll . WoodPaintBll _bll = new CarpenterBll . Bll . WoodPaintBll ( );
            queryTable = _bll . GetDataTableOfProduct ( "'油漆'" );
        }

        void From_PaintEdit_Assign ( DataRow row )
        {
            _modelOpi . OPI001 = row [ "OPI001" ] . ToString ( );
            _modelOpi . OPI002 = row [ "OPI002" ] . ToString ( );
            _modelOpi . OPI005 = row [ "OPI005" ] . ToString ( );
            _modelOpi . OPI007 = row [ "OPI007" ] . ToString ( );
        }

        void Form_PaintWorkProcedureEdit ( )
        {
            OPI001 . Visible = true;
            OPI002 . Visible = true;
            OPI003 . Visible = false;
            OPI004 . Visible = false;
            OPI005 . Visible = true;
            OPI006 . Visible = false;
            OPI007 . Visible = false;
            OPI008 . Visible = false;
            OPI009 . Visible = false;
            OPI010 . Visible = false;
            CarpenterBll . Bll . WoodPaintBll _bll = new CarpenterBll . Bll . WoodPaintBll ( );
            queryTable = _bll . GetDataTableOfPaint ( );
        }

        void Form_PaintWorkProcedureEdit_Assign ( DataRow row )
        {
            _modelOpi . OPI001 = row [ "OPI001" ] . ToString ( );
            _modelOpi . OPI002 = row [ "OPI002" ] . ToString ( );
            _modelOpi . OPI005 = row [ "OPI005" ] . ToString ( );
        }

        void Form_BomWorkPlan ( )
        {
            OPI001 . Visible = true;
            OPI002 . Visible = true;
            OPI003 . Visible = false;
            OPI004 . Visible = false;
            OPI005 . Visible = true;
            OPI006 . Visible = false;
            OPI007 . Visible = false;
            OPI008 . Visible = false;
            OPI009 . Visible = false;
            OPI010 . Visible = true;
            CarpenterBll . Bll . BomWorkPlanBll _bll = new CarpenterBll . Bll . BomWorkPlanBll ( );
            queryTable = _bll . GetDataTableQuery ( );
        }

        void Form_BomWorkPlan_Assign ( DataRow row )
        {
            _modelOpi . OPI001 = row [ "OPI001" ] . ToString ( );
        }

        void Form_BomWorkPlanOPI ( )
        {
            OPI001 . Visible = true;
            OPI002 . Visible = true;
            OPI003 . Visible = true;
            OPI004 . Visible = false;
            OPI005 . Visible = true;
            OPI006 . Visible = true;
            OPI007 . Visible = true;
            OPI008 . Visible = false;
            OPI009 . Visible = false;
            OPI010 . Visible = false;
            CarpenterBll . Bll . BomWorkPlanBll _bll = new CarpenterBll . Bll . BomWorkPlanBll ( );
            queryTable = _bll . GetDataTableOPI ( );
        }

        void Form_BomWorkPlanOPI_Assign ( DataRow row)
        {
            _modelOpi . OPI001 = row [ "OPI001" ] . ToString ( );
            _modelOpi . OPI002 = row [ "OPI002" ] . ToString ( );
            _modelOpi . OPI005 = row [ "OPI005" ] . ToString ( );
        }

        private void gridView1_DoubleClick ( object sender ,System . EventArgs e )
        {
            int num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                DataRow row = gridView1 . GetDataRow ( num );
                if ( this . sign . Equals ( "FormBomWoodPaint" ) )
                    From_BomWoodPaint_Assign ( row );
                if ( this . sign . Equals ( "FormWoodEdit" ) )
                    Form_WoodEdit_Assign ( row );
                if ( this . sign . Equals ( "FormPaintEdit" ) )
                    From_PaintEdit_Assign ( row );
                if ( this . sign . Equals ( "FormPaintWorkProcedureEdit" ) )
                    Form_PaintWorkProcedureEdit_Assign ( row );
                if ( this . sign . Equals ( "FormBomWorkPlan" ) )
                    Form_BomWorkPlan_Assign ( row );
                if ( this . sign . Equals ( "FormBomWorkPlanOPI" ) )
                    Form_BomWorkPlanOPI_Assign ( row );

                this . DialogResult = System . Windows . Forms . DialogResult . OK;
            }
        }

        public CarpenterEntity . OPIEntity getModel
        {
            get
            {
                return _modelOpi;
            }
        }

        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

    }
}
