using System;
using System.Net.Http;
using System.Windows.Forms;

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
            CustomTestTextBox.Text = "https://api.telegram.org/bot1726488859:AAGy13koBigjBU0h_MSxzglmaAAbPzqH8DI/sendMessage?chat_id=-268086624&text=Hello+World%0ATwo";
            TokenTextBox.Text = "1726488859:AAGy13koBigjBU0h_MSxzglmaAAbPzqH8DI";
            ChatIDTextBox.Text = "268086624";

        }

        private async void Test_button_Click(object sender, EventArgs e)
        {
            MemoRichTextBox.Clear();
            using (HttpClient Client = new HttpClient())
            {
                //Add Default Request Headers
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer token");
                try
                {
                    using (HttpResponseMessage Response = await Client.GetAsync(new Uri("https://api.telegram.org/bot" + TokenTextBox.Text + "/sendMessage?chat_id=-" + ChatIDTextBox.Text + "&parse_mode=HTML&text=%F0%9F%9A%A8+<b>Alert</b>%0A<i>+IQ-Blue</i><u>+getMessage</u>%0AMessage+details+go+here")))
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
                    MessageBox.Show(Exception.Message, "Could not test Telegram API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [TelegramAPIForm] ***");
                    return;
                }
            }
        }

        private async void Custom_Test_button_Click(object sender, EventArgs e)
        {
            MemoRichTextBox.Clear();
            using (HttpClient Client = new HttpClient())
            {
                //Add Default Request Headers
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer token");
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
                    MessageBox.Show(Exception.Message, "Could not test Telegram API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [TelegramAPIForm] ***");
                    return;
                }
            }
        }
    }
}
