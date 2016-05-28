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
            this.ZedGraphControl = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // ZedGraphControl
            // 
            this.ZedGraphControl.AutoSize = true;
            this.ZedGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZedGraphControl.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.ZedGraphControl.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZedGraphControl.IsShowContextMenu = false;
            this.ZedGraphControl.IsShowPointValues = true;
            this.ZedGraphControl.Location = new System.Drawing.Point(0, 0);
            this.ZedGraphControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ZedGraphControl.Name = "ZedGraphControl";
            this.ZedGraphControl.PanModifierKeys = System.Windows.Forms.Keys.None;
            this.ZedGraphControl.PointDateFormat = "dd-MMM";
            this.ZedGraphControl.PointValueFormat = "0.##";
            this.ZedGraphControl.ScrollGrace = 0D;
            this.ZedGraphControl.ScrollMaxX = 0D;
            this.ZedGraphControl.ScrollMaxY = 0D;
            this.ZedGraphControl.ScrollMaxY2 = 0D;
            this.ZedGraphControl.ScrollMinX = 0D;
            this.ZedGraphControl.ScrollMinY = 0D;
            this.ZedGraphControl.ScrollMinY2 = 0D;
            this.ZedGraphControl.Size = new System.Drawing.Size(1243, 683);
            this.ZedGraphControl.TabIndex = 1;
            this.ZedGraphControl.UseExtendedPrintDialog = true;
            this.ZedGraphControl.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(this.CandleStickGraph_ZoomEvent);
            // 
            // ChartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 683);
            this.Controls.Add(this.ZedGraphControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Technical Analysis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ZedGraph.ZedGraphControl ZedGraphControl;
    }
}