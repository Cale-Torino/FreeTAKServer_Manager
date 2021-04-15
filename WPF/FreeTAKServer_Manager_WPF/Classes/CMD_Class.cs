using System;
using System.Diagnostics;
using System.Windows;

namespace FreeTAKServer_Manager_WPF
{
    class CMD_Class
    {
        public static class CMD_Instance
        {
            public static void PIDkill(int PID)
            {
                try
                {
                    //Kill the cmd process and close the window
                    Process p = Process.GetProcessById(PID);
                    if (p.MainWindowHandle != IntPtr.Zero)
                    {
                        p.CloseMainWindow();
                    }
                    else
                    {
                        p.Kill();
                        p.Close();
                        p.Dispose();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not run Kill CMD PID", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            public static int CMDStartServer(string CMD_command, string CMD_workingdir)
            {
                try
                {
                    //Method to start cmd (for server) in the specified dir and run a command.
                    //Runs as admin to avoid conflicts.
                    var p = new ProcessStartInfo();
                    p.UseShellExecute = true;//use the OS shell
                    p.WorkingDirectory = CMD_workingdir;//e.g C:\Windows\System32
                    p.FileName = @"C:\Windows\System32\cmd.exe";//find cmd location
                    p.Verb = "runas";//run as admin
                    p.Arguments = CMD_command;//set your cmd command
                    p.WindowStyle = ProcessWindowStyle.Normal;//show the window `Normal` or `Hidden` to hide.
                    Process _Process = Process.Start(p);//Initiate the process
                    return _Process.Id;//Return PID
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not run command successfully", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 1;
                }
            }
            public static int SendCMDCommandNormal(string CMD_command, string CMD_workingdir)
            {
                try
                {
                    //Method to start cmd in the specified dir and run a command.
                    //Does not need admin priv
                    var p = new ProcessStartInfo();
                    p.UseShellExecute = true;
                    p.WorkingDirectory = CMD_workingdir;//C:\Windows\System32
                    p.FileName = @"C:\Windows\System32\cmd.exe";
                    p.Arguments = CMD_command;
                    p.WindowStyle = ProcessWindowStyle.Normal;
                    Process _Process = Process.Start(p);
                    _Process.WaitForExit();//wait for _Process to exit
                    return _Process.Id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not run command successfully", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 1;
                }
            }


        }


    }
}
