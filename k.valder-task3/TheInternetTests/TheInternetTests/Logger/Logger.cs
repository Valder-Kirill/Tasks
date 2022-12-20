using System;
using System.IO;

namespace TheInternetTests.Logs
{
    public static class Logger
    {
        static Logger()
        {

        }

        public static void Info(string log)
        {
            File.AppendAllText(Environment.CurrentDirectory + @"/Log.txt", DateTime.Now + " | Info | "+ log + Environment.NewLine);
        }

        public static void Error(string log, Exception e)
        {
            File.AppendAllText(Environment.CurrentDirectory + @"/Log.txt", DateTime.Now + " | Error | " + log + Environment.NewLine + " | " + e);
        }
    }
}
