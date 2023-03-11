using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto.Weather;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Models.Weather;

namespace TARge21Shop.Controllers
{
    public class WeatherForecastsController : Controller
    {
        private readonly IWeatherForecastsServices _weatherForecastsServices;

        public WeatherForecastsController(IWeatherForecastsServices weatherForecastsServices)
        {
            _weatherForecastsServices = weatherForecastsServices;
        }

        public IActionResult Index()
        {
            WeatherViewModel vm = new WeatherViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult ShowWeather()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecasts");
            }

            return View();
        }

        [HttpGet]
        public IActionResult City()
        {
            WeatherResultDto dto = new WeatherResultDto();
            WeatherViewModel vm = new WeatherViewModel();

            _weatherForecastsServices.WeatherDetail(dto);

            vm.Date = dto.Date;
            vm.EpochDate = dto.EpochDate;
            vm.Temperature = new Models.Weather.Temperatures();

            vm.Temperature.Minimum = new Models.Weather.Temperature();
            vm.Temperature.Minimum.Value = dto.MinimumValue;
            vm.Temperature.Minimum.Unit = dto.MinimumUnit;
            vm.Temperature.Minimum.UnitType = dto.MinimumUnitType;

            vm.Temperature.Maximum = new Models.Weather.Temperature();
            vm.Temperature.Maximum.Value = dto.MaximumValue;
            vm.Temperature.Maximum.Unit = dto.MaximumUnit;
            vm.Temperature.Maximum.UnitType = dto.MaximumUnitType;

            vm.Day = new Models.Weather.DayNightCycle();
            vm.Day.Icon = dto.DayIcon;
            vm.Day.IconPhrase = dto.DayIconPhrase;
            vm.Day.HasPrecipitation = dto.DayHasPrecipitation;
            vm.Day.PrecipitationType = dto.DayPrecipitationType;
            vm.Day.PrecipitationIntensity = dto.DayPrecipitationIntensity;

            vm.Night = new Models.Weather.DayNightCycle();
            vm.Night.Icon = dto.NightIcon;
            vm.Night.IconPhrase = dto.NightIconPhrase;
            vm.Night.HasPrecipitation = dto.NightHasPrecipitation;
            vm.Night.PrecipitationType = dto.NightPrecipitationType;
            vm.Night.PrecipitationIntensity = dto.NightPrecipitationIntensity;

            vm.Sources = dto.Sources;
            vm.MobileLink = dto.MobileLink;
            vm.Link = dto.Link;

            return View(vm);
        }

        [HttpGet]
        public IActionResult CityWeatherDetails() 
        { 
            OpenWeatherResultDto dto = new OpenWeatherResultDto();
            OpenWeatherViewModel vm = new OpenWeatherViewModel();

            _weatherForecastsServices.OpenWeatherDetail(dto);

            vm.Timezone = dto.Timezone;
            vm.Name = dto.Name;
            vm.Lon = dto.Lon;
            vm.Lat = dto.Lat;
            vm.Temp = dto.Temp;
            vm.Feels_like = dto.Feels_like;
            vm.Pressure = dto.Pressure;
            vm.Humidity = dto.Humidity;
            vm.Main = dto.Main;
            vm.Description = dto.Description;
            vm.Speed = dto.Speed;

            return View(); 
        }
    }
}
