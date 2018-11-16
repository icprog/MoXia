namespace Carpenter . ControlUser
{
    partial class ZDayDailyWork
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
            this.PLE001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLE007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLF007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLF012 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.splitContainerControl1.Size = new System.Drawing.Size(1259, 509);
            this.splitContainerControl1.SplitterPosition = 38;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(368, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 26);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(280, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(82, 26);
            this.btnOk.TabIndex = 40;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(96, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 23);
            this.dateTimePicker1.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 38;
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
            this.gridControl1.Size = new System.Drawing.Size(1259, 459);
            this.gridControl1.TabIndex = 4;
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
            this.PLE001,
            this.PST001,
            this.PST002,
            this.PST003,
            this.PST004,
            this.PLE007,
            this.PLF007,
            this.DL,
            this.PLF012});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PLE001
            // 
            this.PLE001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLE001.AppearanceCell.Options.UseFont = true;
            this.PLE001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLE001.AppearanceHeader.Options.UseFont = true;
            this.PLE001.AppearanceHeader.Options.UseTextOptions = true;
            this.PLE001.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PLE001.Caption = "日计划单号";
            this.PLE001.FieldName = "PLE001";
            this.PLE001.Name = "PLE001";
            this.PLE001.OptionsColumn.AllowEdit = false;
            this.PLE001.Visible = true;
            this.PLE001.VisibleIndex = 0;
            this.PLE001.Width = 132;
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
            this.PST001.Width = 125;
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
            this.PST002.Width = 128;
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
            this.PST003.Width = 167;
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
            this.PST004.Width = 145;
            // 
            // PLE007
            // 
            this.PLE007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLE007.AppearanceCell.Options.UseFont = true;
            this.PLE007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLE007.AppearanceHeader.Options.UseFont = true;
            this.PLE007.AppearanceHeader.Options.UseTextOptions = true;
            this.PLE007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PLE007.Caption = "计划数量";
            this.PLE007.FieldName = "PLE007";
            this.PLE007.Name = "PLE007";
            this.PLE007.OptionsColumn.AllowEdit = false;
            this.PLE007.Visible = true;
            this.PLE007.VisibleIndex = 5;
            this.PLE007.Width = 121;
            // 
            // PLF007
            // 
            this.PLF007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLF007.AppearanceCell.Options.UseFont = true;
            this.PLF007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLF007.AppearanceHeader.Options.UseFont = true;
            this.PLF007.AppearanceHeader.Options.UseTextOptions = true;
            this.PLF007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PLF007.Caption = "组装累计报工数量";
            this.PLF007.FieldName = "PLF007";
            this.PLF007.Name = "PLF007";
            this.PLF007.OptionsColumn.AllowEdit = false;
            this.PLF007.Visible = true;
            this.PLF007.VisibleIndex = 6;
            this.PLF007.Width = 201;
            // 
            // DL
            // 
            this.DL.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.DL.AppearanceCell.Options.UseFont = true;
            this.DL.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.DL.AppearanceHeader.Options.UseFont = true;
            this.DL.AppearanceHeader.Options.UseTextOptions = true;
            this.DL.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.DL.Caption = "组装报工数量";
            this.DL.FieldName = "DL";
            this.DL.Name = "DL";
            this.DL.Visible = true;
            this.DL.VisibleIndex = 7;
            this.DL.Width = 193;
            // 
            // PLF012
            // 
            this.PLF012.Caption = "报工时间";
            this.PLF012.FieldName = "PLF012";
            this.PLF012.Name = "PLF012";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // ZDayDailyWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ZDayDailyWork";
            this.Size = new System.Drawing.Size(1259, 509);
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
        private DevExpress . XtraGrid . Columns . GridColumn PLE001;
        private DevExpress . XtraGrid . Columns . GridColumn PST001;
        private DevExpress . XtraGrid . Columns . GridColumn PST002;
        private DevExpress . XtraGrid . Columns . GridColumn PST003;
        private DevExpress . XtraGrid . Columns . GridColumn PST004;
        private DevExpress . XtraGrid . Columns . GridColumn PLE007;
        private DevExpress . XtraGrid . Columns . GridColumn PLF007;
        private DevExpress . XtraGrid . Columns . GridColumn DL;
        private DevExpress . XtraGrid . Columns . GridColumn PLF012;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}
