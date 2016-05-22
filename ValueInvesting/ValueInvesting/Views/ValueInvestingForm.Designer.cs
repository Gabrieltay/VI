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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValueInvestingForm));
            this.tickTxtbox = new System.Windows.Forms.TextBox();
            this.usRadioButton = new System.Windows.Forms.RadioButton();
            this.sgRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.watchlistOLV = new BrightIdeasSoftware.ObjectListView();
            this.symColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lastColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.growthColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.divColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.assetColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.bizColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.watchlistOLV)).BeginInit();
            this.SuspendLayout();
            // 
            // tickTxtbox
            // 
            this.tickTxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tickTxtbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tickTxtbox.Location = new System.Drawing.Point(762, 30);
            this.tickTxtbox.Name = "tickTxtbox";
            this.tickTxtbox.Size = new System.Drawing.Size(127, 23);
            this.tickTxtbox.TabIndex = 0;
            this.tickTxtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tickTxtbox_KeyPress);
            // 
            // usRadioButton
            // 
            this.usRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usRadioButton.AutoSize = true;
            this.usRadioButton.Checked = true;
            this.usRadioButton.Location = new System.Drawing.Point(762, 59);
            this.usRadioButton.Name = "usRadioButton";
            this.usRadioButton.Size = new System.Drawing.Size(127, 23);
            this.usRadioButton.TabIndex = 0;
            this.usRadioButton.TabStop = true;
            this.usRadioButton.Text = "NYSE, NASDAQ";
            this.usRadioButton.UseVisualStyleBackColor = true;
            // 
            // sgRadioButton
            // 
            this.sgRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sgRadioButton.AutoSize = true;
            this.sgRadioButton.Location = new System.Drawing.Point(762, 88);
            this.sgRadioButton.Name = "sgRadioButton";
            this.sgRadioButton.Size = new System.Drawing.Size(58, 23);
            this.sgRadioButton.TabIndex = 1;
            this.sgRadioButton.Text = "SGX";
            this.sgRadioButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 100);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(225, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 100);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
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
            this.watchlistOLV.Location = new System.Drawing.Point(13, 118);
            this.watchlistOLV.Name = "watchlistOLV";
            this.watchlistOLV.Size = new System.Drawing.Size(876, 395);
            this.watchlistOLV.TabIndex = 5;
            this.watchlistOLV.UseCompatibleStateImageBehavior = false;
            this.watchlistOLV.View = System.Windows.Forms.View.Details;
            // 
            // symColumn
            // 
            this.symColumn.AspectName = "Sym";
            this.symColumn.Groupable = false;
            this.symColumn.Text = "Symbol";
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
            this.growthColumn.Text = "Growth EP";
            this.growthColumn.Width = 90;
            // 
            // divColumn
            // 
            this.divColumn.AspectName = "DEP";
            this.divColumn.AspectToStringFormat = "{0:C}";
            this.divColumn.Text = "Dividend EP";
            this.divColumn.Width = 90;
            // 
            // assetColumn
            // 
            this.assetColumn.AspectName = "AEP";
            this.assetColumn.AspectToStringFormat = "{0:C}";
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
            this.dateColumn.Width = 90;
            // 
            // ValueInvestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 525);
            this.Controls.Add(this.watchlistOLV);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private BrightIdeasSoftware.ObjectListView watchlistOLV;
        private BrightIdeasSoftware.OLVColumn symColumn;
        private BrightIdeasSoftware.OLVColumn nameColumn;
        private BrightIdeasSoftware.OLVColumn lastColumn;
        private BrightIdeasSoftware.OLVColumn growthColumn;
        private BrightIdeasSoftware.OLVColumn divColumn;
        private BrightIdeasSoftware.OLVColumn assetColumn;
        private BrightIdeasSoftware.OLVColumn bizColumn;
        private BrightIdeasSoftware.OLVColumn dateColumn;
    }
}