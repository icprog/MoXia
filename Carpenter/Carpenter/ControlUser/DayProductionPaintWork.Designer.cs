namespace Carpenter . ControlUser
{
    partial class DayProductionPaintWork
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
            this.PWD001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWD002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWD003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWD004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWD010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWD009 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(1253, 509);
            this.gridControl1.TabIndex = 5;
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
            this.PWD001,
            this.PWD002,
            this.PWD003,
            this.PWD004,
            this.PWD010,
            this.PWD009});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PWD001
            // 
            this.PWD001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWD001.AppearanceCell.Options.UseFont = true;
            this.PWD001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWD001.AppearanceHeader.Options.UseFont = true;
            this.PWD001.Caption = "单号";
            this.PWD001.FieldName = "PWD001";
            this.PWD001.Name = "PWD001";
            this.PWD001.Visible = true;
            this.PWD001.VisibleIndex = 0;
            this.PWD001.Width = 177;
            // 
            // PWD002
            // 
            this.PWD002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWD002.AppearanceCell.Options.UseFont = true;
            this.PWD002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWD002.AppearanceHeader.Options.UseFont = true;
            this.PWD002.Caption = "工段";
            this.PWD002.FieldName = "PWD002";
            this.PWD002.Name = "PWD002";
            this.PWD002.OptionsColumn.AllowEdit = false;
            this.PWD002.Visible = true;
            this.PWD002.VisibleIndex = 1;
            this.PWD002.Width = 125;
            // 
            // PWD003
            // 
            this.PWD003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWD003.AppearanceCell.Options.UseFont = true;
            this.PWD003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWD003.AppearanceHeader.Options.UseFont = true;
            this.PWD003.Caption = "下单日期";
            this.PWD003.FieldName = "PWD003";
            this.PWD003.Name = "PWD003";
            this.PWD003.OptionsColumn.AllowEdit = false;
            this.PWD003.OptionsFilter.AllowAutoFilter = false;
            this.PWD003.Visible = true;
            this.PWD003.VisibleIndex = 2;
            this.PWD003.Width = 223;
            // 
            // PWD004
            // 
            this.PWD004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWD004.AppearanceCell.Options.UseFont = true;
            this.PWD004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWD004.AppearanceHeader.Options.UseFont = true;
            this.PWD004.Caption = "计划日期";
            this.PWD004.FieldName = "PWD004";
            this.PWD004.Name = "PWD004";
            this.PWD004.OptionsColumn.AllowEdit = false;
            this.PWD004.OptionsFilter.AllowAutoFilter = false;
            this.PWD004.Visible = true;
            this.PWD004.VisibleIndex = 3;
            this.PWD004.Width = 225;
            // 
            // PWD010
            // 
            this.PWD010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWD010.AppearanceCell.Options.UseFont = true;
            this.PWD010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWD010.AppearanceHeader.Options.UseFont = true;
            this.PWD010.Caption = "总产值";
            this.PWD010.DisplayFormat.FormatString = "0.####";
            this.PWD010.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PWD010.FieldName = "PWD010";
            this.PWD010.Name = "PWD010";
            this.PWD010.OptionsColumn.AllowEdit = false;
            this.PWD010.OptionsFilter.AllowAutoFilter = false;
            this.PWD010.Visible = true;
            this.PWD010.VisibleIndex = 4;
            this.PWD010.Width = 160;
            // 
            // PWD009
            // 
            this.PWD009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWD009.AppearanceCell.Options.UseFont = true;
            this.PWD009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWD009.AppearanceHeader.Options.UseFont = true;
            this.PWD009.Caption = "完成率";
            this.PWD009.FieldName = "PWD009";
            this.PWD009.Name = "PWD009";
            this.PWD009.OptionsColumn.AllowEdit = false;
            this.PWD009.OptionsFilter.AllowAutoFilter = false;
            this.PWD009.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OPI007", "总产值")});
            this.PWD009.Visible = true;
            this.PWD009.VisibleIndex = 5;
            this.PWD009.Width = 139;
            // 
            // DayProductionPaintWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "DayProductionPaintWork";
            this.Size = new System.Drawing.Size(1253, 509);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PWD001;
        private DevExpress . XtraGrid . Columns . GridColumn PWD002;
        private DevExpress . XtraGrid . Columns . GridColumn PWD003;
        private DevExpress . XtraGrid . Columns . GridColumn PWD004;
        private DevExpress . XtraGrid . Columns . GridColumn PWD010;
        private DevExpress . XtraGrid . Columns . GridColumn PWD009;
    }
}
