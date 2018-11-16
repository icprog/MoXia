namespace Carpenter
{
    partial class FormExpendWoodAnalysis
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
            this.lupBatchNum = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MCLX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CPXL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LHY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SHY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BFB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BXH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.lupWoodColor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cmbGrade = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.lupProduct = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupBatchNum.Properties)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.lupBatchNum);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1237, 412);
            this.splitContainerControl1.SplitterPosition = 31;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // lupBatchNum
            // 
            this.lupBatchNum.Location = new System.Drawing.Point(60, 8);
            this.lupBatchNum.Name = "lupBatchNum";
            this.lupBatchNum.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupBatchNum.Properties.Appearance.Options.UseFont = true;
            this.lupBatchNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupBatchNum.Properties.NullText = "";
            this.lupBatchNum.Properties.ShowHeader = false;
            this.lupBatchNum.Size = new System.Drawing.Size(134, 20);
            this.lupBatchNum.TabIndex = 5;
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
            this.gridControl1.Size = new System.Drawing.Size(1237, 369);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PIH,
            this.MCLX,
            this.CPXL,
            this.LHY,
            this.SHY,
            this.BFB,
            this.BXH});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PIH
            // 
            this.PIH.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PIH.AppearanceCell.Options.UseFont = true;
            this.PIH.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PIH.AppearanceHeader.Options.UseFont = true;
            this.PIH.Caption = "批次";
            this.PIH.FieldName = "PIH";
            this.PIH.Name = "PIH";
            this.PIH.Visible = true;
            this.PIH.VisibleIndex = 0;
            this.PIH.Width = 112;
            // 
            // MCLX
            // 
            this.MCLX.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.MCLX.AppearanceCell.Options.UseFont = true;
            this.MCLX.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.MCLX.AppearanceHeader.Options.UseFont = true;
            this.MCLX.Caption = "木材类型";
            this.MCLX.FieldName = "MCLX";
            this.MCLX.Name = "MCLX";
            this.MCLX.OptionsColumn.AllowEdit = false;
            this.MCLX.Visible = true;
            this.MCLX.VisibleIndex = 1;
            this.MCLX.Width = 184;
            // 
            // CPXL
            // 
            this.CPXL.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CPXL.AppearanceCell.Options.UseFont = true;
            this.CPXL.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CPXL.AppearanceHeader.Options.UseFont = true;
            this.CPXL.Caption = "产品系列";
            this.CPXL.FieldName = "CPXL";
            this.CPXL.Name = "CPXL";
            this.CPXL.Visible = true;
            this.CPXL.VisibleIndex = 2;
            this.CPXL.Width = 197;
            // 
            // LHY
            // 
            this.LHY.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.LHY.AppearanceCell.Options.UseFont = true;
            this.LHY.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.LHY.AppearanceHeader.Options.UseFont = true;
            this.LHY.Caption = "理论耗用";
            this.LHY.FieldName = "LHY";
            this.LHY.Name = "LHY";
            this.LHY.Visible = true;
            this.LHY.VisibleIndex = 3;
            this.LHY.Width = 154;
            // 
            // SHY
            // 
            this.SHY.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.SHY.AppearanceCell.Options.UseFont = true;
            this.SHY.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.SHY.AppearanceHeader.Options.UseFont = true;
            this.SHY.Caption = "实际耗用";
            this.SHY.FieldName = "SHY";
            this.SHY.Name = "SHY";
            this.SHY.Visible = true;
            this.SHY.VisibleIndex = 4;
            this.SHY.Width = 142;
            // 
            // BFB
            // 
            this.BFB.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.BFB.AppearanceCell.Options.UseFont = true;
            this.BFB.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.BFB.AppearanceHeader.Options.UseFont = true;
            this.BFB.Caption = "出材率";
            this.BFB.DisplayFormat.FormatString = "P0";
            this.BFB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.BFB.FieldName = "BFB";
            this.BFB.Name = "BFB";
            this.BFB.Visible = true;
            this.BFB.VisibleIndex = 5;
            this.BFB.Width = 140;
            // 
            // BXH
            // 
            this.BXH.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.BXH.AppearanceCell.Options.UseFont = true;
            this.BXH.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.BXH.AppearanceHeader.Options.UseFont = true;
            this.BXH.Caption = "包芯料耗用";
            this.BXH.FieldName = "BXH";
            this.BXH.Name = "BXH";
            this.BXH.Visible = true;
            this.BXH.VisibleIndex = 6;
            this.BXH.Width = 120;
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
            this.wait.TabIndex = 36;
            this.wait.Text = "progressPanel1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "批号：";
            // 
            // FormExpendWoodAnalysis
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 438);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormExpendWoodAnalysis";
            this.Text = "木材耗用分析表";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.wait, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lupBatchNum.Properties)).EndInit();
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
        private DevExpress . XtraEditors . LookUpEdit lupBatchNum;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PIH;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit lupProduct;
        private DevExpress . XtraGrid . Columns . GridColumn MCLX;
        private DevExpress . XtraGrid . Columns . GridColumn CPXL;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit lupWoodColor;
        private DevExpress . XtraGrid . Columns . GridColumn LHY;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbType;
        private DevExpress . XtraGrid . Columns . GridColumn SHY;
        private DevExpress . XtraGrid . Columns . GridColumn BFB;
        private DevExpress . XtraEditors . Repository . RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbGrade;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private DevExpress . XtraGrid . Columns . GridColumn BXH;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraEditors . LabelControl labelControl2;
    }
}