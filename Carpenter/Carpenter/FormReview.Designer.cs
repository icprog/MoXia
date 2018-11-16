namespace Carpenter
{
    partial class FormReview
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
            this.radReview = new System.Windows.Forms.RadioButton();
            this.radReject = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.richView = new System.Windows.Forms.RichTextBox();
            this.btnCan = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnCan);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.richView);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radReject);
            this.panel1.Controls.Add(this.radReview);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 337);
            this.panel1.TabIndex = 1;
            // 
            // radReview
            // 
            this.radReview.AutoSize = true;
            this.radReview.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radReview.Location = new System.Drawing.Point(74, 32);
            this.radReview.Name = "radReview";
            this.radReview.Size = new System.Drawing.Size(53, 18);
            this.radReview.TabIndex = 0;
            this.radReview.TabStop = true;
            this.radReview.Text = "送审";
            this.radReview.UseVisualStyleBackColor = true;
            // 
            // radReject
            // 
            this.radReject.AutoSize = true;
            this.radReject.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radReject.Location = new System.Drawing.Point(164, 32);
            this.radReject.Name = "radReject";
            this.radReject.Size = new System.Drawing.Size(53, 18);
            this.radReject.TabIndex = 1;
            this.radReject.TabStop = true;
            this.radReject.Text = "驳回";
            this.radReject.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(71, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "送审意见：";
            // 
            // richView
            // 
            this.richView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richView.Location = new System.Drawing.Point(74, 115);
            this.richView.Name = "richView";
            this.richView.Size = new System.Drawing.Size(300, 161);
            this.richView.TabIndex = 3;
            this.richView.Text = "";
            // 
            // btnCan
            // 
            this.btnCan.AutoSize = true;
            this.btnCan.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCan.Location = new System.Drawing.Point(179, 295);
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(75, 26);
            this.btnCan.TabIndex = 40;
            this.btnCan.Text = "取消";
            this.btnCan.UseVisualStyleBackColor = false;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(74, 295);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 26);
            this.btnOk.TabIndex = 39;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FormReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 363);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReview";
            this.Text = "消息送审";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . Panel panel1;
        private System . Windows . Forms . RadioButton radReject;
        private System . Windows . Forms . RadioButton radReview;
        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . RichTextBox richView;
        private System . Windows . Forms . Button btnCan;
        private System . Windows . Forms . Button btnOk;
    }
}