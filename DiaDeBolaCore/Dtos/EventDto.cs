using DiaDeBolaCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaCore.Dtos
{
    public class EventDto
    {
        
        public int Id { get; set; }
        [Required]
        public int MaxNumberOfPlayers { get; set; }
        
        public DateTime DateTime { get; set; }
        [Required]
        public LocationDto Location { get; set; }
        [Required]
        public EventStatusDto Status { get; set; }
        public int StatusId { get; set; }
    }
}
