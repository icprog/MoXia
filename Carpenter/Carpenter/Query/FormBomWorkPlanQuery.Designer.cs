namespace Carpenter . Query
{
    partial class FormBomWorkPlanQuery
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1242, 483);
            this.panel1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.gridControl1.EmbeddedNavigator.AllowDrop = true;
            this.gridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.gridControl1.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridControl1.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gridControl1.EmbeddedNavigator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridControl1.EmbeddedNavigator.CausesValidation = false;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(35, 35, 35, 35);
            this.gridControl1.EmbeddedNavigator.MaximumSize = new System.Drawing.Size(1167, 35);
            this.gridControl1.EmbeddedNavigator.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.gridControl1.EmbeddedNavigator.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1242, 483);
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
            this.idx,
            this.OPI001,
            this.OPI002,
            this.OPI003,
            this.OPI004,
            this.OPI005,
            this.OPI006,
            this.OPI007,
            this.OPI008,
            this.OPI009,
            this.OPI010});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // OPI001
            // 
            this.OPI001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI001.AppearanceCell.Options.UseFont = true;
            this.OPI001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI001.AppearanceHeader.Options.UseFont = true;
            this.OPI001.Caption = "品号";
            this.OPI001.FieldName = "OPI001";
            this.OPI001.Name = "OPI001";
            this.OPI001.Visible = true;
            this.OPI001.VisibleIndex = 0;
            this.OPI001.Width = 88;
            // 
            // OPI002
            // 
            this.OPI002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI002.AppearanceCell.Options.UseFont = true;
            this.OPI002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI002.AppearanceHeader.Options.UseFont = true;
            this.OPI002.Caption = "产品名称";
            this.OPI002.FieldName = "OPI002";
            this.OPI002.Name = "OPI002";
            this.OPI002.Visible = true;
            this.OPI002.VisibleIndex = 1;
            this.OPI002.Width = 118;
            // 
            // OPI003
            // 
            this.OPI003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI003.AppearanceCell.Options.UseFont = true;
            this.OPI003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI003.AppearanceHeader.Options.UseFont = true;
            this.OPI003.Caption = "产品类别";
            this.OPI003.FieldName = "OPI003";
            this.OPI003.Name = "OPI003";
            this.OPI003.Visible = true;
            this.OPI003.VisibleIndex = 2;
            this.OPI003.Width = 84;
            // 
            // OPI004
            // 
            this.OPI004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI004.AppearanceCell.Options.UseFont = true;
            this.OPI004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI004.AppearanceHeader.Options.UseFont = true;
            this.OPI004.Caption = "产值";
            this.OPI004.FieldName = "OPI004";
            this.OPI004.Name = "OPI004";
            this.OPI004.Visible = true;
            this.OPI004.VisibleIndex = 3;
            this.OPI004.Width = 84;
            // 
            // OPI005
            // 
            this.OPI005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI005.AppearanceCell.Options.UseFont = true;
            this.OPI005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI005.AppearanceHeader.Options.UseFont = true;
            this.OPI005.Caption = "规格";
            this.OPI005.FieldName = "OPI005";
            this.OPI005.Name = "OPI005";
            this.OPI005.Visible = true;
            this.OPI005.VisibleIndex = 4;
            this.OPI005.Width = 100;
            // 
            // OPI006
            // 
            this.OPI006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI006.AppearanceCell.Options.UseFont = true;
            this.OPI006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI006.AppearanceHeader.Options.UseFont = true;
            this.OPI006.Caption = "颜色";
            this.OPI006.FieldName = "OPI006";
            this.OPI006.Name = "OPI006";
            this.OPI006.Visible = true;
            this.OPI006.VisibleIndex = 5;
            this.OPI006.Width = 82;
            // 
            // OPI007
            // 
            this.OPI007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI007.AppearanceCell.Options.UseFont = true;
            this.OPI007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI007.AppearanceHeader.Options.UseFont = true;
            this.OPI007.Caption = "单位";
            this.OPI007.FieldName = "OPI007";
            this.OPI007.Name = "OPI007";
            this.OPI007.Visible = true;
            this.OPI007.VisibleIndex = 6;
            this.OPI007.Width = 82;
            // 
            // OPI008
            // 
            this.OPI008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI008.AppearanceCell.Options.UseFont = true;
            this.OPI008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI008.AppearanceHeader.Options.UseFont = true;
            this.OPI008.Caption = "状态";
            this.OPI008.FieldName = "OPI008";
            this.OPI008.Name = "OPI008";
            this.OPI008.Visible = true;
            this.OPI008.VisibleIndex = 7;
            this.OPI008.Width = 82;
            // 
            // OPI009
            // 
            this.OPI009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI009.AppearanceCell.Options.UseFont = true;
            this.OPI009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI009.AppearanceHeader.Options.UseFont = true;
            this.OPI009.Caption = "属性";
            this.OPI009.FieldName = "OPI009";
            this.OPI009.Name = "OPI009";
            this.OPI009.Visible = true;
            this.OPI009.VisibleIndex = 8;
            this.OPI009.Width = 82;
            // 
            // OPI010
            // 
            this.OPI010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI010.AppearanceCell.Options.UseFont = true;
            this.OPI010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI010.AppearanceHeader.Options.UseFont = true;
            this.OPI010.Caption = "分类";
            this.OPI010.FieldName = "OPI010";
            this.OPI010.Name = "OPI010";
            this.OPI010.Visible = true;
            this.OPI010.VisibleIndex = 9;
            this.OPI010.Width = 82;
            // 
            // FormBomWorkPlanQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 483);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBomWorkPlanQuery";
            this.Text = "";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System . Windows . Forms . Panel panel1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn OPI001;
        private DevExpress . XtraGrid . Columns . GridColumn OPI002;
        private DevExpress . XtraGrid . Columns . GridColumn OPI003;
        private DevExpress . XtraGrid . Columns . GridColumn OPI004;
        private DevExpress . XtraGrid . Columns . GridColumn OPI005;
        private DevExpress . XtraGrid . Columns . GridColumn OPI006;
        private DevExpress . XtraGrid . Columns . GridColumn OPI007;
        private DevExpress . XtraGrid . Columns . GridColumn OPI008;
        private DevExpress . XtraGrid . Columns . GridColumn OPI009;
        private DevExpress . XtraGrid . Columns . GridColumn OPI010;
    }
}