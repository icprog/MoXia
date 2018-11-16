namespace Carpenter
{
    partial class FormExportPaint
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnChoise = new System.Windows.Forms.Button();
            this.txtChoise = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChoise.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.button1);
            this.splitContainerControl1.Panel1.Controls.Add(this.button2);
            this.splitContainerControl1.Panel1.Controls.Add(this.textEdit1);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnSave);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnChoise);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtChoise);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1207, 426);
            this.splitContainerControl1.SplitterPosition = 46;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1029, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 26);
            this.button1.TabIndex = 49;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(973, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 26);
            this.button2.TabIndex = 48;
            this.button2.Text = "选择";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(681, 9);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(286, 20);
            this.textEdit1.TabIndex = 47;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(605, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 46;
            this.labelControl2.Text = "油漆理论：";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(408, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 26);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnChoise
            // 
            this.btnChoise.AutoSize = true;
            this.btnChoise.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnChoise.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChoise.Location = new System.Drawing.Point(352, 5);
            this.btnChoise.Name = "btnChoise";
            this.btnChoise.Size = new System.Drawing.Size(50, 26);
            this.btnChoise.TabIndex = 44;
            this.btnChoise.Text = "选择";
            this.btnChoise.UseVisualStyleBackColor = false;
            this.btnChoise.Click += new System.EventHandler(this.btnChoise_Click);
            // 
            // txtChoise
            // 
            this.txtChoise.Location = new System.Drawing.Point(60, 9);
            this.txtChoise.Name = "txtChoise";
            this.txtChoise.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChoise.Properties.Appearance.Options.UseFont = true;
            this.txtChoise.Properties.ReadOnly = true;
            this.txtChoise.Size = new System.Drawing.Size(286, 20);
            this.txtChoise.TabIndex = 43;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 14);
            this.labelControl1.TabIndex = 42;
            this.labelControl1.Text = "油漆：";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1207, 368);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormExportPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 426);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormExportPaint";
            this.Text = "油漆相关导入";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChoise.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private System . Windows . Forms . Button btnSave;
        private System . Windows . Forms . Button btnChoise;
        private DevExpress . XtraEditors . TextEdit txtChoise;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private System . Windows . Forms . OpenFileDialog openFileDialog1;
        private System . Windows . Forms . Button button1;
        private System . Windows . Forms . Button button2;
        private DevExpress . XtraEditors . TextEdit textEdit1;
        private DevExpress . XtraEditors . LabelControl labelControl2;
    }
}