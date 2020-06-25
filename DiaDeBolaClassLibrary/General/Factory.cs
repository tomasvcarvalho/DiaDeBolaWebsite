using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DiaDeBolaClassLibrary
{
    public static class Factory
    {
        public static ITeam CreateTeam(string teamName)
        {
            return new Team(teamName);
        }

        public static IEvent CreateEvent(IEnumerable<IAdmin> admins)
        {
            return new Event(admins);
        }

        public static IAdmin CreateAdmin(string email)
        {
            return new Admin(email);
        }

        public static IPlayer CreatePlayer(string email)
        {
            return new Player(email);
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
