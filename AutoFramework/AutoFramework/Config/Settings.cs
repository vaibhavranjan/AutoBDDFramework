using AutoFramework.Base;
using System.Net;

namespace AutoFramework.Config
{
    public static class Settings
    {
        public static string AUT { get; set; }
        public static string TestType { get; set; }
        public static string Build { get; set; }
        public static BrowserType BrowserType { get; set; }
        public static string IsLog { get; set; }
        public static string LogPath { get; set; }
        public static string IsReport { get; set; }
        public static string Username { get; set; }
        public static string Passwrod { get; set; }
    }
}
