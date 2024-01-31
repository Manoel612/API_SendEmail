using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using SendEmail.Interfaces;
using SendEmail.Models;
using MailKit.Net.Smtp;

namespace SendEmail.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config) 
        {
            _config = config;
        }
        public void SendEmail(MessageModel request)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUser").Value));
            message.To.Add(MailboxAddress.Parse(request.To));
            message.Subject = request.Subject;
            message.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using SmtpClient smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUser").Value, _config.GetSection("EmailPassWord").Value);
            smtp.Send(message);
            smtp.Disconnect(true);

        }
    }
}
