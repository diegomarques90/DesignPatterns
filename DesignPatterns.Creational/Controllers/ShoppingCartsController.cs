using DesignPatterns.Application.Mementos;
using DesignPatterns.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    [ApiController]
    [Route("api/shopping-carts")]
    public class ShoppingCartsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Save(ShoppingCartInputModel model)
        {
            var originator = new ShoppingCartOriginator(model.CustomerId, model.Items);
            var shoppingCartCareTaker = new ShoppingCartCareTaker(originator);


            model.Items.Add(new OrderItemInputModel { ProductId = new Guid("4396d247-4cc4-49e7-9b01-cef5210351cf"), Quantity = 1 });
            shoppingCartCareTaker.Backup();
            shoppingCartCareTaker._originator.UpdateCart(model.Items);

            model.Items.Add(new OrderItemInputModel { ProductId = new Guid("9e6cff10-5478-4367-9123-23545d8a9c6f"), Quantity = 1 });

            shoppingCartCareTaker.Backup();
            shoppingCartCareTaker._originator.UpdateCart(model.Items);

            model.Items.Add(new OrderItemInputModel { ProductId = new Guid("6d7fd316-96a9-4c02-9862-430c1a36be70"), Quantity = 1 });

            shoppingCartCareTaker.Backup();
            shoppingCartCareTaker._originator.UpdateCart(model.Items);


            shoppingCartCareTaker.Backup();
            shoppingCartCareTaker.PrintHistory();

            shoppingCartCareTaker.Undo();
            return NoContent();
        }
    }

    public class ShoppingCartInputModel
    {
        public Guid CustomerId { get; set; }
        public List<OrderItemInputModel> Items { get; set; }
    }
}
