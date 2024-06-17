using System;
using System.IO;
using System.Linq;

namespace PGS
{
    /*===================================================================================================================================
     * Powershell has a useful function "Get-Item" which is very similar to "FileInfo" and "DirectoryInfo" in C#. Unfortunately, FileInfo 
     * does not have the "BaesName" property of a file as readily available as PowerShell's Get-Item. It also over complicates things by
     * needing to distinguish between "FileInfo" and "DirectoryInfo". This class "FileItem" seeks to remedy these issues.
     *---------------------------------------------------------------------------------------------------------------------------------*/
    public class FileItem
    {
        public FileAttributes Attributes;
        public string BaseName = "";
        public DirectoryInfo Directory;
        public string DirectoryName = "";
        public bool Exists = false;
        public string Extension = "";
        public string FullName = "";
        public bool IsReadOnly = false;
        public DateTime LastAccessTime;
        public DateTime LastAccessTimeUtc;
        public DateTime LastWriteTime;
        public DateTime LastWriteTimeUtc;
        public long Length = 0;
        public string Name = "";
        public DirectoryInfo Parent;
        public DirectoryInfo Root;

        public FileItem(string InputFile)
        {
            // This "Info" can be file or diectory so start it as dynamic.
            dynamic Info = null;

            // If it's a folder, then create DirectoryInfo.
            if (Paths.Test(InputFile, true))
            {
                // Most properties will be derived from DirectoryInfo.
                Info = new DirectoryInfo(InputFile);

                // Properties specific to this type.
                this.BaseName = Info.Name;
                this.DirectoryName = Info.FullName;
                this.Parent = Info.Parent;
                this.Root = Info.Root;
            }
            // If it's a file, then create FileInfo.
            else if (Paths.Test(InputFile, false))
            {
                // Most properties will be derived from FileInfo.
                Info = new FileInfo(InputFile);

                // Properties specific to this type.
                this.BaseName = FileEx.GetBaseName(Info.Name);
                this.Directory = Info.Directory;
                this.DirectoryName = Info.DirectoryName;
                this.IsReadOnly = Info.IsReadOnly;
                this.Length = Info.Length;
            }
            // Set up the shared properties.
            this.Attributes = Info.Attributes;
            this.Exists = Info.Exists;
            this.Extension = Info.Extension;
            this.FullName = Info.FullName;
            this.LastAccessTime = Info.LastAccessTime;
            this.LastAccessTimeUtc = Info.LastAccessTimeUtc;
            this.LastWriteTime = Info.LastWriteTime;
            this.LastWriteTimeUtc = Info.LastWriteTimeUtc;
            this.Name = Info.Name;
        }
    }
    public class FileEx
    {
        /*===================================================================================================================================
         * A more powerful version of "Move" that can move a file to a new location by setting the destination to a file name, or by setting
         * the destination to a folder path. If the target destination folder does not exist, then the location is created before the move.
         *---------------------------------------------------------------------------------------------------------------------------------*/
        public static void Move(string Source, string Destination, bool Overwrite = false)
        {
            // Test the path to see if it is a folder.
            if (Paths.Test(Source, true))
            {
                // Check to see if the file is to be overwritten.
                if (Overwrite)
                {
                    // Remove the path before trying to move.
                    Paths.Remove(Destination);

                    // Now rename the file using "move".
                    Directory.Move(Source, Destination);

                    // We're done so lets go.
                    return;
                }
                // Merge files and folders from the source into the destination.
                else
                {
                    // Check to see if the folder exists.
                    if (!Paths.Test(Destination))
                    {
                        // If not, then create it before trying to move everything there.
                        Paths.Create(Destination);
                    }
                    // Loop through all files in the source.
                    foreach (string FilePath in Enumerate.GetFiles(Source))
                    {
                        // Get the name of the file.
                        string FileName = new FileInfo(FilePath).Name;

                        // Set the path to the destination file.
                        string DestFile = Destination + "\\" + FileName;

                        // If the file already exists in the output path, always remove it.
                        if (Paths.Test(DestFile)) { Paths.Remove(DestFile); }

                        // Move the file to the destination path.
                        File.Move(FilePath, DestFile);
                    }
                    // Loop through all folders in the source.
                    foreach (string FolderPath in Enumerate.GetFolders(Source))
                    {
                        // Get the name of the folder.
                        string FolderName = new DirectoryInfo(FolderPath).Name;

                        // Set the path to the destination folder.
                        string DestFolder = Destination + "\\" + FolderName;

                        // If the file already exists in the output path, always remove it.
                        if (Paths.Test(DestFolder)) { Paths.Remove(DestFolder); }

                        // Move the folder to the destination.
                        Directory.Move(FolderPath, DestFolder);
                    }
                    // We're done so lets go.
                    return;
                }
            }
            // Test the path to see if it is a file.
            else if (Paths.Test(Source, false))
            {
                // Check to see if the file is to be overwritten.
                if (Overwrite && Paths.Test(Destination))
                {
                    // Remove the file before trying to rename.
                    Paths.Remove(Destination);
                }
                // Now rename the file using "move".
                File.Move(Source, Destination);
            }
        }
        /*===================================================================================================================================
         * A more powerful version of "Copy" that can copy a file to a new location by setting the destination to a file name, or by setting
         * the destination to a folder path. If the target destination folder does not exist, then the location is created before the move.
         *---------------------------------------------------------------------------------------------------------------------------------*/
        public static void Copy(string Source, string Destination, bool Overwrite = false)
        {
            // Split the source and destination path by the folders.
            string[] SourceSplit = Source.Split('\\');
            string[] DestinationSplit = Destination.Split('\\');

            // Check to see if the final part of the destination has a period in it.
            bool DestHasPeriod = Wildcard.Match(DestinationSplit[DestinationSplit.Length - 1], "*.*", true);

            // If the destination has a period then its probably a file to file transfer.
            if (DestHasPeriod)
            {
                // Now rename the file using "move".
                File.Copy(Source, Destination, Overwrite);
            }
            // If neither passed, it's probably going to a folder.
            else
            {
                // Check to see if the folder exists.
                if (!Paths.Test(Destination))
                {
                    // If not, then create it before trying to move the file there.
                    Paths.Create(Destination);
                }
                // Extract the file name from the last part of the string.
                string FileName = SourceSplit[SourceSplit.Length - 1];

                // Set the output file name.
                string NewDestination = Destination + "\\" + FileName;

                // Now rename the file using "move".
                File.Copy(Source, NewDestination, Overwrite);
            }
        }
        /*===================================================================================================================================
         * Extracts file extensions from a file and returns the file. The Extensions paramater tells how many extensions to remove. Some
         * files may have multiple extensions like phyre images, so its possible to fine tune the number of extensions to keep.
         * Example: texture.png.phyre ; Extensions = 1 => texture.png ; Extensions = 2 => texture
         *---------------------------------------------------------------------------------------------------------------------------------*/
        public static string GetBaseName(string FileName, int Extensions = 1)
        {
            // Split the input based on periods.
            string[] SplitFileName = FileName.Split('.');

            // Get the number of extensions that will be cropped.
            int Saved = SplitFileName.Count() - Extensions;

            // Always save at least the name if "Extensions" is set too high.
            if (Saved < 1) { Saved = 1; }

            // Start with an empty string
            string NewFileName = "";

            // Loop by the number of counts.
            for (int i = 0; i < Saved; i++)
            {
                // Add the number of positions that are saved.
                NewFileName += SplitFileName[i] + ".";
            }
            // Return the crafted string.
            return NewFileName.TrimEnd('.');
        }
        /*===================================================================================================================================
         * Extracts the file extension from a file and returns the extension.
         *---------------------------------------------------------------------------------------------------------------------------------*/
        public static string GetExtension(string FilePath)
        {
            // Split the input based on periods.
            string[] GetExtension = FilePath.Split('.');

            // Get the position of the extension.
            int Pos = GetExtension.Count() - 1;

            // Get the last value in the stack which holds the extension.
            string SetExtension = ("." + GetExtension[Pos]);

            // If returning only the extension with the file cropped.
            return SetExtension;
        }
    }
}
