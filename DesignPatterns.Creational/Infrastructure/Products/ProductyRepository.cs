
namespace DesignPatterns.Infrastructure.Products
{
    public class ProductyRepository : IProductRepository
    {
        public bool HasStock(Dictionary<Guid, int> items)
        {
            return true;
        }
    }
}
