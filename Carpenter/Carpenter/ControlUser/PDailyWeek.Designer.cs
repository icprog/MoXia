namespace Carpenter . ControlUser
{
    partial class PDailyWeek
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PDP001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDP002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDP003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDP004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDP025 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWI012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.PWH001 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.btnCancel);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnOk);
            this.splitContainerControl1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainerControl1.Panel1.Controls.Add(this.label1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1253, 523);
            this.splitContainerControl1.SplitterPosition = 41;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(328, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 26);
            this.btnCancel.TabIndex = 49;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(252, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 26);
            this.btnOk.TabIndex = 48;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(95, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 22);
            this.dateTimePicker1.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 46;
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
            this.gridControl1.Size = new System.Drawing.Size(1253, 470);
            this.gridControl1.TabIndex = 6;
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
            this.PWH001,
            this.PDP001,
            this.PDP002,
            this.PDP003,
            this.PDP004,
            this.OPI006,
            this.OPI007,
            this.PDP025,
            this.PWI007,
            this.DL,
            this.PWI012});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PDP001
            // 
            this.PDP001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDP001.AppearanceCell.Options.UseFont = true;
            this.PDP001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDP001.AppearanceHeader.Options.UseFont = true;
            this.PDP001.AppearanceHeader.Options.UseTextOptions = true;
            this.PDP001.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PDP001.Caption = "生产批号";
            this.PDP001.FieldName = "PDP001";
            this.PDP001.Name = "PDP001";
            this.PDP001.OptionsColumn.AllowEdit = false;
            this.PDP001.Visible = true;
            this.PDP001.VisibleIndex = 1;
            this.PDP001.Width = 69;
            // 
            // PDP002
            // 
            this.PDP002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDP002.AppearanceCell.Options.UseFont = true;
            this.PDP002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDP002.AppearanceHeader.Options.UseFont = true;
            this.PDP002.AppearanceHeader.Options.UseTextOptions = true;
            this.PDP002.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PDP002.Caption = "产品品号";
            this.PDP002.FieldName = "PDP002";
            this.PDP002.Name = "PDP002";
            this.PDP002.OptionsColumn.AllowEdit = false;
            this.PDP002.Visible = true;
            this.PDP002.VisibleIndex = 2;
            this.PDP002.Width = 132;
            // 
            // PDP003
            // 
            this.PDP003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDP003.AppearanceCell.Options.UseFont = true;
            this.PDP003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDP003.AppearanceHeader.Options.UseFont = true;
            this.PDP003.AppearanceHeader.Options.UseTextOptions = true;
            this.PDP003.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PDP003.Caption = "产品名称";
            this.PDP003.FieldName = "PDP003";
            this.PDP003.Name = "PDP003";
            this.PDP003.OptionsColumn.AllowEdit = false;
            this.PDP003.Visible = true;
            this.PDP003.VisibleIndex = 3;
            this.PDP003.Width = 164;
            // 
            // PDP004
            // 
            this.PDP004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDP004.AppearanceCell.Options.UseFont = true;
            this.PDP004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDP004.AppearanceHeader.Options.UseFont = true;
            this.PDP004.Caption = "规格";
            this.PDP004.FieldName = "PDP004";
            this.PDP004.Name = "PDP004";
            this.PDP004.OptionsColumn.AllowEdit = false;
            this.PDP004.Visible = true;
            this.PDP004.VisibleIndex = 4;
            this.PDP004.Width = 101;
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
            this.OPI006.Width = 94;
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
            this.OPI007.Width = 70;
            // 
            // PDP025
            // 
            this.PDP025.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDP025.AppearanceCell.Options.UseFont = true;
            this.PDP025.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDP025.AppearanceHeader.Options.UseFont = true;
            this.PDP025.AppearanceHeader.Options.UseTextOptions = true;
            this.PDP025.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PDP025.Caption = "生产数量";
            this.PDP025.FieldName = "PDP025";
            this.PDP025.Name = "PDP025";
            this.PDP025.OptionsColumn.AllowEdit = false;
            this.PDP025.Visible = true;
            this.PDP025.VisibleIndex = 7;
            this.PDP025.Width = 70;
            // 
            // PWI007
            // 
            this.PWI007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI007.AppearanceCell.Options.UseFont = true;
            this.PWI007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWI007.AppearanceHeader.Options.UseFont = true;
            this.PWI007.AppearanceHeader.Options.UseTextOptions = true;
            this.PWI007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PWI007.Caption = "累计报工数量";
            this.PWI007.FieldName = "PWI007";
            this.PWI007.Name = "PWI007";
            this.PWI007.OptionsColumn.AllowEdit = false;
            this.PWI007.Visible = true;
            this.PWI007.VisibleIndex = 8;
            this.PWI007.Width = 134;
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
            this.DL.VisibleIndex = 9;
            this.DL.Width = 125;
            // 
            // PWI012
            // 
            this.PWI012.Caption = "报工时间";
            this.PWI012.FieldName = "PWI012";
            this.PWI012.Name = "PWI012";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // PWH001
            // 
            this.PWH001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH001.AppearanceCell.Options.UseFont = true;
            this.PWH001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH001.AppearanceHeader.Options.UseFont = true;
            this.PWH001.AppearanceHeader.Options.UseTextOptions = true;
            this.PWH001.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PWH001.Caption = "周计划单号";
            this.PWH001.FieldName = "PWH001";
            this.PWH001.Name = "PWH001";
            this.PWH001.OptionsColumn.AllowEdit = false;
            this.PWH001.Visible = true;
            this.PWH001.VisibleIndex = 0;
            this.PWH001.Width = 90;
            // 
            // PDailyWeek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "PDailyWeek";
            this.Size = new System.Drawing.Size(1253, 523);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        public System . Windows . Forms . Button btnCancel;
        public System . Windows . Forms . Button btnOk;
        private System . Windows . Forms . DateTimePicker dateTimePicker1;
        private System . Windows . Forms . Label label1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PDP001;
        private DevExpress . XtraGrid . Columns . GridColumn PDP002;
        private DevExpress . XtraGrid . Columns . GridColumn PDP003;
        private DevExpress . XtraGrid . Columns . GridColumn PDP004;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn PDP025;
        private DevExpress . XtraGrid . Columns . GridColumn PWI007;
        private DevExpress . XtraGrid . Columns . GridColumn DL;
        private DevExpress . XtraGrid . Columns . GridColumn PWI012;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress . XtraGrid . Columns . GridColumn PWH001;
    }
}
