namespace Carpenter
{
    partial class FormEquipment
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
            this.components = new System.ComponentModel.Container();
            this.mEdit = new DevExpress.XtraEditors.MemoEdit();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idx_one = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EQV002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ART001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ART002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EQV003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EQU001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EQU002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EQU003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EQU004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EQU005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EQU007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EQU010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.TabPageOne = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.cmdEquWork = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.texNameEqui = new DevExpress.XtraEditors.TextEdit();
            this.texTypeEqui = new DevExpress.XtraEditors.TextEdit();
            this.texNumEqui = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.TabPageTwo = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.mEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.TabPageOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEquWork.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texNameEqui.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texTypeEqui.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texNumEqui.Properties)).BeginInit();
            this.TabPageTwo.SuspendLayout();
            this.SuspendLayout();
            // 
            // mEdit
            // 
            this.mEdit.Location = new System.Drawing.Point(583, 16);
            this.mEdit.Name = "mEdit";
            this.mEdit.Size = new System.Drawing.Size(343, 92);
            this.mEdit.TabIndex = 35;
            // 
            // wait
            // 
            this.wait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wait.Appearance.Options.UseBackColor = true;
            this.wait.BarAnimationElementThickness = 2;
            this.wait.Caption = "请稍后";
            this.wait.Description = "数据加载中 ...";
            this.wait.Location = new System.Drawing.Point(443, 69);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 33;
            this.wait.Text = "progressPanel1";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1});
            this.gridControl2.Size = new System.Drawing.Size(1234, 259);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridControl2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl2_KeyPress);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView2.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idx_one,
            this.EQV002,
            this.EQV003});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.IndicatorWidth = 45;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView2_CustomDrawRowIndicator);
            this.gridView2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanged);
            // 
            // idx_one
            // 
            this.idx_one.Caption = "编号";
            this.idx_one.FieldName = "idx";
            this.idx_one.Name = "idx_one";
            // 
            // EQV002
            // 
            this.EQV002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQV002.AppearanceCell.Options.UseFont = true;
            this.EQV002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQV002.AppearanceHeader.Options.UseFont = true;
            this.EQV002.Caption = "工艺编号";
            this.EQV002.ColumnEdit = this.repositoryItemGridLookUpEdit1;
            this.EQV002.FieldName = "EQV002";
            this.EQV002.Name = "EQV002";
            this.EQV002.Visible = true;
            this.EQV002.VisibleIndex = 0;
            this.EQV002.Width = 407;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.ImmediatePopup = true;
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.NullText = "";
            this.repositoryItemGridLookUpEdit1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.DoubleClick;
            this.repositoryItemGridLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryItemGridLookUpEdit1.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.repositoryItemGridLookUpEdit1View.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.repositoryItemGridLookUpEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ART001,
            this.ART002});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // ART001
            // 
            this.ART001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ART001.AppearanceCell.Options.UseFont = true;
            this.ART001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.ART001.AppearanceHeader.Options.UseFont = true;
            this.ART001.Caption = "工艺编号";
            this.ART001.FieldName = "ART001";
            this.ART001.Name = "ART001";
            this.ART001.Visible = true;
            this.ART001.VisibleIndex = 0;
            // 
            // ART002
            // 
            this.ART002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.ART002.AppearanceCell.Options.UseFont = true;
            this.ART002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.ART002.AppearanceHeader.Options.UseFont = true;
            this.ART002.Caption = "工艺名称";
            this.ART002.FieldName = "ART002";
            this.ART002.Name = "ART002";
            this.ART002.Visible = true;
            this.ART002.VisibleIndex = 1;
            // 
            // EQV003
            // 
            this.EQV003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQV003.AppearanceCell.Options.UseFont = true;
            this.EQV003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQV003.AppearanceHeader.Options.UseFont = true;
            this.EQV003.Caption = "工艺名称";
            this.EQV003.FieldName = "EQV003";
            this.EQV003.Name = "EQV003";
            this.EQV003.Visible = true;
            this.EQV003.VisibleIndex = 1;
            this.EQV003.Width = 642;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1234, 390);
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
            this.EQU001,
            this.EQU002,
            this.EQU003,
            this.EQU004,
            this.EQU005,
            this.EQU007,
            this.EQU010});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.RowAutoHeight = true;
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
            // EQU001
            // 
            this.EQU001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQU001.AppearanceCell.Options.UseFont = true;
            this.EQU001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQU001.AppearanceHeader.Options.UseFont = true;
            this.EQU001.Caption = "设备编码";
            this.EQU001.FieldName = "EQU001";
            this.EQU001.Name = "EQU001";
            this.EQU001.Visible = true;
            this.EQU001.VisibleIndex = 1;
            this.EQU001.Width = 110;
            // 
            // EQU002
            // 
            this.EQU002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQU002.AppearanceCell.Options.UseFont = true;
            this.EQU002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQU002.AppearanceHeader.Options.UseFont = true;
            this.EQU002.Caption = "设备名称";
            this.EQU002.FieldName = "EQU002";
            this.EQU002.Name = "EQU002";
            this.EQU002.Visible = true;
            this.EQU002.VisibleIndex = 2;
            this.EQU002.Width = 168;
            // 
            // EQU003
            // 
            this.EQU003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQU003.AppearanceCell.Options.UseFont = true;
            this.EQU003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQU003.AppearanceHeader.Options.UseFont = true;
            this.EQU003.Caption = "设备型号";
            this.EQU003.FieldName = "EQU003";
            this.EQU003.Name = "EQU003";
            this.EQU003.Visible = true;
            this.EQU003.VisibleIndex = 3;
            this.EQU003.Width = 207;
            // 
            // EQU004
            // 
            this.EQU004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQU004.AppearanceCell.Options.UseFont = true;
            this.EQU004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQU004.AppearanceHeader.Options.UseFont = true;
            this.EQU004.Caption = "设备状态";
            this.EQU004.FieldName = "EQU004";
            this.EQU004.Name = "EQU004";
            this.EQU004.Visible = true;
            this.EQU004.VisibleIndex = 4;
            this.EQU004.Width = 159;
            // 
            // EQU005
            // 
            this.EQU005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQU005.AppearanceCell.Options.UseFont = true;
            this.EQU005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQU005.AppearanceHeader.Options.UseFont = true;
            this.EQU005.Caption = "设备车间";
            this.EQU005.FieldName = "EQU005";
            this.EQU005.Name = "EQU005";
            this.EQU005.Visible = true;
            this.EQU005.VisibleIndex = 5;
            this.EQU005.Width = 159;
            // 
            // EQU007
            // 
            this.EQU007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQU007.AppearanceCell.Options.UseFont = true;
            this.EQU007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQU007.AppearanceHeader.Options.UseFont = true;
            this.EQU007.Caption = "注销";
            this.EQU007.FieldName = "EQU007";
            this.EQU007.Name = "EQU007";
            this.EQU007.Visible = true;
            this.EQU007.VisibleIndex = 6;
            this.EQU007.Width = 39;
            // 
            // EQU010
            // 
            this.EQU010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQU010.AppearanceCell.Options.UseFont = true;
            this.EQU010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EQU010.AppearanceHeader.Options.UseFont = true;
            this.EQU010.Caption = "备注";
            this.EQU010.ColumnEdit = this.repositoryItemMemoEdit1;
            this.EQU010.FieldName = "EQU010";
            this.EQU010.Name = "EQU010";
            this.EQU010.Visible = true;
            this.EQU010.VisibleIndex = 7;
            this.EQU010.Width = 162;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 26);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.TabPageOne;
            this.xtraTabControl1.Size = new System.Drawing.Size(1236, 416);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TabPageOne,
            this.TabPageTwo});
            // 
            // TabPageOne
            // 
            this.TabPageOne.Appearance.Header.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPageOne.Appearance.Header.Options.UseFont = true;
            this.TabPageOne.Controls.Add(this.splitContainerControl1);
            this.TabPageOne.Name = "TabPageOne";
            this.TabPageOne.Size = new System.Drawing.Size(1234, 390);
            this.TabPageOne.Text = "基本信息";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.cmdEquWork);
            this.splitContainerControl1.Panel1.Controls.Add(this.comState);
            this.splitContainerControl1.Panel1.Controls.Add(this.texNameEqui);
            this.splitContainerControl1.Panel1.Controls.Add(this.texTypeEqui);
            this.splitContainerControl1.Panel1.Controls.Add(this.texNumEqui);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl6);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnLast);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnNext);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnPrevious);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnFirst);
            this.splitContainerControl1.Panel1.Controls.Add(this.mEdit);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.wait);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1234, 390);
            this.splitContainerControl1.SplitterPosition = 119;
            this.splitContainerControl1.TabIndex = 33;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // cmdEquWork
            // 
            this.cmdEquWork.Location = new System.Drawing.Point(349, 49);
            this.cmdEquWork.MenuManager = this.barManager1;
            this.cmdEquWork.Name = "cmdEquWork";
            this.cmdEquWork.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEquWork.Properties.Appearance.Options.UseFont = true;
            this.cmdEquWork.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmdEquWork.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmdEquWork.Size = new System.Drawing.Size(146, 20);
            this.cmdEquWork.TabIndex = 50;
            // 
            // comState
            // 
            this.comState.Location = new System.Drawing.Point(95, 84);
            this.comState.MenuManager = this.barManager1;
            this.comState.Name = "comState";
            this.comState.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comState.Properties.Appearance.Options.UseFont = true;
            this.comState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comState.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comState.Size = new System.Drawing.Size(146, 20);
            this.comState.TabIndex = 49;
            // 
            // texNameEqui
            // 
            this.texNameEqui.Location = new System.Drawing.Point(349, 15);
            this.texNameEqui.MenuManager = this.barManager1;
            this.texNameEqui.Name = "texNameEqui";
            this.texNameEqui.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.texNameEqui.Properties.Appearance.Options.UseFont = true;
            this.texNameEqui.Size = new System.Drawing.Size(146, 20);
            this.texNameEqui.TabIndex = 48;
            // 
            // texTypeEqui
            // 
            this.texTypeEqui.Location = new System.Drawing.Point(95, 49);
            this.texTypeEqui.MenuManager = this.barManager1;
            this.texTypeEqui.Name = "texTypeEqui";
            this.texTypeEqui.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.texTypeEqui.Properties.Appearance.Options.UseFont = true;
            this.texTypeEqui.Size = new System.Drawing.Size(146, 20);
            this.texTypeEqui.TabIndex = 47;
            // 
            // texNumEqui
            // 
            this.texNumEqui.Location = new System.Drawing.Point(95, 15);
            this.texNumEqui.MenuManager = this.barManager1;
            this.texNumEqui.Name = "texNumEqui";
            this.texNumEqui.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.texNumEqui.Properties.Appearance.Options.UseFont = true;
            this.texNumEqui.Size = new System.Drawing.Size(146, 20);
            this.texNumEqui.TabIndex = 46;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(535, 18);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(42, 14);
            this.labelControl6.TabIndex = 45;
            this.labelControl6.Text = "备注：";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(273, 52);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 14);
            this.labelControl5.TabIndex = 44;
            this.labelControl5.Text = "设备车间：";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(273, 18);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 14);
            this.labelControl4.TabIndex = 43;
            this.labelControl4.Text = "设备名称：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(19, 87);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 14);
            this.labelControl3.TabIndex = 42;
            this.labelControl3.Text = "设备状态：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(19, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 41;
            this.labelControl2.Text = "设备型号：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(19, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 40;
            this.labelControl1.Text = "设备编号：";
            // 
            // btnLast
            // 
            this.btnLast.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnLast.Appearance.Options.UseFont = true;
            this.btnLast.Location = new System.Drawing.Point(1079, 78);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(41, 28);
            this.btnLast.TabIndex = 39;
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Location = new System.Drawing.Point(1043, 78);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 28);
            this.btnNext.TabIndex = 38;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.Appearance.Options.UseFont = true;
            this.btnPrevious.Location = new System.Drawing.Point(996, 78);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 28);
            this.btnPrevious.TabIndex = 37;
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnFirst.Appearance.Options.UseFont = true;
            this.btnFirst.Location = new System.Drawing.Point(949, 78);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(41, 28);
            this.btnFirst.TabIndex = 36;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // TabPageTwo
            // 
            this.TabPageTwo.Appearance.Header.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPageTwo.Appearance.Header.Options.UseFont = true;
            this.TabPageTwo.Controls.Add(this.gridControl1);
            this.TabPageTwo.Name = "TabPageTwo";
            this.TabPageTwo.Size = new System.Drawing.Size(1234, 390);
            this.TabPageTwo.Text = "详细信息";
            // 
            // FormEquipment
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 442);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FormEquipment";
            this.Text = "设备信息";
            this.Load += new System.EventHandler(this.FormEquipment_Load);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.mEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.TabPageOne.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmdEquWork.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texNameEqui.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texTypeEqui.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texNumEqui.Properties)).EndInit();
            this.TabPageTwo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn EQU001;
        private DevExpress . XtraGrid . Columns . GridColumn EQU002;
        private DevExpress . XtraGrid . Columns . GridColumn EQU003;
        private DevExpress . XtraGrid . Columns . GridColumn EQU004;
        private DevExpress . XtraGrid . Columns . GridColumn EQU005;
        private DevExpress . XtraGrid . Columns . GridColumn EQU007;
        private DevExpress . XtraGrid . GridControl gridControl2;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView2;
        private DevExpress . XtraGrid . Columns . GridColumn EQV002;
        private DevExpress . XtraGrid . Columns . GridColumn EQV003;
        private DevExpress . XtraGrid . Columns . GridColumn idx_one;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private System . Windows . Forms . ErrorProvider errorProvider1;
        private DevExpress . XtraEditors . Repository . RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress . XtraGrid . Views . Grid . GridView repositoryItemGridLookUpEdit1View;
        private DevExpress . XtraGrid . Columns . GridColumn ART001;
        private DevExpress . XtraGrid . Columns . GridColumn ART002;
        private System . ComponentModel . BackgroundWorker backgroundWorker2;
        private System . ComponentModel . BackgroundWorker backgroundWorker3;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private DevExpress . XtraEditors . MemoEdit mEdit;
        private DevExpress . XtraGrid . Columns . GridColumn EQU010;
        private DevExpress . XtraEditors . Repository . RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress . XtraTab . XtraTabControl xtraTabControl1;
        private DevExpress . XtraTab . XtraTabPage TabPageOne;
        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraTab . XtraTabPage TabPageTwo;
        private DevExpress . XtraEditors . SimpleButton btnFirst;
        private DevExpress . XtraEditors . SimpleButton btnPrevious;
        private DevExpress . XtraEditors . SimpleButton btnLast;
        private DevExpress . XtraEditors . SimpleButton btnNext;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LabelControl labelControl6;
        private DevExpress . XtraEditors . LabelControl labelControl5;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private DevExpress . XtraEditors . TextEdit texNumEqui;
        private DevExpress . XtraEditors . TextEdit texNameEqui;
        private DevExpress . XtraEditors . TextEdit texTypeEqui;
        private DevExpress . XtraEditors . ComboBoxEdit comState;
        private DevExpress . XtraEditors . ComboBoxEdit cmdEquWork;
    }
}