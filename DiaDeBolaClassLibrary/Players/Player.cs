using System;
using System.Collections.Generic;
using System.Text;
using static DiaDeBolaClassLibrary.Enums;

namespace DiaDeBolaClassLibrary
{
    public class Player : IPlayer
    {
        public PlayerStatus Status { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        PlayerStatus IPlayer.Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Player(string email) 
        {
            Email = email;
            Status = PlayerStatus.NotContacted;
        }
    }
}
