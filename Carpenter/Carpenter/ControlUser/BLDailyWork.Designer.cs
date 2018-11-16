namespace Carpenter . ControlUser
{
    partial class BLDailyWork
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PSX001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PST004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PSX007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.XB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PDW012 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.splitContainer1.Size = new System.Drawing.Size(1252, 462);
            this.splitContainer1.SplitterDistance = 37;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(373, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 26);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(285, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(82, 26);
            this.btnOk.TabIndex = 36;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(101, 8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 23);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
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
            this.gridControl1.Size = new System.Drawing.Size(1252, 421);
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
            this.PSX001,
            this.PST001,
            this.PST002,
            this.PST003,
            this.PST004,
            this.PSX007,
            this.PDW007,
            this.DL,
            this.PDW008,
            this.XB,
            this.PDW009,
            this.CJ,
            this.PDW010,
            this.PB,
            this.PDW011,
            this.PC,
            this.PDW012});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PSX001
            // 
            this.PSX001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSX001.AppearanceCell.Options.UseFont = true;
            this.PSX001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSX001.AppearanceHeader.Options.UseFont = true;
            this.PSX001.AppearanceHeader.Options.UseTextOptions = true;
            this.PSX001.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PSX001.Caption = "日计划单号";
            this.PSX001.FieldName = "PSX001";
            this.PSX001.Name = "PSX001";
            this.PSX001.OptionsColumn.AllowEdit = false;
            this.PSX001.Visible = true;
            this.PSX001.VisibleIndex = 0;
            this.PSX001.Width = 79;
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
            this.PST001.Width = 34;
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
            this.PST002.Width = 68;
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
            this.PST003.Width = 84;
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
            this.PST004.Width = 51;
            // 
            // PSX007
            // 
            this.PSX007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSX007.AppearanceCell.Options.UseFont = true;
            this.PSX007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSX007.AppearanceHeader.Options.UseFont = true;
            this.PSX007.AppearanceHeader.Options.UseTextOptions = true;
            this.PSX007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PSX007.Caption = "计划数量";
            this.PSX007.FieldName = "PSX007";
            this.PSX007.Name = "PSX007";
            this.PSX007.OptionsColumn.AllowEdit = false;
            this.PSX007.Visible = true;
            this.PSX007.VisibleIndex = 5;
            this.PSX007.Width = 43;
            // 
            // PDW007
            // 
            this.PDW007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW007.AppearanceCell.Options.UseFont = true;
            this.PDW007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW007.AppearanceHeader.Options.UseFont = true;
            this.PDW007.AppearanceHeader.Options.UseTextOptions = true;
            this.PDW007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PDW007.Caption = "断料累计报工数量";
            this.PDW007.FieldName = "PDW007";
            this.PDW007.Name = "PDW007";
            this.PDW007.OptionsColumn.AllowEdit = false;
            this.PDW007.Visible = true;
            this.PDW007.VisibleIndex = 6;
            this.PDW007.Width = 71;
            // 
            // DL
            // 
            this.DL.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.DL.AppearanceCell.Options.UseFont = true;
            this.DL.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.DL.AppearanceHeader.Options.UseFont = true;
            this.DL.AppearanceHeader.Options.UseTextOptions = true;
            this.DL.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.DL.Caption = "断料报工数量";
            this.DL.FieldName = "DL";
            this.DL.Name = "DL";
            this.DL.Visible = true;
            this.DL.VisibleIndex = 7;
            this.DL.Width = 60;
            // 
            // PDW008
            // 
            this.PDW008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW008.AppearanceCell.Options.UseFont = true;
            this.PDW008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW008.AppearanceHeader.Options.UseFont = true;
            this.PDW008.AppearanceHeader.Options.UseTextOptions = true;
            this.PDW008.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PDW008.Caption = "修边累计报工数量";
            this.PDW008.FieldName = "PDW008";
            this.PDW008.Name = "PDW008";
            this.PDW008.OptionsColumn.AllowEdit = false;
            this.PDW008.Visible = true;
            this.PDW008.VisibleIndex = 8;
            this.PDW008.Width = 69;
            // 
            // XB
            // 
            this.XB.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.XB.AppearanceCell.Options.UseFont = true;
            this.XB.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.XB.AppearanceHeader.Options.UseFont = true;
            this.XB.AppearanceHeader.Options.UseTextOptions = true;
            this.XB.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.XB.Caption = "修边报工数量";
            this.XB.FieldName = "XB";
            this.XB.Name = "XB";
            this.XB.Visible = true;
            this.XB.VisibleIndex = 9;
            this.XB.Width = 57;
            // 
            // PDW009
            // 
            this.PDW009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW009.AppearanceCell.Options.UseFont = true;
            this.PDW009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW009.AppearanceHeader.Options.UseFont = true;
            this.PDW009.AppearanceHeader.Options.UseTextOptions = true;
            this.PDW009.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PDW009.Caption = "齿接累计报工数量";
            this.PDW009.FieldName = "PDW009";
            this.PDW009.Name = "PDW009";
            this.PDW009.OptionsColumn.AllowEdit = false;
            this.PDW009.Visible = true;
            this.PDW009.VisibleIndex = 10;
            this.PDW009.Width = 71;
            // 
            // CJ
            // 
            this.CJ.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CJ.AppearanceCell.Options.UseFont = true;
            this.CJ.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CJ.AppearanceHeader.Options.UseFont = true;
            this.CJ.AppearanceHeader.Options.UseTextOptions = true;
            this.CJ.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CJ.Caption = "齿接报工数量";
            this.CJ.FieldName = "CJ";
            this.CJ.Name = "CJ";
            this.CJ.Visible = true;
            this.CJ.VisibleIndex = 11;
            this.CJ.Width = 60;
            // 
            // PDW010
            // 
            this.PDW010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW010.AppearanceCell.Options.UseFont = true;
            this.PDW010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW010.AppearanceHeader.Options.UseFont = true;
            this.PDW010.AppearanceHeader.Options.UseTextOptions = true;
            this.PDW010.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PDW010.Caption = "拼板累计报工数量";
            this.PDW010.FieldName = "PDW010";
            this.PDW010.Name = "PDW010";
            this.PDW010.OptionsColumn.AllowEdit = false;
            this.PDW010.Visible = true;
            this.PDW010.VisibleIndex = 12;
            this.PDW010.Width = 64;
            // 
            // PB
            // 
            this.PB.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PB.AppearanceCell.Options.UseFont = true;
            this.PB.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PB.AppearanceHeader.Options.UseFont = true;
            this.PB.AppearanceHeader.Options.UseTextOptions = true;
            this.PB.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PB.Caption = "拼板报工数量";
            this.PB.FieldName = "PB";
            this.PB.Name = "PB";
            this.PB.Visible = true;
            this.PB.VisibleIndex = 13;
            this.PB.Width = 55;
            // 
            // PDW011
            // 
            this.PDW011.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW011.AppearanceCell.Options.UseFont = true;
            this.PDW011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PDW011.AppearanceHeader.Options.UseFont = true;
            this.PDW011.AppearanceHeader.Options.UseTextOptions = true;
            this.PDW011.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PDW011.Caption = "刨床累计报工数量";
            this.PDW011.FieldName = "PDW011";
            this.PDW011.Name = "PDW011";
            this.PDW011.OptionsColumn.AllowEdit = false;
            this.PDW011.Visible = true;
            this.PDW011.VisibleIndex = 14;
            this.PDW011.Width = 65;
            // 
            // PC
            // 
            this.PC.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PC.AppearanceCell.Options.UseFont = true;
            this.PC.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PC.AppearanceHeader.Options.UseFont = true;
            this.PC.AppearanceHeader.Options.UseTextOptions = true;
            this.PC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PC.Caption = "刨床报工数量";
            this.PC.FieldName = "PC";
            this.PC.Name = "PC";
            this.PC.Visible = true;
            this.PC.VisibleIndex = 15;
            this.PC.Width = 118;
            // 
            // PDW012
            // 
            this.PDW012.Caption = "报工时间";
            this.PDW012.FieldName = "PDW012";
            this.PDW012.Name = "PDW012";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // BLDailyWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "BLDailyWork";
            this.Size = new System.Drawing.Size(1252, 462);
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
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress . XtraGrid . Columns . GridColumn PST001;
        private DevExpress . XtraGrid . Columns . GridColumn PST002;
        private DevExpress . XtraGrid . Columns . GridColumn PST003;
        private DevExpress . XtraGrid . Columns . GridColumn PST004;
        private DevExpress . XtraGrid . Columns . GridColumn DL;
        private DevExpress . XtraGrid . Columns . GridColumn XB;
        private DevExpress . XtraGrid . Columns . GridColumn CJ;
        private DevExpress . XtraGrid . Columns . GridColumn PB;
        private DevExpress . XtraGrid . Columns . GridColumn PC;
        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . DateTimePicker dateTimePicker1;
        public System . Windows . Forms . Button btnCancel;
        public System . Windows . Forms . Button btnOk;
        private DevExpress . XtraGrid . Columns . GridColumn PDW012;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PDW007;
        private DevExpress . XtraGrid . Columns . GridColumn PDW008;
        private DevExpress . XtraGrid . Columns . GridColumn PDW009;
        private DevExpress . XtraGrid . Columns . GridColumn PDW010;
        private DevExpress . XtraGrid . Columns . GridColumn PDW011;
        private DevExpress . XtraGrid . Columns . GridColumn PSX007;
        private DevExpress . XtraGrid . Columns . GridColumn PSX001;
    }
}
