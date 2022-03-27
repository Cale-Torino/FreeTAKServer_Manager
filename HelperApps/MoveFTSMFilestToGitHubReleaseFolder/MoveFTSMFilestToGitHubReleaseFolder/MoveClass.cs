using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveFTSMFilestToGitHubReleaseFolder
{
    public static class MoveClass
    {
        public static void CreateFolders()
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"FreeTAKServer_Manager_Version_1.0.0.X\Installer\WinForms\");
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"FreeTAKServer_Manager_Version_1.0.0.X\Installer\WPF\");
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"FreeTAKServer_Manager_Version_1.0.0.X\Portable\WinForms\");
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"FreeTAKServer_Manager_Version_1.0.0.X\Portable\WPF\");
        }
        public static void GetWinWPFFiles()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"WPF\FreeTAKServer_Manager_WPF\bin\Release\";
            string copyto = AppDomain.CurrentDomain.BaseDirectory + @"FreeTAKServer_Manager_Version_1.0.0.X\Portable\WPF\";
            string[] filez = Directory.GetFiles(path);
            foreach (string file in filez)
            {               
                File.Copy(file, $"{copyto}{Path.GetFileName(file)}", true);
                FileInfo fi = new FileInfo(file);
                Console.WriteLine($"Copied {Path.GetFileName(file)} | {fi.Length / 1024} kb {fi.Length} bytes");
            }
        }
        public static void GetWinFormsFiles()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"WinForms\FreeTAKServer_Manager\bin\Release\";
            string copyto = AppDomain.CurrentDomain.BaseDirectory + @"FreeTAKServer_Manager_Version_1.0.0.X\Portable\WinForms\";
            string[] filez = Directory.GetFiles(path);
            foreach (string file in filez)
            {
                File.Copy(file, $"{copyto}{Path.GetFileName(file)}", true);
                FileInfo fi = new FileInfo(file);
                Console.WriteLine($"Copied {Path.GetFileName(file)} | {fi.Length / 1024} kb {fi.Length} bytes");
            }
            if (File.Exists($"{copyto}FreeTAKServer_Manager.pdb"))
            {
                File.Delete($"{copyto}FreeTAKServer_Manager.pdb");
            }
        }
        public static void GetWinWPFInstallers()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"WPF\FreeTAKServer_Manager_WPF_Installer\Release\";
            string copyto = AppDomain.CurrentDomain.BaseDirectory + @"FreeTAKServer_Manager_Version_1.0.0.X\Installer\WinForms\";
            string[] filez = Directory.GetFiles(path);
            foreach (string file in filez)
            {
                File.Copy(file, $"{copyto}{Path.GetFileName(file)}", true);
                FileInfo fi = new FileInfo(file);
                Console.WriteLine($"Copied {Path.GetFileName(file)} | {fi.Length / 1024} kb {fi.Length} bytes");
            }
            if (File.Exists($"{copyto}setup.exe"))
            {
                File.Delete($"{copyto}setup.exe");
            }
        }
        public static void GetWinFormsInstaller()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"WinForms\FreeTAKServer_Manager_Installer\Release\";
            string copyto = AppDomain.CurrentDomain.BaseDirectory + @"FreeTAKServer_Manager_Version_1.0.0.X\Installer\WinForms\";
            string[] filez = Directory.GetFiles(path);
            foreach (string file in filez)
            {
                File.Copy(file, $"{copyto}{Path.GetFileName(file)}", true);
                FileInfo fi = new FileInfo(file);
                Console.WriteLine($"Copied {Path.GetFileName(file)} | {fi.Length / 1024} kb {fi.Length} bytes");
            }
            if (File.Exists($"{copyto}setup.exe"))
            {
                File.Delete($"{copyto}setup.exe");
            }
        }
    }
}
