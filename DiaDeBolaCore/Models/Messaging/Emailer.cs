using System;
using System.Net.Mail;
using static DiaDeBolaCore.Models.Constants;

namespace DiaDeBolaCore.Models
{
    public class Emailer : IMessageSender
    {
        MailAddress FromAddress { get; set; }
        string FromPassword { get; set; }

        public Emailer(MailAddress fromAddress)
        {
            FromAddress = fromAddress;
            FromPassword = EmailPassword;
        }

        public void SendMessage(Player player, string messageSubject, string messageBody)
        {
            SmtpClient smtp = Factory.CreateSmtpClient(FromAddress.Address, FromPassword);
            MailAddress toAddress = new MailAddress(player.User.Email, player.User.FirstName);

            using (MailMessage message = new MailMessage(FromAddress, toAddress)
            {
                Subject = messageSubject,
                Body = messageBody
            })
            {
                Console.WriteLine($"Sending message '{messageBody}' to {player.User.FirstName}");
                smtp.Send(message);
            }

        }
    }
}
