using System;
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
            // Set the version of the program.
            Config.PGSVersion = "1.4.2";

            // Enable form visual styles.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Make the application DPI Aware so it can be scaled.
            SetProcessDPIAware();

            // Initialize the DPI and Monitor values.
            DPI.Init();

            // Set common variables that are used in the program.
            Config.SetApplicationValues();

            // If there are no arguments launch the "Create Shortcut" GUI.
            if (Arguments.Length == 0) { Launch.ShortcutGUI(); }

            // There was at least one argument.
            else
            {
                // The very first argument should be the game path.
                Config.GamePath = Arguments[0];

                // Test the game path and make sure it exists.
                if (Paths.Test(Config.GamePath))
                {
                    // Builds arguments list for game.
                    Functions.BuildArguments(Arguments);

                    // If the user skipped the GUI load the game now.
                    if (Config.NoGUI) { Launch.GameAndPrimary(); }

                    // The GUI was not skipped so launch the "Game Launch" GUI.
                    else { Launch.GameLaunchGUI(Arguments); }
                }
                // The first argument did not check out so launch the "Error" GUI.
                else { Launch.ErrorGUI(); }
            }
        }
    }
}
