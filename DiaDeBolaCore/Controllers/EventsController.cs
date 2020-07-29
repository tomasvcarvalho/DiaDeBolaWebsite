using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiaDeBolaCore.Dtos;
using DiaDeBolaCore.Models;
using DiaDeBolaCore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DiaDeBolaCore.Controllers
{
    public class EventsController : Controller
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

            var viewModel = new EventFormViewModel(oevent)
            {
                EventStatuses = _context.EventStatus.ToList()
            };
            return View("EventForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Event oevent)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EventFormViewModel(oevent)
                {
                    EventStatuses = _context.EventStatus.ToList()
                };
                return View("EventForm", viewModel);
            }

            if (oevent.Id == 0)
            {
                var user = await _userManager.GetUserAsync(User);
                oevent.EventStatus = _context.EventStatus.SingleOrDefault(es => es.Id == 1);
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
                                Status = _context.PlayerStatus.SingleOrDefault(ps => ps.Id == 1)
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
                var eventInDb = _context.Events.Single(e => e.Id == oevent.Id);
                eventInDb.DateTime = oevent.DateTime;
                eventInDb.EventStatusId = oevent.EventStatusId;
                eventInDb.Location = oevent.Location;
                eventInDb.Name = oevent.Name;
                eventInDb.MaxNumberOfPlayers = oevent.MaxNumberOfPlayers;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Events");
        }
    }
}
