using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using DiaDeBolaClassLibrary;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace DiaDeBolaWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;

            /*
            // CreateEvent
            Admin tempAdmin1 = new Admin("tomasvcarvalho@gmail.com");
            Admin tempAdmin2 = new Admin("teste@gmail.com");
            Event tempEvent = new Event(new List<Admin>() { tempAdmin1, tempAdmin2 });
            tempEvent.SetDateTime(DateTime.Now);
            tempEvent.SetMaxNumberOfPlayers(12);
            tempEvent.SetLocation(new Location() { Name = "BelouraSoccer"});
            
            string serializationTest = JsonConvert.SerializeObject(tempEvent);

            // Write to DB
            SqliteDataAccess.SaveEvent(_config.GetConnectionString("DefaultConnection"), tempEvent);

            // Load from DB
            List<EventMapper> loadedEventsRaw = SqliteDataAccess.LoadEvents(
                _config.GetConnectionString("DefaultConnection"));


            IEnumerable<Event> loadedEvents = loadedEventsRaw.Select(x => x.ToEvent());
            */
            Console.WriteLine("Done");



        }

        public void OnGet()
        {

        }
    }
}
