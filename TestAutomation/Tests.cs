using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using BrowserDriver;

namespace CH_IB_Testing
{

    public class Tests
    {
        Driver driver;
        [SetUp]
        public void start_Browser()
        {

            String test_url = "https://ib-uat.unayo.com/";

            driver = new Driver();
            driver.browser = Driver.Browser.Chrome;
            //driver.browser = Driver.Browser.Firefox;

            driver.Init_Browser();
            driver.Goto(test_url);
        }


        [Test]
        public void testLoginCell()
        {
        }

        [Test]
        public void testLoginLogout()
        {
            WebDriverWait wait = new WebDriverWait(driver.webdriver, TimeSpan.FromSeconds(40));
            IWebElement LoginButton = wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(text(),'Login')]")));
            LoginButton.Click();

            SelectElement oSelect = new SelectElement(driver.webdriver.FindElement(By.Id("MobileInstanceId")));
            oSelect.SelectByValue("3eeb9|BW");

            driver.webdriver.FindElement(By.Id("UserMobNum")).SendKeys("0824269533");
            driver.webdriver.FindElement(By.Id("password_mobile")).SendKeys("13647");
            driver.webdriver.FindElement(By.Id("LOGIN_Mobile_Submit")).Click();

            driver.webdriver.FindElement(By.XPath("//*[@id='topnav']/div[1]/ul[1]/li[4]/a/span/i")).Click();

            Assert.IsTrue(true);
        }

        [TearDown]
        public void close_Browser()
        {
            driver.webdriver.Close();
        }
    }
}

