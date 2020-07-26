using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public EventsController(ILogger<EventsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult GetEvents() 
        {
            return Ok(_context.Events.ToList());
        }

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

    }
}
