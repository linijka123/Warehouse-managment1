namespace Magazyn.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
