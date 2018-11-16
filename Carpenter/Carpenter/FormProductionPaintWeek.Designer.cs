namespace Carpenter
{
    partial class FormProductionPaintWeek
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components . Dispose ( );
            }
            base . Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dtpEnd = new DevExpress.XtraEditors.DateEdit();
            this.dtpStart = new DevExpress.XtraEditors.DateEdit();
            this.dtpOrder = new DevExpress.XtraEditors.DateEdit();
            this.texValue = new DevExpress.XtraEditors.TextEdit();
            this.texBatchNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWH001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWH002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWH003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWH004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWH005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWH006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWH007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRS013 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWH009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWH010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWH014 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWH016 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.textRemark = new System.Windows.Forms.TextBox();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOrder.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texBatchNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpEnd);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpStart);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpOrder);
            this.splitContainerControl1.Panel1.Controls.Add(this.texValue);
            this.splitContainerControl1.Panel1.Controls.Add(this.texBatchNum);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1212, 428);
            this.splitContainerControl1.SplitterPosition = 71;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(440, 45);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(35, 14);
            this.labelControl5.TabIndex = 45;
            this.labelControl5.Text = "---->";
            // 
            // dtpEnd
            // 
            this.dtpEnd.EditValue = null;
            this.dtpEnd.Location = new System.Drawing.Point(485, 42);
            this.dtpEnd.MenuManager = this.barManager1;
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Properties.Appearance.Options.UseFont = true;
            this.dtpEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEnd.Size = new System.Drawing.Size(124, 20);
            this.dtpEnd.TabIndex = 44;
            // 
            // dtpStart
            // 
            this.dtpStart.EditValue = null;
            this.dtpStart.Location = new System.Drawing.Point(310, 42);
            this.dtpStart.MenuManager = this.barManager1;
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Properties.Appearance.Options.UseFont = true;
            this.dtpStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStart.Size = new System.Drawing.Size(124, 20);
            this.dtpStart.TabIndex = 43;
            // 
            // dtpOrder
            // 
            this.dtpOrder.EditValue = null;
            this.dtpOrder.Location = new System.Drawing.Point(303, 11);
            this.dtpOrder.MenuManager = this.barManager1;
            this.dtpOrder.Name = "dtpOrder";
            this.dtpOrder.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrder.Properties.Appearance.Options.UseFont = true;
            this.dtpOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOrder.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOrder.Size = new System.Drawing.Size(124, 20);
            this.dtpOrder.TabIndex = 42;
            // 
            // texValue
            // 
            this.texValue.Location = new System.Drawing.Point(88, 42);
            this.texValue.MenuManager = this.barManager1;
            this.texValue.Name = "texValue";
            this.texValue.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texValue.Properties.Appearance.Options.UseFont = true;
            this.texValue.Properties.ReadOnly = true;
            this.texValue.Size = new System.Drawing.Size(116, 20);
            this.texValue.TabIndex = 41;
            // 
            // texBatchNum
            // 
            this.texBatchNum.Location = new System.Drawing.Point(79, 13);
            this.texBatchNum.MenuManager = this.barManager1;
            this.texBatchNum.Name = "texBatchNum";
            this.texBatchNum.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texBatchNum.Properties.Appearance.Options.UseFont = true;
            this.texBatchNum.Properties.ReadOnly = true;
            this.texBatchNum.Size = new System.Drawing.Size(116, 20);
            this.texBatchNum.TabIndex = 40;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(234, 45);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 14);
            this.labelControl4.TabIndex = 39;
            this.labelControl4.Text = "生产周期：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(26, 45);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 14);
            this.labelControl3.TabIndex = 38;
            this.labelControl3.Text = "总产值：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(227, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 37;
            this.labelControl2.Text = "下单日期：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(31, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 14);
            this.labelControl1.TabIndex = 36;
            this.labelControl1.Text = "周次：";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1212, 345);
            this.gridControl1.TabIndex = 28;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idx,
            this.PWH001,
            this.PWH002,
            this.OPI003,
            this.PWH003,
            this.PWH004,
            this.PWH005,
            this.PWH006,
            this.OPI006,
            this.OPI007,
            this.OPI004,
            this.PWH007,
            this.PRS013,
            this.PWH009,
            this.PWH010,
            this.PWH014,
            this.PWH016});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // PWH001
            // 
            this.PWH001.Caption = "单号";
            this.PWH001.FieldName = "PWH001";
            this.PWH001.Name = "PWH001";
            this.PWH001.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // PWH002
            // 
            this.PWH002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH002.AppearanceCell.Options.UseFont = true;
            this.PWH002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH002.AppearanceHeader.Options.UseFont = true;
            this.PWH002.Caption = "遗留单号";
            this.PWH002.FieldName = "PWH002";
            this.PWH002.Name = "PWH002";
            this.PWH002.OptionsColumn.AllowEdit = false;
            this.PWH002.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PWH002.Visible = true;
            this.PWH002.VisibleIndex = 0;
            this.PWH002.Width = 64;
            // 
            // OPI003
            // 
            this.OPI003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI003.AppearanceCell.Options.UseFont = true;
            this.OPI003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI003.AppearanceHeader.Options.UseFont = true;
            this.OPI003.Caption = "产品类别";
            this.OPI003.FieldName = "OPI003";
            this.OPI003.Name = "OPI003";
            this.OPI003.OptionsColumn.AllowEdit = false;
            this.OPI003.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.OPI003.Visible = true;
            this.OPI003.VisibleIndex = 2;
            this.OPI003.Width = 66;
            // 
            // PWH003
            // 
            this.PWH003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH003.AppearanceCell.Options.UseFont = true;
            this.PWH003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH003.AppearanceHeader.Options.UseFont = true;
            this.PWH003.Caption = "批号";
            this.PWH003.FieldName = "PWH003";
            this.PWH003.Name = "PWH003";
            this.PWH003.OptionsColumn.AllowEdit = false;
            this.PWH003.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PWH003.Visible = true;
            this.PWH003.VisibleIndex = 3;
            this.PWH003.Width = 36;
            // 
            // PWH004
            // 
            this.PWH004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH004.AppearanceCell.Options.UseFont = true;
            this.PWH004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH004.AppearanceHeader.Options.UseFont = true;
            this.PWH004.Caption = "产品品号";
            this.PWH004.FieldName = "PWH004";
            this.PWH004.Name = "PWH004";
            this.PWH004.OptionsColumn.AllowEdit = false;
            this.PWH004.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PWH004.Visible = true;
            this.PWH004.VisibleIndex = 4;
            this.PWH004.Width = 94;
            // 
            // PWH005
            // 
            this.PWH005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH005.AppearanceCell.Options.UseFont = true;
            this.PWH005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH005.AppearanceHeader.Options.UseFont = true;
            this.PWH005.Caption = "产品名称";
            this.PWH005.FieldName = "PWH005";
            this.PWH005.Name = "PWH005";
            this.PWH005.OptionsColumn.AllowEdit = false;
            this.PWH005.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PWH005.Visible = true;
            this.PWH005.VisibleIndex = 5;
            this.PWH005.Width = 100;
            // 
            // PWH006
            // 
            this.PWH006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH006.AppearanceCell.Options.UseFont = true;
            this.PWH006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH006.AppearanceHeader.Options.UseFont = true;
            this.PWH006.Caption = "规格";
            this.PWH006.FieldName = "PWH006";
            this.PWH006.Name = "PWH006";
            this.PWH006.OptionsColumn.AllowEdit = false;
            this.PWH006.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PWH006.Visible = true;
            this.PWH006.VisibleIndex = 6;
            this.PWH006.Width = 62;
            // 
            // OPI006
            // 
            this.OPI006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI006.AppearanceCell.Options.UseFont = true;
            this.OPI006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI006.AppearanceHeader.Options.UseFont = true;
            this.OPI006.Caption = "颜色";
            this.OPI006.FieldName = "OPI006";
            this.OPI006.Name = "OPI006";
            this.OPI006.OptionsColumn.AllowEdit = false;
            this.OPI006.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.OPI006.Visible = true;
            this.OPI006.VisibleIndex = 7;
            this.OPI006.Width = 49;
            // 
            // OPI007
            // 
            this.OPI007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI007.AppearanceCell.Options.UseFont = true;
            this.OPI007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI007.AppearanceHeader.Options.UseFont = true;
            this.OPI007.Caption = "单位";
            this.OPI007.FieldName = "OPI007";
            this.OPI007.Name = "OPI007";
            this.OPI007.OptionsColumn.AllowEdit = false;
            this.OPI007.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.OPI007.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OPI007", "总产值")});
            this.OPI007.Visible = true;
            this.OPI007.VisibleIndex = 8;
            this.OPI007.Width = 40;
            // 
            // OPI004
            // 
            this.OPI004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI004.AppearanceCell.Options.UseFont = true;
            this.OPI004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI004.AppearanceHeader.Options.UseFont = true;
            this.OPI004.Caption = "BOM产值";
            this.OPI004.DisplayFormat.FormatString = "0.####";
            this.OPI004.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.OPI004.FieldName = "OPI004";
            this.OPI004.Name = "OPI004";
            this.OPI004.OptionsColumn.AllowEdit = false;
            this.OPI004.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.OPI004.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OPI004", "{0:0.####}")});
            this.OPI004.Visible = true;
            this.OPI004.VisibleIndex = 9;
            this.OPI004.Width = 65;
            // 
            // PWH007
            // 
            this.PWH007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH007.AppearanceCell.Options.UseFont = true;
            this.PWH007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH007.AppearanceHeader.Options.UseFont = true;
            this.PWH007.Caption = "订单量";
            this.PWH007.FieldName = "PWH007";
            this.PWH007.Name = "PWH007";
            this.PWH007.OptionsColumn.AllowEdit = false;
            this.PWH007.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PWH007.Visible = true;
            this.PWH007.VisibleIndex = 10;
            this.PWH007.Width = 58;
            // 
            // PRS013
            // 
            this.PRS013.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRS013.AppearanceCell.Options.UseFont = true;
            this.PRS013.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRS013.AppearanceHeader.Options.UseFont = true;
            this.PRS013.Caption = "组装完成时间";
            this.PRS013.FieldName = "PRS013";
            this.PRS013.Name = "PRS013";
            this.PRS013.OptionsColumn.AllowEdit = false;
            this.PRS013.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PRS013.Visible = true;
            this.PRS013.VisibleIndex = 12;
            this.PRS013.Width = 92;
            // 
            // PWH009
            // 
            this.PWH009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH009.AppearanceCell.Options.UseFont = true;
            this.PWH009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH009.AppearanceHeader.Options.UseFont = true;
            this.PWH009.Caption = "备注";
            this.PWH009.FieldName = "PWH009";
            this.PWH009.Name = "PWH009";
            this.PWH009.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PWH009.Visible = true;
            this.PWH009.VisibleIndex = 14;
            this.PWH009.Width = 217;
            // 
            // PWH010
            // 
            this.PWH010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH010.AppearanceCell.Options.UseFont = true;
            this.PWH010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH010.AppearanceHeader.Options.UseFont = true;
            this.PWH010.Caption = "预排";
            this.PWH010.FieldName = "PWH010";
            this.PWH010.Name = "PWH010";
            this.PWH010.OptionsColumn.AllowEdit = false;
            this.PWH010.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PWH010.Visible = true;
            this.PWH010.VisibleIndex = 1;
            this.PWH010.Width = 36;
            // 
            // PWH014
            // 
            this.PWH014.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH014.AppearanceCell.Options.UseFont = true;
            this.PWH014.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH014.AppearanceHeader.Options.UseFont = true;
            this.PWH014.Caption = "计划生产量";
            this.PWH014.FieldName = "PWH014";
            this.PWH014.Name = "PWH014";
            this.PWH014.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PWH014.Visible = true;
            this.PWH014.VisibleIndex = 11;
            this.PWH014.Width = 81;
            // 
            // PWH016
            // 
            this.PWH016.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH016.AppearanceCell.Options.UseFont = true;
            this.PWH016.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH016.AppearanceHeader.Options.UseFont = true;
            this.PWH016.Caption = "油漆计划完成时间";
            this.PWH016.FieldName = "PWH016";
            this.PWH016.Name = "PWH016";
            this.PWH016.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PWH016.Visible = true;
            this.PWH016.VisibleIndex = 13;
            this.PWH016.Width = 124;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight});
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.White;
            this.hideContainerRight.Controls.Add(this.dockPanel1);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(1212, 26);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(36, 428);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("ba74b8c5-165c-4d3d-9f86-1be7ae128290");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(200, 454);
            this.dockPanel1.Text = "数据逻辑";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panelControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 39);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(191, 411);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textRemark);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(191, 411);
            this.panelControl1.TabIndex = 0;
            // 
            // textRemark
            // 
            this.textRemark.BackColor = System.Drawing.Color.White;
            this.textRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textRemark.ForeColor = System.Drawing.Color.Gray;
            this.textRemark.Location = new System.Drawing.Point(2, 2);
            this.textRemark.Multiline = true;
            this.textRemark.Name = "textRemark";
            this.textRemark.ReadOnly = true;
            this.textRemark.Size = new System.Drawing.Size(187, 407);
            this.textRemark.TabIndex = 3;
            this.textRemark.Text = " *  遗留：同批号、品号报工数量少于订单量\r\n\r\n *  预排：临时生产的不在周计划中的需要报工的产品做计划排产，可以在下一个周计划中正式排产\r\n\r\n\r\n\r\n\r" +
    "\n";
            // 
            // wait
            // 
            this.wait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wait.Appearance.Options.UseBackColor = true;
            this.wait.BarAnimationElementThickness = 2;
            this.wait.Caption = "请稍后";
            this.wait.Description = "数据加载中 ...";
            this.wait.Location = new System.Drawing.Point(501, 194);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 33;
            this.wait.Text = "progressPanel1";
            // 
            // FormProductionPaintWeek
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 454);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "FormProductionPaintWeek";
            this.Text = "油漆车间生产周计划";
            this.Controls.SetChildIndex(this.hideContainerRight, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.wait, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOrder.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texBatchNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn PWH001;
        private DevExpress . XtraGrid . Columns . GridColumn PWH002;
        private DevExpress . XtraGrid . Columns . GridColumn OPI003;
        private DevExpress . XtraGrid . Columns . GridColumn PWH003;
        private DevExpress . XtraGrid . Columns . GridColumn PWH004;
        private DevExpress . XtraGrid . Columns . GridColumn PWH005;
        private DevExpress . XtraGrid . Columns . GridColumn PWH006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn OPI004;
        private DevExpress . XtraGrid . Columns . GridColumn PWH007;
        private DevExpress . XtraGrid . Columns . GridColumn PRS013;
        private DevExpress . XtraGrid . Columns . GridColumn PWH009;
        private DevExpress . XtraGrid . Columns . GridColumn PWH010;
        private DevExpress . XtraGrid . Columns . GridColumn PWH014;
        private DevExpress . XtraGrid . Columns . GridColumn PWH016;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraBars . Docking . DockManager dockManager1;
        private DevExpress . XtraBars . Docking . DockPanel dockPanel1;
        private DevExpress . XtraBars . Docking . ControlContainer dockPanel1_Container;
        private DevExpress . XtraEditors . PanelControl panelControl1;
        private System . Windows . Forms . TextBox textRemark;
        private DevExpress . XtraBars . Docking . AutoHideContainer hideContainerRight;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . TextEdit texBatchNum;
        private DevExpress . XtraEditors . TextEdit texValue;
        private DevExpress . XtraEditors . DateEdit dtpOrder;
        private DevExpress . XtraEditors . LabelControl labelControl5;
        private DevExpress . XtraEditors . DateEdit dtpEnd;
        private DevExpress . XtraEditors . DateEdit dtpStart;
    }
}