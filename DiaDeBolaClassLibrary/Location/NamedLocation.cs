using System;
using System.Collections.Generic;
using System.Text;

namespace DiaDeBolaClassLibrary
{
    public class NamedLocation : ILocation
    {
        string Name { get; set; }

        public NamedLocation(string locationName) 
        {
            Name = locationName;
        }

        public string GetLocation()
        {
            return $"{Name}";
        }
    }
}
