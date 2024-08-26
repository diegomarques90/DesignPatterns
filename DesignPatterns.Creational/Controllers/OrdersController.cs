using DesignPatterns.Creational.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Creational.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        [Route("withoutFactoryMethod")]
        public IActionResult PostWithoutFactoryMethod(OrderInputModel inputModel)
        {

            return NoContent();
        }


        [HttpPost]
        [Route("withFactoryMethod")]
        public IActionResult PostWithFactoryMethod(OrderInputModel inputModel)
        {

            return NoContent();
        }
    }
}
