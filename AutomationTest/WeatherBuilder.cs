namespace AutomationIntegrationTest
{
    public class WeatherBuilder
    {
        private Weather _weather;

        public static WeatherBuilder New()
        {
            return new WeatherBuilder();
        }

        private WeatherBuilder()
        {
            _weather = new Weather
            {
                City = "Boston",
                State = "MA"
            };
        }

        public WeatherBuilder WithCity(string city)
        {
            _weather.City = city;
            return this;
        }

        public WeatherBuilder WithState(string state)
        {
            _weather.State = state;
            return this;
        }

        public Weather Build()
        {
            return _weather;
        }

    }
}
