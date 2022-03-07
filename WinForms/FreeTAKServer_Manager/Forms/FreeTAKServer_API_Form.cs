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
            Memo_richTextBox.Clear();
            using (HttpClient client = new HttpClient())
            {
                //Add Default Request Headers
                client.DefaultRequestHeaders.Add("Authorization", "Bearer token");
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(new Uri("http://127.0.0.1:19023/manageAPI/getHelp")))
                    {
                        using (HttpContent content = response.Content)
                        {
                            //Read the result and display in Textbox
                            string result = await content.ReadAsStringAsync();//Result string JSON
                            string reasonPhrase = response.ReasonPhrase;//Reason OK, FAIL etc.
                            Memo_richTextBox.AppendText(result + Environment.NewLine);
                            Memo_richTextBox.AppendText(reasonPhrase + Environment.NewLine);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not test API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    return;
                }
            }
        }

        private async void Custom_button_Click(object sender, EventArgs e)
        {
            Memo_richTextBox.Clear();
            using (HttpClient client = new HttpClient())
            {
                //Add Default Request Headers
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token_textBox.Text);
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(new Uri(Customtest_textBox.Text)))
                    {
                        using (HttpContent content = response.Content)
                        {
                            //Read the result and display in Textbox
                            string result = await content.ReadAsStringAsync();//Result string JSON
                            string reasonPhrase = response.ReasonPhrase;//Reason OK, FAIL etc.
                            Memo_richTextBox.AppendText(result + Environment.NewLine);
                            Memo_richTextBox.AppendText(reasonPhrase + Environment.NewLine);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not custom test API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    return;
                }
            }
        }

        private void FreeTAKServer_API_Form_Load(object sender, EventArgs e)
        {
            //Set Textbox text
            Customtest_textBox.Text = "http://127.0.0.1:19023/manageAPI/getHelp";
            Token_textBox.Text = "token";
        }
    }
}
