using System;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace PGS
{
    public partial class Form_ShortMenu : Form
    {
        public Form_ShortMenu()
        {
            InitializeComponent();
        }
        public void ShortcutButtonClick(object sender, EventArgs e)
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
                    WShortCut.Arguments = '"' + RecievedFile + '"';
                    WShortCut.WorkingDirectory = Globals.BaseFolder;
                    WShortCut.IconLocation = RecievedFile;
                    WShortCut.Save();
                }
            }
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
