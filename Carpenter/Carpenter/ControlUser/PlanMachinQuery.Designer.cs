namespace Carpenter . ControlUser
{
    partial class PlanMachinQuery
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
            this.PMC001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMC009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMC003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMC004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMC005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PMD007 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(799, 285);
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
            this.PMC001,
            this.PMC009,
            this.PMC003,
            this.PMC004,
            this.PMC005,
            this.PMD007});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PMC001
            // 
            this.PMC001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMC001.AppearanceCell.Options.UseFont = true;
            this.PMC001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMC001.AppearanceHeader.Options.UseFont = true;
            this.PMC001.Caption = "单号";
            this.PMC001.FieldName = "PMC001";
            this.PMC001.Name = "PMC001";
            this.PMC001.Visible = true;
            this.PMC001.VisibleIndex = 0;
            this.PMC001.Width = 161;
            // 
            // PMC009
            // 
            this.PMC009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMC009.AppearanceCell.Options.UseFont = true;
            this.PMC009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMC009.AppearanceHeader.Options.UseFont = true;
            this.PMC009.Caption = "周次";
            this.PMC009.FieldName = "PMC009";
            this.PMC009.Name = "PMC009";
            this.PMC009.OptionsColumn.AllowEdit = false;
            this.PMC009.Visible = true;
            this.PMC009.VisibleIndex = 1;
            this.PMC009.Width = 94;
            // 
            // PMC003
            // 
            this.PMC003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMC003.AppearanceCell.Options.UseFont = true;
            this.PMC003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMC003.AppearanceHeader.Options.UseFont = true;
            this.PMC003.Caption = "下单日期";
            this.PMC003.FieldName = "PMC003";
            this.PMC003.Name = "PMC003";
            this.PMC003.OptionsColumn.AllowEdit = false;
            this.PMC003.Visible = true;
            this.PMC003.VisibleIndex = 3;
            this.PMC003.Width = 150;
            // 
            // PMC004
            // 
            this.PMC004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMC004.AppearanceCell.Options.UseFont = true;
            this.PMC004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMC004.AppearanceHeader.Options.UseFont = true;
            this.PMC004.Caption = "开始生产周期";
            this.PMC004.FieldName = "PMC004";
            this.PMC004.Name = "PMC004";
            this.PMC004.OptionsColumn.AllowEdit = false;
            this.PMC004.OptionsFilter.AllowAutoFilter = false;
            this.PMC004.Visible = true;
            this.PMC004.VisibleIndex = 4;
            this.PMC004.Width = 259;
            // 
            // PMC005
            // 
            this.PMC005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMC005.AppearanceCell.Options.UseFont = true;
            this.PMC005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMC005.AppearanceHeader.Options.UseFont = true;
            this.PMC005.Caption = "结束生产周期";
            this.PMC005.FieldName = "PMC005";
            this.PMC005.Name = "PMC005";
            this.PMC005.OptionsColumn.AllowEdit = false;
            this.PMC005.OptionsFilter.AllowAutoFilter = false;
            this.PMC005.Visible = true;
            this.PMC005.VisibleIndex = 5;
            this.PMC005.Width = 268;
            // 
            // PMD007
            // 
            this.PMD007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD007.AppearanceCell.Options.UseFont = true;
            this.PMD007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PMD007.AppearanceHeader.Options.UseFont = true;
            this.PMD007.Caption = "总产量";
            this.PMD007.DisplayFormat.FormatString = "0.####";
            this.PMD007.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PMD007.FieldName = "PMD007";
            this.PMD007.Name = "PMD007";
            this.PMD007.OptionsColumn.AllowEdit = false;
            this.PMD007.OptionsFilter.AllowAutoFilter = false;
            this.PMD007.Visible = true;
            this.PMD007.VisibleIndex = 2;
            this.PMD007.Width = 117;
            // 
            // PlanMachinQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "PlanMachinQuery";
            this.Size = new System.Drawing.Size(799, 285);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PMC001;
        private DevExpress . XtraGrid . Columns . GridColumn PMC009;
        private DevExpress . XtraGrid . Columns . GridColumn PMC003;
        private DevExpress . XtraGrid . Columns . GridColumn PMC004;
        private DevExpress . XtraGrid . Columns . GridColumn PMC005;
        private DevExpress . XtraGrid . Columns . GridColumn PMD007;
    }
}
