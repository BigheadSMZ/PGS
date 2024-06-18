using System;
using System.Windows.Forms;

namespace PGS
{
    internal class StartTimer
    {
        // Create a timer to automatically start the game.
        public static Timer RunTimer = new Timer();
        public static int   Countdown = 5;

        public static void Start()
        {
            // Set the timer properties and start it.
            RunTimer.Interval = 1000;
            RunTimer.Tick += new EventHandler(Tick);
            RunTimer.Start();
        }
        public static void Stop(object sender, EventArgs e)
        {
            // Stop the timer from counting down.
            RunTimer.Stop();

            // Hide the timer label.
            Forms.MainDialog.TimerLabel.Text = "";
        }
        public static void Tick(object sender, EventArgs e)
        {
            // Check to see if time remains.
            if (Countdown > 0)
            {
                // Subtract 1 from the total.
                Countdown -= 1;

                // Update the label on the dialog.
                Forms.MainDialog.TimerLabel.Text = Countdown.ToString();
            }
            // Time is up.
            else
            {
                // Stop the timer from counting down.
                RunTimer.Stop();

                // Hide the dialog from the user.
                Forms.MainDialog.Hide();

                // Run the application and swap primary monitor.
                Functions.SetPrimaryAndLaunch();
            }
        }
        public static void AddStopTimerEvents()
        {
            // Add this event to all controls to stop the timer. VS2022 likes to delete them when added in "Designer".
            Forms.MainDialog.Click += new EventHandler(Stop);
            Forms.MainDialog.MainGroupBox.Click += new EventHandler(Stop);
            Forms.MainDialog.Monitor01Label.Click += new EventHandler(Stop);
            Forms.MainDialog.Monitor02Label.Click += new EventHandler(Stop);
            Forms.MainDialog.Monitor01NumBox.Click += new EventHandler(Stop);
            Forms.MainDialog.Monitor02NumBox.Click += new EventHandler(Stop);
            Forms.MainDialog.Monitor01NumBox.ValueChanged += new EventHandler(Stop);
            Forms.MainDialog.Monitor02NumBox.ValueChanged += new EventHandler(Stop);
            Forms.MainDialog.GameGroupBox.Click += new EventHandler(Stop);
            Forms.MainDialog.GameButton.Click += new EventHandler(Stop);
            Forms.MainDialog.GameTextBox.Click += new EventHandler(Stop);
            Forms.MainDialog.TimerLabel.Click += new EventHandler(Stop);
        }
    }
}
