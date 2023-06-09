
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
            this.TokenTextBox = new System.Windows.Forms.TextBox();
            this.CustomTestTextBox = new System.Windows.Forms.TextBox();
            this.CustomButton = new System.Windows.Forms.Button();
            this.TestButton = new System.Windows.Forms.Button();
            this.MemoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TokenTextBox);
            this.groupBox1.Controls.Add(this.CustomTestTextBox);
            this.groupBox1.Controls.Add(this.CustomButton);
            this.groupBox1.Controls.Add(this.TestButton);
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
            // TokenTextBox
            // 
            this.TokenTextBox.Location = new System.Drawing.Point(108, 97);
            this.TokenTextBox.Name = "TokenTextBox";
            this.TokenTextBox.Size = new System.Drawing.Size(747, 26);
            this.TokenTextBox.TabIndex = 13;
            // 
            // CustomTestTextBox
            // 
            this.CustomTestTextBox.Location = new System.Drawing.Point(108, 65);
            this.CustomTestTextBox.Name = "CustomTestTextBox";
            this.CustomTestTextBox.Size = new System.Drawing.Size(747, 26);
            this.CustomTestTextBox.TabIndex = 12;
            // 
            // CustomButton
            // 
            this.CustomButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CustomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(37)))));
            this.CustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomButton.ForeColor = System.Drawing.Color.White;
            this.CustomButton.Location = new System.Drawing.Point(169, 25);
            this.CustomButton.Name = "CustomButton";
            this.CustomButton.Size = new System.Drawing.Size(157, 34);
            this.CustomButton.TabIndex = 11;
            this.CustomButton.Text = "Custom Test";
            this.CustomButton.UseVisualStyleBackColor = true;
            this.CustomButton.Click += new System.EventHandler(this.Custom_button_Click);
            // 
            // TestButton
            // 
            this.TestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TestButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(37)))));
            this.TestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestButton.ForeColor = System.Drawing.Color.White;
            this.TestButton.Location = new System.Drawing.Point(6, 25);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(157, 34);
            this.TestButton.TabIndex = 10;
            this.TestButton.Text = "Local Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.Test_button_Click);
            // 
            // MemoRichTextBox
            // 
            this.MemoRichTextBox.BackColor = System.Drawing.Color.Black;
            this.MemoRichTextBox.ForeColor = System.Drawing.Color.White;
            this.MemoRichTextBox.Location = new System.Drawing.Point(15, 171);
            this.MemoRichTextBox.Name = "MemoRichTextBox";
            this.MemoRichTextBox.ReadOnly = true;
            this.MemoRichTextBox.Size = new System.Drawing.Size(861, 395);
            this.MemoRichTextBox.TabIndex = 2;
            this.MemoRichTextBox.Text = "";
            // 
            // FreeTAKServer_API_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(890, 583);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MemoRichTextBox);
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
        private System.Windows.Forms.TextBox TokenTextBox;
        private System.Windows.Forms.TextBox CustomTestTextBox;
        private System.Windows.Forms.Button CustomButton;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.RichTextBox MemoRichTextBox;
    }
}