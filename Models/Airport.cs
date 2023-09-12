namespace DotNetWebApi.Models
{
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AirportType { get; set; } = string.Empty;// TODO: change type to enum
        public string City { get; set; } = string.Empty;
        public int TimeZone { get; set; } // difference in hours from GMT
        public string Coordinates { get; set; } = string.Empty;// TODO: change to object coordinate
        public string Website { get; set; } = string.Empty;

    }
}
