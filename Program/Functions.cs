using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using Tools;

namespace PGS
{
    internal class Functions
    {
        public static void CreateShortcut()
        {
            // Get the path to the desktop.
            string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Create a new openfile dialog.
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.InitialDirectory = DesktopPath;
            FileDialog.Filter = "Game Executables | *.exe";
            FileDialog.ShowDialog();

            // Store the file that was returned.
            string RecievedFile = FileDialog.FileName;

            // Make sure the file has been set.
            if (RecievedFile != "")
            {
                // Build a string to assemble the arguments.
                string ArgsList = '"' + RecievedFile + '"' + " " + Forms.ShortDialog.ArgumentsTextBox.Text;

                // Create a new openfolder dialog.
                FolderSelectDialog FolderDialog = new FolderSelectDialog();
                FolderDialog.InitialDirectory = DesktopPath;
                FolderDialog.Title = "Select Shortcut Destination";
                FolderDialog.Show();

                // Store the file that was returned.
                string RecievedFolder = FolderDialog.FileName;

                // Make sure the folder has been set.
                if (RecievedFolder != "")
                {
                    // Get the file as an item.
                    FileItem GameItem = new FileItem(RecievedFile);

                    // Set the path to the shortcut.
                    string ShortcutPath = RecievedFolder + "\\" + GameItem.BaseName + ".lnk";

                    // Use windows script host to create a shortcut.
                    WshShell WShell = new WshShell();
                    IWshShortcut WShortCut = (IWshShortcut)WShell.CreateShortcut(ShortcutPath);
                    WShortCut.TargetPath = Globals.AppPath;
                    WShortCut.Arguments = ArgsList;
                    WShortCut.WorkingDirectory = Globals.BaseFolder;
                    WShortCut.IconLocation = RecievedFile;
                    WShortCut.Save();
                }
            }
        }
        public static void UpdateScreenInfo()
        {
            // Monitor ID reference variables.
            int IntID = 0;
            string StringID = "";

            // The array of screens and its length.
            Screen[] Monitors = Screen.AllScreens;
            int ArraySize = Monitors.Length;

            // Info stored to print to the textbox.
            string[] ScrName = new string[ArraySize];
            string[] ScrWidth = new string[ArraySize];
            string[] ScrHeight = new string[ArraySize];
            string[] ScrDims = new string[ArraySize];
            string[] ScrPrime = new string[ArraySize];

            // The total compilation of info.
            string DisplayInfo = "";

            // While we're here, adjust the maximum value for the numeric up/downs.
            Forms.MainDialog.Monitor01NumBox.Maximum = Monitors.Length;
            Forms.MainDialog.Monitor02NumBox.Maximum = Monitors.Length;

            // It turns out "DeviceFriendlyName" always returns the list "in order" starting with index [0] so store them as they are recieved.
            foreach (Screen Monitor in Monitors)
            {
                // I have no idea why it works this way, but it returns the list from lowest index [0] to highest index [number of screens - 1].
                ScrName[IntID] = Monitor.DeviceFriendlyName() + "{0}";

                // Since it's in order, we can just reference the loop ID.
                IntID++;
            }
            // Looping through screens processes them "out of order" (ex: 3,1,4,2) so force reordering them in an array based on their index.
            foreach (Screen Monitor in Monitors)
            {
                // Get the display name (DISPLAY1, DISPLAY2, etc) which starts with index [1] and extract the ID number.
                StringID = Monitor.DeviceName;
                StringID = StringID.Substring(StringID.Length - 1, 1);

                // Subtract one to match the zero based indexes. 
                IntID = Int32.Parse(StringID) - 1;

                // Get the width and height of the screen.
                ScrWidth[IntID] = Monitor.Bounds.Width.ToString();
                ScrHeight[IntID] = Monitor.Bounds.Height.ToString();

                // Assemble the resolution.
                ScrDims[IntID] = "Resolution: " + ScrWidth[IntID] + "x" + ScrHeight[IntID] + "{0}";

                // Get the primary status of the screen.
                ScrPrime[IntID] = "Primary: " + Monitor.Primary.ToString() + "{0}";
            }
            // Now that we have all the information in order, compile it together in a string.
            for (int i = 0; i < ArraySize; i++)
            {
                // Because all of the info is now in order, we can just use the current loop iteration as the ID.
                StringID = "Monitor ID: " + (i + 1).ToString() + "{0}";

                // Add the information to the string.
                DisplayInfo += ScrName[i];
                DisplayInfo += ScrDims[i];
                DisplayInfo += ScrPrime[i];
                DisplayInfo += StringID;
                DisplayInfo += "{0}";
            }
            // Format the text to put each entry onto a new line.
            DisplayInfo = String.Format(DisplayInfo, Environment.NewLine);

            // Add the text to the rich textbox.
            Forms.InfoDialog.InfoRichTextBox.Text = DisplayInfo;
        }
        public static void UpdateMonitorValues()
        {
            // Import the values stored in the registry.
            object Monitor01 = Registry.GetValue("HKEY_CURRENT_USER\\Software\\PGS\\Values", "Monitor01_ID", "0");
            object Monitor02 = Registry.GetValue("HKEY_CURRENT_USER\\Software\\PGS\\Values", "Monitor02_ID", "0");
            object Countdown = Registry.GetValue("HKEY_CURRENT_USER\\Software\\PGS\\Values", "Countdown", "0");

            // If the keys don't exist then create them.
            if (Monitor01 == null || Monitor02 == null || Countdown == null)
            {
                // Create the registry values.
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\PGS\\Values", "Monitor01_ID", "1");
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\PGS\\Values", "Monitor02_ID", "2");
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\PGS\\Values", "Countdown", "5");

                // Set the monitor values.
                Globals.Monitor01_ID = "1";
                Globals.Monitor02_ID = "2";
                StartTimer.Countdown = 5;
            }
            // If the keys exist then pull them from the registry.
            else
            {
                Globals.Monitor01_ID = Monitor01.ToString();
                Globals.Monitor02_ID = Monitor02.ToString();
                StartTimer.Countdown = Int32.Parse(Countdown.ToString());
            }
            // Set the values of the numeric up/downs.
            Forms.MainDialog.Monitor01NumBox.Value = decimal.Parse(Monitor01.ToString(), CultureInfo.InvariantCulture);
            Forms.MainDialog.Monitor02NumBox.Value = decimal.Parse(Monitor02.ToString(), CultureInfo.InvariantCulture);
            Forms.MainDialog.TimerLabel.Text = StartTimer.Countdown.ToString();
        }
        public static void SetPrimaryAndLaunch()
        {
            // Update the registry values with the current selections.
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\PGS\\Values", "Monitor01_ID", Globals.Monitor01_ID);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\PGS\\Values", "Monitor02_ID", Globals.Monitor02_ID);

            // Hid the dialog.
            Forms.MainDialog.Hide();
            Forms.WaitDialog.Show();

            // The function to swap monitors takes an unsigned integer.
            uint uMonitor01_ID = UInt32.Parse(Globals.Monitor01_ID) - 1;
            uint uMonitor02_ID = UInt32.Parse(Globals.Monitor02_ID) - 1;

            // Set the primary display to the secondary monitor.
            Monitors.SetAsPrimaryMonitor(uMonitor02_ID);

            // Get the game as an item to get the raw directory.
            FileItem GameItem = new FileItem(Globals.GamePath);

            // Set the primary display to the secondary monitor.
            Process GameProcess = new Process();
            GameProcess.StartInfo.WorkingDirectory = GameItem.DirectoryName;
            GameProcess.StartInfo.FileName = Globals.GamePath;
            GameProcess.StartInfo.Arguments = "";
            GameProcess.StartInfo.UseShellExecute = false;
            GameProcess.StartInfo.RedirectStandardOutput = false;
            GameProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            GameProcess.Start();
    
            // Wait until the game closes before restoring the display.
            GameProcess.WaitForExit();

            // Set the primary display to the primary monitor.
            Monitors.SetAsPrimaryMonitor(uMonitor01_ID);
        }
    }
}
