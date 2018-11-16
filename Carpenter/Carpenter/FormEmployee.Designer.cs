namespace Carpenter
{
    partial class FormEmployee
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DEP002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EMP008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.wait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageOne = new DevExpress.XtraTab.XtraTabPage();
            this.txtEMP012 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.richRemark = new DevExpress.XtraEditors.MemoEdit();
            this.texEmail = new DevExpress.XtraEditors.TextEdit();
            this.texPhone = new DevExpress.XtraEditors.TextEdit();
            this.texTel = new DevExpress.XtraEditors.TextEdit();
            this.texSalary = new DevExpress.XtraEditors.TextEdit();
            this.texDepartName = new DevExpress.XtraEditors.TextEdit();
            this.texDepartNum = new DevExpress.XtraEditors.TextEdit();
            this.comSex = new DevExpress.XtraEditors.ComboBoxEdit();
            this.texNamePerson = new DevExpress.XtraEditors.TextEdit();
            this.texNumPerson = new DevExpress.XtraEditors.TextEdit();
            this.btnDepart = new DevExpress.XtraEditors.SimpleButton();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tabPageTwo = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabPageOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMP012.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texDepartName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texDepartNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comSex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texNamePerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texNumPerson.Properties)).BeginInit();
            this.tabPageTwo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(917, 353);
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
            this.check,
            this.idx,
            this.EMP002,
            this.EMP001,
            this.EMP010,
            this.EMP012,
            this.EMP011,
            this.EMP003,
            this.DEP002,
            this.EMP004,
            this.EMP005,
            this.EMP006,
            this.EMP007,
            this.EMP008});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // check
            // 
            this.check.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.check.AppearanceCell.Options.UseFont = true;
            this.check.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.check.AppearanceHeader.Options.UseFont = true;
            this.check.Caption = "选择";
            this.check.ColumnEdit = this.repositoryItemCheckEdit1;
            this.check.FieldName = "check";
            this.check.Name = "check";
            this.check.Visible = true;
            this.check.VisibleIndex = 0;
            this.check.Width = 38;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // EMP002
            // 
            this.EMP002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP002.AppearanceCell.Options.UseFont = true;
            this.EMP002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP002.AppearanceHeader.Options.UseFont = true;
            this.EMP002.Caption = "用户姓名";
            this.EMP002.FieldName = "EMP002";
            this.EMP002.Name = "EMP002";
            this.EMP002.Visible = true;
            this.EMP002.VisibleIndex = 1;
            // 
            // EMP001
            // 
            this.EMP001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP001.AppearanceCell.Options.UseFont = true;
            this.EMP001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP001.AppearanceHeader.Options.UseFont = true;
            this.EMP001.Caption = "用户编号";
            this.EMP001.FieldName = "EMP001";
            this.EMP001.Name = "EMP001";
            this.EMP001.Visible = true;
            this.EMP001.VisibleIndex = 2;
            // 
            // EMP010
            // 
            this.EMP010.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP010.AppearanceCell.Options.UseFont = true;
            this.EMP010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP010.AppearanceHeader.Options.UseFont = true;
            this.EMP010.Caption = "性别";
            this.EMP010.FieldName = "EMP010";
            this.EMP010.Name = "EMP010";
            this.EMP010.Visible = true;
            this.EMP010.VisibleIndex = 3;
            this.EMP010.Width = 40;
            // 
            // EMP012
            // 
            this.EMP012.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP012.AppearanceCell.Options.UseFont = true;
            this.EMP012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP012.AppearanceHeader.Options.UseFont = true;
            this.EMP012.Caption = "分组";
            this.EMP012.FieldName = "EMP012";
            this.EMP012.Name = "EMP012";
            this.EMP012.Visible = true;
            this.EMP012.VisibleIndex = 4;
            this.EMP012.Width = 49;
            // 
            // EMP011
            // 
            this.EMP011.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP011.AppearanceCell.Options.UseFont = true;
            this.EMP011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP011.AppearanceHeader.Options.UseFont = true;
            this.EMP011.Caption = "工资系数";
            this.EMP011.FieldName = "EMP011";
            this.EMP011.Name = "EMP011";
            this.EMP011.Visible = true;
            this.EMP011.VisibleIndex = 5;
            this.EMP011.Width = 70;
            // 
            // EMP003
            // 
            this.EMP003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP003.AppearanceCell.Options.UseFont = true;
            this.EMP003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP003.AppearanceHeader.Options.UseFont = true;
            this.EMP003.Caption = "部门编号";
            this.EMP003.FieldName = "EMP003";
            this.EMP003.Name = "EMP003";
            this.EMP003.Visible = true;
            this.EMP003.VisibleIndex = 7;
            // 
            // DEP002
            // 
            this.DEP002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.DEP002.AppearanceCell.Options.UseFont = true;
            this.DEP002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.DEP002.AppearanceHeader.Options.UseFont = true;
            this.DEP002.Caption = "部门名称";
            this.DEP002.FieldName = "DEP002";
            this.DEP002.Name = "DEP002";
            this.DEP002.Visible = true;
            this.DEP002.VisibleIndex = 6;
            this.DEP002.Width = 89;
            // 
            // EMP004
            // 
            this.EMP004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP004.AppearanceCell.Options.UseFont = true;
            this.EMP004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP004.AppearanceHeader.Options.UseFont = true;
            this.EMP004.Caption = "电话";
            this.EMP004.FieldName = "EMP004";
            this.EMP004.Name = "EMP004";
            this.EMP004.Visible = true;
            this.EMP004.VisibleIndex = 8;
            this.EMP004.Width = 105;
            // 
            // EMP005
            // 
            this.EMP005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP005.AppearanceCell.Options.UseFont = true;
            this.EMP005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP005.AppearanceHeader.Options.UseFont = true;
            this.EMP005.Caption = "手机号";
            this.EMP005.FieldName = "EMP005";
            this.EMP005.Name = "EMP005";
            this.EMP005.Visible = true;
            this.EMP005.VisibleIndex = 9;
            this.EMP005.Width = 155;
            // 
            // EMP006
            // 
            this.EMP006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP006.AppearanceCell.Options.UseFont = true;
            this.EMP006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP006.AppearanceHeader.Options.UseFont = true;
            this.EMP006.Caption = "电子邮箱";
            this.EMP006.FieldName = "EMP006";
            this.EMP006.Name = "EMP006";
            this.EMP006.Visible = true;
            this.EMP006.VisibleIndex = 10;
            this.EMP006.Width = 236;
            // 
            // EMP007
            // 
            this.EMP007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP007.AppearanceCell.Options.UseFont = true;
            this.EMP007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP007.AppearanceHeader.Options.UseFont = true;
            this.EMP007.Caption = "备注";
            this.EMP007.FieldName = "EMP007";
            this.EMP007.Name = "EMP007";
            this.EMP007.Visible = true;
            this.EMP007.VisibleIndex = 12;
            this.EMP007.Width = 183;
            // 
            // EMP008
            // 
            this.EMP008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP008.AppearanceCell.Options.UseFont = true;
            this.EMP008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EMP008.AppearanceHeader.Options.UseFont = true;
            this.EMP008.Caption = "注销";
            this.EMP008.FieldName = "EMP008";
            this.EMP008.Name = "EMP008";
            this.EMP008.Visible = true;
            this.EMP008.VisibleIndex = 11;
            this.EMP008.Width = 44;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.wait.Location = new System.Drawing.Point(430, 125);
            this.wait.LookAndFeel.UseDefaultLookAndFeel = false;
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(246, 66);
            this.wait.TabIndex = 33;
            this.wait.Text = "progressPanel1";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 26);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabPageOne;
            this.xtraTabControl1.Size = new System.Drawing.Size(919, 379);
            this.xtraTabControl1.TabIndex = 34;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageOne,
            this.tabPageTwo});
            // 
            // tabPageOne
            // 
            this.tabPageOne.Appearance.Header.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageOne.Appearance.Header.Options.UseFont = true;
            this.tabPageOne.Controls.Add(this.txtEMP012);
            this.tabPageOne.Controls.Add(this.labelControl10);
            this.tabPageOne.Controls.Add(this.richRemark);
            this.tabPageOne.Controls.Add(this.texEmail);
            this.tabPageOne.Controls.Add(this.texPhone);
            this.tabPageOne.Controls.Add(this.texTel);
            this.tabPageOne.Controls.Add(this.texSalary);
            this.tabPageOne.Controls.Add(this.texDepartName);
            this.tabPageOne.Controls.Add(this.texDepartNum);
            this.tabPageOne.Controls.Add(this.comSex);
            this.tabPageOne.Controls.Add(this.texNamePerson);
            this.tabPageOne.Controls.Add(this.texNumPerson);
            this.tabPageOne.Controls.Add(this.btnDepart);
            this.tabPageOne.Controls.Add(this.btnLast);
            this.tabPageOne.Controls.Add(this.btnNext);
            this.tabPageOne.Controls.Add(this.btnPrevious);
            this.tabPageOne.Controls.Add(this.btnFirst);
            this.tabPageOne.Controls.Add(this.labelControl9);
            this.tabPageOne.Controls.Add(this.labelControl8);
            this.tabPageOne.Controls.Add(this.labelControl7);
            this.tabPageOne.Controls.Add(this.labelControl6);
            this.tabPageOne.Controls.Add(this.labelControl5);
            this.tabPageOne.Controls.Add(this.labelControl4);
            this.tabPageOne.Controls.Add(this.labelControl3);
            this.tabPageOne.Controls.Add(this.labelControl2);
            this.tabPageOne.Controls.Add(this.labelControl1);
            this.tabPageOne.Controls.Add(this.wait);
            this.tabPageOne.Name = "tabPageOne";
            this.tabPageOne.Size = new System.Drawing.Size(917, 353);
            this.tabPageOne.Text = "基本信息";
            // 
            // txtEMP012
            // 
            this.txtEMP012.Location = new System.Drawing.Point(230, 71);
            this.txtEMP012.MenuManager = this.barManager1;
            this.txtEMP012.Name = "txtEMP012";
            this.txtEMP012.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtEMP012.Properties.Appearance.Options.UseFont = true;
            this.txtEMP012.Size = new System.Drawing.Size(87, 20);
            this.txtEMP012.TabIndex = 60;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(182, 74);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(42, 14);
            this.labelControl10.TabIndex = 59;
            this.labelControl10.Text = "分组：";
            // 
            // richRemark
            // 
            this.richRemark.Location = new System.Drawing.Point(95, 233);
            this.richRemark.MenuManager = this.barManager1;
            this.richRemark.Name = "richRemark";
            this.richRemark.Size = new System.Drawing.Size(222, 99);
            this.richRemark.TabIndex = 58;
            // 
            // texEmail
            // 
            this.texEmail.Location = new System.Drawing.Point(95, 207);
            this.texEmail.MenuManager = this.barManager1;
            this.texEmail.Name = "texEmail";
            this.texEmail.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.texEmail.Properties.Appearance.Options.UseFont = true;
            this.texEmail.Size = new System.Drawing.Size(222, 20);
            this.texEmail.TabIndex = 57;
            // 
            // texPhone
            // 
            this.texPhone.Location = new System.Drawing.Point(95, 179);
            this.texPhone.MenuManager = this.barManager1;
            this.texPhone.Name = "texPhone";
            this.texPhone.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.texPhone.Properties.Appearance.Options.UseFont = true;
            this.texPhone.Size = new System.Drawing.Size(146, 20);
            this.texPhone.TabIndex = 56;
            // 
            // texTel
            // 
            this.texTel.Location = new System.Drawing.Point(95, 153);
            this.texTel.MenuManager = this.barManager1;
            this.texTel.Name = "texTel";
            this.texTel.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.texTel.Properties.Appearance.Options.UseFont = true;
            this.texTel.Size = new System.Drawing.Size(146, 20);
            this.texTel.TabIndex = 55;
            // 
            // texSalary
            // 
            this.texSalary.Location = new System.Drawing.Point(95, 126);
            this.texSalary.MenuManager = this.barManager1;
            this.texSalary.Name = "texSalary";
            this.texSalary.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.texSalary.Properties.Appearance.Options.UseFont = true;
            this.texSalary.Size = new System.Drawing.Size(146, 20);
            this.texSalary.TabIndex = 54;
            // 
            // texDepartName
            // 
            this.texDepartName.Location = new System.Drawing.Point(211, 97);
            this.texDepartName.MenuManager = this.barManager1;
            this.texDepartName.Name = "texDepartName";
            this.texDepartName.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.texDepartName.Properties.Appearance.Options.UseFont = true;
            this.texDepartName.Properties.ReadOnly = true;
            this.texDepartName.Size = new System.Drawing.Size(106, 20);
            this.texDepartName.TabIndex = 53;
            // 
            // texDepartNum
            // 
            this.texDepartNum.Location = new System.Drawing.Point(95, 97);
            this.texDepartNum.MenuManager = this.barManager1;
            this.texDepartNum.Name = "texDepartNum";
            this.texDepartNum.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.texDepartNum.Properties.Appearance.Options.UseFont = true;
            this.texDepartNum.Properties.ReadOnly = true;
            this.texDepartNum.Size = new System.Drawing.Size(81, 20);
            this.texDepartNum.TabIndex = 52;
            // 
            // comSex
            // 
            this.comSex.Location = new System.Drawing.Point(95, 71);
            this.comSex.MenuManager = this.barManager1;
            this.comSex.Name = "comSex";
            this.comSex.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.comSex.Properties.Appearance.Options.UseFont = true;
            this.comSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comSex.Properties.Items.AddRange(new object[] {
            "",
            "男",
            "女"});
            this.comSex.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comSex.Size = new System.Drawing.Size(81, 20);
            this.comSex.TabIndex = 51;
            // 
            // texNamePerson
            // 
            this.texNamePerson.Location = new System.Drawing.Point(95, 44);
            this.texNamePerson.MenuManager = this.barManager1;
            this.texNamePerson.Name = "texNamePerson";
            this.texNamePerson.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.texNamePerson.Properties.Appearance.Options.UseFont = true;
            this.texNamePerson.Size = new System.Drawing.Size(146, 20);
            this.texNamePerson.TabIndex = 50;
            // 
            // texNumPerson
            // 
            this.texNumPerson.Location = new System.Drawing.Point(95, 16);
            this.texNumPerson.MenuManager = this.barManager1;
            this.texNumPerson.Name = "texNumPerson";
            this.texNumPerson.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.texNumPerson.Properties.Appearance.Options.UseFont = true;
            this.texNumPerson.Size = new System.Drawing.Size(146, 20);
            this.texNumPerson.TabIndex = 49;
            // 
            // btnDepart
            // 
            this.btnDepart.Appearance.BackColor = System.Drawing.Color.Green;
            this.btnDepart.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnDepart.Appearance.Options.UseBackColor = true;
            this.btnDepart.Appearance.Options.UseFont = true;
            this.btnDepart.AppearanceDisabled.BackColor = System.Drawing.Color.Green;
            this.btnDepart.AppearanceDisabled.Options.UseBackColor = true;
            this.btnDepart.AppearanceHovered.BackColor = System.Drawing.Color.Green;
            this.btnDepart.AppearanceHovered.Options.UseBackColor = true;
            this.btnDepart.AppearancePressed.BackColor = System.Drawing.Color.Green;
            this.btnDepart.AppearancePressed.Options.UseBackColor = true;
            this.btnDepart.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnDepart.Location = new System.Drawing.Point(182, 97);
            this.btnDepart.Name = "btnDepart";
            this.btnDepart.Size = new System.Drawing.Size(23, 20);
            this.btnDepart.TabIndex = 48;
            this.btnDepart.Click += new System.EventHandler(this.btnDepart_Click);
            // 
            // btnLast
            // 
            this.btnLast.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnLast.Appearance.Options.UseFont = true;
            this.btnLast.Location = new System.Drawing.Point(462, 16);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(41, 23);
            this.btnLast.TabIndex = 47;
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Location = new System.Drawing.Point(426, 16);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 23);
            this.btnNext.TabIndex = 46;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.Appearance.Options.UseFont = true;
            this.btnPrevious.Location = new System.Drawing.Point(379, 16);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 23);
            this.btnPrevious.TabIndex = 45;
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Appearance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnFirst.Appearance.Options.UseFont = true;
            this.btnFirst.Location = new System.Drawing.Point(332, 16);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(41, 23);
            this.btnFirst.TabIndex = 44;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(43, 237);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(42, 14);
            this.labelControl9.TabIndex = 43;
            this.labelControl9.Text = "备注：";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(15, 210);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(70, 14);
            this.labelControl8.TabIndex = 42;
            this.labelControl8.Text = "电子邮件：";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(29, 182);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(56, 14);
            this.labelControl7.TabIndex = 41;
            this.labelControl7.Text = "手机号：";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(43, 155);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(42, 14);
            this.labelControl6.TabIndex = 40;
            this.labelControl6.Text = "电话：";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(15, 128);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 14);
            this.labelControl5.TabIndex = 39;
            this.labelControl5.Text = "工资系数：";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(43, 100);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(42, 14);
            this.labelControl4.TabIndex = 38;
            this.labelControl4.Text = "部门：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(43, 74);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 14);
            this.labelControl3.TabIndex = 37;
            this.labelControl3.Text = "性别：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(15, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "用户姓名：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(15, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 35;
            this.labelControl1.Text = "用户编号：";
            // 
            // tabPageTwo
            // 
            this.tabPageTwo.Appearance.Header.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabPageTwo.Appearance.Header.Options.UseFont = true;
            this.tabPageTwo.Controls.Add(this.gridControl1);
            this.tabPageTwo.Name = "tabPageTwo";
            this.tabPageTwo.Size = new System.Drawing.Size(917, 353);
            this.tabPageTwo.Text = "详细信息";
            // 
            // FormEmployee
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 405);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FormEmployee";
            this.Text = "人员信息";
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabPageOne.ResumeLayout(false);
            this.tabPageOne.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMP012.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texDepartName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texDepartNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comSex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texNamePerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texNumPerson.Properties)).EndInit();
            this.tabPageTwo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn EMP002;
        private DevExpress . XtraGrid . Columns . GridColumn EMP001;
        private DevExpress . XtraGrid . Columns . GridColumn EMP003;
        private DevExpress . XtraGrid . Columns . GridColumn DEP002;
        private DevExpress . XtraGrid . Columns . GridColumn EMP004;
        private DevExpress . XtraGrid . Columns . GridColumn EMP005;
        private DevExpress . XtraGrid . Columns . GridColumn EMP006;
        private DevExpress . XtraGrid . Columns . GridColumn EMP007;
        private DevExpress . XtraGrid . Columns . GridColumn EMP008;
        private System . Windows . Forms . ErrorProvider errorProvider1;
        private System . ComponentModel . BackgroundWorker backgroundWorker1;
        private DevExpress . XtraGrid . Columns . GridColumn EMP010;
        private DevExpress . XtraGrid . Columns . GridColumn EMP011;
        private DevExpress . XtraGrid . Columns . GridColumn check;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress . XtraWaitForm . ProgressPanel wait;
        private DevExpress . XtraTab . XtraTabControl xtraTabControl1;
        private DevExpress . XtraTab . XtraTabPage tabPageOne;
        private DevExpress . XtraTab . XtraTabPage tabPageTwo;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl8;
        private DevExpress . XtraEditors . LabelControl labelControl7;
        private DevExpress . XtraEditors . LabelControl labelControl6;
        private DevExpress . XtraEditors . LabelControl labelControl5;
        private DevExpress . XtraEditors . LabelControl labelControl9;
        private DevExpress . XtraEditors . SimpleButton btnPrevious;
        private DevExpress . XtraEditors . SimpleButton btnFirst;
        private DevExpress . XtraEditors . SimpleButton btnNext;
        private DevExpress . XtraEditors . SimpleButton btnLast;
        private DevExpress . XtraEditors . SimpleButton btnDepart;
        private DevExpress . XtraEditors . TextEdit texNumPerson;
        private DevExpress . XtraEditors . TextEdit texNamePerson;
        private DevExpress . XtraEditors . ComboBoxEdit comSex;
        private DevExpress . XtraEditors . TextEdit texDepartNum;
        private DevExpress . XtraEditors . TextEdit texDepartName;
        private DevExpress . XtraEditors . TextEdit texTel;
        private DevExpress . XtraEditors . TextEdit texSalary;
        private DevExpress . XtraEditors . MemoEdit richRemark;
        private DevExpress . XtraEditors . TextEdit texEmail;
        private DevExpress . XtraEditors . TextEdit texPhone;
        private DevExpress . XtraEditors . LabelControl labelControl10;
        private DevExpress . XtraEditors . TextEdit txtEMP012;
        private DevExpress . XtraGrid . Columns . GridColumn EMP012;
    }
}