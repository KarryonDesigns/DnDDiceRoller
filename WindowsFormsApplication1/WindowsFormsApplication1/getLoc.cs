using System;
using System.IO;
using System.Reflection;

namespace WindowsFormsApplication1
{
    internal class getLoc
    {
        public static string getLocation()
        {
            String loc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

            try
            {
                if (loc.StartsWith(@"file:\"))
                {
                    loc = loc.Substring(6);
                }
            }
            catch (Exception)
            {
            }
            return loc.ToString();
        }
    }
}