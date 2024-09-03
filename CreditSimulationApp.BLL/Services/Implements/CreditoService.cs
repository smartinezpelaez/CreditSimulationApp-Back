using AutoMapper;
using CreditSimulationApp.BLL.DTOs;
using CreditSimulationApp.BLL.Repositories;
using CreditSimulationApp.DAL.Models;

namespace CreditSimulationApp.BLL.Services.Implements
{
    public class CreditoService : ICreditoService
    {
        private readonly ICreditoRepository _creditoRepository;
        private readonly IMapper _mapper;

        public CreditoService(ICreditoRepository creditoRepository, IMapper mapper)
        {
            _creditoRepository = creditoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CreditoDTO>> GetCreditosAsync()
        {
            var creditos = await _creditoRepository.GetCreditosAsync();
            return _mapper.Map<IEnumerable<CreditoDTO>>(creditos);
        }

        public async Task<CreditoDTO> GetCreditoByIdAsync(int id)
        {
            var credito = await _creditoRepository.GetCreditoByIdAsync(id);
            return _mapper.Map<CreditoDTO>(credito);
        }

        public async Task AddCreditoAsync(CreditoDTO creditoDTO)
        {
            var credito = _mapper.Map<Credito>(creditoDTO);
            await _creditoRepository.AddCreditoAsync(credito);
        }

        public async Task RemoveCreditoAsync(int id)
        {
            await _creditoRepository.RemoveCreditoAsync(id);
        }
    }
}
