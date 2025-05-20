using DesignPatterns.Application.Models;
using DesignPatterns.Infrastructure.Repositories;

namespace DesignPatterns.Application.ChainOfResponsibility
{
    public class ValidateCustomerHandler : OrderHandlerBase, IOrderHandler
    {
        private readonly ICustomerRepository _repository;
        
        public ValidateCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public override bool Handle(OrderInputModel model)
        {
            Console.WriteLine("Invoking ValidateCustomerHandler.Handle");

            var customer = _repository.GetCustomerById(model.Customer.Id);

            if (customer is null)
                return false;

            var customerAllowedToBuy = customer.IsAllowedToBuy();
            
            if (!customerAllowedToBuy)
                return false;

            return base.Handle(model);
        }
    }
}
