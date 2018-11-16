namespace Carpenter
{
    partial class FormAssembleWorkOrder
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
            this.workPerson = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.workEndDate = new DevExpress.XtraEditors.DateEdit();
            this.workStartDate = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.checks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.AWQ002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.textRemark = new System.Windows.Forms.TextBox();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.workPerson);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.workEndDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.workStartDate);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1208, 411);
            this.splitContainerControl1.SplitterPosition = 68;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // workPerson
            // 
            this.workPerson.Location = new System.Drawing.Point(319, 12);
            this.workPerson.MenuManager = this.barManager1;
            this.workPerson.Name = "workPerson";
            this.workPerson.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workPerson.Properties.Appearance.Options.UseFont = true;
            this.workPerson.Properties.ReadOnly = true;
            this.workPerson.Size = new System.Drawing.Size(124, 20);
            this.workPerson.TabIndex = 40;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(257, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 14);
            this.labelControl2.TabIndex = 39;
            this.labelControl2.Text = "经办人：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(21, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 38;
            this.labelControl1.Text = "完工时间：";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(21, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 14);
            this.labelControl4.TabIndex = 37;
            this.labelControl4.Text = "派工时间：";
            // 
            // workEndDate
            // 
            this.workEndDate.EditValue = null;
            this.workEndDate.Location = new System.Drawing.Point(97, 45);
            this.workEndDate.Name = "workEndDate";
            this.workEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.workEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.workEndDate.Size = new System.Drawing.Size(124, 20);
            this.workEndDate.TabIndex = 5;
            // 
            // workStartDate
            // 
            this.workStartDate.EditValue = null;
            this.workStartDate.Location = new System.Drawing.Point(97, 11);
            this.workStartDate.Name = "workStartDate";
            this.workStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.workStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.workStartDate.Size = new System.Drawing.Size(124, 20);
            this.workStartDate.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemCheckEdit2});
            this.gridControl1.Size = new System.Drawing.Size(1208, 331);
            this.gridControl1.TabIndex = 4;
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
            this.checks,
            this.AWQ002,
            this.AWQ003,
            this.AWQ004,
            this.AWQ005,
            this.AWQ009,
            this.AWQ010,
            this.AWQ006,
            this.AWQ007,
            this.OPI006,
            this.AWQ008,
            this.idx});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // checks
            // 
            this.checks.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.checks.AppearanceCell.Options.UseFont = true;
            this.checks.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.checks.AppearanceHeader.Options.UseFont = true;
            this.checks.Caption = "选择";
            this.checks.ColumnEdit = this.repositoryItemCheckEdit2;
            this.checks.FieldName = "checks";
            this.checks.Name = "checks";
            this.checks.Width = 36;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // AWQ002
            // 
            this.AWQ002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ002.AppearanceCell.Options.UseFont = true;
            this.AWQ002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ002.AppearanceHeader.Options.UseFont = true;
            this.AWQ002.Caption = "批号";
            this.AWQ002.FieldName = "AWQ002";
            this.AWQ002.Name = "AWQ002";
            this.AWQ002.OptionsColumn.AllowEdit = false;
            this.AWQ002.Visible = true;
            this.AWQ002.VisibleIndex = 0;
            this.AWQ002.Width = 47;
            // 
            // AWQ003
            // 
            this.AWQ003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ003.AppearanceCell.Options.UseFont = true;
            this.AWQ003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ003.AppearanceHeader.Options.UseFont = true;
            this.AWQ003.Caption = "产品品号";
            this.AWQ003.FieldName = "AWQ003";
            this.AWQ003.Name = "AWQ003";
            this.AWQ003.OptionsColumn.AllowEdit = false;
            this.AWQ003.Visible = true;
            this.AWQ003.VisibleIndex = 1;
            this.AWQ003.Width = 132;
            // 
            // AWQ004
            // 
            this.AWQ004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ004.AppearanceCell.Options.UseFont = true;
            this.AWQ004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ004.AppearanceHeader.Options.UseFont = true;
            this.AWQ004.Caption = "产品名称";
            this.AWQ004.FieldName = "AWQ004";
            this.AWQ004.Name = "AWQ004";
            this.AWQ004.OptionsColumn.AllowEdit = false;
            this.AWQ004.Visible = true;
            this.AWQ004.VisibleIndex = 2;
            this.AWQ004.Width = 125;
            // 
            // AWQ005
            // 
            this.AWQ005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ005.AppearanceCell.Options.UseFont = true;
            this.AWQ005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ005.AppearanceHeader.Options.UseFont = true;
            this.AWQ005.Caption = "规格";
            this.AWQ005.FieldName = "AWQ005";
            this.AWQ005.Name = "AWQ005";
            this.AWQ005.OptionsColumn.AllowEdit = false;
            this.AWQ005.Visible = true;
            this.AWQ005.VisibleIndex = 3;
            this.AWQ005.Width = 81;
            // 
            // AWQ009
            // 
            this.AWQ009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ009.AppearanceCell.Options.UseFont = true;
            this.AWQ009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ009.AppearanceHeader.Options.UseFont = true;
            this.AWQ009.Caption = "人员编号";
            this.AWQ009.FieldName = "AWQ009";
            this.AWQ009.Name = "AWQ009";
            this.AWQ009.OptionsColumn.AllowEdit = false;
            this.AWQ009.Visible = true;
            this.AWQ009.VisibleIndex = 4;
            this.AWQ009.Width = 69;
            // 
            // AWQ010
            // 
            this.AWQ010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ010.AppearanceCell.Options.UseFont = true;
            this.AWQ010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ010.AppearanceHeader.Options.UseFont = true;
            this.AWQ010.Caption = "人员姓名";
            this.AWQ010.FieldName = "AWQ010";
            this.AWQ010.Name = "AWQ010";
            this.AWQ010.OptionsColumn.AllowEdit = false;
            this.AWQ010.Visible = true;
            this.AWQ010.VisibleIndex = 5;
            this.AWQ010.Width = 65;
            // 
            // AWQ006
            // 
            this.AWQ006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ006.AppearanceCell.Options.UseFont = true;
            this.AWQ006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ006.AppearanceHeader.Options.UseFont = true;
            this.AWQ006.Caption = "数量";
            this.AWQ006.FieldName = "AWQ006";
            this.AWQ006.Name = "AWQ006";
            this.AWQ006.Visible = true;
            this.AWQ006.VisibleIndex = 6;
            this.AWQ006.Width = 71;
            // 
            // AWQ007
            // 
            this.AWQ007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ007.AppearanceCell.Options.UseFont = true;
            this.AWQ007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ007.AppearanceHeader.Options.UseFont = true;
            this.AWQ007.Caption = "单价";
            this.AWQ007.FieldName = "AWQ007";
            this.AWQ007.Name = "AWQ007";
            this.AWQ007.Visible = true;
            this.AWQ007.VisibleIndex = 7;
            this.AWQ007.Width = 67;
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
            this.OPI006.Visible = true;
            this.OPI006.VisibleIndex = 8;
            this.OPI006.Width = 77;
            // 
            // AWQ008
            // 
            this.AWQ008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ008.AppearanceCell.Options.UseFont = true;
            this.AWQ008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ008.AppearanceHeader.Options.UseFont = true;
            this.AWQ008.Caption = "备注";
            this.AWQ008.FieldName = "AWQ008";
            this.AWQ008.Name = "AWQ008";
            this.AWQ008.Visible = true;
            this.AWQ008.VisibleIndex = 9;
            this.AWQ008.Width = 279;
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "完工",
            "未完工"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
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
            this.hideContainerRight.Size = new System.Drawing.Size(36, 411);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("8455e90e-e9ae-47ff-956f-55c7596a17b8");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(200, 437);
            this.dockPanel1.Text = "数据逻辑";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panelControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 39);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(191, 394);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textRemark);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(191, 394);
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
            this.textRemark.Size = new System.Drawing.Size(187, 390);
            this.textRemark.TabIndex = 4;
            this.textRemark.Text = " * 同生产批号、同品号、同生产人可以多次派工，直至派工数量等于订单量";
            // 
            // wait
            // 
            this.wait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wait.Appearance.Options.UseBackColor = true;
            this.wait.BarAnimationElementThickness = 2;
            this.wait.Caption = "请稍后";
            this.wait.Description = "数据加载中 ...";
            this.wait.Location = new System.Drawing.Point(499, 185);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 35;
            this.wait.Text = "progressPanel1";
            // 
            // FormAssembleWorkOrder
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 437);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "FormAssembleWorkOrder";
            this.Text = "组装派工单";
            this.Controls.SetChildIndex(this.hideContainerRight, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.wait, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.workPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
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
        private DevExpress . XtraEditors . DateEdit workStartDate;
        private DevExpress . XtraEditors . DateEdit workEndDate;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ002;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ003;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ004;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ005;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ006;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ007;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ008;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private System . ComponentModel . BackgroundWorker backgroundWorker2;
        private DevExpress . XtraGrid . Columns . GridColumn checks;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ009;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ010;
        private DevExpress . XtraBars . Docking . DockManager dockManager1;
        private DevExpress . XtraBars . Docking . DockPanel dockPanel1;
        private DevExpress . XtraBars . Docking . ControlContainer dockPanel1_Container;
        private DevExpress . XtraEditors . PanelControl panelControl1;
        private System . Windows . Forms . TextBox textRemark;
        private DevExpress . XtraBars . Docking . AutoHideContainer hideContainerRight;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . TextEdit workPerson;
    }
}