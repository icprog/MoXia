namespace Carpenter . OrderEdit
{
    partial class PaintAllInfoEdit
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.mePDP021 = new DevExpress.XtraEditors.MemoEdit();
            this.txtPDP020 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.mePDP006 = new DevExpress.XtraEditors.MemoEdit();
            this.txtPDP005 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtPDP007 = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mePDP021.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPDP020.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mePDP006.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPDP005.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPDP007.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPDP007.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(431, 264);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 82;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(350, 264);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 26);
            this.btnOk.TabIndex = 81;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.BackColor = System.Drawing.Color.Gray;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.mePDP021);
            this.groupControl2.Controls.Add(this.txtPDP020);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Location = new System.Drawing.Point(251, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(255, 246);
            this.groupControl2.TabIndex = 80;
            this.groupControl2.Text = "软包";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(19, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 14);
            this.labelControl1.TabIndex = 75;
            this.labelControl1.Text = "完工累计量：";
            // 
            // mePDP021
            // 
            this.mePDP021.Location = new System.Drawing.Point(30, 103);
            this.mePDP021.Name = "mePDP021";
            this.mePDP021.Size = new System.Drawing.Size(220, 138);
            this.mePDP021.TabIndex = 5;
            // 
            // txtPDP020
            // 
            this.txtPDP020.Location = new System.Drawing.Point(109, 30);
            this.txtPDP020.Name = "txtPDP020";
            this.txtPDP020.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDP020.Properties.Appearance.Options.UseFont = true;
            this.txtPDP020.Size = new System.Drawing.Size(118, 20);
            this.txtPDP020.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(10, 103);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(14, 70);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "报\r\n工\r\n备\r\n注\r\n：";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.BackColor = System.Drawing.Color.Gray;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.mePDP006);
            this.groupControl1.Controls.Add(this.txtPDP005);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.dtPDP007);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(233, 246);
            this.groupControl1.TabIndex = 79;
            this.groupControl1.Text = "白坯";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(19, 33);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 14);
            this.labelControl4.TabIndex = 75;
            this.labelControl4.Text = "完工累计量：";
            // 
            // mePDP006
            // 
            this.mePDP006.Location = new System.Drawing.Point(33, 102);
            this.mePDP006.Name = "mePDP006";
            this.mePDP006.Size = new System.Drawing.Size(194, 139);
            this.mePDP006.TabIndex = 5;
            // 
            // txtPDP005
            // 
            this.txtPDP005.Location = new System.Drawing.Point(109, 30);
            this.txtPDP005.Name = "txtPDP005";
            this.txtPDP005.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDP005.Properties.Appearance.Options.UseFont = true;
            this.txtPDP005.Size = new System.Drawing.Size(118, 20);
            this.txtPDP005.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(13, 104);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(14, 70);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "报\r\n工\r\n备\r\n注\r\n：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(98, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "最近来货时间：";
            // 
            // dtPDP007
            // 
            this.dtPDP007.EditValue = null;
            this.dtPDP007.Location = new System.Drawing.Point(109, 66);
            this.dtPDP007.Name = "dtPDP007";
            this.dtPDP007.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPDP007.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPDP007.Size = new System.Drawing.Size(118, 20);
            this.dtPDP007.TabIndex = 3;
            // 
            // PaintAllInfoEdit
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 296);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.Name = "PaintAllInfoEdit";
            this.Text = "PaintAllInfoEdit";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mePDP021.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPDP020.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mePDP006.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPDP005.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPDP007.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPDP007.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . Button btnCancel;
        private System . Windows . Forms . Button btnOk;
        private DevExpress . XtraEditors . GroupControl groupControl2;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . MemoEdit mePDP021;
        private DevExpress . XtraEditors . TextEdit txtPDP020;
        private DevExpress . XtraEditors . LabelControl labelControl5;
        private DevExpress . XtraEditors . GroupControl groupControl1;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private DevExpress . XtraEditors . MemoEdit mePDP006;
        private DevExpress . XtraEditors . TextEdit txtPDP005;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . DateEdit dtPDP007;
    }
}