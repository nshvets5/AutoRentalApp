using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carsRepository;

        public CarsController(ICarRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var cars = await _carsRepository.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _carsRepository.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar(Car car)
        {
            await _carsRepository.CreateCarAsync(car);
            return CreatedAtAction(nameof(GetCar), new { id = car.CarId }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, Car car)
        {
            if (id != car.CarId)
            {
                return BadRequest();
            }
            await _carsRepository.UpdateCarAsync(car);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carsRepository.DeleteCarAsync(id);
            return NoContent();
        }
    }
}
