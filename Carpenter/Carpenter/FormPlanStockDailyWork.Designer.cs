namespace Carpenter
{
    partial class FormPlanStockDailyWork
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.textRemark = new System.Windows.Forms.TextBox();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dtpOrder = new DevExpress.XtraEditors.DateEdit();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lupProN = new DevExpress.XtraEditors.LookUpEdit();
            this.lupPn = new DevExpress.XtraEditors.LookUpEdit();
            this.lupOddNum = new DevExpress.XtraEditors.LookUpEdit();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PDW001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW015 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW016 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U0 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST028 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.OPI004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW014 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOrder.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupOddNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
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
            this.hideContainerRight.Location = new System.Drawing.Point(1210, 26);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(36, 408);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("02a0f097-9925-46d1-aa60-a853a9398f21");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(200, 434);
            this.dockPanel1.Text = "数据逻辑";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panelControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 39);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(191, 391);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textRemark);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(191, 391);
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
            this.textRemark.Size = new System.Drawing.Size(187, 387);
            this.textRemark.TabIndex = 1;
            this.textRemark.Text = " * 同生产批号、同品号、同工段允许报工多次，直至累计报工数量等于计划数量为止\r\n\r\n * 报工条件：日计划单号、批号、品号、工段\r\n\r\n * 计划报工：日计划预" +
    "排或完工状态为未完工";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpOrder);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnClear);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupProN);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupPn);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupOddNum);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.wait);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1210, 408);
            this.splitContainerControl1.SplitterPosition = 41;
            this.splitContainerControl1.TabIndex = 35;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // dtpOrder
            // 
            this.dtpOrder.EditValue = null;
            this.dtpOrder.Location = new System.Drawing.Point(305, 12);
            this.dtpOrder.MenuManager = this.barManager1;
            this.dtpOrder.Name = "dtpOrder";
            this.dtpOrder.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrder.Properties.Appearance.Options.UseFont = true;
            this.dtpOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOrder.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOrder.Size = new System.Drawing.Size(138, 20);
            this.dtpOrder.TabIndex = 41;
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.Location = new System.Drawing.Point(950, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(53, 23);
            this.btnClear.TabIndex = 40;
            this.btnClear.Text = "清除";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(691, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 14);
            this.labelControl4.TabIndex = 38;
            this.labelControl4.Text = "报工品号：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(474, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 14);
            this.labelControl3.TabIndex = 39;
            this.labelControl3.Text = "报工批号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(229, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 38;
            this.labelControl2.Text = "报工日期：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(19, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 37;
            this.labelControl1.Text = "报工单号：";
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
            this.lupProN.TabIndex = 22;
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
            this.lupPn.TabIndex = 21;
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
            this.lupOddNum.TabIndex = 20;
            // 
            // wait
            // 
            this.wait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wait.Appearance.Options.UseBackColor = true;
            this.wait.BarAnimationElementThickness = 2;
            this.wait.Caption = "请稍后";
            this.wait.Description = "数据加载中 ...";
            this.wait.Location = new System.Drawing.Point(430, 100);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 33;
            this.wait.Text = "progressPanel1";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1210, 355);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PDW001,
            this.PDW002,
            this.PDW003,
            this.PDW004,
            this.OPI006,
            this.OPI007,
            this.PDW006,
            this.PDW007,
            this.PDW008,
            this.PDW009,
            this.PDW010,
            this.PDW011,
            this.PDW012,
            this.PDW015,
            this.idx,
            this.PDW016,
            this.U0,
            this.PST028,
            this.OPI004,
            this.PDW014});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PDW001
            // 
            this.PDW001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW001.AppearanceCell.Options.UseFont = true;
            this.PDW001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW001.AppearanceHeader.Options.UseFont = true;
            this.PDW001.Caption = "单号";
            this.PDW001.FieldName = "PDW001";
            this.PDW001.Name = "PDW001";
            this.PDW001.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PDW001.Visible = true;
            this.PDW001.VisibleIndex = 0;
            this.PDW001.Width = 76;
            // 
            // PDW002
            // 
            this.PDW002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW002.AppearanceCell.Options.UseFont = true;
            this.PDW002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW002.AppearanceHeader.Options.UseFont = true;
            this.PDW002.Caption = "批号";
            this.PDW002.FieldName = "PDW002";
            this.PDW002.Name = "PDW002";
            this.PDW002.OptionsColumn.AllowEdit = false;
            this.PDW002.Visible = true;
            this.PDW002.VisibleIndex = 1;
            this.PDW002.Width = 42;
            // 
            // PDW003
            // 
            this.PDW003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW003.AppearanceCell.Options.UseFont = true;
            this.PDW003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW003.AppearanceHeader.Options.UseFont = true;
            this.PDW003.Caption = "产品品号";
            this.PDW003.FieldName = "PDW003";
            this.PDW003.Name = "PDW003";
            this.PDW003.OptionsColumn.AllowEdit = false;
            this.PDW003.Visible = true;
            this.PDW003.VisibleIndex = 2;
            this.PDW003.Width = 89;
            // 
            // PDW004
            // 
            this.PDW004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW004.AppearanceCell.Options.UseFont = true;
            this.PDW004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW004.AppearanceHeader.Options.UseFont = true;
            this.PDW004.Caption = "产品名称";
            this.PDW004.FieldName = "PDW004";
            this.PDW004.Name = "PDW004";
            this.PDW004.OptionsColumn.AllowEdit = false;
            this.PDW004.Visible = true;
            this.PDW004.VisibleIndex = 3;
            this.PDW004.Width = 93;
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
            this.OPI006.VisibleIndex = 5;
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
            this.OPI007.Visible = true;
            this.OPI007.VisibleIndex = 6;
            this.OPI007.Width = 39;
            // 
            // PDW006
            // 
            this.PDW006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW006.AppearanceCell.Options.UseFont = true;
            this.PDW006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW006.AppearanceHeader.Options.UseFont = true;
            this.PDW006.Caption = "计划数量";
            this.PDW006.FieldName = "PDW006";
            this.PDW006.Name = "PDW006";
            this.PDW006.OptionsColumn.AllowEdit = false;
            this.PDW006.Visible = true;
            this.PDW006.VisibleIndex = 8;
            this.PDW006.Width = 70;
            // 
            // PDW007
            // 
            this.PDW007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW007.AppearanceCell.Options.UseFont = true;
            this.PDW007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW007.AppearanceHeader.Options.UseFont = true;
            this.PDW007.Caption = "断料数量";
            this.PDW007.FieldName = "PDW007";
            this.PDW007.Name = "PDW007";
            this.PDW007.Visible = true;
            this.PDW007.VisibleIndex = 10;
            this.PDW007.Width = 66;
            // 
            // PDW008
            // 
            this.PDW008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW008.AppearanceCell.Options.UseFont = true;
            this.PDW008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW008.AppearanceHeader.Options.UseFont = true;
            this.PDW008.Caption = "修边数量";
            this.PDW008.FieldName = "PDW008";
            this.PDW008.Name = "PDW008";
            this.PDW008.Visible = true;
            this.PDW008.VisibleIndex = 11;
            this.PDW008.Width = 66;
            // 
            // PDW009
            // 
            this.PDW009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW009.AppearanceCell.Options.UseFont = true;
            this.PDW009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW009.AppearanceHeader.Options.UseFont = true;
            this.PDW009.Caption = "齿接数量";
            this.PDW009.FieldName = "PDW009";
            this.PDW009.Name = "PDW009";
            this.PDW009.Visible = true;
            this.PDW009.VisibleIndex = 12;
            this.PDW009.Width = 66;
            // 
            // PDW010
            // 
            this.PDW010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW010.AppearanceCell.Options.UseFont = true;
            this.PDW010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW010.AppearanceHeader.Options.UseFont = true;
            this.PDW010.Caption = "拼板数量";
            this.PDW010.FieldName = "PDW010";
            this.PDW010.Name = "PDW010";
            this.PDW010.Visible = true;
            this.PDW010.VisibleIndex = 13;
            this.PDW010.Width = 69;
            // 
            // PDW011
            // 
            this.PDW011.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW011.AppearanceCell.Options.UseFont = true;
            this.PDW011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW011.AppearanceHeader.Options.UseFont = true;
            this.PDW011.Caption = "刨床数量";
            this.PDW011.FieldName = "PDW011";
            this.PDW011.Name = "PDW011";
            this.PDW011.Visible = true;
            this.PDW011.VisibleIndex = 14;
            this.PDW011.Width = 66;
            // 
            // PDW012
            // 
            this.PDW012.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW012.AppearanceCell.Options.UseFont = true;
            this.PDW012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW012.AppearanceHeader.Options.UseFont = true;
            this.PDW012.Caption = "报工时间";
            this.PDW012.FieldName = "PDW012";
            this.PDW012.Name = "PDW012";
            this.PDW012.Visible = true;
            this.PDW012.VisibleIndex = 16;
            this.PDW012.Width = 93;
            // 
            // PDW015
            // 
            this.PDW015.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW015.AppearanceCell.Options.UseFont = true;
            this.PDW015.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW015.AppearanceHeader.Options.UseFont = true;
            this.PDW015.Caption = "计划报工";
            this.PDW015.FieldName = "PDW015";
            this.PDW015.Name = "PDW015";
            this.PDW015.Visible = true;
            this.PDW015.VisibleIndex = 17;
            this.PDW015.Width = 98;
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // PDW016
            // 
            this.PDW016.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW016.AppearanceCell.Options.UseFont = true;
            this.PDW016.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW016.AppearanceHeader.Options.UseFont = true;
            this.PDW016.Caption = "日计划单号";
            this.PDW016.FieldName = "PDW016";
            this.PDW016.Name = "PDW016";
            this.PDW016.Visible = true;
            this.PDW016.VisibleIndex = 9;
            this.PDW016.Width = 80;
            // 
            // U0
            // 
            this.U0.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U0.AppearanceCell.Options.UseFont = true;
            this.U0.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U0.AppearanceHeader.Options.UseFont = true;
            this.U0.Caption = "产值";
            this.U0.DisplayFormat.FormatString = "0.####";
            this.U0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.U0.FieldName = "U0";
            this.U0.Name = "U0";
            this.U0.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "U0", "{0:0.####}")});
            this.U0.Visible = true;
            this.U0.VisibleIndex = 15;
            // 
            // PST028
            // 
            this.PST028.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PST028.AppearanceCell.Options.UseFont = true;
            this.PST028.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PST028.AppearanceHeader.Options.UseFont = true;
            this.PST028.Caption = "订单数量";
            this.PST028.FieldName = "PST028";
            this.PST028.Name = "PST028";
            this.PST028.Visible = true;
            this.PST028.VisibleIndex = 7;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // OPI004
            // 
            this.OPI004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI004.AppearanceCell.Options.UseFont = true;
            this.OPI004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI004.AppearanceHeader.Options.UseFont = true;
            this.OPI004.Caption = "产品产值";
            this.OPI004.FieldName = "OPI004";
            this.OPI004.Name = "OPI004";
            this.OPI004.Visible = true;
            this.OPI004.VisibleIndex = 4;
            // 
            // PDW014
            // 
            this.PDW014.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW014.AppearanceCell.Options.UseFont = true;
            this.PDW014.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW014.AppearanceHeader.Options.UseFont = true;
            this.PDW014.Caption = "报工人";
            this.PDW014.FieldName = "PDW014";
            this.PDW014.Name = "PDW014";
            this.PDW014.Visible = true;
            this.PDW014.VisibleIndex = 18;
            // 
            // FormPlanStockDailyWork
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 434);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "FormPlanStockDailyWork";
            this.Text = "备料日计划报工记录";
            this.Load += new System.EventHandler(this.FormPlanStockDailyWork_Load);
            this.Controls.SetChildIndex(this.hideContainerRight, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpOrder.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupOddNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraBars . Docking . DockManager dockManager1;
        private DevExpress . XtraBars . Docking . DockPanel dockPanel1;
        private DevExpress . XtraBars . Docking . ControlContainer dockPanel1_Container;
        private DevExpress . XtraEditors . PanelControl panelControl1;
        private System . Windows . Forms . TextBox textRemark;
        private DevExpress . XtraBars . Docking . AutoHideContainer hideContainerRight;
        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraEditors . LookUpEdit lupProN;
        private DevExpress . XtraEditors . LookUpEdit lupPn;
        private DevExpress . XtraEditors . LookUpEdit lupOddNum;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PDW001;
        private DevExpress . XtraGrid . Columns . GridColumn PDW002;
        private DevExpress . XtraGrid . Columns . GridColumn PDW003;
        private DevExpress . XtraGrid . Columns . GridColumn PDW004;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn PDW006;
        private DevExpress . XtraGrid . Columns . GridColumn PDW007;
        private DevExpress . XtraGrid . Columns . GridColumn PDW008;
        private DevExpress . XtraGrid . Columns . GridColumn PDW009;
        private DevExpress . XtraGrid . Columns . GridColumn PDW010;
        private DevExpress . XtraGrid . Columns . GridColumn PDW011;
        private DevExpress . XtraGrid . Columns . GridColumn PDW012;
        private DevExpress . XtraGrid . Columns . GridColumn PDW015;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn PDW016;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private DevExpress . XtraEditors . SimpleButton btnClear;
        private DevExpress . XtraEditors . DateEdit dtpOrder;
        private DevExpress . XtraGrid . Columns . GridColumn U0;
        private DevExpress . XtraGrid . Columns . GridColumn PST028;
        private DevExpress . XtraGrid . Columns . GridColumn OPI004;
        private DevExpress . XtraGrid . Columns . GridColumn PDW014;
    }
}