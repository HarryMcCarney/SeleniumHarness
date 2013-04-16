using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SeleniumHarness
{
    public class Globals
    {
        private static Globals instance = new Globals();
        internal Logger log;
        internal  string fileName;
        public string email { get; set; }
    

        public static Globals Instance
        {
            get { return instance; }
        }

        private Globals()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            fileName = String.Format("{0}/logs/{1}.log", basePath, DateTime.Now.ToString("yyyy-MM-dd"));
            configureLogger();
            
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private void configureLogger()
        {

            var config = new LoggingConfiguration();


            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);
            
            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);
            consoleTarget.Layout = @"${date:format=HH\:MM\:ss} ${logger} ${message}";
            fileTarget.FileName = "${basedir}/logs/${shortdate}.log";
            fileTarget.EnableFileDelete = true;
            fileTarget.DeleteOldFileOnStartup = true;
            fileTarget.Layout = "${message}";

            var rule1 = new LoggingRule("*", LogLevel.Trace, consoleTarget);
            config.LoggingRules.Add(rule1);

            var rule2 = new LoggingRule("*", LogLevel.Trace, fileTarget);
            config.LoggingRules.Add(rule2);

            LogManager.Configuration = config;

            log = LogManager.GetLogger("SeleniumTests");

        }

    }
}
