using CreditSimulationApp.BLL.DTOs;

namespace CreditSimulationApp.BLL.Services
{
    public interface ICreditoService 
    {
        Task<IEnumerable<CreditoDTO>> GetCreditosAsync();
        Task<CreditoDTO> GetCreditoByIdAsync(int id);
        Task AddCreditoAsync(CreditoDTO creditoDTO);
        Task RemoveCreditoAsync(int id);

    }
}
