using System.Diagnostics;

namespace FreeTAKServer_Manager_WPF
{
    internal class ProcessClass
    {
        internal static void RunProcess(string Path)
        {
            using (Process Process = new Process())
            {
                Process.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = Path
                };
                Process.Start();
            }
        }
    }
}
