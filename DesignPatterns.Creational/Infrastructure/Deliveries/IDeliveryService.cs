using DesignPatterns.Creational.Application.Models;

namespace DesignPatterns.Creational.Infrastructure.Deliveries
{
    public interface IDeliveryService
    {
        void Deliver(OrderInputModel model);
    }
}
