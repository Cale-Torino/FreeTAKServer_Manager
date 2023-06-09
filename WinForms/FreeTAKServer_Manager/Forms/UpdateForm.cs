using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace FreeTAKServer_Manager
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            CheckApp();
        }

        private void CheckApp()
        {
            try
            {
                UpdateCheckerClass CheckClient = new UpdateCheckerClass("https://raw.githubusercontent.com/Cale-Torino/FreeTAKServer_Manager/main/WinForms/FreeTAKServer_Manager/Classes/UpdateChecker/CurrentVersion.xml");
                int Major = CheckClient.GetVersion(VersionNumber.Major);
                int Minor = CheckClient.GetVersion(VersionNumber.Minor);
                int Build = CheckClient.GetVersion(VersionNumber.Build);

                string StringPath = CheckClient.GetNewVersionPath();

                // Get my own version's numbers
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

                int AppMajor = fileVersionInfo.FileMajorPart;
                int AppMinor = fileVersionInfo.FileMinorPart;
                int AppBuild = fileVersionInfo.FileBuildPart;

                if (Major > AppMajor || Minor > AppMinor || Build > AppBuild)
                {
                    //|| nMinor > nAppMinor
                    DialogResult Result = MessageBox.Show($"Found update:\nversion: {Major}.{Minor}.{Build}\nWould you like to download the update?", "Update Checker", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (Result == DialogResult.Yes)
                    {
                        //code for Yes
                        UpdateApp(StringPath);
                    }
                    else if (Result == DialogResult.No)
                    {
                        //code for No
                        Close();
                    }
                }
                else 
                {
                    //|| nMinor > nAppMinor
                    DialogResult result = MessageBox.Show($"You already have the latest version.\nversion: {Major}.{Minor}.{Build}\n", "Update Checker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.OK)
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

        private void UpdateApp(string StringPath)
        {
            try
            {
                Thread Thread = new Thread(() => {
                    WebClient WC = new WebClient();
                    WC.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                    WC.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback);
                    WC.DownloadFileAsync(new Uri(StringPath), @"Updates\FreeTAKServer_Manager_Installer.msi");
                });
                Thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate {
                double BytesIn = double.Parse(e.BytesReceived.ToString());
                double TotalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double Percentage = BytesIn / TotalBytes * 100;
                Label.Text = $"Downloaded {Math.Round(e.BytesReceived / 1024.0 / 1024.0, 2)} MB of {Math.Round(e.TotalBytesToReceive / 1024.0 / 1024.0, 2)} MB";
                progressBar.Value = int.Parse(Math.Truncate(Percentage).ToString());
            });
        }

        private void DownloadFileCallback(object sender, AsyncCompletedEventArgs e)
        {
            //close app at this point and run installer app or extracter bat file
            //extract files to dir oly no folder
            //might be easier to run zps.msi updater rather than extracting files from zip
            //|| nMinor > nAppMinor
            DialogResult result = MessageBox.Show($"Update Successfully downloaded\nWould you like to close the app and install the update?", "Update Runner", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                //code for Yes
                //Run bat file in temp folder [deletes old app and installs newly downloaded app]
                //ZipFile.ExtractToDirectory($@"{AppDomain.CurrentDomain.BaseDirectory}Updates\FreeTAKServer_Manager_Installer.zip", $@"{AppDomain.CurrentDomain.BaseDirectory}");
                //ProcessClass.RunProcess("FreeTAKServer_Manager.exe");
                ProcessClass.RunProcess($@"{AppDomain.CurrentDomain.BaseDirectory}Updates\FreeTAKServer_Manager_Installer.msi");
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                //code for No
                BeginInvoke((MethodInvoker)delegate {
                    Label.Text = "Download Completed";
                });
                //Close();
            }
        }
    }
}
