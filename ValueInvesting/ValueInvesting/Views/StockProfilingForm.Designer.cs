namespace ValueInvesting.Views
{
    partial class StockProfilingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockProfilingForm));
            this.stockNameLabel = new System.Windows.Forms.Label();
            this.symLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GepLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DepLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AepLabel = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.keyComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sciComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.infComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.regComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.moatCombobox = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.JepLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bizConLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.sumTxtbox = new System.Windows.Forms.TextBox();
            this.infoTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // stockNameLabel
            // 
            this.stockNameLabel.AutoSize = true;
            this.stockNameLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockNameLabel.Location = new System.Drawing.Point(12, 30);
            this.stockNameLabel.Name = "stockNameLabel";
            this.stockNameLabel.Size = new System.Drawing.Size(259, 37);
            this.stockNameLabel.TabIndex = 0;
            this.stockNameLabel.Text = "Company Name";
            // 
            // symLabel
            // 
            this.symLabel.AutoSize = true;
            this.symLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.symLabel.Location = new System.Drawing.Point(16, 9);
            this.symLabel.Name = "symLabel";
            this.symLabel.Size = new System.Drawing.Size(67, 21);
            this.symLabel.TabIndex = 1;
            this.symLabel.Text = "Symbol";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.Location = new System.Drawing.Point(12, 89);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(110, 44);
            this.priceLabel.TabIndex = 2;
            this.priceLabel.Text = "Price";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GepLabel);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Growth Entry Price";
            // 
            // GepLabel
            // 
            this.GepLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GepLabel.AutoSize = true;
            this.GepLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GepLabel.Location = new System.Drawing.Point(6, 39);
            this.GepLabel.Name = "GepLabel";
            this.GepLabel.Size = new System.Drawing.Size(57, 28);
            this.GepLabel.TabIndex = 5;
            this.GepLabel.Text = "GEP";
            this.GepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GepLabel.MouseLeave += new System.EventHandler(this.GepLabel_MouseLeave);
            this.GepLabel.MouseHover += new System.EventHandler(this.GepLabel_MouseHover);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DepLabel);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(177, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dividend Entry Price";
            // 
            // DepLabel
            // 
            this.DepLabel.AutoSize = true;
            this.DepLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepLabel.Location = new System.Drawing.Point(6, 39);
            this.DepLabel.Name = "DepLabel";
            this.DepLabel.Size = new System.Drawing.Size(54, 28);
            this.DepLabel.TabIndex = 6;
            this.DepLabel.Text = "DEP";
            this.DepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DepLabel.MouseLeave += new System.EventHandler(this.DepLabel_MouseLeave);
            this.DepLabel.MouseHover += new System.EventHandler(this.DepLabel_MouseHover);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AepLabel);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(333, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Asset Entry Price";
            // 
            // AepLabel
            // 
            this.AepLabel.AutoSize = true;
            this.AepLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AepLabel.Location = new System.Drawing.Point(6, 39);
            this.AepLabel.Name = "AepLabel";
            this.AepLabel.Size = new System.Drawing.Size(55, 28);
            this.AepLabel.TabIndex = 7;
            this.AepLabel.Text = "AEP";
            this.AepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AepLabel.MouseLeave += new System.EventHandler(this.AepLabel_MouseLeave);
            this.AepLabel.MouseHover += new System.EventHandler(this.AepLabel_MouseHover);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.keyComboBox);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.sciComboBox);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.infComboBox);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.regComboBox);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.moatCombobox);
            this.groupBox4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(380, 267);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(259, 200);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Economy Moat and RISK";
            // 
            // keyComboBox
            // 
            this.keyComboBox.FormattingEnabled = true;
            this.keyComboBox.Items.AddRange(new object[] {
            "HIGH",
            "LOW"});
            this.keyComboBox.Location = new System.Drawing.Point(172, 160);
            this.keyComboBox.Name = "keyComboBox";
            this.keyComboBox.Size = new System.Drawing.Size(72, 25);
            this.keyComboBox.TabIndex = 17;
            this.keyComboBox.Text = "HIGH";
            this.keyComboBox.SelectedIndexChanged += new System.EventHandler(this.keyComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Key People  ";
            // 
            // sciComboBox
            // 
            this.sciComboBox.FormattingEnabled = true;
            this.sciComboBox.Items.AddRange(new object[] {
            "HIGH",
            "LOW"});
            this.sciComboBox.Location = new System.Drawing.Point(172, 132);
            this.sciComboBox.Name = "sciComboBox";
            this.sciComboBox.Size = new System.Drawing.Size(72, 25);
            this.sciComboBox.TabIndex = 15;
            this.sciComboBox.Text = "HIGH";
            this.sciComboBox.SelectedIndexChanged += new System.EventHandler(this.sciComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "Science Tech  ";
            // 
            // infComboBox
            // 
            this.infComboBox.FormattingEnabled = true;
            this.infComboBox.Items.AddRange(new object[] {
            "HIGH",
            "LOW"});
            this.infComboBox.Location = new System.Drawing.Point(172, 100);
            this.infComboBox.Name = "infComboBox";
            this.infComboBox.Size = new System.Drawing.Size(72, 25);
            this.infComboBox.TabIndex = 13;
            this.infComboBox.Text = "HIGH";
            this.infComboBox.SelectedIndexChanged += new System.EventHandler(this.infComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Inflation    ";
            // 
            // regComboBox
            // 
            this.regComboBox.FormattingEnabled = true;
            this.regComboBox.Items.AddRange(new object[] {
            "HIGH",
            "LOW"});
            this.regComboBox.Location = new System.Drawing.Point(172, 70);
            this.regComboBox.Name = "regComboBox";
            this.regComboBox.Size = new System.Drawing.Size(72, 25);
            this.regComboBox.TabIndex = 11;
            this.regComboBox.Text = "HIGH";
            this.regComboBox.SelectedIndexChanged += new System.EventHandler(this.regComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Regulation ";
            // 
            // moatCombobox
            // 
            this.moatCombobox.FormattingEnabled = true;
            this.moatCombobox.Items.AddRange(new object[] {
            "Multiple Clear and Strong Moats",
            "Single Strong Moat",
            "Weak Moat(s)",
            "Moat is present but unclear",
            "No Foreseeable Moat"});
            this.moatCombobox.Location = new System.Drawing.Point(11, 33);
            this.moatCombobox.Name = "moatCombobox";
            this.moatCombobox.Size = new System.Drawing.Size(233, 25);
            this.moatCombobox.TabIndex = 0;
            this.moatCombobox.SelectedIndexChanged += new System.EventHandler(this.moatCombobox_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.JepLabel);
            this.groupBox5.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(489, 161);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(150, 100);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Jitta Entry Price";
            // 
            // JepLabel
            // 
            this.JepLabel.AutoSize = true;
            this.JepLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JepLabel.Location = new System.Drawing.Point(6, 39);
            this.JepLabel.Name = "JepLabel";
            this.JepLabel.Size = new System.Drawing.Size(49, 28);
            this.JepLabel.TabIndex = 7;
            this.JepLabel.Text = "JEP";
            this.JepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 30);
            this.label1.TabIndex = 7;
            this.label1.Text = "Business Confidence :";
            // 
            // bizConLabel
            // 
            this.bizConLabel.AutoSize = true;
            this.bizConLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bizConLabel.Location = new System.Drawing.Point(575, 110);
            this.bizConLabel.Name = "bizConLabel";
            this.bizConLabel.Size = new System.Drawing.Size(40, 28);
            this.bizConLabel.TabIndex = 8;
            this.bizConLabel.Text = "##";
            this.bizConLabel.MouseLeave += new System.EventHandler(this.bizConLabel_MouseLeave);
            this.bizConLabel.MouseHover += new System.EventHandler(this.bizConLabel_MouseHover);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Transparent;
            this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Image = global::ValueInvesting.Properties.Resources.Add;
            this.addButton.Location = new System.Drawing.Point(420, 473);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 100);
            this.addButton.TabIndex = 9;
            this.infoTooltip.SetToolTip(this.addButton, "Add/Update");
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // delButton
            // 
            this.delButton.BackColor = System.Drawing.Color.Transparent;
            this.delButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.delButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.delButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delButton.Image = global::ValueInvesting.Properties.Resources.Delete;
            this.delButton.Location = new System.Drawing.Point(539, 473);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(100, 100);
            this.delButton.TabIndex = 10;
            this.infoTooltip.SetToolTip(this.delButton, "Delete");
            this.delButton.UseVisualStyleBackColor = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.sumTxtbox);
            this.groupBox6.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(20, 267);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(354, 302);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Summary";
            // 
            // sumTxtbox
            // 
            this.sumTxtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sumTxtbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sumTxtbox.Location = new System.Drawing.Point(3, 19);
            this.sumTxtbox.Multiline = true;
            this.sumTxtbox.Name = "sumTxtbox";
            this.sumTxtbox.ReadOnly = true;
            this.sumTxtbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sumTxtbox.Size = new System.Drawing.Size(348, 280);
            this.sumTxtbox.TabIndex = 0;
            // 
            // StockProfilingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 581);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.bizConLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.symLabel);
            this.Controls.Add(this.stockNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StockProfilingForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Profile";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stockNameLabel;
        private System.Windows.Forms.Label symLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label GepLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label DepLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label AepLabel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox moatCombobox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label JepLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label bizConLabel;
        private System.Windows.Forms.ComboBox keyComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox sciComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox infComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox regComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox sumTxtbox;
        private System.Windows.Forms.ToolTip infoTooltip;
    }
}