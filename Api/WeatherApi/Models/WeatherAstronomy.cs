using System;
namespace WeatherApi.Models
{
    public class WeatherAstronomy
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Moonrise { get; set; }
        public string Moonset { get; set; }
        public string MoonPhase { get; set; }
        public int MoonIllumination { get; set; }
    }
}

