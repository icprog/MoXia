namespace Carpenter
{
    partial class FormSetTransmit
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
            this.STR001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STR002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STR003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STR004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
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
            this.gridControl1.Size = new System.Drawing.Size(1243, 430);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.STR001,
            this.STR002,
            this.STR003,
            this.STR004,
            this.idx});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // STR001
            // 
            this.STR001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.STR001.AppearanceCell.Options.UseFont = true;
            this.STR001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.STR001.AppearanceHeader.Options.UseFont = true;
            this.STR001.Caption = "单据编号";
            this.STR001.FieldName = "STR001";
            this.STR001.Name = "STR001";
            this.STR001.OptionsColumn.AllowEdit = false;
            this.STR001.Visible = true;
            this.STR001.VisibleIndex = 2;
            this.STR001.Width = 208;
            // 
            // STR002
            // 
            this.STR002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.STR002.AppearanceCell.Options.UseFont = true;
            this.STR002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.STR002.AppearanceHeader.Options.UseFont = true;
            this.STR002.Caption = "单据类别";
            this.STR002.FieldName = "STR002";
            this.STR002.Name = "STR002";
            this.STR002.Visible = true;
            this.STR002.VisibleIndex = 3;
            this.STR002.Width = 333;
            // 
            // STR003
            // 
            this.STR003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.STR003.AppearanceCell.Options.UseFont = true;
            this.STR003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.STR003.AppearanceHeader.Options.UseFont = true;
            this.STR003.Caption = "人员编号";
            this.STR003.FieldName = "STR003";
            this.STR003.Name = "STR003";
            this.STR003.Visible = true;
            this.STR003.VisibleIndex = 0;
            this.STR003.Width = 222;
            // 
            // STR004
            // 
            this.STR004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.STR004.AppearanceCell.Options.UseFont = true;
            this.STR004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.STR004.AppearanceHeader.Options.UseFont = true;
            this.STR004.Caption = "人员姓名";
            this.STR004.FieldName = "STR004";
            this.STR004.Name = "STR004";
            this.STR004.Visible = true;
            this.STR004.VisibleIndex = 1;
            this.STR004.Width = 286;
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // wait
            // 
            this.wait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wait.Appearance.Options.UseBackColor = true;
            this.wait.BarAnimationElementThickness = 2;
            this.wait.Caption = "请稍后";
            this.wait.Description = "数据加载中 ...";
            this.wait.Location = new System.Drawing.Point(498, 194);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 33;
            this.wait.Text = "progressPanel1";
            // 
            // FormSetTransmit
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 455);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormSetTransmit";
            this.Text = "工作联系单权限";
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.wait, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn STR001;
        private DevExpress . XtraGrid . Columns . GridColumn STR002;
        private DevExpress . XtraGrid . Columns . GridColumn STR003;
        private DevExpress . XtraGrid . Columns . GridColumn STR004;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
    }
}