namespace Carpenter
{
    partial class FormProPartArt
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lupPart = new DevExpress.XtraEditors.LookUpEdit();
            this.lupProduct = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PPA007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PPA001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PPA002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PPA003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PPA004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PPA008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PPA005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PPA006 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupPart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupPart);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupProduct);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1241, 414);
            this.splitContainerControl1.SplitterPosition = 41;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(290, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 45;
            this.labelControl2.Text = "零件信息：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 44;
            this.labelControl1.Text = "产品信息：";
            // 
            // lupPart
            // 
            this.lupPart.Location = new System.Drawing.Point(366, 12);
            this.lupPart.Name = "lupPart";
            this.lupPart.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lupPart.Properties.Appearance.Options.UseFont = true;
            this.lupPart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPart.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PPA003", 60, "零件编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PPA004", 120, "零件名称")});
            this.lupPart.Properties.NullText = "";
            this.lupPart.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupPart.Properties.PopupFormMinSize = new System.Drawing.Size(300, 200);
            this.lupPart.Properties.PopupWidth = 300;
            this.lupPart.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupPart.Properties.ShowHeader = false;
            this.lupPart.Size = new System.Drawing.Size(167, 20);
            this.lupPart.TabIndex = 43;
            // 
            // lupProduct
            // 
            this.lupProduct.Location = new System.Drawing.Point(88, 12);
            this.lupProduct.Name = "lupProduct";
            this.lupProduct.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lupProduct.Properties.Appearance.Options.UseFont = true;
            this.lupProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupProduct.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PPA001", 120, "品号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PPA002", 120, "品名")});
            this.lupProduct.Properties.NullText = "";
            this.lupProduct.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupProduct.Properties.PopupFormMinSize = new System.Drawing.Size(300, 200);
            this.lupProduct.Properties.PopupWidth = 300;
            this.lupProduct.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupProduct.Properties.ShowHeader = false;
            this.lupProduct.Size = new System.Drawing.Size(167, 20);
            this.lupProduct.TabIndex = 42;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1241, 361);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PPA007,
            this.PPA001,
            this.PPA002,
            this.PPA003,
            this.PPA004,
            this.PPA008,
            this.PPA005,
            this.PPA006});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // PPA007
            // 
            this.PPA007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA007.AppearanceCell.Options.UseFont = true;
            this.PPA007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA007.AppearanceHeader.Options.UseFont = true;
            this.PPA007.Caption = "条码";
            this.PPA007.FieldName = "PPA007";
            this.PPA007.Name = "PPA007";
            this.PPA007.Visible = true;
            this.PPA007.VisibleIndex = 0;
            // 
            // PPA001
            // 
            this.PPA001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA001.AppearanceCell.Options.UseFont = true;
            this.PPA001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA001.AppearanceHeader.Options.UseFont = true;
            this.PPA001.Caption = "品号";
            this.PPA001.FieldName = "PPA001";
            this.PPA001.Name = "PPA001";
            this.PPA001.Visible = true;
            this.PPA001.VisibleIndex = 1;
            // 
            // PPA002
            // 
            this.PPA002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA002.AppearanceCell.Options.UseFont = true;
            this.PPA002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA002.AppearanceHeader.Options.UseFont = true;
            this.PPA002.Caption = "品名";
            this.PPA002.FieldName = "PPA002";
            this.PPA002.Name = "PPA002";
            this.PPA002.Visible = true;
            this.PPA002.VisibleIndex = 2;
            // 
            // PPA003
            // 
            this.PPA003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA003.AppearanceCell.Options.UseFont = true;
            this.PPA003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA003.AppearanceHeader.Options.UseFont = true;
            this.PPA003.Caption = "零件编号";
            this.PPA003.FieldName = "PPA003";
            this.PPA003.Name = "PPA003";
            this.PPA003.Visible = true;
            this.PPA003.VisibleIndex = 3;
            // 
            // PPA004
            // 
            this.PPA004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA004.AppearanceCell.Options.UseFont = true;
            this.PPA004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA004.AppearanceHeader.Options.UseFont = true;
            this.PPA004.Caption = "零件名称";
            this.PPA004.FieldName = "PPA004";
            this.PPA004.Name = "PPA004";
            this.PPA004.Visible = true;
            this.PPA004.VisibleIndex = 4;
            // 
            // PPA008
            // 
            this.PPA008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA008.AppearanceCell.Options.UseFont = true;
            this.PPA008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA008.AppearanceHeader.Options.UseFont = true;
            this.PPA008.Caption = "零件规格";
            this.PPA008.FieldName = "PPA008";
            this.PPA008.Name = "PPA008";
            this.PPA008.Visible = true;
            this.PPA008.VisibleIndex = 5;
            // 
            // PPA005
            // 
            this.PPA005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA005.AppearanceCell.Options.UseFont = true;
            this.PPA005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA005.AppearanceHeader.Options.UseFont = true;
            this.PPA005.Caption = "工序序号";
            this.PPA005.FieldName = "PPA005";
            this.PPA005.Name = "PPA005";
            this.PPA005.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PPA005.Visible = true;
            this.PPA005.VisibleIndex = 6;
            // 
            // PPA006
            // 
            this.PPA006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA006.AppearanceCell.Options.UseFont = true;
            this.PPA006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PPA006.AppearanceHeader.Options.UseFont = true;
            this.PPA006.Caption = "工序名称";
            this.PPA006.FieldName = "PPA006";
            this.PPA006.Name = "PPA006";
            this.PPA006.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PPA006.Visible = true;
            this.PPA006.VisibleIndex = 7;
            // 
            // FormProPartArt
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 440);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormProPartArt";
            this.Text = "产品部件工序表";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lupPart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PPA001;
        private DevExpress . XtraGrid . Columns . GridColumn PPA002;
        private DevExpress . XtraGrid . Columns . GridColumn PPA003;
        private DevExpress . XtraGrid . Columns . GridColumn PPA004;
        private DevExpress . XtraGrid . Columns . GridColumn PPA005;
        private DevExpress . XtraGrid . Columns . GridColumn PPA006;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LookUpEdit lupPart;
        private DevExpress . XtraEditors . LookUpEdit lupProduct;
        private DevExpress . XtraGrid . Columns . GridColumn PPA007;
        private DevExpress . XtraGrid . Columns . GridColumn PPA008;
    }
}