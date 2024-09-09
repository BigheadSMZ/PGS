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

            // Adjust the maximum value for the numeric up/downs based on the source of the call.
            if (FromConfigDialog)
            {
                Forms.ConfigDialog.Monitor01NumBox.Maximum = Monitors.Length;
                Forms.ConfigDialog.Monitor02NumBox.Maximum = Monitors.Length;
            }
            else
            {
                Forms.MainDialog.Monitor01NumBox.Maximum = Monitors.Length;
                Forms.MainDialog.Monitor02NumBox.Maximum = Monitors.Length;
            }

            // Store monitor names as they are received.
            for (int i = 0; i < Monitors.Length; i++)
            {
                ScrName[i] = Monitors[i].DeviceFriendlyName() + "{0}";
            }

            // Looping through monitors, extracting and storing their info based on their device name.
            foreach (Screen Monitor in Monitors)
            {
                // Extract the last character of the device name to use as the screen's ID.
                StringID = Monitor.DeviceName;
                if (StringID.Length > 0)
                {
                    // Get the last character of the device name (assuming it ends with a number).
                    StringID = StringID.Substring(StringID.Length - 1, 1);

                    // Try to parse the StringID as an integer.
                    if (int.TryParse(StringID, out int parsedID))
                    {
                        // Subtract 1 to convert to a zero-based index.
                        IntID = parsedID - 1;

                        // Validate that IntID is within bounds.
                        if (IntID >= 0 && IntID < ArraySize)
                        {
                            // Get screen width and height.
                            ScrWidth[IntID] = Monitor.Bounds.Width.ToString();
                            ScrHeight[IntID] = Monitor.Bounds.Height.ToString();

                            // Assemble resolution and primary status.
                            ScrDims[IntID] = "Resolution: " + ScrWidth[IntID] + "x" + ScrHeight[IntID] + "{0}";
                            ScrPrime[IntID] = "Primary: " + Monitor.Primary.ToString() + "{0}";
                        }
                        else
                        {
                            // Log or handle the error if IntID is out of range.
                            Console.WriteLine($"IntID {IntID} is out of bounds for monitor {Monitor.DeviceName}");
                        }
                    }
                    else
                    {
                        // Log or handle the error if parsing fails.
                        Console.WriteLine($"Failed to parse screen ID from device name: {Monitor.DeviceName}");
                    }
                }
                else
                {
                    // Log or handle the error if the device name is empty or invalid.
                    Console.WriteLine("Device name is empty or invalid.");
                }
            }

            // Compile the information into a display string.
            for (int i = 0; i < ArraySize; i++)
            {
                // Use the current loop iteration as the ID (adjusting to one-based).
                StringID = "Monitor ID: " + (i + 1).ToString() + "{0}";

                // Add the information to the display string.
                DisplayInfo += ScrName[i];
                DisplayInfo += ScrDims[i];
                DisplayInfo += ScrPrime[i];
                DisplayInfo += StringID;
                DisplayInfo += "{0}";
            }

            // Format the text to put each entry onto a new line.
            DisplayInfo = String.Format(DisplayInfo, Environment.NewLine);

            // Add the text to the rich text box.
            Forms.InfoDialog.InfoRichTextBox.Text = DisplayInfo;
        }

    }
}
