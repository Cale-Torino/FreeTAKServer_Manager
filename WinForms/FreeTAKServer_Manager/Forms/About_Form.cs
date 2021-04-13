using System;
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
           System.Diagnostics.Process.Start("https://github.com/FreeTAKTeam");
        }

        private void About_Form_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://tutorials.techrad.co.za"); 
        }
    }
}
