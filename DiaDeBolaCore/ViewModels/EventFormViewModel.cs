using DiaDeBolaCore.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DiaDeBolaCore.ViewModels
{
    public class EventFormViewModel
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

        public IEnumerable<EventStatusDto> EventStatuses { get; set; }

        [Required]
        public int? EventStatusId { get; set; }

        public List<TeamDto> Teams { get; set; }

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

        public EventFormViewModel(EventDto eventDto)
        {
            Id = eventDto.Id;
            Name = eventDto.Name;
            MaxNumberOfPlayers = eventDto.MaxNumberOfPlayers;
            DateTime = eventDto.DateTime;
            Location = eventDto.Location;
            EventStatusId = eventDto.EventStatus.Id;
            Teams = eventDto.Teams;
        }
    }
}
