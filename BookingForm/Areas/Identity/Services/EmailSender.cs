//using Microsoft.AspNetCore.Identity.UI.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using MimeKit;
//using MailKit.Net.Smtp;
//using MailKit.Net.Imap;


//namespace BookingForm.Areas.Identity.Services
//{
//    public class EmailSender : IEmailSender
//    {
//        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
//        {
//            Options = optionsAccessor.Value;
//        }

//        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

//        public Task SendEmailAsync(string sender, string subject, string message)
//        {
//            return Execute(sender, subject);
//        }

//        public Task Execute(string sender, string subject)
//        {
//            var message = new MimeMessage();
//            message.To.Add(new MailboxAddress("Duy Khang", "khang.trinh@annhome.vn"));
//            message.From.Add(new MailboxAddress("Annhome Admin", "office@annhome.vn"));
//            message.Subject = "Email from visual studio";

//            message.Body = new TextPart("plain")
//            {
//                Text = @"Hi Khang, be strong!"
//            };
//            using (var client = new SmtpClient())
//            {
//                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
//                client.Connect("smtp-mail.outlook.com", 587, false);

//                client.Authenticate("office@annhome.vn", "kh@ng1412");//Nnhm2018

//                client.Send(message);
//                client.Disconnect(true);

//            }
//            return SendEmailAsync(message);
//        }
//    }
//}
