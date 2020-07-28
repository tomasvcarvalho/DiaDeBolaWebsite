using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiaDeBolaCore.Dtos;
using DiaDeBolaCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DiaDeBolaCore.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;
        private ApplicationDbContext _context;
        private IMapper _mapper;


        public EventsController(ILogger<EventsController> logger, IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        // GET api/events/
        public IActionResult GetEvents() 
        {
            return Ok(_context.Events.ToList());
        }


        [HttpGet]
        // GET api/events/1
        public IActionResult GetPlayersInEvent(int id)
        {

            var playersData = _context.TeamsInEvent
                .Join(
                    _context.PlayersInTeam,
                    teamsInEvent => teamsInEvent.Team.Id,
                    playersInTeam => playersInTeam.Team.Id,
                    (teamsInEvent, playersInTeam) => new { teamsInEvent, playersInTeam }
                ).ToList();


            return Ok(_context.Events.ToList());
        }

        [HttpPost]
        // POST api/events/
        public IActionResult CreateEvent(EventDto eventDto)
        {
            if (eventDto == null)
                return BadRequest();


            var eventToSave = _mapper.Map<EventDto, Event>(eventDto);

            _context.Events.Add(eventToSave);

            _context.SaveChanges();

            return Ok(_context.Events.ToList());
        }

    }
}
