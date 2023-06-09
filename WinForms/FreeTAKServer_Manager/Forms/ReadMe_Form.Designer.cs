
namespace FreeTAKServer_Manager
{
    partial class ReadMe_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadMe_Form));
            this.ReadMeRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ReadMeRichTextBox
            // 
            this.ReadMeRichTextBox.BackColor = System.Drawing.Color.Black;
            this.ReadMeRichTextBox.ForeColor = System.Drawing.Color.White;
            this.ReadMeRichTextBox.Location = new System.Drawing.Point(12, 12);
            this.ReadMeRichTextBox.Name = "ReadMeRichTextBox";
            this.ReadMeRichTextBox.ReadOnly = true;
            this.ReadMeRichTextBox.Size = new System.Drawing.Size(742, 473);
            this.ReadMeRichTextBox.TabIndex = 0;
            this.ReadMeRichTextBox.Text = "";
            // 
            // ReadMe_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(766, 497);
            this.Controls.Add(this.ReadMeRichTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReadMe_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReadMe ";
            this.Load += new System.EventHandler(this.ReadMe_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ReadMeRichTextBox;
    }
}