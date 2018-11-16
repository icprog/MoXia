namespace Carpenter . ControlUser
{
    partial class PDailyWork
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
            this.PWE007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWF007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWF008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWF009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.XS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWF010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWF011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWF016 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWF012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.PWE001 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.splitContainerControl1.Size = new System.Drawing.Size(1250, 516);
            this.splitContainerControl1.SplitterPosition = 35;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(321, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 26);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(246, 9);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 26);
            this.btnOk.TabIndex = 40;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(110, 22);
            this.dateTimePicker1.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
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
            this.gridControl1.Size = new System.Drawing.Size(1250, 469);
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
            this.PWE001,
            this.PDP001,
            this.PDP002,
            this.PDP003,
            this.PDP004,
            this.PWE007,
            this.PWF007,
            this.DQ,
            this.PWF008,
            this.YM,
            this.PWF009,
            this.XS,
            this.PWF010,
            this.MQ,
            this.PWF011,
            this.RB,
            this.PWF016,
            this.BZ,
            this.PWF012});
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
            this.PDP001.Width = 31;
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
            this.PDP002.Width = 61;
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
            this.PDP003.Width = 76;
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
            this.PDP004.Width = 47;
            // 
            // PWE007
            // 
            this.PWE007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE007.AppearanceCell.Options.UseFont = true;
            this.PWE007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE007.AppearanceHeader.Options.UseFont = true;
            this.PWE007.AppearanceHeader.Options.UseTextOptions = true;
            this.PWE007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PWE007.Caption = "计划数量";
            this.PWE007.FieldName = "PWE007";
            this.PWE007.Name = "PWE007";
            this.PWE007.OptionsColumn.AllowEdit = false;
            this.PWE007.Visible = true;
            this.PWE007.VisibleIndex = 5;
            this.PWE007.Width = 39;
            // 
            // PWF007
            // 
            this.PWF007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF007.AppearanceCell.Options.UseFont = true;
            this.PWF007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF007.AppearanceHeader.Options.UseFont = true;
            this.PWF007.AppearanceHeader.Options.UseTextOptions = true;
            this.PWF007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PWF007.Caption = "底漆累计报工数量";
            this.PWF007.FieldName = "PWF007";
            this.PWF007.Name = "PWF007";
            this.PWF007.OptionsColumn.AllowEdit = false;
            this.PWF007.Visible = true;
            this.PWF007.VisibleIndex = 6;
            this.PWF007.Width = 63;
            // 
            // DQ
            // 
            this.DQ.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.DQ.AppearanceCell.Options.UseFont = true;
            this.DQ.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.DQ.AppearanceHeader.Options.UseFont = true;
            this.DQ.AppearanceHeader.Options.UseTextOptions = true;
            this.DQ.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.DQ.Caption = "底漆报工数量";
            this.DQ.FieldName = "DQ";
            this.DQ.Name = "DQ";
            this.DQ.Visible = true;
            this.DQ.VisibleIndex = 7;
            this.DQ.Width = 55;
            // 
            // PWF008
            // 
            this.PWF008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF008.AppearanceCell.Options.UseFont = true;
            this.PWF008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF008.AppearanceHeader.Options.UseFont = true;
            this.PWF008.AppearanceHeader.Options.UseTextOptions = true;
            this.PWF008.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PWF008.Caption = "油磨累计报工数量";
            this.PWF008.FieldName = "PWF008";
            this.PWF008.Name = "PWF008";
            this.PWF008.OptionsColumn.AllowEdit = false;
            this.PWF008.Visible = true;
            this.PWF008.VisibleIndex = 8;
            this.PWF008.Width = 63;
            // 
            // YM
            // 
            this.YM.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.YM.AppearanceCell.Options.UseFont = true;
            this.YM.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.YM.AppearanceHeader.Options.UseFont = true;
            this.YM.AppearanceHeader.Options.UseTextOptions = true;
            this.YM.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.YM.Caption = "油磨报工数量";
            this.YM.FieldName = "YM";
            this.YM.Name = "YM";
            this.YM.Visible = true;
            this.YM.VisibleIndex = 9;
            this.YM.Width = 51;
            // 
            // PWF009
            // 
            this.PWF009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF009.AppearanceCell.Options.UseFont = true;
            this.PWF009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF009.AppearanceHeader.Options.UseFont = true;
            this.PWF009.AppearanceHeader.Options.UseTextOptions = true;
            this.PWF009.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PWF009.Caption = "修色累计报工数量";
            this.PWF009.FieldName = "PWF009";
            this.PWF009.Name = "PWF009";
            this.PWF009.OptionsColumn.AllowEdit = false;
            this.PWF009.Visible = true;
            this.PWF009.VisibleIndex = 10;
            this.PWF009.Width = 63;
            // 
            // XS
            // 
            this.XS.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.XS.AppearanceCell.Options.UseFont = true;
            this.XS.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.XS.AppearanceHeader.Options.UseFont = true;
            this.XS.AppearanceHeader.Options.UseTextOptions = true;
            this.XS.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.XS.Caption = "修色报工数量";
            this.XS.FieldName = "XS";
            this.XS.Name = "XS";
            this.XS.Visible = true;
            this.XS.VisibleIndex = 11;
            this.XS.Width = 55;
            // 
            // PWF010
            // 
            this.PWF010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF010.AppearanceCell.Options.UseFont = true;
            this.PWF010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF010.AppearanceHeader.Options.UseFont = true;
            this.PWF010.AppearanceHeader.Options.UseTextOptions = true;
            this.PWF010.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PWF010.Caption = "面漆累计报工数量";
            this.PWF010.FieldName = "PWF010";
            this.PWF010.Name = "PWF010";
            this.PWF010.OptionsColumn.AllowEdit = false;
            this.PWF010.Visible = true;
            this.PWF010.VisibleIndex = 12;
            this.PWF010.Width = 59;
            // 
            // MQ
            // 
            this.MQ.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.MQ.AppearanceCell.Options.UseFont = true;
            this.MQ.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.MQ.AppearanceHeader.Options.UseFont = true;
            this.MQ.AppearanceHeader.Options.UseTextOptions = true;
            this.MQ.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.MQ.Caption = "面漆报工数量";
            this.MQ.FieldName = "MQ";
            this.MQ.Name = "MQ";
            this.MQ.Visible = true;
            this.MQ.VisibleIndex = 13;
            this.MQ.Width = 49;
            // 
            // PWF011
            // 
            this.PWF011.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF011.AppearanceCell.Options.UseFont = true;
            this.PWF011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF011.AppearanceHeader.Options.UseFont = true;
            this.PWF011.AppearanceHeader.Options.UseTextOptions = true;
            this.PWF011.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PWF011.Caption = "软包累计报工数量";
            this.PWF011.FieldName = "PWF011";
            this.PWF011.Name = "PWF011";
            this.PWF011.OptionsColumn.AllowEdit = false;
            this.PWF011.Visible = true;
            this.PWF011.VisibleIndex = 14;
            this.PWF011.Width = 60;
            // 
            // RB
            // 
            this.RB.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.RB.AppearanceCell.Options.UseFont = true;
            this.RB.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.RB.AppearanceHeader.Options.UseFont = true;
            this.RB.AppearanceHeader.Options.UseTextOptions = true;
            this.RB.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.RB.Caption = "软包报工数量";
            this.RB.FieldName = "RB";
            this.RB.Name = "RB";
            this.RB.Visible = true;
            this.RB.VisibleIndex = 15;
            this.RB.Width = 39;
            // 
            // PWF016
            // 
            this.PWF016.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF016.AppearanceCell.Options.UseFont = true;
            this.PWF016.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWF016.AppearanceHeader.Options.UseFont = true;
            this.PWF016.AppearanceHeader.Options.UseTextOptions = true;
            this.PWF016.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PWF016.Caption = "包装累计报工数量";
            this.PWF016.FieldName = "PWF016";
            this.PWF016.Name = "PWF016";
            this.PWF016.OptionsColumn.AllowEdit = false;
            this.PWF016.Visible = true;
            this.PWF016.VisibleIndex = 16;
            this.PWF016.Width = 69;
            // 
            // BZ
            // 
            this.BZ.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.BZ.AppearanceCell.Options.UseFont = true;
            this.BZ.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.BZ.AppearanceHeader.Options.UseFont = true;
            this.BZ.AppearanceHeader.Options.UseTextOptions = true;
            this.BZ.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.BZ.Caption = "包装报工数量";
            this.BZ.FieldName = "BZ";
            this.BZ.Name = "BZ";
            this.BZ.Visible = true;
            this.BZ.VisibleIndex = 17;
            this.BZ.Width = 105;
            // 
            // PWF012
            // 
            this.PWF012.Caption = "报工时间";
            this.PWF012.FieldName = "PWF012";
            this.PWF012.Name = "PWF012";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // PWE001
            // 
            this.PWE001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE001.AppearanceCell.Options.UseFont = true;
            this.PWE001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWE001.AppearanceHeader.Options.UseFont = true;
            this.PWE001.AppearanceHeader.Options.UseTextOptions = true;
            this.PWE001.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PWE001.Caption = "日计划单号";
            this.PWE001.FieldName = "PWE001";
            this.PWE001.Name = "PWE001";
            this.PWE001.OptionsColumn.AllowEdit = false;
            this.PWE001.Visible = true;
            this.PWE001.VisibleIndex = 0;
            this.PWE001.Width = 64;
            // 
            // PDailyWork
            // 
            this.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "PDailyWork";
            this.Size = new System.Drawing.Size(1250, 516);
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
        private DevExpress . XtraGrid . Columns . GridColumn PWF007;
        private DevExpress . XtraGrid . Columns . GridColumn DQ;
        private DevExpress . XtraGrid . Columns . GridColumn PWF008;
        private DevExpress . XtraGrid . Columns . GridColumn YM;
        private DevExpress . XtraGrid . Columns . GridColumn PWF009;
        private DevExpress . XtraGrid . Columns . GridColumn XS;
        private DevExpress . XtraGrid . Columns . GridColumn PWF010;
        private DevExpress . XtraGrid . Columns . GridColumn MQ;
        private DevExpress . XtraGrid . Columns . GridColumn PWF011;
        private DevExpress . XtraGrid . Columns . GridColumn RB;
        private DevExpress . XtraGrid . Columns . GridColumn PWF012;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress . XtraGrid . Columns . GridColumn PWF016;
        private DevExpress . XtraGrid . Columns . GridColumn BZ;
        private DevExpress . XtraGrid . Columns . GridColumn PWE007;
        private DevExpress . XtraGrid . Columns . GridColumn PWE001;
    }
}
