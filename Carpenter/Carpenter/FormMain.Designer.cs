namespace Carpenter
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripRemind = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolClose = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolRstart = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pushPanel1 = new UILibrary.PushPanel.PushPanel();
            this.pushPanelItem1 = new UILibrary.PushPanel.PushPanelItem();
            this.labBomWorkPlan = new System.Windows.Forms.Label();
            this.labWoodPaint = new System.Windows.Forms.Label();
            this.labOPI = new System.Windows.Forms.Label();
            this.labEquipment = new System.Windows.Forms.Label();
            this.labArt = new System.Windows.Forms.Label();
            this.labSetReview = new System.Windows.Forms.Label();
            this.labProgram = new System.Windows.Forms.Label();
            this.labPower = new System.Windows.Forms.Label();
            this.labEmployee = new System.Windows.Forms.Label();
            this.labDepment = new System.Windows.Forms.Label();
            this.pushPanelItem2 = new UILibrary.PushPanel.PushPanelItem();
            this.labPlanStockDailyWork = new System.Windows.Forms.Label();
            this.lalabPlanStockWork = new System.Windows.Forms.Label();
            this.labPlanStock = new System.Windows.Forms.Label();
            this.labProductionStock = new System.Windows.Forms.Label();
            this.labProductSchedule = new System.Windows.Forms.Label();
            this.labPlanCutting = new System.Windows.Forms.Label();
            this.pushPanelItem3 = new UILibrary.PushPanel.PushPanelItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pushPanel1)).BeginInit();
            this.pushPanel1.SuspendLayout();
            this.pushPanelItem1.SuspendLayout();
            this.pushPanelItem2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.设置ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1220, 24);
            this.menuStrip1.TabIndex = 0;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripRemind});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(47, 20);
            this.toolStripMenuItem1.Text = "消息";
            // 
            // ToolStripRemind
            // 
            this.ToolStripRemind.Name = "ToolStripRemind";
            this.ToolStripRemind.Size = new System.Drawing.Size(130, 22);
            this.ToolStripRemind.Text = "消息提醒";
            this.ToolStripRemind.Click += new System.EventHandler(this.ToolStripRemind_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripPwd});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // ToolStripPwd
            // 
            this.ToolStripPwd.Name = "ToolStripPwd";
            this.ToolStripPwd.Size = new System.Drawing.Size(130, 22);
            this.ToolStripPwd.Text = "口令设置";
            this.ToolStripPwd.Click += new System.EventHandler(this.ToolStripPwd_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolClose,
            this.ToolRstart});
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // ToolClose
            // 
            this.ToolClose.Name = "ToolClose";
            this.ToolClose.Size = new System.Drawing.Size(130, 22);
            this.ToolClose.Text = "退出";
            this.ToolClose.Click += new System.EventHandler(this.ToolClose_Click);
            // 
            // ToolRstart
            // 
            this.ToolRstart.Name = "ToolRstart";
            this.ToolRstart.Size = new System.Drawing.Size(130, 22);
            this.ToolRstart.Text = "重新登录";
            this.ToolRstart.Click += new System.EventHandler(this.ToolRstart_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLogin,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 449);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1220, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolLogin
            // 
            this.toolLogin.Name = "toolLogin";
            this.toolLogin.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pushPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Size = new System.Drawing.Size(1220, 425);
            this.splitContainer1.SplitterDistance = 187;
            this.splitContainer1.TabIndex = 2;
            // 
            // pushPanel1
            // 
            this.pushPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pushPanel1.Items.AddRange(new UILibrary.PushPanel.PushPanelItem[] {
            this.pushPanelItem1,
            this.pushPanelItem2,
            this.pushPanelItem3});
            this.pushPanel1.Location = new System.Drawing.Point(0, 0);
            this.pushPanel1.Name = "pushPanel1";
            this.pushPanel1.RoundStyle = UILibrary.RoundStyle.All;
            this.pushPanel1.Size = new System.Drawing.Size(187, 425);
            this.pushPanel1.TabIndex = 0;
            // 
            // pushPanelItem1
            // 
            this.pushPanelItem1.BackColor = System.Drawing.Color.White;
            this.pushPanelItem1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.pushPanelItem1.Controls.Add(this.labBomWorkPlan);
            this.pushPanelItem1.Controls.Add(this.labWoodPaint);
            this.pushPanelItem1.Controls.Add(this.labOPI);
            this.pushPanelItem1.Controls.Add(this.labEquipment);
            this.pushPanelItem1.Controls.Add(this.labArt);
            this.pushPanelItem1.Controls.Add(this.labSetReview);
            this.pushPanelItem1.Controls.Add(this.labProgram);
            this.pushPanelItem1.Controls.Add(this.labPower);
            this.pushPanelItem1.Controls.Add(this.labEmployee);
            this.pushPanelItem1.Controls.Add(this.labDepment);
            this.pushPanelItem1.Name = "pushPanelItem1";
            this.pushPanelItem1.RoundStyle = UILibrary.RoundStyle.All;
            this.pushPanelItem1.Text = "基础信息";
            // 
            // labBomWorkPlan
            // 
            this.labBomWorkPlan.AutoSize = true;
            this.labBomWorkPlan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labBomWorkPlan.Location = new System.Drawing.Point(20, 259);
            this.labBomWorkPlan.Name = "labBomWorkPlan";
            this.labBomWorkPlan.Size = new System.Drawing.Size(56, 14);
            this.labBomWorkPlan.TabIndex = 9;
            this.labBomWorkPlan.Tag = "FormBomWorkPlan";
            this.labBomWorkPlan.Text = "BOM清单";
            this.labBomWorkPlan.Click += new System.EventHandler(this.labBomWorkPlan_Click);
            // 
            // labWoodPaint
            // 
            this.labWoodPaint.AutoSize = true;
            this.labWoodPaint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labWoodPaint.Location = new System.Drawing.Point(20, 232);
            this.labWoodPaint.Name = "labWoodPaint";
            this.labWoodPaint.Size = new System.Drawing.Size(126, 14);
            this.labWoodPaint.TabIndex = 8;
            this.labWoodPaint.Tag = "FormBomWoodPaint";
            this.labWoodPaint.Text = "木材、油漆标准BOM";
            this.labWoodPaint.Click += new System.EventHandler(this.label2_Click);
            // 
            // labOPI
            // 
            this.labOPI.AutoSize = true;
            this.labOPI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labOPI.Location = new System.Drawing.Point(20, 205);
            this.labOPI.Name = "labOPI";
            this.labOPI.Size = new System.Drawing.Size(63, 14);
            this.labOPI.TabIndex = 7;
            this.labOPI.Tag = "FormOPI";
            this.labOPI.Text = "产品信息";
            this.labOPI.Click += new System.EventHandler(this.label1_Click);
            // 
            // labEquipment
            // 
            this.labEquipment.AutoSize = true;
            this.labEquipment.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labEquipment.Location = new System.Drawing.Point(20, 176);
            this.labEquipment.Name = "labEquipment";
            this.labEquipment.Size = new System.Drawing.Size(63, 14);
            this.labEquipment.TabIndex = 6;
            this.labEquipment.Tag = "FormEquipment";
            this.labEquipment.Text = "设备信息";
            this.labEquipment.Click += new System.EventHandler(this.labEquipment_Click);
            // 
            // labArt
            // 
            this.labArt.AutoSize = true;
            this.labArt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labArt.Location = new System.Drawing.Point(20, 147);
            this.labArt.Name = "labArt";
            this.labArt.Size = new System.Drawing.Size(63, 14);
            this.labArt.TabIndex = 5;
            this.labArt.Tag = "FormArt";
            this.labArt.Text = "工艺信息";
            this.labArt.Click += new System.EventHandler(this.labArt_Click);
            // 
            // labSetReview
            // 
            this.labSetReview.AutoSize = true;
            this.labSetReview.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labSetReview.Location = new System.Drawing.Point(20, 288);
            this.labSetReview.Name = "labSetReview";
            this.labSetReview.Size = new System.Drawing.Size(119, 14);
            this.labSetReview.TabIndex = 4;
            this.labSetReview.Tag = "FormSetReview";
            this.labSetReview.Text = "消息送审流程设置";
            this.labSetReview.Click += new System.EventHandler(this.labSetReview_Click);
            // 
            // labProgram
            // 
            this.labProgram.AutoSize = true;
            this.labProgram.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labProgram.Location = new System.Drawing.Point(20, 60);
            this.labProgram.Name = "labProgram";
            this.labProgram.Size = new System.Drawing.Size(63, 14);
            this.labProgram.TabIndex = 3;
            this.labProgram.Tag = "FormProgramControl";
            this.labProgram.Text = "程序控制";
            this.labProgram.Click += new System.EventHandler(this.labProgram_Click);
            // 
            // labPower
            // 
            this.labPower.AutoSize = true;
            this.labPower.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPower.Location = new System.Drawing.Point(20, 31);
            this.labPower.Name = "labPower";
            this.labPower.Size = new System.Drawing.Size(63, 14);
            this.labPower.TabIndex = 2;
            this.labPower.Tag = "FormPower";
            this.labPower.Text = "权限设置";
            this.labPower.Click += new System.EventHandler(this.labPower_Click);
            // 
            // labEmployee
            // 
            this.labEmployee.AutoSize = true;
            this.labEmployee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labEmployee.Location = new System.Drawing.Point(20, 118);
            this.labEmployee.Name = "labEmployee";
            this.labEmployee.Size = new System.Drawing.Size(63, 14);
            this.labEmployee.TabIndex = 1;
            this.labEmployee.Tag = "FormEmployee";
            this.labEmployee.Text = "人员信息";
            this.labEmployee.Click += new System.EventHandler(this.labEmployee_Click);
            // 
            // labDepment
            // 
            this.labDepment.AutoSize = true;
            this.labDepment.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labDepment.Location = new System.Drawing.Point(20, 89);
            this.labDepment.Name = "labDepment";
            this.labDepment.Size = new System.Drawing.Size(63, 14);
            this.labDepment.TabIndex = 0;
            this.labDepment.Tag = "FormDepartMent";
            this.labDepment.Text = "部门信息";
            this.labDepment.Click += new System.EventHandler(this.labDepment_Click);
            // 
            // pushPanelItem2
            // 
            this.pushPanelItem2.BackColor = System.Drawing.Color.White;
            this.pushPanelItem2.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.pushPanelItem2.Controls.Add(this.labPlanStockDailyWork);
            this.pushPanelItem2.Controls.Add(this.lalabPlanStockWork);
            this.pushPanelItem2.Controls.Add(this.labPlanStock);
            this.pushPanelItem2.Controls.Add(this.labProductionStock);
            this.pushPanelItem2.Controls.Add(this.labProductSchedule);
            this.pushPanelItem2.Controls.Add(this.labPlanCutting);
            this.pushPanelItem2.Name = "pushPanelItem2";
            this.pushPanelItem2.RoundStyle = UILibrary.RoundStyle.All;
            this.pushPanelItem2.Text = "生产计划";
            // 
            // labPlanStockDailyWork
            // 
            this.labPlanStockDailyWork.AutoSize = true;
            this.labPlanStockDailyWork.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPlanStockDailyWork.Location = new System.Drawing.Point(20, 179);
            this.labPlanStockDailyWork.Name = "labPlanStockDailyWork";
            this.labPlanStockDailyWork.Size = new System.Drawing.Size(91, 14);
            this.labPlanStockDailyWork.TabIndex = 8;
            this.labPlanStockDailyWork.Tag = "FormPlanStockDailyWork";
            this.labPlanStockDailyWork.Text = "备料报工记录";
            this.labPlanStockDailyWork.Click += new System.EventHandler(this.labPlanStockDailyWork_Click);
            // 
            // lalabPlanStockWork
            // 
            this.lalabPlanStockWork.AutoSize = true;
            this.lalabPlanStockWork.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalabPlanStockWork.Location = new System.Drawing.Point(20, 150);
            this.lalabPlanStockWork.Name = "lalabPlanStockWork";
            this.lalabPlanStockWork.Size = new System.Drawing.Size(133, 14);
            this.lalabPlanStockWork.TabIndex = 7;
            this.lalabPlanStockWork.Tag = "FormPlanStockWork";
            this.lalabPlanStockWork.Text = "备料车间工段日计划";
            this.lalabPlanStockWork.Click += new System.EventHandler(this.lalabPlanStockWork_Click);
            // 
            // labPlanStock
            // 
            this.labPlanStock.AutoSize = true;
            this.labPlanStock.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPlanStock.Location = new System.Drawing.Point(20, 121);
            this.labPlanStock.Name = "labPlanStock";
            this.labPlanStock.Size = new System.Drawing.Size(133, 14);
            this.labPlanStock.TabIndex = 6;
            this.labPlanStock.Tag = "FormPlanStock";
            this.labPlanStock.Text = "备料车间生产周计划";
            this.labPlanStock.Click += new System.EventHandler(this.labPlanStock_Click);
            // 
            // labProductionStock
            // 
            this.labProductionStock.AutoSize = true;
            this.labProductionStock.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labProductionStock.Location = new System.Drawing.Point(20, 92);
            this.labProductionStock.Name = "labProductionStock";
            this.labProductionStock.Size = new System.Drawing.Size(161, 14);
            this.labProductionStock.TabIndex = 5;
            this.labProductionStock.Tag = "FormProductionStock";
            this.labProductionStock.Text = "备料(机加工)车间跟踪表";
            this.labProductionStock.Click += new System.EventHandler(this.labProductionStock_Click);
            // 
            // labProductSchedule
            // 
            this.labProductSchedule.AutoSize = true;
            this.labProductSchedule.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labProductSchedule.Location = new System.Drawing.Point(20, 63);
            this.labProductSchedule.Name = "labProductSchedule";
            this.labProductSchedule.Size = new System.Drawing.Size(147, 14);
            this.labProductSchedule.TabIndex = 4;
            this.labProductSchedule.Tag = "FormProductSchedule";
            this.labProductSchedule.Text = "生产部生产进度跟踪表";
            this.labProductSchedule.Click += new System.EventHandler(this.labProductSchedule_Click);
            // 
            // labPlanCutting
            // 
            this.labPlanCutting.AutoSize = true;
            this.labPlanCutting.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPlanCutting.Location = new System.Drawing.Point(20, 35);
            this.labPlanCutting.Name = "labPlanCutting";
            this.labPlanCutting.Size = new System.Drawing.Size(105, 14);
            this.labPlanCutting.TabIndex = 3;
            this.labPlanCutting.Tag = "FormPlanCutting";
            this.labPlanCutting.Text = "开料生产周计划";
            this.labPlanCutting.Click += new System.EventHandler(this.labPlanCutting_Click);
            // 
            // pushPanelItem3
            // 
            this.pushPanelItem3.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.pushPanelItem3.Name = "pushPanelItem3";
            this.pushPanelItem3.RoundStyle = UILibrary.RoundStyle.All;
            this.pushPanelItem3.Text = "报表查看";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1174, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "杭州瑞格微科技有限公司  Tel：(0571)  86961522  E_mail：my_rgw163.com";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 471);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "湖州莫霞实业有限公司";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pushPanel1)).EndInit();
            this.pushPanel1.ResumeLayout(false);
            this.pushPanelItem1.ResumeLayout(false);
            this.pushPanelItem1.PerformLayout();
            this.pushPanelItem2.ResumeLayout(false);
            this.pushPanelItem2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . MenuStrip menuStrip1;
        private System . Windows . Forms . StatusStrip statusStrip1;
        private System . Windows . Forms . ToolStripMenuItem toolStripMenuItem1;
        private System . Windows . Forms . SplitContainer splitContainer1;
        private UILibrary . PushPanel . PushPanel pushPanel1;
        private UILibrary.PushPanel.PushPanelItem pushPanelItem1;
        private UILibrary.PushPanel.PushPanelItem pushPanelItem2;
        private UILibrary.PushPanel.PushPanelItem pushPanelItem3;
        private System . Windows . Forms . ToolStripStatusLabel toolLogin;
        private System . Windows . Forms . Label labEmployee;
        private System . Windows . Forms . Label labDepment;
        private System . Windows . Forms . Label labPower;
        private System . Windows . Forms . Label labProgram;
        private System . Windows . Forms . Label labSetReview;
        private System . Windows . Forms . ToolStripMenuItem 设置ToolStripMenuItem;
        private System . Windows . Forms . ToolStripMenuItem 退出ToolStripMenuItem;
        private System . Windows . Forms . ToolStripMenuItem ToolStripRemind;
        private System . Windows . Forms . ToolStripMenuItem ToolStripPwd;
        private System . Windows . Forms . Label labArt;
        private System . Windows . Forms . Label labEquipment;
        private System . Windows . Forms . Label labOPI;
        private System . Windows . Forms . Label labWoodPaint;
        private System . Windows . Forms . Label labBomWorkPlan;
        private System . Windows . Forms . ToolStripMenuItem ToolClose;
        private System . Windows . Forms . ToolStripMenuItem ToolRstart;
        private System . Windows . Forms . Label labPlanCutting;
        private System . Windows . Forms . Label labProductSchedule;
        private System . Windows . Forms . Label labProductionStock;
        private System . Windows . Forms . Label labPlanStock;
        private System . Windows . Forms . Label lalabPlanStockWork;
        private System . Windows . Forms . Label labPlanStockDailyWork;
        private System . Windows . Forms . ToolStripStatusLabel toolStripStatusLabel1;
    }
}