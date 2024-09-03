using CreditSimulationApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditSimulationApp.BLL.Repositories.Implements
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        private readonly CreditSimulationDbContext _context;

        public ClienteRepository(CreditSimulationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _context.Clientes.Include(c => c.Creditos).ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            var cliente = await _context.Clientes.Include(c => c.Creditos)
                                                 .FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception("Cliente no encontrado");
            return cliente;
        }


        public async Task AddClienteAsync(Cliente cliente)
        {
            await AddAsync(cliente);
        }

        public async Task RemoveClienteAsync(int id)
        {
            await DeleteAsync(id);
        }
       
    }
}
