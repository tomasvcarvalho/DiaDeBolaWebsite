using System;
using System.Collections.Generic;
using System.Linq;

namespace DiaDeBolaClassLibrary
{
    public interface IEvent
    {
        int MaxNumberOfPlayers { get; set; }
        List<IAdmin> Admins { get; set; }
        DateTime DateTime { get; set; }
        ILocation Location { get; set; }
        Dictionary<string, ITeam> Teams { get; set; }

        public bool IsPlayerInEvent(IPlayer player);
        public ITeam GetPlayersTeam(IPlayer player);
        public void AddTeam(ITeam team);
        public void RemoveTeam(ITeam team);
        public void AddPlayer(IPlayer player);
        public void RemovePlayer(IPlayer player);
    }
}