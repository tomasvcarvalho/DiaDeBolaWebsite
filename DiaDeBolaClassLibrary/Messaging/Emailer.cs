using System;
using System.Net;
using System.Net.Mail;
using static DiaDeBolaClassLibrary.Constants;

namespace DiaDeBolaClassLibrary
{
    public class Emailer : IMessageSender
    {
        MailAddress FromAddress = new MailAddress(EmailAddress, EmailName);
        const string FromPassword = EmailPassword;

        public Emailer() 
        {
        
        }
        
        public void SendConfirmationMessage(IPlayer player, string messageSubject, string messageBody)
        {
           
            MailAddress toAddress = new MailAddress(player.Email, $"{player.FirstName} {player.LastName}");
           

            Console.WriteLine($"Sending message '{messageBody}' to {player.Email}");

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(FromAddress.Address, FromPassword)
            };
            using (var message = new MailMessage(FromAddress, toAddress)
            {
                Subject = messageSubject,
                Body = messageBody
            })
            {
                smtp.Send(message);
            }

        }
    }
}
