using System;
using WeatherApi.Services;
using Xunit;
using Moq;
using Microsoft.Extensions.Configuration;
using WeatherApi.Models.Exceptions;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Controllers;

namespace WeatherApi.Tests.Services
{
    public class WeatherServiceTests
    {
        private readonly WeatherService _weatherService;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<IConfigurationSection> _mockApiKeyConfigSection;

        public WeatherServiceTests()
        {
            _mockApiKeyConfigSection = new Mock<IConfigurationSection>();
            _mockApiKeyConfigSection
                .Setup(mock => mock.Value)
                .Returns("SecretKey");

            _mockConfiguration = new Mock<IConfiguration>();
            _mockConfiguration
                .Setup(mock => mock.GetSection("Keys:RapidApiKey"))
                .Returns(_mockApiKeyConfigSection.Object);

            _weatherService = new WeatherService(_mockConfiguration.Object);
        }

        [Fact]
        public void EnsureSuccessfulResponse_BadRequest_ThrowsInvalidQueryException()
        {
            // Arrange
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.BadRequest;

            // Act & Assert
            Assert.Throws<InvalidQueryException>(() => _weatherService.EnsureSuccessfulResponse(response));
        }

        [Fact]
        public void EnsureSuccessfulResponse_Unauthorized_ThrowsApiKeyException()
        {
            // Arrange
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Unauthorized;

            // Act & Assert
            Assert.Throws<ApiKeyException>(() => _weatherService.EnsureSuccessfulResponse(response));
        }

        [Fact]
        public void EnsureSuccessfulResponse_Forbidden_ThrowsApiKeyException()
        {
            // Arrange
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Forbidden;

            // Act & Assert
            Assert.Throws<ApiKeyException>(() => _weatherService.EnsureSuccessfulResponse(response));
        }

        [Fact]
        public void EnsureSuccessfulResponse_Success_DoesNotThrowException()
        {
            // Arrange
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;

            // Act & Assert
            _weatherService.EnsureSuccessfulResponse(response);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async void GetTimeZoneAsync_EmptyCity_ThrowsInvalidQueryException(string city)
        {
            // Act & Assert
            await Assert.ThrowsAsync<InvalidQueryException>(() => _weatherService.GetTimeZoneAsync(city));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async void GetAstronomyZoneAsync_EmptyCity_ThrowsInvalidQueryException(string city)
        {
            // Act & Assert
            await Assert.ThrowsAsync<InvalidQueryException>(() => _weatherService.GetAstronomyAsync(city));
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async void GetCurrentWeatherAsync_EmptyCity_ThrowsInvalidQueryException(string city)
        {
            // Act & Assert
            await Assert.ThrowsAsync<InvalidQueryException>(() => _weatherService.GetCurrentWeatherAsync(city));
        }
    }
}

