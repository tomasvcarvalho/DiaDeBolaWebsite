using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaCore.Dtos
{
    public class LocationDto
    {
        public int Id { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
