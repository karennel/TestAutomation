using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace BrowserDriver
{
    public class Driver
    {
        public Driver()
        {

        }

        private IWebDriver _webdriver;
        public IWebDriver webdriver
        {
            get { return _webdriver; }
            set { _webdriver = value; }
        }

        private Browser _browser;
        public Browser browser
        {
            get { return _browser; }
            set { _browser = value; }
        }

        public void Init_Browser()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            switch (browser)
            {
                case Browser.Chrome:
                    webdriver = new ChromeDriver($"{path}/drivers");
                    webdriver.Manage().Window.Maximize();
                    break;
                case Browser.Firefox:
                    webdriver = new FirefoxDriver($"{path}/drivers");
                    webdriver.Manage().Window.Maximize();
                    break;
            }
        }

        public void Goto(string url)
        {
            webdriver.Url = url;
        }

        public enum Browser
        {
            Chrome,
            Firefox
        }
    }
}
