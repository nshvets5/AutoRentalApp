using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypesController : ControllerBase
    {
        private readonly ICarTypeRepository _carTypeRepository;

        public CarTypesController(ICarTypeRepository carTypeRepository)
        {
            _carTypeRepository = carTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarType>>> GetCarTypes()
        {
            var carTypes = await _carTypeRepository.GetAllCarTypesAsync();
            return Ok(carTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarType>> GetCarType(int id)
        {
            var carType = await _carTypeRepository.GetCarTypeByIdAsync(id);
            if (carType == null)
            {
                return NotFound();
            }
            return Ok(carType);
        }

        [HttpPost]
        public async Task<ActionResult<CarType>> CreateCarType(CarType carType)
        {
            await _carTypeRepository.CreateCarTypeAsync(carType);
            return CreatedAtAction(nameof(GetCarType), new { id = carType.CarTypeId }, carType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarType(int id, CarType carType)
        {
            if (id != carType.CarTypeId)
            {
                return BadRequest();
            }
            await _carTypeRepository.UpdateCarTypeAsync(carType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarType(int id)
        {
            await _carTypeRepository.DeleteCarTypeAsync(id);
            return NoContent();
        }
    }
}
