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
                    var p = new ProcessStartInfo();
                    p.UseShellExecute = true;
                    p.WorkingDirectory = CMD_workingdir;//C:\Windows\System32
                    p.FileName = @"C:\Windows\System32\cmd.exe";
                    p.Verb = "runas";//run as admin
                    p.Arguments = CMD_command;
                    p.WindowStyle = ProcessWindowStyle.Normal;
                    Process _Process = Process.Start(p);
                    return _Process.Id;
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
                    var p = new ProcessStartInfo();
                    p.UseShellExecute = true;
                    p.WorkingDirectory = CMD_workingdir;//C:\Windows\System32
                    p.FileName = @"C:\Windows\System32\cmd.exe";
                    //p.Verb = "runas"; //run as admin
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
