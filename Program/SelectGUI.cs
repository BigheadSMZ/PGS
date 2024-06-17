using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGS
{
    public class SelectGUI
    {

        public static void ShowShortcutGUI()
        {
            // Create the dialog.
            Forms.ShortDialog = new Form_ShortMenu();

            // Scale the shortcut dialog.
            DPIScale.ShortcutDialog();

            // Show the shortcut dialog.
            Forms.ShortDialog.ShowDialog();
        }

        public static void ShowGameLaunchGUI(string[] Arguments)
        {
            // Create the dialogs.
            Forms.MainDialog = new Form_MainMenu();
            Forms.WaitDialog = new Form_WaitMenu();
            Forms.InfoDialog = new Form_ScreenInfo();

            // Scale the dialogs with DPI.
            DPIScale.MainDialog();
            DPIScale.WaitDialog();
            DPIScale.InfoDialog();

            // Add the event handlers for stopping the timer so VS2022 doesn't delete them.
            StartTimer.AddStopTimerEvents();

            // Update the info form to show screen information.
            Functions.UpdateScreenInfo();

            // Put in its own method to cut down on fat.
            Functions.UpdateMonitorValues();

            // Set the timer properties and start it.
            StartTimer.RunTimer.Interval = 1000;
            StartTimer.RunTimer.Tick += new EventHandler(StartTimer.Tick);
            StartTimer.RunTimer.Start();

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
                Forms.MainDialog.GameTextBox.Text = GameItem.Name;
            }
            // Show the main dialog.
            Forms.MainDialog.ShowDialog();
        }

        public static void ShowInvalidGUI()
        {
            // Create the dialog.
            Forms.ShortDialog = new Form_ShortMenu();

            // Scale the shortcut dialog.
            DPIScale.ShortcutDialog();

            // Hide the shortcut button.
            Forms.ShortDialog.ShortcutButton.Visible = false;

            // Set the label to show that an issue has occurred.
            Forms.ShortDialog.ShortcutLabel.Text = "Error: More than one command line argument has been passed. This program only works with a single argument that should point to a game executable.";

            // Show the shortcut dialog.
            Forms.ShortDialog.ShowDialog();
        }
    }
}
