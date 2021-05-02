
namespace FreeTAKServer_Manager
{
    partial class TelegramAPIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelegramAPIForm));
            this.Memo_richTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Custom_Test_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Customtest_textBox = new System.Windows.Forms.TextBox();
            this.Test_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Chat_id_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Token_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Memo_richTextBox
            // 
            this.Memo_richTextBox.BackColor = System.Drawing.Color.Black;
            this.Memo_richTextBox.ForeColor = System.Drawing.Color.White;
            this.Memo_richTextBox.Location = new System.Drawing.Point(12, 206);
            this.Memo_richTextBox.Name = "Memo_richTextBox";
            this.Memo_richTextBox.ReadOnly = true;
            this.Memo_richTextBox.Size = new System.Drawing.Size(879, 376);
            this.Memo_richTextBox.TabIndex = 0;
            this.Memo_richTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Token_textBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Chat_id_textBox);
            this.groupBox1.Controls.Add(this.Custom_Test_button);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Customtest_textBox);
            this.groupBox1.Controls.Add(this.Test_button);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(879, 188);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // Custom_Test_button
            // 
            this.Custom_Test_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Custom_Test_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(37)))));
            this.Custom_Test_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Custom_Test_button.ForeColor = System.Drawing.Color.White;
            this.Custom_Test_button.Location = new System.Drawing.Point(169, 25);
            this.Custom_Test_button.Name = "Custom_Test_button";
            this.Custom_Test_button.Size = new System.Drawing.Size(157, 34);
            this.Custom_Test_button.TabIndex = 17;
            this.Custom_Test_button.Text = "Custom Test";
            this.Custom_Test_button.UseVisualStyleBackColor = true;
            this.Custom_Test_button.Click += new System.EventHandler(this.Custom_Test_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Custom Url :";
            // 
            // Customtest_textBox
            // 
            this.Customtest_textBox.Location = new System.Drawing.Point(108, 76);
            this.Customtest_textBox.Name = "Customtest_textBox";
            this.Customtest_textBox.Size = new System.Drawing.Size(747, 26);
            this.Customtest_textBox.TabIndex = 12;
            // 
            // Test_button
            // 
            this.Test_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Test_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(37)))));
            this.Test_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Test_button.ForeColor = System.Drawing.Color.White;
            this.Test_button.Location = new System.Drawing.Point(6, 25);
            this.Test_button.Name = "Test_button";
            this.Test_button.Size = new System.Drawing.Size(157, 34);
            this.Test_button.TabIndex = 11;
            this.Test_button.Text = "Hello Test";
            this.Test_button.UseVisualStyleBackColor = true;
            this.Test_button.Click += new System.EventHandler(this.Test_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Chat ID :";
            // 
            // Chat_id_textBox
            // 
            this.Chat_id_textBox.Location = new System.Drawing.Point(108, 108);
            this.Chat_id_textBox.Name = "Chat_id_textBox";
            this.Chat_id_textBox.Size = new System.Drawing.Size(747, 26);
            this.Chat_id_textBox.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Token :";
            // 
            // Token_textBox
            // 
            this.Token_textBox.Location = new System.Drawing.Point(108, 140);
            this.Token_textBox.Name = "Token_textBox";
            this.Token_textBox.Size = new System.Drawing.Size(747, 26);
            this.Token_textBox.TabIndex = 20;
            // 
            // TelegramAPIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(907, 594);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Memo_richTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelegramAPIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Telegram API";
            this.Load += new System.EventHandler(this.TelegramAPIForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Memo_richTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Test_button;
        private System.Windows.Forms.TextBox Customtest_textBox;
        private System.Windows.Forms.Button Custom_Test_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Chat_id_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Token_textBox;
    }
}