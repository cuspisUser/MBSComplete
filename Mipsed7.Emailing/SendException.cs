using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;
using System.Management;

namespace Mipsed7.Emailing
{
    public class SendException
    {
        private Exception Exception { get; set; }

        public SendException(Exception exception)
        {
            this.Exception = exception;
        }

        public void Send()
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage("exceptions@vugergrad.hr", "exceptions@vugergrad.hr", string.Empty, string.Empty);
            
            try
            {
                mailMessage.Subject = "MBS.Complete - " + Mipsed7.Core.ApplicationDatabaseInformation.KorisnikAplikacije + " - " + Mipsed7.Core.ApplicationDatabaseInformation.OIB + " - " + System.Environment.MachineName + " - " + this.Exception.Message;
            }
            catch (Exception)
            {
                mailMessage.Subject = "MBS.Complete - " + Mipsed7.Core.ApplicationDatabaseInformation.KorisnikAplikacije + " - " + Mipsed7.Core.ApplicationDatabaseInformation.OIB + " - " + System.Environment.MachineName + " - Exception";
            }

            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

            StringBuilder body = new StringBuilder();

            body.Append("<div style='font: 12px Arial;'><b style='font-size: 14px;'>");
            body.AppendLine(this.Exception.Message + "</b><br />");

            body.AppendLine("-------------------------------------------------------------------------------------------------------------------------");
            body.AppendLine("Računalo: " + System.Environment.MachineName);
            body.AppendLine("Korisnik: " + System.Environment.UserName);
            body.AppendLine("OS: " + GetOSFriendlyName() + " - " + Is32Or64());
            body.AppendLine("Datum i vrijeme: " + DateTime.Now.ToString());
            body.AppendLine("-------------------------------------------------------------------------------------------------------------------------");
            body.AppendLine("Source: " + this.Exception.Source);
            body.AppendLine("Target: " + this.Exception.TargetSite.ToString());

            if (this.Exception.InnerException != null)
            {
                body.AppendLine(this.Exception.InnerException.Message);
                body.AppendLine("-------------------------------------------------------------------------------------------------------------------------");
            }

            body.AppendLine(this.Exception.StackTrace);
            body.AppendLine("-------------------------------------------------------------------------------------------------------------------------");
            body.AppendLine("ApplicationVersion: " + Mipsed7.Core.ApplicationDatabaseInformation.ProgramVersion);
            body.AppendLine("DatabaseVersion: " + Mipsed7.Core.ApplicationDatabaseInformation.DatabaseVersion);
            body.AppendLine(string.Empty);
            body.AppendLine("ServerName: " + Mipsed7.Core.ApplicationDatabaseInformation.ServerName);
            body.AppendLine("DatabaseName: " + Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName);
            body.AppendLine(string.Empty);
            body.AppendLine("SqlUserName: " + Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName_REGISTRY_ORIGINAL);
            body.AppendLine("SqlPassword: " + Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword_REGISTRY_ORIGINAL);
            body.AppendLine("-------------------------------------------------------------------------------------------------------------------------");
            body.AppendLine("Send through: " + Mipsed7.Core.ApplicationDatabaseInformation.SMTPClient_Exceptions);
            body.Append("</div>");

            mailMessage.Body = body.ToString().Replace(Environment.NewLine, "<br />");


            StringBuilder message = new StringBuilder();

            try
            {
                new Mipsed7.Emailing.SendEmail(mailMessage).Send();

                message.AppendLine("GREŠKA: informacija o grešci je poslana razvojnom timu!");
                message.AppendLine(string.Empty);
                message.AppendLine("--------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            message.AppendLine(this.Exception.Message);
            message.AppendLine("--------------------------------------------------------------------------");
            message.AppendLine(this.Exception.StackTrace);

        }

        public void DatabaseUpdateFailed(string new_version, string old_verzion)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage("exceptions@vugergrad.hr", "exceptions@vugergrad.hr", string.Empty, string.Empty);

            mailMessage.Subject = "MIPSED.7 - " + Mipsed7.Core.ApplicationDatabaseInformation.KorisnikAplikacije + " - " + Mipsed7.Core.ApplicationDatabaseInformation.OIB + " - " + System.Environment.MachineName + " - Database update failed";

            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

            StringBuilder body = new StringBuilder();

            body.Append("<div style='font: 12px Arial;'><b style='font-size: 14px;'>");
            body.AppendLine("Dogodila se greška prilikom update-a baze.</b><br />");
            body.AppendLine("-------------------------------------------------------------------------------------------------------------------------");
            body.AppendLine("Računalo: " + System.Environment.MachineName);
            body.AppendLine("Korisnik: " + System.Environment.UserName);
            body.AppendLine("OS: " + GetOSFriendlyName() + " - " + Is32Or64());
            body.AppendLine("Datum i vrijeme: " + DateTime.Now.ToString());
            body.AppendLine("-------------------------------------------------------------------------------------------------------------------------");
            body.AppendLine("Verzija prije update-a: " + old_verzion);
            body.AppendLine("Verzija poslje update-a: " + new_version);
            body.AppendLine(string.Empty);
            body.AppendLine("ServerName: " + Mipsed7.Core.ApplicationDatabaseInformation.ServerName);
            body.AppendLine("DatabaseName: " + Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName);
            body.AppendLine(string.Empty);
            body.AppendLine("SqlUserName: " + Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName_REGISTRY_ORIGINAL);
            body.AppendLine("SqlPassword: " + Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword_REGISTRY_ORIGINAL);
            body.AppendLine("-------------------------------------------------------------------------------------------------------------------------");
            body.AppendLine("Send through: " + Mipsed7.Core.ApplicationDatabaseInformation.SMTPClient_Exceptions);
            body.Append("</div>");

            mailMessage.Body = body.ToString().Replace(Environment.NewLine, "<br />");


            StringBuilder message = new StringBuilder();

            try
            {
                new Mipsed7.Emailing.SendEmail(mailMessage).Send();

                message.AppendLine("GREŠKA: informacija o grešci je poslana razvojnom timu!");
                message.AppendLine(string.Empty);
                message.AppendLine("--------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            message.AppendLine(this.Exception.Message);
            message.AppendLine("--------------------------------------------------------------------------");
            message.AppendLine(this.Exception.StackTrace);

        }

        public static string Is32Or64()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                return "64bit";
            }
            else
            {
                return "32bit";
            }
        }

        public static string GetOSFriendlyName()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }
            return result;
        }
    }
}
