using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Navigation;
using System.ComponentModel;
using System;
using System.Net.Http;

namespace FreeTAKServer_Manager_WPF
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        private readonly BackgroundWorker worker = new BackgroundWorker();

        public AboutWindow()
        {
            InitializeComponent();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            labelversion.Content = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            //Opens link to the specified in the xaml code
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void Checkforupdate_button_Click(object sender, RoutedEventArgs e)
        {
            //Checks for a new version of the app via GUP
            try
            {
                if (!worker.IsBusy)
                {
                    worker.RunWorkerAsync();
                }
                LoggerClass.WriteLine(" *** Ran UpdateExe:" + Environment.NewLine + " [About_Form] ***");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not check for update", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [About_Form] ***");
                return;
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // run all background tasks here
            try
            {
                //Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => { RunUpdateExeClass.RunExeActions(); }));
                RunUpdateExeClass.RunExeActions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Run Update Exe Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private async void worker_RunWorkerCompleted(object sender,RunWorkerCompletedEventArgs e)
        {
            //update ui once worker complete his work
            string version = "1.006";
            using (HttpClient client = new HttpClient())
            {
                //Add Default Request Headers
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(new Uri($"https://techrad.co.za/ATAK/FreeTAKServer_Manager/WPF/getDownLoadUrl.php?version={version}")))
                    {
                        using (HttpContent content = response.Content)
                        {
                            //Read the result and display in Textbox
                            string result = await content.ReadAsStringAsync();//Result string JSON
                            string reasonPhrase = response.ReasonPhrase;//Reason OK, FAIL etc.
                            LoggerClass.WriteLine(" *** result:" + result + " [About_Form] ***");
                            LoggerClass.WriteLine(" *** reasonPhrase:" + reasonPhrase + " [About_Form] ***");
                            MessageBox.Show(result, "Updater", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
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
