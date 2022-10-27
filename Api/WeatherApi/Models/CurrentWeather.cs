using System;
namespace WeatherApi.Models
{
    public class CurrentWeather
    {
        public DateTime LastUpdatedTime { get; set; }
        public long LastUpdatedEpochTime { get; set; }
        public Temperature Temperature { get; set; }
        public Boolean IsDayTime { get; set; }
        public string Condition { get; set; }
        public Speed WindSpeed { get; set; }
        public Direction WindDirection { get; set; }
        public Pressure Pressure { get; set; }
        public Precipitation Precipitation { get; set; }
        public int Humidity { get; set; }
        public int CloudCoverage { get; set; }
        public Temperature FeelsLikeTemperature { get; set; }
        public Distance Visibility { get; set; }
        public double UvIndex { get; set; }
        public Speed GustSpeed { get; set; }
    }

    public class Temperature
    {
        public double Celsius { get; set; }
        public double Fahrenheit { get; set; }
    }

    public class Speed
    {
        public double MilesPerHour { get; set; }
        public double KilometresPerHour { get; set; }
    }

    public class Direction
    {
        public int Degree { get; set; }
        public string CompassDirection { get; set; }
    }

    public class Pressure
    {
        public double Millibar { get; set; }
        public double Inches { get; set; }
    }

    public class Precipitation
    {
        public double Millimetres { get; set; }
        public double Inches { get; set; }
    }

    public class Distance
    {
        public double Kilometres { get; set; }
        public double Miles { get; set; }
    }
}

