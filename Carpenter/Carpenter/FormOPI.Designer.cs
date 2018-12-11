namespace Carpenter
{
    partial class FormOPI
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
            this.lupColor = new DevExpress.XtraEditors.LookUpEdit();
            this.lupSpeci = new DevExpress.XtraEditors.LookUpEdit();
            this.lupType = new DevExpress.XtraEditors.LookUpEdit();
            this.lupProduct = new DevExpress.XtraEditors.LookUpEdit();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
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
            this.OPI011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OPI012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.comUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comAtt = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comstate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCl = new DevExpress.XtraEditors.SimpleButton();
            this.btnBatch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lupColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupSpeci.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comAtt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comstate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lupColor
            // 
            this.lupColor.Location = new System.Drawing.Point(334, 43);
            this.lupColor.Name = "lupColor";
            this.lupColor.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupColor.Properties.Appearance.Options.UseFont = true;
            this.lupColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupColor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OPI006", 35, "颜色")});
            this.lupColor.Properties.NullText = "";
            this.lupColor.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupColor.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupColor.Properties.ShowHeader = false;
            this.lupColor.Size = new System.Drawing.Size(129, 20);
            this.lupColor.TabIndex = 10;
            // 
            // lupSpeci
            // 
            this.lupSpeci.Location = new System.Drawing.Point(334, 13);
            this.lupSpeci.Name = "lupSpeci";
            this.lupSpeci.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupSpeci.Properties.Appearance.Options.UseFont = true;
            this.lupSpeci.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupSpeci.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OPI005", 35, "规格")});
            this.lupSpeci.Properties.NullText = "";
            this.lupSpeci.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupSpeci.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupSpeci.Properties.ShowHeader = false;
            this.lupSpeci.Size = new System.Drawing.Size(129, 20);
            this.lupSpeci.TabIndex = 8;
            // 
            // lupType
            // 
            this.lupType.Location = new System.Drawing.Point(95, 43);
            this.lupType.Name = "lupType";
            this.lupType.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupType.Properties.Appearance.Options.UseFont = true;
            this.lupType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OPI003", 35, "OPI003")});
            this.lupType.Properties.NullText = "";
            this.lupType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupType.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupType.Properties.ShowHeader = false;
            this.lupType.Size = new System.Drawing.Size(148, 20);
            this.lupType.TabIndex = 6;
            // 
            // lupProduct
            // 
            this.lupProduct.Location = new System.Drawing.Point(95, 13);
            this.lupProduct.Name = "lupProduct";
            this.lupProduct.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupProduct.Properties.Appearance.Options.UseFont = true;
            this.lupProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupProduct.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OPI001", 55, "品号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OPI002", 55, "品名")});
            this.lupProduct.Properties.NullText = "";
            this.lupProduct.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupProduct.Properties.PopupFormMinSize = new System.Drawing.Size(200, 0);
            this.lupProduct.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupProduct.Size = new System.Drawing.Size(148, 20);
            this.lupProduct.TabIndex = 4;
            // 
            // wait
            // 
            this.wait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wait.Appearance.Options.UseBackColor = true;
            this.wait.BarAnimationElementThickness = 2;
            this.wait.Caption = "请稍后";
            this.wait.Description = "数据加载中 ...";
            this.wait.Location = new System.Drawing.Point(452, 118);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 33;
            this.wait.Text = "progressPanel1";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1245, 335);
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
            this.OPI010,
            this.OPI011,
            this.OPI012});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
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
            this.OPI004.DisplayFormat.FormatString = "0.####";
            this.OPI004.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
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
            // OPI011
            // 
            this.OPI011.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI011.AppearanceCell.Options.UseFont = true;
            this.OPI011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI011.AppearanceHeader.Options.UseFont = true;
            this.OPI011.Caption = "注销";
            this.OPI011.FieldName = "OPI011";
            this.OPI011.Name = "OPI011";
            this.OPI011.Visible = true;
            this.OPI011.VisibleIndex = 10;
            this.OPI011.Width = 41;
            // 
            // OPI012
            // 
            this.OPI012.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI012.AppearanceCell.Options.UseFont = true;
            this.OPI012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.OPI012.AppearanceHeader.Options.UseFont = true;
            this.OPI012.Caption = "图片";
            this.OPI012.FieldName = "OPI012";
            this.OPI012.Name = "OPI012";
            this.OPI012.Visible = true;
            this.OPI012.VisibleIndex = 11;
            this.OPI012.Width = 124;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 24);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.btnBatch);
            this.splitContainerControl1.Panel1.Controls.Add(this.comUnit);
            this.splitContainerControl1.Panel1.Controls.Add(this.comAtt);
            this.splitContainerControl1.Panel1.Controls.Add(this.comClass);
            this.splitContainerControl1.Panel1.Controls.Add(this.comstate);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl8);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl7);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl6);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnCl);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupProduct);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupType);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupSpeci);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupColor);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.wait);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1245, 413);
            this.splitContainerControl1.SplitterPosition = 73;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // comUnit
            // 
            this.comUnit.Location = new System.Drawing.Point(707, 43);
            this.comUnit.MenuManager = this.barManager1;
            this.comUnit.Name = "comUnit";
            this.comUnit.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comUnit.Properties.Appearance.Options.UseFont = true;
            this.comUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comUnit.Size = new System.Drawing.Size(72, 20);
            this.comUnit.TabIndex = 48;
            // 
            // comAtt
            // 
            this.comAtt.Location = new System.Drawing.Point(707, 13);
            this.comAtt.MenuManager = this.barManager1;
            this.comAtt.Name = "comAtt";
            this.comAtt.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comAtt.Properties.Appearance.Options.UseFont = true;
            this.comAtt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comAtt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comAtt.Size = new System.Drawing.Size(72, 20);
            this.comAtt.TabIndex = 47;
            // 
            // comClass
            // 
            this.comClass.Location = new System.Drawing.Point(556, 43);
            this.comClass.MenuManager = this.barManager1;
            this.comClass.Name = "comClass";
            this.comClass.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comClass.Properties.Appearance.Options.UseFont = true;
            this.comClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comClass.Size = new System.Drawing.Size(72, 20);
            this.comClass.TabIndex = 46;
            // 
            // comstate
            // 
            this.comstate.Location = new System.Drawing.Point(556, 13);
            this.comstate.MenuManager = this.barManager1;
            this.comstate.Name = "comstate";
            this.comstate.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comstate.Properties.Appearance.Options.UseFont = true;
            this.comstate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comstate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comstate.Size = new System.Drawing.Size(72, 20);
            this.comstate.TabIndex = 45;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(655, 46);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(42, 14);
            this.labelControl8.TabIndex = 44;
            this.labelControl8.Text = "单位：";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(655, 16);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(42, 14);
            this.labelControl7.TabIndex = 43;
            this.labelControl7.Text = "属性：";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(508, 46);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(42, 14);
            this.labelControl6.TabIndex = 42;
            this.labelControl6.Text = "分类：";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(508, 16);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(42, 14);
            this.labelControl5.TabIndex = 41;
            this.labelControl5.Text = "状态：";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(286, 46);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(42, 14);
            this.labelControl4.TabIndex = 40;
            this.labelControl4.Text = "颜色：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(286, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 14);
            this.labelControl3.TabIndex = 39;
            this.labelControl3.Text = "规格：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(19, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 38;
            this.labelControl2.Text = "产品类别：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(19, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 37;
            this.labelControl1.Text = "产品信息：";
            // 
            // btnCl
            // 
            this.btnCl.Appearance.Font = new System.Drawing.Font("宋体", 12F);
            this.btnCl.Appearance.Options.UseFont = true;
            this.btnCl.Location = new System.Drawing.Point(808, 41);
            this.btnCl.Name = "btnCl";
            this.btnCl.Size = new System.Drawing.Size(75, 23);
            this.btnCl.TabIndex = 36;
            this.btnCl.Text = "清除";
            this.btnCl.Click += new System.EventHandler(this.btnCl_Click);
            // 
            // btnBatch
            // 
            this.btnBatch.Appearance.Font = new System.Drawing.Font("宋体", 12F);
            this.btnBatch.Appearance.Options.UseFont = true;
            this.btnBatch.Location = new System.Drawing.Point(913, 41);
            this.btnBatch.Name = "btnBatch";
            this.btnBatch.Size = new System.Drawing.Size(75, 23);
            this.btnBatch.TabIndex = 49;
            this.btnBatch.Text = "批量编辑";
            this.btnBatch.Click += new System.EventHandler(this.btnBatch_Click);
            // 
            // FormOPI
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 437);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormOPI";
            this.Text = "产品信息";
            this.Load += new System.EventHandler(this.FormOPI_Load);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lupColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupSpeci.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comAtt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comstate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraEditors . LookUpEdit lupProduct;
        private DevExpress . XtraEditors . LookUpEdit lupType;
        private DevExpress . XtraEditors . LookUpEdit lupSpeci;
        private DevExpress . XtraEditors . LookUpEdit lupColor;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
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
        private DevExpress . XtraGrid . Columns . GridColumn OPI011;
        private DevExpress . XtraGrid . Columns . GridColumn OPI012;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraEditors . SimpleButton btnCl;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LabelControl labelControl6;
        private DevExpress . XtraEditors . LabelControl labelControl5;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LabelControl labelControl7;
        private DevExpress . XtraEditors . LabelControl labelControl8;
        private DevExpress . XtraEditors . ComboBoxEdit comstate;
        private DevExpress . XtraEditors . ComboBoxEdit comUnit;
        private DevExpress . XtraEditors . ComboBoxEdit comAtt;
        private DevExpress . XtraEditors . ComboBoxEdit comClass;
        private DevExpress . XtraEditors . SimpleButton btnBatch;
    }
}