using System;
using System.Collections.Generic;
using System.Text;

namespace DiaDeBolaClassLibrary
{
    public static class Factory
    {
        public static ITeam CreateTeam(string teamName) 
        {
            return new Team(teamName);
        }

        public static IEvent CreateEvent(IAdmin admin) 
        {
            return new Event(admin);
        }

        public static IAdmin CreateAdmin(string email)
        {
            return new Admin(email);
        }

        public static IPlayer CreatePlayer(string email)
        {
            return new Player(email);
        }

        public static IMessageSender CreateMessageSender()
        {
            return new Emailer();
        }


    }
}
