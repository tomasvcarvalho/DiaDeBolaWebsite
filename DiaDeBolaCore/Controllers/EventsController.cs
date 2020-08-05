using AutoMapper;
using DiaDeBolaCore.Dtos;
using DiaDeBolaCore.Models;
using DiaDeBolaCore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaCore.Controllers
{
    public class EventsController : Controller
    {
        private readonly ILogger<EventsController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventsController(ILogger<EventsController> logger, IMapper mapper, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }



        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var userEvents = _context.Events
                .Include(e => e.EventStatus)
                .Where(e => e.Teams
                    .Where(t => t.Players
                        .Where(p => p.User.Id == user.Id).Count() > 0).Count() > 0)
                .ToList();

            var userEventDtos = userEvents.Select(_mapper.Map<Event, EventDto>);

            return View("List", userEventDtos);
        }

        public IActionResult New()
        {
            var viewModel = new EventFormViewModel();
            return View("EventForm", viewModel);
        }

        public IActionResult Edit(int id)
        {
            var oevent = _context.Events
                .Include(e => e.EventStatus)
                .Include(e => e.Teams)
                .ThenInclude(t => t.Players)
                .SingleOrDefault(e => e.Id == id);

            if (oevent == null)
                return NotFound();



            var viewModel = new EventFormViewModel(_mapper.Map<Event, EventDto>(oevent))
            {
                EventStatuses = _context.EventStatus.Select(_mapper.Map<EventStatus, EventStatusDto>)
            };
            return View("EventForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(EventDto eventDto)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EventFormViewModel(eventDto)
                {
                    EventStatuses = _context.EventStatus.Select(_mapper.Map<EventStatus, EventStatusDto>)
                };
                return View("EventForm", viewModel);
            }

            if (eventDto.Id == 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var oevent = _mapper.Map<EventDto, Event>(eventDto);
                oevent.EventStatus = _context.EventStatus.SingleOrDefault(es => es.Name == Constants.EventStatusCreated);
                oevent.Teams = new List<Team>()
                {
                    new Team()
                    {
                        Name = "UnplacedPlayers",
                        Players = new List<Player>()
                        {
                            new Player()
                            {
                                User = user,
                                Status = _context.PlayerStatus.SingleOrDefault(ps => ps.Name == Constants.PlayerStatusToBeConfirmed)
                            }
                        }
                    },
                    new Team()
                {
                    Name = "TeamA"
                },
                    new Team()
                {
                    Name = "TeamB"
                }
                    };

                _context.Events.Add(oevent);
            }
            else
            {
                var eventInDb = _context.Events.Single(e => e.Id == eventDto.Id);
                _mapper.Map(eventDto, eventInDb);
                /*
                eventInDb.DateTime = eventDto.DateTime;
                eventInDb.EventStatusId = eventDto.EventStatusId;
                eventInDb.Location = eventDto.Location;
                eventInDb.Name = eventDto.Name;
                eventInDb.MaxNumberOfPlayers = eventDto.MaxNumberOfPlayers;
                */
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Events");
        }
    }
}
