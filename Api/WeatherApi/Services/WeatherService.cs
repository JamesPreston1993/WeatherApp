using System;
using System.Net;
using WeatherApi.Models;
using WeatherApi.Models.Exceptions;
using WeatherApi.Models.RapidApiModels;

namespace WeatherApi.Services
{
    public class WeatherService : ITimeZoneRetriever, IAstronomyRetriever, ICurrentWeatherRetriever
    {
        private readonly string _baseUrl = "weatherapi-com.p.rapidapi.com";
        private readonly string _apiHostHeader = "weatherapi-com.p.rapidapi.com";
        private readonly string _apiKey;

        public WeatherService(IConfiguration configuration)
        {
            _apiKey = configuration.GetSection("Keys:RapidApiKey").Value;
        }

        /// <summary>
        /// Get timezone for given city.
        /// </summary>
        /// <param name="city">The city to get timezone for</param>
        /// <returns>An object containing all timezone details</returns>
        /// <exception cref="InvalidQueryException">Thrown when the city is null, empty or whitespace</exception>
        public async Task<WeatherTimeZone> GetTimeZoneAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new InvalidQueryException();
            }

            Uri uri = BuildUri("timezone.json", city);
            HttpRequestMessage request = BuildRequest(uri);

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.SendAsync(request))
            {
                EnsureSuccessfulResponse(response);

                RapidApiTimeZoneResult result = await response.Content.ReadFromJsonAsync<RapidApiTimeZoneResult>();

                return result.location.ToWeatherTimeZone();
            }
        }

        /// <summary>
        /// Get astronomy for given city.
        /// </summary>
        /// <param name="city">The city to get astronomy for</param>
        /// <returns>An object containing all astronomy details</returns>
        /// <exception cref="InvalidQueryException">Thrown when the city is null, empty or whitespace</exception>
        public async Task<WeatherAstronomy> GetAstronomyAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new InvalidQueryException();
            }

            Uri uri = BuildUri("astronomy.json", city);
            HttpRequestMessage request = BuildRequest(uri);

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.SendAsync(request))
            {
                EnsureSuccessfulResponse(response);

                RapidApiAstronomyResult result = await response.Content.ReadFromJsonAsync<RapidApiAstronomyResult>();

                return result.astronomy.astro.ToAstronomy();
            }
        }

        /// <summary>
        /// Get current weather for given city.
        /// </summary>
        /// <param name="city">The city to get current weather for</param>
        /// <returns>An object containing all current weather details</returns>
        /// <exception cref="InvalidQueryException">Thrown when the city is null, empty or whitespace</exception>
        public async Task<CurrentWeather> GetCurrentWeatherAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new InvalidQueryException();
            }

            Uri uri = BuildUri("current.json", city);
            HttpRequestMessage request = BuildRequest(uri);

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.SendAsync(request))
            {
                EnsureSuccessfulResponse(response);

                RapidApiCurrentWeatherResult result = await response.Content.ReadFromJsonAsync<RapidApiCurrentWeatherResult>();

                return result.current.ToCurrentWeather();
            }
        }

        /// <summary>
        /// Confirm that the response was succesful and throw relevant exceptions if not.
        /// </summary>
        /// <param name="response">The response to validate against</param>
        /// <exception cref="InvalidQueryException">Thrown wehn a BadRequest is detected</exception>
        /// <exception cref="ApiKeyException">Thrown when an Unauthorized or Forbidden is detected</exception>
        /// <exception cref="Exception">Thrown when an unexpected response failure is detected</exception>
        public void EnsureSuccessfulResponse(HttpResponseMessage response)
        {
            // Compare status code to those returned by Weather API
            // See https://www.weatherapi.com/docs/#intro-error-codes
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new InvalidQueryException();
                }

                if (response.StatusCode == HttpStatusCode.Unauthorized
                    || response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new ApiKeyException();
                }

                // Generic catch-all exception
                throw new Exception("Unexpected error occurred");
            }
        }

        private HttpRequestMessage BuildRequest(Uri uri)
        {
            return new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = uri,
                Headers =
                {
                    { "X-RapidAPI-Key", _apiKey },
                    { "X-RapidAPI-Host", _apiHostHeader }
                },
            };
        }

        private Uri BuildUri(string path, string query)
        {
            var uriBuilder = new UriBuilder();

            uriBuilder.Scheme = "https";
            uriBuilder.Host = _baseUrl;
            uriBuilder.Path = path;
            uriBuilder.Query = $"q={query}";

            return uriBuilder.Uri;
        }
    }
}

