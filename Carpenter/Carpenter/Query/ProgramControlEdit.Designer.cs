namespace Carpenter . Query
{
    partial class ProgramControlEdit
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
            this.panel = new System.Windows.Forms.Panel();
            this.comType = new System.Windows.Forms.ComboBox();
            this.btnCan = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.texTab = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.texNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.texName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Controls.Add(this.comType);
            this.panel.Controls.Add(this.btnCan);
            this.panel.Controls.Add(this.btnOk);
            this.panel.Controls.Add(this.texTab);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.texNum);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.texName);
            this.panel.Controls.Add(this.label1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(321, 187);
            this.panel.TabIndex = 0;
            // 
            // comType
            // 
            this.comType.BackColor = System.Drawing.Color.White;
            this.comType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comType.FormattingEnabled = true;
            this.comType.Location = new System.Drawing.Point(93, 87);
            this.comType.Name = "comType";
            this.comType.Size = new System.Drawing.Size(212, 22);
            this.comType.TabIndex = 10;
            // 
            // btnCan
            // 
            this.btnCan.AutoSize = true;
            this.btnCan.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCan.Location = new System.Drawing.Point(249, 151);
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(56, 26);
            this.btnCan.TabIndex = 9;
            this.btnCan.Text = "取消";
            this.btnCan.UseVisualStyleBackColor = false;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(143, 151);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 26);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // texTab
            // 
            this.texTab.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.texTab.Location = new System.Drawing.Point(93, 118);
            this.texTab.Name = "texTab";
            this.texTab.Size = new System.Drawing.Size(212, 23);
            this.texTab.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(10, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "程序用表：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(10, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "程序类别：";
            // 
            // texNum
            // 
            this.texNum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.texNum.Location = new System.Drawing.Point(93, 50);
            this.texNum.Name = "texNum";
            this.texNum.Size = new System.Drawing.Size(212, 23);
            this.texNum.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(10, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "程序编号：";
            // 
            // texName
            // 
            this.texName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.texName.Location = new System.Drawing.Point(93, 15);
            this.texName.Name = "texName";
            this.texName.Size = new System.Drawing.Size(212, 23);
            this.texName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "程序名称：";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ProgramControlEdit
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 187);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramControlEdit";
            this.Text = "ProgramControlEdit";
            this.Load += new System.EventHandler(this.ProgramControlEdit_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System . Windows . Forms . Panel panel;
        private System . Windows . Forms . TextBox texName;
        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . TextBox texNum;
        private System . Windows . Forms . Label label2;
        private System . Windows . Forms . Label label3;
        private System . Windows . Forms . TextBox texTab;
        private System . Windows . Forms . Label label4;
        private System . Windows . Forms . Button btnCan;
        private System . Windows . Forms . Button btnOk;
        private System . Windows . Forms . ComboBox comType;
        private System . Windows . Forms . ErrorProvider errorProvider1;
    }
}