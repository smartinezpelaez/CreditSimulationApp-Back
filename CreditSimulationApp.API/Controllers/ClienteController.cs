using AutoMapper;
using CreditSimulationApp.BLL.DTOs;
using CreditSimulationApp.BLL.Services;
using CreditSimulationApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreditSimulationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
        {
            var clientes = await _clienteService.GetClientesAsync();
            var clientesDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            return Ok(clientesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            var clienteDTO = _mapper.Map<ClienteDTO>(cliente);
            return Ok(clienteDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddCliente(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<ClienteDTO>(clienteDTO);
            await _clienteService.AddClienteAsync(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, clienteDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            await _clienteService.RemoveClienteAsync(id);
            return NoContent();
        }
    }
}
