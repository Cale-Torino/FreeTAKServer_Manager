using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FreeTAKServer_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        private static void SetCursor()
        {
            try
            {
                typeof(Cursors).GetField("hand", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, SystemHandCursor);
            }
            catch {
                    //do nothing
                  }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadCursor(IntPtr Instance, int CursorName);

        private static readonly Cursor SystemHandCursor = new Cursor(LoadCursor(IntPtr.Zero, 32649 /*IDC_HAND*/));
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetCursor();
            Application.Run(new MainForm());
        }
    }
}
