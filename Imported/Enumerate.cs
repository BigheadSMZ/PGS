using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PGS
{
    public class Enumerate
    {
        /*===================================================================================================================================
         * A solution to enumerate files in a directory using multiple filter options that is really fast.
         * Source: https://stackoverflow.com/questions/3754118/how-to-filter-directory-enumeratefiles-with-multiple-criteria
         *---------------------------------------------------------------------------------------------------------------------------------*/
        public static List<string> GetFiles(string Path, string SearchPatterns = "*.*", bool Recurse = false)
        {
            // Split the search patterns using the commas into a list.
            string[] findPatterns = SearchPatterns.Split(',');

            // Default the search type to searching only the top directory.
            SearchOption searchOption = SearchOption.TopDirectoryOnly;

            // Search all sub-folders if recurse is enabled.
            if (Recurse) { searchOption = SearchOption.AllDirectories; }

            // Grab the files within the folder (and maybe sub-folders).
            return Strings.EnumToList(findPatterns.AsParallel()
                .SelectMany(searchPattern => Directory.EnumerateFiles(Path, searchPattern, searchOption)
                .Where(f => !new FileInfo(f).Attributes.HasFlag(FileAttributes.Hidden | FileAttributes.System))));
        }
        /*===================================================================================================================================
         * Just uses a simple .NET function to get directories. Since it similar to the above, figured I'd just put it here.
         *---------------------------------------------------------------------------------------------------------------------------------*/
        public static List<string> GetFolders(string Path, string SearchPattern = "*", bool Recurse = false)
        {
            // Default the search type to searching only the top directory.
            SearchOption SearchOption = SearchOption.TopDirectoryOnly;

            // Search all sub-folders if recurse is enabled.
            if (Recurse) { SearchOption = SearchOption.AllDirectories; }

            // Grab the folders within the folder (and maybe sub-folders).
            return Strings.EnumToList(Directory.GetDirectories(Path, SearchPattern, SearchOption));
        }
    }
}
