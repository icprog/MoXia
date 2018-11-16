namespace Carpenter
{
    partial class FormOutPutValue
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
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.OPV003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPV004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPV005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPV006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPV007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPV008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPV009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPV010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPV011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPV001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPV002 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.dateEdit1);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1231, 409);
            this.splitContainerControl1.SplitterPosition = 50;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(61, 15);
            this.dateEdit1.MenuManager = this.barManager1;
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEdit1.Properties.Appearance.Options.UseFont = true;
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateEdit1.Size = new System.Drawing.Size(129, 20);
            this.dateEdit1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(27, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "年月";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1231, 347);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.OPV003,
            this.OPV004,
            this.OPV005,
            this.OPV006,
            this.OPV007,
            this.OPV008,
            this.OPV009,
            this.OPV010,
            this.OPV011,
            this.OPV001,
            this.OPV002});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // OPV003
            // 
            this.OPV003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPV003.AppearanceCell.Options.UseFont = true;
            this.OPV003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV003.AppearanceHeader.Options.UseFont = true;
            this.OPV003.Caption = "日期";
            this.OPV003.FieldName = "OPV003";
            this.OPV003.Name = "OPV003";
            this.OPV003.Visible = true;
            this.OPV003.VisibleIndex = 0;
            // 
            // OPV004
            // 
            this.OPV004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV004.AppearanceCell.Options.UseFont = true;
            this.OPV004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV004.AppearanceHeader.Options.UseFont = true;
            this.OPV004.Caption = "备料";
            this.OPV004.DisplayFormat.FormatString = "0.####";
            this.OPV004.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.OPV004.FieldName = "OPV004";
            this.OPV004.Name = "OPV004";
            this.OPV004.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OPV004", "{0:0.####}")});
            this.OPV004.Visible = true;
            this.OPV004.VisibleIndex = 1;
            // 
            // OPV005
            // 
            this.OPV005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV005.AppearanceCell.Options.UseFont = true;
            this.OPV005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV005.AppearanceHeader.Options.UseFont = true;
            this.OPV005.Caption = "机加工";
            this.OPV005.DisplayFormat.FormatString = "0.####";
            this.OPV005.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.OPV005.FieldName = "OPV005";
            this.OPV005.Name = "OPV005";
            this.OPV005.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OPV005", "{0:0.####}")});
            this.OPV005.Visible = true;
            this.OPV005.VisibleIndex = 2;
            // 
            // OPV006
            // 
            this.OPV006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV006.AppearanceCell.Options.UseFont = true;
            this.OPV006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV006.AppearanceHeader.Options.UseFont = true;
            this.OPV006.Caption = "组装";
            this.OPV006.DisplayFormat.FormatString = "0.####";
            this.OPV006.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.OPV006.FieldName = "OPV006";
            this.OPV006.Name = "OPV006";
            this.OPV006.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OPV006", "{0:0.####}")});
            this.OPV006.Visible = true;
            this.OPV006.VisibleIndex = 3;
            // 
            // OPV007
            // 
            this.OPV007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV007.AppearanceCell.Options.UseFont = true;
            this.OPV007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV007.AppearanceHeader.Options.UseFont = true;
            this.OPV007.Caption = "底漆";
            this.OPV007.DisplayFormat.FormatString = "0.####";
            this.OPV007.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.OPV007.FieldName = "OPV007";
            this.OPV007.Name = "OPV007";
            this.OPV007.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OPV007", "{0:0.####}")});
            this.OPV007.Visible = true;
            this.OPV007.VisibleIndex = 4;
            // 
            // OPV008
            // 
            this.OPV008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV008.AppearanceCell.Options.UseFont = true;
            this.OPV008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV008.AppearanceHeader.Options.UseFont = true;
            this.OPV008.Caption = "油墨";
            this.OPV008.DisplayFormat.FormatString = "0.####";
            this.OPV008.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.OPV008.FieldName = "OPV008";
            this.OPV008.Name = "OPV008";
            this.OPV008.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OPV008", "{0:0.####}")});
            this.OPV008.Visible = true;
            this.OPV008.VisibleIndex = 5;
            // 
            // OPV009
            // 
            this.OPV009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV009.AppearanceCell.Options.UseFont = true;
            this.OPV009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV009.AppearanceHeader.Options.UseFont = true;
            this.OPV009.Caption = "面漆";
            this.OPV009.DisplayFormat.FormatString = "0.####";
            this.OPV009.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.OPV009.FieldName = "OPV009";
            this.OPV009.Name = "OPV009";
            this.OPV009.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OPV009", "{0:0.####}")});
            this.OPV009.Visible = true;
            this.OPV009.VisibleIndex = 6;
            // 
            // OPV010
            // 
            this.OPV010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV010.AppearanceCell.Options.UseFont = true;
            this.OPV010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV010.AppearanceHeader.Options.UseFont = true;
            this.OPV010.Caption = "包装";
            this.OPV010.DisplayFormat.FormatString = "0.####";
            this.OPV010.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.OPV010.FieldName = "OPV010";
            this.OPV010.Name = "OPV010";
            this.OPV010.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OPV010", "{0:0.####}")});
            this.OPV010.Visible = true;
            this.OPV010.VisibleIndex = 7;
            // 
            // OPV011
            // 
            this.OPV011.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV011.AppearanceCell.Options.UseFont = true;
            this.OPV011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPV011.AppearanceHeader.Options.UseFont = true;
            this.OPV011.Caption = "断料";
            this.OPV011.DisplayFormat.FormatString = "0.####";
            this.OPV011.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.OPV011.FieldName = "OPV011";
            this.OPV011.Name = "OPV011";
            this.OPV011.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OPV011", "{0:0.####}")});
            this.OPV011.Visible = true;
            this.OPV011.VisibleIndex = 8;
            // 
            // OPV001
            // 
            this.OPV001.Caption = "年";
            this.OPV001.FieldName = "OPV001";
            this.OPV001.Name = "OPV001";
            // 
            // OPV002
            // 
            this.OPV002.Caption = "月";
            this.OPV002.FieldName = "OPV002";
            this.OPV002.Name = "OPV002";
            // 
            // FormOutPutValue
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 435);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormOutPutValue";
            this.Text = "产值统计表";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraEditors . DateEdit dateEdit1;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraGrid . Columns . GridColumn OPV003;
        private DevExpress . XtraGrid . Columns . GridColumn OPV004;
        private DevExpress . XtraGrid . Columns . GridColumn OPV005;
        private DevExpress . XtraGrid . Columns . GridColumn OPV006;
        private DevExpress . XtraGrid . Columns . GridColumn OPV007;
        private DevExpress . XtraGrid . Columns . GridColumn OPV008;
        private DevExpress . XtraGrid . Columns . GridColumn OPV009;
        private DevExpress . XtraGrid . Columns . GridColumn OPV010;
        private DevExpress . XtraGrid . Columns . GridColumn OPV011;
        private DevExpress . XtraGrid . Columns . GridColumn OPV001;
        private DevExpress . XtraGrid . Columns . GridColumn OPV002;
    }
}