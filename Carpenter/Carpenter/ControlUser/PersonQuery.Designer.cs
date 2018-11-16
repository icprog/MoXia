namespace Carpenter . ControlUser
{
    partial class PersonQuery
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components . Dispose ( );
            }
            base . Dispose ( disposing );
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent ( )
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.EMP001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DEP002 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(422, 233);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.check,
            this.EMP001,
            this.EMP002,
            this.DEP002});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // check
            // 
            this.check.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.check.AppearanceHeader.Options.UseFont = true;
            this.check.Caption = "选择";
            this.check.ColumnEdit = this.repositoryItemCheckEdit1;
            this.check.FieldName = "check";
            this.check.Name = "check";
            this.check.OptionsColumn.AllowEdit = false;
            this.check.Visible = true;
            this.check.VisibleIndex = 0;
            this.check.Width = 22;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // EMP001
            // 
            this.EMP001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP001.AppearanceCell.Options.UseFont = true;
            this.EMP001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP001.AppearanceHeader.Options.UseFont = true;
            this.EMP001.Caption = "人员编号";
            this.EMP001.FieldName = "EMP001";
            this.EMP001.Name = "EMP001";
            this.EMP001.OptionsColumn.AllowEdit = false;
            this.EMP001.Visible = true;
            this.EMP001.VisibleIndex = 2;
            this.EMP001.Width = 329;
            // 
            // EMP002
            // 
            this.EMP002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP002.AppearanceCell.Options.UseFont = true;
            this.EMP002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP002.AppearanceHeader.Options.UseFont = true;
            this.EMP002.Caption = "人员姓名";
            this.EMP002.FieldName = "EMP002";
            this.EMP002.Name = "EMP002";
            this.EMP002.OptionsColumn.AllowEdit = false;
            this.EMP002.Visible = true;
            this.EMP002.VisibleIndex = 3;
            this.EMP002.Width = 350;
            // 
            // DEP002
            // 
            this.DEP002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.DEP002.AppearanceCell.Options.UseFont = true;
            this.DEP002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.DEP002.AppearanceHeader.Options.UseFont = true;
            this.DEP002.Caption = "部门";
            this.DEP002.FieldName = "DEP002";
            this.DEP002.Name = "DEP002";
            this.DEP002.Visible = true;
            this.DEP002.VisibleIndex = 1;
            this.DEP002.Width = 348;
            // 
            // PersonQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "PersonQuery";
            this.Size = new System.Drawing.Size(422, 233);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Columns . GridColumn EMP001;
        private DevExpress . XtraGrid . Columns . GridColumn EMP002;
        private DevExpress . XtraGrid . Columns . GridColumn check;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit1;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn DEP002;
    }
}
