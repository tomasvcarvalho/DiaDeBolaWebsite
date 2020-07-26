using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DiaDeBolaCore.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public DateTime DateTime { get; set; }
        public Location Location { get ; set; }
        public EventStatus Status { get; set; }
        public int StatusId { get; set; }

    }
}
