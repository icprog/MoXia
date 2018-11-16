namespace Carpenter
{
    partial class FormDepartMent
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.checkJob = new DevExpress.XtraEditors.CheckEdit();
            this.texName = new DevExpress.XtraEditors.TextEdit();
            this.texNum = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkJob.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texNum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(563, 355);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeView1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.texNum);
            this.splitContainerControl1.Panel2.Controls.Add(this.texName);
            this.splitContainerControl1.Panel2.Controls.Add(this.checkJob);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(833, 355);
            this.splitContainerControl1.SplitterPosition = 258;
            this.splitContainerControl1.TabIndex = 13;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(21, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "部门编号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(21, 88);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "部门名称：";
            // 
            // checkJob
            // 
            this.checkJob.Location = new System.Drawing.Point(97, 141);
            this.checkJob.MenuManager = this.barManager1;
            this.checkJob.Name = "checkJob";
            this.checkJob.Properties.Caption = "是否工作中心";
            this.checkJob.Size = new System.Drawing.Size(98, 19);
            this.checkJob.TabIndex = 12;
            // 
            // texName
            // 
            this.texName.Location = new System.Drawing.Point(97, 82);
            this.texName.MenuManager = this.barManager1;
            this.texName.Name = "texName";
            this.texName.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.texName.Properties.Appearance.Options.UseFont = true;
            this.texName.Size = new System.Drawing.Size(145, 20);
            this.texName.TabIndex = 13;
            // 
            // texNum
            // 
            this.texNum.Location = new System.Drawing.Point(97, 41);
            this.texNum.MenuManager = this.barManager1;
            this.texNum.Name = "texNum";
            this.texNum.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F);
            this.texNum.Properties.Appearance.Options.UseFont = true;
            this.texNum.Properties.ReadOnly = true;
            this.texNum.Size = new System.Drawing.Size(145, 20);
            this.texNum.TabIndex = 14;
            // 
            // FormDepartMent
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 381);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormDepartMent";
            this.Text = "部门信息";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkJob.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texNum.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System . Windows . Forms . ErrorProvider errorProvider1;
        private System . Windows . Forms . TreeView treeView1;
        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . CheckEdit checkJob;
        private DevExpress . XtraEditors . TextEdit texName;
        private DevExpress . XtraEditors . TextEdit texNum;
    }
}