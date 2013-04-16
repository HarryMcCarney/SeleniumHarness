using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace SeleniumHarness
{
    class Browser
    {
        public IWebDriver driver { get; set; }
        public string driverName { get; set; }


        public Browser(string browserName)
        {
            driverName = browserName;

            if (browserName == "Chrome")
                driver = new ChromeDriver();
            if (browserName == "IE")
                driver = new InternetExplorerDriver();
            if (browserName == "Safari")
                driver = new SafariDriver();
            if (browserName == "Firefox")
                driver = new FirefoxDriver();


        }

       

    }
}
