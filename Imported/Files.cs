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
    }
}
