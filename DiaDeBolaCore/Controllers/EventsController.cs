using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiaDeBolaCore.Models;
using DiaDeBolaCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiaDeBolaCore.Controllers
{
    public class EventsController : Controller
    {
        private readonly ILogger<EventsController> _logger;
        private readonly IMapper _mapper;
        private ApplicationDbContext _context;

        public EventsController(ILogger<EventsController> logger, IMapper mapper, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            var eventStatuses = _context.EventStatus.ToList();
            var viewModel = new EventFormViewModel()
            {
                EventStatuses = eventStatuses
            };
            return View("EventForm", viewModel);
        }


        public IActionResult Save(Event oevent)
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
                _context.Events.Add(oevent);
            }
            else
            {
                var eventInDb = _context.Events.Single(c => c.Id == oevent.Id);
                _mapper.Map(oevent, eventInDb);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Events");
        }
    }
}
