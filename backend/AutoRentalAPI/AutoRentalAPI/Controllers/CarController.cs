using AutoRentalAPI.DTOs;
using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carsRepository;

        public CarController(ICarRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {
            var cars = await _carsRepository.GetAllCarsAsync();
            var carDtos = cars.Select(car => new CarDto
            {
                CarId = car.CarId,
                Model = car.Model,
                YearOfManufacture = car.YearOfManufacture,
                Color = car.Color,
                Condition = car.Condition,
                PricePerDay = car.PricePerDay,
                Availability = car.Availability,
                CarTypeId = car.CarTypeId
            });
            return Ok(carDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCar(int id)
        {
            var car = await _carsRepository.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var carDto = new CarDto
            {
                CarId = car.CarId,
                Model = car.Model,
                YearOfManufacture = car.YearOfManufacture,
                Color = car.Color,
                Condition = car.Condition,
                PricePerDay = car.PricePerDay,
                Availability = car.Availability,
                CarTypeId = car.CarTypeId
            };
            return Ok(carDto);
        }

        [HttpPost]
        public async Task<ActionResult<CarDto>> CreateCar(CarDto carDto)
        {
            var car = new Car
            {
                Model = carDto.Model,
                YearOfManufacture = carDto.YearOfManufacture,
                Color = carDto.Color,
                Condition = carDto.Condition,
                PricePerDay = carDto.PricePerDay,
                Availability = carDto.Availability,
                CarTypeId = carDto.CarTypeId
            };
            await _carsRepository.CreateCarAsync(car);
            return CreatedAtAction(nameof(GetCar), new { id = carDto.CarId }, carDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, CarDto carDto)
        {
            if (id != carDto.CarId)
            {
                return BadRequest();
            }

            var car = new Car
            {
                CarId = carDto.CarId,
                Model = carDto.Model,
                YearOfManufacture = carDto.YearOfManufacture,
                Color = carDto.Color,
                Condition = carDto.Condition,
                PricePerDay = carDto.PricePerDay,
                Availability = carDto.Availability,
                CarTypeId = carDto.CarTypeId
            };
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
