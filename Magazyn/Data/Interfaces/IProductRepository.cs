using Magazyn.Models;

namespace Magazyn.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();

    }
}
