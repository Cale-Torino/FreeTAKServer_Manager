using System;

namespace FTSManagerCheckMD5Hashes
{
    internal class Program
    {
        protected private static readonly string FreeTAKServer_Manager = "2749a98a110eed158a90a2e03653356c";
        protected private static readonly string CPOL = "e52b0358e338681f42115d3a850ec13b";
        protected private static readonly string config = "263656db8384903ffe32b654b1fc6bdc";
        protected private static readonly string MainConfig = "d419dea0cd177247eb5029fb8f58425a";
        protected private static readonly string ReadMe = "ebae1907ccfa63733c7210fe7b37e89c";
        protected private static readonly string requirements = "221c77e68241e4f4816bb3cdbdd7ebba";
        protected private static readonly string FTSConfig = "5cfcc29c0123102f4f011b9d3a91dc69";
        protected private static readonly string FTSManagerCheckMD5Hashes_bat = "b5e742a6684867c322c13a19c016c669";
        //protected private static readonly string FTSManagerCheckMD5Hashes_exe = "440028381e2c79898ab08c531bddbbf4";

        protected private static readonly string FreeTAKServer_Manager_WPF = "13680891f7edcdbe14472ad2f2f308ad";
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
