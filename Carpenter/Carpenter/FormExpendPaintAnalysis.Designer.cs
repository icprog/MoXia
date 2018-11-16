namespace Carpenter
{
    partial class FormExpendPaintAnalysis
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnRead = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.EPA002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EPA003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EPA004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EPA005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EPA008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EPA006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U0 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EPA007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.lupWoodColor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cmbGrade = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.lupProduct = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
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
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnRead);
            this.splitContainerControl1.Panel1.Controls.Add(this.dateEdit);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1237, 412);
            this.splitContainerControl1.SplitterPosition = 35;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 14);
            this.labelControl2.TabIndex = 34;
            this.labelControl2.Text = "年月：";
            // 
            // btnRead
            // 
            this.btnRead.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.Appearance.Options.UseFont = true;
            this.btnRead.Location = new System.Drawing.Point(239, 6);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 33;
            this.btnRead.Text = "生成";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // dateEdit
            // 
            this.dateEdit.EditValue = null;
            this.dateEdit.Location = new System.Drawing.Point(60, 7);
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
            this.dateEdit.TabIndex = 1;
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
            this.gridControl1.Size = new System.Drawing.Size(1237, 365);
            this.gridControl1.TabIndex = 7;
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
            this.EPA002,
            this.EPA003,
            this.EPA004,
            this.EPA005,
            this.EPA008,
            this.EPA006,
            this.U2,
            this.U0,
            this.U1,
            this.EPA007,
            this.idx});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // EPA002
            // 
            this.EPA002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPA002.AppearanceCell.Options.UseFont = true;
            this.EPA002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPA002.AppearanceHeader.Options.UseFont = true;
            this.EPA002.Caption = "物料名称";
            this.EPA002.FieldName = "EPA002";
            this.EPA002.Name = "EPA002";
            this.EPA002.OptionsColumn.AllowEdit = false;
            this.EPA002.Visible = true;
            this.EPA002.VisibleIndex = 0;
            this.EPA002.Width = 125;
            // 
            // EPA003
            // 
            this.EPA003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPA003.AppearanceCell.Options.UseFont = true;
            this.EPA003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPA003.AppearanceHeader.Options.UseFont = true;
            this.EPA003.Caption = "单价";
            this.EPA003.FieldName = "EPA003";
            this.EPA003.Name = "EPA003";
            this.EPA003.OptionsColumn.AllowEdit = false;
            this.EPA003.Visible = true;
            this.EPA003.VisibleIndex = 1;
            // 
            // EPA004
            // 
            this.EPA004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPA004.AppearanceCell.Options.UseFont = true;
            this.EPA004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPA004.AppearanceHeader.Options.UseFont = true;
            this.EPA004.Caption = "期初库存";
            this.EPA004.FieldName = "EPA004";
            this.EPA004.Name = "EPA004";
            this.EPA004.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EPA004", "{0:0.#}")});
            this.EPA004.Visible = true;
            this.EPA004.VisibleIndex = 2;
            this.EPA004.Width = 97;
            // 
            // EPA005
            // 
            this.EPA005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPA005.AppearanceCell.Options.UseFont = true;
            this.EPA005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPA005.AppearanceHeader.Options.UseFont = true;
            this.EPA005.Caption = "盘低留存";
            this.EPA005.FieldName = "EPA005";
            this.EPA005.Name = "EPA005";
            this.EPA005.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EPA005", "{0:0.#}")});
            this.EPA005.Visible = true;
            this.EPA005.VisibleIndex = 3;
            this.EPA005.Width = 92;
            // 
            // EPA008
            // 
            this.EPA008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPA008.AppearanceCell.Options.UseFont = true;
            this.EPA008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPA008.AppearanceHeader.Options.UseFont = true;
            this.EPA008.Caption = "本期领用";
            this.EPA008.FieldName = "EPA008";
            this.EPA008.Name = "EPA008";
            this.EPA008.OptionsColumn.AllowEdit = false;
            this.EPA008.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EPA008", "{0:0.#}")});
            this.EPA008.Visible = true;
            this.EPA008.VisibleIndex = 4;
            this.EPA008.Width = 100;
            // 
            // EPA006
            // 
            this.EPA006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPA006.AppearanceCell.Options.UseFont = true;
            this.EPA006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPA006.AppearanceHeader.Options.UseFont = true;
            this.EPA006.Caption = "理论耗用";
            this.EPA006.DisplayFormat.FormatString = "0.#";
            this.EPA006.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.EPA006.FieldName = "EPA006";
            this.EPA006.Name = "EPA006";
            this.EPA006.OptionsColumn.AllowEdit = false;
            this.EPA006.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EPA006", "{0:0.#}")});
            this.EPA006.Visible = true;
            this.EPA006.VisibleIndex = 5;
            this.EPA006.Width = 102;
            // 
            // U2
            // 
            this.U2.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U2.AppearanceCell.Options.UseFont = true;
            this.U2.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U2.AppearanceHeader.Options.UseFont = true;
            this.U2.Caption = "实际耗用";
            this.U2.DisplayFormat.FormatString = "0.#";
            this.U2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.U2.FieldName = "U2";
            this.U2.Name = "U2";
            this.U2.OptionsColumn.AllowEdit = false;
            this.U2.ToolTip = "[期初库存] + [本期领用] - [盘低留存]";
            this.U2.UnboundExpression = "[EPA004] + [EPA008] - [EPA005]";
            this.U2.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U2.Visible = true;
            this.U2.VisibleIndex = 6;
            // 
            // U0
            // 
            this.U0.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U0.AppearanceCell.Options.UseFont = true;
            this.U0.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U0.AppearanceHeader.Options.UseFont = true;
            this.U0.AppearanceHeader.Options.UseTextOptions = true;
            this.U0.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U0.Caption = "差异";
            this.U0.DisplayFormat.FormatString = "0.#";
            this.U0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.U0.FieldName = "U0";
            this.U0.Name = "U0";
            this.U0.OptionsColumn.AllowEdit = false;
            this.U0.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "U0", "{0:0.#}")});
            this.U0.ToolTip = "[理论耗用] - [实际耗用] ";
            this.U0.Visible = true;
            this.U0.VisibleIndex = 7;
            this.U0.Width = 86;
            // 
            // U1
            // 
            this.U1.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U1.AppearanceCell.Options.UseFont = true;
            this.U1.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U1.AppearanceHeader.Options.UseFont = true;
            this.U1.Caption = "小计";
            this.U1.DisplayFormat.FormatString = "{0:0.#}";
            this.U1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U1.FieldName = "U1";
            this.U1.Name = "U1";
            this.U1.OptionsColumn.AllowEdit = false;
            this.U1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "U1", "{0:0.#}")});
            this.U1.ToolTip = "[差异] * [单价]";
            this.U1.UnboundExpression = "[U0] * [EPA003]";
            this.U1.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U1.Visible = true;
            this.U1.VisibleIndex = 8;
            this.U1.Width = 90;
            // 
            // EPA007
            // 
            this.EPA007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPA007.AppearanceCell.Options.UseFont = true;
            this.EPA007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPA007.AppearanceHeader.Options.UseFont = true;
            this.EPA007.Caption = "备注";
            this.EPA007.FieldName = "EPA007";
            this.EPA007.Name = "EPA007";
            this.EPA007.Visible = true;
            this.EPA007.VisibleIndex = 9;
            this.EPA007.Width = 282;
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
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
            this.wait.TabIndex = 37;
            this.wait.Text = "progressPanel1";
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
            // FormExpendPaintAnalysis
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 438);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormExpendPaintAnalysis";
            this.Text = "油漆耗用分析表";
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
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn EPA002;
        private DevExpress . XtraGrid . Columns . GridColumn EPA003;
        private DevExpress . XtraGrid . Columns . GridColumn EPA004;
        private DevExpress . XtraGrid . Columns . GridColumn EPA005;
        private DevExpress . XtraGrid . Columns . GridColumn EPA006;
        private DevExpress . XtraGrid . Columns . GridColumn U0;
        private DevExpress . XtraGrid . Columns . GridColumn U1;
        private DevExpress . XtraEditors . Repository . RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit lupWoodColor;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbType;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbGrade;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit lupProduct;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private DevExpress . XtraGrid . Columns . GridColumn EPA007;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn EPA008;
        private System . ComponentModel . BackgroundWorker backgroundWorker2;
        private DevExpress . XtraEditors . SimpleButton btnRead;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraGrid . Columns . GridColumn U2;
    }
}