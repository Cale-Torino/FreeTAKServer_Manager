using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FreeTAKServer_Manager_WPF
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            //CheckApp();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CheckApp();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //CheckApp();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CheckApp()
        {
            try
            {
                UpdateCheckerClass oCheckClient = new UpdateCheckerClass("https://raw.githubusercontent.com/Cale-Torino/FreeTAKServer_Manager/main/WPF/FreeTAKServer_Manager_WPF/Classes/UpdateChecker/CurrentVersion.xml");
                int nMajor = oCheckClient.GetVersion(enVerion.EMajor);
                int nMinor = oCheckClient.GetVersion(enVerion.EMinor);
                int nBuild = oCheckClient.GetVersion(enVerion.EBuild);

                string strPath = oCheckClient.GetNewVersionPath();

                // Get my own version's numbers
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

                int nAppMajor = fileVersionInfo.FileMajorPart;
                int nAppMinor = fileVersionInfo.FileMinorPart;
                int nAppBuild = fileVersionInfo.FileBuildPart;

                if (nMajor > nAppMajor || nMinor > nAppMinor || nBuild > nAppBuild)
                {
                    //|| nMinor > nAppMinor
                    MessageBoxResult result = MessageBox.Show($"Found update:\nversion: {nMajor}.{nMinor}.{nBuild}\nWould you like to download the update?", "Update Checker", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
                    if (result == MessageBoxResult.Yes)
                    {
                        //code for Yes
                        UpdateApp(strPath);
                    }
                    else if (result == MessageBoxResult.No)
                    {
                        //code for No
                        Close();
                    }
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show($"You already have the latest version.\nversion: {nMajor}.{nMinor}.{nBuild}\n", "Update Checker", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
                    if (result == MessageBoxResult.OK)
                    {
                        //code for ok
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void UpdateApp(string strPath)
        {
            try
            {
                Thread thread = new Thread(() => {
                    WebClient wc = new WebClient();
                    wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback);
                    wc.DownloadFileAsync(new Uri(strPath), @"Updates\FreeTAKServer_Manager_Installer.msi");
                });
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Dispatcher.Invoke(new Action(delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                label.Content = $"Downloaded {Math.Round(e.BytesReceived / 1024.0 / 1024.0, 2)} MB of {Math.Round(e.TotalBytesToReceive / 1024.0 / 1024.0, 2)} MB";
                progressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
            }));
        }

        private void DownloadFileCallback(object sender, AsyncCompletedEventArgs e)
        {
            //close app at this point and run installer app or extracter bat file
            //extract files to dir oly no folder
            //might be easier to run zps.msi updater rather than extracting files from zip
            //|| nMinor > nAppMinor
            MessageBoxResult result = MessageBox.Show($"Update Successfully downloaded\nWould you like to close the app and install the update?", "Update Runner", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
            if (result == MessageBoxResult.Yes)
            {
                //code for Yes
                //Run bat file in temp folder [deletes old app and installs newly downloaded app]
                //ZipFile.ExtractToDirectory($@"{AppDomain.CurrentDomain.BaseDirectory}Updates\FreeTAKServer_Manager_Installer.zip", $@"{AppDomain.CurrentDomain.BaseDirectory}");
                //ProcessClass.RunProcess("FreeTAKServer_Manager.exe");
                ProcessClass.RunProcess($@"{AppDomain.CurrentDomain.BaseDirectory}Updates\FreeTAKServer_Manager_Installer.msi");
                Application.Current.Shutdown();
                //Environment.Exit(0);
            }
            else if (result == MessageBoxResult.No)
            {
                Dispatcher.Invoke(new Action(delegate
                {
                    label.Content = "Download Completed";
                }));
                //Close();
            }
        }
    }
}
