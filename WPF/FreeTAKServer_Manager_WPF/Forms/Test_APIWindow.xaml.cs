using System;
using System.Net.Http;
using System.Windows;

namespace FreeTAKServer_Manager_WPF
{
    /// <summary>
    /// Interaction logic for Test_APIWindow.xaml
    /// </summary>
    public partial class Test_APIWindow : Window
    {
        public Test_APIWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Set Textbox text
            Customtest_textBox.Text = "http://127.0.0.1:19023/manageAPI/getHelp";
            Token_textBox.Text = "token";
        }

        private async void Customtest_button_Click(object sender, RoutedEventArgs e)
        {
            Richtextbox.Document.Blocks.Clear();
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
                            Richtextbox.AppendText(result + "\r");
                            Richtextbox.AppendText(reasonPhrase + "\r");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not custom test API", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    return;
                }
            }
        }

        private async void LocalTest_button_Click(object sender, RoutedEventArgs e)
        {
            Richtextbox.Document.Blocks.Clear();
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
                            Richtextbox.AppendText(result + "\r");
                            Richtextbox.AppendText(reasonPhrase + "\r");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not test API", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    return;
                }
            }
        }
    }
}
