namespace Carpenter . Query
{
    partial class SetReviewEdit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.texLevel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCan = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lupNamePro = new DevExpress.XtraEditors.LookUpEdit();
            this.lupNamePerson = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupNamePro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupNamePerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.texLevel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCan);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.lupNamePro);
            this.panel1.Controls.Add(this.lupNamePerson);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 147);
            this.panel1.TabIndex = 0;
            // 
            // texLevel
            // 
            this.texLevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.texLevel.Location = new System.Drawing.Point(101, 75);
            this.texLevel.Name = "texLevel";
            this.texLevel.Size = new System.Drawing.Size(161, 23);
            this.texLevel.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(18, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 39;
            this.label2.Text = "送审级别：";
            // 
            // btnCan
            // 
            this.btnCan.AutoSize = true;
            this.btnCan.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCan.Location = new System.Drawing.Point(203, 111);
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(58, 26);
            this.btnCan.TabIndex = 38;
            this.btnCan.Text = "取消";
            this.btnCan.UseVisualStyleBackColor = false;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(98, 111);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(58, 26);
            this.btnOk.TabIndex = 37;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lupNamePro
            // 
            this.lupNamePro.Location = new System.Drawing.Point(101, 45);
            this.lupNamePro.Name = "lupNamePro";
            this.lupNamePro.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupNamePro.Properties.Appearance.Options.UseFont = true;
            this.lupNamePro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupNamePro.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FOR002", 50, "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FOR001", 55, "名称")});
            this.lupNamePro.Properties.NullText = "";
            this.lupNamePro.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupNamePro.Properties.ShowFooter = false;
            this.lupNamePro.Size = new System.Drawing.Size(160, 20);
            this.lupNamePro.TabIndex = 36;
            // 
            // lupNamePerson
            // 
            this.lupNamePerson.Location = new System.Drawing.Point(101, 15);
            this.lupNamePerson.Name = "lupNamePerson";
            this.lupNamePerson.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupNamePerson.Properties.Appearance.Options.UseFont = true;
            this.lupNamePerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupNamePerson.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EMP001", 35, "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EMP002", 55, "姓名")});
            this.lupNamePerson.Properties.NullText = "";
            this.lupNamePerson.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupNamePerson.Properties.ShowFooter = false;
            this.lupNamePerson.Size = new System.Drawing.Size(160, 20);
            this.lupNamePerson.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(18, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 34;
            this.label4.Text = "程序名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 33;
            this.label1.Text = "人员姓名：";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SetReviewEdit
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 147);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetReviewEdit";
            this.Text = "SetReviewEdit";
            this.Load += new System.EventHandler(this.SetReviewEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupNamePro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupNamePerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System . Windows . Forms . Panel panel1;
        private DevExpress . XtraEditors . LookUpEdit lupNamePro;
        private DevExpress . XtraEditors . LookUpEdit lupNamePerson;
        private System . Windows . Forms . Label label4;
        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . Button btnCan;
        private System . Windows . Forms . Button btnOk;
        private System . Windows . Forms . TextBox texLevel;
        private System . Windows . Forms . Label label2;
        private System . Windows . Forms . ErrorProvider errorProvider1;
    }
}