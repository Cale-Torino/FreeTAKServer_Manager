using System;
using System.Diagnostics;
using System.Windows;

namespace FreeTAKServer_Manager_WPF
{
    class RunUpdateExeClass
    {
        public static void RunExeActions()
        {
            string pathToFile = AppDomain.CurrentDomain.BaseDirectory + @"\Updater\GUP.exe";
            Process runProg = new Process();
            try
            {
                runProg.StartInfo.FileName = pathToFile;
                runProg.StartInfo.CreateNoWindow = false;
                runProg.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\Updater";
                //runProg.StartInfo.Verb = "runas";
                runProg.Start();
                runProg.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Could Not Run: GUP.exe", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
