using Microsoft.Win32;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
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
                Directory.CreateDirectory($@"{AppDomain.CurrentDomain.BaseDirectory}\Logs");
                LoggerClass.WriteLine(" *** Application Start [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Application Start" + "\r");
                LoggerClass.WriteLine(" *** CreateDirectory Success [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Logs Create Directory Success" + "\r");
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Create Folder Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\r");
                return;
            }
        }
        private void Ini()
        {
            try
            {
                //Initiate the application: call methods
                StartServer_Button.IsEnabled = false;
                StopServer_Button.IsEnabled = false;
                RestartServer_Button.IsEnabled = false;
                UninstallServer_Button.IsEnabled = false;
                EditConfigServer_Button.IsEnabled = false;
                EditMainConfigServer_Button.IsEnabled = false;
                CheckPortsServer_Button.IsEnabled = false;
                InstallServer_Button.IsEnabled = false;
                CreateFolder();
                PythonInstalled();
                LoadPropertys();
                LoggerClass.WriteLine(" *** Ini Complete [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Ini Complete" + "\r");
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Ini Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\r");
                return;
            }
        }

        private void PythonInstalled()
        {
            try
            {
                //Check if Python is installed
                //bool isinstalled = IsSoftwareInstalled("Python");//Call the method
                string PythonVer = PythonVersion();
                LoggerClass.WriteLine($" *** Python check result: {PythonVer} [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Python check result: {PythonVer}");
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "PythonInstalled check error", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\n");
                return;
            }
        }
        private void LoadPropertys()
        {
            try
            {
                //Load all the path setting and set button propertys
                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.PythonDir))
                {
                    PythonDir_TextBox.IsEnabled = false;
                    PythonDir_TextBox.Text = Properties.Settings.Default.PythonDir;

                    StartServer_Button.IsEnabled = true;
                    StopServer_Button.IsEnabled = true;
                    RestartServer_Button.IsEnabled = true;
                    UninstallServer_Button.IsEnabled = true;
                    EditConfigServer_Button.IsEnabled = true;
                    EditMainConfigServer_Button.IsEnabled = true;
                    CheckPortsServer_Button.IsEnabled = true;
                    InstallServer_Button.IsEnabled = true;
                }
                if (Properties.Settings.Default.EmailCheckState)
                {
                    Email_CheckBox.IsChecked = Properties.Settings.Default.EmailCheckState;
                    if (Email_CheckBox.IsChecked == true)
                    {
                        TimerStart();
                    }
                }
                if (Properties.Settings.Default.StartupServer_CheckState)
                {
                    Startserver_CheckBox.IsChecked = Properties.Settings.Default.StartupServer_CheckState;
                    if (Startserver_CheckBox.IsChecked == true)
                    {
                        StartServer();
                    }
                }

            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Could not get Pythondir Property", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\n");
                return;
            }
        }

        private void ReplaceText()
        {
            try
            {
                //Replace the text `</text>` with the formatted Python path for windows in both config files
                string YamlConfigFile = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer\FTSConfig.yaml";
                string ConfigFile = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer-UI\config.py";
                string MainConfigFile = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
                if (Directory.Exists(Path.GetDirectoryName(ConfigFile)) && Directory.Exists(Path.GetDirectoryName(MainConfigFile)) && Directory.Exists(Path.GetDirectoryName(YamlConfigFile)))
                {
                    string ConfigFile = File.ReadAllText(ConfigFile, Encoding.UTF8);//Read config.py file text
                    string MainConfigFile = File.ReadAllText(MainConfigFile, Encoding.UTF8);//Read MainConfig.py file text
                    string YamlConfigFile = File.ReadAllText(YamlConfigFile, Encoding.UTF8);//Read FTSConfig.yaml file text
                    string PythonPath = Properties.Settings.Default.PythonDir.Replace(@"\", @"\\");//Replace directory `\` with `\\`

                    MainConfigFile = MainConfigFile.Replace("</text>", PythonPath);// Replace `</text>` with the directory
                    MainConfigFile = Regex.Replace(MainConfigFile, @"\<ref.*?\</ref\>", "");
                    File.WriteAllText(MainConfigFile, MainConfigFile);//Write all to file

                    ConfigFile = ConfigFile.Replace("</text>", PythonPath);// Replace `</text>` with the directory
                    ConfigFile = Regex.Replace(ConfigFile, @"\<ref.*?\</ref\>", "");
                    File.WriteAllText(ConfigFile, ConfigFile);//Write all to file

                    YamlConfigFile = YamlConfigFile.Replace("</text>", PythonPath);// Replace `</text>` with the directory
                    YamlConfigFile = Regex.Replace(YamlConfigFile, @"\<ref.*?\</ref\>", "");
                    File.WriteAllText(YamlConfigFile, YamlConfigFile);//Write all to file
                }

            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Create Folder Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\r");
                return;
            }
        }

        private void DirChecks()
        {
            //create logs folder, no need to check if it exists
            Directory.CreateDirectory($@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer\controllers\logs");
            string Nullkb_Init = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer-UI\__init__.py";
            //del 0kb file if it exists
            FileInfo FileInfo = new FileInfo(Nullkb_Init);
            if (Directory.Exists(Path.GetDirectoryName(Nullkb_Init)))
            {
                try
                {
                    if (FileInfo.Length <= 0)
                    {
                        File.Delete(Nullkb_Init);
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
            string ConfigFile = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigFile = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            string Nullkb_Init = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer-UI\__init__.py";
            if (Directory.Exists(Path.GetDirectoryName(ConfigFile)) && Directory.Exists(Path.GetDirectoryName(MainConfigFile)))
            {
                DirChecks();
                int ServerPID = CMD_Class.CMDStartServer("/k python -m FreeTAKServer.controllers.services.FTS", @"C:\Windows\System32");
                System.Threading.Thread.Sleep(1000);
                int UIPID = CMD_Class.CMDStartServer("/k cd " + Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer-UI&&set FLASK_APP=run.py&&Flask run --host=0.0.0.0", Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer-UI");
                CMD_PID_Class.ServerPIDVar = ServerPID;
                CMD_PID_Class.UIPIDVar = UIPID;
                Process.Start("http://127.0.0.1:5000");
                LoggerClass.WriteLine(" *** Start Server PID=" + ServerPID + ", Start UI PID=" + UIPID + " [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Start Server PID=" + ServerPID + ", Start UI PID=" + UIPID + Environment.NewLine);

            }
            else
            {
                MessageBox.Show("Server is not installed", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LoggerClass.WriteLine(" *** Server is not installed  [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Server is not installed" + Environment.NewLine);
            }
        }

        private void StopServer()
        {
            //Stop the server by sending a cmd command
            string ConfigFile = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigFile = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            if (Directory.Exists(Path.GetDirectoryName(ConfigFile)) && Directory.Exists(Path.GetDirectoryName(MainConfigFile)))
            {
                if (CMD_PID_Class.ServerPIDVar != 0)
                {
                    CMD_Class.PIDKill(CMD_PID_Class.ServerPIDVar);
                    CMD_Class.PIDKill(CMD_PID_Class.UIPIDVar);
                    LoggerClass.WriteLine(" *** Kill Server PID=" + CMD_PID_Class.ServerPIDVar + ",  Kill UI PID=" + CMD_PID_Class.UIPIDVar + "[MainForm] ***");
                    Richtextbox.AppendText($"[{DateTime.Now}] : Kill Server PID=" + CMD_PID_Class.ServerPIDVar + ", Kill UI PID=" + CMD_PID_Class.UIPIDVar + Environment.NewLine);
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
                Richtextbox.AppendText($"[{DateTime.Now}] : Server is not installed" + Environment.NewLine);
            }
        }
        private void About_menuitem_Click(object sender, RoutedEventArgs e)
        {
            //About window open
            AboutWindow W = new AboutWindow();
            W.ShowDialog();
            W.Activate();
        }

        private void Email_setup_menuitem_Click(object sender, RoutedEventArgs e)
        {
            //Email setup window open
            EmailSetupWindow W = new EmailSetupWindow();
            Owner = Owner;
            W.ShowDialog();
            W.Activate();
        }

        private void Read_me_menuitem_Click(object sender, RoutedEventArgs e)
        {
            //Readme window open
            ReadMeWindow W = new ReadMeWindow();
            Owner = Owner;
            W.ShowDialog();
            W.Activate();
        }

        private void Test_API_menuitem_Click(object sender, RoutedEventArgs e)
        {
            //Test API window open
            Test_APIWindow W = new Test_APIWindow();
            Owner = Owner;
            W.ShowDialog();
            W.Activate();
        }

        private void Startserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Call StartServer() method
            StartServer();
        }

        private bool ClickedButton = true;
        private void Setdirserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Get the Python install path and set it as a setting in the app
            if (ClickedButton == true)
            {
                try
                {
                    ClickedButton = false;
                    PythonDir_TextBox.Text = GetPythonPath();
                    PythonDir_TextBox.IsEnabled = true;
                    PythonDir_TextBox.IsReadOnly = false;
                    SetDirServer_Button.Content = "Save Dir";
                    LoggerClass.WriteLine(" *** Auto Get Python Path Success [MainForm] ***");
                    Richtextbox.AppendText($"[{DateTime.Now}] : Auto Get Python Path Success" + Environment.NewLine);
                }
                catch (Exception Exception)
                {
                    ClickedButton = false;
                    MessageBox.Show(Exception.Message, "Auto Get Python Path Error! Please enter path manually.", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                    Richtextbox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\r");
                    PythonDir_TextBox.IsEnabled = true;
                    PythonDir_TextBox.IsReadOnly = false;
                    SetDirServer_Button.Content = "Save Dir";
                    LoggerClass.WriteLine(" *** Auto Get Python Path Error. Attempting Manual Path Entry [MainForm] ***");
                    Richtextbox.AppendText($"[{DateTime.Now}] : Auto Get Python Path Error. Attempting Manual Path Entry" + Environment.NewLine);
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(PythonDir_TextBox.Text))
                {
                    MessageBox.Show("Python directory not entered!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation); return;
                }
                ClickedButton = true;
                Properties.Settings.Default.PythonDir = PythonDir_TextBox.Text;
                Properties.Settings.Default.Save();
                SetDirServer_Button.Content = "Get Dir";
                PythonDir_TextBox.IsEnabled = false;
                PythonDir_TextBox.IsReadOnly = true;
                StartServer_Button.IsEnabled = true;
                StopServer_Button.IsEnabled = true;
                RestartServer_Button.IsEnabled = true;
                UninstallServer_Button.IsEnabled = true;
                EditConfigServer_Button.IsEnabled = true;
                EditMainConfigServer_Button.IsEnabled = true;
                CheckPortsServer_Button.IsEnabled = true;
                InstallServer_Button.IsEnabled = true;
                MessageBox.Show("Dir : \' " + PythonDir_TextBox.Text + " \' has been saved ", "");
                LoggerClass.WriteLine(" *** Python Path Save Success. Path=" + PythonDir_TextBox.Text + " [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Python Path Save Success" + Environment.NewLine);
            }
        }

        private void Installserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Install the server by sending install commands via the cmd
            string ConfigFile = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigFile = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            string YamlConfigFile = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer\FTSConfig.yaml";
            if (Directory.Exists(Path.GetDirectoryName(ConfigFile)) && Directory.Exists(Path.GetDirectoryName(MainConfigFile)) && Directory.Exists(Path.GetDirectoryName(YamlConfigFile)))
            {
                MessageBox.Show("Server is already installed", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LoggerClass.WriteLine(" *** Server is already installed  [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Server is already installed" + Environment.NewLine);
            }
            else
            {
                try
                {
                    ForceCursor = true;
                    Cursor = Cursors.Wait;
                    int Install = CMD_Class.SendCMDCommandNormal(@"/c pip install -r TextFiles\requirements.txt&&python -m pip install FreeTAKServer[ui]==2.0.69", AppDomain.CurrentDomain.BaseDirectory);
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"\YamlScripts\FTSConfig.yaml", Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer\FTSConfig.yaml", true);
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"\PythonScripts\config.py", Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer-UI\config.py", true);
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"\PythonScripts\MainConfig.py", Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py", true);
                    ReplaceText();
                    LoggerClass.WriteLine(" *** Install Server PID=" + Install + " [MainForm] ***");
                    Richtextbox.AppendText($"[{DateTime.Now}] : Install Server PID=" + Install + Environment.NewLine);
                    ForceCursor = true;
                    Cursor = Cursors.Arrow;
                    PythonInstalled();
                    MessageBox.Show("Server has been installed", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception Exception)
                {
                    ForceCursor = true;
                    Cursor = Cursors.Arrow;
                    MessageBox.Show(Exception.Message, "Could not install FreeTAKServer[ui]", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                    Richtextbox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\r");
                    return;
                }
            }
        }

        private string PythonVersion()
        {
            //string result = "";
            ProcessStartInfo PYCheck = new ProcessStartInfo
            {
                FileName = @"python.exe",
                Arguments = "--version",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            using (Process Process = Process.Start(PYCheck))
            {
                using (StreamReader Reader = Process.StandardOutput)
                {
                    string Result = Reader.ReadToEnd();
                    return Result;
                }
            }
        }

        string GetPythonPath()
        {
            //get python path from environtment variables
            try
            {
                IDictionary EV = Environment.GetEnvironmentVariables();
                string PathVariable = EV["Path"] as string;
                string PythonPathFromEnv = "";
                if (PathVariable != null)
                {
                    string[] AllPaths = PathVariable.Split(';');
                    foreach (var Path in AllPaths)
                    {
                        PythonPathFromEnv = Path + @"\python.exe";
                        if (File.Exists(PythonPathFromEnv))
                        {
                            return PythonPathFromEnv = Path;
                        }
                    }
                }
                return PythonPathFromEnv;
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Get Python Path Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\r");
                return "Get Python Path Error";
            }

        }

        private void Uninstallserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Stop the server and uninstall via cmd commands and delete FTSDataBase.db
            StopServer();
            string ConfigFile = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigFile = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            if (Directory.Exists(Path.GetDirectoryName(ConfigFile)) && Directory.Exists(Path.GetDirectoryName(MainConfigFile)))
            {
                string PythonPath = Properties.Settings.Default.PythonDir;
                try
                {
                    ForceCursor = true;
                    Cursor = Cursors.Wait;
                    int Uninstall = CMD_Class.SendCMDCommandNormal("/c pip uninstall --yes FreeTAKServer&&pip uninstall --yes FreeTAKServer-UI", @"C:\Windows\System32");

                    string DataBaseFile = PythonPath + @"Lib\site-packages\FreeTAKServer\FTSDataBase.db";
                    if (Directory.Exists(Path.GetDirectoryName(DataBaseFile)))
                    {
                        File.Delete(DataBaseFile);
                        Directory.Delete(PythonPath + @"Lib\site-packages\FreeTAKServer", true);
                        Directory.Delete(PythonPath + @"Lib\site-packages\FreeTAKServer-UI", true);

                        LoggerClass.WriteLine(" *** Deleting Dir=" + PythonPath + @"Lib\site-packages\FreeTAKServer  [MainForm] ***");
                        Richtextbox.AppendText($"[{DateTime.Now}] : Deleting Dir=" + PythonPath + @"Lib\site-packages\FreeTAKServer" + Environment.NewLine);
                        LoggerClass.WriteLine(" *** Deleting Dir=" + PythonPath + @"Lib\site-packages\FreeTAKServer-UI  [MainForm] ***");
                        Richtextbox.AppendText($"[{DateTime.Now}] : Deleting Dir=" + PythonPath + @"Lib\site-packages\FreeTAKServer-UI" + Environment.NewLine);
                    }
                    LoggerClass.WriteLine(" *** Uninstall Server PID=" + Uninstall + " [MainForm] ***");
                    Richtextbox.AppendText($"[{DateTime.Now}] : Uninstall Server PID=" + Uninstall + Environment.NewLine);
                    ForceCursor = true;
                    Cursor = Cursors.Arrow;
                    MessageBox.Show("Server has been uninstalled", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception Exception)
                {
                    ForceCursor = true;
                    Cursor = Cursors.Arrow;
                    MessageBox.Show(Exception.Message, "Could not uninstall FreeTAKServer & FreeTAKServer-UI", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                    Richtextbox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\r");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Server is already uninstalled", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LoggerClass.WriteLine(" *** Server is already uninstalled  [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Server is already uninstalled" + Environment.NewLine);
            }
        }

        private void Checkportsserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Open the default browser to a port checking website
            Process.Start("https://www.yougetsignal.com/tools/open-ports/");
            LoggerClass.WriteLine(" *** Check ports https://www.yougetsignal.com/tools/open-ports/ [MainForm] ***");
            Richtextbox.AppendText($"[{DateTime.Now}] : Check ports https://www.yougetsignal.com/tools/open-ports/" + Environment.NewLine);
        }

        private void Restartserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Kill the cmd PIDs and start the server again via cmd
            string ConfigFile = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigFile = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            if (Directory.Exists(Path.GetDirectoryName(ConfigFile)) && Directory.Exists(Path.GetDirectoryName(MainConfigFile)))
            {
                if (CMD_PID_Class.ServerPIDVar != 0)
                {
                    CMD_Class.PIDKill(CMD_PID_Class.ServerPIDVar);
                    CMD_Class.PIDKill(CMD_PID_Class.UIPIDVar);
                    int ServerPID = CMD_Class.CMDStartServer("/k python -m FreeTAKServer.controllers.services.FTS", @"C:\Windows\System32");
                    System.Threading.Thread.Sleep(1000);
                    int UIPID = CMD_Class.CMDStartServer("/k cd " + Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer-UI&&set FLASK_APP=run.py&&Flask run --host=0.0.0.0", Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer-UI");
                    CMD_PID_Class.ServerPIDVar = ServerPID;
                    CMD_PID_Class.UIPIDVar = UIPID;
                    LoggerClass.WriteLine(" *** Restart Server PID=" + ServerPID + ", Restart UI PID=" + UIPID + " [MainForm] ***");
                    Richtextbox.AppendText($"[{DateTime.Now}] : Restart Server PID=" + ServerPID + ", Restart UI PID=" + UIPID + Environment.NewLine);
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
                Richtextbox.AppendText($"[{DateTime.Now}] : Server is not installed" + Environment.NewLine);
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
                var FileName = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer-UI\config.py";
                var Process = new Process();
                Process.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = FileName
                };

                Process.Start();
                //Process.WaitForExit();
                LoggerClass.WriteLine(" *** Edit config.py [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Edit config.py" + Environment.NewLine);
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Could edit config.py", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\r");
                return;
            }
        }

        private void Editmainconfigserver_button_Click(object sender, RoutedEventArgs e)
        {
            //Open the MainConfig.py file with the default file editor for that file type
            try
            {
                var FileName = Properties.Settings.Default.PythonDir + @"Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
                var Process = new Process();
                Process.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = FileName
                };

                Process.Start();
                //p.WaitForExit();
                LoggerClass.WriteLine(" *** Edit MainConfig.py [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Edit MainConfig.py" + Environment.NewLine);
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Could edit MainConfig.py", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\r");
                return;
            }
        }

        public static bool PingHost(string HostUri, int PortNumber)
        {
            //ping an IP and PORT
            try
            {
                using (var Client = new TcpClient(HostUri, PortNumber))
                    return true;
            }
            catch (SocketException Exception)
            {
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                return false;
            }
        }

        private DispatcherTimer DT = new DispatcherTimer();
        private void TimerStart()
        {
            //Start the dispatcherTimer watchdog (check that ip and port can be pinged every 30s)
            try
            {
                if (DT.IsEnabled)
                {
                    LoggerClass.WriteLine(" *** DispatcherTimer Already Running, No Need To Start [MainForm] ***");
                }
                else
                {
                    LoggerClass.WriteLine(" *** Started dispatcherTimer [MainForm] ***");
                    DT = new DispatcherTimer();
                    DT.Tick += DispatcherTimer_Tick;
                    DT.Interval = new TimeSpan(0, 0, 30);//60 seconds
                    DT.Start();
                }
            }
            catch (Exception Exception)
            {
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
            }
        }

        private void TimerStop()
        {
            //Stop the dispatcherTimer watchdog
            try
            {
                if (DT.IsEnabled)
                {
                    LoggerClass.WriteLine(" *** Stopped dispatcherTimer [MainForm] *** ");
                    DT.Stop();
                }
                else
                {
                    LoggerClass.WriteLine(" *** DispatcherTimer Already Stopped, No Need To Stop [MainForm] *** ");
                }
            }
            catch (Exception Exception)
            {
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            //Do what is contained within this method every 30 seconds
            if (PingHost("127.0.0.1", 5000) == false || PingHost("127.0.0.1", 8080) == false || PingHost("127.0.0.1", 8443) == false)
            {
                try
                {
                    //If ping fails send email loop
                    //Decrypt
                    SecureString Password = EncryptionClass.DecryptString(Properties.Settings.Default.EmailPass);
                    string Pass = EncryptionClass.ToInsecureString(Password);

                    MailMessage Mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(Properties.Settings.Default.EmailSmtp);//smtp.techrad.co.za

                    Mail.From = new MailAddress(Properties.Settings.Default.EmailFrom);
                    Mail.To.Add(Properties.Settings.Default.EmailTo);
                    Mail.Subject = Properties.Settings.Default.EmailSubject;
                    Mail.Body = Properties.Settings.Default.EmailBody;

                    SmtpServer.Port = 587;//port
                    SmtpServer.Credentials = new NetworkCredential(Properties.Settings.Default.EmailUsername, Pass);//details
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(Mail);
                    LoggerClass.WriteLine(" *** ALERT!! Mail sent! [MainForm] ***");
                }
                catch (Exception Exception)
                {
                    //MessageBox.Show(Exception.Message, "Email could not be tested", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [EmailSetup_Form] ***");
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //On closing the application kill the server and UI PIDs
            if (CMD_PID_Class.ServerPIDVar != 0)
            {
                CMD_Class.PIDKill(CMD_PID_Class.ServerPIDVar);
                CMD_Class.PIDKill(CMD_PID_Class.UIPIDVar);
                LoggerClass.WriteLine(" *** Kill Server PID=" + CMD_PID_Class.ServerPIDVar + ",  Kill UI PID=" + CMD_PID_Class.UIPIDVar + "[MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Kill Server PID=" + CMD_PID_Class.ServerPIDVar + ", Kill UI PID=" + CMD_PID_Class.UIPIDVar + Environment.NewLine);
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
                if (Email_CheckBox.IsChecked == true)
                {
                    Properties.Settings.Default.EmailCheckState = true;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Emails WILL be sent", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    TimerStart();
                }
                else
                {
                    Properties.Settings.Default.EmailCheckState = false;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Emails will NOT be sent", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    TimerStop();
                }
            }
            catch (Exception Exception)
            {
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\r");
                MessageBox.Show(Exception.Message, "Send email alert error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Startserver_Checkbox_Click(object sender, RoutedEventArgs e)
        {
            //The server will start at startup if the checkbox is checked
            //add startup event to registry
            try
            {
                RegistryKey RK = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                string AppName = "FreeTAKServer_Manager";
                if (Startserver_CheckBox.IsChecked == true)
                {
                    RK.SetValue(AppName, AppDomain.CurrentDomain.BaseDirectory);
                    Properties.Settings.Default.StartupServer_CheckState = true;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Server will START at startup", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    RK.DeleteValue(AppName, false);
                    Properties.Settings.Default.StartupServer_CheckState = false;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Server will NOT START at startup", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception Exception)
            {
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                Richtextbox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\r");
                MessageBox.Show(Exception.Message, "Send email alert error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
