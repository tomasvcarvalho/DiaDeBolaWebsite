using System;
using System.Collections.Generic;

namespace DiaDeBolaClassLibrary
{
    public interface IEvent
    {
        string Id { get; set; }
        int MaxNumberOfPlayers { get; set; }
        List<IAdmin> Admins { get; set; }
        DateTime DateTime { get; set; }
        Location Location { get; set; }
        Dictionary<string, ITeam> Teams { get; set; }

        public bool IsPlayerInEvent(IPlayer player);
        public ITeam GetPlayersTeam(IPlayer player);
        public void AddTeam(ITeam team);
        public void RemoveTeam(ITeam team);
        public void AddPlayer(IPlayer player);
        public void RemovePlayer(IPlayer player);
    }
}