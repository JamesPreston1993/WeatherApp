using System;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public interface ITimeZoneRetriever
    {
        public Task<WeatherTimeZone> GetTimeZoneAsync(string city);
    }
}

