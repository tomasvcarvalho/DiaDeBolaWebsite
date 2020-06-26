using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using static DiaDeBolaClassLibrary.Enums;

namespace DiaDeBolaClassLibrary
{
    public class Event : IEvent
    {
        public string Id { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public List<IAdmin> Admins { get; set; }
        public Dictionary<string, ITeam> Teams { get; set; }
        public DateTime DateTime { get; set; }
        public Location Location { get ; set; }
        public EventStatus Status { get; set; }


        public Event() { }

        
        public Event(IEnumerable<IAdmin> admins) 
        {
            Admins = admins.ToList();
            var unplacedPlayers = new Team(Constants.UnplacedPlayersTeamName);
            Teams = new Dictionary<string, ITeam>();
            Teams.Add(unplacedPlayers.Name, unplacedPlayers);
            Status = EventStatus.Created;
            foreach (IAdmin player in Admins)
            {
                AddPlayer(player);
            }
        }

        public void SetLocation(Location location)
        {
            Location = location;
        }

        public void SetMaxNumberOfPlayers(int maxNumberOfPlayers)
        {
            MaxNumberOfPlayers = maxNumberOfPlayers;
        }

        public void SetDateTime(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public void SetEventStatus(EventStatus status)
        {
            Status = status;
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

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }
    }
}
