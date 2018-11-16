namespace Carpenter
{
    partial class FormPlanStock
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PLT001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLT002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLT003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLT004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLT005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLT006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLT012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLT007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLT008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLT013 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.textRemark = new System.Windows.Forms.TextBox();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dtpEnd = new DevExpress.XtraEditors.DateEdit();
            this.dtpStart = new DevExpress.XtraEditors.DateEdit();
            this.dtpOrder = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.texValue = new DevExpress.XtraEditors.TextEdit();
            this.texBatchNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1214, 345);
            this.gridControl1.TabIndex = 0;
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
            this.PLT001,
            this.PLT002,
            this.OPI003,
            this.PLT003,
            this.PLT004,
            this.PLT005,
            this.PLT006,
            this.OPI006,
            this.OPI007,
            this.OPI004,
            this.PLT012,
            this.PLT007,
            this.PLT008,
            this.PLT013});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // PLT001
            // 
            this.PLT001.Caption = "单号";
            this.PLT001.FieldName = "PLT001";
            this.PLT001.Name = "PLT001";
            this.PLT001.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // PLT002
            // 
            this.PLT002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT002.AppearanceCell.Options.UseFont = true;
            this.PLT002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT002.AppearanceHeader.Options.UseFont = true;
            this.PLT002.Caption = "遗留单号";
            this.PLT002.FieldName = "PLT002";
            this.PLT002.Name = "PLT002";
            this.PLT002.OptionsColumn.AllowEdit = false;
            this.PLT002.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLT002.Visible = true;
            this.PLT002.VisibleIndex = 0;
            this.PLT002.Width = 65;
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
            this.OPI003.Width = 69;
            // 
            // PLT003
            // 
            this.PLT003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT003.AppearanceCell.Options.UseFont = true;
            this.PLT003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT003.AppearanceHeader.Options.UseFont = true;
            this.PLT003.Caption = "批号";
            this.PLT003.FieldName = "PLT003";
            this.PLT003.Name = "PLT003";
            this.PLT003.OptionsColumn.AllowEdit = false;
            this.PLT003.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLT003.Visible = true;
            this.PLT003.VisibleIndex = 3;
            this.PLT003.Width = 40;
            // 
            // PLT004
            // 
            this.PLT004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT004.AppearanceCell.Options.UseFont = true;
            this.PLT004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT004.AppearanceHeader.Options.UseFont = true;
            this.PLT004.Caption = "产品品号";
            this.PLT004.FieldName = "PLT004";
            this.PLT004.Name = "PLT004";
            this.PLT004.OptionsColumn.AllowEdit = false;
            this.PLT004.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLT004.Visible = true;
            this.PLT004.VisibleIndex = 4;
            this.PLT004.Width = 70;
            // 
            // PLT005
            // 
            this.PLT005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT005.AppearanceCell.Options.UseFont = true;
            this.PLT005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT005.AppearanceHeader.Options.UseFont = true;
            this.PLT005.Caption = "产品名称";
            this.PLT005.FieldName = "PLT005";
            this.PLT005.Name = "PLT005";
            this.PLT005.OptionsColumn.AllowEdit = false;
            this.PLT005.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLT005.Visible = true;
            this.PLT005.VisibleIndex = 5;
            this.PLT005.Width = 72;
            // 
            // PLT006
            // 
            this.PLT006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT006.AppearanceCell.Options.UseFont = true;
            this.PLT006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT006.AppearanceHeader.Options.UseFont = true;
            this.PLT006.Caption = "规格";
            this.PLT006.FieldName = "PLT006";
            this.PLT006.Name = "PLT006";
            this.PLT006.OptionsColumn.AllowEdit = false;
            this.PLT006.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLT006.Visible = true;
            this.PLT006.VisibleIndex = 6;
            this.PLT006.Width = 67;
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
            this.OPI006.Width = 56;
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
            this.OPI007.Width = 37;
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
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OPI004", "{0:####}")});
            this.OPI004.Visible = true;
            this.OPI004.VisibleIndex = 9;
            this.OPI004.Width = 60;
            // 
            // PLT012
            // 
            this.PLT012.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT012.AppearanceCell.Options.UseFont = true;
            this.PLT012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT012.AppearanceHeader.Options.UseFont = true;
            this.PLT012.Caption = "订单量";
            this.PLT012.FieldName = "PLT012";
            this.PLT012.Name = "PLT012";
            this.PLT012.OptionsColumn.AllowEdit = false;
            this.PLT012.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLT012.Visible = true;
            this.PLT012.VisibleIndex = 10;
            this.PLT012.Width = 57;
            // 
            // PLT007
            // 
            this.PLT007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT007.AppearanceCell.Options.UseFont = true;
            this.PLT007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT007.AppearanceHeader.Options.UseFont = true;
            this.PLT007.Caption = "备料计划完成时间";
            this.PLT007.FieldName = "PLT007";
            this.PLT007.Name = "PLT007";
            this.PLT007.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLT007.Visible = true;
            this.PLT007.VisibleIndex = 11;
            this.PLT007.Width = 124;
            // 
            // PLT008
            // 
            this.PLT008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT008.AppearanceCell.Options.UseFont = true;
            this.PLT008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT008.AppearanceHeader.Options.UseFont = true;
            this.PLT008.Caption = "备注";
            this.PLT008.FieldName = "PLT008";
            this.PLT008.Name = "PLT008";
            this.PLT008.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLT008.Visible = true;
            this.PLT008.VisibleIndex = 12;
            this.PLT008.Width = 293;
            // 
            // PLT013
            // 
            this.PLT013.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT013.AppearanceCell.Options.UseFont = true;
            this.PLT013.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT013.AppearanceHeader.Options.UseFont = true;
            this.PLT013.Caption = "预排";
            this.PLT013.FieldName = "PLT013";
            this.PLT013.Name = "PLT013";
            this.PLT013.OptionsColumn.AllowEdit = false;
            this.PLT013.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLT013.Visible = true;
            this.PLT013.VisibleIndex = 1;
            this.PLT013.Width = 39;
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
            this.hideContainerRight.Location = new System.Drawing.Point(1214, 26);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(36, 430);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("2fe271d9-e987-4e29-8754-2291c96d3e0a");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(223, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(223, 430);
            this.dockPanel1.Text = "数据逻辑";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panelControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 39);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(214, 387);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textRemark);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(214, 387);
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
            this.textRemark.Size = new System.Drawing.Size(210, 383);
            this.textRemark.TabIndex = 1;
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
            this.wait.Location = new System.Drawing.Point(479, 94);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 33;
            this.wait.Text = "progressPanel1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpEnd);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpStart);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpOrder);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel1.Controls.Add(this.texValue);
            this.splitContainerControl1.Panel1.Controls.Add(this.texBatchNum);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.wait);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1214, 430);
            this.splitContainerControl1.SplitterPosition = 73;
            this.splitContainerControl1.TabIndex = 35;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // dtpEnd
            // 
            this.dtpEnd.EditValue = null;
            this.dtpEnd.Location = new System.Drawing.Point(455, 44);
            this.dtpEnd.MenuManager = this.barManager1;
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEnd.Size = new System.Drawing.Size(117, 20);
            this.dtpEnd.TabIndex = 25;
            // 
            // dtpStart
            // 
            this.dtpStart.EditValue = null;
            this.dtpStart.Location = new System.Drawing.Point(291, 44);
            this.dtpStart.MenuManager = this.barManager1;
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStart.Size = new System.Drawing.Size(117, 20);
            this.dtpStart.TabIndex = 24;
            // 
            // dtpOrder
            // 
            this.dtpOrder.EditValue = null;
            this.dtpOrder.Location = new System.Drawing.Point(291, 12);
            this.dtpOrder.MenuManager = this.barManager1;
            this.dtpOrder.Name = "dtpOrder";
            this.dtpOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOrder.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOrder.Size = new System.Drawing.Size(117, 20);
            this.dtpOrder.TabIndex = 23;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(414, 47);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(35, 14);
            this.labelControl5.TabIndex = 22;
            this.labelControl5.Text = "---->";
            // 
            // texValue
            // 
            this.texValue.Location = new System.Drawing.Point(81, 44);
            this.texValue.MenuManager = this.barManager1;
            this.texValue.Name = "texValue";
            this.texValue.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texValue.Properties.Appearance.Options.UseFont = true;
            this.texValue.Properties.ReadOnly = true;
            this.texValue.Size = new System.Drawing.Size(122, 20);
            this.texValue.TabIndex = 21;
            // 
            // texBatchNum
            // 
            this.texBatchNum.Location = new System.Drawing.Point(67, 12);
            this.texBatchNum.MenuManager = this.barManager1;
            this.texBatchNum.Name = "texBatchNum";
            this.texBatchNum.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texBatchNum.Properties.Appearance.Options.UseFont = true;
            this.texBatchNum.Properties.ReadOnly = true;
            this.texBatchNum.Size = new System.Drawing.Size(122, 20);
            this.texBatchNum.TabIndex = 20;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(215, 47);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 14);
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "生产周期：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(215, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 14);
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "下单日期：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(19, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 14);
            this.labelControl2.TabIndex = 17;
            this.labelControl2.Text = "总产值：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(19, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 14);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "周次：";
            // 
            // FormPlanStock
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 456);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "FormPlanStock";
            this.Text = "备料车间生产周计划";
            this.Controls.SetChildIndex(this.hideContainerRight, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PLT001;
        private DevExpress . XtraGrid . Columns . GridColumn OPI003;
        private DevExpress . XtraGrid . Columns . GridColumn PLT004;
        private DevExpress . XtraGrid . Columns . GridColumn PLT005;
        private DevExpress . XtraGrid . Columns . GridColumn PLT006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn PLT007;
        private DevExpress . XtraGrid . Columns . GridColumn PLT008;
        private DevExpress . XtraGrid . Columns . GridColumn PLT002;
        private DevExpress . XtraGrid . Columns . GridColumn PLT003;
        private DevExpress . XtraGrid . Columns . GridColumn PLT012;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraGrid . Columns . GridColumn OPI004;
        private DevExpress . XtraGrid . Columns . GridColumn PLT013;
        private DevExpress . XtraBars . Docking . DockManager dockManager1;
        private DevExpress . XtraBars . Docking . DockPanel dockPanel1;
        private DevExpress . XtraBars . Docking . ControlContainer dockPanel1_Container;
        private DevExpress . XtraEditors . PanelControl panelControl1;
        private System . Windows . Forms . TextBox textRemark;
        private DevExpress . XtraBars . Docking . AutoHideContainer hideContainerRight;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private DevExpress . XtraEditors . TextEdit texBatchNum;
        private DevExpress . XtraEditors . TextEdit texValue;
        private DevExpress . XtraEditors . LabelControl labelControl5;
        private DevExpress . XtraEditors . DateEdit dtpOrder;
        private DevExpress . XtraEditors . DateEdit dtpEnd;
        private DevExpress . XtraEditors . DateEdit dtpStart;
    }
}