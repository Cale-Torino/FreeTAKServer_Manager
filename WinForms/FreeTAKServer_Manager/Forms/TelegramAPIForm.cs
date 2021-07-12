using System;
using System.Net.Http;
using System.Windows.Forms;
using static FreeTAKServer_Manager.LoggerClass;

namespace FreeTAKServer_Manager
{
    public partial class TelegramAPIForm : Form
    {
        public TelegramAPIForm()
        {
            InitializeComponent();
        }

        private void TelegramAPIForm_Load(object sender, EventArgs e)
        {
            // 1726488859:AAGy13koBigjBU0h_MSxzglmaAAbPzqH8DI
            //https://api.telegram.org/bot1726488859:AAGy13koBigjBU0h_MSxzglmaAAbPzqH8DI/sendMessage?chat_id=-4321432&parse_mode=HTML&text=%F0%9F%9A%A8+<b>Alert</b>%0A<i>+IQ-Blue</i><u>+getMessage</u>%0AMessage+details+go+here
            //Set Textbox text
            Customtest_textBox.Text = "https://api.telegram.org/bot1726488859:AAGy13koBigjBU0h_MSxzglmaAAbPzqH8DI/sendMessage?chat_id=-268086624&text=Hello+World%0ATwo";
            Token_textBox.Text = "1726488859:AAGy13koBigjBU0h_MSxzglmaAAbPzqH8DI";
            Chat_id_textBox.Text = "268086624";

        }

        private async void Test_button_Click(object sender, EventArgs e)
        {
            Memo_richTextBox.Clear();
            using (HttpClient client = new HttpClient())
            {
                //Add Default Request Headers
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer token");
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(new Uri("https://api.telegram.org/bot" + Token_textBox.Text + "/sendMessage?chat_id=-" + Chat_id_textBox.Text + "&parse_mode=HTML&text=%F0%9F%9A%A8+<b>Alert</b>%0A<i>+IQ-Blue</i><u>+getMessage</u>%0AMessage+details+go+here")))
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
                    MessageBox.Show(ex.Message, "Could not test Telegram API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [TelegramAPIForm] ***");
                    return;
                }
            }
        }

        private async void Custom_Test_button_Click(object sender, EventArgs e)
        {
            Memo_richTextBox.Clear();
            using (HttpClient client = new HttpClient())
            {
                //Add Default Request Headers
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer token");
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
                    MessageBox.Show(ex.Message, "Could not test Telegram API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [TelegramAPIForm] ***");
                    return;
                }
            }
        }
    }
}
