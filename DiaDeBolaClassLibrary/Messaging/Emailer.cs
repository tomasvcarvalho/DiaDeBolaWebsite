using System;
using System.Net;
using System.Net.Mail;
using static DiaDeBolaClassLibrary.Constants;

namespace DiaDeBolaClassLibrary
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

        public void SendMessage(IPlayer player, string messageSubject, string messageBody)
        {
            SmtpClient smtp = Factory.CreateSmtpClient(FromAddress.Address, FromPassword);
            MailAddress toAddress = Factory.CreateMailAddress(player.Email, player.FullName);

            using (MailMessage message = new MailMessage(FromAddress, toAddress)
            {
                Subject = messageSubject,
                Body = messageBody
            })
            {
                Console.WriteLine($"Sending message '{messageBody}' to {player.FirstName}");
                smtp.Send(message);
            }

        }
    }
}
