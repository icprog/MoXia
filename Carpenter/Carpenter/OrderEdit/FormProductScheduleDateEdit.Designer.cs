namespace Carpenter . OrderEdit
{
    partial class FormProductScheduleDateEdit
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labP = new DevExpress.XtraEditors.LabelControl();
            this.labPro = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dtJ = new DevExpress.XtraEditors.DateEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtJ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtJ.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(33, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "批号：";
            // 
            // labP
            // 
            this.labP.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labP.Appearance.Options.UseFont = true;
            this.labP.Location = new System.Drawing.Point(81, 26);
            this.labP.Name = "labP";
            this.labP.Size = new System.Drawing.Size(91, 14);
            this.labP.TabIndex = 1;
            this.labP.Text = "labelControl2";
            // 
            // labPro
            // 
            this.labPro.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPro.Appearance.Options.UseFont = true;
            this.labPro.Location = new System.Drawing.Point(81, 59);
            this.labPro.Name = "labPro";
            this.labPro.Size = new System.Drawing.Size(91, 14);
            this.labPro.TabIndex = 3;
            this.labPro.Text = "labelControl2";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(33, 59);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "品号：";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(33, 96);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(42, 14);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "日期：";
            // 
            // dtJ
            // 
            this.dtJ.EditValue = null;
            this.dtJ.Location = new System.Drawing.Point(81, 93);
            this.dtJ.Name = "dtJ";
            this.dtJ.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtJ.Properties.Appearance.Options.UseFont = true;
            this.dtJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtJ.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtJ.Properties.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.dtJ.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtJ.Properties.EditFormat.FormatString = "yyyy/MM/dd";
            this.dtJ.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtJ.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dtJ.Size = new System.Drawing.Size(132, 20);
            this.dtJ.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(57, 151);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(138, 151);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormProductScheduleDateEdit
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 196);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dtJ);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labPro);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labP);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormProductScheduleDateEdit";
            this.Text = "加急日期编辑";
            ((System.ComponentModel.ISupportInitialize)(this.dtJ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtJ.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LabelControl labP;
        private DevExpress . XtraEditors . LabelControl labPro;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LabelControl labelControl5;
        private DevExpress . XtraEditors . DateEdit dtJ;
        private DevExpress . XtraEditors . SimpleButton btnOk;
        private DevExpress . XtraEditors . SimpleButton btnCancel;
    }
}