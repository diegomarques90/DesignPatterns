using DesignPatterns.Application.Models;

namespace DesignPatterns.Infrastructure.Integrations
{
    public interface ICoreCrmIntegrationService
    {
        void Sync(OrderInputModel model);
    }
}
