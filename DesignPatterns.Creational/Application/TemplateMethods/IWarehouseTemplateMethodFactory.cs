using DesignPatterns.Application.Models;

namespace DesignPatterns.Application.TemplateMethods
{
    public interface IWarehouseTemplateMethodFactory
    {
        WarehouseTemplateMethod Create(OrderInputModel model);
    }
}
