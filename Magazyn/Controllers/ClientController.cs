using Magazyn.Data;
using Magazyn.Data.Interfaces;
using Magazyn.Models;
using Magazyn.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Magazyn.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IClientRepository _clientRepository;

        public ClientController(ApplicationDBContext context, IClientRepository clientRepository)
        {
            _context = context;
            _clientRepository = clientRepository;
        }
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToPurchase(int clientId, int productId)
        {           
                var purchase = new Purchase
                {
                    ClientId = clientId,
                    ProductId = productId
                };

                _context.purchases.Add(purchase);
                _context.SaveChanges();

                return RedirectToAction("ClientDetails", new { clientId = clientId });
     
        }

        [HttpGet]
        public IActionResult LoginId()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginId(int id)
        {
            var client = await _clientRepository.GetAsync(id);

            if (client == null)
            {
                ModelState.AddModelError(string.Empty, "Client not found.");
            }

            return View(client);

        }

        [HttpPost]
        public IActionResult AddClient(string clientName)
        {
            if (!string.IsNullOrEmpty(clientName))
            {
                var client = new Client
                {
                    Name = clientName
                };

                _context.clients.Add(client);
                _context.SaveChanges();

                return RedirectToAction("ClientDetails", "Client", new { clientId = client.ClientId, clientName = client.Name });

            }

            return RedirectToAction("Index", "Home");
        }
        public IActionResult ClientDetails(int clientId, string clientName)
        {
            var products = _context.products.ToList();

            ViewData["ClientId"] = clientId;
            ViewData["ClientName"] = clientName;
            ViewData["Products"] = products;
             
            return View();
        }


    }
}
