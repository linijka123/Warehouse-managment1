namespace Magazyn.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public ICollection<Purchase> Purchases { get; set; } // Relacja many-to-many z pomocniczą tabelą Purchase
    }
}
