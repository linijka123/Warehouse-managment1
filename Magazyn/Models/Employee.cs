namespace Magazyn.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public ICollection<Product> AddedProducts { get; set; }
    }
}
