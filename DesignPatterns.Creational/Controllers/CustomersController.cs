using DesignPatterns.Application.Models;
using DesignPatterns.Infrastructure.Proxies;
using DesignPatterns.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        [HttpGet("get-blocked-customers")]
        public IActionResult GetBlockedCustomers([FromServices] CustomerRepositoryProxy proxy)
        {
            var blockedCustomers = proxy.GetBlockedCustomers();

            if (blockedCustomers is null)
                return Unauthorized();

            return Ok(blockedCustomers);
        }

        [HttpGet("report-notify-blocked-customers")]
        public IActionResult NotifyBlockedCustomerEmail([FromServices] ICustomerRepository repository)
        {
            var blockedCustomers = repository.GetBlockedCustomers();

            var query = new CustomersToNotifyQueryModel(blockedCustomers, "DiegoAdm");

            foreach (var customer in query)
            {
                Console.WriteLine($"Customer: {customer.Key}, Email: {customer.Value}");
            }

            Console.WriteLine($"Utilizando acesso direto: {query["Fulano 1"]}");

            return Ok();
        }
    }
}
