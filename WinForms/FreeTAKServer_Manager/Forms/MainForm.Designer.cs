
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
            this.LogsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StartServerCheckBox = new System.Windows.Forms.CheckBox();
            this.EmailCheckBox = new System.Windows.Forms.CheckBox();
            this.SetDirButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PythonDirTextBox = new System.Windows.Forms.TextBox();
            this.InstallServerButton = new System.Windows.Forms.Button();
            this.CheckPortsButton = new System.Windows.Forms.Button();
            this.EditConfigButton = new System.Windows.Forms.Button();
            this.EditMainConfigButton = new System.Windows.Forms.Button();
            this.UninstallServerButton = new System.Windows.Forms.Button();
            this.RestartServerButton = new System.Windows.Forms.Button();
            this.StopServerButton = new System.Windows.Forms.Button();
            this.StartServerButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmailSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReadMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FreeTAKServerAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TelegramAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 522);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LogsRichTextBox);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(18, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(687, 249);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logs";
            // 
            // LogsRichTextBox
            // 
            this.LogsRichTextBox.BackColor = System.Drawing.Color.Black;
            this.LogsRichTextBox.ForeColor = System.Drawing.Color.White;
            this.LogsRichTextBox.HideSelection = false;
            this.LogsRichTextBox.Location = new System.Drawing.Point(6, 25);
            this.LogsRichTextBox.Name = "LogsRichTextBox";
            this.LogsRichTextBox.ReadOnly = true;
            this.LogsRichTextBox.Size = new System.Drawing.Size(674, 213);
            this.LogsRichTextBox.TabIndex = 0;
            this.LogsRichTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StartServerCheckBox);
            this.groupBox1.Controls.Add(this.EmailCheckBox);
            this.groupBox1.Controls.Add(this.SetDirButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PythonDirTextBox);
            this.groupBox1.Controls.Add(this.InstallServerButton);
            this.groupBox1.Controls.Add(this.CheckPortsButton);
            this.groupBox1.Controls.Add(this.EditConfigButton);
            this.groupBox1.Controls.Add(this.EditMainConfigButton);
            this.groupBox1.Controls.Add(this.UninstallServerButton);
            this.groupBox1.Controls.Add(this.RestartServerButton);
            this.groupBox1.Controls.Add(this.StopServerButton);
            this.groupBox1.Controls.Add(this.StartServerButton);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(18, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // StartServerCheckBox
            // 
            this.StartServerCheckBox.AutoSize = true;
            this.StartServerCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartServerCheckBox.Location = new System.Drawing.Point(158, 194);
            this.StartServerCheckBox.Name = "StartServerCheckBox";
            this.StartServerCheckBox.Size = new System.Drawing.Size(276, 24);
            this.StartServerCheckBox.TabIndex = 27;
            this.StartServerCheckBox.Text = "Start Server On Computer Startup";
            this.StartServerCheckBox.UseVisualStyleBackColor = true;
            this.StartServerCheckBox.Click += new System.EventHandler(this.Startserver_checkBox_Click);
            // 
            // EmailCheckBox
            // 
            this.EmailCheckBox.AutoSize = true;
            this.EmailCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EmailCheckBox.Location = new System.Drawing.Point(158, 162);
            this.EmailCheckBox.Name = "EmailCheckBox";
            this.EmailCheckBox.Size = new System.Drawing.Size(325, 24);
            this.EmailCheckBox.TabIndex = 26;
            this.EmailCheckBox.Text = "Send Email Alert If Server Is not Running";
            this.EmailCheckBox.UseVisualStyleBackColor = true;
            this.EmailCheckBox.Click += new System.EventHandler(this.Email_checkBox_Click);
            // 
            // SetDirButton
            // 
            this.SetDirButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SetDirButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.SetDirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetDirButton.ForeColor = System.Drawing.Color.White;
            this.SetDirButton.Location = new System.Drawing.Point(512, 120);
            this.SetDirButton.Name = "SetDirButton";
            this.SetDirButton.Size = new System.Drawing.Size(158, 34);
            this.SetDirButton.TabIndex = 11;
            this.SetDirButton.Text = "Get Dir";
            this.SetDirButton.UseVisualStyleBackColor = true;
            this.SetDirButton.Click += new System.EventHandler(this.Setdir_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Python Install dir :";
            // 
            // PythonDirTextBox
            // 
            this.PythonDirTextBox.Location = new System.Drawing.Point(158, 125);
            this.PythonDirTextBox.Name = "PythonDirTextBox";
            this.PythonDirTextBox.Size = new System.Drawing.Size(346, 26);
            this.PythonDirTextBox.TabIndex = 9;
            // 
            // InstallServerButton
            // 
            this.InstallServerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InstallServerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.InstallServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstallServerButton.ForeColor = System.Drawing.Color.White;
            this.InstallServerButton.Location = new System.Drawing.Point(512, 65);
            this.InstallServerButton.Name = "InstallServerButton";
            this.InstallServerButton.Size = new System.Drawing.Size(158, 34);
            this.InstallServerButton.TabIndex = 8;
            this.InstallServerButton.Text = "Install Server";
            this.InstallServerButton.UseVisualStyleBackColor = true;
            this.InstallServerButton.Click += new System.EventHandler(this.Installserver_button_Click);
            // 
            // CheckPortsButton
            // 
            this.CheckPortsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckPortsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.CheckPortsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckPortsButton.ForeColor = System.Drawing.Color.White;
            this.CheckPortsButton.Location = new System.Drawing.Point(348, 65);
            this.CheckPortsButton.Name = "CheckPortsButton";
            this.CheckPortsButton.Size = new System.Drawing.Size(158, 34);
            this.CheckPortsButton.TabIndex = 7;
            this.CheckPortsButton.Text = "Check Ports";
            this.CheckPortsButton.UseVisualStyleBackColor = true;
            this.CheckPortsButton.Click += new System.EventHandler(this.Checkports_button_Click);
            // 
            // EditConfigButton
            // 
            this.EditConfigButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditConfigButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.EditConfigButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditConfigButton.ForeColor = System.Drawing.Color.White;
            this.EditConfigButton.Location = new System.Drawing.Point(184, 65);
            this.EditConfigButton.Name = "EditConfigButton";
            this.EditConfigButton.Size = new System.Drawing.Size(158, 34);
            this.EditConfigButton.TabIndex = 6;
            this.EditConfigButton.Text = "Edit Config.py";
            this.EditConfigButton.UseVisualStyleBackColor = true;
            this.EditConfigButton.Click += new System.EventHandler(this.Editconfig_button_Click);
            // 
            // EditMainConfigButton
            // 
            this.EditMainConfigButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditMainConfigButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.EditMainConfigButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditMainConfigButton.ForeColor = System.Drawing.Color.White;
            this.EditMainConfigButton.Location = new System.Drawing.Point(22, 65);
            this.EditMainConfigButton.Name = "EditMainConfigButton";
            this.EditMainConfigButton.Size = new System.Drawing.Size(158, 34);
            this.EditMainConfigButton.TabIndex = 5;
            this.EditMainConfigButton.Text = "Edit MainConfig.py";
            this.EditMainConfigButton.UseVisualStyleBackColor = true;
            this.EditMainConfigButton.Click += new System.EventHandler(this.Editmainconfig_button_Click);
            // 
            // UninstallServerButton
            // 
            this.UninstallServerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UninstallServerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.UninstallServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UninstallServerButton.ForeColor = System.Drawing.Color.White;
            this.UninstallServerButton.Location = new System.Drawing.Point(512, 25);
            this.UninstallServerButton.Name = "UninstallServerButton";
            this.UninstallServerButton.Size = new System.Drawing.Size(158, 34);
            this.UninstallServerButton.TabIndex = 4;
            this.UninstallServerButton.Text = "Uninstall Server";
            this.UninstallServerButton.UseVisualStyleBackColor = true;
            this.UninstallServerButton.Click += new System.EventHandler(this.Uninstallserver_button_Click);
            // 
            // RestartServerButton
            // 
            this.RestartServerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RestartServerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.RestartServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestartServerButton.ForeColor = System.Drawing.Color.White;
            this.RestartServerButton.Location = new System.Drawing.Point(348, 25);
            this.RestartServerButton.Name = "RestartServerButton";
            this.RestartServerButton.Size = new System.Drawing.Size(158, 34);
            this.RestartServerButton.TabIndex = 3;
            this.RestartServerButton.Text = "Restart Server";
            this.RestartServerButton.UseVisualStyleBackColor = true;
            this.RestartServerButton.Click += new System.EventHandler(this.Restartserver_button_Click);
            // 
            // StopServerButton
            // 
            this.StopServerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopServerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.StopServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopServerButton.ForeColor = System.Drawing.Color.White;
            this.StopServerButton.Location = new System.Drawing.Point(184, 25);
            this.StopServerButton.Name = "StopServerButton";
            this.StopServerButton.Size = new System.Drawing.Size(158, 34);
            this.StopServerButton.TabIndex = 2;
            this.StopServerButton.Text = "Stop Server";
            this.StopServerButton.UseVisualStyleBackColor = true;
            this.StopServerButton.Click += new System.EventHandler(this.Stopserver_button_Click);
            // 
            // StartServerButton
            // 
            this.StartServerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartServerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.StartServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartServerButton.ForeColor = System.Drawing.Color.White;
            this.StartServerButton.Location = new System.Drawing.Point(22, 25);
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.Size = new System.Drawing.Size(158, 34);
            this.StartServerButton.TabIndex = 1;
            this.StartServerButton.Text = "Start Server";
            this.StartServerButton.UseVisualStyleBackColor = true;
            this.StartServerButton.Click += new System.EventHandler(this.Startserver_button_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem,
            this.EmailSetupToolStripMenuItem,
            this.ReadMeToolStripMenuItem,
            this.TestAPIToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(748, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.AboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("AboutToolStripMenuItem.Image")));
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(102, 29);
            this.AboutToolStripMenuItem.Text = "About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // EmailSetupToolStripMenuItem
            // 
            this.EmailSetupToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.EmailSetupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("EmailSetupToolStripMenuItem.Image")));
            this.EmailSetupToolStripMenuItem.Name = "EmailSetupToolStripMenuItem";
            this.EmailSetupToolStripMenuItem.Size = new System.Drawing.Size(145, 29);
            this.EmailSetupToolStripMenuItem.Text = "Email Setup";
            this.EmailSetupToolStripMenuItem.Click += new System.EventHandler(this.EmailSetupToolStripMenuItem_Click);
            // 
            // ReadMeToolStripMenuItem
            // 
            this.ReadMeToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.ReadMeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ReadMeToolStripMenuItem.Image")));
            this.ReadMeToolStripMenuItem.Name = "ReadMeToolStripMenuItem";
            this.ReadMeToolStripMenuItem.Size = new System.Drawing.Size(116, 29);
            this.ReadMeToolStripMenuItem.Text = "ReadMe";
            this.ReadMeToolStripMenuItem.Click += new System.EventHandler(this.ReadMeToolStripMenuItem_Click);
            // 
            // TestAPIToolStripMenuItem
            // 
            this.TestAPIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FreeTAKServerAPIToolStripMenuItem,
            this.TelegramAPIToolStripMenuItem});
            this.TestAPIToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.TestAPIToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("TestAPIToolStripMenuItem.Image")));
            this.TestAPIToolStripMenuItem.Name = "TestAPIToolStripMenuItem";
            this.TestAPIToolStripMenuItem.Size = new System.Drawing.Size(114, 29);
            this.TestAPIToolStripMenuItem.Text = "Test API";
            // 
            // FreeTAKServerAPIToolStripMenuItem
            // 
            this.FreeTAKServerAPIToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("FreeTAKServerAPIToolStripMenuItem.Image")));
            this.FreeTAKServerAPIToolStripMenuItem.Name = "FreeTAKServerAPIToolStripMenuItem";
            this.FreeTAKServerAPIToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.FreeTAKServerAPIToolStripMenuItem.Text = "FreeTAKServer API";
            this.FreeTAKServerAPIToolStripMenuItem.Click += new System.EventHandler(this.FreeTAKServerAPIToolStripMenuItem_Click);
            // 
            // TelegramAPIToolStripMenuItem
            // 
            this.TelegramAPIToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("TelegramAPIToolStripMenuItem.Image")));
            this.TelegramAPIToolStripMenuItem.Name = "TelegramAPIToolStripMenuItem";
            this.TelegramAPIToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.TelegramAPIToolStripMenuItem.Text = "Telegram API";
            this.TelegramAPIToolStripMenuItem.Click += new System.EventHandler(this.TelegramAPIToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar,
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 574);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(748, 32);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 24);
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(60, 25);
            this.StatusLabel.Text = "Ready";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(748, 606);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(770, 662);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(770, 662);
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
        private System.Windows.Forms.RichTextBox LogsRichTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button InstallServerButton;
        private System.Windows.Forms.Button CheckPortsButton;
        private System.Windows.Forms.Button EditConfigButton;
        private System.Windows.Forms.Button EditMainConfigButton;
        private System.Windows.Forms.Button UninstallServerButton;
        private System.Windows.Forms.Button RestartServerButton;
        private System.Windows.Forms.Button StopServerButton;
        private System.Windows.Forms.Button StartServerButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EmailSetupToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripMenuItem ReadMeToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PythonDirTextBox;
        private System.Windows.Forms.Button SetDirButton;
        private System.Windows.Forms.ToolStripMenuItem TestAPIToolStripMenuItem;
        private System.Windows.Forms.CheckBox EmailCheckBox;
        private System.Windows.Forms.CheckBox StartServerCheckBox;
        private System.Windows.Forms.ToolStripMenuItem FreeTAKServerAPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TelegramAPIToolStripMenuItem;
    }
}

