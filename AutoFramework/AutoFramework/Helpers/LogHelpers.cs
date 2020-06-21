using AutoFramework.Config;
using System;
using System.IO;

namespace AutoFramework.Helpers
{
    public static class LogHelpers
    {
        //Global Declaration
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;

        //Create a method which can create a log file
        public static void CreateLogFile()
        {
            string dir = Settings.LogPath;
            //@"D:\UdemyEATestProject\EATestProjectLogs\";
            if (Directory.Exists(dir))
                _streamw = File.AppendText(dir + _logFileName + ".log");
            else
            {
                Directory.CreateDirectory(dir);
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }

        }
        //Create a method which can write the text in the log file
        public static void WriteLog(string logMessage)
        {
            _streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamw.WriteLine("    {0}", logMessage);
            _streamw.Flush();
        }


    }
}
