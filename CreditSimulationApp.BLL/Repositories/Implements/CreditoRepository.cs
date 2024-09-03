using CreditSimulationApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditSimulationApp.BLL.Repositories.Implements
{
    public class CreditoRepository : GenericRepository<Credito>, ICreditoRepository
    {
        private readonly CreditSimulationDbContext _context;

        public CreditoRepository(CreditSimulationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Credito>> GetCreditosAsync()
        {
            return await _context.Creditos.Include(c => c.Cliente).ToListAsync();
        }

        public async Task<Credito> GetCreditoByIdAsync(int id)
        {
            var credito = await _context.Creditos.Include(c => c.Cliente)
                                           .FirstOrDefaultAsync( c => c.Id == id) ?? throw new Exception("Credito no encontrado");

            return credito;
        }

        public async Task AddCreditoAsync(Credito credito)
        {
            await AddAsync(credito);
        }

        public async Task RemoveCreditoAsync(int id)
        {
            await DeleteAsync(id);
        }
    }
}
