using Microsoft.Win32;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PGS
{
    internal static class Initialization
    {
        // Gets and sets the registry values and updates the GUI.
        private static void UpdateMonitorValues()
        {
            // Import the values stored in the registry.
            object Monitor01 = Registry.GetValue("HKEY_CURRENT_USER\\Software\\PGS", "Monitor01_ID", "0");
            object Monitor02 = Registry.GetValue("HKEY_CURRENT_USER\\Software\\PGS", "Monitor02_ID", "0");

            // If the keys don't exist then create them.
            if (Monitor01 == null || Monitor02 == null)
            {
                // Create the registry values.
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\PGS", "Monitor01_ID", "1");
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\PGS", "Monitor02_ID", "2");

                // Set the monitor values.
                Globals.Monitor01_ID = "1";
                Globals.Monitor02_ID = "2";
            }
            // If the keys exist then pull them from the registry.
            else
            {
                Globals.Monitor01_ID = Monitor01.ToString();
                Globals.Monitor02_ID = Monitor02.ToString();
            }
            // Set the values of the numeric up/downs.
            Globals.MainDialog.Monitor01NumBox.Value = decimal.Parse(Monitor01.ToString(), CultureInfo.InvariantCulture);
            Globals.MainDialog.Monitor02NumBox.Value = decimal.Parse(Monitor02.ToString(), CultureInfo.InvariantCulture);
        }
        // Import to make the application DPI aware for high DPI displays.
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main(string[] Arguments)
        {
            // Enable form visual styles.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Get the folder this app is in.
            Globals.AppPath = Assembly.GetExecutingAssembly().Location;
            Globals.BaseFolder = Path.GetDirectoryName(Globals.AppPath);

            // Set the path of NirCMD.
            Globals.NirCMDPath = Globals.BaseFolder + "\\NirCMD\\nircmd.exe";

            // Check to see if arguments were actually passed.
            if (Arguments.Length > 0)
            {
                // Set the timer properties and start it.
                Functions.RunTimer.Interval = 1000;
                Functions.RunTimer.Tick += new EventHandler(Functions.TimerTick);
                Functions.RunTimer.Start();

                // Create the dialog.
                Globals.MainDialog = new Form_MainMenu();
                Globals.WaitDialog = new Form_WaitMenu();

                // Add the event handlers for stopping the timer here so VS2022 doesn't delete them.
                Globals.MainDialog.Click += new EventHandler(Functions.StopTimer);
                Globals.MainDialog.MainGroupBox.Click += new EventHandler(Functions.StopTimer);
                Globals.MainDialog.Monitor01.Click += new EventHandler(Functions.StopTimer);
                Globals.MainDialog.GameGroupBox.Click += new EventHandler(Functions.StopTimer);
                Globals.MainDialog.GameButton.Click += new EventHandler(Functions.StopTimer);
                Globals.MainDialog.Monitor02.Click += new EventHandler(Functions.StopTimer);
                Globals.MainDialog.GameTextBox.Click += new EventHandler(Functions.StopTimer);
                Globals.MainDialog.Monitor01NumBox.Click += new EventHandler(Functions.StopTimer);
                Globals.MainDialog.Monitor02NumBox.Click += new EventHandler(Functions.StopTimer);
                Globals.MainDialog.TimerLabel.Click += new EventHandler(Functions.StopTimer);

                // Put in its own method to cut down on fat.
                UpdateMonitorValues();

                // Loop through the arguments.
                foreach (var Arg in Arguments)
                {
                    // Grab the path from the arguments.
                    Globals.GamePath = Arg;
                }
                // Check to see if the image was created.
                if (Paths.Test(Globals.GamePath))
                {
                    // Get the file as an item.
                    FileItem GameItem = new FileItem(Globals.GamePath);

                    // Set the textbox to just the executable.
                    Globals.MainDialog.GameTextBox.Text = GameItem.Name;
                }
                // Show the main dialog.
                Globals.MainDialog.ShowDialog();
            }
            // If no arguments were passed, show an alternate dialog to create shortcuts.
            else
            {
                // Create the dialog.
                Globals.ShortDialog = new Form_ShortMenu();

                // Show the shortcut dialog.
                Globals.ShortDialog.ShowDialog();
            }
        }
    }
}
