using BrowserDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Utilities
{
    public class Utils
    {
        Driver _driver;
        public Utils(Driver driver)
        {
            _driver = driver;
        }
        public void Login()
        {
            WebDriverWait wait = new WebDriverWait(_driver.webdriver, TimeSpan.FromSeconds(40));
            IWebElement LoginButton = wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(text(),'Login')]")));
            LoginButton.Click();
        }

    }
}
