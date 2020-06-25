using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using DiaDeBolaClassLibrary;

namespace DiaDeBolaWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

            Event tempEvent;

            List<EventMapper> rawEvents = SqliteDataAccess.LoadEvents("Data Source=./Data/DiaDeBolaWebsite.sqlite");

            foreach (EventMapper gameEvent in rawEvents) 
            {
                tempEvent = gameEvent.ToEvent();
                Console.WriteLine(tempEvent);
            }



        }

        public void OnGet()
        {

        }
    }
}
