using System;
using System.IO;

namespace PGS
{
    public class Paths
    {
        /*===================================================================================================================================
         * GENERAL PATH FUNCTIONS
         *===================================================================================================================================
         * Checks if a path exists. Avoids use of using it directly which can generate an error if the tested path is null.
         *---------------------------------------------------------------------------------------------------------------------------------*/
        public static bool Test(string InputPath, bool IsDirectory = false)
        {
            // If the path is empty then it does not exist.
            if (InputPath == "" || InputPath == null) { return false; };

            // Attempt to pull attributes from the file/folder.
            try { FileAttributes Dummy = File.GetAttributes(InputPath); }

            // If the path doesn't exist catch the exception.
            catch (Exception x)
            {
                // All of this crap has popped up depending on the input paramter so catch it all.
                if (x is DirectoryNotFoundException || x is FileNotFoundException || x is ArgumentException) { return false; }
            }
            // The above should already catch most paths or files that don't exist. But any paths or files that make it past
            // the exception, get the type that they are (path or file) then use the respective method to test if they exist.*/
            FileAttributes attr = File.GetAttributes(InputPath);

            // If it's a directory, check for that specific attribute.
            if (attr.HasFlag(FileAttributes.Directory))
            {
                return Directory.Exists(InputPath);
            }
            // If it's a file, check to see if only folder types will pass.
            else if (!IsDirectory)
            {
                return File.Exists(InputPath);
            }
            // If file checks were blocked, then we end up here so return false.
            return false;
        }
        /*===================================================================================================================================
         * Creates a folder if it does not already exist. Returns the parameter so it can be set to a variable when called.
         *---------------------------------------------------------------------------------------------------------------------------------*/
        public static string Create(string InputPath, bool NoReturn = false)
        {
            // If the path is empty then it does not exist.
            if (InputPath == "" || InputPath == null) { return ""; };

            // Check to see if the path does not exist.
            if (!Paths.Test(InputPath))
            {
                // Create the path.
                Directory.CreateDirectory(InputPath);
            }
            // Return the path that was created.
            return InputPath;
        }
        /*===================================================================================================================================
         * Renames a folder using Directory.Move() since C# does not have its own rename option.
         *---------------------------------------------------------------------------------------------------------------------------------*/
        public static void Move(string Source, string Destination, bool Overwrite = false)
        {
            // Check to see if the file is to be overwritten.
            if (Overwrite && Paths.Test(Destination, true))
            {
                // Remove the file before trying to rename.
                Paths.Remove(Destination);
            }
            // Now rename the file using "move".
            Directory.Move(Source, Destination);
        }
        /*===================================================================================================================================
         * Removes a file or folder if it exists.
         *---------------------------------------------------------------------------------------------------------------------------------*/
        public static void Remove(string InputPath)
        {
            // If the path is empty then it does not exist.
            if (InputPath == "" || InputPath == null) { return; };

            // Check to see if the path exists.
            if (Paths.Test(InputPath))
            {
                // Files and folders each have their own removal method.
                FileAttributes attr = File.GetAttributes(InputPath);

                // A true/false switch will make for some shorter/cleaner code.
                bool IsFolder = ((attr & FileAttributes.Directory) == FileAttributes.Directory);

                // Choose the appropriate method.
                switch (IsFolder)
                {
                    case true: { Directory.Delete(InputPath, true); break; }
                    case false: { File.Delete(InputPath); break; }
                }
            }
        }
    }
}
