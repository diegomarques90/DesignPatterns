using DesignPatterns.Application.Models;
using DesignPatterns.Infrastructure.Products;
using System.Collections;

namespace DesignPatterns.Application.ChainOfResponsibility
{
    public class ValidateStockHandler : OrderHandlerBase, IOrderHandler
    {
        private readonly IProductRepository _productRepository;

        public ValidateStockHandler(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public override bool Handle(OrderInputModel model)
        {
            Console.WriteLine("Invoking ValidadeStockHandler.Handle");

            var itemsDictionary = model.Items.ToDictionary(d => d.ProductId, d => d.Quantity);
            var hasStock = _productRepository.HasStock(itemsDictionary);

            if (!hasStock)
                return false;

            return base.Handle(model);
        }

    }
}
