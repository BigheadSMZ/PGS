using System.Drawing;

namespace PGS
{
    internal class Forms
    {
        // The various dialogs.
        public static Form_MainMenu   MainDialog   = null;
        public static Form_ShortMenu  ShortDialog  = null;
        public static Form_WaitMenu   WaitDialog   = null;
        public static Form_ScreenInfo InfoDialog   = null;
        public static Form_ErrorMenu  ErrorDialog  = null;
        public static Form_ConfigMenu ConfigDialog = null;

        // Keeps track of the whether or not the arguments are visible.
        private static bool ArgumentsHidden = false;

        public static void ArgumentsToggle()
        {
            // Store the tooltip in a string.
            string TipString = "";

            // If the arguments is hidden then hide it.
            if (Forms.ArgumentsHidden)
            {
                // Extend the dialog to a larger size.
                Forms.ShortDialog.ClientSize = DPI.Scale(new Size(198, 230));
                Forms.ShortDialog.MaximumSize = DPI.Scale(new Size(214, 269));
                Forms.ShortDialog.MinimumSize = DPI.Scale(new Size(214, 269));

                // Move the buttons back down.
                Forms.ShortDialog.ArgsToggleButton.Location = DPI.Scale(new Point(10, 199));
                Forms.ShortDialog.ConfigButton.Location = DPI.Scale(new Point(40, 199));
                Forms.ShortDialog.CloseButton.Location = DPI.Scale(new Point(89, 199));

                // Swap the image on the button.
                Forms.ShortDialog.ArgsToggleButton.Image = global::PGS.Properties.Resources.arrowup;

                // Set the tooltip string.
                TipString = "Hide the textbox to add game arguments.";
            }
            // If the arguments is extended then hide it.
            else
            {
                // Shrink the dialog to standard size.
                Forms.ShortDialog.ClientSize = DPI.Scale(new Size(198, 175));
                Forms.ShortDialog.MaximumSize = DPI.Scale(new Size(214, 214));
                Forms.ShortDialog.MinimumSize = DPI.Scale(new Size(214, 214));

                // Move the buttons up a bit.
                Forms.ShortDialog.ArgsToggleButton.Location = DPI.Scale(new Point(10, 144));
                Forms.ShortDialog.ConfigButton.Location = DPI.Scale(new Point(40, 144));
                Forms.ShortDialog.CloseButton.Location = DPI.Scale(new Point(89, 144));

                // Swap the image on the button.
                Forms.ShortDialog.ArgsToggleButton.Image = global::PGS.Properties.Resources.arrowdown;

                // Set the tooltip string.
                TipString = "Show a textbox to add arguments to the \r\nselected executable. Arguments must be \r\nentered before creating the shortcut.";
            }
            // Toggle the groupbox and textbox.
            Forms.ShortDialog.ArgumentsTextBox.Visible = ArgumentsHidden;
            Forms.ShortDialog.ArgumentsGroupBox.Visible = ArgumentsHidden;

            // Swap the tooltip with the updated message.
            Forms.ShortDialog.GlobalToolTip.SetToolTip(Forms.ShortDialog.ArgsToggleButton, null);
            Forms.ShortDialog.GlobalToolTip.SetToolTip(Forms.ShortDialog.ArgsToggleButton, TipString);

            // Keep track of the toggled state.
            ArgumentsHidden = !ArgumentsHidden;
        }
        public static void ScaleShortcutDialog()
        {
            Forms.ShortDialog.ClientSize = DPI.Scale(new Size(198, 230));
            Forms.ShortDialog.MaximumSize = DPI.Scale(new Size(214, 269));
            Forms.ShortDialog.MinimumSize = DPI.Scale(new Size(214, 269));
            Forms.ShortDialog.ShortcutGroupBox.Location = DPI.Scale(new Point(10, 2));
            Forms.ShortDialog.ShortcutGroupBox.Size = DPI.Scale(new Size(178, 138));
            Forms.ShortDialog.ShortcutLabel.Location = DPI.Scale(new Point(8, 22));
            Forms.ShortDialog.ShortcutLabel.Size = DPI.Scale(new Size(164, 81));
            Forms.ShortDialog.ShortcutButton.Location = DPI.Scale(new Point(26, 103));
            Forms.ShortDialog.ShortcutButton.Size = DPI.Scale(new Size(125, 25));
            Forms.ShortDialog.ArgumentsGroupBox.Location = DPI.Scale(new Point(13, 143));
            Forms.ShortDialog.ArgumentsGroupBox.Size = DPI.Scale(new Size(175, 50));
            Forms.ShortDialog.ArgumentsTextBox.Location = DPI.Scale(new Point(6, 19));
            Forms.ShortDialog.ArgumentsTextBox.Size = DPI.Scale(new Size(163, 20));
            Forms.ShortDialog.CloseButton.Location = DPI.Scale(new Point(89, 199));
            Forms.ShortDialog.CloseButton.Size = DPI.Scale(new Size(100, 25));
            Forms.ShortDialog.ArgsToggleButton.Location = DPI.Scale(new Point(10, 199));
            Forms.ShortDialog.ArgsToggleButton.Size = DPI.Scale(new Size(28, 25));
            Forms.ShortDialog.ConfigButton.Location = DPI.Scale(new Point(40, 199));
            Forms.ShortDialog.ConfigButton.Size = DPI.Scale(new Size(30, 25));
        }
        public static void ScaleConfigDialog()
        {
            Forms.ConfigDialog.ClientSize = DPI.Scale(new Size(198, 250));
            Forms.ConfigDialog.MaximumSize = DPI.Scale(new Size(214, 289));
            Forms.ConfigDialog.MinimumSize = DPI.Scale(new Size(214, 289));
            Forms.ConfigDialog.ScreenConfigGroupBox.Location = DPI.Scale(new Point(10, 2));
            Forms.ConfigDialog.ScreenConfigGroupBox.Size = DPI.Scale(new Size(178, 80));
            Forms.ConfigDialog.Monitor01NumBox.Location = DPI.Scale(new Point(126, 20));
            Forms.ConfigDialog.Monitor01NumBox.Size = DPI.Scale(new Size(40, 20));
            Forms.ConfigDialog.Monitor02NumBox.Location = DPI.Scale(new Point(126, 45));
            Forms.ConfigDialog.Monitor02NumBox.Size = DPI.Scale(new Size(40, 20));
            Forms.ConfigDialog.Monitor01Label.Location = DPI.Scale(new Point(6, 22));
            Forms.ConfigDialog.Monitor01Label.Size = DPI.Scale(new Size(100, 18));
            Forms.ConfigDialog.Monitor02Label.Location = DPI.Scale(new Point(6, 47));
            Forms.ConfigDialog.Monitor02Label.Size = DPI.Scale(new Size(110, 18));
            Forms.ConfigDialog.InfoButton.Location = DPI.Scale(new Point(10, 219));
            Forms.ConfigDialog.InfoButton.Size = DPI.Scale(new Size(30, 25));
            Forms.ConfigDialog.OptionsConfigGroupBox.Location = DPI.Scale(new Point(10, 86));
            Forms.ConfigDialog.OptionsConfigGroupBox.Size = DPI.Scale(new Size(178, 127));
            Forms.ConfigDialog.CountdownNumBox.Location = DPI.Scale(new Point(126, 20));
            Forms.ConfigDialog.CountdownNumBox.Size = DPI.Scale(new Size(40, 20));
            Forms.ConfigDialog.CountdownLabel.Location = DPI.Scale(new Point(6, 22));
            Forms.ConfigDialog.CountdownLabel.Size = DPI.Scale(new Size(110, 18));
            Forms.ConfigDialog.NoGUICheckBox.Location = DPI.Scale(new Point(6, 72));
            Forms.ConfigDialog.NoGUICheckBox.Size = DPI.Scale(new Size(160, 20));
            Forms.ConfigDialog.NoTimerCheckbox.Location = DPI.Scale(new Point(6, 47));
            Forms.ConfigDialog.NoTimerCheckbox.Size = DPI.Scale(new Size(160, 20));
            Forms.ConfigDialog.DesktopIconsCheckbox.Location = DPI.Scale(new Point(6, 97));
            Forms.ConfigDialog.DesktopIconsCheckbox.Size = DPI.Scale(new Size(168, 20));
            Forms.ConfigDialog.CloseButton.Location = DPI.Scale(new Point(89, 219));
            Forms.ConfigDialog.CloseButton.Size = DPI.Scale(new Size(100, 25));
        }

