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
        public AboutWindow()
        {
            InitializeComponent();
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
                UpdateWindow w = new UpdateWindow
                {
                    Topmost = true
                };
                w.ShowDialog();
                w.Activate();
                LoggerClass.WriteLine(" *** Ran Update:" + Environment.NewLine + " [About_Form] ***");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not check for update", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [About_Form] ***");
                return;
            }
        }


    }
}
