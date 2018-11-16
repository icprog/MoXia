namespace Carpenter . ControlUser
{
    partial class DayPlanAssemebleWork
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
            this.PLD001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLD002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLD003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLD004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLD010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLD009 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(1076, 466);
            this.gridControl1.TabIndex = 4;
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
            this.PLD001,
            this.PLD002,
            this.PLD003,
            this.PLD004,
            this.PLD010,
            this.PLD009});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PLD001
            // 
            this.PLD001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLD001.AppearanceCell.Options.UseFont = true;
            this.PLD001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLD001.AppearanceHeader.Options.UseFont = true;
            this.PLD001.Caption = "单号";
            this.PLD001.FieldName = "PLD001";
            this.PLD001.Name = "PLD001";
            this.PLD001.Visible = true;
            this.PLD001.VisibleIndex = 0;
            this.PLD001.Width = 177;
            // 
            // PLD002
            // 
            this.PLD002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLD002.AppearanceCell.Options.UseFont = true;
            this.PLD002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLD002.AppearanceHeader.Options.UseFont = true;
            this.PLD002.Caption = "工段";
            this.PLD002.FieldName = "PLD002";
            this.PLD002.Name = "PLD002";
            this.PLD002.OptionsColumn.AllowEdit = false;
            this.PLD002.Visible = true;
            this.PLD002.VisibleIndex = 1;
            this.PLD002.Width = 125;
            // 
            // PLD003
            // 
            this.PLD003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLD003.AppearanceCell.Options.UseFont = true;
            this.PLD003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLD003.AppearanceHeader.Options.UseFont = true;
            this.PLD003.Caption = "下单日期";
            this.PLD003.FieldName = "PLD003";
            this.PLD003.Name = "PLD003";
            this.PLD003.OptionsColumn.AllowEdit = false;
            this.PLD003.OptionsFilter.AllowAutoFilter = false;
            this.PLD003.Visible = true;
            this.PLD003.VisibleIndex = 2;
            this.PLD003.Width = 223;
            // 
            // PLD004
            // 
            this.PLD004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLD004.AppearanceCell.Options.UseFont = true;
            this.PLD004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLD004.AppearanceHeader.Options.UseFont = true;
            this.PLD004.Caption = "计划日期";
            this.PLD004.FieldName = "PLD004";
            this.PLD004.Name = "PLD004";
            this.PLD004.OptionsColumn.AllowEdit = false;
            this.PLD004.OptionsFilter.AllowAutoFilter = false;
            this.PLD004.Visible = true;
            this.PLD004.VisibleIndex = 3;
            this.PLD004.Width = 225;
            // 
            // PLD010
            // 
            this.PLD010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLD010.AppearanceCell.Options.UseFont = true;
            this.PLD010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLD010.AppearanceHeader.Options.UseFont = true;
            this.PLD010.Caption = "总产值";
            this.PLD010.DisplayFormat.FormatString = "0.####";
            this.PLD010.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PLD010.FieldName = "PLD010";
            this.PLD010.Name = "PLD010";
            this.PLD010.OptionsColumn.AllowEdit = false;
            this.PLD010.OptionsFilter.AllowAutoFilter = false;
            this.PLD010.Visible = true;
            this.PLD010.VisibleIndex = 4;
            this.PLD010.Width = 160;
            // 
            // PLD009
            // 
            this.PLD009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLD009.AppearanceCell.Options.UseFont = true;
            this.PLD009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLD009.AppearanceHeader.Options.UseFont = true;
            this.PLD009.Caption = "完成率";
            this.PLD009.FieldName = "PLD009";
            this.PLD009.Name = "PLD009";
            this.PLD009.OptionsColumn.AllowEdit = false;
            this.PLD009.OptionsFilter.AllowAutoFilter = false;
            this.PLD009.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OPI007", "总产值")});
            this.PLD009.Visible = true;
            this.PLD009.VisibleIndex = 5;
            this.PLD009.Width = 139;
            // 
            // DayPlanAssemebleWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "DayPlanAssemebleWork";
            this.Size = new System.Drawing.Size(1076, 466);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PLD001;
        private DevExpress . XtraGrid . Columns . GridColumn PLD002;
        private DevExpress . XtraGrid . Columns . GridColumn PLD003;
        private DevExpress . XtraGrid . Columns . GridColumn PLD004;
        private DevExpress . XtraGrid . Columns . GridColumn PLD010;
        private DevExpress . XtraGrid . Columns . GridColumn PLD009;
    }
}
