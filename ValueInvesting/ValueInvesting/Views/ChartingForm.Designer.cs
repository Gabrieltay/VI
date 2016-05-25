namespace ValueInvesting.Views
{
    partial class ChartingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartingForm));
            this.CandleStickGraph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // CandleStickGraph
            // 
            this.CandleStickGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CandleStickGraph.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.CandleStickGraph.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CandleStickGraph.IsShowContextMenu = false;
            this.CandleStickGraph.IsShowPointValues = true;
            this.CandleStickGraph.Location = new System.Drawing.Point(0, 0);
            this.CandleStickGraph.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CandleStickGraph.Name = "CandleStickGraph";
            this.CandleStickGraph.PanModifierKeys = System.Windows.Forms.Keys.None;
            this.CandleStickGraph.PointDateFormat = "dd-MMM";
            this.CandleStickGraph.PointValueFormat = "0.##";
            this.CandleStickGraph.ScrollGrace = 0D;
            this.CandleStickGraph.ScrollMaxX = 0D;
            this.CandleStickGraph.ScrollMaxY = 0D;
            this.CandleStickGraph.ScrollMaxY2 = 0D;
            this.CandleStickGraph.ScrollMinX = 0D;
            this.CandleStickGraph.ScrollMinY = 0D;
            this.CandleStickGraph.ScrollMinY2 = 0D;
            this.CandleStickGraph.Size = new System.Drawing.Size(1013, 583);
            this.CandleStickGraph.TabIndex = 1;
            this.CandleStickGraph.UseExtendedPrintDialog = true;
            this.CandleStickGraph.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(this.CandleStickGraph_ZoomEvent);
            // 
            // ChartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 583);
            this.Controls.Add(this.CandleStickGraph);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Technical Analysis";
            this.ResumeLayout(false);

        }

        #endregion
        private ZedGraph.ZedGraphControl CandleStickGraph;
    }
}