namespace Carpenter
{
    partial class FormRemind
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.REV001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FOR001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REV003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REV004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REV005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REV006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REV002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1107, 420);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.REV001,
            this.FOR001,
            this.REV003,
            this.EMP002,
            this.REV004,
            this.REV005,
            this.REV006,
            this.REV002});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // REV001
            // 
            this.REV001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.REV001.AppearanceCell.Options.UseFont = true;
            this.REV001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.REV001.AppearanceHeader.Options.UseFont = true;
            this.REV001.Caption = "程序编号";
            this.REV001.FieldName = "REV001";
            this.REV001.Name = "REV001";
            // 
            // FOR001
            // 
            this.FOR001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FOR001.AppearanceCell.Options.UseFont = true;
            this.FOR001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FOR001.AppearanceHeader.Options.UseFont = true;
            this.FOR001.Caption = "程序名称";
            this.FOR001.FieldName = "FOR001";
            this.FOR001.Name = "FOR001";
            this.FOR001.Visible = true;
            this.FOR001.VisibleIndex = 0;
            this.FOR001.Width = 174;
            // 
            // REV003
            // 
            this.REV003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.REV003.AppearanceCell.Options.UseFont = true;
            this.REV003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.REV003.AppearanceHeader.Options.UseFont = true;
            this.REV003.Caption = "送审人编号";
            this.REV003.FieldName = "REV003";
            this.REV003.Name = "REV003";
            // 
            // EMP002
            // 
            this.EMP002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP002.AppearanceCell.Options.UseFont = true;
            this.EMP002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP002.AppearanceHeader.Options.UseFont = true;
            this.EMP002.Caption = "送审人";
            this.EMP002.FieldName = "EMP002";
            this.EMP002.Name = "EMP002";
            this.EMP002.Visible = true;
            this.EMP002.VisibleIndex = 2;
            this.EMP002.Width = 174;
            // 
            // REV004
            // 
            this.REV004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.REV004.AppearanceCell.Options.UseFont = true;
            this.REV004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.REV004.AppearanceHeader.Options.UseFont = true;
            this.REV004.Caption = "送审日期";
            this.REV004.FieldName = "REV004";
            this.REV004.Name = "REV004";
            this.REV004.Visible = true;
            this.REV004.VisibleIndex = 3;
            this.REV004.Width = 174;
            // 
            // REV005
            // 
            this.REV005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.REV005.AppearanceCell.Options.UseFont = true;
            this.REV005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.REV005.AppearanceHeader.Options.UseFont = true;
            this.REV005.Caption = "送审状态";
            this.REV005.FieldName = "REV005";
            this.REV005.Name = "REV005";
            this.REV005.Visible = true;
            this.REV005.VisibleIndex = 4;
            this.REV005.Width = 72;
            // 
            // REV006
            // 
            this.REV006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.REV006.AppearanceCell.Options.UseFont = true;
            this.REV006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.REV006.AppearanceHeader.Options.UseFont = true;
            this.REV006.Caption = "送审意见";
            this.REV006.FieldName = "REV006";
            this.REV006.Name = "REV006";
            this.REV006.Visible = true;
            this.REV006.VisibleIndex = 5;
            this.REV006.Width = 281;
            // 
            // REV002
            // 
            this.REV002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.REV002.AppearanceCell.Options.UseFont = true;
            this.REV002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.REV002.AppearanceHeader.Options.UseFont = true;
            this.REV002.Caption = "单号";
            this.REV002.FieldName = "REV002";
            this.REV002.Name = "REV002";
            this.REV002.Visible = true;
            this.REV002.VisibleIndex = 1;
            this.REV002.Width = 174;
            // 
            // FormRemind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 420);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormRemind";
            this.Text = "消息提醒";
            this.Load += new System.EventHandler(this.FormRemind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn REV001;
        private DevExpress . XtraGrid . Columns . GridColumn FOR001;
        private DevExpress . XtraGrid . Columns . GridColumn REV003;
        private DevExpress . XtraGrid . Columns . GridColumn EMP002;
        private DevExpress . XtraGrid . Columns . GridColumn REV004;
        private DevExpress . XtraGrid . Columns . GridColumn REV005;
        private DevExpress . XtraGrid . Columns . GridColumn REV006;
        private DevExpress . XtraGrid . Columns . GridColumn REV002;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
    }
}