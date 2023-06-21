using System;
using System.IO;
using System.Windows;

namespace FreeTAKServer_Manager_WPF
{
    internal class LoggerClass
    {
        //Create logfile log. file
        internal static string LogFile { get; set; } = $@"{AppDomain.CurrentDomain.BaseDirectory}Logs\{AppDomain.CurrentDomain.FriendlyName}_{DateTime.Now:yyyy-dd-M--HH-mm-ss}.log";
        public static void WriteLine(string Text)
            {
                try
                {
                    //Write to the logfile
                    File.AppendAllText(LogFile, $"[{DateTime.Now}] : {Text}\n");
                 }
                catch (Exception Exception)
                {
                    MessageBox.Show(Exception.ToString(), "Could Not Append Text To Log File", MessageBoxButton.OK, MessageBoxImage.Error);
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
                catch (Exception Exception)
                {
                    MessageBox.Show(Exception.ToString(), "Could Not Delete Log File", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        
    }
}
