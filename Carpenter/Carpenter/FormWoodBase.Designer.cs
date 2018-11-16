namespace Carpenter
{
    partial class FormWoodBase
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
            this.lupWood = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WOB001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.secProduct = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.WOB001_1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WOB002_1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WOB003_1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WOB002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WOB003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WOB004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.WOB005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WOB006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.lupWoodColor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbGrade = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.lupProduct = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lupPartNum = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupWood.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupWoodColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPartNum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupPartNum);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupWood);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1237, 412);
            this.splitContainerControl1.SplitterPosition = 32;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "木材：";
            // 
            // lupWood
            // 
            this.lupWood.Location = new System.Drawing.Point(60, 5);
            this.lupWood.Name = "lupWood";
            this.lupWood.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupWood.Properties.Appearance.Options.UseFont = true;
            this.lupWood.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupWood.Properties.NullText = "";
            this.lupWood.Properties.ShowHeader = false;
            this.lupWood.Size = new System.Drawing.Size(194, 20);
            this.lupWood.TabIndex = 3;
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
            this.lupProduct,
            this.secProduct});
            this.gridControl1.Size = new System.Drawing.Size(1237, 368);
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
            this.WOB001,
            this.WOB002,
            this.WOB003,
            this.WOB004,
            this.WOB005,
            this.WOB006});
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
            // WOB001
            // 
            this.WOB001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB001.AppearanceCell.Options.UseFont = true;
            this.WOB001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB001.AppearanceHeader.Options.UseFont = true;
            this.WOB001.Caption = "品号";
            this.WOB001.ColumnEdit = this.secProduct;
            this.WOB001.FieldName = "WOB001";
            this.WOB001.Name = "WOB001";
            this.WOB001.Visible = true;
            this.WOB001.VisibleIndex = 0;
            this.WOB001.Width = 185;
            // 
            // secProduct
            // 
            this.secProduct.AutoHeight = false;
            this.secProduct.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.secProduct.Name = "secProduct";
            this.secProduct.NullText = "";
            this.secProduct.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.secProduct.ShowFooter = false;
            this.secProduct.View = this.repositoryItemSearchLookUpEdit1View;
            this.secProduct.EditValueChanged += new System.EventHandler(this.secProduct_EditValueChanged);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.WOB001_1,
            this.WOB002_1,
            this.WOB003_1});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsBehavior.Editable = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // WOB001_1
            // 
            this.WOB001_1.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WOB001_1.AppearanceCell.Options.UseFont = true;
            this.WOB001_1.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB001_1.AppearanceHeader.Options.UseFont = true;
            this.WOB001_1.Caption = "品号";
            this.WOB001_1.FieldName = "WOB001";
            this.WOB001_1.Name = "WOB001_1";
            this.WOB001_1.Visible = true;
            this.WOB001_1.VisibleIndex = 0;
            // 
            // WOB002_1
            // 
            this.WOB002_1.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB002_1.AppearanceCell.Options.UseFont = true;
            this.WOB002_1.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB002_1.AppearanceHeader.Options.UseFont = true;
            this.WOB002_1.Caption = "品名";
            this.WOB002_1.FieldName = "WOB002";
            this.WOB002_1.Name = "WOB002_1";
            this.WOB002_1.Visible = true;
            this.WOB002_1.VisibleIndex = 1;
            // 
            // WOB003_1
            // 
            this.WOB003_1.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB003_1.AppearanceCell.Options.UseFont = true;
            this.WOB003_1.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB003_1.AppearanceHeader.Options.UseFont = true;
            this.WOB003_1.Caption = "产品类别";
            this.WOB003_1.FieldName = "WOB003";
            this.WOB003_1.Name = "WOB003_1";
            this.WOB003_1.Visible = true;
            this.WOB003_1.VisibleIndex = 2;
            // 
            // WOB002
            // 
            this.WOB002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB002.AppearanceCell.Options.UseFont = true;
            this.WOB002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB002.AppearanceHeader.Options.UseFont = true;
            this.WOB002.Caption = "产品名称";
            this.WOB002.FieldName = "WOB002";
            this.WOB002.Name = "WOB002";
            this.WOB002.OptionsColumn.AllowEdit = false;
            this.WOB002.Visible = true;
            this.WOB002.VisibleIndex = 1;
            this.WOB002.Width = 185;
            // 
            // WOB003
            // 
            this.WOB003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB003.AppearanceCell.Options.UseFont = true;
            this.WOB003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB003.AppearanceHeader.Options.UseFont = true;
            this.WOB003.Caption = "木材";
            this.WOB003.FieldName = "WOB003";
            this.WOB003.Name = "WOB003";
            this.WOB003.OptionsColumn.AllowEdit = false;
            this.WOB003.Visible = true;
            this.WOB003.VisibleIndex = 2;
            this.WOB003.Width = 84;
            // 
            // WOB004
            // 
            this.WOB004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB004.AppearanceCell.Options.UseFont = true;
            this.WOB004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB004.AppearanceHeader.Options.UseFont = true;
            this.WOB004.Caption = "类别";
            this.WOB004.ColumnEdit = this.cmbType;
            this.WOB004.FieldName = "WOB004";
            this.WOB004.Name = "WOB004";
            this.WOB004.Visible = true;
            this.WOB004.VisibleIndex = 3;
            this.WOB004.Width = 171;
            // 
            // cmbType
            // 
            this.cmbType.AutoHeight = false;
            this.cmbType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbType.Items.AddRange(new object[] {
            ""});
            this.cmbType.Name = "cmbType";
            // 
            // WOB005
            // 
            this.WOB005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB005.AppearanceCell.Options.UseFont = true;
            this.WOB005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB005.AppearanceHeader.Options.UseFont = true;
            this.WOB005.Caption = "用量";
            this.WOB005.FieldName = "WOB005";
            this.WOB005.Name = "WOB005";
            this.WOB005.Visible = true;
            this.WOB005.VisibleIndex = 4;
            this.WOB005.Width = 82;
            // 
            // WOB006
            // 
            this.WOB006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB006.AppearanceCell.Options.UseFont = true;
            this.WOB006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WOB006.AppearanceHeader.Options.UseFont = true;
            this.WOB006.Caption = "备注";
            this.WOB006.FieldName = "WOB006";
            this.WOB006.Name = "WOB006";
            this.WOB006.Visible = true;
            this.WOB006.VisibleIndex = 5;
            this.WOB006.Width = 342;
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
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WOB002", 300, "品名"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WOB003", 100, "木材")});
            this.lupProduct.Name = "lupProduct";
            this.lupProduct.NullText = "";
            this.lupProduct.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupProduct.PopupWidth = 600;
            this.lupProduct.EditValueChanged += new System.EventHandler(this.lupProduct_EditValueChanged);
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
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(290, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "批号：";
            // 
            // lupPartNum
            // 
            this.lupPartNum.Location = new System.Drawing.Point(338, 5);
            this.lupPartNum.Name = "lupPartNum";
            this.lupPartNum.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupPartNum.Properties.Appearance.Options.UseFont = true;
            this.lupPartNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPartNum.Properties.NullText = "";
            this.lupPartNum.Properties.ShowHeader = false;
            this.lupPartNum.Size = new System.Drawing.Size(112, 20);
            this.lupPartNum.TabIndex = 5;
            // 
            // FormWoodBase
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 438);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormWoodBase";
            this.Text = "木材理论耗用";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.wait, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lupWood.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupWoodColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPartNum.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn WOB001;
        private DevExpress . XtraGrid . Columns . GridColumn WOB002;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbType;
        private DevExpress . XtraGrid . Columns . GridColumn WOB003;
        private DevExpress . XtraGrid . Columns . GridColumn WOB004;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbGrade;
        private DevExpress . XtraGrid . Columns . GridColumn WOB005;
        private DevExpress . XtraGrid . Columns . GridColumn WOB006;
        private DevExpress . XtraEditors . Repository . RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit lupWoodColor;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit lupProduct;
        private DevExpress . XtraEditors . LookUpEdit lupWood;
        private DevExpress . XtraEditors . Repository . RepositoryItemSearchLookUpEdit secProduct;
        private DevExpress . XtraGrid . Views . Grid . GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress . XtraGrid . Columns . GridColumn WOB001_1;
        private DevExpress . XtraGrid . Columns . GridColumn WOB002_1;
        private DevExpress . XtraGrid . Columns . GridColumn WOB003_1;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LookUpEdit lupPartNum;
    }
}