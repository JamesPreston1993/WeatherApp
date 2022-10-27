using System;
using WeatherApi.Controllers;
using WeatherApi.Services;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeatherApi.Models.Exceptions;
using WeatherApi.Models;

namespace WeatherApi.Tests.Controllers
{
    public class WeatherControllerTests
    {
        private readonly WeatherController _weatherController;
        private readonly Mock<ITimeZoneRetriever> _timeZoneRetrieverMock;
        private readonly Mock<IAstronomyRetriever> _astronomyRetrieverMock;

        private readonly Mock<ICurrentWeatherRetriever> _currentWeatherRetrieverMock;

        private readonly string TEST_CITY = "Dublin";
        private readonly string TEST_SUNRISE = "08:12 AM";
        private readonly int TEST_CLOUD_COVERAGE = 50;

        public WeatherControllerTests()
        {
            _timeZoneRetrieverMock = new Mock<ITimeZoneRetriever>();
            _astronomyRetrieverMock = new Mock<IAstronomyRetriever>();
            _currentWeatherRetrieverMock = new Mock<ICurrentWeatherRetriever>();

            _weatherController = new WeatherController(
                _timeZoneRetrieverMock.Object,
                _astronomyRetrieverMock.Object,
                _currentWeatherRetrieverMock.Object
            );
        }

        [Fact]
        public async void GetTimeZone_InvalidQueryExceptionThrown_ReturnsBadRequest()
        {
            // Arrange
            _timeZoneRetrieverMock
                .Setup(mock => mock.GetTimeZoneAsync(It.IsAny<string>()))
                .ThrowsAsync(new InvalidQueryException());

            // Act
            BadRequestObjectResult result = await _weatherController.GetTimeZone(TEST_CITY) as BadRequestObjectResult;

            // Assert
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async void GetTimeZone_ApiKeyExceptionThrown_ReturnsUnauthorized()
        {
            // Arrange
            _timeZoneRetrieverMock
                .Setup(mock => mock.GetTimeZoneAsync(It.IsAny<string>()))
                .ThrowsAsync(new ApiKeyException());

            // Act
            UnauthorizedResult result = await _weatherController.GetTimeZone(TEST_CITY) as UnauthorizedResult;

            // Assert
            Assert.Equal(401, result.StatusCode);
        }

        [Fact]
        public async void GetTimeZone_Success_ReturnsTimeZone()
        {
            // Arrange
            _timeZoneRetrieverMock
                .Setup(mock => mock.GetTimeZoneAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new WeatherTimeZone
                {
                    Name = TEST_CITY
                }));

            // Act
            ObjectResult result = await _weatherController.GetTimeZone(TEST_CITY) as ObjectResult;

            // Assert
            Assert.Equal(200, result.StatusCode);

            WeatherTimeZone timeZone = result.Value as WeatherTimeZone;
            Assert.NotNull(timeZone);
            Assert.Equal(TEST_CITY, timeZone.Name);
        }

        [Fact]
        public async void GetAstronomy_InvalidQueryExceptionThrown_ReturnsBadRequest()
        {
            // Arrange
            _astronomyRetrieverMock
                .Setup(mock => mock.GetAstronomyAsync(It.IsAny<string>()))
                .ThrowsAsync(new InvalidQueryException());

            // Act
            BadRequestObjectResult result = await _weatherController.GetAstronomy(TEST_CITY) as BadRequestObjectResult;

            // Assert
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async void GetAstronomy_ApiKeyExceptionThrown_ReturnsUnauthorized()
        {
            // Arrange
            _astronomyRetrieverMock
                .Setup(mock => mock.GetAstronomyAsync(It.IsAny<string>()))
                .ThrowsAsync(new ApiKeyException());

            // Act
            UnauthorizedResult result = await _weatherController.GetAstronomy(TEST_CITY) as UnauthorizedResult;

            // Assert
            Assert.Equal(401, result.StatusCode);
        }

        [Fact]
        public async void GetAstronomy_Success_ReturnsAstronomy()
        {
            // Arrange
            _astronomyRetrieverMock
                .Setup(mock => mock.GetAstronomyAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new WeatherAstronomy
                {
                    Sunrise = TEST_SUNRISE
                }));

            // Act
            ObjectResult result = await _weatherController.GetAstronomy(TEST_CITY) as ObjectResult;

            // Assert
            Assert.Equal(200, result.StatusCode);

            WeatherAstronomy astronomy = result.Value as WeatherAstronomy;
            Assert.NotNull(astronomy);
            Assert.Equal(TEST_SUNRISE, astronomy.Sunrise);
        }

        [Fact]
        public async void GetCurrentWeather_InvalidQueryExceptionThrown_ReturnsBadRequest()
        {
            // Arrange
            _currentWeatherRetrieverMock
                .Setup(mock => mock.GetCurrentWeatherAsync(It.IsAny<string>()))
                .ThrowsAsync(new InvalidQueryException());

            // Act
            BadRequestObjectResult result = await _weatherController.GetCurrentWeather(TEST_CITY) as BadRequestObjectResult;

            // Assert
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async void GetACurrentWeather_ApiKeyExceptionThrown_ReturnsUnauthorized()
        {
            // Arrange
            _currentWeatherRetrieverMock
                .Setup(mock => mock.GetCurrentWeatherAsync(It.IsAny<string>()))
                .ThrowsAsync(new ApiKeyException());

            // Act
            UnauthorizedResult result = await _weatherController.GetCurrentWeather(TEST_CITY) as UnauthorizedResult;

            // Assert
            Assert.Equal(401, result.StatusCode);
        }

        [Fact]
        public async void GetCurrentWeather_Success_ReturnsAstronomy()
        {
            // Arrange
            _currentWeatherRetrieverMock
                .Setup(mock => mock.GetCurrentWeatherAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new CurrentWeather
                {
                    CloudCoverage = TEST_CLOUD_COVERAGE
                }));

            // Act
            ObjectResult result = await _weatherController.GetCurrentWeather(TEST_CITY) as ObjectResult;

            // Assert
            Assert.Equal(200, result.StatusCode);

            CurrentWeather currentWeather = result.Value as CurrentWeather;
            Assert.NotNull(currentWeather);
            Assert.Equal(TEST_CLOUD_COVERAGE, currentWeather.CloudCoverage);
        }
    }
}

