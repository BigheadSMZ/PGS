using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace PGS
{
    public class Functions
    {
        // Create a timer to automatically start the game.
        public static System.Windows.Forms.Timer RunTimer = new System.Windows.Forms.Timer();

        public static void StopTimer(object sender, EventArgs e)
        {
            // Stop the timer from counting down.
            Functions.RunTimer.Stop();

            // Hide the timer label.
            Globals.MainDialog.TimerLabel.Text = "";
        }

        public static void TimerTick(object sender, EventArgs e)
        {
            // Check to see if time remains.
            if (Globals.Countdown > 0)
            {
                // Subtract 1 from the total.
                Globals.Countdown -= 1;

                // Update the label on the dialog.
                Globals.MainDialog.TimerLabel.Text = Globals.Countdown.ToString();
            }
            // Time is up.
            else
            {
                // Stop the timer from counting down.
                Functions.RunTimer.Stop();

                // Run the application and swap primary monitor.
                SetPrimaryAndLaunch();
            }
        }

        public static void SetPrimaryAndLaunch()
        {
            // Update the registry values with the current selections.
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\PGS", "Monitor01_ID", Globals.Monitor01_ID);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\PGS", "Monitor02_ID", Globals.Monitor02_ID);

            // Hid the dialog.
            Globals.MainDialog.Hide();
            Globals.WaitDialog.Show();

            // Set the primary display to the secondary monitor.
            Process NirCMDProcess = new Process();
            NirCMDProcess.StartInfo.FileName = Globals.NirCMDPath;
            NirCMDProcess.StartInfo.Arguments = "setprimarydisplay " + Globals.Monitor02_ID;
            NirCMDProcess.StartInfo.UseShellExecute = true;
            NirCMDProcess.StartInfo.RedirectStandardOutput = false;
            NirCMDProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            NirCMDProcess.Start();

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
            NirCMDProcess.StartInfo.Arguments = "setprimarydisplay " + Globals.Monitor01_ID;
            NirCMDProcess.Start();
        }
    }
}
