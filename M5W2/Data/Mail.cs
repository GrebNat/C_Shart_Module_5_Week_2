using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5W2.M5W2.Data

{

    public class Mail : IMail
    {

        protected string mailTo;
        protected string body;
        protected string subject;


        string IMail.Body => body;
        string IMail.MailTo => mailTo;
        string IMail.Subject => subject;

    }

    public class CorrectMail : Mail
    {


        public CorrectMail(string mailTo, string body, string subject)
        {
            if (mailTo.Contains("@") & mailTo.Contains("."))
                this.mailTo = mailTo;
            else
                throw new System.ArgumentException("invalid 'mailTo' exception");
            this.body = body;
            this.subject = subject;
        }
       
    }

    public class WrongMail : Mail
    {
        public WrongMail(string mailTo, string body, string subject)
        {

            if (!(mailTo.Contains("@") & mailTo.Contains(".")))
                this.mailTo = mailTo;
            else
                throw new System.ArgumentException("invalid 'mailTo' exception, format should be invailid");
            this.body = body;
            this.subject = subject;

        }
    }
}
