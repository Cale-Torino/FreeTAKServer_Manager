using System;
using System.IO;
using System.Windows.Forms;

namespace FreeTAKServer_Manager
{
    class LoggerClass
    {
        public static class Logger
        {
            //Create logfile log. file
            private static string LogFile = Application.StartupPath + "\\Logs\\FreeTAKServer_Manager_" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".log";

            public static void WriteLine(string txt)
            {
                try
                {
                    //Write to the logfile
                    File.AppendAllText(LogFile, "[" + DateTime.Now.ToString() + "] : " + txt + "\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could Not Append Text To Log File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            public static void DeleteLog()
            {
                try
                {
                    //Delete the log file
                    File.Delete(LogFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could Not Delete Log File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
