﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiaDeBolaCore.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int MaxNumberOfPlayers { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        [Required]
        public EventStatusDto EventStatus { get; set; }
        public int EventStatusId { get; set; }

        public List<TeamDto> Teams { get; set; }
    }
}
