using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace M5W2.M5W2.Util
{
    public class BrowserManager
    {
        public static IWebDriver GetDriver()
        {
            string driverName = PropertiesGetter.Browser;
            switch (driverName)
            {
                case "chrome":
                    return new ChromeDriver();
                case "ie":
                    return new InternetExplorerDriver();
                case "internet explorer":
                    return new InternetExplorerDriver();
                case "ff":
                    return new FirefoxDriver();
                case "firefox":
                    return new FirefoxDriver();
            }
            
            throw new Exception(
                "Incorrect browser name supply, possible values are 'chrome', 'ie', 'internet explorer', 'ff','firefox'");
        }
    }
}