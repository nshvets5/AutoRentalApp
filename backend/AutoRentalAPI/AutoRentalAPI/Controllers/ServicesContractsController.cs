using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesContractsController : ControllerBase
    {
        private readonly IServicesContractRepository _servicesContractsRepository;

        public ServicesContractsController(IServicesContractRepository servicesContractsRepository)
        {
            _servicesContractsRepository = servicesContractsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicesContract>>> GetServicesContracts()
        {
            var servicesContracts = await _servicesContractsRepository.GetAllServicesContractsAsync();
            return Ok(servicesContracts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServicesContract>> GetServicesContract(int id)
        {
            var servicesContract = await _servicesContractsRepository.GetServicesContractByIdAsync(id);
            if (servicesContract == null)
            {
                return NotFound();
            }
            return Ok(servicesContract);
        }

        [HttpPost]
        public async Task<ActionResult<ServicesContract>> CreateServicesContract(ServicesContract servicesContract)
        {
            await _servicesContractsRepository.CreateServicesContractAsync(servicesContract);
            return CreatedAtAction(nameof(GetServicesContract), new { id = servicesContract.ServiceContractId }, servicesContract);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServicesContract(int id, ServicesContract servicesContract)
        {
            if (id != servicesContract.ServiceContractId)
            {
                return BadRequest();
            }
            await _servicesContractsRepository.UpdateServicesContractAsync(servicesContract);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicesContract(int id)
        {
            await _servicesContractsRepository.DeleteServicesContractAsync(id);
            return NoContent();
        }
    }
}
