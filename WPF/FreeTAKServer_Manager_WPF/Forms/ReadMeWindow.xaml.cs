using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            Logger.WriteLine(" *** Notes Form Show Success [NotesForm] *** ");
            try
            {
                Richtextbox.Document.Blocks.Clear();
                Richtextbox.AppendText(File.ReadAllText("ReadMe.txt"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Read Me Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
