using CreditSimulationApp.BLL.DTOs;
using CreditSimulationApp.DAL.Models;

namespace CreditSimulationApp.BLL.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetClientesAsync();
        Task<ClienteDTO> GetClienteByIdAsync(int id);
        Task AddClienteAsync(ClienteDTO clienteDTO);
        Task RemoveClienteAsync(int id);
        
    }
}
