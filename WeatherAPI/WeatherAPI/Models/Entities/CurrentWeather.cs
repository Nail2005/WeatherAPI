using System;
using System.Collections.Generic;

namespace WeatherAPI.Models.Entities;

public partial class CurrentWeather
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public decimal Temperature { get; set; }

    public decimal FeelsLike { get; set; }

    public decimal WindSpeed { get; set; }

    public string WindDirection { get; set; } = null!;

    public int Pressure { get; set; }

    public int Humidity { get; set; }

    public decimal UvIndex { get; set; }

    public decimal VisibilityKm { get; set; }

    public string VisibilityCondition { get; set; } = null!;

    public decimal DewPoint { get; set; }

    public DateTime SunriseTime { get; set; }

    public DateTime SunsetTime { get; set; }

    public string WeatherDescription { get; set; } = null!;

    public string WeatherIcon { get; set; } = null!;

    public DateTime RecordedAt { get; set; }

    public virtual City City { get; set; } = null!;
}
