using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Models.Dtos;
using WeatherAPI.Services.Abstract;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _service;

        public WeatherController(IWeatherService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather([FromQuery] RequestDto dto)
        {
            if(string.IsNullOrWhiteSpace(dto.City))
            {
                return BadRequest(new ResponseDto
                {
                    Success = false,
                    Message = "City name is required."
                });
            }

            var data = await _service.GetWeatherAsync(dto);       

            if(data == null)
            {
                return NotFound(new ResponseDto
                {
                    Success = false,
                    Message = $"Weather data for city '{dto.City}' not found."
                });
            }

            var result = new ResponseDto
            {
                Success = true,
                Message = "Ok",
                Data = data
            };

            return Ok(result);
        }
    }
}
