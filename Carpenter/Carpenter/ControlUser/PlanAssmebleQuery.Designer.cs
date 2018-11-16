namespace Carpenter . ControlUser
{
    partial class PlanAssmebleQuery
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
            this.PLA001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLA009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLA003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLA004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLA005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLB014 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(826, 305);
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
            this.PLA001,
            this.PLA009,
            this.PLA003,
            this.PLA004,
            this.PLA005,
            this.PLB014});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PLA001
            // 
            this.PLA001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLA001.AppearanceCell.Options.UseFont = true;
            this.PLA001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLA001.AppearanceHeader.Options.UseFont = true;
            this.PLA001.Caption = "单号";
            this.PLA001.FieldName = "PLA001";
            this.PLA001.Name = "PLA001";
            this.PLA001.Visible = true;
            this.PLA001.VisibleIndex = 0;
            this.PLA001.Width = 161;
            // 
            // PLA009
            // 
            this.PLA009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLA009.AppearanceCell.Options.UseFont = true;
            this.PLA009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLA009.AppearanceHeader.Options.UseFont = true;
            this.PLA009.Caption = "周次";
            this.PLA009.FieldName = "PLA009";
            this.PLA009.Name = "PLA009";
            this.PLA009.OptionsColumn.AllowEdit = false;
            this.PLA009.Visible = true;
            this.PLA009.VisibleIndex = 1;
            this.PLA009.Width = 94;
            // 
            // PLA003
            // 
            this.PLA003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLA003.AppearanceCell.Options.UseFont = true;
            this.PLA003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLA003.AppearanceHeader.Options.UseFont = true;
            this.PLA003.Caption = "下单日期";
            this.PLA003.FieldName = "PLA003";
            this.PLA003.Name = "PLA003";
            this.PLA003.OptionsColumn.AllowEdit = false;
            this.PLA003.Visible = true;
            this.PLA003.VisibleIndex = 3;
            this.PLA003.Width = 150;
            // 
            // PLA004
            // 
            this.PLA004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLA004.AppearanceCell.Options.UseFont = true;
            this.PLA004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLA004.AppearanceHeader.Options.UseFont = true;
            this.PLA004.Caption = "开始生产周期";
            this.PLA004.FieldName = "PLA004";
            this.PLA004.Name = "PLA004";
            this.PLA004.OptionsColumn.AllowEdit = false;
            this.PLA004.OptionsFilter.AllowAutoFilter = false;
            this.PLA004.Visible = true;
            this.PLA004.VisibleIndex = 4;
            this.PLA004.Width = 259;
            // 
            // PLA005
            // 
            this.PLA005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLA005.AppearanceCell.Options.UseFont = true;
            this.PLA005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLA005.AppearanceHeader.Options.UseFont = true;
            this.PLA005.Caption = "结束生产周期";
            this.PLA005.FieldName = "PLA005";
            this.PLA005.Name = "PLA005";
            this.PLA005.OptionsColumn.AllowEdit = false;
            this.PLA005.OptionsFilter.AllowAutoFilter = false;
            this.PLA005.Visible = true;
            this.PLA005.VisibleIndex = 5;
            this.PLA005.Width = 268;
            // 
            // PLB014
            // 
            this.PLB014.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB014.AppearanceCell.Options.UseFont = true;
            this.PLB014.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PLB014.AppearanceHeader.Options.UseFont = true;
            this.PLB014.Caption = "总产量";
            this.PLB014.DisplayFormat.FormatString = "0.####";
            this.PLB014.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PLB014.FieldName = "PLB014";
            this.PLB014.Name = "PLB014";
            this.PLB014.OptionsColumn.AllowEdit = false;
            this.PLB014.OptionsFilter.AllowAutoFilter = false;
            this.PLB014.Visible = true;
            this.PLB014.VisibleIndex = 2;
            this.PLB014.Width = 117;
            // 
            // PlanAssmebleQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "PlanAssmebleQuery";
            this.Size = new System.Drawing.Size(826, 305);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PLA001;
        private DevExpress . XtraGrid . Columns . GridColumn PLA009;
        private DevExpress . XtraGrid . Columns . GridColumn PLA003;
        private DevExpress . XtraGrid . Columns . GridColumn PLA004;
        private DevExpress . XtraGrid . Columns . GridColumn PLA005;
        private DevExpress . XtraGrid . Columns . GridColumn PLB014;
    }
}
