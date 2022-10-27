using System;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public interface IAstronomyRetriever
    {
        Task<WeatherAstronomy> GetAstronomyAsync(string city);
    }
}

