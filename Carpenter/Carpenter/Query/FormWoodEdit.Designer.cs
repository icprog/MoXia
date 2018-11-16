namespace Carpenter . Query
{
    partial class FormWoodEdit
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
            this.btnCan = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.texConsu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.texWoodUnit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.texWoodSpeci = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.texWoodName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.texWoodNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnCan);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.texConsu);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.texWoodUnit);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.texWoodSpeci);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.texWoodName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.texWoodNum);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 209);
            this.panel1.TabIndex = 0;
            // 
            // btnCan
            // 
            this.btnCan.AutoSize = true;
            this.btnCan.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCan.Location = new System.Drawing.Point(183, 169);
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(66, 30);
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
            this.btnOk.Location = new System.Drawing.Point(99, 169);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(66, 30);
            this.btnOk.TabIndex = 31;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // texConsu
            // 
            this.texConsu.Location = new System.Drawing.Point(99, 128);
            this.texConsu.Name = "texConsu";
            this.texConsu.Size = new System.Drawing.Size(150, 23);
            this.texConsu.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "用量：";
            // 
            // texWoodUnit
            // 
            this.texWoodUnit.Location = new System.Drawing.Point(99, 99);
            this.texWoodUnit.Name = "texWoodUnit";
            this.texWoodUnit.ReadOnly = true;
            this.texWoodUnit.Size = new System.Drawing.Size(150, 23);
            this.texWoodUnit.TabIndex = 9;
            this.texWoodUnit.Click += new System.EventHandler(this.texWoodNum_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "单位：";
            // 
            // texWoodSpeci
            // 
            this.texWoodSpeci.Location = new System.Drawing.Point(99, 70);
            this.texWoodSpeci.Name = "texWoodSpeci";
            this.texWoodSpeci.ReadOnly = true;
            this.texWoodSpeci.Size = new System.Drawing.Size(150, 23);
            this.texWoodSpeci.TabIndex = 7;
            this.texWoodSpeci.Click += new System.EventHandler(this.texWoodNum_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "规格：";
            // 
            // texWoodName
            // 
            this.texWoodName.Location = new System.Drawing.Point(99, 41);
            this.texWoodName.Name = "texWoodName";
            this.texWoodName.ReadOnly = true;
            this.texWoodName.Size = new System.Drawing.Size(150, 23);
            this.texWoodName.TabIndex = 5;
            this.texWoodName.Click += new System.EventHandler(this.texWoodNum_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "木材名称：";
            // 
            // texWoodNum
            // 
            this.texWoodNum.Location = new System.Drawing.Point(99, 12);
            this.texWoodNum.Name = "texWoodNum";
            this.texWoodNum.ReadOnly = true;
            this.texWoodNum.Size = new System.Drawing.Size(150, 23);
            this.texWoodNum.TabIndex = 3;
            this.texWoodNum.Click += new System.EventHandler(this.texWoodNum_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "木材编码：";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormWoodEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 209);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWoodEdit";
            this.Text = "FormWoodEdit";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System . Windows . Forms . Panel panel1;
        private System . Windows . Forms . TextBox texWoodNum;
        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . TextBox texWoodName;
        private System . Windows . Forms . Label label2;
        private System . Windows . Forms . TextBox texConsu;
        private System . Windows . Forms . Label label5;
        private System . Windows . Forms . TextBox texWoodUnit;
        private System . Windows . Forms . Label label4;
        private System . Windows . Forms . TextBox texWoodSpeci;
        private System . Windows . Forms . Label label3;
        private System . Windows . Forms . Button btnCan;
        private System . Windows . Forms . Button btnOk;
        private System . Windows . Forms . ErrorProvider errorProvider1;
    }
}