namespace Carpenter . ControlUser
{
    partial class DayPlan
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
            this.label1 = new System.Windows.Forms.Label();
            this.comWorkShip = new System.Windows.Forms.ComboBox();
            this.dtpPlan = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpOrder = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.checkPlan = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPlan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(55, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "工段：";
            // 
            // comWorkShip
            // 
            this.comWorkShip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comWorkShip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comWorkShip.FormattingEnabled = true;
            this.comWorkShip.Location = new System.Drawing.Point(110, 16);
            this.comWorkShip.Name = "comWorkShip";
            this.comWorkShip.Size = new System.Drawing.Size(128, 22);
            this.comWorkShip.TabIndex = 8;
            // 
            // dtpPlan
            // 
            this.dtpPlan.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpPlan.Location = new System.Drawing.Point(110, 100);
            this.dtpPlan.Name = "dtpPlan";
            this.dtpPlan.Size = new System.Drawing.Size(128, 23);
            this.dtpPlan.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(27, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "计划日期：";
            // 
            // dtpOrder
            // 
            this.dtpOrder.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpOrder.Location = new System.Drawing.Point(110, 55);
            this.dtpOrder.Name = "dtpOrder";
            this.dtpOrder.Size = new System.Drawing.Size(128, 23);
            this.dtpOrder.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(27, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "下单日期：";
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(191, 179);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 26);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(110, 179);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(50, 26);
            this.btnOk.TabIndex = 36;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // checkPlan
            // 
            this.checkPlan.Location = new System.Drawing.Point(110, 143);
            this.checkPlan.Name = "checkPlan";
            this.checkPlan.Properties.Caption = "预排";
            this.checkPlan.Size = new System.Drawing.Size(75, 19);
            this.checkPlan.TabIndex = 38;
            // 
            // DayPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.checkPlan);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dtpOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpPlan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comWorkShip);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DayPlan";
            this.Size = new System.Drawing.Size(287, 212);
            ((System.ComponentModel.ISupportInitialize)(this.checkPlan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . ComboBox comWorkShip;
        private System . Windows . Forms . DateTimePicker dtpPlan;
        private System . Windows . Forms . Label label3;
        private System . Windows . Forms . DateTimePicker dtpOrder;
        private System . Windows . Forms . Label label2;
        public System . Windows . Forms . Button btnCancel;
        public System . Windows . Forms . Button btnOk;
        private DevExpress . XtraEditors . CheckEdit checkPlan;
    }
}
