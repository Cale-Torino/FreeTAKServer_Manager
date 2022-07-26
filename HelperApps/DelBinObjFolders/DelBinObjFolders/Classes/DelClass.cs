using System;
using System.IO;

namespace DelBinObjFolders
{
    internal class DelClass
    {
        public static void DelAllFilesAndFolder(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine($"Scanning...");
                DirectoryInfo directory = new DirectoryInfo(path);
                foreach (FileInfo file in directory.EnumerateFiles())
                {
                    Console.WriteLine($"Deleted {Path.GetFileName(file.Name)}");
                    file.Delete();
                }
                foreach (DirectoryInfo dir in directory.EnumerateDirectories())
                {
                    Console.WriteLine($"Deleted {Path.GetFileName(dir.Name)}");
                    dir.Delete(true);
                }
            }
            else 
            {
                Console.WriteLine($"Directory Does Not Exist");
            }
        }

        public static void ListAllFolders(string basepath)
        {
            string[] folders = Directory.GetDirectories(basepath, "*", SearchOption.AllDirectories);
            foreach (string folder in folders)
            {
                Console.WriteLine($"{folder}");
            }
        }

        public static void GoUp2Dir()
        {
            string result = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\"));
            //var upTwoDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            //var result = x.Parent.Parent;
            Console.WriteLine($"{result}");
        }
    }
}
