using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using DiaDeBolaClassLibrary;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DiaDeBolaWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;


            // CreateEvent
            Admin tempAdmin1 = new Admin("tomasvcarvalho@gmail.com");
            Admin tempAdmin2 = new Admin("teste@gmail.com");
            Event tempEvent = new Event(new List<IAdmin>() { tempAdmin1, tempAdmin2 });
            tempEvent.SetDateTime(DateTime.Now);
            tempEvent.SetMaxNumberOfPlayers(12);
            tempEvent.SetLocation(new Location() { Name = "BelouraSoccer"});
            
            string serializationTest = JsonConvert.SerializeObject(tempEvent);

            Console.WriteLine(serializationTest);

            // Write to DB
            SqliteDataAccess.SaveEvent("Data Source=./Data/DiaDeBolaWebsite.sqlite", tempEvent);
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
