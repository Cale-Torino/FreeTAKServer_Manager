using System;
using System.IO;
using System.Security.Cryptography;

namespace FTSManagerCheckMD5Hashes
{
    public static class GetHashClass
    {
        public static void CheckFileHash(string rootpath, string filename, string hash)
        {
            string[] files = Directory.GetFiles(rootpath, filename);

            foreach (string file in files)
            {
                if (hash == CalculateMD5(file))
                {
                    FileInfo fi = new FileInfo(file);
                    string data = $" => {Path.GetFileName(file)} | {CalculateMD5(file)} MATCH | {fi.Length / 1024} kb | {fi.Length} bytes";
                    Console.WriteLine(data);
                    WriteLine(data);
                }
                else
                {
                    FileInfo fi = new FileInfo(file);
                    string data = $" => {Path.GetFileName(file)} | {CalculateMD5(file)} ERROR | {fi.Length / 1024} kb | {fi.Length} bytes";
                    Console.WriteLine("Warning!!!");
                    Console.WriteLine(data);
                    WriteLine(data);
                }
            }
        }
        public static void CheckFile(string rootpath, string filename)
        {
            string[] files = Directory.GetFiles(rootpath, filename);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                string data = $" => {Path.GetFileName(file)} | {CalculateMD5(file)} | {fi.Length / 1024} kb | {fi.Length} bytes";
                Console.WriteLine(data);
                WriteLine(data);
            }
        }
        public static void GetAllFiles(string rootpath)
        {
            string[] files = Directory.GetFiles(rootpath, "*", SearchOption.AllDirectories);//Do not run on large directories!!
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                string data = $" => {Path.GetFileName(file)} | {CalculateMD5(file)} | {fi.Length/1024} kb | {fi.Length} bytes";
                Console.WriteLine(data);
                WriteLine(data);
            }
        }
        public static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var s = File.OpenRead(filename))
                {
                    return BitConverter.ToString(md5.ComputeHash(s)).Replace("-", string.Empty).ToLower();
                }
            }
        }
        private static readonly string LogFile = AppDomain.CurrentDomain.BaseDirectory + @"filelist_"+ DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".md5.txt";
        public static int WriteLine(string t)
        {
            try
            {
                File.AppendAllText(LogFile, t + "\n");
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
