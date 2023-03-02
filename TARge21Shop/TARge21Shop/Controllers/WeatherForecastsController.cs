using Microsoft.AspNetCore.Mvc;
using TARge21Shop.Core.Dto.Weather;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Data;
using TARge21Shop.Models.Weather;

namespace TARge21Shop.Controllers
{
    public class WeatherForecastsController : Controller
    {
        private readonly TARge21ShopContext _context;
        private readonly IWeatherForecastsServices _weatherForecastsServices;

        public WeatherForecastsController
            (
                TARge21ShopContext context,
                IWeatherForecastsServices weatherForecastsServices
            )
        {
            _context = context;
            _weatherForecastsServices = weatherForecastsServices;
        }

        public IActionResult Index()
        {
            WeatherViewModel vm = new WeatherViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult ShowWeather(WeatherViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecasts");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult City()
        {
            WeatherResultDto dto = new WeatherResultDto();
            WeatherViewModel vm = new WeatherViewModel();

            _weatherForecastsServices.WeatherDetail(dto);

            vm.Date = dto.Date;
            vm.EpochDate = dto.EpochDate;

            vm.Temperature.Minimum.Value = dto.MinimumValue;
            vm.Temperature.Minimum.Unit = dto.MinimumUnit;
            vm.Temperature.Minimum.UnitType = dto.MinimumUnitType;

            vm.Temperature.Maximum.Value = dto.MaximumValue;
            vm.Temperature.Maximum.Unit = dto.MaximumUnit;
            vm.Temperature.Maximum.UnitType = dto.MaximumUnitType;

            vm.Day.Icon = dto.DayIcon;
            vm.Day.IconPhrase = dto.DayIconPhrase;
            vm.Day.HasPrecipitation = dto.DayHasPrecipitation;
            vm.Day.PrecipitationType = dto.DayPrecipitationType;
            vm.Day.PrecipitationIntensity = dto.DayPrecipitationIntensity;

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
    }
}
