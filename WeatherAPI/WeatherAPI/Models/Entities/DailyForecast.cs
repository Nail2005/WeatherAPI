using System;
using System.Collections.Generic;

namespace WeatherAPI.Models.Entities;

public partial class DailyForecast
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public DateTime ForecastDate { get; set; }

    public string DayName { get; set; } = null!;

    public decimal Temperature { get; set; }

    public string WeatherDescription { get; set; } = null!;

    public string WeatherIcon { get; set; } = null!;

    public virtual City City { get; set; } = null!;
}
