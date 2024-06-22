using System;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using Tools;
using System.Drawing;

namespace PGS
{
    internal class Functions
    {
        public static Icon IconFromFilePath(string FilePath)
        {
            // Store the extracted icon in a variable.
            var IconFile = (Icon)null;

            // Try to extract the icon from the executable.
            try
            {
                // Most cases this will work but use a try anyway.
                IconFile = Icon.ExtractAssociatedIcon(FilePath);
            }
            // If it fails, fall back to the default icon.
            catch (Exception)
            {
                // This is the icon that is used by default anyway.
                IconFile = Properties.Resources.icon;
            }
            // Return whatever we got.
            return IconFile;
        }

        public static void BuildArguments(string[] Arguments)
        {
            // Check to see if there are additional arguments.
            if (Arguments.Length > 1)
            {
                // Loop through the remaining arguments.
                for (int i = 1; i < Arguments.Length; i++)
                {
                    // Add the arguments to the game arguments.
                    Config.GameArgs += Arguments[i] + " ";
                }
                // Trim the space from the final argument.
                Config.GameArgs.TrimEnd();
            }
        }

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
                    WShortCut.TargetPath = Config.AppPath;
                    WShortCut.Arguments = ArgsList;
                    WShortCut.WorkingDirectory = Config.BaseFolder;
                    WShortCut.IconLocation = RecievedFile;
                    WShortCut.Save();
                }
            }
        }

        public static void UpdateScreenInfo(bool FromConfigDialog)
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

            // This method can be called from config dialog or main dialog so update appropriate numeric up/down maximums.
            if (FromConfigDialog)
            {
                // While we're here, adjust the maximum value for the numeric up/downs.
                Forms.ConfigDialog.Monitor01NumBox.Maximum = Monitors.Length;
                Forms.ConfigDialog.Monitor02NumBox.Maximum = Monitors.Length;
            }
            else
            {
                // While we're here, adjust the maximum value for the numeric up/downs.
                Forms.MainDialog.Monitor01NumBox.Maximum = Monitors.Length;
                Forms.MainDialog.Monitor02NumBox.Maximum = Monitors.Length;
            }
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
    }
}
