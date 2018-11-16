namespace Carpenter
{
    partial class FormPaintBaseAndProduct
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
            this.PBA001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridL = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.viewP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.OPI001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBA002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBA003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBA004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PBA005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewP)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 26);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridL});
            this.gridControl1.Size = new System.Drawing.Size(1237, 412);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PBA001,
            this.PBA002,
            this.PBA003,
            this.PBA004,
            this.PBA005});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // PBA001
            // 
            this.PBA001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBA001.AppearanceCell.Options.UseFont = true;
            this.PBA001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBA001.AppearanceHeader.Options.UseFont = true;
            this.PBA001.Caption = "品号";
            this.PBA001.ColumnEdit = this.gridL;
            this.PBA001.FieldName = "PBA001";
            this.PBA001.Name = "PBA001";
            this.PBA001.Visible = true;
            this.PBA001.VisibleIndex = 2;
            this.PBA001.Width = 267;
            // 
            // gridL
            // 
            this.gridL.AutoHeight = false;
            this.gridL.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.gridL.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridL.ImmediatePopup = true;
            this.gridL.Name = "gridL";
            this.gridL.NullText = "";
            this.gridL.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.gridL.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridL.View = this.viewP;
            this.gridL.EditValueChanged += new System.EventHandler(this.gridL_EditValueChanged);
            // 
            // viewP
            // 
            this.viewP.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.OPI001,
            this.OPI002,
            this.OPI003});
            this.viewP.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.viewP.Name = "viewP";
            this.viewP.OptionsBehavior.Editable = false;
            this.viewP.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewP.OptionsView.ShowGroupPanel = false;
            // 
            // OPI001
            // 
            this.OPI001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI001.AppearanceCell.Options.UseFont = true;
            this.OPI001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI001.AppearanceHeader.Options.UseFont = true;
            this.OPI001.Caption = "品号";
            this.OPI001.FieldName = "PBA001";
            this.OPI001.Name = "OPI001";
            this.OPI001.Visible = true;
            this.OPI001.VisibleIndex = 1;
            this.OPI001.Width = 342;
            // 
            // OPI002
            // 
            this.OPI002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI002.AppearanceCell.Options.UseFont = true;
            this.OPI002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI002.AppearanceHeader.Options.UseFont = true;
            this.OPI002.Caption = "品名";
            this.OPI002.FieldName = "PBA002";
            this.OPI002.Name = "OPI002";
            this.OPI002.Visible = true;
            this.OPI002.VisibleIndex = 2;
            this.OPI002.Width = 733;
            // 
            // OPI003
            // 
            this.OPI003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI003.AppearanceCell.Options.UseFont = true;
            this.OPI003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI003.AppearanceHeader.Options.UseFont = true;
            this.OPI003.Caption = "系列";
            this.OPI003.FieldName = "PBA005";
            this.OPI003.Name = "OPI003";
            this.OPI003.Visible = true;
            this.OPI003.VisibleIndex = 0;
            // 
            // PBA002
            // 
            this.PBA002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBA002.AppearanceCell.Options.UseFont = true;
            this.PBA002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBA002.AppearanceHeader.Options.UseFont = true;
            this.PBA002.Caption = "品名";
            this.PBA002.FieldName = "PBA002";
            this.PBA002.Name = "PBA002";
            this.PBA002.OptionsColumn.AllowEdit = false;
            this.PBA002.Visible = true;
            this.PBA002.VisibleIndex = 3;
            this.PBA002.Width = 315;
            // 
            // PBA003
            // 
            this.PBA003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBA003.AppearanceCell.Options.UseFont = true;
            this.PBA003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBA003.AppearanceHeader.Options.UseFont = true;
            this.PBA003.Caption = "部件";
            this.PBA003.FieldName = "PBA003";
            this.PBA003.Name = "PBA003";
            this.PBA003.Visible = true;
            this.PBA003.VisibleIndex = 4;
            this.PBA003.Width = 356;
            // 
            // PBA004
            // 
            this.PBA004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBA004.AppearanceCell.Options.UseFont = true;
            this.PBA004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBA004.AppearanceHeader.Options.UseFont = true;
            this.PBA004.Caption = "油漆平方";
            this.PBA004.FieldName = "PBA004";
            this.PBA004.Name = "PBA004";
            this.PBA004.Visible = true;
            this.PBA004.VisibleIndex = 5;
            this.PBA004.Width = 138;
            // 
            // PBA005
            // 
            this.PBA005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBA005.AppearanceCell.Options.UseFont = true;
            this.PBA005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PBA005.AppearanceHeader.Options.UseFont = true;
            this.PBA005.Caption = "系列";
            this.PBA005.FieldName = "PBA005";
            this.PBA005.Name = "PBA005";
            this.PBA005.Visible = true;
            this.PBA005.VisibleIndex = 1;
            this.PBA005.Width = 105;
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
            this.wait.Location = new System.Drawing.Point(495, 186);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 37;
            this.wait.Text = "progressPanel1";
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // FormPaintBaseAndProduct
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 438);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormPaintBaseAndProduct";
            this.Text = "油漆名称";
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.wait, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PBA001;
        private DevExpress . XtraGrid . Columns . GridColumn PBA002;
        private DevExpress . XtraGrid . Columns . GridColumn PBA003;
        private DevExpress . XtraGrid . Columns . GridColumn PBA004;
        private DevExpress . XtraEditors . Repository . RepositoryItemGridLookUpEdit gridL;
        private DevExpress . XtraGrid . Views . Grid . GridView viewP;
        private DevExpress . XtraGrid . Columns . GridColumn OPI001;
        private DevExpress . XtraGrid . Columns . GridColumn OPI002;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private System . ComponentModel . BackgroundWorker backgroundWorker2;
        private DevExpress . XtraGrid . Columns . GridColumn PBA005;
        private DevExpress . XtraGrid . Columns . GridColumn OPI003;
    }
}