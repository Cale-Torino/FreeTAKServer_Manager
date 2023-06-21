using System.Diagnostics;

namespace FreeTAKServer_Manager_WPF
{
    internal class ProcessClass
    {
        internal static void RunProcess(string path)
        {
            using (Process Process = new Process())
            {
                Process.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = path
                };
                Process.Start();
            }
        }
    }
}
