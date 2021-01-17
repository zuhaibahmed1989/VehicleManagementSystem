using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VehiceManagementSystem.Application.Services;
using VehicleManagementSystem.Application.Dtos;

namespace VehicleManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            this._carService = carService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] CreateCarDto createCarDto)
        {
            try
            {
                await _carService.CreateAsync(createCarDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}