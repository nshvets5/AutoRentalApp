using AutoRentalAPI.DTOs;
using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalServiceController : ControllerBase
    {
        private readonly IAdditionalServiceRepository _additionalServicesRepository;

        public AdditionalServiceController(IAdditionalServiceRepository additionalServicesRepository)
        {
            _additionalServicesRepository = additionalServicesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdditionalServiceDto>>> GetAdditionalServices()
        {
            var additionalServices = await _additionalServicesRepository.GetAllAdditionalServicesAsync();
            var additionalServiceDtos = additionalServices.Select(service => new AdditionalServiceDto
            {
                ServiceId = service.ServiceId,
                Name = service.Name,
                Description = service.Description,
                PricePerDay = service.PricePerDay
            });
            return Ok(additionalServiceDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdditionalServiceDto>> GetAdditionalService(int id)
        {
            var additionalService = await _additionalServicesRepository.GetAdditionalServiceByIdAsync(id);
            if (additionalService == null)
            {
                return NotFound();
            }
            var additionalServiceDto = new AdditionalServiceDto
            {
                ServiceId = additionalService.ServiceId,
                Name = additionalService.Name,
                Description = additionalService.Description,
                PricePerDay = additionalService.PricePerDay
            };
            return Ok(additionalServiceDto);
        }

        [HttpPost]
        public async Task<ActionResult<AdditionalServiceDto>> CreateAdditionalService(AdditionalServiceDto additionalServiceDto)
        {
            var additionalService = new AdditionalService
            {
                Name = additionalServiceDto.Name,
                Description = additionalServiceDto.Description,
                PricePerDay = additionalServiceDto.PricePerDay
            };
            await _additionalServicesRepository.CreateAdditionalServiceAsync(additionalService);
            return CreatedAtAction(nameof(GetAdditionalService), new { id = additionalServiceDto.ServiceId }, additionalServiceDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdditionalService(int id, AdditionalServiceDto additionalServiceDto)
        {
            if (id != additionalServiceDto.ServiceId)
            {
                return BadRequest();
            }

            var additionalService = new AdditionalService
            {
                ServiceId = additionalServiceDto.ServiceId,
                Name = additionalServiceDto.Name,
                Description = additionalServiceDto.Description,
                PricePerDay = additionalServiceDto.PricePerDay
            };
            await _additionalServicesRepository.UpdateAdditionalServiceAsync(additionalService);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdditionalService(int id)
        {
            await _additionalServicesRepository.DeleteAdditionalServiceAsync(id);
            return NoContent();
        }
    }
}
