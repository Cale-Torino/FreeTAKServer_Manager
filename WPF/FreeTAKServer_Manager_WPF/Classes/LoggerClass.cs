﻿using System;
using System.IO;
using System.Windows;

namespace FreeTAKServer_Manager_WPF
{
    class LoggerClass
    {
        public static class Logger
        {
            private static string LogFile = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\FreeTAKServer_Manager_WPF_" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".log";

            public static void WriteLine(string txt)
            {
                try
                {
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
}