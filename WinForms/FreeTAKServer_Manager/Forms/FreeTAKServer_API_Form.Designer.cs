
namespace FreeTAKServer_Manager
{
    partial class FreeTAKServer_API_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreeTAKServer_API_Form));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Token_textBox = new System.Windows.Forms.TextBox();
            this.Customtest_textBox = new System.Windows.Forms.TextBox();
            this.Custom_button = new System.Windows.Forms.Button();
            this.Test_button = new System.Windows.Forms.Button();
            this.Memo_richTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Token_textBox);
            this.groupBox1.Controls.Add(this.Customtest_textBox);
            this.groupBox1.Controls.Add(this.Custom_button);
            this.groupBox1.Controls.Add(this.Test_button);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(861, 153);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Custom Url :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Token :";
            // 
            // Token_textBox
            // 
            this.Token_textBox.Location = new System.Drawing.Point(108, 97);
            this.Token_textBox.Name = "Token_textBox";
            this.Token_textBox.Size = new System.Drawing.Size(747, 26);
            this.Token_textBox.TabIndex = 13;
            // 
            // Customtest_textBox
            // 
            this.Customtest_textBox.Location = new System.Drawing.Point(108, 65);
            this.Customtest_textBox.Name = "Customtest_textBox";
            this.Customtest_textBox.Size = new System.Drawing.Size(747, 26);
            this.Customtest_textBox.TabIndex = 12;
            // 
            // Custom_button
            // 
            this.Custom_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Custom_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(37)))));
            this.Custom_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Custom_button.ForeColor = System.Drawing.Color.White;
            this.Custom_button.Location = new System.Drawing.Point(169, 25);
            this.Custom_button.Name = "Custom_button";
            this.Custom_button.Size = new System.Drawing.Size(157, 34);
            this.Custom_button.TabIndex = 11;
            this.Custom_button.Text = "Custom Test";
            this.Custom_button.UseVisualStyleBackColor = true;
            this.Custom_button.Click += new System.EventHandler(this.Custom_button_Click);
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
            this.Test_button.TabIndex = 10;
            this.Test_button.Text = "Local Test";
            this.Test_button.UseVisualStyleBackColor = true;
            this.Test_button.Click += new System.EventHandler(this.Test_button_Click);
            // 
            // Memo_richTextBox
            // 
            this.Memo_richTextBox.BackColor = System.Drawing.Color.Black;
            this.Memo_richTextBox.ForeColor = System.Drawing.Color.White;
            this.Memo_richTextBox.Location = new System.Drawing.Point(15, 171);
            this.Memo_richTextBox.Name = "Memo_richTextBox";
            this.Memo_richTextBox.ReadOnly = true;
            this.Memo_richTextBox.Size = new System.Drawing.Size(861, 395);
            this.Memo_richTextBox.TabIndex = 2;
            this.Memo_richTextBox.Text = "";
            // 
            // FreeTAKServer_API_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(890, 583);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Memo_richTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FreeTAKServer_API_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FreeTAKServer API";
            this.Load += new System.EventHandler(this.FreeTAKServer_API_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Token_textBox;
        private System.Windows.Forms.TextBox Customtest_textBox;
        private System.Windows.Forms.Button Custom_button;
        private System.Windows.Forms.Button Test_button;
        private System.Windows.Forms.RichTextBox Memo_richTextBox;
    }
}