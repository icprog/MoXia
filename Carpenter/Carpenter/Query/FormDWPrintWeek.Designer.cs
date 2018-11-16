namespace Carpenter . Query
{
    partial class FormDWPrintWeek
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
            this.dwp = new Carpenter.ControlUser.DWPrintWeekControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOne = new System.Windows.Forms.TabPage();
            this.tabPageTwo = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtOrder = new DevExpress.XtraEditors.DateEdit();
            this.tabControl1.SuspendLayout();
            this.tabPageOne.SuspendLayout();
            this.tabPageTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOrder.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOrder.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dwp
            // 
            this.dwp.Appearance.BackColor = System.Drawing.Color.White;
            this.dwp.Appearance.Options.UseBackColor = true;
            this.dwp.Location = new System.Drawing.Point(6, 6);
            this.dwp.Name = "dwp";
            this.dwp.Size = new System.Drawing.Size(240, 157);
            this.dwp.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageOne);
            this.tabControl1.Controls.Add(this.tabPageTwo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(264, 196);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageOne
            // 
            this.tabPageOne.Controls.Add(this.dwp);
            this.tabPageOne.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPageOne.Location = new System.Drawing.Point(4, 24);
            this.tabPageOne.Name = "tabPageOne";
            this.tabPageOne.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOne.Size = new System.Drawing.Size(256, 168);
            this.tabPageOne.TabIndex = 0;
            this.tabPageOne.Text = "常规报工";
            this.tabPageOne.UseVisualStyleBackColor = true;
            // 
            // tabPageTwo
            // 
            this.tabPageTwo.Controls.Add(this.btnCancel);
            this.tabPageTwo.Controls.Add(this.btnOk);
            this.tabPageTwo.Controls.Add(this.cmbName);
            this.tabPageTwo.Controls.Add(this.labelControl1);
            this.tabPageTwo.Controls.Add(this.labelControl2);
            this.tabPageTwo.Controls.Add(this.dtOrder);
            this.tabPageTwo.Location = new System.Drawing.Point(4, 22);
            this.tabPageTwo.Name = "tabPageTwo";
            this.tabPageTwo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTwo.Size = new System.Drawing.Size(256, 170);
            this.tabPageTwo.TabIndex = 1;
            this.tabPageTwo.Text = "非常规报工";
            this.tabPageTwo.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(140, 111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 26);
            this.btnCancel.TabIndex = 64;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(35, 111);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(68, 26);
            this.btnOk.TabIndex = 63;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click_1);
            // 
            // cmbName
            // 
            this.cmbName.Location = new System.Drawing.Point(93, 58);
            this.cmbName.Name = "cmbName";
            this.cmbName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbName.Properties.ImmediatePopup = true;
            this.cmbName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbName.Size = new System.Drawing.Size(115, 20);
            this.cmbName.TabIndex = 62;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(31, 61);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 14);
            this.labelControl1.TabIndex = 59;
            this.labelControl1.Text = "报工人：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(17, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 58;
            this.labelControl2.Text = "报工日期：";
            // 
            // dtOrder
            // 
            this.dtOrder.EditValue = null;
            this.dtOrder.Location = new System.Drawing.Point(93, 18);
            this.dtOrder.Name = "dtOrder";
            this.dtOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtOrder.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtOrder.Size = new System.Drawing.Size(115, 20);
            this.dtOrder.TabIndex = 57;
            // 
            // FormDWPrintWeek
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 196);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormDWPrintWeek";
            this.Text = "";
            this.tabControl1.ResumeLayout(false);
            this.tabPageOne.ResumeLayout(false);
            this.tabPageTwo.ResumeLayout(false);
            this.tabPageTwo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOrder.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOrder.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser . DWPrintWeekControl dwp;
        private System . Windows . Forms . TabControl tabControl1;
        private System . Windows . Forms . TabPage tabPageOne;
        private System . Windows . Forms . TabPage tabPageTwo;
        private DevExpress . XtraEditors . ComboBoxEdit cmbName;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . DateEdit dtOrder;
        public System . Windows . Forms . Button btnCancel;
        public System . Windows . Forms . Button btnOk;
    }
}