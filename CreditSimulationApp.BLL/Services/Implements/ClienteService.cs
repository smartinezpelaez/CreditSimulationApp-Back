using AutoMapper;
using CreditSimulationApp.BLL.DTOs;
using CreditSimulationApp.BLL.Repositories;
using CreditSimulationApp.DAL.Models;

namespace CreditSimulationApp.BLL.Services.Implements
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientesAsync()
        {
            var clientes = await _clienteRepository.GetClientesAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        public async Task<ClienteDTO> GetClienteByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task AddClienteAsync(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            await _clienteRepository.AddClienteAsync(cliente);
        }

        public async Task RemoveClienteAsync(int id)
        {
            await _clienteRepository.RemoveClienteAsync(id);
        }
    }
}
