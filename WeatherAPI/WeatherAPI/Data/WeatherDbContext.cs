using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Models.Entities;

namespace WeatherAPI.Data;

public partial class WeatherDbContext : DbContext
{
    public WeatherDbContext()
    {
    }

    public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<CurrentWeather> CurrentWeathers { get; set; }

    public virtual DbSet<DailyForecast> DailyForecasts { get; set; }

    public virtual DbSet<HourlyData> HourlyData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LenovoSlim3\\SqlExpress01;Database=WeatherApp;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cities__3214EC074AFE456D");

            entity.Property(e => e.CountryCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Country_code");
            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Country_name");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CurrentWeather>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Current___3214EC07BD7C0678");

            entity.ToTable("Current_Weather");

            entity.Property(e => e.CityId).HasColumnName("City_id");
            entity.Property(e => e.DewPoint)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Dew_point");
            entity.Property(e => e.FeelsLike)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Feels_like");
            entity.Property(e => e.RecordedAt)
                .HasColumnType("datetime")
                .HasColumnName("Recorded_at");
            entity.Property(e => e.SunriseTime)
                .HasColumnType("datetime")
                .HasColumnName("Sunrise_time");
            entity.Property(e => e.SunsetTime)
                .HasColumnType("datetime")
                .HasColumnName("Sunset_time");
            entity.Property(e => e.Temperature).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.UvIndex)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("UV_index");
            entity.Property(e => e.VisibilityCondition)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Visibility_condition");
            entity.Property(e => e.VisibilityKm)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Visibility_km");
            entity.Property(e => e.WeatherDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Weather_description");
            entity.Property(e => e.WeatherIcon)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Weather_icon");
            entity.Property(e => e.WindDirection)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Wind_direction");
            entity.Property(e => e.WindSpeed)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Wind_speed");

            entity.HasOne(d => d.City).WithMany(p => p.CurrentWeathers)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Current_W__City___398D8EEE");
        });

        modelBuilder.Entity<DailyForecast>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Daily_Fo__3214EC078002F495");

            entity.ToTable("Daily_Forecast");

            entity.Property(e => e.CityId).HasColumnName("City_id");
            entity.Property(e => e.DayName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Day_name");
            entity.Property(e => e.ForecastDate)
                .HasColumnType("datetime")
                .HasColumnName("Forecast_date");
            entity.Property(e => e.Temperature).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.WeatherDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Weather_description");
            entity.Property(e => e.WeatherIcon)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Weather_icon");

            entity.HasOne(d => d.City).WithMany(p => p.DailyForecasts)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Daily_For__City___3C69FB99");
        });

        modelBuilder.Entity<HourlyData>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hourly_D__3214EC07326BB015");

            entity.ToTable("Hourly_Data");

            entity.Property(e => e.CityId).HasColumnName("City_id");
            entity.Property(e => e.HourLabel)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Hour_label");
            entity.Property(e => e.RainCondition)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Rain_condition");
            entity.Property(e => e.RainProbability).HasColumnName("Rain_probability");
            entity.Property(e => e.RecordedAt)
                .HasColumnType("datetime")
                .HasColumnName("Recorded_at");
            entity.Property(e => e.WindSpeed)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Wind_speed");

            entity.HasOne(d => d.City).WithMany(p => p.HourlyData)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Hourly_Da__City___3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
