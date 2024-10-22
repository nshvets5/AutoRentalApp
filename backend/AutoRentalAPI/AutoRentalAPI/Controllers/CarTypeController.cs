using AutoRentalAPI.DTOs;
using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypeController : ControllerBase
    {
        private readonly ICarTypeRepository _carTypeRepository;

        public CarTypeController(ICarTypeRepository carTypeRepository)
        {
            _carTypeRepository = carTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarTypeDto>>> GetCarTypes()
        {
            var carTypes = await _carTypeRepository.GetAllCarTypesAsync();
            var carTypeDtos = carTypes.Select(carType => new CarTypeDto
            {
                CarTypeId = carType.CarTypeId,
                Category = carType.Category,
                BodyType = carType.BodyType,
                SeatingCapacity = carType.SeatingCapacity,
                Brand = carType.Brand
            });
            return Ok(carTypeDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarTypeDto>> GetCarType(int id)
        {
            var carType = await _carTypeRepository.GetCarTypeByIdAsync(id);
            if (carType == null)
            {
                return NotFound();
            }
            var carTypeDto = new CarTypeDto
            {
                CarTypeId = carType.CarTypeId,
                Category = carType.Category,
                BodyType = carType.BodyType,
                SeatingCapacity = carType.SeatingCapacity,
                Brand = carType.Brand
            };
            return Ok(carTypeDto);
        }

        [HttpPost]
        public async Task<ActionResult<CarTypeDto>> CreateCarType(CarTypeDto carTypeDto)
        {
            var carType = new CarType
            {
                Category = carTypeDto.Category,
                BodyType = carTypeDto.BodyType,
                SeatingCapacity = carTypeDto.SeatingCapacity,
                Brand = carTypeDto.Brand
            };
            await _carTypeRepository.CreateCarTypeAsync(carType);
            return CreatedAtAction(nameof(GetCarType), new { id = carType.CarTypeId }, carTypeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarType(int id, CarTypeDto carTypeDto)
        {
            if (id != carTypeDto.CarTypeId)
            {
                return BadRequest();
            }

            var carType = new CarType
            {
                CarTypeId = carTypeDto.CarTypeId,
                Category = carTypeDto.Category,
                BodyType = carTypeDto.BodyType,
                SeatingCapacity = carTypeDto.SeatingCapacity,
                Brand = carTypeDto.Brand
            };
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
