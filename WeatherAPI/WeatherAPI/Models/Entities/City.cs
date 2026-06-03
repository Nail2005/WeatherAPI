using System;
using System.Collections.Generic;

namespace WeatherAPI.Models.Entities;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public string CountryName { get; set; } = null!;

    public virtual ICollection<CurrentWeather> CurrentWeathers { get; set; } = new List<CurrentWeather>();

    public virtual ICollection<DailyForecast> DailyForecasts { get; set; } = new List<DailyForecast>();

    public virtual ICollection<HourlyData> HourlyData { get; set; } = new List<HourlyData>();
}
