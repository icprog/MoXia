namespace Carpenter . ControlUser
{
    partial class MaintainTranmsmitPeoQuery
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components . Dispose ( );
            }
            base . Dispose ( disposing );
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent ( )
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnUnCheckAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnUnCheckAll);
            this.splitContainer1.Panel1.Controls.Add(this.btnCheckAll);
            this.splitContainer1.Panel1.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel1.Controls.Add(this.btnOk);
            this.splitContainer1.Size = new System.Drawing.Size(537, 270);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(9, 10);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(50, 26);
            this.btnOk.TabIndex = 35;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(65, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 26);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.AutoSize = true;
            this.btnCheckAll.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCheckAll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheckAll.Location = new System.Drawing.Point(121, 10);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(50, 26);
            this.btnCheckAll.TabIndex = 37;
            this.btnCheckAll.Text = "全选";
            this.btnCheckAll.UseVisualStyleBackColor = false;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnUnCheckAll
            // 
            this.btnUnCheckAll.AutoSize = true;
            this.btnUnCheckAll.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnUnCheckAll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUnCheckAll.Location = new System.Drawing.Point(177, 10);
            this.btnUnCheckAll.Name = "btnUnCheckAll";
            this.btnUnCheckAll.Size = new System.Drawing.Size(82, 26);
            this.btnUnCheckAll.TabIndex = 38;
            this.btnUnCheckAll.Text = "取消全选";
            this.btnUnCheckAll.UseVisualStyleBackColor = false;
            this.btnUnCheckAll.Click += new System.EventHandler(this.btnUnCheckAll_Click);
            // 
            // MaintainTranmsmitPeoQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MaintainTranmsmitPeoQuery";
            this.Size = new System.Drawing.Size(537, 270);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System . Windows . Forms . SplitContainer splitContainer1;
        private System . Windows . Forms . Button btnUnCheckAll;
        private System . Windows . Forms . Button btnCheckAll;
        public System . Windows . Forms . Button btnCancel;
        public System . Windows . Forms . Button btnOk;
    }
}
