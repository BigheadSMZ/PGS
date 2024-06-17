using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Normally I would just replace the values in the designers, but scaling this way makes it so they are still usable in visual studio designer.

namespace PGS
{
    internal static class DPIScale
    {
        public static void ShortcutDialog()
        {
            // Scale the shortcut dialogs.
            Forms.ShortDialog.ClientSize = DPI.Scale(new System.Drawing.Size(198, 175));
            Forms.ShortDialog.MaximumSize = DPI.Scale(new System.Drawing.Size(214, 214));
            Forms.ShortDialog.MinimumSize = DPI.Scale(new System.Drawing.Size(214, 214));
            Forms.ShortDialog.ShortcutGroupBox.Location = DPI.Scale(new System.Drawing.Point(10, 2));
            Forms.ShortDialog.ShortcutGroupBox.Size = DPI.Scale(new System.Drawing.Size(178, 138));
            Forms.ShortDialog.ShortcutLabel.Location = DPI.Scale(new System.Drawing.Point(8, 20));
            Forms.ShortDialog.ShortcutLabel.Size = DPI.Scale(new System.Drawing.Size(164, 77));
            Forms.ShortDialog.ShortcutButton.Location = DPI.Scale(new System.Drawing.Point(29, 100));
            Forms.ShortDialog.ShortcutButton.Size = DPI.Scale(new System.Drawing.Size(125, 23));
            Forms.ShortDialog.CloseButton.Location = DPI.Scale(new System.Drawing.Point(89, 144));
            Forms.ShortDialog.CloseButton.Size = DPI.Scale(new System.Drawing.Size(100, 25));
        }
        public static void InfoDialog()
        {
            // Scale the monitor information dialog.
            Forms.InfoDialog.ClientSize = DPI.Scale(new System.Drawing.Size(346, 369));
            Forms.InfoDialog.MaximumSize = DPI.Scale(new System.Drawing.Size(362, 408));
            Forms.InfoDialog.MinimumSize = DPI.Scale(new System.Drawing.Size(362, 408));
            Forms.InfoDialog.InfoGroupBox.Location = DPI.Scale(new System.Drawing.Point(12, 12));
            Forms.InfoDialog.InfoGroupBox.Size = DPI.Scale(new System.Drawing.Size(322, 320));
            Forms.InfoDialog.InfoRichTextBox.Location = DPI.Scale(new System.Drawing.Point(6, 19));
            Forms.InfoDialog.InfoRichTextBox.Size = DPI.Scale(new System.Drawing.Size(310, 295));
            Forms.InfoDialog.CloseButton.Location = DPI.Scale(new System.Drawing.Point(234, 338));
            Forms.InfoDialog.CloseButton.Size = DPI.Scale(new System.Drawing.Size(100, 25));
        }
        public static void MainDialog()
        {
            // Scale the 
            Forms.MainDialog.ClientSize = DPI.Scale(new System.Drawing.Size(198, 175));
            Forms.MainDialog.MaximumSize = DPI.Scale(new System.Drawing.Size(214, 214));
            Forms.MainDialog.MinimumSize = DPI.Scale(new System.Drawing.Size(214, 214));
            Forms.MainDialog.MainGroupBox.Location = DPI.Scale(new System.Drawing.Point(10, 2));
            Forms.MainDialog.MainGroupBox.Size = DPI.Scale(new System.Drawing.Size(178, 80));
            Forms.MainDialog.Monitor01NumBox.Location = DPI.Scale(new System.Drawing.Point(126, 20));
            Forms.MainDialog.Monitor01NumBox.Size = DPI.Scale(new System.Drawing.Size(40, 20));
            Forms.MainDialog.Monitor02NumBox.Location = DPI.Scale(new System.Drawing.Point(126, 45));
            Forms.MainDialog.Monitor02NumBox.Size = DPI.Scale(new System.Drawing.Size(40, 20));
            Forms.MainDialog.Monitor01.Location = DPI.Scale(new System.Drawing.Point(6, 22));
            Forms.MainDialog.Monitor01.Size = DPI.Scale(new System.Drawing.Size(100, 18));
            Forms.MainDialog.Monitor02.Location = DPI.Scale(new System.Drawing.Point(6, 47));
            Forms.MainDialog.Monitor02.Size = DPI.Scale(new System.Drawing.Size(110, 18));
            Forms.MainDialog.GameGroupBox.Location = DPI.Scale(new System.Drawing.Point(10, 86));
            Forms.MainDialog.GameGroupBox.Size = DPI.Scale(new System.Drawing.Size(178, 54));
            Forms.MainDialog.GameTextBox.Location = DPI.Scale(new System.Drawing.Point(10, 22));
            Forms.MainDialog.GameTextBox.Size = DPI.Scale(new System.Drawing.Size(158, 20));
            Forms.MainDialog.GameButton.Location = DPI.Scale(new System.Drawing.Point(89, 144));
            Forms.MainDialog.GameButton.Size = DPI.Scale(new System.Drawing.Size(100, 25));
            Forms.MainDialog.TimerLabel.Location = DPI.Scale(new System.Drawing.Point(12, 147));
            Forms.MainDialog.TimerLabel.Size = DPI.Scale(new System.Drawing.Size(16, 17));
            Forms.MainDialog.InfoButton.Location = DPI.Scale(new System.Drawing.Point(55, 144));
            Forms.MainDialog.InfoButton.Size = DPI.Scale(new System.Drawing.Size(30, 25));
        }
        public static void WaitDialog()
        {
            Forms.WaitDialog.ClientSize = DPI.Scale(new System.Drawing.Size(198, 175));
            Forms.WaitDialog.MaximumSize = DPI.Scale(new System.Drawing.Size(214, 214));
            Forms.WaitDialog.MinimumSize = DPI.Scale(new System.Drawing.Size(214, 214));
            Forms.WaitDialog.WaitLabel.Location = DPI.Scale(new System.Drawing.Point(27, 72));
            Forms.WaitDialog.WaitLabel.Size = DPI.Scale(new System.Drawing.Size(136, 100));
        }
    }
}
