using System;
using System.Collections.Generic;

namespace DiaDeBolaClassLibrary
{
    public class Event : IEvent
    {
        public int MaxNumberOfPlayers { get; set; }
        public List<IAdmin> Admins { get; set; }
        public Dictionary<string, ITeam> Teams { get; set; }
        public DateTime DateTime { get; set ; }
        public ILocation Location { get ; set ; }


        public Event(IAdmin admin) 
        {
            Admins = new List<IAdmin>() { admin };
            var unplacedPlayers = new Team(Constants.UnplacedPlayersTeamName);
            Teams = new Dictionary<string, ITeam>();
            Teams.Add(unplacedPlayers.Name, unplacedPlayers);
            AddPlayer(admin);
        }

        public ITeam GetPlayersTeam(IPlayer player)
        {
            foreach (ITeam team in Teams.Values)
            {
                if (team.IsPlayerInTeam(player))
                {
                    return team;
                }
            }

            return null;
        }

        public bool IsPlayerInEvent(IPlayer player) => GetPlayersTeam(player) != null;

        public bool IsTeamInEvent(ITeam team) => Teams.ContainsValue(team);

        public void AddTeam(ITeam team)
        {
            if (!IsTeamInEvent(team)) 
            {
                Teams.Add(team.Name, team);
            }
        }

        public void RemoveTeam(ITeam team)
        {
            if (IsTeamInEvent(team))
            {
                Teams.Remove(team.Name);
            }
        }

        public void AddPlayer(IPlayer player)
        {
            if (Teams != null && !IsPlayerInEvent(player)) 
            {
                Teams[Constants.UnplacedPlayersTeamName].AddPlayer(player);
            }
        }

        public void AddPlayerToTeam(IPlayer player, ITeam team)
        {
            AddPlayer(player);
            Teams[Constants.UnplacedPlayersTeamName].RemovePlayer(player);
            team.AddPlayer(player);
        }

        public void RemovePlayer(IPlayer player)
        {
            var team = GetPlayersTeam(player);

            if (team != null)
            {
                team.RemovePlayer(player);
            }
        }
    }
}
