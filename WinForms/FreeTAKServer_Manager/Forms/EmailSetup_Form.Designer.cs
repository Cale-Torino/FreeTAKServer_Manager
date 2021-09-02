
namespace FreeTAKServer_Manager
{
    partial class EmailSetup_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailSetup_Form));
            this.Test_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.Username_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Body_textBox = new System.Windows.Forms.TextBox();
            this.Subject_textBox = new System.Windows.Forms.TextBox();
            this.To_textBox = new System.Windows.Forms.TextBox();
            this.From_textBox = new System.Windows.Forms.TextBox();
            this.Smtp_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Savesettings_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Test_button
            // 
            this.Test_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Test_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(37)))));
            this.Test_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Test_button.ForeColor = System.Drawing.Color.White;
            this.Test_button.Location = new System.Drawing.Point(102, 169);
            this.Test_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Test_button.Name = "Test_button";
            this.Test_button.Size = new System.Drawing.Size(105, 22);
            this.Test_button.TabIndex = 9;
            this.Test_button.Text = "Test";
            this.Test_button.UseVisualStyleBackColor = true;
            this.Test_button.Click += new System.EventHandler(this.Test_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Password_textBox);
            this.groupBox1.Controls.Add(this.Username_textBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Body_textBox);
            this.groupBox1.Controls.Add(this.Subject_textBox);
            this.groupBox1.Controls.Add(this.To_textBox);
            this.groupBox1.Controls.Add(this.From_textBox);
            this.groupBox1.Controls.Add(this.Smtp_textBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Savesettings_button);
            this.groupBox1.Controls.Add(this.Test_button);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(345, 217);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Email Setup";
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(101, 145);
            this.Password_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '•';
            this.Password_textBox.Size = new System.Drawing.Size(215, 20);
            this.Password_textBox.TabIndex = 24;
            this.Password_textBox.UseSystemPasswordChar = true;
            // 
            // Username_textBox
            // 
            this.Username_textBox.Location = new System.Drawing.Point(101, 124);
            this.Username_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Username_textBox.Name = "Username_textBox";
            this.Username_textBox.Size = new System.Drawing.Size(215, 20);
            this.Username_textBox.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 148);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "PASSWORD :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 127);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "USERNAME :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "BODY :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "SUBJECT :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "TO :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "FROM :";
            // 
            // Body_textBox
            // 
            this.Body_textBox.Location = new System.Drawing.Point(101, 104);
            this.Body_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Body_textBox.Name = "Body_textBox";
            this.Body_textBox.Size = new System.Drawing.Size(215, 20);
            this.Body_textBox.TabIndex = 16;
            // 
            // Subject_textBox
            // 
            this.Subject_textBox.Location = new System.Drawing.Point(101, 83);
            this.Subject_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Subject_textBox.Name = "Subject_textBox";
            this.Subject_textBox.Size = new System.Drawing.Size(215, 20);
            this.Subject_textBox.TabIndex = 15;
            // 
            // To_textBox
            // 
            this.To_textBox.Location = new System.Drawing.Point(101, 62);
            this.To_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.To_textBox.Name = "To_textBox";
            this.To_textBox.Size = new System.Drawing.Size(215, 20);
            this.To_textBox.TabIndex = 14;
            // 
            // From_textBox
            // 
            this.From_textBox.Location = new System.Drawing.Point(101, 41);
            this.From_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.From_textBox.Name = "From_textBox";
            this.From_textBox.Size = new System.Drawing.Size(215, 20);
            this.From_textBox.TabIndex = 13;
            // 
            // Smtp_textBox
            // 
            this.Smtp_textBox.Location = new System.Drawing.Point(101, 20);
            this.Smtp_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Smtp_textBox.Name = "Smtp_textBox";
            this.Smtp_textBox.Size = new System.Drawing.Size(215, 20);
            this.Smtp_textBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "SMTP :";
            // 
            // Savesettings_button
            // 
            this.Savesettings_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Savesettings_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(37)))));
            this.Savesettings_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Savesettings_button.ForeColor = System.Drawing.Color.White;
            this.Savesettings_button.Location = new System.Drawing.Point(211, 169);
            this.Savesettings_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Savesettings_button.Name = "Savesettings_button";
            this.Savesettings_button.Size = new System.Drawing.Size(105, 22);
            this.Savesettings_button.TabIndex = 10;
            this.Savesettings_button.Text = "Edit Settings";
            this.Savesettings_button.UseVisualStyleBackColor = true;
            this.Savesettings_button.Click += new System.EventHandler(this.Savesettings_button_Click);
            // 
            // EmailSetup_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(364, 236);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmailSetup_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Email Setup";
            this.Load += new System.EventHandler(this.EmailSetup_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Test_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Savesettings_button;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.TextBox Username_textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Body_textBox;
        private System.Windows.Forms.TextBox Subject_textBox;
        private System.Windows.Forms.TextBox To_textBox;
        private System.Windows.Forms.TextBox From_textBox;
        private System.Windows.Forms.TextBox Smtp_textBox;
        private System.Windows.Forms.Label label1;
    }
}