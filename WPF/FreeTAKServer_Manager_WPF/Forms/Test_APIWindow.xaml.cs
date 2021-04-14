﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static FreeTAKServer_Manager_WPF.LoggerClass;

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
            Customtest_textBox.Text = "http://127.0.0.1:19023/manageAPI/getHelp";
            Token_textBox.Text = "token";
        }

        private async void Customtest_button_Click(object sender, RoutedEventArgs e)
        {
            Richtextbox.Document.Blocks.Clear();
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
                            Richtextbox.AppendText(result + Environment.NewLine);
                            Richtextbox.AppendText(reasonPhrase + Environment.NewLine);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not test API", MessageBoxButton.OK, MessageBoxImage.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    return;
                }
            }
        }

        private async void LocalTest_button_Click(object sender, RoutedEventArgs e)
        {
            Richtextbox.Document.Blocks.Clear();
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
                            Richtextbox.AppendText(result + Environment.NewLine);
                            Richtextbox.AppendText(reasonPhrase + Environment.NewLine);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not custom test API", MessageBoxButton.OK, MessageBoxImage.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    return;
                }
            }
        }
    }
}