namespace Carpenter
{
    partial class FormExpendPaint
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
            this.lupOdd = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WXP002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.EPP005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WXP003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WXP004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WXP005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WXP006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.lupPaintName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cmbGrade = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupOdd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupOdd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPaintName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.lupOdd);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1237, 412);
            this.splitContainerControl1.SplitterPosition = 39;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // lupOdd
            // 
            this.lupOdd.EditValue = null;
            this.lupOdd.Location = new System.Drawing.Point(66, 9);
            this.lupOdd.MenuManager = this.barManager1;
            this.lupOdd.Name = "lupOdd";
            this.lupOdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupOdd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupOdd.Properties.DisplayFormat.FormatString = "yyyyMM";
            this.lupOdd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.lupOdd.Properties.EditFormat.FormatString = "yyyyMM";
            this.lupOdd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.lupOdd.Properties.Mask.EditMask = "yyyyMM";
            this.lupOdd.Size = new System.Drawing.Size(133, 20);
            this.lupOdd.TabIndex = 5;
            this.lupOdd.EditValueChanged += new System.EventHandler(this.lupOdd_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(18, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "年月：";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.lupPaintName,
            this.repositoryItemLookUpEdit2,
            this.cmbType,
            this.cmbGrade,
            this.LookUpEdit});
            this.gridControl1.Size = new System.Drawing.Size(1237, 361);
            this.gridControl1.TabIndex = 5;
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
            this.WXP002,
            this.WXP003,
            this.WXP004,
            this.WXP005,
            this.WXP006});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // WXP002
            // 
            this.WXP002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WXP002.AppearanceCell.Options.UseFont = true;
            this.WXP002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WXP002.AppearanceHeader.Options.UseFont = true;
            this.WXP002.Caption = "物料名称";
            this.WXP002.ColumnEdit = this.LookUpEdit;
            this.WXP002.FieldName = "WXP002";
            this.WXP002.Name = "WXP002";
            this.WXP002.Visible = true;
            this.WXP002.VisibleIndex = 0;
            this.WXP002.Width = 255;
            // 
            // LookUpEdit
            // 
            this.LookUpEdit.AutoHeight = false;
            this.LookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.LookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEdit.ImmediatePopup = true;
            this.LookUpEdit.Name = "LookUpEdit";
            this.LookUpEdit.NullText = "";
            this.LookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.LookUpEdit.View = this.View;
            // 
            // View
            // 
            this.View.Appearance.FocusedRow.BackColor = System.Drawing.Color.Green;
            this.View.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Green;
            this.View.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Green;
            this.View.Appearance.FocusedRow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.View.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.View.Appearance.FocusedRow.Options.UseFont = true;
            this.View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.EPP005});
            this.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.View.Name = "View";
            this.View.OptionsBehavior.Editable = false;
            this.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.View.OptionsView.ShowGroupPanel = false;
            // 
            // EPP005
            // 
            this.EPP005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EPP005.AppearanceCell.Options.UseFont = true;
            this.EPP005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EPP005.AppearanceHeader.Options.UseFont = true;
            this.EPP005.Caption = "物料名称";
            this.EPP005.FieldName = "EPP005";
            this.EPP005.Name = "EPP005";
            this.EPP005.Visible = true;
            this.EPP005.VisibleIndex = 0;
            // 
            // WXP003
            // 
            this.WXP003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WXP003.AppearanceCell.Options.UseFont = true;
            this.WXP003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WXP003.AppearanceHeader.Options.UseFont = true;
            this.WXP003.Caption = "规格型号";
            this.WXP003.FieldName = "WXP003";
            this.WXP003.Name = "WXP003";
            this.WXP003.Visible = true;
            this.WXP003.VisibleIndex = 1;
            this.WXP003.Width = 228;
            // 
            // WXP004
            // 
            this.WXP004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WXP004.AppearanceCell.Options.UseFont = true;
            this.WXP004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WXP004.AppearanceHeader.Options.UseFont = true;
            this.WXP004.Caption = "单位";
            this.WXP004.FieldName = "WXP004";
            this.WXP004.Name = "WXP004";
            this.WXP004.Visible = true;
            this.WXP004.VisibleIndex = 3;
            this.WXP004.Width = 100;
            // 
            // WXP005
            // 
            this.WXP005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WXP005.AppearanceCell.Options.UseFont = true;
            this.WXP005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WXP005.AppearanceHeader.Options.UseFont = true;
            this.WXP005.Caption = "数量";
            this.WXP005.FieldName = "WXP005";
            this.WXP005.Name = "WXP005";
            this.WXP005.Visible = true;
            this.WXP005.VisibleIndex = 4;
            this.WXP005.Width = 257;
            // 
            // WXP006
            // 
            this.WXP006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WXP006.AppearanceCell.Options.UseFont = true;
            this.WXP006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WXP006.AppearanceHeader.Options.UseFont = true;
            this.WXP006.Caption = "单价";
            this.WXP006.FieldName = "WXP006";
            this.WXP006.Name = "WXP006";
            this.WXP006.Visible = true;
            this.WXP006.VisibleIndex = 2;
            this.WXP006.Width = 209;
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
            // lupPaintName
            // 
            this.lupPaintName.AutoHeight = false;
            this.lupPaintName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPaintName.Name = "lupPaintName";
            this.lupPaintName.NullText = "";
            this.lupPaintName.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupPaintName.ShowHeader = false;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
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
            this.wait.TabIndex = 35;
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
            // FormExpendPaint
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 438);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormExpendPaint";
            this.Text = "每日油漆耗用录入";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.wait, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lupOdd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupOdd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPaintName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGrade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn WXP002;
        private DevExpress . XtraGrid . Columns . GridColumn WXP003;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbType;
        private DevExpress . XtraGrid . Columns . GridColumn WXP004;
        private DevExpress . XtraGrid . Columns . GridColumn WXP005;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbGrade;
        private DevExpress . XtraEditors . Repository . RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit lupPaintName;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private System . ComponentModel . BackgroundWorker backgroundWorker2;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . Repository . RepositoryItemGridLookUpEdit LookUpEdit;
        private DevExpress . XtraGrid . Views . Grid . GridView View;
        private DevExpress . XtraGrid . Columns . GridColumn EPP005;
        private DevExpress . XtraGrid . Columns . GridColumn WXP006;
        private DevExpress . XtraEditors . DateEdit lupOdd;
    }
}