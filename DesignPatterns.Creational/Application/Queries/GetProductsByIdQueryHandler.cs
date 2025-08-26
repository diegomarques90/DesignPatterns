using DesignPatterns.Application.Models;

namespace DesignPatterns.Application.Queries
{
    public class GetProductsByIdQueryHandler
    {
        public Task<ProductDetailsViewModel> Handle(GetProductByIdQuery query)
        {
            return Task.FromResult(new ProductDetailsViewModel());
        }
    }
}
