namespace Carpenter . Query
{
    partial class FormPaintWorkProcedureEdit
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
            this.texPaintNum = new System.Windows.Forms.TextBox();
            this.texPaintName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.texMQ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.texXS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.texYM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.texDQ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.texBP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCan = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.texGM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.texPaintNum);
            this.panel1.Controls.Add(this.texPaintName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.texMQ);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.texXS);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.texYM);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.texDQ);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.texBP);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCan);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.texGM);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 185);
            this.panel1.TabIndex = 2;
            // 
            // texPaintNum
            // 
            this.texPaintNum.Location = new System.Drawing.Point(99, 12);
            this.texPaintNum.Name = "texPaintNum";
            this.texPaintNum.ReadOnly = true;
            this.texPaintNum.Size = new System.Drawing.Size(140, 23);
            this.texPaintNum.TabIndex = 46;
            this.texPaintNum.Click += new System.EventHandler(this.texPaintNum_Click);
            // 
            // texPaintName
            // 
            this.texPaintName.Location = new System.Drawing.Point(328, 12);
            this.texPaintName.Name = "texPaintName";
            this.texPaintName.ReadOnly = true;
            this.texPaintName.Size = new System.Drawing.Size(140, 23);
            this.texPaintName.TabIndex = 45;
            this.texPaintName.Click += new System.EventHandler(this.texPaintNum_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(245, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 44;
            this.label8.Text = "油漆名称：";
            // 
            // texMQ
            // 
            this.texMQ.Location = new System.Drawing.Point(328, 99);
            this.texMQ.Name = "texMQ";
            this.texMQ.Size = new System.Drawing.Size(140, 23);
            this.texMQ.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 42;
            this.label6.Text = "面漆单价：";
            // 
            // texXS
            // 
            this.texXS.Location = new System.Drawing.Point(99, 99);
            this.texXS.Name = "texXS";
            this.texXS.Size = new System.Drawing.Size(140, 23);
            this.texXS.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 40;
            this.label7.Text = "修色单价：";
            // 
            // texYM
            // 
            this.texYM.Location = new System.Drawing.Point(328, 70);
            this.texYM.Name = "texYM";
            this.texYM.Size = new System.Drawing.Size(140, 23);
            this.texYM.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 38;
            this.label4.Text = "油磨单价：";
            // 
            // texDQ
            // 
            this.texDQ.Location = new System.Drawing.Point(99, 70);
            this.texDQ.Name = "texDQ";
            this.texDQ.Size = new System.Drawing.Size(140, 23);
            this.texDQ.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 36;
            this.label5.Text = "底漆单价：";
            // 
            // texBP
            // 
            this.texBP.Location = new System.Drawing.Point(328, 41);
            this.texBP.Name = "texBP";
            this.texBP.Size = new System.Drawing.Size(140, 23);
            this.texBP.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 34;
            this.label2.Text = "白坯单价：";
            // 
            // btnCan
            // 
            this.btnCan.AutoSize = true;
            this.btnCan.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCan.Location = new System.Drawing.Point(392, 142);
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(76, 30);
            this.btnCan.TabIndex = 32;
            this.btnCan.Text = "取消";
            this.btnCan.UseVisualStyleBackColor = false;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(287, 142);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 30);
            this.btnOk.TabIndex = 31;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // texGM
            // 
            this.texGM.Location = new System.Drawing.Point(99, 41);
            this.texGM.Name = "texGM";
            this.texGM.Size = new System.Drawing.Size(140, 23);
            this.texGM.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "刮毛单价：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "油漆编号：";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormPaintWorkProcedureEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 185);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPaintWorkProcedureEdit";
            this.Text = "FormPaintWorkProcedureEdit";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System . Windows . Forms . Panel panel1;
        private System . Windows . Forms . Button btnCan;
        private System . Windows . Forms . Button btnOk;
        private System . Windows . Forms . TextBox texGM;
        private System . Windows . Forms . Label label3;
        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . TextBox texMQ;
        private System . Windows . Forms . Label label6;
        private System . Windows . Forms . TextBox texXS;
        private System . Windows . Forms . Label label7;
        private System . Windows . Forms . TextBox texYM;
        private System . Windows . Forms . Label label4;
        private System . Windows . Forms . TextBox texDQ;
        private System . Windows . Forms . Label label5;
        private System . Windows . Forms . TextBox texBP;
        private System . Windows . Forms . Label label2;
        private System . Windows . Forms . ErrorProvider errorProvider1;
        private System . Windows . Forms . TextBox texPaintName;
        private System . Windows . Forms . Label label8;
        private System . Windows . Forms . TextBox texPaintNum;
    }
}