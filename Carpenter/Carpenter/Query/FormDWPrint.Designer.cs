namespace Carpenter . Query
{
    partial class FormDWPrint
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
            this.dwP = new Carpenter.ControlUser.DWPrintControl1();
            this.SuspendLayout();
            // 
            // dwP
            // 
            this.dwP.Appearance.BackColor = System.Drawing.Color.White;
            this.dwP.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dwP.Appearance.Options.UseBackColor = true;
            this.dwP.Appearance.Options.UseFont = true;
            this.dwP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwP.Location = new System.Drawing.Point(0, 0);
            this.dwP.Name = "dwP";
            this.dwP.Size = new System.Drawing.Size(225, 162);
            this.dwP.TabIndex = 0;
            // 
            // FormDWPrint
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 162);
            this.Controls.Add(this.dwP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormDWPrint";
            this.Text = "";
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser . DWPrintControl1 dwP;
    }
}