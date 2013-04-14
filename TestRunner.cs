using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace SeleniumHarness
{
    class TestRunner
    {
        private string driver { get; set; } 
        private Type test { get; set; }
        private static  Logger log = Globals.Instance.log;
        private string[] browsers { get; set; }

        public TestRunner(Type test, string[] _browsers)
        {
            this.test = test;
            this.browsers = _browsers;
        }

        public void runtTest()
        {
            log.Info(String.Format("Starting test:{0}", test.Name));

            foreach (var b in browsers)
            {
                log.Info(String.Format("Running {0} on {1}", test.Name, b));

                executeInBrowser(new Browser(b));
                log.Info(String.Format("Finished test:{0} on {1}", test.Name, b));
            }

            log.Info(String.Format("Finished test:{0}", test.Name));
         }

        private void executeInBrowser(Browser browser)
        {
            var instance = (dynamic)Activator.CreateInstance(test);
            try
            {

                test.GetField("driver", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(instance, browser.driver);
                test.GetField("baseURL", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(instance, "");
                test.GetField("verificationErrors", BindingFlags.NonPublic | BindingFlags.Instance)
                    .SetValue(instance, new StringBuilder());
                test.GetMethod(String.Format("The{0}Test", test.Name)).Invoke(instance, null);
                instance.TeardownTest();
            }
            catch (Exception exp)
            {
                log.Error(exp);
                log.Error(String.Format("test: {0} is broken on {1}", test.Name, browser.driverName));
                instance.TeardownTest();
            }
            var errors = test.GetField("verificationErrors", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(instance);
            if (errors.ToString() != "" && errors.ToString() != null)
                log.Error(errors.ToString());

        }

      











    }
}
