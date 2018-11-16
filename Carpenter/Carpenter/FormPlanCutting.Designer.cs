namespace Carpenter
{
    partial class FormPlanCutting
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
            this.texValue = new System.Windows.Forms.TextBox();
            this.texBatchNum = new System.Windows.Forms.TextBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CUU001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUU002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUU008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUU009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUU003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUU004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUU005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimePicker3 = new DevExpress.XtraEditors.DateEdit();
            this.dateTimePicker2 = new DevExpress.XtraEditors.DateEdit();
            this.dateTimePicker1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnObtain = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePicker3.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePicker3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePicker2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePicker2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePicker1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePicker1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // texValue
            // 
            this.texValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.texValue.Location = new System.Drawing.Point(114, 47);
            this.texValue.Name = "texValue";
            this.texValue.ReadOnly = true;
            this.texValue.Size = new System.Drawing.Size(107, 23);
            this.texValue.TabIndex = 9;
            // 
            // texBatchNum
            // 
            this.texBatchNum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.texBatchNum.Location = new System.Drawing.Point(101, 13);
            this.texBatchNum.Name = "texBatchNum";
            this.texBatchNum.Size = new System.Drawing.Size(107, 23);
            this.texBatchNum.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1205, 329);
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
            this.CUU001,
            this.OPI003,
            this.CUU002,
            this.CUU008,
            this.CUU009,
            this.OPI006,
            this.OPI007,
            this.OPI004,
            this.CUU003,
            this.CUU004,
            this.CUU005});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // CUU001
            // 
            this.CUU001.Caption = "生产批号";
            this.CUU001.FieldName = "CUU001";
            this.CUU001.Name = "CUU001";
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
            this.OPI003.Visible = true;
            this.OPI003.VisibleIndex = 1;
            this.OPI003.Width = 73;
            // 
            // CUU002
            // 
            this.CUU002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU002.AppearanceCell.Options.UseFont = true;
            this.CUU002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU002.AppearanceHeader.Options.UseFont = true;
            this.CUU002.Caption = "产品品号";
            this.CUU002.FieldName = "CUU002";
            this.CUU002.Name = "CUU002";
            this.CUU002.OptionsColumn.AllowEdit = false;
            this.CUU002.Visible = true;
            this.CUU002.VisibleIndex = 2;
            this.CUU002.Width = 124;
            // 
            // CUU008
            // 
            this.CUU008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU008.AppearanceCell.Options.UseFont = true;
            this.CUU008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU008.AppearanceHeader.Options.UseFont = true;
            this.CUU008.Caption = "产品名称";
            this.CUU008.FieldName = "CUU008";
            this.CUU008.Name = "CUU008";
            this.CUU008.OptionsColumn.AllowEdit = false;
            this.CUU008.Visible = true;
            this.CUU008.VisibleIndex = 3;
            this.CUU008.Width = 144;
            // 
            // CUU009
            // 
            this.CUU009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU009.AppearanceCell.Options.UseFont = true;
            this.CUU009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU009.AppearanceHeader.Options.UseFont = true;
            this.CUU009.Caption = "规格";
            this.CUU009.FieldName = "CUU009";
            this.CUU009.Name = "CUU009";
            this.CUU009.OptionsColumn.AllowEdit = false;
            this.CUU009.Visible = true;
            this.CUU009.VisibleIndex = 4;
            this.CUU009.Width = 100;
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
            this.OPI006.VisibleIndex = 5;
            this.OPI006.Width = 52;
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
            this.OPI007.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OPI007", "总产值")});
            this.OPI007.Visible = true;
            this.OPI007.VisibleIndex = 6;
            this.OPI007.Width = 51;
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
            this.OPI004.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OPI004", "{0:0.####}")});
            this.OPI004.Visible = true;
            this.OPI004.VisibleIndex = 7;
            this.OPI004.Width = 65;
            // 
            // CUU003
            // 
            this.CUU003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU003.AppearanceCell.Options.UseFont = true;
            this.CUU003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU003.AppearanceHeader.Options.UseFont = true;
            this.CUU003.Caption = "生产数量";
            this.CUU003.FieldName = "CUU003";
            this.CUU003.Name = "CUU003";
            this.CUU003.Visible = true;
            this.CUU003.VisibleIndex = 8;
            this.CUU003.Width = 72;
            // 
            // CUU004
            // 
            this.CUU004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU004.AppearanceCell.Options.UseFont = true;
            this.CUU004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU004.AppearanceHeader.Options.UseFont = true;
            this.CUU004.Caption = "下料计划完成时间";
            this.CUU004.FieldName = "CUU004";
            this.CUU004.Name = "CUU004";
            this.CUU004.Visible = true;
            this.CUU004.VisibleIndex = 9;
            this.CUU004.Width = 122;
            // 
            // CUU005
            // 
            this.CUU005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU005.AppearanceCell.Options.UseFont = true;
            this.CUU005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU005.AppearanceHeader.Options.UseFont = true;
            this.CUU005.Caption = "备注";
            this.CUU005.FieldName = "CUU005";
            this.CUU005.Name = "CUU005";
            this.CUU005.Visible = true;
            this.CUU005.VisibleIndex = 10;
            this.CUU005.Width = 246;
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
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
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
            this.hideContainerRight.Location = new System.Drawing.Point(1205, 26);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(36, 423);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dockPanel1.Appearance.Options.UseFont = true;
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("78da544b-4082-4a89-9735-1b146231dc97");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(264, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(264, 423);
            this.dockPanel1.Text = "数据逻辑";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.memoEdit1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 39);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(255, 380);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit1.EditValue = "* 同生产批号、同品号只能生成一次 * 审核生成生产部生产跟踪进度表、备料(机加工)车间进度跟踪表、组装车间进度跟踪表、油漆车间进度跟踪表 * 不允许反审核";
            this.memoEdit1.Location = new System.Drawing.Point(0, 0);
            this.memoEdit1.MenuManager = this.barManager1;
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoEdit1.Properties.Appearance.Options.UseFont = true;
            this.memoEdit1.Properties.ReadOnly = true;
            this.memoEdit1.Size = new System.Drawing.Size(255, 380);
            this.memoEdit1.TabIndex = 1;
            // 
            // wait
            // 
            this.wait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wait.Appearance.Options.UseBackColor = true;
            this.wait.BarAnimationElementThickness = 2;
            this.wait.Caption = "请稍后";
            this.wait.Description = "数据加载中 ...";
            this.wait.Location = new System.Drawing.Point(368, 83);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 33;
            this.wait.Text = "progressPanel1";
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            this.backgroundWorker4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker4_RunWorkerCompleted);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.splitContainerControl1.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.splitContainerControl1.AppearanceCaption.Options.UseBackColor = true;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Appearance.BackColor = System.Drawing.Color.White;
            this.splitContainerControl1.Panel1.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.Panel1.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseBackColor = true;
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel1.Controls.Add(this.dateTimePicker3);
            this.splitContainerControl1.Panel1.Controls.Add(this.dateTimePicker2);
            this.splitContainerControl1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnObtain);
            this.splitContainerControl1.Panel1.Controls.Add(this.texBatchNum);
            this.splitContainerControl1.Panel1.Controls.Add(this.texValue);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Appearance.BackColor = System.Drawing.Color.White;
            this.splitContainerControl1.Panel2.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.Panel2.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseBackColor = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.wait);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1205, 423);
            this.splitContainerControl1.SplitterPosition = 82;
            this.splitContainerControl1.TabIndex = 35;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(502, 50);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(25, 14);
            this.labelControl5.TabIndex = 44;
            this.labelControl5.Text = "---->";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.EditValue = null;
            this.dateTimePicker3.Location = new System.Drawing.Point(536, 47);
            this.dateTimePicker3.MenuManager = this.barManager1;
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker3.Properties.Appearance.Options.UseFont = true;
            this.dateTimePicker3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimePicker3.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimePicker3.Size = new System.Drawing.Size(128, 20);
            this.dateTimePicker3.TabIndex = 43;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.EditValue = null;
            this.dateTimePicker2.Location = new System.Drawing.Point(368, 47);
            this.dateTimePicker2.MenuManager = this.barManager1;
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Properties.Appearance.Options.UseFont = true;
            this.dateTimePicker2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimePicker2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimePicker2.Size = new System.Drawing.Size(128, 20);
            this.dateTimePicker2.TabIndex = 42;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.EditValue = null;
            this.dateTimePicker1.Location = new System.Drawing.Point(331, 16);
            this.dateTimePicker1.MenuManager = this.barManager1;
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Properties.Appearance.Options.UseFont = true;
            this.dateTimePicker1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimePicker1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 20);
            this.dateTimePicker1.TabIndex = 41;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(264, 50);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(98, 14);
            this.labelControl4.TabIndex = 39;
            this.labelControl4.Text = "下料生产周期：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(255, 19);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 14);
            this.labelControl3.TabIndex = 38;
            this.labelControl3.Text = "下单日期：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(24, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 14);
            this.labelControl2.TabIndex = 37;
            this.labelControl2.Text = "开料总产值：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(25, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 36;
            this.labelControl1.Text = "生产批号：";
            // 
            // btnObtain
            // 
            this.btnObtain.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObtain.Appearance.Options.UseFont = true;
            this.btnObtain.Location = new System.Drawing.Point(561, 12);
            this.btnObtain.Name = "btnObtain";
            this.btnObtain.Size = new System.Drawing.Size(75, 23);
            this.btnObtain.TabIndex = 35;
            this.btnObtain.Text = "添加产品";
            this.btnObtain.Click += new System.EventHandler(this.btnObtain_Click);
            // 
            // FormPlanCutting
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 449);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "FormPlanCutting";
            this.Text = "开料生产周计划";
            this.Controls.SetChildIndex(this.hideContainerRight, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePicker3.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePicker3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePicker2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePicker2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePicker1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePicker1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private System . Windows . Forms . TextBox texBatchNum;
        private System . Windows . Forms . TextBox texValue;
        private DevExpress . XtraGrid . Columns . GridColumn OPI003;
        private DevExpress . XtraGrid . Columns . GridColumn CUU002;
        private DevExpress . XtraGrid . Columns . GridColumn CUU008;
        private DevExpress . XtraGrid . Columns . GridColumn CUU009;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn CUU003;
        private DevExpress . XtraGrid . Columns . GridColumn CUU004;
        private DevExpress . XtraGrid . Columns . GridColumn OPI004;
        private DevExpress . XtraGrid . Columns . GridColumn CUU005;
        private DevExpress . XtraGrid . Columns . GridColumn CUU001;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private System . ComponentModel . BackgroundWorker backgroundWorker2;
        private System . ComponentModel . BackgroundWorker backgroundWorker3;
        private DevExpress . XtraBars . Docking . DockManager dockManager1;
        private DevExpress . XtraBars . Docking . DockPanel dockPanel1;
        private DevExpress . XtraBars . Docking . ControlContainer dockPanel1_Container;
        private DevExpress . Utils . Behaviors . BehaviorManager behaviorManager1;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private System . ComponentModel . BackgroundWorker backgroundWorker4;
        private DevExpress . XtraEditors . MemoEdit memoEdit1;
        private DevExpress . XtraBars . Docking . AutoHideContainer hideContainerRight;
        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraEditors . SimpleButton btnObtain;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private DevExpress . XtraEditors . DateEdit dateTimePicker1;
        private DevExpress . XtraEditors . DateEdit dateTimePicker2;
        private DevExpress . XtraEditors . DateEdit dateTimePicker3;
        private DevExpress . XtraEditors . LabelControl labelControl5;
    }
}