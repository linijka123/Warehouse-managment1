using Magazyn.Models;

namespace Magazyn.Data.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> GetAsync(int id);
    }
}
