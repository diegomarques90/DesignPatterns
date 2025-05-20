using DesignPatterns.Core.Entities;
using DesignPatterns.Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace DesignPatterns.Infrastructure.Proxies
{
    public class CustomerRepositoryProxy : ICustomerRepository
    {
        private readonly ICustomerRepository _repository;
        private readonly IMemoryCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerRepositoryProxy(ICustomerRepository repository, IMemoryCache cache, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Customer> GetBlockedCustomers()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext is null)
                return null;

            if (httpContext.Request.Headers["x-role"] != "admin")
                return null;

            List<Customer> blockedCusstomers = _cache.GetOrCreate("blocked-customers", customers =>
            {
                return _repository.GetBlockedCustomers();
            });

            return blockedCusstomers;
        }

        public Customer GetCustomerById(Guid id)
        {
            return new Customer(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "CUSTOMER TEST", new DateTime(1999, 12, 21));
        }
    }
}
