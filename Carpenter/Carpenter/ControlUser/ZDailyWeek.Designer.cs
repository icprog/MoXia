namespace Carpenter . ControlUser
{
    partial class ZDailyWeek
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
            this.PAS001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAS002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAS003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAS004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAS016 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLC007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLC012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
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
            this.splitContainerControl1.Size = new System.Drawing.Size(1222, 504);
            this.splitContainerControl1.SplitterPosition = 41;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(321, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 26);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(245, 9);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 26);
            this.btnOk.TabIndex = 44;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 22);
            this.dateTimePicker1.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 42;
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
            this.gridControl1.Size = new System.Drawing.Size(1222, 458);
            this.gridControl1.TabIndex = 5;
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
            this.PAS001,
            this.PAS002,
            this.PAS003,
            this.PAS004,
            this.OPI006,
            this.OPI007,
            this.PAS016,
            this.PLC007,
            this.DL,
            this.PLC012});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PAS001
            // 
            this.PAS001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS001.AppearanceCell.Options.UseFont = true;
            this.PAS001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS001.AppearanceHeader.Options.UseFont = true;
            this.PAS001.AppearanceHeader.Options.UseTextOptions = true;
            this.PAS001.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PAS001.Caption = "生产批号";
            this.PAS001.FieldName = "PAS001";
            this.PAS001.Name = "PAS001";
            this.PAS001.OptionsColumn.AllowEdit = false;
            this.PAS001.Visible = true;
            this.PAS001.VisibleIndex = 0;
            this.PAS001.Width = 36;
            // 
            // PAS002
            // 
            this.PAS002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS002.AppearanceCell.Options.UseFont = true;
            this.PAS002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS002.AppearanceHeader.Options.UseFont = true;
            this.PAS002.AppearanceHeader.Options.UseTextOptions = true;
            this.PAS002.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PAS002.Caption = "产品品号";
            this.PAS002.FieldName = "PAS002";
            this.PAS002.Name = "PAS002";
            this.PAS002.OptionsColumn.AllowEdit = false;
            this.PAS002.Visible = true;
            this.PAS002.VisibleIndex = 1;
            this.PAS002.Width = 69;
            // 
            // PAS003
            // 
            this.PAS003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS003.AppearanceCell.Options.UseFont = true;
            this.PAS003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS003.AppearanceHeader.Options.UseFont = true;
            this.PAS003.AppearanceHeader.Options.UseTextOptions = true;
            this.PAS003.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PAS003.Caption = "产品名称";
            this.PAS003.FieldName = "PAS003";
            this.PAS003.Name = "PAS003";
            this.PAS003.OptionsColumn.AllowEdit = false;
            this.PAS003.Visible = true;
            this.PAS003.VisibleIndex = 2;
            this.PAS003.Width = 85;
            // 
            // PAS004
            // 
            this.PAS004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS004.AppearanceCell.Options.UseFont = true;
            this.PAS004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS004.AppearanceHeader.Options.UseFont = true;
            this.PAS004.Caption = "规格";
            this.PAS004.FieldName = "PAS004";
            this.PAS004.Name = "PAS004";
            this.PAS004.OptionsColumn.AllowEdit = false;
            this.PAS004.Visible = true;
            this.PAS004.VisibleIndex = 3;
            this.PAS004.Width = 53;
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
            this.OPI006.VisibleIndex = 4;
            this.OPI006.Width = 49;
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
            this.OPI007.VisibleIndex = 5;
            this.OPI007.Width = 37;
            // 
            // PAS016
            // 
            this.PAS016.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS016.AppearanceCell.Options.UseFont = true;
            this.PAS016.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PAS016.AppearanceHeader.Options.UseFont = true;
            this.PAS016.AppearanceHeader.Options.UseTextOptions = true;
            this.PAS016.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PAS016.Caption = "生产数量";
            this.PAS016.FieldName = "PAS016";
            this.PAS016.Name = "PAS016";
            this.PAS016.OptionsColumn.AllowEdit = false;
            this.PAS016.Visible = true;
            this.PAS016.VisibleIndex = 6;
            this.PAS016.Width = 37;
            // 
            // PLC007
            // 
            this.PLC007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC007.AppearanceCell.Options.UseFont = true;
            this.PLC007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLC007.AppearanceHeader.Options.UseFont = true;
            this.PLC007.AppearanceHeader.Options.UseTextOptions = true;
            this.PLC007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PLC007.Caption = "累计报工数量";
            this.PLC007.FieldName = "PLC007";
            this.PLC007.Name = "PLC007";
            this.PLC007.OptionsColumn.AllowEdit = false;
            this.PLC007.Visible = true;
            this.PLC007.VisibleIndex = 7;
            this.PLC007.Width = 70;
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
            this.DL.VisibleIndex = 8;
            this.DL.Width = 60;
            // 
            // PLC012
            // 
            this.PLC012.Caption = "报工时间";
            this.PLC012.FieldName = "PLC012";
            this.PLC012.Name = "PLC012";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // ZDailyWeek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ZDailyWeek";
            this.Size = new System.Drawing.Size(1222, 504);
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
        private DevExpress . XtraGrid . Columns . GridColumn PAS001;
        private DevExpress . XtraGrid . Columns . GridColumn PAS002;
        private DevExpress . XtraGrid . Columns . GridColumn PAS003;
        private DevExpress . XtraGrid . Columns . GridColumn PAS004;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn PAS016;
        private DevExpress . XtraGrid . Columns . GridColumn PLC007;
        private DevExpress . XtraGrid . Columns . GridColumn DL;
        private DevExpress . XtraGrid . Columns . GridColumn PLC012;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}
