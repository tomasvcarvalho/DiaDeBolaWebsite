using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiaDeBolaCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiaDeBolaCore.Controllers
{
    public class EventsController : Controller
    {
        private readonly ILogger<EventsController> _logger;
        private ApplicationDbContext _context;

        public EventsController(ILogger<EventsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
