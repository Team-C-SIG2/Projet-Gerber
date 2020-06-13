using System.Net;
using System.Net.Mail;

namespace IdentityServerAspNetIdentity.Services
{
    public class EmailSender
    {
        public string EmailFrom { get; set; }

        private ICredentialsByHost basicCredential;

        public string User { get; set; }

        public EmailSender(string ApiKey, string EmailFrom)
        {
            this.EmailFrom = EmailFrom;
            this.basicCredential = basicCredential = new NetworkCredential("apikey", ApiKey);
            User = "ESBookshop";
        }



        public void SendEmail(string emailTo, string subject, string body)
        {
            MailMessage message = new MailMessage(EmailFrom, emailTo);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", 587);
            // Credentials are necessary if the server requires the client 
            // to authenticate before it will send email on the client's behalf.
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
            smtpClient.Send(message);
        }
    }
}