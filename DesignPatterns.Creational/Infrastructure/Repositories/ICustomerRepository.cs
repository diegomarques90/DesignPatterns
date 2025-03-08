using DesignPatterns.Core.Entities;

namespace DesignPatterns.Infrastructure.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetBlockedCustomers();
    }
}
