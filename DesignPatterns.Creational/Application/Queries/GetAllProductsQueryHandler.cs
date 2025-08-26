using DesignPatterns.Application.Models;

namespace DesignPatterns.Application.Queries
{
    public class GetAllProductsQueryHandler
    {
        public Task<ProductViewModel> Handle(GetAllProductsQuery query)
        {
            return Task.FromResult(new ProductViewModel());
        }
    }
}
