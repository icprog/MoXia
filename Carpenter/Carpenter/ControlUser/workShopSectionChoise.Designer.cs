namespace Carpenter . ControlUser
{
    partial class workShopSectionChoise
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
            this.comWorkShip = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comWorkShip
            // 
            this.comWorkShip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comWorkShip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comWorkShip.FormattingEnabled = true;
            this.comWorkShip.Location = new System.Drawing.Point(82, 19);
            this.comWorkShip.Name = "comWorkShip";
            this.comWorkShip.Size = new System.Drawing.Size(128, 22);
            this.comWorkShip.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "工段：";
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(140, 68);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 26);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(59, 68);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(50, 26);
            this.btnOk.TabIndex = 38;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // workShopSectionChoise
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.comWorkShip);
            this.Controls.Add(this.label1);
            this.Name = "workShopSectionChoise";
            this.Size = new System.Drawing.Size(251, 114);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System . Windows . Forms . Label label1;
        public System . Windows . Forms . Button btnCancel;
        public System . Windows . Forms . Button btnOk;
        public System . Windows . Forms . ComboBox comWorkShip;
    }
}
