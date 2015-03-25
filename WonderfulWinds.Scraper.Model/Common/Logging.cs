using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WonderfulWinds.Scraper.Model.Common
{
    public static class Logging
    {
        public static void Open ()
        {
            File.Delete("log.csv");
        }

        public static void Write (string message)
        {
            StreamWriter writetext = new StreamWriter("log.csv", true);
            writetext.WriteLine(message);
            writetext.Close();
        }
    }
}
