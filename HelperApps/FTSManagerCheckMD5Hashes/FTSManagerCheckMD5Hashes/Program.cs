using System;

namespace FTSManagerCheckMD5Hashes
{
    internal class Program
    {
        protected private static readonly string FreeTAKServer_Manager = "3a5643fd77e37063a6cc358d58917cfd";
        protected private static readonly string CPOL = "e52b0358e338681f42115d3a850ec13b";
        protected private static readonly string config = "e2f408e9728448cc1f08ed8bdebbbe5c";
        protected private static readonly string MainConfig = "62d20d89c0d0be45ee44f9ca20a1d678";
        protected private static readonly string ReadMe = "6fd05949a8a8c6e4ce79168eeab361b6";
        protected private static readonly string requirements = "221c77e68241e4f4816bb3cdbdd7ebba";
        protected private static readonly string FTSConfig = "5cfcc29c0123102f4f011b9d3a91dc69";
        protected private static readonly string FTSManagerCheckMD5Hashes_bat = "b5e742a6684867c322c13a19c016c669";
        //protected private static readonly string FTSManagerCheckMD5Hashes_exe = "440028381e2c79898ab08c531bddbbf4";

        protected private static readonly string FreeTAKServer_Manager_WPF = "78ae0770210e359fc1737d6be928c91e";
        //protected private static readonly string GUPxmlWinForms = "4238c89b048797a24726df050f1eb86c";
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"Arg[{i}] = [{args[i]}]");
            }
            if (args[0] == "-Run")
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().Location);
                Console.WriteLine("----------------------------------------------");
                GetHashClass ghc = new GetHashClass();
                try
                {
                    ghc.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "FreeTAKServer_Manager.exe", FreeTAKServer_Manager);
                    ghc.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "Licenses\\CPOL.htm", CPOL);
                    ghc.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "PythonScripts\\config.py", config);
                    ghc.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "PythonScripts\\MainConfig.py", MainConfig);
                    ghc.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "TextFiles\\ReadMe.txt", ReadMe);
                    ghc.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "TextFiles\\requirements.txt", requirements);
                    ghc.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "YamlScripts\\FTSConfig.yaml", FTSConfig);
                    ghc.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "FTSManagerCheckMD5Hashes.bat", FTSManagerCheckMD5Hashes_bat);
                    //ghc.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "FTSManagerCheckMD5Hashes.exee", FreeTAKServer_Manager);

                    ghc.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "FreeTAKServer_Manager_WPF.exe", FreeTAKServer_Manager_WPF);
                    //ghc.CheckFileHash($"{AppDomain.CurrentDomain.BaseDirectory}\\Updater", "gup.xml", GUPxmlWinForms);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:"+ ex);
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("MD5 list complete");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid Arg");
                Console.ReadLine();
            }
        }
    }
}
