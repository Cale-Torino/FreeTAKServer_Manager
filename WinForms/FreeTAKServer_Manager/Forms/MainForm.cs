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
using System.Windows.Forms;
using System.Windows.Threading;
using static FreeTAKServer_Manager.CMDClass;

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
                //Initiate the app by calling these methods
                StartServerButton.Enabled = false;
                StopServerButton.Enabled = false;
                RestartServerButton.Enabled = false;
                UninstallServerButton.Enabled = false;
                EditConfigButton.Enabled = false;
                EditMainConfigButton.Enabled = false;
                CheckPortsButton.Enabled = false;
                InstallServerButton.Enabled = false;
                CreateFolder();
                PythonInstalled();
                LoadPropertys();

                LoggerClass.WriteLine(" *** Ini Complete [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Ini Complete \n");
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Ini Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message} \n");
                return;
            }
        }

        private void PythonInstalled()
        {
            try
            {
                //Check if Python is installed
                //bool isinstalled = IsSoftwareInstalled("Python");//Call the method
                string PythonVersion = CheckPythonVersion();
                LoggerClass.WriteLine($" *** Python check result: {PythonVersion} [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Python check result: {PythonVersion}");
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "PythonInstalled check error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerClass.WriteLine($" *** Error: {Exception.Message} [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message} \n");
                return;
            }
        }
        private void LoadPropertys()
        {
            try
            {
                //Load all the saved properties from the config file on app startup
                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.PythonDir))
                {
                    PythonDirTextBox.Enabled = false;
                    PythonDirTextBox.Text = Properties.Settings.Default.PythonDir;//Gets Python directory.

                    StartServerButton.Enabled = true;
                    StopServerButton.Enabled = true;
                    RestartServerButton.Enabled = true;
                    UninstallServerButton.Enabled = true;
                    EditConfigButton.Enabled = true;
                    EditMainConfigButton.Enabled = true;
                    CheckPortsButton.Enabled = true;
                    InstallServerButton.Enabled = true;
                }
                if (Properties.Settings.Default.EmailCheckState)
                {
                    //If the checkbox was checked start the server running watchdog timer on app start
                    EmailCheckBox.Checked = Properties.Settings.Default.EmailCheckState;
                    if (EmailCheckBox.Checked == true)
                    {
                        TimerStart();
                    }
                }
                if (Properties.Settings.Default.StartupServerCheckState)
                {
                    //If the checkbox was checked start the server on app start
                    StartServerCheckBox.Checked = Properties.Settings.Default.StartupServerCheckState;
                    if (StartServerCheckBox.Checked == true)
                    {
                        StartServer();
                    }
                }

            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Could not get Pythondir Property", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\n");
                return;
            }
        }
        private void CreateFolder()
        {
            try
            {
                //Create the folders used by the app
                string Path = Application.StartupPath;
                Directory.CreateDirectory($@"{Path}\Logs");
                Directory.CreateDirectory($@"{Path}\Updates");
                LoggerClass.WriteLine(" *** Application Start [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Application Start\n");
                LoggerClass.WriteLine(" *** CreateDirectory Success [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Logs Create Directory Success\n");
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Create Folder Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\n");
                return;
            }
        }

        private void ReplaceText()
        {
            try
            {
                string YamlConfigfile = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer\FTSConfig.yaml";
                string ConfigFile = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer-UI\config.py";
                string MainConfigfile = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
                //If the files exist replace `</text>`
                if (Directory.Exists(Path.GetDirectoryName(ConfigFile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)) && Directory.Exists(Path.GetDirectoryName(YamlConfigfile))) 
                {
                    string ConFigFile = File.ReadAllText(ConfigFile, Encoding.UTF8);//Read config.py file text
                    string MainCF = File.ReadAllText(MainConfigfile, Encoding.UTF8);//Read MainConfig.py file text
                    string YamlCF = File.ReadAllText(YamlConfigfile, Encoding.UTF8);//Read FTSConfig.yaml file text
                    string PythonPath = Properties.Settings.Default.PythonDir.Replace(@"\", @"\\");//Replace directory `\` with `\\`

                    YamlCF = YamlCF.Replace("</text>", PythonPath);// Replace `</text>` with the directory
                    YamlCF = Regex.Replace(YamlCF, @"\<ref.*?\</ref\>", "");
                    File.WriteAllText(YamlConfigfile, YamlCF);//Write all to file

                    MainCF = MainCF.Replace("</text>", PythonPath);// Replace `</text>` with the directory
                    MainCF = Regex.Replace(MainCF, @"\<ref.*?\</ref\>", "");
                    File.WriteAllText(MainConfigfile, MainCF);//Write all to file

                    ConFigFile = ConFigFile.Replace("</text>", PythonPath);// Replace `</text>` with the directory
                    ConFigFile = Regex.Replace(ConFigFile, @"\<ref.*?\</ref\>", "");
                    File.WriteAllText(ConfigFile, ConFigFile);//Write all to file
                }

            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Create Folder Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\n");
                return;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Application load
            Ini();
            Focus();//Focus on the Main form
        }

        public static bool IsFileEmpty(string FileName)
        {
            var Info = new FileInfo(FileName);
            if (Info.Length == 0)
            {
                return true;
            }             
            // only if your use case can involve files with 1 or a few bytes of content.
            if (Info.Length < 6)
            {
                var Content = File.ReadAllText(FileName);
                return Content.Length == 0;
            }
            return false;
        }

        private void DirChecks()
        {
            //create logs folder, no need to check if it exists
            Directory.CreateDirectory($@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer\controllers\logs");
            string NullkbInit = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer-UI\__init__.py";
            //del 0kb file if it exists
            FileInfo FileInf = new FileInfo(NullkbInit);
            if (Directory.Exists(Path.GetDirectoryName(NullkbInit)))
            {
                try
                {
                    if (FileInf.Length <= 0)
                    {
                        File.Delete(NullkbInit);
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
            string Configfile = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigfile = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            if (Directory.Exists(Path.GetDirectoryName(Configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                DirChecks();
                //Start the server via sending a cmd command
                int ServerPID = CMDInstance.CMDStartServer("/k python -m FreeTAKServer.controllers.services.FTS", @"C:\Windows\System32");//Start server
                System.Threading.Thread.Sleep(1000);
                int UIPID = CMDInstance.CMDStartServer($@"/k cd {Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer-UI&&set FLASK_APP=run.py&&Flask run --host=0.0.0.0", $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer-UI");//Start UI
                CMDPIDClass.ServerPIDVar = ServerPID;
                CMDPIDClass.UIPIDVar = UIPID;
                Process.Start("http://127.0.0.1:5000");// Open this page in the default browser
                LoggerClass.WriteLine($" *** Start Server PID={ServerPID}, Start UI PID={UIPID} [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Start Server PID={ServerPID}, Start UI PID={UIPID}\n");

            }
            else
            {
                MessageBox.Show("Server is not installed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoggerClass.WriteLine(" *** Server is not installed  [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Server is not installed\n");
            }
        }

        private void Startserver_button_Click(object sender, EventArgs e)
        {
            //Start the server
            StartServer();
        }
        private void StopServer()
        {
            string Configfile = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigfile = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            //Stop the server via sending a cmd command to kill the process
            if (Directory.Exists(Path.GetDirectoryName(Configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                if (CMDPIDClass.ServerPIDVar != 0)
                {
                    CMDInstance.PIDKill(CMDPIDClass.ServerPIDVar);//Kill the server
                    CMDInstance.PIDKill(CMDPIDClass.UIPIDVar);//Kill the UI
                    LoggerClass.WriteLine($" *** Kill Server PID={CMDPIDClass.ServerPIDVar},  Kill UI PID={CMDPIDClass.UIPIDVar}[MainForm] ***");
                    LogsRichTextBox.AppendText($"[{DateTime.Now}] : Kill Server PID={CMDPIDClass.ServerPIDVar}, Kill UI PID={CMDPIDClass.UIPIDVar}\n");
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
                LoggerClass.WriteLine(" *** Server is not installed  [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Server is not installed\n");
            }
        }
        private void Stopserver_button_Click(object sender, EventArgs e)
        {
            //Stop the server
            StopServer();
        }

        private void Restartserver_button_Click(object sender, EventArgs e)
        {
            string Configfile = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigfile = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            //Stop the server and UI by killing the process, then start the server again by calling the cmd methods
            if (Directory.Exists(Path.GetDirectoryName(Configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                if (CMDPIDClass.ServerPIDVar != 0)
                {
                    CMDInstance.PIDKill(CMDPIDClass.ServerPIDVar);
                    CMDInstance.PIDKill(CMDPIDClass.UIPIDVar);
                    int ServerPID = CMDInstance.CMDStartServer("/k python -m FreeTAKServer.controllers.services.FTS", @"C:\Windows\System32");
                    System.Threading.Thread.Sleep(1000);
                    int UIPID = CMDInstance.CMDStartServer($@"/k cd {Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer-UI&&set FLASK_APP=run.py&&Flask run --host=0.0.0.0",  $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer-UI");
                    CMDPIDClass.ServerPIDVar = ServerPID;
                    CMDPIDClass.UIPIDVar = UIPID;
                    LoggerClass.WriteLine($" *** Restart Server PID={ServerPID}, Restart UI PID={UIPID} [MainForm] ***");
                    LogsRichTextBox.AppendText($"[{DateTime.Now}] : Restart Server PID={ServerPID}, Restart UI PID={UIPID}\n");
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
                LoggerClass.WriteLine(" *** Server is not installed  [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Server is not installed\n");
            }

        }

        private void Uninstallserver_button_Click(object sender, EventArgs e)
        {
            StopServer();//Stop the server
            string Configfile = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigfile = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            //Uninstall the server bu sending the pip uninstall command to the cmd.
            if (Directory.Exists(Path.GetDirectoryName(Configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)))
            {
                string PythonPath = Properties.Settings.Default.PythonDir;
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int Uninstall = CMDInstance.SendCMDCommandNormal("/c pip uninstall --yes FreeTAKServer&&pip uninstall --yes FreeTAKServer-UI", @"C:\Windows\System32");

                    string DataBasefile = $@"{PythonPath}Lib\site-packages\FreeTAKServer\FTSDataBase.db";
                    if (Directory.Exists(Path.GetDirectoryName(DataBasefile)))
                    {
                        //Delete the FreeTAKServer folder, the FreeTAKServer-UI folder and the FTSDataBase.db file
                        File.Delete(DataBasefile);
                        Directory.Delete($@"{PythonPath}Lib\site-packages\FreeTAKServer", true);
                        Directory.Delete($@"{PythonPath}Lib\site-packages\FreeTAKServer-UI", true);

                        LoggerClass.WriteLine($@" *** Deleting Dir={PythonPath}Lib\site-packages\FreeTAKServer  [MainForm] ***");
                        LogsRichTextBox.AppendText($@"[{DateTime.Now}] : Deleting Dir={PythonPath}Lib\site-packages\FreeTAKServer{Environment.NewLine}");
                        LoggerClass.WriteLine($@" *** Deleting Dir={PythonPath}Lib\site-packages\FreeTAKServer-UI  [MainForm] ***");
                        LogsRichTextBox.AppendText($@"[{DateTime.Now}] : Deleting Dir={PythonPath}Lib\site-packages\FreeTAKServer-UI{Environment.NewLine}");
                    }
                    LoggerClass.WriteLine($" *** Uninstall Server PID={Uninstall} [MainForm] ***");
                    LogsRichTextBox.AppendText($"[{DateTime.Now}] : Uninstall Server PID={Uninstall}\n");
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Server has been uninstalled", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception Exception)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(Exception.Message, "Could not uninstall FreeTAKServer & FreeTAKServer-UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                    LogsRichTextBox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\n");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Server is already uninstalled", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoggerClass.WriteLine(" *** Server is already uninstalled  [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Server is already uninstalled\n");
            }

        }

        private void Editmainconfig_button_Click(object sender, EventArgs e)
        {
            try
            {
                //Open the MainConfig.py in the default editor for that file type
                var FileName = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
                var Process = new Process();
                Process.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = FileName
                };

                Process.Start();
                //p.WaitForExit();
                LoggerClass.WriteLine(" *** Edit MainConfig.py [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Edit MainConfig.py\n");
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Could edit MainConfig.py", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\n");
                return;
            }
        }

        private void Editconfig_button_Click(object sender, EventArgs e)
        {
            try
            {
                //Open the config.py in the default editor for that file type
                var FileName = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer-UI\config.py";
                var Process = new Process();
                Process.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = FileName
                };

                Process.Start();
                //p.WaitForExit();
                LoggerClass.WriteLine(" *** Edit config.py [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Edit config.py\n");
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Could edit config.py", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\n");
                return;
            }
        }

        private void Checkports_button_Click(object sender, EventArgs e)
        {
            //Open www.yougetsignal.com in the default browser 
            Process.Start("https://www.yougetsignal.com/tools/open-ports/");
            LoggerClass.WriteLine(" *** Check ports https://www.yougetsignal.com/tools/open-ports/ [MainForm] ***");
            LogsRichTextBox.AppendText($"[{DateTime.Now}] : Check ports https://www.yougetsignal.com/tools/open-ports/\n");
        }
        private void Installserver_button_Click(object sender, EventArgs e)
        {
            string Configfile =  $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer-UI\config.py";
            string MainConfigfile = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py";
            string YamlConfigfile = $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer\FTSConfig.yaml";
            //Install the requirements file, the server and the UI
            if (Directory.Exists(Path.GetDirectoryName(Configfile)) && Directory.Exists(Path.GetDirectoryName(MainConfigfile)) && Directory.Exists(Path.GetDirectoryName(YamlConfigfile)))
            {
                MessageBox.Show("Server is already installed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoggerClass.WriteLine(" *** Server is already installed  [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Server is already installed\n");
            }
            else
            {
                try
                {
                    PythonInstalled();
                    Cursor.Current = Cursors.WaitCursor;
                    // /c pip install -r requirements.txt&&python -m pip install FreeTAKServer[ui]
                    // /c pip install -r requirements.txt&&python -m pip install FreeTAKServer[ui]==1.8.1
                    // /c pip python -m pip install FreeTAKServer[ui]==1.7.5
                    int Install = CMDInstance.SendCMDCommandNormal("/c pip install -r TextFiles\\requirements.txt&&python -m pip install FreeTAKServer[ui]==2.0.69", Application.StartupPath);
                    File.Copy($@"{Application.StartupPath}\YamlScripts\FTSConfig.yaml", $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer\FTSConfig.yaml", true);
                    File.Copy($@"{Application.StartupPath}\PythonScripts\config.py", $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer-UI\config.py", true);
                    File.Copy($@"{Application.StartupPath}\PythonScripts\MainConfig.py", $@"{Properties.Settings.Default.PythonDir}Lib\site-packages\FreeTAKServer\core\configuration\MainConfig.py", true);
                    ReplaceText();
                    LoggerClass.WriteLine($" *** Install Server PID={Install} [MainForm] ***");
                    LogsRichTextBox.AppendText($"[{DateTime.Now}] : Install Server PID={Install}\n");
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Server has been installed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception Exception)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(Exception.Message, "Could not install FreeTAKServer[ui]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                    LogsRichTextBox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\n");
                    return;
                }
            }

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open the about form
            using (Form Form = new About_Form())
            {
                Form.ShowDialog();
                Form.Activate();
            }
        }

        private void EmailSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open the email setup form
            using (Form Form = new EmailSetup_Form())
            {
                Form.ShowDialog();
                Form.Activate();
            }
        }

        private void ReadMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open the read me form
            using (Form Form = new ReadMe_Form())
            {
                Form.ShowDialog();
                Form.Activate();
            }
        }
        private string CheckPythonVersion()
        {
            //string result = "";
            ProcessStartInfo PyCheck = new ProcessStartInfo
            {
                FileName = @"python.exe",
                Arguments = "--version",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            using (Process Process = Process.Start(PyCheck))
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
            try
            {
                //get python path from environtment variable [set when python was installed]
                IDictionary EnvironmentVariables = Environment.GetEnvironmentVariables();
                string PathVariable = EnvironmentVariables["Path"] as string;
                string PythonPathFromEnv = "";
                if (PathVariable != null)
                {
                    string[] AllPaths = PathVariable.Split(';');
                    foreach (var Path in AllPaths)
                    {
                        PythonPathFromEnv = $@"{Path}\python.exe";
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
                MessageBox.Show(Exception.Message, "Get Python Path Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\n");
                return "Get Python Path Error";
            }

        }

        private void Setdir_button_Click(object sender, EventArgs e)
        {
            //Click the Set dir button to set the directory entered in the textbox
            if (SetDirButton.Text == "Get Dir")
            {
                try
                {
                    PythonDirTextBox.Text = GetPythonPath();//Get the Python path
                    PythonDirTextBox.Enabled = true;
                    PythonDirTextBox.ReadOnly = false;
                    SetDirButton.Text = "Save Dir";
                    LoggerClass.WriteLine(" *** Auto Get Python Path Success [MainForm] ***");
                    LogsRichTextBox.AppendText($"[{DateTime.Now}] : Auto Get Python Path Success\n");
                }
                catch (Exception Exception)
                {
                    MessageBox.Show(Exception.Message, "Auto Get Python Path Error! Please enter path manually.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                    LogsRichTextBox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\n");
                    PythonDirTextBox.Enabled = true;
                    PythonDirTextBox.ReadOnly = false;
                    SetDirButton.Text = "Save Dir";
                    LoggerClass.WriteLine(" *** Auto Get Python Path Error. Attempting Manual Path Entry [MainForm] ***");
                    LogsRichTextBox.AppendText($"[{DateTime.Now}] : Auto Get Python Path Error. Attempting Manual Path Entry\n");
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(SetDirButton.Text))
                {
                    MessageBox.Show("Python directory not entered!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                }
                Properties.Settings.Default.PythonDir = PythonDirTextBox.Text;
                Properties.Settings.Default.Save();//Save the directory to the config file
                SetDirButton.Text = "Get Dir";
                PythonDirTextBox.Enabled = false;
                PythonDirTextBox.ReadOnly = true;

                StartServerButton.Enabled = true;
                StopServerButton.Enabled = true;
                RestartServerButton.Enabled = true;
                UninstallServerButton.Enabled = true;
                EditConfigButton.Enabled = true;
                EditMainConfigButton.Enabled = true;
                CheckPortsButton.Enabled = true;
                InstallServerButton.Enabled = true;
                MessageBox.Show($"Dir : \' {PythonDirTextBox.Text} \' has been saved ", "");
                LoggerClass.WriteLine($" *** Python Path Save Success. Path={PythonDirTextBox.Text} [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Python Path Save Success\n");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CMDPIDClass.ServerPIDVar != 0)
            {
                //On form closing stop the server and UI
                CMDInstance.PIDKill(CMDPIDClass.ServerPIDVar);
                CMDInstance.PIDKill(CMDPIDClass.UIPIDVar);
                LoggerClass.WriteLine($" *** Kill Server PID={CMDPIDClass.ServerPIDVar},  Kill UI PID={CMDPIDClass.UIPIDVar}[MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Kill Server PID={CMDPIDClass.ServerPIDVar}, Kill UI PID={CMDPIDClass.UIPIDVar}\n");
                LoggerClass.WriteLine(" *** Application Closed [MainForm] ***");
            }
            else
            {
                LoggerClass.WriteLine(" *** Application Closed [MainForm] ***");
                //do nothing
            }
        }
        public static bool PingHost(string HostUri, int PortNumber)
        {
            //Ping the server to see if it is running
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

        private DispatcherTimer DispatcherTimer = new DispatcherTimer();
        private void TimerStart()
        {
            try
            {
                //Start the watchdog timer to check that the server is running
                if (DispatcherTimer.IsEnabled)
                {
                    LoggerClass.WriteLine(" *** DispatcherTimer Already Running, No Need To Start [MainForm] ***");
                }
                else
                {
                    LoggerClass.WriteLine(" *** Started dispatcherTimer [MainForm] ***");
                    DispatcherTimer = new DispatcherTimer();
                    DispatcherTimer.Tick += DispatcherTimer_Tick;
                    DispatcherTimer.Interval = new TimeSpan(0, 0, 30);//60 seconds
                    DispatcherTimer.Start();
                }
            }
            catch (Exception Exception)
            {
                LoggerClass.WriteLine($" *** Error:{Exception.Message}[MainForm] ***");
                //MessageBox.Show(ex.ToString(), "TimerStart Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TimerStop()
        {
            try
            {
                //Stop the watchdog timer
                if (DispatcherTimer.IsEnabled)
                {
                    LoggerClass.WriteLine(" *** Stopped dispatcherTimer [MainForm] *** ");
                    DispatcherTimer.Stop();
                }
                else
                {
                    LoggerClass.WriteLine(" *** DispatcherTimer Already Stopped, No Need To Stop [MainForm] *** ");
                }
            }
            catch (Exception Exception)
            {
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                //MessageBox.Show(ex.ToString(), "TimerStop Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            //If pings are false send an email loop again forever
            if (PingHost("127.0.0.1", 5000) == false || PingHost("127.0.0.1", 8080) == false || PingHost("127.0.0.1", 8443) == false)
            {
                try
                {

                    //Decrypt
                    SecureString Password = EncryptionClass.DecryptString(Properties.Settings.Default.EmailPass);
                    string Pass = EncryptionClass.ToInsecureString(Password);

                    MailMessage Mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(Properties.Settings.Default.EmailSmtp);//smtp.example.com

                    Mail.From = new MailAddress(Properties.Settings.Default.EmailFrom);//from
                    Mail.To.Add(Properties.Settings.Default.EmailTo);//to
                    Mail.Subject = Properties.Settings.Default.EmailSubject;//subject
                    Mail.Body = Properties.Settings.Default.EmailBody;//body

                    SmtpServer.Port = 587;//port
                    SmtpServer.Credentials = new NetworkCredential(Properties.Settings.Default.EmailUsername, Pass);//details
                    SmtpServer.EnableSsl = true;//ssl

                    SmtpServer.Send(Mail);
                    LoggerClass.WriteLine(" *** ALERT!! Mail sent! [MainForm] ***");
                }
                catch (Exception Exception)
                {
                    //MessageBox.Show(ex.Message, "Email could not be tested", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine($" *** Error:{Exception.Message} [EmailSetup_Form] ***");
                }
            }
        }

        private void Email_checkBox_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the email checkbox is checked or unchecked 
                if (EmailCheckBox.Checked)
                {
                    Properties.Settings.Default.EmailCheckState = true;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Emails WILL be sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TimerStart();
                }
                else
                {
                    Properties.Settings.Default.EmailCheckState = false;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Emails will NOT be sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TimerStop(); 
                }
            }
            catch (Exception Exception)
            {
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\n");
                MessageBox.Show(Exception.Message, "Send email alert error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Startserver_checkBox_Click(object sender, EventArgs e)
        {
            try
            {
                //Set the registry to run the app on start or remove the registry entry
                RegistryKey Reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                string AppName = "FreeTAKServer_Manager";
                if (StartServerCheckBox.Checked)
                {
                    Reg.SetValue(AppName, Application.ExecutablePath);
                    Properties.Settings.Default.StartupServerCheckState = true;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Server will START at startup", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Reg.DeleteValue(AppName, false);
                    Properties.Settings.Default.StartupServerCheckState = false;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Server will NOT START at startup", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Exception)
            {
                LoggerClass.WriteLine($" *** Error:{Exception.Message} [MainForm] ***");
                LogsRichTextBox.AppendText($"[{DateTime.Now}] : Error:{Exception.Message}\n");
                MessageBox.Show(Exception.Message, "Send email alert error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void FreeTAKServerAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open the test API form
            using (Form Form = new FreeTAKServer_API_Form())
            {
                Form.ShowDialog();
                Form.Activate();
            }
        }

        private void TelegramAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open the test API form
            using (Form Form = new TelegramAPIForm())
            {
                Form.ShowDialog();
                Form.Activate();
            }
        }
    }
}
