using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FreeTAKServer_Manager
{
    public static class RunUpdateExeClass
    {
        public static void RunExeActions()
        {
            string pathToFile = Application.StartupPath + @"\Updater\GUP.exe";
            Process runProg = new Process();
            try
            {
                runProg.StartInfo.FileName = pathToFile;
                runProg.StartInfo.CreateNoWindow = false;
                runProg.StartInfo.WorkingDirectory = Application.StartupPath + @"\Updater";
                //runProg.StartInfo.Verb = "runas";
                runProg.Start();
                runProg.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Could Not Run: GUP.exe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
