using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Navigation;
using System;

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
            labelversion.Content = $"Version {Assembly.GetExecutingAssembly().GetName().Version}";
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
                UpdateWindow W = new UpdateWindow
                {
                    Topmost = true
                };
                W.ShowDialog();
                W.Activate();
                LoggerClass.WriteLine(" *** Ran Update:\n[About_Form] ***");
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Could not check for update", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [About_Form] ***");
                return;
            }
        }


    }
}
