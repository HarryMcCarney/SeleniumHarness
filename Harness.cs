using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace SeleniumHarness
{
    public static class Harness
    {




        private static List<Type> tests { get; set; }

        private static string logFile = Globals.Instance.fileName;
        private static Logger log = Globals.Instance.log;
        private static string email = Globals.Instance.email;


        private static List<Type> getTests()
        {
            tests = (from t in Assembly.GetEntryAssembly().GetTypes()
            where t.IsClass && t.Namespace == "SeleniumTests"
             select t).ToList();

            log.Info(String.Format("{0} tests found", tests.Count()));
            return tests;

        }


        public static void run()
        {
            var tests = getTests();
            if (tests == null) return;
            var browsers = new[] {"Chrome", "Safari", "IE", "Firefox"};
            foreach (var t in tests)
                new TestRunner(t, browsers).runtTest();
            if (email != null)
            EmailLog.send();
        }

        public static void run(string[] browsers)
        {
            var tests = getTests();
            if (tests == null) return;
            foreach (var t in tests)
                new TestRunner(t, browsers).runtTest();
            if (email != null)
            EmailLog.send();
        }



        public static void run(string test)
        {
            var tests = getTests();
            if (tests == null) return;
            var browsers = new[] {"Chrome", "Safari", "IE", "Firefox"};
            foreach (var t in tests)
                if (t.Name == test)
                    new TestRunner(t, browsers).runtTest();
            if (email != null)
            EmailLog.send();
        }


        public static void run(string[] browsers, string test)
        {
            var tests = getTests();
            if (tests == null) return;
            foreach (var t in tests)
                if (t.Name == test)
                    new TestRunner(t, browsers).runtTest();
            if (email != null)
            EmailLog.send();
        }
    }
        




   

    }

