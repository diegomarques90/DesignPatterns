using DesignPatterns.Application.Models;

namespace DesignPatterns.Infrastructure.Orders.Models
{
    public class OrderBuilder
    {
        private readonly OrderInputModel _orderInputModel;
        
        public OrderBuilder() 
        {
            _orderInputModel = new OrderInputModel(Guid.NewGuid());    
        }

        public OrderBuilder WithCustomer()
        {
            _orderInputModel.Customer = new CustomerInputModel()
            {
                Id = Guid.NewGuid(),
                FullName = "Customer Full Name",
                Email = "customer@email.com.br",
                Document = "0121451444"
            };

            return this;
        }

        public OrderBuilder WithItems()
        {
            _orderInputModel.Items.AddRange(
            [
                new OrderItemInputModel { Price = 100, ProductId = Guid.NewGuid(), Quantity = 2 },
                new OrderItemInputModel { Price = 30, ProductId = Guid.NewGuid(), Quantity = 3 },
            ]);

            return this;
        }

        public OrderBuilder IsInternational(bool isInternational)
        {
            _orderInputModel.IsInternational = isInternational;

            return this;
        }

        public OrderInputModel Build() => _orderInputModel;
    }
}
