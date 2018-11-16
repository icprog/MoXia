namespace Carpenter
{
    partial class FormExpendWood
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
            this.EXW002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EXW003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.EXW004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EXW005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbGrade = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.EXW006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EXW007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EXW008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lupOdd = new DevExpress.XtraEditors.LookUpEdit();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupOdd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2,
            this.cmbType,
            this.cmbGrade});
            this.gridControl1.Size = new System.Drawing.Size(1237, 371);
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
            this.idx,
            this.EXW002,
            this.EXW003,
            this.EXW004,
            this.EXW005,
            this.EXW006,
            this.EXW007,
            this.EXW008});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEdit);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // EXW002
            // 
            this.EXW002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EXW002.AppearanceCell.Options.UseFont = true;
            this.EXW002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EXW002.AppearanceHeader.Options.UseFont = true;
            this.EXW002.Caption = "批次";
            this.EXW002.FieldName = "EXW002";
            this.EXW002.Name = "EXW002";
            this.EXW002.Visible = true;
            this.EXW002.VisibleIndex = 0;
            this.EXW002.Width = 60;
            // 
            // EXW003
            // 
            this.EXW003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EXW003.AppearanceCell.Options.UseFont = true;
            this.EXW003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EXW003.AppearanceHeader.Options.UseFont = true;
            this.EXW003.Caption = "木材类型";
            this.EXW003.ColumnEdit = this.cmbType;
            this.EXW003.FieldName = "EXW003";
            this.EXW003.Name = "EXW003";
            this.EXW003.Visible = true;
            this.EXW003.VisibleIndex = 1;
            this.EXW003.Width = 98;
            // 
            // cmbType
            // 
            this.cmbType.AutoHeight = false;
            this.cmbType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbType.Name = "cmbType";
            this.cmbType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // EXW004
            // 
            this.EXW004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EXW004.AppearanceCell.Options.UseFont = true;
            this.EXW004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EXW004.AppearanceHeader.Options.UseFont = true;
            this.EXW004.Caption = "厚度";
            this.EXW004.FieldName = "EXW004";
            this.EXW004.Name = "EXW004";
            this.EXW004.Visible = true;
            this.EXW004.VisibleIndex = 3;
            this.EXW004.Width = 70;
            // 
            // EXW005
            // 
            this.EXW005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EXW005.AppearanceCell.Options.UseFont = true;
            this.EXW005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EXW005.AppearanceHeader.Options.UseFont = true;
            this.EXW005.Caption = "木材等级";
            this.EXW005.ColumnEdit = this.cmbGrade;
            this.EXW005.FieldName = "EXW005";
            this.EXW005.Name = "EXW005";
            this.EXW005.Visible = true;
            this.EXW005.VisibleIndex = 2;
            this.EXW005.Width = 174;
            // 
            // cmbGrade
            // 
            this.cmbGrade.AutoHeight = false;
            this.cmbGrade.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbGrade.Name = "cmbGrade";
            // 
            // EXW006
            // 
            this.EXW006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EXW006.AppearanceCell.Options.UseFont = true;
            this.EXW006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EXW006.AppearanceHeader.Options.UseFont = true;
            this.EXW006.Caption = "木材立方";
            this.EXW006.FieldName = "EXW006";
            this.EXW006.Name = "EXW006";
            this.EXW006.Visible = true;
            this.EXW006.VisibleIndex = 4;
            this.EXW006.Width = 95;
            // 
            // EXW007
            // 
            this.EXW007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EXW007.AppearanceCell.Options.UseFont = true;
            this.EXW007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EXW007.AppearanceHeader.Options.UseFont = true;
            this.EXW007.Caption = "备注";
            this.EXW007.FieldName = "EXW007";
            this.EXW007.Name = "EXW007";
            this.EXW007.Visible = true;
            this.EXW007.VisibleIndex = 5;
            this.EXW007.Width = 455;
            // 
            // EXW008
            // 
            this.EXW008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EXW008.AppearanceCell.Options.UseFont = true;
            this.EXW008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EXW008.AppearanceHeader.Options.UseFont = true;
            this.EXW008.Caption = "时间";
            this.EXW008.ColumnEdit = this.repositoryItemDateEdit1;
            this.EXW008.FieldName = "EXW008";
            this.EXW008.Name = "EXW008";
            this.EXW008.Visible = true;
            this.EXW008.VisibleIndex = 6;
            this.EXW008.Width = 97;
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
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupOdd);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1237, 412);
            this.splitContainerControl1.SplitterPosition = 29;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // lupOdd
            // 
            this.lupOdd.Location = new System.Drawing.Point(60, 5);
            this.lupOdd.Name = "lupOdd";
            this.lupOdd.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lupOdd.Properties.Appearance.Options.UseFont = true;
            this.lupOdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupOdd.Properties.NullText = "";
            this.lupOdd.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupOdd.Properties.ShowHeader = false;
            this.lupOdd.Size = new System.Drawing.Size(156, 20);
            this.lupOdd.TabIndex = 1;
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
            this.wait.TabIndex = 34;
            this.wait.Text = "progressPanel1";
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "年月：";
            // 
            // FormExpendWood
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 438);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormExpendWood";
            this.Text = "每日木料耗用录入";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.wait, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lupOdd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn EXW002;
        private DevExpress . XtraGrid . Columns . GridColumn EXW003;
        private DevExpress . XtraGrid . Columns . GridColumn EXW004;
        private DevExpress . XtraGrid . Columns . GridColumn EXW005;
        private DevExpress . XtraGrid . Columns . GridColumn EXW006;
        private DevExpress . XtraGrid . Columns . GridColumn EXW007;
        private DevExpress . XtraGrid . Columns . GridColumn EXW008;
        private DevExpress . XtraEditors . Repository . RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraEditors . LookUpEdit lupOdd;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private System . ComponentModel . BackgroundWorker backgroundWorker2;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbType;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbGrade;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress . XtraEditors . LabelControl labelControl2;
    }
}