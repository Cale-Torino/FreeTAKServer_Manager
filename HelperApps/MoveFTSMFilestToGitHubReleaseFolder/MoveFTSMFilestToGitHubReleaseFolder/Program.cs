using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveFTSMFilestToGitHubReleaseFolder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("----------------------------------------------");
            Callmethods();
            Console.WriteLine("Copy Files Complete");
            Console.Beep();
            Console.ReadKey();
        }

        public static void Callmethods()
        {
            MoveClass.CreateFolders();
            MoveClass.GetWinFormsFiles();
            MoveClass.GetWinWPFFiles();
            MoveClass.GetWinFormsInstaller();
            MoveClass.GetWinWPFInstallers();
        }
    }
}
