using Microsoft.Extensions.Options;
using PWSlaba.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace PWSlaba.Services.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly Helpers.MailSettings _mailSettings;
        public EmailSender(IOptionsMonitor<Helpers.MailSettings> options)
        {
            _mailSettings = options.CurrentValue;
        }
        public EmailSender()
        {

        }
        public async Task SendEmailAsync(string To, string ToName, string Subject, string Body)
        {
            var client = new SendGridClient(_mailSettings.ApiKey);

            string Content = $"Thank you:\n{Body}\nWe will contact you soon";

            SendGridMessage message = new()
            {
                From = new EmailAddress(_mailSettings.Email, _mailSettings.DisplayName),
                Subject = Subject,
                PlainTextContent = Content
            };

            message.AddTo(new EmailAddress(To, ToName));

            await client.SendEmailAsync(message);
        }
    }
}
