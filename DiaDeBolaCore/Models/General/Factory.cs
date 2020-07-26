using DiaDeBolaCore.Data;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace DiaDeBolaCore.Models
{
    public static class Factory
    {
        public static Team CreateTeam(string teamName)
        {
            return new Team() 
            {
                Name = teamName
            };
        }

        public static Event CreateEvent()
        {
            return new Event();
        }

        
        public static Player CreatePlayer()
        {
            return new Player();
        }

        public static IMessageSender CreateMessageSender(MailAddress fromEmail)
        {
            return new Emailer(fromEmail);
        }

        public static MailAddress CreateMailAddress(string email, string displayName)
        {
            return new MailAddress(email, displayName);
        }

        public static SmtpClient CreateSmtpClient(string fromEmail, string fromPassword)
        {
            return new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail, fromPassword)
            };
        }

    }
}
