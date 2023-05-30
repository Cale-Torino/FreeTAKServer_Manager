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
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace FreeTAKServer_Manager_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Window load
            Ini();
        }
        private void CreateFolder()
        {
            try
            {
                //Create the Logs folder for the application
                string path = AppDomain.CurrentDomain.BaseDirectory;
                Directory.CreateDirectory(path + @"\Logs");
                LoggerClass.WriteLine(" *** Application Start [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Application Start" + "\r");
                LoggerClass.WriteLine(" *** CreateDirectory Success [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Logs Create Directory Success" + "\r");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Create Folder Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + "\r");
                return;
            }
        }
        private void Ini()
        {
            try
            {
                //Initiate the application: call methods
                Startserver_button.IsEnabled = false;
                Stopserver_button.IsEnabled = false;
                Restartserver_button.IsEnabled = false;
                Uninstallserver_button.IsEnabled = false;
                Editconfigserver_button.IsEnabled = false;
                Editmainconfigserver_button.IsEnabled = false;
                Checkportsserver_button.IsEnabled = false;
                Installserver_button.IsEnabled = false;
                CreateFolder();
                PythonInstalled();
                LoadPropertys();
                LoggerClass.WriteLine(" *** Ini Complete [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Ini Complete" + "\r");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ini Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + "\r");
                return;
            }
        }

        private void PythonInstalled()
        {
            try
            {
                //Check if Python is installed
                //bool isinstalled = IsSoftwareInstalled("Python");//Call the method
                string pythonversion = PythonVersion();
                LoggerClass.WriteLine($" *** Python check result: {pythonversion} [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + $"] : Python check result: {pythonversion}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PythonInstalled check error", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
        }
        private void LoadPropertys()
        {
            try
            {
                //Load all the path setting and set button propertys
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
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
        }

        private void replaceText()
        {
            try
            {
                //Replace the text `</text>` with the formatted Python path for windows in both config files
                string YamlConfigfile = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer\FTSConfig.yaml";
                string configfile = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer-UI\config.py";
                string MainConfigfile = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
                if (Directory.Exists(Path.GetDirectoryName(configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)) && Directory.Exists(Path.GetDirectoryName(YamlConfigfile)))
                {
                    string _configfile = File.ReadAllText(configfile, Encoding.UTF8);//Read config.py file text
                    string _MainConfigfile = File.ReadAllText(MainConfigfile, Encoding.UTF8);//Read MainConfig.py file text
                    string _YamlConfigfile = File.ReadAllText(YamlConfigfile, Encoding.UTF8);//Read FTSConfig.yaml file text
                    string PythonPath = Properties.Settings.Default.Pythondir.Replace(@"\", @"\\");//Replace directory `\` with `\\`

                    _MainConfigfile = _MainConfigfile.Replace("</text>", PythonPath);// Replace `</text>` with the directory
                    _MainConfigfile = Regex.Replace(_MainConfigfile, @"\<ref.*?\</ref\>", "");
                    File.WriteAllText(MainConfigfile, _MainConfigfile);//Write all to file

                    _configfile = _configfile.Replace("</text>", PythonPath);// Replace `</text>` with the directory
                    _configfile = Regex.Replace(_configfile, @"\<ref.*?\</ref\>", "");
                    File.WriteAllText(configfile, _configfile);//Write all to file

                    _YamlConfigfile = _YamlConfigfile.Replace("</text>", PythonPath);// Replace `</text>` with the directory
                    _YamlConfigfile = Regex.Replace(_YamlConfigfile, @"\<ref.*?\</ref\>", "");
                    File.WriteAllText(YamlConfigfile, _YamlConfigfile);//Write all to file
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Create Folder Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
        }

        private void DirChecks()
        {
            //create logs folder, no need to check if it exists
            Directory.CreateDirectory(Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer\controllers\logs");
            string nullkb_init = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer-UI\__init__.py";
            //del 0kb file if it exists
            FileInfo file = new FileInfo(nullkb_init);
            if (Directory.Exists(Path.GetDirectoryName(nullkb_init)))
            {
                try
                {
                    if (file.Length <= 0)
                    {
                        File.Delete(nullkb_init);
                    }
                }
                catch (Exception)
                {
                    //do nothing
                }
            }
        }

        private void StartServer()
        {
            //Start the server by sending a cmd command
            string configfile = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigfile = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            string nullkb_init = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer-UI\__init__.py";
            if (Directory.Exists(Path.GetDirectoryName(configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                DirChecks();
                int _ServerPID = CMD_Class.CMDStartServer("/k python -m FreeTAKServer.controllers.services.FTS", @"C:\Windows\System32");
                System.Threading.Thread.Sleep(1000);
                int _UIPID = CMD_Class.CMDStartServer("/k cd " + Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer-UI&&set FLASK_APP=run.py&&Flask run --host=0.0.0.0", Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer-UI");
                CMD_PID_Class._ServerPIDVar = _ServerPID;
                CMD_PID_Class._UIPIDVar = _UIPID;
                Process.Start("http://127.0.0.1:5000");
                LoggerClass.WriteLine(" *** Start Server PID=" + _ServerPID + ", Start UI PID=" + _UIPID + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Start Server PID=" + _ServerPID + ", Start UI PID=" + _UIPID + Environment.NewLine);

            }
            else
            {
                MessageBox.Show("Server is not installed", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LoggerClass.WriteLine(" *** Server is not installed  [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Server is not installed" + Environment.NewLine);
            }
        }

        private void StopServer()
        {
            //Stop the server by sending a cmd command
            string configfile = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigfile = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            if (Directory.Exists(Path.GetDirectoryName(configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                if (CMD_PID_Class._ServerPIDVar != 0)
                {
                    CMD_Class.PIDkill(CMD_PID_Class._ServerPIDVar);
                    CMD_Class.PIDkill(CMD_PID_Class._UIPIDVar);
                    LoggerClass.WriteLine(" *** Kill Server PID=" + CMD_PID_Class._ServerPIDVar + ",  Kill UI PID=" + CMD_PID_Class._UIPIDVar + "[MainForm] ***");
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
                LoggerClass.WriteLine(" *** Server is not installed  [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Server is not installed" + Environment.NewLine);
            }
        }
        private void about_menuitem_Click(object sender, RoutedEventArgs e)
        {
            //About window open
            AboutWindow w = new AboutWindow();
            w.ShowDialog();
            w.Activate();
        }

        private void email_setup_menuitem_Click(object sender, RoutedEventArgs e)
        {
            //Email setup window open
            EmailSetupWindow w = new EmailSetupWindow();
            Owner = Owner;
            w.ShowDialog();
            w.Activate();
        }

        private void read_me_menuitem_Click(object sender, RoutedEventArgs e)
        {
            //Readme window open
            ReadMeWindow w = new ReadMeWindow();
            Owner = Owner;
            w.ShowDialog();
            w.Activate();
        }

        private void Test_API_menuitem_Click(object sender, RoutedEventArgs e)
        {
            //Test API window open
            Test_APIWindow w = new Test_APIWindow();
            Owner = Owner;
            w.ShowDialog();
            w.Activate();
        }

        private void Startserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Call StartServer() method
            StartServer();
        }

        private bool clicked = true;
        private void Setdirserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Get the Python install path and set it as a setting in the app
            if (clicked == true)
            {
                try
                {
                    clicked = false;
                    Pythondir_textBox.Text = GetPythonPath();
                    Pythondir_textBox.IsEnabled = true;
                    Pythondir_textBox.IsReadOnly = false;
                    Setdirserver_button.Content = "Save Dir";
                    LoggerClass.WriteLine(" *** Auto Get Python Path Success [MainForm] ***");
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Auto Get Python Path Success" + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    clicked = false;
                    MessageBox.Show(ex.Message, "Auto Get Python Path Error! Please enter path manually.", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                    Pythondir_textBox.IsEnabled = true;
                    Pythondir_textBox.IsReadOnly = false;
                    Setdirserver_button.Content = "Save Dir";
                    LoggerClass.WriteLine(" *** Auto Get Python Path Error. Attempting Manual Path Entry [MainForm] ***");
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
                clicked = true;
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
                LoggerClass.WriteLine(" *** Python Path Save Success. Path=" + Pythondir_textBox.Text + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Python Path Save Success" + Environment.NewLine);
            }
        }

        private void Installserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Install the server by sending install commands via the cmd
            string configfile = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigfile = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            string YamlConfigfile = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer\FTSConfig.yaml";
            if (Directory.Exists(Path.GetDirectoryName(configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)) && Directory.Exists(Path.GetDirectoryName(YamlConfigfile)))
            {
                MessageBox.Show("Server is already installed", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LoggerClass.WriteLine(" *** Server is already installed  [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Server is already installed" + Environment.NewLine);
            }
            else
            {
                try
                {
                    ForceCursor = true;
                    Cursor = Cursors.Wait;
                    int _Install = CMD_Class.SendCMDCommandNormal("/c pip install -r TextFiles\\requirements.txt&&python -m pip install FreeTAKServer[ui]==2.0.69", AppDomain.CurrentDomain.BaseDirectory);
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"\YamlScripts\FTSConfig.yaml", Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer\FTSConfig.yaml", true);
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"\PythonScripts\config.py", Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer-UI\config.py", true);
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"\PythonScripts\MainConfig.py", Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py", true);
                    replaceText();
                    LoggerClass.WriteLine(" *** Install Server PID=" + _Install + " [MainForm] ***");
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Install Server PID=" + _Install + Environment.NewLine);
                    ForceCursor = true;
                    Cursor = Cursors.Arrow;
                    PythonInstalled();
                    MessageBox.Show("Server has been installed", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    ForceCursor = true;
                    Cursor = Cursors.Arrow;
                    MessageBox.Show(ex.Message, "Could not install FreeTAKServer[ui]", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                    return;
                }
            }
        }

        private string PythonVersion()
        {
            //string result = "";
            ProcessStartInfo pycheck = new ProcessStartInfo
            {
                FileName = @"python.exe",
                Arguments = "--version",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            using (Process process = Process.Start(pycheck))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }

        string GetPythonPath()
        {
            //get python path from environtment variables
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
                        pythonPathFromEnv = path + @"\python.exe";
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
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return "Get Python Path Error";
            }

        }

        private void Uninstallserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Stop the server and uninstall via cmd commands and delete FTSDataBase.db
            StopServer();
            string configfile = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigfile = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            if (Directory.Exists(Path.GetDirectoryName(configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                string Pythonpath = Properties.Settings.Default.Pythondir;
                try
                {
                    ForceCursor = true;
                    Cursor = Cursors.Wait;
                    int _Uninstall = CMD_Class.SendCMDCommandNormal("/c pip uninstall --yes FreeTAKServer&&pip uninstall --yes FreeTAKServer-UI", @"C:\Windows\System32");

                    string DataBasefile = Pythonpath + @"Lib\site-packages\FreeTAKServer\FTSDataBase.db";
                    if (Directory.Exists(Path.GetDirectoryName(DataBasefile)))
                    {
                        File.Delete(DataBasefile);
                        Directory.Delete(Pythonpath + @"Lib\site-packages\FreeTAKServer", true);
                        Directory.Delete(Pythonpath + @"Lib\site-packages\FreeTAKServer-UI", true);

                        LoggerClass.WriteLine(" *** Deleting Dir=" + Pythonpath + @"Lib\site-packages\FreeTAKServer  [MainForm] ***");
                        Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Deleting Dir=" + Pythonpath + @"Lib\site-packages\FreeTAKServer" + Environment.NewLine);
                        LoggerClass.WriteLine(" *** Deleting Dir=" + Pythonpath + @"Lib\site-packages\FreeTAKServer-UI  [MainForm] ***");
                        Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Deleting Dir=" + Pythonpath + @"Lib\site-packages\FreeTAKServer-UI" + Environment.NewLine);
                    }
                    LoggerClass.WriteLine(" *** Uninstall Server PID=" + _Uninstall + " [MainForm] ***");
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
                    LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Server is already uninstalled", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LoggerClass.WriteLine(" *** Server is already uninstalled  [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Server is already uninstalled" + Environment.NewLine);
            }
        }

        private void Checkportsserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Open the default browser to a port checking website
            Process.Start("https://www.yougetsignal.com/tools/open-ports/");
            LoggerClass.WriteLine(" *** Check ports https://www.yougetsignal.com/tools/open-ports/ [MainForm] ***");
            Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Check ports https://www.yougetsignal.com/tools/open-ports/" + Environment.NewLine);
        }

        private void Restartserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Kill the cmd PIDs and start the server again via cmd
            string configfile = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigfile = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            if (Directory.Exists(Path.GetDirectoryName(configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                if (CMD_PID_Class._ServerPIDVar != 0)
                {
                    CMD_Class.PIDkill(CMD_PID_Class._ServerPIDVar);
                    CMD_Class.PIDkill(CMD_PID_Class._UIPIDVar);
                    int _ServerPID = CMD_Class.CMDStartServer("/k python -m FreeTAKServer.controllers.services.FTS", @"C:\Windows\System32");
                    System.Threading.Thread.Sleep(1000);
                    int _UIPID = CMD_Class.CMDStartServer("/k cd " + Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer-UI&&set FLASK_APP=run.py&&Flask run --host=0.0.0.0", Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer-UI");
                    CMD_PID_Class._ServerPIDVar = _ServerPID;
                    CMD_PID_Class._UIPIDVar = _UIPID;
                    LoggerClass.WriteLine(" *** Restart Server PID=" + _ServerPID + ", Restart UI PID=" + _UIPID + " [MainForm] ***");
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
                LoggerClass.WriteLine(" *** Server is not installed  [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Server is not installed" + Environment.NewLine);
            }
        }

        private void Stopserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Stop the server method
            StopServer();
        }

        private void Editconfigserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Open the config.py file with the default file editor for that file type
            try
            {
                var f = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer-UI\config.py";
                var p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = f
                };

                p.Start();
                //p.WaitForExit();
                LoggerClass.WriteLine(" *** Edit config.py [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Edit config.py" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could edit config.py", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
        }

        private void Editmainconfigserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Open the MainConfig.py file with the default file editor for that file type
            try
            {
                var f = Properties.Settings.Default.Pythondir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
                var p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = f
                };

                p.Start();
                //p.WaitForExit();
                LoggerClass.WriteLine(" *** Edit MainConfig.py [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Edit MainConfig.py" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could edit MainConfig.py", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                return;
            }
        }

        public static bool PingHost(string hostUri, int portNumber)
        {
            //ping an IP and PORT
            try
            {
                using (var client = new TcpClient(hostUri, portNumber))
                    return true;
            }
            catch (SocketException ex)
            {
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                return false;
            }
        }

        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private void TimerStart()
        {
            //Start the dispatcherTimer watchdog (check that ip and port can be pinged every 30s)
            try
            {
                if (dispatcherTimer.IsEnabled)
                {
                    LoggerClass.WriteLine(" *** DispatcherTimer Already Running, No Need To Start [MainForm] ***");
                }
                else
                {
                    LoggerClass.WriteLine(" *** Started dispatcherTimer [MainForm] ***");
                    dispatcherTimer = new DispatcherTimer();
                    dispatcherTimer.Tick += dispatcherTimer_Tick;
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 30);//60 seconds
                    dispatcherTimer.Start();
                }
            }
            catch (Exception ex)
            {
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
            }
        }

        private void TimerStop()
        {
            //Stop the dispatcherTimer watchdog
            try
            {
                if (dispatcherTimer.IsEnabled)
                {
                    LoggerClass.WriteLine(" *** Stopped dispatcherTimer [MainForm] *** ");
                    dispatcherTimer.Stop();
                }
                else
                {
                    LoggerClass.WriteLine(" *** DispatcherTimer Already Stopped, No Need To Stop [MainForm] *** ");
                }
            }
            catch (Exception ex)
            {
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //Do what is contained within this method every 30 seconds
            if (PingHost("127.0.0.1", 5000) == false || PingHost("127.0.0.1", 8080) == false || PingHost("127.0.0.1", 8443) == false)
            {
                try
                {
                    //If ping fails send email loop
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
                    LoggerClass.WriteLine(" *** ALERT!! Mail sent! [MainForm] ***");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Email could not be tested", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine(" *** Error:" + ex.Message + " [EmailSetup_Form] ***");
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //On closing the application kill the server and UI PIDs
            if (CMD_PID_Class._ServerPIDVar != 0)
            {
                CMD_Class.PIDkill(CMD_PID_Class._ServerPIDVar);
                CMD_Class.PIDkill(CMD_PID_Class._UIPIDVar);
                LoggerClass.WriteLine(" *** Kill Server PID=" + CMD_PID_Class._ServerPIDVar + ",  Kill UI PID=" + CMD_PID_Class._UIPIDVar + "[MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Kill Server PID=" + CMD_PID_Class._ServerPIDVar + ", Kill UI PID=" + CMD_PID_Class._UIPIDVar + Environment.NewLine);
                LoggerClass.WriteLine(" *** Application Closed [MainForm] ***");
            }
            else
            {
                LoggerClass.WriteLine(" *** Application Closed [MainForm] ***");
                //do nothing
            }
        }

        private void Email_checkBox_click(object sender, RoutedEventArgs e)
        {
            //Emails will be sent if the watchdog ping fails when the checkbox is checked
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
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                MessageBox.Show(ex.Message, "Send email alert error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Startserver_Checkbox_Click(object sender, RoutedEventArgs e)
        {
            //The server will start at startup if the checkbox is checked
            //add startup event to registry
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
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
                LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                Richtextbox.AppendText("[" + DateTime.Now.ToString() + "] : Error:" + ex.Message + Environment.NewLine);
                MessageBox.Show(ex.Message, "Send email alert error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
