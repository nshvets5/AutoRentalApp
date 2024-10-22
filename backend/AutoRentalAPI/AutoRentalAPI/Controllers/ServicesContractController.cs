using AutoRentalAPI.DTOs;
using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesContractController : ControllerBase
    {
        private readonly IServicesContractRepository _servicesContractsRepository;

        public ServicesContractController(IServicesContractRepository servicesContractsRepository)
        {
            _servicesContractsRepository = servicesContractsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicesContractDto>>> GetServicesContracts()
        {
            var servicesContracts = await _servicesContractsRepository.GetAllServicesContractsAsync();
            var servicesContractDtos = servicesContracts.Select(contract => new ServicesContractDto
            {
                ServiceContractId = contract.ServiceContractId,
                ContractId = contract.ContractId,
                ServiceId = contract.ServiceId
            });
            return Ok(servicesContractDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServicesContractDto>> GetServicesContract(int id)
        {
            var servicesContract = await _servicesContractsRepository.GetServicesContractByIdAsync(id);
            if (servicesContract == null)
            {
                return NotFound();
            }
            var servicesContractDto = new ServicesContractDto
            {
                ServiceContractId = servicesContract.ServiceContractId,
                ContractId = servicesContract.ContractId,
                ServiceId = servicesContract.ServiceId
            };
            return Ok(servicesContractDto);
        }

        [HttpPost]
        public async Task<ActionResult<ServicesContractDto>> CreateServicesContract(ServicesContractDto servicesContractDto)
        {
            var servicesContract = new ServicesContract
            {
                ContractId = servicesContractDto.ContractId,
                ServiceId = servicesContractDto.ServiceId
            };
            await _servicesContractsRepository.CreateServicesContractAsync(servicesContract);
            servicesContractDto.ServiceContractId = servicesContract.ServiceContractId;
            return CreatedAtAction(nameof(GetServicesContract), new { id = servicesContractDto.ServiceContractId }, servicesContractDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServicesContract(int id, ServicesContractDto servicesContractDto)
        {
            if (id != servicesContractDto.ServiceContractId)
            {
                return BadRequest();
            }

            var servicesContract = new ServicesContract
            {
                ServiceContractId = servicesContractDto.ServiceContractId,
                ContractId = servicesContractDto.ContractId,
                ServiceId = servicesContractDto.ServiceId
            };
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
