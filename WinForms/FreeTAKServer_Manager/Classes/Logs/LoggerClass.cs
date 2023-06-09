using System;
using System.IO;
using System.Windows.Forms;

namespace FreeTAKServer_Manager
{
    internal class LoggerClass
    {
        //Create logfile log. file
        internal static string LogFile { get; set; } = $@"{AppDomain.CurrentDomain.BaseDirectory}Logs\{AppDomain.CurrentDomain.FriendlyName}_{DateTime.Now:yyyy-dd-M--HH-mm-ss}.log";

        internal static void WriteLine(string Text)
        {
            try
            {
                //Write to the logfile
                File.AppendAllText(LogFile, $"[{DateTime.Now}] : {Text}\n");
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Could Not Append Text To Log File", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message, "Could Not Delete Log File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

    }
}
