namespace Carpenter . ControlUser
{
    partial class AssembleWorkOrder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AWQ009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWO002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemCheckEdit2});
            this.gridControl1.Size = new System.Drawing.Size(412, 296);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.ColumnPanelRowHeight = 45;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AWQ009,
            this.AWQ010,
            this.AWQ006,
            this.AWQ007,
            this.AWO002});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 25;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // AWQ009
            // 
            this.AWQ009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ009.AppearanceCell.Options.UseFont = true;
            this.AWQ009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ009.AppearanceHeader.Options.UseFont = true;
            this.AWQ009.AppearanceHeader.Options.UseTextOptions = true;
            this.AWQ009.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AWQ009.Caption = "人员编号";
            this.AWQ009.FieldName = "AWQ009";
            this.AWQ009.Name = "AWQ009";
            this.AWQ009.OptionsColumn.AllowEdit = false;
            this.AWQ009.Visible = true;
            this.AWQ009.VisibleIndex = 0;
            this.AWQ009.Width = 64;
            // 
            // AWQ010
            // 
            this.AWQ010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ010.AppearanceCell.Options.UseFont = true;
            this.AWQ010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ010.AppearanceHeader.Options.UseFont = true;
            this.AWQ010.AppearanceHeader.Options.UseTextOptions = true;
            this.AWQ010.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AWQ010.Caption = "人员姓名";
            this.AWQ010.FieldName = "AWQ010";
            this.AWQ010.Name = "AWQ010";
            this.AWQ010.OptionsColumn.AllowEdit = false;
            this.AWQ010.Visible = true;
            this.AWQ010.VisibleIndex = 1;
            this.AWQ010.Width = 74;
            // 
            // AWQ006
            // 
            this.AWQ006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ006.AppearanceCell.Options.UseFont = true;
            this.AWQ006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ006.AppearanceHeader.Options.UseFont = true;
            this.AWQ006.AppearanceHeader.Options.UseTextOptions = true;
            this.AWQ006.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AWQ006.Caption = "数量";
            this.AWQ006.FieldName = "AWQ006";
            this.AWQ006.Name = "AWQ006";
            this.AWQ006.Visible = true;
            this.AWQ006.VisibleIndex = 2;
            this.AWQ006.Width = 54;
            // 
            // AWQ007
            // 
            this.AWQ007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ007.AppearanceCell.Options.UseFont = true;
            this.AWQ007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ007.AppearanceHeader.Options.UseFont = true;
            this.AWQ007.AppearanceHeader.Options.UseTextOptions = true;
            this.AWQ007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AWQ007.Caption = "单价";
            this.AWQ007.FieldName = "AWQ007";
            this.AWQ007.Name = "AWQ007";
            this.AWQ007.Visible = true;
            this.AWQ007.VisibleIndex = 3;
            this.AWQ007.Width = 56;
            // 
            // AWO002
            // 
            this.AWO002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWO002.AppearanceCell.Options.UseFont = true;
            this.AWO002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWO002.AppearanceHeader.Options.UseFont = true;
            this.AWO002.AppearanceHeader.Options.UseTextOptions = true;
            this.AWO002.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AWO002.Caption = "日期";
            this.AWO002.FieldName = "AWO002";
            this.AWO002.Name = "AWO002";
            this.AWO002.Visible = true;
            this.AWO002.VisibleIndex = 4;
            this.AWO002.Width = 117;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "完工",
            "未完工"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // AssembleWorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "AssembleWorkOrder";
            this.Size = new System.Drawing.Size(412, 296);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ009;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ010;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ006;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ007;
        private DevExpress . XtraGrid . Columns . GridColumn AWO002;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit2;
        public DevExpress . XtraGrid . GridControl gridControl1;
    }
}
