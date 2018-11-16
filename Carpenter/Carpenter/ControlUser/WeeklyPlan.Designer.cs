namespace Carpenter . ControlUser
{
    partial class WeeklyPlan
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
            this.texWeek = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpOrder = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkPlan = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPlan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // texWeek
            // 
            this.texWeek.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.texWeek.Location = new System.Drawing.Point(96, 13);
            this.texWeek.Name = "texWeek";
            this.texWeek.Size = new System.Drawing.Size(107, 23);
            this.texWeek.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(41, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "周次：";
            // 
            // dtpOrder
            // 
            this.dtpOrder.Location = new System.Drawing.Point(96, 50);
            this.dtpOrder.Name = "dtpOrder";
            this.dtpOrder.Size = new System.Drawing.Size(117, 21);
            this.dtpOrder.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "下单日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(219, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "-->";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(253, 85);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(117, 21);
            this.dtpEnd.TabIndex = 16;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(96, 85);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(117, 21);
            this.dtpStart.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(13, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "生产周期：";
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(96, 154);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(50, 26);
            this.btnOk.TabIndex = 34;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(177, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 26);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // checkPlan
            // 
            this.checkPlan.Location = new System.Drawing.Point(96, 119);
            this.checkPlan.Name = "checkPlan";
            this.checkPlan.Properties.Caption = "预排";
            this.checkPlan.Size = new System.Drawing.Size(75, 19);
            this.checkPlan.TabIndex = 36;
            // 
            // WeeklyPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.checkPlan);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.texWeek);
            this.Controls.Add(this.label1);
            this.Name = "WeeklyPlan";
            this.Size = new System.Drawing.Size(381, 191);
            ((System.ComponentModel.ISupportInitialize)(this.checkPlan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . TextBox texWeek;
        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . DateTimePicker dtpOrder;
        private System . Windows . Forms . Label label2;
        private System . Windows . Forms . Label label5;
        private System . Windows . Forms . DateTimePicker dtpEnd;
        private System . Windows . Forms . DateTimePicker dtpStart;
        private System . Windows . Forms . Label label4;
        public System . Windows . Forms . Button btnOk;
        public System . Windows . Forms . Button btnCancel;
        private DevExpress . XtraEditors . CheckEdit checkPlan;
    }
}
