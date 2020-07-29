using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiaDeBolaCore.Dtos;
using DiaDeBolaCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public EventsController(ILogger<EventsController> logger, IMapper mapper, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        // GET api/events/
        public IActionResult GetEvents() 
        {
            return Ok(_context.Events.ToList());
        }


        [HttpGet("{id}")]
        // GET api/events/1
        public IActionResult GetEvents(string id)
        {
            var userEvents = _context.Events
                .Include(e => e.EventStatus)
                .Where(e => e.Teams
                    .Where(t => t.Players
                        .Where(p => p.User.Id == id).Count() > 0).Count() > 0)
                .ToList();

            var userEventDtos = userEvents.Select(_mapper.Map<Event, EventDto>);

            return Ok(userEventDtos);
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


        // DELETE /api/contacts/Id
        [HttpDelete("{id:int}")]
        public IActionResult DeleteContact(int id)
        {
            var eventInDb = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (eventInDb == null)
                return NotFound();

            _context.Contacts.Remove(eventInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
