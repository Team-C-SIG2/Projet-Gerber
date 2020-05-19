using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace IdentityServerAspNetIdentity.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(/*AuthMessageSenderOptions optionsAccessor*/)
        {
            AuthMessageSenderOptions options = new AuthMessageSenderOptions
            {
                SendGridKey = "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",
                SendGridUser = "ESBookshop"
            };
            Options = options;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public async Task<Response> Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("info@esbookshop.ch", Options.SendGridUser);
            var msg = MailHelper.CreateSingleEmail(from, new EmailAddress(email), subject, "", message);
            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
            return response;
        }
    }
}