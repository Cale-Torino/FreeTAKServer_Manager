
namespace FreeTAKServer_Manager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Logs_richTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Startserver_checkBox = new System.Windows.Forms.CheckBox();
            this.Email_checkBox = new System.Windows.Forms.CheckBox();
            this.Setdir_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Pythondir_textBox = new System.Windows.Forms.TextBox();
            this.Installserver_button = new System.Windows.Forms.Button();
            this.Checkports_button = new System.Windows.Forms.Button();
            this.Editconfig_button = new System.Windows.Forms.Button();
            this.Editmainconfig_button = new System.Windows.Forms.Button();
            this.Uninstallserver_button = new System.Windows.Forms.Button();
            this.Restartserver_button = new System.Windows.Forms.Button();
            this.Stopserver_button = new System.Windows.Forms.Button();
            this.Startserver_button = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freeTAKServerAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telegramAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 331);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Logs_richTextBox);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 167);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(458, 162);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logs";
            // 
            // Logs_richTextBox
            // 
            this.Logs_richTextBox.BackColor = System.Drawing.Color.Black;
            this.Logs_richTextBox.ForeColor = System.Drawing.Color.White;
            this.Logs_richTextBox.HideSelection = false;
            this.Logs_richTextBox.Location = new System.Drawing.Point(4, 16);
            this.Logs_richTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Logs_richTextBox.Name = "Logs_richTextBox";
            this.Logs_richTextBox.ReadOnly = true;
            this.Logs_richTextBox.Size = new System.Drawing.Size(451, 140);
            this.Logs_richTextBox.TabIndex = 0;
            this.Logs_richTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Startserver_checkBox);
            this.groupBox1.Controls.Add(this.Email_checkBox);
            this.groupBox1.Controls.Add(this.Setdir_button);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Pythondir_textBox);
            this.groupBox1.Controls.Add(this.Installserver_button);
            this.groupBox1.Controls.Add(this.Checkports_button);
            this.groupBox1.Controls.Add(this.Editconfig_button);
            this.groupBox1.Controls.Add(this.Editmainconfig_button);
            this.groupBox1.Controls.Add(this.Uninstallserver_button);
            this.groupBox1.Controls.Add(this.Restartserver_button);
            this.groupBox1.Controls.Add(this.Stopserver_button);
            this.groupBox1.Controls.Add(this.Startserver_button);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(458, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // Startserver_checkBox
            // 
            this.Startserver_checkBox.AutoSize = true;
            this.Startserver_checkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Startserver_checkBox.Location = new System.Drawing.Point(105, 126);
            this.Startserver_checkBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Startserver_checkBox.Name = "Startserver_checkBox";
            this.Startserver_checkBox.Size = new System.Drawing.Size(184, 17);
            this.Startserver_checkBox.TabIndex = 27;
            this.Startserver_checkBox.Text = "Start Server On Computer Startup";
            this.Startserver_checkBox.UseVisualStyleBackColor = true;
            this.Startserver_checkBox.Click += new System.EventHandler(this.Startserver_checkBox_Click);
            // 
            // Email_checkBox
            // 
            this.Email_checkBox.AutoSize = true;
            this.Email_checkBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Email_checkBox.Location = new System.Drawing.Point(105, 105);
            this.Email_checkBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Email_checkBox.Name = "Email_checkBox";
            this.Email_checkBox.Size = new System.Drawing.Size(218, 17);
            this.Email_checkBox.TabIndex = 26;
            this.Email_checkBox.Text = "Send Email Alert If Server Is not Running";
            this.Email_checkBox.UseVisualStyleBackColor = true;
            this.Email_checkBox.Click += new System.EventHandler(this.Email_checkBox_Click);
            // 
            // Setdir_button
            // 
            this.Setdir_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Setdir_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.Setdir_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Setdir_button.ForeColor = System.Drawing.Color.White;
            this.Setdir_button.Location = new System.Drawing.Point(341, 78);
            this.Setdir_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Setdir_button.Name = "Setdir_button";
            this.Setdir_button.Size = new System.Drawing.Size(105, 22);
            this.Setdir_button.TabIndex = 11;
            this.Setdir_button.Text = "Get Dir";
            this.Setdir_button.UseVisualStyleBackColor = true;
            this.Setdir_button.Click += new System.EventHandler(this.Setdir_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Python Install dir :";
            // 
            // Pythondir_textBox
            // 
            this.Pythondir_textBox.Location = new System.Drawing.Point(105, 81);
            this.Pythondir_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Pythondir_textBox.Name = "Pythondir_textBox";
            this.Pythondir_textBox.Size = new System.Drawing.Size(232, 20);
            this.Pythondir_textBox.TabIndex = 9;
            // 
            // Installserver_button
            // 
            this.Installserver_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Installserver_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.Installserver_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Installserver_button.ForeColor = System.Drawing.Color.White;
            this.Installserver_button.Location = new System.Drawing.Point(341, 42);
            this.Installserver_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Installserver_button.Name = "Installserver_button";
            this.Installserver_button.Size = new System.Drawing.Size(105, 22);
            this.Installserver_button.TabIndex = 8;
            this.Installserver_button.Text = "Install Server";
            this.Installserver_button.UseVisualStyleBackColor = true;
            this.Installserver_button.Click += new System.EventHandler(this.Installserver_button_Click);
            // 
            // Checkports_button
            // 
            this.Checkports_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Checkports_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.Checkports_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Checkports_button.ForeColor = System.Drawing.Color.White;
            this.Checkports_button.Location = new System.Drawing.Point(232, 42);
            this.Checkports_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Checkports_button.Name = "Checkports_button";
            this.Checkports_button.Size = new System.Drawing.Size(105, 22);
            this.Checkports_button.TabIndex = 7;
            this.Checkports_button.Text = "Check Ports";
            this.Checkports_button.UseVisualStyleBackColor = true;
            this.Checkports_button.Click += new System.EventHandler(this.Checkports_button_Click);
            // 
            // Editconfig_button
            // 
            this.Editconfig_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Editconfig_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.Editconfig_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Editconfig_button.ForeColor = System.Drawing.Color.White;
            this.Editconfig_button.Location = new System.Drawing.Point(123, 42);
            this.Editconfig_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Editconfig_button.Name = "Editconfig_button";
            this.Editconfig_button.Size = new System.Drawing.Size(105, 22);
            this.Editconfig_button.TabIndex = 6;
            this.Editconfig_button.Text = "Edit Config.py";
            this.Editconfig_button.UseVisualStyleBackColor = true;
            this.Editconfig_button.Click += new System.EventHandler(this.Editconfig_button_Click);
            // 
            // Editmainconfig_button
            // 
            this.Editmainconfig_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Editmainconfig_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.Editmainconfig_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Editmainconfig_button.ForeColor = System.Drawing.Color.White;
            this.Editmainconfig_button.Location = new System.Drawing.Point(15, 42);
            this.Editmainconfig_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Editmainconfig_button.Name = "Editmainconfig_button";
            this.Editmainconfig_button.Size = new System.Drawing.Size(105, 22);
            this.Editmainconfig_button.TabIndex = 5;
            this.Editmainconfig_button.Text = "Edit MainConfig.py";
            this.Editmainconfig_button.UseVisualStyleBackColor = true;
            this.Editmainconfig_button.Click += new System.EventHandler(this.Editmainconfig_button_Click);
            // 
            // Uninstallserver_button
            // 
            this.Uninstallserver_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Uninstallserver_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.Uninstallserver_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Uninstallserver_button.ForeColor = System.Drawing.Color.White;
            this.Uninstallserver_button.Location = new System.Drawing.Point(341, 16);
            this.Uninstallserver_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Uninstallserver_button.Name = "Uninstallserver_button";
            this.Uninstallserver_button.Size = new System.Drawing.Size(105, 22);
            this.Uninstallserver_button.TabIndex = 4;
            this.Uninstallserver_button.Text = "Uninstall Server";
            this.Uninstallserver_button.UseVisualStyleBackColor = true;
            this.Uninstallserver_button.Click += new System.EventHandler(this.Uninstallserver_button_Click);
            // 
            // Restartserver_button
            // 
            this.Restartserver_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Restartserver_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.Restartserver_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Restartserver_button.ForeColor = System.Drawing.Color.White;
            this.Restartserver_button.Location = new System.Drawing.Point(232, 16);
            this.Restartserver_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Restartserver_button.Name = "Restartserver_button";
            this.Restartserver_button.Size = new System.Drawing.Size(105, 22);
            this.Restartserver_button.TabIndex = 3;
            this.Restartserver_button.Text = "Restart Server";
            this.Restartserver_button.UseVisualStyleBackColor = true;
            this.Restartserver_button.Click += new System.EventHandler(this.Restartserver_button_Click);
            // 
            // Stopserver_button
            // 
            this.Stopserver_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Stopserver_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.Stopserver_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stopserver_button.ForeColor = System.Drawing.Color.White;
            this.Stopserver_button.Location = new System.Drawing.Point(123, 16);
            this.Stopserver_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Stopserver_button.Name = "Stopserver_button";
            this.Stopserver_button.Size = new System.Drawing.Size(105, 22);
            this.Stopserver_button.TabIndex = 2;
            this.Stopserver_button.Text = "Stop Server";
            this.Stopserver_button.UseVisualStyleBackColor = true;
            this.Stopserver_button.Click += new System.EventHandler(this.Stopserver_button_Click);
            // 
            // Startserver_button
            // 
            this.Startserver_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Startserver_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.Startserver_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Startserver_button.ForeColor = System.Drawing.Color.White;
            this.Startserver_button.Location = new System.Drawing.Point(15, 16);
            this.Startserver_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Startserver_button.Name = "Startserver_button";
            this.Startserver_button.Size = new System.Drawing.Size(105, 22);
            this.Startserver_button.TabIndex = 1;
            this.Startserver_button.Text = "Start Server";
            this.Startserver_button.UseVisualStyleBackColor = true;
            this.Startserver_button.Click += new System.EventHandler(this.Startserver_button_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.emailSetupToolStripMenuItem,
            this.readMeToolStripMenuItem,
            this.testAPIToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(499, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(76, 28);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // emailSetupToolStripMenuItem
            // 
            this.emailSetupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("emailSetupToolStripMenuItem.Image")));
            this.emailSetupToolStripMenuItem.Name = "emailSetupToolStripMenuItem";
            this.emailSetupToolStripMenuItem.Size = new System.Drawing.Size(105, 28);
            this.emailSetupToolStripMenuItem.Text = "Email Setup";
            this.emailSetupToolStripMenuItem.Click += new System.EventHandler(this.emailSetupToolStripMenuItem_Click);
            // 
            // readMeToolStripMenuItem
            // 
            this.readMeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("readMeToolStripMenuItem.Image")));
            this.readMeToolStripMenuItem.Name = "readMeToolStripMenuItem";
            this.readMeToolStripMenuItem.Size = new System.Drawing.Size(86, 28);
            this.readMeToolStripMenuItem.Text = "ReadMe";
            this.readMeToolStripMenuItem.Click += new System.EventHandler(this.readMeToolStripMenuItem_Click);
            // 
            // testAPIToolStripMenuItem
            // 
            this.testAPIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freeTAKServerAPIToolStripMenuItem,
            this.telegramAPIToolStripMenuItem});
            this.testAPIToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("testAPIToolStripMenuItem.Image")));
            this.testAPIToolStripMenuItem.Name = "testAPIToolStripMenuItem";
            this.testAPIToolStripMenuItem.Size = new System.Drawing.Size(84, 28);
            this.testAPIToolStripMenuItem.Text = "Test API";
            // 
            // freeTAKServerAPIToolStripMenuItem
            // 
            this.freeTAKServerAPIToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("freeTAKServerAPIToolStripMenuItem.Image")));
            this.freeTAKServerAPIToolStripMenuItem.Name = "freeTAKServerAPIToolStripMenuItem";
            this.freeTAKServerAPIToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.freeTAKServerAPIToolStripMenuItem.Text = "FreeTAKServer API";
            this.freeTAKServerAPIToolStripMenuItem.Click += new System.EventHandler(this.freeTAKServerAPIToolStripMenuItem_Click);
            // 
            // telegramAPIToolStripMenuItem
            // 
            this.telegramAPIToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("telegramAPIToolStripMenuItem.Image")));
            this.telegramAPIToolStripMenuItem.Name = "telegramAPIToolStripMenuItem";
            this.telegramAPIToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.telegramAPIToolStripMenuItem.Text = "Telegram API";
            this.telegramAPIToolStripMenuItem.Click += new System.EventHandler(this.telegramAPIToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 371);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip1.Size = new System.Drawing.Size(499, 23);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(67, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 18);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(499, 394);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FreeTAKServer Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox Logs_richTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Installserver_button;
        private System.Windows.Forms.Button Checkports_button;
        private System.Windows.Forms.Button Editconfig_button;
        private System.Windows.Forms.Button Editmainconfig_button;
        private System.Windows.Forms.Button Uninstallserver_button;
        private System.Windows.Forms.Button Restartserver_button;
        private System.Windows.Forms.Button Stopserver_button;
        private System.Windows.Forms.Button Startserver_button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailSetupToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem readMeToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Pythondir_textBox;
        private System.Windows.Forms.Button Setdir_button;
        private System.Windows.Forms.ToolStripMenuItem testAPIToolStripMenuItem;
        private System.Windows.Forms.CheckBox Email_checkBox;
        private System.Windows.Forms.CheckBox Startserver_checkBox;
        private System.Windows.Forms.ToolStripMenuItem freeTAKServerAPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem telegramAPIToolStripMenuItem;
    }
}

