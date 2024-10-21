using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalContractsController : ControllerBase
    {
        private readonly IRentalContractRepository _contractsRepository;

        public RentalContractsController(IRentalContractRepository contractsRepository)
        {
            _contractsRepository = contractsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalContract>>> GetContracts()
        {
            var contracts = await _contractsRepository.GetAllContractsAsync();
            return Ok(contracts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentalContract>> GetContract(int id)
        {
            var contract = await _contractsRepository.GetContractByIdAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok(contract);
        }

        [HttpPost]
        public async Task<ActionResult<RentalContract>> CreateContract(RentalContract contract)
        {
            await _contractsRepository.CreateContractAsync(contract);
            return CreatedAtAction(nameof(GetContract), new { id = contract.ContractId }, contract);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContract(int id, RentalContract contract)
        {
            if (id != contract.ContractId)
            {
                return BadRequest();
            }
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
