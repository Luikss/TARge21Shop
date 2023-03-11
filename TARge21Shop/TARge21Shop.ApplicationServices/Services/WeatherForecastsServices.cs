using Nancy.Json;
using System.Net;
using TARge21Shop.Core.Dto.Weather;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.ApplicationServices.Services
{
    public class WeatherForecastsServices : IWeatherForecastsServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            string apiKey = "1bbFjs6HkbKYmqmlqgV9tADCnLcpGGFn";
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=1bbFjs6HkbKYmqmlqgV9tADCnLcpGGFn&metric=true";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherRootDto weatherInfo = new JavaScriptSerializer().Deserialize<WeatherRootDto>(json);
                dto.EffectiveDate = weatherInfo.Headline.EffectiveDate;
                dto.EffectiveEpochDate = weatherInfo.Headline.EffectiveEpochDate;
                dto.Severity = weatherInfo.Headline.Severity;
                dto.Text = weatherInfo.Headline.Text;
                dto.Category = weatherInfo.Headline.Category;
                dto.EndDate = weatherInfo.Headline.EndDate;
                dto.EndEpochDate = weatherInfo.Headline.EndEpochDate;
                dto.HeadlineMobileLink = weatherInfo.Headline.MobileLink;
                dto.HeadlineLink = weatherInfo.Headline.Link;

                dto.Date = weatherInfo.DailyForecasts[0].Date;
                dto.EpochDate = weatherInfo.DailyForecasts[0].EpochDate;
                dto.Temperature = weatherInfo.DailyForecasts[0].Temperature;

                dto.Minimum = weatherInfo.DailyForecasts[0].Temperature.Minimum;
                dto.MinimumValue = weatherInfo.DailyForecasts[0].Temperature.Minimum.Value;
                dto.MinimumUnit = weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit;
                dto.MinimumUnitType = weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType;

                dto.Maximum = weatherInfo.DailyForecasts[0].Temperature.Maximum;
                dto.MaximumValue = weatherInfo.DailyForecasts[0].Temperature.Maximum.Value;
                dto.MaximumUnit = weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit;
                dto.MaximumUnitType = weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType;

                dto.Day = weatherInfo.DailyForecasts[0].Day;
                dto.DayIcon = weatherInfo.DailyForecasts[0].Day.Icon;
                dto.DayIconPhrase = weatherInfo.DailyForecasts[0].Day.IconPhrase;
                dto.DayHasPrecipitation = weatherInfo.DailyForecasts[0].Day.HasPrecipitation;
                dto.DayPrecipitationType = weatherInfo.DailyForecasts[0].Day.PrecipitationType;
                dto.DayPrecipitationIntensity = weatherInfo.DailyForecasts[0].Day.PrecipitationIntensity;

                dto.Night = weatherInfo.DailyForecasts[0].Night;
                dto.NightIcon = weatherInfo.DailyForecasts[0].Night.Icon;
                dto.NightIconPhrase = weatherInfo.DailyForecasts[0].Night.IconPhrase;
                dto.NightHasPrecipitation = weatherInfo.DailyForecasts[0].Night.HasPrecipitation;
                dto.NightPrecipitationType = weatherInfo.DailyForecasts[0].Night.PrecipitationType;
                dto.NightPrecipitationIntensity = weatherInfo.DailyForecasts[0].Night.PrecipitationIntensity;

                dto.Sources = weatherInfo.DailyForecasts[0].Sources;
                dto.MobileLink = weatherInfo.DailyForecasts[0].MobileLink;
                dto.Link = weatherInfo.DailyForecasts[0].Link;
            }

            return dto;
        }

        public async Task<OpenWeatherResultDto> OpenWeatherDetail(OpenWeatherResultDto dto)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q=Kuressaare&APPID=c67b33b70fec143216b389893cc73f3b";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                OpenWeatherDto result = new JavaScriptSerializer().Deserialize<OpenWeatherDto>(json);

                dto.Timezone = result.Timezone;
                dto.Name = result.Name;
                dto.Lon = result.Coords.Lon;
                dto.Lat = result.Coords.Lat;
                dto.Temp = result.Mains.Temp;
                dto.Feels_like = result.Mains.Feels_like;
                dto.Pressure = result.Mains.Pressure;
                dto.Humidity = result.Mains.Humidity;
                dto.Main = result.Weathers[0].Main;
                dto.Description = result.Weathers[0].Description;
                dto.Speed = result.Winds.Speed;
            }

            return dto;
        }
    }
}
