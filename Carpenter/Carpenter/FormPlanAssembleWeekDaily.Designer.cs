namespace Carpenter
{
    partial class FormPlanAssembleWeekDaily
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
            this.PLC001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLC002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLC003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLC004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLC006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLC007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLC012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLC008 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.splitContainerControl1.Size = new System.Drawing.Size(1208, 434);
            this.splitContainerControl1.SplitterPosition = 44;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(691, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 14);
            this.labelControl4.TabIndex = 69;
            this.labelControl4.Text = "报工品号：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(474, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 14);
            this.labelControl3.TabIndex = 68;
            this.labelControl3.Text = "报工批号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(229, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 67;
            this.labelControl2.Text = "报工日期：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(19, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 66;
            this.labelControl1.Text = "报工单号：";
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.Location = new System.Drawing.Point(945, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 65;
            this.btnClear.Text = "清除";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dtOrder
            // 
            this.dtOrder.EditValue = null;
            this.dtOrder.Location = new System.Drawing.Point(305, 12);
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
            this.lupProN.Location = new System.Drawing.Point(767, 12);
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
            this.lupPn.Location = new System.Drawing.Point(550, 12);
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
            this.lupOddNum.Location = new System.Drawing.Point(95, 12);
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
            this.gridControl1.Size = new System.Drawing.Size(1208, 378);
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
            this.PLC001,
            this.PLC002,
            this.PLC003,
            this.PLC004,
            this.OPI006,
            this.OPI007,
            this.PLC006,
            this.PLC007,
            this.PLC012,
            this.PLC008,
            this.idx});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PLC001
            // 
            this.PLC001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC001.AppearanceCell.Options.UseFont = true;
            this.PLC001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC001.AppearanceHeader.Options.UseFont = true;
            this.PLC001.Caption = "单号";
            this.PLC001.FieldName = "PLC001";
            this.PLC001.Name = "PLC001";
            this.PLC001.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLC001.Visible = true;
            this.PLC001.VisibleIndex = 0;
            this.PLC001.Width = 82;
            // 
            // PLC002
            // 
            this.PLC002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC002.AppearanceCell.Options.UseFont = true;
            this.PLC002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC002.AppearanceHeader.Options.UseFont = true;
            this.PLC002.Caption = "批号";
            this.PLC002.FieldName = "PLC002";
            this.PLC002.Name = "PLC002";
            this.PLC002.OptionsColumn.AllowEdit = false;
            this.PLC002.Visible = true;
            this.PLC002.VisibleIndex = 1;
            this.PLC002.Width = 46;
            // 
            // PLC003
            // 
            this.PLC003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC003.AppearanceCell.Options.UseFont = true;
            this.PLC003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC003.AppearanceHeader.Options.UseFont = true;
            this.PLC003.Caption = "产品品号";
            this.PLC003.FieldName = "PLC003";
            this.PLC003.Name = "PLC003";
            this.PLC003.OptionsColumn.AllowEdit = false;
            this.PLC003.Visible = true;
            this.PLC003.VisibleIndex = 2;
            this.PLC003.Width = 96;
            // 
            // PLC004
            // 
            this.PLC004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC004.AppearanceCell.Options.UseFont = true;
            this.PLC004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC004.AppearanceHeader.Options.UseFont = true;
            this.PLC004.Caption = "产品名称";
            this.PLC004.FieldName = "PLC004";
            this.PLC004.Name = "PLC004";
            this.PLC004.OptionsColumn.AllowEdit = false;
            this.PLC004.Visible = true;
            this.PLC004.VisibleIndex = 3;
            this.PLC004.Width = 100;
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
            // PLC006
            // 
            this.PLC006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC006.AppearanceCell.Options.UseFont = true;
            this.PLC006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC006.AppearanceHeader.Options.UseFont = true;
            this.PLC006.Caption = "计划数量";
            this.PLC006.FieldName = "PLC006";
            this.PLC006.Name = "PLC006";
            this.PLC006.OptionsColumn.AllowEdit = false;
            this.PLC006.Visible = true;
            this.PLC006.VisibleIndex = 6;
            this.PLC006.Width = 76;
            // 
            // PLC007
            // 
            this.PLC007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC007.AppearanceCell.Options.UseFont = true;
            this.PLC007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC007.AppearanceHeader.Options.UseFont = true;
            this.PLC007.Caption = "报工数量";
            this.PLC007.FieldName = "PLC007";
            this.PLC007.Name = "PLC007";
            this.PLC007.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PLC007", "{0}")});
            this.PLC007.Visible = true;
            this.PLC007.VisibleIndex = 7;
            this.PLC007.Width = 71;
            // 
            // PLC012
            // 
            this.PLC012.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC012.AppearanceCell.Options.UseFont = true;
            this.PLC012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC012.AppearanceHeader.Options.UseFont = true;
            this.PLC012.Caption = "报工时间";
            this.PLC012.FieldName = "PLC012";
            this.PLC012.Name = "PLC012";
            this.PLC012.Visible = true;
            this.PLC012.VisibleIndex = 8;
            this.PLC012.Width = 102;
            // 
            // PLC008
            // 
            this.PLC008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC008.AppearanceCell.Options.UseFont = true;
            this.PLC008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC008.AppearanceHeader.Options.UseFont = true;
            this.PLC008.Caption = "计划报工";
            this.PLC008.FieldName = "PLC008";
            this.PLC008.Name = "PLC008";
            this.PLC008.Visible = true;
            this.PLC008.VisibleIndex = 9;
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
            this.hideContainerRight.Location = new System.Drawing.Point(1208, 26);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(36, 434);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("94f4a9af-ebe8-4285-a176-630359fefe17");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(200, 460);
            this.dockPanel1.Text = "数据逻辑";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panelControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 39);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(191, 417);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textRemark);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(191, 417);
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
            this.textRemark.Size = new System.Drawing.Size(187, 413);
            this.textRemark.TabIndex = 3;
            this.textRemark.Text = " * 同生产批号、同品号允许报工多次，直至累计报工数量等于订单量为止\r\n\r\n * 报工条件：批号、品号\r\n\r\n * 计划报工：周计划预排";
            // 
            // wait
            // 
            this.wait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wait.Appearance.Options.UseBackColor = true;
            this.wait.BarAnimationElementThickness = 2;
            this.wait.Caption = "请稍后";
            this.wait.Description = "数据加载中 ...";
            this.wait.Location = new System.Drawing.Point(499, 197);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 33;
            this.wait.Text = "progressPanel1";
            // 
            // FormPlanAssembleWeekDaily
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 460);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "FormPlanAssembleWeekDaily";
            this.Text = "组装车间生产周计划报工";
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
        private DevExpress . XtraGrid . Columns . GridColumn PLC001;
        private DevExpress . XtraGrid . Columns . GridColumn PLC002;
        private DevExpress . XtraGrid . Columns . GridColumn PLC003;
        private DevExpress . XtraGrid . Columns . GridColumn PLC004;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn PLC006;
        private DevExpress . XtraGrid . Columns . GridColumn PLC007;
        private DevExpress . XtraGrid . Columns . GridColumn PLC012;
        private DevExpress . XtraGrid . Columns . GridColumn PLC008;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraBars . Docking . DockManager dockManager1;
        private DevExpress . XtraBars . Docking . DockPanel dockPanel1;
        private DevExpress . XtraBars . Docking . ControlContainer dockPanel1_Container;
        private DevExpress . XtraEditors . PanelControl panelControl1;
        private System . Windows . Forms . TextBox textRemark;
        private DevExpress . XtraBars . Docking . AutoHideContainer hideContainerRight;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private DevExpress . XtraEditors . SimpleButton btnClear;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl1;
    }
}