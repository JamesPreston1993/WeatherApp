using System;
namespace WeatherApi.Models.RapidApiModels
{
    public class RapidApiCurrentWeatherResult
    {
        public RapidApiTimeZone location { get; set; }
        public RapidApiCurrentWeather current { get; set; }
    }

    public class RapidApiCurrentWeather
    {
        public long last_updated_epoch { get; set; }
        public string last_updated { get; set; }
        public double temp_c { get; set; }
        public double temp_f { get; set; }
        public double is_day { get; set; }
        public RapidApiCondition condition { get; set; }
        public double wind_mph { get; set; }
        public double wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mb { get; set; }
        public double pressure_in { get; set; }
        public double precip_mm { get; set; }
        public double precip_in { get; set; }
        public int humidity { get; set; }
        public int cloud { get; set; }
        public double feelslike_c { get; set; }
        public double feelslike_f { get; set; }
        public double vis_km { get; set; }
        public double vis_miles { get; set; }
        public double uv { get; set; }
        public double gust_mph { get; set; }
        public double gust_kph { get; set; }

        public CurrentWeather ToCurrentWeather()
        {
            return new CurrentWeather
            {
                LastUpdatedEpochTime = last_updated_epoch,
                LastUpdatedTime = DateTime.Parse(last_updated),
                Temperature = new Temperature
                {
                    Celsius = temp_c,
                    Fahrenheit = temp_f
                },
                IsDayTime = is_day == 1,
                Condition = condition.text,
                WindSpeed = new Speed
                {
                    KilometresPerHour = wind_kph,
                    MilesPerHour = wind_mph
                },
                WindDirection = new Direction
                {
                    Degree = wind_degree,
                    CompassDirection = wind_dir
                },
                Pressure = new Pressure
                {
                    Millibar = pressure_mb,
                    Inches = pressure_in
                },
                Precipitation = new Precipitation
                {
                    Millimetres = precip_mm,
                    Inches = precip_in
                },
                Humidity = humidity,
                CloudCoverage = cloud,
                FeelsLikeTemperature = new Temperature
                {
                    Celsius = feelslike_c,
                    Fahrenheit = feelslike_f
                },
                Visibility = new Distance
                {
                    Kilometres = vis_km,
                    Miles = vis_miles
                },
                UvIndex = uv,
                GustSpeed = new Speed
                {
                    KilometresPerHour = gust_kph,
                    MilesPerHour = gust_mph
                }
            };
        }
    }

    public class RapidApiCondition
    {
        public string text { get; set; }
        public string icon { get; set; }
        public int code { get; set; }
    }

}

