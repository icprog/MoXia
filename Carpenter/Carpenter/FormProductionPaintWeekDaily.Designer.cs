namespace Carpenter
{
    partial class FormProductionPaintWeekDaily
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
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.dtOrder = new DevExpress.XtraEditors.DateEdit();
            this.lupProN = new DevExpress.XtraEditors.LookUpEdit();
            this.lupPn = new DevExpress.XtraEditors.LookUpEdit();
            this.lupOddNum = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PWI009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWI001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWI002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWI003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWI004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWI012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWI008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dtOrder.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupOddNum.Properties)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnClear);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtOrder);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupProN);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupPn);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupOddNum);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1206, 421);
            this.splitContainerControl1.SplitterPosition = 37;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(702, 16);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 14);
            this.labelControl4.TabIndex = 69;
            this.labelControl4.Text = "报工品号：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(485, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 14);
            this.labelControl3.TabIndex = 68;
            this.labelControl3.Text = "报工批号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(240, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 67;
            this.labelControl2.Text = "报工日期：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(30, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 66;
            this.labelControl1.Text = "报工单号：";
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.Location = new System.Drawing.Point(955, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 65;
            this.btnClear.Text = "清除";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dtOrder
            // 
            this.dtOrder.EditValue = null;
            this.dtOrder.Location = new System.Drawing.Point(316, 13);
            this.dtOrder.Name = "dtOrder";
            this.dtOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtOrder.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtOrder.Size = new System.Drawing.Size(115, 20);
            this.dtOrder.TabIndex = 64;
            // 
            // lupProN
            // 
            this.lupProN.Location = new System.Drawing.Point(778, 13);
            this.lupProN.Name = "lupProN";
            this.lupProN.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupProN.Properties.Appearance.Options.UseFont = true;
            this.lupProN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupProN.Properties.NullText = "";
            this.lupProN.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupProN.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupProN.Properties.ShowHeader = false;
            this.lupProN.Size = new System.Drawing.Size(156, 20);
            this.lupProN.TabIndex = 62;
            // 
            // lupPn
            // 
            this.lupPn.Location = new System.Drawing.Point(561, 13);
            this.lupPn.Name = "lupPn";
            this.lupPn.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupPn.Properties.Appearance.Options.UseFont = true;
            this.lupPn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPn.Properties.NullText = "";
            this.lupPn.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupPn.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupPn.Properties.ShowHeader = false;
            this.lupPn.Size = new System.Drawing.Size(110, 20);
            this.lupPn.TabIndex = 61;
            // 
            // lupOddNum
            // 
            this.lupOddNum.Location = new System.Drawing.Point(106, 13);
            this.lupOddNum.Name = "lupOddNum";
            this.lupOddNum.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupOddNum.Properties.Appearance.Options.UseFont = true;
            this.lupOddNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupOddNum.Properties.NullText = "";
            this.lupOddNum.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupOddNum.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupOddNum.Properties.ShowHeader = false;
            this.lupOddNum.Size = new System.Drawing.Size(110, 20);
            this.lupOddNum.TabIndex = 60;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1206, 372);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PWI009,
            this.PWI001,
            this.PWI002,
            this.PWI003,
            this.PWI004,
            this.OPI006,
            this.OPI007,
            this.PWI006,
            this.PWI007,
            this.PWI012,
            this.PWI008,
            this.idx});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PWI009
            // 
            this.PWI009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI009.AppearanceCell.Options.UseFont = true;
            this.PWI009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI009.AppearanceHeader.Options.UseFont = true;
            this.PWI009.AppearanceHeader.Options.UseTextOptions = true;
            this.PWI009.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PWI009.Caption = "周计划单号";
            this.PWI009.FieldName = "PWI009";
            this.PWI009.Name = "PWI009";
            this.PWI009.Visible = true;
            this.PWI009.VisibleIndex = 10;
            // 
            // PWI001
            // 
            this.PWI001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI001.AppearanceCell.Options.UseFont = true;
            this.PWI001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI001.AppearanceHeader.Options.UseFont = true;
            this.PWI001.Caption = "单号";
            this.PWI001.FieldName = "PWI001";
            this.PWI001.Name = "PWI001";
            this.PWI001.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PWI001.Visible = true;
            this.PWI001.VisibleIndex = 0;
            this.PWI001.Width = 82;
            // 
            // PWI002
            // 
            this.PWI002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI002.AppearanceCell.Options.UseFont = true;
            this.PWI002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI002.AppearanceHeader.Options.UseFont = true;
            this.PWI002.Caption = "批号";
            this.PWI002.FieldName = "PWI002";
            this.PWI002.Name = "PWI002";
            this.PWI002.OptionsColumn.AllowEdit = false;
            this.PWI002.Visible = true;
            this.PWI002.VisibleIndex = 1;
            this.PWI002.Width = 46;
            // 
            // PWI003
            // 
            this.PWI003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI003.AppearanceCell.Options.UseFont = true;
            this.PWI003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI003.AppearanceHeader.Options.UseFont = true;
            this.PWI003.Caption = "产品品号";
            this.PWI003.FieldName = "PWI003";
            this.PWI003.Name = "PWI003";
            this.PWI003.OptionsColumn.AllowEdit = false;
            this.PWI003.Visible = true;
            this.PWI003.VisibleIndex = 2;
            this.PWI003.Width = 96;
            // 
            // PWI004
            // 
            this.PWI004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI004.AppearanceCell.Options.UseFont = true;
            this.PWI004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI004.AppearanceHeader.Options.UseFont = true;
            this.PWI004.Caption = "产品名称";
            this.PWI004.FieldName = "PWI004";
            this.PWI004.Name = "PWI004";
            this.PWI004.OptionsColumn.AllowEdit = false;
            this.PWI004.Visible = true;
            this.PWI004.VisibleIndex = 3;
            this.PWI004.Width = 100;
            // 
            // OPI006
            // 
            this.OPI006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI006.AppearanceCell.Options.UseFont = true;
            this.OPI006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI006.AppearanceHeader.Options.UseFont = true;
            this.OPI006.Caption = "材质";
            this.OPI006.FieldName = "OPI006";
            this.OPI006.Name = "OPI006";
            this.OPI006.OptionsColumn.AllowEdit = false;
            this.OPI006.Visible = true;
            this.OPI006.VisibleIndex = 4;
            this.OPI006.Width = 53;
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
            this.OPI007.Visible = true;
            this.OPI007.VisibleIndex = 5;
            this.OPI007.Width = 42;
            // 
            // PWI006
            // 
            this.PWI006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI006.AppearanceCell.Options.UseFont = true;
            this.PWI006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI006.AppearanceHeader.Options.UseFont = true;
            this.PWI006.Caption = "订单数量";
            this.PWI006.FieldName = "PWI006";
            this.PWI006.Name = "PWI006";
            this.PWI006.OptionsColumn.AllowEdit = false;
            this.PWI006.Visible = true;
            this.PWI006.VisibleIndex = 6;
            this.PWI006.Width = 76;
            // 
            // PWI007
            // 
            this.PWI007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI007.AppearanceCell.Options.UseFont = true;
            this.PWI007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI007.AppearanceHeader.Options.UseFont = true;
            this.PWI007.Caption = "报工数量";
            this.PWI007.FieldName = "PWI007";
            this.PWI007.Name = "PWI007";
            this.PWI007.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PWI007", "{0}")});
            this.PWI007.Visible = true;
            this.PWI007.VisibleIndex = 7;
            this.PWI007.Width = 71;
            // 
            // PWI012
            // 
            this.PWI012.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI012.AppearanceCell.Options.UseFont = true;
            this.PWI012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI012.AppearanceHeader.Options.UseFont = true;
            this.PWI012.Caption = "报工时间";
            this.PWI012.FieldName = "PWI012";
            this.PWI012.Name = "PWI012";
            this.PWI012.Visible = true;
            this.PWI012.VisibleIndex = 8;
            this.PWI012.Width = 102;
            // 
            // PWI008
            // 
            this.PWI008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI008.AppearanceCell.Options.UseFont = true;
            this.PWI008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI008.AppearanceHeader.Options.UseFont = true;
            this.PWI008.Caption = "计划报工";
            this.PWI008.FieldName = "PWI008";
            this.PWI008.Name = "PWI008";
            this.PWI008.Visible = true;
            this.PWI008.VisibleIndex = 9;
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
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
            this.hideContainerRight.Location = new System.Drawing.Point(1206, 26);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(36, 421);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("ca49be32-efe8-47bf-9514-0c684b3a9592");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(200, 447);
            this.dockPanel1.Text = "数据逻辑";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panelControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 39);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(191, 404);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textRemark);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(191, 404);
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
            this.textRemark.Size = new System.Drawing.Size(187, 400);
            this.textRemark.TabIndex = 4;
            this.textRemark.Text = " * 同生产批号、同品号允许报工多次，直至累计报工数量等于订单量为止\r\n\r\n * 报工条件：批号、品号\r\n\r\n * 计划报工：周计划预排";
            // 
            // wait
            // 
            this.wait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wait.Appearance.Options.UseBackColor = true;
            this.wait.BarAnimationElementThickness = 2;
            this.wait.Caption = "请稍后";
            this.wait.Description = "数据加载中 ...";
            this.wait.Location = new System.Drawing.Point(498, 190);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 33;
            this.wait.Text = "progressPanel1";
            // 
            // FormProductionPaintWeekDaily
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 447);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "FormProductionPaintWeekDaily";
            this.Text = "油漆车间生产周计划报工";
            this.Controls.SetChildIndex(this.hideContainerRight, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.wait, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtOrder.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupOddNum.Properties)).EndInit();
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
        private DevExpress . XtraEditors . DateEdit dtOrder;
        private DevExpress . XtraEditors . LookUpEdit lupProN;
        private DevExpress . XtraEditors . LookUpEdit lupPn;
        private DevExpress . XtraEditors . LookUpEdit lupOddNum;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PWI001;
        private DevExpress . XtraGrid . Columns . GridColumn PWI002;
        private DevExpress . XtraGrid . Columns . GridColumn PWI003;
        private DevExpress . XtraGrid . Columns . GridColumn PWI004;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn PWI006;
        private DevExpress . XtraGrid . Columns . GridColumn PWI007;
        private DevExpress . XtraGrid . Columns . GridColumn PWI012;
        private DevExpress . XtraGrid . Columns . GridColumn PWI008;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraBars . Docking . DockManager dockManager1;
        private DevExpress . XtraBars . Docking . DockPanel dockPanel1;
        private DevExpress . XtraBars . Docking . ControlContainer dockPanel1_Container;
        private DevExpress . XtraEditors . PanelControl panelControl1;
        private System . Windows . Forms . TextBox textRemark;
        private DevExpress . XtraBars . Docking . AutoHideContainer hideContainerRight;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private DevExpress . XtraGrid . Columns . GridColumn PWI009;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . SimpleButton btnClear;
    }
}