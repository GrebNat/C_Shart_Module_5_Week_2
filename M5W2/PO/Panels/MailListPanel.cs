using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using M5W2.M5W2.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace M5W2.M5W2.PO.Panels
{
    public abstract class MailListPanelAbstract
    {
        public IWebDriver _driver;

        public MailListPanelAbstract(IWebDriver driver)
        {
            _driver = driver;
        }

        public string RowTemplate { get; set; }
        public abstract Boolean IsMailPresent(Mail mail);
        public abstract Boolean IsMailListEmpty(Mail mail);
        public abstract void OpenMail(Mail mail);
        public abstract Boolean IsMailPresentAfterWait(Mail mail);
    }

    public class MailListPanel : MailListPanelAbstract
    {
        public MailListPanel(IWebDriver driver) : base(driver)
        {
        }

        public override Boolean IsMailPresent(Mail mail)
        {
            return _driver.FindElement(By.XPath(string.Format(RowTemplate, mail.subject, mail.body))).Displayed;
        }

        public override bool IsMailListEmpty(Mail mail)
        {
            throw new NotImplementedException();
        }

        public override void OpenMail(Mail mail)
        {
            _driver.FindElement(By.XPath(string.Format(RowTemplate, mail.subject, mail.body))).Click();
        }

        public override Boolean IsMailPresentAfterWait(Mail mail)
        {
            int timer = 20, i = 0;

            while (i < timer)
            {
                if (IsMailPresent(mail))
                    return true;

                Thread.Sleep(1000);
                i++;
            }

            return false;
        }
    }

    abstract class MailListDecorator : MailListPanelAbstract
    {
        protected MailListPanelAbstract mailListPanelAbstract;

        public MailListDecorator(MailListPanelAbstract mailListPanelAbstract) : base(mailListPanelAbstract._driver)
        {
            this.mailListPanelAbstract = mailListPanelAbstract;
        }

        public override bool IsMailPresent(Mail mail)
        {
            return mailListPanelAbstract.IsMailPresent(mail);
        }

        public override bool IsMailListEmpty(Mail mail)
        {
            return mailListPanelAbstract.IsMailListEmpty(mail);
        }

        public override void OpenMail(Mail mail)
        {
            mailListPanelAbstract.OpenMail(mail);
        }

        public override Boolean IsMailPresentAfterWait(Mail mail)
        {
           return mailListPanelAbstract.IsMailPresentAfterWait(mail);
        }
    }

    class InputMailListPanel : MailListDecorator
    {
        public InputMailListPanel( MailListPanelAbstract mailListPanelAbstract) : base(mailListPanelAbstract)
        {
        }

        public void SelectSochialTab()
        {

        }

    }

    class DraftMailListPanel : MailListDecorator
    {
        public DraftMailListPanel(MailListPanelAbstract mailListPanelAbstract) : base(mailListPanelAbstract)
        {
            mailListPanelAbstract.RowTemplate = "//div[@class='y6']/span[text()='{0}']/../span[contains(text(),'{1}')]";
        }

    }
    class SentMailListPanel : MailListDecorator
    {
        public SentMailListPanel(MailListPanelAbstract mailListPanelAbstract) : base(mailListPanelAbstract)
        {
            mailListPanelAbstract.RowTemplate = "//tr[contains(@class,'zA')]//span[@email='{0}']/../../..//*[text()='{1}']";
    }

    }
}
