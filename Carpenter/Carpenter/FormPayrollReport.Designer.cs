namespace Carpenter
{
    partial class FormPayrollReport
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnRead = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PAY001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY013 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY014 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY015 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY016 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY017 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY018 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY019 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY020 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY021 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY022 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY023 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY024 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY025 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY026 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY027 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY028 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY029 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY030 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY031 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY032 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY033 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAY034 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U0 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.lupWoodColor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cmbGrade = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.lupProduct = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupWoodColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 24);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.btnRead);
            this.splitContainerControl1.Panel1.Controls.Add(this.dateEdit);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1237, 414);
            this.splitContainerControl1.SplitterPosition = 33;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(243, 6);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "读取";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // dateEdit
            // 
            this.dateEdit.EditValue = null;
            this.dateEdit.Location = new System.Drawing.Point(68, 6);
            this.dateEdit.Name = "dateEdit";
            this.dateEdit.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEdit.Properties.Appearance.Options.UseFont = true;
            this.dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit.Properties.DisplayFormat.FormatString = "yyyyMM";
            this.dateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit.Properties.EditFormat.FormatString = "yyyyMM";
            this.dateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit.Properties.Mask.EditMask = "yyyyMM";
            this.dateEdit.Size = new System.Drawing.Size(153, 20);
            this.dateEdit.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(20, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "年月：";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.lupWoodColor,
            this.cmbType,
            this.cmbGrade,
            this.lupProduct});
            this.gridControl1.Size = new System.Drawing.Size(1237, 376);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PAY001,
            this.PAY002,
            this.PAY004,
            this.PAY005,
            this.PAY006,
            this.PAY007,
            this.PAY008,
            this.PAY009,
            this.PAY010,
            this.PAY011,
            this.PAY012,
            this.PAY013,
            this.PAY014,
            this.PAY015,
            this.PAY016,
            this.PAY017,
            this.PAY018,
            this.PAY019,
            this.PAY020,
            this.PAY021,
            this.PAY022,
            this.PAY023,
            this.PAY024,
            this.PAY025,
            this.PAY026,
            this.PAY027,
            this.PAY028,
            this.PAY029,
            this.PAY030,
            this.PAY031,
            this.PAY032,
            this.PAY033,
            this.PAY034,
            this.U0});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PAY001
            // 
            this.PAY001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY001.AppearanceCell.Options.UseFont = true;
            this.PAY001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY001.AppearanceHeader.Options.UseFont = true;
            this.PAY001.Caption = "人员编号";
            this.PAY001.FieldName = "PAY001";
            this.PAY001.Name = "PAY001";
            this.PAY001.OptionsColumn.AllowEdit = false;
            this.PAY001.Visible = true;
            this.PAY001.VisibleIndex = 0;
            this.PAY001.Width = 66;
            // 
            // PAY002
            // 
            this.PAY002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY002.AppearanceCell.Options.UseFont = true;
            this.PAY002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY002.AppearanceHeader.Options.UseFont = true;
            this.PAY002.Caption = "人员姓名";
            this.PAY002.FieldName = "PAY002";
            this.PAY002.Name = "PAY002";
            this.PAY002.OptionsColumn.AllowEdit = false;
            this.PAY002.Visible = true;
            this.PAY002.VisibleIndex = 1;
            this.PAY002.Width = 68;
            // 
            // PAY004
            // 
            this.PAY004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY004.AppearanceCell.Options.UseFont = true;
            this.PAY004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY004.AppearanceHeader.Options.UseFont = true;
            this.PAY004.Caption = "1日";
            this.PAY004.FieldName = "PAY004";
            this.PAY004.Name = "PAY004";
            this.PAY004.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY004", "{0:0.##}")});
            this.PAY004.Visible = true;
            this.PAY004.VisibleIndex = 2;
            this.PAY004.Width = 60;
            // 
            // PAY005
            // 
            this.PAY005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY005.AppearanceCell.Options.UseFont = true;
            this.PAY005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY005.AppearanceHeader.Options.UseFont = true;
            this.PAY005.Caption = "2日";
            this.PAY005.FieldName = "PAY005";
            this.PAY005.Name = "PAY005";
            this.PAY005.OptionsColumn.AllowEdit = false;
            this.PAY005.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY005", "{0:0.##}")});
            this.PAY005.Visible = true;
            this.PAY005.VisibleIndex = 3;
            this.PAY005.Width = 60;
            // 
            // PAY006
            // 
            this.PAY006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY006.AppearanceCell.Options.UseFont = true;
            this.PAY006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY006.AppearanceHeader.Options.UseFont = true;
            this.PAY006.Caption = "3日";
            this.PAY006.FieldName = "PAY006";
            this.PAY006.Name = "PAY006";
            this.PAY006.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY006", "{0:0.##}")});
            this.PAY006.Visible = true;
            this.PAY006.VisibleIndex = 4;
            this.PAY006.Width = 60;
            // 
            // PAY007
            // 
            this.PAY007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY007.AppearanceCell.Options.UseFont = true;
            this.PAY007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY007.AppearanceHeader.Options.UseFont = true;
            this.PAY007.Caption = "4日";
            this.PAY007.FieldName = "PAY007";
            this.PAY007.Name = "PAY007";
            this.PAY007.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY007", "{0:0.##}")});
            this.PAY007.Visible = true;
            this.PAY007.VisibleIndex = 5;
            this.PAY007.Width = 60;
            // 
            // PAY008
            // 
            this.PAY008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY008.AppearanceCell.Options.UseFont = true;
            this.PAY008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY008.AppearanceHeader.Options.UseFont = true;
            this.PAY008.Caption = "5日";
            this.PAY008.FieldName = "PAY008";
            this.PAY008.Name = "PAY008";
            this.PAY008.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY008", "{0:0.##}")});
            this.PAY008.Visible = true;
            this.PAY008.VisibleIndex = 6;
            this.PAY008.Width = 60;
            // 
            // PAY009
            // 
            this.PAY009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY009.AppearanceCell.Options.UseFont = true;
            this.PAY009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY009.AppearanceHeader.Options.UseFont = true;
            this.PAY009.Caption = "6日";
            this.PAY009.FieldName = "PAY009";
            this.PAY009.Name = "PAY009";
            this.PAY009.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY009", "{0:0.##}")});
            this.PAY009.Visible = true;
            this.PAY009.VisibleIndex = 7;
            this.PAY009.Width = 60;
            // 
            // PAY010
            // 
            this.PAY010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY010.AppearanceCell.Options.UseFont = true;
            this.PAY010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY010.AppearanceHeader.Options.UseFont = true;
            this.PAY010.Caption = "7日";
            this.PAY010.FieldName = "PAY010";
            this.PAY010.Name = "PAY010";
            this.PAY010.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY010", "{0:0.##}")});
            this.PAY010.Visible = true;
            this.PAY010.VisibleIndex = 8;
            this.PAY010.Width = 60;
            // 
            // PAY011
            // 
            this.PAY011.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY011.AppearanceCell.Options.UseFont = true;
            this.PAY011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY011.AppearanceHeader.Options.UseFont = true;
            this.PAY011.Caption = "8日";
            this.PAY011.FieldName = "PAY011";
            this.PAY011.Name = "PAY011";
            this.PAY011.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY011", "{0:0.##}")});
            this.PAY011.Visible = true;
            this.PAY011.VisibleIndex = 9;
            this.PAY011.Width = 60;
            // 
            // PAY012
            // 
            this.PAY012.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY012.AppearanceCell.Options.UseFont = true;
            this.PAY012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY012.AppearanceHeader.Options.UseFont = true;
            this.PAY012.Caption = "9日";
            this.PAY012.FieldName = "PAY012";
            this.PAY012.Name = "PAY012";
            this.PAY012.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY012", "{0:0.##}")});
            this.PAY012.Visible = true;
            this.PAY012.VisibleIndex = 10;
            this.PAY012.Width = 60;
            // 
            // PAY013
            // 
            this.PAY013.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY013.AppearanceCell.Options.UseFont = true;
            this.PAY013.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY013.AppearanceHeader.Options.UseFont = true;
            this.PAY013.Caption = "10日";
            this.PAY013.FieldName = "PAY013";
            this.PAY013.Name = "PAY013";
            this.PAY013.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY013", "{0:0.##}")});
            this.PAY013.Visible = true;
            this.PAY013.VisibleIndex = 11;
            this.PAY013.Width = 60;
            // 
            // PAY014
            // 
            this.PAY014.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY014.AppearanceCell.Options.UseFont = true;
            this.PAY014.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY014.AppearanceHeader.Options.UseFont = true;
            this.PAY014.Caption = "11日";
            this.PAY014.FieldName = "PAY014";
            this.PAY014.Name = "PAY014";
            this.PAY014.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY014", "{0:0.##}")});
            this.PAY014.Visible = true;
            this.PAY014.VisibleIndex = 12;
            this.PAY014.Width = 60;
            // 
            // PAY015
            // 
            this.PAY015.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY015.AppearanceCell.Options.UseFont = true;
            this.PAY015.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY015.AppearanceHeader.Options.UseFont = true;
            this.PAY015.Caption = "12日";
            this.PAY015.FieldName = "PAY015";
            this.PAY015.Name = "PAY015";
            this.PAY015.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY015", "{0:0.##}")});
            this.PAY015.Visible = true;
            this.PAY015.VisibleIndex = 13;
            this.PAY015.Width = 60;
            // 
            // PAY016
            // 
            this.PAY016.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY016.AppearanceCell.Options.UseFont = true;
            this.PAY016.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY016.AppearanceHeader.Options.UseFont = true;
            this.PAY016.Caption = "13日";
            this.PAY016.FieldName = "PAY016";
            this.PAY016.Name = "PAY016";
            this.PAY016.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY016", "{0:0.##}")});
            this.PAY016.Visible = true;
            this.PAY016.VisibleIndex = 14;
            this.PAY016.Width = 60;
            // 
            // PAY017
            // 
            this.PAY017.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY017.AppearanceCell.Options.UseFont = true;
            this.PAY017.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY017.AppearanceHeader.Options.UseFont = true;
            this.PAY017.Caption = "14日";
            this.PAY017.FieldName = "PAY017";
            this.PAY017.Name = "PAY017";
            this.PAY017.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY017", "{0:0.##}")});
            this.PAY017.Visible = true;
            this.PAY017.VisibleIndex = 15;
            this.PAY017.Width = 60;
            // 
            // PAY018
            // 
            this.PAY018.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY018.AppearanceCell.Options.UseFont = true;
            this.PAY018.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY018.AppearanceHeader.Options.UseFont = true;
            this.PAY018.Caption = "15日";
            this.PAY018.FieldName = "PAY018";
            this.PAY018.Name = "PAY018";
            this.PAY018.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY018", "{0:0.##}")});
            this.PAY018.Visible = true;
            this.PAY018.VisibleIndex = 16;
            this.PAY018.Width = 60;
            // 
            // PAY019
            // 
            this.PAY019.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY019.AppearanceCell.Options.UseFont = true;
            this.PAY019.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY019.AppearanceHeader.Options.UseFont = true;
            this.PAY019.Caption = "16日";
            this.PAY019.FieldName = "PAY019";
            this.PAY019.Name = "PAY019";
            this.PAY019.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY019", "{0:0.##}")});
            this.PAY019.Visible = true;
            this.PAY019.VisibleIndex = 17;
            this.PAY019.Width = 60;
            // 
            // PAY020
            // 
            this.PAY020.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY020.AppearanceCell.Options.UseFont = true;
            this.PAY020.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY020.AppearanceHeader.Options.UseFont = true;
            this.PAY020.Caption = "17日";
            this.PAY020.FieldName = "PAY020";
            this.PAY020.Name = "PAY020";
            this.PAY020.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY020", "{0:0.##}")});
            this.PAY020.Visible = true;
            this.PAY020.VisibleIndex = 18;
            this.PAY020.Width = 60;
            // 
            // PAY021
            // 
            this.PAY021.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY021.AppearanceCell.Options.UseFont = true;
            this.PAY021.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY021.AppearanceHeader.Options.UseFont = true;
            this.PAY021.Caption = "18日";
            this.PAY021.FieldName = "PAY021";
            this.PAY021.Name = "PAY021";
            this.PAY021.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY021", "{0:0.##}")});
            this.PAY021.Visible = true;
            this.PAY021.VisibleIndex = 19;
            this.PAY021.Width = 60;
            // 
            // PAY022
            // 
            this.PAY022.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY022.AppearanceCell.Options.UseFont = true;
            this.PAY022.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY022.AppearanceHeader.Options.UseFont = true;
            this.PAY022.Caption = "19日";
            this.PAY022.FieldName = "PAY022";
            this.PAY022.Name = "PAY022";
            this.PAY022.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY022", "{0:0.##}")});
            this.PAY022.Visible = true;
            this.PAY022.VisibleIndex = 20;
            this.PAY022.Width = 60;
            // 
            // PAY023
            // 
            this.PAY023.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY023.AppearanceCell.Options.UseFont = true;
            this.PAY023.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY023.AppearanceHeader.Options.UseFont = true;
            this.PAY023.Caption = "20日";
            this.PAY023.FieldName = "PAY023";
            this.PAY023.Name = "PAY023";
            this.PAY023.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY023", "{0:0.##}")});
            this.PAY023.Visible = true;
            this.PAY023.VisibleIndex = 21;
            this.PAY023.Width = 60;
            // 
            // PAY024
            // 
            this.PAY024.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY024.AppearanceCell.Options.UseFont = true;
            this.PAY024.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY024.AppearanceHeader.Options.UseFont = true;
            this.PAY024.Caption = "21日";
            this.PAY024.FieldName = "PAY024";
            this.PAY024.Name = "PAY024";
            this.PAY024.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY024", "{0:0.##}")});
            this.PAY024.Visible = true;
            this.PAY024.VisibleIndex = 22;
            this.PAY024.Width = 60;
            // 
            // PAY025
            // 
            this.PAY025.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY025.AppearanceCell.Options.UseFont = true;
            this.PAY025.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY025.AppearanceHeader.Options.UseFont = true;
            this.PAY025.Caption = "22日";
            this.PAY025.FieldName = "PAY025";
            this.PAY025.Name = "PAY025";
            this.PAY025.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY025", "{0:0.##}")});
            this.PAY025.Visible = true;
            this.PAY025.VisibleIndex = 23;
            this.PAY025.Width = 60;
            // 
            // PAY026
            // 
            this.PAY026.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY026.AppearanceCell.Options.UseFont = true;
            this.PAY026.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY026.AppearanceHeader.Options.UseFont = true;
            this.PAY026.Caption = "23日";
            this.PAY026.FieldName = "PAY026";
            this.PAY026.Name = "PAY026";
            this.PAY026.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY026", "{0:0.##}")});
            this.PAY026.Visible = true;
            this.PAY026.VisibleIndex = 24;
            this.PAY026.Width = 60;
            // 
            // PAY027
            // 
            this.PAY027.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY027.AppearanceCell.Options.UseFont = true;
            this.PAY027.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY027.AppearanceHeader.Options.UseFont = true;
            this.PAY027.Caption = "24日";
            this.PAY027.FieldName = "PAY027";
            this.PAY027.Name = "PAY027";
            this.PAY027.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY027", "{0:0.##}")});
            this.PAY027.Visible = true;
            this.PAY027.VisibleIndex = 25;
            this.PAY027.Width = 60;
            // 
            // PAY028
            // 
            this.PAY028.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY028.AppearanceCell.Options.UseFont = true;
            this.PAY028.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY028.AppearanceHeader.Options.UseFont = true;
            this.PAY028.Caption = "25日";
            this.PAY028.FieldName = "PAY028";
            this.PAY028.Name = "PAY028";
            this.PAY028.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY028", "{0:0.##}")});
            this.PAY028.Visible = true;
            this.PAY028.VisibleIndex = 26;
            this.PAY028.Width = 60;
            // 
            // PAY029
            // 
            this.PAY029.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY029.AppearanceCell.Options.UseFont = true;
            this.PAY029.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY029.AppearanceHeader.Options.UseFont = true;
            this.PAY029.Caption = "26日";
            this.PAY029.FieldName = "PAY029";
            this.PAY029.Name = "PAY029";
            this.PAY029.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY029", "{0:0.##}")});
            this.PAY029.Visible = true;
            this.PAY029.VisibleIndex = 27;
            this.PAY029.Width = 60;
            // 
            // PAY030
            // 
            this.PAY030.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY030.AppearanceCell.Options.UseFont = true;
            this.PAY030.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY030.AppearanceHeader.Options.UseFont = true;
            this.PAY030.Caption = "27日";
            this.PAY030.FieldName = "PAY030";
            this.PAY030.Name = "PAY030";
            this.PAY030.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY030", "{0:0.##}")});
            this.PAY030.Visible = true;
            this.PAY030.VisibleIndex = 28;
            this.PAY030.Width = 60;
            // 
            // PAY031
            // 
            this.PAY031.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY031.AppearanceCell.Options.UseFont = true;
            this.PAY031.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY031.AppearanceHeader.Options.UseFont = true;
            this.PAY031.Caption = "28日";
            this.PAY031.FieldName = "PAY031";
            this.PAY031.Name = "PAY031";
            this.PAY031.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY031", "{0:0.##}")});
            this.PAY031.Visible = true;
            this.PAY031.VisibleIndex = 29;
            this.PAY031.Width = 60;
            // 
            // PAY032
            // 
            this.PAY032.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY032.AppearanceCell.Options.UseFont = true;
            this.PAY032.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY032.AppearanceHeader.Options.UseFont = true;
            this.PAY032.Caption = "29日";
            this.PAY032.FieldName = "PAY032";
            this.PAY032.Name = "PAY032";
            this.PAY032.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY032", "{0:0.##}")});
            this.PAY032.Visible = true;
            this.PAY032.VisibleIndex = 30;
            this.PAY032.Width = 60;
            // 
            // PAY033
            // 
            this.PAY033.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY033.AppearanceCell.Options.UseFont = true;
            this.PAY033.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY033.AppearanceHeader.Options.UseFont = true;
            this.PAY033.Caption = "30日";
            this.PAY033.FieldName = "PAY033";
            this.PAY033.Name = "PAY033";
            this.PAY033.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY033", "{0:0.##}")});
            this.PAY033.Visible = true;
            this.PAY033.VisibleIndex = 31;
            this.PAY033.Width = 60;
            // 
            // PAY034
            // 
            this.PAY034.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY034.AppearanceCell.Options.UseFont = true;
            this.PAY034.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAY034.AppearanceHeader.Options.UseFont = true;
            this.PAY034.Caption = "31日";
            this.PAY034.FieldName = "PAY034";
            this.PAY034.Name = "PAY034";
            this.PAY034.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAY034", "{0:0.##}")});
            this.PAY034.Visible = true;
            this.PAY034.VisibleIndex = 32;
            this.PAY034.Width = 60;
            // 
            // U0
            // 
            this.U0.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U0.AppearanceCell.Options.UseFont = true;
            this.U0.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U0.AppearanceHeader.Options.UseFont = true;
            this.U0.Caption = "工资";
            this.U0.FieldName = "U0";
            this.U0.Name = "U0";
            this.U0.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "U0", "{0:0.##}")});
            this.U0.Visible = true;
            this.U0.VisibleIndex = 33;
            this.U0.Width = 70;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // lupWoodColor
            // 
            this.lupWoodColor.AutoHeight = false;
            this.lupWoodColor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupWoodColor.Name = "lupWoodColor";
            this.lupWoodColor.NullText = "";
            this.lupWoodColor.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupWoodColor.ShowHeader = false;
            // 
            // cmbType
            // 
            this.cmbType.AutoHeight = false;
            this.cmbType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbType.Name = "cmbType";
            // 
            // cmbGrade
            // 
            this.cmbGrade.AutoHeight = false;
            this.cmbGrade.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbGrade.Name = "cmbGrade";
            // 
            // lupProduct
            // 
            this.lupProduct.AutoHeight = false;
            this.lupProduct.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupProduct.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WOB001", 200, "品号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WOB002", 300, "品名")});
            this.lupProduct.Name = "lupProduct";
            this.lupProduct.NullText = "";
            this.lupProduct.PopupWidth = 500;
            // 
            // wait
            // 
            this.wait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wait.Appearance.Options.UseBackColor = true;
            this.wait.BarAnimationElementThickness = 2;
            this.wait.Caption = "请稍后";
            this.wait.Description = "数据加载中 ...";
            this.wait.Location = new System.Drawing.Point(495, 186);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 39;
            this.wait.Text = "progressPanel1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FormPayrollReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 438);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormPayrollReport";
            this.Text = "员工工资报表";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.wait, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupWoodColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraEditors . DateEdit dateEdit;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PAY001;
        private DevExpress . XtraGrid . Columns . GridColumn PAY002;
        private DevExpress . XtraGrid . Columns . GridColumn PAY004;
        private DevExpress . XtraGrid . Columns . GridColumn PAY005;
        private DevExpress . XtraEditors . Repository . RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit lupWoodColor;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbType;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbGrade;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit lupProduct;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraEditors . SimpleButton btnRead;
        private DevExpress . XtraGrid . Columns . GridColumn PAY006;
        private DevExpress . XtraGrid . Columns . GridColumn PAY007;
        private DevExpress . XtraGrid . Columns . GridColumn PAY008;
        private DevExpress . XtraGrid . Columns . GridColumn PAY009;
        private DevExpress . XtraGrid . Columns . GridColumn PAY010;
        private DevExpress . XtraGrid . Columns . GridColumn PAY011;
        private DevExpress . XtraGrid . Columns . GridColumn PAY012;
        private DevExpress . XtraGrid . Columns . GridColumn PAY013;
        private DevExpress . XtraGrid . Columns . GridColumn PAY014;
        private DevExpress . XtraGrid . Columns . GridColumn PAY015;
        private DevExpress . XtraGrid . Columns . GridColumn PAY016;
        private DevExpress . XtraGrid . Columns . GridColumn PAY017;
        private DevExpress . XtraGrid . Columns . GridColumn PAY018;
        private DevExpress . XtraGrid . Columns . GridColumn PAY019;
        private DevExpress . XtraGrid . Columns . GridColumn PAY020;
        private DevExpress . XtraGrid . Columns . GridColumn PAY021;
        private DevExpress . XtraGrid . Columns . GridColumn PAY022;
        private DevExpress . XtraGrid . Columns . GridColumn PAY023;
        private DevExpress . XtraGrid . Columns . GridColumn PAY024;
        private DevExpress . XtraGrid . Columns . GridColumn PAY025;
        private DevExpress . XtraGrid . Columns . GridColumn PAY026;
        private DevExpress . XtraGrid . Columns . GridColumn PAY027;
        private DevExpress . XtraGrid . Columns . GridColumn PAY028;
        private DevExpress . XtraGrid . Columns . GridColumn PAY029;
        private DevExpress . XtraGrid . Columns . GridColumn PAY030;
        private DevExpress . XtraGrid . Columns . GridColumn PAY031;
        private DevExpress . XtraGrid . Columns . GridColumn PAY032;
        private DevExpress . XtraGrid . Columns . GridColumn PAY033;
        private DevExpress . XtraGrid . Columns . GridColumn PAY034;
        private DevExpress . XtraGrid . Columns . GridColumn U0;
    }
}