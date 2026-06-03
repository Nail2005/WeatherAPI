using WeatherAPI.Models.Entities;

namespace WeatherAPI.Repositories.Abstract
{
    public interface IWeatherRepository
    {
        Task<City> GetCityAsync(string cityName);   
        Task<CurrentWeather> GetCurrentWeatherAsync(int cityId);        
        Task<List<DailyForecast>> GetDailyForecastsAsync(int cityId); 
        Task<List<HourlyData>> GetHourlyDataAsync(int cityId);      
    }
}