        public static void ScaleErrorDialog()
        {
            Forms.ErrorDialog.ClientSize = DPI.Scale(new Size(198, 175));
            Forms.ErrorDialog.MaximumSize = DPI.Scale(new Size(214, 214));
            Forms.ErrorDialog.MinimumSize = DPI.Scale(new Size(214, 214));
            Forms.ErrorDialog.ErrorGroupBox.Location = DPI.Scale(new Point(10, 2));
            Forms.ErrorDialog.ErrorGroupBox.Size = DPI.Scale(new Size(178, 138));
            Forms.ErrorDialog.ErrorLabel.Location = DPI.Scale(new Point(10, 31));
            Forms.ErrorDialog.ErrorLabel.Size = DPI.Scale(new Size(156, 97));
            Forms.ErrorDialog.ErrorButton.Location = DPI.Scale(new Point(89, 144));
            Forms.ErrorDialog.ErrorButton.Size = DPI.Scale(new Size(100, 25));
        }
        public static void ScaleInfoDialog()
        {
            Forms.InfoDialog.ClientSize = DPI.Scale(new Size(346, 369));
            Forms.InfoDialog.MaximumSize = DPI.Scale(new Size(362, 408));
            Forms.InfoDialog.MinimumSize = DPI.Scale(new Size(362, 408));
            Forms.InfoDialog.InfoGroupBox.Location = DPI.Scale(new Point(12, 12));
            Forms.InfoDialog.InfoGroupBox.Size = DPI.Scale(new Size(322, 320));
            Forms.InfoDialog.InfoRichTextBox.Location = DPI.Scale(new Point(6, 19));
            Forms.InfoDialog.InfoRichTextBox.Size = DPI.Scale(new Size(310, 295));
            Forms.InfoDialog.CloseButton.Location = DPI.Scale(new Point(234, 338));
            Forms.InfoDialog.CloseButton.Size = DPI.Scale(new Size(100, 25));
        }
        public static void ScaleMainDialog()
        {
            Forms.MainDialog.ClientSize = DPI.Scale(new Size(198, 175));
            Forms.MainDialog.MaximumSize = DPI.Scale(new Size(214, 214));
            Forms.MainDialog.MinimumSize = DPI.Scale(new Size(214, 214));
            Forms.MainDialog.MainGroupBox.Location = DPI.Scale(new Point(10, 2));
            Forms.MainDialog.MainGroupBox.Size = DPI.Scale(new Size(178, 80));
            Forms.MainDialog.Monitor01NumBox.Location = DPI.Scale(new Point(126, 20));
            Forms.MainDialog.Monitor01NumBox.Size = DPI.Scale(new Size(40, 20));
            Forms.MainDialog.Monitor02NumBox.Location = DPI.Scale(new Point(126, 45));
            Forms.MainDialog.Monitor02NumBox.Size = DPI.Scale(new Size(40, 20));
            Forms.MainDialog.Monitor01Label.Location = DPI.Scale(new Point(6, 22));
            Forms.MainDialog.Monitor01Label.Size = DPI.Scale(new Size(100, 18));
            Forms.MainDialog.Monitor02Label.Location = DPI.Scale(new Point(6, 47));
            Forms.MainDialog.Monitor02Label.Size = DPI.Scale(new Size(110, 18));
            Forms.MainDialog.GameGroupBox.Location = DPI.Scale(new Point(10, 86));
            Forms.MainDialog.GameGroupBox.Size = DPI.Scale(new Size(178, 54));
            Forms.MainDialog.GameTextBox.Location = DPI.Scale(new Point(10, 22));
            Forms.MainDialog.GameTextBox.Size = DPI.Scale(new Size(158, 20));
            Forms.MainDialog.GameButton.Location = DPI.Scale(new Point(89, 144));
            Forms.MainDialog.GameButton.Size = DPI.Scale(new Size(100, 25));
            Forms.MainDialog.TimerLabel.Location = DPI.Scale(new Point(56, 148));
            Forms.MainDialog.TimerLabel.Size = DPI.Scale(new Size(16, 17));
            Forms.MainDialog.InfoButton.Location = DPI.Scale(new Point(10, 144));
            Forms.MainDialog.InfoButton.Size = DPI.Scale(new Size(30, 25));
        }
        public static void ScaleWaitDialog()
        {
            Forms.WaitDialog.ClientSize = DPI.Scale(new Size(198, 175));
            Forms.WaitDialog.MaximumSize = DPI.Scale(new Size(214, 214));
            Forms.WaitDialog.MinimumSize = DPI.Scale(new Size(214, 214));
            Forms.WaitDialog.WaitLabel.Location = DPI.Scale(new Point(27, 72));
            Forms.WaitDialog.WaitLabel.Size = DPI.Scale(new Size(136, 100));
        }
    }
}
