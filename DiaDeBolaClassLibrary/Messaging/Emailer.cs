using System;
using System.Collections.Generic;
using System.Text;

namespace DiaDeBolaClassLibrary
{
    public class Emailer : IMessageSender
    {
        public Emailer() 
        {
        
        }
        
        public void SendMessage(IPlayer player, string message)
        {
            Console.WriteLine($"Sending message '{message}' to {player.Email}");
        }
    }
}
