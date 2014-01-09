namespace RollBack
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.frequency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hour = new System.Windows.Forms.NumericUpDown();
            this.minute = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.oldbackcount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.onlymodif = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.zipbe = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderbrowser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oldbackcount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mentés gyakorisága";
            // 
            // frequency
            // 
            this.frequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frequency.FormattingEnabled = true;
            this.frequency.Items.AddRange(new object[] {
            "Minden nap",
            "Hetente",
            "Havonta",
            "Évente"});
            this.frequency.Location = new System.Drawing.Point(16, 29);
            this.frequency.Name = "frequency";
            this.frequency.Size = new System.Drawing.Size(172, 21);
            this.frequency.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Óra";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Perc";
            // 
            // hour
            // 
            this.hour.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.hour.Location = new System.Drawing.Point(221, 29);
            this.hour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.hour.Name = "hour";
            this.hour.Size = new System.Drawing.Size(35, 20);
            this.hour.TabIndex = 2;
            // 
            // minute
            // 
            this.minute.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.minute.Location = new System.Drawing.Point(278, 30);
            this.minute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minute.Name = "minute";
            this.minute.Size = new System.Drawing.Size(35, 20);
            this.minute.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Régi mentések megtartása";
            // 
            // oldbackcount
            // 
            this.oldbackcount.Location = new System.Drawing.Point(220, 76);
            this.oldbackcount.Name = "oldbackcount";
            this.oldbackcount.Size = new System.Drawing.Size(36, 20);
            this.oldbackcount.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "db";
            // 
            // onlymodif
            // 
            this.onlymodif.AutoSize = true;
            this.onlymodif.Checked = true;
            this.onlymodif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onlymodif.Location = new System.Drawing.Point(16, 124);
            this.onlymodif.Name = "onlymodif";
            this.onlymodif.Size = new System.Drawing.Size(186, 17);
            this.onlymodif.TabIndex = 5;
            this.onlymodif.Text = "Csak a módosított file-ok mentése";
            this.onlymodif.UseVisualStyleBackColor = true;
            this.onlymodif.CheckedChanged += new System.EventHandler(this.onlymodif_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(241, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Mentés";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // zipbe
            // 
            this.zipbe.AutoSize = true;
            this.zipbe.Checked = true;
            this.zipbe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zipbe.Location = new System.Drawing.Point(16, 147);
            this.zipbe.Name = "zipbe";
            this.zipbe.Size = new System.Drawing.Size(115, 17);
            this.zipbe.TabIndex = 10;
            this.zipbe.Text = "Zip-be csomagolás";
            this.zipbe.UseVisualStyleBackColor = true;
            this.zipbe.CheckedChanged += new System.EventHandler(this.zipbe_CheckedChanged);
            // 
            // folderbrowser
            // 
            this.folderbrowser.Location = new System.Drawing.Point(19, 212);
            this.folderbrowser.Name = "folderbrowser";
            this.folderbrowser.ReadOnly = true;
            this.folderbrowser.Size = new System.Drawing.Size(297, 20);
            this.folderbrowser.TabIndex = 11;
            this.folderbrowser.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Célkönyvtár";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "Alapértelmezett",
            "Leggyorsabb",
            "Legerősebb"});
            this.comboBox1.Location = new System.Drawing.Point(100, 168);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(213, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tömörítési ráta";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 275);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.folderbrowser);
            this.Controls.Add(this.zipbe);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.onlymodif);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.oldbackcount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.minute);
            this.Controls.Add(this.hour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.frequency);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.Text = "Beállítások";
            ((System.ComponentModel.ISupportInitialize)(this.hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oldbackcount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox frequency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown hour;
        private System.Windows.Forms.NumericUpDown minute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown oldbackcount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox onlymodif;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox zipbe;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox folderbrowser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
    }
}