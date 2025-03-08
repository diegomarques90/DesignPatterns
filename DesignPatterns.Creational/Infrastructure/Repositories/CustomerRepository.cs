using DesignPatterns.Core.Entities;

namespace DesignPatterns.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetBlockedCustomers()
        {
            return
            [
                new Customer("Fulano", DateTime.Now.AddYears(-20)),
                new Customer("Fulano", DateTime.Now.AddYears(-30)),
                new Customer("Fulano", DateTime.Now.AddYears(-40))
            ];
        }
    }
}
