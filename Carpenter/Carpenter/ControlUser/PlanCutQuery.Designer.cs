namespace Carpenter . ControlUser
{
    partial class PlanCutQuery
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
            this.CUT001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUT002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUT003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUT004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUT007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUT008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUT009 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridControl1.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(662, 275);
            this.gridControl1.TabIndex = 1;
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
            this.CUT001,
            this.CUT002,
            this.CUT003,
            this.CUT004,
            this.CUT007,
            this.CUT008,
            this.CUT009});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // CUT001
            // 
            this.CUT001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUT001.AppearanceCell.Options.UseFont = true;
            this.CUT001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUT001.AppearanceHeader.Options.UseFont = true;
            this.CUT001.Caption = "生产批号";
            this.CUT001.FieldName = "CUT001";
            this.CUT001.Name = "CUT001";
            this.CUT001.Visible = true;
            this.CUT001.VisibleIndex = 0;
            this.CUT001.Width = 116;
            // 
            // CUT002
            // 
            this.CUT002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUT002.AppearanceCell.Options.UseFont = true;
            this.CUT002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUT002.AppearanceHeader.Options.UseFont = true;
            this.CUT002.Caption = "下单日期";
            this.CUT002.FieldName = "CUT002";
            this.CUT002.Name = "CUT002";
            this.CUT002.OptionsColumn.AllowEdit = false;
            this.CUT002.Visible = true;
            this.CUT002.VisibleIndex = 1;
            this.CUT002.Width = 159;
            // 
            // CUT003
            // 
            this.CUT003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUT003.AppearanceCell.Options.UseFont = true;
            this.CUT003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUT003.AppearanceHeader.Options.UseFont = true;
            this.CUT003.Caption = "下单生产开始日期";
            this.CUT003.FieldName = "CUT003";
            this.CUT003.Name = "CUT003";
            this.CUT003.OptionsColumn.AllowEdit = false;
            this.CUT003.Visible = true;
            this.CUT003.VisibleIndex = 2;
            this.CUT003.Width = 186;
            // 
            // CUT004
            // 
            this.CUT004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUT004.AppearanceCell.Options.UseFont = true;
            this.CUT004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUT004.AppearanceHeader.Options.UseFont = true;
            this.CUT004.Caption = "下单生产结束日期";
            this.CUT004.FieldName = "CUT004";
            this.CUT004.Name = "CUT004";
            this.CUT004.OptionsColumn.AllowEdit = false;
            this.CUT004.Visible = true;
            this.CUT004.VisibleIndex = 3;
            this.CUT004.Width = 171;
            // 
            // CUT007
            // 
            this.CUT007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUT007.AppearanceCell.Options.UseFont = true;
            this.CUT007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUT007.AppearanceHeader.Options.UseFont = true;
            this.CUT007.Caption = "注销";
            this.CUT007.FieldName = "CUT007";
            this.CUT007.Name = "CUT007";
            this.CUT007.OptionsColumn.AllowEdit = false;
            this.CUT007.Visible = true;
            this.CUT007.VisibleIndex = 5;
            this.CUT007.Width = 119;
            // 
            // CUT008
            // 
            this.CUT008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUT008.AppearanceCell.Options.UseFont = true;
            this.CUT008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUT008.AppearanceHeader.Options.UseFont = true;
            this.CUT008.Caption = "审核";
            this.CUT008.FieldName = "CUT008";
            this.CUT008.Name = "CUT008";
            this.CUT008.OptionsColumn.AllowEdit = false;
            this.CUT008.Visible = true;
            this.CUT008.VisibleIndex = 6;
            this.CUT008.Width = 104;
            // 
            // CUT009
            // 
            this.CUT009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUT009.AppearanceCell.Options.UseFont = true;
            this.CUT009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUT009.AppearanceHeader.Options.UseFont = true;
            this.CUT009.Caption = "总产值";
            this.CUT009.DisplayFormat.FormatString = "N2";
            this.CUT009.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CUT009.FieldName = "CUT009";
            this.CUT009.Name = "CUT009";
            this.CUT009.OptionsColumn.AllowEdit = false;
            this.CUT009.Visible = true;
            this.CUT009.VisibleIndex = 4;
            this.CUT009.Width = 194;
            // 
            // PlanCutQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gridControl1);
            this.Name = "PlanCutQuery";
            this.Size = new System.Drawing.Size(662, 275);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress . XtraGrid . Columns . GridColumn CUT001;
        private DevExpress . XtraGrid . Columns . GridColumn CUT002;
        private DevExpress . XtraGrid . Columns . GridColumn CUT003;
        private DevExpress . XtraGrid . Columns . GridColumn CUT004;
        private DevExpress . XtraGrid . Columns . GridColumn CUT007;
        private DevExpress . XtraGrid . Columns . GridColumn CUT008;
        private DevExpress . XtraGrid . Columns . GridColumn CUT009;
        private DevExpress . XtraGrid . GridControl gridControl1;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
    }
}
