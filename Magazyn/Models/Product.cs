namespace Magazyn.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? EmployeeId { get; set; } // Klucz obcy dla pracownika, który dodał produkt
        public Employee Employee { get; set; } // Navigation property
    }
}
