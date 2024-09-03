using AutoMapper;
using CreditSimulationApp.BLL.DTOs;
using CreditSimulationApp.BLL.Services;
using CreditSimulationApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreditSimulationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        private readonly ICreditoService _creditoService;
        private readonly IMapper _mapper;

        public CreditoController(ICreditoService creditoService, IMapper mapper)
        {
            _creditoService = creditoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditoDTO>>> GetCreditos()
        {
            var creditos = await _creditoService.GetCreditosAsync();
            var creditosDTO = _mapper.Map<IEnumerable<CreditoDTO>>(creditos);
            return Ok(creditosDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreditoDTO>> GetCredito(int id)
        {
            var credito = await _creditoService.GetCreditoByIdAsync(id);
            if (credito == null)
            {
                return NotFound();
            }
            var creditoDTO = _mapper.Map<CreditoDTO>(credito);
            return Ok(creditoDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddCredito(CreditoDTO creditoDTO)
        {           

            var credito = _mapper.Map<CreditoDTO>(creditoDTO);
            await _creditoService.AddCreditoAsync(credito);
            return CreatedAtAction(nameof(GetCredito), new { id = credito.Id }, creditoDTO);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCredito(int id)
        {
            var credito = await _creditoService.GetCreditoByIdAsync(id);
            if (credito == null)
            {
                return NotFound();
            }
            await _creditoService.RemoveCreditoAsync(id);
            return NoContent();
        }
    }
}
