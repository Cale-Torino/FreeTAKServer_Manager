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
            CustomTest_TextBox.Text = "http://127.0.0.1:19023/manageAPI/getHelp";
            Token_TextBox.Text = "token";
        }

        private async void Customtest_button_Click(object sender, RoutedEventArgs e)
        {
            Richtextbox.Document.Blocks.Clear();
            using (HttpClient Client = new HttpClient())
            {
                //Add Default Request Headers
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token_TextBox.Text);
                try
                {
                    using (HttpResponseMessage Response = await Client.GetAsync(new Uri(CustomTest_TextBox.Text)))
                    {
                        using (HttpContent Content = Response.Content)
                        {
                            //Read the result and display in Textbox
                            string Result = await Content.ReadAsStringAsync();//Result string JSON
                            string ReasonPhrase = Response.ReasonPhrase;//Reason OK, FAIL etc.
                            Richtextbox.AppendText($"{Result}\r");
                            Richtextbox.AppendText($"{ReasonPhrase}\r");
                        }
                    }
                }
                catch (Exception Exception)
                {
                    MessageBox.Show(Exception.Message, "Could not custom test API", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                    return;
                }
            }
        }

        private async void LocalTest_button_Click(object sender, RoutedEventArgs e)
        {
            Richtextbox.Document.Blocks.Clear();
            using (HttpClient Client = new HttpClient())
            {
                //Add Default Request Headers
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer token");
                try
                {
                    using (HttpResponseMessage Response = await Client.GetAsync(new Uri("http://127.0.0.1:19023/manageAPI/getHelp")))
                    {
                        using (HttpContent Content = Response.Content)
                        {
                            //Read the result and display in Textbox
                            string Result = await Content.ReadAsStringAsync();//Result string JSON
                            string ReasonPhrase = Response.ReasonPhrase;//Reason OK, FAIL etc.
                            Richtextbox.AppendText($"{Result}\r");
                            Richtextbox.AppendText($"{ReasonPhrase}\r");
                        }
                    }
                }
                catch (Exception Exception)
                {
                    MessageBox.Show(Exception.Message, "Could not test API", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                    return;
                }
            }
        }
    }
}
