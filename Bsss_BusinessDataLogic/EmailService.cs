using Azure.Identity;
using BsssCommon;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsssBLogic
{

    public class EmailService
    {
        public void SendEmail(string subject, string body)
        {
            
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("BookSerene Transaction", "do-not-reply@bookserene.com"));
            message.To.Add(new MailboxAddress("Name", "user@example.com"));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            
            using (var client = new SmtpClient())
            {
                var smtpHost = "sandbox.smtp.mailtrap.io";
                var smtpPort = 2525;
                var tls = MailKit.Security.SecureSocketOptions.StartTls;

                client.Connect(smtpHost, smtpPort, tls);

                var userName = "18aa49a939f031";
                var password = "94bdddecd00c0b";

                client.Authenticate(userName, password);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}

