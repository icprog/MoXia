namespace Carpenter
{
    partial class FormProductScheduleTrackTable
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
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.lupBat = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.luPro = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PRD007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRD008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRD009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUU003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRD011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRD034 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WPC016 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WPC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRD003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRD013 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.PRD004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRD005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRD019 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupBat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luPro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.btnClear);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupBat);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.luPro);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1240, 408);
            this.splitContainerControl1.SplitterPosition = 49;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.Location = new System.Drawing.Point(498, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lupBat
            // 
            this.lupBat.Location = new System.Drawing.Point(351, 13);
            this.lupBat.MenuManager = this.barManager1;
            this.lupBat.Name = "lupBat";
            this.lupBat.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lupBat.Properties.Appearance.Options.UseFont = true;
            this.lupBat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupBat.Properties.NullText = "";
            this.lupBat.Properties.ShowHeader = false;
            this.lupBat.Size = new System.Drawing.Size(116, 20);
            this.lupBat.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(303, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "批号：";
            // 
            // luPro
            // 
            this.luPro.Location = new System.Drawing.Point(97, 13);
            this.luPro.MenuManager = this.barManager1;
            this.luPro.Name = "luPro";
            this.luPro.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.luPro.Properties.Appearance.Options.UseFont = true;
            this.luPro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luPro.Properties.NullText = "";
            this.luPro.Properties.ShowHeader = false;
            this.luPro.Size = new System.Drawing.Size(171, 20);
            this.luPro.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(21, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "产品信息：";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1240, 347);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PRD007,
            this.PRD008,
            this.PRD009,
            this.CUU003,
            this.PRD011,
            this.PRD034,
            this.WPC016,
            this.WPC,
            this.PRD003,
            this.PRD013,
            this.PRD004,
            this.PRD005,
            this.PRD019});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // PRD007
            // 
            this.PRD007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD007.AppearanceCell.Options.UseFont = true;
            this.PRD007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD007.AppearanceHeader.Options.UseFont = true;
            this.PRD007.Caption = "批号";
            this.PRD007.FieldName = "PRD007";
            this.PRD007.Name = "PRD007";
            this.PRD007.Visible = true;
            this.PRD007.VisibleIndex = 0;
            this.PRD007.Width = 63;
            // 
            // PRD008
            // 
            this.PRD008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD008.AppearanceCell.Options.UseFont = true;
            this.PRD008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD008.AppearanceHeader.Options.UseFont = true;
            this.PRD008.Caption = "品号";
            this.PRD008.FieldName = "PRD008";
            this.PRD008.Name = "PRD008";
            this.PRD008.Visible = true;
            this.PRD008.VisibleIndex = 1;
            this.PRD008.Width = 99;
            // 
            // PRD009
            // 
            this.PRD009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD009.AppearanceCell.Options.UseFont = true;
            this.PRD009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD009.AppearanceHeader.Options.UseFont = true;
            this.PRD009.Caption = "品名";
            this.PRD009.FieldName = "PRD009";
            this.PRD009.Name = "PRD009";
            this.PRD009.Visible = true;
            this.PRD009.VisibleIndex = 2;
            this.PRD009.Width = 132;
            // 
            // CUU003
            // 
            this.CUU003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU003.AppearanceCell.Options.UseFont = true;
            this.CUU003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CUU003.AppearanceHeader.Options.UseFont = true;
            this.CUU003.Caption = "产品数量";
            this.CUU003.FieldName = "CUU003";
            this.CUU003.Name = "CUU003";
            this.CUU003.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.CUU003.Visible = true;
            this.CUU003.VisibleIndex = 3;
            this.CUU003.Width = 68;
            // 
            // PRD011
            // 
            this.PRD011.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD011.AppearanceCell.Options.UseFont = true;
            this.PRD011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD011.AppearanceHeader.Options.UseFont = true;
            this.PRD011.Caption = "零件名称";
            this.PRD011.FieldName = "PRD011";
            this.PRD011.Name = "PRD011";
            this.PRD011.Visible = true;
            this.PRD011.VisibleIndex = 4;
            // 
            // PRD034
            // 
            this.PRD034.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD034.AppearanceCell.Options.UseFont = true;
            this.PRD034.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD034.AppearanceHeader.Options.UseFont = true;
            this.PRD034.Caption = "规格";
            this.PRD034.FieldName = "PRD034";
            this.PRD034.Name = "PRD034";
            this.PRD034.Visible = true;
            this.PRD034.VisibleIndex = 5;
            this.PRD034.Width = 103;
            // 
            // WPC016
            // 
            this.WPC016.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WPC016.AppearanceCell.Options.UseFont = true;
            this.WPC016.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WPC016.AppearanceHeader.Options.UseFont = true;
            this.WPC016.Caption = "单量";
            this.WPC016.FieldName = "WPC016";
            this.WPC016.Name = "WPC016";
            this.WPC016.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.WPC016.Visible = true;
            this.WPC016.VisibleIndex = 6;
            this.WPC016.Width = 39;
            // 
            // WPC
            // 
            this.WPC.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WPC.AppearanceCell.Options.UseFont = true;
            this.WPC.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WPC.AppearanceHeader.Options.UseFont = true;
            this.WPC.Caption = "需要量";
            this.WPC.FieldName = "WPC";
            this.WPC.Name = "WPC";
            this.WPC.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.WPC.Visible = true;
            this.WPC.VisibleIndex = 7;
            this.WPC.Width = 56;
            // 
            // PRD003
            // 
            this.PRD003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD003.AppearanceCell.Options.UseFont = true;
            this.PRD003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD003.AppearanceHeader.Options.UseFont = true;
            this.PRD003.Caption = "工艺";
            this.PRD003.FieldName = "PRD003";
            this.PRD003.Name = "PRD003";
            this.PRD003.Visible = true;
            this.PRD003.VisibleIndex = 8;
            this.PRD003.Width = 80;
            // 
            // PRD013
            // 
            this.PRD013.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD013.AppearanceCell.Options.UseFont = true;
            this.PRD013.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD013.AppearanceHeader.Options.UseFont = true;
            this.PRD013.Caption = "完成时间";
            this.PRD013.ColumnEdit = this.repositoryItemDateEdit1;
            this.PRD013.FieldName = "PRD013";
            this.PRD013.Name = "PRD013";
            this.PRD013.Visible = true;
            this.PRD013.VisibleIndex = 9;
            this.PRD013.Width = 99;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "yyyy-MM-dd hh:mm:ss";
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // PRD004
            // 
            this.PRD004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD004.AppearanceCell.Options.UseFont = true;
            this.PRD004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD004.AppearanceHeader.Options.UseFont = true;
            this.PRD004.Caption = "人员编号";
            this.PRD004.FieldName = "PRD004";
            this.PRD004.Name = "PRD004";
            this.PRD004.Visible = true;
            this.PRD004.VisibleIndex = 10;
            this.PRD004.Width = 74;
            // 
            // PRD005
            // 
            this.PRD005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD005.AppearanceCell.Options.UseFont = true;
            this.PRD005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD005.AppearanceHeader.Options.UseFont = true;
            this.PRD005.Caption = "人员姓名";
            this.PRD005.FieldName = "PRD005";
            this.PRD005.Name = "PRD005";
            this.PRD005.Visible = true;
            this.PRD005.VisibleIndex = 11;
            this.PRD005.Width = 79;
            // 
            // PRD019
            // 
            this.PRD019.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD019.AppearanceCell.Options.UseFont = true;
            this.PRD019.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PRD019.AppearanceHeader.Options.UseFont = true;
            this.PRD019.Caption = "记工量";
            this.PRD019.FieldName = "PRD019";
            this.PRD019.Name = "PRD019";
            this.PRD019.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PRD019.Visible = true;
            this.PRD019.VisibleIndex = 12;
            this.PRD019.Width = 108;
            // 
            // FormProductScheduleTrackTable
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 434);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormProductScheduleTrackTable";
            this.Text = "产品生产进度跟踪表";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lupBat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luPro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PRD007;
        private DevExpress . XtraGrid . Columns . GridColumn PRD008;
        private DevExpress . XtraGrid . Columns . GridColumn PRD009;
        private DevExpress . XtraGrid . Columns . GridColumn CUU003;
        private DevExpress . XtraGrid . Columns . GridColumn PRD011;
        private DevExpress . XtraGrid . Columns . GridColumn PRD034;
        private DevExpress . XtraGrid . Columns . GridColumn WPC016;
        private DevExpress . XtraGrid . Columns . GridColumn WPC;
        private DevExpress . XtraGrid . Columns . GridColumn PRD003;
        private DevExpress . XtraGrid . Columns . GridColumn PRD013;
        private DevExpress . XtraGrid . Columns . GridColumn PRD004;
        private DevExpress . XtraGrid . Columns . GridColumn PRD005;
        private DevExpress . XtraGrid . Columns . GridColumn PRD019;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LookUpEdit luPro;
        private DevExpress . XtraEditors . LookUpEdit lupBat;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . SimpleButton btnClear;
        private DevExpress . XtraEditors . Repository . RepositoryItemDateEdit repositoryItemDateEdit1;
    }
}