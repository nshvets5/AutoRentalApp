using AutoRentalAPI.DTOs;
using AutoRentalAPI.Interfaces;
using AutoRentalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients()
        {
            var clients = await _clientRepository.GetAllClientsAsync();
            var clientDtos = clients.Select(client => new ClientDto
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                BirthDate = client.BirthDate,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Address = client.Adress
            });
            return Ok(clientDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetClient(int id)
        {
            var client = await _clientRepository.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            var clientDto = new ClientDto
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                BirthDate = client.BirthDate,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Address = client.Adress
            };
            return Ok(clientDto);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDto>> CreateClient(ClientDto clientDto)
        {
            var client = new Client
            {
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                BirthDate = clientDto.BirthDate,
                PhoneNumber = clientDto.PhoneNumber,
                Email = clientDto.Email,
                Adress = clientDto.Address
            };
            await _clientRepository.AddClientAsync(client);
            return CreatedAtAction(nameof(GetClient), new { id = client.ClientId }, clientDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, ClientDto clientDto)
        {
            if (id != clientDto.ClientId)
            {
                return BadRequest();
            }

            var client = new Client
            {
                ClientId = clientDto.ClientId,
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                BirthDate = clientDto.BirthDate,
                PhoneNumber = clientDto.PhoneNumber,
                Email = clientDto.Email,
                Adress = clientDto.Address
            };
            await _clientRepository.UpdateClientAsync(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientRepository.DeleteClientAsync(id);
            return NoContent();
        }
    }
}
