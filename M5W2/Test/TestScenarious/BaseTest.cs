using System;
using M5W2.M5W2.Util;
using NUnit.Framework;
using OpenQA.Selenium;

namespace M5W2.M5W2.Test.TestScenarious
{
    class BaseTest
    {
        public IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = BrowserManager.GetDriver();
            driver.Navigate().GoToUrl(PropertiesGetter.Url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
        }


        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
