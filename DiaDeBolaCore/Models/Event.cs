using System;
using System.Collections.Generic;

namespace DiaDeBolaCore.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public EventStatus EventStatus { get; set; }
        public int EventStatusId { get; set; }
        public List<Team> Teams { get; set; }

    }
}
