using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiaDeBolaClassLibrary
{
    public class EventMapper
    {
        public int Id { get; set; }
        public string JsonEventContent{ get; set; }

        public EventMapper() { }

        public EventMapper(IEvent gameEvent)
        {
            JsonEventContent = JsonConvert.SerializeObject(gameEvent);
        }

        public Event ToEvent() 
        {
            return JsonConvert.DeserializeObject<Event>(JsonEventContent, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }

    }
}
