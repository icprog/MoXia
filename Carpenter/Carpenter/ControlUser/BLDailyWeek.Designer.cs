namespace Carpenter . ControlUser
{
    partial class BLDailyWeek
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PLT001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST028 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDK007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDK012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel1.Controls.Add(this.btnOk);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1058, 409);
            this.splitContainer1.SplitterDistance = 37;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(320, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 26);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(244, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 26);
            this.btnOk.TabIndex = 36;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(87, 7);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 23);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "报工时间：";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1058, 369);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.ColumnPanelRowHeight = 35;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PLT001,
            this.PST001,
            this.PST002,
            this.PST003,
            this.PST004,
            this.OPI006,
            this.OPI007,
            this.PST028,
            this.PST005,
            this.PDK007,
            this.DL,
            this.PDK012});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PLT001
            // 
            this.PLT001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT001.AppearanceCell.Options.UseFont = true;
            this.PLT001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLT001.AppearanceHeader.Options.UseFont = true;
            this.PLT001.AppearanceHeader.Options.UseTextOptions = true;
            this.PLT001.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PLT001.Caption = "周计划单号";
            this.PLT001.FieldName = "PLT001";
            this.PLT001.Name = "PLT001";
            this.PLT001.Visible = true;
            this.PLT001.VisibleIndex = 0;
            this.PLT001.Width = 78;
            // 
            // PST001
            // 
            this.PST001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PST001.AppearanceCell.Options.UseFont = true;
            this.PST001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PST001.AppearanceHeader.Options.UseFont = true;
            this.PST001.AppearanceHeader.Options.UseTextOptions = true;
            this.PST001.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PST001.Caption = "生产批号";
            this.PST001.FieldName = "PST001";
            this.PST001.Name = "PST001";
            this.PST001.OptionsColumn.AllowEdit = false;
            this.PST001.Visible = true;
            this.PST001.VisibleIndex = 1;
            this.PST001.Width = 60;
            // 
            // PST002
            // 
            this.PST002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PST002.AppearanceCell.Options.UseFont = true;
            this.PST002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PST002.AppearanceHeader.Options.UseFont = true;
            this.PST002.AppearanceHeader.Options.UseTextOptions = true;
            this.PST002.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PST002.Caption = "产品品号";
            this.PST002.FieldName = "PST002";
            this.PST002.Name = "PST002";
            this.PST002.OptionsColumn.AllowEdit = false;
            this.PST002.Visible = true;
            this.PST002.VisibleIndex = 2;
            this.PST002.Width = 116;
            // 
            // PST003
            // 
            this.PST003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PST003.AppearanceCell.Options.UseFont = true;
            this.PST003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PST003.AppearanceHeader.Options.UseFont = true;
            this.PST003.AppearanceHeader.Options.UseTextOptions = true;
            this.PST003.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PST003.Caption = "产品名称";
            this.PST003.FieldName = "PST003";
            this.PST003.Name = "PST003";
            this.PST003.OptionsColumn.AllowEdit = false;
            this.PST003.Visible = true;
            this.PST003.VisibleIndex = 3;
            this.PST003.Width = 143;
            // 
            // PST004
            // 
            this.PST004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PST004.AppearanceCell.Options.UseFont = true;
            this.PST004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PST004.AppearanceHeader.Options.UseFont = true;
            this.PST004.Caption = "规格";
            this.PST004.FieldName = "PST004";
            this.PST004.Name = "PST004";
            this.PST004.OptionsColumn.AllowEdit = false;
            this.PST004.Visible = true;
            this.PST004.VisibleIndex = 4;
            this.PST004.Width = 88;
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
            this.OPI006.OptionsColumn.AllowEdit = false;
            this.OPI006.Visible = true;
            this.OPI006.VisibleIndex = 5;
            this.OPI006.Width = 82;
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
            this.OPI007.OptionsColumn.AllowEdit = false;
            this.OPI007.Visible = true;
            this.OPI007.VisibleIndex = 6;
            this.OPI007.Width = 61;
            // 
            // PST028
            // 
            this.PST028.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PST028.AppearanceCell.Options.UseFont = true;
            this.PST028.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PST028.AppearanceHeader.Options.UseFont = true;
            this.PST028.AppearanceHeader.Options.UseTextOptions = true;
            this.PST028.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PST028.Caption = "生产数量";
            this.PST028.FieldName = "PST028";
            this.PST028.Name = "PST028";
            this.PST028.OptionsColumn.AllowEdit = false;
            this.PST028.Visible = true;
            this.PST028.VisibleIndex = 7;
            this.PST028.Width = 61;
            // 
            // PST005
            // 
            this.PST005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PST005.AppearanceCell.Options.UseFont = true;
            this.PST005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PST005.AppearanceHeader.Options.UseFont = true;
            this.PST005.AppearanceHeader.Options.UseTextOptions = true;
            this.PST005.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PST005.Caption = "下料计划完成时间";
            this.PST005.FieldName = "PST005";
            this.PST005.Name = "PST005";
            this.PST005.OptionsColumn.AllowEdit = false;
            this.PST005.Visible = true;
            this.PST005.VisibleIndex = 8;
            this.PST005.Width = 114;
            // 
            // PDK007
            // 
            this.PDK007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDK007.AppearanceCell.Options.UseFont = true;
            this.PDK007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDK007.AppearanceHeader.Options.UseFont = true;
            this.PDK007.AppearanceHeader.Options.UseTextOptions = true;
            this.PDK007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PDK007.Caption = "累计报工数量";
            this.PDK007.FieldName = "PDK007";
            this.PDK007.Name = "PDK007";
            this.PDK007.OptionsColumn.AllowEdit = false;
            this.PDK007.Visible = true;
            this.PDK007.VisibleIndex = 9;
            this.PDK007.Width = 117;
            // 
            // DL
            // 
            this.DL.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.DL.AppearanceCell.Options.UseFont = true;
            this.DL.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.DL.AppearanceHeader.Options.UseFont = true;
            this.DL.AppearanceHeader.Options.UseTextOptions = true;
            this.DL.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.DL.Caption = "报工数量";
            this.DL.FieldName = "DL";
            this.DL.Name = "DL";
            this.DL.Visible = true;
            this.DL.VisibleIndex = 10;
            this.DL.Width = 129;
            // 
            // PDK012
            // 
            this.PDK012.Caption = "报工时间";
            this.PDK012.FieldName = "PDK012";
            this.PDK012.Name = "PDK012";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // BLDailyWeek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "BLDailyWeek";
            this.Size = new System.Drawing.Size(1058, 409);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System . Windows . Forms . SplitContainer splitContainer1;
        public System . Windows . Forms . Button btnCancel;
        public System . Windows . Forms . Button btnOk;
        private System . Windows . Forms . DateTimePicker dateTimePicker1;
        private System . Windows . Forms . Label label1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PST001;
        private DevExpress . XtraGrid . Columns . GridColumn PST002;
        private DevExpress . XtraGrid . Columns . GridColumn PST003;
        private DevExpress . XtraGrid . Columns . GridColumn PST004;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn PST028;
        private DevExpress . XtraGrid . Columns . GridColumn PST005;
        private DevExpress . XtraGrid . Columns . GridColumn PDK007;
        private DevExpress . XtraGrid . Columns . GridColumn DL;
        private DevExpress . XtraGrid . Columns . GridColumn PDK012;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress . XtraGrid . Columns . GridColumn PLT001;
    }
}
