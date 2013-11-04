using System;

namespace WindowsFormsApplication1
{
    internal class logStrings
    {
        //Logging Strings
        public static string time = DateTime.Now.ToString("hh:mm:ss tt");
        public static string date = DateTime.Now.ToString("M-d");
        public static string logLoc = getLoc.getLocation() + @"\" + @"Logs\" + date + ".txt";
        //End Logging Strings
    }
}