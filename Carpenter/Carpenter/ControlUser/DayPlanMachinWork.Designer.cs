namespace Carpenter . ControlUser
{
    partial class DayPlanMachinWork
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
            this.PMW001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMW002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMW004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMW003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMW010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMW009 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridControl1.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gridControl1.EmbeddedNavigator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridControl1.EmbeddedNavigator.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(755, 427);
            this.gridControl1.TabIndex = 3;
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
            this.PMW001,
            this.PMW002,
            this.PMW004,
            this.PMW003,
            this.PMW010,
            this.PMW009});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PMW001
            // 
            this.PMW001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMW001.AppearanceCell.Options.UseFont = true;
            this.PMW001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMW001.AppearanceHeader.Options.UseFont = true;
            this.PMW001.Caption = "单号";
            this.PMW001.FieldName = "PMW001";
            this.PMW001.Name = "PMW001";
            this.PMW001.Visible = true;
            this.PMW001.VisibleIndex = 0;
            this.PMW001.Width = 177;
            // 
            // PMW002
            // 
            this.PMW002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMW002.AppearanceCell.Options.UseFont = true;
            this.PMW002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMW002.AppearanceHeader.Options.UseFont = true;
            this.PMW002.Caption = "工段";
            this.PMW002.FieldName = "PMW002";
            this.PMW002.Name = "PMW002";
            this.PMW002.OptionsColumn.AllowEdit = false;
            this.PMW002.Visible = true;
            this.PMW002.VisibleIndex = 1;
            this.PMW002.Width = 125;
            // 
            // PMW004
            // 
            this.PMW004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMW004.AppearanceCell.Options.UseFont = true;
            this.PMW004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMW004.AppearanceHeader.Options.UseFont = true;
            this.PMW004.Caption = "下单日期";
            this.PMW004.FieldName = "PMW004";
            this.PMW004.Name = "PMW004";
            this.PMW004.OptionsColumn.AllowEdit = false;
            this.PMW004.OptionsFilter.AllowAutoFilter = false;
            this.PMW004.Visible = true;
            this.PMW004.VisibleIndex = 2;
            this.PMW004.Width = 223;
            // 
            // PMW003
            // 
            this.PMW003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMW003.AppearanceCell.Options.UseFont = true;
            this.PMW003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMW003.AppearanceHeader.Options.UseFont = true;
            this.PMW003.Caption = "计划日期";
            this.PMW003.FieldName = "PMW003";
            this.PMW003.Name = "PMW003";
            this.PMW003.OptionsColumn.AllowEdit = false;
            this.PMW003.OptionsFilter.AllowAutoFilter = false;
            this.PMW003.Visible = true;
            this.PMW003.VisibleIndex = 3;
            this.PMW003.Width = 225;
            // 
            // PMW010
            // 
            this.PMW010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMW010.AppearanceCell.Options.UseFont = true;
            this.PMW010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMW010.AppearanceHeader.Options.UseFont = true;
            this.PMW010.Caption = "总产值";
            this.PMW010.DisplayFormat.FormatString = "0.####";
            this.PMW010.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PMW010.FieldName = "PMW010";
            this.PMW010.Name = "PMW010";
            this.PMW010.OptionsColumn.AllowEdit = false;
            this.PMW010.OptionsFilter.AllowAutoFilter = false;
            this.PMW010.Visible = true;
            this.PMW010.VisibleIndex = 4;
            this.PMW010.Width = 160;
            // 
            // PMW009
            // 
            this.PMW009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMW009.AppearanceCell.Options.UseFont = true;
            this.PMW009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMW009.AppearanceHeader.Options.UseFont = true;
            this.PMW009.Caption = "完成率";
            this.PMW009.FieldName = "PMW009";
            this.PMW009.Name = "PMW009";
            this.PMW009.OptionsColumn.AllowEdit = false;
            this.PMW009.OptionsFilter.AllowAutoFilter = false;
            this.PMW009.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OPI007", "总产值")});
            this.PMW009.Visible = true;
            this.PMW009.VisibleIndex = 5;
            this.PMW009.Width = 139;
            // 
            // DayPlanMachinWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "DayPlanMachinWork";
            this.Size = new System.Drawing.Size(755, 427);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PMW001;
        private DevExpress . XtraGrid . Columns . GridColumn PMW002;
        private DevExpress . XtraGrid . Columns . GridColumn PMW004;
        private DevExpress . XtraGrid . Columns . GridColumn PMW003;
        private DevExpress . XtraGrid . Columns . GridColumn PMW010;
        private DevExpress . XtraGrid . Columns . GridColumn PMW009;
    }
}
