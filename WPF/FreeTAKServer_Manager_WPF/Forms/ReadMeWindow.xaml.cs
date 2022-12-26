using System;
using System.IO;
using System.Windows;

namespace FreeTAKServer_Manager_WPF
{
    /// <summary>
    /// Interaction logic for ReadMeWindow.xaml
    /// </summary>
    public partial class ReadMeWindow : Window
    {
        public ReadMeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoggerClass.WriteLine(" *** Notes Form Show Success [NotesForm] *** ");
            try
            {
                //Clear Richtextbox and add the content of ReadMe.txt
                Richtextbox.Document.Blocks.Clear();
                Richtextbox.AppendText(File.ReadAllText("TextFiles\\ReadMe.txt"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Read Me Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Richtextbox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
