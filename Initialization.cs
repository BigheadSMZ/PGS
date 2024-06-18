using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PGS
{
    internal static class Initialization
    {
        // Import to make the application DPI aware for high DPI displays.
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main(string[] Arguments)
        {
            // Enable form visual styles.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Make the application DPI Aware so it can be scaled.
            SetProcessDPIAware();

            // Initialize the DPI and Monitor values.
            DPI.Init();

            // Get the folder this app is in.
            Globals.AppPath = Assembly.GetExecutingAssembly().Location;
            Globals.BaseFolder = Path.GetDirectoryName(Globals.AppPath);

            // The number of arguments determines the GUI shown. 0: Create Shortcuts, 1: Launch Game
            switch (Arguments.Length)
            {
                // If no arguments were passed, show the dialog to create shortcuts.
                case 0:  { Forms.ShowShortcutGUI(); break; }

                // If arguments have been passed, show the GUI to configure monitors and launch the game.
                default: { Forms.ShowGameLaunchGUI(Arguments); break; }
            }
        }
    }
}
