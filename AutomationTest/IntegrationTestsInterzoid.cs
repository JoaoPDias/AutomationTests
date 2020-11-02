using AutomationIntegrationTest;
using FluentAssertions;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace AutomationTest
{
    public class IntegrationTestsInterzoid
    {
        private readonly RestClient _client;

        public IntegrationTestsInterzoid()
        {
            _client = new RestClient("https://api.interzoid.com");
            var license = "94bf587f25c9c08f4d02ca47aa2fa9fb";
            _client.AddDefaultHeader("Accept", "application/json");
            _client.AddDefaultHeader("x-api-key", license);
        }
        /**In this situation, we can use Fact or Theory.
         * I prefer to use Fact to respect the Automated Test Standard: one test to one behavior*
         */
        [Fact]
        public async Task GetWeather_ExistingCityAndExistingState_ShouldReturnStatusCode200()
        {
            Weather weatherRequest = WeatherBuilder.New().WithCity("Round Rock").WithState("TX").Build();
            var request = new RestRequest("/getweather")
                .AddParameter("city", weatherRequest.City)
                .AddParameter("state", weatherRequest.State);
            var response = await _client.ExecuteGetTaskAsync<Weather>(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.StatusDescription.Should().Be("OK");
        }
        [Fact]
        public async Task GetWeather_NonExistingCityAndExistingState_ShouldReturnStatusCode404()
        {
            Weather weatherRequest = WeatherBuilder.New().WithCity("Tampa").WithState("TX").Build();
            var request = new RestRequest("/getweather")
                .AddParameter("city", weatherRequest.City)
                .AddParameter("state", weatherRequest.State);
            var response = await _client.ExecuteGetTaskAsync<Weather>(request);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            response.StatusDescription.Should().Be("Not Found");
        }
        [Fact]
        public async Task GetWeather_NonExistingCityAndNonExistingState_ShouldReturnStatusCode400()
        {
            Weather weatherRequest = WeatherBuilder.New().WithCity("--").WithState("--").Build();
            var request = new RestRequest("/getweather")
                .AddParameter("city", weatherRequest.City)
                .AddParameter("state", weatherRequest.State);
            var response = await _client.ExecuteGetTaskAsync<Weather>(request);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            response.StatusDescription.Should().Be("Bad Request");
        }

        /* If I were to use Theory Technique, it would be like that */
        [Theory]
        [InlineData("Tampa", "TX", HttpStatusCode.NotFound, "Not Found")]
        [InlineData("Round Rock", "TX", HttpStatusCode.OK, "OK")]
        [InlineData("--", "--", HttpStatusCode.BadRequest, "Bad Request")]
        public async Task GetWeather_CityAndState_ShouldValidStatusCode(string city, string state,
            HttpStatusCode expectedStatusCode, string expectedStatusDescription)
        {
            Weather weatherRequest = WeatherBuilder.New().WithCity(city).WithState(state).Build();
            var request = new RestRequest("/getweather")
                .AddParameter("city", weatherRequest.City)
                .AddParameter("state", weatherRequest.State);
            var response = await _client.ExecuteGetTaskAsync<Weather>(request);
            response.StatusCode.Should().Be(expectedStatusCode);
            response.StatusDescription.Should().Be(expectedStatusDescription);
        }
    }
}
