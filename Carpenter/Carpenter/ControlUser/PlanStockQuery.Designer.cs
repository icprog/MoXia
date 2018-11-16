namespace Carpenter . ControlUser
{
    partial class PlanStockQuery
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
            this.PLS001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLS002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLS003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLS004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLS005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLS006 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(484, 271);
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
            this.PLS001,
            this.PLS002,
            this.PLS003,
            this.PLS004,
            this.PLS005,
            this.PLS006});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PLS001
            // 
            this.PLS001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLS001.AppearanceCell.Options.UseFont = true;
            this.PLS001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLS001.AppearanceHeader.Options.UseFont = true;
            this.PLS001.Caption = "单号";
            this.PLS001.FieldName = "PLS001";
            this.PLS001.Name = "PLS001";
            this.PLS001.Visible = true;
            this.PLS001.VisibleIndex = 0;
            this.PLS001.Width = 161;
            // 
            // PLS002
            // 
            this.PLS002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLS002.AppearanceCell.Options.UseFont = true;
            this.PLS002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLS002.AppearanceHeader.Options.UseFont = true;
            this.PLS002.Caption = "周次";
            this.PLS002.FieldName = "PLS002";
            this.PLS002.Name = "PLS002";
            this.PLS002.OptionsColumn.AllowEdit = false;
            this.PLS002.Visible = true;
            this.PLS002.VisibleIndex = 1;
            this.PLS002.Width = 94;
            // 
            // PLS003
            // 
            this.PLS003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLS003.AppearanceCell.Options.UseFont = true;
            this.PLS003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLS003.AppearanceHeader.Options.UseFont = true;
            this.PLS003.Caption = "下单日期";
            this.PLS003.FieldName = "PLS003";
            this.PLS003.Name = "PLS003";
            this.PLS003.OptionsColumn.AllowEdit = false;
            this.PLS003.Visible = true;
            this.PLS003.VisibleIndex = 3;
            this.PLS003.Width = 150;
            // 
            // PLS004
            // 
            this.PLS004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLS004.AppearanceCell.Options.UseFont = true;
            this.PLS004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLS004.AppearanceHeader.Options.UseFont = true;
            this.PLS004.Caption = "开始生产周期";
            this.PLS004.FieldName = "PLS004";
            this.PLS004.Name = "PLS004";
            this.PLS004.OptionsColumn.AllowEdit = false;
            this.PLS004.OptionsFilter.AllowAutoFilter = false;
            this.PLS004.Visible = true;
            this.PLS004.VisibleIndex = 4;
            this.PLS004.Width = 259;
            // 
            // PLS005
            // 
            this.PLS005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLS005.AppearanceCell.Options.UseFont = true;
            this.PLS005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLS005.AppearanceHeader.Options.UseFont = true;
            this.PLS005.Caption = "结束生产周期";
            this.PLS005.FieldName = "PLS005";
            this.PLS005.Name = "PLS005";
            this.PLS005.OptionsColumn.AllowEdit = false;
            this.PLS005.OptionsFilter.AllowAutoFilter = false;
            this.PLS005.Visible = true;
            this.PLS005.VisibleIndex = 5;
            this.PLS005.Width = 268;
            // 
            // PLS006
            // 
            this.PLS006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLS006.AppearanceCell.Options.UseFont = true;
            this.PLS006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLS006.AppearanceHeader.Options.UseFont = true;
            this.PLS006.Caption = "总产量";
            this.PLS006.DisplayFormat.FormatString = "0.####";
            this.PLS006.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PLS006.FieldName = "PLS006";
            this.PLS006.Name = "PLS006";
            this.PLS006.OptionsColumn.AllowEdit = false;
            this.PLS006.OptionsFilter.AllowAutoFilter = false;
            this.PLS006.Visible = true;
            this.PLS006.VisibleIndex = 2;
            this.PLS006.Width = 117;
            // 
            // PlanStockQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gridControl1);
            this.Name = "PlanStockQuery";
            this.Size = new System.Drawing.Size(484, 271);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Columns . GridColumn PLS001;
        private DevExpress . XtraGrid . Columns . GridColumn PLS002;
        private DevExpress . XtraGrid . Columns . GridColumn PLS003;
        private DevExpress . XtraGrid . Columns . GridColumn PLS004;
        private DevExpress . XtraGrid . Columns . GridColumn PLS005;
        private DevExpress . XtraGrid . Columns . GridColumn PLS006;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
    }
}
