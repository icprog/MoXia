namespace Carpenter
{
    partial class FormExoendBasePaint
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EBP001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbWoodType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.EBP002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbWorkProcedure = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.EBP003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbPaintName = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cmbPaintType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.EBP005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EBP006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EBP007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lupWoodType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWoodType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWorkProcedure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaintName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaintType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupWoodType)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 26);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lupWoodType,
            this.cmbWorkProcedure,
            this.cmbPaintName,
            this.cmbPaintType,
            this.cmbWoodType});
            this.gridControl1.Size = new System.Drawing.Size(1237, 412);
            this.gridControl1.TabIndex = 6;
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
            this.EBP001,
            this.EBP002,
            this.EBP003,
            this.EBP005,
            this.EBP006,
            this.EBP007});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // EBP001
            // 
            this.EBP001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EBP001.AppearanceCell.Options.UseFont = true;
            this.EBP001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EBP001.AppearanceHeader.Options.UseFont = true;
            this.EBP001.Caption = "木材";
            this.EBP001.ColumnEdit = this.cmbWoodType;
            this.EBP001.FieldName = "EBP001";
            this.EBP001.Name = "EBP001";
            this.EBP001.Visible = true;
            this.EBP001.VisibleIndex = 0;
            this.EBP001.Width = 121;
            // 
            // cmbWoodType
            // 
            this.cmbWoodType.AutoHeight = false;
            this.cmbWoodType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbWoodType.Name = "cmbWoodType";
            // 
            // EBP002
            // 
            this.EBP002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EBP002.AppearanceCell.Options.UseFont = true;
            this.EBP002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EBP002.AppearanceHeader.Options.UseFont = true;
            this.EBP002.Caption = "工序";
            this.EBP002.ColumnEdit = this.cmbWorkProcedure;
            this.EBP002.FieldName = "EBP002";
            this.EBP002.Name = "EBP002";
            this.EBP002.Visible = true;
            this.EBP002.VisibleIndex = 1;
            this.EBP002.Width = 162;
            // 
            // cmbWorkProcedure
            // 
            this.cmbWorkProcedure.AutoHeight = false;
            this.cmbWorkProcedure.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbWorkProcedure.Name = "cmbWorkProcedure";
            // 
            // EBP003
            // 
            this.EBP003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EBP003.AppearanceCell.Options.UseFont = true;
            this.EBP003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EBP003.AppearanceHeader.Options.UseFont = true;
            this.EBP003.Caption = "油漆名称";
            this.EBP003.ColumnEdit = this.cmbPaintName;
            this.EBP003.FieldName = "EBP003";
            this.EBP003.Name = "EBP003";
            this.EBP003.Visible = true;
            this.EBP003.VisibleIndex = 2;
            this.EBP003.Width = 204;
            // 
            // cmbPaintName
            // 
            this.cmbPaintName.AutoHeight = false;
            this.cmbPaintName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPaintName.Name = "cmbPaintName";
            // 
            // cmbPaintType
            // 
            this.cmbPaintType.AutoHeight = false;
            this.cmbPaintType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPaintType.Name = "cmbPaintType";
            // 
            // EBP005
            // 
            this.EBP005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EBP005.AppearanceCell.Options.UseFont = true;
            this.EBP005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EBP005.AppearanceHeader.Options.UseFont = true;
            this.EBP005.Caption = "用量";
            this.EBP005.FieldName = "EBP005";
            this.EBP005.Name = "EBP005";
            this.EBP005.Visible = true;
            this.EBP005.VisibleIndex = 4;
            this.EBP005.Width = 92;
            // 
            // EBP006
            // 
            this.EBP006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EBP006.AppearanceCell.Options.UseFont = true;
            this.EBP006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EBP006.AppearanceHeader.Options.UseFont = true;
            this.EBP006.Caption = "油漆配比批次";
            this.EBP006.FieldName = "EBP006";
            this.EBP006.Name = "EBP006";
            this.EBP006.Visible = true;
            this.EBP006.VisibleIndex = 5;
            this.EBP006.Width = 125;
            // 
            // EBP007
            // 
            this.EBP007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EBP007.AppearanceCell.Options.UseFont = true;
            this.EBP007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EBP007.AppearanceHeader.Options.UseFont = true;
            this.EBP007.Caption = "单价";
            this.EBP007.FieldName = "EBP007";
            this.EBP007.Name = "EBP007";
            this.EBP007.Visible = true;
            this.EBP007.VisibleIndex = 3;
            this.EBP007.Width = 141;
            // 
            // lupWoodType
            // 
            this.lupWoodType.AutoHeight = false;
            this.lupWoodType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupWoodType.Name = "lupWoodType";
            this.lupWoodType.NullText = "";
            this.lupWoodType.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupWoodType.PopupWidth = 100;
            this.lupWoodType.ShowHeader = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
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
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // FormExoendBasePaint
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 438);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormExoendBasePaint";
            this.Text = "油漆基础资料";
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.wait, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWoodType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWorkProcedure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaintName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaintType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupWoodType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn EBP001;
        private DevExpress . XtraGrid . Columns . GridColumn EBP002;
        private DevExpress . XtraGrid . Columns . GridColumn EBP003;
        private DevExpress . XtraGrid . Columns . GridColumn EBP005;
        private DevExpress . XtraGrid . Columns . GridColumn EBP006;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit lupWoodType;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbWorkProcedure;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbPaintName;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbPaintType;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private System . ComponentModel . BackgroundWorker backgroundWorker2;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbWoodType;
        private DevExpress . XtraGrid . Columns . GridColumn EBP007;
    }
}