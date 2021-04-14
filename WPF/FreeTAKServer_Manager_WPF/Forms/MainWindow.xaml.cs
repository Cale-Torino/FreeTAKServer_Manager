using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using static FreeTAKServer_Manager_WPF.CMD_Class;
using static FreeTAKServer_Manager_WPF.LoggerClass;

namespace FreeTAKServer_Manager_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    //https://stackoverflow.com/questions/14868713/xaml-the-property-content-is-set-more-than-once/14868978
    //https://stackoverflow.com/questions/43585036/add-button-with-border-in-wpf
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Ini();
        }
        private void CreateFolder()
        {
            try
            {
                //CreatFolder
                string path = AppDomain.CurrentDomain.BaseDirectory;
                Directory.CreateDirectory(path + "\\Logs");
                Logger.WriteLine(" *** Application Start [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Application Start" + "\r");
                Logger.WriteLine(" *** CreateDirectory Success [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Logs Create Directory Success" + "\r");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Create Folder Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + "\r");
                return;
            }
        }
        private void Ini()
        {
            try
            {
                Startserver_button.IsEnabled = false;
                Stopserver_button.IsEnabled = false;
                Restartserver_button.IsEnabled = false;
                Uninstallserver_button.IsEnabled = false;
                Editconfigserver_button.IsEnabled = false;
                Editmainconfigserver_button.IsEnabled = false;
                Checkportsserver_button.IsEnabled = false;
                Installserver_button.IsEnabled = false;
                CreateFolder();
                //PythonInstalled();
                //LoadPropertys();
                Logger.WriteLine(" *** Ini Complete [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Ini Complete" + "\r");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ini Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + "\r");
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
                    status_lable.Text = "Python IS installed :)";
                    Logger.WriteLine(" *** Python Installed [MainForm] ***");
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Python Installed" + Environment.NewLine);
                }
                else
                {
                    status_lable.Text = "Python NOT installed :( ";
                    Logger.WriteLine(" *** Python Not Installed. Error [MainForm] ***");
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Python Not Installed. Error! " + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PythonInstalled check error", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
        }
        private void LoadPropertys()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Pythondir))
                {
                    Pythondir_textBox.IsEnabled = false;
                    Pythondir_textBox.Text = Properties.Settings.Default.Pythondir;

                    Startserver_button.IsEnabled = true;
                    Stopserver_button.IsEnabled = true;
                    Restartserver_button.IsEnabled = true;
                    Uninstallserver_button.IsEnabled = true;
                    Editconfigserver_button.IsEnabled = true;
                    Editmainconfigserver_button.IsEnabled = true;
                    Checkportsserver_button.IsEnabled = true;
                    Installserver_button.IsEnabled = true;
                }
                if (Properties.Settings.Default.email_checkstate)
                {
                    Email_checkBox.IsChecked = Properties.Settings.Default.email_checkstate;
                    if (Email_checkBox.IsChecked == true)
                    {
                        TimerStart();
                    }
                }
                if (Properties.Settings.Default.StartupServer_checkstate)
                {
                    Startserver_checkBox.IsChecked = Properties.Settings.Default.StartupServer_checkstate;
                    if (Startserver_checkBox.IsChecked == true)
                    {
                        StartServer();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not get Pythondir Property", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
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
                MessageBox.Show(ex.Message, "Create Folder Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
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
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Start Server PID=" + _ServerPID + ", Start UI PID=" + _UIPID + Environment.NewLine);

            }
            else
            {
                MessageBox.Show("Server is not installed", "", MessageBoxButton.OK, MessageBoxImage.Information);
                Logger.WriteLine(" *** Server is not installed  [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Server is not installed" + Environment.NewLine);
            }
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
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Kill Server PID=" + CMD_PID_Class._ServerPIDVar + ", Kill UI PID=" + CMD_PID_Class._UIPIDVar + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("Server is not running.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Server is not installed", "", MessageBoxButton.OK, MessageBoxImage.Information);
                Logger.WriteLine(" *** Server is not installed  [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Server is not installed" + Environment.NewLine);
            }
        }
        private void about_menuitem_Click(object sender, RoutedEventArgs e)
        {
            //About window open
            AboutWindow w = new AboutWindow();
            //w.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            w.ShowDialog();
        }

        private void email_setup_menuitem_Click(object sender, RoutedEventArgs e)
        {
            //Email setup window open
            EmailSetupWindow w = new EmailSetupWindow();
            Owner = Owner;
            w.ShowDialog();
        }

        private void read_me_menuitem_Click(object sender, RoutedEventArgs e)
        {
            //Readme window open
            ReadMeWindow w = new ReadMeWindow();
            Owner = Owner;
            w.ShowDialog();
        }

        private void Test_API_menuitem_Click(object sender, RoutedEventArgs e)
        {
            //Test API window open
            Test_APIWindow w = new Test_APIWindow();
            Owner = Owner;
            w.ShowDialog();
        }

        private void Startserver_button_Click(object sender, RoutedEventArgs e)
        {
            StartServer();
        }

        private bool clickedOnce = true;
        private void Setdirserver_button_Click(object sender, RoutedEventArgs e)
        {
            if (clickedOnce == true)
            {
                try
                {
                    clickedOnce = false;
                    Pythondir_textBox.Text = GetPythonPath();
                    Pythondir_textBox.IsEnabled = true;
                    Pythondir_textBox.IsReadOnly = false;
                    Setdirserver_button.Content = "Save Dir";
                    Logger.WriteLine(" *** Auto Get Python Path Success [MainForm] ***");
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Auto Get Python Path Success" + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    clickedOnce = false;
                    MessageBox.Show(ex.Message, "Auto Get Python Path Error! Please enter path manually.", MessageBoxButton.OK, MessageBoxImage.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                    Pythondir_textBox.IsEnabled = true;
                    Pythondir_textBox.IsReadOnly = false;
                    Setdirserver_button.Content = "Save Dir";
                    Logger.WriteLine(" *** Auto Get Python Path Error. Attempting Manual Path Entry [MainForm] ***");
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Auto Get Python Path Error. Attempting Manual Path Entry" + Environment.NewLine);
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Pythondir_textBox.Text))
                {
                    MessageBox.Show("Python directory not entered!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation); return;
                }
                clickedOnce = true;
                Properties.Settings.Default.Pythondir = Pythondir_textBox.Text;
                Properties.Settings.Default.Save();
                Setdirserver_button.Content = "Get Dir";
                Pythondir_textBox.IsEnabled = false;
                Pythondir_textBox.IsReadOnly = true;
                Startserver_button.IsEnabled = true;
                Stopserver_button.IsEnabled = true;
                Restartserver_button.IsEnabled = true;
                Uninstallserver_button.IsEnabled = true;
                Editconfigserver_button.IsEnabled = true;
                Editmainconfigserver_button.IsEnabled = true;
                Checkportsserver_button.IsEnabled = true;
                Installserver_button.IsEnabled = true;
                MessageBox.Show("Dir : \' " + Pythondir_textBox.Text + " \' has been saved ", "");
                Logger.WriteLine(" *** Python Path Save Success. Path=" + Pythondir_textBox.Text + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Python Path Save Success" + Environment.NewLine);
            }
        }

        private void Installserver_button_Click(object sender, RoutedEventArgs e)
        {
            string configfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI\\config.py";
            string MainConfigfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer\\controllers\\configuration\\MainConfig.py";
            if (Directory.Exists(Path.GetDirectoryName(configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                MessageBox.Show("Server is already installed", "", MessageBoxButton.OK, MessageBoxImage.Information);
                Logger.WriteLine(" *** Server is already installed  [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Server is already installed" + Environment.NewLine);
            }
            else
            {
                try
                {
                    ForceCursor = true;
                    Cursor = Cursors.Wait;
                    int _Install = CMD_Instance.SendCMDCommandNormal("/c pip install -r requirements.txt&&python -m pip install FreeTAKServer[ui]", AppDomain.CurrentDomain.BaseDirectory);
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + "\\config.py", Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI\\config.py", true);
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + "\\MainConfig.py", Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer\\controllers\\configuration\\MainConfig.py", true);
                    replaceText();
                    Logger.WriteLine(" *** Install Server PID=" + _Install + " [MainForm] ***");
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Install Server PID=" + _Install + Environment.NewLine);
                    ForceCursor = true;
                    Cursor = Cursors.Arrow;
                    MessageBox.Show("Server has been installed", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    ForceCursor = true;
                    Cursor = Cursors.Arrow;
                    MessageBox.Show(ex.Message, "Could not install FreeTAKServer[ui]", MessageBoxButton.OK, MessageBoxImage.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                    return;
                }
            }
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
                MessageBox.Show(ex.Message, "Get Python Path Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return "Get Python Path Error";
            }

        }

        private void Uninstallserver_button_Click(object sender, RoutedEventArgs e)
        {
            StopServer();
            string configfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI\\config.py";
            string MainConfigfile = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer\\controllers\\configuration\\MainConfig.py";
            if (Directory.Exists(Path.GetDirectoryName(configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                string Pythonpath = Properties.Settings.Default.Pythondir;
                try
                {
                    ForceCursor = true;
                    Cursor = Cursors.Wait;
                    int _Uninstall = CMD_Instance.SendCMDCommandNormal("/c pip uninstall --yes FreeTAKServer&&pip uninstall --yes FreeTAKServer-UI", "C:\\Windows\\System32");

                    string DataBasefile = Pythonpath + "Lib\\site-packages\\FreeTAKServer\\FTSDataBase.db";
                    if (Directory.Exists(Path.GetDirectoryName(DataBasefile)))
                    {
                        File.Delete(DataBasefile);
                        Directory.Delete(Pythonpath + "Lib\\site-packages\\FreeTAKServer", true);
                        Directory.Delete(Pythonpath + "Lib\\site-packages\\FreeTAKServer-UI", true);

                        Logger.WriteLine(" *** Deleting Dir=" + Pythonpath + "Lib\\site-packages\\FreeTAKServer  [MainForm] ***");
                        Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Deleting Dir=" + Pythonpath + "Lib\\site-packages\\FreeTAKServer" + Environment.NewLine);
                        Logger.WriteLine(" *** Deleting Dir=" + Pythonpath + "Lib\\site-packages\\FreeTAKServer-UI  [MainForm] ***");
                        Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Deleting Dir=" + Pythonpath + "Lib\\site-packages\\FreeTAKServer-UI" + Environment.NewLine);
                    }
                    Logger.WriteLine(" *** Uninstall Server PID=" + _Uninstall + " [MainForm] ***");
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Uninstall Server PID=" + _Uninstall + Environment.NewLine);
                    ForceCursor = true;
                    Cursor = Cursors.Arrow;
                    MessageBox.Show("Server has been uninstalled", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    ForceCursor = true;
                    Cursor = Cursors.Arrow;
                    MessageBox.Show(ex.Message, "Could not uninstall FreeTAKServer & FreeTAKServer-UI", MessageBoxButton.OK, MessageBoxImage.Error);
                    Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Server is already uninstalled", "", MessageBoxButton.OK, MessageBoxImage.Information);
                Logger.WriteLine(" *** Server is already uninstalled  [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Server is already uninstalled" + Environment.NewLine);
            }
        }

        private void Checkportsserver_button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.yougetsignal.com/tools/open-ports/");
            Logger.WriteLine(" *** Check ports https://www.yougetsignal.com/tools/open-ports/ [MainForm] ***");
            Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Check ports https://www.yougetsignal.com/tools/open-ports/" + Environment.NewLine);
        }

        private void Restartserver_button_Click(object sender, RoutedEventArgs e)
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
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Restart Server PID=" + _ServerPID + ", Restart UI PID=" + _UIPID + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("Server is not running. Please start the server.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Server is not installed", "", MessageBoxButton.OK, MessageBoxImage.Information);
                Logger.WriteLine(" *** Server is not installed  [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Server is not installed" + Environment.NewLine);
            }
        }

        private void Stopserver_button_Click(object sender, RoutedEventArgs e)
        {
            StopServer();
        }

        private void Editconfigserver_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var f = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer-UI\\config.py";
                var p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = f
                };

                p.Start();
                //p.WaitForExit();
                Logger.WriteLine(" *** Edit config.py [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Edit config.py" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could edit config.py", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
        }

        private void Editmainconfigserver_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var f = Properties.Settings.Default.Pythondir + "Lib\\site-packages\\FreeTAKServer\\controllers\\configuration\\MainConfig.py";
                var p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = f
                };

                p.Start();
                //p.WaitForExit();
                Logger.WriteLine(" *** Edit MainConfig.py [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Edit MainConfig.py" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could edit MainConfig.py", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CMD_PID_Class._ServerPIDVar != 0)
            {
                CMD_Instance.PIDkill(CMD_PID_Class._ServerPIDVar);
                CMD_Instance.PIDkill(CMD_PID_Class._UIPIDVar);
                Logger.WriteLine(" *** Kill Server PID=" + CMD_PID_Class._ServerPIDVar + ",  Kill UI PID=" + CMD_PID_Class._UIPIDVar + "[MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Kill Server PID=" + CMD_PID_Class._ServerPIDVar + ", Kill UI PID=" + CMD_PID_Class._UIPIDVar + Environment.NewLine);
                Logger.WriteLine(" *** Application Closed [MainForm] ***");
            }
            else
            {
                Logger.WriteLine(" *** Application Closed [MainForm] ***");
                //do nothing
            }
        }

        private void Email_checkBox_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Email_checkBox.IsChecked == true)
                {
                    Properties.Settings.Default.email_checkstate = true;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Emails WILL be sent", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    TimerStart();
                }
                else
                {
                    Properties.Settings.Default.email_checkstate = false;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Emails will NOT be sent", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    TimerStop();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                MessageBox.Show(ex.Message, "Send email alert error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Startserver_Checkbox_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                string AppName = "FreeTAKServer_Manager";
                if (Startserver_checkBox.IsChecked == true)
                {
                    rk.SetValue(AppName, AppDomain.CurrentDomain.BaseDirectory);
                    Properties.Settings.Default.StartupServer_checkstate = true;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Server will START at startup", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    rk.DeleteValue(AppName, false);
                    Properties.Settings.Default.StartupServer_checkstate = false;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Server will NOT START at startup", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                MessageBox.Show(ex.Message, "Send email alert error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
