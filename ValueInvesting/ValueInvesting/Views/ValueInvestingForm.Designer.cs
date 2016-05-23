namespace ValueInvesting.Views
{
    partial class ValueInvestingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValueInvestingForm));
            this.tickTxtbox = new System.Windows.Forms.TextBox();
            this.usRadioButton = new System.Windows.Forms.RadioButton();
            this.sgRadioButton = new System.Windows.Forms.RadioButton();
            this.updateButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.trashButton = new System.Windows.Forms.Button();
            this.chartButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.updateWorker = new System.ComponentModel.BackgroundWorker();
            this.watchlistOLV = new BrightIdeasSoftware.ObjectListView();
            this.symColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lastColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.growthColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.growthPriceRenderer = new ValueInvesting.Renderers.GrowthPriceRenderer();
            this.divColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.assetColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.bizColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dividendPriceRenderer = new ValueInvesting.Renderers.DividendPriceRenderer();
            this.assetPriceRenderer = new ValueInvesting.Renderers.AssetPriceRenderer();
            ((System.ComponentModel.ISupportInitialize)(this.watchlistOLV)).BeginInit();
            this.SuspendLayout();
            // 
            // tickTxtbox
            // 
            this.tickTxtbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tickTxtbox.Location = new System.Drawing.Point(790, 30);
            this.tickTxtbox.Name = "tickTxtbox";
            this.tickTxtbox.Size = new System.Drawing.Size(127, 23);
            this.tickTxtbox.TabIndex = 0;
            this.tickTxtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tickTxtbox_KeyPress);
            // 
            // usRadioButton
            // 
            this.usRadioButton.AutoSize = true;
            this.usRadioButton.Checked = true;
            this.usRadioButton.ForeColor = System.Drawing.Color.White;
            this.usRadioButton.Location = new System.Drawing.Point(790, 59);
            this.usRadioButton.Name = "usRadioButton";
            this.usRadioButton.Size = new System.Drawing.Size(127, 23);
            this.usRadioButton.TabIndex = 0;
            this.usRadioButton.TabStop = true;
            this.usRadioButton.Text = "NYSE, NASDAQ";
            this.usRadioButton.UseVisualStyleBackColor = true;
            // 
            // sgRadioButton
            // 
            this.sgRadioButton.AutoSize = true;
            this.sgRadioButton.ForeColor = System.Drawing.Color.White;
            this.sgRadioButton.Location = new System.Drawing.Point(790, 88);
            this.sgRadioButton.Name = "sgRadioButton";
            this.sgRadioButton.Size = new System.Drawing.Size(58, 23);
            this.sgRadioButton.TabIndex = 1;
            this.sgRadioButton.Text = "SGX";
            this.sgRadioButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.FlatAppearance.BorderSize = 0;
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.Image = global::ValueInvesting.Properties.Resources.Refresh;
            this.updateButton.Location = new System.Drawing.Point(331, 11);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(100, 100);
            this.updateButton.TabIndex = 8;
            this.toolTip.SetToolTip(this.updateButton, "Update");
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Image = global::ValueInvesting.Properties.Resources.Save;
            this.saveButton.Location = new System.Drawing.Point(225, 11);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 100);
            this.saveButton.TabIndex = 7;
            this.toolTip.SetToolTip(this.saveButton, "Save");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openButton
            // 
            this.openButton.FlatAppearance.BorderSize = 0;
            this.openButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openButton.Image = global::ValueInvesting.Properties.Resources.Open;
            this.openButton.Location = new System.Drawing.Point(119, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(100, 100);
            this.openButton.TabIndex = 6;
            this.toolTip.SetToolTip(this.openButton, "Open");
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // newButton
            // 
            this.newButton.FlatAppearance.BorderSize = 0;
            this.newButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newButton.Image = global::ValueInvesting.Properties.Resources.New;
            this.newButton.Location = new System.Drawing.Point(13, 11);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(100, 100);
            this.newButton.TabIndex = 2;
            this.toolTip.SetToolTip(this.newButton, "New");
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // trashButton
            // 
            this.trashButton.FlatAppearance.BorderSize = 0;
            this.trashButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trashButton.Image = global::ValueInvesting.Properties.Resources.Trash;
            this.trashButton.Location = new System.Drawing.Point(437, 12);
            this.trashButton.Name = "trashButton";
            this.trashButton.Size = new System.Drawing.Size(100, 100);
            this.trashButton.TabIndex = 9;
            this.toolTip.SetToolTip(this.trashButton, "Delete");
            this.trashButton.UseVisualStyleBackColor = true;
            this.trashButton.Click += new System.EventHandler(this.trashButton_Click);
            // 
            // chartButton
            // 
            this.chartButton.FlatAppearance.BorderSize = 0;
            this.chartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chartButton.Image = ((System.Drawing.Image)(resources.GetObject("chartButton.Image")));
            this.chartButton.Location = new System.Drawing.Point(543, 11);
            this.chartButton.Name = "chartButton";
            this.chartButton.Size = new System.Drawing.Size(100, 100);
            this.chartButton.TabIndex = 10;
            this.toolTip.SetToolTip(this.chartButton, "Chart");
            this.chartButton.UseVisualStyleBackColor = true;
            this.chartButton.Click += new System.EventHandler(this.chartButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.FlatAppearance.BorderSize = 0;
            this.infoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoButton.Image = global::ValueInvesting.Properties.Resources.Info;
            this.infoButton.Location = new System.Drawing.Point(649, 11);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(100, 100);
            this.infoButton.TabIndex = 11;
            this.toolTip.SetToolTip(this.infoButton, "Info");
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "vib";
            this.saveFileDialog.Filter = "\"vib files (*.vib)|*.vib|All files (*.*)|*.*\"";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "vib";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "\"vib files (*.vib)|*.vib|All files (*.*)|*.*\"";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // updateWorker
            // 
            this.updateWorker.WorkerReportsProgress = true;
            this.updateWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateWorker_DoWork);
            this.updateWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.updateWorker_ProgressChanged);
            this.updateWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.updateWorker_RunWorkerCompleted);
            // 
            // watchlistOLV
            // 
            this.watchlistOLV.AllColumns.Add(this.symColumn);
            this.watchlistOLV.AllColumns.Add(this.nameColumn);
            this.watchlistOLV.AllColumns.Add(this.lastColumn);
            this.watchlistOLV.AllColumns.Add(this.growthColumn);
            this.watchlistOLV.AllColumns.Add(this.divColumn);
            this.watchlistOLV.AllColumns.Add(this.assetColumn);
            this.watchlistOLV.AllColumns.Add(this.bizColumn);
            this.watchlistOLV.AllColumns.Add(this.dateColumn);
            this.watchlistOLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.watchlistOLV.BackColor = System.Drawing.Color.LightGray;
            this.watchlistOLV.CellEditUseWholeCell = false;
            this.watchlistOLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.symColumn,
            this.nameColumn,
            this.lastColumn,
            this.growthColumn,
            this.divColumn,
            this.assetColumn,
            this.bizColumn,
            this.dateColumn});
            this.watchlistOLV.Cursor = System.Windows.Forms.Cursors.Default;
            this.watchlistOLV.FullRowSelect = true;
            this.watchlistOLV.GridLines = true;
            this.watchlistOLV.ItemRenderer = this.growthPriceRenderer;
            this.watchlistOLV.Location = new System.Drawing.Point(13, 118);
            this.watchlistOLV.Name = "watchlistOLV";
            this.watchlistOLV.Size = new System.Drawing.Size(904, 395);
            this.watchlistOLV.TabIndex = 5;
            this.watchlistOLV.UseCompatibleStateImageBehavior = false;
            this.watchlistOLV.View = System.Windows.Forms.View.Details;
            this.watchlistOLV.DoubleClick += new System.EventHandler(this.watchlistOLV_DoubleClick);
            // 
            // symColumn
            // 
            this.symColumn.AspectName = "Sym";
            this.symColumn.Groupable = false;
            this.symColumn.Text = "Symbol";
            this.symColumn.Width = 69;
            // 
            // nameColumn
            // 
            this.nameColumn.AspectName = "Name";
            this.nameColumn.Groupable = false;
            this.nameColumn.Text = "Company";
            this.nameColumn.Width = 240;
            // 
            // lastColumn
            // 
            this.lastColumn.AspectName = "Last";
            this.lastColumn.AspectToStringFormat = "{0:C}";
            this.lastColumn.Text = "Price";
            this.lastColumn.Width = 90;
            // 
            // growthColumn
            // 
            this.growthColumn.AspectName = "GEP";
            this.growthColumn.AspectToStringFormat = "{0:C}";
            this.growthColumn.Renderer = this.growthPriceRenderer;
            this.growthColumn.Text = "Growth EP";
            this.growthColumn.Width = 90;
            // 
            // divColumn
            // 
            this.divColumn.AspectName = "DEP";
            this.divColumn.AspectToStringFormat = "{0:C}";
            this.divColumn.Renderer = this.dividendPriceRenderer;
            this.divColumn.Text = "Dividend EP";
            this.divColumn.Width = 90;
            // 
            // assetColumn
            // 
            this.assetColumn.AspectName = "AEP";
            this.assetColumn.AspectToStringFormat = "{0:C}";
            this.assetColumn.Renderer = this.assetPriceRenderer;
            this.assetColumn.Text = "Asset EP";
            this.assetColumn.Width = 90;
            // 
            // bizColumn
            // 
            this.bizColumn.AspectName = "BizConf";
            this.bizColumn.Text = "Biz Conf";
            this.bizColumn.Width = 90;
            // 
            // dateColumn
            // 
            this.dateColumn.AspectName = "LastUpdate";
            this.dateColumn.AspectToStringFormat = "{0:d}";
            this.dateColumn.Text = "Last Updated";
            this.dateColumn.Width = 122;
            // 
            // ValueInvestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(929, 525);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.chartButton);
            this.Controls.Add(this.trashButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.watchlistOLV);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.sgRadioButton);
            this.Controls.Add(this.usRadioButton);
            this.Controls.Add(this.tickTxtbox);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ValueInvestingForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Value Investing";
            ((System.ComponentModel.ISupportInitialize)(this.watchlistOLV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tickTxtbox;
        private System.Windows.Forms.RadioButton usRadioButton;
        private System.Windows.Forms.RadioButton sgRadioButton;
        private System.Windows.Forms.Button newButton;
        private BrightIdeasSoftware.ObjectListView watchlistOLV;
        private BrightIdeasSoftware.OLVColumn symColumn;
        private BrightIdeasSoftware.OLVColumn nameColumn;
        private BrightIdeasSoftware.OLVColumn lastColumn;
        private BrightIdeasSoftware.OLVColumn growthColumn;
        private BrightIdeasSoftware.OLVColumn divColumn;
        private BrightIdeasSoftware.OLVColumn assetColumn;
        private BrightIdeasSoftware.OLVColumn bizColumn;
        private BrightIdeasSoftware.OLVColumn dateColumn;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button trashButton;
        private System.Windows.Forms.Button chartButton;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.ComponentModel.BackgroundWorker updateWorker;
        private Renderers.GrowthPriceRenderer growthPriceRenderer;
        private Renderers.DividendPriceRenderer dividendPriceRenderer;
        private Renderers.AssetPriceRenderer assetPriceRenderer;
    }
}