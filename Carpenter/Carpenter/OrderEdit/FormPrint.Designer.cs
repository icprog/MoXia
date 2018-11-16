namespace Carpenter . OrderEdit
{
    partial class FormPrint
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtOrder = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.cmbName = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOrder.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(26, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 51;
            this.labelControl2.Text = "报工日期：";
            // 
            // dtOrder
            // 
            this.dtOrder.EditValue = null;
            this.dtOrder.Location = new System.Drawing.Point(102, 26);
            this.dtOrder.Name = "dtOrder";
            this.dtOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtOrder.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtOrder.Size = new System.Drawing.Size(115, 20);
            this.dtOrder.TabIndex = 50;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(40, 69);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 14);
            this.labelControl1.TabIndex = 53;
            this.labelControl1.Text = "报工人：";
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(40, 112);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 54;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(142, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 55;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbName
            // 
            this.cmbName.Location = new System.Drawing.Point(102, 66);
            this.cmbName.Name = "cmbName";
            this.cmbName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbName.Properties.ImmediatePopup = true;
            this.cmbName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbName.Size = new System.Drawing.Size(115, 20);
            this.cmbName.TabIndex = 56;
            // 
            // FormPrint
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 159);
            this.Controls.Add(this.cmbName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.dtOrder);
            this.MaximizeBox = false;
            this.Name = "FormPrint";
            this.Text = "FormPrint";
            ((System.ComponentModel.ISupportInitialize)(this.dtOrder.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . DateEdit dtOrder;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . SimpleButton btnSure;
        private DevExpress . XtraEditors . SimpleButton btnCancel;
        private DevExpress . XtraEditors . ComboBoxEdit cmbName;
    }
}