namespace Carpenter . Query
{
    partial class FormPaintEdit
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
            this.texClass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCan = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.texPaintConsu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.texPaintUnit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.texPaintSpeci = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.texPaintName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.texPaintNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.texClass);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnCan);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.texPaintConsu);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.texPaintUnit);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.texPaintSpeci);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.texPaintName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.texPaintNum);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 241);
            this.panel1.TabIndex = 1;
            // 
            // texClass
            // 
            this.texClass.Location = new System.Drawing.Point(95, 160);
            this.texClass.Name = "texClass";
            this.texClass.Size = new System.Drawing.Size(150, 23);
            this.texClass.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 33;
            this.label6.Text = "类别：";
            // 
            // btnCan
            // 
            this.btnCan.AutoSize = true;
            this.btnCan.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCan.Location = new System.Drawing.Point(174, 201);
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(71, 30);
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
            this.btnOk.Location = new System.Drawing.Point(69, 201);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(71, 30);
            this.btnOk.TabIndex = 31;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // texPaintConsu
            // 
            this.texPaintConsu.Location = new System.Drawing.Point(95, 131);
            this.texPaintConsu.Name = "texPaintConsu";
            this.texPaintConsu.Size = new System.Drawing.Size(150, 23);
            this.texPaintConsu.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "用量：";
            // 
            // texPaintUnit
            // 
            this.texPaintUnit.Location = new System.Drawing.Point(95, 102);
            this.texPaintUnit.Name = "texPaintUnit";
            this.texPaintUnit.ReadOnly = true;
            this.texPaintUnit.Size = new System.Drawing.Size(150, 23);
            this.texPaintUnit.TabIndex = 9;
            this.texPaintUnit.Click += new System.EventHandler(this.FormPaintEdit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "单位：";
            // 
            // texPaintSpeci
            // 
            this.texPaintSpeci.Location = new System.Drawing.Point(95, 73);
            this.texPaintSpeci.Name = "texPaintSpeci";
            this.texPaintSpeci.ReadOnly = true;
            this.texPaintSpeci.Size = new System.Drawing.Size(150, 23);
            this.texPaintSpeci.TabIndex = 7;
            this.texPaintSpeci.Click += new System.EventHandler(this.FormPaintEdit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "规格：";
            // 
            // texPaintName
            // 
            this.texPaintName.Location = new System.Drawing.Point(95, 44);
            this.texPaintName.Name = "texPaintName";
            this.texPaintName.ReadOnly = true;
            this.texPaintName.Size = new System.Drawing.Size(150, 23);
            this.texPaintName.TabIndex = 5;
            this.texPaintName.Click += new System.EventHandler(this.FormPaintEdit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "油漆名称：";
            // 
            // texPaintNum
            // 
            this.texPaintNum.Location = new System.Drawing.Point(95, 15);
            this.texPaintNum.Name = "texPaintNum";
            this.texPaintNum.ReadOnly = true;
            this.texPaintNum.Size = new System.Drawing.Size(150, 23);
            this.texPaintNum.TabIndex = 3;
            this.texPaintNum.Click += new System.EventHandler(this.FormPaintEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "油漆编码：";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormPaintEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 241);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPaintEdit";
            this.Text = "FormPaintEdit";
            this.Click += new System.EventHandler(this.FormPaintEdit_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System . Windows . Forms . Panel panel1;
        private System . Windows . Forms . Button btnCan;
        private System . Windows . Forms . Button btnOk;
        private System . Windows . Forms . TextBox texPaintConsu;
        private System . Windows . Forms . Label label5;
        private System . Windows . Forms . TextBox texPaintUnit;
        private System . Windows . Forms . Label label4;
        private System . Windows . Forms . TextBox texPaintSpeci;
        private System . Windows . Forms . Label label3;
        private System . Windows . Forms . TextBox texPaintName;
        private System . Windows . Forms . Label label2;
        private System . Windows . Forms . TextBox texPaintNum;
        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . ErrorProvider errorProvider1;
        private System . Windows . Forms . TextBox texClass;
        private System . Windows . Forms . Label label6;
    }
}