using Microsoft.Win32;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Threading;
using static FreeTAKServer_Manager.CMD_Class;
using static FreeTAKServer_Manager.LoggerClass;

namespace FreeTAKServer_Manager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Ini()
        {
            try
            {
                Startserver_button.Enabled = false;
                Stopserver_button.Enabled = false;
                Restartserver_button.Enabled = false;
                Uninstallserver_button.Enabled = false;
                Editconfig_button.Enabled = false;
                Editmainconfig_button.Enabled = false;
                Checkports_button.Enabled = false;
                Installserver_button.Enabled = false;
                CreateFolder();
                PythonInstalled();
                LoadPropertys();

                Logger.WriteLine(" *** Ini Complete [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Ini Complete" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ini Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
        }

    private void PythonInstalled()
        {
            try
            {
                bool isinstalled = IsSoftwareInstalled("Python");
                if (isinstalled == true)
                {
                    toolStripStatusLabel1.Text = "Python IS installed :)";
                    Logger.WriteLine(" *** Python Installed [MainForm] ***");
                    Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Python Installed" + Environment.NewLine);
                }
                else
                {
                    toolStripStatusLabel1.Text = "Python NOT installed :( ";
                    Logger.WriteLine(" *** Python Not Installed. Error [MainForm] ***");
                    Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Python Not Installed. Error! " + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PythonInstalled check error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
        }
        private void LoadPropertys()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Pythondir))
                {
                    Pythondir_textBox.Enabled = false;
                    Pythondir_textBox.Text = Properties.Settings.Default.Pythondir;

                    Startserver_button.Enabled = true;
                    Stopserver_button.Enabled = true;
                    Restartserver_button.Enabled = true;
                    Uninstallserver_button.Enabled = true;
                    Editconfig_button.Enabled = true;
                    Editmainconfig_button.Enabled = true;
                    Checkports_button.Enabled = true;
                    Installserver_button.Enabled = true;
                }
                if (Properties.Settings.Default.email_checkstate)
                {
                    Email_checkBox.Checked = Properties.Settings.Default.email_checkstate;
                    if (Email_checkBox.Checked == true)
                    {
                        TimerStart();
                    }
                }
                if (Properties.Settings.Default.StartupServer_checkstate)
                {
                    Startserver_checkBox.Checked = Properties.Settings.Default.StartupServer_checkstate;
                    if (Startserver_checkBox.Checked == true)
                    {
                        StartServer();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not get Pythondir Property", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
        }
        private void CreateFolder()
        {
            try
            {
                //CreatFolder
                string path = Application.StartupPath;
                Directory.CreateDirectory(path + "\\Logs");
                Logger.WriteLine(" *** Application Start [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Application Start" + Environment.NewLine);
                Logger.WriteLine(" *** CreateDirectory Success [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Logs Create Directory Success" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Create Folder Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
        }

        private void replaceText()
        {
            try
            {
                string configfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI\\config.py";
                string MainConfigfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer\\controllers\\configuration\\MainConfig.py";
                if (Directory.Exists(Path.GetDirectoryName(configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile))) 
                {
                    string _configfile = File.ReadAllText(configfile, Encoding.UTF8);
                    string _MainConfigfile = File.ReadAllText(MainConfigfile, Encoding.UTF8);
                    string PythonPath = Properties.Settings.Default.Pythondir.Replace(@"\", @"\\");

                    _MainConfigfile = _MainConfigfile.Replace("</text>", PythonPath);
                    _MainConfigfile = Regex.Replace(_MainConfigfile, @"\<ref.*?\</ref\>", "");
                    File.WriteAllText(MainConfigfile, _MainConfigfile);

                    _configfile = _configfile.Replace("</text>", PythonPath);
                    _configfile = Regex.Replace(_configfile, @"\<ref.*?\</ref\>", "");
                    File.WriteAllText(configfile, _configfile);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Create Folder Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Ini();
            Focus();
        }

        private void StartServer()
        {
            string configfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI\\config.py";
            string MainConfigfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer\\controllers\\configuration\\MainConfig.py";
            if (Directory.Exists(Path.GetDirectoryName(configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                int _ServerPID = CMD_Instance.CMDStartServer("/k python -m FreeTAKServer.controllers.services.FTS", "C:\\Windows\\System32");
                System.Threading.Thread.Sleep(1000);
                int _UIPID = CMD_Instance.CMDStartServer("/k cd " + Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI&&set FLASK_APP=run.py&&Flask run --host=0.0.0.0", Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI");
                CMD_PID_Class._ServerPIDVar = _ServerPID;
                CMD_PID_Class._UIPIDVar = _UIPID;
                Process.Start("http://127.0.0.1:5000");
                Logger.WriteLine(" *** Start Server PID=" + _ServerPID + ", Start UI PID=" + _UIPID + " [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Start Server PID=" + _ServerPID + ", Start UI PID=" + _UIPID + Environment.NewLine);

            }
            else
            {
                MessageBox.Show("Server is not installed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.WriteLine(" *** Server is not installed  [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Server is not installed" + Environment.NewLine);
            }
        }

        private void Startserver_button_Click(object sender, EventArgs e)
        {
            StartServer();
        }
        private void StopServer()
        {
            string configfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI\\config.py";
            string MainConfigfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer\\controllers\\configuration\\MainConfig.py";
            if (Directory.Exists(Path.GetDirectoryName(configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                if (CMD_PID_Class._ServerPIDVar != 0)
                {
                    CMD_Instance.PIDkill(CMD_PID_Class._ServerPIDVar);
                    CMD_Instance.PIDkill(CMD_PID_Class._UIPIDVar);
                    Logger.WriteLine(" *** Kill Server PID=" + CMD_PID_Class._ServerPIDVar + ",  Kill UI PID=" + CMD_PID_Class._UIPIDVar + "[MainForm] ***");
                    Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Kill Server PID=" + CMD_PID_Class._ServerPIDVar + ", Kill UI PID=" + CMD_PID_Class._UIPIDVar + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("Server is not running.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Server is not installed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.WriteLine(" *** Server is not installed  [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Server is not installed" + Environment.NewLine);
            }
        }
        private void Stopserver_button_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void Restartserver_button_Click(object sender, EventArgs e)
        {
            string configfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI\\config.py";
            string MainConfigfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer\\controllers\\configuration\\MainConfig.py";
            if (Directory.Exists(Path.GetDirectoryName(configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                if (CMD_PID_Class._ServerPIDVar != 0)
                {
                    CMD_Instance.PIDkill(CMD_PID_Class._ServerPIDVar);
                    CMD_Instance.PIDkill(CMD_PID_Class._UIPIDVar);
                    int _ServerPID = CMD_Instance.CMDStartServer("/k python -m FreeTAKServer.controllers.services.FTS", "C:\\Windows\\System32");
                    System.Threading.Thread.Sleep(1000);
                    int _UIPID = CMD_Instance.CMDStartServer("/k cd " + Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI&&set FLASK_APP=run.py&&Flask run --host=0.0.0.0", Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI");
                    CMD_PID_Class._ServerPIDVar = _ServerPID;
                    CMD_PID_Class._UIPIDVar = _UIPID;
                    Logger.WriteLine(" *** Restart Server PID=" + _ServerPID + ", Restart UI PID=" + _UIPID + " [MainForm] ***");
                    Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Restart Server PID=" + _ServerPID + ", Restart UI PID=" + _UIPID + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("Server is not running. Please start the server.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Server is not installed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.WriteLine(" *** Server is not installed  [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Server is not installed" + Environment.NewLine);
            }

        }

        private void Uninstallserver_button_Click(object sender, EventArgs e)
        {
            StopServer();
            string configfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI\\config.py";
            string MainConfigfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer\\controllers\\configuration\\MainConfig.py";
            if (Directory.Exists(Path.GetDirectoryName(configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                string Pythonpath = Properties.Settings.Default.Pythondir;
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int _Uninstall = CMD_Instance.SendCMDCommandNormal("/c pip uninstall --yes FreeTAKServer&&pip uninstall --yes FreeTAKServer-UI", "C:\\Windows\\System32");

                    string DataBasefile = Pythonpath + "Lib\\site-packages\\FreeTAKServer\\FTSDataBase.db";
                    if (Directory.Exists(Path.GetDirectoryName(DataBasefile)))
                    {
                        File.Delete(DataBasefile);
                        Directory.Delete(Pythonpath + "Lib\\site-packages\\FreeTAKServer", true);
                        Directory.Delete(Pythonpath + "Lib\\site-packages\\FreeTAKServer-UI", true);

                        Logger.WriteLine(" *** Deleting Dir=" + Pythonpath + "Lib\\site-packages\\FreeTAKServer  [MainForm] ***");
                        Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Deleting Dir=" + Pythonpath + "Lib\\site-packages\\FreeTAKServer" + Environment.NewLine);
                        Logger.WriteLine(" *** Deleting Dir=" + Pythonpath + "Lib\\site-packages\\FreeTAKServer-UI  [MainForm] ***");
                        Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Deleting Dir=" + Pythonpath + "Lib\\site-packages\\FreeTAKServer-UI" + Environment.NewLine);
                    }
                    Logger.WriteLine(" *** Uninstall Server PID=" + _Uninstall + " [MainForm] ***");
                    Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Uninstall Server PID=" + _Uninstall + Environment.NewLine);
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Server has been uninstalled", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message, "Could not uninstall FreeTAKServer & FreeTAKServer-UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Server is already uninstalled", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.WriteLine(" *** Server is already uninstalled  [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Server is already uninstalled" + Environment.NewLine);
            }

        }

        private void Editmainconfig_button_Click(object sender, EventArgs e)
        {
            try
            {
                var f = Properties.Settings.Default.Pythondir+"Lib\\site-packages\\FreeTAKServer\\controllers\\configuration\\MainConfig.py";
                var p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = f
                };

                p.Start();
                //p.WaitForExit();
                Logger.WriteLine(" *** Edit MainConfig.py [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Edit MainConfig.py" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could edit MainConfig.py", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
        }

        private void Editconfig_button_Click(object sender, EventArgs e)
        {
            try
            {
                var f = Properties.Settings.Default.Pythondir+"Lib\\site-packages\\FreeTAKServer-UI\\config.py";
                var p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = f
                };

                p.Start();
                //p.WaitForExit();
                Logger.WriteLine(" *** Edit config.py [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Edit config.py" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could edit config.py", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
        }

        private void Checkports_button_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.yougetsignal.com/tools/open-ports/");
            Logger.WriteLine(" *** Check ports https://www.yougetsignal.com/tools/open-ports/ [MainForm] ***");
            Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Check ports https://www.yougetsignal.com/tools/open-ports/" + Environment.NewLine);
        }
        private void Installserver_button_Click(object sender, EventArgs e)
        {
            string configfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI\\config.py";
            string MainConfigfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer\\controllers\\configuration\\MainConfig.py";
            if (Directory.Exists(Path.GetDirectoryName(configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                MessageBox.Show("Server is already installed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.WriteLine(" *** Server is already installed  [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Server is already installed" + Environment.NewLine);
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int _Install = CMD_Instance.SendCMDCommandNormal("/c pip install -r requirements.txt&&python -m pip install FreeTAKServer[ui]", Application.StartupPath);
                    File.Copy(Application.StartupPath+ "\\config.py", Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI\\config.py", true);
                    File.Copy(Application.StartupPath+ "\\MainConfig.py", Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer\\controllers\\configuration\\MainConfig.py", true);
                    replaceText();
                    Logger.WriteLine(" *** Install Server PID=" + _Install + " [MainForm] ***");
                    Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Install Server PID=" + _Install + Environment.NewLine);
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Server has been installed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message, "Could not install FreeTAKServer[ui]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                    return;
                }
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new About_Form();
            f.ShowDialog();
        }

        private void emailSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new EmailSetup_Form();
            f.ShowDialog();
        }

        private void readMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new ReadMe_Form();
            f.ShowDialog();
        }
        private void testAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Test_API_Form();
            f.ShowDialog();
        }
        private static bool IsSoftwareInstalled(string softwareName)
        {
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall") ?? Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            if (key == null)
            { 
                return false; 
            } 
            return key.GetSubKeyNames()
                .Select(keyName => key.OpenSubKey(keyName))
                .Select(subkey => subkey.GetValue("DisplayName") as string)
                .Any(displayName => displayName != null && displayName.Contains(softwareName));
        }

        //get python path from environtment variable
        string GetPythonPath()
        {
            try
            {
                IDictionary environmentVariables = Environment.GetEnvironmentVariables();
                string pathVariable = environmentVariables["Path"] as string;
                string pythonPathFromEnv = "";
                if (pathVariable != null)
                {
                    string[] allPaths = pathVariable.Split(';');
                    foreach (var path in allPaths)
                    {
                        pythonPathFromEnv = path + "\\python.exe";
                        if (File.Exists(pythonPathFromEnv))
                        {
                            return pythonPathFromEnv = path;
                        }
                    }
                }
                return pythonPathFromEnv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Python Path Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return "Get Python Path Error";
            }

        }

        private void Setdir_button_Click(object sender, EventArgs e)
        {
            if (Setdir_button.Text == "Get Dir")
            {
                try
                {
                    Pythondir_textBox.Text = GetPythonPath();
                    Pythondir_textBox.Enabled = true;
                    Pythondir_textBox.ReadOnly = false;
                    Setdir_button.Text = "Save Dir";
                    Logger.WriteLine(" *** Auto Get Python Path Success [MainForm] ***");
                    Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Auto Get Python Path Success" + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Auto Get Python Path Error! Please enter path manually.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                    Pythondir_textBox.Enabled = true;
                    Pythondir_textBox.ReadOnly = false;
                    Setdir_button.Text = "Save Dir";
                    Logger.WriteLine(" *** Auto Get Python Path Error. Attempting Manual Path Entry [MainForm] ***");
                    Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Auto Get Python Path Error. Attempting Manual Path Entry" + Environment.NewLine);
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Setdir_button.Text))
                {
                    MessageBox.Show("Python directory not entered!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                }
                Properties.Settings.Default.Pythondir = Pythondir_textBox.Text;
                Properties.Settings.Default.Save();
                Setdir_button.Text = "Get Dir";
                Pythondir_textBox.Enabled = false;
                Pythondir_textBox.ReadOnly = true;

                Startserver_button.Enabled = true;
                Stopserver_button.Enabled = true;
                Restartserver_button.Enabled = true;
                Uninstallserver_button.Enabled = true;
                Editconfig_button.Enabled = true;
                Editmainconfig_button.Enabled = true;
                Checkports_button.Enabled = true;
                Installserver_button.Enabled = true;
                MessageBox.Show("Dir : \' " + Pythondir_textBox.Text + " \' has been saved ", "");
                Logger.WriteLine(" *** Python Path Save Success. Path=" + Pythondir_textBox.Text + " [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Python Path Save Success" + Environment.NewLine);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CMD_PID_Class._ServerPIDVar != 0)
            {
                CMD_Instance.PIDkill(CMD_PID_Class._ServerPIDVar);
                CMD_Instance.PIDkill(CMD_PID_Class._UIPIDVar);
                Logger.WriteLine(" *** Kill Server PID=" + CMD_PID_Class._ServerPIDVar + ",  Kill UI PID=" + CMD_PID_Class._UIPIDVar + "[MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Kill Server PID=" + CMD_PID_Class._ServerPIDVar + ", Kill UI PID=" + CMD_PID_Class._UIPIDVar + Environment.NewLine);
                Logger.WriteLine(" *** Application Closed [MainForm] ***");
            }
            else
            {
                Logger.WriteLine(" *** Application Closed [MainForm] ***");
                //do nothing
            }
        }
        public static bool PingHost(string hostUri, int portNumber)
        {
            try
            {
                using (var client = new TcpClient(hostUri, portNumber))
                    return true;
            }
            catch (SocketException ex)
            {
                //MessageBox.Show("Error pinging host:'" + hostUri + ":" + portNumber.ToString() + "'");
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                //Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return false;
            }
        }

        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private void TimerStart()
        {
            try
            {
                if (dispatcherTimer.IsEnabled)
                {
                    Logger.WriteLine(" *** DispatcherTimer Already Running, No Need To Start [MainForm] ***");
                }
                else
                {
                    Logger.WriteLine(" *** Started dispatcherTimer [MainForm] ***");
                    dispatcherTimer = new DispatcherTimer();
                    dispatcherTimer.Tick += dispatcherTimer_Tick;
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 30);//60 seconds
                    dispatcherTimer.Start();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                //MessageBox.Show(ex.ToString(), "TimerStart Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TimerStop()
        {
            try
            {
                if (dispatcherTimer.IsEnabled)
                {
                    Logger.WriteLine(" *** Stopped dispatcherTimer [MainForm] *** ");
                    dispatcherTimer.Stop();
                }
                else
                {
                    Logger.WriteLine(" *** DispatcherTimer Already Stopped, No Need To Stop [MainForm] *** ");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                //MessageBox.Show(ex.ToString(), "TimerStop Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (PingHost("127.0.0.1", 5000) == false || PingHost("127.0.0.1", 8080) == false || PingHost("127.0.0.1", 8443) == false)
            {
                try
                {

                    //Decrypt
                    SecureString password = EncryptionClass.DecryptString(Properties.Settings.Default.emailPass);
                    string _pass = EncryptionClass.ToInsecureString(password);

                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(Properties.Settings.Default.emailSmtp);//smtp.techrad.co.za

                    mail.From = new MailAddress(Properties.Settings.Default.emailFrom);
                    mail.To.Add(Properties.Settings.Default.emailTo);
                    mail.Subject = Properties.Settings.Default.emailSubject;
                    mail.Body = Properties.Settings.Default.emailBody;

                    SmtpServer.Port = 587;//port
                    SmtpServer.Credentials = new NetworkCredential(Properties.Settings.Default.emailUsername, _pass);//details
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    Logger.WriteLine(" *** ALERT!! Mail sent! [MainForm] ***");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Email could not be tested", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [EmailSetup_Form] ***");
                }
            }
        }

        private void Email_checkBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (Email_checkBox.Checked)
                {
                    Properties.Settings.Default.email_checkstate = true;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Emails WILL be sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TimerStart();
                }
                else
                {
                    Properties.Settings.Default.email_checkstate = false;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Emails will NOT be sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TimerStop(); 
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                MessageBox.Show(ex.Message, "Send email alert error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Startserver_checkBox_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                string AppName = "FreeTAKServer_Manager";
                if (Startserver_checkBox.Checked)
                {
                    rk.SetValue(AppName, Application.ExecutablePath);
                    Properties.Settings.Default.StartupServer_checkstate = true;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Server will START at startup", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    rk.DeleteValue(AppName, false);
                    Properties.Settings.Default.StartupServer_checkstate = false;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Server will NOT START at startup", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Logs_richTextBox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                MessageBox.Show(ex.Message, "Send email alert error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
