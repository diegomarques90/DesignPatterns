using DesignPatterns.Core.Entities;

namespace DesignPatterns.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetBlockedCustomers()
        {
            return
            [
                new Customer(Guid.NewGuid(), "Fulano", DateTime.Now.AddYears(-20)),
                new Customer(Guid.NewGuid(), "Fulano", DateTime.Now.AddYears(-30)),
                new Customer(Guid.NewGuid(), "Fulano", DateTime.Now.AddYears(-40))
            ];
        }

        public Customer GetCustomerById(Guid id)
        {
            var customers = new List<Customer>
            {
                new Customer(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "Fulano TESTE", DateTime.Now.AddYears(-20)),
                new Customer(Guid.NewGuid(), "Fulano", DateTime.Now.AddYears(-30)),
                new Customer(Guid.NewGuid(), "Fulano", DateTime.Now.AddYears(-40))
            };

            return customers.FirstOrDefault(c => c.Id == id);
        }
    }
}
