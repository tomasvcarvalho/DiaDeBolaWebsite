namespace DiaDeBolaClassLibrary
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }


        public Location() { } 

        public string GetCoordinates()
        {
            return $"{Latitude} , {Longitude}";
        }
    }
}
