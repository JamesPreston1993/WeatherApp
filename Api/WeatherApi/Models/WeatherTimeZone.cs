using System;

namespace WeatherApi.Models
{
    public class WeatherTimeZone
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string TimeZoneIdentifier { get; set; }
        public DateTime LocalTime { get; set; }
        public long EpochTime { get; set; }
    }
}

