using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data;
using WeatherAPI.Models.Entities;
using WeatherAPI.Repositories.Abstract;

namespace WeatherAPI.Repositories.Concrete
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherDbContext _context;

        public WeatherRepository(WeatherDbContext context)
        {
            _context = context;
        }

        public async Task<City> GetCityAsync(string cityName)
        {
            return await _context.Cities.FirstOrDefaultAsync(x => x.Name == cityName);
        }

        public async Task<CurrentWeather> GetCurrentWeatherAsync(int cityId)
        {
            return await _context.CurrentWeathers.Where(x=>x.CityId==cityId)
                .OrderByDescending(x=>x.RecordedAt)
                .FirstOrDefaultAsync(); 
        }

        public async Task<List<DailyForecast>> GetDailyForecastsAsync(int cityId)
        {
            return await _context.DailyForecasts.Where(x=>x.CityId == cityId)
                .OrderBy(x=>x.ForecastDate)
                .ToListAsync(); 
        }

        public async Task<List<HourlyData>> GetHourlyDataAsync(int cityId)
        {
            return await _context.HourlyData.Where(x=>x.CityId==cityId)
                .OrderBy(x=>x.HourLabel)
                .ToListAsync(); 
        }
    }
}
