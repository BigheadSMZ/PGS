using System;
using System.IO;
using System.Reflection;

namespace PGS
{
    internal class Config
    {
        // Rather than keep trying to find all places the version is set, let's create a single instance.
        public static string PGSVersion = "";

        // Values used across the application.
        public static string AppPath = "";
        public static string BaseFolder = "";
        public static string GamePath = "";
        public static string GameArgs = "";

        // INI Path
        public static string INIPath;
        public static IniFile INIFile;

        // INI Settings
        public static bool NoGUI;
        public static bool NoTimer;
        public static bool SaveIconPos;
        public static string Countdown;
        public static string Monitor01_ID;
        public static string Monitor02_ID;

        public static void SetApplicationValues()
        {
            // Get the folder this app is in.
            Config.AppPath = Assembly.GetExecutingAssembly().Location;
            Config.BaseFolder = Path.GetDirectoryName(Config.AppPath);

            // Set the path of the INI file.
            Config.INIPath = Config.BaseFolder + "\\PGS.ini";
            Config.INIFile = new IniFile(Config.INIPath);

            // See if the INI file exists and Load the values from the INI.
            if (Paths.Test(Config.INIPath)) { Config.LoadINIValues(); }

            // It does not exist create the INI with default values.
            else { Config.CreateNewINI(); }
        }
        public static void CreateNewINI()
        {
            // Set the configuration defaults.
            Config.Monitor01_ID = "1";
            Config.Monitor02_ID = "2";
            Config.Countdown = "5";
            Config.NoGUI = false;
            Config.NoTimer = false;
            Config.SaveIconPos = false;

            // Store the defaults to the INI file.
            WriteINIValues();
        }
        public static void WriteINIValues()
        {
            // Write the values to the INI file.
            Config.INIFile.Write("Monitor01", Config.Monitor01_ID, "ScreenID");
            Config.INIFile.Write("Monitor02", Config.Monitor02_ID, "ScreenID");
            Config.INIFile.Write("Countdown", Config.Countdown.ToString(), "Options");
            Config.INIFile.Write("DisableGUI", Config.NoGUI.ToString(), "Options");
            Config.INIFile.Write("DisableTimer", Config.NoTimer.ToString(), "Options");
            Config.INIFile.Write("SaveIconPos", Config.SaveIconPos.ToString(), "Options");
        }
        public static void LoadINIValues()
        {
            // Load the values from the INI file.
            Config.Monitor01_ID = Config.INIFile.Read("Monitor01", "ScreenID");
            Config.Monitor02_ID = Config.INIFile.Read("Monitor02", "ScreenID");
            Config.Countdown = Config.INIFile.Read("Countdown", "Options");
            Config.NoGUI = Convert.ToBoolean(Config.INIFile.Read("DisableGUI", "Options"));
            Config.NoTimer = Convert.ToBoolean(Config.INIFile.Read("DisableTimer", "Options"));
            Config.SaveIconPos = Convert.ToBoolean(Config.INIFile.Read("SaveIconPos", "Options"));
        }
    }
}
