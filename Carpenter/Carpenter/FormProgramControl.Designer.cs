namespace Carpenter
{
    partial class FormProgramControl
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
            this.FOR001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FOR002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FOR003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FOR004 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 26);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1233, 424);
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
            this.FOR001,
            this.FOR002,
            this.FOR003,
            this.FOR004});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
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
            this.FOR001.Width = 243;
            // 
            // FOR002
            // 
            this.FOR002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FOR002.AppearanceCell.Options.UseFont = true;
            this.FOR002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FOR002.AppearanceHeader.Options.UseFont = true;
            this.FOR002.Caption = "程序编号";
            this.FOR002.FieldName = "FOR002";
            this.FOR002.Name = "FOR002";
            this.FOR002.Visible = true;
            this.FOR002.VisibleIndex = 1;
            this.FOR002.Width = 268;
            // 
            // FOR003
            // 
            this.FOR003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FOR003.AppearanceCell.Options.UseFont = true;
            this.FOR003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FOR003.AppearanceHeader.Options.UseFont = true;
            this.FOR003.Caption = "程序类别";
            this.FOR003.FieldName = "FOR003";
            this.FOR003.Name = "FOR003";
            this.FOR003.Visible = true;
            this.FOR003.VisibleIndex = 2;
            this.FOR003.Width = 268;
            // 
            // FOR004
            // 
            this.FOR004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FOR004.AppearanceCell.Options.UseFont = true;
            this.FOR004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FOR004.AppearanceHeader.Options.UseFont = true;
            this.FOR004.Caption = "程序用表";
            this.FOR004.FieldName = "FOR004";
            this.FOR004.Name = "FOR004";
            this.FOR004.Visible = true;
            this.FOR004.VisibleIndex = 3;
            this.FOR004.Width = 270;
            // 
            // FormProgramControl
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 450);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormProgramControl";
            this.Text = "程序管控";
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
        private DevExpress . XtraGrid . Columns . GridColumn FOR001;
        private DevExpress . XtraGrid . Columns . GridColumn FOR002;
        private DevExpress . XtraGrid . Columns . GridColumn FOR003;
        private DevExpress . XtraGrid . Columns . GridColumn FOR004;
    }
}