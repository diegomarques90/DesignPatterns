using DesignPatterns.Application.Models;

namespace DesignPatterns.Infrastructure.Deliveries
{
    public interface IDeliveryService
    {
        void Deliver(OrderInputModel model);
    }
}
