using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mipsed7.Core;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Mipsed7.Emailing
{
    public class SendEmail
    {
        private MailMessage MailMessage { get; set; }

        public SendEmail(MailMessage mailMessage)
        {
            this.MailMessage = mailMessage;
        }

        public void Send()
        {
            if (MailMessage.To.Count == 1)
                if (!MailMessage.To[0].Address.Contains("@"))
                    return;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = Mipsed7.Core.ApplicationDatabaseInformation.SMTPClient_Exceptions;
            smtp.Credentials = new NetworkCredential("exceptions@vugergrad.hr", Mipsed7.Security.Cryptography.EncodeDecode.Decrypt("yfGbWPE3VJoVSNVgH2btjw=="), "mail.vugergrad.hr");
            smtp.UseDefaultCredentials = false;

            smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
            smtp.SendAsync(MailMessage, System.Guid.NewGuid().ToString());
        }

        void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            string guid = e.UserState.ToString();
        }
    }
}
