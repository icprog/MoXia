namespace Carpenter
{
    partial class FormProductCycle
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
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.lupProductName = new DevExpress.XtraEditors.LookUpEdit();
            this.lupPartNum = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CUU001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUU002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUU008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUU009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUU003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRD013 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWF012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U0 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDK012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PME012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLF012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWF012M = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWF012Z = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.lupWoodColor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cmbGrade = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.lupProduct = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupProductName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPartNum.Properties)).BeginInit();
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
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.btnClear);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupProductName);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupPartNum);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1237, 430);
            this.splitContainerControl1.SplitterPosition = 39;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.Location = new System.Drawing.Point(519, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "清  除";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lupProductName
            // 
            this.lupProductName.Location = new System.Drawing.Point(292, 11);
            this.lupProductName.MenuManager = this.barManager1;
            this.lupProductName.Name = "lupProductName";
            this.lupProductName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupProductName.Properties.NullText = "";
            this.lupProductName.Properties.PopupWidth = 1000;
            this.lupProductName.Properties.ShowHeader = false;
            this.lupProductName.Size = new System.Drawing.Size(205, 20);
            this.lupProductName.TabIndex = 12;
            // 
            // lupPartNum
            // 
            this.lupPartNum.Location = new System.Drawing.Point(60, 11);
            this.lupPartNum.MenuManager = this.barManager1;
            this.lupPartNum.Name = "lupPartNum";
            this.lupPartNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPartNum.Properties.NullText = "";
            this.lupPartNum.Properties.ShowHeader = false;
            this.lupPartNum.Size = new System.Drawing.Size(126, 20);
            this.lupPartNum.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(216, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 14);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "产品信息：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "批号：";
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
            this.gridControl1.Size = new System.Drawing.Size(1237, 379);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CUU001,
            this.CUU002,
            this.CUU008,
            this.CUU009,
            this.OPI006,
            this.OPI007,
            this.CUU003,
            this.PRD013,
            this.PWF012,
            this.U0,
            this.PDK012,
            this.PME012,
            this.PLF012,
            this.PWF012M,
            this.PWF012Z});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // CUU001
            // 
            this.CUU001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU001.AppearanceCell.Options.UseFont = true;
            this.CUU001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU001.AppearanceHeader.Options.UseFont = true;
            this.CUU001.Caption = "批号";
            this.CUU001.FieldName = "CUU001";
            this.CUU001.Name = "CUU001";
            this.CUU001.OptionsColumn.AllowEdit = false;
            this.CUU001.Visible = true;
            this.CUU001.VisibleIndex = 0;
            this.CUU001.Width = 57;
            // 
            // CUU002
            // 
            this.CUU002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU002.AppearanceCell.Options.UseFont = true;
            this.CUU002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU002.AppearanceHeader.Options.UseFont = true;
            this.CUU002.Caption = "品号";
            this.CUU002.FieldName = "CUU002";
            this.CUU002.Name = "CUU002";
            this.CUU002.OptionsColumn.AllowEdit = false;
            this.CUU002.Visible = true;
            this.CUU002.VisibleIndex = 1;
            this.CUU002.Width = 146;
            // 
            // CUU008
            // 
            this.CUU008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU008.AppearanceCell.Options.UseFont = true;
            this.CUU008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU008.AppearanceHeader.Options.UseFont = true;
            this.CUU008.Caption = "品名";
            this.CUU008.FieldName = "CUU008";
            this.CUU008.Name = "CUU008";
            this.CUU008.OptionsColumn.AllowEdit = false;
            this.CUU008.Visible = true;
            this.CUU008.VisibleIndex = 2;
            this.CUU008.Width = 191;
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
            this.CUU009.VisibleIndex = 3;
            this.CUU009.Width = 145;
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
            this.OPI006.Visible = true;
            this.OPI006.VisibleIndex = 4;
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
            this.OPI007.Visible = true;
            this.OPI007.VisibleIndex = 5;
            this.OPI007.Width = 42;
            // 
            // CUU003
            // 
            this.CUU003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU003.AppearanceCell.Options.UseFont = true;
            this.CUU003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU003.AppearanceHeader.Options.UseFont = true;
            this.CUU003.Caption = "数量";
            this.CUU003.FieldName = "CUU003";
            this.CUU003.Name = "CUU003";
            this.CUU003.OptionsColumn.AllowEdit = false;
            this.CUU003.Visible = true;
            this.CUU003.VisibleIndex = 6;
            this.CUU003.Width = 56;
            // 
            // PRD013
            // 
            this.PRD013.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD013.AppearanceCell.Options.UseFont = true;
            this.PRD013.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD013.AppearanceHeader.Options.UseFont = true;
            this.PRD013.Caption = "开始时间";
            this.PRD013.FieldName = "PRD013";
            this.PRD013.Name = "PRD013";
            this.PRD013.OptionsColumn.AllowEdit = false;
            this.PRD013.Visible = true;
            this.PRD013.VisibleIndex = 7;
            this.PRD013.Width = 109;
            // 
            // PWF012
            // 
            this.PWF012.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF012.AppearanceCell.Options.UseFont = true;
            this.PWF012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF012.AppearanceHeader.Options.UseFont = true;
            this.PWF012.Caption = "结束时间";
            this.PWF012.FieldName = "PWF012";
            this.PWF012.Name = "PWF012";
            this.PWF012.OptionsColumn.AllowEdit = false;
            this.PWF012.Visible = true;
            this.PWF012.VisibleIndex = 8;
            this.PWF012.Width = 97;
            // 
            // U0
            // 
            this.U0.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U0.AppearanceCell.Options.UseFont = true;
            this.U0.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U0.AppearanceHeader.Options.UseFont = true;
            this.U0.Caption = "生产总周期";
            this.U0.FieldName = "U0";
            this.U0.Name = "U0";
            this.U0.OptionsColumn.AllowEdit = false;
            this.U0.ToolTip = "备料生产周期+机加工生产周期+组装生产周期+油漆生产周期+包装生产周期";
            this.U0.Visible = true;
            this.U0.VisibleIndex = 9;
            this.U0.Width = 80;
            // 
            // PDK012
            // 
            this.PDK012.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDK012.AppearanceCell.Options.UseFont = true;
            this.PDK012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDK012.AppearanceHeader.Options.UseFont = true;
            this.PDK012.Caption = "备料生产周期";
            this.PDK012.FieldName = "PDK012";
            this.PDK012.Name = "PDK012";
            this.PDK012.Visible = true;
            this.PDK012.VisibleIndex = 10;
            this.PDK012.Width = 94;
            // 
            // PME012
            // 
            this.PME012.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PME012.AppearanceCell.Options.UseFont = true;
            this.PME012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PME012.AppearanceHeader.Options.UseFont = true;
            this.PME012.Caption = "机加工生产周期";
            this.PME012.FieldName = "PME012";
            this.PME012.Name = "PME012";
            this.PME012.Visible = true;
            this.PME012.VisibleIndex = 11;
            this.PME012.Width = 108;
            // 
            // PLF012
            // 
            this.PLF012.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLF012.AppearanceCell.Options.UseFont = true;
            this.PLF012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLF012.AppearanceHeader.Options.UseFont = true;
            this.PLF012.Caption = "组装生产周期";
            this.PLF012.FieldName = "PLF012";
            this.PLF012.Name = "PLF012";
            this.PLF012.Visible = true;
            this.PLF012.VisibleIndex = 12;
            this.PLF012.Width = 94;
            // 
            // PWF012M
            // 
            this.PWF012M.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF012M.AppearanceCell.Options.UseFont = true;
            this.PWF012M.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF012M.AppearanceHeader.Options.UseFont = true;
            this.PWF012M.Caption = "油漆生产周期";
            this.PWF012M.FieldName = "PWF012M";
            this.PWF012M.Name = "PWF012M";
            this.PWF012M.Visible = true;
            this.PWF012M.VisibleIndex = 13;
            this.PWF012M.Width = 94;
            // 
            // PWF012Z
            // 
            this.PWF012Z.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF012Z.AppearanceCell.Options.UseFont = true;
            this.PWF012Z.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF012Z.AppearanceHeader.Options.UseFont = true;
            this.PWF012Z.Caption = "包装生产周期";
            this.PWF012Z.FieldName = "PWF012Z";
            this.PWF012Z.Name = "PWF012Z";
            this.PWF012Z.Visible = true;
            this.PWF012Z.VisibleIndex = 14;
            this.PWF012Z.Width = 94;
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
            // FormProductCycle
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 456);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormProductCycle";
            this.Text = "产品周期表";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.wait, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lupProductName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPartNum.Properties)).EndInit();
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
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn CUU001;
        private DevExpress . XtraGrid . Columns . GridColumn CUU002;
        private DevExpress . XtraGrid . Columns . GridColumn CUU008;
        private DevExpress . XtraGrid . Columns . GridColumn CUU009;
        private DevExpress . XtraGrid . Columns . GridColumn CUU003;
        private DevExpress . XtraGrid . Columns . GridColumn PRD013;
        private DevExpress . XtraGrid . Columns . GridColumn PWF012;
        private DevExpress . XtraGrid . Columns . GridColumn U0;
        private DevExpress . XtraEditors . Repository . RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit lupWoodColor;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbType;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbGrade;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit lupProduct;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LookUpEdit lupPartNum;
        private DevExpress . XtraEditors . LookUpEdit lupProductName;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn PDK012;
        private DevExpress . XtraGrid . Columns . GridColumn PME012;
        private DevExpress . XtraGrid . Columns . GridColumn PLF012;
        private DevExpress . XtraGrid . Columns . GridColumn PWF012M;
        private DevExpress . XtraGrid . Columns . GridColumn PWF012Z;
        private DevExpress . XtraEditors . SimpleButton btnClear;
    }
}