namespace Carpenter
{
    partial class FormPlanMachin
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
            this.dtpEnd = new DevExpress.XtraEditors.DateEdit();
            this.dtpStart = new DevExpress.XtraEditors.DateEdit();
            this.dtpOrder = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label5 = new System.Windows.Forms.Label();
            this.texValue = new System.Windows.Forms.TextBox();
            this.texBatchNum = new System.Windows.Forms.TextBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMD001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMD002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMD003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMD004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMD005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMD006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMD007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMD008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMD009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMD010 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpEnd);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpStart);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpOrder);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.label5);
            this.splitContainerControl1.Panel1.Controls.Add(this.texValue);
            this.splitContainerControl1.Panel1.Controls.Add(this.texBatchNum);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1204, 421);
            this.splitContainerControl1.SplitterPosition = 74;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // dtpEnd
            // 
            this.dtpEnd.EditValue = null;
            this.dtpEnd.Location = new System.Drawing.Point(481, 44);
            this.dtpEnd.MenuManager = this.barManager1;
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Properties.Appearance.Options.UseFont = true;
            this.dtpEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEnd.Size = new System.Drawing.Size(127, 20);
            this.dtpEnd.TabIndex = 32;
            // 
            // dtpStart
            // 
            this.dtpStart.EditValue = null;
            this.dtpStart.Location = new System.Drawing.Point(312, 44);
            this.dtpStart.MenuManager = this.barManager1;
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Properties.Appearance.Options.UseFont = true;
            this.dtpStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStart.Size = new System.Drawing.Size(127, 20);
            this.dtpStart.TabIndex = 31;
            // 
            // dtpOrder
            // 
            this.dtpOrder.EditValue = null;
            this.dtpOrder.Location = new System.Drawing.Point(302, 10);
            this.dtpOrder.MenuManager = this.barManager1;
            this.dtpOrder.Name = "dtpOrder";
            this.dtpOrder.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrder.Properties.Appearance.Options.UseFont = true;
            this.dtpOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOrder.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOrder.Size = new System.Drawing.Size(127, 20);
            this.dtpOrder.TabIndex = 30;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(236, 47);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 14);
            this.labelControl4.TabIndex = 29;
            this.labelControl4.Text = "生产周期：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(226, 13);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 14);
            this.labelControl3.TabIndex = 28;
            this.labelControl3.Text = "下单日期：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(28, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 14);
            this.labelControl2.TabIndex = 27;
            this.labelControl2.Text = "总产值：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(22, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 14);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "周次：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(447, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 14);
            this.label5.TabIndex = 23;
            this.label5.Text = "-->";
            // 
            // texValue
            // 
            this.texValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.texValue.Location = new System.Drawing.Point(90, 44);
            this.texValue.Name = "texValue";
            this.texValue.ReadOnly = true;
            this.texValue.Size = new System.Drawing.Size(107, 23);
            this.texValue.TabIndex = 19;
            // 
            // texBatchNum
            // 
            this.texBatchNum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.texBatchNum.Location = new System.Drawing.Point(70, 10);
            this.texBatchNum.Name = "texBatchNum";
            this.texBatchNum.ReadOnly = true;
            this.texBatchNum.Size = new System.Drawing.Size(107, 23);
            this.texBatchNum.TabIndex = 15;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1204, 335);
            this.gridControl1.TabIndex = 1;
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
            this.PMD001,
            this.PMD002,
            this.OPI003,
            this.PMD003,
            this.PMD004,
            this.PMD005,
            this.PMD006,
            this.OPI006,
            this.OPI007,
            this.OPI004,
            this.PMD007,
            this.PMD008,
            this.PMD009,
            this.PMD010});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
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
            // PMD001
            // 
            this.PMD001.Caption = "单号";
            this.PMD001.FieldName = "PMD001";
            this.PMD001.Name = "PMD001";
            this.PMD001.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // PMD002
            // 
            this.PMD002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD002.AppearanceCell.Options.UseFont = true;
            this.PMD002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD002.AppearanceHeader.Options.UseFont = true;
            this.PMD002.Caption = "遗留单号";
            this.PMD002.FieldName = "PMD002";
            this.PMD002.Name = "PMD002";
            this.PMD002.OptionsColumn.AllowEdit = false;
            this.PMD002.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PMD002.Visible = true;
            this.PMD002.VisibleIndex = 0;
            this.PMD002.Width = 65;
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
            // PMD003
            // 
            this.PMD003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD003.AppearanceCell.Options.UseFont = true;
            this.PMD003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD003.AppearanceHeader.Options.UseFont = true;
            this.PMD003.Caption = "批号";
            this.PMD003.FieldName = "PMD003";
            this.PMD003.Name = "PMD003";
            this.PMD003.OptionsColumn.AllowEdit = false;
            this.PMD003.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PMD003.Visible = true;
            this.PMD003.VisibleIndex = 3;
            this.PMD003.Width = 40;
            // 
            // PMD004
            // 
            this.PMD004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD004.AppearanceCell.Options.UseFont = true;
            this.PMD004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD004.AppearanceHeader.Options.UseFont = true;
            this.PMD004.Caption = "产品品号";
            this.PMD004.FieldName = "PMD004";
            this.PMD004.Name = "PMD004";
            this.PMD004.OptionsColumn.AllowEdit = false;
            this.PMD004.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PMD004.Visible = true;
            this.PMD004.VisibleIndex = 4;
            this.PMD004.Width = 70;
            // 
            // PMD005
            // 
            this.PMD005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD005.AppearanceCell.Options.UseFont = true;
            this.PMD005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD005.AppearanceHeader.Options.UseFont = true;
            this.PMD005.Caption = "产品名称";
            this.PMD005.FieldName = "PMD005";
            this.PMD005.Name = "PMD005";
            this.PMD005.OptionsColumn.AllowEdit = false;
            this.PMD005.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PMD005.Visible = true;
            this.PMD005.VisibleIndex = 5;
            this.PMD005.Width = 72;
            // 
            // PMD006
            // 
            this.PMD006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD006.AppearanceCell.Options.UseFont = true;
            this.PMD006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD006.AppearanceHeader.Options.UseFont = true;
            this.PMD006.Caption = "规格";
            this.PMD006.FieldName = "PMD006";
            this.PMD006.Name = "PMD006";
            this.PMD006.OptionsColumn.AllowEdit = false;
            this.PMD006.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PMD006.Visible = true;
            this.PMD006.VisibleIndex = 6;
            this.PMD006.Width = 67;
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
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OPI004", "{0:0.####}")});
            this.OPI004.Visible = true;
            this.OPI004.VisibleIndex = 9;
            this.OPI004.Width = 60;
            // 
            // PMD007
            // 
            this.PMD007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD007.AppearanceCell.Options.UseFont = true;
            this.PMD007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD007.AppearanceHeader.Options.UseFont = true;
            this.PMD007.Caption = "订单量";
            this.PMD007.FieldName = "PMD007";
            this.PMD007.Name = "PMD007";
            this.PMD007.OptionsColumn.AllowEdit = false;
            this.PMD007.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PMD007.Visible = true;
            this.PMD007.VisibleIndex = 10;
            this.PMD007.Width = 57;
            // 
            // PMD008
            // 
            this.PMD008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD008.AppearanceCell.Options.UseFont = true;
            this.PMD008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD008.AppearanceHeader.Options.UseFont = true;
            this.PMD008.Caption = "倒圆计划完成时间";
            this.PMD008.FieldName = "PMD008";
            this.PMD008.Name = "PMD008";
            this.PMD008.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PMD008.Visible = true;
            this.PMD008.VisibleIndex = 11;
            this.PMD008.Width = 120;
            // 
            // PMD009
            // 
            this.PMD009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD009.AppearanceCell.Options.UseFont = true;
            this.PMD009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD009.AppearanceHeader.Options.UseFont = true;
            this.PMD009.Caption = "备注";
            this.PMD009.FieldName = "PMD009";
            this.PMD009.Name = "PMD009";
            this.PMD009.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PMD009.Visible = true;
            this.PMD009.VisibleIndex = 12;
            this.PMD009.Width = 297;
            // 
            // PMD010
            // 
            this.PMD010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD010.AppearanceCell.Options.UseFont = true;
            this.PMD010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD010.AppearanceHeader.Options.UseFont = true;
            this.PMD010.Caption = "预排";
            this.PMD010.FieldName = "PMD010";
            this.PMD010.Name = "PMD010";
            this.PMD010.OptionsColumn.AllowEdit = false;
            this.PMD010.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PMD010.Visible = true;
            this.PMD010.VisibleIndex = 1;
            this.PMD010.Width = 39;
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
            this.hideContainerRight.Location = new System.Drawing.Point(1204, 26);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(36, 421);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("8f7a4a22-27eb-4c1d-875a-2fd59dd8ca71");
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
            this.textRemark.TabIndex = 2;
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
            this.wait.Location = new System.Drawing.Point(497, 190);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 33;
            this.wait.Text = "progressPanel1";
            // 
            // FormPlanMachin
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 447);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "FormPlanMachin";
            this.Text = "机加工车间生产周计划";
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
        private System . Windows . Forms . Label label5;
        private System . Windows . Forms . TextBox texValue;
        private System . Windows . Forms . TextBox texBatchNum;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PMD001;
        private DevExpress . XtraGrid . Columns . GridColumn PMD002;
        private DevExpress . XtraGrid . Columns . GridColumn OPI003;
        private DevExpress . XtraGrid . Columns . GridColumn PMD003;
        private DevExpress . XtraGrid . Columns . GridColumn PMD004;
        private DevExpress . XtraGrid . Columns . GridColumn PMD005;
        private DevExpress . XtraGrid . Columns . GridColumn PMD006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn OPI004;
        private DevExpress . XtraGrid . Columns . GridColumn PMD007;
        private DevExpress . XtraGrid . Columns . GridColumn PMD008;
        private DevExpress . XtraGrid . Columns . GridColumn PMD009;
        private DevExpress . XtraGrid . Columns . GridColumn PMD010;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
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
        private DevExpress . XtraEditors . DateEdit dtpOrder;
        private DevExpress . XtraEditors . DateEdit dtpEnd;
        private DevExpress . XtraEditors . DateEdit dtpStart;
    }
}