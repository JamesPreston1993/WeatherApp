using System;
namespace WeatherApi.Models.RapidApiModels
{
    public class RapidApiAstronomyResult
    {
        public RapidApiTimeZone location { get; set; }
        public RapidApiAstronomyInnerResult astronomy { get; set; }
    }

    public class RapidApiAstronomyInnerResult
    {
        public RapidApiAstronomy astro { get; set; }
    }

    public class RapidApiAstronomy
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string moonrise { get; set; }
        public string moonset { get; set; }
        public string moon_phase { get; set; }
        public string moon_illumination { get; set; }

        public WeatherAstronomy ToAstronomy()
        {
            return new WeatherAstronomy
            {
                Sunrise = sunrise,
                Sunset = sunset,
                Moonrise = moonrise,
                Moonset = moonset,
                MoonPhase = moon_phase,
                MoonIllumination = int.Parse(moon_illumination)
            };
        }
    }
}

