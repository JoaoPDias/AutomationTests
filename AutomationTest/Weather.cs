using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AutomationIntegrationTest
{
    public class Weather
    {
        public string City { get; set; }
        public string State { get; set; }
        public string TempF { get; set; }
        public string TempC { get; set; }
        [JsonProperty("Weather")]
        public string WeatherDescription { get; set; }
    }
}
