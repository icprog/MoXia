namespace Carpenter
{
    partial class FormPlanMachinWork
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
            this.dtpPlan = new DevExpress.XtraEditors.DateEdit();
            this.dtpOrder = new DevExpress.XtraEditors.DateEdit();
            this.dtpPrevious = new DevExpress.XtraEditors.DateEdit();
            this.texOver = new DevExpress.XtraEditors.TextEdit();
            this.texBatchNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PMX001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMX012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMX003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMX004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMX005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMX006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMX007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMX008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMX002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMX013 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dtpPlan.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPlan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOrder.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPrevious.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPrevious.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texOver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texBatchNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpPlan);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpOrder);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpPrevious);
            this.splitContainerControl1.Panel1.Controls.Add(this.texOver);
            this.splitContainerControl1.Panel1.Controls.Add(this.texBatchNum);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1193, 431);
            this.splitContainerControl1.SplitterPosition = 62;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // dtpPlan
            // 
            this.dtpPlan.EditValue = null;
            this.dtpPlan.Location = new System.Drawing.Point(535, 9);
            this.dtpPlan.MenuManager = this.barManager1;
            this.dtpPlan.Name = "dtpPlan";
            this.dtpPlan.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPlan.Properties.Appearance.Options.UseFont = true;
            this.dtpPlan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpPlan.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpPlan.Size = new System.Drawing.Size(133, 20);
            this.dtpPlan.TabIndex = 34;
            // 
            // dtpOrder
            // 
            this.dtpOrder.EditValue = null;
            this.dtpOrder.Location = new System.Drawing.Point(290, 9);
            this.dtpOrder.MenuManager = this.barManager1;
            this.dtpOrder.Name = "dtpOrder";
            this.dtpOrder.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrder.Properties.Appearance.Options.UseFont = true;
            this.dtpOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOrder.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOrder.Size = new System.Drawing.Size(133, 20);
            this.dtpOrder.TabIndex = 33;
            // 
            // dtpPrevious
            // 
            this.dtpPrevious.EditValue = null;
            this.dtpPrevious.Location = new System.Drawing.Point(64, 37);
            this.dtpPrevious.MenuManager = this.barManager1;
            this.dtpPrevious.Name = "dtpPrevious";
            this.dtpPrevious.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpPrevious.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpPrevious.Properties.ReadOnly = true;
            this.dtpPrevious.Size = new System.Drawing.Size(117, 20);
            this.dtpPrevious.TabIndex = 32;
            // 
            // texOver
            // 
            this.texOver.Location = new System.Drawing.Point(256, 37);
            this.texOver.MenuManager = this.barManager1;
            this.texOver.Name = "texOver";
            this.texOver.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texOver.Properties.Appearance.Options.UseFont = true;
            this.texOver.Properties.ReadOnly = true;
            this.texOver.Size = new System.Drawing.Size(117, 20);
            this.texOver.TabIndex = 31;
            // 
            // texBatchNum
            // 
            this.texBatchNum.Location = new System.Drawing.Point(64, 9);
            this.texBatchNum.MenuManager = this.barManager1;
            this.texBatchNum.Name = "texBatchNum";
            this.texBatchNum.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texBatchNum.Properties.Appearance.Options.UseFont = true;
            this.texBatchNum.Properties.ReadOnly = true;
            this.texBatchNum.Size = new System.Drawing.Size(117, 20);
            this.texBatchNum.TabIndex = 30;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(194, 40);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(56, 14);
            this.labelControl4.TabIndex = 29;
            this.labelControl4.Text = "完成率：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(459, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 14);
            this.labelControl3.TabIndex = 28;
            this.labelControl3.Text = "计划日期：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(214, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 27;
            this.labelControl2.Text = "下单日期：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(16, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 14);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "工段：";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gridControl1.Size = new System.Drawing.Size(1193, 357);
            this.gridControl1.TabIndex = 2;
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
            this.PMX001,
            this.PMX012,
            this.PMX003,
            this.PMX004,
            this.PMX005,
            this.OPI006,
            this.OPI007,
            this.OPI004,
            this.PMX006,
            this.PMX007,
            this.PMX008,
            this.PMX002,
            this.idx,
            this.PMX013});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // PMX001
            // 
            this.PMX001.Caption = "单号";
            this.PMX001.FieldName = "PMX001";
            this.PMX001.Name = "PMX001";
            this.PMX001.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // PMX012
            // 
            this.PMX012.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX012.AppearanceCell.Options.UseFont = true;
            this.PMX012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX012.AppearanceHeader.Options.UseFont = true;
            this.PMX012.Caption = "预排";
            this.PMX012.FieldName = "PMX012";
            this.PMX012.Name = "PMX012";
            this.PMX012.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PMX012.Visible = true;
            this.PMX012.VisibleIndex = 1;
            this.PMX012.Width = 39;
            // 
            // PMX003
            // 
            this.PMX003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX003.AppearanceCell.Options.UseFont = true;
            this.PMX003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX003.AppearanceHeader.Options.UseFont = true;
            this.PMX003.Caption = "批号";
            this.PMX003.FieldName = "PMX003";
            this.PMX003.Name = "PMX003";
            this.PMX003.OptionsColumn.AllowEdit = false;
            this.PMX003.Visible = true;
            this.PMX003.VisibleIndex = 2;
            this.PMX003.Width = 41;
            // 
            // PMX004
            // 
            this.PMX004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX004.AppearanceCell.Options.UseFont = true;
            this.PMX004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX004.AppearanceHeader.Options.UseFont = true;
            this.PMX004.Caption = "产品品号";
            this.PMX004.FieldName = "PMX004";
            this.PMX004.Name = "PMX004";
            this.PMX004.OptionsColumn.AllowEdit = false;
            this.PMX004.Visible = true;
            this.PMX004.VisibleIndex = 3;
            this.PMX004.Width = 104;
            // 
            // PMX005
            // 
            this.PMX005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX005.AppearanceCell.Options.UseFont = true;
            this.PMX005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX005.AppearanceHeader.Options.UseFont = true;
            this.PMX005.Caption = "产品名称";
            this.PMX005.FieldName = "PMX005";
            this.PMX005.Name = "PMX005";
            this.PMX005.OptionsColumn.AllowEdit = false;
            this.PMX005.Visible = true;
            this.PMX005.VisibleIndex = 4;
            this.PMX005.Width = 107;
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
            this.OPI006.Width = 61;
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
            this.OPI007.Width = 39;
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
            this.OPI004.Width = 61;
            // 
            // PMX006
            // 
            this.PMX006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX006.AppearanceCell.Options.UseFont = true;
            this.PMX006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX006.AppearanceHeader.Options.UseFont = true;
            this.PMX006.Caption = "订单数量";
            this.PMX006.FieldName = "PMX006";
            this.PMX006.Name = "PMX006";
            this.PMX006.OptionsColumn.AllowEdit = false;
            this.PMX006.Visible = true;
            this.PMX006.VisibleIndex = 9;
            this.PMX006.Width = 65;
            // 
            // PMX007
            // 
            this.PMX007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX007.AppearanceCell.Options.UseFont = true;
            this.PMX007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX007.AppearanceHeader.Options.UseFont = true;
            this.PMX007.Caption = "计划数量";
            this.PMX007.FieldName = "PMX007";
            this.PMX007.Name = "PMX007";
            this.PMX007.Visible = true;
            this.PMX007.VisibleIndex = 10;
            this.PMX007.Width = 70;
            // 
            // PMX008
            // 
            this.PMX008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX008.AppearanceCell.Options.UseFont = true;
            this.PMX008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX008.AppearanceHeader.Options.UseFont = true;
            this.PMX008.Caption = "备注";
            this.PMX008.FieldName = "PMX008";
            this.PMX008.Name = "PMX008";
            this.PMX008.Visible = true;
            this.PMX008.VisibleIndex = 11;
            this.PMX008.Width = 324;
            // 
            // PMX002
            // 
            this.PMX002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX002.AppearanceCell.Options.UseFont = true;
            this.PMX002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX002.AppearanceHeader.Options.UseFont = true;
            this.PMX002.Caption = "完工状态";
            this.PMX002.ColumnEdit = this.repositoryItemComboBox1;
            this.PMX002.FieldName = "PMX002";
            this.PMX002.Name = "PMX002";
            this.PMX002.Visible = true;
            this.PMX002.VisibleIndex = 8;
            this.PMX002.Width = 69;
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
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // PMX013
            // 
            this.PMX013.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX013.AppearanceCell.Options.UseFont = true;
            this.PMX013.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMX013.AppearanceHeader.Options.UseFont = true;
            this.PMX013.Caption = "遗留单号";
            this.PMX013.FieldName = "PMX013";
            this.PMX013.Name = "PMX013";
            this.PMX013.OptionsColumn.AllowEdit = false;
            this.PMX013.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PMX013.Visible = true;
            this.PMX013.VisibleIndex = 0;
            this.PMX013.Width = 69;
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
            this.hideContainerRight.Location = new System.Drawing.Point(1193, 26);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(36, 431);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("6b344f45-f68f-44ac-bd0a-32d13e082679");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(200, 457);
            this.dockPanel1.Text = "数据逻辑";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panelControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 39);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(191, 414);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textRemark);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(191, 414);
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
            this.textRemark.Size = new System.Drawing.Size(187, 410);
            this.textRemark.TabIndex = 2;
            this.textRemark.Text = " * 同生产批号、品号、工段、下单日期根据完工状态可多次排产\r\n\r\n *  预排：临时生产的不在日计划中的需要报工的产品做计划排产，可以在下一个日计划中正式排产\r" +
    "\n \r\n * 完成率：上一个工作日的日计划中正式排产的产品的完成情况统计(完成率=SUM(计划数量/报工数量)/排产数目*100%)";
            // 
            // wait
            // 
            this.wait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wait.Appearance.Options.UseBackColor = true;
            this.wait.BarAnimationElementThickness = 2;
            this.wait.Caption = "请稍后";
            this.wait.Description = "数据加载中 ...";
            this.wait.Location = new System.Drawing.Point(499, 195);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 33;
            this.wait.Text = "progressPanel1";
            // 
            // FormPlanMachinWork
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 457);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "FormPlanMachinWork";
            this.Text = "机加工车间工段日计划";
            this.Controls.SetChildIndex(this.hideContainerRight, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.wait, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpPlan.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPlan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOrder.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPrevious.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPrevious.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texOver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texBatchNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PMX001;
        private DevExpress . XtraGrid . Columns . GridColumn PMX012;
        private DevExpress . XtraGrid . Columns . GridColumn PMX003;
        private DevExpress . XtraGrid . Columns . GridColumn PMX004;
        private DevExpress . XtraGrid . Columns . GridColumn PMX005;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn OPI004;
        private DevExpress . XtraGrid . Columns . GridColumn PMX006;
        private DevExpress . XtraGrid . Columns . GridColumn PMX007;
        private DevExpress . XtraGrid . Columns . GridColumn PMX008;
        private DevExpress . XtraGrid . Columns . GridColumn PMX002;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox repositoryItemComboBox1;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private System . ComponentModel . BackgroundWorker backgroundWorker2;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraBars . Docking . DockManager dockManager1;
        private DevExpress . XtraBars . Docking . DockPanel dockPanel1;
        private DevExpress . XtraBars . Docking . ControlContainer dockPanel1_Container;
        private DevExpress . XtraEditors . PanelControl panelControl1;
        private System . Windows . Forms . TextBox textRemark;
        private DevExpress . XtraBars . Docking . AutoHideContainer hideContainerRight;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private DevExpress . XtraGrid . Columns . GridColumn PMX013;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private DevExpress . XtraEditors . TextEdit texBatchNum;
        private DevExpress . XtraEditors . TextEdit texOver;
        private DevExpress . XtraEditors . DateEdit dtpPrevious;
        private DevExpress . XtraEditors . DateEdit dtpOrder;
        private DevExpress . XtraEditors . DateEdit dtpPlan;
    }
}