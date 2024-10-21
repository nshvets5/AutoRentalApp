using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalServicesController : ControllerBase
    {
        private readonly IAdditionalServiceRepository _additionalServicesRepository;

        public AdditionalServicesController(IAdditionalServiceRepository additionalServicesRepository)
        {
            _additionalServicesRepository = additionalServicesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdditionalService>>> GetAdditionalServices()
        {
            var additionalServices = await _additionalServicesRepository.GetAllAdditionalServicesAsync();
            return Ok(additionalServices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdditionalService>> GetAdditionalService(int id)
        {
            var additionalService = await _additionalServicesRepository.GetAdditionalServiceByIdAsync(id);
            if (additionalService == null)
            {
                return NotFound();
            }
            return Ok(additionalService);
        }

        [HttpPost]
        public async Task<ActionResult<AdditionalService>> CreateAdditionalService(AdditionalService additionalService)
        {
            await _additionalServicesRepository.CreateAdditionalServiceAsync(additionalService);
            return CreatedAtAction(nameof(GetAdditionalService), new { id = additionalService.ServiceId }, additionalService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdditionalService(int id, AdditionalService additionalService)
        {
            if (id != additionalService.ServiceId)
            {
                return BadRequest();
            }
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
