using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class LL131
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://startpage.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheLL131Test()
        {
            String demo = "http://demo.larryslist.de/";
            String dev = "http://dev.larryslist.de/";
            // ERROR: Caught exception [ERROR: Unsupported command [setSpeed | 200 | ]]
            driver.Navigate().GoToUrl(baseURL + dev + "logout");
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("What You Get"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            driver.FindElement(By.LinkText("What You Get")).Click();
            driver.FindElement(By.LinkText("Pricing")).Click();
            driver.FindElement(By.LinkText("Collector Ranking")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//div[3]/div[2]/div/p[2]/a"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Learn more here\\.[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Learn more here.")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("h1.title"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=h1.title | ]]
            driver.Navigate().Back();
            driver.Navigate().GoToUrl(baseURL + dev + "logout");
            driver.FindElement(By.LinkText("Data Sources")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//div[4]/div[2]/div/p[2]/a"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Test us\\.[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//div[4]/div[2]/div/p[2]/a")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=label.control-label.search-title | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=div.control-group.last > label.control-label.search-title | ]]
             
            driver.FindElement(By.LinkText("exact:Who is Larry?")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alert.Text;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
