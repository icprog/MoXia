namespace Carpenter.ControlUser
{
    partial class PlanCutProduct
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnCanAll = new System.Windows.Forms.Button();
            this.bthAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSure = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.OPI001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnCanAll);
            this.splitContainer1.Panel1.Controls.Add(this.bthAll);
            this.splitContainer1.Panel1.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel1.Controls.Add(this.btnSure);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(658, 347);
            this.splitContainer1.SplitterDistance = 43;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnCanAll
            // 
            this.btnCanAll.AutoSize = true;
            this.btnCanAll.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCanAll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCanAll.Location = new System.Drawing.Point(251, 8);
            this.btnCanAll.Name = "btnCanAll";
            this.btnCanAll.Size = new System.Drawing.Size(82, 26);
            this.btnCanAll.TabIndex = 36;
            this.btnCanAll.Text = "取消全选";
            this.btnCanAll.UseVisualStyleBackColor = false;
            this.btnCanAll.Click += new System.EventHandler(this.btnCanAll_Click);
            // 
            // bthAll
            // 
            this.bthAll.AutoSize = true;
            this.bthAll.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.bthAll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bthAll.Location = new System.Drawing.Point(170, 8);
            this.bthAll.Name = "bthAll";
            this.bthAll.Size = new System.Drawing.Size(75, 26);
            this.bthAll.TabIndex = 35;
            this.bthAll.Text = "全选";
            this.bthAll.UseVisualStyleBackColor = false;
            this.bthAll.Click += new System.EventHandler(this.bthAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(89, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSure
            // 
            this.btnSure.AutoSize = true;
            this.btnSure.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSure.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSure.Location = new System.Drawing.Point(8, 8);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 26);
            this.btnSure.TabIndex = 33;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = false;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridControl1.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckedComboBoxEdit1,
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(658, 300);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idx,
            this.check,
            this.OPI001,
            this.OPI002,
            this.OPI003,
            this.OPI004,
            this.OPI005,
            this.OPI006,
            this.OPI007});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // check
            // 
            this.check.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.check.AppearanceCell.Options.UseFont = true;
            this.check.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.check.AppearanceHeader.Options.UseFont = true;
            this.check.Caption = "选择";
            this.check.ColumnEdit = this.repositoryItemCheckEdit1;
            this.check.FieldName = "check";
            this.check.Name = "check";
            this.check.Visible = true;
            this.check.VisibleIndex = 0;
            this.check.Width = 37;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // OPI001
            // 
            this.OPI001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI001.AppearanceCell.Options.UseFont = true;
            this.OPI001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI001.AppearanceHeader.Options.UseFont = true;
            this.OPI001.Caption = "品号";
            this.OPI001.FieldName = "OPI001";
            this.OPI001.Name = "OPI001";
            this.OPI001.Visible = true;
            this.OPI001.VisibleIndex = 1;
            this.OPI001.Width = 136;
            // 
            // OPI002
            // 
            this.OPI002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI002.AppearanceCell.Options.UseFont = true;
            this.OPI002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI002.AppearanceHeader.Options.UseFont = true;
            this.OPI002.Caption = "产品名称";
            this.OPI002.FieldName = "OPI002";
            this.OPI002.Name = "OPI002";
            this.OPI002.Visible = true;
            this.OPI002.VisibleIndex = 2;
            this.OPI002.Width = 183;
            // 
            // OPI003
            // 
            this.OPI003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI003.AppearanceCell.Options.UseFont = true;
            this.OPI003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI003.AppearanceHeader.Options.UseFont = true;
            this.OPI003.Caption = "产品类别";
            this.OPI003.FieldName = "OPI003";
            this.OPI003.Name = "OPI003";
            this.OPI003.Visible = true;
            this.OPI003.VisibleIndex = 3;
            this.OPI003.Width = 130;
            // 
            // OPI004
            // 
            this.OPI004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI004.AppearanceCell.Options.UseFont = true;
            this.OPI004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI004.AppearanceHeader.Options.UseFont = true;
            this.OPI004.Caption = "产值";
            this.OPI004.DisplayFormat.FormatString = "0.####";
            this.OPI004.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.OPI004.FieldName = "OPI004";
            this.OPI004.Name = "OPI004";
            this.OPI004.Visible = true;
            this.OPI004.VisibleIndex = 4;
            this.OPI004.Width = 130;
            // 
            // OPI005
            // 
            this.OPI005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI005.AppearanceCell.Options.UseFont = true;
            this.OPI005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI005.AppearanceHeader.Options.UseFont = true;
            this.OPI005.Caption = "规格";
            this.OPI005.FieldName = "OPI005";
            this.OPI005.Name = "OPI005";
            this.OPI005.Visible = true;
            this.OPI005.VisibleIndex = 5;
            this.OPI005.Width = 156;
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
            this.OPI006.VisibleIndex = 7;
            this.OPI006.Width = 127;
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
            this.OPI007.VisibleIndex = 8;
            this.OPI007.Width = 150;
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            this.repositoryItemCheckedComboBoxEdit1.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            // 
            // PlanCutProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "PlanCutProduct";
            this.Size = new System.Drawing.Size(658, 347);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn OPI001;
        private DevExpress . XtraGrid . Columns . GridColumn OPI002;
        private DevExpress . XtraGrid . Columns . GridColumn OPI003;
        private DevExpress . XtraGrid . Columns . GridColumn OPI004;
        private DevExpress . XtraGrid . Columns . GridColumn OPI005;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn check;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
        private System . Windows . Forms . Button btnCanAll;
        private System . Windows . Forms . Button bthAll;
        public System . Windows . Forms . SplitContainer splitContainer1;
        public System . Windows . Forms . Button btnCancel;
        public System . Windows . Forms . Button btnSure;
    }
}
