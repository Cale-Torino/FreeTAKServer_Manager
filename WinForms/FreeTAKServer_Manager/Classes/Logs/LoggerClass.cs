using System;
using System.IO;
using System.Windows.Forms;

namespace FreeTAKServer_Manager
{
    internal class LoggerClass
    {
        //Create logfile log. file
        internal static string LogFile { get; set; } = $@"{AppDomain.CurrentDomain.BaseDirectory}Logs\{AppDomain.CurrentDomain.FriendlyName}_{DateTime.Now:yyyy-dd-M--HH-mm-ss}.log";

        internal static void WriteLine(string txt)
        {
            try
            {
                //Write to the logfile
                File.AppendAllText(LogFile, $"[{DateTime.Now}] : {txt}\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could Not Append Text To Log File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        internal static void DeleteLog()
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
