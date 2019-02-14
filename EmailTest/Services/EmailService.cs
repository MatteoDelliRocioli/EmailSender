using EmailTest.Configs;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailTest.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfig ec;

        public EmailService(IOptions<EmailConfig> emailConfig)
        {
            this.ec = emailConfig.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(ec.FromName, ec.FromAddress));
                emailMessage.To.Add(new MailboxAddress("Foreign", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(TextFormat.Html) { Text = message };

                using (var client = new SmtpClient())
                {
                    client.LocalDomain = ec.LocalDomain;

                    await client.ConnectAsync(ec.MailServerAddress, Convert.ToInt32(ec.MailServerPort), SecureSocketOptions.Auto).ConfigureAwait(false);
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
