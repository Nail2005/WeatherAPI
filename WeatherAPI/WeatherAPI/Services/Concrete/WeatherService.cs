using WeatherAPI.Models.Dtos;
using WeatherAPI.Repositories.Abstract;
using WeatherAPI.Services.Abstract;

namespace WeatherAPI.Services.Concrete
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _repository;

        public WeatherService(IWeatherRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> GetWeatherAsync(RequestDto dto)
        {
            var city = await _repository.GetCityAsync(dto.City);

            if (city == null)
            {
                return null;
            }

            var current = await _repository.GetCurrentWeatherAsync(city.Id);

            var forecast = await _repository.GetDailyForecastsAsync(city.Id);

            var hourly = await _repository.GetHourlyDataAsync(city.Id);

            return new
            {
                city = new
                {
                    name = city.Name,
                    country_code = city.CountryCode,
                    country_name = city.CountryName
                },

                current = new
                {
                    temperature = current?.Temperature,
                    feels_like = current?.FeelsLike,
                    wind_speed = current?.WindSpeed,
                    wind_direction = current?.WindDirection,
                    pressure = current?.Pressure,
                    humidity = current?.Humidity,
                    uv_index = current?.UvIndex,
                    visibility_km = current?.VisibilityKm,
                    visibility_condition = current?.VisibilityCondition,
                    dew_point = current?.DewPoint,
                    sunrise_time = current?.SunriseTime,
                    sunset_time = current?.SunsetTime,
                    weather_description = current?.WeatherDescription,
                    weather_icon = current?.WeatherIcon,
                    recorded_at = current?.RecordedAt
                },

                weekly_forecast = forecast.Select(x => new
                {
                    day_name = x.DayName,
                    temperature = x.Temperature,
                    weather_description = x.WeatherDescription,
                    weather_icon = x.WeatherIcon,
                    forecast_date = x.ForecastDate
                }),

                hourly = hourly.Select(x => new
                {
                    hour_label = x.HourLabel,
                    wind_speed = x.WindSpeed,
                    rain_probability = x.RainProbability,
                    rain_condition = x.RainCondition
                })
            };

        }
    }
}
