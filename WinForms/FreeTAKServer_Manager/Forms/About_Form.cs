﻿using System;
using System.Windows.Forms;

namespace FreeTAKServer_Manager
{
    public partial class About_Form : Form
    {
        public About_Form()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Opens link to https://github.com/FreeTAKTeam
            System.Diagnostics.Process.Start("https://github.com/FreeTAKTeam");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Opens link to https://tutorials.techrad.co.za
            System.Diagnostics.Process.Start("https://tutorials.techrad.co.za"); 
        }

        private void About_Form_Load(object sender, EventArgs e)
        {
            label2.Text = $"Version {Application.ProductVersion}";
        }

        private void Checkforupdate_button_Click(object sender, EventArgs e)
        {
           try
           {
                using (Form Form = new UpdateForm())
                {
                    Form.ShowDialog();
                    Form.Activate();
                }
                LoggerClass.WriteLine(" *** Ran Update [About_Form] ***");
           }
           catch (Exception Exception)
           {
             MessageBox.Show(Exception.Message, "Could not check for update", MessageBoxButtons.OK, MessageBoxIcon.Error);
             LoggerClass.WriteLine($" *** Error:{Exception.Message} [About_Form] ***");
             return;
           }
        }
    }
}
