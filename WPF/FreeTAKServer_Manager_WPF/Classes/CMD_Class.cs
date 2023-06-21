using System;
using System.Diagnostics;
using System.Windows;

namespace FreeTAKServer_Manager_WPF
{
    public static class CMD_Class
    {
            public static void PIDKill(int PID)
            {
                try
                {
                    //Kill the cmd process and close the window
                    Process Process = Process.GetProcessById(PID);
                    if (Process.MainWindowHandle != IntPtr.Zero)
                    {
                        Process.CloseMainWindow();
                    }
                    else
                    {
                        Process.Kill();
                        Process.Close();
                        Process.Dispose();
                    }

                }
                catch (Exception Exception)
                {
                    MessageBox.Show(Exception.Message, "Could not run Kill CMD PID", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            public static int CMDStartServer(string CMD_command, string CMD_workingdir)
            {
                try
                {
                    //Method to start cmd (for server) in the specified dir and run a command.
                    //Runs as admin to avoid conflicts.
                    var ProcessInfo = new ProcessStartInfo();
                    ProcessInfo.UseShellExecute = true;//use the OS shell
                    ProcessInfo.WorkingDirectory = CMD_workingdir;//e.g C:\Windows\System32
                    ProcessInfo.FileName = @"C:\Windows\System32\cmd.exe";//find cmd location
                    ProcessInfo.Verb = "runas";//run as admin
                    ProcessInfo.Arguments = CMD_command;//set your cmd command
                    ProcessInfo.WindowStyle = ProcessWindowStyle.Normal;//show the window `Normal` or `Hidden` to hide.
                    Process Process = Process.Start(ProcessInfo);//Initiate the process
                    return Process.Id;//Return PID
                }
                catch (Exception Exception)
                {
                    MessageBox.Show(Exception.Message, "Could not run command successfully", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 1;
                }
            }
            public static int SendCMDCommandNormal(string CMD_command, string CMD_workingdir)
            {
                try
                {
                    //Method to start cmd in the specified dir and run a command.
                    //Does not need admin priv
                    var ProcessInfo = new ProcessStartInfo();
                    ProcessInfo.UseShellExecute = true;
                    ProcessInfo.WorkingDirectory = CMD_workingdir;//C:\Windows\System32
                    ProcessInfo.FileName = @"C:\Windows\System32\cmd.exe";
                    ProcessInfo.Arguments = CMD_command;
                    ProcessInfo.WindowStyle = ProcessWindowStyle.Normal;
                    Process Process = Process.Start(ProcessInfo);
                    Process.WaitForExit();//wait for _Process to exit
                    return Process.Id;
                }
                catch (Exception Exception)
                {
                    MessageBox.Show(Exception.Message, "Could not run command successfully", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 1;
                }
            }
    }
}
