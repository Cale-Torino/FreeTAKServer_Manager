using System;
using System.Net.Http;
using System.Windows.Forms;

namespace FreeTAKServer_Manager
{
    public partial class FreeTAKServer_API_Form : Form
    {
        public FreeTAKServer_API_Form()
        {
            InitializeComponent();
        }

        private async void Test_button_Click(object sender, EventArgs e)
        {
            MemoRichTextBox.Clear();
            using (HttpClient Client = new HttpClient())
            {
                //Add Default Request Headers
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer token");
                try
                {
                    using (HttpResponseMessage Response = await Client.GetAsync(new Uri("http://127.0.0.1:19023/manageAPI/getHelp")))
                    {
                        using (HttpContent content = Response.Content)
                        {
                            //Read the result and display in Textbox
                            string Result = await content.ReadAsStringAsync();//Result string JSON
                            string ReasonPhrase = Response.ReasonPhrase;//Reason OK, FAIL etc.
                            MemoRichTextBox.AppendText(Result + Environment.NewLine);
                            MemoRichTextBox.AppendText(ReasonPhrase + Environment.NewLine);
                        }
                    }
                }
                catch (Exception Exception)
                {
                    MessageBox.Show(Exception.Message, "Could not test API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                    return;
                }
            }
        }

        private async void Custom_button_Click(object sender, EventArgs e)
        {
            MemoRichTextBox.Clear();
            using (HttpClient Client = new HttpClient())
            {
                //Add Default Request Headers
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenTextBox.Text);
                try
                {
                    using (HttpResponseMessage Response = await Client.GetAsync(new Uri(CustomTestTextBox.Text)))
                    {
                        using (HttpContent Content = Response.Content)
                        {
                            //Read the result and display in Textbox
                            string Result = await Content.ReadAsStringAsync();//Result string JSON
                            string ReasonPhrase = Response.ReasonPhrase;//Reason OK, FAIL etc.
                            MemoRichTextBox.AppendText(Result + Environment.NewLine);
                            MemoRichTextBox.AppendText(ReasonPhrase + Environment.NewLine);
                        }
                    }
                }
                catch (Exception Exception)
                {
                    MessageBox.Show(Exception.Message, "Could not custom test API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                    return;
                }
            }
        }

        private void FreeTAKServer_API_Form_Load(object sender, EventArgs e)
        {
            //Set Textbox text
            CustomTestTextBox.Text = "http://127.0.0.1:19023/manageAPI/getHelp";
            TokenTextBox.Text = "token";
        }
    }
}
