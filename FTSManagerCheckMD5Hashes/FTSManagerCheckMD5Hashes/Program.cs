using System;

namespace FTSManagerCheckMD5Hashes
{
    internal class Program
    {
        protected private static readonly string FreeTAKServer_Manager = "74992c411d07d22c7d6e73daef0ed457";
        protected private static readonly string FreeTAKServer_Manager_WPF = "74992c411d07d22c7d6e73daef0ed457";
        protected private static readonly string Cryptographydll = "74992c411d07d22c7d6e73daef0ed457";
        protected private static readonly string Cryptographyxml = "74992c411d07d22c7d6e73daef0ed457";
        protected private static readonly string GUPexe = "74992c411d07d22c7d6e73daef0ed457";
        protected private static readonly string GUPxml = "74992c411d07d22c7d6e73daef0ed457";
        protected private static readonly string Libcurldll = "74992c411d07d22c7d6e73daef0ed457";
        static void Main(string[] args)
        {            
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Console.WriteLine("----------------------------------------------");
            GetHashClass.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "FreeTAKServer_Manager.exe", FreeTAKServer_Manager);
            GetHashClass.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "FreeTAKServer_Manager_WPF.exe", FreeTAKServer_Manager_WPF);
            GetHashClass.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "System.Security.Cryptography.ProtectedData.dll", Cryptographydll);
            GetHashClass.CheckFileHash(AppDomain.CurrentDomain.BaseDirectory, "System.Security.Cryptography.ProtectedData.xml", Cryptographyxml);
            GetHashClass.CheckFileHash($"{AppDomain.CurrentDomain.BaseDirectory}\\Updater", "GUP.exe", GUPexe);
            GetHashClass.CheckFileHash($"{AppDomain.CurrentDomain.BaseDirectory}\\Updater", "gup.xml", GUPxml);
            GetHashClass.CheckFileHash($"{AppDomain.CurrentDomain.BaseDirectory}\\Updater", "libcurl.dll", Libcurldll);
            /*GetHashClass.CheckFile(AppDomain.CurrentDomain.BaseDirectory, "FreeTAKServer_Manager.exe");
            GetHashClass.CheckFile(AppDomain.CurrentDomain.BaseDirectory, "FreeTAKServer_Manager_WPF.exe");
            GetHashClass.CheckFile(AppDomain.CurrentDomain.BaseDirectory, "System.Security.Cryptography.ProtectedData.dll");
            GetHashClass.CheckFile(AppDomain.CurrentDomain.BaseDirectory, "System.Security.Cryptography.ProtectedData.xml");
            GetHashClass.CheckFile($"{AppDomain.CurrentDomain.BaseDirectory}\\Updater", "GUP.exe");
            GetHashClass.CheckFile($"{AppDomain.CurrentDomain.BaseDirectory}\\Updater", "gup.xml");
            GetHashClass.CheckFile($"{AppDomain.CurrentDomain.BaseDirectory}\\Updater", "libcurl.dll");*/
            //GetHashClass.GetAllFiles(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("MD5 list complete");
            Console.ReadLine();
        }
    }
}
