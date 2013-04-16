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
    public class LLPayment
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
        public void TheLLPaymentTest()
        {
            String demo = "http://demo.larryslist.de/";
            String dev = "http://dev.larryslist.de/";
            // Speed below 350 results in an Internal Server Error
            // ERROR: Caught exception [ERROR: Unsupported command [setSpeed | 400 | ]]
            driver.Navigate().GoToUrl(baseURL + dev + "logout");
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
            driver.FindElement(By.XPath("//div[@id='global-frame']/div/div/div/ul/li[4]/a/span")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.Name("login.email"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            driver.FindElement(By.Name("login.email")).Clear();
            driver.FindElement(By.Name("login.email")).SendKeys("test@friendfund.com");
            driver.FindElement(By.Name("login.pwd")).Clear();
            driver.FindElement(By.Name("login.pwd")).SendKeys("123");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//div[@id='global-frame']/div[3]/div[2]/div[2]/div[2]/div[2]/div/ul/li[4]/div/div[5]/p"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            driver.FindElement(By.XPath("//li[4]/a")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Account"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=Account | ]]
            driver.FindElement(By.LinkText("Account")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Buy more credits"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=Buy more credits | ]]
            driver.FindElement(By.LinkText("Buy more credits")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("(//button[@name='formdata.option'])[2]"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=span.price-quantity | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | name=formdata.option | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //div[@id='global-frame']/div[3]/div/div/div/div/form/div/div/div[3]/span[3] | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | xpath=(//button[@name='formdata.option'])[3] | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //div[@id='global-frame']/div[3]/div/div/div/div/form/div/div/div[2]/span[3] | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | xpath=(//button[@name='formdata.option'])[2] | ]]
            driver.FindElement(By.XPath("(//button[@name='formdata.option'])[2]")).Click();
            // Wrong Payment (CVV)
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.Name("pay"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            driver.FindElement(By.Id("card.cardNumber")).Clear();
            driver.FindElement(By.Id("card.cardNumber")).SendKeys("4111111111111111");
            driver.FindElement(By.Id("card.cardHolderName")).Clear();
            driver.FindElement(By.Id("card.cardHolderName")).SendKeys("test signs:  亰é Ö € ?");
            new SelectElement(driver.FindElement(By.Id("card.expiryMonth"))).SelectByText("");
            new SelectElement(driver.FindElement(By.Id("card.expiryYear"))).SelectByText("");
            driver.FindElement(By.Id("card.cvcCode")).Clear();
            driver.FindElement(By.Id("card.cvcCode")).SendKeys("wrong");
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | id=card.cvcCode | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | name=pay | ]]
            driver.FindElement(By.Name("pay")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("span.red"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // Wrong Payment (EXPIRY DAY)
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.Name("pay"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=span.red | ]]
            driver.FindElement(By.Id("card.cardNumber")).Clear();
            driver.FindElement(By.Id("card.cardNumber")).SendKeys("4111111111111111");
            driver.FindElement(By.Id("card.cardHolderName")).Clear();
            driver.FindElement(By.Id("card.cardHolderName")).SendKeys("test signs:  亰é Ö € ? one time more ...");
            new SelectElement(driver.FindElement(By.Id("card.expiryMonth"))).SelectByText("");
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | id=card.expiryMonth | ]]
            new SelectElement(driver.FindElement(By.Id("card.expiryYear"))).SelectByText("");
            driver.FindElement(By.Id("card.cvcCode")).Clear();
            driver.FindElement(By.Id("card.cvcCode")).SendKeys("737");
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | name=pay | ]]
            driver.FindElement(By.Name("pay")).Click();
            // Page should redirect
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("div.alert.alert-error"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // Warning: waitForTextPresent may require manual changes
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Payment Failed! [\\s\\S]*$")) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            driver.FindElement(By.LinkText("×")).Click();
            // use Account and try to buy Credits again
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //li[4]/a | ]]
            driver.FindElement(By.XPath("//li[4]/a")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Account"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=Account | ]]
            driver.FindElement(By.LinkText("Account")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Buy more credits"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=Buy more credits | ]]
            driver.FindElement(By.LinkText("Buy more credits")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("(//button[@name='formdata.option'])[2]"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //div[@id='global-frame']/div[3]/div/div/div/div/form/div/div/div[2]/span[3] | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | xpath=(//button[@name='formdata.option'])[2] | ]]
            driver.FindElement(By.XPath("(//button[@name='formdata.option'])[2]")).Click();
            // Payment should be SUCCESSFUL
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.Name("pay"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            driver.FindElement(By.Id("card.cardNumber")).Clear();
            driver.FindElement(By.Id("card.cardNumber")).SendKeys("4111111111111111");
            driver.FindElement(By.Id("card.cardHolderName")).Clear();
            driver.FindElement(By.Id("card.cardHolderName")).SendKeys("test signs:  亰é Ö € ?");
            new SelectElement(driver.FindElement(By.Id("card.expiryMonth"))).SelectByText("");
            new SelectElement(driver.FindElement(By.Id("card.expiryYear"))).SelectByText("");
            driver.FindElement(By.Id("card.cvcCode")).Clear();
            driver.FindElement(By.Id("card.cvcCode")).SendKeys("737");
            driver.FindElement(By.Name("pay")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("div.alert.alert-success"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // Warning: verifyTextPresent may require manual changes
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Payment Successful! [\\s\\S]*$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=div.alert.alert-success | ]]
            driver.FindElement(By.LinkText("×")).Click();
            // LOGOUT
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //li[4]/a | ]]
            driver.FindElement(By.XPath("//li[4]/a")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=Logout | ]]
            driver.FindElement(By.LinkText("Logout")).Click();
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
