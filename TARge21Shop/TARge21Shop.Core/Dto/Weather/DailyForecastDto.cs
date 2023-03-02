using System.Text.Json.Serialization;

namespace TARge21Shop.Core.Dto.Weather
{
    public class DailyForecastDto
    {
        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("EpochDate")]
        public int EpochDate { get; set; }

        [JsonPropertyName("Temperature")]
        public Temperatures Temperature { get; set; }

        [JsonPropertyName("Day")]
        public DayNightCycle Day { get; set; }

        [JsonPropertyName("Night")]
        public DayNightCycle Night { get; set; }

        [JsonPropertyName("Sources")]
        public List<string> Sources { get; set; }

        [JsonPropertyName("MobileLink")]
        public string MobileLink { get; set; }

        [JsonPropertyName("Link")]
        public string Link { get; set; }
    }

    public class DayNightCycle
    {
        [JsonPropertyName("Icon")]
        public int Icon { get; set; }

        [JsonPropertyName("IconPhrase")]
        public string IconPhrase { get; set; }

        [JsonPropertyName("HasPrecipitation")]
        public bool HasPrecipitation { get; set; }

        [JsonPropertyName("PrecipitationType")]
        public string PrecipitationType { get; set; }

        [JsonPropertyName("PrecipitationIntensity")]
        public string PrecipitationIntensity { get; set; }
    }

    public class Temperature
    {
        [JsonPropertyName("Value")]
        public double Value { get; set; }

        [JsonPropertyName("Unit")]
        public string Unit { get; set; }

        [JsonPropertyName("UnitType")]
        public int UnitType { get; set; }
    }

    public class Temperatures
    {
        [JsonPropertyName("Minimum")]
        public Temperature Minimum { get; set; }

        [JsonPropertyName("Maximum")]
        public Temperature Maximum { get; set; }
    }
}
