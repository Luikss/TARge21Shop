using TARge21Shop.Core.Dto.Weather;

namespace TARge21Shop.Core.ServiceInterface
{
    public interface IWeatherForecastsServices
    {
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
        Task<OpenWeatherResultDto> OpenWeatherDetail(OpenWeatherResultDto dto);
    }
}
