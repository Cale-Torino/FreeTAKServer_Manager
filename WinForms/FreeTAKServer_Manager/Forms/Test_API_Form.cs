using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FreeTAKServer_Manager.LoggerClass;

namespace FreeTAKServer_Manager
{
    public partial class Test_API_Form : Form
    {
        public Test_API_Form()
        {
            InitializeComponent();
        }

        private void Test_API_Form_Load(object sender, EventArgs e)
        {
            Customtest_textBox.Text = "http://127.0.0.1:19023/manageAPI/getHelp";
            Token_textBox.Text = "token";
        }

        private async void Test_button_Click(object sender, EventArgs e)
        {
            Memo_richTextBox.Clear();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer token");
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(new Uri("http://127.0.0.1:19023/manageAPI/getHelp")))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string result = await content.ReadAsStringAsync();
                            string reasonPhrase = response.ReasonPhrase;
                            Memo_richTextBox.AppendText(result + Environment.NewLine);
                            Memo_richTextBox.AppendText(reasonPhrase + Environment.NewLine);
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

        private async void Custom_button_Click(object sender, EventArgs e)
        {
            Memo_richTextBox.Clear();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token_textBox.Text);
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(new Uri(Customtest_textBox.Text)))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string result = await content.ReadAsStringAsync();
                            string reasonPhrase = response.ReasonPhrase;
                            Memo_richTextBox.AppendText(result + Environment.NewLine);
                            Memo_richTextBox.AppendText(reasonPhrase + Environment.NewLine);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not custom test API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    return;
                }
            }
        }
    }
}
