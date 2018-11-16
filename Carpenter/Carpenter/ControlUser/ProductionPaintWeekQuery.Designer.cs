namespace Carpenter . ControlUser
{
    partial class ProductionPaintWeekQuery
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
            this.PWG001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWG009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWG003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWG004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWG005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PWH014 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(1168, 444);
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
            this.PWG001,
            this.PWG009,
            this.PWG003,
            this.PWG004,
            this.PWG005,
            this.PWH014});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PWG001
            // 
            this.PWG001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWG001.AppearanceCell.Options.UseFont = true;
            this.PWG001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWG001.AppearanceHeader.Options.UseFont = true;
            this.PWG001.Caption = "单号";
            this.PWG001.FieldName = "PWG001";
            this.PWG001.Name = "PWG001";
            this.PWG001.Visible = true;
            this.PWG001.VisibleIndex = 0;
            this.PWG001.Width = 161;
            // 
            // PWG009
            // 
            this.PWG009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWG009.AppearanceCell.Options.UseFont = true;
            this.PWG009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWG009.AppearanceHeader.Options.UseFont = true;
            this.PWG009.Caption = "周次";
            this.PWG009.FieldName = "PWG009";
            this.PWG009.Name = "PWG009";
            this.PWG009.OptionsColumn.AllowEdit = false;
            this.PWG009.Visible = true;
            this.PWG009.VisibleIndex = 1;
            this.PWG009.Width = 94;
            // 
            // PWG003
            // 
            this.PWG003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWG003.AppearanceCell.Options.UseFont = true;
            this.PWG003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWG003.AppearanceHeader.Options.UseFont = true;
            this.PWG003.Caption = "下单日期";
            this.PWG003.FieldName = "PWG003";
            this.PWG003.Name = "PWG003";
            this.PWG003.OptionsColumn.AllowEdit = false;
            this.PWG003.Visible = true;
            this.PWG003.VisibleIndex = 3;
            this.PWG003.Width = 150;
            // 
            // PWG004
            // 
            this.PWG004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWG004.AppearanceCell.Options.UseFont = true;
            this.PWG004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWG004.AppearanceHeader.Options.UseFont = true;
            this.PWG004.Caption = "开始生产周期";
            this.PWG004.FieldName = "PWG004";
            this.PWG004.Name = "PWG004";
            this.PWG004.OptionsColumn.AllowEdit = false;
            this.PWG004.OptionsFilter.AllowAutoFilter = false;
            this.PWG004.Visible = true;
            this.PWG004.VisibleIndex = 4;
            this.PWG004.Width = 259;
            // 
            // PWG005
            // 
            this.PWG005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWG005.AppearanceCell.Options.UseFont = true;
            this.PWG005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWG005.AppearanceHeader.Options.UseFont = true;
            this.PWG005.Caption = "结束生产周期";
            this.PWG005.FieldName = "PWG005";
            this.PWG005.Name = "PWG005";
            this.PWG005.OptionsColumn.AllowEdit = false;
            this.PWG005.OptionsFilter.AllowAutoFilter = false;
            this.PWG005.Visible = true;
            this.PWG005.VisibleIndex = 5;
            this.PWG005.Width = 268;
            // 
            // PWH014
            // 
            this.PWH014.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH014.AppearanceCell.Options.UseFont = true;
            this.PWH014.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PWH014.AppearanceHeader.Options.UseFont = true;
            this.PWH014.Caption = "总产量";
            this.PWH014.DisplayFormat.FormatString = "N2";
            this.PWH014.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PWH014.FieldName = "PWH014";
            this.PWH014.Name = "PWH014";
            this.PWH014.OptionsColumn.AllowEdit = false;
            this.PWH014.OptionsFilter.AllowAutoFilter = false;
            this.PWH014.Visible = true;
            this.PWH014.VisibleIndex = 2;
            this.PWH014.Width = 117;
            // 
            // ProductionPaintWeekQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "ProductionPaintWeekQuery";
            this.Size = new System.Drawing.Size(1168, 444);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        public DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PWG001;
        private DevExpress . XtraGrid . Columns . GridColumn PWG009;
        private DevExpress . XtraGrid . Columns . GridColumn PWG003;
        private DevExpress . XtraGrid . Columns . GridColumn PWG004;
        private DevExpress . XtraGrid . Columns . GridColumn PWG005;
        private DevExpress . XtraGrid . Columns . GridColumn PWH014;
    }
}
