using WeatherAPI.Models.Dtos;

namespace WeatherAPI.Services.Abstract
{
    public interface IWeatherService
    {
        Task<object> GetWeatherAsync(RequestDto dto);      
    }
}
