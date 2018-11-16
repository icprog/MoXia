namespace test
{
    partial class ToolbarForm1
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
            this.diagramControl1 = new DevExpress.XtraDiagram.DiagramControl();
            this.diagramShape1 = new DevExpress.XtraDiagram.DiagramShape();
            this.diagramShape2 = new DevExpress.XtraDiagram.DiagramShape();
            this.diagramShape3 = new DevExpress.XtraDiagram.DiagramShape();
            this.diagramShape4 = new DevExpress.XtraDiagram.DiagramShape();
            this.diagramShape5 = new DevExpress.XtraDiagram.DiagramShape();
            this.diagramShape6 = new DevExpress.XtraDiagram.DiagramShape();
            ((System.ComponentModel.ISupportInitialize)(this.diagramControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // diagramControl1
            // 
            this.diagramControl1.Items.AddRange(new DevExpress.XtraDiagram.DiagramItem[] {
            this.diagramShape1,
            this.diagramShape2,
            this.diagramShape3,
            this.diagramShape4,
            this.diagramShape5,
            this.diagramShape6});
            this.diagramControl1.Location = new System.Drawing.Point(12, 3);
            this.diagramControl1.Name = "diagramControl1";
            this.diagramControl1.OptionsBehavior.SelectedStencils = new DevExpress.Diagram.Core.StencilCollection(new string[] {
            "BasicShapes",
            "BasicFlowchartShapes",
            "SDLDiagramShapes",
            "ArrowShapes",
            "SoftwareIcons",
            "DecorativeShapes"});
            this.diagramControl1.OptionsView.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.diagramControl1.Size = new System.Drawing.Size(1196, 460);
            this.diagramControl1.TabIndex = 0;
            this.diagramControl1.Text = "diagramControl1";
            // 
            // diagramShape1
            // 
            this.diagramShape1.Position = new DevExpress.Utils.PointFloat(460F, 60F);
            this.diagramShape1.Size = new System.Drawing.SizeF(100F, 75F);
            // 
            // diagramShape2
            // 
            this.diagramShape2.Position = new DevExpress.Utils.PointFloat(120F, 200F);
            this.diagramShape2.Shape = DevExpress.Diagram.Core.BasicShapes.Pentagon;
            this.diagramShape2.Size = new System.Drawing.SizeF(100F, 100F);
            // 
            // diagramShape3
            // 
            this.diagramShape3.Position = new DevExpress.Utils.PointFloat(820F, 200F);
            this.diagramShape3.Shape = DevExpress.Diagram.Core.BasicShapes.Donut;
            this.diagramShape3.Size = new System.Drawing.SizeF(100F, 100F);
            // 
            // diagramShape4
            // 
            this.diagramShape4.Content = "Hello word !";
            this.diagramShape4.Position = new DevExpress.Utils.PointFloat(480F, 380F);
            this.diagramShape4.Shape = DevExpress.Diagram.Core.DecorativeShapes.HorizontalScroll;
            this.diagramShape4.Size = new System.Drawing.SizeF(125F, 100F);
            // 
            // diagramShape5
            // 
            this.diagramShape5.Content = "Love\r\nyou";
            this.diagramShape5.Position = new DevExpress.Utils.PointFloat(492.5F, 580F);
            this.diagramShape5.Shape = DevExpress.Diagram.Core.DecorativeShapes.Heart;
            this.diagramShape5.Size = new System.Drawing.SizeF(100F, 100F);
            // 
            // diagramShape6
            // 
            this.diagramShape6.Content = "Tools";
            this.diagramShape6.Position = new DevExpress.Utils.PointFloat(445F, 176.25F);
            this.diagramShape6.Shape = DevExpress.Diagram.Core.SoftwareIcons.Tools;
            this.diagramShape6.Size = new System.Drawing.SizeF(147.5F, 147.5F);
            // 
            // ToolbarForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 475);
            this.Controls.Add(this.diagramControl1);
            this.Name = "ToolbarForm1";
            this.Text = "ToolbarForm1";
            ((System.ComponentModel.ISupportInitialize)(this.diagramControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraDiagram . DiagramControl diagramControl1;
        private DevExpress . XtraDiagram . DiagramShape diagramShape1;
        private DevExpress . XtraDiagram . DiagramShape diagramShape2;
        private DevExpress . XtraDiagram . DiagramShape diagramShape3;
        private DevExpress . XtraDiagram . DiagramShape diagramShape4;
        private DevExpress . XtraDiagram . DiagramShape diagramShape5;
        private DevExpress . XtraDiagram . DiagramShape diagramShape6;
    }
}