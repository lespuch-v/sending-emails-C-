using System;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace EmailSendProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MimeMessage message = new MimeMessage();
            // Message from
            message.From.Add(new MailboxAddress("Adam Duma", "testvl@seznam.cz"));

            // Message to 
            message.To.Add(MailboxAddress.Parse("example@gmail.com"));
            message.Subject = "Hello World";
            message.Body = new TextPart("plain")
            {
                Text = @"Yes, 
                Hello!.
                Buy Bitcoin!
                "
            };
            // Authenticate here pass and login info to your account
            string emailAddress = "";
            string password = "";

            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect("smtp.seznam.cz", 587, false);
                client.Authenticate(emailAddress, password);
                client.Send(message);
                Console.WriteLine("Email Sent!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
