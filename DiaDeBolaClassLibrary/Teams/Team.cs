using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiaDeBolaClassLibrary
{
    public class Team : ITeam
    {
        public string Name { get; set; }
        public List<IPlayer> Members { get; set; }
        public Enums.EquipmentColor EquipmentColor { get; set; }

        public int MaxNumberOfPlayers{ get; set; }

        public Team(string name) 
        {
            Name = name;
            Members = new List<IPlayer>();
            EquipmentColor = Enums.EquipmentColor.NotAttributed;
        }

        public bool IsPlayerInTeam(IPlayer player) 
        {
            return Members.Contains(player);
        }

        public void AddPlayer(IPlayer player)
        {
            if (!IsPlayerInTeam(player)) 
            {
                Members.Add(player);
            }
        }

        public void RemovePlayer(IPlayer player)
        {
            if (IsPlayerInTeam(player))
            {
                Members.Remove(player);
            }
        }
    }
}
