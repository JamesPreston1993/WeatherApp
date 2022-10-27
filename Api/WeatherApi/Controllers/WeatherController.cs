using Microsoft.AspNetCore.Mvc;
using WeatherApi.Models;
using WeatherApi.Models.Exceptions;
using WeatherApi.Services;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ITimeZoneRetriever _timeZoneRetriever;
        private readonly IAstronomyRetriever _astronomyRetriever;
        private readonly ICurrentWeatherRetriever _currentWeatherRetriever;

        public WeatherController(
            ITimeZoneRetriever timeZoneRetriever,
            IAstronomyRetriever astronomyRetriever,
            ICurrentWeatherRetriever currentWeatherRetriever
        )
        {
            _timeZoneRetriever = timeZoneRetriever;
            _astronomyRetriever = astronomyRetriever;
            _currentWeatherRetriever = currentWeatherRetriever;
        }

        [HttpGet("TimeZone")]
        public async Task<IActionResult> GetTimeZone([FromQuery] string city)
        {
            try
            {
                return Ok(await _timeZoneRetriever.GetTimeZoneAsync(city));
            }
            catch (InvalidQueryException)
            {
                return BadRequest($"City {city} is not valid.");
            }
            catch (ApiKeyException)
            {
                return Unauthorized();
            }
        }

        [HttpGet("Astronomy")]
        public async Task<IActionResult> GetAstronomy([FromQuery] string city)
        {
            try
            {
                return Ok(await _astronomyRetriever.GetAstronomyAsync(city));
            }
            catch (InvalidQueryException)
            {
                return BadRequest($"City {city} is not valid.");
            }
            catch (ApiKeyException)
            {
                return Unauthorized();
            }
        }

        [HttpGet("Current")]
        public async Task<IActionResult> GetCurrentWeather([FromQuery] string city)
        {
            try
            {
                return Ok(await _currentWeatherRetriever.GetCurrentWeatherAsync(city));
            }
            catch (InvalidQueryException)
            {
                return BadRequest($"City {city} is not valid.");
            }
            catch (ApiKeyException)
            {
                return Unauthorized();
            }
        }
    }
}