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
            Console.WriteLine($"Parameter count = {args.Length}");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"Arg[{i}] = [{args[i]}]");
            }
            Console.WriteLine("----------------------------------------------");
            if (args.Length > 0) 
            {
                Callmethods(args[0]);
                Console.WriteLine("Copy Files Complete");
                Console.Beep();
                Console.ReadKey();
            } 
            else 
            {
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("Copy Files Failed Please Add The Version Arg E.G: -1.0.0.7");
                Console.Beep();
                Console.ReadKey();
            }

        }

        public static void Callmethods(string version)
        {
            //string version = "1.0.0.X";
            MoveClass mc = new MoveClass();
            mc.CreateFolders(version);
            mc.GetWinFormsFiles(version);
            mc.GetWinWPFFiles(version);
            mc.GetWinFormsInstaller(version);
            mc.GetWinWPFInstallers(version);
        }
    }
}
