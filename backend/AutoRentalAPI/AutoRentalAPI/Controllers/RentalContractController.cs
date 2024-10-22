using AutoRentalAPI.DTOs;
using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalContractController : ControllerBase
    {
        private readonly IRentalContractRepository _contractsRepository;

        public RentalContractController(IRentalContractRepository contractsRepository)
        {
            _contractsRepository = contractsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalContractDto>>> GetContracts()
        {
            var contracts = await _contractsRepository.GetAllContractsAsync();
            var contractDtos = contracts.Select(contract => new RentalContractDto
            {
                ContractId = contract.ContractId,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate,
                TotalAmount = contract.TotalAmount,
                Status = contract.Status,
                ClientId = contract.ClientId,
                CarId = contract.CarId
            });
            return Ok(contractDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentalContractDto>> GetContract(int id)
        {
            var contract = await _contractsRepository.GetContractByIdAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            var contractDto = new RentalContractDto
            {
                ContractId = contract.ContractId,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate,
                TotalAmount = contract.TotalAmount,
                Status = contract.Status,
                ClientId = contract.ClientId,
                CarId = contract.CarId
            };
            return Ok(contractDto);
        }

        [HttpPost]
        public async Task<ActionResult<RentalContractDto>> CreateContract(RentalContractDto contractDto)
        {
            var contract = new RentalContract
            {
                StartDate = contractDto.StartDate,
                EndDate = contractDto.EndDate,
                TotalAmount = contractDto.TotalAmount,
                Status = contractDto.Status,
                ClientId = contractDto.ClientId,
                CarId = contractDto.CarId
            };
            await _contractsRepository.CreateContractAsync(contract);
            return CreatedAtAction(nameof(GetContract), new { id = contractDto.ContractId }, contractDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContract(int id, RentalContractDto contractDto)
        {
            if (id != contractDto.ContractId)
            {
                return BadRequest();
            }

            var contract = new RentalContract
            {
                ContractId = contractDto.ContractId,
                StartDate = contractDto.StartDate,
                EndDate = contractDto.EndDate,
                TotalAmount = contractDto.TotalAmount,
                Status = contractDto.Status,
                ClientId = contractDto.ClientId,
                CarId = contractDto.CarId
            };
            await _contractsRepository.UpdateContractAsync(contract);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            await _contractsRepository.DeleteContractAsync(id);
            return NoContent();
        }
    }
}
