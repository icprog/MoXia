namespace Carpenter
{
    partial class FormWageCoef
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dtTime = new DevExpress.XtraEditors.DateEdit();
            this.btnRead = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.WAC001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WAC002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WAC003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WAC004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WAC005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WAC006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WAC007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WAC009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.layoutControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1237, 412);
            this.splitContainerControl1.SplitterPosition = 51;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dtTime);
            this.layoutControl1.Controls.Add(this.btnRead);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1237, 51);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dtTime
            // 
            this.dtTime.EditValue = null;
            this.dtTime.Location = new System.Drawing.Point(43, 12);
            this.dtTime.MenuManager = this.barManager1;
            this.dtTime.Name = "dtTime";
            this.dtTime.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtTime.Properties.Appearance.Options.UseFont = true;
            this.dtTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTime.Properties.DisplayFormat.FormatString = "yyyyMM";
            this.dtTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTime.Properties.EditFormat.FormatString = "yyyyMM";
            this.dtTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTime.Properties.Mask.EditMask = "yyyyMM";
            this.dtTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dtTime.Size = new System.Drawing.Size(168, 20);
            this.dtTime.StyleController = this.layoutControl1;
            this.dtTime.TabIndex = 4;
            // 
            // btnRead
            // 
            this.btnRead.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.Appearance.Options.UseFont = true;
            this.btnRead.Location = new System.Drawing.Point(245, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(58, 22);
            this.btnRead.StyleController = this.layoutControl1;
            this.btnRead.TabIndex = 5;
            this.btnRead.Text = "读取";
            this.btnRead.Visible = false;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1237, 51);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.dtTime;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(203, 31);
            this.layoutControlItem1.Text = "年月";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(28, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnRead;
            this.layoutControlItem2.Location = new System.Drawing.Point(233, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(62, 31);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(203, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(30, 31);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(295, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(922, 31);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1237, 349);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.WAC001,
            this.WAC002,
            this.WAC003,
            this.WAC004,
            this.WAC005,
            this.WAC006,
            this.WAC007,
            this.idx,
            this.WAC009});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // WAC001
            // 
            this.WAC001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC001.AppearanceCell.Options.UseFont = true;
            this.WAC001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC001.AppearanceHeader.Options.UseFont = true;
            this.WAC001.Caption = "设备编号";
            this.WAC001.FieldName = "WAC001";
            this.WAC001.Name = "WAC001";
            this.WAC001.OptionsColumn.AllowEdit = false;
            this.WAC001.Visible = true;
            this.WAC001.VisibleIndex = 0;
            this.WAC001.Width = 116;
            // 
            // WAC002
            // 
            this.WAC002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC002.AppearanceCell.Options.UseFont = true;
            this.WAC002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC002.AppearanceHeader.Options.UseFont = true;
            this.WAC002.Caption = "设备名称";
            this.WAC002.FieldName = "WAC002";
            this.WAC002.Name = "WAC002";
            this.WAC002.OptionsColumn.AllowEdit = false;
            this.WAC002.Visible = true;
            this.WAC002.VisibleIndex = 1;
            this.WAC002.Width = 146;
            // 
            // WAC003
            // 
            this.WAC003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC003.AppearanceCell.Options.UseFont = true;
            this.WAC003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC003.AppearanceHeader.Options.UseFont = true;
            this.WAC003.Caption = "工资系数分组";
            this.WAC003.FieldName = "WAC003";
            this.WAC003.Name = "WAC003";
            this.WAC003.OptionsColumn.AllowEdit = false;
            this.WAC003.Visible = true;
            this.WAC003.VisibleIndex = 2;
            this.WAC003.Width = 96;
            // 
            // WAC004
            // 
            this.WAC004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC004.AppearanceCell.Options.UseFont = true;
            this.WAC004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC004.AppearanceHeader.Options.UseFont = true;
            this.WAC004.Caption = "员工编号";
            this.WAC004.FieldName = "WAC004";
            this.WAC004.Name = "WAC004";
            this.WAC004.OptionsColumn.AllowEdit = false;
            this.WAC004.Visible = true;
            this.WAC004.VisibleIndex = 3;
            this.WAC004.Width = 98;
            // 
            // WAC005
            // 
            this.WAC005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC005.AppearanceCell.Options.UseFont = true;
            this.WAC005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC005.AppearanceHeader.Options.UseFont = true;
            this.WAC005.Caption = "员工姓名";
            this.WAC005.FieldName = "WAC005";
            this.WAC005.Name = "WAC005";
            this.WAC005.OptionsColumn.AllowEdit = false;
            this.WAC005.Visible = true;
            this.WAC005.VisibleIndex = 4;
            this.WAC005.Width = 176;
            // 
            // WAC006
            // 
            this.WAC006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC006.AppearanceCell.Options.UseFont = true;
            this.WAC006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC006.AppearanceHeader.Options.UseFont = true;
            this.WAC006.Caption = "工资系数";
            this.WAC006.FieldName = "WAC006";
            this.WAC006.Name = "WAC006";
            this.WAC006.Visible = true;
            this.WAC006.VisibleIndex = 5;
            this.WAC006.Width = 150;
            // 
            // WAC007
            // 
            this.WAC007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC007.AppearanceCell.Options.UseFont = true;
            this.WAC007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC007.AppearanceHeader.Options.UseFont = true;
            this.WAC007.Caption = "当月工资";
            this.WAC007.FieldName = "WAC007";
            this.WAC007.Name = "WAC007";
            this.WAC007.OptionsColumn.AllowEdit = false;
            this.WAC007.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WAC007", "{0:0.##}")});
            this.WAC007.Visible = true;
            this.WAC007.VisibleIndex = 6;
            this.WAC007.Width = 122;
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // WAC009
            // 
            this.WAC009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC009.AppearanceCell.Options.UseFont = true;
            this.WAC009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.WAC009.AppearanceHeader.Options.UseFont = true;
            this.WAC009.Caption = "当月组别工资(汇总)";
            this.WAC009.FieldName = "WAC009";
            this.WAC009.Name = "WAC009";
            this.WAC009.OptionsColumn.AllowEdit = false;
            this.WAC009.Visible = true;
            this.WAC009.VisibleIndex = 7;
            this.WAC009.Width = 171;
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
            this.wait.TabIndex = 39;
            this.wait.Text = "progressPanel1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // FormWageCoef
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 438);
            this.Controls.Add(this.wait);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormWageCoef";
            this.Text = "组别工资系数分配";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.wait, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraLayout . LayoutControl layoutControl1;
        private DevExpress . XtraLayout . LayoutControlGroup layoutControlGroup1;
        private DevExpress . XtraEditors . DateEdit dtTime;
        private DevExpress . XtraLayout . LayoutControlItem layoutControlItem1;
        private DevExpress . XtraEditors . SimpleButton btnRead;
        private DevExpress . XtraLayout . LayoutControlItem layoutControlItem2;
        private DevExpress . XtraLayout . EmptySpaceItem emptySpaceItem1;
        private DevExpress . XtraLayout . EmptySpaceItem emptySpaceItem2;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn WAC001;
        private DevExpress . XtraGrid . Columns . GridColumn WAC002;
        private DevExpress . XtraGrid . Columns . GridColumn WAC003;
        private DevExpress . XtraGrid . Columns . GridColumn WAC004;
        private DevExpress . XtraGrid . Columns . GridColumn WAC005;
        private DevExpress . XtraGrid . Columns . GridColumn WAC006;
        private DevExpress . XtraGrid . Columns . GridColumn WAC007;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private System . ComponentModel . BackgroundWorker backgroundWorker2;
        private DevExpress . XtraGrid . Columns . GridColumn WAC009;
    }
}