using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WithHangFire.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendMail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("wacsk19921002@gmail.com", "wacsk19921002@gmail.com"));
            message.To.Add(new MailboxAddress("clivekumara@gmail.com", "clivekumara@gmail.com"));
            message.Subject = "aaaa";
            message.Body = new TextPart("plain")
            {
                Text = "bbbbbbbb"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("wacsk19921002@gmail.com", "Sandun#123");
                await client.SendAsync(message);
                client.Disconnect(true);

            }
        }
    }
}
