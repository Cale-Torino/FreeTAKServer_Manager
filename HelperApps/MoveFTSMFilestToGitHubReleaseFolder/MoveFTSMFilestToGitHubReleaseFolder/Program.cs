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
            //1.0.0.X
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
            string version = "1.0.0.X";
            MoveClass.CreateFolders(version);
            MoveClass.GetWinFormsFiles(version);
            MoveClass.GetWinWPFFiles(version);
            MoveClass.GetWinFormsInstaller(version);
            MoveClass.GetWinWPFInstallers(version);
        }
    }
}
