using System;
using System.Collections.Generic;
using System.Text;

namespace DiaDeBolaClassLibrary
{
    public interface IMessageSender
    {
        public void SendMessage(IPlayer player, string message);

    }
}
