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
    public class LLSignup
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
        public void TheLLSignupTest()
        {
            // ERROR: Caught exception [ERROR: Unsupported command [getEval |  | ]]
            String demo = "http://demo.larryslist.de/";
            String dev = "http://dev.larryslist.de/";
            driver.Navigate().GoToUrl(baseURL + dev + "logout");
            // ERROR: Caught exception [ERROR: Unsupported command [setSpeed | 300 | ]]
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("(//input[@type='text'])[2]"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            driver.FindElement(By.XPath("(//input[@type='text'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[2]")).SendKeys("Wri");
            driver.FindElement(By.XPath("(//input[@type='text'])[2]")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//body/div[4]"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [clickAt | //body/div[4] | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [clickAt | //body/div[4] | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | //body/div[4] | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [mouseDownAt | css=ul.entity-search | Richard Wright]]
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//body/div[4]/ul/li"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            driver.FindElement(By.XPath("//body/div[4]/ul/li")).Click();
            driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Buy"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=Buy | ]]
            driver.FindElement(By.LinkText("Buy")).Click();
            // View Selection
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("(//a[contains(text(),'View Selection')])[2]"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | xpath=(//a[contains(text(),'View Selection')])[2] | ]]
            driver.FindElement(By.XPath("(//a[contains(text(),'View Selection')])[2]")).Click();
            // Click on Search for Profiles
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Search for profiles"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=Search for profiles | ]]
            driver.FindElement(By.LinkText("Search for profiles")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Buy"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // View Selection Again
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("(//a[contains(text(),'View Selection')])[2]"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | xpath=(//a[contains(text(),'View Selection')])[2] | ]]
            driver.FindElement(By.XPath("(//a[contains(text(),'View Selection')])[2]")).Click();
            // Deselect
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Deselect"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=Deselect | ]]
            driver.FindElement(By.LinkText("Deselect")).Click();
            // SIGNUP NOW
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=Buy credits now | ]]
            driver.FindElement(By.LinkText("Buy credits now")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.Name("formdata.option"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=span.price-quantity | ]]
            driver.FindElement(By.Name("formdata.option")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("div.form-actions > button.btn.btn-primary"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            driver.FindElement(By.Name("signup.name")).Clear();
            driver.FindElement(By.Name("signup.name")).SendKeys("test signs:  亰é Ö € ?");
            driver.FindElement(By.Name("signup.email")).Clear();
            driver.FindElement(By.Name("signup.email")).SendKeys(email);
            driver.FindElement(By.Name("signup.pwd")).Clear();
            driver.FindElement(By.Name("signup.pwd")).SendKeys("12345");
            driver.FindElement(By.Name("signup.pwdconfirm")).Clear();
            driver.FindElement(By.Name("signup.pwdconfirm")).SendKeys("12345");
            driver.FindElement(By.CssSelector("div.form-actions > button.btn.btn-primary")).Click();
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("span.help-inline"))) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=span.help-inline | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=terms of use | ]]
            driver.FindElement(By.LinkText("terms of use")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectPopUp |  | ]]
            // Warning: waitForTextPresent may require manual changes
            for (int second = 0;; second++) {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (Regex.IsMatch(driver.FindElement(By.CssSelector("BODY")).Text, "^[\\s\\S]*Terms[\\s\\S]*$")) break;
                }
                catch (Exception)
                {}
                Thread.Sleep(1000);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | css=h4.title | ]]
            driver.Close();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow |  | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | name=signup.agreeTOS | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [highlight | link=terms of use | ]]
            driver.FindElement(By.Name("signup.agreeTOS")).Click();
            // PAY
            driver.FindElement(By.CssSelector("div.form-actions > button.btn.btn-primary")).Click();
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
            driver.FindElement(By.Id("card.cardHolderName")).SendKeys("亰é Ö € buy one credit");
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
