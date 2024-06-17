using System.Collections.Generic;

namespace PGS
{
    public class Strings
    {
        /*===================================================================================================================================
         * Counts the number of characters in a string and extends it with empty spaces to the input amount.
         *---------------------------------------------------------------------------------------------------------------------------------*/
        public static string Extend(string InputString, int Length)
        {
            // Count the number of characters in the input string.
            int Count = InputString.Length;

            // Check the number of characters against the desired amount.
            if (Count < Length)
            {
                // If the string is to be lengthened, find out by how much.
                int AddLength = Length - Count;

                // Loop until the string matches the desired number of characters.
                for (int i = 1; i <= AddLength; i++)
                {
                    // Add an empty space to the end of the string.
                    InputString += " ";
                }
            }
            // Return the modified string.
            return InputString;
        }
        /*===================================================================================================================================
         * Converts a List<string> into a string[] array.
         *---------------------------------------------------------------------------------------------------------------------------------*/
        public static string[] ListToArray(List<string> StringList)
        {
            // Create a new string array equal in size to the list.
            string[] StringArray = new string[StringList.Count];

            // Loop through all items in the list.
            for (int i = 0; i < StringList.Count; i++)
            {
                // Add the item to the string array.
                StringArray[i] = StringList[i];
            }
            // Return the string array.
            return StringArray;
        }
        /*===================================================================================================================================
         * Converts a string[] array into a List<string>.
         *---------------------------------------------------------------------------------------------------------------------------------*/
        public static List<string> ArrayToList(string[] StringArray)
        {
            // Create a new string list.
            List<string> StringList = new List<string> { };

            // Loop through all items in the array.
            for (int i = 0; i < StringArray.Length; i++)
            {
                // Add the item to the string array.
                StringList.Add(StringArray[i]);
            }
            // Return the string array.
            return StringList;
        }
        /*===================================================================================================================================
         * Converts a IEnumerable array into a List<string>.
         *---------------------------------------------------------------------------------------------------------------------------------*/
        public static List<string> EnumToList(IEnumerable<string> EnumArray)
        {
            // Create a new string list.
            List<string> StringList = new List<string> { };

            // Loop through all items in the array.
            foreach (string Item in EnumArray)
            {
                // Add the item to the string array.
                StringList.Add(Item);
            }
            // Return the string array.
            return StringList;
        }
    }
}
