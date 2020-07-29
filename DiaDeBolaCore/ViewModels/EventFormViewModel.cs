using DiaDeBolaCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaCore.ViewModels
{   public class EventFormViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Number of Players")]
        [Required]
        public int? MaxNumberOfPlayers { get; set; }

        [DisplayName("Date and Time")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? DateTime { get; set; }

        [Required]
        public string Location { get; set; }

        public IEnumerable<EventStatus> EventStatuses { get; set; }

        [Required]
        public int? EventStatusId { get; set; }

        public List<Team> Teams { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Event" : "New Event";
            }
        }

        public EventFormViewModel()
        {
            Id = 0;
        }

        public EventFormViewModel(Event oevent)
        {
            Id = oevent.Id;
            Name = oevent.Name;
            MaxNumberOfPlayers = oevent.MaxNumberOfPlayers;
            DateTime = oevent.DateTime;
            Location = oevent.Location;
            EventStatusId = oevent.EventStatus.Id;
            Teams = oevent.Teams;
        }
    }
}
