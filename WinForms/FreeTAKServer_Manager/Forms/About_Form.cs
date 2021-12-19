using System;
using System.Net.Http;
using System.Windows.Forms;
using static FreeTAKServer_Manager.LoggerClass;

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
            label2.Text = "Version " + Application.ProductVersion;
        }

        private void Checkforupdate_button_Click(object sender, EventArgs e)
        {
           try
           {
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                Logger.WriteLine(" *** Ran UpdateExe:" + Environment.NewLine + " [About_Form] ***");
           }
           catch (Exception ex)
           {
             MessageBox.Show(ex.Message, "Could not check for update", MessageBoxButtons.OK, MessageBoxIcon.Error);
             Logger.WriteLine(" *** Error:" + ex.Message + " [About_Form] ***");
             return;
           }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Invoke(new MethodInvoker(() => RunUpdateExeClass.RunExeActions()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Run Update Exe Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private async void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            string version = "1.005";
            using (HttpClient client = new HttpClient())
            {
                //Add Default Request Headers
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(new Uri($"https://techrad.co.za/ATAK/FreeTAKServer_Manager/Winforms/getDownLoadUrl.php?version={version}")))
                    {
                        using (HttpContent content = response.Content)
                        {
                            //Read the result and display in Textbox
                            string result = await content.ReadAsStringAsync();//Result string JSON
                            string reasonPhrase = response.ReasonPhrase;//Reason OK, FAIL etc.
                            Logger.WriteLine(" *** result:" + result + " [About_Form] ***");
                            Logger.WriteLine(" *** reasonPhrase:" + reasonPhrase + " [About_Form] ***");
                            MessageBox.Show(result, "Updater", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not test API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    return;
                }
            }
        }
    }
}
