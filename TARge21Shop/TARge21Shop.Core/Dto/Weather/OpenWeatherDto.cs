using System.Text.Json.Serialization;

namespace TARge21Shop.Core.Dto.Weather
{
    public class OpenWeatherDto
    {
        [JsonPropertyName("coord")]
        public Coord Coords { get; set; }

        [JsonPropertyName("weather")]
        public List<Weather> Weathers { get; set; }

        [JsonPropertyName("main")]
        public Main Mains { get; set; }

        [JsonPropertyName("wind")]
        public Wind Winds { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        public class Coord
        {
            [JsonPropertyName("lon")]
            public double Lon { get; set; }

            [JsonPropertyName("lat")]
            public double Lat { get; set; }
        }

        public class Main
        {
            [JsonPropertyName("temp")]
            public double Temp { get; set; }

            [JsonPropertyName("feels_like")]
            public double Feels_like { get; set; }

            [JsonPropertyName("pressure")]
            public int Pressure { get; set; }

            [JsonPropertyName("humidity")]
            public int Humidity { get; set; }
        }

        public class Weather
        {
            [JsonPropertyName("main")]
            public string Main { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }
        }

        public class Wind
        {
            [JsonPropertyName("speed")]
            public double Speed { get; set; }
        }
    }
}
