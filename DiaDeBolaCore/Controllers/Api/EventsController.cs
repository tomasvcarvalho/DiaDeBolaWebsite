using AutoMapper;
using DiaDeBolaCore.Dtos;
using DiaDeBolaCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DiaDeBolaCore.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EventsController(ILogger<EventsController> logger, IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }


        // GET api/events/1
        [HttpGet("{id}")]
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


        // DELETE /api/contacts/Id
        [HttpDelete("{id:int}")]
        public IActionResult DeleteEvent(int id)
        {
            var eventInDb = _context.Events.SingleOrDefault(c => c.Id == id);

            if (eventInDb == null)
                return NotFound();

            _context.Events.Remove(eventInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
