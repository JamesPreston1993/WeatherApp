using System;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public interface ICurrentWeatherRetriever
    {
        Task<CurrentWeather> GetCurrentWeatherAsync(string city);
    }
}

