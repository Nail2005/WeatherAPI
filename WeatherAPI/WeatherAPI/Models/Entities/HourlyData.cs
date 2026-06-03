using System;
using System.Collections.Generic;

namespace WeatherAPI.Models.Entities;

public partial class HourlyData
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public string HourLabel { get; set; } = null!;

    public decimal WindSpeed { get; set; }

    public int RainProbability { get; set; }

    public string RainCondition { get; set; } = null!;

    public DateTime RecordedAt { get; set; }

    public virtual City City { get; set; } = null!;
}
