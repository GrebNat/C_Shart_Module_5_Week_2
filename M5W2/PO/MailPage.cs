﻿using System;
using M5W2.M5W2.Data;
using M5W2.M5W2.PO.Panels;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace M5W2.M5W2.PO
{
    public class MailPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='z0']/div[@role='button' and @tabindex=0]")] public IWebElement createNewMailButton;
        [FindsBy(How = How.CssSelector, Using = ".Am.Al.editable")] public IWebElement mailBodyTextArea;
        [FindsBy(How = How.CssSelector, Using = ".aoD.hl")] public IWebElement sendToElement;
        [FindsBy(How = How.CssSelector, Using = ".wO.nr.l1 > textarea")] public IWebElement sendToTextField;
        [FindsBy(How = How.CssSelector, Using = ".aoD.hl span[email]")] public IWebElement sendToTextFieldForRead;
        [FindsBy(How = How.CssSelector, Using = "[name='subjectbox']")] public IWebElement subjectTextField;
        [FindsBy(How = How.CssSelector, Using = "[name = 'subject']")] public IWebElement subjectTextFieldForRead;
        [FindsBy(How = How.CssSelector, Using = ".Hm>.Ha")] public IWebElement closeMailDialogButton;
        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'draft')]")] public IWebElement draftLink;
        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'sent')]")] public IWebElement sentLink;
        [FindsBy(How = How.CssSelector, Using = ".n1tfz .gU.Up [role='button']")] public IWebElement sendButton;

        public MailListPanelAbstract draftMailListPanel;
        public MailListPanelAbstract sentMailListPanel;
        public MailListPanelAbstract inboxMailListPanel;
        public MailPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            draftMailListPanel = new MailListPanel(_driver);
            draftMailListPanel = new DraftMailListPanel(draftMailListPanel);
            sentMailListPanel = new MailListPanel(_driver);
            sentMailListPanel = new SentMailListPanel(sentMailListPanel);

        }

        public MailPage CreateNewMail(Mail mail)
        {
            createNewMailButton.Click();
            PopulateMailContent(mail);
            sendToElement.Click();
            sendToTextField.SendKeys(mail.mailTo);
            subjectTextField.SendKeys(mail.subject);

            return this;
        }

        public void PopulateMailContent(Mail mail)
        {
            mailBodyTextArea.SendKeys(mail.body);
        }

        public MailPage VerifyMailPresentInDraftFolder(Mail mail)
        {
            draftLink.Click();
            Assert.True(draftMailListPanel.IsMailPresent(mail));
            return this;
        }

        public MailPage VerifyMailContentInDraftFolder(Mail mail)
        {
            draftLink.Click();
    
            draftMailListPanel.OpenMail(mail);

            Assert.AreEqual(mail.body, mailBodyTextArea.Text);
            sendToTextFieldForRead.Click();
            Assert.AreEqual(mail.mailTo, sendToTextFieldForRead.GetAttribute("email"));
            Assert.AreEqual(mail.subject, subjectTextFieldForRead.GetAttribute("value"));

            return this;
        }

        public MailPage VerifyMailNotPresentInDraftFolder(Mail mail)
        {
            draftLink.Click();
            Assert.False(draftMailListPanel.IsMailPresentAfterWait(mail));
            return this;
        }

        public MailPage VerifyMailPresentInSentFolder(Mail mail)
        {
            sentLink.Click();
            Assert.True(draftMailListPanel.IsMailPresent(mail));
            return this;
        }

        public MailPage CloseMailDialog()
        {
            closeMailDialogButton.Click();
            return this;
        }

        public MailPage SendMail()
        {
            sendButton.Click();
            return this;
        }
    }
}
