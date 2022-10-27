using System;
namespace WeatherApi.Models.RapidApiModels
{
    public class RapidApiTimeZoneResult
    {
        public RapidApiTimeZone location { get; set; }
    }

    public class RapidApiTimeZone
    {
        public string name { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string tz_id { get; set; }
        public long localtime_epoch { get; set; }
        public string localtime { get; set; }

        public WeatherTimeZone ToWeatherTimeZone()
        {
            return new WeatherTimeZone
            {
                Name = name,
                Region = region,
                Country = country,
                Latitude = lat,
                Longitude = lon,
                TimeZoneIdentifier = tz_id,
                EpochTime = localtime_epoch,
                LocalTime = DateTime.Parse(localtime)
            };
        }
    }
}

