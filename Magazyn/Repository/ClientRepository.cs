using Magazyn.Data;
using Magazyn.Data.Interfaces;
using Magazyn.Models;
using Microsoft.EntityFrameworkCore;

namespace Magazyn.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDBContext _context;
        public ClientRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Client> GetAsync(int id)
        {
            return await _context.clients
                                 .Include(c => c.Purchases)
                                 .ThenInclude(c => c.Product)
                                 .FirstOrDefaultAsync(c => c.ClientId == id);
        }


    }
}
