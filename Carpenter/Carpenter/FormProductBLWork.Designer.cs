namespace Carpenter
{
    partial class FormProductBLWork
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
            this.lupPro = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lupPart = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PBW001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBW002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBW003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBW004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBW005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBW013 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBW006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBW007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBW008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBW009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBW010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBW014 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBW011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBW012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupPro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPart.Properties)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.btnClear);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupPro);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupPart);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.wait);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1252, 430);
            this.splitContainerControl1.SplitterPosition = 38;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.Location = new System.Drawing.Point(495, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(57, 23);
            this.btnClear.TabIndex = 36;
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lupPro
            // 
            this.lupPro.Location = new System.Drawing.Point(263, 8);
            this.lupPro.MenuManager = this.barManager1;
            this.lupPro.Name = "lupPro";
            this.lupPro.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lupPro.Properties.Appearance.Options.UseFont = true;
            this.lupPro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPro.Properties.NullText = "";
            this.lupPro.Properties.PopupFormMinSize = new System.Drawing.Size(800, 800);
            this.lupPro.Properties.PopupWidth = 800;
            this.lupPro.Properties.ShowHeader = false;
            this.lupPro.Size = new System.Drawing.Size(196, 20);
            this.lupPro.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(187, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "产品信息：";
            // 
            // lupPart
            // 
            this.lupPart.Location = new System.Drawing.Point(60, 8);
            this.lupPart.MenuManager = this.barManager1;
            this.lupPart.Name = "lupPart";
            this.lupPart.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lupPart.Properties.Appearance.Options.UseFont = true;
            this.lupPart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPart.Properties.NullText = "";
            this.lupPart.Properties.ShowHeader = false;
            this.lupPart.Size = new System.Drawing.Size(110, 20);
            this.lupPart.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "批号：";
            // 
            // wait
            // 
            this.wait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wait.Appearance.Options.UseBackColor = true;
            this.wait.BarAnimationElementThickness = 2;
            this.wait.Caption = "请稍后";
            this.wait.Description = "数据加载中 ...";
            this.wait.Location = new System.Drawing.Point(503, 157);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 34;
            this.wait.Text = "progressPanel1";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1252, 380);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PBW001,
            this.PBW002,
            this.PBW003,
            this.PBW004,
            this.PBW005,
            this.PBW013,
            this.PBW006,
            this.PBW007,
            this.PBW008,
            this.PBW009,
            this.PBW010,
            this.PBW014,
            this.PBW011,
            this.PBW012});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // PBW001
            // 
            this.PBW001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW001.AppearanceCell.Options.UseFont = true;
            this.PBW001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW001.AppearanceHeader.Options.UseFont = true;
            this.PBW001.Caption = "批号";
            this.PBW001.FieldName = "PBW001";
            this.PBW001.Name = "PBW001";
            this.PBW001.Visible = true;
            this.PBW001.VisibleIndex = 0;
            this.PBW001.Width = 58;
            // 
            // PBW002
            // 
            this.PBW002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW002.AppearanceCell.Options.UseFont = true;
            this.PBW002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW002.AppearanceHeader.Options.UseFont = true;
            this.PBW002.Caption = "品号";
            this.PBW002.FieldName = "PBW002";
            this.PBW002.Name = "PBW002";
            this.PBW002.Visible = true;
            this.PBW002.VisibleIndex = 1;
            this.PBW002.Width = 132;
            // 
            // PBW003
            // 
            this.PBW003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW003.AppearanceCell.Options.UseFont = true;
            this.PBW003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW003.AppearanceHeader.Options.UseFont = true;
            this.PBW003.Caption = "品名";
            this.PBW003.FieldName = "PBW003";
            this.PBW003.Name = "PBW003";
            this.PBW003.Visible = true;
            this.PBW003.VisibleIndex = 2;
            this.PBW003.Width = 151;
            // 
            // PBW004
            // 
            this.PBW004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW004.AppearanceCell.Options.UseFont = true;
            this.PBW004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW004.AppearanceHeader.Options.UseFont = true;
            this.PBW004.Caption = "生产数量";
            this.PBW004.FieldName = "PBW004";
            this.PBW004.Name = "PBW004";
            this.PBW004.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PBW004.Visible = true;
            this.PBW004.VisibleIndex = 3;
            this.PBW004.Width = 66;
            // 
            // PBW005
            // 
            this.PBW005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW005.AppearanceCell.Options.UseFont = true;
            this.PBW005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW005.AppearanceHeader.Options.UseFont = true;
            this.PBW005.Caption = "零件名称";
            this.PBW005.FieldName = "PBW005";
            this.PBW005.Name = "PBW005";
            this.PBW005.Visible = true;
            this.PBW005.VisibleIndex = 4;
            this.PBW005.Width = 78;
            // 
            // PBW013
            // 
            this.PBW013.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW013.AppearanceCell.Options.UseFont = true;
            this.PBW013.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW013.AppearanceHeader.Options.UseFont = true;
            this.PBW013.Caption = "零件规格";
            this.PBW013.FieldName = "PBW013";
            this.PBW013.Name = "PBW013";
            this.PBW013.Visible = true;
            this.PBW013.VisibleIndex = 5;
            this.PBW013.Width = 96;
            // 
            // PBW006
            // 
            this.PBW006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW006.AppearanceCell.Options.UseFont = true;
            this.PBW006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW006.AppearanceHeader.Options.UseFont = true;
            this.PBW006.Caption = "单量";
            this.PBW006.FieldName = "PBW006";
            this.PBW006.Name = "PBW006";
            this.PBW006.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PBW006.Visible = true;
            this.PBW006.VisibleIndex = 6;
            this.PBW006.Width = 39;
            // 
            // PBW007
            // 
            this.PBW007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW007.AppearanceCell.Options.UseFont = true;
            this.PBW007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW007.AppearanceHeader.Options.UseFont = true;
            this.PBW007.Caption = "需要量";
            this.PBW007.FieldName = "PBW007";
            this.PBW007.Name = "PBW007";
            this.PBW007.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PBW007.Visible = true;
            this.PBW007.VisibleIndex = 7;
            this.PBW007.Width = 51;
            // 
            // PBW008
            // 
            this.PBW008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW008.AppearanceCell.Options.UseFont = true;
            this.PBW008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW008.AppearanceHeader.Options.UseFont = true;
            this.PBW008.Caption = "工序";
            this.PBW008.FieldName = "PBW008";
            this.PBW008.Name = "PBW008";
            this.PBW008.Visible = true;
            this.PBW008.VisibleIndex = 8;
            this.PBW008.Width = 85;
            // 
            // PBW009
            // 
            this.PBW009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW009.AppearanceCell.Options.UseFont = true;
            this.PBW009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW009.AppearanceHeader.Options.UseFont = true;
            this.PBW009.Caption = "完成时间";
            this.PBW009.FieldName = "PBW009";
            this.PBW009.Name = "PBW009";
            this.PBW009.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PBW009.Visible = true;
            this.PBW009.VisibleIndex = 9;
            this.PBW009.Width = 86;
            // 
            // PBW010
            // 
            this.PBW010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW010.AppearanceCell.Options.UseFont = true;
            this.PBW010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW010.AppearanceHeader.Options.UseFont = true;
            this.PBW010.Caption = "工号";
            this.PBW010.FieldName = "PBW010";
            this.PBW010.Name = "PBW010";
            this.PBW010.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PBW010.Visible = true;
            this.PBW010.VisibleIndex = 10;
            this.PBW010.Width = 46;
            // 
            // PBW014
            // 
            this.PBW014.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW014.AppearanceCell.Options.UseFont = true;
            this.PBW014.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW014.AppearanceHeader.Options.UseFont = true;
            this.PBW014.Caption = "姓名";
            this.PBW014.FieldName = "PBW014";
            this.PBW014.Name = "PBW014";
            this.PBW014.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PBW014.Visible = true;
            this.PBW014.VisibleIndex = 11;
            this.PBW014.Width = 56;
            // 
            // PBW011
            // 
            this.PBW011.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW011.AppearanceCell.Options.UseFont = true;
            this.PBW011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW011.AppearanceHeader.Options.UseFont = true;
            this.PBW011.Caption = "数量";
            this.PBW011.FieldName = "PBW011";
            this.PBW011.Name = "PBW011";
            this.PBW011.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PBW011.Visible = true;
            this.PBW011.VisibleIndex = 12;
            this.PBW011.Width = 42;
            // 
            // PBW012
            // 
            this.PBW012.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW012.AppearanceCell.Options.UseFont = true;
            this.PBW012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBW012.AppearanceHeader.Options.UseFont = true;
            this.PBW012.Caption = "备注";
            this.PBW012.FieldName = "PBW012";
            this.PBW012.Name = "PBW012";
            this.PBW012.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PBW012.Visible = true;
            this.PBW012.VisibleIndex = 13;
            this.PBW012.Width = 89;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FormProductBLWork
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 456);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormProductBLWork";
            this.Text = "备料车间产品生产工序进度跟踪表";
            this.Load += new System.EventHandler(this.FormProductBLWork_Load);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lupPro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LookUpEdit lupPart;
        private DevExpress . XtraEditors . LookUpEdit lupPro;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . SimpleButton btnClear;
        private DevExpress . XtraGrid . Columns . GridColumn PBW001;
        private DevExpress . XtraGrid . Columns . GridColumn PBW002;
        private DevExpress . XtraGrid . Columns . GridColumn PBW003;
        private DevExpress . XtraGrid . Columns . GridColumn PBW004;
        private DevExpress . XtraGrid . Columns . GridColumn PBW005;
        private DevExpress . XtraGrid . Columns . GridColumn PBW013;
        private DevExpress . XtraGrid . Columns . GridColumn PBW006;
        private DevExpress . XtraGrid . Columns . GridColumn PBW007;
        private DevExpress . XtraGrid . Columns . GridColumn PBW008;
        private DevExpress . XtraGrid . Columns . GridColumn PBW009;
        private DevExpress . XtraGrid . Columns . GridColumn PBW010;
        private DevExpress . XtraGrid . Columns . GridColumn PBW011;
        private DevExpress . XtraGrid . Columns . GridColumn PBW012;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraGrid . Columns . GridColumn PBW014;
    }
}