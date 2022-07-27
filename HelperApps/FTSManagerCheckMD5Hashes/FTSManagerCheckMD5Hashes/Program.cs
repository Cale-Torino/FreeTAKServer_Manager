using System;

namespace FTSManagerCheckMD5Hashes
{
    internal class Program
    {
        protected private static readonly string FreeTAKServer_Manager = "9a5d24245a6aa392de88448abed62204";
        protected private static readonly string FreeTAKServer_Manager_WPF = "440028381e2c79898ab08c531bddbbf4";
        protected private static readonly string GUPexe = "9ab985908d9fe9a2d536b5fd23974287";
        protected private static readonly string GUPxmlWPF = "9f1ee248cfc342b8f5442e031f8b985a";
        //protected private static readonly string GUPxmlWinForms = "4238c89b048797a24726df050f1eb86c";
        protected private static readonly string Libcurldll = "11f4a27b9612987255757dbb96d6f420";
        static void Main(string[] args)
        {            
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Console.WriteLine("----------------------------------------------");
            GetHashClass ghc = new GetHashClass();
            ghc.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "FreeTAKServer_Manager.exe", FreeTAKServer_Manager);
            ghc.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "FreeTAKServer_Manager_WPF.exe", FreeTAKServer_Manager_WPF);
            ghc.CheckFileHash($"{AppDomain.CurrentDomain.BaseDirectory}\\Updater", "GUP.exe", GUPexe);
            //ghc.CheckFileHash($"{AppDomain.CurrentDomain.BaseDirectory}\\Updater", "gup.xml", GUPxmlWinForms);
            ghc.CheckFileHash($"{AppDomain.CurrentDomain.BaseDirectory}\\Updater", "gup.xml", GUPxmlWPF);
            ghc.CheckFileHash($"{AppDomain.CurrentDomain.BaseDirectory}\\Updater", "libcurl.dll", Libcurldll);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("MD5 list complete");
            Console.ReadLine();
        }
    }
}
