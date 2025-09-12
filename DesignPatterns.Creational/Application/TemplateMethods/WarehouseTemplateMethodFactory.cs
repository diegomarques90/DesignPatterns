using DesignPatterns.Application.Models;

namespace DesignPatterns.Application.TemplateMethods
{
    public class WarehouseTemplateMethodFactory : IWarehouseTemplateMethodFactory
    {
        public WarehouseTemplateMethod Create(OrderInputModel model)
        {
            if (model.IsExternal)
            {
                return new WarehouseExternalService(model);
            }
            else
            {
                return new WarehouseInternalService(model);
            }
        }
    }
}
