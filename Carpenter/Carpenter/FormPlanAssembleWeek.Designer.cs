namespace Carpenter
{
    partial class FormPlanAssembleWeek
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
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.texValue = new System.Windows.Forms.TextBox();
            this.texBatchNum = new System.Windows.Forms.TextBox();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLB001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLB002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLB003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLB004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLB005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLB006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLB007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRS010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLB009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLB010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLB014 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAS011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLB016 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.textRemark = new System.Windows.Forms.TextBox();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpEnd);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpStart);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpOrder);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.texValue);
            this.splitContainerControl1.Panel1.Controls.Add(this.texBatchNum);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.wait);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1203, 433);
            this.splitContainerControl1.SplitterPosition = 73;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(452, 44);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(35, 14);
            this.labelControl5.TabIndex = 43;
            this.labelControl5.Text = "---->";
            // 
            // dtpEnd
            // 
            this.dtpEnd.EditValue = null;
            this.dtpEnd.Location = new System.Drawing.Point(496, 41);
            this.dtpEnd.MenuManager = this.barManager1;
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Properties.Appearance.Options.UseFont = true;
            this.dtpEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEnd.Size = new System.Drawing.Size(129, 20);
            this.dtpEnd.TabIndex = 42;
            // 
            // dtpStart
            // 
            this.dtpStart.EditValue = null;
            this.dtpStart.Location = new System.Drawing.Point(317, 41);
            this.dtpStart.MenuManager = this.barManager1;
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Properties.Appearance.Options.UseFont = true;
            this.dtpStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStart.Size = new System.Drawing.Size(129, 20);
            this.dtpStart.TabIndex = 41;
            // 
            // dtpOrder
            // 
            this.dtpOrder.EditValue = null;
            this.dtpOrder.Location = new System.Drawing.Point(305, 11);
            this.dtpOrder.MenuManager = this.barManager1;
            this.dtpOrder.Name = "dtpOrder";
            this.dtpOrder.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrder.Properties.Appearance.Options.UseFont = true;
            this.dtpOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOrder.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOrder.Size = new System.Drawing.Size(129, 20);
            this.dtpOrder.TabIndex = 40;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(241, 44);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 14);
            this.labelControl4.TabIndex = 39;
            this.labelControl4.Text = "生产周期：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(229, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 14);
            this.labelControl3.TabIndex = 38;
            this.labelControl3.Text = "下单日期：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(25, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 14);
            this.labelControl2.TabIndex = 37;
            this.labelControl2.Text = "总产值：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(25, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 14);
            this.labelControl1.TabIndex = 36;
            this.labelControl1.Text = "周次：";
            // 
            // texValue
            // 
            this.texValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.texValue.Location = new System.Drawing.Point(85, 41);
            this.texValue.Name = "texValue";
            this.texValue.ReadOnly = true;
            this.texValue.Size = new System.Drawing.Size(107, 23);
            this.texValue.TabIndex = 29;
            // 
            // texBatchNum
            // 
            this.texBatchNum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.texBatchNum.Location = new System.Drawing.Point(73, 11);
            this.texBatchNum.Name = "texBatchNum";
            this.texBatchNum.ReadOnly = true;
            this.texBatchNum.Size = new System.Drawing.Size(107, 23);
            this.texBatchNum.TabIndex = 25;
            // 
            // wait
            // 
            this.wait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wait.Appearance.Options.UseBackColor = true;
            this.wait.BarAnimationElementThickness = 2;
            this.wait.Caption = "请稍后";
            this.wait.Description = "数据加载中 ...";
            this.wait.Location = new System.Drawing.Point(478, 141);
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
            this.gridControl1.Size = new System.Drawing.Size(1203, 348);
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
            this.idx,
            this.PLB001,
            this.PLB002,
            this.OPI003,
            this.PLB003,
            this.PLB004,
            this.PLB005,
            this.PLB006,
            this.OPI006,
            this.OPI007,
            this.OPI004,
            this.PLB007,
            this.PRS010,
            this.PLB009,
            this.PLB010,
            this.PLB014,
            this.PAS011,
            this.PLB016});
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
            // PLB001
            // 
            this.PLB001.Caption = "单号";
            this.PLB001.FieldName = "PLB001";
            this.PLB001.Name = "PLB001";
            this.PLB001.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // PLB002
            // 
            this.PLB002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB002.AppearanceCell.Options.UseFont = true;
            this.PLB002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB002.AppearanceHeader.Options.UseFont = true;
            this.PLB002.Caption = "遗留单号";
            this.PLB002.FieldName = "PLB002";
            this.PLB002.Name = "PLB002";
            this.PLB002.OptionsColumn.AllowEdit = false;
            this.PLB002.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLB002.Visible = true;
            this.PLB002.VisibleIndex = 0;
            this.PLB002.Width = 64;
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
            // PLB003
            // 
            this.PLB003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB003.AppearanceCell.Options.UseFont = true;
            this.PLB003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB003.AppearanceHeader.Options.UseFont = true;
            this.PLB003.Caption = "批号";
            this.PLB003.FieldName = "PLB003";
            this.PLB003.Name = "PLB003";
            this.PLB003.OptionsColumn.AllowEdit = false;
            this.PLB003.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLB003.Visible = true;
            this.PLB003.VisibleIndex = 3;
            this.PLB003.Width = 36;
            // 
            // PLB004
            // 
            this.PLB004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB004.AppearanceCell.Options.UseFont = true;
            this.PLB004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB004.AppearanceHeader.Options.UseFont = true;
            this.PLB004.Caption = "产品品号";
            this.PLB004.FieldName = "PLB004";
            this.PLB004.Name = "PLB004";
            this.PLB004.OptionsColumn.AllowEdit = false;
            this.PLB004.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLB004.Visible = true;
            this.PLB004.VisibleIndex = 4;
            this.PLB004.Width = 94;
            // 
            // PLB005
            // 
            this.PLB005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB005.AppearanceCell.Options.UseFont = true;
            this.PLB005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB005.AppearanceHeader.Options.UseFont = true;
            this.PLB005.Caption = "产品名称";
            this.PLB005.FieldName = "PLB005";
            this.PLB005.Name = "PLB005";
            this.PLB005.OptionsColumn.AllowEdit = false;
            this.PLB005.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLB005.Visible = true;
            this.PLB005.VisibleIndex = 5;
            this.PLB005.Width = 100;
            // 
            // PLB006
            // 
            this.PLB006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB006.AppearanceCell.Options.UseFont = true;
            this.PLB006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB006.AppearanceHeader.Options.UseFont = true;
            this.PLB006.Caption = "规格";
            this.PLB006.FieldName = "PLB006";
            this.PLB006.Name = "PLB006";
            this.PLB006.OptionsColumn.AllowEdit = false;
            this.PLB006.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLB006.Visible = true;
            this.PLB006.VisibleIndex = 6;
            this.PLB006.Width = 62;
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
            // PLB007
            // 
            this.PLB007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB007.AppearanceCell.Options.UseFont = true;
            this.PLB007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB007.AppearanceHeader.Options.UseFont = true;
            this.PLB007.Caption = "订单量";
            this.PLB007.FieldName = "PLB007";
            this.PLB007.Name = "PLB007";
            this.PLB007.OptionsColumn.AllowEdit = false;
            this.PLB007.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLB007.Visible = true;
            this.PLB007.VisibleIndex = 10;
            this.PLB007.Width = 58;
            // 
            // PRS010
            // 
            this.PRS010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRS010.AppearanceCell.Options.UseFont = true;
            this.PRS010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRS010.AppearanceHeader.Options.UseFont = true;
            this.PRS010.Caption = "倒圆完成时间";
            this.PRS010.FieldName = "PRS010";
            this.PRS010.Name = "PRS010";
            this.PRS010.OptionsColumn.AllowEdit = false;
            this.PRS010.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PRS010.Visible = true;
            this.PRS010.VisibleIndex = 13;
            this.PRS010.Width = 92;
            // 
            // PLB009
            // 
            this.PLB009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB009.AppearanceCell.Options.UseFont = true;
            this.PLB009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB009.AppearanceHeader.Options.UseFont = true;
            this.PLB009.Caption = "备注";
            this.PLB009.FieldName = "PLB009";
            this.PLB009.Name = "PLB009";
            this.PLB009.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLB009.Visible = true;
            this.PLB009.VisibleIndex = 15;
            this.PLB009.Width = 217;
            // 
            // PLB010
            // 
            this.PLB010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB010.AppearanceCell.Options.UseFont = true;
            this.PLB010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB010.AppearanceHeader.Options.UseFont = true;
            this.PLB010.Caption = "预排";
            this.PLB010.FieldName = "PLB010";
            this.PLB010.Name = "PLB010";
            this.PLB010.OptionsColumn.AllowEdit = false;
            this.PLB010.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLB010.Visible = true;
            this.PLB010.VisibleIndex = 1;
            this.PLB010.Width = 36;
            // 
            // PLB014
            // 
            this.PLB014.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB014.AppearanceCell.Options.UseFont = true;
            this.PLB014.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB014.AppearanceHeader.Options.UseFont = true;
            this.PLB014.Caption = "计划生产量";
            this.PLB014.FieldName = "PLB014";
            this.PLB014.Name = "PLB014";
            this.PLB014.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLB014.Visible = true;
            this.PLB014.VisibleIndex = 11;
            this.PLB014.Width = 81;
            // 
            // PAS011
            // 
            this.PAS011.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS011.AppearanceCell.Options.UseFont = true;
            this.PAS011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS011.AppearanceHeader.Options.UseFont = true;
            this.PAS011.Caption = "累计完工量";
            this.PAS011.FieldName = "PAS011";
            this.PAS011.Name = "PAS011";
            this.PAS011.OptionsColumn.AllowEdit = false;
            this.PAS011.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PAS011.Visible = true;
            this.PAS011.VisibleIndex = 12;
            this.PAS011.Width = 80;
            // 
            // PLB016
            // 
            this.PLB016.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB016.AppearanceCell.Options.UseFont = true;
            this.PLB016.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB016.AppearanceHeader.Options.UseFont = true;
            this.PLB016.Caption = "组装计划完成时间";
            this.PLB016.FieldName = "PLB016";
            this.PLB016.Name = "PLB016";
            this.PLB016.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PLB016.Visible = true;
            this.PLB016.VisibleIndex = 14;
            this.PLB016.Width = 124;
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
            this.hideContainerRight.Location = new System.Drawing.Point(1203, 26);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(36, 433);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("a44572c0-af58-45b5-8913-77c708322c5d");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(200, 459);
            this.dockPanel1.Text = "数据逻辑";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panelControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 39);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(191, 416);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textRemark);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(191, 416);
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
            this.textRemark.Size = new System.Drawing.Size(187, 412);
            this.textRemark.TabIndex = 2;
            this.textRemark.Text = " *  遗留：同批号、品号报工数量少于订单量\r\n\r\n *  预排：临时生产的不在周计划中的需要报工的产品做计划排产，可以在下一个周计划中正式排产\r\n\r\n\r\n\r\n\r" +
    "\n";
            // 
            // FormPlanAssembleWeek
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 459);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "FormPlanAssembleWeek";
            this.Text = "组装车间生产周计划";
            this.Controls.SetChildIndex(this.hideContainerRight, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
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
        private System . Windows . Forms . TextBox texValue;
        private System . Windows . Forms . TextBox texBatchNum;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn PLB001;
        private DevExpress . XtraGrid . Columns . GridColumn PLB002;
        private DevExpress . XtraGrid . Columns . GridColumn OPI003;
        private DevExpress . XtraGrid . Columns . GridColumn PLB003;
        private DevExpress . XtraGrid . Columns . GridColumn PLB004;
        private DevExpress . XtraGrid . Columns . GridColumn PLB005;
        private DevExpress . XtraGrid . Columns . GridColumn PLB006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn OPI004;
        private DevExpress . XtraGrid . Columns . GridColumn PLB007;
        private DevExpress . XtraGrid . Columns . GridColumn PRS010;
        private DevExpress . XtraGrid . Columns . GridColumn PLB009;
        private DevExpress . XtraGrid . Columns . GridColumn PLB010;
        private DevExpress . XtraGrid . Columns . GridColumn PLB014;
        private DevExpress . XtraGrid . Columns . GridColumn PAS011;
        private DevExpress . XtraGrid . Columns . GridColumn PLB016;
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
        private DevExpress . XtraEditors . DateEdit dtpStart;
        private DevExpress . XtraEditors . LabelControl labelControl5;
        private DevExpress . XtraEditors . DateEdit dtpEnd;
    }
}