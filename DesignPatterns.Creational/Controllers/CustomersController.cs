using DesignPatterns.Infrastructure.Proxies;
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
    }
}
