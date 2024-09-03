using CreditSimulationApp.DAL.Models;

namespace CreditSimulationApp.BLL.Repositories
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task AddClienteAsync(Cliente cliente);
        Task RemoveClienteAsync(int id);
    }
}
