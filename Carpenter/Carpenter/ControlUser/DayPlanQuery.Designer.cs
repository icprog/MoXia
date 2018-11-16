namespace Carpenter . ControlUser
{
    partial class DayPlanQuery
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PSW001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PSW002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PSW004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PSW003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PSW006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PSW009 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(627, 327);
            this.gridControl1.TabIndex = 2;
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
            this.PSW001,
            this.PSW002,
            this.PSW004,
            this.PSW003,
            this.PSW006,
            this.PSW009});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PSW001
            // 
            this.PSW001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSW001.AppearanceCell.Options.UseFont = true;
            this.PSW001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSW001.AppearanceHeader.Options.UseFont = true;
            this.PSW001.Caption = "单号";
            this.PSW001.FieldName = "PSW001";
            this.PSW001.Name = "PSW001";
            this.PSW001.Visible = true;
            this.PSW001.VisibleIndex = 0;
            this.PSW001.Width = 177;
            // 
            // PSW002
            // 
            this.PSW002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSW002.AppearanceCell.Options.UseFont = true;
            this.PSW002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSW002.AppearanceHeader.Options.UseFont = true;
            this.PSW002.Caption = "工段";
            this.PSW002.FieldName = "PSW002";
            this.PSW002.Name = "PSW002";
            this.PSW002.OptionsColumn.AllowEdit = false;
            this.PSW002.Visible = true;
            this.PSW002.VisibleIndex = 1;
            this.PSW002.Width = 125;
            // 
            // PSW004
            // 
            this.PSW004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSW004.AppearanceCell.Options.UseFont = true;
            this.PSW004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSW004.AppearanceHeader.Options.UseFont = true;
            this.PSW004.Caption = "下单日期";
            this.PSW004.FieldName = "PSW004";
            this.PSW004.Name = "PSW004";
            this.PSW004.OptionsColumn.AllowEdit = false;
            this.PSW004.OptionsFilter.AllowAutoFilter = false;
            this.PSW004.Visible = true;
            this.PSW004.VisibleIndex = 2;
            this.PSW004.Width = 223;
            // 
            // PSW003
            // 
            this.PSW003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSW003.AppearanceCell.Options.UseFont = true;
            this.PSW003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSW003.AppearanceHeader.Options.UseFont = true;
            this.PSW003.Caption = "计划日期";
            this.PSW003.FieldName = "PSW003";
            this.PSW003.Name = "PSW003";
            this.PSW003.OptionsColumn.AllowEdit = false;
            this.PSW003.OptionsFilter.AllowAutoFilter = false;
            this.PSW003.Visible = true;
            this.PSW003.VisibleIndex = 3;
            this.PSW003.Width = 225;
            // 
            // PSW006
            // 
            this.PSW006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSW006.AppearanceCell.Options.UseFont = true;
            this.PSW006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSW006.AppearanceHeader.Options.UseFont = true;
            this.PSW006.Caption = "总产值";
            this.PSW006.DisplayFormat.FormatString = "0.####";
            this.PSW006.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PSW006.FieldName = "PSW006";
            this.PSW006.Name = "PSW006";
            this.PSW006.OptionsColumn.AllowEdit = false;
            this.PSW006.OptionsFilter.AllowAutoFilter = false;
            this.PSW006.Visible = true;
            this.PSW006.VisibleIndex = 4;
            this.PSW006.Width = 160;
            // 
            // PSW009
            // 
            this.PSW009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSW009.AppearanceCell.Options.UseFont = true;
            this.PSW009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PSW009.AppearanceHeader.Options.UseFont = true;
            this.PSW009.Caption = "完成率";
            this.PSW009.FieldName = "PSW009";
            this.PSW009.Name = "PSW009";
            this.PSW009.OptionsColumn.AllowEdit = false;
            this.PSW009.OptionsFilter.AllowAutoFilter = false;
            this.PSW009.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OPI007", "总产值")});
            this.PSW009.Visible = true;
            this.PSW009.VisibleIndex = 5;
            this.PSW009.Width = 139;
            // 
            // DayPlanQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "DayPlanQuery";
            this.Size = new System.Drawing.Size(627, 327);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Columns . GridColumn PSW002;
        private DevExpress . XtraGrid . Columns . GridColumn PSW004;
        private DevExpress . XtraGrid . Columns . GridColumn PSW003;
        private DevExpress . XtraGrid . Columns . GridColumn PSW006;
        private DevExpress . XtraGrid . Columns . GridColumn PSW009;
        private DevExpress . XtraGrid . Columns . GridColumn PSW001;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
    }
}
