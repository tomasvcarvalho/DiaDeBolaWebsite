using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DiaDeBolaClassLibrary
{
    public class EventMapper
    {
        string Id;
        int MaxNumberOfPlayers;
        string Admins;
        string DateTime;
        string Location;
        string Teams;

        public Event ToEvent() 
        {
            var gameAdmins = JsonSerializer.Deserialize<List<IAdmin>>(Admins);
            var gameLocation = JsonSerializer.Deserialize<Location>(Location);
            var gameTeams = JsonSerializer.Deserialize<List<ITeam>>(Teams);
            var teamsDict = gameTeams.ToDictionary(g => g.Name, g => g);

            Event mappedEvent = new Event(gameAdmins);
            mappedEvent.Id = Id;
            mappedEvent.MaxNumberOfPlayers = MaxNumberOfPlayers;
            mappedEvent.Location = gameLocation;
            mappedEvent.Teams = teamsDict;

            if (System.DateTime.TryParse(DateTime, out DateTime newDateTime))
            {
                mappedEvent.DateTime = newDateTime;

            }

            return mappedEvent;
        }
    }
}
