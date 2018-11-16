namespace Carpenter . ControlUser
{
    partial class DWPrintWeekControl
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
            this.lupPerson = new DevExpress.XtraEditors.LookUpEdit();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lupWeek = new DevExpress.XtraEditors.LookUpEdit();
            this.lupYear = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupWeek.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lupPerson
            // 
            this.lupPerson.Location = new System.Drawing.Point(86, 86);
            this.lupPerson.Name = "lupPerson";
            this.lupPerson.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupPerson.Properties.Appearance.Options.UseFont = true;
            this.lupPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPerson.Properties.NullText = "";
            this.lupPerson.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupPerson.Properties.ShowHeader = false;
            this.lupPerson.Size = new System.Drawing.Size(121, 20);
            this.lupPerson.TabIndex = 48;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(139, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 26);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(34, 126);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(68, 26);
            this.btnOk.TabIndex = 45;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(32, 89);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 44;
            this.labelControl3.Text = "报工人：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(44, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 42;
            this.labelControl2.Text = "周次：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(56, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 41;
            this.labelControl1.Text = "年：";
            // 
            // lupWeek
            // 
            this.lupWeek.Location = new System.Drawing.Point(86, 51);
            this.lupWeek.Name = "lupWeek";
            this.lupWeek.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupWeek.Properties.Appearance.Options.UseFont = true;
            this.lupWeek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupWeek.Properties.NullText = "";
            this.lupWeek.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupWeek.Properties.ShowHeader = false;
            this.lupWeek.Size = new System.Drawing.Size(121, 20);
            this.lupWeek.TabIndex = 49;
            // 
            // lupYear
            // 
            this.lupYear.Location = new System.Drawing.Point(86, 18);
            this.lupYear.Name = "lupYear";
            this.lupYear.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupYear.Properties.Appearance.Options.UseFont = true;
            this.lupYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupYear.Properties.NullText = "";
            this.lupYear.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupYear.Properties.ShowHeader = false;
            this.lupYear.Size = new System.Drawing.Size(121, 20);
            this.lupYear.TabIndex = 50;
            this.lupYear.TextChanged += new System.EventHandler(this.lupYear_TextChanged);
            // 
            // DWPrintWeekControl
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lupYear);
            this.Controls.Add(this.lupWeek);
            this.Controls.Add(this.lupPerson);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "DWPrintWeekControl";
            this.Size = new System.Drawing.Size(231, 166);
            ((System.ComponentModel.ISupportInitialize)(this.lupPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupWeek.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupYear.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress . XtraEditors . LookUpEdit lupPerson;
        public System . Windows . Forms . Button btnCancel;
        public System . Windows . Forms . Button btnOk;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        public DevExpress . XtraEditors . LookUpEdit lupWeek;
        public DevExpress . XtraEditors . LookUpEdit lupYear;
    }
}
