using System.Diagnostics;
using System;
using System.Drawing;
using System.Globalization;
using IconsRestorer.ViewModels;

namespace PGS
{
    internal class Launch
    {
        public static void ShortcutGUI()
        {
            // Create the dialog.
            Forms.ShortDialog  = new Form_ShortMenu();
            Forms.ConfigDialog = new Form_ConfigMenu();
            Forms.InfoDialog   = new Form_ScreenInfo();

            // Scale the shortcut dialog.
            Forms.ScaleConfigDialog();
            Forms.ScaleShortcutDialog();
            Forms.ScaleInfoDialog();

            // Update the info form to show screen information.
            Functions.UpdateScreenInfo(true);

            // Hide the arguments by default.
            Forms.ArgumentsToggle();

            // Update the values on the GUI.
            Forms.ConfigDialog.Monitor01NumBox.Value = decimal.Parse(Config.Monitor01_ID, CultureInfo.InvariantCulture);
            Forms.ConfigDialog.Monitor02NumBox.Value = decimal.Parse(Config.Monitor02_ID, CultureInfo.InvariantCulture);
            Forms.ConfigDialog.CountdownNumBox.Value = decimal.Parse(Config.Countdown, CultureInfo.InvariantCulture);
            Forms.ConfigDialog.NoGUICheckBox.Checked = Config.NoGUI;
            Forms.ConfigDialog.NoTimerCheckbox.Checked = Config.NoTimer;
            Forms.ConfigDialog.DesktopIconsCheckbox.Checked = Config.SaveIconPos;

            // Show the shortcut dialog.
            Forms.ShortDialog.ShowDialog();

            // Update the values in the configuration file.
            Config.WriteINIValues();
        }

        public static void ErrorGUI()
        {
            // If it doesn't exist, show the error dialog.
            Forms.ErrorDialog = new Form_ErrorMenu();

            // Scale it for DPI.
            Forms.ScaleErrorDialog();

            // Show the shortcut dialog.
            Forms.ErrorDialog.ShowDialog();
        }

        public static void GameLaunchGUI(string[] Arguments)
        {
            // Try to get the icon from the executable.
            Icon FormIcon = Functions.IconFromFilePath(Config.GamePath);

            // Create the dialogs.
            Forms.MainDialog = new Form_MainMenu();
            Forms.InfoDialog = new Form_ScreenInfo();
            Forms.WaitDialog = new Form_WaitMenu();

            // Set the icon to the form.
            Forms.MainDialog.Icon = FormIcon;

            // Scale the dialogs with DPI.
            Forms.ScaleMainDialog();
            Forms.ScaleWaitDialog();
            Forms.ScaleInfoDialog();

            // Update the info form to show screen information.
            Functions.UpdateScreenInfo(false);

            // Set the timer value.
            GameTimer.Countdown = Int32.Parse(Config.Countdown);
            Forms.MainDialog.TimerLabel.Text = Config.Countdown;

            // Update the values on the GUI.
            Forms.MainDialog.Monitor01NumBox.Value = decimal.Parse(Config.Monitor01_ID, CultureInfo.InvariantCulture);
            Forms.MainDialog.Monitor02NumBox.Value = decimal.Parse(Config.Monitor02_ID, CultureInfo.InvariantCulture);

            // Get the file as an item.
            FileItem GameItem = new FileItem(Config.GamePath);

            // Set the textbox to executable and args.
            Forms.MainDialog.GameTextBox.Text = GameItem.Name + " " + Config.GameArgs;

            // If the user did not skip the timer then start it now.
            if (!Config.NoTimer)
            {
                // Countdown to the end of time.
                GameTimer.Start();

                // Add the event handlers for stopping the timer so VS2022 doesn't delete them.
                GameTimer.AddStopTimerEvents();
            }
            // If the user did skip the timer then blank out the text.
            else
            {
                // No timer means no need to display this label.
                Forms.MainDialog.TimerLabel.Text = "";
            }
            // Show the main dialog.
            Forms.MainDialog.ShowDialog();
        }

        public static void GameAndPrimary()
        {
            // Create a new instance of the class to save and load icon postiions.
            MainViewModel DesktopIcons = new MainViewModel();

            // Save the positions of desktop icons.
            if (Config.SaveIconPos) { DesktopIcons.SaveIconPositions(); }

            // Update the values in the configuration file.
            Config.WriteINIValues();

            // Show the dialog that alerts the user stuff is still going on.
            if (!Config.NoGUI) { Forms.WaitDialog.Show(); }

            // The function to swap monitors takes an unsigned integer.
            uint uMonitor01_ID = UInt32.Parse(Config.Monitor01_ID) - 1;
            uint uMonitor02_ID = UInt32.Parse(Config.Monitor02_ID) - 1;

            // Set the primary display to the secondary monitor.
            Monitors.SetAsPrimaryMonitor(uMonitor02_ID);

            // Get the game as an item to get the raw directory.
            FileItem GameItem = new FileItem(Config.GamePath);

            // Set the primary display to the secondary monitor.
            Process GameProcess = new Process();
            GameProcess.StartInfo.WorkingDirectory = GameItem.DirectoryName;
            GameProcess.StartInfo.FileName = Config.GamePath;
            GameProcess.StartInfo.Arguments = "";
            GameProcess.StartInfo.UseShellExecute = false;
            GameProcess.StartInfo.RedirectStandardOutput = false;
            GameProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            GameProcess.Start();

            // Wait until the game closes before restoring the display.
            GameProcess.WaitForExit();

            // Set the primary display to the primary monitor.
            Monitors.SetAsPrimaryMonitor(uMonitor01_ID);

            // Restore the desktop icon locations.
            if (Config.SaveIconPos) { DesktopIcons.RestoreIconPositions(); }
        }
    }
}
