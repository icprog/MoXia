namespace Carpenter
{
    partial class FormProductionPaintDay
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
            this.PWE001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWE012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWE003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWE004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWE005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWE006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWE007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWE008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWE002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.splitContainerControl1.Size = new System.Drawing.Size(1208, 413);
            this.splitContainerControl1.SplitterPosition = 68;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // dtpPlan
            // 
            this.dtpPlan.EditValue = null;
            this.dtpPlan.Location = new System.Drawing.Point(538, 9);
            this.dtpPlan.MenuManager = this.barManager1;
            this.dtpPlan.Name = "dtpPlan";
            this.dtpPlan.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPlan.Properties.Appearance.Options.UseFont = true;
            this.dtpPlan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpPlan.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpPlan.Size = new System.Drawing.Size(126, 20);
            this.dtpPlan.TabIndex = 54;
            // 
            // dtpOrder
            // 
            this.dtpOrder.EditValue = null;
            this.dtpOrder.Location = new System.Drawing.Point(293, 9);
            this.dtpOrder.MenuManager = this.barManager1;
            this.dtpOrder.Name = "dtpOrder";
            this.dtpOrder.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrder.Properties.Appearance.Options.UseFont = true;
            this.dtpOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOrder.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOrder.Size = new System.Drawing.Size(126, 20);
            this.dtpOrder.TabIndex = 53;
            // 
            // dtpPrevious
            // 
            this.dtpPrevious.EditValue = null;
            this.dtpPrevious.Location = new System.Drawing.Point(66, 46);
            this.dtpPrevious.MenuManager = this.barManager1;
            this.dtpPrevious.Name = "dtpPrevious";
            this.dtpPrevious.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPrevious.Properties.Appearance.Options.UseFont = true;
            this.dtpPrevious.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpPrevious.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpPrevious.Properties.ReadOnly = true;
            this.dtpPrevious.Size = new System.Drawing.Size(117, 20);
            this.dtpPrevious.TabIndex = 52;
            // 
            // texOver
            // 
            this.texOver.Location = new System.Drawing.Point(258, 46);
            this.texOver.MenuManager = this.barManager1;
            this.texOver.Name = "texOver";
            this.texOver.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texOver.Properties.Appearance.Options.UseFont = true;
            this.texOver.Properties.ReadOnly = true;
            this.texOver.Size = new System.Drawing.Size(117, 20);
            this.texOver.TabIndex = 51;
            // 
            // texBatchNum
            // 
            this.texBatchNum.Location = new System.Drawing.Point(66, 9);
            this.texBatchNum.MenuManager = this.barManager1;
            this.texBatchNum.Name = "texBatchNum";
            this.texBatchNum.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texBatchNum.Properties.Appearance.Options.UseFont = true;
            this.texBatchNum.Properties.ReadOnly = true;
            this.texBatchNum.Size = new System.Drawing.Size(117, 20);
            this.texBatchNum.TabIndex = 50;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(196, 49);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(56, 14);
            this.labelControl4.TabIndex = 49;
            this.labelControl4.Text = "完成率：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(462, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 14);
            this.labelControl3.TabIndex = 48;
            this.labelControl3.Text = "计划日期：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(217, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 47;
            this.labelControl2.Text = "下单日期：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(18, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 14);
            this.labelControl1.TabIndex = 46;
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
            this.gridControl1.Size = new System.Drawing.Size(1208, 333);
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
            this.PWE001,
            this.PWE012,
            this.PWE003,
            this.PWE004,
            this.PWE005,
            this.OPI006,
            this.OPI007,
            this.OPI004,
            this.PWE006,
            this.PWE007,
            this.PWE008,
            this.PWE002,
            this.idx});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // PWE001
            // 
            this.PWE001.Caption = "单号";
            this.PWE001.FieldName = "PWE001";
            this.PWE001.Name = "PWE001";
            this.PWE001.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // PWE012
            // 
            this.PWE012.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE012.AppearanceCell.Options.UseFont = true;
            this.PWE012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE012.AppearanceHeader.Options.UseFont = true;
            this.PWE012.Caption = "预排";
            this.PWE012.FieldName = "PWE012";
            this.PWE012.Name = "PWE012";
            this.PWE012.OptionsColumn.AllowEdit = false;
            this.PWE012.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PWE012.Visible = true;
            this.PWE012.VisibleIndex = 0;
            this.PWE012.Width = 38;
            // 
            // PWE003
            // 
            this.PWE003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE003.AppearanceCell.Options.UseFont = true;
            this.PWE003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE003.AppearanceHeader.Options.UseFont = true;
            this.PWE003.Caption = "批号";
            this.PWE003.FieldName = "PWE003";
            this.PWE003.Name = "PWE003";
            this.PWE003.OptionsColumn.AllowEdit = false;
            this.PWE003.Visible = true;
            this.PWE003.VisibleIndex = 1;
            this.PWE003.Width = 46;
            // 
            // PWE004
            // 
            this.PWE004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE004.AppearanceCell.Options.UseFont = true;
            this.PWE004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE004.AppearanceHeader.Options.UseFont = true;
            this.PWE004.Caption = "产品品号";
            this.PWE004.FieldName = "PWE004";
            this.PWE004.Name = "PWE004";
            this.PWE004.OptionsColumn.AllowEdit = false;
            this.PWE004.Visible = true;
            this.PWE004.VisibleIndex = 2;
            this.PWE004.Width = 113;
            // 
            // PWE005
            // 
            this.PWE005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE005.AppearanceCell.Options.UseFont = true;
            this.PWE005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE005.AppearanceHeader.Options.UseFont = true;
            this.PWE005.Caption = "产品名称";
            this.PWE005.FieldName = "PWE005";
            this.PWE005.Name = "PWE005";
            this.PWE005.OptionsColumn.AllowEdit = false;
            this.PWE005.Visible = true;
            this.PWE005.VisibleIndex = 3;
            this.PWE005.Width = 117;
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
            this.OPI006.Width = 67;
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
            this.OPI007.VisibleIndex = 5;
            this.OPI007.Width = 38;
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
            this.OPI004.VisibleIndex = 6;
            this.OPI004.Width = 62;
            // 
            // PWE006
            // 
            this.PWE006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE006.AppearanceCell.Options.UseFont = true;
            this.PWE006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE006.AppearanceHeader.Options.UseFont = true;
            this.PWE006.Caption = "订单数量";
            this.PWE006.FieldName = "PWE006";
            this.PWE006.Name = "PWE006";
            this.PWE006.OptionsColumn.AllowEdit = false;
            this.PWE006.Visible = true;
            this.PWE006.VisibleIndex = 8;
            this.PWE006.Width = 68;
            // 
            // PWE007
            // 
            this.PWE007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE007.AppearanceCell.Options.UseFont = true;
            this.PWE007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE007.AppearanceHeader.Options.UseFont = true;
            this.PWE007.Caption = "计划数量";
            this.PWE007.FieldName = "PWE007";
            this.PWE007.Name = "PWE007";
            this.PWE007.Visible = true;
            this.PWE007.VisibleIndex = 9;
            this.PWE007.Width = 67;
            // 
            // PWE008
            // 
            this.PWE008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE008.AppearanceCell.Options.UseFont = true;
            this.PWE008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE008.AppearanceHeader.Options.UseFont = true;
            this.PWE008.Caption = "备注";
            this.PWE008.FieldName = "PWE008";
            this.PWE008.Name = "PWE008";
            this.PWE008.Visible = true;
            this.PWE008.VisibleIndex = 10;
            this.PWE008.Width = 369;
            // 
            // PWE002
            // 
            this.PWE002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE002.AppearanceCell.Options.UseFont = true;
            this.PWE002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE002.AppearanceHeader.Options.UseFont = true;
            this.PWE002.Caption = "完工状态";
            this.PWE002.ColumnEdit = this.repositoryItemComboBox1;
            this.PWE002.FieldName = "PWE002";
            this.PWE002.Name = "PWE002";
            this.PWE002.Visible = true;
            this.PWE002.VisibleIndex = 7;
            this.PWE002.Width = 68;
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
            this.hideContainerRight.Size = new System.Drawing.Size(36, 413);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("4d7df49d-b921-446f-aeb9-8d0992ac69f7");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(200, 439);
            this.dockPanel1.Text = "数据逻辑";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panelControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 39);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(191, 396);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textRemark);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(191, 396);
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
            this.textRemark.Size = new System.Drawing.Size(187, 392);
            this.textRemark.TabIndex = 2;
            this.textRemark.Text = " * 同生产批号、品号、工段、下单日期根据完工状态可多次排产\r\n\r\n *  预排：临时生产的不在日计划中的需要报工的产品做计划排产，可以在下一个日计划中正式排产\r" +
    "\n\r\n * 完成率：上一个工作日的日计划中正式排产的产品的完成情况统计(完成率=SUM(计划数量/报工数量)/排产数目*100%)";
            // 
            // wait
            // 
            this.wait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wait.Appearance.Options.UseBackColor = true;
            this.wait.BarAnimationElementThickness = 2;
            this.wait.Caption = "请稍后";
            this.wait.Description = "数据加载中 ...";
            this.wait.Location = new System.Drawing.Point(499, 186);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 33;
            this.wait.Text = "progressPanel1";
            // 
            // FormProductionPaintDay
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 439);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "FormProductionPaintDay";
            this.Text = "油漆车间生产日计划";
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
        private DevExpress . XtraGrid . Columns . GridColumn PWE001;
        private DevExpress . XtraGrid . Columns . GridColumn PWE012;
        private DevExpress . XtraGrid . Columns . GridColumn PWE003;
        private DevExpress . XtraGrid . Columns . GridColumn PWE004;
        private DevExpress . XtraGrid . Columns . GridColumn PWE005;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn OPI004;
        private DevExpress . XtraGrid . Columns . GridColumn PWE006;
        private DevExpress . XtraGrid . Columns . GridColumn PWE007;
        private DevExpress . XtraGrid . Columns . GridColumn PWE008;
        private DevExpress . XtraGrid . Columns . GridColumn PWE002;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private System . ComponentModel . BackgroundWorker backgroundWorker2;
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
        private DevExpress . XtraEditors . TextEdit texOver;
        private DevExpress . XtraEditors . TextEdit texBatchNum;
        private DevExpress . XtraEditors . DateEdit dtpPrevious;
        private DevExpress . XtraEditors . DateEdit dtpPlan;
        private DevExpress . XtraEditors . DateEdit dtpOrder;
    }
}