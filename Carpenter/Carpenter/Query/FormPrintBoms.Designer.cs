namespace Carpenter . Query
{
    partial class FormPrintBoms
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
            this.btnPrintOrder = new System.Windows.Forms.Button();
            this.btnPrintCp = new System.Windows.Forms.Button();
            this.btnExportOrder = new System.Windows.Forms.Button();
            this.btnExportCP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrintOrder
            // 
            this.btnPrintOrder.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnPrintOrder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintOrder.Location = new System.Drawing.Point(26, 31);
            this.btnPrintOrder.Name = "btnPrintOrder";
            this.btnPrintOrder.Size = new System.Drawing.Size(75, 34);
            this.btnPrintOrder.TabIndex = 1;
            this.btnPrintOrder.Text = "打印清单";
            this.btnPrintOrder.UseVisualStyleBackColor = false;
            this.btnPrintOrder.Click += new System.EventHandler(this.btnPrintOrder_Click);
            // 
            // btnPrintCp
            // 
            this.btnPrintCp.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnPrintCp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintCp.Location = new System.Drawing.Point(26, 104);
            this.btnPrintCp.Name = "btnPrintCp";
            this.btnPrintCp.Size = new System.Drawing.Size(75, 34);
            this.btnPrintCp.TabIndex = 2;
            this.btnPrintCp.Text = "打印传票";
            this.btnPrintCp.UseVisualStyleBackColor = false;
            this.btnPrintCp.Click += new System.EventHandler(this.btnPrintCp_Click);
            // 
            // btnExportOrder
            // 
            this.btnExportOrder.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnExportOrder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportOrder.Location = new System.Drawing.Point(149, 31);
            this.btnExportOrder.Name = "btnExportOrder";
            this.btnExportOrder.Size = new System.Drawing.Size(75, 34);
            this.btnExportOrder.TabIndex = 3;
            this.btnExportOrder.Text = "导出清单";
            this.btnExportOrder.UseVisualStyleBackColor = false;
            this.btnExportOrder.Click += new System.EventHandler(this.btnExportOrder_Click);
            // 
            // btnExportCP
            // 
            this.btnExportCP.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnExportCP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCP.Location = new System.Drawing.Point(149, 104);
            this.btnExportCP.Name = "btnExportCP";
            this.btnExportCP.Size = new System.Drawing.Size(75, 34);
            this.btnExportCP.TabIndex = 4;
            this.btnExportCP.Text = "导出传票";
            this.btnExportCP.UseVisualStyleBackColor = false;
            this.btnExportCP.Click += new System.EventHandler(this.btnExportCP_Click);
            // 
            // FormPrintBoms
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 170);
            this.Controls.Add(this.btnExportCP);
            this.Controls.Add(this.btnExportOrder);
            this.Controls.Add(this.btnPrintCp);
            this.Controls.Add(this.btnPrintOrder);
            this.MaximizeBox = false;
            this.Name = "FormPrintBoms";
            this.Text = "FormPrintBoms";
            this.ResumeLayout(false);

        }

        #endregion
        private System . Windows . Forms . Button btnPrintCp;
        private System . Windows . Forms . Button btnPrintOrder;
        private System . Windows . Forms . Button btnExportOrder;
        private System . Windows . Forms . Button btnExportCP;
    }
}