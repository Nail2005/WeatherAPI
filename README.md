Weather API Layihəsi
Layihə haqqında

Bu layihə hava məlumatlarını təqdim edən REST API xidmətidir. Frontend tərəfindən şəhər adı göndərilir və backend həmin şəhərə aid:

* cari hava vəziyyəti
* 6 günlük proqnoz
* saatlıq hava məlumatları

verilənlər bazasından oxunaraq JSON formatında qaytarılır.

---

Texnologiyalar

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger (OpenAPI)

---

Quraşdırma

1. Layihəni Visual Studio-da aç

2. NuGet paketləri qur:


Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore


3. Verilənlər bazasını hazırla (SQL Server)

4. Connection string-i konfiqurasiya et

5. Proyekti işə sal


---

Mühit dəyişənləri (.env)

Layihədə aşağıdakı açarlar istifadə olunur:

DB_HOST
DB_PORT
DB_NAME
DB_USER
DB_PASSWORD

(Qiymətlər GitHub-a yüklənmir)

---

Verilənlər bazası

Aşağıdakı cədvəllər mövcuddur:

* Cities
* CurrentWeather
* DailyForecast
* HourlyData

Hər cədvəl city_id vasitəsilə əlaqələndirilib.

---

API Endpoint

GET /api/weather

Şəhər adına görə hava məlumatlarını qaytarır.

Query Parameter:

* city (string, required)

Nümunə request:


GET /api/weather?city=Baku


Uğurlu cavab (200):

json
{
  "success": true,
  "message": "OK",
  "data": {
    "city": {
      "name": "Baku",
      "country_code": "AZ",
      "country_name": "Azerbaijan"
    },
    "current": {
      "temperature": 28,
      "feels_like": 30,
      "wind_speed": 12.5,
      "wind_direction": "NE",
      "pressure": 1012,
      "humidity": 55,
      "uv_index": 7.2,
      "visibility_km": 10,
      "visibility_condition": "Clear",
      "dew_point": 18,
      "sunrise_time": "05:22:00",
      "sunset_time": "20:11:00",
      "weather_description": "Clear Sky",
      "weather_icon": "01d",
      "recorded_at": "2026-06-04T14:00:00"
    },
    "weekly_forecast": [],
    "hourly": []
  }
}

Xəta cavabları:

400 Bad Request


city parameter is required


404 Not Found


City not found


---

Swagger

Swagger UI vasitəsilə API test edilə bilər:


https://localhost:7086/docs


---

Müəllif

Ad: Nail Rasulov
GitHub: https://github.com/Nail2005
LinkedIn: www.linkedin.com/in/nail-rasulov-614ab8297
