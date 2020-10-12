using Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UtilModels;



namespace Utils
{
    public class Mailer : IMailer
    {
        private readonly StmpSettings _stmpSettings;
        public Mailer(IOptions<StmpSettings> stmpSettings)
        {
            _stmpSettings = stmpSettings.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_stmpSettings.SenderName, _stmpSettings.SenderEmail));
                message.To.Add(new MailboxAddress(email));
                message.Subject = subject;
                message.Body = new TextPart("html")
                {
                    Text = body
                };
                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    //I am using my own certificate for https. so when trying to connect to google smtp it cannot authenticate the certificate. I used this temp workaround: SecureSocketOptions.Auto.
                    //It means that the mail wont be encrypted.
                    //https://github.com/jstedfast/MailKit/blob/master/FAQ.md#SslHandshakeExceptionhttps://support.google.com/mail/?p=InvalidSecondFactor look for more secure solutions.

                    await client.ConnectAsync(_stmpSettings.Server, _stmpSettings.Port, SecureSocketOptions.Auto);
                    await client.AuthenticateAsync(_stmpSettings.Username, _stmpSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
