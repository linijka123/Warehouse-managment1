using Magazyn.Data;
using Magazyn.Data.Interfaces;
using Magazyn.Models;
using Microsoft.EntityFrameworkCore;


namespace Magazyn.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
