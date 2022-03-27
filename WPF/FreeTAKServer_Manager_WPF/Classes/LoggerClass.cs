using System;
using System.IO;
using System.Windows;

namespace FreeTAKServer_Manager_WPF
{
    public static class LoggerClass
    {
            //Create logfile log. file
            private static readonly string LogFile = AppDomain.CurrentDomain.BaseDirectory + @"Logs\" + AppDomain.CurrentDomain.FriendlyName + "_" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".log";
            public static void WriteLine(string txt)
            {
                try
                {
                    //Write to the logfile
                    File.AppendAllText(LogFile, "[" + DateTime.Now.ToString() + "] : " + txt + "\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Could Not Append Text To Log File", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    MessageBox.Show(ex.ToString(), "Could Not Delete Log File", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        
    }
}
