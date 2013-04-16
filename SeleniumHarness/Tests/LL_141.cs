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
    public class LL141
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
        public void TheLL141Test()
        {
            String demo = "http://demo.larryslist.de/admin/";
            String dev = "http://dev.larryslist.de/admin/";
            driver.Navigate().GoToUrl(baseURL + dev + "logout");
            // ERROR: Caught exception [ERROR: Unsupported command [setSpeed | 0 | ]]
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Login"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
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
            // AddALinkedCollector
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Add a linked collector"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=Add a linked collector | ]]
            driver.FindElement(By.LinkText("Add a linked collector")).Click();
            // LinkedCollector
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("div.nav-entry-link > a"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.Name("base.firstName"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//select[@name='base.relation']"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            driver.FindElement(By.XPath("//select[@name='base.relation']")).Clear();
            driver.FindElement(By.XPath("//select[@name='base.relation']")).SendKeys("label=Family");
            driver.FindElement(By.Name("base.firstName")).Clear();
            driver.FindElement(By.Name("base.firstName")).SendKeys("Gesine");
            driver.FindElement(By.Name("base.lastName")).Clear();
            driver.FindElement(By.Name("base.lastName")).SendKeys("Grieg");
            driver.FindElement(By.Name("base.origName")).Clear();
            driver.FindElement(By.Name("base.origName")).SendKeys("Grieg");
            driver.FindElement(By.Name("base.dob")).Clear();
            driver.FindElement(By.Name("base.dob")).SendKeys("0000");
            new SelectElement(driver.FindElement(By.Name("base.title"))).SelectByText("Baron");
            new SelectElement(driver.FindElement(By.Name("base.gender"))).SelectByText("Female");
            new SelectElement(driver.FindElement(By.Name("base.nationality"))).SelectByText("Norwegian");
            driver.FindElement(By.Name("base.Address-0.Country.name")).Clear();
            driver.FindElement(By.Name("base.Address-0.Country.name")).SendKeys("Norway");
            driver.FindElement(By.Name("base.Address-0.City.name")).Clear();
            driver.FindElement(By.Name("base.Address-0.City.name")).SendKeys("Bergen");
            // ERROR: Caught exception [ERROR: Unsupported command [setSpeed | 250 | ]]
            driver.FindElement(By.CssSelector("button.btn.btn-primary")).Click();
            driver.FindElement(By.Name("base.relation")).Click();
            new SelectElement(driver.FindElement(By.Name("base.relation"))).SelectByText("other");
            driver.FindElement(By.CssSelector("option[value=\"other\"]")).Click();
            // Warning: verifyTextNotPresent may require manual changes
            try
            {
                Assert.IsFalse(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Status: 10278 Reason: [\\s\\S]*[\\s\\S]*[\\s\\S]* \\[admin_collector_create\\], 61\\. Errno 515: Cannot insert the value NULL into column 'cityToken', table '@address'; column does not allow nulls\\. INSERT fails\\.[\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Name("base.Address-0.City.name")).Clear();
            driver.FindElement(By.Name("base.Address-0.City.name")).SendKeys("Bergen");
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
