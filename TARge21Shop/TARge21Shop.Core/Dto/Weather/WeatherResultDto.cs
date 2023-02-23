namespace TARge21Shop.Core.Dto.Weather
{
    public class WeatherResultDto
    {
        // HeadlineDto
        public DateTime EffectiveDate { get; set; }
        public int EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public DateTime EndDate { get; set; }
        public int EndEpochDate { get; set; }
        public string HeadlineMobileLink { get; set; }
        public string HeadlineLink { get; set; }

        // DailyForecastDto
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public Temperatures Temperature { get; set; }
        public DayNightCycle Day { get; set; }
        public DayNightCycle Night { get; set; }
        public List<string> Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }

        // DayNightCycle
        public int DayIcon { get; set; }
        public string DayIconPhrase { get; set; }
        public bool DayHasPrecipitation { get; set; }
        public string DayPrecipitationType { get; set; }
        public string DayPrecipitationIntensity { get; set; }
        public int NightIcon { get; set; }
        public string NightIconPhrase { get; set; }
        public bool NightHasPrecipitation { get; set; }
        public string NightPrecipitationType { get; set; }
        public string NightPrecipitationIntensity { get; set; }

        // Temperature
        public double MaximumValue { get; set; }
        public string MaximumUnit { get; set; }
        public int MaximumUnitType { get; set; }
        public double MinimumValue { get; set; }
        public string MinimumUnit { get; set; }
        public int MinimumUnitType { get; set; }


        // Temperatures
        public Temperature Minimum { get; set; }
        public Temperature Maximum { get; set; }
    }
}
