namespace Carpenter . ControlUser
{
    partial class AssembleWorkOrderQuery
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.tolPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tolExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AWO001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWO002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWO004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWO005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWO006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AWQ010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.tolPrintOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tolExportOrder = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gridControl1.Size = new System.Drawing.Size(1255, 408);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tolPrint,
            this.tolExport,
            this.tolPrintOrder,
            this.tolExportOrder});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 114);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // tolPrint
            // 
            this.tolPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tolPrint.Name = "tolPrint";
            this.tolPrint.Size = new System.Drawing.Size(152, 22);
            this.tolPrint.Text = "打印任务单";
            // 
            // tolExport
            // 
            this.tolExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tolExport.Name = "tolExport";
            this.tolExport.Size = new System.Drawing.Size(152, 22);
            this.tolExport.Text = "导出任务单";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AWO001,
            this.AWO002,
            this.AWQ005,
            this.AWO004,
            this.AWO005,
            this.AWO006,
            this.AWQ002,
            this.AWQ003,
            this.AWQ004,
            this.AWQ006,
            this.AWQ007,
            this.AWQ008,
            this.AWQ010,
            this.OPI006});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // AWO001
            // 
            this.AWO001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWO001.AppearanceCell.Options.UseFont = true;
            this.AWO001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWO001.AppearanceHeader.Options.UseFont = true;
            this.AWO001.Caption = "单号";
            this.AWO001.FieldName = "AWO001";
            this.AWO001.Name = "AWO001";
            this.AWO001.OptionsColumn.AllowEdit = false;
            this.AWO001.Visible = true;
            this.AWO001.VisibleIndex = 1;
            this.AWO001.Width = 105;
            // 
            // AWO002
            // 
            this.AWO002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWO002.AppearanceCell.Options.UseFont = true;
            this.AWO002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWO002.AppearanceHeader.Options.UseFont = true;
            this.AWO002.Caption = "派工时间";
            this.AWO002.FieldName = "AWO002";
            this.AWO002.Name = "AWO002";
            this.AWO002.OptionsColumn.AllowEdit = false;
            this.AWO002.Visible = true;
            this.AWO002.VisibleIndex = 10;
            this.AWO002.Width = 71;
            // 
            // AWQ005
            // 
            this.AWQ005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ005.AppearanceCell.Options.UseFont = true;
            this.AWQ005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ005.AppearanceHeader.Options.UseFont = true;
            this.AWQ005.Caption = "规格";
            this.AWQ005.FieldName = "AWQ005";
            this.AWQ005.Name = "AWQ005";
            this.AWQ005.OptionsColumn.AllowEdit = false;
            this.AWQ005.Visible = true;
            this.AWQ005.VisibleIndex = 5;
            this.AWQ005.Width = 69;
            // 
            // AWO004
            // 
            this.AWO004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWO004.AppearanceCell.Options.UseFont = true;
            this.AWO004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWO004.AppearanceHeader.Options.UseFont = true;
            this.AWO004.Caption = "完工时间";
            this.AWO004.FieldName = "AWO004";
            this.AWO004.Name = "AWO004";
            this.AWO004.OptionsColumn.AllowEdit = false;
            this.AWO004.Visible = true;
            this.AWO004.VisibleIndex = 11;
            this.AWO004.Width = 69;
            // 
            // AWO005
            // 
            this.AWO005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWO005.AppearanceCell.Options.UseFont = true;
            this.AWO005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWO005.AppearanceHeader.Options.UseFont = true;
            this.AWO005.Caption = "审核";
            this.AWO005.FieldName = "AWO005";
            this.AWO005.Name = "AWO005";
            this.AWO005.Visible = true;
            this.AWO005.VisibleIndex = 13;
            this.AWO005.Width = 38;
            // 
            // AWO006
            // 
            this.AWO006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWO006.AppearanceCell.Options.UseFont = true;
            this.AWO006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWO006.AppearanceHeader.Options.UseFont = true;
            this.AWO006.Caption = "注销";
            this.AWO006.FieldName = "AWO006";
            this.AWO006.Name = "AWO006";
            this.AWO006.Visible = true;
            this.AWO006.VisibleIndex = 14;
            this.AWO006.Width = 51;
            // 
            // AWQ002
            // 
            this.AWQ002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ002.AppearanceCell.Options.UseFont = true;
            this.AWQ002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ002.AppearanceHeader.Options.UseFont = true;
            this.AWQ002.Caption = "批号";
            this.AWQ002.FieldName = "AWQ002";
            this.AWQ002.Name = "AWQ002";
            this.AWQ002.Visible = true;
            this.AWQ002.VisibleIndex = 2;
            this.AWQ002.Width = 57;
            // 
            // AWQ003
            // 
            this.AWQ003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ003.AppearanceCell.Options.UseFont = true;
            this.AWQ003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ003.AppearanceHeader.Options.UseFont = true;
            this.AWQ003.Caption = "品号";
            this.AWQ003.FieldName = "AWQ003";
            this.AWQ003.Name = "AWQ003";
            this.AWQ003.Visible = true;
            this.AWQ003.VisibleIndex = 3;
            this.AWQ003.Width = 122;
            // 
            // AWQ004
            // 
            this.AWQ004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ004.AppearanceCell.Options.UseFont = true;
            this.AWQ004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ004.AppearanceHeader.Options.UseFont = true;
            this.AWQ004.Caption = "品名";
            this.AWQ004.FieldName = "AWQ004";
            this.AWQ004.Name = "AWQ004";
            this.AWQ004.Visible = true;
            this.AWQ004.VisibleIndex = 4;
            this.AWQ004.Width = 139;
            // 
            // AWQ006
            // 
            this.AWQ006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ006.AppearanceCell.Options.UseFont = true;
            this.AWQ006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ006.AppearanceHeader.Options.UseFont = true;
            this.AWQ006.Caption = "数量";
            this.AWQ006.FieldName = "AWQ006";
            this.AWQ006.Name = "AWQ006";
            this.AWQ006.Visible = true;
            this.AWQ006.VisibleIndex = 7;
            this.AWQ006.Width = 45;
            // 
            // AWQ007
            // 
            this.AWQ007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ007.AppearanceCell.Options.UseFont = true;
            this.AWQ007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ007.AppearanceHeader.Options.UseFont = true;
            this.AWQ007.Caption = "单价";
            this.AWQ007.FieldName = "AWQ007";
            this.AWQ007.Name = "AWQ007";
            this.AWQ007.Visible = true;
            this.AWQ007.VisibleIndex = 8;
            this.AWQ007.Width = 39;
            // 
            // AWQ008
            // 
            this.AWQ008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ008.AppearanceCell.Options.UseFont = true;
            this.AWQ008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ008.AppearanceHeader.Options.UseFont = true;
            this.AWQ008.Caption = "备注";
            this.AWQ008.FieldName = "AWQ008";
            this.AWQ008.Name = "AWQ008";
            this.AWQ008.Visible = true;
            this.AWQ008.VisibleIndex = 12;
            this.AWQ008.Width = 120;
            // 
            // AWQ010
            // 
            this.AWQ010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ010.AppearanceCell.Options.UseFont = true;
            this.AWQ010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AWQ010.AppearanceHeader.Options.UseFont = true;
            this.AWQ010.Caption = "人员姓名";
            this.AWQ010.FieldName = "AWQ010";
            this.AWQ010.Name = "AWQ010";
            this.AWQ010.Visible = true;
            this.AWQ010.VisibleIndex = 9;
            this.AWQ010.Width = 71;
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
            this.OPI006.VisibleIndex = 6;
            this.OPI006.Width = 53;
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
            // tolPrintOrder
            // 
            this.tolPrintOrder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tolPrintOrder.Name = "tolPrintOrder";
            this.tolPrintOrder.Size = new System.Drawing.Size(152, 22);
            this.tolPrintOrder.Text = "打印清单";
            // 
            // tolExportOrder
            // 
            this.tolExportOrder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tolExportOrder.Name = "tolExportOrder";
            this.tolExportOrder.Size = new System.Drawing.Size(152, 22);
            this.tolExportOrder.Text = "导出清单";
            // 
            // AssembleWorkOrderQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "AssembleWorkOrderQuery";
            this.Size = new System.Drawing.Size(1255, 408);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Columns . GridColumn AWO001;
        private DevExpress . XtraGrid . Columns . GridColumn AWO002;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ005;
        private DevExpress . XtraGrid . Columns . GridColumn AWO004;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox repositoryItemComboBox1;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn AWO005;
        private DevExpress . XtraGrid . Columns . GridColumn AWO006;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ002;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ003;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ004;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ006;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ007;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ008;
        private DevExpress . XtraGrid . Columns . GridColumn AWQ010;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private System . Windows . Forms . ContextMenuStrip contextMenuStrip1;
        private System . Windows . Forms . ToolStripMenuItem tolPrint;
        private System . Windows . Forms . ToolStripMenuItem tolExport;
        private System . Windows . Forms . ToolStripMenuItem tolPrintOrder;
        private System . Windows . Forms . ToolStripMenuItem tolExportOrder;
    }
}
