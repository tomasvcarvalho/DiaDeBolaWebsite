using System;
using System.Collections.Generic;
using System.Text;
using static DiaDeBolaClassLibrary.Enums;

namespace DiaDeBolaClassLibrary
{
    public interface IPlayer : IRegisteredUser
    {
        public PlayerStatus Status { get; set; }
        
    }
}
