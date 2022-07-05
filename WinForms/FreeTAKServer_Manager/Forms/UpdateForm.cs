using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
                UpdateCheckerClass oCheckClient = new UpdateCheckerClass("https://raw.githubusercontent.com/Cale-Torino/FreeTAKServer_Manager/main/WinForms/FreeTAKServer_Manager/Classes/UpdateChecker/CurrentVersion.xml");
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

                if (nMajor >= nAppMajor)
                {
                    //|| nMinor > nAppMinor
                    DialogResult result = MessageBox.Show($"Found update:\nversion: {nMajor}.{nMinor}.{nBuild}\nWould you like to download the update?", "Update Checker", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        //code for Yes
                        UpdateApp(strPath);
                    }
                    else if (result == DialogResult.No)
                    {
                        //code for No
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
                    wc.DownloadFileAsync(new Uri(strPath), @"Updates\ZPS_Server_Manager.zip");
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
            BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                label.Text = $"Downloaded {Math.Round(e.BytesReceived / 1024.0 / 1024.0, 2)} MB of {Math.Round(e.TotalBytesToReceive / 1024.0 / 1024.0, 2)} MB";
                progressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
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
                ZipFile.ExtractToDirectory($@"{AppDomain.CurrentDomain.BaseDirectory}Updates\ZPS_Server_Manager.zip", $@"{AppDomain.CurrentDomain.BaseDirectory}");
                ProcessClass.RunProcess("ZPS_Server_Manager.exe");
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                //code for No
                BeginInvoke((MethodInvoker)delegate {
                    label.Text = "Download Completed";
                });
                //Close();
            }
        }
    }
}
