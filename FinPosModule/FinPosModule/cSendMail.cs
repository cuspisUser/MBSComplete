namespace FinPosModule
{
    using System;
    using System.Net.Mail;

    public class cSendMail
    {
        public void SendSMTP(string server, string strFromAddress, string strFromName, string strToAddress, string strToName, string strReplyToAddrr, string strReplyToName, string strSubject, string strBody, string strCC, string strAttachments, string port, string password)
        {
            //MailMessage message = new MailMessage(new MailAddress(strFromAddress, strFromName), new MailAddress(strToAddress, strToName));
            
            //MailMessage message2 = message;
            //message2.Subject = strSubject;
            //message2.Body = strBody;
            //message2.ReplyToList.Add(new MailAddress(strReplyToAddrr, strReplyToName));
            //message2.IsBodyHtml = true;
            //if (!strAttachments.Equals(string.Empty))
            //{
            //    foreach (string str in strAttachments.Split(new char[] { ';' }))
            //    {
            //        message2.Attachments.Add(new Attachment(str.Trim()));
            //    }
            //}
            //message2 = null;

            MailMessage message = new MailMessage();
            message.From = new MailAddress(strFromAddress);
            message.To.Add(new MailAddress(strToAddress));
            message.Body = strBody;
            message.Subject = strSubject;
            if (!strAttachments.Equals(string.Empty))
            {
                foreach (string str in strAttachments.Split(new char[] { ';' }))
                {
                    message.Attachments.Add(new Attachment(str.Trim()));
                }
            }

            System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential(strFromAddress, password);

            new SmtpClient { UseDefaultCredentials = false, Host = server, Port = Convert.ToInt32(port), Credentials = basicauthenticationinfo, EnableSsl = false, DeliveryMethod = SmtpDeliveryMethod.Network }.Send(message);
        }
    }
}

