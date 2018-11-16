namespace Carpenter
{
    partial class FormSetReview
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
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SRE002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FOR001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SRE003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SRE004 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 25);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1233, 429);
            this.gridControl1.TabIndex = 1;
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
            this.SRE002,
            this.FOR001,
            this.SRE003,
            this.EMP002,
            this.SRE004});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // SRE002
            // 
            this.SRE002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.SRE002.AppearanceCell.Options.UseFont = true;
            this.SRE002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.SRE002.AppearanceHeader.Options.UseFont = true;
            this.SRE002.Caption = "程序编号";
            this.SRE002.FieldName = "SRE002";
            this.SRE002.Name = "SRE002";
            this.SRE002.Visible = true;
            this.SRE002.VisibleIndex = 1;
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
            // 
            // SRE003
            // 
            this.SRE003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.SRE003.AppearanceCell.Options.UseFont = true;
            this.SRE003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.SRE003.AppearanceHeader.Options.UseFont = true;
            this.SRE003.Caption = "人员编号";
            this.SRE003.FieldName = "SRE003";
            this.SRE003.Name = "SRE003";
            this.SRE003.Visible = true;
            this.SRE003.VisibleIndex = 3;
            // 
            // EMP002
            // 
            this.EMP002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP002.AppearanceCell.Options.UseFont = true;
            this.EMP002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP002.AppearanceHeader.Options.UseFont = true;
            this.EMP002.Caption = "人员名称";
            this.EMP002.FieldName = "EMP002";
            this.EMP002.Name = "EMP002";
            this.EMP002.Visible = true;
            this.EMP002.VisibleIndex = 2;
            // 
            // SRE004
            // 
            this.SRE004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.SRE004.AppearanceCell.Options.UseFont = true;
            this.SRE004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.SRE004.AppearanceHeader.Options.UseFont = true;
            this.SRE004.Caption = "送审级别";
            this.SRE004.FieldName = "SRE004";
            this.SRE004.Name = "SRE004";
            this.SRE004.Visible = true;
            this.SRE004.VisibleIndex = 4;
            // 
            // FormSetReview
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 454);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormSetReview";
            this.Text = "消息送审流程设置";
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn SRE002;
        private DevExpress . XtraGrid . Columns . GridColumn FOR001;
        private DevExpress . XtraGrid . Columns . GridColumn SRE003;
        private DevExpress . XtraGrid . Columns . GridColumn EMP002;
        private DevExpress . XtraGrid . Columns . GridColumn SRE004;
    }
}