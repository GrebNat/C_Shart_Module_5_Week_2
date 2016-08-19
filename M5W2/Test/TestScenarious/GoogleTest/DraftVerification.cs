using M5W2.M5W2.Data;
using M5W2.M5W2.PO;
using M5W2.M5W2.Test.DataProvider;
using NUnit.Framework;

namespace M5W2.M5W2.Test.TestScenarious.GoogleTest
{
    [TestFixture]
    class GoogleTest : BaseTest
    {

        [Test, TestCaseSource(typeof(MailProvider),"testMail")]
        public void VerifyMailSentCorrectly(Mail mail)
        {
            AccountPanel accountPanel = new AccountPanel(driver);

            new MainPage(driver).Login();
            accountPanel.VerifyLogin();

            accountPanel
                    .NavigateMailPage()
                    .CreateNewMail(mail)
                    .CloseMailDialog()
                    .VerifyMailPresentInDraftFolder(mail)
                    .VerifyMailContentInDraftFolder(mail)
                    .SendMail()
                    .VerifyMailPresentInDraftFolder(mail)
                    .VerifyMailPresentInSentFolder(mail);

            accountPanel.Logoff();
        }

    }
}
