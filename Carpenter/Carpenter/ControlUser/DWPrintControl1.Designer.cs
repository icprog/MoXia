namespace Carpenter . ControlUser
{
    partial class DWPrintControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbWorkShop = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbPerson = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWorkShop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPerson.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "报工工段：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "报工时间：";
            // 
            // dateEdit
            // 
            this.dateEdit.EditValue = null;
            this.dateEdit.Location = new System.Drawing.Point(90, 55);
            this.dateEdit.Name = "dateEdit";
            this.dateEdit.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateEdit.Properties.Appearance.Options.UseFont = true;
            this.dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit.Size = new System.Drawing.Size(121, 18);
            this.dateEdit.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(36, 93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "报工人：";
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(35, 127);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(71, 26);
            this.btnOk.TabIndex = 37;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(140, 127);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 26);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // cmbWorkShop
            // 
            this.cmbWorkShop.Location = new System.Drawing.Point(90, 22);
            this.cmbWorkShop.Name = "cmbWorkShop";
            this.cmbWorkShop.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbWorkShop.Properties.Appearance.Options.UseFont = true;
            this.cmbWorkShop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbWorkShop.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbWorkShop.Size = new System.Drawing.Size(121, 18);
            this.cmbWorkShop.TabIndex = 39;
            // 
            // cmbPerson
            // 
            this.cmbPerson.Location = new System.Drawing.Point(90, 90);
            this.cmbPerson.Name = "cmbPerson";
            this.cmbPerson.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPerson.Properties.Appearance.Options.UseFont = true;
            this.cmbPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPerson.Properties.NullText = "";
            this.cmbPerson.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cmbPerson.Properties.ShowHeader = false;
            this.cmbPerson.Size = new System.Drawing.Size(121, 18);
            this.cmbPerson.TabIndex = 40;
            // 
            // DWPrintControl1
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbPerson);
            this.Controls.Add(this.cmbWorkShop);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.dateEdit);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "DWPrintControl1";
            this.Size = new System.Drawing.Size(234, 171);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWorkShop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPerson.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        public System . Windows . Forms . Button btnOk;
        public System . Windows . Forms . Button btnCancel;
        public DevExpress . XtraEditors . DateEdit dateEdit;
        public DevExpress . XtraEditors . ComboBoxEdit cmbWorkShop;
        public DevExpress . XtraEditors . LookUpEdit cmbPerson;
    }
}
