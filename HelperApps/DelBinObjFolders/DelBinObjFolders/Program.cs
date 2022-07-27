using System;

namespace DelBinObjFolders
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
                Console.WriteLine("Delete Files Method Complete");
                Console.Beep();
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Delete Files Failed Please Add Switch");
                Console.Beep();
                Console.ReadKey();
            }
        }
        public static void Callmethods(string arg)
        {
            if (arg == "-Run")
            {
                DelClass del = new DelClass();
                //del.ListAllFolders($@"{AppDomain.CurrentDomain.BaseDirectory}");
                del.DelAllFilesAndFolder($@"{AppDomain.CurrentDomain.BaseDirectory}WinForms\FreeTAKServer_Manager\bin\");
                del.DelAllFilesAndFolder($@"{AppDomain.CurrentDomain.BaseDirectory}WinForms\FreeTAKServer_Manager\obj\");
                del.DelAllFilesAndFolder($@"{AppDomain.CurrentDomain.BaseDirectory}WPF\FreeTAKServer_Manager_WPF\bin\");
                del.DelAllFilesAndFolder($@"{AppDomain.CurrentDomain.BaseDirectory}WPF\FreeTAKServer_Manager_WPF\obj\");
            }
            else 
            {
                Console.WriteLine("Invalid Arg");
            }
        }
    }
}
