using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveFTSMFilestToGitHubReleaseFolder
{
    internal class MoveClass
    {
        internal void CreateFolders(string version)
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + $@"FreeTAKServer_Manager_Version_{version}\Installer\WinForms\");
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + $@"FreeTAKServer_Manager_Version_{version}\Installer\WPF\");
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + $@"FreeTAKServer_Manager_Version_{version}\Portable\WinForms\");
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + $@"FreeTAKServer_Manager_Version_{version}\Portable\WPF\");
        }
        internal void GetWinWPFFiles(string version)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"WPF\FreeTAKServer_Manager_WPF\bin\Release\";
            string copyto = AppDomain.CurrentDomain.BaseDirectory + $@"FreeTAKServer_Manager_Version_{version}\Portable\WPF\";
            string[] filez = Directory.GetFiles(path);
            foreach (string file in filez)
            {               
                File.Copy(file, $"{copyto}{Path.GetFileName(file)}", true);
                FileInfo fi = new FileInfo(file);
                Console.WriteLine($"Copied {Path.GetFileName(file)} | {fi.Length / 1024} kb {fi.Length} bytes");
            }
        }
        internal void GetWinFormsFiles(string version)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"WinForms\FreeTAKServer_Manager\bin\Release\";
            string copyto = AppDomain.CurrentDomain.BaseDirectory + $@"FreeTAKServer_Manager_Version_{version}\Portable\WinForms\";
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
        internal void GetWinWPFInstallers(string version)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"WPF\FreeTAKServer_Manager_WPF_Installer\Release\";
            string copyto = AppDomain.CurrentDomain.BaseDirectory + $@"FreeTAKServer_Manager_Version_{version}\Installer\WinForms\";
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
        internal void GetWinFormsInstaller(string version)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"WinForms\FreeTAKServer_Manager_Installer\Release\";
            string copyto = AppDomain.CurrentDomain.BaseDirectory + $@"FreeTAKServer_Manager_Version_{version}\Installer\WinForms\";
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
