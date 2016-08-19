using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M5W2.M5W2.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace M5W2.M5W2.PO.Panels
{
    interface IMailListPanel
    {
        string RowTemplate { get; set; }
        Boolean IsMailPresent(Mail mail);
    }

    public class MailListPanel:IMailListPanel
    {
        private IWebDriver _driver;

        public MailListPanel(IWebDriver driver)
        {
            _driver = driver;
        }

        public string RowTemplate { get; set; }
        public Boolean IsMailPresent(Mail mail)
        {
            return _driver.FindElement(By.XPath(string.Format(RowTemplate, mail.subject, mail.body))).Displayed;
        }
    }

    public abstract class MailListDecorator : MailListPanel
    {
        protected MailListPanel mailListPanel;

        protected MailListDecorator() 
        {
        }

        protected MailListDecorator(MailListPanel mailListPanel)
        {
            this.mailListPanel = mailListPanel;
        }
        
    }
}
