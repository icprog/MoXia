namespace Carpenter . Query
{
    partial class FormWorkOrder
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
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.USERS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAS001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAS002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAS003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.EMP001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DEP002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.splitContainerControl1.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(715, 432);
            this.splitContainerControl1.SplitterPosition = 211;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.btnOk);
            this.splitContainerControl2.Panel1.Controls.Add(this.btnCancel);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.gridControl2);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(715, 211);
            this.splitContainerControl2.SplitterPosition = 35;
            this.splitContainerControl2.TabIndex = 36;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(12, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(67, 26);
            this.btnOk.TabIndex = 34;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(97, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 26);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.gridControl2.Size = new System.Drawing.Size(715, 164);
            this.gridControl2.TabIndex = 5;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView2.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DT,
            this.USERS,
            this.PAS001,
            this.PAS002,
            this.PAS003,
            this.AWQ006});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.IndicatorWidth = 45;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView2_RowClick);
            this.gridView2.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView2_CustomDrawRowIndicator);
            // 
            // DT
            // 
            this.DT.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.DT.AppearanceCell.Options.UseFont = true;
            this.DT.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.DT.AppearanceHeader.Options.UseFont = true;
            this.DT.Caption = "派工时间";
            this.DT.FieldName = "DT";
            this.DT.Name = "DT";
            this.DT.Visible = true;
            this.DT.VisibleIndex = 0;
            this.DT.Width = 121;
            // 
            // USERS
            // 
            this.USERS.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.USERS.AppearanceCell.Options.UseFont = true;
            this.USERS.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.USERS.AppearanceHeader.Options.UseFont = true;
            this.USERS.Caption = "经办人";
            this.USERS.FieldName = "USERS";
            this.USERS.Name = "USERS";
            this.USERS.OptionsColumn.AllowEdit = false;
            this.USERS.Visible = true;
            this.USERS.VisibleIndex = 1;
            this.USERS.Width = 103;
            // 
            // PAS001
            // 
            this.PAS001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS001.AppearanceCell.Options.UseFont = true;
            this.PAS001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS001.AppearanceHeader.Options.UseFont = true;
            this.PAS001.Caption = "批号";
            this.PAS001.FieldName = "PAS001";
            this.PAS001.Name = "PAS001";
            this.PAS001.OptionsColumn.AllowEdit = false;
            this.PAS001.Visible = true;
            this.PAS001.VisibleIndex = 2;
            this.PAS001.Width = 121;
            // 
            // PAS002
            // 
            this.PAS002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS002.AppearanceCell.Options.UseFont = true;
            this.PAS002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS002.AppearanceHeader.Options.UseFont = true;
            this.PAS002.Caption = "品号";
            this.PAS002.FieldName = "PAS002";
            this.PAS002.Name = "PAS002";
            this.PAS002.OptionsColumn.AllowEdit = false;
            this.PAS002.Visible = true;
            this.PAS002.VisibleIndex = 3;
            this.PAS002.Width = 114;
            // 
            // PAS003
            // 
            this.PAS003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS003.AppearanceCell.Options.UseFont = true;
            this.PAS003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS003.AppearanceHeader.Options.UseFont = true;
            this.PAS003.Caption = "品名";
            this.PAS003.FieldName = "PAS003";
            this.PAS003.Name = "PAS003";
            this.PAS003.OptionsColumn.AllowEdit = false;
            this.PAS003.Visible = true;
            this.PAS003.VisibleIndex = 4;
            this.PAS003.Width = 123;
            // 
            // AWQ006
            // 
            this.AWQ006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ006.AppearanceCell.Options.UseFont = true;
            this.AWQ006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ006.AppearanceHeader.Options.UseFont = true;
            this.AWQ006.Caption = "剩余数量";
            this.AWQ006.FieldName = "AWQ006";
            this.AWQ006.Name = "AWQ006";
            this.AWQ006.OptionsColumn.AllowEdit = false;
            this.AWQ006.Visible = true;
            this.AWQ006.VisibleIndex = 5;
            this.AWQ006.Width = 86;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(715, 209);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.EMP001,
            this.EMP002,
            this.DEP002,
            this.Num});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
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
            this.EMP001.VisibleIndex = 0;
            this.EMP001.Width = 313;
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
            this.EMP002.VisibleIndex = 1;
            this.EMP002.Width = 272;
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
            this.DEP002.VisibleIndex = 2;
            this.DEP002.Width = 228;
            // 
            // Num
            // 
            this.Num.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Num.AppearanceCell.Options.UseFont = true;
            this.Num.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Num.AppearanceHeader.Options.UseFont = true;
            this.Num.Caption = "派工数量";
            this.Num.FieldName = "Num";
            this.Num.Name = "Num";
            this.Num.Visible = true;
            this.Num.VisibleIndex = 3;
            this.Num.Width = 236;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // FormWorkOrder
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 432);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormWorkOrder";
            this.Text = "组装派工单";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private System . Windows . Forms . Button btnCancel;
        private System . Windows . Forms . Button btnOk;
        private DevExpress . XtraGrid . GridControl gridControl1;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress . XtraGrid . Columns . GridColumn EMP001;
        private DevExpress . XtraGrid . Columns . GridColumn EMP002;
        private DevExpress . XtraGrid . Columns . GridColumn Num;
        private DevExpress . XtraGrid . Columns . GridColumn DEP002;
        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl2;
        private DevExpress . XtraGrid . GridControl gridControl2;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView2;
        private DevExpress . XtraGrid . Columns . GridColumn DT;
        private DevExpress . XtraGrid . Columns . GridColumn USERS;
        private DevExpress . XtraGrid . Columns . GridColumn PAS002;
        private DevExpress . XtraGrid . Columns . GridColumn PAS001;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress . XtraGrid . Columns . GridColumn PAS003;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ006;
    }
}