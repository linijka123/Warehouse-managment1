using Magazyn.Models;
using Microsoft.EntityFrameworkCore;

namespace Magazyn.Data
{
    public class ApplicationDBContext : DbContext
    {

            public DbSet<Client> clients {  get; set; }
            public DbSet<Employee> employees { get; set; }
            public DbSet<Product> products { get; set; }
            public DbSet<Purchase> purchases { get; set; }

            public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
            {

            }
     
    }
}
