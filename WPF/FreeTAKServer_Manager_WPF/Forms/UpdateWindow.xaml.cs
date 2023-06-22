using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows;

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
                UpdateCheckerClass CheckClient = new UpdateCheckerClass("https://raw.githubusercontent.com/Cale-Torino/FreeTAKServer_Manager/main/WPF/FreeTAKServer_Manager_WPF/Classes/UpdateChecker/CurrentVersion.xml");
                int Major = CheckClient.GetVersion(VersionNumber.Major);
                int Minor = CheckClient.GetVersion(VersionNumber.Minor);
                int Build = CheckClient.GetVersion(VersionNumber.Build);

                string StrPath = CheckClient.GetNewVersionPath();

                // Get my own version's numbers
                Assembly Assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo FVI = FileVersionInfo.GetVersionInfo(Assembly.Location);

                int AppMajor = FVI.FileMajorPart;
                int AppMinor = FVI.FileMinorPart;
                int AppBuild = FVI.FileBuildPart;

                if (Major > AppMajor || Minor > AppMinor || Build > AppBuild)
                {
                    //|| nMinor > nAppMinor
                    MessageBoxResult Result = MessageBox.Show($"Found update:\nversion: {Major}.{Minor}.{Build}\nWould you like to download the update?", "Update Checker", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
                    if (Result == MessageBoxResult.Yes)
                    {
                        //code for Yes
                        UpdateApp(StrPath);
                    }
                    else if (Result == MessageBoxResult.No)
                    {
                        //code for No
                        Close();
                    }
                }
                else
                {
                    MessageBoxResult Result = MessageBox.Show($"You already have the latest version.\nversion: {Major}.{Minor}.{Build}\n", "Update Checker", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
                    if (Result == MessageBoxResult.OK)
                    {
                        //code for ok
                        Close();
                    }
                }
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message);
                return;
            }

        }

        private void UpdateApp(string StrPath)
        {
            try
            {
                Thread Thread = new Thread(() => {
                    WebClient WC = new WebClient();
                    WC.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                    WC.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback);
                    WC.DownloadFileAsync(new Uri(StrPath), @"Updates\FreeTAKServer_Manager_Installer.msi");
                });
                Thread.Start();
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message);
                return;
            }

        }

        void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Dispatcher.Invoke(new Action(delegate
            {
                double BytesIn = double.Parse(e.BytesReceived.ToString());
                double TotalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double Percentage = BytesIn / TotalBytes * 100;
                label.Content = $"Downloaded {Math.Round(e.BytesReceived / 1024.0 / 1024.0, 2)} MB of {Math.Round(e.TotalBytesToReceive / 1024.0 / 1024.0, 2)} MB";
                progressBar.Value = int.Parse(Math.Truncate(Percentage).ToString());
            }));
        }

        private void DownloadFileCallback(object sender, AsyncCompletedEventArgs e)
        {
            //close app at this point and run installer app or extracter bat file
            //extract files to dir oly no folder
            //might be easier to run zps.msi updater rather than extracting files from zip
            //|| nMinor > nAppMinor
            MessageBoxResult Result = MessageBox.Show($"Update Successfully downloaded\nWould you like to close the app and install the update?", "Update Runner", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.None, MessageBoxOptions.DefaultDesktopOnly);
            if (Result == MessageBoxResult.Yes)
            {
                //code for Yes
                //Run bat file in temp folder [deletes old app and installs newly downloaded app]
                //ZipFile.ExtractToDirectory($@"{AppDomain.CurrentDomain.BaseDirectory}Updates\FreeTAKServer_Manager_Installer.zip", $@"{AppDomain.CurrentDomain.BaseDirectory}");
                //ProcessClass.RunProcess("FreeTAKServer_Manager.exe");
                ProcessClass.RunProcess($@"{AppDomain.CurrentDomain.BaseDirectory}Updates\FreeTAKServer_Manager_Installer.msi");
                Application.Current.Shutdown();
                //Environment.Exit(0);
            }
            else if (Result == MessageBoxResult.No)
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
