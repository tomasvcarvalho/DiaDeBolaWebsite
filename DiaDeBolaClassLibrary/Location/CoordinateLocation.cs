using System;
using System.Collections.Generic;
using System.Text;

namespace DiaDeBolaClassLibrary
{
    public class CoordinateLocation : ILocation
    {
        double Latitude { get; set; }
        double Longitude { get; set; }

        public CoordinateLocation(double latitude, double longitude) 
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public string GetLocation()
        {
            return $"{Latitude} , {Longitude}";
        }
    }
}
