using CreditSimulationApp.BLL.DTOs;
using CreditSimulationApp.DAL.Models;

namespace CreditSimulationApp.BLL.Repositories
{
    public interface ICreditoRepository: IGenericRepository<Credito>
    {
        Task<IEnumerable<Credito>> GetCreditosAsync();
        Task<Credito> GetCreditoByIdAsync(int id);
        Task AddCreditoAsync(Credito credito);
        Task RemoveCreditoAsync(int id);
        
    }
}
