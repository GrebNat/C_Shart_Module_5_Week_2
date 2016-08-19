using M5W2.M5W2.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace M5W2.M5W2.PO
{
    public class MainPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "gb_70")] public IWebElement signInButton;


        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }


        public LoginPage NavigateToLoginPage()
        {
            signInButton.Click();
            return new LoginPage(_driver);
        }

        public MainPage Login()
        {
            LoginPage loginPage = NavigateToLoginPage();
            loginPage.Login(User.UserName(), User.Password());
            return this;
        }
    }
}