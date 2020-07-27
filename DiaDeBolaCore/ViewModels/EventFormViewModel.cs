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

        [Required]
        [DisplayName("Number of Players")]
        public int? MaxNumberOfPlayers { get; set; }

        [Required]
        [DisplayName("Event DateTime")]
        public DateTime? DateTime { get; set; }

        [Required]
        public string Location { get; set; }

        public IEnumerable<EventStatus> EventStatuses { get; set; }

        [Required]
        public int? EventStatusId { get; set; }

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
            MaxNumberOfPlayers = oevent.MaxNumberOfPlayers;
            DateTime = oevent.DateTime;
            Location = oevent.Location;
            EventStatusId = oevent.EventStatusId;
        }

        
    }
}
