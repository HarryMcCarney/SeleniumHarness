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
    public class LL169
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
        public void TheLL169Test()
        {
            String demo = "http://demo.larryslist.de/admin/";
            String dev = "http://dev.larryslist.de/admin/";
            // Speed below 350 results in an Internal Server Error
            // ERROR: Caught exception [ERROR: Unsupported command [setSpeed | 400 | ]]
            driver.Navigate().GoToUrl(baseURL + dev + "logout");
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.Name("formdata.pwd"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            driver.FindElement(By.Name("formdata.email")).Clear();
            driver.FindElement(By.Name("formdata.email")).SendKeys("mapa@friendfund.com");
            driver.FindElement(By.Name("formdata.pwd")).Clear();
            driver.FindElement(By.Name("formdata.pwd")).SendKeys("mapa123");
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("button.btn.btn-primary"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            driver.FindElement(By.CssSelector("button.btn.btn-primary")).Click();
            // take 1st of Approved Collectors
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//div[2]/div/div/a"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //div[2]/div/div/a | ]]
            driver.FindElement(By.XPath("//div[2]/div/div/a")).Click();
            // Tab Business/Industry
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Business / Industry"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=Business / Industry | ]]
            driver.FindElement(By.LinkText("Business / Industry")).Click();
            // type Name Of Company
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("button.btn.btn-primary"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // GET READY FOR IT
            driver.FindElement(By.CssSelector("button.btn.btn-primary")).Click();
            // Internal Server Error ?
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("business.Company-0.name")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | name=business.Company-0.name | ]]
            driver.FindElement(By.Name("business.Company-0.name")).Clear();
            driver.FindElement(By.Name("business.Company-0.name")).SendKeys("BUG gGmbH");
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div.data-dirty-notice.label-important")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=div.data-dirty-notice.label-important | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=button.btn.btn-primary | ]]
            driver.FindElement(By.CssSelector("button.btn.btn-primary")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Logout"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=Logout | ]]
            driver.FindElement(By.LinkText("Logout")).Click();
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
