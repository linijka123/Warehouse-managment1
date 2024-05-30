using Magazyn.Data;
using Magazyn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity;

namespace Magazyn.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string employeeName)
        {
            var existingEmployee = _context.employees.FirstOrDefault(e => e.Name == employeeName);

            if (existingEmployee != null)
            {
                return RedirectToAction("NextPage", 
                                        new { employeeId = existingEmployee.EmployeeId
                                       , employeeName = existingEmployee.Name });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Employee not found.");
                return View();
            }
        }

        public IActionResult NextPage(int employeeId, string employeeName)
        {
            ViewBag.EmployeeId = employeeId;
            ViewBag.EmployeeName = employeeName;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NextPage(string productName, int employeeId, string employeeName)
        {
            if (!string.IsNullOrEmpty(productName))
            {
                var product = new Product
                {
                    Name = productName,
                    EmployeeId = employeeId
                };

                _context.products.Add(product);
                _context.SaveChanges();

                ViewBag.EmployeeId = employeeId;
                ViewBag.EmployeeName = employeeName;

                return RedirectToAction("NextPage", new { employeeId = employeeId, employeeName = employeeName });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Product name cannot be empty.");
                return View();
            }
        }
    }
}
